using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameApp
{
    public class Cell : IDrawable
    {
        public Position Position { get; set; }
        public List<Item> Items { get; set; } = new List<Item>();
        public string Symbol => ". ";

        public ConsoleColor Color { get; set; }

        public Cell(Position position)
        {
            Color = ConsoleColor.Red;
            Position = position;
        }
    }
}
