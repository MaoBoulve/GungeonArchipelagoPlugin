using Alexandria.ItemAPI;
using Alexandria.Misc;
using ArchiGungeon.ArchipelagoServer;
using ArchiGungeon.Data;
using ArchiGungeon.DebugTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace ArchiGungeon.Character
{

    public class HunterParadoxItem: PassiveItem
    {
        public static int SpawnItemID = -1;

        private static string displayName = "Hunter Identity";
        private static string spriteDirectory = "ArchiGungeon/Resources/identity_hunterV2.png";

        public static void RegisterItem()
        {
            ArchDebugPrint.DebugLog(DebugCategory.PluginStartup, "Registering Hunter paradox");

            GameObject obj = new GameObject(displayName);
            var item = obj.AddComponent<HunterParadoxItem>();

            ItemBuilder.AddSpriteToObject(displayName, spriteDirectory, obj);

            ItemBuilder.SetupItem(item, "You CAN pet this one", "Changes loadout and Past to the Hunter", ArchipelaGunPlugin.MOD_ITEM_PREFIX);

            item.ShouldBeExcludedFromShops = true;
            item.CanBeDropped = false;
            item.CanBeSold = false;
            item.IgnoredByRat = true;
            item.quality = ItemQuality.EXCLUDED;

            SpawnItemID = PickupObjectDatabase.GetId(item);
            CharSwap.OnCharacterSelected += SetInvalidToPickup;
            //ArchipelagoGUI.ConsoleLog("APItem spawn ID: " + SpawnItemID);

            return;
        }

        private static bool IsValid = true;
        private static void SetInvalidToPickup()
        {
            IsValid = false;
            return;
        }
        public override void Pickup(PlayerController player)
        {
            base.Pickup(player);


            if (!IsValid)
            {
                player.RemoveItemFromInventory(PickupObjectDatabase.GetById(SpawnItemID));
                return;
            }

            CharSwap.DoCharacterSwap(PlayableCharacters.Guide, player);

            return;
        }


    }


}
