using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alexandria.ItemAPI;
using ArchiGungeon.Archipelago;
using UnityEngine;

namespace ArchiGungeon.NPC
{
    public class OldArchipelagoMenuCreator: PlayerItem
    {
        public static int SpawnItemID = -1;


        private static string customItemName = "APItem";
        private static string spriteDirectory = "ArchiGungeon/Resources/archipelago.png";

        private static string shortDesc = "TKTKTK";
        private static string longDesc = "TKTKTK";

        public static void Register()
        {
            

            GameObject obj = new GameObject(customItemName);
            var item = obj.AddComponent<OldArchipelagoMenuCreator>();
            ItemBuilder.AddSpriteToObject(customItemName, spriteDirectory, obj);

            
            ItemBuilder.SetupItem(item, shortDesc, longDesc, Plugin.MOD_ITEM_PREFIX);
            ItemBuilder.SetCooldownType(item, ItemBuilder.CooldownType.None, 0f);

            item.quality = PickupObject.ItemQuality.EXCLUDED;
            item.consumable = false;
            item.CanBeDropped = false;
            item.CanBeSold = false;
            item.ShouldBeExcludedFromShops = true;

            SpawnItemID = PickupObjectDatabase.GetId(item);

        }

        public override void Pickup(PlayerController player)
        {
            base.Pickup(player);
        }

        public override void DoEffect(PlayerController user)
        {

            ArchipelagoGUI.Instance?.OnOpen();
            //user.carriedConsumables.Currency += 15;

            return;
        }


    }
}
