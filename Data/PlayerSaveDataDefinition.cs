using ArchiGungeon.Data;
using ArchiGungeon.DebugTools;
using ArchiGungeon.ItemArchipelago;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static DungeonTileStampData;

namespace ArchiGungeon.Data
{

    public class CountGoalManager
    {
        #region APWorld Data

        public static Dictionary<CountStats, CountGoalServerKeys> CountStatToKeys { get; } = new Dictionary<CountStats, CountGoalServerKeys>()
        {
            { CountStats.ChestsOpened, new CountGoalServerKeys("ChestsOpened")},
            { CountStats.RoomPoints, new CountGoalServerKeys("RoomPoints")},
            { CountStats.CashSpent, new CountGoalServerKeys("CashSpent")},

            { CountStats.BlobulordKills, new CountGoalServerKeys("Blobulord")},
            { CountStats.OldKingKills, new CountGoalServerKeys("OldKing")},
            { CountStats.RatKills, new CountGoalServerKeys("Rat")},
            { CountStats.DeptAgunimKills, new CountGoalServerKeys("DeptAgunim")},
            { CountStats.AdvancedDragunKills, new CountGoalServerKeys("AdvancedDragun")},
            { CountStats.DragunKills, new CountGoalServerKeys("Dragun")},
            { CountStats.LichKills, new CountGoalServerKeys("Lich")},

            { CountStats.Floor1Clears, new CountGoalServerKeys("Floor1")},
            { CountStats.Floor2Clears, new CountGoalServerKeys("Floor2")},
            { CountStats.Floor3Clears, new CountGoalServerKeys("Floor3")},
            { CountStats.Floor4Clears, new CountGoalServerKeys("Floor4")},
            { CountStats.Floor5Clears, new CountGoalServerKeys("Floor5")},

            { CountStats.FloorHellClears, new CountGoalServerKeys("FloorHell")},
            { CountStats.FloorGoopClears, new CountGoalServerKeys("FloorGoop")},
            { CountStats.FloorAbbeyClears, new CountGoalServerKeys("FloorAbbey")},
            { CountStats.FloorRatClears, new CountGoalServerKeys("FloorRat")},
            { CountStats.FloorDeptClears, new CountGoalServerKeys("FloorDept")},

            { CountStats.PastBullet, new CountGoalServerKeys("PastBullet")},
            { CountStats.PastConvict, new CountGoalServerKeys("PastConvict")},
            { CountStats.PastHunter, new CountGoalServerKeys("PastHunter")},
            { CountStats.PastMarine, new CountGoalServerKeys("PastMarine")},
            { CountStats.PastPilot, new CountGoalServerKeys("PastPilot")},
            { CountStats.PastRobot, new CountGoalServerKeys("PastRobot")},
            { CountStats.PastKills, new CountGoalServerKeys("PastKills")},
        };

        #endregion

        #region Dictionary Inits
        private static Dictionary<CountStats, int> CountSaveDataDict { get; set; } = new Dictionary<CountStats, int>()
        {
            { CountStats.ChestsOpened, 0 },
            { CountStats.RoomPoints, 0},
            { CountStats.CashSpent, 0},

            { CountStats.BlobulordKills, 0},
            { CountStats.OldKingKills, 0},
            { CountStats.RatKills, 0},
            { CountStats.DeptAgunimKills, 0},
            { CountStats.AdvancedDragunKills, 0},
            { CountStats.DragunKills, 0},
            { CountStats.LichKills, 0},

            { CountStats.Floor1Clears, 0},
            { CountStats.Floor2Clears, 0},
            { CountStats.Floor3Clears, 0},
            { CountStats.Floor4Clears, 0},
            { CountStats.Floor5Clears, 0},

            { CountStats.FloorHellClears, 0},
            { CountStats.FloorGoopClears, 0},
            { CountStats.FloorAbbeyClears, 0    },
            { CountStats.FloorRatClears, 0},
            { CountStats.FloorDeptClears, 0},

            { CountStats.PastBullet, 0},
            { CountStats.PastConvict, 0},
            { CountStats.PastHunter, 0},
            { CountStats.PastMarine, 0},
            { CountStats.PastPilot, 0},
            { CountStats.PastRobot, 0},
            { CountStats.PastKills, 0},
        };
        private static Dictionary<CountStats, List<int>> LocationCheckGoals { get; set; } = new Dictionary<CountStats, List<int>>();

