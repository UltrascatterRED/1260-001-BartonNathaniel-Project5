using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1260_001_BartonNathaniel_Project5
{
    internal class Entity
    {
        protected int Health;
        protected int Strength;
        protected double CritChance;
        protected double Agility;
        protected double Accuracy;

        //getters
        public int GetHealth() { return Health; }
        public int GetStrength() { return Strength;}
        public double GetCritChance() { return CritChance;}
        public double GetAgility() { return Agility;}
        public double GetAccuracy() { return Accuracy;}

        //setters
        public void SetHealth(int health) 
        { 
            if(health < 0) 
            { 
                Health = 0;
            }
            else
            {
                Health = health;
            }
        }
        public void SetStrength(int strength) 
        { 
            if(strength < 0)
            {
                Strength = 0;
            }
            else
            {
                Strength = strength;
            }
        }
        public void SetCritChance(double critChance) 
        { 
            if(critChance < 0)
            { 
                CritChance = 0;
            }
            else if(critChance > 1)
            {
                CritChance = 1;
            }
            else
            {
                CritChance = critChance;
            }
        }
        public void SetAgility(double agility)
        {
            if (agility < 0)
            {
                Agility = 0;
            }
            else if (agility > 1)
            {
                Agility = 1;
            }
            else
            {
                Agility = agility;
            }
        }
        public void SetAccuracy(double accuracy) 
        {
            if (accuracy < 0)
            {
                Accuracy = 0;
            }
            else if (accuracy > 1)
            {
                Accuracy = 1;
            }
            else
            {
                Accuracy = accuracy;
            }
        }

        public Entity()
        {
            SetHealth(0);
            SetStrength(0);
            SetCritChance(0);
            SetAgility(0);
            SetAccuracy(0);
        }
        public Entity(int health, int strength, double critChance, double agility, double accuracy)
        {
            Health = health;
            Strength = strength;
            CritChance = critChance;
            Agility = agility;
            Accuracy = accuracy;
        }
        public virtual void Attack(Entity target)
        {
            Random rand = new Random();
            if(rand.Next(10000) < Accuracy * 10000)
            {
                if(rand.Next(10000) < Agility * 10000)
                {
                    if (rand.Next(10000) < CritChance * 10000)
                    {
                        target.TakeDamage(this.Strength * 2);
                    }
                    else
                    {
                        target.TakeDamage(this.Strength);
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
        public void TakeDamage(int damage)
        {
            SetHealth(GetHealth() - damage);
        }
    }
}
