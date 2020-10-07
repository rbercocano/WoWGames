using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WowGames.Models;
using WowGames.Proxy;
using WowGames.Repositories;

namespace WowGames
{
    public partial class FrmEPay : MaterialSkin.Controls.MaterialForm
    {
        private static readonly object objLock = new object();
        private PurchaseRepository repository = new PurchaseRepository();
        private readonly EPayProxy proxy = new EPayProxy();
        public FrmEPay(string sku, string valor)
        {
            InitializeComponent();

            dgvCompras.AutoGenerateColumns = false;
            dgvCompras.AutoSize = false;
            dgvCompras.ReadOnly = true;
            dgvCompras.AllowUserToAddRows = false;
            dgvCompras.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCompras.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dgvCompras.ColumnCount = 6;
            dgvCompras.Columns[0].Visible = true;
            dgvCompras.Columns[0].HeaderText = "Data / Hora";
            dgvCompras.Columns[0].DataPropertyName = "PurchaseDate";

            dgvCompras.Columns[1].Visible = true;
            dgvCompras.Columns[1].HeaderText = "Montante";
            dgvCompras.Columns[1].DataPropertyName = "PaidPrice";

            dgvCompras.Columns[2].Visible = true;
            dgvCompras.Columns[2].HeaderText = "Transaçao";
            dgvCompras.Columns[2].DataPropertyName = "TransactionId";

            dgvCompras.Columns[3].Visible = true;
            dgvCompras.Columns[3].HeaderText = "PIN";
            dgvCompras.Columns[3].DataPropertyName = "Token";

            dgvCompras.Columns[4].Visible = true;
            dgvCompras.Columns[4].HeaderText = "Serial Number";
            dgvCompras.Columns[4].DataPropertyName = "Serial";

            dgvCompras.Columns[5].Visible = true;
            dgvCompras.Columns[5].HeaderText = "Recibo";
            dgvCompras.Columns[5].DataPropertyName = "Receipt";
            txtSku.Text = sku;
            txtValor.Text = valor;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void btnComprar_Click(object sender, System.EventArgs e)
        {

            var purchases = new List<Purchase>();
            if (string.IsNullOrEmpty(txtValor.Text) || Convert.ToDecimal(txtValor.Text, CultureInfo.InvariantCulture) <= 0)
            {
                MessageBox.Show("Informe uma quantidade maior que zero!", "Atenção", MessageBoxButtons.OK);
                return;
            }
            if (string.IsNullOrEmpty(txtSku.Text))
            {
                MessageBox.Show("Informe um SKU!", "Atenção", MessageBoxButtons.OK);
                return;
            }
            var qtd = string.IsNullOrEmpty(txtQtd.Text) ? 0 : Convert.ToInt32(txtQtd.Text);
            var totalSucesso = 0;
            var amount = Convert.ToInt32(Convert.ToDecimal(txtValor.Text, CultureInfo.InvariantCulture) * 100);
            Parallel.For(0, qtd, new ParallelOptions { MaxDegreeOfParallelism = 10 }, (i) =>
               {
                   try
                   {
                       var result = proxy.Sale(amount, txtSku.Text);
                       Interlocked.Increment(ref totalSucesso);
                       var purchase = new Purchase
                       {
                           Receipt = result.Receipt.ToString(),
                           PartnerId = 3,
                           PurchaseDate = DateTime.Now,
                           TransactionId = result.TXID,
                           Serial = result.PINCredentials.Serial,
                           Token = result.PINCredentials.PIN,
                           PaidPrice = (Convert.ToDecimal(result.Amount) / 100).ToString(CultureInfo.InvariantCulture),
                           SuggestedPrice = (Convert.ToDecimal(result.Amount) / 100).ToString(CultureInfo.InvariantCulture),
                           Sku = txtSku.Text,
                           Cancelled = false
                       };
                       repository.Add(purchase);
                       lock (objLock)
                           purchases.Add(purchase);

                   }
                   catch (Exception ex)
                   {
                       var responseLog = $"ERRO: {ex.Message}";
                       purchases.Add(new Purchase
                       {
                           Token = responseLog,
                           Serial = "ERRO",
                           PurchaseDate = DateTime.Now,
                           Sku = "ERRO",
                           PaidPrice = "ERRO",
                           SuggestedPrice = "ERRO",
                       });
                   }
               });
            var sucess = purchases.Where(d => d.Serial != "ERRO");
            lblValor.Text = $"{sucess.Sum(d => Convert.ToDecimal(d.PaidPrice, CultureInfo.InvariantCulture)):C}";
            lblSucesso.Text = $"{sucess.Count()}/{qtd}";
            dgvCompras.DataSource = purchases;

        }
    }
}

