using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quest
{
    internal class Puzzle
    {
        private string _answer = "10 11 21 32 53";
        public int count_of_trying = 0;

        public bool Solve(string answer)
        {
            if (answer == _answer)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
