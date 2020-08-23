using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowGames.Models.AquiPaga
{
    public class TransactionRequest
    {
        public string Token { get; set; }
        public string ProductTypeCode { get; set; }
        public string ProviderCode { get; set; }
        public string ProductCode { get; set; }
        public string ProductOptionCode { get; set; }
        public double Amount { get; set; }
    }
}
