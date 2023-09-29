using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using WowGames.Models.TopUp;
using System.Linq;

namespace WowGames.Proxy
{
    public class UnipinTopUpProxy
    {
        public readonly string partnerId = ConfigurationManager.AppSettings["UniPinPID"].ToString();
        public readonly string apiUrl = ConfigurationManager.AppSettings["UniPinUrl"].ToString();
        public readonly string secret = ConfigurationManager.AppSettings["UniPinSecret"].ToString();
        public readonly string userid = ConfigurationManager.AppSettings["UniPinUserId"].ToString();
        public readonly string zoneid = ConfigurationManager.AppSettings["UniPinZoneId"].ToString();
        public GamesListResult GetGameList()
        {
            string json = null;
            string resultJson = null;
            string uriPath = "in-game-topup/list";
            var url = $"{apiUrl}{uriPath}";
            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            var auth = GetAuth(uriPath, timestamp);
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("partnerid", partnerId);
                    client.DefaultRequestHeaders.Add("timestamp", timestamp.ToString());
                    client.DefaultRequestHeaders.Add("path", uriPath);
                    client.DefaultRequestHeaders.Add("auth", auth);

                    var contractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy() };
                    json = JsonConvert.SerializeObject("", new JsonSerializerSettings { ContractResolver = contractResolver });
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var resp = client.PostAsync(url, content).Result;
                    resultJson = resp.Content.ReadAsStringAsync().Result;
                    resp.EnsureSuccessStatusCode();
                    var result = JsonConvert.DeserializeObject<GamesListResult>(resultJson);
                    return result;
                }
            }
            catch (Exception ex)
            {
                var path = Path.Combine(Environment.CurrentDirectory, "Logs", $"getgamelist_unipin_{DateTime.Now:yyyyMMdd}.log");
                var sb = new StringBuilder();
                sb.AppendLine(ex.ToString());
                sb.AppendLine(url);
                sb.AppendLine("Request");
                sb.AppendLine(json);
                sb.AppendLine("Response");
                sb.AppendLine(resultJson);
                File.WriteAllText(path, sb.ToString(), Encoding.UTF8);
                throw new Exception($"ERRO AO CHAMAR API GET GAME LIST - UNIPIN", ex);
            }
        }
        public GameDetailsResult GetGameDetails(string gameCode)
        {
            string json = null;
            string resultJson = null;
            string uriPath = "in-game-topup/detail";
            var url = $"{apiUrl}{uriPath}";
            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            var auth = GetAuth(uriPath, timestamp);
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("partnerid", partnerId);
                    client.DefaultRequestHeaders.Add("timestamp", timestamp.ToString());
                    client.DefaultRequestHeaders.Add("path", uriPath);
                    client.DefaultRequestHeaders.Add("auth", auth);

                    var contractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy() };
                    json = JsonConvert.SerializeObject(new { game_code = gameCode }, new JsonSerializerSettings { ContractResolver = contractResolver });
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var resp = client.PostAsync(url, content).Result;
                    resultJson = resp.Content.ReadAsStringAsync().Result;
                    resp.EnsureSuccessStatusCode();
                    var result = JsonConvert.DeserializeObject<GameDetailsResult>(resultJson);
                    return result;
                }
            }
            catch (Exception ex)
            {
                var path = Path.Combine(Environment.CurrentDirectory, "Logs", $"getgamedetails_unipin_{DateTime.Now:yyyyMMdd}.log");
                var sb = new StringBuilder();
                sb.AppendLine(ex.ToString());
                sb.AppendLine(url);
                sb.AppendLine("Request");
                sb.AppendLine(json);
                sb.AppendLine("Response");
                sb.AppendLine(resultJson);
                File.WriteAllText(path, sb.ToString(), Encoding.UTF8);
                throw new Exception($"ERRO AO CHAMAR API GET GAME Detail - UNIPIN", ex);
            }
        }
        public OrderResult CreateOrder(string gameCode, string validationToken, string refNumber, string denomination)
        {
            string json = null;
            string resultJson = null;
            string uriPath = "in-game-topup/order/create";
            var url = $"{apiUrl}{uriPath}";
            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            var auth = GetAuth(uriPath, timestamp);
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("partnerid", partnerId);
                    client.DefaultRequestHeaders.Add("timestamp", timestamp.ToString());
                    client.DefaultRequestHeaders.Add("path", uriPath);
                    client.DefaultRequestHeaders.Add("auth", auth);

                    var contractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy() };
                    json = JsonConvert.SerializeObject(new { game_code = gameCode, validation_token = validationToken, reference_no = refNumber, denomination_id = denomination }, new JsonSerializerSettings { ContractResolver = contractResolver });
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var resp = client.PostAsync(url, content).Result;
                    resultJson = resp.Content.ReadAsStringAsync().Result;
                    resp.EnsureSuccessStatusCode();
                    var result = JsonConvert.DeserializeObject<OrderResult>(resultJson);
                    return result;
                }
            }
            catch (Exception ex)
            {
                var path = Path.Combine(Environment.CurrentDirectory, "Logs", $"createorder_unipin_{DateTime.Now:yyyyMMdd}.log");
                var sb = new StringBuilder();
                sb.AppendLine(ex.ToString());
                sb.AppendLine(url);
                sb.AppendLine("Request");
                sb.AppendLine(json);
                sb.AppendLine("Response");
                sb.AppendLine(resultJson);
                File.WriteAllText(path, sb.ToString(), Encoding.UTF8);
                throw new Exception($"ERRO AO CHAMAR API CREATE ORDER - UNIPIN", ex);
            }
        }
        public ValidateUserResult ValidateUser(string gameCode, List<Field> fields)
        {
            var dicFields = new Dictionary<string, string>();
            if (fields.Any(f => f.Name == "userid"))
                dicFields["userid"] = userid;

            if (fields.Any(f => f.Name == "zoneid"))
                dicFields["zoneid"] = zoneid;

            string json = null;
            string resultJson = null;
            string uriPath = "in-game-topup/user/validate";
            var url = $"{apiUrl}{uriPath}";
            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            var auth = GetAuth(uriPath, timestamp);
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("partnerid", partnerId);
                    client.DefaultRequestHeaders.Add("timestamp", timestamp.ToString());
                    client.DefaultRequestHeaders.Add("path", uriPath);
                    client.DefaultRequestHeaders.Add("auth", auth);

                    var contractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy() };
                    json = JsonConvert.SerializeObject(new { game_code = gameCode, fields = dicFields }, new JsonSerializerSettings { ContractResolver = contractResolver });
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var resp = client.PostAsync(url, content).Result;
                    resultJson = resp.Content.ReadAsStringAsync().Result;
                    resp.EnsureSuccessStatusCode();
                    var result = JsonConvert.DeserializeObject<ValidateUserResult>(resultJson);
                    return result;
                }
            }
            catch (Exception ex)
            {
                var path = Path.Combine(Environment.CurrentDirectory, "Logs", $"validateUser_unipin_{DateTime.Now:yyyyMMdd}.log");
                var sb = new StringBuilder();
                sb.AppendLine(ex.ToString());
                sb.AppendLine(url);
                sb.AppendLine("Request");
                sb.AppendLine(json);
                sb.AppendLine("Response");
                sb.AppendLine(resultJson);
                File.WriteAllText(path, sb.ToString(), Encoding.UTF8);
                throw new Exception($"ERRO AO CHAMAR API VALIDATE USER - UNIPIN", ex);
            }
        }
        public InquiryResult Inquiry(string refNumber)
        {
            string json = null;
            string resultJson = null;
            string uriPath = "in-game-topup/order/inquiry";
            var url = $"{apiUrl}{uriPath}";
            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            var auth = GetAuth(uriPath, timestamp);
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("partnerid", partnerId);
                    client.DefaultRequestHeaders.Add("timestamp", timestamp.ToString());
                    client.DefaultRequestHeaders.Add("path", uriPath);
                    client.DefaultRequestHeaders.Add("auth", auth);

                    var contractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy() };
                    json = JsonConvert.SerializeObject(new { reference_no = refNumber }, new JsonSerializerSettings { ContractResolver = contractResolver });
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var resp = client.PostAsync(url, content).Result;
                    resultJson = resp.Content.ReadAsStringAsync().Result;
                    resp.EnsureSuccessStatusCode();
                    var result = JsonConvert.DeserializeObject<InquiryResult>(resultJson);
                    return result;
                }
            }
            catch (Exception ex)
            {
                var path = Path.Combine(Environment.CurrentDirectory, "Logs", $"inquiryorder_unipin_{DateTime.Now:yyyyMMdd}.log");
                var sb = new StringBuilder();
                sb.AppendLine(ex.ToString());
                sb.AppendLine(url);
                sb.AppendLine("Request");
                sb.AppendLine(json);
                sb.AppendLine("Response");
                sb.AppendLine(resultJson);
                File.WriteAllText(path, sb.ToString(), Encoding.UTF8);
                throw new Exception($"ERRO AO CHAMAR API INQUIRY ORDER - UNIPIN", ex);
            }
        }
        public string GetAuth(string path, long timestamp)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes($"{partnerId}{timestamp}{path}");
            using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secret)))
            {
                byte[] hashBytes = hmac.ComputeHash(inputBytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
    }
}
