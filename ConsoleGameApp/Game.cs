using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
                    Move(Direction.West);
                    break;
                case ConsoleKey.RightArrow:
                    Move(Direction.East);
                    break;
                case ConsoleKey.UpArrow:
                    Move(Direction.North);
                    break;
                case ConsoleKey.DownArrow:
                    Move(Direction.South);
                    break;
                //case ConsoleKey.P:
                //    PickUp();
                //    break;
                //case ConsoleKey.I:
                //    Inventory();
                //    break;
                case ConsoleKey.Q:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
            var actionMeny = new Dictionary<ConsoleKey, Action>()
            {
                {ConsoleKey.P, PickUp },
                {ConsoleKey.I, Inventory }
            };

            if (actionMeny.ContainsKey(keyPressed))
            {
                var method = actionMeny[keyPressed];
                method?.Invoke();
            }
        }

        private void Inventory()
        {
            var builder = new StringBuilder();
            builder.AppendLine("Inventory: ");
            for (int i = 0; i < hero.BackPack.Count; i++)
            {
                builder.AppendLine($"{i + 1}: \t{hero.BackPack[i]}");
            }
            UI.AddMessage(builder.ToString());
        }

        private void PickUp()
        {
            if (hero.BackPack.IsFull)
            {
                UI.AddMessage("Backpack is full");
                return;
            }

            var items = hero.Cell.Items;
            var item = items.FirstOrDefault();
            if (item == null) return;
            if (hero.BackPack.Add(item))
            {
                UI.AddMessage($"Hero picks up {item}");
                items.Remove(item);
            }
        }

        private void Move(Position movement)
        {
            Position newPosition = hero.Cell.Position + movement;
            Cell newCell = map.GetCell(newPosition);
            if (newCell != null) hero.Cell = newCell;
        }

        private void DrawMap()
        {
            UI.Clear();
            UI.Draw(map);
            UI.PrintStats($"Health: {hero.Health}" +
                          $"\nEnemies: {map.Creatures.Count}");
            UI.PrintLog();
        }

        private void Initialize()
        {
            //ToDo Read from config
            map = new Map(width: 10, height: 10);
            Cell heroCell = map.GetCell(0, 0);
            hero = new Hero(heroCell);
            map.Creatures.Add(hero);

            //ToDo Random position
            map.GetCell(3, 3).Items.Add(Item.Coin());
            map.GetCell(0, 8).Items.Add(Item.Coin());
            map.GetCell(7, 4).Items.Add(Item.Torch());
            map.GetCell(8, 7).Items.Add(Item.Torch());
        }
    }
}