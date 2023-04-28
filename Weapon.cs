using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1260_001_BartonNathaniel_Project5
{
    internal class Weapon
    {
        private string Name;
        private string Description;
        private int Damage;
        private double AccuracyMod;

        //getters
        public string GetName() { return Name; }
        public string GetDescription() { return Description; }
        public int GetDamage() { return Damage; }
        public double GetAccuracyMod() { return AccuracyMod; } //formula: Acc = BaseAcc + (BaseAcc * AccuracyMod)

        //setters
        public void SetName(string name) { Name = name; }
        public void SetDescription(string description) { Description = description; }
        public void SetDamage(int damage) { Damage = damage; }
        public void SetAccuracyMod(double accuracyMod) { AccuracyMod = accuracyMod; }

        public Weapon() 
        {
            SetName("Fists");
            SetDescription("You are unarmed. Hopefully you've brushed up on hand-to-hand combat.");
            SetDamage(0);
            SetAccuracyMod(0);
        }
        public Weapon(string name, string description, int damage, double accuracyMod)
        {
            Name = name;
            Description = description;
            Damage = damage;
            AccuracyMod = accuracyMod;
        }

        public Weapon(Weapon other)
        {
            Name = other.Name;
            Description = other.Description;
            Damage = other.Damage;
            AccuracyMod = other.AccuracyMod;
        }

        public override string ToString()
        {
            return GetName() + "\n" + 
                "<------------------------>\n" +
                GetDescription() + "\n";
        }
    }
}
