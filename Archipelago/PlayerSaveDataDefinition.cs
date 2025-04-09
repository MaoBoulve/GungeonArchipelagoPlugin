using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace ArchiGungeon.Archipelago
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
        public int[] GoalList;

        public CountStatInfo(int countVal, int goalVal, int[] listVal)
        {
            Count = countVal;
            NextGoal = goalVal;
            GoalList = listVal;
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

        public static Dictionary<SaveCountStats, string> StatToKey { get; } = new Dictionary<SaveCountStats, string>()
        {
            { SaveCountStats.ChestsOpened, "ChestsOpened"},
            { SaveCountStats.RoomPoints, "RoomPoints"},
            { SaveCountStats.CashSpent, "CashSpent"},

            { SaveCountStats.BlobulordKills, "Blobulord"},
            { SaveCountStats.OldKingKills, "OldKing"},
            { SaveCountStats.RatKills, "Rat"},
            { SaveCountStats.DeptAgunimKills, "DeptAgunim"},
            { SaveCountStats.AdvancedDragunKills, "AdvancedDragun"},
            { SaveCountStats.DragunKills, "Dragun"},
            { SaveCountStats.LichKills, "Lich"},

            { SaveCountStats.Floor1Clears, "Floor1"},
            { SaveCountStats.Floor2Clears, "Floor2"},
            { SaveCountStats.Floor3Clears, "Floor3"},
            { SaveCountStats.Floor4Clears, "Floor4"},
            { SaveCountStats.Floor5Clears, "Floor5"},

            { SaveCountStats.FloorHellClears, "FloorHell"},
            { SaveCountStats.FloorGoopClears, "FloorGoop"},
            { SaveCountStats.FloorAbbeyClears, "FloorAbbey"},
            { SaveCountStats.FloorRatClears, "FloorRat"},
            { SaveCountStats.FloorDeptClears, "FloorDept"},
        };

        private static Dictionary<SaveCountStats, CountStatInfo> InitialStatValues { get; } = new Dictionary<SaveCountStats, CountStatInfo>()
        {
            { SaveCountStats.ChestsOpened, new CountStatInfo(0, 1,  new int[]{ 4, 8, 13, 18, 24, 30, 37, 44 }  ) },
            { SaveCountStats.RoomPoints, new CountStatInfo(0, 1,  new int[]{ 2, 6, 24, 120, 720, 5040, 10000, 15000 }  )},
            { SaveCountStats.CashSpent, new CountStatInfo(0, 1,  new int[]{ 50, 100, 150, 200, 250 }  )},

            { SaveCountStats.BlobulordKills, new CountStatInfo(0, 1,  new int[]{1}  )},
            { SaveCountStats.OldKingKills, new CountStatInfo(0, 1,  new int[]{1}  )},
            { SaveCountStats.RatKills, new CountStatInfo(0, 1,  new int[]{1}  )},
            { SaveCountStats.DeptAgunimKills, new CountStatInfo(0, 1,  new int[]{1}  )},
            { SaveCountStats.AdvancedDragunKills, new CountStatInfo(0, 1,  new int[]{1}  )},
            { SaveCountStats.DragunKills, new CountStatInfo(0, 1,  new int[]{1}  )},
            { SaveCountStats.LichKills, new CountStatInfo(0, 1,  new int[]{1}  )},

            { SaveCountStats.Floor1Clears, new CountStatInfo(0, 1,  new int[]{ 1, 2, 3, 4, 5 }  )},
            { SaveCountStats.Floor2Clears, new CountStatInfo(0, 1,  new int[]{ 1, 2, 3, 4 }  )},
            { SaveCountStats.Floor3Clears, new CountStatInfo(0, 1,  new int[]{ 1, 2, 3 }  )},
            { SaveCountStats.Floor4Clears, new CountStatInfo(0, 1,  new int[]{ 1, 2, 3 }  )},
            { SaveCountStats.Floor5Clears, new CountStatInfo(0, 1,  new int[]{1, 2}  )},

            { SaveCountStats.FloorHellClears, new CountStatInfo(0, 1,  new int[]{1}  )},
            { SaveCountStats.FloorGoopClears, new CountStatInfo(0, 1,  new int[]{1, 2 ,3}  )},
            { SaveCountStats.FloorAbbeyClears, new CountStatInfo(0, 1,  new int[]{1}  )},
            { SaveCountStats.FloorRatClears, new CountStatInfo(0, 1,  new int[]{1}  )},
            { SaveCountStats.FloorDeptClears, new CountStatInfo(0, 1,  new int[]{1}  )},
        };

        private static Dictionary<SaveCountStats, CountStatInfo> SaveDataTrackedStats { get; set; } = InitialStatValues;

        private static CountStatInfo nullCountStat = new CountStatInfo(-9999, 9999, new int[] { 9999 });

        private static JObject CreateCountStatAsJObject(int count, int nextGoal, int[] goalList)
        {
            JObject JSONObject = JObject.FromObject(new { CurrentCount = count, NextGoal = nextGoal, GoalList = goalList });

            return JSONObject;
        }

        public static CountStatInfo GetCountStat(SaveCountStats statToGet)
        {
            CountStatInfo statData = SaveDataTrackedStats[statToGet];

            return statData;
        }

        public static JObject GetCountStatAsJObject(SaveCountStats statToGet)
        {
            CountStatInfo statData = SaveDataTrackedStats[statToGet];

            JObject initValJObject = CreateCountStatAsJObject(statData.Count, statData.NextGoal, statData.GoalList);
            return initValJObject;
        }

        private static void SetCountStatInfo(SaveCountStats statToSet, CountStatInfo newValue)
        {
            SaveDataTrackedStats[statToSet] = newValue;
            return;
        }

        public static void SetCountStatInfoFromJObject(SaveCountStats statToSet, JObject newStat)
        {
            CountStatInfo statData = new CountStatInfo(newStat.Value<int>("CurrentCount"), newStat.Value<int>("NextGoal"), newStat.Value<int[]>("GoalList"));

            SetCountStatInfo(statToSet, statData);
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

            int goalEntryIndex = Array.IndexOf(statData.GoalList, statData.NextGoal);

            try
            {
                statData.NextGoal = statData.GoalList[goalEntryIndex + 1];
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
