using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using BepInEx;
using Newtonsoft.Json.Linq;
using System.IO;

namespace ArchiGungeon.Archipelago
{
    public enum SaveDataTrackedStats
    {
        ChestsOpened,
        RoomPoints,
        CashSpent,
        Floor1Clears,
        Floor2Clears,
        Floor3Clears,
        Floor4Clears,
        Floor5Clears,
        Floor6Clears,
        FloorGoopClears,
        FloorAbbeyClears,
        FloorRatClears,
        FloorDeptClears
    }

    public class RandomizerSaveData
    {
        public RandomizerSaveData()
        {
        }

        public static Dictionary<string, string> GoalKeyToSaveKey { get; } = new Dictionary<string, string>()
        {
            { "Blobulord Goal", "Blobulord Killed"},
            { "Old King Goal", "Old King Killed"},
            { "Resourceful Rat Goal", "Resourceful Rat Killed"},
            { "Agunim Goal", "Agunim Killed"},
            { "Advanced Dragun Goal", "Advanced Dragun Killed"},
        };

        

        private static Dictionary<string, int> saveData = new Dictionary<string, int>()
        {

            { "ChestsOpened", -99 },
            { "RoomPoints", -99 },
            { "CashSpent", -99 },

            /*
            { "Floor1Clears", -99 },
            { "Floor2Clears", -99 },
            { "Floor3Clears", -99 },
            { "Floor4Clears", -99 },
            { "Floor5Clears", -99 },
            { "Floor6Clears", -99 },

            { "FloorGoopClears", -99 },
            { "FloorAbbeyClears", -99 },
            { "FloorRatClears", -99 },
            { "FloorDeptClears", -99 },
            */
        };


        public static int ChestsOpened{get { return saveData["ChestsOpened"]; }set { saveData["ChestsOpened"] = value; }}
        public static int RoomPoints { get { return saveData["RoomPoints"]; }set { saveData["RoomPoints"] = value; }}
        public static int CashSpent { get { return saveData["CashSpent"]; } set { saveData["CashSpent"] = value; }}
        

        public static int Floor1Clears { get { return saveData["Floor1Clears"]; } set { saveData["Floor1Clears"] = value; } }
        public static int Floor2Clears { get { return saveData["Floor2Clears"]; } set { saveData["Floor2Clears"] = value; } }
        public static int Floor3Clears { get { return saveData["Floor3Clears"]; } set { saveData["Floor3Clears"] = value; } }
        public static int Floor4Clears { get { return saveData["Floor4Clears"]; } set { saveData["Floor4Clears"] = value; } }
        public static int Floor5Clears { get { return saveData["Floor5Clears"]; } set { saveData["Floor5Clears"] = value; } }
        public static int Floor6Clears { get { return saveData["Floor6Clears"]; } set { saveData["Floor6Clears"] = value; } }

        public static int FloorGoopClears { get { return saveData["FloorGoopClears"]; } set { saveData["FloorGoopClears"] = value; } }
        public static int FloorAbbeyClears { get { return saveData["FloorAbbeyClears"]; } set { saveData["FloorAbbeyClears"] = value; } }
        public static int FloorRatClears { get { return saveData["FloorRatClears"]; } set { saveData["FloorRatClears"] = value; } }
        public static int FloorDeptClears { get { return saveData["FloorDeptClears"]; } set { saveData["FloorDeptClears"] = value; } }

        public static Dictionary<string, object> ServerKeyToSaveProperty { get; } = new Dictionary<string, object>
        {
            {"ChestsOpened", ChestsOpened},
            {"RoomPoints", RoomPoints }
        };

        public static Dictionary<SaveDataTrackedStats, string> StatEnumToServerKey { get; } = new Dictionary<SaveDataTrackedStats, string>
        {
            { SaveDataTrackedStats.ChestsOpened, "ChestsOpened"},
            { SaveDataTrackedStats.RoomPoints, "RoomPoints" },
            { SaveDataTrackedStats.CashSpent, "CashSpent" }
        };

