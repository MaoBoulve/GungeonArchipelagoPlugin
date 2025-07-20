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

namespace ArchiGungeon.Data
{

    #region Save Data 
    public class SaveDataWriter
    {   
        // using randomizer key as save data key
        private static string ConfigPath { get; } = Paths.ConfigPath;
        private const string SAVE_DATA_FILEPREFIX = "SAVE_";
        private static bool isSavePathInitialized = false;
        private static string SaveFilepath { get; set; }

        public static bool InitSaveFilenameAndCheckPrevious(string playerName, string seedString)
        {
            string fileName = SAVE_DATA_FILEPREFIX + playerName + seedString.Substring(0,8) + ".json";
            SaveFilepath = Path.Combine(ConfigPath, fileName);

            isSavePathInitialized = true;

            return File.Exists(SaveFilepath);
        }

        public static void WriteSaveFile(Dictionary<SaveCountStats, int> countSaveData)
        {
            if(!isSavePathInitialized)
            {
                return;
            }
            string outputToWrite = JsonConvert.SerializeObject(countSaveData);
            File.WriteAllText(SaveFilepath, outputToWrite);

            ArchipelagoGUI.ConsoleLog($"Save data updated: {SaveFilepath}");

            return;
        }
        
        public static Dictionary<SaveCountStats, int> RetrieveSaveData(string playerName ="", string seedString="")
        {
            if(playerName != "" && seedString != "")
            {
                string fileName = SAVE_DATA_FILEPREFIX + playerName + seedString.Substring(0, 8) +".json";
                SaveFilepath = Path.Combine(ConfigPath, fileName);
            }

            if (File.Exists(SaveFilepath))
            {
                string localData = File.ReadAllText(SaveFilepath);
                Dictionary<SaveCountStats, int> saveData = JsonConvert.DeserializeObject<Dictionary<SaveCountStats, int>>(localData);

                return saveData;
            }
            else
            {
                ArchipelagoGUI.ConsoleLog($"ERROR filepath does not exist:{SaveFilepath}");
                return null;
            }
        }

    }

    #endregion

    #region Connection Data
    public class ConnectionDataWriter
    {
        private static string ArchipelConfigPath { get; } = Paths.ConfigPath;
        private const string SAVED_CONNECTION_FILENAME = "LastConnection.json";
        public static PlayerConnectionInfo SavedConnectionSettings { get; private set; }

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
            // data task for connection
            // data task for save data

            ArchDebugPrint.DebugLog(DebugCategory.LocalSaveData, $"============== LocalSaveDataHandler JSON WIP ==========");

            string outputToWrite = JsonConvert.SerializeObject(connectionSettingsToSave);
            File.WriteAllText(Path.Combine(ArchipelConfigPath, SAVED_CONNECTION_FILENAME), outputToWrite);

            ArchDebugPrint.DebugLog(DebugCategory.LocalSaveData, $"Connection settings: {outputToWrite} \n\n" +
                $"Written at: {Path.Combine(ArchipelConfigPath, SAVED_CONNECTION_FILENAME)}");


            return;
        }

        public static bool CheckPreviousConnectionExists()
        {
            if (File.Exists(Path.Combine(ArchipelConfigPath, SAVED_CONNECTION_FILENAME)) == false)
            {
                
                return false;
            }


            SavedConnectionSettings = JsonConvert.DeserializeObject<PlayerConnectionInfo>(File.ReadAllText(Path.Combine(ArchipelConfigPath,
                SAVED_CONNECTION_FILENAME)));

            return true;
        }

    }

    #endregion

    #region Debug Writing
    public class DebugFileWriter
    {
        private static string DocPath { get; } = Paths.ConfigPath;
        private static string[] DebugFilename { get; } =
        [
            Path.Combine(DocPath, "ArchiGungeonDebug_A.txt"),
            Path.Combine(DocPath, "ArchiGungeonDebug_B.txt"),
            Path.Combine(DocPath, "ArchiGungeonDebug_C.txt"),
            Path.Combine(DocPath, "ArchiGungeonDebug_D.txt")
        ];

        private static string oldestFile = "N/A";
        private static string fileToWrite;

        private static bool isWritingText = false;
        private static List<string> TextLog { get; } = new List<string>();

        public static void AppendToLocalDebugLog(string newEntry)
        {
            TextLog.Add(newEntry);

            if (isWritingText)
            {
                AppendWriteToFile(newEntry);
            }

            return;
        }

        public static void StartWritingDebugToLocal()
        {
            if (isWritingText)
            {
                return;
            }

            isWritingText = true;
            ArchipelagoGUI.ConsoleLog($"===** Debug text log at {fileToWrite} **=== \n\n");
            WriteCurrentLogToFile();

            return;
        }

        private static void WriteCurrentLogToFile()
        {
            using (StreamWriter outputFile = new StreamWriter(fileToWrite, true))
            {
                foreach (string debugEntry in TextLog)
                {
                    outputFile.WriteLine(debugEntry);
                }
            }

            return;
        }

        private static void AppendWriteToFile(string newText)
        {
            using (StreamWriter outputFile = new StreamWriter(fileToWrite, true))
            {
                outputFile.WriteLine(newText);
            }

            return;
        }

        public static void ClearLocalOldestFile()
        {
            if(oldestFile != "N/A")
            {
                File.Delete(oldestFile);
            }
            
            return;
        }

        public static void CheckForOldestDebugFile()
        {

            int filenameCount = DebugFilename.Length;

            if (File.Exists(DebugFilename[filenameCount - 1]) == true)
            {
                // last entry exists

                for (int i = 0; i <= (filenameCount - 2); i++)
                {
                    if (File.Exists(DebugFilename[i]) == false)
                    {
                        // C doesn't exist, D is oldest
                        fileToWrite = DebugFilename[i];
                        oldestFile = DebugFilename[i + 1];
                        return;
                    }
                }
            }


            for (int i = 0; i <= (filenameCount - 2); i++)
            {
                if (File.Exists(DebugFilename[i]) == false)
                {
                    fileToWrite = DebugFilename[i];
                    return;
                }
            }

            // if still in function, first (length - 1) entries exist

            oldestFile = DebugFilename[0];
            fileToWrite = DebugFilename[filenameCount - 1];
            return;

        }
    }

    #endregion
}
