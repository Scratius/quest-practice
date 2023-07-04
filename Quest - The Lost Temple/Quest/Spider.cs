using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quest
{
    internal class Spider
    {
        //Сражение с пауком
        public bool Fight(bool hasAntidote, string health) //функция определяющая победил ли персонаж паука
        {
            int chance;
            int n = 100;
            if (health == "mid") //если персонаж был ранен то уменьшаем шансы на победу
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