        #endregion

        #region Goal Definitions
        private static Dictionary<CountStats, List<int>> ShortGoals { get; } = new Dictionary<CountStats, List<int>>()
        {
            { CountStats.ChestsOpened, new List<int>{ 4, 8, 13, 18 }   },
            { CountStats.RoomPoints, new List<int>{ 6, 24, 120, 720, 5040 }  },
            { CountStats.CashSpent, new List<int>{ 50, 100, 150 }  },

            { CountStats.Floor1Clears, new List<int>{ 1, 2, 3, 4 } },
            { CountStats.Floor2Clears, new List<int>{ 1, 2, 3, 4 }  },
            { CountStats.Floor3Clears, new List<int>{ 1, 2, 3 }  },
            { CountStats.Floor4Clears, new List<int>{ 1, 2, 3 }  },
            { CountStats.Floor5Clears, new List<int>{ 1, 2}  },

            { CountStats.FloorHellClears, new List<int>{1}  },
            { CountStats.FloorGoopClears, new List<int>{1, 2 }  },
            { CountStats.FloorAbbeyClears,   new List<int>{1}  },

            { CountStats.PastKills, new List<int>{1}  },
        };

        private static Dictionary<CountStats, List<int>> StandardGoals { get; } = new Dictionary<CountStats, List<int>>()
        {
            { CountStats.ChestsOpened, new List<int>{ 4, 8, 13, 18, 24, 30 }   },
            { CountStats.RoomPoints, new List<int>{ 6, 24, 120, 720, 5040, 10000, 15000, 20000 }  },
            { CountStats.CashSpent, new List<int>{ 50, 100, 150, 200, 250 }  },

            { CountStats.Floor1Clears, new List<int>{ 1, 2, 3, 4, 5, 6 } },
            { CountStats.Floor2Clears, new List<int>{ 1, 2, 3, 4, 5, 6 }  },
            { CountStats.Floor3Clears, new List<int>{ 1, 2, 3, 4 }  },
            { CountStats.Floor4Clears, new List<int>{ 1, 2, 3, 4 }  },
            { CountStats.Floor5Clears, new List<int>{1, 2, 3, 4}  },

            { CountStats.FloorHellClears, new List<int>{1, 2}  },
            { CountStats.FloorGoopClears, new List<int>{1, 2 ,3}  },
            { CountStats.FloorAbbeyClears,   new List<int>{1, 2}  },
            { CountStats.FloorRatClears, new List<int>{1}  },
            { CountStats.FloorDeptClears, new List<int>{1}  },

            { CountStats.PastKills, new List<int>{1, 2, 3, 4}  },
        };

        private static Dictionary<CountStats, List<int>> MarathonGoals { get; } = new Dictionary<CountStats, List<int>>()
        {
            { CountStats.ChestsOpened, new List<int>{ 4, 8, 13, 18, 25, 30, 35, 40 }   },
            { CountStats.RoomPoints, new List<int>{ 6, 24, 120, 720, 5040, 10000, 15000, 20000, 25000, 30000, 40000, 50000, 60000 }  },
            { CountStats.CashSpent, new List<int>{ 50, 100, 150, 200, 250, 300, 350 }  },

            { CountStats.Floor1Clears, new List<int>{ 1, 2, 3, 4, 5, 6, 7, 8 } },
            { CountStats.Floor2Clears, new List<int>{ 1, 2, 3, 4, 5, 6, 7, 8 }  },
            { CountStats.Floor3Clears, new List<int>{ 1, 2, 3, 4, 5, 6 }  },
            { CountStats.Floor4Clears, new List<int>{ 1, 2, 3, 4, 5, 6 }  },
            { CountStats.Floor5Clears, new List<int>{1, 2, 3, 4, 5, 6}  },

            { CountStats.FloorHellClears, new List<int>{1, 2, 3}  },
            { CountStats.FloorGoopClears, new List<int>{1, 2 ,3, 4, 5, 6}  },
            { CountStats.FloorAbbeyClears,   new List<int>{1, 2, 3}  },
            { CountStats.FloorRatClears, new List<int>{1, 2}  },
            { CountStats.FloorDeptClears, new List<int>{1, 2}  },

            { CountStats.PastKills, new List<int>{1, 2, 3, 4, 5, 6}  },
        };

