using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptGame
{
    //public class DiceConfigAnalyzer
    //{
    //    public bool ValidateDiceConfig(int[] diceConfig)
    //    {
    //        if (diceConfig == null || diceConfig.Length == 0)
    //            throw new ArgumentException("The dice configuration cannot be empty.");

    //        // Checking that all values ​​are within the acceptable range
    //        if (diceConfig.Any(value => value <= 0))
    //        {
    //            Console.WriteLine("Error: The configuration contains invalid values.");
    //            return false;
    //        }

    //        return true;
    //    }

    //    public int GetTotalSum(int[] diceConfig)
    //    {
    //        if (!ValidateDiceConfig(diceConfig))
    //            throw new ArgumentException("The dice configuration is invalid.");

    //        return diceConfig.Sum();
    //    }

    //    public Dictionary<int, int> GetDiceFrequency(int[] diceConfig)
    //    {
    //        if (!ValidateDiceConfig(diceConfig))
    //            throw new ArgumentException("The dice configuration is invalid.");

    //        // Подсчет частоты появления каждого значения
    //        return diceConfig.GroupBy(value => value)
    //                         .ToDictionary(group => group.Key, group => group.Count());
    //    }

    //    public void DisplayDiceAnalysis(int[] diceConfig)
    //    {
    //        if (!ValidateDiceConfig(diceConfig))
    //            throw new ArgumentException("The dice configuration is invalid.");

    //        Console.WriteLine($"Analysis of bone configuration: {string.Join(",", diceConfig)}");
    //        Console.WriteLine($"Sum of all values: {GetTotalSum(diceConfig)}");
    //        Console.WriteLine("Frequency of values:");

    //        foreach (var pair in GetDiceFrequency(diceConfig))
    //        {
    //            Console.WriteLine($"Meaning {pair.Key}: {pair.Value} time(s)");
    //        }
    //    }
    //}
}
