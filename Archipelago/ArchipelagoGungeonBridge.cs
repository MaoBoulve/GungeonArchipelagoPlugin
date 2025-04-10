using ArchiGungeon.ItemArchipelago;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace ArchiGungeon.Archipelago
{
    public class ArchipelagoGungeonBridge
    {

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

        public static void GiveGungeonItem(long itemID)
        {
            Vector2 spawnPosition = GameManager.Instance.PrimaryPlayer.CenterPosition;
            long num3 = itemID;
            long num4 = num3 - 8754000;
            if ((ulong)num4 <= 12uL)
            {
                switch (num4)
                {
                    case 0L:
                        ReceivedLocationItemHandler.SpawnRandomGun(new PickupObject.ItemQuality[] { PickupObject.ItemQuality.D });
                        //LootEngine.SpawnItem((PickupObjectDatabase.GetRandomGunOfQualities(random, [], PickupObject.ItemQuality.D)).gameObject, spawnPosition, Vector2.down, 0f);
                        return;
                    case 1L:
                        ReceivedLocationItemHandler.SpawnRandomGun(new PickupObject.ItemQuality[] { PickupObject.ItemQuality.C });
                        return;
                    case 2L:
                        ReceivedLocationItemHandler.SpawnRandomGun(new PickupObject.ItemQuality[] { PickupObject.ItemQuality.B });
                        return;
                    case 3L:
                        ReceivedLocationItemHandler.SpawnRandomGun(new PickupObject.ItemQuality[] { PickupObject.ItemQuality.A });
                        return;
                    case 4L:
                        ReceivedLocationItemHandler.SpawnRandomGun(new PickupObject.ItemQuality[] { PickupObject.ItemQuality.S });
                        return;
                    case 5L:
                        ReceivedLocationItemHandler.SpawnRandomPassive(new PickupObject.ItemQuality[] { PickupObject.ItemQuality.D });
                        //LootEngine.SpawnItem((PickupObjectDatabase.GetRandomPassiveOfQualities(random, [], PickupObject.ItemQuality.D)).gameObject, spawnPosition, Vector2.down, 0f);
                        return;
                    case 6L:
                        ReceivedLocationItemHandler.SpawnRandomPassive(new PickupObject.ItemQuality[] { PickupObject.ItemQuality.C });
                        return;
                    case 7L:
                        ReceivedLocationItemHandler.SpawnRandomPassive(new PickupObject.ItemQuality[] { PickupObject.ItemQuality.B });
                        return;
                    case 8L:
                        ReceivedLocationItemHandler.SpawnRandomPassive(new PickupObject.ItemQuality[] { PickupObject.ItemQuality.A });
                        return;
                    case 9L:
                        ReceivedLocationItemHandler.SpawnRandomPassive(new PickupObject.ItemQuality[] { PickupObject.ItemQuality.S });
                        return;
                    case 10L:
                        ETGModConsole.SpawnItem(new string[] { "gnawed_key", "1" });
                        return;
                    case 11L:
                        ETGModConsole.SpawnItem(new string[] { "old_crest", "1" });
                        return;
                    case 12L:
                        ETGModConsole.SpawnItem(new string[] { "weird_egg", "1" });
                        return;
                }
            }
            long num5 = num3 - 8754100;
            if ((ulong)num5 <= 6uL)
            {
                switch (num5)
                {
                    case 0L:
                        ETGModConsole.Spawn(new string[] { "chance_kin", "10" });
                        return;
                    case 1L:
                        ETGModConsole.SpawnItem(new string[] { "50_casing", "1" });
                        return;
                    case 2L:
                        ETGModConsole.SpawnItem(new string[] { "key", "1" });
                        return;
                    case 3L:
                        ETGModConsole.SpawnItem(new string[] { "blank", "1" });
                        return;
                    case 4L:
                        ETGModConsole.SpawnItem(new string[] { "armor", "1" });
                        return;
                    case 5L:
                        ETGModConsole.SpawnItem(new string[] { "heart", "1" });
                        return;
                    case 6L:
                        ETGModConsole.SpawnItem(new string[] { "ammo", "1" });
                        return;
                }
            }
            long num6 = num3 - 8754200;
            if ((ulong)num6 <= 7uL)
            {
                switch (num6)
                {
                    case 0L:
                        ETGModConsole.Spawn(new string[] { "rat", "100" });
                        break;
                    case 1L:
                        ETGModConsole.Spawn(new string[] { "shelleton", "3" });
                        break;
                    case 2L:
                        ETGModConsole.Spawn(new string[] { "shotgrub", "3" });
                        break;
                    case 3L:
                        ETGModConsole.Spawn(new string[] { "tanker", "12" });
                        ETGModConsole.Spawn(new string[] { "professional", "2" });
                        break;
                    case 4L:
                        ETGModConsole.Spawn(new string[] { "hollowpoint", "6" });
                        ETGModConsole.Spawn(new string[] { "bombshee", "2" });
                        ETGModConsole.Spawn(new string[] { "gunreaper", "1" });
                        break;
                    case 5L:
                        ETGModConsole.Spawn(new string[] { "gun_nut", "1" });
                        ETGModConsole.Spawn(new string[] {"chain_gunner", "2"});
                        ETGModConsole.Spawn(new string[] { "spectral_gun_nut", "3" });
                        break;
                    case 6L:
                        ETGModConsole.Spawn(new string[] { "jamerlengo", "3" });
                        ETGModConsole.Spawn(new string[] { "spirat", "15" });
                        break;
                    case 7L:
                        GameManager.Instance.Dungeon.SpawnCurseReaper();
                        break;
                }
            }
        }

        public static void SpawnAPItem(int numberToSpawn)
        {
            for(int i=0; i < numberToSpawn; i++)
            {
                GameObject archipelItem = PickupObjectDatabase.GetById(APItem.SpawnItemID).gameObject;
                LootEngine.SpawnItem(archipelItem, playerController.CenterPosition, Vector2.zero, 0);
            }

            return;
        }
    }
}
