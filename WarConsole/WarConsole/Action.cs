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

        public static void BuildActions(){

            // -----------------------------
            //           MILITARY ACTIONS
            // -----------------------------
            MilitaryActions = new List<Action>();

            // Increase Funding
            EconActions.Add(new Action("Increase Funding", 10, 0));
            EconActions.Add(new Action("Decrease Funding", -10, 0));

            // Invest in
            // - infrastructure
            List<Effect> temp = new List<Effect>();
            temp.Add(new Effect(Economy.stat.infrastructure, 1));
            EconActions.Add(new Action("Invest in Infrastructure", 5, 5, temp));

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

        public List<Effect> Effects()
        {
            return econEffects;
        }

    }
}
