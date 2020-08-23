using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WowGames.Models.AquiPaga;

namespace WowGames.Proxy
{
    public class AquiPagaProxy
    {
        private static object objLock = new object();
        private string Authenticate()
        {
            lock (objLock)
            {
                if (!string.IsNullOrEmpty(Session.Instance.AquiPagaToken) &&
                    DateTime.Now < Session.Instance.AquiPagaTokenExpiration)
                    return Session.Instance.AquiPagaToken;
                using (var client = new HttpClient())
                {
                    var expiresAt = DateTime.Now.AddSeconds(50);
                    var url = $"{ConfigurationManager.AppSettings["AquiPagaApi"]}/Authenticate";
                    var request = new AuthenticationRequest
                    {
                        Password = ConfigurationManager.AppSettings["AquiPagaPassword"],
                        TerminalKey = ConfigurationManager.AppSettings["AquiPagaTerminal"],
                        Username = ConfigurationManager.AppSettings["AquiPagaUser"]
                    };
                    var jsonReq = JsonConvert.SerializeObject(request);
                    using (var stringContent = new StringContent(jsonReq, Encoding.UTF8, "application/json"))
                    {
                        var resp = client.PostAsync(url, stringContent).Result;
                        resp.EnsureSuccessStatusCode();
                        var resultJson = resp.Content.ReadAsStringAsync().Result;
                        var result = JsonConvert.DeserializeObject<AuthenticationResponse>(resultJson);
                        if (!result.OperationSucceeded)
                            throw new Exception($"ERRO AO CHAMAR API (/Authenticate) AQUI PAGA - {result.ErrorText}");

                        Session.Instance.AquiPagaToken = result.Token;
                        Session.Instance.AquiPagaTokenExpiration = expiresAt;
                        return result.Token;
                    }
                }
            }
        }
        public List<Product> GetAvailableProducts(string codeType)
        {
            var token = Authenticate();
            using (var client = new HttpClient())
            {
                var url = $"{ConfigurationManager.AppSettings["AquiPagaApi"]}/GetAvailableProduct";
                var request = new ProductRequest
                {
                    Token = token,
                    ProductTypeCode = codeType
                };
                var jsonReq = JsonConvert.SerializeObject(request);
                using (var stringContent = new StringContent(jsonReq, Encoding.UTF8, "application/json"))
                {
                    var resp = client.PostAsync(url, stringContent).Result;
                    resp.EnsureSuccessStatusCode();
                    var resultJson = resp.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<ProductResponse>(resultJson);
                    if (!result.OperationSucceeded)
                        throw new Exception($"ERRO AO CHAMAR API (/GetAvailableProduct) AQUI PAGA - {result.ErrorText}");
                    return result.AvailableProductList;
                }
            }
        }
        public PaymentResultData DoTransaction(string codeType, string providerCode, string prodCode, string optionCode, double amount)
        {
            var token = Authenticate();
            using (var client = new HttpClient())
            {
                var url = $"{ConfigurationManager.AppSettings["AquiPagaApi"]}/DoTransaction";
                var request = new TransactionRequest
                {
                    Token = token,
                    ProductTypeCode = codeType,
                    Amount = amount,
                    ProductCode = prodCode,
                    ProductOptionCode = optionCode,
                    ProviderCode = providerCode
                };
                var jsonReq = JsonConvert.SerializeObject(request);
                using (var stringContent = new StringContent(jsonReq, Encoding.UTF8, "application/json"))
                {
                    var resp = client.PostAsync(url, stringContent).Result;
                    resp.EnsureSuccessStatusCode();
                    var resultJson = resp.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<TransactionResponse>(resultJson);
                    if (!result.OperationSucceeded)
                        throw new Exception($"ERRO AO CHAMAR API (/DoTransaction) AQUI PAGA - {result.ErrorText}");
                    return result.PaymentResultData;
                }
            }
        }
    }
}
