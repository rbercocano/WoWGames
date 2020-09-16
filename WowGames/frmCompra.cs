using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WowGames.Models;
using WowGames.Models.AquiPaga;
using WowGames.Proxy;
using WowGames.Repositories;

namespace WowGames
{
    public partial class frmCompra : MaterialSkin.Controls.MaterialForm
    {
        private static object objLock = new object();
        private PurchaseRepository repository = new PurchaseRepository();
        private readonly ProductDetails productDetails;

        public frmCompra(ProductDetails productDetails)
        {
            InitializeComponent();
            this.productDetails = productDetails;
        }

        private void frmCompra_Load(object sender, EventArgs e)
        {
            txtProduto.Text = productDetails.Nome;
            txtOpcao.Text = productDetails.Descricao;
            txtDescricao.Text = productDetails.Description;
            if (productDetails.Preco.HasValue)
                txtPreco.Text = productDetails.PrecoDisplay;
            else
            {
                txtPreco.Text = "";
                txtPreco.ReadOnly = false;
            }
            txtProvider.Text = productDetails.ProviderCode;
            txtCodProd.Text = productDetails.ProductCode;
            txtCodOpcao.Text = productDetails.ProductOptionCode;

            dgResult.AutoGenerateColumns = false;
            dgResult.AutoSize = false;
            dgResult.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgResult.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgResult.ReadOnly = true;
            dgResult.AllowUserToAddRows = false;

            dgResult.ColumnCount = 6;
            dgResult.Columns[0].Visible = true;
            dgResult.Columns[0].HeaderText = "Data / Hora";
            dgResult.Columns[0].DataPropertyName = "Date";

            dgResult.Columns[1].Visible = true;
            dgResult.Columns[1].HeaderText = "Montante";
            dgResult.Columns[1].DataPropertyName = "Amount";

            dgResult.Columns[2].Visible = true;
            dgResult.Columns[2].HeaderText = "Transaçao";
            dgResult.Columns[2].DataPropertyName = "ProviderTransactionId";

            dgResult.Columns[3].Visible = true;
            dgResult.Columns[3].HeaderText = "PIN";
            dgResult.Columns[3].DataPropertyName = "Reference";

            dgResult.Columns[4].Visible = true;
            dgResult.Columns[4].HeaderText = "Serial Number";
            dgResult.Columns[4].DataPropertyName = "SerialNumber";

            dgResult.Columns[5].Visible = true;
            dgResult.Columns[5].HeaderText = "Recibo";
            dgResult.Columns[5].DataPropertyName = "Message";
        }

        private void txtQtd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnCompar_Click(object sender, EventArgs e)
        {
            var qtd = string.IsNullOrEmpty(txtQtd.Text) ? 0 : Convert.ToInt32(txtQtd.Text);
            if (qtd == 0)
            {
                MessageBox.Show("A quantidade deve ser maior que ZERO", "Atenção");
                return;
            }
            var resultList = new List<PurchaseDetails>();

            var proxy = new AquiPagaProxy();
            var totalSucesso = 0;
            Parallel.For(0, qtd, (x) =>
            {
                PurchaseDetails data;
                try
                {
                    double preco = 0;
                    if (productDetails.Preco.HasValue)
                        preco = productDetails.Preco.Value;
                    else if (double.TryParse(txtPreco.Text, out preco))
                        preco = Convert.ToDouble(txtPreco.Text, new CultureInfo("pt-BR"));
                    else
                    {
                        MessageBox.Show("Informe o preço do produto", "Atenção");
                        return;
                    }
                    var result = proxy.DoTransaction(productDetails.ProductTypeCode, productDetails.ProviderCode,
                        productDetails.ProductCode, productDetails.ProductOptionCode, preco);
                    data = new PurchaseDetails
                    {
                        Date = result.Date.ToString("dd/MM/yyyy hh:mm:ss"),
                        ProviderTransactionId = result.ProviderTransactionId.ToString(),
                        Amount = result.Amount.ToString("C"),
                        Reference = result.Reference.ToString(),
                        SerialNumber = result.SerialNumber.ToString(),
                        Message = string.Join(Environment.NewLine, result.Receipt)
                    };
                    Interlocked.Increment(ref totalSucesso);
                    repository.Add(new Purchase
                    {

                        PaidPrice = result.Amount.ToString(CultureInfo.InvariantCulture),
                        PartnerId = 2,
                        SuggestedPrice = result.Amount.ToString(CultureInfo.InvariantCulture),
                        Token = result.Reference,
                        Serial = result.SerialNumber,
                        PurchaseDate = DateTime.Now,
                        Sku = productDetails.Descricao,
                        TransactionId = result.ProviderTransactionId.ToString(),
                        Receipt = string.Join(Environment.NewLine, result.Receipt)
                    });
                }
                catch (Exception ex)
                {
                    data = new PurchaseDetails
                    {
                        Message = "Error - " + ex.Message
                    };
                }
                lock (objLock)
                    resultList.Add(data);
            });
            dgResult.DataSource = resultList;
            lblSucesso.Text = $"{totalSucesso}/{qtd}";
            lblValor.Text = $"{totalSucesso * (productDetails.Preco ?? 0):C}";
        }
    }
}
