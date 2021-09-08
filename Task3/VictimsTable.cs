using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    class VictimsTable
    {
        private string[] arguments;

        public VictimsTable(string[] args) { arguments = args; }
        public int[] calculateVictims(int element)
        {
            int[] victims = new int[arguments.Length / 2];
            for (int i = 1; i <= victims.Length; i++)
            {
                if (element - i < 0)
                    victims[i - 1] = element - i + arguments.Length;
                else
                    victims[i - 1] = element - i;
            }
            return victims;
        }
    }
}
