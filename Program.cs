using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
                GlobalUtils.DisplayMainMenu();
                if (!GlobalUtils.PlayerContinue) { break; }
                GlobalUtils.PlayerInGame = true;
                do
                {
                    GlobalUtils.PlayerDungeon.DisplayFullMap();
                    GlobalUtils.DisplayGameMessage(GlobalUtils.PlayerDungeon.GetPlayerRoom().DescString());
                    if (GlobalUtils.PlayerDungeon.GetPlayerRoom().GetHasMonster() && !GlobalUtils.PlayerDungeon.GetPlayerRoom().GetMonster().GetIsDead())
                    {
                        GlobalUtils.PlayerInCombat = true;
                        do
                        {
                            int combatMenuChoice = GlobalUtils.DisplayCombatMenu();
                            GlobalUtils.ExecuteCombatMenu(combatMenuChoice);
                            if(GlobalUtils.PlayerDungeon.GetPlayerRoom().GetMonster().GetHealth() <= 0)
                            {
                                GlobalUtils.PlayerDungeon.GetPlayerRoom().GetMonster().Die();
                                GlobalUtils.DisplayGameMessage("You defeated the " + GlobalUtils.PlayerDungeon.GetPlayerRoom().GetMonster().GetName() + "!");
                                GlobalUtils.PlayerInCombat = false;
                            }
                            if(GlobalUtils.Player.GetHealth() <= 0)
                            {
                                GlobalUtils.Player.Die();
                                GlobalUtils.DisplayGameMessage(
                                    "The " + GlobalUtils.PlayerDungeon.GetPlayerRoom().GetMonster().GetName() + " killed you.\n" +
                                    "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx\n" +
                                    "|                YOU DIED               |\n" +
                                    "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
                                int defeatMenuChoice = GlobalUtils.DisplayDefeatMenu();  
                                GlobalUtils.ExecuteGameOverMenu(defeatMenuChoice);
                            }
                        } while (GlobalUtils.PlayerInCombat);
                    }

                    int gameMenuChoice = GlobalUtils.DisplayGameMenu();
                    GlobalUtils.ExecuteGameMenu(gameMenuChoice);
                    if(gameMenuChoice == 5) 
                    { 
                        int pauseMenuChoice = GlobalUtils.DisplayPauseMenu(0);
                        GlobalUtils.ExecutePauseMenu(pauseMenuChoice);
                        continue;
                    }
                    //if (!GlobalAttributes.PlayerInGame) { break; }
                } while (GlobalUtils.PlayerInGame);

            } while (GlobalUtils.PlayerContinue);

            //prevents output console from instantly closing
            //Console.ReadLine();
        }

    }
}