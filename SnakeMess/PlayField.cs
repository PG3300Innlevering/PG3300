using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeMess
{
	class PlayField : SnakeGame
	{
		public int Width { get; set; }
		public int Height { get; set; }
		public Coord AppleCoord { get; set; }

		private readonly Random _random = new Random();

		public PlayField(List<Coord> tailCoords )
		{
			SetSnakeField(tailCoords);
		}

		public void SetSnakeField(List<Coord> tailCoords)
		{
			Width = Console.WindowWidth;
			Height = Console.WindowHeight;

			AppleCoord = new Coord();

			Console.CursorVisible = false;
			Console.Title = "Westerdals Oslo ACT - SNAKE";
			Console.ForegroundColor = ConsoleColor.Green;
			Console.SetCursorPosition(10, 10);
			Console.Write("@");
			SetAppleField(tailCoords, AppleCoord);
		}

		public void CreateApple(Coord appleCoord)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.SetCursorPosition(appleCoord.X, appleCoord.Y);
			Console.Write("$");
		}

		public bool IsOccupied(Coord location)
		{
			return false;
		}

		public void getOccupied(Coord location)
		{
			
		}

		private void setFieldClass()
		{
			
		}

		public void SetAppleField(List<Coord> tailCoords, Coord appleCoord)
		{
			while (true)
			{
				AppleCoord.X = _random.Next(0, Width);
				AppleCoord.Y = _random.Next(0, Height);

				var freeSpot = tailCoords.All(i => i.X != appleCoord.X || i.Y != appleCoord.Y);
				if (!freeSpot) continue;

				CreateApple(appleCoord);
				AppleEaten = true;
				break;
			}
		}
	}
}
