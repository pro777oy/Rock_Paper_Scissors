using System.Security.Cryptography;
using System.Text;

namespace Rock_Paper_Scissors;
    public static class HmacGenerator
    {
        
        public static byte[] GenerateRandomKey()
        {
            var key = new byte[32]; 
            RandomNumberGenerator.Fill(key); 
            return key;
        }
        
        public static byte[] GenerateHmac(byte[] key, string message)
        {
            using var hmacSha256 = new HMACSHA256(key);
            return hmacSha256.ComputeHash(Encoding.UTF8.GetBytes(message));
        }
    }
