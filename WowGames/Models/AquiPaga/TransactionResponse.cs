using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowGames.Models.AquiPaga
{
    public class TransactionResponse : ResponseBase
    {
        public int Status { get; set; }
        public PaymentResultData PaymentResultData { get; set; }
    }
}
