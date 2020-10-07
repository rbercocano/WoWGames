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
        private int partnerId;
        public FrmSkuSearch(int partnerId)
        {
            InitializeComponent();
            if (partnerId == 1)
                Text = "SKUs RIXTY";
            else if(partnerId == 3)
                Text = "SKUs EPay";
            this.partnerId = partnerId;
            dgProdutos.AutoGenerateColumns = false;
            dgProdutos.AutoSize = false;
            dgProdutos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgProdutos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgProdutos.ReadOnly = true;
            dgProdutos.AllowUserToAddRows = false;

            dgProdutos.ColumnCount = 7;
            dgProdutos.Columns[0].Visible = false;
            dgProdutos.Columns[0].HeaderText = "Id";
            dgProdutos.Columns[0].DataPropertyName = "Id";

            dgProdutos.Columns[1].Visible = true;
            dgProdutos.Columns[1].HeaderText = "SKU";
            dgProdutos.Columns[1].DataPropertyName = "SKU";

            dgProdutos.Columns[2].Visible = true;
            dgProdutos.Columns[2].HeaderText = "Descrição";
            dgProdutos.Columns[2].DataPropertyName = "Description";

            dgProdutos.Columns[3].Visible = false;
            dgProdutos.Columns[3].DataPropertyName = "PartnerId";

            dgProdutos.Columns[4].Visible = true;
            dgProdutos.Columns[4].HeaderText = "Parceiro";
            dgProdutos.Columns[4].DataPropertyName = "Partner";

            dgProdutos.Columns[5].Visible = true;
            dgProdutos.Columns[5].HeaderText = "Valor";
            dgProdutos.Columns[5].DataPropertyName = "Valor";

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn
            {
                HeaderText = "",
                UseColumnTextForButtonValue = true,
                Text = "Comprar"
            };
            dgProdutos.Columns.Add(btn);
            btnValidar_Click(null, null);
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

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                var row = senderGrid.Rows[e.RowIndex];
                var sku = row.Cells[1].Value.ToString();
                var valor = row.Cells[5].Value.ToString();
                if (partnerId == 1)
                {
                    var frm = new FrmRixty(sku);
                    frm.ShowDialog();
                }
                else if (partnerId == 3)
                {
                    var frm = new FrmEPay(sku,valor);
                    frm.ShowDialog();
                }
            }
        }
    }
}
