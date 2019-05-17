using System;
using System.Configuration;
using System.Net;
using System.Windows.Forms;
using WowGames.Models;
using WowGames.Repositories;

namespace WowGames
{
    public partial class FrmRixty : Form
    {
        private PurchaseRepository repository = new PurchaseRepository();
        public FrmRixty()
        {
            InitializeComponent();
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
            txtLog.Text = "";
            var sucesso = false;
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
                        sucesso = true;
                    }
                    else
                    {
                        responseLog = $"ERRO: {System.Net.WebUtility.UrlDecode(errMsg)}";
                    }
                }
            }
            catch (Exception exception)
            {
                responseLog = $"ERRO: {exception.Message}";
            }

            txtLog.Text += responseLog + Environment.NewLine;
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

            txtLog.Text = "";
            var qtd = Convert.ToInt32(txtQtd.Text.Trim());
            for (int i = 0; i < qtd; i++)
            {
                var sucesso = false;
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
                            repository.Add(new Purchase
                            {
                                PaidPrice = seuPreco,
                                PartnerId = 1,
                                SuggestedPrice = precoSugerido,
                                Token = token,
                                Serial = serial,
                                PurchaseDate = DateTime.Now,
                                Sku = sku
                            });
                            sucesso = true;
                        }
                        else
                        {
                            responseLog = $"ERRO: {System.Net.WebUtility.UrlDecode(errMsg)}";
                        }
                    }
                }
                catch (Exception exception)
                {
                    responseLog = $"ERRO: {exception.Message}";
                }
                txtLog.Text += responseLog + Environment.NewLine;
            }
        }

    }
}
