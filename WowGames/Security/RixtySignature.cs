using System.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace WowGames.Security
{
    public class RixtySignature
    {
        public static string GenerateSignature(string applicationCode, string productCode, string quantity, string referenceId)
        {
            var secret = ConfigurationManager.AppSettings["RixtySecret"];
            var version = ConfigurationManager.AppSettings["RixtyGoldApiVersion"];

            
            var input = $"{applicationCode}{productCode}{quantity}{referenceId}{version}{secret}";
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                    sb.Append(hashBytes[i].ToString("X2"));
                return sb.ToString();
            }
        }
    }
}
