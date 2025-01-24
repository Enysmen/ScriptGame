using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptGame
{
    class Calculation
    {
        public int CalculationChoiseNumberInDice(int userInput, int computerChoise)
        {
            int diceFaces = 6;
            int result = (computerChoise + userInput) % diceFaces;

            return result;
        }

        public int GetDiceFacesNumber(int rezultCalculation, string[] args, int choiseDice)
        {


            List<int[]> diceSets = args.Select(arg => arg.Split(',').Select(int.Parse).ToArray()).ToList();

            int[] computerDice = diceSets[choiseDice];

            int diceResult = computerDice[rezultCalculation];

            return diceResult;
        }

    }
}
