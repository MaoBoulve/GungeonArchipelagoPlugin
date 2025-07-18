using ArchiGungeon.ModConsoleVisuals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArchiGungeon.DebugTools
{
    public class UnitTests
    {
        static string[] unitTestCommands;
        static int commandIndex = -1;

        public static void HandleUnitTestCommand(string commandText)
        {

            switch (commandText)
            {
                #region Go Next Cases
                case "0":
                    {
                        GoToNextUnitTestStep();
                        return;
                    }
                case "next":
                    {
                        goto case "0";
                    }
                #endregion

                case "1":
                    {
                        return;
                    }

                default:
                    {
                        ArchipelagoGUI.ConsoleLog($"ERROR: '{commandText}' not a unity test command");
                        break;
                    }
            }

            return;
        }

        public static void GoToNextUnitTestStep()
        {
            return;
        }

        /*
         * Game Completion Unit Test
            - Quick kill on
            - Teleport to level
            - Teleport to boss
            - Repeat

            Need to account for which game completion goals are active
         */


        /*
         * Pasts Key Item Test
            - Generate different APWorld, Paradox mode always on, pasts
            - Spawn all AP Items
            - Quick kill on
            - Teleport to dragun level
            - Teleport to dragun
            - See if bullet works
         */

        /*
        Floor Clear Test
        - Boss rush
        - Check in boss rush before starting
        - Output if each boss is read by gungeon listener

        ### Deathlink RECEIVE Test
        - Connect sudoku
        - Lose

        ### Deathlink SEND Test
        - Kill player
        - See if sudoku lost

        ### Password & Weird Name Test
        - Setup password & bad name AP World
        - Send console command for password and name set commands
        - full connect

        ### AP Item Receive Stress Test
        - Spawn 5 AP Items
        - Pickup
        - Repeat 5 AP Items 
         
         */

    }
}
