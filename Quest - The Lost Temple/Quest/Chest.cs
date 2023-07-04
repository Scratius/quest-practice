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
        public static string _code;

        public Chest()
        {
            Random rnd = new Random();
            _code = $"{rnd.Next(0, 10)}{rnd.Next(0, 10)}{rnd.Next(0, 10)}{rnd.Next(0, 10)}"; //Рандомная генерация ключа
        }

        //Проверка кода для открытия сундука
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
