using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArchiGungeon.DebugTools;
using ArchiGungeon.Data;

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
        public static Dictionary<PlayerCompletionGoals, SaveCountStats[]> GoalToStatChecks { get; } = new Dictionary<PlayerCompletionGoals, SaveCountStats[]>
        {
            { PlayerCompletionGoals.Lich, new SaveCountStats[] { SaveCountStats.LichKills } },
            { PlayerCompletionGoals.Dragun, new SaveCountStats[] { SaveCountStats.DragunKills} },
            { PlayerCompletionGoals.SecretChamber, new SaveCountStats[] { SaveCountStats.OldKingKills, SaveCountStats.BlobulordKills} },
            { PlayerCompletionGoals.AdvancedGungeon, new SaveCountStats[] { SaveCountStats.AdvancedDragunKills, SaveCountStats.RatKills} },
            { PlayerCompletionGoals.FarewellArms, new SaveCountStats[] { SaveCountStats.DeptAgunimKills} },
            { PlayerCompletionGoals.PastsBase, new SaveCountStats[] { SaveCountStats.PastConvict, SaveCountStats.PastHunter, SaveCountStats.PastMarine, SaveCountStats.PastPilot} },
            { PlayerCompletionGoals.PastsFull, new SaveCountStats[] { SaveCountStats.PastConvict, SaveCountStats.PastHunter, SaveCountStats.PastMarine, SaveCountStats.PastPilot, SaveCountStats.PastRobot, SaveCountStats.PastBullet} },
        };  

        private static Dictionary<SaveCountStats, int> InitialStatValues { get; } = new Dictionary<SaveCountStats, int>()
        {
            { SaveCountStats.ChestsOpened, -1 },
            { SaveCountStats.RoomPoints, -1},
            { SaveCountStats.CashSpent, -1},

            { SaveCountStats.BlobulordKills, -1},
            { SaveCountStats.OldKingKills, -1},
            { SaveCountStats.RatKills, -1},
            { SaveCountStats.DeptAgunimKills, -1},
            { SaveCountStats.AdvancedDragunKills, -1},
            { SaveCountStats.DragunKills, -1},
            { SaveCountStats.LichKills, -1},

            { SaveCountStats.Floor1Clears, -1},
            { SaveCountStats.Floor2Clears, -1},
            { SaveCountStats.Floor3Clears, -1},
            { SaveCountStats.Floor4Clears, -1},
            { SaveCountStats.Floor5Clears, -1},

            { SaveCountStats.FloorHellClears, -1},
            { SaveCountStats.FloorGoopClears, -1},
            { SaveCountStats.FloorAbbeyClears, -1},
            { SaveCountStats.FloorRatClears, -1},
            { SaveCountStats.FloorDeptClears, -1},

            { SaveCountStats.PastBullet, -1},
            { SaveCountStats.PastConvict, -1},
            { SaveCountStats.PastHunter, -1},
            { SaveCountStats.PastMarine, -1},
            { SaveCountStats.PastPilot, -1},
            { SaveCountStats.PastRobot, -1},
            { SaveCountStats.PastKills, -1},
        };

        private static Dictionary<SaveCountStats, int> SaveDataTrackedStats { get; set; } = InitialStatValues;
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
            int statData = SaveDataTrackedStats[statToGet];

            return statData;
        }


        public static void SetCountStat(SaveCountStats statToSet, int count)
        {
            SaveDataTrackedStats[statToSet] = count;
            return;
        }



        public static int AddToGoalCount(SaveCountStats statToModify, int addAmount)
        {
            if(IsCountStatNull(statToModify))
            {
                return 0;
            }

            int statCount = SaveDataTrackedStats[statToModify];
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
                SaveDataTrackedStats[statToModify] = 99999;
                outOfGoals = true;
                ArchDebugPrint.DebugLog(DebugCategory.CountingGoal, statToModify + " goals complete");
            }
           
            return outOfGoals;
        }

        private static bool IsCountStatNull(SaveCountStats statToCheck)
        {
            int statCount = SaveDataTrackedStats[statToCheck];

            if(statCount == 99999) { return true; }

            else {  return false; }
        }
        #endregion
    }
}
