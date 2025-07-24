using ArchiGungeon.Data;
using ArchiGungeon.DebugTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArchiGungeon.ArchipelagoServer
{
    public class ArchipelagoCompletion
    {
        #region Data Inits
        public static List<PlayerCompletionGoals> ArchipelagoRequiredGoals { get; } = new List<PlayerCompletionGoals>();

        private static Dictionary<PlayerCompletionGoals, CountStats[]> GoalToStatChecks { get; } = new Dictionary<PlayerCompletionGoals, CountStats[]>
        {
            { PlayerCompletionGoals.Lich, new CountStats[] { CountStats.LichKills } },
            { PlayerCompletionGoals.Dragun, new CountStats[] { CountStats.DragunKills} },
            { PlayerCompletionGoals.SecretChamber, new CountStats[] { CountStats.OldKingKills, CountStats.BlobulordKills} },
            { PlayerCompletionGoals.AdvancedGungeon, new CountStats[] { CountStats.AdvancedDragunKills, CountStats.RatKills} },
            { PlayerCompletionGoals.FarewellArms, new CountStats[] { CountStats.DeptAgunimKills} },
            { PlayerCompletionGoals.PastsBase, new CountStats[] { CountStats.PastConvict, CountStats.PastHunter, CountStats.PastMarine, CountStats.PastPilot} },
            { PlayerCompletionGoals.PastsFull, new CountStats[] { CountStats.PastConvict, CountStats.PastHunter, CountStats.PastMarine, CountStats.PastPilot, CountStats.PastRobot, CountStats.PastBullet} },
        };

        private static Dictionary<CountStats, string> FormattedIncompleteGoalStat_Variation1 { get; } = new Dictionary<CountStats, string>
        {
            { CountStats.LichKills, "Defeat Lich"},
            { CountStats.DragunKills, "Defeat Dragun"},
            { CountStats.OldKingKills, "Defeat Old King"},
            { CountStats.BlobulordKills, "Defeat Blobulord"},
            { CountStats.AdvancedDragunKills, "Defeat Advanced Dragun"},
            { CountStats.RatKills, "Defeat The Resourceful Rat (Mech Phase)"},
            { CountStats.DeptAgunimKills, "Defeat R&G Dept. Agunim"},
            { CountStats.PastConvict, "Kill the Convict's Past"},
            { CountStats.PastHunter, "Kill the Hunter's Past"},
            { CountStats.PastMarine, "Kill the Marine's Past"},
            { CountStats.PastPilot, "Kill the Pilot's Past"},
            { CountStats.PastRobot, "Kill the Robot's Past"},
            { CountStats.PastBullet, "Kill the Bullet's Past"},
        };

        private static Dictionary<CountStats, string> FormattedIncompleteGoalStat_Variation2 { get; } = new Dictionary<CountStats, string>
        {
            { CountStats.LichKills, "Lich"},
            { CountStats.DragunKills, "Dragun"},
            { CountStats.OldKingKills, "Old King"},
            { CountStats.BlobulordKills, "Blobulord"},
            { CountStats.AdvancedDragunKills, "Advanced Dragun"},
            { CountStats.RatKills, "The Resourceful Rat (Mech Phase)"},
            { CountStats.DeptAgunimKills, "R&G Dept. Agunim"},
            { CountStats.PastConvict, "Convict's Past"},
            { CountStats.PastHunter, "Hunter's Past"},
            { CountStats.PastMarine, "Marine's Past"},
            { CountStats.PastPilot, "Pilot's Past"},
            { CountStats.PastRobot, "Robot's Past"},
            { CountStats.PastBullet, "Bullet's Past"},
        };

        #endregion

        public static void AddToCompletionGoalsToCheck(PlayerCompletionGoals goalToAdd)
        {
            ArchDebugPrint.DebugLog(DebugCategory.GameCompletion, $"Adding {goalToAdd} to player completion goals.");
            ArchipelagoRequiredGoals.Add(goalToAdd);
        }

        public static CountStats[] GetCountStatsForCompletionGoal(PlayerCompletionGoals goalEnum)
        {
            if(!GoalToStatChecks.ContainsKey(goalEnum))
            {
                return null;
            }

            CountStats[] statsToReturn = GoalToStatChecks[goalEnum];

            return statsToReturn;
        }

        public static List<string> GetAllUnmetCountsForGoals()
        {
            List<string> unmetCountStats = new List<string>();
            // string outputs of incomplete count stats, list length > 0 means run is not complete

            foreach (PlayerCompletionGoals playerGoal in ArchipelagoRequiredGoals)
            {
                List<CountStats> statsForGoal = new List<CountStats>();
                //statsForGoal is the countSaveStats enums that will be checked if greater than 0

                statsForGoal = GetCountStatsForCompletionGoal(playerGoal).ToList();

                foreach (CountStats statCheck in statsForGoal)
                {
                    int statCount = CountGoalManager.GetCountStat(statCheck);

                    if (statCount < 1)
                    {
                        ArchDebugPrint.DebugLog(DebugCategory.GameCompletion, $"Count {statCheck} not met in completion check");
                        unmetCountStats.Add(FormattedIncompleteGoalStat_Variation2[statCheck]);
                    }
                }
            }
            

            return unmetCountStats;
        }


    }
}
