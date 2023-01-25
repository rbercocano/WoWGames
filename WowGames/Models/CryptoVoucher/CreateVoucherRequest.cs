using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowGames.Models.CryptoVoucher
{
    public class CreateVoucherRequest : Credentials
    {
        public CreateVoucherRequest()
        {
            OrderId = Guid.NewGuid().ToString();
        }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string OrderId { get; set; }

    }
}
