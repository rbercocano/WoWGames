using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowGames.Models
{
    public class EpayProductPurchase
    {
        public string Nome { get; set; }
        public int Amount { get; set; }
        public string Preco { get; set; }
        public string SKU { get; set; }
        public string EAN { get; set; }
        public string Provider { get; set; }
        public string Enabled { get; set; }

    }
}
