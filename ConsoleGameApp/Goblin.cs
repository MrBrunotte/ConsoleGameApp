using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameApp
{
    class Goblin : Creature
    {
        public Goblin(Cell cell, int maxHealth) : 
            base(cell, "G ", 30)
        {
            Damage = 15;
        }
    }
}
