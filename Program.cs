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
            //construct flow of menu navigation here!
            DisplayMainMenu();

            //prevents output console from instantly closing
            //Console.ReadLine();
        }
        //Main menu or "Title Screen" menu
        static void DisplayMainMenu()
        {
            bool valid = false;

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
                    int playerChoice = int.Parse(Console.ReadLine());
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

        }
        //General in-game menu (non-combat actions)
        static void DisplayGameMenu()
        {
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
                    int playerChoice = int.Parse(Console.ReadLine());
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
        }
        //Typical puase menu utilities (resume, exit to title, exit game)
        static void DisplayPauseMenu()
        {
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
                    int playerChoice = int.Parse(Console.ReadLine());
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
        }
        //In-game combat menu
        static void DisplayCombatMenu()
        {
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
                    int playerChoice = int.Parse(Console.ReadLine());
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