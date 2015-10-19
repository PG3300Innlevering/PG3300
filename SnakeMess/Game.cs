using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

// WARNING: DO NOT code like this. Please. EVER! 
//          "Aaaargh!" 
//          "My eyes bleed!" 
//          "I facepalmed my facepalm." 
//          Etc.
//          I had a lot of fun obfuscating this code though! And I can now (proudly?) say that this is the uggliest short piece of code I've ever worked with! :-)
//          (And yes, it could have been a lot ugglier! But the idea wasn't to make it fuggly-uggly, just funny-uggly, sweet-uggly, or whatever you want to call it.)
//
//          -Tomas
//

namespace SnakeMess
{
	public class Game : WalkingDirection
    {
        public static Coord AppleCoord = new Coord();
        public static AppleItem Apple = new AppleItem();
		public static GameState State = new GameState();
        public Input Input = new Input();
        public static SnakePlayer Player;
		public static List<Coord> Coords;

		public Game()
        {
			
			LastDirection = Direction;

			Coords = new List<Coord> {new Coord(10, 10), new Coord(10, 10), new Coord(10, 10), new Coord(10, 10) };

			Apple.SetAppleOnField();

			var timer = new Stopwatch();
			timer.Start();

			while (!GameOver)
            {
                Input.CheckInput();

                if (Paused) continue;
                if (timer.ElapsedMilliseconds < 100) continue;
                timer.Restart();
					
				Player = new SnakePlayer();

				switch (Direction)
				{
					case 0:
						Player.NewHeadCoord.Y--;
						break;
					case 1:
						Player.NewHeadCoord.X++;
						break;
					case 2:
						Player.NewHeadCoord.Y++;
						break;
					default:
						Player.NewHeadCoord.X--;
						break;
				}

				if (Player.NewHeadCoord.X < 0 || Player.NewHeadCoord.X >= BoardW)
                    GameOver = true;
                else if (Player.NewHeadCoord.Y < 0 || Player.NewHeadCoord.Y >= BoardH)
                    GameOver = true;


                if (Player.NewHeadCoord.X == AppleCoord.X && Player.NewHeadCoord.Y == AppleCoord.Y)
                {
                    if (Coords.Count + 1 >= BoardW * BoardH)
                        // No more room to place apples -- game over.
                        GameOver = true;
                    else
                    {
                        Apple.SetAppleOnField();
                    }
                }
                if (!InUse)
                {
                    Coords.RemoveAt(0);
                    foreach (var x in Coords)
                        if (x.X == Player.NewHeadCoord.X && x.Y == Player.NewHeadCoord.Y)
                        {
                            // Death by accidental self-cannibalism.
                            GameOver = true;
                            break;
                        }
                }

                if (GameOver) continue;

                DrawChar(Player.HeadCoord, '0');
                if (!InUse)
                {
                    DrawChar(Player.TailCoord, ' ');
                }
                else
                {
                    Apple.DrawApple();
                    InUse = false;
                }
                Coords.Add(Player.NewHeadCoord);
                DrawChar(Player.NewHeadCoord, '@');
                LastDirection = Direction;

            }
        }

     
        public static void Main(string[] args)
        {
            new Game();
        }
             
    }
}