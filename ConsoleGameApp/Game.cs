using System;

namespace ConsoleGameApp
{
    internal class Game
    {
        private Map map;
        private Hero hero;

        internal void Run()
        {
            Initialize();
            Play();
        }

        private void Play()
        {
            bool gameInProgress = true;
            do
            {
                // Draw map
                DrawMap();
                // Get input/command from user
                // Execute command
                // Draw map 
                // Enemy action
                // Draw map
                Console.ReadKey();
            } while (gameInProgress);
        }

        private void DrawMap()
        {
            for (int y = 0; y < map.Width; y++)
            {
                for (int x = 0; x < map.Height; x++)
                {
                Cell cell = map.GetCell(y, x);
                    Console.Write(cell.Symbol);
                }
                Console.WriteLine();
            }
        }

        private void Initialize()
        {
            //ToDo Read from config
            map = new Map(width: 10, height: 10);
            hero = new Hero();
        }
    }
}