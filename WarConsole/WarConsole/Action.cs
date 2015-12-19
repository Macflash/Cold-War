using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarConsole
{
    class Action
    {
        public static List<Action> EconActions;
        public static List<Action> MilitaryActions;
        public static List<Action> PoliticalActions;
        private string name;
        private int fundCost;
        private int cloutCost;
        private List<Effect> econEffects;

        public static int listActions(List<Action> actionList){
            int i = 0;
            Console.WriteLine("0. Go Back");
            foreach (Action a in actionList)
            {
                i++;
                Console.WriteLine("{0}. {1} Funds: {2}, Clout: {3}", i, a.name, a.FundCost() * -1, a.CloutCost() * -1);
            }
            int v = int.Parse(Console.ReadLine());
            if (v > 0 && v <= i) { return v; }
            else { return 0; }
        }

        public static void BuildActions(){
            List<Effect> temp = new List<Effect>();
            // -----------------------------
            //           MILITARY ACTIONS
            // -----------------------------
            MilitaryActions = new List<Action>();

            // General Funding
            temp = new List<Effect>();
            temp.Add(new Effect(Military.stat.weapons, 1));
            temp.Add(new Effect(Military.stat.training, 1));
            MilitaryActions.Add(new Action("Increase Funding", 10, 0, temp));
            temp = new List<Effect>();
            temp.Add(new Effect(Military.stat.weapons, -1));
            temp.Add(new Effect(Military.stat.training, -1));
            temp.Add(new Effect(Military.stat.intelligence, -1));
            temp.Add(new Effect(Military.stat.troops, -1));
            MilitaryActions.Add(new Action("Decrease Funding", -10, 0, temp));

            // Normal Weapons
            temp = new List<Effect>();
            temp.Add(new Effect(Military.stat.weapons, 1));
            temp.Add(new Effect(Economy.stat.manufacturing, 1));
            temp.Add(new Effect(Economy.stat.employment, 1));
            MilitaryActions.Add(new Action("Build Weapons", 10, 0, temp));

            // Nuclear Weapons
            temp = new List<Effect>();
            temp.Add(new Effect(Military.stat.weapons, 2));
            MilitaryActions.Add(new Action("Build Nukes", 10, 0, temp));
            temp = new List<Effect>();
            temp.Add(new Effect(Military.stat.weapons, -3));
            MilitaryActions.Add(new Action("Dismantle Nukes", 0, 0, temp));

            // Espionage / intelligence
            temp = new List<Effect>();
            temp.Add(new Effect(Military.stat.intelligence, 1));
            MilitaryActions.Add(new Action("Spy Program", 5, 0, temp));

            // increase recruitment
            temp = new List<Effect>();
            temp.Add(new Effect(Military.stat.troops, 1));
            MilitaryActions.Add(new Action("Increase Recruitment", 5, 0, temp));

            // draft
            temp = new List<Effect>();
            temp.Add(new Effect(Military.stat.troops, 3));
            temp.Add(new Effect(Economy.stat.employment, 1));
            temp.Add(new Effect(Economy.stat.education, -1));
            MilitaryActions.Add(new Action("Enact Draft", 5, 20, temp));

            // illegally Sell Arms 
            temp = new List<Effect>();
            temp.Add(new Effect(Military.stat.weapons, -1));
            MilitaryActions.Add(new Action("Sell Illegal Arms", -10, 0, temp));

            // -----------------------------
            //           ECON ACTIONS
            // -----------------------------
            EconActions = new List<Action>();

            // Raise Taxes
            EconActions.Add(new Action("Raise Taxes", -10, 10));
            EconActions.Add(new Action("Lower Taxes", 10, -10));

            // Invest in
            // - infrastructure
            temp = new List<Effect>();
            temp.Add(new Effect(Economy.stat.infrastructure, 1));
            EconActions.Add(new Action("Invest in Infrastructure", 5, 5, temp));

            // education
            temp = new List<Effect>();
            temp.Add(new Effect(Economy.stat.education, 1));
            EconActions.Add(new Action("Invest in Education", 5, 5, temp));

            // capital and manufacturing
            temp = new List<Effect>();
            temp.Add(new Effect(Economy.stat.capital, 1));
            temp.Add(new Effect(Economy.stat.manufacturing, 1));
            EconActions.Add(new Action("Invest in Local Manufacturing & Capital", 5, 5, temp));
    
            // Lower Interest Rates
            temp = new List<Effect>();
            temp.Add(new Effect(Economy.stat.inflation, 1));
            temp.Add(new Effect(Economy.stat.employment, 1));
            EconActions.Add(new Action("Lower Interest Rates", 5, 0, temp));

            // Raise Interest Rates
            temp = new List<Effect>();
            temp.Add(new Effect(Economy.stat.inflation, -1));
            temp.Add(new Effect(Economy.stat.employment, -1));
            EconActions.Add(new Action("Raise Interest Rates", -5, 0, temp));

            // -----------------------------
            //           POLITICAL ACTIONS
            // -----------------------------
            PoliticalActions = new List<Action>();

            // foreign aid
            temp = new List<Effect>();
            temp.Add(new Effect(Politics.stat.reputation, 1));
            PoliticalActions.Add(new Action("Increase Foreign Aid", -5, 0, temp));

            // foster Bipartisanship
            temp = new List<Effect>();
            temp.Add(new Effect(Economy.stat.satisfaction, 1));
            PoliticalActions.Add(new Action("Foster BiPartisanship", 0, -10, temp));

            // Hold Peace Conference
            temp = new List<Effect>();
            temp.Add(new Effect(Politics.stat.reputation, 1));
            PoliticalActions.Add(new Action("Hold Peace Conference", 0, -10, temp));

            // arms to allies
            temp = new List<Effect>();
            temp.Add(new Effect(Politics.stat.alliances, 1));
            temp.Add(new Effect(Military.stat.weapons, 1));
            PoliticalActions.Add(new Action("Sell Arms To Allies", -5, 0, temp));

            // trade deal
            temp = new List<Effect>();
            temp.Add(new Effect(Politics.stat.trade, 1));
            temp.Add(new Effect(Politics.stat.globalization, 1));
            PoliticalActions.Add(new Action("Pass Trade Agreement", 0, 0, temp));
        }

        public Action(string n, int f, int c, List<Effect> e)
        {
            name = n;
            fundCost = f;
            cloutCost = c;
            econEffects = e;
        }

        public Action(string n, int f, int c)
        {
            name = n;
            fundCost = f;
            cloutCost = c;
            econEffects = new List<Effect>();
        }

        public string Name(){
            return name;
        }

        public int FundCost()
        {
            return this.fundCost;
        }

        public int CloutCost()
        {
            return this.cloutCost;
        }

        public List<Effect> Effects()
        {
            return econEffects;
        }

    }
}
