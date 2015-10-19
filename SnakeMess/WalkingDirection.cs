using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeMess
{
    public class WalkingDirection : Board
    {
        public short Direction { get; set; } 
		public short LastDirection { get; set; }
        public WalkingDirection()
        {
			Direction = (short)Directions.Down;
        }

        // 0 = up, 1 = right, 2 = down, 3 = left
        private enum Directions
        {
            Up,
            Right,
            Down,
            Left
        }
    }
}
