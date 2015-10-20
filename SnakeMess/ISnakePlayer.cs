using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SnakeMess
{
	public abstract class ISnakePlayer
	{
		public abstract Coord TailCoord { get; set; }
		public abstract Coord HeadCoord { get; set; }
		public abstract Coord NewHeadCoord { get; set; }
		public abstract List<Coord> Coords { get; set; }
		public abstract void GetPlayerCoords();
	}
}
