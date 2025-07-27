using ArchiGungeon.ArchipelagoServer;
using ArchiGungeon.Character;
using ArchiGungeon.Data;
using ArchiGungeon.UserInterface;
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
                case "wait":
                    {
                        return;
                    }
                case "func":
                    {
                        ParseUnitTestFunctionCase(stepCommand[1]);
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

        private static void ParseUnitTestFunctionCase(string functionCase)
        {
            switch (functionCase)
            {
                case "sendDeathlink":
                    {
                        SessionHandler.DataSender.SendDeathlink(causeOfDeath: "Died by Unit Test");
                        return;
                    }
                case "bossOutput":
                    {
                        ArchDebugPrint.SetDebugState(DebugCategory.PlayerEventListener, true);
                        return;
                    }
                case "spawnAP":
                    {
                        ArchipelagoGungeonBridge.SpawnAPItem(5);
                        return;
                    }
                case "identityItems":
                    {
                        CharSwap.ReceiveParadoxModeItem(0);
                        CharSwap.ReceiveParadoxModeItem(1);
                        CharSwap.ReceiveParadoxModeItem(2);
                        CharSwap.ReceiveParadoxModeItem(3);
                        CharSwap.ReceiveParadoxModeItem(4);
                        CharSwap.ReceiveParadoxModeItem(5);
                        return;
                    }
                case "bulletSpawn":
                    {
                        ETGModConsole.SpawnItem(new string[] { "bullet_that_can_kill_the_past", "1" });
                        return;
                    }
            }

            return;
        }

        #region Unit Test 1 - Game Completion
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

                        goalConsoleCommands.Add("print Sewers level loading, repeat 'test next' for teleport");
                        goalConsoleCommands.Add("cmd load_level sewers");
                        goalConsoleCommands.Add("print Enter 'test next' to load NEXT goal level");
                        goalConsoleCommands.Add("cmd visit_all_rooms");

                        goalConsoleCommands.Add("print Abbey level loading");
                        goalConsoleCommands.Add("cmd load_level abbey");
                        goalConsoleCommands.Add("print Enter 'test next' to load NEXT goal level");
                        goalConsoleCommands.Add("cmd visit_all_rooms");
                        break;
                    case PlayerCompletionGoals.Dragun:
                        goalConsoleCommands.Add("print Forge level loading");
                        goalConsoleCommands.Add("cmd load_level forge");
                        goalConsoleCommands.Add("print Enter 'test next' to load NEXT goal level");
                        goalConsoleCommands.Add("cmd visit_all_rooms");
                        break;
                    case PlayerCompletionGoals.Lich:
                        goalConsoleCommands.Add("print Hell level loading");
                        goalConsoleCommands.Add("cmd load_level hell");
                        goalConsoleCommands.Add("print Enter 'test next' to load NEXT goal level");
                        goalConsoleCommands.Add("cmd visit_all_rooms");
                        break;
                    case PlayerCompletionGoals.AdvancedGungeon:

                        goalConsoleCommands.Add("print Forge, level loading, repeat TWICE 'test next' for teleport and weird egg");
                        goalConsoleCommands.Add("cmd load_level forge");
                        goalConsoleCommands.Add("cmd visit_all_rooms");
                        goalConsoleCommands.Add("print Enter 'test next' to load NEXT goal level");
                        goalConsoleCommands.Add("cmd spawn item weird_egg");

                        goalConsoleCommands.Add("print RAT level loading, repeat 'test next' for teleport");
                        goalConsoleCommands.Add("cmd load_level ratlair");
                        goalConsoleCommands.Add("print Enter 'test next' to load NEXT goal level");
                        goalConsoleCommands.Add("cmd visit_all_rooms");
                        break;
                    case PlayerCompletionGoals.FarewellArms:
                        goalConsoleCommands.Add("print RNG Dept loading, repeat 'test next' for teleport");
                        goalConsoleCommands.Add("cmd load_level rng_dept");
                        goalConsoleCommands.Add("print Enter 'test next' to load NEXT goal level");
                        goalConsoleCommands.Add("cmd visit_all_rooms");
                        break;
                    case PlayerCompletionGoals.PastsBase:
                        goalConsoleCommands.Add("print =========== CAUTION. Pasts are VERY glitchy if you start them with quick_kill on. Next test_next will DISABLE IT");
                        goalConsoleCommands.Add("wait --");
                        goalConsoleCommands.Add("cmd quick_kill");
                        goalConsoleCommands.Add("print Marine Past loading");
                        goalConsoleCommands.Add("cmd load_level marinepast");
                        goalConsoleCommands.Add("cmd quick_kill");
                        goalConsoleCommands.Add("print Enter 'test next' to load NEXT goal level");
                        goalConsoleCommands.Add("cmd quick_kill");

                        goalConsoleCommands.Add("print Convict Past loading");
                        goalConsoleCommands.Add("cmd load_level convictpast");
                        goalConsoleCommands.Add("cmd quick_kill");
                        goalConsoleCommands.Add("print Enter 'test next' to load NEXT goal level");
                        goalConsoleCommands.Add("cmd quick_kill");

                        goalConsoleCommands.Add("print Hunter Past loading");
                        goalConsoleCommands.Add("cmd load_level hunterpast");
                        goalConsoleCommands.Add("cmd quick_kill");
                        goalConsoleCommands.Add("print Enter 'test next' to load NEXT goal level");
                        goalConsoleCommands.Add("cmd quick_kill");

                        goalConsoleCommands.Add("print Pilot Past loading");
                        goalConsoleCommands.Add("cmd load_level pilotpast");
                        goalConsoleCommands.Add("cmd quick_kill");
                        goalConsoleCommands.Add("print Enter 'test next' to load NEXT goal level");
                        goalConsoleCommands.Add("cmd quick_kill");
                        break;
                    case PlayerCompletionGoals.PastsFull:
                        goalConsoleCommands.Add("print =========== CAUTION. Pasts are VERY glitchy if you start them with quick_kill on. Next test_next will DISABLE IT");
                        goalConsoleCommands.Add("wait --");
                        goalConsoleCommands.Add("cmd quick_kill");
                        goalConsoleCommands.Add("print Marine Past loading");
                        goalConsoleCommands.Add("cmd load_level marinepast");
                        goalConsoleCommands.Add("cmd quick_kill");
                        goalConsoleCommands.Add("print Enter 'test next' to load NEXT goal level");
                        goalConsoleCommands.Add("cmd quick_kill");

                        goalConsoleCommands.Add("print Convict Past loading");
                        goalConsoleCommands.Add("cmd load_level convictpast");
                        goalConsoleCommands.Add("cmd quick_kill");
                        goalConsoleCommands.Add("print Enter 'test next' to load NEXT goal level");
                        goalConsoleCommands.Add("cmd quick_kill");

                        goalConsoleCommands.Add("print Hunter Past loading");
                        goalConsoleCommands.Add("cmd load_level hunterpast");
                        goalConsoleCommands.Add("cmd quick_kill");
                        goalConsoleCommands.Add("print Enter 'test next' to load NEXT goal level");
                        goalConsoleCommands.Add("cmd quick_kill");

                        goalConsoleCommands.Add("print Pilot Past loading");
                        goalConsoleCommands.Add("cmd load_level pilotpast");
                        goalConsoleCommands.Add("cmd quick_kill");
                        goalConsoleCommands.Add("print Enter 'test next' to load NEXT goal level");
                        goalConsoleCommands.Add("cmd quick_kill");

                        goalConsoleCommands.Add("print Robot Past loading");
                        goalConsoleCommands.Add("cmd load_level robotpast");
                        goalConsoleCommands.Add("cmd quick_kill");
                        goalConsoleCommands.Add("print Enter 'test next' to load NEXT goal level");
                        goalConsoleCommands.Add("cmd quick_kill");

                        goalConsoleCommands.Add("print Bullet Past loading");
                        goalConsoleCommands.Add("cmd load_level bulletpast");
                        goalConsoleCommands.Add("cmd character bullet");
                        goalConsoleCommands.Add("print Enter 'test next' to load NEXT goal level");
                        goalConsoleCommands.Add("cmd quick_kill");
                        break;
                }
            }

            goalConsoleCommands.Add("print ------------------- END OF UNIT TEST ------------------------");

            List<string> unitTest1 = new List<string>()
            {
                "print GAME COMPLETION UNIT TEST",
                "print Requires connection to Archipelago, otherwise nothing happens",
                "print Enter 'test next' x2 to initialize quick_kill",
                "cmd quick_kill",
                "cmd godmode",
                "print Enter 'test next' to load NEXT goal level",
                "wait --"
            };

            unitTest1.AddRange(goalConsoleCommands);

            unitTestCommands = unitTest1.ToArray();
            commandIndex = -1;

            GoToNextUnitTestStep();
            return;

        }

        #endregion

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

            List<string> unitTest2 = new List<string>()
            {
                "print BULLET TO PAST ITEM TEST",
                "print Enter 'test next' to initialize Paradox Mode",
                "wait ---",

                "print Enter 'test next' to spawn bullet to past",
                "cmd character paradox",

                "print Enter 'test next' to spawn identity items",
                "func bulletSpawn",

                "print Enter 'test next' x3 to 1] Load Forge, 2] Visit All Floor 3] Quick_Kill",
                "func identityItems",

                "cmd load_level forge",
                "cmd visit_all_rooms",
                "print ------------ END OF UNIT TEST ----------------",
                "cmd quick_kill"

            };

            unitTestCommands = unitTest2.ToArray();
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

            List<string> unitTest3 = new List<string>()
            {
                "print BOSS OUTPUT UNIT TEST",
                "print Test requires going to Boss Rush",
                "print Enter 'test next' to enable quick_kill",
                "wait --",
                "print Enter 'test next' to force output to true for boss kills",
                "cmd quick_kill",
                "------------ END OF UNIT TEST -------------",
                "func bossOutput",

            };

            unitTestCommands = unitTest3.ToArray();
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

            List<string> unitTest4 = new List<string>()
            {
                "print DEATHLINK RECEIVE UNIT TEST",
                "print Connect another client to the server (ie. AP Sudoku)",
                "print Enter 'test next' to enable Deathlink",
                "wait --",
                "print Send Deathlink from other client and see if Gungeon player dies",
                "print ----------------- END OF UNIT TEST ------------------",
                "cmd deathlink 1"
            };

            unitTestCommands = unitTest4.ToArray();
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

            List<string> unitTest5 = new List<string>()
            {
                "print DEATHLINK SEND UNIT TEST",
                "print Connect another client to server to test Deathlink",
                "print Send 'test next' to send a Deathlink event",
                "wait ---",
                "print Check if deathlink sent",
                "print ---------- END OF UNIT TEST ---------------",
                "func sendDeathlink"

            };
            unitTestCommands = unitTest5.ToArray();
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

            List<string> unitTest6 = new List<string>()
            {
                "print PASSWORD & NAME ARCHIPEL CONNECT UNIT TEST",
                "print Create APWorld with slot name 'Gun Gie 2Test' and password 'testPass' ",
                "print Send 'test next' to set Slot Name for fullconnect",
                "wait ---",
                
                "print Send 'test next' to set Password for fullconnect",
                "cmd set name Gun Gie 2Test",

                "print Send 'test next' to fullconnect",
                "cmd set password testPass",

                "print Try connection with IP Address and port",
                "print ---------- END OF UNIT TEST --------------",
                "wait --"

            };

            unitTestCommands = unitTest6.ToArray();
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

            List<string> unitTest7 = new List<string>()
            {
                "print AP ITEM MULTI SEND UNIT TEST",
                "print Send 'test next' to spawn 5 AP Items",
                "wait ---",

                "print Send 'test next' to spawn another 5 AP Items",
                "func spawnAP",

                "print -------------- END OF UNIT TEST ----------------",
                "func spawnAP", 
            };

            unitTestCommands = unitTest7.ToArray();
            commandIndex = -1;

            GoToNextUnitTestStep();
            return;
        }


    }
}
