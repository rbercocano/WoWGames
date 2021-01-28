using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using WowGames.Models.Enterative;

namespace WowGames.Proxy
{
    public class EnterativeProxy
    {
        public ActivationResponse Activate(string[] barcodes)
        {
            using (var client = new HttpClient())
            {
                var url = $"{ConfigurationManager.AppSettings["EnterativeActivationApi"]}";
                var request = new ActivationRequest
                {
                    ActivationType = "VIRTUAL",
                    Merchant = ConfigurationManager.AppSettings["EnterativeMerchant"],
                    Shop = ConfigurationManager.AppSettings["EnterativeShop"],
                    Terminal = ConfigurationManager.AppSettings["EnterativeTerminal"],
                    CallbackURL = ConfigurationManager.AppSettings["EnterativeCallBackUrl"],
                    Lines = barcodes.Select(b =>
                     new Line
                     {
                         Barcode = b,
                         ExternalCode = $"WOW-{DateTime.Now:yyyyMMddhhmmddss}"
                     }).ToList()
                };
                var xml = request.ToString();
                using (var stringContent = new StringContent(xml, Encoding.UTF8, "application/json"))
                {
                    var resp = client.PostAsync(url, stringContent).Result;
                    resp.EnsureSuccessStatusCode();
                    var jsonResult = resp.Content.ReadAsStringAsync().Result;
                    var response = JsonConvert.DeserializeObject<ActivationResponse>(jsonResult);
                    if (response.Response != "E00")
                        throw new Exception($"ERRO AO CHAMAR API DE ATIVAÇÃO ENTERATIVE - CODIGO {response.Response}");
                    return response;
                }
            }
        }
    }

}

