using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using ArchiGungeon.DebugTools;
using Alexandria.Misc;
using ArchiGungeon.UserInterface;
using Alexandria.ItemAPI;
using ArchiGungeon.Data;

namespace ArchiGungeon.GungeonEventHandlers
{
    #region General Item Spawning
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
            // don't understand actives yet
            PassiveItem passiveItem = PickupObjectDatabase.GetRandomPassiveOfQualities(random, new List<int>(), itemQuals);
            return passiveItem;
        }


        public static void GivePlayerRandomGun(PickupObject.ItemQuality[] itemquals)
        {
            PlayerController playerToSpawnOn = GungeonPlayerEventListener.GetFirstAlivePlayer();
            Gun gunToGive = GetRandomGunByQualities(itemquals);

            ArchDebugPrint.DebugLog(DebugCategory.ItemHandling, $"Giving random gun: {gunToGive.name}");
            playerToSpawnOn.inventory.AddGunToInventory(gunToGive);

            return;
        }

        public static void GivePlayerRandomPassive(PickupObject.ItemQuality[] itemquals)
        {
            PlayerController playerToSpawnOn = GungeonPlayerEventListener.GetFirstAlivePlayer();
            PassiveItem passiveToSpawn = GetRandomPassiveByQualities(itemquals);

            //ArchipelagoGUI.ConsoleLog(passiveToSpawn.Cool);
            //ItemBuilder.SetCooldownType
            ArchDebugPrint.DebugLog(DebugCategory.ItemHandling, $"Giving random passive: {passiveToSpawn.name}");
            playerToSpawnOn.AcquirePassiveItem(passiveToSpawn);

            //SpawnObjectPlayerItem.ItemQuality.

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

    #endregion

    #region Progression Key Objects
    public class ProgressionItemSpawnHandler
    {
        public static void SpawnProgressionItem(int itemCase)
        {
            EffectsController.PlaySynergyVFX();

            switch (itemCase)
            {
                case 1:

                    GungeonPlayerEventListener.GetFirstAlivePlayer().GiveItem("gnawed_key");

                    ArchDebugPrint.DebugLog(DebugCategory.ItemHandling, $"Giving gnawed key");

                    break;
                case 2:
                    GungeonPlayerEventListener.GetFirstAlivePlayer().GiveItem("old_crest");

                    ArchDebugPrint.DebugLog(DebugCategory.ItemHandling, $"Giving Old Crest");

                    break;

                case 3:
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
                GungeonPlayerEventListener.GetFirstAlivePlayer().GiveItem(note);
            }

            return;
        }

    }
    #endregion

}
