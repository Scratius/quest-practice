using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quest
{
    internal class Trap
    {
        public bool IsDisabled { get; set; }
        public string Health { get; set; }

        public Trap()
        {
            IsDisabled = false;
            Health = "full";
        }

        //проверка ловушки
        public void Pass()
        {
            int chance = new Random().Next(100);

            if (chance < 20)
            {
                Health = "full";
            }
            else if (chance < 50)
            {
                Health = "mid";
            }
            else
            {
                Health = "low";
            }
        }
    }   
}
