using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarConsole
{
    class Effect
    {
        private Economy.stat eStat;
        private Military.stat mStat;
        private Politics.stat pStat;
        private int bonus;

        public Effect(Economy.stat e, int b)
        {
            eStat = e;
            bonus = b;
        }

        public Effect(Military.stat m, int b)
        {
            mStat = m;
            bonus = b;
        }

        public Effect(Politics.stat p, int b)
        {
            pStat = p;
            bonus = b;
        }

        public Economy.stat Estat()
        {
            return eStat;
        }
        public Military.stat Mstat()
        {
            return mStat;
        }
        public Politics.stat Pstat()
        {
            return pStat;
        }

        public int Bonus()
        {
            return bonus;
        }

    }
}
