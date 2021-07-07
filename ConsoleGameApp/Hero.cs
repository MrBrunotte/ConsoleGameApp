using LimitedList;
using System;
using System.Collections.Generic;

namespace ConsoleGameApp
{
    internal class Hero : Creature
    {
        public LimitedList<Item> BackPack { get; set; }
        public Hero(Cell cell) : base(cell, "H ", 100)
        {
            Color = ConsoleColor.Yellow;
            BackPack = new LimitedList<Item>(3);
        }
    }
}