        private static Dictionary<CountStats, string> GoalsFormattedText { get; } = new Dictionary<CountStats, string>
        {
            { CountStats.ChestsOpened, "Open chests" },
            { CountStats.RoomPoints, "Clear rooms"},
            { CountStats.CashSpent, "Spend cash"},

            { CountStats.Floor1Clears, "Keep" },
            { CountStats.Floor2Clears, "Gungeon Proper"  },
            { CountStats.Floor3Clears, "Mine"  },
            { CountStats.Floor4Clears, "Hollow"  },
            { CountStats.Floor5Clears, "Forge"},

            { CountStats.FloorHellClears, "Hell" },
            { CountStats.FloorGoopClears, "Oubliette"},
            { CountStats.FloorAbbeyClears, "Abbey"    },
            { CountStats.FloorRatClears, "Rat Lair" },
            { CountStats.FloorDeptClears, "R&G Dept." },

            { CountStats.PastKills, "Kill Pasts" },
        };
        #endregion

        #region Goal Management
        public static void SetGoalList(int goalCase)
        {
            ArchDebugPrint.DebugLog(DebugCategory.CountingGoal, $"Getting goal case list: {goalCase}");
            switch (goalCase)
            {
                case 0:
                    LocationCheckGoals = ShortGoals;
                    return;
                case 1:
                    LocationCheckGoals = StandardGoals;
                    return;
                case 2:
                    LocationCheckGoals = MarathonGoals;
                    return;
                default:
                    LocationCheckGoals = StandardGoals;
                    break;
            }

            return;
        }

        public static List<CountStats> GetListOfStatsWithGoals()
        {
            ArchDebugPrint.DebugLog(DebugCategory.CountingGoal, $"Getting list of goals");
            List<CountStats> statsWithGoals = LocationCheckGoals.Keys.ToList();
            return statsWithGoals;
        }
        
        public static int GetCountOfStatGoals(CountStats statToCount)
        {
            if(LocationCheckGoals.ContainsKey(statToCount))
            {
                ArchDebugPrint.DebugLog(DebugCategory.CountingGoal, $"Counted goals for {statToCount} -- {LocationCheckGoals[statToCount].Count}");
                return LocationCheckGoals[statToCount].Count;
            }

            else
            {
                ArchDebugPrint.DebugLog(DebugCategory.CountingGoal, $"Tried counting stat with no goals: {statToCount}");
                return 0;
            }
            
        }

        public static int GetCountStat(CountStats statToGet)
        {
            int statData = CountSaveDataDict[statToGet];

            return statData;
        }


        public static void SetCountStat(CountStats statToSet, int count)
        {
            CountSaveDataDict[statToSet] = count;
            return;
        }

        public static Dictionary<CountStats, int> GetFullCountSaveData()
        {
            return CountSaveDataDict;
        }

        public static void SetFullCountSaveData(Dictionary<CountStats, int> dataToLoad)
        {
            CountSaveDataDict = dataToLoad;
        }

        public static int AddToGoalCount(CountStats statToModify, int addAmount)
        {
            if(IsCountStatNull(statToModify))
            {
                return 0;
            }

            int statCount = CountSaveDataDict[statToModify];
            statCount += addAmount;
            SetCountStat(statToModify, statCount);

            if(!LocationCheckGoals.ContainsKey(statToModify))
            {
                return 0;
            }

            int goalsMet = 0;
            foreach (int goal in LocationCheckGoals[statToModify])
            {
                ArchDebugPrint.DebugLog(DebugCategory.CountingGoal, $"[{statToModify}] New count: {statCount} against goal: {goal}");

                if(statCount >= goal)
                {
                    goalsMet++;
                }
                else
                {
                    break;
                }
            }

            return goalsMet;
        }

