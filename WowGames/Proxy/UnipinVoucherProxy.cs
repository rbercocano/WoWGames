using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.IO;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using WowGames.Models.UnipinVoucher;
using System.Collections.Generic;

namespace WowGames.Proxy
{
    public class UnipinVoucherProxy
    {
        public readonly string partnerId = ConfigurationManager.AppSettings["UniPinPID"].ToString();
        public readonly string apiUrl = ConfigurationManager.AppSettings["UniPinUrl"].ToString();
        public readonly string secret = ConfigurationManager.AppSettings["UniPinSecret"].ToString();
        public VoucherListResult GetVoucherList()
        {
            string json = null;
            string resultJson = null;
            string uriPath = "voucher/list";
            var url = $"{apiUrl}{uriPath}";
            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            var auth = GetSignature(partnerId, timestamp.ToString());
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var contractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy() };
                    json = JsonConvert.SerializeObject(new { partner_guid = partnerId, logid = timestamp, signature = auth }, new JsonSerializerSettings { ContractResolver = contractResolver });
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var resp = client.PostAsync(url, content).Result;
                    resultJson = resp.Content.ReadAsStringAsync().Result;
                    resp.EnsureSuccessStatusCode();
                    var result = JsonConvert.DeserializeObject<VoucherListResult>(resultJson);
                    return result;
                }
            }
            catch (Exception ex)
            {
                var path = Path.Combine(Environment.CurrentDirectory, "Logs", $"getvoucherlist_unipin_{DateTime.Now:yyyyMMdd}.log");
                var sb = new StringBuilder();
                sb.AppendLine(ex.ToString());
                sb.AppendLine(url);
                sb.AppendLine("Request");
                sb.AppendLine(json);
                sb.AppendLine("Response");
                sb.AppendLine(resultJson);
                File.WriteAllText(path, sb.ToString(), Encoding.UTF8);
                throw new Exception($"ERRO AO CHAMAR API GET VOUCHER LIST - UNIPIN", ex);
            }
        }
        public Dictionary<string, int> GetVoucherStock()
        {
            string json = null;
            string resultJson = null;
            string uriPath = "voucher/get_stock_count";
            var url = $"{apiUrl}{uriPath}";
            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            var auth = GetSignature(partnerId, timestamp.ToString());
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var contractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy() };
                    json = JsonConvert.SerializeObject(new { partner_guid = partnerId, logid = timestamp, signature = auth }, new JsonSerializerSettings { ContractResolver = contractResolver });
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var resp = client.PostAsync(url, content).Result;
                    resultJson = resp.Content.ReadAsStringAsync().Result;
                    resp.EnsureSuccessStatusCode();
                    var result = JsonConvert.DeserializeObject<Dictionary<string, int>>(resultJson);
                    return result;
                }
            }
            catch (Exception ex)
            {
                var path = Path.Combine(Environment.CurrentDirectory, "Logs", $"getvoucherstock_unipin_{DateTime.Now:yyyyMMdd}.log");
                var sb = new StringBuilder();
                sb.AppendLine(ex.ToString());
                sb.AppendLine(url);
                sb.AppendLine("Request");
                sb.AppendLine(json);
                sb.AppendLine("Response");
                sb.AppendLine(resultJson);
                File.WriteAllText(path, sb.ToString(), Encoding.UTF8);
                throw new Exception($"ERRO AO CHAMAR API GET VOUCHER STOCK - UNIPIN", ex);
            }
        }
        public VoucherDetailsResult GetVoucherDetails(string code)
        {
            string json = null;
            string resultJson = null;
            string uriPath = "voucher/details";
            var url = $"{apiUrl}{uriPath}";
            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            var auth = GetSignature(partnerId, timestamp.ToString());
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var contractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy() };
                    json = JsonConvert.SerializeObject(new { voucher_code = code, partner_guid = partnerId, logid = timestamp, signature = auth }, new JsonSerializerSettings { ContractResolver = contractResolver });
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var resp = client.PostAsync(url, content).Result;
                    resultJson = resp.Content.ReadAsStringAsync().Result;
                    resp.EnsureSuccessStatusCode();
                    var result = JsonConvert.DeserializeObject<VoucherDetailsResult>(resultJson);
                    return result;
                }
            }
            catch (Exception ex)
            {
                var path = Path.Combine(Environment.CurrentDirectory, "Logs", $"getvoucherdetails_unipin_{DateTime.Now:yyyyMMdd}.log");
                var sb = new StringBuilder();
                sb.AppendLine(ex.ToString());
                sb.AppendLine(url);
                sb.AppendLine("Request");
                sb.AppendLine(json);
                sb.AppendLine("Response");
                sb.AppendLine(resultJson);
                File.WriteAllText(path, sb.ToString(), Encoding.UTF8);
                throw new Exception($"ERRO AO CHAMAR API GET VOUCHER DETAILS - UNIPIN", ex);
            }
        }
        public VoucherRequestResult RequestVoucher(string code, int quantity, string refNumber)
        {
            string json = null;
            string resultJson = null;
            string uriPath = "voucher/request";
            var url = $"{apiUrl}{uriPath}";
            var auth = GetSignature(partnerId, code, quantity.ToString(), refNumber);
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var contractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy() };
                    json = JsonConvert.SerializeObject(new { reference_no = refNumber, quantity, denomination_code = code, partner_guid = partnerId, signature = auth }, new JsonSerializerSettings { ContractResolver = contractResolver });
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var resp = client.PostAsync(url, content).Result;
                    resultJson = resp.Content.ReadAsStringAsync().Result;
                    resp.EnsureSuccessStatusCode();
                    var result = JsonConvert.DeserializeObject<VoucherRequestResult>(resultJson);
                    return result;
                }
            }
            catch (Exception ex)
            {
                var path = Path.Combine(Environment.CurrentDirectory, "Logs", $"getvoucherrequest_unipin_{DateTime.Now:yyyyMMdd}.log");
                var sb = new StringBuilder();
                sb.AppendLine(ex.ToString());
                sb.AppendLine(url);
                sb.AppendLine("Request");
                sb.AppendLine(json);
                sb.AppendLine("Response");
                sb.AppendLine(resultJson);
                File.WriteAllText(path, sb.ToString(), Encoding.UTF8);
                throw new Exception($"ERRO AO CHAMAR API GET VOUCHER REQUEST - UNIPIN", ex);
            }
        }
        public VoucherRequestResult InquiryVoucher(string refNumber)
        {
            string json = null;
            string resultJson = null;
            string uriPath = "voucher/inquiry";
            var url = $"{apiUrl}{uriPath}";
            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            var auth = GetSignature(partnerId, refNumber);
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var contractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy() };
                    json = JsonConvert.SerializeObject(new { reference_no = refNumber, partner_guid = partnerId, signature = auth }, new JsonSerializerSettings { ContractResolver = contractResolver });
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var resp = client.PostAsync(url, content).Result;
                    resultJson = resp.Content.ReadAsStringAsync().Result;
                    resp.EnsureSuccessStatusCode();
                    var result = JsonConvert.DeserializeObject<VoucherRequestResult>(resultJson);
                    return result;
                }
            }
            catch (Exception ex)
            {
                var path = Path.Combine(Environment.CurrentDirectory, "Logs", $"getvoucherrequest_unipin_{DateTime.Now:yyyyMMdd}.log");
                var sb = new StringBuilder();
                sb.AppendLine(ex.ToString());
                sb.AppendLine(url);
                sb.AppendLine("Request");
                sb.AppendLine(json);
                sb.AppendLine("Response");
                sb.AppendLine(resultJson);
                File.WriteAllText(path, sb.ToString(), Encoding.UTF8);
                throw new Exception($"ERRO AO CHAMAR API GET VOUCHER REQUEST - UNIPIN", ex);
            }
        }
        public BalanceResult InquiryBalance()
        {
            string json = null;
            string resultJson = null;
            string uriPath = "voucher/balance";
            var url = $"{apiUrl}{uriPath}";
            var auth = GetSignature(partnerId);
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var contractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy() };
                    json = JsonConvert.SerializeObject(new { partner_guid = partnerId, signature = auth }, new JsonSerializerSettings { ContractResolver = contractResolver });
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var resp = client.PostAsync(url, content).Result;
                    resultJson = resp.Content.ReadAsStringAsync().Result;
                    resp.EnsureSuccessStatusCode();
                    var result = JsonConvert.DeserializeObject<BalanceResult>(resultJson);
                    return result;
                }
            }
            catch (Exception ex)
            {
                var path = Path.Combine(Environment.CurrentDirectory, "Logs", $"getvoucherrequest_unipin_{DateTime.Now:yyyyMMdd}.log");
                var sb = new StringBuilder();
                sb.AppendLine(ex.ToString());
                sb.AppendLine(url);
                sb.AppendLine("Request");
                sb.AppendLine(json);
                sb.AppendLine("Response");
                sb.AppendLine(resultJson);
                File.WriteAllText(path, sb.ToString(), Encoding.UTF8);
                throw new Exception($"ERRO AO CHAMAR API GET VOUCHER REQUEST - UNIPIN", ex);
            }
        }
        public string GetSignature(params string[] fields)
        {
            var value = string.Join("", fields) + secret;
            var crypt = new SHA256Managed();
            var hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(value));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }
    }
}
