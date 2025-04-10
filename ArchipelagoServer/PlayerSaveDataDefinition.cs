using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using ArchiGungeon.ModConsoleVisuals;

namespace ArchiGungeon.ArchipelagoServer
{
    public struct PlayerConnectionInfo
    {
        public string IP;
        public string Port;
        public string PlayerName;

        public PlayerConnectionInfo(string IPstring, string portString, string playerNameString)
        {
            IP = IPstring;
            Port = portString;
            PlayerName = playerNameString;

            return;
        }
    }

    public enum SaveCountStats
    {
        // public readonly int location_check_initial_ID = 8755000;
        ChestsOpened,
        RoomPoints,
        CashSpent,

        BlobulordKills,
        OldKingKills,
        RatKills,
        DeptAgunimKills,
        AdvancedDragunKills,
        DragunKills,
        LichKills,

        Floor1Clears,
        Floor2Clears,
        Floor3Clears,
        Floor4Clears,
        Floor5Clears,
        FloorHellClears,
        FloorGoopClears,
        FloorAbbeyClears,
        FloorRatClears,
        FloorDeptClears
    }


    public struct CountStatInfo
    {
        public int Count;
        public int NextGoal;

        public CountStatInfo(int countVal, int goalVal)
        {
            Count = countVal;
            NextGoal = goalVal;
        }
    }

    public class CountSaveData
    {
        public static Dictionary<CompletionGoals, SaveCountStats> GoalToSaveStat = new Dictionary<CompletionGoals, SaveCountStats>()
        {
            { CompletionGoals.Blobulord, SaveCountStats.BlobulordKills },
            { CompletionGoals.OldKing, SaveCountStats.OldKingKills},
            { CompletionGoals.Rat, SaveCountStats.RatKills},
            { CompletionGoals.Agunim, SaveCountStats.DeptAgunimKills},
            { CompletionGoals.AdvancedDragun, SaveCountStats.AdvancedDragunKills},
            { CompletionGoals.Dragun, SaveCountStats.DragunKills},
            { CompletionGoals.Lich, SaveCountStats.LichKills },
        };


        public static Dictionary<SaveCountStats, CountGoalServerKeys> CountStatToKeys { get; } = new Dictionary<SaveCountStats, CountGoalServerKeys>()
        {
            { SaveCountStats.ChestsOpened, new CountGoalServerKeys("ChestsOpened")},
            { SaveCountStats.RoomPoints, new CountGoalServerKeys("RoomPoints")},
            { SaveCountStats.CashSpent, new CountGoalServerKeys("CashSpent")},

            { SaveCountStats.BlobulordKills, new CountGoalServerKeys("Blobulord")},
            { SaveCountStats.OldKingKills, new CountGoalServerKeys("OldKing")},
            { SaveCountStats.RatKills, new CountGoalServerKeys("Rat")},
            { SaveCountStats.DeptAgunimKills, new CountGoalServerKeys("DeptAgunim")},
            { SaveCountStats.AdvancedDragunKills, new CountGoalServerKeys("AdvancedDragun")},
            { SaveCountStats.DragunKills, new CountGoalServerKeys("Dragun")},
            { SaveCountStats.LichKills, new CountGoalServerKeys("Lich")},

            { SaveCountStats.Floor1Clears, new CountGoalServerKeys("Floor1")},
            { SaveCountStats.Floor2Clears, new CountGoalServerKeys("Floor2")},
            { SaveCountStats.Floor3Clears, new CountGoalServerKeys("Floor3")},
            { SaveCountStats.Floor4Clears, new CountGoalServerKeys("Floor4")},
            { SaveCountStats.Floor5Clears, new CountGoalServerKeys("Floor5")},

            { SaveCountStats.FloorHellClears, new CountGoalServerKeys("FloorHell")},
            { SaveCountStats.FloorGoopClears, new CountGoalServerKeys("FloorGoop")},
            { SaveCountStats.FloorAbbeyClears, new CountGoalServerKeys("FloorAbbey")},
            { SaveCountStats.FloorRatClears, new CountGoalServerKeys("FloorRat")},
            { SaveCountStats.FloorDeptClears, new CountGoalServerKeys("FloorDept")},

        };

        private static Dictionary<SaveCountStats, CountStatInfo> InitialStatValues { get; } = new Dictionary<SaveCountStats, CountStatInfo>()
        {
            { SaveCountStats.ChestsOpened, new CountStatInfo(0, 4) },
            { SaveCountStats.RoomPoints, new CountStatInfo(0, 6)},
            { SaveCountStats.CashSpent, new CountStatInfo(0, 50)},

            { SaveCountStats.BlobulordKills, new CountStatInfo(0, 1)},
            { SaveCountStats.OldKingKills, new CountStatInfo(0, 1)},
            { SaveCountStats.RatKills, new CountStatInfo(0, 1)},
            { SaveCountStats.DeptAgunimKills, new CountStatInfo(0, 1)},
            { SaveCountStats.AdvancedDragunKills, new CountStatInfo(0, 1)},
            { SaveCountStats.DragunKills, new CountStatInfo(0, 1)},
            { SaveCountStats.LichKills, new CountStatInfo(0, 1)},

            { SaveCountStats.Floor1Clears, new CountStatInfo(0, 1)},
            { SaveCountStats.Floor2Clears, new CountStatInfo(0, 1)},
            { SaveCountStats.Floor3Clears, new CountStatInfo(0, 1)},
            { SaveCountStats.Floor4Clears, new CountStatInfo(0, 1)},
            { SaveCountStats.Floor5Clears, new CountStatInfo(0, 1)},

            { SaveCountStats.FloorHellClears, new CountStatInfo(0, 1)},
            { SaveCountStats.FloorGoopClears, new CountStatInfo(0, 1)},
            { SaveCountStats.FloorAbbeyClears, new CountStatInfo(0, 1)},
            { SaveCountStats.FloorRatClears, new CountStatInfo(0, 1)},
            { SaveCountStats.FloorDeptClears, new CountStatInfo(0, 1)},
        };

