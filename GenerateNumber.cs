using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace ScriptGame
{
    class GenerateNumber
    {


        public int GenerateNumberArgsIndex(string[] args)
        {
            int index = RandomNumberGenerator.GetInt32(0, args.Length);
            return index;
        }

        public int GenerateNumberArgsAndChoise()
        {
            int index = RandomNumberGenerator.GetInt32(0, 6);  // arg1: min arg2:max
            return index;

        }


    }
}
