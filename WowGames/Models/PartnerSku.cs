using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowGames.Models
{
    public class PartnerSku
    {
        public int Id { get; set; }
        public string SKU { get; set; }
        public string Description { get; set; }
        public int PartnerId { get; set; }
        public string Partner { get; set; }
        public string Valor { get; set; }
    }
}
