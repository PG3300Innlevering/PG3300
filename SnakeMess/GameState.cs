﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace SnakeMess
{
	public class GameState
    {
        public bool GameOver { get; set; }
        public bool Paused { get; set; }
        public bool AppleEaten { get; set; }

        // Sets the game state to running if this is called.
        public GameState()
        {
            GameOver = false;
            Paused = false;
	        AppleEaten = false;
        }

		public void SetPause()
		{

		}
    }
}
