using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ScriptGame
{
    // DiceConfiguration class: Chech user input  
    class DiceChechInput
    {
        private HelpDesk helpDesk = new HelpDesk();
        private GenerateNumber generateNumber = new GenerateNumber();
        public static bool CheckRangeStringReturn(string[] args) 
        {

            if (args.Length < 3)
            {
                Console.WriteLine("Error: At least 3 dice configurations are required.");
                Console.WriteLine("Example: 2,2,4,4,9,9 6,8,1,1,8,6 7,5,3,7,5,3");
                return false;
            }
            return true;
        }

        public static bool CheckDiceConfigReturn(string[] args)
        {
            foreach (var arg in args)
            {
                var values = arg.Split(',');
                if (values.Length != 6 || !values.All(v => int.TryParse(v, out _)))
                {
                    Console.WriteLine($"Error: Invalid dice configuration \"{arg}\".");
                    Console.WriteLine("Each dice must have exactly 6 integers separated by commas.");
                    Console.WriteLine("Example: 2,2,4,4,9,9");
                    return false;
                }

            }
            return true;
        }

        public static bool CheckIdenticalCubesReturn(string[] args)
        {


            HashSet<string> uniqueGroups = new HashSet<string>();

            foreach (string group in args)
            {
                if (!uniqueGroups.Add(group))
                {
                    Console.WriteLine($"Repeating line: {group} , please enter the correct line, ex: 2,2,4,4,9,9 1,1,6,6,8,8 3,3,5,5,7,7 there may be more cubes");
                    return false;
                }


            }

            return true;
        }



        public string GetValidatedInput(string[] args)
        {
            string input;

            while (true)
            {
                input = Console.ReadLine()?.Trim().ToUpper();

                if (input == "X")
                {
                    Console.WriteLine("Goodbye!");
                    Environment.Exit(1);
                }
                else if (input == "?")
                {
                    helpDesk.DrawHelp();
                    helpDesk.DisplayProbabilityTable(DiceChechInput.ParseDiceConfigurations(args));
                    continue;
                }
                else if (int.TryParse(input, out int number) && number >= 0 && number <= 5)
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number between 0 and 5, 'X' to exit, or '?' for help.");
                }

            }

        }

        public int CheckCoincidences(int argsIndexUser, int argsIndexComputer, string[] args)
        {
            while (true)
            {
                if (argsIndexUser != argsIndexComputer)
                {
                    return argsIndexComputer;
                }
                else
                {
                    argsIndexComputer = generateNumber.GenerateNumberArgsIndex(args);
                }
            }
            return argsIndexComputer;


        }


        public static List<int[]> ParseDiceConfigurations(string[] args)
        {
            var diceConfigurations = new List<int[]>();

            foreach (var arg in args)
            {
                var values = arg.Split(',');

                diceConfigurations.Add(values.Select(int.Parse).ToArray());
            }

            return diceConfigurations;
        }
    }
}
