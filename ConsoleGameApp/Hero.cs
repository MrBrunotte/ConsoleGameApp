using System;

namespace ConsoleGameApp
{
    internal class Hero : Creature
    {
        public Hero(Cell cell) :base(cell, "H ")
        {
            Color = ConsoleColor.Yellow;
        }
    }
}