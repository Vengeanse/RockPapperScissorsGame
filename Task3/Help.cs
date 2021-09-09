using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    class Help
    {
        private string[] arguments;
        private VictimsTable victimsTable;

        public Help(string[] args, VictimsTable table) { arguments = args; victimsTable = table; }
        public string[] GenerateHelp()
        {
            const int reservedStringsForHelp = 12;
            const int reservedStringsForHeader = 2;
            const int reservedStrings = reservedStringsForHelp + reservedStringsForHeader;
            string[] helpText = new string [arguments.Length*2 + reservedStrings];


            helpText[0] = "";
            helpText[1] = "___HELP___";
            helpText[2] = "";
            helpText[3] = "At the beginning of the game, the computer chooses an item for itself.";
            helpText[4] = "After that, using the secret key and the name of the selected item, the computer generates HMAC which it shows to the user.";
            helpText[5] = "The user selects an item for himself.";
            helpText[6] = "The computer then shows the item it has selected, the result, and the secret key.";
            helpText[7] = "By adding the name of the selected element to the secret key, we get a string that we can insert on the site";
            helpText[8] = "https://www.liavaag.org/English/SHA-Generator/HMAC/";
            helpText[9] = "and get HMAC. If it matches the HMAC displayed by the computer at the beginning of the game, then the computer did not change its choice.";
            helpText[10] = "The table of who beats whom is presented below:";
            helpText[11] = "";


            helpText[reservedStringsForHelp] = string.Format("{0}", " \\User".PadRight(CalculateLongestElement(), ' ')) + " |";
            helpText[reservedStringsForHelp + 1] = string.Format("{0}", "PC\\  ".PadRight(CalculateLongestElement(), ' ')) + " |";


            for (int i = 0; i < arguments.Length; i++)
            {
                helpText[reservedStringsForHelp] += string.Format("{0}", "".PadRight(CalculateLongestElement(i), ' ')) + "|";
                helpText[reservedStringsForHelp + 1] += string.Format("{0}", (" " + arguments[i] + " ").PadRight(6, ' ')) + "|";
                helpText[i * 2 + reservedStrings] = CreateBarier(-1);
                helpText[i * 2 + 1 + reservedStrings] = string.Format("{0}", arguments[i].PadRight(CalculateLongestElement(), ' ')) + " |";
                for (int g = 0; g < arguments.Length; g++)
                {
                    helpText[i * 2 + reservedStrings] += CreateBarier(g);
                    helpText[i * 2 + 1 + reservedStrings] += string.Format("{0}", CalculateResult(i, g).PadRight(CalculateLongestElement(g), ' ')) + "|";
                }
            }

            return helpText;
        }

        private string CreateBarier(int mod)
        {
            string result = "";
            if (mod == -1)
            {
                result = string.Format("{0}", result.PadRight(CalculateLongestElement(), '-'));
                result += "-+";
                return result;
            }
            result = string.Format("{0}", result.PadRight(CalculateLongestElement(mod), '-'));
            result += "+";
            return result;
        }

        private int CalculateLongestElement()
        {
            int maxLength = 6;
            foreach (string element in arguments)
                if (element.Length > maxLength)
                    maxLength = element.Length;
            return maxLength;
        }

        private int CalculateLongestElement(int element)
        {
            int maxLength = 6;
            if (arguments[element].Length + 2 > maxLength)
                maxLength = arguments[element].Length + 2;
            return maxLength;
        }

        private string CalculateResult(int element, int target)
        {
            if (element == target)
                return " DRAW";
            if (Array.IndexOf(victimsTable.calculateVictims(target), element) != -1)
                return " WIN";
            return " LOSE";
        }
    }
}
