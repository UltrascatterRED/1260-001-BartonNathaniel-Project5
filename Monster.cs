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
            SetName("Monster");
            SetHealth(20);
            SetStrength(4);
            SetCritChance(0.05);
            SetAgility(0.10);
            SetAccuracy(0.90);
            SetRageChance(0.03);
        }
        public override void Attack(Entity target)
        {
            Random rand = new Random();
            if (rand.Next(10000) < Accuracy * 10000)
            {
                if (rand.Next(10000) < Agility * 10000)
                {
                    if (rand.Next(10000) < CritChance * 10000)
                    {
                        target.TakeDamage(this.Strength * 2);
                        GlobalUtils.DisplayGameMessage("The " + Name + " attacks! You take " + (this.Strength * 2) + " damage.");
                    }
                    else
                    {
                        target.TakeDamage(this.Strength);
                        GlobalUtils.DisplayGameMessage("The " + Name + " attacks! You take " + (this.Strength) + " damage.");
                    }
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }
            
        }
    }
}
