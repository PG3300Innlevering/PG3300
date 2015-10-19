using System;
using System.Linq;
using SnakeMess;

namespace SnakeMess
{
	public class AppleItem : Board
    {

        private Random _random = new Random();
        //private Board _board = new Board();

        public void SetAppleOnField()
        {
            while (true)
            {
                Game.AppleCoord.X = _random.Next(0, BoardW);
                Game.AppleCoord.Y = _random.Next(0, BoardH);

                var freeSpot = Game.Coords.All(i => i.X != Game.AppleCoord.X || i.Y != Game.AppleCoord.Y);
                if (!freeSpot) continue;
                DrawApple();
				InUse = true;
				break;
            }
        }

        public void DrawApple()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(Game.AppleCoord.X, Game.AppleCoord.Y);
            Console.Write("$");
        }
    }
}
