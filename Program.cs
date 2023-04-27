using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1260_001_BartonNathaniel_Project5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //bool[] testExits = new bool[] { true, true, true, false };
            //int[] testPos = new int[] { 0, 0 };
            //Room test = new Room(testExits, true, false, testPos);
            //Room test2 = new Room();
            //test.DisplayRoom();

            Dungeon dungeon = new Dungeon(5, 6);
            //Console.WriteLine("Constructor success!");
            dungeon.DisplayFullMap();
            //testing all four movement directions
            //East
            Console.ReadLine();
            dungeon.MovePlayer(2);
            dungeon.DisplayFullMap();
            //South
            Console.ReadLine();
            dungeon.MovePlayer(3);
            dungeon.DisplayFullMap();
            //West
            Console.ReadLine();
            dungeon.MovePlayer(0);
            dungeon.DisplayFullMap();
            //North
            Console.ReadLine();
            dungeon.MovePlayer(1);
            dungeon.DisplayFullMap();

            //prevents output console from instantly closing
            Console.ReadLine();
        }
        static void DisplayMainMenu()
        {

        }
        static void DisplayPauseMenu()
        {

        }
        static void DisplayCombatMenu()
        {

        }
    }
}