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
            const int reservedStrings = 12;
            string[] helpText = new string [arguments.Length + reservedStrings];
            helpText[0] = "";
            helpText[1] = "___HELP___";
            helpText[2] = "";
            helpText[3] = "At the beginning of the game, the computer chooses an item for itself.";
            helpText[4] = "After that, using the secret key and the name of the selected item, the computer generates HMAC which it shows to the user.";
            helpText[5] = "The user selects an item for himself.";
            helpText[6] = "The computer then shows the item it has selected, the result, and the secret key.";
            helpText[7] = "By adding the name of the selected element to the secret key, we get a string that we can insert on the site";
            helpText[8] = "https://emn178.github.io/online-tools/sha3_256.html";
            helpText[9] = "and get HMAC. If it matches the HMAC displayed by the computer at the beginning of the game, then the computer did not change its choice.";
            helpText[10] = "The table of who beats whom is presented below:";
            helpText[10] = "";
            for (int i = 0; i < arguments.Length; i++)
            {
                helpText[i + reservedStrings] = arguments[i] + " beats ";
                foreach (int victim in victimsTable.calculateVictims(i))
                    helpText[i + reservedStrings] += arguments[victim] + " ";
            }
            return helpText;
        }
    }
}
