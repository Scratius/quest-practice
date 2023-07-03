using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quest
{
    internal class Spider
    {
        public bool Fight(bool hasAntidote, string health)
        {
            int chance;
            int n = 100;
            if (health == "mid")
            {
                n = 80;
            }

            if (hasAntidote && health == "full")
            {
                chance = new Random().Next(n);
                if (chance > 10)
                {
                    return true;
                }
            }
            else
            {
                chance = new Random().Next(n);
                if (chance > 60)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
