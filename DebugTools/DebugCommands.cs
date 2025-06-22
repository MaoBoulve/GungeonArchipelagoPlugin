using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArchiGungeon.ArchipelagoServer;
using ArchiGungeon.GungeonEventHandlers;
using ArchiGungeon.ModConsoleVisuals;
using ArchiGungeon.Data;

namespace ArchiGungeon.DebugTools
{
    

    public class DebugCommands
    {
        #region Command Definitions
        //commands MUST have no spacing

        public static Dictionary<string, AvailableDebugCMD> InputToCommand { get; } = new Dictionary<string, AvailableDebugCMD>()
        {
            { "item", AvailableDebugCMD.SpawnAPItem},
            { "sendDeath", AvailableDebugCMD.SendDeathlink },
            {  "receiveDeath", AvailableDebugCMD.ReceiveDeathlink },
            { "chest", AvailableDebugCMD.AddChest },
            {  "room", AvailableDebugCMD.Add1RoomPoint},
            {  "cash", AvailableDebugCMD.Add100CashSpent},
            {  "speedrun", AvailableDebugCMD.Speedrun},
            {  "fullDebug", AvailableDebugCMD.FullDebug },
            {  "noDebug", AvailableDebugCMD.NoDebug },

            {  "floor1", AvailableDebugCMD.LoadFloor1 },
            {  "floor2", AvailableDebugCMD.LoadFloor2 },
            { "floor3" , AvailableDebugCMD.LoadFloor3 },
            { "floor4" , AvailableDebugCMD.LoadFloor4 },
            { "floor5" , AvailableDebugCMD.LoadFloor5 },
            { "hell" , AvailableDebugCMD.LoadHell },
            { "sewers" , AvailableDebugCMD.LoadSewers },
            { "abbey" , AvailableDebugCMD.LoadAbbey },
            { "rat" , AvailableDebugCMD.LoadRat },
            { "dept" , AvailableDebugCMD.LoadDept },

            {  "pastmarine", AvailableDebugCMD.PastMarine },
            { "pastconvict" , AvailableDebugCMD.PastConvict },
            { "pasthunter" , AvailableDebugCMD.PastHunter },
            { "pastpilot" , AvailableDebugCMD.PastPilot },
            { "pastrobot" , AvailableDebugCMD.PastRobot },
            { "pastbullet" , AvailableDebugCMD.PastBullet },
            { "pastgunslinger" , AvailableDebugCMD.PastGunslinger },
            { "pastcoop" , AvailableDebugCMD.PastCoop },

            {"receive", AvailableDebugCMD.ReceiveItem },
        };

        private static Dictionary<AvailableDebugCMD, string> CommandToLevel { get; } = new Dictionary<AvailableDebugCMD, string>()
        {
            { AvailableDebugCMD.LoadFloor1, "keep" },
            { AvailableDebugCMD.LoadFloor2, "proper" },
            { AvailableDebugCMD.LoadFloor3, "mines" },
            { AvailableDebugCMD.LoadFloor4, "hollow" },
            { AvailableDebugCMD.LoadFloor5, "forge" },
            { AvailableDebugCMD.LoadHell, "hell" },
            { AvailableDebugCMD.LoadSewers, "sewers" },
            { AvailableDebugCMD.LoadAbbey, "abbey" },
            { AvailableDebugCMD.LoadRat, "ratlair" },
            { AvailableDebugCMD.LoadDept, "rng_dept" },

            { AvailableDebugCMD.PastMarine, "marinepast" },
            { AvailableDebugCMD.PastConvict, "convictpast" },
            { AvailableDebugCMD.PastHunter, "hunterpast" },
            { AvailableDebugCMD.PastPilot, "pilotpast" },
            { AvailableDebugCMD.PastRobot, "robotpast" },
            { AvailableDebugCMD.PastBullet, "bulletpast" },
            { AvailableDebugCMD.PastGunslinger, "gunslingerpast" },
            { AvailableDebugCMD.PastCoop, "cultistpast" },
        };
        #endregion

        #region Debug Commands
        private static void DebugSpawnAPItem()
        {
            ArchipelagoGungeonBridge.SpawnAPItem(1);
            return;
        }

        private static void DebugSendDeathlink()
        {
            SessionHandler.DataSender.SendDeathlink();
            return;
        }

        private static void DebugReceiveDeathlink()
        {
            string playerCauser = "TESTING";

            string deathlinkCause = $"Deathlink by {playerCauser}";

            ArchipelagoGungeonBridge.DeathlinkKillPlayer(deathlinkCause);

            return;
        }

        private static void DebugChest(int chestNum)
        {
            SaveDataManagement.AddToCountSaveDataEntry(SaveCountStats.ChestsOpened, chestNum);
            return;
        }

