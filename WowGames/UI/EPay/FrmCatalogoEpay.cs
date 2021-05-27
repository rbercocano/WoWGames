﻿using System;
using System.Data;
using System.Windows.Forms;
using WowGames.Models;
using WowGames.Proxy;
using System.Linq;
using WowGames.Models.EPay;

namespace WowGames
{
    public partial class FrmCatalogoEpay : MaterialSkin.Controls.MaterialForm
    {
        public FrmCatalogoEpay()
        {
            InitializeComponent();
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            var idx = 0;
            ARTICLE current = null;
            try
            {
                var proxy = new EPayProxy();
                var catalog = proxy.GetCatalog();
                var dt = new DataTable();
                dt.Columns.Add("Nome");
                dt.Columns.Add("Provider");
                dt.Columns.Add("SKU");
                dt.Columns.Add("Preco");
                dt.Columns.Add("Enabled");
                dt.Columns.Add("Amount");
                var products = catalog.CATALOG.ARTICLE;
                DataRow dr;
                foreach (var p in products)
                {
                    var info = p.INFOS.INFO.Count > 1 ? p.INFOS.INFO[1] : p.INFOS.INFO.FirstOrDefault();
                    current = p;
                    dr = dt.NewRow();
                    dr[0] = p.NAME;
                    dr[1] = p.PROVIDER.ToString();
                    dr[2] = info?.SKU;
                    dr[3] = (Convert.ToDecimal(p.AMOUNT.Text) / 100).ToString("C");
                    dr[4] = p.ENABLED;
                    dr[5] = Convert.ToDecimal(p.AMOUNT.Text);
                    dt.Rows.Add(dr);
                    idx++;
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

            dgProdutos.ColumnCount = 6;
            dgProdutos.Columns[0].Visible = true;
            dgProdutos.Columns[0].HeaderText = "Nome";
            dgProdutos.Columns[0].DataPropertyName = "Nome";

            dgProdutos.Columns[1].Visible = true;
            dgProdutos.Columns[1].HeaderText = "Provider";
            dgProdutos.Columns[1].DataPropertyName = "Provider";

            dgProdutos.Columns[2].Visible = true;
            dgProdutos.Columns[2].HeaderText = "SKU";
            dgProdutos.Columns[2].DataPropertyName = "SKU";

            dgProdutos.Columns[3].Visible = true;
            dgProdutos.Columns[3].HeaderText = "Preço";
            dgProdutos.Columns[3].DataPropertyName = "Preco";

            dgProdutos.Columns[4].Visible = true;
            dgProdutos.Columns[4].HeaderText = "Enabled";
            dgProdutos.Columns[4].DataPropertyName = "Enabled";

            dgProdutos.Columns[5].Visible = false;
            dgProdutos.Columns[5].DataPropertyName = "Amount";

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

                var details = new EpayProductPurchase
                {
                    Nome = row.Cells[0].Value.ToString(),
                    Provider = row.Cells[1].Value.ToString(),
                    SKU = row.Cells[2].Value.ToString(),
                    Preco = row.Cells[3].Value.ToString(),
                    Enabled = row.Cells[4].Value.ToString(),
                    Amount = Convert.ToInt32(row.Cells[5].Value.ToString()),
                };
                var frm = new FrmEPay(details);
                frm.ShowDialog();
            }
        }
    }
}