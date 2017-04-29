using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MesoketesBattle.DataStructures;

namespace MesoketesBattle
{
    public class Attack
    {
        public WallDirection Direction { get; set; }
        public Weapon Weapon { get; set; }
        public int Magnitude { get; set; }
    }
}
