using System;
using System.Globalization;
using System.Windows.Forms;
using WowGames.Proxy;

namespace WowGames
{
    public partial class frmPinupBalanceInquiry : MaterialSkin.Controls.MaterialForm
    {
        private readonly UnipinVoucherProxy proxy = new UnipinVoucherProxy();

        public frmPinupBalanceInquiry()
        {
            InitializeComponent();
        }


        private void frmAquiPaga_Load(object sender, EventArgs e)
        {
            lblBalance.Text = string.Empty;
            var inquiry = proxy.InquiryBalance();
            if (inquiry.Status == 1)
            {
                lblBalance.Text = (Convert.ToDecimal(inquiry.Balance) / 100).ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                MessageBox.Show(inquiry.Message, "Erro");
            }
        }

    }
}
