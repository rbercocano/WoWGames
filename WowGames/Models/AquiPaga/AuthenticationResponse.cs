using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowGames.Models.AquiPaga
{
    public class AuthenticationResponse : ResponseBase
    {
        public string Token { get; set; }
        public string Plafond { get; set; }
    }
}
