using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ScriptGame
{
    
    public class RandomGeneratorKey
    {
        private static RandomNumberGenerator _rng = RandomNumberGenerator.Create();

        public static byte[] GenerateKey(int length = 32)
        {

            var key = new byte[length];
            _rng.GetBytes(key);
            return key;
        }

        public static string ConvertKeyToHexString(byte[] bytes)
        {
            return BitConverter.ToString(bytes).Replace("-", "");
        }



    }
}
