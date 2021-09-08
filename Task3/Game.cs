using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    class Game
    {
        private VictimsTable victimsTable;
        public Game(VictimsTable table) { victimsTable = table; }
        public string CalculateResult(int computerChoise, int userChoise)
        {
            if (computerChoise == userChoise)
                return "Draw!";
            if (Array.IndexOf(victimsTable.calculateVictims(userChoise), computerChoise) != -1)
                return "You are Victorious!";
            return "Computer is Victorious!";
        }
    }
}
