using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;


namespace ScriptGame
{
    class HelpDesk
    {
        private ProbabilityCalculator _probabilityCalculator = new ProbabilityCalculator();



        public void DrawHelp()
        {

            Console.WriteLine("HMAC and KEY provide guarantees that the computer did not cheat, " +
                "\nas a user you can take a number and a key and with this get the same HMAC and be convinced\n");

            Console.WriteLine("The number is generated using a cryptographically secure random generator (RandomNumberGenerator C#)\n");

            Console.WriteLine("The beginning of the game is choosing who will be the first to choose the dice.");

        }


        public void DisplayProbabilityTable(List<int[]> diceConfigs)
        {
            Console.WriteLine("Probability of the win for the user:");

            var tableHeaders = new List<string> { "User dice v" };
            foreach(var config in diceConfigs)
            {
                tableHeaders.Add(string.Join(",", config));
            }

            var table = new ConsoleTable(tableHeaders.ToArray());

            for (int i = 0; i < diceConfigs.Count; i++)
            {
                var row = new List<string> { string.Join(",", diceConfigs[i]) };

                for (int j = 0; j < diceConfigs.Count; j++)
                {
                    if (i == j)
                    {
                        row.Add("- (0.3333)");
                    }
                    else
                    {
                        double probability = _probabilityCalculator.GetWinProbability(diceConfigs[i], diceConfigs[j]);
                        row.Add(probability.ToString("0.0000"));
                    }
                }

                table.AddRow(row.ToArray());
            }

            table.Write(Format.Alternative);
        }


    }

}

