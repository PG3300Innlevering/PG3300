using System;

namespace SnakeMess
{
    public class Board : GameState
    {
        public int BoardH { get; set; }
        public int BoardW { get; set; }

        public Board()
        {
            BoardW = Console.WindowWidth;
            BoardH = Console.WindowHeight;

            Console.CursorVisible = false;
            Console.Title = "Westerdals Oslo ACT - SNAKE";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(10, 10);
            Console.Write("@");

        }
        public void DrawChar(Coord coord, char c)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(coord.X, coord.Y);
            Console.Write(c);
        }
    }
    
}