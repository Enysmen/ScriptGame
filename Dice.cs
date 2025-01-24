using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ScriptGame
{
    //public class Dice
    //{
    //    public int Sides { get; private set; }
    //    private readonly RandomNumberGenerator _rng;

    //    public Dice(int sides)
    //    {
    //        if (sides <= 0)
    //            throw new ArgumentException("The number of faces must be positive.");

    //        Sides = sides;
    //        _rng = RandomNumberGenerator.Create();
    //    }

    //    public int Roll()
    //    {
    //        // Generate a random number between 1 and Sides inclusive
    //        return RandomNumberGenerator.GetInt32(1, Sides + 1);
    //    }

    //    public int[] RollMultiple(int rolls)
    //    {
    //        if (rolls <= 0)
    //            throw new ArgumentException("The number of throws must be positive.");

    //        int[] results = new int[rolls];
    //        for (int i = 0; i < rolls; i++)
    //        {
    //            results[i] = Roll();
    //        }
    //        return results;
    //    }
    //}
}
