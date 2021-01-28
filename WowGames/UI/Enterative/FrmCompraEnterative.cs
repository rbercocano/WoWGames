using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using WowGames.Models;
using WowGames.Proxy;
using WowGames.Repositories;

namespace WowGames.Enterative
{
    public partial class FrmCompraEnterative : MaterialSkin.Controls.MaterialForm
    {
        private PurchaseRepository repository = new PurchaseRepository();
        private EnterativeProxy proxy = new EnterativeProxy();
        public FrmCompraEnterative(string sku)
        {
            InitializeComponent();

            dgvCompras.AutoGenerateColumns = false;
            dgvCompras.AllowUserToAddRows = false;
            dgvCompras.ReadOnly = true;
            dgvCompras.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PurchaseDate", Name = "Data Compra", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvCompras.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Sku", Name = "SKU", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvCompras.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Serial", Name = "Serial", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvCompras.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Token", Name = "Token", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvCompras.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PaidPrice", Name = "Seu Preço", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvCompras.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SuggestedPrice", Name = "Preço Sugerido", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            txtSku.Text = sku;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }


        private void btnComprar_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSku.Text))
            {
                MessageBox.Show("Informe o SKU", "Atenção", MessageBoxButtons.OK);
                return;
            }
            if (string.IsNullOrEmpty(txtQtd.Text))
            {
                MessageBox.Show("Informe a quantidade", "Atenção", MessageBoxButtons.OK);
                return;
            }

            var data = new List<Purchase>();
            var qtd = Convert.ToInt32(txtQtd.Text.Trim());
            for (int i = 0; i < qtd; i++)
            {
                string responseLog;
                try
                {
                    var result = proxy.Activate(new[] { txtSku.Text });
                    foreach (var item in result.Lines)
                    {
                        if (item.Response == "E00")
                        {
                            data.Add(new Purchase
                            {
                                TransactionId = item.ExternalCode,
                                Token = "",
                                Serial = "ERRO",
                                PurchaseDate = DateTime.Now,
                                Sku = "ERRO",
                                PaidPrice = "ERRO",
                                SuggestedPrice = "ERRO"
                            });
                        }
                        else
                        {
                            data.Add(new Purchase
                            {
                                TransactionId = item.ExternalCode,
                                Token = $"ERRO - Código ${item.Response} - Código Auxiliar ${item.ResponseAux}",
                                Serial = "ERRO",
                                PurchaseDate = DateTime.Now,
                                Sku = "ERRO",
                                PaidPrice = "ERRO",
                                SuggestedPrice = "ERRO"
                            });
                        }
                    }

                }
                catch (Exception exception)
                {
                    responseLog = $"ERRO: {exception.Message}";
                    data.Add(new Purchase
                    {
                        Token = responseLog,
                        Serial = "ERRO",
                        PurchaseDate = DateTime.Now,
                        Sku = "ERRO",
                        PaidPrice = "ERRO",
                        SuggestedPrice = "ERRO",
                    });
                }
            }
            var sucess = data.Where(d => d.Serial != "ERRO");
            lblValor.Text = $"{sucess.Sum(d => Convert.ToDecimal(d.PaidPrice, CultureInfo.InvariantCulture)):C}";
            lblSucesso.Text = $"{sucess.Count()}/{qtd}";
            dgvCompras.DataSource = data;
        }
        private void BindListItem(List<Purchase> data)
        {
            foreach (var item in data)
            {
                var cols = new[] {
                    item.PurchaseDate.ToString("dd/MM/yyyy hh:mm:ss"),
                    item.Sku,
                    item.Serial,
                    item.Token,
                    item.PaidPrice,
                    item.SuggestedPrice
                };
                var itm = new ListViewItem(cols);
            }
        }
        private void FrmRixty_Load(object sender, EventArgs e)
        {

        }

    }
}
