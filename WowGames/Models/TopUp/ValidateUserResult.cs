using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace WowGames.Models.TopUp
{
    public class ValidateUserResult
    {
        [JsonProperty("username")]
        public string User { get; set; }
        [JsonProperty("validation_token")]
        public string ValidationToken { get; set; }
        [JsonProperty("status")]
        public int Status { get; set; }
        [JsonProperty("reason")]
        public string Reason { get; set; }
    }
}
