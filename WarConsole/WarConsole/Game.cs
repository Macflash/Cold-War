using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarConsole
{
    /// <summary>
    /// Game holds all game information etc and runs rounds
    /// </summary>
    class Game
    {
        private Country ai;
        private Country player;
        private int round;
        private bool gameRunning;

        public void start()
        {
            gameRunning = true;
            player = new Country();

        }

    }
}
