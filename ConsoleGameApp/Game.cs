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
                GetInput();
                // Execute command
                // Draw map 
                DrawMap();
                // Enemy action
                // Draw map
            } while (gameInProgress);
        }

        private void GetInput()
        {
            var keyPressed = UI.GetKey();
            switch (keyPressed)
            {
                case ConsoleKey.LeftArrow:
                    Move(hero.Cell.Y, hero.Cell.X - 1);
                    break;
                case ConsoleKey.RightArrow:
                    Move(hero.Cell.Y, hero.Cell.X + 1);
                    break;
                case ConsoleKey.UpArrow:
                    Move(hero.Cell.Y - 1, hero.Cell.X);
                    break;
                case ConsoleKey.DownArrow:
                    Move(hero.Cell.Y + 1, hero.Cell.X);
                    break;
                default:
                    break;
            }
        }

        private void Move(int y, int x)
        {
            var newPosition = map.GetCell(y, x);
            if (newPosition != null) 
                hero.Cell = newPosition;
        }

        private void DrawMap()
        {
            UI.Clear();
            for (int y = 0; y < map.Width; y++)
            {
                for (int x = 0; x < map.Height; x++)
                {
                    Cell cell = map.GetCell(y, x);
                    IDrawable drawable = cell;

                    foreach (Creature creature in map.Creatures)
                    {
                        if (creature.Cell == cell)
                        {
                            drawable = creature;
                            break;
                        }
                    }
                    Console.ForegroundColor = drawable?.Color ?? ConsoleColor.White;
                    Console.Write(drawable?.Symbol);
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = Console.ForegroundColor = ConsoleColor.White;
        }

        private void Initialize()
        {
            //ToDo Read from config
            map = new Map(width: 10, height: 10);
            Cell heroCell = map.GetCell(0, 0);
            hero = new Hero(heroCell);
            map.Creatures.Add(hero);
        }
    }
}