        public static void SetTrackedStatByEnumSwitch(SaveDataTrackedStats statToSet, int newValue)
        {
            ArchipelagoGUI.ConsoleLog($"Setting stat: {statToSet} to value: {newValue}");

            switch (statToSet)
            {
                case SaveDataTrackedStats.ChestsOpened:
                    ChestsOpened = newValue;
                    break;
                case SaveDataTrackedStats.RoomPoints:
                    RoomPoints = newValue;
                    break;
                case SaveDataTrackedStats.CashSpent:
                    CashSpent = newValue;
                    break;
                case SaveDataTrackedStats.Floor1Clears:
                    Floor1Clears = newValue;
                    break;
                case SaveDataTrackedStats.Floor2Clears:
                    Floor2Clears = newValue;
                    break;
                case SaveDataTrackedStats.Floor3Clears:
                    Floor3Clears = newValue;
                    break;
                case SaveDataTrackedStats.Floor4Clears:
                    Floor4Clears = newValue;
                    break;
                case SaveDataTrackedStats.Floor5Clears:
                    Floor5Clears = newValue;
                    break;
                case SaveDataTrackedStats.Floor6Clears:
                    Floor6Clears = newValue;
                    break;
                case SaveDataTrackedStats.FloorGoopClears:
                    FloorGoopClears = newValue;
                    break;
                case SaveDataTrackedStats.FloorAbbeyClears:
                    FloorAbbeyClears = newValue;
                    break;
                case SaveDataTrackedStats.FloorRatClears:
                    FloorRatClears = newValue;
                    break;
                case SaveDataTrackedStats.FloorDeptClears:
                    FloorDeptClears = newValue;
                    break;
                default:
                    break;
            }

            return;
        }

    }

    public enum MilestoneGoals
    {
        ChestsOpened,
        RoomPoints,
        CashSpent,
        Floor1Clears,
        Floor2Clears,
        Floor3Clears,
        Floor4Clears,
        Floor5Clears,
        Floor6Clears,
        FloorGoopClears,
        FloorAbbeyClears,
        FloorRatClears,
        FloorDeptClears
    }

    public class CountMilestones
    {
        public static int GetGoalByEnum(MilestoneGoals goalToGet)
        {
            switch (goalToGet)
            {
                case MilestoneGoals.ChestsOpened:
                    return chestsOpenedGoal;
                case MilestoneGoals.RoomPoints:
                    return roomPointsGoal;
                case MilestoneGoals.CashSpent:
                    return cashSpentGoal;
                case MilestoneGoals.Floor1Clears:
                    return floor1clearsGoal;
                case MilestoneGoals.Floor2Clears:
                    return floor2clearsGoal;
                case MilestoneGoals.Floor3Clears:
                    return floor3clearsGoal;
                case MilestoneGoals.Floor4Clears:
                    return floor4clearsGoal;
                case MilestoneGoals.Floor5Clears:
                    return floor5clearsGoal;
                case MilestoneGoals.Floor6Clears:
                    return floor6clearsGoal;
                case MilestoneGoals.FloorGoopClears:
                    return floorGoopClearsGoal;
                case MilestoneGoals.FloorAbbeyClears:
                    return floorAbbeyClearsGoal;
                case MilestoneGoals.FloorRatClears:
                    return floorRatClearGoal;
                case MilestoneGoals.FloorDeptClears:
                    return floorDeptClearGoal;
                default:
                    return -9999;
            }
        }

        public static int[] GetMilestoneListByEnum(MilestoneGoals goalToGet)
        {
            switch (goalToGet)
            {
                case MilestoneGoals.ChestsOpened:
                    return chestsOpenedMilestones;
                case MilestoneGoals.RoomPoints:
                    return roomPointMilestones;
                case MilestoneGoals.CashSpent:
                    return cashSpentMilestones;
                case MilestoneGoals.Floor1Clears:
                    return floor1Milestones;
                case MilestoneGoals.Floor2Clears:
                    return floor2Milestones;
                case MilestoneGoals.Floor3Clears:
                    return floor3Milestones;
                case MilestoneGoals.Floor4Clears:
                    return floor4Milestones;
                case MilestoneGoals.Floor5Clears:
                    return floor5Milestones;
                case MilestoneGoals.Floor6Clears:
                    return floor6Milestones;
                case MilestoneGoals.FloorGoopClears:
                    return floorGoopMilestones;
                case MilestoneGoals.FloorAbbeyClears:
                    return floorAbbeyMilestones;
                case MilestoneGoals.FloorRatClears:
                    return floorRatMilestones;
                case MilestoneGoals.FloorDeptClears:
                    return floorDeptClearMilestones;
                default:
                    return new int[]{ -9999, -9999};
            }
        }


