using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
namespace beGreen.WebApplication.Authentication.Aut_Services
{
    public class TokenStoreSecurityService
    {
        public static byte[] GetSha256Hash(string input)
        {
            using (var hashAlgorithm = new SHA256CryptoServiceProvider())
            {
                var byteValue = Encoding.UTF8.GetBytes(input);
                return hashAlgorithm.ComputeHash(byteValue);
            }
        }
    }
}
