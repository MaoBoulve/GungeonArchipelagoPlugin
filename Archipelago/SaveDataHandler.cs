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
    public class RandomizerSaveData
    {
        public RandomizerSaveData()
        {
        }

        public static Dictionary<string, object> player_slot_settings = new Dictionary<string, object>();

        private static Dictionary<string, int> saveData = new Dictionary<string, int>()
        {
            { "Init", 0 },
            { "ItemsRetrievedThisRun", 0 },
            { "ChestsOpened", 0 },
            { "RoomPoints", 0 },
            { "CashSpent", 0 },

            { "Floor1Clears", 0 },
            { "Floor2Clears", 0 },
            { "Floor3Clears", 0 },
            { "Floor4Clears", 0 },
            { "Floor5Clears", 0 },
            { "Floor6Clears", 0 },

            { "FloorGoopClears", 0 },
            { "FloorAbbeyClears", 0 },
            { "FloorRatClears", 0 },
            { "FloorDeptClears", 0 },
        };

        public Dictionary<string, int> SaveData{get { return saveData; }}

        public int IsSaveDataInitialize{get { return saveData["Init"]; } set { saveData["Init"] = value; } }

        public int ChestsOpened{get { return saveData["ChestsOpened"]; }set { saveData["ChestsOpened"] = value; }}

        public int RoomPoints { get { return saveData["RoomPoints"]; }set { saveData["RoomPoints"] = value; }}

        public int ItemsRetrievedThisRun{ get { return saveData["ItemsRetrievedThisRun"]; } set { saveData["ItemsRetrievedThisRun"] = value; }}

        public int Floor1Clears { get { return saveData["Floor1Clears"]; } set { saveData["Floor1Clears"] = value; } }
        public int Floor2Clears { get { return saveData["Floor2Clears"]; } set { saveData["Floor2Clears"] = value; } }
        public int Floor3Clears { get { return saveData["Floor3Clears"]; } set { saveData["Floor3Clears"] = value; } }
        public int Floor4Clears { get { return saveData["Floor4Clears"]; } set { saveData["Floor4Clears"] = value; } }
        public int Floor5Clears { get { return saveData["Floor5Clears"]; } set { saveData["Floor5Clears"] = value; } }
        public int Floor6Clears { get { return saveData["Floor6Clears"]; } set { saveData["Floor6Clears"] = value; } }

        public int FloorGoopClears { get { return saveData["FloorGoopClears"]; } set { saveData["FloorGoopClears"] = value; } }
        public int FloorAbbeyClears { get { return saveData["FloorAbbeyClears"]; } set { saveData["FloorAbbeyClears"] = value; } }
        public int FloorRatClears { get { return saveData["FloorRatClears"]; } set { saveData["FloorRatClears"] = value; } }
        public int FloorDeptClears { get { return saveData["FloorDeptClears"]; } set { saveData["FloorDeptClears"] = value; } }

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

    public class CountMilestones()
    {
        private static Dictionary<MilestoneGoals, Object> enumToGoal = new Dictionary<MilestoneGoals, Object>()
        {
            {MilestoneGoals.ChestsOpened, openedChestGoal},
            {MilestoneGoals.RoomPoints, roomPointsGoal},
            {MilestoneGoals.CashSpent, cashSpentGoal},
            {MilestoneGoals.Floor1Clears, floor1clearsGoal},
            {MilestoneGoals.Floor2Clears, floor2clearsGoal},
            {MilestoneGoals.Floor3Clears, floor3clearsGoal},
            {MilestoneGoals.Floor4Clears, floor4clearsGoal},
            {MilestoneGoals.Floor5Clears, floor5clearsGoal},
            {MilestoneGoals.Floor6Clears, floor6clearsGoal},
            {MilestoneGoals.FloorGoopClears, floorGoopClearsGoal},
            {MilestoneGoals.FloorAbbeyClears, floorAbbeyClearsGoal},
            {MilestoneGoals.FloorRatClears, floorRatClearGoal},
            {MilestoneGoals.FloorDeptClears, floorDeptClearGoal},
        };

        private static Dictionary<MilestoneGoals, Object> enumToMilestone = new Dictionary<MilestoneGoals, Object>()
        {
            {MilestoneGoals.ChestsOpened, openedChestMilestones},
            {MilestoneGoals.RoomPoints, roomPointMilestones},
            {MilestoneGoals.CashSpent, cashSpentMilestones},
            {MilestoneGoals.Floor1Clears, floor1Milestones},
            {MilestoneGoals.Floor2Clears, floor2Milestones},
            {MilestoneGoals.Floor3Clears, floor3Milestones},
            {MilestoneGoals.Floor4Clears, floor4Milestones},
            {MilestoneGoals.Floor5Clears, floor5Milestones},
            {MilestoneGoals.Floor6Clears, floor6Milestones},
            {MilestoneGoals.FloorGoopClears, floorGoopMilestones},
            {MilestoneGoals.FloorAbbeyClears, floorAbbeyMilestones},
            {MilestoneGoals.FloorRatClears, floorRatMilestones},
            {MilestoneGoals.FloorDeptClears, floorDeptClearMilestones},
        };

        private static int openedChestGoal = 1;
        private static int[] openedChestMilestones = { 4, 8, 13, 18, 24, 30, 37, 44 };

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


        public int OpenedChestGoal { get { return openedChestGoal; } set { openedChestGoal = value; }}
        public int[] ChestMilestones{ get { return openedChestMilestones; }set { openedChestMilestones = value; }}

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

            var goalToCompare = enumToGoal[goalEnumToCheck];

            if((int)goalToCompare == -9999)
            {
                return false;
            }

            isMilestoneGoalComplete = (valueToCompare >= (int)goalToCompare);

            return isMilestoneGoalComplete;
        }

        public void UpdateMilestoneGoalToNext(MilestoneGoals goalToChangeEnum)
        {
            var goalToEdit = enumToGoal[goalToChangeEnum];
            var goalMilestoneArray = enumToMilestone[goalToChangeEnum];

            if(goalMilestoneArray == null || goalToEdit == null) { return; }

            int currentGoalIndex = Array.IndexOf((int[])goalMilestoneArray, (int)goalToEdit);

            if (currentGoalIndex > (((int[])goalMilestoneArray).Length - 1))
            {
                SetMilestoneGoalWithEnumSwitch(goalToChangeEnum, -9999);
                return;
            }

            int newValue = ((int[])goalMilestoneArray)[currentGoalIndex + 1];

            SetMilestoneGoalWithEnumSwitch(goalToChangeEnum, newValue);
            return;

        }

        public void SetMilestoneGoalWithEnumSwitch(MilestoneGoals goalToChangeEnum, int newValue)
        {
            switch (goalToChangeEnum)
            {
                case MilestoneGoals.ChestsOpened:
                    openedChestGoal = newValue;
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
                    [
                        "A moist",
                        "A cubic",
                        "A mushy",
                        "An orb-like",
                        "A smelly",
                        "A mysterious"
                    ];
    }


}
