using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Web;

namespace NBP.Logger.Client
{
    public static class RandomGenerator
    {
        internal static string GetStringSha256Hash(string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            using (var sha = new SHA256Managed())
            {
                byte[] textData = Encoding.UTF8.GetBytes(text);
                byte[] hash = sha.ComputeHash(textData);
                return BitConverter.ToString(hash).Replace("-", string.Empty);
            }
        }

        public static string GenerateRandomMobileNumber()
        {
            Random R = new Random();

            return ((long)R.Next(0, 100000) * (long)R.Next(0, 100000)).ToString().PadLeft(10, '0');
        }

        public static string GenerateRandomUsername()
        {
            string token = Guid.NewGuid().ToString();
            var bytes = Encoding.UTF8.GetBytes(token);
            return Convert.ToBase64String(bytes);
        }

        public static string GenerateRandomPassword()
        {
            return GetStringSha256Hash(GenerateRandomUsername());
        }

        public static string GenerateRandomMail()
        {
            return string.Concat(GenerateRandomUsername().Take(10)) + "@" + "gmail.com";
        }
    }
}
