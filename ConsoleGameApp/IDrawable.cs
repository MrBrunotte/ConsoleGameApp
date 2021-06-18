using System;

namespace ConsoleGameApp
{
    public interface IDrawable
    {
        ConsoleColor Color { get; set; }
        string Symbol { get; }
    }
}