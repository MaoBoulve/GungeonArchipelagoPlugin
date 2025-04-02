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
                        ReceivedLocationItemHandler.SpawnRandomGun([PickupObject.ItemQuality.D]);
                        //LootEngine.SpawnItem((PickupObjectDatabase.GetRandomGunOfQualities(random, [], PickupObject.ItemQuality.D)).gameObject, spawnPosition, Vector2.down, 0f);
                        return;
                    case 1L:
                        ReceivedLocationItemHandler.SpawnRandomGun([PickupObject.ItemQuality.C]);
                        return;
                    case 2L:
                        ReceivedLocationItemHandler.SpawnRandomGun([PickupObject.ItemQuality.B]);
                        return;
                    case 3L:
                        ReceivedLocationItemHandler.SpawnRandomGun([PickupObject.ItemQuality.A]);
                        return;
                    case 4L:
                        ReceivedLocationItemHandler.SpawnRandomGun([PickupObject.ItemQuality.S]);
                        return;
                    case 5L:
                        ReceivedLocationItemHandler.SpawnRandomPassive([PickupObject.ItemQuality.D]);
                        //LootEngine.SpawnItem((PickupObjectDatabase.GetRandomPassiveOfQualities(random, [], PickupObject.ItemQuality.D)).gameObject, spawnPosition, Vector2.down, 0f);
                        return;
                    case 6L:
                        ReceivedLocationItemHandler.SpawnRandomPassive([PickupObject.ItemQuality.C]);
                        return;
                    case 7L:
                        ReceivedLocationItemHandler.SpawnRandomPassive([PickupObject.ItemQuality.B]);
                        return;
                    case 8L:
                        ReceivedLocationItemHandler.SpawnRandomPassive([PickupObject.ItemQuality.A]);
                        return;
                    case 9L:
                        ReceivedLocationItemHandler.SpawnRandomPassive([PickupObject.ItemQuality.S]);
                        return;
                    case 10L:
                        ETGModConsole.SpawnItem(["gnawed_key", "1"]);
                        return;
                    case 11L:
                        ETGModConsole.SpawnItem(["old_crest", "1"]);
                        return;
                    case 12L:
                        ETGModConsole.SpawnItem(["weird_egg", "1"]);
                        return;
                }
            }
            long num5 = num3 - 8754100;
            if ((ulong)num5 <= 6uL)
            {
                switch (num5)
                {
                    case 0L:
                        ETGModConsole.Spawn(["chance_kin", "10"]);
                        return;
                    case 1L:
                        ETGModConsole.SpawnItem(["50_casing", "1"]);
                        return;
                    case 2L:
                        ETGModConsole.SpawnItem(["key", "1"]);
                        return;
                    case 3L:
                        ETGModConsole.SpawnItem(["blank", "1"]);
                        return;
                    case 4L:
                        ETGModConsole.SpawnItem(["armor", "1"]);
                        return;
                    case 5L:
                        ETGModConsole.SpawnItem(["heart", "1"]);
                        return;
                    case 6L:
                        ETGModConsole.SpawnItem(["ammo", "1"]);
                        return;
                }
            }
            long num6 = num3 - 8754200;
            if ((ulong)num6 <= 7uL)
            {
                switch (num6)
                {
                    case 0L:
                        ETGModConsole.Spawn(["rat", "100"]);
                        break;
                    case 1L:
                        ETGModConsole.Spawn(["shelleton", "3"]);
                        break;
                    case 2L:
                        ETGModConsole.Spawn(["shotgrub", "3"]);
                        break;
                    case 3L:
                        ETGModConsole.Spawn(["tanker", "12"]);
                        ETGModConsole.Spawn(["professional", "2"]);
                        break;
                    case 4L:
                        ETGModConsole.Spawn(["hollowpoint", "6"]);
                        ETGModConsole.Spawn(["bombshee", "2"]);
                        ETGModConsole.Spawn(["gunreaper", "1"]);
                        break;
                    case 5L:
                        ETGModConsole.Spawn(["gun_nut", "1"]);
                        ETGModConsole.Spawn(["chain_gunner", "2"]);
                        ETGModConsole.Spawn(["spectral_gun_nut", "3"]);
                        break;
                    case 6L:
                        ETGModConsole.Spawn(["jamerlengo", "3"]);
                        ETGModConsole.Spawn(["spirat", "15"]);
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
