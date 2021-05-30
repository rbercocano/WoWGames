using System;
using System.Data;
using System.Windows.Forms;
using System.Linq;
using WowGames.Models.Rixty;
using WowGames.Proxy;
using WowGames.Repositories;

namespace WowGames
{
    public partial class FrmProdutosRixty : MaterialSkin.Controls.MaterialForm
    {
        public FrmProdutosRixty()
        {
            InitializeComponent();
            //cbSource.Items.AddRange(new[] { "Rixty", "Database" });
            //cbSource.SelectedIndex = 0;
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            BindFromRixty();
        }
        private void BindFromDB()
        {
            try
            {
                var rep = new SkuRepository();
                var skus = rep.Search(1, "");
                var dt = new DataTable();
                dt.Columns.Add("Nome");
                dt.Columns.Add("Descricao");
                dt.Columns.Add("ProductCode");
                dt.Columns.Add("IsStockAvailable");
                dt.Columns.Add("Comission");
                dt.Columns.Add("SellingPrice");
                dt.Columns.Add("UnitPrice");

                DataRow dr;
                foreach (var p in skus)
                {
                    dr = dt.NewRow();
                    dr[0] = p.Description;
                    dr[1] = p.Description;
                    dr[2] = p.SKU;
                    dr[3] = string.Empty;
                    dr[4] = string.Empty;
                    dr[5] = p.Valor;
                    dr[6] = p.Valor;
                    dt.Rows.Add(dr);
                }
                dgProdutos.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro");
            }
        }
        private void BindFromRixty()
        {
            try
            {
                var proxy = new RixtyProxy();
                var products = proxy.GetProducts();
                var dt = new DataTable();
                dt.Columns.Add("Nome");
                dt.Columns.Add("Descricao");
                dt.Columns.Add("ProductCode");
                dt.Columns.Add("IsStockAvailable");
                dt.Columns.Add("Comission");
                dt.Columns.Add("SellingPrice");
                dt.Columns.Add("UnitPrice");

                DataRow dr;
                foreach (var p in products.OrderBy(p => p.ProductName))
                {
                    dr = dt.NewRow();
                    dr[0] = p.ProductName;
                    dr[1] = p.ProductDescription;
                    dr[2] = "013" + p.ProductCode;
                    dr[3] = p.IsStockAvailable ? "Sim" : "Não";
                    dr[4] = (p.Commission / 100).ToString("P");
                    dr[5] = p.SellingPrice.ToString("C");
                    dr[6] = p.UnitPrice.ToString("C");
                    dt.Rows.Add(dr);
                }
                dgProdutos.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro");
            }
        }
        private void frm_Load(object sender, EventArgs e)
        {
            dgProdutos.AutoGenerateColumns = false;
            dgProdutos.AutoSize = false;
            dgProdutos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgProdutos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgProdutos.ReadOnly = true;
            dgProdutos.AllowUserToAddRows = false;

            dgProdutos.ColumnCount = 7;
            dgProdutos.Columns[0].Visible = true;
            dgProdutos.Columns[0].HeaderText = "Produto";
            dgProdutos.Columns[0].DataPropertyName = "Nome";
            dgProdutos.Columns[0].Width = 250;

            dgProdutos.Columns[1].Visible = true;
            dgProdutos.Columns[1].HeaderText = "Descrição";
            dgProdutos.Columns[1].DataPropertyName = "Descricao";

            dgProdutos.Columns[2].Visible = true;
            dgProdutos.Columns[2].HeaderText = "Código";
            dgProdutos.Columns[2].DataPropertyName = "ProductCode";

            dgProdutos.Columns[3].Visible = true;
            dgProdutos.Columns[3].HeaderText = "Em Estoque";
            dgProdutos.Columns[3].DataPropertyName = "IsStockAvailable";

            dgProdutos.Columns[4].Visible = true;
            dgProdutos.Columns[4].HeaderText = "Comissão";
            dgProdutos.Columns[4].DataPropertyName = "Comission";
            dgProdutos.Columns[4].Width = 60;

            dgProdutos.Columns[5].Visible = true;
            dgProdutos.Columns[5].HeaderText = "Preço Pago";
            dgProdutos.Columns[5].DataPropertyName = "SellingPrice";
            dgProdutos.Columns[5].Width = 95;

            dgProdutos.Columns[6].Visible = true;
            dgProdutos.Columns[6].HeaderText = "Preço Venda";
            dgProdutos.Columns[6].DataPropertyName = "UnitPrice";
            dgProdutos.Columns[6].Width = 110;

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn
            {
                HeaderText = "",
                UseColumnTextForButtonValue = true,
                Text = "Comprar"
            };
            dgProdutos.Columns.Add(btn);
            dgProdutos.Columns[7].Width = 85;
        }

        private void dgProdutos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                var row = senderGrid.Rows[e.RowIndex];
                var details = new RixtyProductDetails
                {
                    ProductName = row.Cells[0].Value.ToString(),
                    ProductDescription = row.Cells[1].Value.ToString(),
                    ProductCode = row.Cells[2].Value.ToString(),
                    IsStockAvailable = row.Cells[3].Value.ToString(),
                    Commission = row.Cells[4].Value.ToString(),
                    SellingPrice = row.Cells[5].Value.ToString(),
                    UnitPrice = row.Cells[6].Value.ToString()
                };
                var frm = new FrmCompraRixtyV2(details);
                frm.ShowDialog();
            }
        }
    }
}
