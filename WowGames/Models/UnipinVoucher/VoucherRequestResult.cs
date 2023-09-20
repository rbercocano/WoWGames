using Newtonsoft.Json;
using System.Collections.Generic;

namespace WowGames.Models.UnipinVoucher
{
    public class VoucherRequestResult
    {
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("reference_no")]
        public int RefNumber { get; set; }
        [JsonProperty("order")]
        public string Order { get; set; }
        [JsonProperty("total_amount")]
        public int Amount { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("items")]
        public List<Item> Items { get; set; }
        [JsonProperty("signature")]
        public string Signature { get; set; }
        [JsonProperty("balance")]
        public int Balance { get; set; }
        [JsonProperty("status")]
        public int Status { get; set; }
    }
    public class Item
    {
        [JsonProperty("serial_1")]
        public string Serial1 { get; set; }
        [JsonProperty("serial_2")]
        public string Serial2 { get; set; }
    }

}
