using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowGames.Models.AquiPaga
{
    public class PurchaseDetails
    {
        public string Date { get; set; }
        public string Amount { get; set; }
        public string ProviderTransactionId { get; set; }
        public string Reference { get; set; }
        public string SerialNumber { get; set; }
        public string Message { get; set; }
    }
}
