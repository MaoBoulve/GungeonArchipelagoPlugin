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

        private static Dictionary<SaveCountStats, int> InitialStatValues { get; } = new Dictionary<SaveCountStats, int>()
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
            { SaveCountStats.FloorAbbeyClears, 0},
            { SaveCountStats.FloorRatClears, 0},
            { SaveCountStats.FloorDeptClears, 0},
        };

        //TO DO: set from server settings
        private static Dictionary<SaveCountStats, List<int>> GoalList { get; } = new Dictionary<SaveCountStats, List<int>>()
        {
            { SaveCountStats.ChestsOpened, new List<int>{ 4, 8, 13, 18, 24, 30, 37, 44 }   },
            { SaveCountStats.RoomPoints, new List<int>{ 6, 24, 120, 720, 5040, 10000, 15000, 20000 }  },
            { SaveCountStats.CashSpent, new List<int>{ 50, 100, 150, 200, 250 }  },

            { SaveCountStats.BlobulordKills, new List<int>{1}  },
            { SaveCountStats.OldKingKills, new List<int>{1}  },
            { SaveCountStats.RatKills, new List<int>{1}  },
            { SaveCountStats.DeptAgunimKills, new List<int>{1}  },
            { SaveCountStats.AdvancedDragunKills, new List<int>{1}  },
            { SaveCountStats.DragunKills, new List<int>{1}  },
            { SaveCountStats.LichKills, new List<int>{1}  },

            { SaveCountStats.Floor1Clears, new List<int>{ 1, 2, 3, 4, 5 } },
            { SaveCountStats.Floor2Clears, new List<int>{ 1, 2, 3, 4 }  },
            { SaveCountStats.Floor3Clears, new List<int>{ 1, 2, 3 }  },
            { SaveCountStats.Floor4Clears, new List<int>{ 1, 2, 3 }  },
            { SaveCountStats.Floor5Clears, new List<int>{1, 2}  },

            { SaveCountStats.FloorHellClears, new List<int>{1}  },
            { SaveCountStats.FloorGoopClears, new List<int>{1, 2 ,3}  },
            { SaveCountStats.FloorAbbeyClears,   new List<int>{1}  },
            { SaveCountStats.FloorRatClears, new List<int>{1}  },
            { SaveCountStats.FloorDeptClears, new List<int>{1}  },
        };

        private static Dictionary<SaveCountStats, int> SaveDataTrackedStats { get; set; } = InitialStatValues;



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

            int goalsMet = 0;

            int statCount = SaveDataTrackedStats[statToModify];

            statCount += addAmount;
            SetCountStat(statToModify, statCount);

            foreach (int goal in GoalList[statToModify])
            {
                ArchipelagoGUI.ConsoleLog($"[{statToModify}] New count: {statCount} against goal: {goal}");

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

            List<int> goalList = GoalList[statToModify];

            if(goalList.Count < 1)
            {
                outOfGoals = true;

                return outOfGoals;
            }

            goalList.RemoveRange(0, goalsCleared);
            GoalList[statToModify] = goalList;

            if (goalList.Count == 0)
            {
                SaveDataTrackedStats[statToModify] = -9999;
                outOfGoals = true;
                ArchipelagoGUI.ConsoleLog(statToModify + " goals complete");
            }
           
            return outOfGoals;
        }

        private static bool IsCountStatNull(SaveCountStats statToCheck)
        {
            int statCount = SaveDataTrackedStats[statToCheck];

            if(statCount == -9999) { return true; }

            else {  return false; }
        }

    }
}
