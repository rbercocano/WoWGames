using Newtonsoft.Json;
using System.Collections.Generic;

namespace WowGames.Models.UnipinVoucher
{
    public class Denomination
    {
        [JsonProperty("denomination_code")]
        public string Code { get; set; }
        [JsonProperty("denomination_name")]
        public string Name { get; set; }
        [JsonProperty("denomination_currency")]
        public string Currency { get; set; }
        [JsonProperty("denomination_amount")]
        public string Amount { get; set; }
    }

    public class VoucherDetailsResult
    {
        [JsonProperty("voucher_name")]
        public string Name { get; set; }
        [JsonProperty("voucher_code")]
        public string Code { get; set; }
        [JsonProperty("icon_url")]
        public string IconUrl { get; set; }
        [JsonProperty("denominations")]
        public List<Denomination> Denominations { get; set; }
        [JsonProperty("status")]
        public int Status { get; set; }
    }

}
