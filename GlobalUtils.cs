using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1260_001_BartonNathaniel_Project5
{
    internal static class GlobalUtils
    {
        public static Player Player = new Player();
        public static Dungeon PlayerDungeon = new Dungeon();
        public static bool PlayerContinue = true;
        public static bool PlayerInGame = true;
        public static bool PlayerInCombat = false;
        public static int GameMenusBuffer = 6;
        public static int PlayerInputPromptBuffer = GameMenusBuffer + 7;
        //public Dagger Dagger = new Dagger(<attributes here>);
        //public Macuahuitl Macuahuitl = new Macuahuitl(<attributes here>);
        //public Axe Axe = new Axe(<attributes here>);

        public static void DisplayGameMessage(string message)
        {
            ClearConsoleSection(PlayerDungeon.GetFullMapHeight() + 1, PlayerDungeon.GetFullMapHeight() + 5);
            //Console.SetCursorPosition(0, PlayerDungeon.GetPlayerMapHeight() + 1);
            //<debug>
            Console.SetCursorPosition(0, PlayerDungeon.GetFullMapHeight() + 1);
            //</debug>
            Console.Write(message);
        }

        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
        //clears a specified section of the console; sectionTop and sectionBottom are both inclusive.
        public static void ClearConsoleSection(int sectionTop, int sectionBottom)
        {
            for (int i = sectionTop; i <= sectionBottom; i++)
            {
                Console.SetCursorPosition(0, i);
                ClearCurrentConsoleLine();
            }
        }

        public static void DisplayPlayerHealth()
        {
            Console.SetCursorPosition(45, PlayerDungeon.GetFullMapHeight() + GameMenusBuffer);
            Console.Write("[+] HEALTH: " + Player.GetHealth() + " [+]");
        }
        //Main menu or "Title Screen" menu.
        public static void DisplayMainMenu()
        {
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

            switch (PromptPlayerInput(1, 4))
            {
                case 1:
                    Console.Clear();
                    GlobalUtils.PlayerDungeon = new Dungeon(3, 4);
                    GlobalUtils.PlayerContinue = true;
                    break;
                case 2:
                    Console.Clear();
                    GlobalUtils.PlayerDungeon = new Dungeon(4, 6);
                    GlobalUtils.PlayerContinue = true;
                    break;
                case 3:
                    Console.Clear();
                    GlobalUtils.PlayerDungeon = new Dungeon(5, 8);
                    GlobalUtils.PlayerContinue = true;
                    break;
                case 4:
                    GlobalUtils.PlayerContinue = false;
                    break;
                default:
                    GlobalUtils.PlayerContinue = true;
                    break;
            }
        }

        //General in-game menu (non-combat actions)
        public static int DisplayGameMenu()
        {
            //GlobalUtilities.ClearConsoleSection(GlobalUtilities.PlayerDungeon.GetPlayerMapHeight() + GlobalUtilities.GameMenusBuffer,
            //GlobalUtilities.PlayerDungeon.GetPlayerMapHeight() + GlobalUtilities.GameMenusBuffer + 20);
            //<debug>
            GlobalUtils.ClearConsoleSection(GlobalUtils.PlayerDungeon.GetFullMapHeight() + GlobalUtils.GameMenusBuffer,
                GlobalUtils.PlayerDungeon.GetFullMapHeight() + GlobalUtils.GameMenusBuffer + 20);
            //</debug>

            DisplayPlayerHealth();
            //Console.SetCursorPosition(0, GlobalAttributes.PlayerDungeon.GetPlayerMapHeight() + GlobalUtilities.GameMenusBuffer);
            //<debug>
            Console.SetCursorPosition(0, PlayerDungeon.GetFullMapHeight() + GameMenusBuffer);
            //</debug>
            Console.WriteLine("[+]-----------[=_=]-----------[+]");
            Console.WriteLine("  1>\tMove North");
            Console.WriteLine("  2>\tMove South");
            Console.WriteLine("  3>\tMove East");
            Console.WriteLine("  4>\tMove West");
            Console.WriteLine("  5>\tPause Game");
            Console.WriteLine();

            return PromptPlayerInput(1, 5);
        }
        //Game menu option functions
        public static void ExecuteGameMenu(int playerChoice)
        {
            switch (playerChoice)
            {
                case 1:
                    PlayerDungeon.MovePlayer(1);
                    break;
                case 2:
                    PlayerDungeon.MovePlayer(3);
                    break;
                case 3:
                    PlayerDungeon.MovePlayer(2);
                    break;
                case 4:
                    PlayerDungeon.MovePlayer(0);
                    break;
                case 5:
                    //called in main
                    //DisplayPauseMenu(0);
                    break;
                default:
                    throw new Exception("Input playerChoice was invalid.");
            }
        }

        //Typical pause menu utilities (resume, exit to title, exit game).
        public static int DisplayPauseMenu(int callingMenuIndex)
        {
            if (callingMenuIndex < 0 || callingMenuIndex > 1)
            {
                throw new Exception("Input value for callingMenuIndex was invalid.");
            }

            //GlobalUtilities.ClearConsoleSection(GlobalUtilities.PlayerDungeon.GetPlayerMapHeight() + GlobalUtilities.GameMenusBuffer,
            //GlobalUtilities.PlayerDungeon.GetPlayerMapHeight() + GlobalUtilities.GameMenusBuffer + 20);
            //<debug>
            ClearConsoleSection(PlayerDungeon.GetFullMapHeight() + GameMenusBuffer, PlayerDungeon.GetFullMapHeight() + GameMenusBuffer + 20);
            //</debug>

            //Console.SetCursorPosition(0, GlobalAttributes.PlayerDungeon.GetPlayerMapHeight() + GlobalUtilities.GameMenusBuffer);
            //<debug>
            Console.SetCursorPosition(0, PlayerDungeon.GetFullMapHeight() + GameMenusBuffer);
            //</debug>
            Console.WriteLine("[||]--------[PAUSED]--------[||]");
            Console.WriteLine("  1>\tResume Game");
            Console.WriteLine("  2>\tExit to Title");
            Console.WriteLine("  3>\tExit Game");
            Console.WriteLine();

            return PromptPlayerInput(1, 3);
        }
        //Pause Menu option functions
        public static void ExecutePauseMenu(int playerChoice)
        {
            switch (playerChoice)
            {
                case 1:
                    break;
                case 2:
                    PlayerInGame = false;
                    break;
                case 3:
                    PlayerInGame = false;
                    PlayerContinue = false;
                    break;
                default:
                    throw new Exception("Input playerChoice was invalid.");
            }
        }

        //In-game combat menu
        public static int DisplayCombatMenu()
        {
            //GlobalUtilities.ClearConsoleSection(GlobalUtilities.PlayerDungeon.GetPlayerMapHeight() + GlobalUtilities.GameMenusBuffer,
            //GlobalUtilities.PlayerDungeon.GetPlayerMapHeight() + GlobalUtilities.GameMenusBuffer + 20);
            //<debug>
            ClearConsoleSection(PlayerDungeon.GetFullMapHeight() + GameMenusBuffer,
                PlayerDungeon.GetFullMapHeight() + GameMenusBuffer + 20);
            //</debug>

            DisplayPlayerHealth();
            //Console.SetCursorPosition(0, GlobalAttributes.PlayerDungeon.GetPlayerMapHeight() + GlobalUtilities.GameMenusBuffer);
            //<debug>
            Console.SetCursorPosition(0, PlayerDungeon.GetFullMapHeight() + GameMenusBuffer);
            //</debug>
            Console.WriteLine(">>>-----------[x_x]------------|>");
            Console.WriteLine("  1>\tAttack!");
            Console.WriteLine("  2>\tAssume defensive stance");
            Console.WriteLine("  3>\tParry");
            Console.WriteLine("  4>\tFlee!");
            Console.WriteLine();

            return PromptPlayerInput(1, 4);
        }
        //Combat menu option functions
        public static void ExecuteCombatMenu(int playerChoice)
        {
            switch (playerChoice)
            {
                case 1:
                    Player.Attack(PlayerDungeon.GetPlayerRoom().GetMonster());
                    PlayerDungeon.GetPlayerRoom().GetMonster().Attack(Player);
                    break;
                case 2:
                    DisplayGameMessage("[This mechanic is in development]");
                    PlayerDungeon.GetPlayerRoom().GetMonster().Attack(Player);
                    break;
                case 3:
                    DisplayGameMessage("[This mechanic is in development]");
                    PlayerDungeon.GetPlayerRoom().GetMonster().Attack(Player);
                    break;
                case 4:
                    DisplayGameMessage("[This mechanic is in development]");
                    break;
                default:
                    throw new Exception("Input playerChoice was invalid.");
            }
        }

        //Victory screen and menu
        public static int DisplayVictoryMenu()
        {
            //GlobalUtilities.ClearConsoleSection(GlobalUtilities.PlayerDungeon.GetPlayerMapHeight() + GlobalUtilities.GameMenusBuffer,
            //GlobalUtilities.PlayerDungeon.GetPlayerMapHeight() + GlobalUtilities.GameMenusBuffer + 20);
            //<debug>
            GlobalUtils.ClearConsoleSection(GlobalUtils.PlayerDungeon.GetFullMapHeight() + GlobalUtils.GameMenusBuffer,
                GlobalUtils.PlayerDungeon.GetFullMapHeight() + GlobalUtils.GameMenusBuffer + 20);
            //</debug>

            //Console.SetCursorPosition(0, GlobalAttributes.PlayerDungeon.GetPlayerMapHeight() + GlobalUtilities.GameMenusBuffer);
            //<debug>
            Console.SetCursorPosition(0, GlobalUtils.PlayerDungeon.GetFullMapHeight() + GlobalUtils.GameMenusBuffer);
            //</debug>
            Console.WriteLine("<-[*]-[*]-[*]-[^-^]-[*]-[*]-[*]->");
            Console.WriteLine("  1>\tReturn to Main Menu");
            Console.WriteLine("  2>\tExit Game");
            Console.WriteLine();

            return PromptPlayerInput(1, 2);
        }
        //Defeat screen and menu
        public static int DisplayDefeatMenu()
        {
            //GlobalUtilities.ClearConsoleSection(GlobalUtilities.PlayerDungeon.GetPlayerMapHeight() + GlobalUtilities.GameMenusBuffer,
            //GlobalUtilities.PlayerDungeon.GetPlayerMapHeight() + GlobalUtilities.GameMenusBuffer + 20);
            //<debug>
            GlobalUtils.ClearConsoleSection(GlobalUtils.PlayerDungeon.GetFullMapHeight() + GlobalUtils.GameMenusBuffer,
                GlobalUtils.PlayerDungeon.GetFullMapHeight() + GlobalUtils.GameMenusBuffer + 20);
            //</debug>

            //Console.SetCursorPosition(0, GlobalAttributes.PlayerDungeon.GetPlayerMapHeight() + GlobalUtilities.GameMenusBuffer);
            //<debug>
            Console.SetCursorPosition(0, GlobalUtils.PlayerDungeon.GetFullMapHeight() + GlobalUtils.GameMenusBuffer);
            //</debug>
            Console.WriteLine("<-[x]-[x]-[x]-[=_=]-[x]-[x]-[x]->");
            Console.WriteLine("  1>\tReturn to Main Menu");
            Console.WriteLine("  2>\tExit Game");
            Console.WriteLine();

            return PromptPlayerInput(1, 2);
        }
        //Victory & Defeat menu option functions (identical for each menu)
        public static void ExecuteGameOverMenu(int playerChoice)
        {
            switch (playerChoice)
            {
                case 1:
                    PlayerInGame = false;
                    break;
                case 2:
                    PlayerInGame = false;
                    PlayerContinue = false;
                    break;
                default:
                    throw new Exception("Input arg for playerChoice was invalid.");
            }
        }
        public static int PromptPlayerInput(int lowBound, int highBound)
        {
            //both bounds are inclusive

            bool valid = false;
            int playerChoice = 0;

            do
            {
                //Console.SetCursorPosition(0, GlobalAttributes.PlayerDungeon.GetPlayerMapHeight() + GlobalAttributes.PlayerInputPromptBuffer);
                //<debug>
                Console.SetCursorPosition(0, GlobalUtils.PlayerDungeon.GetFullMapHeight() + GlobalUtils.PlayerInputPromptBuffer);
                //</debug>
                ClearCurrentConsoleLine();
                Console.Write(" Your choice:\t");
                try
                {
                    playerChoice = int.Parse(Console.ReadLine());
                    if (playerChoice >= lowBound && playerChoice <= highBound)
                    {
                        valid = true;
                    }
                }
                catch
                {
                    //Console.SetCursorPosition(0, GlobalAttributes.PlayerDungeon.GetPlayerMapHeight() + GlobalAttributes.PlayerInputPromptBuffer + 1);
                    //<debug>
                    Console.SetCursorPosition(0, GlobalUtils.PlayerDungeon.GetFullMapHeight() + GlobalUtils.PlayerInputPromptBuffer + 1);
                    //</debug>
                    Console.WriteLine("[x] Enter a listed number");
                }
            } while (!valid);

            return playerChoice;
        }
    }
}
