using System;
using System.IO;
using System.Collections.Generic;
using ArchiGungeon.ModConsoleVisuals;
using ArchiGungeon.Data;
using UnityEngine;
using BepInEx;

namespace ArchiGungeon.DebugTools
{

    #region Console Output

    public class ArchDebugPrint
    {
        
        private static Dictionary<DebugCategory, bool> DebugActiveStates { get; set; } = new Dictionary<DebugCategory, bool>()
        {
            {DebugCategory.PluginStartup, false },
            {DebugCategory.PlayerEventListener, false },
            {DebugCategory.LocalSaveData, true },
            {DebugCategory.ServerReceive, true },
            {DebugCategory.ServerSend, true },
            {DebugCategory.CountingGoal, true },
            {DebugCategory.EnemyRandomization, false },
            {DebugCategory.InitializingGameState, false },
            {DebugCategory.ItemHandling, false },
            {DebugCategory.TrapHandling, false },
            {DebugCategory.UserInterface, false },
            {DebugCategory.GameCompletion, false },
            {DebugCategory.CharacterSystems, false }
        };

        public static void ClearDebugLog()
        {
            DebugFileWriter.CheckForOldestDebugFile();
            DebugFileWriter.ClearLocalOldestFile();
        }

        public static void DebugLog(DebugCategory debugGroup, string textToLog)
        {
            
            
            if(!DebugActiveStates.ContainsKey(debugGroup))
            {
                return;
            }

            bool isActive = DebugActiveStates[debugGroup];

            if(isActive)
            {
                ArchipelagoGUI.ConsoleLog($"Group: {debugGroup} -- " + textToLog);
            }
            else
            {
                DebugFileWriter.AppendToLocalDebugLog($"Group: {debugGroup} -- " + textToLog);
            }

            return;
        }

        internal static void OnCatchException(string condition, string stackTrace, LogType type)
        {
            //LocalDebugLogWriter.AppendToLocalDebugLog("\n\n ============ ERROR CAUGHT: Contact Archipelago mod developer to debug ============= \n\n");
            DebugFileWriter.AppendToLocalDebugLog(condition);
            DebugFileWriter.AppendToLocalDebugLog(stackTrace);

            //LocalDebugLogWriter.StartWritingDebugToLocal();

            return;
        }

        public static void SetDebugState(bool newState)
        {
            Dictionary<DebugCategory, bool> newDict = new Dictionary<DebugCategory, bool>();

            foreach(DebugCategory debugCategory in DebugActiveStates.Keys)
            {
                newDict.Add(debugCategory, newState);
            }

            DebugActiveStates = newDict;

            if(newState)
            {
                DebugFileWriter.StartWritingDebugToLocal();
            }

            return;
        }
        
    }

    #endregion

    #region File Writing
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

            if(isWritingText)
            {
                AppendWriteToFile(newEntry);
            }

            return;
        }

        public static void StartWritingDebugToLocal()
        {
            if(isWritingText)
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
            using(StreamWriter outputFile = new StreamWriter(fileToWrite, true))
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
            File.Delete(oldestFile);
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
                if(File.Exists(DebugFilename[i]) == false)
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
