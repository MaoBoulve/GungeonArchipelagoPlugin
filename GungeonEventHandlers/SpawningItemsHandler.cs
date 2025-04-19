using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using ArchiGungeon.DebugTools;
using Alexandria.ChestAPI;

namespace ArchiGungeon.GungeonEventHandlers
{
    public enum SpawnableConsumables
    {
        Casing50,
        Key,
        Blank,
        Armor,
        Heart,
        Ammo,
        GlassGuon
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
            {SpawnableConsumables.Ammo, "ammo" },
            {SpawnableConsumables.GlassGuon, "glass_guon_stone" }
        };

        public static void SpawnConsumable(SpawnableConsumables item, int numberToSpawn)
        {
            if(IsSpawnValid == false)
            {
                return;
            }

            string itemToSpawn = EnumToItemString[item];

            ArchDebugPrint.DebugLog(DebugCategory.ItemHandling, $"Spawning consumable: {numberToSpawn} {itemToSpawn}");

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
                    SpawnConsumable(SpawnableConsumables.GlassGuon, 5);
                    //ChestUtility.SpawnChestEasy(IntVector2.Up, ChestUtility.ChestTier.SYNERGY, false);
                    break;
                case 1:
                    SpawnConsumable(SpawnableConsumables.Casing50, 2);
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

            ArchDebugPrint.DebugLog(DebugCategory.ItemHandling, $"Spawning random gun: {gunToSpawn.name}");

            LootEngine.SpawnItem(gunToSpawn.gameObject, spawnPosition, spawnDirection, spawnForce);

            return;
        }

        public static void SpawnRandomPassive(PickupObject.ItemQuality[] itemquals)
        {
            Vector2 spawnPosition = GameManager.Instance.PrimaryPlayer.CenterPosition;
            Vector2 spawnDirection = Vector2.down;
            float spawnForce = 0f;

            PassiveItem passiveToSpawn = GetRandomPassiveByQualities(itemquals);

            ArchDebugPrint.DebugLog(DebugCategory.ItemHandling, $"Spawning random passive: {passiveToSpawn.name}");

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
                    ArchDebugPrint.DebugLog(DebugCategory.ItemHandling, $"Spawning gnawed key");
                    ETGModConsole.SpawnItem(new string[] { "gnawed_key", "1" });
                    break;
                case 11:
                    ArchDebugPrint.DebugLog(DebugCategory.ItemHandling, $"Spawning Old Crest");
                    ETGModConsole.SpawnItem(new string[] { "old_crest", "1" });
                    break;
                case 12:
                    ArchDebugPrint.DebugLog(DebugCategory.ItemHandling, $"Spawning weird egg");
                    ETGModConsole.SpawnItem(new string[] { "weird_egg", "1" });
                    break;

                default:
                    break;
            }

            return;
        }
    }

}
