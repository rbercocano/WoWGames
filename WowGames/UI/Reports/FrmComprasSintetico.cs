using System;
using System.Globalization;
using System.Windows.Forms;
using WowGames.Repositories;

namespace WowGames
{
    public partial class FrmComprasSintetico : MaterialSkin.Controls.MaterialForm
    {
        private readonly PurchaseRepository repository = new PurchaseRepository();
        public FrmComprasSintetico()
        {
            InitializeComponent();
            txtIni.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtFim.Text = DateTime.Now.ToString("dd/MM/yyyy");

            dgvCompras.AutoGenerateColumns = false;
            dgvCompras.AutoSize = false;
            dgvCompras.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCompras.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvCompras.ReadOnly = true;
            dgvCompras.AllowUserToAddRows = false;

            dgvCompras.ColumnCount = 5;

            dgvCompras.Columns[0].Visible = true;
            dgvCompras.Columns[0].HeaderText = "Partner";
            dgvCompras.Columns[0].DataPropertyName = "Partner";

            dgvCompras.Columns[1].Visible = true;
            dgvCompras.Columns[1].HeaderText = "Sku";
            dgvCompras.Columns[1].DataPropertyName = "Sku";

            dgvCompras.Columns[2].Visible = true;
            dgvCompras.Columns[2].HeaderText = "Data";
            dgvCompras.Columns[2].DataPropertyName = "Date";
            dgvCompras.Columns[2].DefaultCellStyle.Format = "dd/MM/yyyy";

            dgvCompras.Columns[3].Visible = true;
            dgvCompras.Columns[3].HeaderText = "Qtd";
            dgvCompras.Columns[3].DataPropertyName = "Qtd";
            dgvCompras.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCompras.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvCompras.Columns[4].Visible = true;
            dgvCompras.Columns[4].HeaderText = "Total";
            dgvCompras.Columns[4].DataPropertyName = "Total";
            dgvCompras.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCompras.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            DateTime? ini = null;
            DateTime? fim = null;
            if (!txtIni.Text.Trim().Equals("/  /"))
                if (DateTime.TryParse(txtIni.Text, new CultureInfo("pt-BR"), DateTimeStyles.None, out DateTime dtIni))
                {
                    ini = dtIni;
                }
                else
                {
                    MessageBox.Show("Data Inicial inválida", "Atenção", MessageBoxButtons.OK);
                    return;
                }

            if (!txtFim.Text.Trim().Equals("/  /"))
                if (DateTime.TryParse(txtFim.Text, new CultureInfo("pt-BR"), DateTimeStyles.None, out DateTime dtFim))
                {
                    fim = dtFim;
                }
                else
                {
                    MessageBox.Show("Data Inicial inválida", "Atenção", MessageBoxButtons.OK);
                    return;
                }

            var result = repository.GetPurchaseReport(ini, fim);
            dgvCompras.DataSource = result;
        }
    }
}
