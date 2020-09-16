using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowGames.Models.Rixty
{
    public class PurchaseConfirmation
    {
        public string ReferenceId { get; set; }
        public string PaymentId { get; set; }
        public string UserId { get; set; }
        public string ProductCode { get; set; }
        public string Quantity { get; set; }
        public string DeliveredQuantity { get; set; }
        public string Currency { get; set; }
        public string UnitPrice { get; set; }
        public string TotalPrice { get; set; }
        public string MerchantProductCode { get; set; }
        public string PurchaseStatusCode { get; set; }
        public DateTime PurchaseStatusDate { get; set; }
        public List<Coupon> Coupons { get; set; }
        public string ProductDescription { get; set; }
        public string TotalPayablePrice { get; set; }
        public string Version { get; set; }
        public string Signature { get; set; }
        public string ApplicationCode { get; set; }
    }
}
