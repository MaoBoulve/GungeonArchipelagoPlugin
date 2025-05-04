using Alexandria.ItemAPI;
using ArchiGungeon.ArchipelagoServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using ArchiGungeon.DebugTools;
using Archipelago.MultiClient.Net.Models;

namespace ArchiGungeon.ItemArchipelago
{

    public class APPickUpItem: PassiveItem
    {
        private static long APItemStartID { get; } = 8755000;

        private static List<long> remainingLocationIDs = new List<long>();

        public static int SpawnItemID = -1;

        private static string displayName = "AP Item";
        private static string spriteDirectory = "ArchiGungeon/Resources/archipelago.png";

        public static void RegisterItemBase()
        {
            ArchDebugPrint.DebugLog(DebugCategory.PluginStartup, "Registering APPickUpItem");

            GameObject obj = new GameObject(displayName);
            var item = obj.AddComponent<APPickUpItem>();

            ItemBuilder.AddSpriteToObject(displayName, spriteDirectory, obj);

            ItemBuilder.SetupItem(item, "A crossover!", "A cool item from another world", ArchipelaGunPlugin.MOD_ITEM_PREFIX);

            item.ShouldBeExcludedFromShops = true;
            item.CanBeDropped = false;
            item.CanBeSold = false;
            item.IgnoredByRat = true;
            item.quality = ItemQuality.EXCLUDED;

            SpawnItemID = PickupObjectDatabase.GetId(item);

            //ArchipelagoGUI.ConsoleLog("APItem spawn ID: " + SpawnItemID);

            return;
        }


        public static void RegisterAPItemLocations(int APItemCount)
        {
            for (int i = 0; i < APItemCount; i++)
            {
                remainingLocationIDs.Add(APItemStartID + i);
            }

  
            var locationID = SessionHandler.Session.Locations.AllLocationsChecked;

            foreach(long item in locationID)
            {
                if(remainingLocationIDs.Contains(item))
                {
                    ArchDebugPrint.DebugLog(DebugCategory.ItemHandling, "APItem Location Check already cleared: " + item);
                    remainingLocationIDs.Remove(item);
                }
            }
           

            return;
        }


        public static int GetBaseAPItemAmount(int userOptionCase)
        {
            switch (userOptionCase)
            {
                case 0:
                    return 16;
                case 1:
                    return 25;
                case 2:
                    return 40;
                default:
                    return 25;
            }
        }

        public override void Pickup(PlayerController player)
        {
            base.Pickup(player);

            if(remainingLocationIDs.Count > 0)
            {
                ArchDebugPrint.DebugLog(DebugCategory.ServerSend, $"Sending location ID {remainingLocationIDs[0]}");
                SessionHandler.DataSender.SendFoundLocationCheck(remainingLocationIDs[0]);

                remainingLocationIDs.RemoveAt(0);
            }

            //handle edge case of user finishing items
            
            return;
        }

        public static bool HasAPItemChecksRemaining()
        {
            return (remainingLocationIDs.Count > 0);
        }


    }
}
