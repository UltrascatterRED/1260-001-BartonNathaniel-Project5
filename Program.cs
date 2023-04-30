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
            do
            {
                DisplayMainMenu();
                if (!GlobalAttributes.PlayerContinue) { break; }
                GlobalAttributes.PlayerInGame = true;
                do
                {
                    GlobalAttributes.PlayerDungeon.DisplayFullMap();
                    int gameMenuChoice = DisplayGameMenu();
                    ExecuteGameMenu(gameMenuChoice);
                    if(gameMenuChoice == 5) 
                    { 
                        int pauseMenuChoice = DisplayPauseMenu(0);
                        ExecutePauseMenu(pauseMenuChoice);
                        continue;
                    }
                    //if (!GlobalAttributes.PlayerInGame) { break; }
                } while (GlobalAttributes.PlayerInGame);

            } while (GlobalAttributes.PlayerContinue);

            //prevents output console from instantly closing
            //Console.ReadLine();
        }

        //Main menu or "Title Screen" menu.
        //Returns bool to indicate whether or not player wants to continue.
        static void DisplayMainMenu()
        {
            bool valid = false;
            int playerChoice = 0;

            Console.Clear();
            Console.SetCursorPosition(0, 1);
            Console.WriteLine(@"/\^^^^^^^^^^^^^^^^^^^^^^^^^^^/\");
            Console.WriteLine(@"| [=_=] CONSOLE CRAWLER [x_x] |");
            Console.WriteLine(@"+-----------------------------+");
            Console.WriteLine();
            Console.WriteLine("  1>\tEnter Dungeon - Small");
            Console.WriteLine("  2>\tEnter Dungeon - Medium");
            Console.WriteLine("  3>\tEnter Dungeon - Large");
            Console.WriteLine("  4>\tExit Game");
            Console.WriteLine();
            do
            {
                Console.SetCursorPosition(0, 10);
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
                    Console.Clear();
                    GlobalAttributes.PlayerDungeon = new Dungeon(3, 4);
                    GlobalAttributes.PlayerContinue = true;
                    break;
                case 2:
                    Console.Clear();
                    GlobalAttributes.PlayerDungeon = new Dungeon(4, 6);
                    GlobalAttributes.PlayerContinue = true;
                    break;
                case 3:
                    Console.Clear();
                    GlobalAttributes.PlayerDungeon = new Dungeon(5, 8);
                    GlobalAttributes.PlayerContinue = true;
                    break;
                case 4:
                    GlobalAttributes.PlayerContinue = false;
                    break;
                default:
                    GlobalAttributes.PlayerContinue = true;
                    break;
            }
        }

        //General in-game menu (non-combat actions)
        static int DisplayGameMenu()
        {
            int playerChoice = 0;
            bool valid = false;

            ClearPrevMenu();
            Console.SetCursorPosition(0, GlobalAttributes.PlayerDungeon.GetPlayerMapHeight() + 5);
            Console.WriteLine("[+]-----------[=_=]-----------[+]");
            Console.WriteLine("  1>\tMove North");
            Console.WriteLine("  2>\tMove South");
            Console.WriteLine("  3>\tMove East");
            Console.WriteLine("  4>\tMove West");
            Console.WriteLine("  5>\tPause Game");
            Console.WriteLine();
            do
            {
                Console.SetCursorPosition(0, GlobalAttributes.PlayerDungeon.GetPlayerMapHeight() + 12);
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

            return playerChoice;
        }
        //Game menu option functions
        static void ExecuteGameMenu(int playerChoice)
        {
            switch(playerChoice)
            {
                case 1:
                    GlobalAttributes.PlayerDungeon.MovePlayer(1);
                    break;
                case 2:
                    GlobalAttributes.PlayerDungeon.MovePlayer(3);
                    break;
                case 3:
                    GlobalAttributes.PlayerDungeon.MovePlayer(2);
                    break;
                case 4:
                    GlobalAttributes.PlayerDungeon.MovePlayer(0);
                    break;
                case 5:
                    //called in main
                    //DisplayPauseMenu(0);
                    break;
                default:
                    throw new Exception("Input playerChoice was invalid.");
            }
        }

        //Typical puase menu utilities (resume, exit to title, exit game).
        //Returns bool to indicate whether or not player wants to continue.
        static int DisplayPauseMenu(int callingMenuIndex)
        {
            if (callingMenuIndex < 0 || callingMenuIndex > 1)
            {
                throw new Exception("Input value for callingMenuIndex was invalid.");
            }

            int playerChoice = 0;
            bool valid = false;

            ClearPrevMenu();
            Console.SetCursorPosition(0, GlobalAttributes.PlayerDungeon.GetPlayerMapHeight() + 5);
            Console.WriteLine("[||]--------[PAUSED]--------[||]");
            Console.WriteLine("  1>\tResume Game");
            Console.WriteLine("  2>\tExit to Title");
            Console.WriteLine("  3>\tExit Game");
            Console.WriteLine();
            do
            {
                Console.SetCursorPosition(0, GlobalAttributes.PlayerDungeon.GetPlayerMapHeight() + 10);
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

            return playerChoice;

            /*switch (callingMenuIndex)
            {
                  case 0:
                     return 0;
                  case 1:
                     return 1;
                  default:
                     return -1;
            }*/
        }
        //Pause Menu option functions
        static void ExecutePauseMenu(int playerChoice)
        {
            switch (playerChoice)
            {
                case 1:
                    break;
                case 2:
                    GlobalAttributes.PlayerInGame = false;
                    break;
                case 3:
                    GlobalAttributes.PlayerInGame = false;
                    GlobalAttributes.PlayerContinue = false;
                    break;
                default:
                    throw new Exception("Input playerChoice was invalid.");
            }
        }

        //In-game combat menu
        static int DisplayCombatMenu()
        {
            bool valid = false;
            int playerChoice = 0;

            ClearPrevMenu();
            Console.SetCursorPosition(0, GlobalAttributes.PlayerDungeon.GetPlayerMapHeight() + 5);
            Console.WriteLine(">>>-----------[x_x]------------|>");
            Console.WriteLine("  1>\tAttack!");
            Console.WriteLine("  2>\tAssume defensive stance");
            Console.WriteLine("  3>\tParry");
            Console.WriteLine("  4>\tFlee!");
            Console.WriteLine();
            do
            {
                Console.SetCursorPosition(0, GlobalAttributes.PlayerDungeon.GetPlayerMapHeight() + 11);
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

            return playerChoice;
        }
        //Combat menu option functions
        static void ExecuteCombatMenu(int playerChoice)
        {
            switch (playerChoice)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                default:
                    throw new Exception("Input playerChoice was invalid.");
            }
        }

        //Victory screen and menu
        static int DisplayVictoryMenu()
        {
            bool valid = false;
            int playerChoice = 0;

            ClearPrevMenu();
            Console.SetCursorPosition(0, GlobalAttributes.PlayerDungeon.GetPlayerMapHeight() + 5);
            Console.WriteLine("<-[*]-[*]-[*]-[^-^]-[*]-[*]-[*]->");
            Console.WriteLine("  1>\tReturn to Main Menu");
            Console.WriteLine("  2>\tExit Game");
            Console.WriteLine();
            do
            {
                Console.SetCursorPosition(0, GlobalAttributes.PlayerDungeon.GetPlayerMapHeight() + 9);
                ClearCurrentConsoleLine();
                Console.Write(" Your choice:\t");
                try
                {
                    playerChoice = int.Parse(Console.ReadLine());
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

            return playerChoice;
        }
        //Defeat screen and menu
        static int ShowDefeatMenu()
        {
            bool valid = false;
            int playerChoice = 0;

            ClearPrevMenu();
            Console.SetCursorPosition(0, GlobalAttributes.PlayerDungeon.GetPlayerMapHeight() + 5);
            Console.WriteLine("<-[x]-[x]-[x]-[=_=]-[x]-[x]-[x]->");
            Console.WriteLine("  1>\tReturn to Main Menu");
            Console.WriteLine("  2>\tExit Game");
            Console.WriteLine();
            do
            {
                Console.SetCursorPosition(0, GlobalAttributes.PlayerDungeon.GetPlayerMapHeight() + 9);
                ClearCurrentConsoleLine();
                Console.Write(" Your choice:\t");
                try
                {
                    playerChoice = int.Parse(Console.ReadLine());
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

            return playerChoice;
        }
        //Victory & Defeat menu option functions (identical for each menu)
        static void ExecuteGameOverMenu(int playerChoice)
        {
            switch (playerChoice)
            {
                case 1:
                    break;
                case 2:
                    break;
                default:
                    throw new Exception("Input playerChoice was invalid.");
            }
        }

        static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
        static void ClearPrevMenu()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(0, GlobalAttributes.PlayerDungeon.GetPlayerMapHeight() + 5 + i);
                ClearCurrentConsoleLine();
            }
        }
    }
}