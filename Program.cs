using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1260_001_BartonNathaniel_Project5
{
    internal class Program
    {
        //make static class of these global attributes:
        //public Dungeon PlayerDungeon = new Dungeon();
        //public Dagger Dagger = new Dagger(<attributes here>);
        //public Macuahuitl Macuahuitl = new Macuahuitl(<attributes here>);
        //public Axe Axe = new Axe(<attributes here>);

        static void Main(string[] args)
        {
            //construct flow of menu navigation here!
            DisplayMainMenu();




            //prevents output console from instantly closing
            //Console.ReadLine();
        }
        //Main menu or "Title Screen" menu.
        //Returns bool to indicate whether or not player wants to continue.
        static bool DisplayMainMenu()
        {
            bool valid = false;
            int playerChoice = 0;

            Console.Clear();
            Console.SetCursorPosition(0, 2);
            Console.WriteLine(@"/\^^^^^^^^^^^^^^^^^^^^^^^^^^^/\");
            Console.WriteLine(@"| [x_x] CONSOLE CRAWLER [x_x] |");
            Console.WriteLine(@"+-----------------------------+");
            Console.WriteLine();
            Console.WriteLine("  1>\tEnter Dungeon - Small");
            Console.WriteLine("  2>\tEnter Dungeon - Medium");
            Console.WriteLine("  3>\tEnter Dungeon - Large");
            Console.WriteLine("  4>\tExit Game");
            Console.WriteLine();
            do
            {
                Console.SetCursorPosition(0, 11);
                ClearCurrentConsoleLine();
                Console.Write(" Your choice:\t");
                try
                {
                    playerChoice = int.Parse(Console.ReadLine());
                    if(playerChoice >= 1 && playerChoice <= 4)
                    {
                        valid = true;
                    }
                }
                catch
                {
                    Console.SetCursorPosition(0, 12);
                    Console.WriteLine("[x] Enter a listed number");
                }
            } while (!valid);

            switch (playerChoice)
            {
                case 1:
                    //dungeon = new Dungeon(3, 4);
                    return true;
                case 2:
                    //dungeon = new Dungeon(5, 7);
                    return true;
                case 3:
                    //dungeon = new Dungeon(7, 10);
                    return true;
                case 4:
                    return false;
                default:
                    return true;
            }
        }
        //General in-game menu (non-combat actions)
        static void DisplayGameMenu()
        {
            int playerChoice = 0;
            bool valid = false;

            //Console.SetCursorPosition(0, <vert pos depends on dungeon size>)
            Console.WriteLine("[+]-----------[=_=]-----------[+]");
            Console.WriteLine("  1>\tMove North");
            Console.WriteLine("  2>\tMove South");
            Console.WriteLine("  3>\tMove East");
            Console.WriteLine("  4>\tMove West");
            Console.WriteLine("  5>\tPause Game");
            Console.WriteLine();
            do
            {
                Console.SetCursorPosition(0, 11);
                ClearCurrentConsoleLine();
                Console.Write(" Your choice:\t");
                try
                {
                    playerChoice = int.Parse(Console.ReadLine());
                    if (playerChoice >= 1 && playerChoice <= 5)
                    {
                        valid = true;
                    }
                }
                catch
                {
                    Console.SetCursorPosition(0, 12);
                    Console.WriteLine("[x] Enter a listed number");
                }
            } while (!valid);
        }
        //Typical puase menu utilities (resume, exit to title, exit game).
        //Returns bool to indicate whether or not player wants to continue.
        static bool DisplayPauseMenu()
        {
            int playerChoice = 0;
            bool valid = false;

            //Console.SetCursorPosition(0, <vert pos depends on dungeon size>)
            Console.WriteLine("[||]--------[PAUSED]--------[||]");
            Console.WriteLine("  1>\tResume Game");
            Console.WriteLine("  2>\tExit to Title");
            Console.WriteLine("  3>\tExit Game");
            Console.WriteLine();
            do
            {
                //Console.SetCursorPosition(0, <vert pos depends on dungeon size>);
                ClearCurrentConsoleLine();
                Console.Write(" Your choice:\t");
                try
                {
                    playerChoice = int.Parse(Console.ReadLine());
                    if (playerChoice >= 1 && playerChoice <= 3)
                    {
                        valid = true;
                    }
                }
                catch
                {
                    Console.SetCursorPosition(0, 12);
                    Console.WriteLine("[x] Enter a listed number");
                }
            } while (!valid);

            //temp return statement to avoid errors
            return true;
        }
        //In-game combat menu
        static void DisplayCombatMenu()
        {
            bool valid = false;
            int playerChoice = 0;

            //Console.SetCursorPosition(0, <vert pos depends on dungeon size>)
            Console.WriteLine(">>>-----------[x_x]------------|>");
            Console.WriteLine("  1>\tAttack!");
            Console.WriteLine("  2>\tAssume defensive stance");
            Console.WriteLine("  3>\tParry");
            Console.WriteLine("  4>\tFlee!");
            Console.WriteLine();
            do
            {
                //Console.SetCursorPosition(0, <vert pos depends on dungeon size>);
                ClearCurrentConsoleLine();
                Console.Write(" Your choice:\t");
                try
                {
                    playerChoice = int.Parse(Console.ReadLine());
                    if (playerChoice >= 1 && playerChoice <= 4)
                    {
                        valid = true;
                    }
                }
                catch
                {
                    Console.SetCursorPosition(0, 12);
                    Console.WriteLine("[x] Enter a listed number");
                }
            } while (!valid);

            switch (playerChoice)
            {

            }
            return true;
        }
        public static bool DisplayVictoryMenu()
        {
            bool valid = false;

            //Console.SetCursorPosition(0, <vert pos depends on dungeon size>)
            Console.WriteLine("<-[*]-[*]-[*]-[^-^]-[*]-[*]-[*]->");
            Console.WriteLine("  1>\tReturn to Main Menu");
            Console.WriteLine("  2>\tExit Game");
            Console.WriteLine();
            do
            {
                //Console.SetCursorPosition(0, <vert pos depends on dungeon size>);
                ClearCurrentConsoleLine();
                Console.Write(" Your choice:\t");
                try
                {
                    int playerChoice = int.Parse(Console.ReadLine());
                    if (playerChoice >= 1 && playerChoice <= 2)
                    {
                        valid = true;
                    }
                }
                catch
                {
                    Console.SetCursorPosition(0, 12);
                    Console.WriteLine("[x] Enter a listed number");
                }
            } while (!valid);

        }

        public static bool ShowDefeatMenu()
        {
            bool valid = false;

            //Console.SetCursorPosition(0, <vert pos depends on dungeon size>)
            Console.WriteLine("<-[x]-[x]-[x]-[=_=]-[x]-[x]-[x]->");
            Console.WriteLine("  1>\tReturn to Main Menu");
            Console.WriteLine("  2>\tExit Game");
            Console.WriteLine();
            do
            {
                //Console.SetCursorPosition(0, <vert pos depends on dungeon size>);
                ClearCurrentConsoleLine();
                Console.Write(" Your choice:\t");
                try
                {
                    int playerChoice = int.Parse(Console.ReadLine());
                    if (playerChoice >= 1 && playerChoice <= 2)
                    {
                        valid = true;
                    }
                }
                catch
                {
                    Console.SetCursorPosition(0, 12);
                    Console.WriteLine("[x] Enter a listed number");
                }
            } while (!valid);
        }

        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
    }
}