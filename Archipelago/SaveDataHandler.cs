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



}
