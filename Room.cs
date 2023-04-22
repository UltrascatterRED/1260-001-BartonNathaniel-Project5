using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1260_001_BartonNathaniel_Project5
{
    internal class Room
    {
        private bool[] Exits = new bool[4];
        private bool HasMonster;
        //private Monster Monster;
        private bool HasWeapon;
        //private Weapon Weapon;
        private int[] position = new int[2];

        public Room()
        {
            Exits = new bool[] { true, true, true, true };
            HasMonster = false;
            HasWeapon = false;
            position = new int[] { 0,0 };
        }
        public string DescString()
        {
            StringBuilder bldr = new StringBuilder();
            Random rand = new Random();
            bldr.Append("You step into another room, just as dim and" +
                "unwelcoming as the last.\n");
            if (HasWeapon)
            {
                bldr.Append("There is a [weapon] propped against one wall.\n"); //link to generation logic to determine weapon type
            }
            if(HasMonster)
            {
                //if(Monster.isDead())
                //{
                //  bldr.Append("A monster's corpse lays sprawled on the ground, felled by your hand.\n");
                //}
                //else
                //{
                    bldr.Append("There is a monster here!\n"); 
                //}
            }
            return bldr.ToString();
        }
    }
}
