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

    public class PilotParadoxItem: PassiveItem
    {
        public static int SpawnItemID = -1;

        private static string displayName = "Pilot Identity";
        private static string spriteDirectory = "ArchiGungeon/Resources/identity_pilotV2.png";

        public static void RegisterItem()
        {
            ArchDebugPrint.DebugLog(DebugCategory.PluginStartup, "Registering Pilot Paradox");

            GameObject obj = new GameObject(displayName);
            var item = obj.AddComponent<PilotParadoxItem>();

            ItemBuilder.AddSpriteToObject(displayName, spriteDirectory, obj);

            ItemBuilder.SetupItem(item, "Be my wingman anytime", "Changes loadout and Past to the Pilot", ArchipelaGunPlugin.MOD_ITEM_PREFIX);

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
        public static void SetValidToPickup()
        {
            IsValid = false;
            return;
        }
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

            CharSwap.DoCharacterSwap(PlayableCharacters.Pilot, player);

            return;
        }


    }


}
