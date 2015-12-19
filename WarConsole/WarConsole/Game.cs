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
        private int phase;
        private bool gameRunning;

        public void start()
        {
            gameRunning = true;
            round = 0;
            phase = 0;
            player = new Country();
            Action.BuildActions();

            bool first = true;
            while (gameRunning)
            {
                playRound(first);
                first = false;
            }

        }

        public void playRound(bool firstRound)
        {
            
            Console.ForegroundColor = ConsoleColor.White;
            // Action 1
            ActionPhase(player);
            player.updateCountry();
            
            // Press Release / Statement / Declaration
            // - who goes first or is it simultaneous?
            StatementPhase(player);
            player.updateCountry();

            // Action 2
            ActionPhase(player);
            player.updateCountry();

            // End of Year Report
            // - Includes historical performance and current economy stats/boosts
            ReportPhase(player);

            // Random Event!
            player.addEvent();
        }

        public void ReportPhase(Country c)
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Here Is Your Economic Report For The Past Year");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine();

            int[] stats = c.getEconStats();
            int count = 0;
            foreach (Economy.stat s in Enum.GetValues(typeof(Economy.stat)))
            {
                if (count == 3) { count = 0; Console.WriteLine(); }
                count++;

                if (stats[(int)s] == 0) { Console.ForegroundColor = ConsoleColor.DarkGray; }
                if (stats[(int)s] > 0) { Console.ForegroundColor = ConsoleColor.DarkGreen; }
                if (stats[(int)s] > 1) { Console.ForegroundColor = ConsoleColor.Green; }
                if (stats[(int)s] < 0) { Console.ForegroundColor = ConsoleColor.DarkRed; }
                if (stats[(int)s] < -1) { Console.ForegroundColor = ConsoleColor.Red; }
                
                Console.Write("{0}: {1} / ", Enum.GetName(typeof(Economy.stat), s), stats[(int)s]);
                
                Console.ForegroundColor = ConsoleColor.White;
            }

            Program.ENTER();
        }

        public void ActionPhase(Country c)
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("-**              ACTION PHASE              **-");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Funds: {0}, Clout: {1}", c.Funds(), c.Clout());

            Action a = PickAction(c);

            //apply the action bro!
            c.applyAction(a);

            Console.WriteLine("You chose: {0}", a.Name());
        }

        public Action PickAction(Country c)
        {
            Console.WriteLine("1. Economic      2. Military      3. Political");
            int i = Program.EMP();
            if (i == 1) { Console.WriteLine("ECONOMY:"); return ShowActions(c, Action.EconActions); }
            else if (i == 2) { Console.WriteLine("MILITARY:"); return ShowActions(c, Action.MilitaryActions); }
            else if (i == 3) { Console.WriteLine("POLITICS:"); return ShowActions(c, Action.PoliticalActions); }
            else { return PickAction(c); }
        }

        public Action ShowActions(Country c, List<Action> alist)
        {
            int r = Action.listActions(alist);
            if (r > 0)
            {
                //Console.WriteLine(r);
                return alist.ElementAt(r - 1);
            }
            else { return PickAction(c); }
        }

        public void StatementPhase(Country c)
        {

        }


    }
}
