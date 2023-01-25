using System;
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
            GetBalance();
        }
        private void GetBalance()
        {
            var balance = proxy.GetBalance();
            txtBalance.Text = $"{balance.Amount} {balance.Currency}";

            txtCurrency.Text = balance.Currency;
        }

        private void btnCriar_Click(object sender, EventArgs e)
        {
            try
            {

                txtDate.Text = string.Empty;
                txtOrderRes.Text = string.Empty;
                txtCode.Text = string.Empty;
                var result = proxy.CreateVoucher(new CreateVoucherRequest
                {
                    Amount = Convert.ToDecimal(txtAmount.Text, new CultureInfo("pt-BR")),
                    Currency = txtCurrency.Text,
                });
                txtDate.Text = result.CreatedAt.ToString();
                txtOrderRes.Text = result.OrderId;
                txtCode.Text = result.Code;
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
                    Sku = result.Code,
                    Cancelled = false,
                    Limit = string.Empty
                };
                repository.Add(purchase);
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
    }
}
