using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameApp
{
    public class Cell : IDrawable
    {
        public int X { get; }
        public int Y { get; }
        public List<Item> Items { get; set; } = new List<Item>();
        public string Symbol => ". ";

        public ConsoleColor Color { get; set; }

        public Cell(int y, int x)
        {
            Color = ConsoleColor.Red;
            Y = y;
            X = x;
        }
    }
}
