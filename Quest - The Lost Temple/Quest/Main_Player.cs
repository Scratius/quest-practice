using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quest
{
    internal class Main_Player
    {
        public bool HasAntidote { get; set; } //Антидот
        public bool HasRope { get; set; }     //Веревка
        public bool HasKey { get; set; }      //Ключ
        public string Health { get; set; }    //Здоровье

        //Конструктор персонажа
        public Main_Player()
        {
            HasAntidote = false;
            HasRope = false;
            HasKey = false;
            Health = "full";
        }
    }
}
