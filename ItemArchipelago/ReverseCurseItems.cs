using Alexandria.ItemAPI;
using ArchiGungeon.ArchipelagoServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using ArchiGungeon.DebugTools;
using ArchiGungeon.Data;

namespace ArchiGungeon.ItemArchipelago
{

    public class ReverseCurse: PassiveItem
    {
        public static int SpawnItemID = -1;

        private static string displayName = "Reverse Curse";
        private static string spriteDirectory = "ArchiGungeon/Resources/reverseCurse.png";

        public static void RegisterItem()
        {
            ArchDebugPrint.DebugLog(DebugCategory.PluginStartup, "Registering Reverse Curse");

            GameObject obj = new GameObject(displayName);
            var item = obj.AddComponent<ReverseCurse>();

            ItemBuilder.AddSpriteToObject(displayName, spriteDirectory, obj);

            ItemBuilder.SetupItem(item, "Curses from beyond..", "Tainted objects from a world architect who chose to make things difficult. Adds 1 curse.", ArchipelaGunPlugin.MOD_ITEM_PREFIX);

            item.ShouldBeExcludedFromShops = true;
            item.CanBeDropped = false;
            item.CanBeSold = false;
            item.IgnoredByRat = true;
            item.quality = ItemQuality.EXCLUDED;

            ItemBuilder.AddPassiveStatModifier(item, PlayerStats.StatType.Curse, 1, StatModifier.ModifyMethod.ADDITIVE);

            SpawnItemID = PickupObjectDatabase.GetId(item);

            //ArchipelagoGUI.ConsoleLog("APItem spawn ID: " + SpawnItemID);

            return;
        }


        public override void Pickup(PlayerController player)
        {
            base.Pickup(player);

            //player. += 1;

            return;
        }


    }


    //Reverse Curse Reversal

    public class ReverseCurseReversal : PassiveItem
    {

        public static int SpawnItemID = -1;

        private static string displayName = "Reverse Curse Reversal";
        private static string spriteDirectory = "ArchiGungeon/Resources/reverseCurseReverse.png";

        public static void RegisterItem()
        {
            ArchDebugPrint.DebugLog(DebugCategory.PluginStartup, "Registering Reverse Curse Reversal");

            GameObject obj = new GameObject(displayName);
            var item = obj.AddComponent<ReverseCurseReversal>();

            ItemBuilder.AddSpriteToObject(displayName, spriteDirectory, obj);

            ItemBuilder.SetupItem(item, "Tried and true counter", "A technique to reverse another's sneaky attack. Ruins friendships. Removes 1 curse.", ArchipelaGunPlugin.MOD_ITEM_PREFIX);

            ItemBuilder.AddPassiveStatModifier(item, PlayerStats.StatType.Curse, -1, StatModifier.ModifyMethod.ADDITIVE);


            item.ShouldBeExcludedFromShops = true;
            item.CanBeDropped = false;
            item.CanBeSold = false;
            item.IgnoredByRat = true;
            item.quality = ItemQuality.EXCLUDED;

            SpawnItemID = PickupObjectDatabase.GetId(item);

            //ArchipelagoGUI.ConsoleLog("APItem spawn ID: " + SpawnItemID);

            return;
        }


        public override void Pickup(PlayerController player)
        {
            base.Pickup(player);

            return;
        }


    }


}
