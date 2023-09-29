using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using WowGames.Models;
using WowGames.Models.UnipinVoucher;
using WowGames.Proxy;
using WowGames.Repositories;

namespace WowGames
{
    public partial class frmPinupVoucherDetails : MaterialSkin.Controls.MaterialForm
    {
        private readonly string code;
        private VoucherDetailsResult details;
        private readonly UnipinVoucherProxy proxy = new UnipinVoucherProxy();
        private readonly PurchaseRepository repository = new PurchaseRepository();

        public frmPinupVoucherDetails(string code)
        {
            InitializeComponent();
            this.code = code;
        }


        private void frmAquiPaga_Load(object sender, EventArgs e)
        {
            dgProdutos.AutoGenerateColumns = false;
            dgProdutos.AutoSize = false;
            dgProdutos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgProdutos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgProdutos.ReadOnly = true;
            dgProdutos.AllowUserToAddRows = false;

            dgProdutos.ColumnCount = 4;
            dgProdutos.Columns[0].Visible = false;
            dgProdutos.Columns[0].HeaderText = "Code";
            dgProdutos.Columns[0].DataPropertyName = "Codigo";

            dgProdutos.Columns[1].Visible = true;
            dgProdutos.Columns[1].HeaderText = "Nome";
            dgProdutos.Columns[1].DataPropertyName = "Nome";

            dgProdutos.Columns[2].Visible = true;
            dgProdutos.Columns[2].HeaderText = "Currency";
            dgProdutos.Columns[2].DataPropertyName = "Currency";

            dgProdutos.Columns[3].Visible = true;
            dgProdutos.Columns[3].HeaderText = "Valor";
            dgProdutos.Columns[3].DataPropertyName = "Amount";

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn
            {
                HeaderText = "",
                UseColumnTextForButtonValue = true,
                Text = "Comprar"
            };
            dgProdutos.Columns.Add(btn);

            try
            {
                details = proxy.GetVoucherDetails(code);
                var dt = new DataTable();
                dt.Columns.Add("Codigo");
                dt.Columns.Add("Nome");
                dt.Columns.Add("Currency");
                dt.Columns.Add("Amount");
                txtCode.Text = details.Code;
                txtName.Text = details.Name;
                DataRow dr;
                foreach (var p in details.Denominations)
                {
                    dr = dt.NewRow();
                    dr[0] = p.Code;
                    dr[1] = p.Name;
                    dr[2] = p.Currency;
                    dr[3] = p.Amount;
                    dt.Rows.Add(dr);

                }
                dgProdutos.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro");
            }
        }

        private void dgProdutos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                var row = senderGrid.Rows[e.RowIndex];
                var code = row.Cells[0].Value.ToString();
                var name = row.Cells[1].Value.ToString();
                if (string.IsNullOrEmpty(txtQtd.Text) || Convert.ToInt32(txtQtd.Text) < 1 || Convert.ToInt32(txtQtd.Text) > 10)
                {
                    MessageBox.Show("Informe uma quantidade entre 1 e 10", "Atenção");
                    return;
                }

                var result = proxy.RequestVoucher(code, Convert.ToInt32(txtQtd.Text), Guid.NewGuid().ToString());
                if (result.Status == 1)
                {
                    foreach (var item in result.Items)
                    {
                        repository.Add(new Purchase
                        {
                            Receipt = string.Empty,
                            PartnerId = 5,
                            PurchaseDate = DateTime.Now,
                            TransactionId = result.RefNumber.ToString(),
                            Serial = item.Serial1,
                            Token = item.Serial2,
                            PaidPrice = result.Amount.ToString(CultureInfo.InvariantCulture),
                            SuggestedPrice = "",
                            Sku = result.RefNumber.ToString(),
                            Cancelled = false,
                            Limit = string.Empty
                        });
                    }
                    MessageBox.Show($"Transação efetuada com sucesso. Voucher: {name}", "Sucesso");
                }
                else
                    MessageBox.Show(result.Message, "Erro");
            }

        }

        private void txtQtd_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
             (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

        }
    }
}
