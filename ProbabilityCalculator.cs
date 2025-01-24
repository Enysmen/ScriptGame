using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptGame
{
    public class ProbabilityCalculator
    {
        public double GetWinProbability(int[] userDice, int[] opponentDice)
        {
            if (userDice == null || opponentDice == null)
                throw new ArgumentException("Cube lists cannot be empty.");

            int userWins = 0;
            int totalRolls = userDice.Length * opponentDice.Length;

            foreach (int userRoll in userDice)
            {
                foreach (int opponentRoll in opponentDice)
                {
                    if (userRoll > opponentRoll)
                    {
                        userWins++;
                    }
                }
            }

            return (double)userWins / totalRolls;
        }
    }
}
