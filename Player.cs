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
        public Player(int health, int strength, double critChance, double agility, double accuracy, double perceptionChance, Weapon weapon = null)
            : base(health, strength, critChance, agility, accuracy)
        {
            SetPerceptionChance(perceptionChance);
        }
        public override void Attack(Entity target)
        {
            //same as base, but applying weapon logic if armed
        }
    }
}
