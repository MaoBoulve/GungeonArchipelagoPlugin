using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BepInEx;
using System.IO;
using ArchiGungeon.DebugTools;

namespace ArchiGungeon.ArchipelagoServer
{

    public class LocalSaveDataHandler
    {


        //public static string dataPath = Path.Combine(SaveManager.SavePath, "<path to your custom save data>");

        public static void TDD_PrintAllPathsDirectory()
        {

            ArchDebugPrint.DebugLog(DebugCategory.LocalSaveData, $"============== ProgressDataHandler TDD_PrintAllPathsDirectory ==========");

            ArchDebugPrint.DebugLog(DebugCategory.LocalSaveData, $"Config: {Paths.ConfigPath}");
            ArchDebugPrint.DebugLog(DebugCategory.LocalSaveData, $"SavePath: {SaveManager.SavePath}");

            return;
        }

        public static List<string> RetrievePreviousGameSettings()
        {

            return new List<string>();
        }

        public static void SaveArchipelagoConnectionSettings(string ip, string port, string playerName)
        {
            ArchDebugPrint.DebugLog(DebugCategory.LocalSaveData, $"============== LocalSaveDataHandler JSON WIP ==========");

            PlayerConnectionInfo connectionSettings = new(ip, port, playerName);

            /*
            JObject JSONoutput = new(
                new JProperty("IP", connectionSettings.IP),
                new JProperty("Port", connectionSettings.Port),
                new JProperty("Name", connectionSettings.PlayerName)
                );
            */

            //ArchDebugPrint.DebugLog(DebugCategory.LocalFileSaveData, $"{JSONoutput}");

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

        public static void LoadLocalConnectionSettings()
        {
            // TKTK READ JSON

            //string JSONoutput = "TEST TKTKTK";

            //PlayerConnectionInfo connectionSettings = JsonConvert.DeserializeObject<PlayerConnectionInfo>(JSONoutput);


            return;
        }

    }




}
