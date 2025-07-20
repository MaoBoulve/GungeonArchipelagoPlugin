using ArchiGungeon.ArchipelagoServer;
using ArchiGungeon.Data;
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

        

        static string[] unitTest2 =
        [
            "ff",
            "fff"
        ];

        static string[] unitTest3 =
        [
            "ff",
            "fff"
        ];

        static string[] unitTest4 =
        [
            "ff",
            "fff"
        ];

        static string[] unitTest5 =
        [
            "ff",
            "fff"
        ];

        static string[] unitTest6 =
        [
            "ff",
            "fff"
        ];

        static string[] unitTest7 =
        [
            "ff",
            "fff"
        ];


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
                        LoadUnitTest1();
                        return;
                    }
                case "2":
                    {
                        LoadUnitTest2();
                        return;
                    }
                case "3":
                    {
                        LoadUnitTest3();
                        return;
                    }
                case "4":
                    {
                        LoadUnitTest4();
                        return;
                    }
                case "5":
                    {
                        LoadUnitTest5();
                        return;
                    }
                case "6":
                    {
                        LoadUnitTest6();
                        return;
                    }
                case "7":
                    {
                        LoadUnitTest7();
                        return;
                    }
                default:
                    {
                        ArchipelagoGUI.ConsoleLog($"ERROR: '{commandText}' not a unit test command");
                        break;
                    }
            }

            return;
        }

        public static void GoToNextUnitTestStep()
        {
            if(commandIndex >= (unitTestCommands.Length - 1))
            {
                return;
            }

            commandIndex++;

            string[] splitCommand = SplitStepString(unitTestCommands[commandIndex]);

            ParseStepCommand(splitCommand);

            //SendConsoleCommand(unitTestCommands[commandIndex]);

            return;
        }

        private static string[] SplitStepString(string text)
        {
            string[] separator = { " " };
            string[] result = text.Split(separator, 2, StringSplitOptions.None);

            return result;
        }

        private static void ParseStepCommand(string[] stepCommand)
        {

            switch(stepCommand[0])
            {
                case "cmd":
                    {
                        SendConsoleCommand(stepCommand[1]);
                        return;
                    }
                case "print":
                    {
                        SendOutputString(stepCommand[1]);
                        GoToNextUnitTestStep();
                        return;
                    }
            }

            return;
        }


        private static void SendConsoleCommand(string consoleString)
        {
            ETGModConsole.Instance?.ParseCommand(consoleString);
            return;
        }

        private static void SendOutputString(string outputString)
        {
            ArchipelagoGUI.ConsoleLog($"UNIT TEST: {outputString}" );
            return;
        }

        private static void LoadUnitTest1()
        {
            /*
                * Game Completion Unit Test
                - Quick kill on
                - Teleport to level
                - Teleport to boss
                - Repeat

                Need to account for which game completion goals are active
                */

            List<PlayerCompletionGoals> goals = ArchipelagoCompletion.ArchipelagoRequiredGoals;
            List<string> goalConsoleCommands = new List<string>();

            foreach (PlayerCompletionGoals goal in goals)
            {
                switch (goal)
                {
                    case PlayerCompletionGoals.SecretChamber:

                        goalConsoleCommands.Add("cmd load_level sewers");
                        goalConsoleCommands.Add("cmd load_level abbey");

                        break;
                    case PlayerCompletionGoals.Dragun:
                        goalConsoleCommands.Add("cmd load_level forge");
                        break;
                    case PlayerCompletionGoals.Lich:
                        goalConsoleCommands.Add("cmd load_level hell");
                        break;
                    case PlayerCompletionGoals.AdvancedGungeon:
                        goalConsoleCommands.Add("cmd load_level forge");
                        goalConsoleCommands.Add("cmd spawn item weird_egg");
                        goalConsoleCommands.Add("cmd load_level ratlair");
                        break;
                    case PlayerCompletionGoals.FarewellArms:
                        goalConsoleCommands.Add("cmd load_level rng_dept");
                        break;
                    case PlayerCompletionGoals.PastsBase:
                        goalConsoleCommands.Add("cmd load_level marinepast");
                        goalConsoleCommands.Add("cmd load_level convictpast");
                        goalConsoleCommands.Add("cmd load_level hunterpast");
                        goalConsoleCommands.Add("cmd load_level pilotpast");
                        break;
                    case PlayerCompletionGoals.PastsFull:
                        goalConsoleCommands.Add("cmd load_level marinepast");
                        goalConsoleCommands.Add("cmd load_level convictpast");
                        goalConsoleCommands.Add("cmd load_level hunterpast");
                        goalConsoleCommands.Add("cmd load_level pilotpast");
                        goalConsoleCommands.Add("cmd load_level robotpast");
                        goalConsoleCommands.Add("cmd load_level bulletpast");
                        break;
                }

                goalConsoleCommands.Add("cmd visit_all_rooms");
            }

            List<string> unitTest1 = new List<string>()
            {
                "print GAME COMPLETION UNIT TEST",
                "cmd quick_kill"
            };

            unitTest1.AddRange(goalConsoleCommands);

            unitTestCommands = unitTest1.ToArray();
            commandIndex = -1;

            GoToNextUnitTestStep();
            return;

        }


        private static void LoadUnitTest2()
        {
            /*
             * Pasts Key Item Test
                - Generate different APWorld, Paradox mode always on, pasts
                - Spawn all AP Items
                - Quick kill on
                - Teleport to dragun level
                - Teleport to dragun
                - See if bullet works
             */

            unitTestCommands = unitTest2;
            commandIndex = -1;

            GoToNextUnitTestStep();
            return;
        }

        
        private static void LoadUnitTest3()
        {
            /*
             * Floor Clear Test
            - Boss rush
            - Check in boss rush before starting
            - Output if each boss is read by gungeon listener
             */

            unitTestCommands = unitTest3;
            commandIndex = -1;

            GoToNextUnitTestStep();
            return;
        }

        private static void LoadUnitTest4()
        {
            /*
             *### Deathlink RECEIVE Test
        - Connect sudoku
        - Lose 
             */

            unitTestCommands = unitTest4;
            commandIndex = -1;

            GoToNextUnitTestStep();
            return;
        }

        private static void LoadUnitTest5()
        {
            /*
             *  ### Deathlink SEND Test
        - Kill player
        - See if sudoku lost
             */

            unitTestCommands = unitTest5;
            commandIndex = -1;

            GoToNextUnitTestStep();
            return;
        }

        private static void LoadUnitTest6()
        {
            /*
             * ### Password & Weird Name Test
        - Setup password & bad name AP World
        - Send console command for password and name set commands
        - full connect
             */

            unitTestCommands = unitTest6;
            commandIndex = -1;

            GoToNextUnitTestStep();
            return;
        }

        private static void LoadUnitTest7()
        {
            /*
                 *  ### AP Item Receive Stress Test
            - Spawn 5 AP Items
            - Pickup
            - Repeat 5 AP Items 
             */

            unitTestCommands = unitTest7;
            commandIndex = -1;

            GoToNextUnitTestStep();
            return;
        }


    }
}
