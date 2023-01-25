using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Configuration;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using WowGames.Models.CryptoVoucher;

namespace WowGames.Proxy
{
    public class CryptoVoucherProxy
    {
        public GetVoucherResponse GetVoucher(string orderId)
        {
            var url = $"{ConfigurationManager.AppSettings["CryptoVoucherAPIUrl"]}/voucher/order-id/{orderId}";
            string json = null;
            string resultJson = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                    var body = new Credentials();
                    var contractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new CamelCaseNamingStrategy()
                    };
                    json = JsonConvert.SerializeObject(body, new JsonSerializerSettings { ContractResolver = contractResolver });
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var resp = client.PostAsync(url, content).Result;
                    resultJson = resp.Content.ReadAsStringAsync().Result;
                    resp.EnsureSuccessStatusCode();
                    var result = JsonConvert.DeserializeObject<GetVoucherResponse>(resultJson);
                    return result;
                }
            }   
            catch (Exception ex)
            {
                var path = Path.Combine(Environment.CurrentDirectory, "Logs", $"getvoucher_cryptovoucher_{DateTime.Now:yyyyMMdd}.log");
                var sb = new StringBuilder();
                sb.AppendLine(ex.ToString());
                sb.AppendLine(url);
                sb.AppendLine("Request");
                sb.AppendLine(json);
                sb.AppendLine("Response");
                sb.AppendLine(resultJson);
                File.WriteAllText(path, sb.ToString(), Encoding.UTF8);
                throw new Exception($"ERRO AO CHAMAR API GET VOUCHER - CRYPTO VOUCHER", ex);
            }
        }
        public CreateVoucherResponse CreateVoucher(CreateVoucherRequest request)
        {
            var url = $"{ConfigurationManager.AppSettings["CryptoVoucherAPIUrl"]}/voucher/partner";
            string json = null;
            string resultJson = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var contractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new CamelCaseNamingStrategy()
                    };
                    json = JsonConvert.SerializeObject(request, new JsonSerializerSettings { ContractResolver = contractResolver });
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var resp = client.PostAsync(url, content).Result;
                    resultJson = resp.Content.ReadAsStringAsync().Result;
                    resp.EnsureSuccessStatusCode();
                    var result = JsonConvert.DeserializeObject<CreateVoucherResponse>(resultJson);
                    return result;
                }
            }
            catch (Exception ex)
            {
                var path = Path.Combine(Environment.CurrentDirectory, "Logs", $"createvoucher_cryptovoucher_{DateTime.Now:yyyyMMdd}.log");
                var sb = new StringBuilder();
                sb.AppendLine(ex.ToString());
                sb.AppendLine(url);
                sb.AppendLine("Request");
                sb.AppendLine(json);
                sb.AppendLine("Response");
                sb.AppendLine(resultJson);
                File.WriteAllText(path, sb.ToString(), Encoding.UTF8);
                throw new Exception($"ERRO AO CHAMAR API CREATE VOUCHER - CRYPTO VOUCHER", ex);
            }
        }
        public GetBalanceResponse GetBalance()
        {
            var url = $"{ConfigurationManager.AppSettings["CryptoVoucherAPIUrl"]}/partner";
            string json = null;
            string resultJson = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                    var body = new Credentials();
                    var contractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new CamelCaseNamingStrategy()
                    };
                    json = JsonConvert.SerializeObject(body, new JsonSerializerSettings { ContractResolver = contractResolver });
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var resp = client.PostAsync(url, content).Result;
                    resultJson = resp.Content.ReadAsStringAsync().Result;
                    resp.EnsureSuccessStatusCode();
                    var result = JsonConvert.DeserializeObject<GetBalanceResponse>(resultJson);
                    return result;
                }
            }
            catch (Exception ex)
            {
                var path = Path.Combine(Environment.CurrentDirectory, "Logs", $"getbalance_cryptovoucher_{DateTime.Now:yyyyMMdd}.log");
                var sb = new StringBuilder();
                sb.AppendLine(ex.ToString());
                sb.AppendLine(url);
                sb.AppendLine("Request");
                sb.AppendLine(json);
                sb.AppendLine("Response");
                sb.AppendLine(resultJson);
                File.WriteAllText(path, sb.ToString(), Encoding.UTF8);
                throw new Exception($"ERRO AO CHAMAR API GET BALANCE - CRYPTO VOUCHER", ex);
            }
        }
    }
}
