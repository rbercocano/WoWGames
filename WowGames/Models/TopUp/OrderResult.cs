using Newtonsoft.Json;

namespace WowGames.Models.TopUp
{
    public class OrderResult
    {
        [JsonProperty("transaction_number")]
        public string TransactionId { get; set; }
        [JsonProperty("reference_no")]
        public string Ref { get; set; }
        [JsonProperty("amount")]
        public int Amount { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("item_name")]
        public string Item { get; set; }
        [JsonProperty("status")]
        public int Status { get; set; }
        [JsonProperty("reason")]
        public string Reason { get; set; }
    }
}
