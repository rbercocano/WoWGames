using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowGames.Models.AquiPaga
{
    public class ProductTypeResponse : ResponseBase
    {
        public List<ProductType> AvailableProductTypeList { get; set; }
    }
}
