using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArchiGungeon.ArchipelagoServer;
using ArchiGungeon.DebugTools;

namespace ArchiGungeon.ItemArchipelago
{
    class AchievementLocationCheckHandler
    {
        private static Dictionary<SaveCountStats, List<long>> StatToLocationIDs = new Dictionary<SaveCountStats, List<long>>();

        public static void SetStatLocationIDs(SaveCountStats statToSet, List<long> idList)
        {
            ArchDebugPrint.DebugLog(DebugCategory.InitializingGameState, $"Setting {statToSet} with location IDs count {idList.Count}");

            StatToLocationIDs[statToSet] = idList;
            return;
        }

        public static void SendStatLocationChecks(SaveCountStats statCategory, int numberOfChecks)
        {
            if (StatToLocationIDs.ContainsKey(statCategory) == false)
            {
                return;
            }

            List<long> fullList = StatToLocationIDs[statCategory];
            List<long> sendList = fullList.GetRange(0, numberOfChecks);

            foreach (long locationID in sendList)
            {
                ArchDebugPrint.DebugLog(DebugCategory.ServerSend, $"Sending {statCategory} location check: {locationID}");

                SessionHandler.DataSender.SendFoundLocationCheck(locationID);
            }

            fullList.RemoveRange(0, numberOfChecks);
            StatToLocationIDs[statCategory] = fullList;

            return;
        }

    }
}