        private static void DebugRoomPoint(int pointNum)
        {
            SaveDataManagement.AddToCountSaveDataEntry(SaveCountStats.RoomPoints, pointNum);
            return;
        }

        private static void DebugCash(int cashNum)
        {
            SaveDataManagement.AddToCountSaveDataEntry(SaveCountStats.CashSpent, cashNum);
            return;
        }

        private static void SpeedrunDebug()
        {
            ETGModConsole.Instance?.ParseCommand("quick_kill");
            ETGModConsole.Instance?.ParseCommand("flight");
            GungeonPlayerEventListener.GetFirstAlivePlayer().GiveItem("shotgun_coffee");
            GungeonPlayerEventListener.GetFirstAlivePlayer().GiveItem("shotgun_coffee");
            GungeonPlayerEventListener.GetFirstAlivePlayer().GiveItem("shotgun_coffee");
            GungeonPlayerEventListener.GetFirstAlivePlayer().GiveItem("shotgun_coffee");
            GungeonPlayerEventListener.GetFirstAlivePlayer().GiveItem("shotgun_coffee");
            GungeonPlayerEventListener.GetFirstAlivePlayer().GiveItem("shotgun_coffee");
            GungeonPlayerEventListener.GetFirstAlivePlayer().GiveItem("shotgun_coffee");
            GungeonPlayerEventListener.GetFirstAlivePlayer().GiveItem("shotgun_coffee");
            GungeonPlayerEventListener.GetFirstAlivePlayer().GiveItem("shotgun_coffee");
            GungeonPlayerEventListener.GetFirstAlivePlayer().GiveItem("shotgun_coffee");
            GungeonPlayerEventListener.GetFirstAlivePlayer().GiveItem("shotgun_coffee");
            GungeonPlayerEventListener.GetFirstAlivePlayer().GiveItem("shotgun_coffee");
            GungeonPlayerEventListener.GetFirstAlivePlayer().GiveItem("shotgun_coffee");
            GungeonPlayerEventListener.GetFirstAlivePlayer().GiveItem("shotgun_coffee");

            return;
        }

        private static void SetNewDebugOutputState(bool isActive)
        {
            ArchDebugPrint.SetDebugState(isActive);
            return;
        }

        private static void DebugLoadLevel(AvailableDebugCMD levelToLoad)
        {
            if(CommandToLevel.ContainsKey(levelToLoad))
            {
                string consoleCMD = "load_level " + CommandToLevel[levelToLoad];

                ETGModConsole.Instance?.ParseCommand(consoleCMD);

            }

            return;
        }
        #endregion

        #region Command Handling
        public static void HandleCommand(string inputString, string additionalInput = "")
        {
            if(!InputToCommand.ContainsKey(inputString))
            {
                ArchipelagoGUI.ConsoleLog(inputString + " is not a debug command");
                return;
            }

            AvailableDebugCMD command = InputToCommand[inputString];

            switch (command)
            {
                case AvailableDebugCMD.SpawnAPItem:
                    {
                        DebugSpawnAPItem();
                        return;
                    }
                case AvailableDebugCMD.SendDeathlink:
                    {
                        DebugSendDeathlink();
                        return;
                    }
                case AvailableDebugCMD.ReceiveDeathlink:
                    {
                        DebugReceiveDeathlink();
                        return;
                    }
                case AvailableDebugCMD.AddChest:
                    {
                        if(additionalInput == "")
                        {
                            DebugChest(1);
                        }
                        else
                        {
                            DebugChest(Convert.ToInt32(additionalInput));
                        }
                        return;
                    }
                case AvailableDebugCMD.Add1RoomPoint:
                    {
                        if (additionalInput == "")
                        {
                            DebugRoomPoint(1);
                        }
                        else
                        {
                            DebugRoomPoint(Convert.ToInt32(additionalInput));
                        }
                        return;
                    }
                case AvailableDebugCMD.Add100CashSpent:
                    {

                        if (additionalInput == "")
                        {
                            DebugCash(100);
                        }
                        else
                        {
                            DebugCash(Convert.ToInt32(additionalInput));
                        }
                        return;
                    }
                case AvailableDebugCMD.Speedrun:
                    {
                        SpeedrunDebug();
                        return;
                    }
                case AvailableDebugCMD.FullDebug:
                    {
                        SetNewDebugOutputState(true);
                        return;
                    }

                case AvailableDebugCMD.NoDebug:
                    {
                        SetNewDebugOutputState(false);
                        return;
                    }
                case AvailableDebugCMD.ReceiveItem:
                    {
                        ArchipelagoGungeonBridge.GiveGungeonItem((long)Convert.ToDouble(additionalInput));
                        return;
                    }
                default:
                    {
                        DebugLoadLevel(command);
                        return;
                    }
            }

        }
        #endregion
    }
}
