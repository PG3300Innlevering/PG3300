using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeMess
{
	public class SnakePlayer : Input
	{

		public Coord TailCoord { get; set; }
		public Coord HeadCoord { get; set; }
		public Coord NewHeadCoord { get; set; }
			

		public SnakePlayer()
		{			
			TailCoord = new Coord(Game.Coords.First());
			HeadCoord = new Coord(Game.Coords.Last());
			NewHeadCoord = new Coord(HeadCoord);			
		}

		public void SwitchDirection()
		{
			
		}

	}
}
