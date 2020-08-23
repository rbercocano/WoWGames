using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowGames.Models.AquiPaga
{
    public class AuthenticationRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string TerminalKey { get; set; }
    }
}
