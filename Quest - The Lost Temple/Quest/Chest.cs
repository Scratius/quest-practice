using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Quest
{
    internal class Chest
    {
        private string _code = "1738";

        public bool Unlock(string code)
        {
            if (code == _code)
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
