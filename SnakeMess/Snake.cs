using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace SnakeMess
{
	internal class Snake : SnakeGame
	{
		public short Direction { get; set; }
		public short LastDirection { get; set; }
		public Coord TailCoord { get; set; }
		public Coord HeadCoord { get; set; }
		public Coord NewHeadCoord { get; set; }
	
		public Snake(List<Coord> tailCoords)
		{
			Direction = 2;
			LastDirection = Direction;
			FillTail(tailCoords);	
		}

		public void FillTail(List<Coord> tailCoords)
		{
			tailCoords.Add(new Coord(10, 10));
			tailCoords.Add(new Coord(10, 10));
			tailCoords.Add(new Coord(10, 10));
			tailCoords.Add(new Coord(10, 10));
			tailCoords.Add(new Coord(10, 10));
			tailCoords.Add(new Coord(10, 10));

		}

		public void SetDirection(short newDir)
		{
			switch (newDir)
			{
				case 0:
					NewHeadCoord.Y--;
					break;
				case 1:
					NewHeadCoord.X++;
					break;
				case 2:
					NewHeadCoord.Y++;
					break;
				default:
					NewHeadCoord.X--;
					break;
			}
		}

		public void GetNextPosition(List<Coord> tailCoords)
		{
			TailCoord = new Coord(tailCoords.First());
			HeadCoord = new Coord(tailCoords.Last());
			NewHeadCoord = new Coord(HeadCoord);
		}

		public bool CollisionCheck(int width, int height)
		{
			if (NewHeadCoord.X < 0 || NewHeadCoord.X >= width)
				return false;
			else if (NewHeadCoord.Y < 0 || NewHeadCoord.Y >= height)
				return false;
			return true;
		}

		public void AppleCollisionCheck(int width, int height, Coord appleCoord, PlayField playField, List<Coord> tailCoords)
		{
			if (NewHeadCoord.X == appleCoord.X && NewHeadCoord.Y == appleCoord.Y)
			{
				if (tailCoords.Count + 1 >= width*height)
					// No more room to place apples -- game over.
					GameIsPlaying = false;
				else
				{
					playField.SetAppleField(tailCoords, appleCoord);
					ExtendSnakeTail(tailCoords);
				}
			}
		}

		// Death by accidental self-cannibalism.
		public void SelfCollisionTest(List<Coord> tailCoords, Coord headCoord, bool appleEaten)
		{
			if (!appleEaten)
			{
				tailCoords.RemoveAt(0);
				foreach (Coord x in tailCoords)
					if (x.X == NewHeadCoord.X && x.Y == NewHeadCoord.Y)
					{
						// Death by accidental self-cannibalism.
						GameIsPlaying = false;
						break;
					}
			}
		}

		public void DrawCharAtLoc(Coord coord, char c)
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.SetCursorPosition(coord.X, coord.Y);
			Console.Write(c);
		}

		public void ExtendSnakeTail(List<Coord> tailCoords)
		{
			tailCoords.Add(new Coord(NewHeadCoord));
		}
    }
}
