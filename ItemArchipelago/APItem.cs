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
        public static int SpawnItemID = -1;
        private static List<long> locationIDs;

        private static string displayName = "AP Item";
        private static string spriteDirectory = "ArchiGungeon/Resources/archipelago.png";



        public static void RegisterItemBase()
        {
            GameObject obj = new GameObject(displayName);
            var item = obj.AddComponent<APItem>();

            ItemBuilder.AddSpriteToObject(displayName, spriteDirectory, obj);

            ItemBuilder.SetupItem(item, "A crossover!", "A cool item from another world", ArchipelaGunPlugin.MOD_ITEM_PREFIX);

            item.CanBeDropped = false;
            item.CanBeSold = false;
            item.IgnoredByRat = true;

            SpawnItemID = PickupObjectDatabase.GetId(item);
            ArchipelagoGUI.ConsoleLog("APItem spawn ID: " + SpawnItemID);

            return;
        }

        

        public static void RegisterLocationIDs(long[] serverLocationIDs)
        {
            locationIDs = serverLocationIDs.ToList<long>();

            return;
        }

        public override void Pickup(PlayerController player)
        {
            base.Pickup(player);

            if(locationIDs.Count > 0)
            {
                SessionHandler.DataSender.SendFoundLocationCheck(locationIDs[0]);

                locationIDs.RemoveAt(0);
            }

            
            return;
        }


    }
}
