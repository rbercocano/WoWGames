using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WowGames.Models;
using WowGames.Repositories;

namespace WowGames
{
    public partial class FrmSku : MaterialSkin.Controls.MaterialForm
    {
        readonly SkuRepository repository = new SkuRepository();
        readonly PartnerRepository partnerRepository = new PartnerRepository();
        public FrmSku()
        {
            InitializeComponent();
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            try
            {
                var pid = ((Partner)cbPartner.SelectedItem).Id;
                var skus = repository.Search(pid == 0 ? new int?() : pid, txtSku.Text.Trim());
                dgProdutos.DataSource = skus;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro");
            }
        }

        private void frm_Load(object sender, EventArgs e)
        {
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
                Image = Image.FromFile(Path.Combine(Environment.CurrentDirectory, "img", "bin.png")),
                Width = 33,
                ImageLayout = DataGridViewImageCellLayout.Normal
            };
            dgProdutos.Columns.Add(btn);

            var partners = partnerRepository.List();
            cbPartnerCad.DisplayMember = "Name";
            cbPartnerCad.ValueMember = "Id";
            cbPartnerCad.DataSource = partners;
            cbPartnerCad.SelectedIndex = 0;

            partners = partnerRepository.List();
            partners.Insert(0, new Partner { Id = 0, Name = "Selecione" });
            cbPartner.DisplayMember = "Name";
            cbPartner.ValueMember = "Id";
            cbPartner.DataSource = partners;
            cbPartner.SelectedIndex = 0;
        }

        private void dgProdutos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn &&
                e.RowIndex >= 0)
            {
                var row = senderGrid.Rows[e.RowIndex];
                var id = Convert.ToInt32(row.Cells[0].Value);
                var sku = row.Cells[1].Value.ToString();
                if (MessageBox.Show($"Tem certeza que deseja exluir o sku {sku}?", "Atenção", MessageBoxButtons.YesNo) ==
                    DialogResult.Yes)
                {
                    repository.Remove(id);
                    btnValidar_Click(null, null);
                    MessageBox.Show($"SKU {sku} removido com sucesso", "Sucesso", MessageBoxButtons.OK);
                }

            }
        }

        private void bdnAdd_Click(object sender, EventArgs e)
        {
            var sku = txtSkuCad.Text.Trim();
            var partner = (Partner)cbPartnerCad.SelectedItem;
            var desc = txtDesc.Text;

            var exists = repository.Get(partner.Id, sku);
            if (exists != null)
            {
                MessageBox.Show($"SKU já cadastrado para o parceiro selecionado", "Atenção", MessageBoxButtons.OK);
                return;
            }

            repository.Add(new PartnerSku
            {

                Description = desc,
                Id = 0,
                PartnerId = partner.Id,
                SKU = sku
            });
            btnValidar_Click(null, null);

        }
    }
}
