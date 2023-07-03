using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quest
{
    internal class Main_Player
    {
        public bool HasAntidote { get; set; }
        public bool HasRope { get; set; }
        public bool HasKey { get; set; }
        public string Health { get; set; }

        public Main_Player()
        {
            HasAntidote = false;
            HasRope = false;
            HasKey = false;
            Health = "full";
        }
    }
}
