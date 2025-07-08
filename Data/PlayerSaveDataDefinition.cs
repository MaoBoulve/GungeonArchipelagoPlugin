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

    public class CountSaveData
    {
        #region APWorld Data

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

            { SaveCountStats.PastBullet, new CountGoalServerKeys("PastBullet")},
            { SaveCountStats.PastConvict, new CountGoalServerKeys("PastConvict")},
            { SaveCountStats.PastHunter, new CountGoalServerKeys("PastHunter")},
            { SaveCountStats.PastMarine, new CountGoalServerKeys("PastMarine")},
            { SaveCountStats.PastPilot, new CountGoalServerKeys("PastPilot")},
            { SaveCountStats.PastRobot, new CountGoalServerKeys("PastRobot")},
            { SaveCountStats.PastKills, new CountGoalServerKeys("PastKills")},
        };

        #endregion

        #region Dictionary Inits
        private static Dictionary<SaveCountStats, int> CountSaveDataDict { get; set; } = new Dictionary<SaveCountStats, int>()
        {
            { SaveCountStats.ChestsOpened, 0 },
            { SaveCountStats.RoomPoints, 0},
            { SaveCountStats.CashSpent, 0},

            { SaveCountStats.BlobulordKills, 0},
            { SaveCountStats.OldKingKills, 0},
            { SaveCountStats.RatKills, 0},
            { SaveCountStats.DeptAgunimKills, 0},
            { SaveCountStats.AdvancedDragunKills, 0},
            { SaveCountStats.DragunKills, 0},
            { SaveCountStats.LichKills, 0},

            { SaveCountStats.Floor1Clears, 0},
            { SaveCountStats.Floor2Clears, 0},
            { SaveCountStats.Floor3Clears, 0},
            { SaveCountStats.Floor4Clears, 0},
            { SaveCountStats.Floor5Clears, 0},

            { SaveCountStats.FloorHellClears, 0},
            { SaveCountStats.FloorGoopClears, 0},
            { SaveCountStats.FloorAbbeyClears, 0    },
            { SaveCountStats.FloorRatClears, 0},
            { SaveCountStats.FloorDeptClears, 0},

            { SaveCountStats.PastBullet, 0},
            { SaveCountStats.PastConvict, 0},
            { SaveCountStats.PastHunter, 0},
            { SaveCountStats.PastMarine, 0},
            { SaveCountStats.PastPilot, 0},
            { SaveCountStats.PastRobot, 0},
            { SaveCountStats.PastKills, 0},
        };
        private static Dictionary<SaveCountStats, List<int>> LocationCheckGoals { get; set; } = new Dictionary<SaveCountStats, List<int>>();

        #endregion

        #region Goal Definitions
        private static Dictionary<SaveCountStats, List<int>> ShortGoals { get; } = new Dictionary<SaveCountStats, List<int>>()
        {
            { SaveCountStats.ChestsOpened, new List<int>{ 4, 8, 13, 18 }   },
            { SaveCountStats.RoomPoints, new List<int>{ 6, 24, 120, 720, 5040 }  },
            { SaveCountStats.CashSpent, new List<int>{ 50, 100, 150 }  },

            { SaveCountStats.Floor1Clears, new List<int>{ 1, 2, 3, 4 } },
            { SaveCountStats.Floor2Clears, new List<int>{ 1, 2, 3, 4 }  },
            { SaveCountStats.Floor3Clears, new List<int>{ 1, 2, 3 }  },
            { SaveCountStats.Floor4Clears, new List<int>{ 1, 2, 3 }  },
            { SaveCountStats.Floor5Clears, new List<int>{ 1, 2}  },

            { SaveCountStats.FloorHellClears, new List<int>{1}  },
            { SaveCountStats.FloorGoopClears, new List<int>{1, 2 }  },
            { SaveCountStats.FloorAbbeyClears,   new List<int>{1}  },

            { SaveCountStats.PastKills, new List<int>{1}  },
        };

        private static Dictionary<SaveCountStats, List<int>> StandardGoals { get; } = new Dictionary<SaveCountStats, List<int>>()
        {
            { SaveCountStats.ChestsOpened, new List<int>{ 4, 8, 13, 18, 24, 30 }   },
            { SaveCountStats.RoomPoints, new List<int>{ 6, 24, 120, 720, 5040, 10000, 15000, 20000 }  },
            { SaveCountStats.CashSpent, new List<int>{ 50, 100, 150, 200, 250 }  },

            { SaveCountStats.Floor1Clears, new List<int>{ 1, 2, 3, 4, 5, 6 } },
            { SaveCountStats.Floor2Clears, new List<int>{ 1, 2, 3, 4, 5, 6 }  },
            { SaveCountStats.Floor3Clears, new List<int>{ 1, 2, 3, 4 }  },
            { SaveCountStats.Floor4Clears, new List<int>{ 1, 2, 3, 4 }  },
            { SaveCountStats.Floor5Clears, new List<int>{1, 2, 3, 4}  },

            { SaveCountStats.FloorHellClears, new List<int>{1, 2}  },
            { SaveCountStats.FloorGoopClears, new List<int>{1, 2 ,3}  },
            { SaveCountStats.FloorAbbeyClears,   new List<int>{1, 2}  },
            { SaveCountStats.FloorRatClears, new List<int>{1}  },
            { SaveCountStats.FloorDeptClears, new List<int>{1}  },

            { SaveCountStats.PastKills, new List<int>{1, 2, 3, 4}  },
        };

        private static Dictionary<SaveCountStats, List<int>> MarathonGoals { get; } = new Dictionary<SaveCountStats, List<int>>()
        {
            { SaveCountStats.ChestsOpened, new List<int>{ 4, 8, 13, 18, 25, 30, 35, 40 }   },
            { SaveCountStats.RoomPoints, new List<int>{ 6, 24, 120, 720, 5040, 10000, 15000, 20000, 25000, 30000, 40000, 50000, 60000 }  },
            { SaveCountStats.CashSpent, new List<int>{ 50, 100, 150, 200, 250, 300, 350 }  },

            { SaveCountStats.Floor1Clears, new List<int>{ 1, 2, 3, 4, 5, 6, 7, 8 } },
            { SaveCountStats.Floor2Clears, new List<int>{ 1, 2, 3, 4, 5, 6, 7, 8 }  },
            { SaveCountStats.Floor3Clears, new List<int>{ 1, 2, 3, 4, 5, 6 }  },
            { SaveCountStats.Floor4Clears, new List<int>{ 1, 2, 3, 4, 5, 6 }  },
            { SaveCountStats.Floor5Clears, new List<int>{1, 2, 3, 4, 5, 6}  },

            { SaveCountStats.FloorHellClears, new List<int>{1, 2, 3}  },
            { SaveCountStats.FloorGoopClears, new List<int>{1, 2 ,3, 4, 5, 6}  },
            { SaveCountStats.FloorAbbeyClears,   new List<int>{1, 2, 3}  },
            { SaveCountStats.FloorRatClears, new List<int>{1, 2}  },
            { SaveCountStats.FloorDeptClears, new List<int>{1, 2}  },

            { SaveCountStats.PastKills, new List<int>{1, 2, 3, 4, 5, 6}  },
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

        public static List<SaveCountStats> GetListOfStatsWithGoals()
        {
            ArchDebugPrint.DebugLog(DebugCategory.CountingGoal, $"Getting list of goals");
            List<SaveCountStats> statsWithGoals = LocationCheckGoals.Keys.ToList();
            return statsWithGoals;
        }
        
        public static int GetCountOfStatGoals(SaveCountStats statToCount)
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

        public static int GetCountStat(SaveCountStats statToGet)
        {
            int statData = CountSaveDataDict[statToGet];

            return statData;
        }


        public static void SetCountStat(SaveCountStats statToSet, int count)
        {
            CountSaveDataDict[statToSet] = count;
            return;
        }

        public static Dictionary<SaveCountStats, int> GetFullCountSaveData()
        {
            return CountSaveDataDict;
        }

        public static void SetFullCountSaveData(Dictionary<SaveCountStats, int> dataToLoad)
        {
            CountSaveDataDict = dataToLoad;
        }

        public static int AddToGoalCount(SaveCountStats statToModify, int addAmount)
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

        public static bool RemoveClearedGoals(SaveCountStats statToModify, int goalsCleared)
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

        private static bool IsCountStatNull(SaveCountStats statToCheck)
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
                Dictionary<SaveCountStats, int> saveData = SaveDataWriter.RetrieveSaveData();

                CountSaveData.SetFullCountSaveData(saveData);
                return;
            }
            else
            {
                return;
            }
        }

        private static void HandleSaveValidationAndWrite()
        {
            Dictionary<SaveCountStats, int> countSaveDataToWrite = new Dictionary<SaveCountStats, int>();

            foreach (SaveCountStats countStat in (SaveCountStats[])Enum.GetValues(typeof(SaveCountStats)))
            {
                int statData = CountSaveData.GetCountStat(countStat);

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

        public static void AddToCountSaveDataEntry(SaveCountStats statToAdd, int numberToAdd)
        {
            if(numberToAdd > 0)
            {
                ArchDebugPrint.DebugLog(DebugCategory.LocalSaveData, $"{statToAdd} goal adding: {numberToAdd}");
            }
            int goalsMet = CountSaveData.AddToGoalCount(statToAdd, numberToAdd);

            if (goalsMet >= 1)
            {
                ArchDebugPrint.DebugLog(DebugCategory.CountingGoal, $"[{statToAdd}] Goal handling {goalsMet} completions");

                AchievementLocationCheckHandler.SendStatLocationChecks(statToAdd, goalsMet);
                CountSaveData.RemoveClearedGoals(statToAdd, goalsMet);

                SaveCurrentRandomizerProgress();
            }

            return;
        }

        public static void CheckFullCountStatsForGoals()
        {
            ArchDebugPrint.DebugLog(DebugCategory.CountingGoal, $"Checking save data for cleared goals");

            List<SaveCountStats> countStatList = CountSaveData.GetFullCountSaveData().Keys.ToList<SaveCountStats>();
            foreach(SaveCountStats countStat in countStatList)
            {
                AddToCountSaveDataEntry(countStat, 0);
            }
            return;
        }
    }
}
