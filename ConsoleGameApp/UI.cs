using System;

namespace ConsoleGameApp
{
    internal static class UI
    {
        internal static ConsoleKey GetKey()
        {
            return Console.ReadKey(intercept: true).Key;
        }

        internal static void Clear()
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
        }

        internal static void Draw(Map map)
        {
            for (int y = 0; y < map.Width; y++)
            {
                for (int x = 0; x < map.Height; x++)
                {
                    Cell cell = map.GetCell(y, x);
                    IDrawable drawable = map.CreaturAt(cell) ?? cell;
                   //IDrawable drawable = map.Creatures.CreatureAtExtension(cell) ?? cell;

                    Console.ForegroundColor = drawable?.Color ?? ConsoleColor.White;
                    Console.Write(drawable?.Symbol);
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = Console.ForegroundColor = ConsoleColor.White;
        }

        internal static void PrintLog()
        {
            throw new NotImplementedException();
        }
    }
}