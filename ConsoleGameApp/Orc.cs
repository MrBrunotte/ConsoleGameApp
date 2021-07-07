using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameApp
{
    class Orc : Creature
    {
        public Orc(Cell cell, int maxHealth) : 
            base(cell, "O ", maxHealth)
        {
            Damage = 25;
            Color = ConsoleColor.Cyan;
        }
    }
}
