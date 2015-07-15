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
        private Military military;
        private Politics politics;
        private Climate climate;

        public Country()
        {
            funds = 10;
            clout = 10;
            economy = new Economy();
            military = new Military();
            politics = new Politics();
            climate = new Climate();
        }

        public int[] getEconStats()
        {
            return economy.getStats();
        }

    }
}
