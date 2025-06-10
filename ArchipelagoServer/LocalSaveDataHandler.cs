using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BepInEx;
using System.IO;
using ArchiGungeon.DebugTools;
using ArchiGungeon.ModConsoleVisuals;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using ArchiGungeon.Data;

namespace ArchiGungeon.ArchipelagoServer
{

    public class LocalSaveDataHandler
    {
        private static string ArchipelConfigPath { get; } = Paths.ConfigPath;
        private const string PREV_CONNECTION_FILENAME = "LastConnection.json";
        public static PlayerConnectionInfo PreviousConnectionSettings { get; private set; }

        //public static string dataPath = Path.Combine(SaveManager.SavePath, "<path to your custom save data>");

        public static void TDD_PrintAllPathsDirectory()
        {

            ArchDebugPrint.DebugLog(DebugCategory.LocalSaveData, $"============== ProgressDataHandler TDD_PrintAllPathsDirectory ==========");

            ArchDebugPrint.DebugLog(DebugCategory.LocalSaveData, $"Config: {Paths.ConfigPath}");
            ArchDebugPrint.DebugLog(DebugCategory.LocalSaveData, $"SavePath: {SaveManager.SavePath}");

            return;
        }

        public static void SaveArchipelagoConnectionSettings(PlayerConnectionInfo connectionSettingsToSave)
        {
            // want to create TWO separate local save data tasks
            // TODO: write last successful connection settings locally

            ArchDebugPrint.DebugLog(DebugCategory.LocalSaveData, $"============== LocalSaveDataHandler JSON WIP ==========");

            string outputToWrite = JsonConvert.SerializeObject(connectionSettingsToSave);
            File.WriteAllText(Path.Combine(ArchipelConfigPath, PREV_CONNECTION_FILENAME), outputToWrite);

            ArchDebugPrint.DebugLog(DebugCategory.LocalSaveData, $"Connection settings: {outputToWrite} \n\n" +
                $"Written at: {Path.Combine(ArchipelConfigPath, PREV_CONNECTION_FILENAME)}");

            // todo: write a most recent connection
            // todo: TEST ABOVE
            return;
        }

        public static bool CheckPreviousConnectionExists()
        {
            if (File.Exists(Path.Combine(ArchipelConfigPath, PREV_CONNECTION_FILENAME)) == false)
            {
                ArchipelagoGUI.ConsoleLog("ERROR: No data for previous connection could be found!");
                return false;
            }


            PreviousConnectionSettings = JsonConvert.DeserializeObject<PlayerConnectionInfo>(File.ReadAllText(Path.Combine(ArchipelConfigPath,
                PREV_CONNECTION_FILENAME)));

            return true;
        }

        public static void SaveLocalArchipelagoData()
        {
            // TODO: write sava data by slot name + randomizer key as file name
            // todo: serialize count save data

            ArchDebugPrint.DebugLog(DebugCategory.LocalSaveData, $"Connection & player data locally saved at: ");

            // todo: figure format of output
            return;
        }



    }




}
