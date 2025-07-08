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
        private static List<PlayerCompletionGoals> CompletionGoalsToCheck { get; } = new List<PlayerCompletionGoals>();

        private static Dictionary<PlayerCompletionGoals, SaveCountStats[]> GoalToStatChecks { get; } = new Dictionary<PlayerCompletionGoals, SaveCountStats[]>
        {
            { PlayerCompletionGoals.Lich, new SaveCountStats[] { SaveCountStats.LichKills } },
            { PlayerCompletionGoals.Dragun, new SaveCountStats[] { SaveCountStats.DragunKills} },
            { PlayerCompletionGoals.SecretChamber, new SaveCountStats[] { SaveCountStats.OldKingKills, SaveCountStats.BlobulordKills} },
            { PlayerCompletionGoals.AdvancedGungeon, new SaveCountStats[] { SaveCountStats.AdvancedDragunKills, SaveCountStats.RatKills} },
            { PlayerCompletionGoals.FarewellArms, new SaveCountStats[] { SaveCountStats.DeptAgunimKills} },
            { PlayerCompletionGoals.PastsBase, new SaveCountStats[] { SaveCountStats.PastConvict, SaveCountStats.PastHunter, SaveCountStats.PastMarine, SaveCountStats.PastPilot} },
            { PlayerCompletionGoals.PastsFull, new SaveCountStats[] { SaveCountStats.PastConvict, SaveCountStats.PastHunter, SaveCountStats.PastMarine, SaveCountStats.PastPilot, SaveCountStats.PastRobot, SaveCountStats.PastBullet} },
        };

        private static Dictionary<SaveCountStats, string> FormattedIncompleteGoalStat { get; } = new Dictionary<SaveCountStats, string>
        {
            { SaveCountStats.LichKills, "Defeat Lich"},
            { SaveCountStats.DragunKills, "Defeat Dragun"},
            { SaveCountStats.OldKingKills, "Defeat Old King"},
            { SaveCountStats.BlobulordKills, "Defeat Blobulord"},
            { SaveCountStats.AdvancedDragunKills, "Defeat Advanced Dragun"},
            { SaveCountStats.RatKills, "Defeat The Resourceful Rat (Mech Phase)"},
            { SaveCountStats.DeptAgunimKills, "Defeat R&G Dept. Agunim"},
            { SaveCountStats.PastConvict, "Kill the Convict's Past"},
            { SaveCountStats.PastHunter, "Kill the Hunter's Past"},
            { SaveCountStats.PastMarine, "Kill the Marine's Past"},
            { SaveCountStats.PastPilot, "Kill the Pilot's Past"},
            { SaveCountStats.PastRobot, "Kill the Robot's Past"},
            { SaveCountStats.PastBullet, "Kill the Bullet's Past"},
        };

        #endregion

        public static void AddToCompletionGoalsToCheck(PlayerCompletionGoals goalToAdd)
        {
            ArchDebugPrint.DebugLog(DebugCategory.GameCompletion, $"Adding {goalToAdd} to player completion goals.");
            CompletionGoalsToCheck.Add(goalToAdd);
        }

        public static SaveCountStats[] GetCountStatsForCompletionGoal(PlayerCompletionGoals goalEnum)
        {
            if(!GoalToStatChecks.ContainsKey(goalEnum))
            {
                return null;
            }

            SaveCountStats[] statsToReturn = GoalToStatChecks[goalEnum];

            return statsToReturn;
        }

        public static List<string> GetAllUnmetCountsForGoals()
        {
            List<string> unmetCountStats = new List<string>();
            // string outputs of incomplete count stats, list length > 0 means run is not complete

            foreach (PlayerCompletionGoals playerGoal in CompletionGoalsToCheck)
            {
                List<SaveCountStats> statsForGoal = new List<SaveCountStats>();
                //statsForGoal is the countSaveStats enums that will be checked if greater than 0

                statsForGoal = GetCountStatsForCompletionGoal(playerGoal).ToList();

                foreach (SaveCountStats statCheck in statsForGoal)
                {
                    int statCount = CountSaveData.GetCountStat(statCheck);

                    if (statCount < 1)
                    {
                        ArchDebugPrint.DebugLog(DebugCategory.GameCompletion, $"Count {statCheck} not met in completion check");
                        unmetCountStats.Add(FormattedIncompleteGoalStat[statCheck]);
                    }
                }
            }
            

            return unmetCountStats;
        }


    }
}
