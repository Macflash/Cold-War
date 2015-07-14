using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarConsole
{
    class Country
    {
        
        // Government Stats
        private int funds; // financial
        private int clout; // political

        private Economy economy;

        public Country()
        {
            funds = 10;
            clout = 10;
            economy = new Economy();
        }

    }
}
