using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using WowGames.Models;
using WowGames.Models.CryptoVoucher;
using WowGames.Proxy;
using WowGames.Repositories;

namespace WowGames.UI.CryptoVoucher
{
    public partial class FrmVoucher : MaterialSkin.Controls.MaterialForm
    {
        private readonly CryptoVoucherProxy proxy = new CryptoVoucherProxy();
        private readonly PurchaseRepository repository = new PurchaseRepository();
        public FrmVoucher()
        {
            InitializeComponent();
        }

        private void FrmVoucher_Load(object sender, EventArgs e)
        {
            dgSaldo.AutoGenerateColumns = false;
            dgSaldo.AutoSize = false;
            dgSaldo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgSaldo.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgSaldo.ReadOnly = true;
            dgSaldo.AllowUserToAddRows = false;
            dgSaldo.ColumnCount = 2;
            dgSaldo.Columns[0].Visible = true;
            dgSaldo.Columns[0].HeaderText = "Saldo";
            dgSaldo.Columns[0].DataPropertyName = "Amount";

            dgSaldo.Columns[1].Visible = true;
            dgSaldo.Columns[1].HeaderText = "Moeda";
            dgSaldo.Columns[1].DataPropertyName = "Currency";


            dgVoucher.AutoGenerateColumns = false;
            dgVoucher.AutoSize = false;
            dgVoucher.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgVoucher.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgVoucher.ReadOnly = true;
            dgVoucher.AllowUserToAddRows = false;
            dgVoucher.ColumnCount = 4;
            dgVoucher.Columns[0].Visible = true;
            dgVoucher.Columns[0].HeaderText = "Pedido";
            dgVoucher.Columns[0].DataPropertyName = "OrderId";

            dgVoucher.Columns[1].Visible = true;
            dgVoucher.Columns[1].HeaderText = "PIN";
            dgVoucher.Columns[1].DataPropertyName = "Code";

            dgVoucher.Columns[2].Visible = true;
            dgVoucher.Columns[2].HeaderText = "Data";
            dgVoucher.Columns[2].DataPropertyName = "CreatedAt";

            dgVoucher.Columns[3].Visible = true;
            dgVoucher.Columns[3].HeaderText = "Status";
            dgVoucher.Columns[3].DataPropertyName = "Status";
            GetBalance();
        }
        private void GetBalance()
        {
            var balance = proxy.GetBalance();
            dgSaldo.DataSource = balance;
        }

        private void btnCriar_Click(object sender, EventArgs e)
        {
            try
            {
                var count = Convert.ToInt32(txtQtd.Text);
                if (count <= 0) return;
                var results = new List<CreateVoucherResponse>();
                for (int i = 0; i < count; i++)
                {
                    CreateVoucherResponse result = new CreateVoucherResponse();
                    try
                    {
                        result = proxy.CreateVoucher(new CreateVoucherRequest
                        {
                            Amount = Convert.ToDecimal(txtAmount.Text, new CultureInfo("pt-BR")),
                            Currency = txtCurrency.Text,
                        });
                        result.Status = "Sucessso";
                        var purchase = new Purchase
                        {
                            Receipt = string.Empty,
                            PartnerId = 4,
                            PurchaseDate = DateTime.Now,
                            TransactionId = result.OrderId,
                            Serial = result.Code,
                            Token = result.Code,
                            PaidPrice = Convert.ToDecimal(txtAmount.Text, new CultureInfo("en-US")).ToString(CultureInfo.InvariantCulture),
                            SuggestedPrice = Convert.ToDecimal(txtAmount.Text, new CultureInfo("en-US")).ToString(CultureInfo.InvariantCulture),
                            Sku = "CRYPTO VOUCHER",
                            Cancelled = false,
                            Limit = string.Empty
                        };
                        repository.Add(purchase);
                    }
                    catch (Exception ex)
                    {
                        result.Status = $"Erro - {ex.Message}";
                    }
                    results.Add(result);
                }
                dgVoucher.DataSource = results;
                GetBalance();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro");
            }
        }

        private void btnResgatar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPedido.Text))
                return;
            try
            {
                txtDate2.Text = string.Empty;
                txtOrder2.Text = string.Empty;
                txtCode2.Text = string.Empty;
                var result = proxy.GetVoucher(txtPedido.Text);
                txtDate2.Text = result.CreatedAt.ToString();
                txtOrder2.Text = result.OrderId;
                txtCode2.Text = result.Code;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro");
            }
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            GetBalance();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
             (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
