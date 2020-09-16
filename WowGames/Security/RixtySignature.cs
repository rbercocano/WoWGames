using System.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace WowGames.Security
{
    public class RixtySignature
    {
        public static string GeneratePurchaseConfirmationSignature(string validatedToken, string referenceId)
        {
            var secret = ConfigurationManager.AppSettings["RixtySecret"];
            var version = ConfigurationManager.AppSettings["RixtyGoldApiVersion"];
            var applicationCode = ConfigurationManager.AppSettings["RixtyAppCode"];
            var input = $"{applicationCode}{referenceId}{version}{validatedToken}{secret}";
            return Hash(input);
        }

        private static string Hash(string input)
        {
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
