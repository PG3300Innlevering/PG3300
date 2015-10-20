using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace SnakeMess
{
	public enum SnakeDirection
	{
		Up,
		Right,
		Down,
		Left
	}

	public class WalkingDirection : AppleItem
	{
		public SnakeDirection Direction { get; set; }
		public SnakeDirection LastDirection { get; set; }
		public WalkingDirection()
		{
			Direction = SnakeDirection.Down;      // 0 = up, 1 = right, 2 = down, 3 = left
		}

		public void CheckInput()
		{
			if (Console.KeyAvailable)
			{
				var readKey = Console.ReadKey(true);
				if (readKey.Key == ConsoleKey.Escape)
					GameOver = true;

				else if (readKey.Key == ConsoleKey.Spacebar)
					Paused = !Paused;

				else if (readKey.Key == ConsoleKey.UpArrow && LastDirection != SnakeDirection.Down)
					Direction = SnakeDirection.Up;

				else if (readKey.Key == ConsoleKey.RightArrow && LastDirection != SnakeDirection.Left)
					Direction = SnakeDirection.Right;

				else if (readKey.Key == ConsoleKey.DownArrow && LastDirection != SnakeDirection.Up)
					Direction = SnakeDirection.Down;

				else if (readKey.Key == ConsoleKey.LeftArrow && Direction != SnakeDirection.Right)
					Direction = SnakeDirection.Left;
			}
		}
	}
}
