using Alexandria.ItemAPI;
using ArchiGungeon.ArchipelagoServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using ArchiGungeon.DebugTools;
using ArchiGungeon.Data;
using Alexandria.Misc;

namespace ArchiGungeon.Character
{

    public class BulletParadoxItem: PassiveItem
    {
        private static bool IsValid = true;
        public static int SpawnItemID = -1;

        private static string displayName = "Bullet Identity";
        private static string spriteDirectory = "ArchiGungeon/Resources/identity_bulletV2.png";

        public static void RegisterItem()
        {
            ArchDebugPrint.DebugLog(DebugCategory.PluginStartup, "Registering Bullet");

            GameObject obj = new GameObject(displayName);
            var item = obj.AddComponent<BulletParadoxItem>();

            ItemBuilder.AddSpriteToObject(displayName, spriteDirectory, obj);

            ItemBuilder.SetupItem(item, "Breath of the Gunsmoke", "Changes loadout and Past to the Bullet", ArchipelaGunPlugin.MOD_ITEM_PREFIX);

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
            

            CharSwap.DoCharacterSwap(PlayableCharacters.Bullet, player);

            return;
        }


    }


}
