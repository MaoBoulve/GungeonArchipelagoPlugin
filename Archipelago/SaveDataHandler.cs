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


    public class CountMilestones()
    {
        private static int currentOpenedChestGoal = 1;
        private static int[] openedChestMilestones = { 4, 8, 13, 18, 24, 30, 37, 44 };

        private static int currentRoomPointsGoal = 1;
        private static int[] clearedRoomPointMilestones = { 2, 6, 24, 120, 720, 5040, 10000, 15000 };

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


        public int OpenedChestGoal { get { return currentOpenedChestGoal; } set { currentOpenedChestGoal = value; }}
        public int[] ChestMilestones{ get { return openedChestMilestones; }set { openedChestMilestones = value; }}

        public int RoomPointsGoal { get { return currentRoomPointsGoal; } set { currentRoomPointsGoal = value; } }
        public int[] RoomPointsMilestones{get { return clearedRoomPointMilestones; }set { clearedRoomPointMilestones = value; }}

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
