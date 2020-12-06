using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using WowGames.Models.Rixty;
using WowGames.Security;

namespace WowGames.Proxy
{
    public class RixtyProxy
    {
        private readonly string applicationCode = ConfigurationManager.AppSettings["RixtyAppCode"];
        private readonly string version = ConfigurationManager.AppSettings["RixtyGoldApiVersion"];
        public string GetErrorCode(string resultCode)
        {
            switch (resultCode)
            {
                case "02": return "02 - Fora de estoque";
                case "04": return "04 - Fundos insuficientes";
                case "05": return "05 - Produto Inváido";
                case "06": return "06 - Reference ID já existente";
                case "07": return "07 - País ou IP não suportado";
                default:
                    return "Código de erro " + resultCode + "não mapeado";
            }
        }
        public PurchaseConfirmation GetPurchaseConfirmation(string referenceId, string validatedToken)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var signature = RixtySignature.GeneratePurchaseConfirmationSignature(validatedToken, referenceId);
                    var url = $"{ConfigurationManager.AppSettings["RixtyPurchaseConfirmationUrl"]}";

                    var request = new HttpRequestMessage(HttpMethod.Post, url);
                    var keyValues = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("applicationCode", applicationCode),
                        new KeyValuePair<string, string>("version", version),
                        new KeyValuePair<string, string>("signature", signature),
                        new KeyValuePair<string, string>("referenceId", referenceId),
                        new KeyValuePair<string, string>("validatedToken", validatedToken),
                        new KeyValuePair<string, string>("userId", "")
                    };
                    request.Content = new FormUrlEncodedContent(keyValues);
                    var resp = client.SendAsync(request).Result;
                    resp.EnsureSuccessStatusCode();
                    var resultJson = resp.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<PurchaseConfirmation>(resultJson);
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"ERRO AO CHAMAR API RIXTY PURCHASE CONFIRMATION", ex);
            }
        }
        public PurchaseInitiation GetPurchaseInitiation(string referenceId, string productCode, int quantity)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var signature = RixtySignature.GeneratePurchaseInitiationSignature(productCode, referenceId, quantity);
                    var url = $"{ConfigurationManager.AppSettings["RixtyPurchaseInitiationUrl"]}";

                    var request = new HttpRequestMessage(HttpMethod.Post, url);
                    var keyValues = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("applicationCode", applicationCode),
                        new KeyValuePair<string, string>("version", version),
                        new KeyValuePair<string, string>("referenceId", referenceId),
                        new KeyValuePair<string, string>("productCode", productCode),
                        new KeyValuePair<string, string>("quantity", quantity.ToString()),
                        new KeyValuePair<string, string>("signature", signature)
                    };
                    request.Content = new FormUrlEncodedContent(keyValues);
                    var resp = client.SendAsync(request).Result;
                    resp.EnsureSuccessStatusCode();
                    var resultJson = resp.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<PurchaseInitiation>(resultJson);
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"ERRO AO CHAMAR API RIXTY PURCHASE INITIATION", ex);
            }
        }
        public List<RixtyProduct> GetProducts()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var signature = RixtySignature.GenerateProductSignature();
                    var url = $"{ConfigurationManager.AppSettings["RixtyProductUrl"]}";

                    var request = new HttpRequestMessage(HttpMethod.Post, url);
                    var keyValues = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("applicationCode", applicationCode),
                        new KeyValuePair<string, string>("version", version),
                        new KeyValuePair<string, string>("signature", signature)
                    };
                    request.Content = new FormUrlEncodedContent(keyValues);
                    var resp = client.SendAsync(request).Result;
                    resp.EnsureSuccessStatusCode();
                    var resultJson = resp.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<RixtyProductResponse>(resultJson);
                    return result.Products;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"ERRO AO CHAMAR API RIXTY PRODUCTS", ex);
            }

        }
    }
}
