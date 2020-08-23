using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowGames.Models
{
    public class ProductDetails
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string PrecoDisplay { get { return Preco?.ToString("C"); } }
        public double? Preco { get; set; }
        public string ProductTypeCode { get; set; }
        public string ProviderCode { get; set; }
        public string ProductCode { get; set; }
        public string ProductOptionCode { get; set; }
        public string Description { get; set; }
        
    }
}
