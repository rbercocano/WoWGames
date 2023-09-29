using Newtonsoft.Json;

namespace WowGames.Models.TopUp
{
    public class InquiryResult
    {
        [JsonProperty("status")]
        public int Status { get; set; }
        [JsonProperty("reason")]
        public string Reason { get; set; }
        [JsonProperty("item_name")]
        public string Item { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("amount")]
        public double Amount { get; set; }
        [JsonProperty("reference_no")]
        public string RefNumber { get; set; }
        [JsonProperty("transaction_number")]
        public string TransactionId { get; set; }
    }
}
