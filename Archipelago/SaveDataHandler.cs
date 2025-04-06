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
        };

        public Dictionary<string, int> SaveData
        {
            get { return saveData; }
        }

        public int IsSaveDataInitialize
        {
            get { return saveData["Init"]; }
            set { saveData["Init"] = value; }
        }

        public int ChestsOpened
        {
            get { return saveData["ChestsOpened"]; }
            set { saveData["ChestsOpened"] = value; }
        }

        public int RoomPoints
        {
            get { return saveData["RoomPoints"]; }
            set { saveData["RoomPoints"] = value; }
        }

        public int ItemsRetrievedThisRun
        {
            get { return saveData["ItemsRetrievedThisRun"]; }
            set { saveData["ItemsRetrievedThisRun"] = value; }
        }

    }


    public class CountMilestones()
    {
        private static int currentOpenedChestGoal = 1;
        private static int[] openedChestMilestones = { 4, 8, 13, 18, 24, 30, 37, 44 };
        private static int currentRoomPointsGoal = 1;
        private static int[] clearedRoomPointMilestones = { 2, 6, 24, 120, 720, 5040, 10000, 15000 };

        public int OpenedChestGoal { get { return currentOpenedChestGoal; } set { currentOpenedChestGoal = value; } }
        public int RoomPointsGoal { get { return currentRoomPointsGoal; } set { currentRoomPointsGoal = value; } }

        public int[] ChestMilestones
        {
            get { return openedChestMilestones; }
            set { openedChestMilestones = value; }
        }

        public int[] RoomPointsMilestones
        {
            get { return clearedRoomPointMilestones; }
            set { clearedRoomPointMilestones = value; }
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
