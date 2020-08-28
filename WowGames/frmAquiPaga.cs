using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WowGames.Models;
using WowGames.Proxy;

namespace WowGames
{
    public partial class frmAquiPaga : Form
    {
        public frmAquiPaga()
        {
            InitializeComponent();
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            try
            {
                var proxy = new AquiPagaProxy();
                var products = proxy.GetAvailableProducts("Voucher");
                var dt = new DataTable();
                dt.Columns.Add("Nome");
                dt.Columns.Add("Descricao");
                dt.Columns.Add("PrecoDisplay");
                dt.Columns.Add("Preco");
                dt.Columns.Add("ProductTypeCode");
                dt.Columns.Add("ProviderCode");
                dt.Columns.Add("ProductCode");
                dt.Columns.Add("ProductOptionCode");
                dt.Columns.Add("Description");

                DataRow dr;
                foreach (var p in products)
                {
                    foreach (var o in p.ProductOptionsList)
                    {
                        dr = dt.NewRow();
                        dr[0] = p.Name;
                        dr[1] = o.Name;
                        dr[2] = o.Value?.ToString("C");
                        dr[3] = o.Value;
                        dr[4] = "Voucher";
                        dr[5] = p.ProviderCode;
                        dr[6] = p.ProductCode;
                        dr[7] = o.ProductOptionCode;
                        dr[8] = o.Description;
                        dt.Rows.Add(dr);
                    }
                }
                dgProdutos.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro");
            }
        }

        private void frmAquiPaga_Load(object sender, EventArgs e)
        {
            dgProdutos.AutoGenerateColumns = false;
            dgProdutos.AutoSize = false;
            dgProdutos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgProdutos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgProdutos.ReadOnly = true;
            dgProdutos.AllowUserToAddRows = false;

            dgProdutos.ColumnCount = 9;
            dgProdutos.Columns[0].Visible = true;
            dgProdutos.Columns[0].HeaderText = "Produto";
            dgProdutos.Columns[0].DataPropertyName = "Nome";

            dgProdutos.Columns[1].Visible = true;
            dgProdutos.Columns[1].HeaderText = "Descrição";
            dgProdutos.Columns[1].DataPropertyName = "Descricao";

            dgProdutos.Columns[2].Visible = true;
            dgProdutos.Columns[2].HeaderText = "Preço";
            dgProdutos.Columns[2].DataPropertyName = "PrecoDisplay";

            dgProdutos.Columns[3].Visible = false;
            dgProdutos.Columns[3].DataPropertyName = "Preco";

            dgProdutos.Columns[4].Visible = false;
            dgProdutos.Columns[4].DataPropertyName = "ProductTypeCode";

            dgProdutos.Columns[5].Visible = false;
            dgProdutos.Columns[5].DataPropertyName = "ProviderCode";

            dgProdutos.Columns[6].Visible = false;
            dgProdutos.Columns[6].DataPropertyName = "ProductCode";

            dgProdutos.Columns[7].Visible = false;
            dgProdutos.Columns[7].DataPropertyName = "ProductOptionCode";

            dgProdutos.Columns[8].Visible = false;
            dgProdutos.Columns[8].DataPropertyName = "Description";

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn
            {
                HeaderText = "",
                UseColumnTextForButtonValue = true,
                Text = "Comprar"
            };
            dgProdutos.Columns.Add(btn);
        }

        private void dgProdutos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                var row = senderGrid.Rows[e.RowIndex];

                var details = new ProductDetails
                {
                    Nome = row.Cells[0].Value.ToString(),
                    Descricao = row.Cells[1].Value.ToString(),
                    Preco = row.Cells[3].Value.ToString() != "" ? Convert.ToDouble(row.Cells[3].Value) : new double?(),
                    ProductTypeCode = row.Cells[4].Value.ToString(),
                    ProviderCode = row.Cells[5].Value.ToString(),
                    ProductCode = row.Cells[6].Value.ToString(),
                    ProductOptionCode = row.Cells[7].Value.ToString(),
                    Description = row.Cells[8].Value.ToString(),
                };
                var frm = new frmCompra(details);
                frm.ShowDialog();
            }
        }
    }
}
