using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WowGames.Models.Rixty;
using WowGames.Security;

namespace WowGames.Proxy
{
    public class RixtyProxy
    {
        private readonly string applicationCode = ConfigurationManager.AppSettings["RixtyAppCode"];
        private readonly string version = ConfigurationManager.AppSettings["RixtyGoldApiVersion"];
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
    }
}
