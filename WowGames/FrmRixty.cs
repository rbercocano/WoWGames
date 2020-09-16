using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using WowGames.Models;
using WowGames.Repositories;

namespace WowGames
{
    public partial class FrmRixty : MaterialSkin.Controls.MaterialForm
    {
        private PurchaseRepository repository = new PurchaseRepository();
        public FrmRixty()
        {
            InitializeComponent();
            //lvCompras.Columns.Add("Data Compra", 180, HorizontalAlignment.Left);
            //lvCompras.Columns.Add("SKU", 180, HorizontalAlignment.Left);
            //lvCompras.Columns.Add("Serial", 180, HorizontalAlignment.Left);
            //lvCompras.Columns.Add("Token", 180, HorizontalAlignment.Left);
            //lvCompras.Columns.Add("PaidPrice", 180, HorizontalAlignment.Left);
            //lvCompras.Columns.Add("SuggestedPrice", 180, HorizontalAlignment.Left);

            dgvCompras.AutoGenerateColumns = false;
            dgvCompras.AllowUserToAddRows = false;
            dgvCompras.ReadOnly = true;
            dgvCompras.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PurchaseDate", Name = "Data Compra", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvCompras.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Sku", Name = "SKU", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvCompras.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Serial", Name = "Serial", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvCompras.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Token", Name = "Token", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvCompras.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PaidPrice", Name = "Seu Preço", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvCompras.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SuggestedPrice", Name = "Preço Sugerido", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void btnValidar_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSku.Text))
            {
                MessageBox.Show("Informe o SKU", "Atenção", MessageBoxButtons.OK);
                return;
            }
            var data = new List<Purchase>();
            string responseLog;
            try
            {
                using (var client = new WebClient())
                {
                    var signature = ConfigurationManager.AppSettings["RixtySignature"];
                    var sku = txtSku.Text;
                    var url = $"{ConfigurationManager.AppSettings["RixtyApi"]}?METHOD=CheckSku&SIGNATURE={signature}&SKU={System.Net.WebUtility.UrlEncode(sku)}";
                    string reply = client.DownloadString(url);

                    var desc = string.Empty;
                    var precoSugerido = string.Empty;
                    var ack = string.Empty;
                    var seuPreco = string.Empty;
                    var errMsg = string.Empty;
                    var values = reply.Split(new[] { '&' });
                    foreach (var v in values)
                    {
                        var vUpper = v.ToUpper().Split(new[] { '=' });
                        if (vUpper[0] == "DESC")
                            desc = vUpper[1];
                        else if (vUpper[0] == "AMT")
                            precoSugerido = vUpper[1];
                        else if (vUpper[0] == "SETTLEAMT")
                            seuPreco = vUpper[1];
                        else if (vUpper[0] == "ACK")
                            ack = vUpper[1];
                        else if (vUpper[0] == "ERRORMESSAGE")
                            errMsg = vUpper[1];
                    }
                    if (ack.Equals("SUCCESS"))
                    {
                        responseLog = $"SUCESSO | PREÇO SUGERIDO: ${precoSugerido} | PREÇO COMPRA: ${seuPreco}";
                        var p = new Purchase
                        {
                            PaidPrice = seuPreco,
                            PartnerId = 1,
                            SuggestedPrice = precoSugerido,
                            PurchaseDate = DateTime.Now,
                            Sku = sku
                        };
                        data.Add(p);
                    }
                    else
                    {
                        responseLog = $"ERRO: {System.Net.WebUtility.UrlDecode(errMsg)}";
                        data.Add(new Purchase
                        {
                            Token = responseLog,
                            Serial = "ERRO",
                            PurchaseDate = DateTime.Now,
                            Sku = "ERRO",
                            PaidPrice = "ERRO",
                            SuggestedPrice = "ERRO"
                        });
                    }
                    lblValor.Text = "";
                    lblSucesso.Text = "";
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
                    SuggestedPrice = "ERRO"
                });
            }
            dgvCompras.DataSource = data;

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
                    using (var client = new WebClient())
                    {
                        var signature = ConfigurationManager.AppSettings["RixtySignature"];
                        var sku = txtSku.Text;
                        var url = $"{ConfigurationManager.AppSettings["RixtyApi"]}?METHOD=GetSku&SIGNATURE={signature}&SKU={System.Net.WebUtility.UrlEncode(sku)}";
                        string reply = client.DownloadString(url);

                        var desc = string.Empty;
                        var precoSugerido = string.Empty;
                        var ack = string.Empty;
                        var seuPreco = string.Empty;
                        var errMsg = string.Empty;
                        var values = reply.Split(new[] { '&' });
                        var token = string.Empty;
                        var serial = string.Empty;
                        foreach (var v in values)
                        {
                            var vUpper = v.ToUpper().Split(new[] { '=' });
                            if (vUpper[0] == "DESC")
                                desc = vUpper[1];
                            else if (vUpper[0] == "AMT")
                                precoSugerido = vUpper[1];
                            else if (vUpper[0] == "SETTLEAMT")
                                seuPreco = vUpper[1];
                            else if (vUpper[0] == "ACK")
                                ack = vUpper[1];
                            else if (vUpper[0] == "ERRORMESSAGE")
                                errMsg = vUpper[1];
                            else if (vUpper[0] == "TOKEN")
                                token = vUpper[1];
                            else if (vUpper[0] == "SERIALNUMBER")
                                serial = vUpper[1];
                        }
                        if (ack.Equals("Success", StringComparison.InvariantCultureIgnoreCase))
                        {
                            responseLog = $"SUCESSO |  PREÇO COMPRA: {seuPreco} | TOKEN: {token} | SERIAL: {serial}";
                            var p = new Purchase
                            {
                                PaidPrice = seuPreco,
                                PartnerId = 1,
                                SuggestedPrice = precoSugerido,
                                Token = token,
                                Serial = serial,
                                PurchaseDate = DateTime.Now,
                                Sku = sku
                            };
                            data.Add(p);
                            repository.Add(p);
                        }
                        else
                        {
                            responseLog = $"ERRO: {System.Net.WebUtility.UrlDecode(errMsg)}";
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
            //BindListItem(data);
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
                //materialListView1.Items.Add(itm);
            }
        }
        private void FrmRixty_Load(object sender, EventArgs e)
        {

        }
    }
}
