using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowGames.Models.AquiPaga
{
    public class Product
    {
        public string Name { get; set; }
        public string ProviderCode { get; set; }
        public string ProductCode { get; set; }
        public string Description { get; set; }
        public object ReferenceLength { get; set; }
        public bool IsVoucher { get; set; }
        public List<ProductOptionsList> ProductOptionsList { get; set; }
        public object InternationalProductOptionsList { get; set; }
        public object VisibleFields { get; set; }
        public object MandatoryFields { get; set; }
        public string NextMethodCall { get; set; }
        public object GroupCode { get; set; }
        public object VFPCode { get; set; }
        public object VGPCode { get; set; }
        public object GeneralDataMessage { get; set; }
        public object DealerCode { get; set; }
        public object GroupKey { get; set; }
        public object ImageCode { get; set; }
    }
}
