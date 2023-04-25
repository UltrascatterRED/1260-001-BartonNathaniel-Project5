using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1260_001_BartonNathaniel_Project5
{
    internal class Room
    {
        //exit order in array: W, N, E, S
        private bool[] Exits = new bool[4];
        private bool HasMonster;
        //private Monster Monster;
        private bool HasWeapon;
        //private Weapon Weapon;
        private int[] Position = new int[2];
        private bool Visited = false;

        //implement random generation of weapons, monsters
        public Room()
        {
            Exits = new bool[] { true, true, true, true };
            HasMonster = false;
            HasWeapon = false;
            Position = new int[] { 0,0 };
            Visited = false;
        }
        public Room(bool[] exits, bool hasMonster, bool hasWeapon, int[] position)
        {
            Exits = exits;
            HasMonster = hasMonster;
            HasWeapon = hasWeapon;
            Position = position;
            Visited = false;
        }

        public string DescString()
        {
            StringBuilder bldr = new StringBuilder();
            Random rand = new Random();
            bldr.Append("You step into another room, just as dim and " +
                "unwelcoming as the last.\n");
            bldr.Append("Exits:  ");
            if (Exits[0]) { bldr.Append("[West]  "); }
            if (Exits[1]) { bldr.Append("[North]  "); }
            if (Exits[2]) { bldr.Append("[East]  "); }
            if (Exits[3]) { bldr.Append("[South]  "); }
            bldr.Append('\n');
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
        public void DisplayRoom()
        {
            try
            {
                Console.SetCursorPosition((Position[0] * 6), Position[1] * 3);
            }
            catch
            {
                Console.Write("+---+ \n" +
                              "|x_x| \n" +
                              "+---+ ");
            }
            StringBuilder bldr = new StringBuilder();

            //row 1
            if (Exits[1]) { bldr.Append("+   + \n"); }
            else { bldr.Append("+---+ \n"); }

            //row 2
            StringBuilder midLineBldr = new StringBuilder(5);           
            if (Exits[0]) { midLineBldr.Append(" "); }
            else { midLineBldr.Append("|"); }
            if (HasMonster) { midLineBldr.Append("M"); }
            if (HasWeapon) { midLineBldr.Append("W"); }
            for(int i = 0; i < midLineBldr.Capacity-(midLineBldr.Length-1); i++)
            {
                midLineBldr.Append(" ");
            }
            if (Exits[2]) { midLineBldr.Append("  \n"); }
            else { midLineBldr.Append("| \n"); }

            bldr.Append(midLineBldr.ToString());
            //row 3
            if (Exits[3]) { bldr.Append("+   + "); }
            else { bldr.Append("+---+ "); }

            return bldr.ToString();
        }
    }
}
