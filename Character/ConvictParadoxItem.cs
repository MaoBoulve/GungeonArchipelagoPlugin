using Alexandria.ItemAPI;
using ArchiGungeon.ArchipelagoServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using ArchiGungeon.DebugTools;

namespace ArchiGungeon.Character
{

    public class ConvictParadoxItem: PassiveItem
    {
        public static int SpawnItemID = -1;

        private static string displayName = "Convict Identity";
        private static string spriteDirectory = "ArchiGungeon/Resources/identity_convictV2.png";

        public static void RegisterItem()
        {
            ArchDebugPrint.DebugLog(DebugCategory.PluginStartup, "Registering Convict paradox");

            GameObject obj = new GameObject(displayName);
            var item = obj.AddComponent<ConvictParadoxItem>();

            ItemBuilder.AddSpriteToObject(displayName, spriteDirectory, obj);

            ItemBuilder.SetupItem(item, "Laser Lily till I die", "Changes loadout and Past to the Convict", ArchipelaGunPlugin.MOD_ITEM_PREFIX);

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

            CharSwap.DoCharacterSwap(PlayableCharacters.Convict, player);

            return;
        }


    }




}