        public static bool RemoveClearedGoals(CountStats statToModify, int goalsCleared)
        {
            if(IsCountStatNull(statToModify))
            {
                return true;
            }

            bool outOfGoals = false;

            List<int> goalList = LocationCheckGoals[statToModify];

            if(goalList.Count < 1)
            {
                ArchDebugPrint.DebugLog(DebugCategory.CountingGoal, statToModify + " goals complete");
                outOfGoals = true;

                return outOfGoals;
            }

            ArchDebugPrint.DebugLog(DebugCategory.CountingGoal, $"[Removing {goalsCleared} from goal list: {statToModify}");

            goalList.RemoveRange(0, goalsCleared);
            LocationCheckGoals[statToModify] = goalList;

            if (goalList.Count == 0)
            {
                CountSaveDataDict[statToModify] = 99999;
                outOfGoals = true;
                ArchDebugPrint.DebugLog(DebugCategory.CountingGoal, statToModify + " goals complete");
            }
           
            return outOfGoals;
        }

        public static List<string> GetFormattedListOfRemainingGoals()
        {
            List<string> formatList = new List<string>();

            foreach(CountStats saveCountStats in LocationCheckGoals.Keys)
            {
                List<int> goalCount = LocationCheckGoals[saveCountStats];

                if(goalCount.Count > 1 && GoalsFormattedText.ContainsKey(saveCountStats))
                {
                    formatList.Add(GoalsFormattedText[saveCountStats]);
                }
            }

            return formatList;
        }

        private static bool IsCountStatNull(CountStats statToCheck)
        {
            int statCount = CountSaveDataDict[statToCheck];

            if(statCount == 99999) { return true; }

            else {  return false; }
        }
        #endregion
    }

    public class SaveDataManagement
    {
        public static void TryPreviousSaveLoad(PlayerConnectionInfo playerInfo)
        {
            if(SaveDataWriter.InitSaveFilenameAndCheckPrevious(playerInfo.PlayerName, playerInfo.Seed) == true)
            {
                // TODO FUTURE: define other dicts for multiple save data types to consider
                Dictionary<CountStats, int> saveData = SaveDataWriter.RetrieveSaveData();

                CountGoalManager.SetFullCountSaveData(saveData);
                return;
            }
            else
            {
                return;
            }
        }

        private static void HandleSaveValidationAndWrite()
        {
            Dictionary<CountStats, int> countSaveDataToWrite = new Dictionary<CountStats, int>();

            foreach (CountStats countStat in (CountStats[])Enum.GetValues(typeof(CountStats)))
            {
                int statData = CountGoalManager.GetCountStat(countStat);

                if (statData > 0)
                {
                    countSaveDataToWrite[countStat] = statData;

                    ArchDebugPrint.DebugLog(DebugCategory.LocalSaveData, $"Saving count for {countStat}: {statData}");
                }
                else
                {
                    countSaveDataToWrite[countStat] = 0;
                }

            }

            SaveDataWriter.WriteSaveFile(countSaveDataToWrite);
        }

        public static void SaveCurrentRandomizerProgress()
        {
            HandleSaveValidationAndWrite();
            return;
        }

        public static void AddToCountSaveDataEntry(CountStats statToAdd, int numberToAdd)
        {
            if(numberToAdd > 0)
            {
                ArchDebugPrint.DebugLog(DebugCategory.LocalSaveData, $"{statToAdd} goal adding: {numberToAdd}");
            }
            int goalsMet = CountGoalManager.AddToGoalCount(statToAdd, numberToAdd);

            if (goalsMet >= 1)
            {
                ArchDebugPrint.DebugLog(DebugCategory.CountingGoal, $"[{statToAdd}] Goal handling {goalsMet} completions");

                AchievementLocationCheckHandler.SendStatLocationChecks(statToAdd, goalsMet);
                CountGoalManager.RemoveClearedGoals(statToAdd, goalsMet);

                SaveCurrentRandomizerProgress();
            }

            return;
        }

        public static void CheckFullCountStatsForGoals()
        {
            ArchDebugPrint.DebugLog(DebugCategory.CountingGoal, $"Checking save data for cleared goals");

            List<CountStats> countStatList = CountGoalManager.GetFullCountSaveData().Keys.ToList<CountStats>();
            foreach(CountStats countStat in countStatList)
            {
                AddToCountSaveDataEntry(countStat, 0);
            }
            return;
        }
    }
}
