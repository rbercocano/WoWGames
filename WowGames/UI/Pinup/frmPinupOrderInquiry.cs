using System;
using System.Globalization;
using System.Windows.Forms;
using WowGames.Proxy;

namespace WowGames
{
    public partial class frmPinupOrderInquiry : MaterialSkin.Controls.MaterialForm
    {
        private readonly UnipinTopUpProxy proxy = new UnipinTopUpProxy();

        public frmPinupOrderInquiry()
        {
            InitializeComponent();
        }


        private void frmAquiPaga_Load(object sender, EventArgs e)
        {
            lblTrans.Text = string.Empty;
            lblValor.Text = string.Empty;
            lblName.Text = string.Empty;
            lblCurrency.Text = string.Empty;
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            lblTrans.Text = string.Empty;
            lblValor.Text = string.Empty;
            lblName.Text = string.Empty;
            lblCurrency.Text = string.Empty;
            if (string.IsNullOrEmpty(txtRef.Text)) return;
            try
            {
                var inquiry = proxy.Inquiry(txtRef.Text);
                if (inquiry.Status == 1)
                {
                    lblTrans.Text = inquiry.TransactionId;
                    lblValor.Text = inquiry.Amount.ToString(CultureInfo.InvariantCulture);
                    lblName.Text = inquiry.Item;
                    lblCurrency.Text = inquiry.Currency;
                }
                else
                {
                    MessageBox.Show(inquiry.Reason, "Erro");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro");
            }
        }
    }
}
