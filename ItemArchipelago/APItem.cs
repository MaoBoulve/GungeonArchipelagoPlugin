using Alexandria.ItemAPI;
using ArchiGungeon.Archipelago;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace ArchiGungeon.ItemArchipelago
{
    public class APItem: PassiveItem
    {
        public int GungeonAPItemSpawnID = -1;
        public long ArchipelagoItemID;
        private static string spriteDirectory = "ArchiGungeon/Resources/archipelago.png";
        private static string longDesc = "A mysterious item from another world";

        // Dynamically create APItem with names
        public static APItem RegisterAPItem(long itemIDstring, string passiveName = "APItem", string shortDesc = "Short Description")
        {
            GameObject obj = new GameObject(passiveName);
            var item = obj.AddComponent<APItem>();
            ItemBuilder.AddSpriteToObject(passiveName, spriteDirectory, obj);

            item.ArchipelagoItemID = itemIDstring;

            ItemBuilder.SetupItem(item, shortDesc, longDesc, ArchipelaGunPlugin.MOD_ITEM_PREFIX);

            item.CanBeDropped = false;
            item.CanBeSold = false;
            item.IgnoredByRat = true;

            item.GungeonAPItemSpawnID = PickupObjectDatabase.GetId(item);

            return item;
        }

        public override void Pickup(PlayerController player)
        {
            base.Pickup(player);

            SessionHandler.DataSender.SendFoundLocationCheck(this.ArchipelagoItemID);

            return;
        }

    }
}
