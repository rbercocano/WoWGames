using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WowGames.Proxy;
using WowGames.Repositories;

namespace WowGames
{
    public partial class FrmRelCompras : MaterialSkin.Controls.MaterialForm
    {
        private readonly PurchaseRepository repository = new PurchaseRepository();
        private readonly EPayProxy proxy = new EPayProxy();
        public FrmRelCompras()
        {
            InitializeComponent();
            dgvCompras.AutoGenerateColumns = false;
            dgvCompras.AutoGenerateColumns = false;
            dgvCompras.AutoGenerateColumns = false;
            dgvCompras.AutoSize = false;
            dgvCompras.ReadOnly = true;
            dgvCompras.AllowUserToAddRows = false;

            dgvCompras.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PurchaseDate", Name = "Data Compra", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvCompras.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Sku", Name = "SKU", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvCompras.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Serial", Name = "Serial", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvCompras.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Token", Name = "Token", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvCompras.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SuggestedPrice", Name = "Preço Sugerido", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvCompras.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PaidPrice", Name = "Valor Compra", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvCompras.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Partner", Name = "Parceiro", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvCompras.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TransactionId", Name = "Transação", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvCompras.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Receipt", Name = "Recibo", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvCompras.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Status", Name = "Status", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvCompras.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "CancelDate", Name = "Dt. Cancelamento", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvCompras.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PurchaseId", Name = "PurchaseId", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, Visible = false });
            dgvCompras.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PartnerId", Name = "PartnerId", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, Visible = false });
            dgvCompras.Columns.Add(new DataGridViewImageColumn
            {
                HeaderText = "",
                Image = Image.FromFile(Path.Combine(Environment.CurrentDirectory, "img", "cancel.png")),
                Width = 33,
                ImageLayout = DataGridViewImageCellLayout.Normal
            });
            dgvCompras.Columns[0].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            dgvCompras.Columns[10].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
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

            var result = repository.Search(ini, fim, txtSku.Text, txtPIN.Lines.ToList());
            dgvCompras.DataSource = result;
        }

        private void FrmRelCompras_Load(object sender, EventArgs e)
        {

        }

        private void dgvCompras_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn &&
                e.RowIndex >= 0)
            {
                var row = senderGrid.Rows[e.RowIndex];
                var id = Convert.ToInt32(row.Cells[11].Value);
                var pid = Convert.ToInt32(row.Cells[12].Value);
                if (pid != 3) return;
                if (MessageBox.Show($"Tem certeza que deseja cancelar esta compra?", "Atenção", MessageBoxButtons.YesNo) ==
                    DialogResult.Yes)
                {
                    try
                    {
                        var sku = row.Cells[1].Value.ToString();
                        var amount = Convert.ToInt32(Convert.ToDecimal(row.Cells[5].Value) * 100);
                        var txid = row.Cells[7].Value.ToString();
                        var result = proxy.Cancellation(amount, sku, txid);
                        repository.CancelPurchase(id);
                        btnPesquisar_Click(null, null);
                        MessageBox.Show($"Compra cancelada com sucesso.", "Sucesso", MessageBoxButtons.OK);
                    }
                    catch (EPayCancellationException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void dgvCompras_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 13)
            {
                var cell = dgvCompras.Rows[e.RowIndex].Cells[12];
                var pid = Convert.ToInt32(cell.Value);
                if (pid != 3 || dgvCompras.Rows[e.RowIndex].Cells[9].Value.ToString() == "Cancelado")
                {
                    e.Value = new Bitmap(1, 1);
                }
            }
        }
    }
}
