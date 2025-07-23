using System;
using System.IO;
using System.Collections.Generic;
using ArchiGungeon.UserInterface;
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

        public static void InitDebugLog()
        {
            DebugFileWriter.CheckForOldestDebugFile();
            DebugFileWriter.ClearLocalOldestFile();
            DebugFileWriter.StartWritingDebugToLocal();
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

        public static void SetDebugState(DebugCategory debugGroup, bool newState)
        {
            DebugActiveStates[debugGroup] = newState;
            return;
        }
        
    }

    #endregion

}
