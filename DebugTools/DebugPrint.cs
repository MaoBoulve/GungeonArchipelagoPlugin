using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArchiGungeon.ModConsoleVisuals;

namespace ArchiGungeon.DebugTools
{
    public enum DebugCategory
    {
        PlayerEventListener,
        LocalFileSaveData,
        ServerReceive,
        ServerSend,
        CountingGoal,
        EnemyRandomization,
        InitializingGameState,
        ItemHandling,
        TrapHandling
    }

    public class DebugPrint
    {
        private static Dictionary<DebugCategory, bool> DebugActiveStates { get; } = new Dictionary<DebugCategory, bool>()
        {
            {DebugCategory.PlayerEventListener, false },
            {DebugCategory.LocalFileSaveData, false },
            {DebugCategory.ServerReceive, true },
            {DebugCategory.ServerSend, true },
            {DebugCategory.CountingGoal, true },
            {DebugCategory.EnemyRandomization, false },
            {DebugCategory.InitializingGameState, false },
            {DebugCategory.ItemHandling, true },
            {DebugCategory.TrapHandling, true },
        };

        public static void DebugLog(DebugCategory debugGroup, string textToLog)
        {
            
            if(!DebugActiveStates.ContainsKey(debugGroup))
            {
                return;
            }

            bool isActive = DebugActiveStates[debugGroup];

            if(isActive)
            {
                ArchipelagoGUI.ConsoleLog(textToLog);
            }

            return;
        }

        public static void SetDebugState(bool newState)
        {
            foreach(DebugCategory debugCategory in DebugActiveStates.Keys)
            {
                DebugActiveStates[debugCategory] = newState;
            }

            return;
        }
        
    }
}
