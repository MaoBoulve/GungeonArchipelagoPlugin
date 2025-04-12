using ArchiGungeon.ModConsoleVisuals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using ArchiGungeon.GungeonEventHandlers;
using ArchiGungeon.ItemArchipelago;

namespace ArchiGungeon.ArchipelagoServer
{
    public class ArchipelagoGungeonBridge
    {
        private static int baseItemID = 8754000;
        private static int consumableCategoryItemID = 8754100;
        private static int trapCategoryItemID = 8754200;

        private static Dictionary<long, int> itemIDToPickUpItem = new Dictionary<long, int>
        {
            { 0L, 0 },
            { 1L, 1 },
            { 2L, 2 },
            { 3L, 3 },
            { 4L, 4 },
            { 5L, 5 },
            { 6L, 6 },
            { 7L, 7 },
            { 8L, 7 },
            { 9L, 7 },
            { 10L, 7 },
            { 11L, 7 },
            { 12L, 7 },
        };

        private static Dictionary<long, int> itemIDToConsumable = new Dictionary<long, int>
        {
            { 0L, 0 },
            { 1L, 1 },
            { 2L, 2 },
            { 3L, 3 },
            { 4L, 4 },
            { 5L, 5 },
            { 6L, 6 }
        };

        private static Dictionary<long, int> itemIDToTrap = new Dictionary<long, int>
        {
            { 0L, 0 },
            { 1L, 1 },
            { 2L, 2 },
            { 3L, 3 },
            { 4L, 4 },
            { 5L, 5 },
            { 6L, 6 },
            { 7L, 7 }
        };

        private static PlayerController playerController;

        public static void SetPlayerController(PlayerController controller)
        {
            playerController = controller;
            return;
        }

        public static void DeathlinkKillPlayer(string causeOfDeath = "Deathlink")
        {
            ArchipelagoGUI.ConsoleLog("Die");

            AkSoundEngine.PostEvent("m_WPN_windupgun_reload_04", playerController.gameObject);

            playerController.healthHaver.lastIncurredDamageSource = causeOfDeath;
            playerController.Die(playerController.CenterPosition);
            return;
        }

        public static void GiveGungeonItem(long receivedItemID)
        {
            long categoryAdjustedID = receivedItemID - baseItemID;
            if (itemIDToPickUpItem.ContainsKey(categoryAdjustedID))
            {
                int itemCase = itemIDToPickUpItem[categoryAdjustedID];
                RandomizedByQualityItems.SpawnRandomizedItemByCase(itemCase);
            }

            categoryAdjustedID = receivedItemID - consumableCategoryItemID;
            if(itemIDToConsumable.ContainsKey(categoryAdjustedID))
            {
                int itemCase = itemIDToConsumable[categoryAdjustedID];
                ConsumableSpawnHandler.SpawnConsumableByCase(itemCase);
            }

            categoryAdjustedID = receivedItemID - trapCategoryItemID;
            if (itemIDToTrap.ContainsKey(categoryAdjustedID))
            {
                int trapCase = itemIDToTrap[categoryAdjustedID];
                TrapSpawnHandler.SpawnTrapByCase(trapCase);
            }

            return;
        }

        public static void SpawnAPItem(int numberToSpawn)
        {
            for(int i=0; i < numberToSpawn; i++)
            {
                GameObject archipelItem = PickupObjectDatabase.GetById(APPickUpItem.SpawnItemID).gameObject;
                LootEngine.SpawnItem(archipelItem, playerController.CenterPosition, Vector2.zero, 0);
            }

            return;
        }

        
    }

}

