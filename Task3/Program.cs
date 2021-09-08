using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            if (CheckArguments(args))
                StartGame(args);

        }

        static private void StartGame(string[] args)
        {
            VictimsTable victimsTable = new VictimsTable(args);
            Cryptography cryptography = new Cryptography();
            cryptography.CalculateSecretKey();
            int computerChoise = cryptography.GetComputerChoise(args);
            ShowHMAC(cryptography.GetHMAC(args[computerChoise]));
            ShowMenu(args);
            int userChoise = GetUserChoise(args.Length);
            switch (userChoise)
            {
                case -1:
                    Help help = new Help(args, victimsTable);
                    ShowHelp(help.GenerateHelp());
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
                default:
                    Game game = new Game(victimsTable);
                    string result = game.CalculateResult(computerChoise, userChoise - 1);
                    ShowResult(result, args[userChoise-1], args[computerChoise], cryptography.GetSecretKey());
                    break;
            }
            StartGame(args);
        }

        static private bool CheckArguments(string[] arguments)
        {
            if (WrongArgumentsCount(arguments.Length))
            {
                Console.WriteLine("Number of elements must be odd and >=3");
                return false;
            }
            if (SameArguments(arguments))
            {
                Console.WriteLine("All elements must be different");
                return false;
            }
            return true;
        }

        static private bool WrongArgumentsCount(int argumentsCount)
        {
            if (argumentsCount < 3)
                return true;
            if (argumentsCount % 2 == 0)
                return true;
            return false;
        }

        static private bool SameArguments(string[] arguments)
        {
            for (int i = 0; i < arguments.Length; i++)
            {
                for (int g = i+1; g < arguments.Length; g++)
                {
                    if (arguments[i] == arguments[g])
                        return true;
                }
            }
            return false;
        }

        static private void ShowHMAC(string hmac)
        {
            Console.WriteLine("HMAC:");
            Console.WriteLine(hmac);
            Console.WriteLine();
        }

        static private void ShowMenu(string[] arguments)
        {
            Console.WriteLine("Available moves:");
            Console.WriteLine();

            for (int i = 1; i <= arguments.Length; i++)
            {
                Console.WriteLine(i + ": " + arguments[i - 1]);
                Console.WriteLine();
            }

            Console.WriteLine("0: exit");
            Console.WriteLine();
            Console.WriteLine("?: help");
            Console.WriteLine();
        }

        static private void ShowHelp(string[] helpText)
        {
            foreach (string element in helpText)
                Console.WriteLine(element);
            Console.WriteLine();
        }

        static private int GetUserChoise(int availableChoises)
        {
            Console.Write("Enter your move: ");
            string userString = Console.ReadLine();
            if (userString == "?")
                return -1;
            if (int.TryParse(userString, out int result))
                if (result < 0 || result > availableChoises)
                {
                    Console.WriteLine("Incorrect value!");
                    GetUserChoise(availableChoises);
                }
            return result;
        }

        static private void ShowResult(string result, string userChoise, string computerChoise, string secretKey)
        {
            Console.WriteLine("Your move: " + userChoise);
            Console.WriteLine("Computer move: " + computerChoise);
            Console.WriteLine("Result: " + result);
            Console.WriteLine("HMAC key: " + secretKey);
            Console.WriteLine();
        }
    }
}

