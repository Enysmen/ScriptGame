using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ScriptGame
{
    // HMACGenerator class: Computes HMAC using SHA3
    class HMACGenerator
    {
        public static string ComputeHMAC(byte[] key, string message)
        {
            using (var hmac = new HMACSHA3_256(key))
            {
                var messageBytes = Encoding.UTF8.GetBytes(message);
                var hash = hmac.ComputeHash(messageBytes);
                return Convert.ToHexString(hash);
            }
        }
    }
}