        //TO DO: set from server settings
        private static Dictionary<SaveCountStats, int[]> GoalList { get; } = new Dictionary<SaveCountStats, int[]>()
        {
            { SaveCountStats.ChestsOpened, new int[]{ 4, 8, 13, 18, 24, 30, 37, 44 }   },
            { SaveCountStats.RoomPoints, new int[]{ 6, 24, 120, 720, 5040, 10000, 15000, 20000 }  },
            { SaveCountStats.CashSpent, new int[]{ 50, 100, 150, 200, 250 }  },

            { SaveCountStats.BlobulordKills, new int[]{1}  },
            { SaveCountStats.OldKingKills, new int[]{1}  },
            { SaveCountStats.RatKills, new int[]{1}  },
            { SaveCountStats.DeptAgunimKills, new int[]{1}  },
            { SaveCountStats.AdvancedDragunKills, new int[]{1}  },
            { SaveCountStats.DragunKills, new int[]{1}  },
            { SaveCountStats.LichKills, new int[]{1}  },

            { SaveCountStats.Floor1Clears, new int[]{ 1, 2, 3, 4, 5 } },
            { SaveCountStats.Floor2Clears, new int[]{ 1, 2, 3, 4 }  },
            { SaveCountStats.Floor3Clears, new int[]{ 1, 2, 3 }  },
            { SaveCountStats.Floor4Clears, new int[]{ 1, 2, 3 }  },
            { SaveCountStats.Floor5Clears, new int[]{1, 2}  },

            { SaveCountStats.FloorHellClears, new int[]{1}  },
            { SaveCountStats.FloorGoopClears, new int[]{1, 2 ,3}  },
            { SaveCountStats.FloorAbbeyClears,   new int[]{1}  },
            { SaveCountStats.FloorRatClears, new int[]{1}  },
            { SaveCountStats.FloorDeptClears, new int[]{1}  },
        };

        private static Dictionary<SaveCountStats, CountStatInfo> SaveDataTrackedStats { get; set; } = InitialStatValues;

        private static CountStatInfo nullCountStat = new CountStatInfo(-9999, 9999);


        public static CountStatInfo GetCountStat(SaveCountStats statToGet)
        {
            CountStatInfo statData = SaveDataTrackedStats[statToGet];

            return statData;
        }

        public static void SetCountStat(SaveCountStats statToSet, int count, int nextGoal)
        {
            CountStatInfo newStatInfo = new CountStatInfo(count, nextGoal);

            SetCountStatInfo(statToSet, newStatInfo);
        }

        public static void SetCountStat(SaveCountStats statToSet, int count)
        {
            CountStatInfo newStatInfo = new CountStatInfo(count, GetCountStat(statToSet).NextGoal);
            SetCountStatInfo(statToSet, newStatInfo);
        }

        private static void SetCountStatInfo(SaveCountStats statToSet, CountStatInfo newValue)
        {
            SaveDataTrackedStats[statToSet] = newValue;
            return;
        }


        public static bool AddToCount(SaveCountStats statToModify, int addAmount)
        {
            if(IsCountStatNull(statToModify))
            {
                return false;
            }

            bool goalMet = false;

            CountStatInfo statData = SaveDataTrackedStats[statToModify];
            statData.Count += addAmount;

            ArchipelagoGUI.ConsoleLog($"[{statToModify}] New count: {statData.Count} against goal: {statData.NextGoal}");
            if(statData.Count >= statData.NextGoal) 
            { 
                goalMet = true; 
            }

            SetCountStatInfo(statToModify, statData);

            return goalMet;
        }

        public static bool SetGoalToNextEntry(SaveCountStats statToModify)
        {
            if(IsCountStatNull(statToModify))
            {
                return true;
            }

            bool outOfGoals = false;

            CountStatInfo statData = SaveDataTrackedStats[statToModify];
            int[] goalList = GoalList[statToModify];

            int goalEntryIndex = Array.IndexOf(goalList, statData.NextGoal);

            try
            {
                statData.NextGoal = goalList[goalEntryIndex + 1];
                SetCountStatInfo(statToModify, statData);
            }
            catch
            {
                SetCountStatInfo(statToModify, nullCountStat);
                ArchipelagoGUI.ConsoleLog(statToModify + " goals all complete!");

                outOfGoals = true;
            }

            return outOfGoals;
        }

        private static bool IsCountStatNull(SaveCountStats statToCheck)
        {
            CountStatInfo statData = SaveDataTrackedStats[statToCheck];

            if(statData.Count == -9999) { return true; }

            else {  return false; }
        }

    }
}
