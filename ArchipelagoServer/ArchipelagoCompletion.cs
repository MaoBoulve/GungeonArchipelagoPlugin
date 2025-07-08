using ArchiGungeon.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArchiGungeon.ArchipelagoServer
{
    public class ArchipelagoCompletion
    {
        #region Data Inits
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
        #endregion

        public static SaveCountStats[] GetCountStatsForCompletionGoal(PlayerCompletionGoals goalEnum)
        {
            if(!GoalToStatChecks.ContainsKey(goalEnum))
            {
                return null;
            }

            SaveCountStats[] statsToReturn = GoalToStatChecks[goalEnum];

            return statsToReturn;
        }
    }
}
