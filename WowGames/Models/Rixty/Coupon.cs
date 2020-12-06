using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowGames.Models.Rixty
{
    public class Coupon
    {
        public DateTime ExpiryDate { get; set; }
        public List<string> Serials { get; set; }
        public List<string> Pins { get; set; }
    }
}
