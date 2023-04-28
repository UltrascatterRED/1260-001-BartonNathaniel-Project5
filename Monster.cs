using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1260_001_BartonNathaniel_Project5
{
    internal class Monster : Entity
    {
        private double RageChance;

        public double GetRageChance() { return RageChance; }

        public void SetRageChance(double rageChance) { RageChance = rageChance; }

        public Monster()
        {
            SetHealth(20);
            SetStrength(4);
            SetCritChance(0.05);
            SetAgility(0.08);
            SetAccuracy(0.90);
            SetRageChance(.03);
        }
    }
}
