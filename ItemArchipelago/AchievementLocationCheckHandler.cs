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
        private static Dictionary<SaveCountStats, long> StatToStartLocationID { get; } = new Dictionary<SaveCountStats, long>()
        {
            {SaveCountStats.RoomPoints, 8755200},
            {SaveCountStats.ChestsOpened, 8755300},
            {SaveCountStats.CashSpent, 8755400},
            {SaveCountStats.PastKills, 8755600},

            {SaveCountStats.Floor1Clears, 8755700},
            {SaveCountStats.Floor2Clears, 8755720},
            {SaveCountStats.Floor3Clears, 8755740},
            {SaveCountStats.Floor4Clears, 8755760},
            {SaveCountStats.Floor5Clears, 8755780},

            {SaveCountStats.FloorHellClears, 8755800},
            {SaveCountStats.FloorGoopClears, 8755820},
            {SaveCountStats.FloorAbbeyClears, 8755840},
            {SaveCountStats.FloorRatClears, 8755860},
            {SaveCountStats.FloorDeptClears, 8755880},
        };

        private static Dictionary<SaveCountStats, List<long>> StatToLocationIDs = new Dictionary<SaveCountStats, List<long>>();

        public static void SendStatLocationChecks(SaveCountStats statCategory, int numberOfChecks)
        {
            if (StatToLocationIDs.ContainsKey(statCategory) == false)
            {
                ArchDebugPrint.DebugLog(DebugCategory.ServerSend, $"{statCategory} trying to send check but not in stat:LocationID dict.");
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

        public static void SetStatLocationIDsFromGoalList(SaveCountStats statToSet)
        {

            int numberOfLocationChecks = CountSaveData.GetCountOfStatGoals(statToSet);

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
