using System;
using System.Globalization;
using System.Windows.Forms;
using WowGames.Repositories;

namespace WowGames
{
    public partial class FrmRelCompras : Form
    {
        private PurchaseRepository repository = new PurchaseRepository();
        public FrmRelCompras()
        {
            InitializeComponent();
            dgvCompras.AutoGenerateColumns = false;
            dgvCompras.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PurchaseDate", Name = "Data Compra", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvCompras.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Sku", Name = "SKU", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvCompras.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Serial", Name = "Serial", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvCompras.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Token", Name = "Token", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvCompras.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SuggestedPrice", Name = "Preço Sugerido", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvCompras.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PaidPrice", Name = "Valor Compra", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvCompras.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Partner", Name = "Parceiro", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
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

            var result = repository.Search(ini, fim, txtSku.Text);
            dgvCompras.DataSource = result;
        }

        private void FrmRelCompras_Load(object sender, EventArgs e)
        {

        }
    }
}
