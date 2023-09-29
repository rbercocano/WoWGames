using System;
using System.Data;
using System.Windows.Forms;
using WowGames.Proxy;

namespace WowGames
{
    public partial class frmPinupVoucherStock : MaterialSkin.Controls.MaterialForm
    {
        private readonly UnipinVoucherProxy proxy = new UnipinVoucherProxy();

        public frmPinupVoucherStock()
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

            dgProdutos.ColumnCount = 2;
            dgProdutos.Columns[0].Visible = true;
            dgProdutos.Columns[0].HeaderText = "Codigo";
            dgProdutos.Columns[0].DataPropertyName = "Codigo";

            dgProdutos.Columns[1].Visible = true;
            dgProdutos.Columns[1].HeaderText = "Quantidade";
            dgProdutos.Columns[1].DataPropertyName = "Quantidade";

            try
            {
                var voucherResult = proxy.GetVoucherStock();
                var dt = new DataTable();
                dt.Columns.Add("Codigo");
                dt.Columns.Add("Quantidade");

                DataRow dr;
                foreach (var p in voucherResult)
                {
                    dr = dt.NewRow();
                    dr[0] = p.Key;
                    dr[1] = p.Value;
                    dt.Rows.Add(dr);
                }
                dgProdutos.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro");
            }
        }

    }
}
