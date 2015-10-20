using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Microsoft.SqlServer.Server;

namespace SnakeMess
{
	class SnakeGame
	{
		public bool GameIsPlaying { get; set; }
		public bool AppleEaten { get; set; }
		public bool Paused { get; set; }
		public List<Coord> TailCoordsList = new List<Coord>();
		private PlayField PlayField { get; set; }
		private Snake Player { get; set; }
		private Stopwatch Tick { get; set; }


		private void Initiliaze()
		{
			GameIsPlaying = true;
			Paused = false;
			AppleEaten = false;
			Tick  = new Stopwatch();
			Player = new Snake(TailCoordsList);
			PlayField = new PlayField(TailCoordsList);

			Tick.Start();
			UpdatePlayField();
		}

		private void UpdatePlayField()
		{
			while (GameIsPlaying)
			{
				OnKeyUp();

				if (!Paused)
				{
					if (Tick.ElapsedMilliseconds < 100) continue;
					Tick.Restart();

					Player.GetNextPosition(TailCoordsList);
					Player.SetDirection(Player.Direction);

					GameIsPlaying = Player.CollisionCheck(PlayField.Width, PlayField.Height);
					Player.AppleCollisionCheck(PlayField.Width, PlayField.Height, PlayField.AppleCoord, PlayField, TailCoordsList);
					Player.SelfCollisionTest(TailCoordsList, Player.HeadCoord, AppleEaten);

					if (!GameIsPlaying) continue;

					Player.DrawCharAtLoc(Player.HeadCoord, '0');

					if (!AppleEaten)
					{
						Player.DrawCharAtLoc(Player.TailCoord, ' ');
					}
					else
					{
						PlayField.CreateApple(PlayField.AppleCoord);
						AppleEaten = false;
					}
					Player.ExtendSnakeTail(TailCoordsList);
					//TailCoordsList.Add(new Coord(Player.NewHeadCoord));
					Player.DrawCharAtLoc(Player.NewHeadCoord, '@');
					Player.LastDirection = Player.Direction;

				}
			}
		}

		private void OnKeyUp()
		{
			if (!Console.KeyAvailable) return;

			ConsoleKeyInfo cki = Console.ReadKey(true);
			if (cki.Key == ConsoleKey.Escape)
				GameIsPlaying = false;
			else if (cki.Key == ConsoleKey.Spacebar)
				Paused = !Paused;
			else if (cki.Key == ConsoleKey.UpArrow && Player.LastDirection != 2)
				Player.Direction = 0;
			else if (cki.Key == ConsoleKey.RightArrow && Player.LastDirection != 3)
				Player.Direction = 1;
			else if (cki.Key == ConsoleKey.DownArrow && Player.LastDirection != 0)
				Player.Direction = 2;
			else if (cki.Key == ConsoleKey.LeftArrow && Player.LastDirection != 1)
				Player.Direction = 3;
		}

		public static void Main(String[] args)
		{
			var game = new SnakeGame();
			game.Initiliaze();
		}
	}
}
