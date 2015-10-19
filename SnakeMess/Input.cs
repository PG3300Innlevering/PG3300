using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeMess
{
	public class Input : WalkingDirection
    {
	    
        public void CheckInput()
        { 
            if (Console.KeyAvailable)
            {
                var readKey = Console.ReadKey(true);
                if (readKey.Key == ConsoleKey.Escape)
                    Game.State.GameOver = true;
                else if (readKey.Key == ConsoleKey.Spacebar)
                    Game.State.Paused = !Game.State.Paused;
                else if (readKey.Key == ConsoleKey.UpArrow && LastDirection != 2)
                    Direction = 0;
                else if (readKey.Key == ConsoleKey.RightArrow && LastDirection != 3)
                    Direction = 1;
                else if (readKey.Key == ConsoleKey.DownArrow && LastDirection != 0)
                    Direction = 2;
                else if (readKey.Key == ConsoleKey.LeftArrow && Direction != 1)
                    Direction = 3;
            }
        }
    }
}
