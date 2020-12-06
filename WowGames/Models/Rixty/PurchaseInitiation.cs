using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowGames.Models.Rixty
{
    public class PurchaseInitiation
    {
        public string ReferenceId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string ProductCode { get; set; }
        public string Quantity { get; set; }
        public string InitiationResultCode { get; set; }
        public string ValidatedToken { get; set; }
        public string Currency { get; set; }
        public string EstimateUnitPrice { get; set; }
        public string Version { get; set; }
        public string Signature { get; set; }
        public string ApplicationCode { get; set; }
    }
}
