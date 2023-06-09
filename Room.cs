﻿using System;
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
        private Monster Monster = new Monster();
        private bool HasWeapon;
        private Weapon Weapon = new Weapon();
        private int[] Position = new int[2];
        private bool PlayerPresent = false;
        private bool Visited = false;

        public bool HasWestExit() { return Exits[0]; }
        public bool HasNorthExit() { return Exits[1]; }
        public bool HasEastExit() { return Exits[2]; }
        public bool HasSouthExit() { return Exits[3]; }
        public bool GetHasMonster() { return HasMonster; }
        public Monster GetMonster() { return Monster; }
        public bool GetHasWeapon() { return HasWeapon; }
        public Weapon GetWeapon() { return Weapon; }
        public int GetPosX() { return Position[0]; }
        public int GetPosY() { return Position[1]; }
        public bool GetPlayerPresent() { return PlayerPresent; }
        public bool GetVisited() { return Visited; }

        public void SetHasMonster(bool value) { HasMonster = value; }
        public void SetMonster(Monster monster) { Monster = monster; }
        public void SetHasWeapon(bool value) { HasWeapon = value; }
        public void SetWeapon(Weapon weapon) { Weapon = weapon; }
        public void Visit()
        {
            PlayerPresent = true;
            Visited = true;
        }
        public void Leave()
        {
            PlayerPresent = false;
        }

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
            bldr.Append("You step into a dim and unwelcoming chamber.\n");
            bldr.Append("Exits:  ");
            if (Exits[0]) { bldr.Append("[West]  "); }
            if (Exits[1]) { bldr.Append("[North]  "); }
            if (Exits[2]) { bldr.Append("[East]  "); }
            if (Exits[3]) { bldr.Append("[South]  "); }
            bldr.Append('\n');
            if (HasWeapon)
            {
                bldr.Append("There is a " + Weapon.GetName() + " propped against one wall.\n"); //link to generation logic to determine weapon type
            }
            if(HasMonster)
            {
                if(Monster.GetIsDead())
                {
                  bldr.Append("A monster's corpse lays sprawled on the ground, felled by your hand.\n");
                }
                else
                {
                    bldr.Append("There is a monster here!\n"); 
                }
            }
            return bldr.ToString();
        }

        public void DisplayRoom()
        {
            try
            {
                Console.SetCursorPosition(Position[0] * 6, Position[1] * 3);
            }
            catch
            {
                Console.Write("|x_x| ");
            }
            //StringBuilder bldr = new StringBuilder();

            //row 1
            if (Exits[1]) { Console.Write("+   + "); }
            else { Console.Write("+---+ "); }
            //row 2
            Console.SetCursorPosition(Position[0] * 6, (Position[1] * 3) + 1);
            StringBuilder midLineBldr = new StringBuilder(6);   
            
            if (Exits[0]) { midLineBldr.Append(" "); }
            else { midLineBldr.Append("|"); }
            if(PlayerPresent) { midLineBldr.Append("P"); }
            if (HasMonster && !Monster.GetIsDead()) { midLineBldr.Append("M"); }
            if (HasMonster && Monster.GetIsDead()) { midLineBldr.Append("X"); }
            if (HasWeapon) { midLineBldr.Append("T"); }
            for(int i = 0; i < midLineBldr.Capacity-midLineBldr.Length; i++)
            {
                midLineBldr.Append(" ");
            }
            if (Exits[2]) { midLineBldr.Append("  "); }
            else { midLineBldr.Append("| "); }

            Console.Write(midLineBldr.ToString());
            //row 3
            Console.SetCursorPosition(Position[0] * 6, (Position[1] * 3) + 2);
            if (Exits[3]) { Console.Write("+   + "); }
            else { Console.Write("+---+ "); }

        }
    }
}
