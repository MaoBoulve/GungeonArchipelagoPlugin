using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using ArchiGungeon.GungeonEventHandlers;
using ArchiGungeon.ItemArchipelago;
using ArchiGungeon.DebugTools;

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
            { 8L, 8 },
            { 9L, 9 },
            { 10L, 10 },
            { 11L, 11 },
            { 12L, 12 },
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

        private static PlayerController playerOne;
        private static PlayerController playerTwo;

        public static void SetPlayerOne(PlayerController controller)
        {
            playerOne = controller;
            return;
        }

        public static void SetPlayerTwo(PlayerController controller) 
        {
            playerTwo = controller;
            return;
        }

        public static void DeathlinkKillPlayer(string causeOfDeath = "Deathlink")
        {
            
            if(playerTwo != null)
            {
                if(playerTwo.healthHaver.IsAlive && playerOne.healthHaver.IsDead)
                {
                    DebugPrint.DebugLog(DebugCategory.ServerReceive, "Attempting to kill Player Two");

                    playerTwo.healthHaver.lastIncurredDamageSource = causeOfDeath;
                    playerTwo.healthHaver.Die(Vector2.zero);
                    return;
                }
                else if(playerTwo.healthHaver.IsAlive)
                {
                    DebugPrint.DebugLog(DebugCategory.ServerReceive, "Soft killing Player Two");

                    //playerTwo.healthHaver.ManualDeathHandling = true;
                    playerTwo.healthHaver.currentHealth = 0f;
                    playerTwo.healthHaver.lastIncurredDamageSource = causeOfDeath;
                    playerTwo.Fall();

                    return;
                }

            }

            DebugPrint.DebugLog(DebugCategory.ServerReceive, "Killing Player One");
            playerOne.healthHaver.lastIncurredDamageSource = causeOfDeath;
            playerOne.Die(Vector2.zero);

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
            PlayerController playerToSpawnOn;

            if(playerOne.healthHaver.IsAlive)
            {
                playerToSpawnOn = playerOne;
            }

            else if (playerTwo != null)
            {
                if(playerTwo.healthHaver.IsDead)
                {
                    return;
                }
                playerToSpawnOn = playerTwo;
            }

            else
            {
                return;
            }

            for(int i=0; i < numberToSpawn; i++)
            {
                GameObject archipelItem = PickupObjectDatabase.GetById(APPickUpItem.SpawnItemID).gameObject;
                LootEngine.SpawnItem(archipelItem, playerToSpawnOn.CenterPosition, Vector2.zero, 0);
            }

            return;
        }

        
    }

}

