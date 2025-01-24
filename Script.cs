using System;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using RandomOrg.CoreApi;
using RandomOrg.CoreApi.Errors;
using ConsoleTables;


// 1. nietu dokazujemoj cziesnoj generacyji sluczajnogo czisla 
// 2. nietu klassa abstrakcyji kosciej 
// 3. nietu klasa kotoryj analizirujet konfiguracyju 



namespace ScriptGame
{

    class GameLogic
    {
        private int computerChoice;
        private string? userInput;
        private int userInputInt;
        private int argsIndexUser;
        private int argsIndexComputer;
        private int rezultCalculation;
        private int rezultDiceNumber1;
        private int rezultDiceNumber2;
        private byte[] bytes;
        private string key;
        private GenerateNumber generateNumber = new GenerateNumber();
        private HelpDesk helpDesk = new HelpDesk();
        private Calculation calculation = new  Calculation();
        private DiceChechInput diceChechInput = new DiceChechInput();
        private Rezult rezult = new Rezult();


        public void StartGame(string[] args)
        {

            while (true)
            {

                computerChoice = generateNumber.GenerateNumberArgsAndChoise();
                bytes = RandomGeneratorKey.GenerateKey();
                key = RandomGeneratorKey.ConvertKeyToHexString(bytes);

                // Determine first player
                Console.WriteLine("Let's determine who makes the first move.");
                Console.WriteLine($"I selected a random value in the range 0..5 (HMAC={HMACGenerator.ComputeHMAC(bytes,Convert.ToString(computerChoice))}).");
                Console.WriteLine("Try to guess my selection.");
                Console.WriteLine("\n0 - 0\n1 - 1\n2 - 2\n3 - 3\n4 - 4\n5 - 5\nX - exit\n? - help");
                Console.WriteLine($"Your selection: {userInput = diceChechInput.GetValidatedInput(args)} ;");

                

                userInputInt = int.Parse(userInput);

                if (userInputInt < computerChoice)
                {
                    argsIndexComputer = generateNumber.GenerateNumberArgsIndex(args);

                    Console.WriteLine($"My selection: {computerChoice} (KEY={key}).");
                    Console.WriteLine($"I make the first move and choose the [{args[argsIndexComputer]}] dice.");
                    Console.WriteLine("Choose your dice:");

                    for (int i = 0;i < args.Length; i++)
                    {
                        if (!(args[argsIndexComputer] == args[i]))
                        {
                            Console.WriteLine($"{i} - {args[i]}");
                        }

                    }

                    Console.WriteLine("X - exit\n? - help");
                    Console.WriteLine($"Your selection:{userInput = diceChechInput.GetValidatedInput(args)}");

                    argsIndexUser = int.Parse(userInput);

                    Console.WriteLine($"You choose the [{args[argsIndexUser]}] dice.");

                    computerChoice = generateNumber.GenerateNumberArgsAndChoise();
                    bytes = RandomGeneratorKey.GenerateKey();
                    key = RandomGeneratorKey.ConvertKeyToHexString(bytes);

                    Console.WriteLine("It's time for my throw.");
                    Console.WriteLine($"I selected a random value in the range 0..5 (HMAC={HMACGenerator.ComputeHMAC(bytes, Convert.ToString(computerChoice))}).");
                    Console.WriteLine("Add your number modulo 6.");
                    Console.WriteLine("\n0 - 0\n1 - 1\n2 - 2\n3 - 3\n4 - 4\n5 - 5\nX - exit\n? - help");
                    Console.WriteLine($"Your selection:{userInput = diceChechInput.GetValidatedInput(args)}");

                    Console.WriteLine($"My number is {computerChoice} (KEY={key})");

                    rezultCalculation = calculation.CalculationChoiseNumberInDice(int.Parse(userInput), computerChoice);
                    rezultDiceNumber1 = calculation.GetDiceFacesNumber(rezultCalculation, args, argsIndexComputer);

                    Console.WriteLine($"The result is {userInput} + {computerChoice} = {rezultCalculation}  (mod 6).");
                    Console.WriteLine($"My throw is {rezultDiceNumber1}.");

                    computerChoice = generateNumber.GenerateNumberArgsAndChoise();
                    bytes = RandomGeneratorKey.GenerateKey();
                    key = RandomGeneratorKey.ConvertKeyToHexString(bytes);

                    Console.WriteLine("It's time for your throw.");
                    Console.WriteLine($"I selected a random value in the range 0..5 (HMAC={HMACGenerator.ComputeHMAC(bytes, Convert.ToString(computerChoice))}).");
                    Console.WriteLine("Add your number modulo 6.");
                    Console.WriteLine("\n0 - 0\n1 - 1\n2 - 2\n3 - 3\n4 - 4\n5 - 5\nX - exit\n? - help");
                    Console.WriteLine($"Your selection:{userInput = diceChechInput.GetValidatedInput(args)}");
                    Console.WriteLine($"My number is {computerChoice} (KEY={key})");

                    rezultCalculation = calculation.CalculationChoiseNumberInDice(int.Parse(userInput), computerChoice);
                    rezultDiceNumber2 = calculation.GetDiceFacesNumber(rezultCalculation, args, argsIndexUser);

                    Console.WriteLine($"The result is {userInput} + {computerChoice} = {rezultCalculation}  (mod 6).");
                    Console.WriteLine($"Your throw is {rezultDiceNumber2}.");
                    rezult.WhoWin(rezultDiceNumber1, rezultDiceNumber2);

                }
                else 
                {

                    Console.WriteLine($"My selection: {computerChoice} (KEY={key}).");
                    Console.WriteLine($"You make the first move and choose the dice.");
                    Console.WriteLine("Choose your dice:");

                    for (int i = 0; i < args.Length; i++)
                    {
                       Console.WriteLine($"{i} - {args[i]}");
                    }

                    Console.WriteLine("X - exit\n? - help");
                    Console.WriteLine($"Your selection:{userInput = diceChechInput.GetValidatedInput(args)}");

                    argsIndexUser = int.Parse(userInput);

                    Console.WriteLine($"You choose the [{args[argsIndexUser]}] dice.");

                    argsIndexComputer = generateNumber.GenerateNumberArgsIndex(args);
                    argsIndexComputer = diceChechInput.CheckCoincidences(argsIndexUser, argsIndexComputer,args);

                    Console.WriteLine($"I choose the [{args[argsIndexComputer]}] dice.");

                    computerChoice = generateNumber.GenerateNumberArgsAndChoise();
                    bytes = RandomGeneratorKey.GenerateKey();
                    key = RandomGeneratorKey.ConvertKeyToHexString(bytes);


                    Console.WriteLine("It's time for you throw.");
                    Console.WriteLine($"I selected a random value in the range 0..5 (HMAC={HMACGenerator.ComputeHMAC(bytes, Convert.ToString(computerChoice))}).");
                    Console.WriteLine("Add your number modulo 6.");
                    Console.WriteLine("\n0 - 0\n1 - 1\n2 - 2\n3 - 3\n4 - 4\n5 - 5\nX - exit\n? - help");
                    Console.WriteLine($"Your selection:{userInput = diceChechInput.GetValidatedInput(args)}");
                    Console.WriteLine($"My number is {computerChoice} (KEY={key})");

                    rezultCalculation = calculation.CalculationChoiseNumberInDice(int.Parse(userInput), computerChoice);
                    rezultDiceNumber1 = calculation.GetDiceFacesNumber(rezultCalculation, args, argsIndexUser); 

                    Console.WriteLine($"The result is {userInput} + {computerChoice} = {rezultCalculation}  (mod 6).");
                    Console.WriteLine($"Your throw is {rezultDiceNumber1}.");

                    computerChoice = generateNumber.GenerateNumberArgsAndChoise();
                    bytes = RandomGeneratorKey.GenerateKey();
                    key = RandomGeneratorKey.ConvertKeyToHexString(bytes);

                    Console.WriteLine("It's time for my throw.");
                    Console.WriteLine($"I selected a random value in the range 0..5 (HMAC={HMACGenerator.ComputeHMAC(bytes, Convert.ToString(computerChoice))}).");
                    Console.WriteLine("Add your number modulo 6.");
                    Console.WriteLine("\n0 - 0\n1 - 1\n2 - 2\n3 - 3\n4 - 4\n5 - 5\nX - exit\n? - help");
                    Console.WriteLine($"Your selection:{userInput = diceChechInput.GetValidatedInput(args)}");
                    Console.WriteLine($"My number is {computerChoice} (KEY={key})");

                    rezultCalculation = calculation.CalculationChoiseNumberInDice(int.Parse(userInput), computerChoice);
                    rezultDiceNumber2 = calculation.GetDiceFacesNumber(rezultCalculation, args, argsIndexComputer);

                    Console.WriteLine($"The result is {userInput} + {computerChoice} = {rezultCalculation}  (mod 6).");
                    Console.WriteLine($"My throw is {rezultDiceNumber2}.");
                    rezult.WhoWin(rezultDiceNumber2, rezultDiceNumber1);




                }

                
            }


        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello!!!");

            GameLogic gameLogic = new GameLogic();

            if (DiceChechInput.CheckDiceConfigReturn(args))
            {
                if (DiceChechInput.CheckRangeStringReturn(args))
                {
                    if (DiceChechInput.CheckIdenticalCubesReturn(args))
                    {
                        gameLogic.StartGame(args);
                    }
                    else 
                    {
                        Environment.Exit(-1);
                    }
                }
            }



            

        }
    }
}