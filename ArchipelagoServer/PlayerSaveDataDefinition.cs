using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

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
            { SaveCountStats.ChestsOpened, new CountGoalServerKeys("RoomPoints")},
            { SaveCountStats.ChestsOpened, new CountGoalServerKeys("CashSpent")},

            { SaveCountStats.ChestsOpened, new CountGoalServerKeys("Blobulord")},
            { SaveCountStats.ChestsOpened, new CountGoalServerKeys("OldKing")},
            { SaveCountStats.ChestsOpened, new CountGoalServerKeys("Rat")},
            { SaveCountStats.ChestsOpened, new CountGoalServerKeys("DeptAgunim")},
            { SaveCountStats.ChestsOpened, new CountGoalServerKeys("AdvancedDragun")},
            { SaveCountStats.ChestsOpened, new CountGoalServerKeys("Dragun")},
            { SaveCountStats.ChestsOpened, new CountGoalServerKeys("Lich")},

            { SaveCountStats.ChestsOpened, new CountGoalServerKeys("Floor1")},
            { SaveCountStats.ChestsOpened, new CountGoalServerKeys("Floor2")},
            { SaveCountStats.ChestsOpened, new CountGoalServerKeys("Floor3")},
            { SaveCountStats.ChestsOpened, new CountGoalServerKeys("Floor4")},
            { SaveCountStats.ChestsOpened, new CountGoalServerKeys("Floor5")},

            { SaveCountStats.ChestsOpened, new CountGoalServerKeys("FloorHell")},
            { SaveCountStats.ChestsOpened, new CountGoalServerKeys("FloorGoop")},
            { SaveCountStats.ChestsOpened, new CountGoalServerKeys("FloorAbbey")},
            { SaveCountStats.ChestsOpened, new CountGoalServerKeys("FloorRat")},
            { SaveCountStats.ChestsOpened, new CountGoalServerKeys("FloorDept")},

        };

        private static Dictionary<SaveCountStats, CountStatInfo> InitialStatValues { get; } = new Dictionary<SaveCountStats, CountStatInfo>()
        {
            { SaveCountStats.ChestsOpened, new CountStatInfo(0, 1) },
            { SaveCountStats.RoomPoints, new CountStatInfo(0, 1)},
            { SaveCountStats.CashSpent, new CountStatInfo(0, 1)},

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
            { SaveCountStats.RoomPoints, new int[]{ 2, 6, 24, 120, 720, 5040, 10000, 15000 }  },
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

            if(statData.Count >= statData.NextGoal) { goalMet = true; }

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
