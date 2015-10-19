using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeMess
{
    public class WalkingDirection
    {
        public short Direction { get; set; } 
		public short LastDirection { get; set; }
        public WalkingDirection()
        {
			Direction = 2;      // 0 = up, 1 = right, 2 = down, 3 = left

		}


	}
}
