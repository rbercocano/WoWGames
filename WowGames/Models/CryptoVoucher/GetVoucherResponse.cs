using System;

namespace WowGames.Models.CryptoVoucher
{
    public class GetVoucherResponse
    {
        public string OrderId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Code { get; set; }
    }
}
