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
    public partial class frmPinupVoucherList : MaterialSkin.Controls.MaterialForm
    {
        private readonly UnipinVoucherProxy proxy = new UnipinVoucherProxy();
        private readonly PurchaseRepository repository = new PurchaseRepository();

        public frmPinupVoucherList()
        {
            InitializeComponent();
        }


        private void frmAquiPaga_Load(object sender, EventArgs e)
        {
            dgProdutos.AutoGenerateColumns = false;
            dgProdutos.AutoSize = false;
            dgProdutos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgProdutos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgProdutos.ReadOnly = true;
            dgProdutos.AllowUserToAddRows = false;

            dgProdutos.ColumnCount = 3;
            dgProdutos.Columns[0].Visible = false;
            dgProdutos.Columns[0].HeaderText = "Codigo";
            dgProdutos.Columns[0].DataPropertyName = "Codigo";

            dgProdutos.Columns[1].Visible = true;
            dgProdutos.Columns[1].HeaderText = "Nome";
            dgProdutos.Columns[1].DataPropertyName = "Nome";

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn
            {
                HeaderText = "",
                UseColumnTextForButtonValue = true,
                Text = "Comprar"
            };
            dgProdutos.Columns.Add(btn);

            try
            {
                var voucherResult = proxy.GetVoucherList();
                var dt = new DataTable();
                dt.Columns.Add("Codigo");
                dt.Columns.Add("Nome");

                DataRow dr;
                foreach (var p in voucherResult.Vouchers)
                {
                    dr = dt.NewRow();
                    dr[0] = p.Code;
                    dr[1] = p.Name;
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
                var id = row.Cells[0].Value.ToString();
                
            }

        }
    }
}
