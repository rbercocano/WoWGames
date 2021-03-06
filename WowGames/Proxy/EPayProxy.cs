﻿using System;
using System.Configuration;
using System.IO;
using System.Net.Http;
using System.Text;
using WowGames.Models.EPay;

namespace WowGames.Proxy
{
    public class EPayProxy
    {
        public SaleResponse Sale(int amount, string ean)
        {
            var request = new SaleRequest
            {
                Amount = amount,
                Card = new Card
                {
                    EAN = ean
                }
            };
            var xml = request.ToString();
            var resultXML = "";
            try
            {
                using (var client = new HttpClient())
                {
                    var url = $"{ConfigurationManager.AppSettings["EPayApi"]}";
                    using (var stringContent = new StringContent(xml, Encoding.UTF8, "application/xml"))
                    {
                        var resp = client.PostAsync(url, stringContent).Result;
                        resp.EnsureSuccessStatusCode();
                        resultXML = resp.Content.ReadAsStringAsync().Result;
                        var response = SaleResponse.LoadFromXML(resultXML);
                        if (response.Result != "0")
                            throw new Exception($"ERRO AO CHAMAR DE VENDAS EPAY - " + response.ResultText);
                        return response;
                    }
                }
            }
            catch (Exception ex)
            {
                var path = Path.Combine(Environment.CurrentDirectory, "Logs", DateTime.Now.ToString("yyyyMMdd") + ".log");
                var sb = new StringBuilder();
                sb.AppendLine(ex.ToString());
                sb.AppendLine("Request");
                sb.AppendLine(xml);
                sb.AppendLine("Response");
                sb.AppendLine(resultXML);
                File.WriteAllText(path, sb.ToString(), Encoding.UTF8);
                throw new Exception($"ERRO AO CHAMAR DE VENDAS EPAY", ex);
            }
        }

        public CancellationResponse Cancellation(int amount, string ean, string txref)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var url = $"{ConfigurationManager.AppSettings["EPayApi"]}";
                    var request = new SaleCancellation
                    {
                        Amount = amount,
                        TXREF = txref,
                        Card = new Card
                        {
                            EAN = ean
                        }
                    };

                    var xml = request.ToString();
                    using (var stringContent = new StringContent(xml, Encoding.UTF8, "application/xml"))
                    {
                        var resp = client.PostAsync(url, stringContent).Result;
                        resp.EnsureSuccessStatusCode();
                        var resultXML = resp.Content.ReadAsStringAsync().Result;
                        var response = CancellationResponse.LoadFromXML(resultXML);
                        if (response.Result != "0")
                            throw new Exception($"ERRO AO CHAMAR DE VENDAS EPAY - " + response.ResultText);
                        return response;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"ERRO AO CHAMAR DE CANCELAMENTO DE VENDAS EPAY", ex);
            }
        }


        public CatalogResponse GetCatalog()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var url = $"{ConfigurationManager.AppSettings["EPayApi"]}";
                    var request = new CatalogRequest();
                    var xml = request.ToString();
                    using (var stringContent = new StringContent(xml, Encoding.UTF8, "application/xml"))
                    {
                        var resp = client.PostAsync(url, stringContent).Result;
                        resp.EnsureSuccessStatusCode();
                        var resultXML = resp.Content.ReadAsStringAsync().Result;
                        var response = CatalogResponse.LoadFromXML(resultXML);
                        if (response.Result != "0")
                            throw new Exception($"ERRO AO CHAMAR DE API DE CATALOGO EPAY - " + response.ResultText);
                        return response;
                    }
                }
            }
            catch (Exception ex)
            {
                var path = Path.Combine(Environment.CurrentDirectory, "Logs", DateTime.Now.ToString("yyyyMMdd") + ".log");
                File.WriteAllText(path, ex.ToString(), Encoding.UTF8);
                throw new Exception($"ERRO AO CHAMAR DE VENDAS EPAY", ex);
            }
        }
    }
}
