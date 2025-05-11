using System;
using System.IO;
using System.Collections.Generic;
using ArchiGungeon.ModConsoleVisuals;
using UnityEngine;
using BepInEx;

namespace ArchiGungeon.DebugTools
{
    public enum DebugCategory
    {
        PluginStartup,
        PlayerEventListener,
        LocalSaveData,
        ServerReceive,
        ServerSend,
        CountingGoal,
        EnemyRandomization,
        InitializingGameState,
        ItemHandling,
        TrapHandling,
        UserInterface,
        GameCompletion,
        CharacterSystems
    }

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
            LocalDebugLogWriter.ClearLocalFile();
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
                LocalDebugLogWriter.AppendToLocalDebugLog($"Group: {debugGroup} -- " + textToLog);
            }

            return;
        }

        internal static void OnCatchException(string condition, string stackTrace, LogType type)
        {
            //LocalDebugLogWriter.AppendToLocalDebugLog("\n\n ============ ERROR CAUGHT: Contact Archipelago mod developer to debug ============= \n\n");
            LocalDebugLogWriter.AppendToLocalDebugLog(condition);
            LocalDebugLogWriter.AppendToLocalDebugLog(stackTrace);

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
                LocalDebugLogWriter.StartWritingDebugToLocal();
            }

            return;
        }
        
    }

    public class LocalDebugLogWriter
    {
        public static string DocPath { get; } = Paths.ConfigPath;
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
            ArchipelagoGUI.ConsoleLog($"===** Debug text log at {Paths.ConfigPath} as 'ArchiGungeonDebug.txt' **=== \n\n");
            WriteCurrentLogToFile();

            return;
        }

        private static void WriteCurrentLogToFile()
        {
            using(StreamWriter outputFile = new StreamWriter(Path.Combine(DocPath, "ArchiGungeonDebug.txt"), true))
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
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(DocPath, "ArchiGungeonDebug.txt"), true))
            {
                outputFile.WriteLine(newText);
            }

            return;
        }

        public static void ClearLocalFile()
        {
            File.WriteAllText(@Path.Combine(DocPath, "ArchiGungeonDebug.txt"), "");
        }
    }
}
