using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowGames.Models.CryptoVoucher
{
    public class Credentials
    {
        public string Login => ConfigurationManager.AppSettings["CryptoVoucherLogin"];
        public string Password => ConfigurationManager.AppSettings["CryptoVoucherPassword"];
    }
}
