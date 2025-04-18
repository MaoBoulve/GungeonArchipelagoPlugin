﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace ArchiGungeon.GungeonEventHandlers
{
    public enum SpawnableConsumables
    {
        Casing50,
        Key,
        Blank,
        Armor,
        Heart,
        Ammo
    }

    public class ConsumableSpawnHandler
    {
        public static bool IsSpawnValid { get; protected set; } = true;

        public static void SetCanSpawn(bool newState)
        {
            IsSpawnValid = newState;
            return;
        }

        private static Dictionary<SpawnableConsumables, string> EnumToItemString { get; } = new Dictionary<SpawnableConsumables, string>()
        {
            {SpawnableConsumables.Casing50, "50_casing" },
            {SpawnableConsumables.Key, "key" },
            {SpawnableConsumables.Blank, "blank" },
            {SpawnableConsumables.Armor, "armor" },
            {SpawnableConsumables.Heart, "heart" },
            {SpawnableConsumables.Ammo, "ammo" }
        };

        public static void SpawnConsumable(SpawnableConsumables item, int numberToSpawn)
        {
            if(IsSpawnValid == false)
            {
                return;
            }

            string itemToSpawn = EnumToItemString[item];
            ETGModConsole.SpawnItem(new string[] { itemToSpawn, numberToSpawn.ToString() });

            return;
        }

        public static void SpawnConsumableByCase(int itemCase)
        {
            if (IsSpawnValid == false)
            {
                return;
            }

            EffectsController.PlaySynergyVFX();

            switch (itemCase)
            {
                case 0:
                    ETGModConsole.Spawn(new string[] { "chance_kin", "10" });
                    break;
                case 1:
                    SpawnConsumable(SpawnableConsumables.Casing50, 1);
                    break;
                case 2:
                    SpawnConsumable(SpawnableConsumables.Key, 1);
                    break;
                case 3:
                    SpawnConsumable(SpawnableConsumables.Blank, 1);
                    break;
                case 4:
                    SpawnConsumable(SpawnableConsumables.Armor, 1);
                    break;
                case 5:
                    SpawnConsumable(SpawnableConsumables.Heart, 1);
                    break;
                case 6:
                    SpawnConsumable(SpawnableConsumables.Ammo, 1);
                    break;

                default:
                    break;

            }
        }
    }

    public class RandomizedByQualityItems
    {
        private static System.Random random = new();

        private static Gun GetRandomGunByQualities(PickupObject.ItemQuality[] itemQuals)
        {
            Gun gunToReturn = PickupObjectDatabase.GetRandomGunOfQualities(random, new List<int>(), itemQuals);

            return gunToReturn;
        }

        private static PassiveItem GetRandomPassiveByQualities(PickupObject.ItemQuality[] itemQuals)
        {
            PassiveItem passiveItem = PickupObjectDatabase.GetRandomPassiveOfQualities(random, new List<int>(), itemQuals);

            return passiveItem;
        }

        public static void SpawnRandomGun(PickupObject.ItemQuality[] itemquals)
        {
            Vector2 spawnPosition = GameManager.Instance.PrimaryPlayer.CenterPosition;
            Vector2 spawnDirection = Vector2.down;
            float spawnForce = 0f;

            Gun gunToSpawn = GetRandomGunByQualities(itemquals);

            LootEngine.SpawnItem(gunToSpawn.gameObject, spawnPosition, spawnDirection, spawnForce);

            return;
        }

        public static void SpawnRandomPassive(PickupObject.ItemQuality[] itemquals)
        {
            Vector2 spawnPosition = GameManager.Instance.PrimaryPlayer.CenterPosition;
            Vector2 spawnDirection = Vector2.down;
            float spawnForce = 0f;

            PassiveItem passiveToSpawn = GetRandomPassiveByQualities(itemquals);

            LootEngine.SpawnItem(passiveToSpawn.gameObject, spawnPosition, spawnDirection, spawnForce);

            return;
        }

        public static void SpawnRandomizedItemByCase(int itemCase)
        {
            EffectsController.PlaySynergyVFX();

            switch (itemCase)
            {
                case 0:
                    SpawnRandomGun(new PickupObject.ItemQuality[] { PickupObject.ItemQuality.D });
                    break;
                case 1:
                    SpawnRandomGun(new PickupObject.ItemQuality[] { PickupObject.ItemQuality.C });
                    break;
                case 2:
                    SpawnRandomGun(new PickupObject.ItemQuality[] { PickupObject.ItemQuality.B });
                    break;
                case 3:
                    SpawnRandomGun(new PickupObject.ItemQuality[] { PickupObject.ItemQuality.A });
                    break;
                case 4:
                    SpawnRandomGun(new PickupObject.ItemQuality[] { PickupObject.ItemQuality.A });
                    break;
                case 5:
                    SpawnRandomPassive(new PickupObject.ItemQuality[] { PickupObject.ItemQuality.D });
                    break;
                case 6:
                    SpawnRandomPassive(new PickupObject.ItemQuality[] { PickupObject.ItemQuality.D });
                    break;
                case 7:
                    SpawnRandomPassive(new PickupObject.ItemQuality[] { PickupObject.ItemQuality.D });
                    break;
                case 8:
                    SpawnRandomPassive(new PickupObject.ItemQuality[] { PickupObject.ItemQuality.D });
                    break;
                case 9:
                    SpawnRandomPassive(new PickupObject.ItemQuality[] { PickupObject.ItemQuality.D });
                    break;
                case 10:
                    ETGModConsole.SpawnItem(new string[] { "gnawed_key", "1" });
                    break;
                case 11:
                    ETGModConsole.SpawnItem(new string[] { "old_crest", "1" });
                    break;
                case 12:
                    ETGModConsole.SpawnItem(new string[] { "weird_egg", "1" });
                    break;

                default:
                    break;
            }

            return;
        }
    }

}
