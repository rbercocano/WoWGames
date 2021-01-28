using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowGames.Models.Enterative
{
    public class ActivationResponse
    {
        public string Merchant { get; set; }
        public string Shop { get; set; }
        public string Terminal { get; set; }
        public string Response { get; set; }
        public string ActivationType { get; set; }
        public string CallbackURL { get; set; }
        public List<ResponseLine> Lines { get; set; }
    }
}
