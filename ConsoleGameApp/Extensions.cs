using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameApp
{
    public static class Extensions
    {
        public static IDrawable CreatureAtExtension(this IEnumerable<Creature> creatures, Cell cell)
        {
            return creatures.FirstOrDefault(c => c.Cell == cell);
        }
    }
}
