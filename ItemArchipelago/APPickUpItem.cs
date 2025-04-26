using Alexandria.ItemAPI;
using ArchiGungeon.ArchipelagoServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using ArchiGungeon.DebugTools;

namespace ArchiGungeon.ItemArchipelago
{

    public class APPickUpItem: PassiveItem
    {
        private static long ChestAPItemStartID { get; } = 8755000;
        private static long ShopAPItemStartID { get; } = 8755100;

        private static List<long> chestLocationIDs;
        private static List<long> shopLocationIDs;

        public static int SpawnItemID = -1;
        private static List<long> locationIDs;

        private static string displayName = "AP Item";
        private static string spriteDirectory = "ArchiGungeon/Resources/archipelago.png";

        public static void RegisterItemBase()
        {
            ArchDebugPrint.DebugLog(DebugCategory.PluginStartup, "Registering APPickUpItem");

            GameObject obj = new GameObject(displayName);
            var item = obj.AddComponent<APPickUpItem>();

            ItemBuilder.AddSpriteToObject(displayName, spriteDirectory, obj);

            ItemBuilder.SetupItem(item, "A crossover!", "A cool item from another world", ArchipelaGunPlugin.MOD_ITEM_PREFIX);

            item.CanBeDropped = false;
            item.CanBeSold = false;
            item.IgnoredByRat = true;

            SpawnItemID = PickupObjectDatabase.GetId(item);

            //ArchipelagoGUI.ConsoleLog("APItem spawn ID: " + SpawnItemID);

            return;
        }

        
        public static void RegisterAPItemLocationIDs(int chestLocationCount, int shopLocationCount)
        {
            for (int i = 0; i < shopLocationCount; i++) 
            {
                shopLocationIDs.Add(ShopAPItemStartID + i);
            }

            for (int i = 0; i< chestLocationCount; i++)
            {
                chestLocationIDs.Add(ChestAPItemStartID + i);
            }

            return;
        }

        public static int GetBaseAPChestLocationChecks(int userOptionCase)
        {
            switch (userOptionCase)
            {
                case 0:
                    return 11;
                case 1:
                    return 16;
                case 2:
                    return 25;
                default:
                    return 16;
            }
        }

        public static int GetAPShopLocationChecks(int userOptionCase)
        {
            switch (userOptionCase)
            {
                case 0:
                    return 5;
                case 1:
                    return 9;
                case 2:
                    return 15;
                default:
                    return 15;
            }
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
                ArchDebugPrint.DebugLog(DebugCategory.ServerSend, $"Sending location ID {locationIDs[0]}");
                SessionHandler.DataSender.SendFoundLocationCheck(locationIDs[0]);

                locationIDs.RemoveAt(0);
            }

            
            return;
        }

        public static bool HasAPItemChecksRemaining()
        {
            return (locationIDs.Count > 0);
        }


    }
}
