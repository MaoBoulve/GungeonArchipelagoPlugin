using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArchiGungeon.ArchipelagoServer;
using ArchiGungeon.DebugTools;
using ArchiGungeon.Data;

namespace ArchiGungeon.ItemArchipelago
{
    class AchievementLocationCheckHandler
    {
        private static Dictionary<CountStats, long> StatToStartLocationID { get; } = new Dictionary<CountStats, long>()
        {
            {CountStats.RoomPoints, 8755200},
            {CountStats.ChestsOpened, 8755300},
            {CountStats.CashSpent, 8755400},
            {CountStats.PastKills, 8755600},

            {CountStats.Floor1Clears, 8755700},
            {CountStats.Floor2Clears, 8755720},
            {CountStats.Floor3Clears, 8755740},
            {CountStats.Floor4Clears, 8755760},
            {CountStats.Floor5Clears, 8755780},

            {CountStats.FloorHellClears, 8755800},
            {CountStats.FloorGoopClears, 8755820},
            {CountStats.FloorAbbeyClears, 8755840},
            {CountStats.FloorRatClears, 8755860},
            {CountStats.FloorDeptClears, 8755880},
        };

        private static Dictionary<CountStats, List<long>> StatToLocationIDs = new Dictionary<CountStats, List<long>>();

        public static void SendStatLocationChecks(CountStats statCategory, int numberOfChecks)
        {
            if (StatToLocationIDs.ContainsKey(statCategory) == false)
            {
                ArchDebugPrint.DebugLog(DebugCategory.ServerSend, $"{statCategory} trying to send check but not in stat:LocationID dict.");
                return;
            }

            List<long> fullList = StatToLocationIDs[statCategory];
            List<long> sendList = fullList.GetRange(0, numberOfChecks);

            ArchDebugPrint.DebugLog(DebugCategory.ServerSend, $"Sending {statCategory} location check: {sendList}");
            SessionHandler.DataSender.SendFoundLocationCheck(sendList.ToArray());

            /*
            foreach (long locationID in sendList)
            {
                ArchDebugPrint.DebugLog(DebugCategory.ServerSend, $"Sending {statCategory} location check: {locationID}");

                SessionHandler.DataSender.SendFoundLocationCheck(locationID);
            }
            */

            fullList.RemoveRange(0, numberOfChecks);
            StatToLocationIDs[statCategory] = fullList;

            return;
        }

        public static void SetStatLocationIDsFromGoalList(CountStats statToSet)
        {

            int numberOfLocationChecks = CountGoalManager.GetCountOfStatGoals(statToSet);

            if(numberOfLocationChecks < 1)
            { return; }

            List<long> locationIDs = new List<long>();

            for (int i = 0; i < numberOfLocationChecks; i++ )
            {
                long newLocID = StatToStartLocationID[statToSet] + i;
                locationIDs.Add(newLocID);
            }

            ArchDebugPrint.DebugLog(DebugCategory.InitializingGameState, $"Setting {statToSet} with location IDs count {locationIDs.Count}");

            StatToLocationIDs[statToSet] = locationIDs;
            return;
        }

    }
}
