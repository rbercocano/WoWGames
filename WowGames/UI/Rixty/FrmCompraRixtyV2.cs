using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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
        private static object objLock = new object();

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
            var total = Convert.ToInt32(txtQuantity.Text);
            var loops = (int)Math.Ceiling(total / 10D) + 1;
            var results = new List<PurchaseResult>();
            var purchases = new List<Purchase>();
            var totalDelivered = 0;
            var totalQuantity = 0;
            var totalPrice = 0;
            Parallel.For(1, loops, (idx) =>
            {
                var qtd = 10;
                if (idx * qtd > total)
                    qtd = total - ((idx - 1) * qtd);
                var purchaseResult = Purchase(txtProductCode.Text, qtd);
                lock (objLock)
                {
                    foreach (var i in purchaseResult)
                    {
                        results.Add(i);
                        if (Convert.ToInt32(i.DeliveredQuantity) > 0)
                            purchases.Add(new Purchase
                            {
                                PaidPrice = Parse(data.SellingPrice),
                                SuggestedPrice = i.UnitPrice,
                                Token = i.PIN,
                                Serial = i.Serial,
                                PartnerId = 1,
                                PurchaseDate = DateTime.Now,
                                Sku = i.ProductCode,
                                Cancelled = false,
                                TransactionId = i.PaymentId
                            });
                    }
                    totalDelivered += purchaseResult.Count == 0 ? 0 : Convert.ToInt32(purchaseResult.First().DeliveredQuantity);
                    totalQuantity += purchaseResult.Count == 0 ? 0 : Convert.ToInt32(purchaseResult.First().Quantity);
                    totalPrice += purchaseResult.Count == 0 ? 0 : Convert.ToInt32(purchaseResult.First().TotalPrice);
                }
            });
            totalQuantity = totalQuantity == 0 ? 1 : totalQuantity;
            dgvResultado.DataSource = results;
            //lblValor.Text = result.TotalPrice.ToString("C");
            //lblSucesso.Text = $"{result.DeliveredQuantity}/{result.Quantity}";
            lblValor.Text = totalPrice.ToString("C");
            lblSucesso.Text = $"{totalDelivered}/{totalQuantity}";
            purchases.ForEach(repository.Add);
        }
        public static string Parse(string input)
        {
            return input.ToString().Replace("R$", "").Replace(",", ".").Trim();
        }
        private List<PurchaseResult> Purchase(string productCode, int qtd)
        {
            try
            {
                var proxy = new RixtyProxy();
                var refId = Guid.NewGuid().ToString();
                var initiation = proxy.GetPurchaseInitiation(refId, productCode, qtd);
                if (initiation.InitiationResultCode != "00")
                {
                    //MessageBox.Show(proxy.GetErrorCode(initiation.InitiationResultCode), "Atenção");
                    return Enumerable.Range(0, qtd).Select(i => new PurchaseResult
                    {
                        Serial = "ERRO",
                        PIN = proxy.GetErrorCode(initiation.InitiationResultCode),
                        DeliveredQuantity = "0",
                        Quantity = qtd.ToString()
                    }).ToList();
                }
                var result = proxy.GetPurchaseConfirmation(refId, initiation.ValidatedToken);
                if (result == null || !result.Coupons.Any())
                {
                    //MessageBox.Show("PIN não encontrado", "Atenção");
                    return Enumerable.Range(0, qtd).Select(i => new PurchaseResult
                    {
                        Serial = "ERRO",
                        PIN = "PIN não encontrado",
                        DeliveredQuantity = "0",
                        Quantity = qtd.ToString()
                    }).ToList();
                }

                var pins = result.Coupons.SelectMany(c => c.Pins).ToList();
                var serials = result.Coupons.SelectMany(c => c.Serials).ToList();
                var total = pins.Count() > serials.Count() ? pins.Count() : serials.Count();
                var pinSerials = new List<PinAndSerial>();
                var items = Enumerable.Range(0, total).Select(i => new PurchaseResult
                {
                    PurchaseStatusDate = result.PurchaseStatusDate.ToString("dd/MM/yyyy hh:mm"),
                    ExpiryDate = result.Coupons[i].ExpiryDate.ToString("dd/MM/yyyy hh:mm"),
                    UnitPrice = result.UnitPrice,
                    PaymentId = result.PaymentId,
                    ProductCode = result.ProductCode,
                    ProductDescription = result.ProductDescription,
                    PIN = result.Coupons[i].Pins[0],
                    ReferenceId = result.ReferenceId,
                    Serial = result.Coupons[i].Serials[0],
                    DeliveredQuantity = result.DeliveredQuantity,
                    TotalPrice = result.TotalPrice,
                    Quantity = result.Quantity
                }).ToList();
                return items;
            }
            catch (Exception ex)
            {
                return Enumerable.Range(0, qtd).Select(i => new PurchaseResult
                {
                    Serial = "ERRO",
                    PIN = ex.Message,
                    DeliveredQuantity = "0",
                    Quantity = qtd.ToString()
                }).ToList();
            }
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
        public class PurchaseResult
        {
            public string PurchaseStatusDate { get; set; }
            public string ExpiryDate { get; set; }
            public string UnitPrice { get; set; }
            public string PaymentId { get; set; }
            public string ProductCode { get; set; }
            public string ProductDescription { get; set; }
            public string PIN { get; set; }
            public string ReferenceId { get; set; }
            public string Serial { get; set; }
            public string DeliveredQuantity { get; set; }
            public double TotalPrice { get; set; }
            public string Quantity { get; set; }
        }
    }
}