        public void SetNextGoalWithEnumSwitch(MilestoneGoals goalToChangeEnum, int newValue)
        {
            ArchipelagoGUI.ConsoleLog($"Setting stat: {goalToChangeEnum} to value: {newValue}");

            switch (goalToChangeEnum)
            {
                case MilestoneGoals.ChestsOpened:
                    chestsOpenedGoal = newValue;
                    break;
                case MilestoneGoals.RoomPoints:
                    roomPointsGoal = newValue;
                    break;
                case MilestoneGoals.CashSpent:
                    cashSpentGoal = newValue;
                    break;
                case MilestoneGoals.Floor1Clears:
                    floor1clearsGoal = newValue;
                    break;
                case MilestoneGoals.Floor2Clears:
                    floor2clearsGoal = newValue;
                    break;
                case MilestoneGoals.Floor3Clears:
                    floor3clearsGoal = newValue;
                    break;
                case MilestoneGoals.Floor4Clears:
                    floor4clearsGoal = newValue;
                    break;
                case MilestoneGoals.Floor5Clears:
                    floor5clearsGoal = newValue;
                    break;
                case MilestoneGoals.Floor6Clears:
                    floor6clearsGoal = newValue;
                    break;
                case MilestoneGoals.FloorGoopClears:
                    floorGoopClearsGoal = newValue;
                    break;
                case MilestoneGoals.FloorAbbeyClears:
                    floorAbbeyClearsGoal = newValue;
                    break;
                case MilestoneGoals.FloorRatClears:
                    floorRatClearGoal = newValue;
                    break;
                case MilestoneGoals.FloorDeptClears:
                    floorDeptClearGoal = newValue;
                    break;
                default:
                    break;
            }

            return;
        }


        public static Dictionary<MilestoneGoals, string[]> GoalEnumToServerKey { get; } = new Dictionary<MilestoneGoals, string[]>()
        {
            { MilestoneGoals.ChestsOpened, new string[]{"NextGoalChestsOpened", "ChestsOpenedMilestones" } },
            { MilestoneGoals.RoomPoints, new string[]{"NextGoalRoomPoints", "RoomPointsMilestones" } }
        };

        private static int chestsOpenedGoal = 1;
        private static int[] chestsOpenedMilestones = { 4, 8, 13, 18, 24, 30, 37, 44 };

        private static int roomPointsGoal = 1;
        private static int[] roomPointMilestones = { 2, 6, 24, 120, 720, 5040, 10000, 15000 };

        private static int cashSpentGoal = 1;
        private static int[] cashSpentMilestones = { 50, 100, 150, 200, 250 };

        private static int floor1clearsGoal = 1;
        private static int[] floor1Milestones = { 1, 2, 3, 4, 5 };
        private static int floor2clearsGoal = 1;
        private static int[] floor2Milestones = { 1, 2, 3, 4 };
        private static int floor3clearsGoal = 1;
        private static int[] floor3Milestones = { 1, 2, 3 };
        private static int floor4clearsGoal = 1;
        private static int[] floor4Milestones = { 1, 2, 3, 4 };
        private static int floor5clearsGoal = 1;
        private static int[] floor5Milestones = { 1, 2, 3 };
        private static int floor6clearsGoal = 1;
        private static int[] floor6Milestones = { 1 };

        private static int floorGoopClearsGoal = 1;
        private static int[] floorGoopMilestones = { 1, 2, 3 };
        private static int floorAbbeyClearsGoal = 1;
        private static int[] floorAbbeyMilestones = { 1 };
        private static int floorRatClearGoal = 1;
        private static int[] floorRatMilestones = { 1 };
        private static int floorDeptClearGoal = 1;
        private static int[] floorDeptClearMilestones = { 1 };


        public int ChestsOpenedGoal { get { return chestsOpenedGoal; } set { chestsOpenedGoal = value; }}
        public int[] ChestMilestones{ get { return chestsOpenedMilestones; }set { chestsOpenedMilestones = value; }}

        public int RoomPointsGoal { get { return roomPointsGoal; } set { roomPointsGoal = value; } }
        public int[] RoomPointsMilestones{get { return roomPointMilestones; }set { roomPointMilestones = value; }}

        public int CashSpentGoal { get { return cashSpentGoal; } set { cashSpentGoal = value; } }
        public int[] CashSpentMilestones { get { return cashSpentMilestones; } set { cashSpentMilestones = value; } }

        public int Floor1ClearGoal { get { return floor1clearsGoal;} set { floor1clearsGoal = value;}}
        public int Floor2ClearGoal { get { return floor2clearsGoal;} set { floor2clearsGoal = value; }}
        public int Floor3ClearGoal { get { return floor3clearsGoal; } set { floor3clearsGoal = value; } }
        public int Floor4ClearGoal { get { return floor4clearsGoal; } set { floor4clearsGoal = value; } }
        public int Floor5ClearGoal { get { return floor5clearsGoal; } set { floor5clearsGoal = value; } }
        public int Floor6ClearGoal { get { return floor6clearsGoal; } set { floor6clearsGoal = value; } }
        public int FloorGoopClearGoal { get { return floorGoopClearsGoal; } set { floorGoopClearsGoal = value; } }
        public int FloorAbbeyClearGoal { get { return floorAbbeyClearsGoal; } set { floorAbbeyClearsGoal = value; } }
        public int FloorRatClearGoal { get { return floorRatClearGoal; } set { floorRatClearGoal = value; } }
        public int FloorDeptClearGoal { get { return floorDeptClearGoal; } set { floorDeptClearGoal = value; } }

