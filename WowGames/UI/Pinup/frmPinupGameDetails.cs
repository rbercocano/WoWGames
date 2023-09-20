using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using WowGames.Models;
using WowGames.Models.TopUp;
using WowGames.Proxy;
using WowGames.Repositories;

namespace WowGames
{
    public partial class frmPinupGameDetails : MaterialSkin.Controls.MaterialForm
    {
        private readonly string code;
        private GameDetailsResult gameDetails;
        private readonly UnipinTopUpProxy proxy = new UnipinTopUpProxy();
        private readonly PurchaseRepository repository = new PurchaseRepository();

        public frmPinupGameDetails(string code)
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

            dgProdutos.ColumnCount = 5;
            dgProdutos.Columns[0].Visible = false;
            dgProdutos.Columns[0].HeaderText = "Id";
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
                gameDetails = proxy.GetGameDetails(code);
                var dt = new DataTable();
                dt.Columns.Add("Id");
                dt.Columns.Add("Nome");
                dt.Columns.Add("Currency");
                dt.Columns.Add("Amount");
                txtCode.Text = gameDetails.Game.Code;
                txtName.Text = gameDetails.Game.Name;
                txtCategoria.Text = gameDetails.Game.Category;

                DataRow dr;
                foreach (var p in gameDetails.Denominations)
                {
                    dr = dt.NewRow();
                    dr[0] = p.Id;
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
                var validationResult = proxy.ValidateUser(code, gameDetails.Fields);
                var id = row.Cells[0].Value.ToString();
                var orderResult = proxy.CreateOrder(code, validationResult.ValidationToken, Guid.NewGuid().ToString(), id);
                if (orderResult.Status == 1)
                {
                    repository.Add(new Purchase
                    {
                        Receipt = string.Empty,
                        PartnerId = 4,
                        PurchaseDate = DateTime.Now,
                        TransactionId = orderResult.TransactionId,
                        Serial = orderResult.Ref,
                        Token = orderResult.Ref,
                        PaidPrice = (Convert.ToDecimal(orderResult.Amount) / 100).ToString(CultureInfo.InvariantCulture),
                        SuggestedPrice = (Convert.ToDecimal(orderResult.Amount) / 100).ToString(CultureInfo.InvariantCulture),
                        Sku = orderResult.Ref,
                        Cancelled = false,
                        Limit = string.Empty
                    });
                }
                else
                    MessageBox.Show(orderResult.Reason, "Erro");
            }

        }
    }
}
