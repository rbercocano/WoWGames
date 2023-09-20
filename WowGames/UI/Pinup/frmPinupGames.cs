using System;
using System.Data;
using System.Windows.Forms;
using WowGames.Models;
using WowGames.Proxy;

namespace WowGames
{
    public partial class frmPinupGames : MaterialSkin.Controls.MaterialForm
    {
        public frmPinupGames()
        {
            InitializeComponent();
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
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
            dgProdutos.Columns[0].Visible = true;
            dgProdutos.Columns[0].HeaderText = "Código";
            dgProdutos.Columns[0].DataPropertyName = "Codigo";

            dgProdutos.Columns[1].Visible = true;
            dgProdutos.Columns[1].HeaderText = "Nome";
            dgProdutos.Columns[1].DataPropertyName = "Nome";

            dgProdutos.Columns[2].Visible = true;
            dgProdutos.Columns[2].HeaderText = "Categoria Game";
            dgProdutos.Columns[2].DataPropertyName = "CategoriaGame";

            dgProdutos.Columns[3].Visible = true;
            dgProdutos.Columns[3].HeaderText = "Produto";
            dgProdutos.Columns[3].DataPropertyName = "Product";

            dgProdutos.Columns[4].Visible = true;
            dgProdutos.Columns[4].HeaderText = "Categoria";
            dgProdutos.Columns[4].DataPropertyName = "Categoria";

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn
            {
                HeaderText = "",
                UseColumnTextForButtonValue = true,
                Text = "Detalhes"
            };
            dgProdutos.Columns.Add(btn);

            try
            {
                var proxy = new UnipinTopUpProxy();
                var games = proxy.GetGameList();
                var dt = new DataTable();
                dt.Columns.Add("Codigo");
                dt.Columns.Add("Nome");
                dt.Columns.Add("CategoriaGame");
                dt.Columns.Add("Produto");
                dt.Columns.Add("Categoria");

                DataRow dr;
                foreach (var p in games.GameList)
                {
                    dr = dt.NewRow();
                    dr[0] = p.GameCode;
                    dr[1] = p.GameName;
                    dr[2] = p.GameCategory;
                    dr[3] = p.Product;
                    dr[4] = p.Category;
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
                var frm = new frmPinupGameDetails(row.Cells[0].Value.ToString());
                frm.ShowDialog();
            }
        }
    }
}
