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

    public class BulletParadoxItem: PassiveItem
    {
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

            //ArchipelagoGUI.ConsoleLog("APItem spawn ID: " + SpawnItemID);

            return;
        }


        public override void Pickup(PlayerController player)
        {
            base.Pickup(player);

            CharSwap.DoCharacterSwap(PlayableCharacters.Soldier, player);

            return;
        }


    }


}
