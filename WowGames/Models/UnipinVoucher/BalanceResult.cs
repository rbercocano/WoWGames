using Newtonsoft.Json;

namespace WowGames.Models.UnipinVoucher
{

    public class BalanceResult
    {
        [JsonProperty("balance")]
        public int Balance { get; set; }
        [JsonProperty("status")]
        public int Status { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
    }

}
