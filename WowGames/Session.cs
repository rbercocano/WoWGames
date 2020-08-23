using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowGames
{
    public class Session
    {
        private Session()
        {

        }
        private static object _lock = new object();
        private static Session _instance;
        public static Session Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        _instance = new Session();
                    }
                }
                return _instance;
            }
        }
        public string AquiPagaToken { get; set; }
        public DateTime AquiPagaTokenExpiration { get; set; }
    }
}
