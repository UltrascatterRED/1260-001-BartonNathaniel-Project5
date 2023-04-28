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

            //Dungeon dungeon = new Dungeon(5, 6);
            //dungeon.DisplayFullMap();
            //testing all four movement directions
            //East
            //Console.ReadLine();
            //dungeon.MovePlayer(2);
            //dungeon.DisplayFullMap();
            //South
            //Console.ReadLine();
            //dungeon.MovePlayer(3);
            //dungeon.DisplayFullMap();
            //West
            //Console.ReadLine();
            //dungeon.MovePlayer(0);
            //dungeon.DisplayFullMap();
            //North
            //Console.ReadLine();
            //dungeon.MovePlayer(1);
            //dungeon.DisplayFullMap();

            DisplayMainMenu();
            //Monster monster = new Monster();

            //prevents output console from instantly closing
            Console.ReadLine();
        }
        //Main menu or "Title Screen" menu
        static void DisplayMainMenu()
        {
            Console.WriteLine(@"/\^^^^^^^^^^^^^^^^^^^^^^^^^^^/\");
            Console.WriteLine(@"| [x_x] CONSOLE CRAWLER [x_x] |");
            Console.WriteLine(@"+-----------------------------+");
            Console.WriteLine();
            Console.WriteLine("1>\tEnter Dungeon - Small");
            Console.WriteLine("2>\tEnter Dungeon - Medium");
            Console.WriteLine("3>\tEnter Dungeon - Large");
            Console.WriteLine("4>\tExit Game");
            Console.WriteLine();
            Console.Write("Your choice:\t");
        }
        //General in-game menu (non-combat actions)
        static void DisplayGameMenu()
        {

        }
        //Typical puase menu utilities (resume, exit to title, exit game)
        static void DisplayPauseMenu()
        {

        }
        //In-game combat menu
        static void DisplayCombatMenu()
        {

        }
    }
}