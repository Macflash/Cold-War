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
            List<Action> acts = Action.EconActions;
            Console.WriteLine(":: {0}", acts.Count);

            bool first = true;
            while (gameRunning)
            {
                playRound(first);
                first = false;
            }

        }

        public void playRound(bool firstRound)
        {
            // Action 1
            ActionPhase(player);

            // Press Release / Statement / Declaration
            // - who goes first or is it simultaneous?

            // Action 2
            ActionPhase(player);
            // End of Year Report
            // - Includes historical performance and current economy stats/boosts
            ReportPhase(player);
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
            Console.WriteLine("1. Economic      2. Military      3. Political");
            Console.WriteLine();

            PickActionType(c);

        }

        public void PickActionType(Country c)
        {
            int i = Program.EMP();
            if (i == 1) { ShowEcon(c); }
            if (i == 2) { ShowMilitary(c); }
            if (i == 3) { ShowPolitics(c); }
        }

        public void ShowEcon(Country c)
        {
            Console.WriteLine("ECON:");
        }
        public void ShowMilitary(Country c)
        {
            Console.WriteLine("MILITARY:");
        }
        public void ShowPolitics(Country c)
        {
            Console.WriteLine("POLITICS:");
        }

        public void StatementPhase(Country c)
        {

        }


    }
}
