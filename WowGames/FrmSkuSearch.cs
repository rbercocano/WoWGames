using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WowGames.Models;
using WowGames.Repositories;

namespace WowGames
{
    public partial class FrmSkuSearch : MaterialSkin.Controls.MaterialForm
    {
        readonly SkuRepository repository = new SkuRepository();
        readonly PartnerRepository partnerRepository = new PartnerRepository();
        public delegate void SelectSku(object sender, string sku);
        public event SelectSku OnSelectSku;
        private int partnerId;
        public FrmSkuSearch(int partnerId)
        {
            this.partnerId = partnerId;
            InitializeComponent();
            var font = new Font("Arial", 8.5F, GraphicsUnit.Point);
            dgProdutos.AutoGenerateColumns = false;
            dgProdutos.AutoSize = false;
            dgProdutos.ReadOnly = true;
            dgProdutos.AllowUserToAddRows = false;

            dgProdutos.ColumnCount = 5;
            dgProdutos.Columns[0].Visible = false;
            dgProdutos.Columns[0].HeaderText = "Id";
            dgProdutos.Columns[0].DataPropertyName = "Id";
            dgProdutos.Columns[0].HeaderCell.Style.Font = font;

            dgProdutos.Columns[1].Visible = true;
            dgProdutos.Columns[1].HeaderText = "SKU";
            dgProdutos.Columns[1].DataPropertyName = "SKU";
            dgProdutos.Columns[1].HeaderCell.Style.Font = font;
            dgProdutos.Columns[1].Width = 200;

            dgProdutos.Columns[2].Visible = true;
            dgProdutos.Columns[2].HeaderText = "Descrição";
            dgProdutos.Columns[2].DataPropertyName = "Description";
            dgProdutos.Columns[2].HeaderCell.Style.Font = font;
            dgProdutos.Columns[2].Width = 243;

            dgProdutos.Columns[3].Visible = false;
            dgProdutos.Columns[3].DataPropertyName = "PartnerId";
            dgProdutos.Columns[3].HeaderCell.Style.Font = font;

            dgProdutos.Columns[4].Visible = true;
            dgProdutos.Columns[4].HeaderText = "Parceiro";
            dgProdutos.Columns[4].DataPropertyName = "Partner";
            dgProdutos.Columns[4].HeaderCell.Style.Font = font;
            dgProdutos.Columns[4].Width = 100;


            dgProdutos.DefaultCellStyle.Font = font;
            var btn = new DataGridViewImageColumn
            {
                HeaderText = "",
                Image = Image.FromFile(Path.Combine(Environment.CurrentDirectory, "img", "check.png")),
                Width = 33,
                ImageLayout = DataGridViewImageCellLayout.Normal
            };
            dgProdutos.Columns.Add(btn);
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            try
            {
                var skus = repository.Search(partnerId, txtSku.Text.Trim());
                dgProdutos.DataSource = skus;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro");
            }
        }

        private void frm_Load(object sender, EventArgs e)
        {
        }

        private void dgProdutos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn &&
                e.RowIndex >= 0)
            {
                var row = senderGrid.Rows[e.RowIndex];
                var sku = row.Cells[1].Value.ToString();
                OnSelectSku?.Invoke(this, sku);
                this.Close();
            }
        }
    }
}
