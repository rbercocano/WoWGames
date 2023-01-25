using System;

namespace WowGames.Models.CryptoVoucher
{
    public class CreateVoucherResponse 
    {
        public DateTime CreatedAt { get; set; }
        public string Code { get; set; }
        public string OrderId { get; set; }

    }
}
