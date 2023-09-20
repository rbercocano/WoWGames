using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using WowGames.Proxy;

namespace WowGames
{
    public partial class frmPinupVoucherInquiry : MaterialSkin.Controls.MaterialForm
    {
        private readonly UnipinVoucherProxy proxy = new UnipinVoucherProxy();

        public frmPinupVoucherInquiry()
        {
            InitializeComponent();
        }


        private void frmAquiPaga_Load(object sender, EventArgs e)
        {
            lblTrans.Text = string.Empty;
            lblValor.Text = string.Empty;
            lblCurrency.Text = string.Empty;
            lblBalance.Text = string.Empty;
            dgProdutos.AutoGenerateColumns = false;
            dgProdutos.AutoSize = false;
            dgProdutos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgProdutos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgProdutos.ReadOnly = true;
            dgProdutos.AllowUserToAddRows = false;

            dgProdutos.ColumnCount =2;
            dgProdutos.Columns[0].Visible = false;
            dgProdutos.Columns[0].HeaderText = "Serial 1";
            dgProdutos.Columns[0].DataPropertyName = "Serial_1";

            dgProdutos.Columns[1].Visible = true;
            dgProdutos.Columns[1].HeaderText = "Serial 2";
            dgProdutos.Columns[1].DataPropertyName = "Serial_2";

        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            lblTrans.Text = string.Empty;
            lblValor.Text = string.Empty;
            lblCurrency.Text = string.Empty;
            lblBalance.Text = string.Empty;
            if (string.IsNullOrEmpty(txtRef.Text)) return;
            try
            {
                var inquiry = proxy.InquiryVoucher(txtRef.Text);
                if (inquiry.Status == 1)
                {
                    lblTrans.Text = inquiry.Order;
                    lblValor.Text = (Convert.ToDecimal(inquiry.Amount) / 100).ToString(CultureInfo.InvariantCulture);
                    lblCurrency.Text = inquiry.Currency;
                    lblBalance.Text = (Convert.ToDecimal(inquiry.Balance) / 100).ToString(CultureInfo.InvariantCulture);
                    var dt = new DataTable();
                    dt.Columns.Add("Serial_1");
                    dt.Columns.Add("Serial_2");
                    DataRow dr;
                    foreach (var p in inquiry.Items)
                    {
                        dr = dt.NewRow();
                        dr[0] = p.Serial1;
                        dr[1] = p.Serial2;
                        dt.Rows.Add(dr);
                    }
                    dgProdutos.DataSource = dt;
                }
                else
                {
                    MessageBox.Show(inquiry.Message, "Erro");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro");
            }
        }
    }
}
