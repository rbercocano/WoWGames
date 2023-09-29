using Newtonsoft.Json;
using System.Collections.Generic;

namespace WowGames.Models.UnipinVoucher
{
    public class VoucherListResult
    {
        [JsonProperty("voucher_list")]
        public List<VoucherList> Vouchers { get; set; }
        [JsonProperty("status")]
        public int Status { get; set; }
    }

    public class VoucherList
    {
        [JsonProperty("voucher_code")]
        public string Code { get; set; }
        [JsonProperty("voucher_name")]
        public string Name { get; set; }
        [JsonProperty("icon_url")]
        public string Url { get; set; }
    }
}
