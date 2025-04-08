using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace ArchiGungeon.Archipelago
{
    public enum SaveStats
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

    public struct StatInfo
    {
        public int Count;
        public int NextGoal;
        public int[] GoalList;

        public StatInfo(int countVal, int goalVal, int[] listVal)
        {
            Count = countVal;
            NextGoal = goalVal;
            GoalList = listVal;
        }
    }

    public class SaveStatsInfo
    {
        public static Dictionary<CompletionGoals, SaveStats> GoalToSaveStat = new Dictionary<CompletionGoals, SaveStats>()
        {
            { CompletionGoals.Blobulord, SaveStats.BlobulordKills },
            { CompletionGoals.OldKing, SaveStats.OldKingKills},
            { CompletionGoals.Rat, SaveStats.RatKills},
            { CompletionGoals.Agunim, SaveStats.DeptAgunimKills},
            { CompletionGoals.AdvancedDragun, SaveStats.AdvancedDragunKills},
            { CompletionGoals.Dragun, SaveStats.DragunKills},
            { CompletionGoals.Lich, SaveStats.LichKills },
        };

        public static Dictionary<SaveStats, string> StatToKey { get; } = new Dictionary<SaveStats, string>()
        {
            { SaveStats.ChestsOpened, "ChestsOpened"},
            { SaveStats.RoomPoints, "RoomPoints"},
            { SaveStats.CashSpent, "CashSpent"},

            { SaveStats.BlobulordKills, "Blobulord"},
            { SaveStats.OldKingKills, "OldKing"},
            { SaveStats.RatKills, "Rat"},
            { SaveStats.DeptAgunimKills, "DeptAgunim"},
            { SaveStats.AdvancedDragunKills, "AdvancedDragun"},
            { SaveStats.DragunKills, "Dragun"},
            { SaveStats.LichKills, "Lich"},

            { SaveStats.Floor1Clears, "Floor1"},
            { SaveStats.Floor2Clears, "Floor2"},
            { SaveStats.Floor3Clears, "Floor3"},
            { SaveStats.Floor4Clears, "Floor4"},
            { SaveStats.Floor5Clears, "Floor5"},

            { SaveStats.FloorHellClears, "FloorHell"},
            { SaveStats.FloorGoopClears, "FloorGoop"},
            { SaveStats.FloorAbbeyClears, "FloorAbbey"},
            { SaveStats.FloorRatClears, "FloorRat"},
            { SaveStats.FloorDeptClears, "FloorDept"},
        };

        private static Dictionary<SaveStats, StatInfo> StatInitValue { get; } = new Dictionary<SaveStats, StatInfo>()
        {
            { SaveStats.ChestsOpened, new StatInfo(0, 1,  new int[]{ 4, 8, 13, 18, 24, 30, 37, 44 }  ) },
            { SaveStats.RoomPoints, new StatInfo(0, 1,  new int[]{ 2, 6, 24, 120, 720, 5040, 10000, 15000 }  )},
            { SaveStats.CashSpent, new StatInfo(0, 1,  new int[]{ 50, 100, 150, 200, 250 }  )},

            { SaveStats.BlobulordKills, new StatInfo(0, 1,  new int[]{1}  )},
            { SaveStats.OldKingKills, new StatInfo(0, 1,  new int[]{1}  )},
            { SaveStats.RatKills, new StatInfo(0, 1,  new int[]{1}  )},
            { SaveStats.DeptAgunimKills, new StatInfo(0, 1,  new int[]{1}  )},
            { SaveStats.AdvancedDragunKills, new StatInfo(0, 1,  new int[]{1}  )},
            { SaveStats.DragunKills, new StatInfo(0, 1,  new int[]{1}  )},
            { SaveStats.LichKills, new StatInfo(0, 1,  new int[]{1}  )},

            { SaveStats.Floor1Clears, new StatInfo(0, 1,  new int[]{ 1, 2, 3, 4, 5 }  )},
            { SaveStats.Floor2Clears, new StatInfo(0, 1,  new int[]{ 1, 2, 3, 4 }  )},
            { SaveStats.Floor3Clears, new StatInfo(0, 1,  new int[]{ 1, 2, 3 }  )},
            { SaveStats.Floor4Clears, new StatInfo(0, 1,  new int[]{ 1, 2, 3 }  )},
            { SaveStats.Floor5Clears, new StatInfo(0, 1,  new int[]{1, 2}  )},

            { SaveStats.FloorHellClears, new StatInfo(0, 1,  new int[]{1}  )},
            { SaveStats.FloorGoopClears, new StatInfo(0, 1,  new int[]{1, 2 ,3}  )},
            { SaveStats.FloorAbbeyClears, new StatInfo(0, 1,  new int[]{1}  )},
            { SaveStats.FloorRatClears, new StatInfo(0, 1,  new int[]{1}  )},
            { SaveStats.FloorDeptClears, new StatInfo(0, 1,  new int[]{1}  )},
        };

        public static JObject CreateSaveJObj(int count, int nextGoal, int[] goalList)
        {
            JObject JSONObject = JObject.FromObject(new { CurrentCount = count, NextGoal = nextGoal, GoalList = goalList });

            return JSONObject;
        }

        public static JObject GetStatInitValueJObject(SaveStats statToGet)
        {
            StatInfo statData = StatInitValue[statToGet];

            JObject initValJObject = CreateSaveJObj(statData.Count, statData.NextGoal, statData.GoalList);
            return initValJObject;
        }
    }
}
