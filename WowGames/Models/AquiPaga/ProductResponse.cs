using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowGames.Models.AquiPaga
{
    public class ProductResponse : ResponseBase
    {
        public List<Product> AvailableProductList { get; set; }
    }
}
