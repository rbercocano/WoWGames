using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using WowGames.Models;
using WowGames.Models.Rixty;
using WowGames.Proxy;
using WowGames.Repositories;

namespace WowGames
{
    public partial class FrmCompraRixtyV2 : MaterialSkin.Controls.MaterialForm
    {
        private PurchaseRepository repository = new PurchaseRepository();
        private readonly RixtyProductDetails data;

        public FrmCompraRixtyV2(RixtyProductDetails data)
        {
            InitializeComponent();
            txtProductCode.Text = data.ProductCode;
            txtPreco.Text = data.UnitPrice;
            txtProd.Text = data.ProductName;
            txtQuantity.Text = "1";
            this.data = data;
        }

        private void btnRecovery_Click(object sender, EventArgs e)
        {
            var proxy = new RixtyProxy();
            if (string.IsNullOrEmpty(txtQuantity.Text))
            {
                MessageBox.Show("O campo quantidade é obrigatório", "Atenção");
                return;
            }
            if (string.IsNullOrEmpty(txtProductCode.Text))
            {
                MessageBox.Show("O campo Código do Produto é obrigatório", "Atenção");
                return;
            }
            var refId = Guid.NewGuid().ToString();
            var initiation = proxy.GetPurchaseInitiation(refId, txtProductCode.Text, Convert.ToInt32(txtQuantity.Text));
            if (initiation.InitiationResultCode != "00")
            {
                MessageBox.Show(proxy.GetErrorCode(initiation.InitiationResultCode), "Atenção");
                return;
            }
            var result = proxy.GetPurchaseConfirmation(refId, initiation.ValidatedToken);
            if (result == null || !result.Coupons.Any())
            {
                MessageBox.Show("PIN não encontrado", "Atenção");
                return;
            }

            var pins = result.Coupons.SelectMany(c => c.Pins).ToList();
            var serials = result.Coupons.SelectMany(c => c.Serials).ToList();
            var total = pins.Count() > serials.Count() ? pins.Count() : serials.Count();
            var pinSerials = new List<PinAndSerial>();
            var items = Enumerable.Range(0, total).Select(i => new
            {
                PurchaseStatusDate = result.PurchaseStatusDate.ToString("dd/MM/yyyy hh:mm"),
                ExpiryDate = result.Coupons[i].ExpiryDate.ToString("dd/MM/yyyy hh:mm"),
                result.UnitPrice,
                result.PaymentId,
                result.ProductCode,
                result.ProductDescription,
                PIN = result.Coupons[i].Pins[0],
                result.ReferenceId,
                Serial = result.Coupons[i].Serials[0]
            }).ToList();
            var purchases = Enumerable.Range(0, total).Select(i => new Purchase
            {
                PaidPrice = Parse(data.SellingPrice),
                SuggestedPrice = result.UnitPrice,
                Token = result.Coupons[i].Pins[0],
                Serial = result.Coupons[i].Serials[0],
                PartnerId = 1,
                PurchaseDate = DateTime.Now,
                Sku = result.ProductCode,
                Cancelled = false,
                TransactionId = result.PaymentId
            }).ToList();
            dgvResultado.DataSource = items;
            lblValor.Text = result.TotalPrice.ToString("C");
            lblSucesso.Text = $"{result.DeliveredQuantity}/{result.Quantity}";
            purchases.ForEach(repository.Add);
        }
        public static string Parse(string input)
        {
            return input.ToString().Replace("R$", "").Replace(",", ".").Trim();
        }
        private void FrmRixtyPinRecovery_Load(object sender, EventArgs e)
        {

            dgvResultado.AutoGenerateColumns = false;
            dgvResultado.AutoSize = false;
            dgvResultado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResultado.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvResultado.ReadOnly = true;
            dgvResultado.AllowUserToAddRows = false;

            dgvResultado.ColumnCount = 6;
            dgvResultado.Columns[0].Visible = true;
            dgvResultado.Columns[0].HeaderText = "Dt. Status";
            dgvResultado.Columns[0].DataPropertyName = "PurchaseStatusDate";

            dgvResultado.Columns[1].Visible = true;
            dgvResultado.Columns[1].HeaderText = "Preço";
            dgvResultado.Columns[1].DataPropertyName = "UnitPrice";

            dgvResultado.Columns[2].Visible = true;
            dgvResultado.Columns[2].HeaderText = "ID Pagamento";
            dgvResultado.Columns[2].DataPropertyName = "PaymentId";

            dgvResultado.Columns[3].Visible = true;
            dgvResultado.Columns[3].HeaderText = "PIN";
            dgvResultado.Columns[3].DataPropertyName = "PIN";

            dgvResultado.Columns[4].Visible = true;
            dgvResultado.Columns[4].HeaderText = "Serial";
            dgvResultado.Columns[4].DataPropertyName = "Serial";

            dgvResultado.Columns[5].Visible = true;
            dgvResultado.Columns[5].HeaderText = "Reference Id";
            dgvResultado.Columns[5].DataPropertyName = "ReferenceId";
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
             (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