        public int[] Floor1Milestones { get { return floor1Milestones; } set { floor1Milestones = value; } }
        public int[] Floor2Milestones { get { return floor2Milestones; } set { floor2Milestones = value; } }
        public int[] Floor3Milestones { get { return floor3Milestones; } set { floor3Milestones = value; } }
        public int[] Floor4Milestones { get { return floor4Milestones; } set { floor4Milestones = value; } }
        public int[] Floor5Milestones { get { return floor5Milestones; } set { floor5Milestones = value; } }
        public int[] Floor6Milestones { get { return floor6Milestones; } set { floor6Milestones = value; } }
        public int[] FloorGoopMilestones { get { return floorGoopMilestones; } set { floorGoopMilestones = value; } }
        public int[] FloorAbbeyMilestones { get { return floorAbbeyMilestones; } set { floorAbbeyMilestones = value; } }
        public int[] FloorRatMilestones { get { return floorRatMilestones; } set { floorRatMilestones = value; } }
        public int[] FloorDeptMilestones { get { return floorDeptClearMilestones; } set { floorDeptClearMilestones = value; } }

        public bool GetIsGoalMet(MilestoneGoals goalEnumToCheck, int valueToCompare)
        {
            bool isMilestoneGoalComplete;

            int goalToCompare = GetGoalByEnum(goalEnumToCheck);

            if(goalToCompare == -9999)
            {
                return false;
            }

            isMilestoneGoalComplete = (valueToCompare >= (int)goalToCompare);

            return isMilestoneGoalComplete;
        }

        public void UpdateMilestoneGoalToNext(MilestoneGoals goalToChangeEnum)
        {
            var goalToEdit = GetGoalByEnum(goalToChangeEnum);
            var goalMilestoneArray = GetMilestoneListByEnum(goalToChangeEnum);

            if(goalMilestoneArray == null || goalToEdit == -9999) { return; }

            int currentGoalIndex = Array.IndexOf((int[])goalMilestoneArray, (int)goalToEdit);

            if (currentGoalIndex > (((int[])goalMilestoneArray).Length - 1))
            {
                SetNextGoalWithEnumSwitch(goalToChangeEnum, -9999);
                return;
            }

            int newValue = ((int[])goalMilestoneArray)[currentGoalIndex + 1];

            SetNextGoalWithEnumSwitch(goalToChangeEnum, newValue);
            return;

        }

    }

    public class SaveDataHandler
    {


        //public static string dataPath = Path.Combine(SaveManager.SavePath, "<path to your custom save data>");

        public static void TDD_PrintAllPathsDirectory()
        {

            //ArchipelagoGUI.ConsoleLog($"============== ProgressDataHandler TDD_PrintAllPathsDirectory ==========");

            //ArchipelagoGUI.ConsoleLog($"Config: {Paths.ConfigPath}");
            //ArchipelagoGUI.ConsoleLog($"SavePath: {SaveManager.SavePath}");

            return;
        }

        public static List<string> RetrievePreviousGameSettings()
        {

            return new List<string>();
        }

        public static void SaveArchipelagoConnectionSettings(string ip, string port, string playerName)
        {
            ArchipelagoGUI.ConsoleLog($"============== ProgressDataHandler JSON WIP DOESN'T WORK YET ==========");

            ConnectionSettings.IP = ip;
            ConnectionSettings.Port = port;
            ConnectionSettings.PlayerName = playerName;


            JObject JSONoutput = new(
                new JProperty("IP", ConnectionSettings.IP),
                new JProperty("Port", ConnectionSettings.Port),
                new JProperty("Name", ConnectionSettings.PlayerName)
                );

            ArchipelagoGUI.ConsoleLog($"{JSONoutput}");

            /*
            File.WriteAllText(@"c:\videogames.json", JSONoutput.ToString());

            // write JSON directly to a file
            using (StreamWriter file = File.CreateText(@"c:\videogames.json"))
            using (JsonTextWriter writer = new JsonTextWriter(file))
            {
                JSONoutput.WriteTo(writer);
            }

            */

            return;
        }

        public static ConnectionSettings LoadLocalConnectionSettings()
        {
            // TKTK READ JSON

            string JSONoutput = "TEST TKTKTK";

            ConnectionSettings connectionSettingsInstance = JsonConvert.DeserializeObject<ConnectionSettings>(JSONoutput);


            return connectionSettingsInstance;
        }

    }

    public class ConnectionSettings
    {
        public static string IP;
        public static string Port;
        public static string PlayerName;
    }

    public class APItemData
    {
        public static string[] itemFunnyPrefix =
                    {
                        "A moist",
                        "A cubic",
                        "A mushy",
                        "An orb-like",
                        "A smelly",
                        "A mysterious"
                    };
    }


}
