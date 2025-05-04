using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using ArchiGungeon.DebugTools;
using Alexandria.Misc;

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


        public static void SpawnConsumableByCase(int itemCase)
        {
            if (IsSpawnValid == false)
            {
                return;
            }

            PlayerController playerToSpawnOn = GungeonPlayerEventListener.GetFirstAlivePlayer();
            EffectsController.PlaySynergyVFX();

            switch (itemCase)
            {
                case 0:
                    //ChestUtility.SpawnChestEasy(IntVector2.Up, ChestUtility.ChestTier.SYNERGY, false);

                    playerToSpawnOn.GiveItem("glass_guon_stone");
                    break;
                case 1:
                    playerToSpawnOn.GiveItem("50_casing");
                    break;
                case 2:
                    playerToSpawnOn.GiveItem("key");
                    break;
                case 3:
                    playerToSpawnOn.GiveItem("blank");
                    break;
                case 4:
                    playerToSpawnOn.GiveItem("armor");
                    break;
                case 5:
                    playerToSpawnOn.GiveItem("heart");
                    break;
                case 6:
                    playerToSpawnOn.GiveItem("ammo");
                    break;

                default:
                    ArchDebugPrint.DebugLog(DebugCategory.ItemHandling, $"Consumable received invalid ID: {itemCase}");
                    break;

            }


            return;
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

        public static void GivePlayerRandomGun(PickupObject.ItemQuality[] itemquals)
        {
            PlayerController playerToSpawnOn = GungeonPlayerEventListener.GetFirstAlivePlayer();
            Gun gunToGive = GetRandomGunByQualities(itemquals);

            ArchDebugPrint.DebugLog(DebugCategory.ItemHandling, $"Giving random gun: {gunToGive.name}");
            SpawnedItemLog.GunItems.Add(gunToGive);
            playerToSpawnOn.inventory.AddGunToInventory(gunToGive);

            return;
        }

        public static void GivePlayerRandomPassive(PickupObject.ItemQuality[] itemquals)
        {
            PlayerController playerToSpawnOn = GungeonPlayerEventListener.GetFirstAlivePlayer();
            PassiveItem passiveToSpawn = GetRandomPassiveByQualities(itemquals);

            ArchDebugPrint.DebugLog(DebugCategory.ItemHandling, $"Giving random passive: {passiveToSpawn.name}");
            SpawnedItemLog.PassiveItems.Add(passiveToSpawn);
            playerToSpawnOn.AcquirePassiveItem(passiveToSpawn);

            return;
        }

        public static void GiveRandomizedItemByCase(int itemCase)
        {
            EffectsController.PlaySynergyVFX();

            switch (itemCase)
            {
                case 0:
                    GivePlayerRandomGun(new PickupObject.ItemQuality[] { PickupObject.ItemQuality.D });
                    break;
                case 1:
                    GivePlayerRandomGun(new PickupObject.ItemQuality[] { PickupObject.ItemQuality.C });
                    break;
                case 2:
                    GivePlayerRandomGun(new PickupObject.ItemQuality[] { PickupObject.ItemQuality.B });
                    break;
                case 3:
                    GivePlayerRandomGun(new PickupObject.ItemQuality[] { PickupObject.ItemQuality.A });
                    break;
                case 4:
                    GivePlayerRandomGun(new PickupObject.ItemQuality[] { PickupObject.ItemQuality.S });
                    break;
                case 5:
                    GivePlayerRandomPassive(new PickupObject.ItemQuality[] { PickupObject.ItemQuality.D });
                    break;
                case 6:
                    GivePlayerRandomPassive(new PickupObject.ItemQuality[] { PickupObject.ItemQuality.C });
                    break;
                case 7:
                    GivePlayerRandomPassive(new PickupObject.ItemQuality[] { PickupObject.ItemQuality.B });
                    break;
                case 8:
                    GivePlayerRandomPassive(new PickupObject.ItemQuality[] { PickupObject.ItemQuality.A });
                    break;
                case 9:
                    GivePlayerRandomPassive(new PickupObject.ItemQuality[] { PickupObject.ItemQuality.S });
                    break;

                default:
                    ArchDebugPrint.DebugLog(DebugCategory.ItemHandling, $"Random Gun/Passive received invalid ID: {itemCase}");
                    break;
            }

            return;
        }

    }

    public class ProgressionItemSpawnHandler
    {
        public static void SpawnProgressionItem(int itemCase)
        {
            EffectsController.PlaySynergyVFX();

            switch (itemCase)
            {
                case 1:

                    SpawnedItemLog.ConsoleCommandGivenItems.Add("gnawed_key");
                    GungeonPlayerEventListener.GetFirstAlivePlayer().GiveItem("gnawed_key");

                    ArchDebugPrint.DebugLog(DebugCategory.ItemHandling, $"Giving gnawed key");

                    break;
                case 2:
                    SpawnedItemLog.ConsoleCommandGivenItems.Add("old_crest");
                    GungeonPlayerEventListener.GetFirstAlivePlayer().GiveItem("old_crest");

                    ArchDebugPrint.DebugLog(DebugCategory.ItemHandling, $"Giving Old Crest");

                    break;

                case 3:
                    SpawnedItemLog.ConsoleCommandGivenItems.Add("weird_egg");
                    GungeonPlayerEventListener.GetFirstAlivePlayer().GiveItem("weird_egg");

                    ArchDebugPrint.DebugLog(DebugCategory.ItemHandling, $"Spawning weird egg");
                    //ETGModConsole.SpawnItem(new string[] { "weird_egg", "1" });

                    break;

                default:
                    ArchDebugPrint.DebugLog(DebugCategory.ItemHandling, $"PROGRESSION received invalid ID: {itemCase}");
                    break;
            }

            return;
        }

        public static void GivePastBullet()
        {

            SpawnedItemLog.ConsoleCommandGivenItems.Add("bullet_that_can_kill_the_past");
            GungeonPlayerEventListener.GetFirstAlivePlayer().GiveItem("bullet_that_can_kill_the_past");

            ArchDebugPrint.DebugLog(DebugCategory.ItemHandling, $"Giving bullet");

            return;
        }

        public static void GiveRatNotes()
        {
            ArchDebugPrint.DebugLog(DebugCategory.ItemHandling, $"Giving Rat Notes");

            List<string> ratNoteItems = new List<string>()
            {
                "infuriating_note_1",
                "infuriating_note_2",
                "infuriating_note_3",
                "infuriating_note_4",
                "infuriating_note_5",
                "infuriating_note_6",
            };

            foreach(string note in ratNoteItems)
            {
                SpawnedItemLog.ConsoleCommandGivenItems.Add(note);
                GungeonPlayerEventListener.GetFirstAlivePlayer().GiveItem(note);
            }

            return;
        }

    }

    public class SpawnedItemLog
    {
        public static List<PassiveItem> PassiveItems { get; } = new List<PassiveItem>();
        public static List<Gun> GunItems { get; } = new List<Gun>();
        public static List<string> ConsoleCommandGivenItems { get; } = new List<string>();

        public static void ClearSpawnedItemLog()
        {
            ArchDebugPrint.DebugLog(DebugCategory.ItemHandling, "Clearing item log");
            PassiveItems.Clear();
            GunItems.Clear();
            ConsoleCommandGivenItems.Clear();
        }

        public static void GivePlayerMissingItemsFromLog(PlayerController player)
        {
            ArchDebugPrint.DebugLog(DebugCategory.ItemHandling, "Restoring player inventory");

            foreach(PassiveItem item in PassiveItems)
            {
                if(!player.HasPickupID(item.PickupObjectId))
                {
                    ArchDebugPrint.DebugLog(DebugCategory.ItemHandling, $"Restoring item: {item.name}");
                    item.suppressPickupVFX = true;

                    player.AcquirePassiveItemPrefabDirectly(item);
                }
            }

            foreach(Gun gunItem in GunItems)
            {
                if (!player.HasPickupID(gunItem.PickupObjectId))
                {   

                    ArchDebugPrint.DebugLog(DebugCategory.ItemHandling, $"Restoring item: {gunItem.name}");
                    player.inventory.AddGunToInventory(gunItem);
                }
            }

            foreach(string consoleItem in ConsoleCommandGivenItems)
            {

            }

            return;
        }
    }
}
