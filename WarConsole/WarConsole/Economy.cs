using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarConsole
{
    class Economy
    {
        // Economony Stats
        private enum stat {employment, gdp, infrastructure, capital, manufacturing, education, productivity, food, confidence, inflation, satisfaction, savings, wages, spending, middleClass, buyingPower, companies, safety };
        private int statLength;
        private int[] stats;
        private int[] net;
        private Random rand;
        
        public Economy(){
            statLength = Enum.GetNames(typeof(stat)).Length;
            stats = new int[statLength];
            rand = new Random();
        }

        public void addEvent()
        {
            int r = rand.Next(statLength - 1);
            int amt = rand.Next(7) - 3;
            stats[r] += amt;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Event! {0} {1}", Enum.GetName(typeof(stat), r), amt);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void updateEconomy()
        {
            net = new int[statLength];

            // define the interplay between these pieces
            
            // EMPLOYMENT
            norm(stat.employment, stat.middleClass);
            norm(stat.employment, stat.buyingPower);

            // GDP
            norm(stat.gdp, stat.satisfaction);
            norm(stat.gdp, stat.companies);

            // INFRASTRUCTURE
            norm(stat.infrastructure, stat.productivity);
            norm(stat.infrastructure, stat.satisfaction);

            // CAPITAL
            norm(stat.capital, stat.gdp);
            //inv_bad(stat.capital, stat.employment); //capital causes cyclical/structural unemployment from advances? negative capital doesnt help employment....
            norm(stat.capital, stat.manufacturing);

            // MANUFACTURING
            norm(stat.manufacturing, stat.employment);

            // EDUCATION
            norm(stat.education, stat.productivity);
            norm(stat.education, stat.middleClass);
            norm(stat.education, stat.satisfaction);

            // productivity, 
            norm(stat.productivity, stat.wages);
            norm(stat.productivity, stat.gdp);

            //food, 
            norm(stat.food, stat.middleClass);
            norm(stat.food, stat.confidence);

            //confidence, 
            norm(stat.confidence, stat.spending);
            norm(stat.confidence, stat.companies);
            norm(stat.confidence, stat.satisfaction);

            //inflation, 
            inv(stat.inflation, stat.wages);
            bad(stat.inflation, stat.satisfaction);
            inv(stat.inflation, stat.buyingPower);

            //satisfaction, 
            

            //savings, 
            

            //wages,
            norm(stat.wages, stat.middleClass);
            norm(stat.wages, stat.buyingPower);

            //spending, 
            norm(stat.spending, stat.gdp);
            norm(stat.spending, stat.manufacturing);

            //middleClass, 
            norm(stat.middleClass, stat.satisfaction);
            norm(stat.middleClass, stat.confidence);
            
            //buyingPower, 
            norm(stat.buyingPower, stat.middleClass);
            norm(stat.buyingPower, stat.capital);
            
            //companies, 
            norm(stat.companies, stat.employment);
            norm(stat.companies, stat.capital);
            
            //safety 
            norm(stat.safety, stat.satisfaction);
            norm(stat.safety, stat.confidence);

            //go through the net and add some stuff to each piece if it was a net pos or neg.
            Console.WriteLine();
            Console.WriteLine("Country: ");
            foreach (stat s in Enum.GetValues(typeof(stat)))
            {
                if (net[(int)s] > 0)
                {
                    stats[(int)s]++;
                    if (net[(int)s] > stats[(int)s]) { stats[(int)s]++; }
                }
                if (net[(int)s] < 0)
                {
                    stats[(int)s]--;
                    if (net[(int)s] < stats[(int)s]) { stats[(int)s]--; }
                }
                if (stats[(int)s] == 0) { Console.ForegroundColor = ConsoleColor.DarkGray; }
                if (stats[(int)s] > 0) { Console.ForegroundColor = ConsoleColor.DarkGreen; }
                if (stats[(int)s] > 1) { Console.ForegroundColor = ConsoleColor.Green; }
                if (stats[(int)s] < 0) { Console.ForegroundColor = ConsoleColor.DarkRed; }
                if (stats[(int)s] < -1) { Console.ForegroundColor = ConsoleColor.Red; }
                Console.Write("{0}: {1} / ", Enum.GetName(typeof(stat), s), stats[(int) s]);
                Console.ForegroundColor = ConsoleColor.White;
            }

        }

        private void norm(stat cause, stat effected)
        {
            if (stats[(int)cause] > 0) { if (stats[(int)cause] > stats[(int)effected]) { net[(int)effected]++; } }
            if (stats[(int)cause] < 0) { if (stats[(int)cause] < stats[(int)effected]) { net[(int)effected]--; } }
        }

        private void inv(stat cause, stat effected)
        {
            if (stats[(int)cause] > 0) { if (stats[(int)cause] > -1 * stats[(int)effected]) { net[(int)effected]--; } }
            if (stats[(int)cause] < 0) { if (stats[(int)cause] < -1 * stats[(int)effected]) { net[(int)effected]++; } }
        }

        private void bad(stat cause, stat effected)
        {
            if (stats[(int)cause] < 0) { if (stats[(int)cause] < stats[(int)effected]) { net[(int)effected]--; } }
        }

        private void inv_bad(stat cause, stat effected)
        {
            if (stats[(int)cause] > 0) { if (stats[(int)cause] > -1 *stats[(int)effected]) { net[(int)effected]--; } }
        }

        private void good(stat cause, stat effected)
        {
            if (stats[(int)cause] > 0) { if (stats[(int)cause] > stats[(int)effected]) { net[(int)effected]++; } }
        }

    }
}
