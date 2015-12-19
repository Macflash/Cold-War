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

        public int Funds()
        {
            return this.funds;
        }

        public int Clout()
        {
            return this.clout;
        }

        public int[] getEconStats()
        {
            return economy.getStats();
        }

        public void updateCountry()
        {
            economy.updateEconomy();
        }

        public void addEvent()
        {
            economy.addEvent();
        }

        public void applyAction(Action a)
        {
            this.funds -= a.FundCost();
            this.clout -= a.CloutCost();
            foreach (Effect e in a.Effects())
            {
                if (e.Estat() > 0)
                {
                    economy.addStat(e.Estat(), e.Bonus());
                }
                if (e.Mstat() > 0)
                {
                    military.addStat(e.Mstat(), e.Bonus());
                }
                if (e.Pstat() > 0)
                {
                    politics.addStat(e.Pstat(), e.Bonus());
                }
            }
        }

    }
}
