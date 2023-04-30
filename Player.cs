using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1260_001_BartonNathaniel_Project5
{
    internal class Player : Entity
    {
        private double PerceptionChance;
        private Weapon Weapon = new Weapon();

        public double GetPerceptionChance() { return PerceptionChance; }

        public void SetPerceptionChance(double perceptionChance) { PerceptionChance = perceptionChance; }
        public void ObtainWeapon(Weapon weapon) { Weapon = new Weapon(weapon); }

        public Player()
        {
            SetHealth(50);
            SetStrength(3);
            SetCritChance(0.05);
            SetAgility(0.15);
            SetAccuracy(0.90);
            SetPerceptionChance(0.3);
        }
        public Player(int health, int strength, double critChance, double agility, double accuracy, double perceptionChance, Weapon weapon = null)
            : base(health, strength, critChance, agility, accuracy)
        {
            SetPerceptionChance(perceptionChance);
        }
        public void ObtainWeapon(Room containingRoom, Weapon weapon)
        {
            Weapon = weapon;
            containingRoom.SetWeapon(new Weapon());
            containingRoom.SetHasWeapon(false);
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
                        target.TakeDamage((this.Strength + Weapon.GetDamage()) * 2);
                        GlobalUtils.DisplayGameMessage("You strike the " + target.GetName() + "! It takes " + ((this.Strength + Weapon.GetDamage()) * 2) + " damage.");
                    }
                    else
                    {
                        target.TakeDamage(this.Strength + Weapon.GetDamage());
                        GlobalUtils.DisplayGameMessage("You strike the " + target.GetName() + "! It takes " + (this.Strength + Weapon.GetDamage()) + " damage.");
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
