using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArchiGungeon.ArchipelagoServer;
using ArchiGungeon.GungeonEventHandlers;
using ArchiGungeon.ModConsoleVisuals;

namespace ArchiGungeon.DebugTools
{
    public enum AvailableDebugCMD
    {
        SpawnAPItem,
        SendDeathlink,
        ReceiveDeathlink,
        AddChest,
        Add5Chest,
        Add1RoomPoint,
        Add10RoomPoint,
        Add100RoomPoint,
        Add1000RoomPoint,
        Add100CashSpent,
        Add1000CashSpent,
        Speedrun,
        FullDebug,
        NoDebug,
        LoadFloor1,
        LoadFloor2,
        LoadFloor3,
        LoadFloor4,
        LoadFloor5,
        LoadHell,
        LoadSewers,
        LoadAbbey,
        LoadRat,
        LoadDept,
        PastMarine,
        PastConvict,
        PastHunter,
        PastPilot,
        PastRobot,
        PastBullet,
        PastGunslinger,
        PastCoop
    }

    public class DebugCommands
    {

        //commands MUST have no spacing
        public static Dictionary<AvailableDebugCMD, string> CommandToInputString { get; } = new Dictionary<AvailableDebugCMD, string>()
        {
            { AvailableDebugCMD.SpawnAPItem, "item" },
            { AvailableDebugCMD.SendDeathlink, "sendDeath" },
            { AvailableDebugCMD.ReceiveDeathlink, "receiveDeath" },
            { AvailableDebugCMD.AddChest, "chest" },
            { AvailableDebugCMD.Add5Chest, "chestchest" },
            { AvailableDebugCMD.Add1RoomPoint, "room" },
            { AvailableDebugCMD.Add10RoomPoint, "roomroom" },
            { AvailableDebugCMD.Add100RoomPoint, "roomroomroom" },
            { AvailableDebugCMD.Add1000RoomPoint, "roomroomroomroom" },
            { AvailableDebugCMD.Add100CashSpent, "cash" },
            { AvailableDebugCMD.Add1000CashSpent, "cashcash" },
            { AvailableDebugCMD.Speedrun, "speedrun" },
            { AvailableDebugCMD.FullDebug, "fullDebug" },
            { AvailableDebugCMD.NoDebug, "noDebug" },

            { AvailableDebugCMD.LoadFloor1, "floor1" },
            { AvailableDebugCMD.LoadFloor2, "floor2" },
            { AvailableDebugCMD.LoadFloor3, "floor3" },
            { AvailableDebugCMD.LoadFloor4, "floor4" },
            { AvailableDebugCMD.LoadFloor5, "floor5" },
            { AvailableDebugCMD.LoadHell, "hell" },
            { AvailableDebugCMD.LoadSewers, "sewers" },
            { AvailableDebugCMD.LoadAbbey, "abbey" },
            { AvailableDebugCMD.LoadRat, "rat" },
            { AvailableDebugCMD.LoadDept, "dept" },

            { AvailableDebugCMD.PastMarine, "pastmarine" },
            { AvailableDebugCMD.PastConvict, "pastconvict" },
            { AvailableDebugCMD.PastHunter, "pasthunter" },
            { AvailableDebugCMD.PastPilot, "pastpilot" },
            { AvailableDebugCMD.PastRobot, "pastrobot" },
            { AvailableDebugCMD.PastBullet, "pastbullet" },
            { AvailableDebugCMD.PastGunslinger, "pastgunslinger" },
            { AvailableDebugCMD.PastCoop, "pastcoop" },
        };

        private static Dictionary<string, AvailableDebugCMD> InputToCommand { get; } = new Dictionary<string, AvailableDebugCMD>()
        {
            { "item", AvailableDebugCMD.SpawnAPItem},
            { "sendDeath", AvailableDebugCMD.SendDeathlink },
            {  "receiveDeath", AvailableDebugCMD.ReceiveDeathlink },
            { "chest", AvailableDebugCMD.AddChest },
            {  "chestchest", AvailableDebugCMD.Add5Chest },
            {  "room", AvailableDebugCMD.Add1RoomPoint},
            {  "roomroom", AvailableDebugCMD.Add10RoomPoint},
            {  "roomroomroom", AvailableDebugCMD.Add100RoomPoint},
            {  "roomroomroomroom", AvailableDebugCMD.Add1000RoomPoint},
            {  "cash", AvailableDebugCMD.Add100CashSpent},
            {  "cashcash", AvailableDebugCMD.Add1000CashSpent},
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
            SessionHandler.DataSender.AddToGoalCount(SaveCountStats.ChestsOpened, chestNum);
            return;
        }

        private static void DebugRoomPoint(int pointNum)
        {
            SessionHandler.DataSender.AddToGoalCount(SaveCountStats.RoomPoints, pointNum);
            return;
        }

        private static void DebugCash(int cashNum)
        {
            SessionHandler.DataSender.AddToGoalCount(SaveCountStats.CashSpent, cashNum);
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

        public static void HandleCommand(string inputString)
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
                        DebugChest(1);
                        return;
                    }
                case AvailableDebugCMD.Add5Chest:
                    {
                        DebugChest(5);
                        return;
                    }
                case AvailableDebugCMD.Add1RoomPoint:
                    {
                        DebugRoomPoint(1);
                        return;
                    }
                case AvailableDebugCMD.Add10RoomPoint:
                    {
                        DebugRoomPoint(10);
                        return;
                    }
                case AvailableDebugCMD.Add100RoomPoint:
                    {
                        DebugRoomPoint(100);
                        return;
                    }
                case AvailableDebugCMD.Add1000RoomPoint:
                    {
                        DebugRoomPoint(1000);
                        return;
                    }
                case AvailableDebugCMD.Add100CashSpent:
                    {
                        DebugCash(100);
                        return;
                    }
                case AvailableDebugCMD.Add1000CashSpent:
                    {
                        DebugCash(1000);
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
                default:
                    {
                        DebugLoadLevel(command);
                        return;
                    }
            }

        }
    }
}
