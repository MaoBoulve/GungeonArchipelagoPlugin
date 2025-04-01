using Archipelago.MultiClient.Net;
using Archipelago.MultiClient.Net.Enums;
using Archipelago.MultiClient.Net.Helpers;
using Archipelago.MultiClient.Net.MessageLog.Messages;
using Archipelago.MultiClient.Net.Models;
using Archipelago.MultiClient.Net.Packets;
using Archipelago.MultiClient.Net.BounceFeatures.DeathLink;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Collections;
using Newtonsoft.Json.Linq;
using ArchiGungeon.ItemArchipelago;
using System.Collections.ObjectModel;

namespace ArchiGungeon.Archipelago
{

    public class SessionHandler:MonoBehaviour
    {
        // Summary:
        // The current instance of the console.
        public static SessionHandler Instance { get; protected set; }

        public readonly int location_check_initial_ID = 8755000;

        //public static Dictionary<string, int> server_slot_data = new Dictionary<string, int>();
        public static ArchipelagoSession session;
        public static DeathLinkService deathLinkService;
        public static bool RetrievedServerItemsThisRun = false;

        private static List<long> item_add_queue = new();
        public static bool allow_traps = false;

        private static List<APItem> remainingAPItems;

        public SessionHandler()
        {
            Instance = this;
        }

        public void ArchipelagoConnect(string ip, string port, string name)
        {
            allow_traps = false;
            // check for session already in progress
            if (session != null && session.Socket.Connected)
            {
                ArchipelagoGUI.ConsoleLog("You are already connected!");
                return;
            }

            ArchipelagoGUI.ConsoleLog($"Connecting to {ip}:{port} as {name}");
            LoginResult loginResult;

            // Handle try login
            try
            {
                loginResult = LoginToArchipelago(ip, port, name);
            }
            catch (Exception ex)
            {
                loginResult = new LoginFailure(ex.GetBaseException().Message);
            }

            if (!loginResult.Successful)
            {
                ParseLoginError(ip, port, name, loginResult);
                return;
            }

            // Success after this point

            BindToArchipelagoEvents();

            LoginSuccessful loginSuccessful = (LoginSuccessful)loginResult;
            PlayerPersistentDataHandler.SaveArchipelagoConnectionSettings(ip, port, name);

            InitializeServerDataStorage();
            InitializeAPItems();

            allow_traps = true;
            ArchipelagoGUI.ConsoleLog("Connected to Archipelago server.");

            return;
        }

        private static LoginResult LoginToArchipelago(string ip, string port, string name)
        {
            session = ArchipelagoSessionFactory.CreateSession(ip, int.Parse(port));

            LoginResult loginResult = session.TryConnectAndLogin("Enter The Gungeon", name, ItemsHandlingFlags.IncludeOwnItems);
            return loginResult;
        }

        
        private static void ParseLoginError(string ip, string port, string name, LoginResult loginResult)
        {
            LoginFailure loginFailure = (LoginFailure)loginResult;

            string text = "Failed to Connect to " + ip + ":" + port + " as " + name;
            string[] errors = loginFailure.Errors;

            foreach (string text2 in errors)
            {
                text = text + "\n    " + text2;
            }
            ConnectionRefusedError[] errorCodes = loginFailure.ErrorCodes;
            foreach (ConnectionRefusedError connectionRefusedError in errorCodes)
            {
                text += $"\n    {connectionRefusedError}";
            }
            ArchipelagoGUI.ConsoleLog(text);

            return;
        }


        private static void BindToArchipelagoEvents()
        {
            Dictionary<string, object> slotData = session.DataStorage.GetSlotData();
            foreach (string key in slotData.Keys)
            {
                ArchipelagoGUI.ConsoleLog($"KEY: {key} -- VALUE: {slotData[key]}");
            }
            
            // binds
            session.Socket.PacketReceived += DataReceiver.OnPacketReceived;
            session.Items.ItemReceived += DataReceiver.OnItemReceived;
            session.MessageLog.OnMessageReceived += DataReceiver.OnMessageReceived;

            
            // deathlink
            if (Convert.ToInt32(slotData["DeathLink"]) == 1)
            {
                InitializeDeathlink(true);
                ArchipelagoGUI.ConsoleLog("Deathlink ON");
            }
            else
            {
                ArchipelagoGUI.ConsoleLog("Deathlink off");
            }

           

            return;
        }

        private static void InitializeDeathlink(bool isDeathlinkEnabled)
        {
            deathLinkService = session.CreateDeathLinkService();

            if (isDeathlinkEnabled)
            {
                deathLinkService.EnableDeathLink();
            }

            deathLinkService.OnDeathLinkReceived += DataReceiver.OnDeathlink;

            return;
        }


        private static void InitializeServerDataStorage()
        {
            session.DataStorage[Scope.Slot, "ChestsOpened"].Initialize(0);
            session.DataStorage[Scope.Slot, "Blobulord Killed"].Initialize(0);
            session.DataStorage[Scope.Slot, "Old King Killed"].Initialize(0);
            session.DataStorage[Scope.Slot, "Resourceful Rat Killed"].Initialize(0);
            session.DataStorage[Scope.Slot, "Agunim Killed"].Initialize(0);
            session.DataStorage[Scope.Slot, "Dragun Killed"].Initialize(0);
            session.DataStorage[Scope.Slot, "Advanced Dragun Killed"].Initialize(0);
            session.DataStorage[Scope.Slot, "Lich Killed"].Initialize(0);

            // session.DataStorage[Scope.Slot, "ChestsOpened"].OnValueChanged += DataSender.OnLocationCheckChestOpened;
        }

        public static void RetrieveServerItems()
        {
            allow_traps = false;
            if (session == null)
            {
                ArchipelagoGUI.ConsoleLog("ERROR: Not connected to Archipelago!");
                return;
            }
            if (RetrievedServerItemsThisRun)
            {
                ArchipelagoGUI.ConsoleLog("ERROR: Server items already retrieved!");
                return;
            }

            RetrievedServerItemsThisRun = true;

            ArchipelagoGUI.ConsoleLog("Retrieving server items!");

            foreach (var item in session.Items.AllItemsReceived)
            {
                AddItemToLocalGungeon(item);
            }

            allow_traps = true;

            return;
        }

        public static void AddItemToLocalGungeon(ItemInfo itemInfo)
        {
            if (allow_traps || (!allow_traps && itemInfo.ItemId < 8754200))
            {
                //GungeonControl.GiveGungeonItem(itemInfo.ItemId);
                item_add_queue.Add(itemInfo.ItemId);
            }

            return;
        }

        public static void OutputGameGoalStatus()
        {
            if (session == null)
            {
                ArchipelagoGUI.ConsoleLog("ERROR: Not connected to Archipelago!");
                return;
            }

            //ArchipelagoGUI.ConsoleLog("Blobby");
            if (session.DataStorage[Scope.Slot, "Blobulord Goal"] == 1)
            {
                ArchipelagoGUI.ConsoleLog($"Blobulord killed: {(bool)session.DataStorage[Scope.Slot, "Blobulord Killed"]}");
            }

            //ArchipelagoGUI.ConsoleLog("Old");
            if (session.DataStorage[Scope.Slot, "Old King Goal"] == 1)
            {
                ArchipelagoGUI.ConsoleLog($"Old King killed: {(bool)session.DataStorage[Scope.Slot, "Old King Killed"]}");
            }

            //ArchipelagoGUI.ConsoleLog("RAT");
            if (session.DataStorage[Scope.Slot, "Resourceful Rat Goal"] == 1)
            {
                ArchipelagoGUI.ConsoleLog($"Resourceful Rat killed: {(bool)session.DataStorage[Scope.Slot, "Resourceful Rat Killed"]}");
            }

            //ArchipelagoGUI.ConsoleLog("Agunim");
            if (session.DataStorage[Scope.Slot, "Agunim Goal"] == 1)
            {
                ArchipelagoGUI.ConsoleLog($"Liquid Agunim killed: {(bool)session.DataStorage[Scope.Slot, "Agunim Killed"]}");
            }

            //ArchipelagoGUI.ConsoleLog("Advanced Dwagun");
            if (session.DataStorage[Scope.Slot, "Advanced Dragun Goal"] == 1)
            {
                ArchipelagoGUI.ConsoleLog($"Advanced Dragun killed: {(bool)session.DataStorage[Scope.Slot, "Advanced Dragun Killed"]}");
            }

            //ArchipelagoGUI.ConsoleLog("Main game goal");
            if (session.DataStorage[Scope.Slot, "Goal"] == 0)
            {
                ArchipelagoGUI.ConsoleLog($"Dragun killed: {(bool)session.DataStorage[Scope.Slot, "Dragun Killed"]}");
            }

            //if (session.DataStorage[Scope.Slot, "Goal"] == 1)
            {
                ArchipelagoGUI.ConsoleLog($"Lich killed: {(bool)session.DataStorage[Scope.Slot, "Lich Killed"]}");
            }

            return;
        }

        public void Update()
        {
            if (item_add_queue.Count > 0)
            {
                ArchipelagoGungeonBridge.GiveGungeonItem(item_add_queue[0]);
                item_add_queue.RemoveAt(0);
            }

            return;
        }

        private static void InitializeAPItems()
        {
            //TODO: pull from json file to reduce heavy calls

            ReadOnlyCollection<long> serverRemainingLocations = session.Locations.AllMissingLocations;
            long[] locationIDs = serverRemainingLocations.ToArray<long>();  
            

            DataSender.CreateAPItemsFromLocationIDs(locationIDs);
            return ;
        }

        public static APItem GetNextAPItem()
        {
            APItem itemToPop = remainingAPItems[0];
            remainingAPItems.RemoveAt(0);

            return itemToPop;

        }

        public class DataSender
        {

            public static void SendFoundLocationCheck(string locationName)
            {
                long locationID = session.Locations.GetLocationIdFromName("Enter the Gungeon", locationName);
                session.Locations.CompleteLocationChecks(locationID);
                return;
            }

            public static void SendFoundLocationCheck(long idToSend)
            {
                session.Locations.CompleteLocationChecks(idToSend);

                return;
            }


            public static void SendDeathlink(string playerName = "Gungeoneer", string causeOfDeath = "Died to Gungeon")
            {
                if(deathLinkService == null)
                {
                    ArchipelagoGUI.ConsoleLog("Tried to send Deathlink but not connected!");
                    return;
                }

                string deathName = ConnectionSettings.PlayerName;

                deathLinkService.SendDeathLink(new DeathLink(deathName, causeOfDeath));
                return;
            }

            public static void SendGoalCompletion(string goalName)
            {
                session.DataStorage[Scope.Slot, goalName] = 1;

                if ((session.DataStorage[Scope.Slot, "Blobulord Goal"] != 1 || (bool)session.DataStorage[Scope.Slot, "Blobulord Killed"]) && (session.DataStorage[Scope.Slot, "Old King Goal"] != 1 || (bool)session.DataStorage[Scope.Slot, "Old King Killed"]) && (session.DataStorage[Scope.Slot, "Resourceful Rat Goal"] != 1 || (bool)session.DataStorage[Scope.Slot, "Resourceful Rat Killed"]) && (session.DataStorage[Scope.Slot, "Agunim Goal"] != 1 || (bool)session.DataStorage[Scope.Slot, "Agunim Killed"]) && (session.DataStorage[Scope.Slot, "Advanced Dragun Goal"] != 1 || (bool)session.DataStorage[Scope.Slot, "Advanced Dragun Killed"]) && (session.DataStorage[Scope.Slot, "Goal"] != 0 || (bool)session.DataStorage[Scope.Slot, "Dragun Killed"]) && (session.DataStorage[Scope.Slot, "Goal"] != 1 || (bool)session.DataStorage[Scope.Slot, "Lich Killed"]))
                {
                    SendGameCompletion();
                }

                return;
            }

            public static void SendGameCompletion()
            {
                StatusUpdatePacket statusUpdatePacket = new StatusUpdatePacket();
                statusUpdatePacket.Status = ArchipelagoClientState.ClientGoal;
                session.Socket.SendPacket(statusUpdatePacket);
                return;
            }

            public static void SendChatMessage(string message)
            {
                session.Socket.SendPacketAsync(new SayPacket
                {
                    Text = message
                });
            }

            public static void ParseOpenedChestToLocationCheck()
            {
                session.DataStorage[Scope.Slot, "ChestsOpened"] += 1;

                long locationCheckCompleted = session.DataStorage[Scope.Slot, "ChestsOpened"] + SessionHandler.Instance.location_check_initial_ID;

                string locationName = session.Locations.GetLocationNameFromId(locationCheckCompleted) ?? $"Location: {locationCheckCompleted}";

                session.Locations.ScoutLocationsAsync(locationInfoPacket => PrintScoutedLocationInfo(locationInfoPacket), 
                    [locationCheckCompleted]);

                ArchipelagoGUI.ConsoleLog($"{locationCheckCompleted} is location: {locationName}");

                //SendFoundLocationCheck(locationCheckCompleted);
            }

            private static void PrintScoutedLocationInfo(Dictionary<long, ScoutedItemInfo> scoutedInfo)
            {
                foreach(long key in scoutedInfo.Keys)
                {
                    ArchipelagoGUI.ConsoleLog($"ID: {key} Item: {scoutedInfo[key].Player}'s + {scoutedInfo[key].ItemName}");
                }    
                
            }

            /*
            public static void OnLocationCheckChestOpened(JToken previousChestId, JToken newChestId, Dictionary<string, JToken> additionalArguments)
            {
                for (int locationChecks = 0; locationChecks < newChestId.ToObject<int>(); locationChecks++)
                {
                    SendFoundLocationCheck(SessionHandler.Instance.location_check_initial_ID + locationChecks);
                }

                return;
            }
            */

            public static void CreateAPItemsFromLocationIDs(long[] locationIDs)
            {
                session.Locations.ScoutLocationsAsync(locationInfoPacket => DataReceiver.OnScoutedItemLocationReceived(locationInfoPacket),
                    locationIDs);

                return;
            }

        }

        public class DataReceiver
        {

            public static void OnPacketReceived(ArchipelagoPacketBase packet)
            {

                // ArchipelagoGUI.ConsoleLog(packet);

                /*
                if (packet is ItemPrintJsonPacket)
                {
                    ItemPrintJsonPacket itemPrintJsonPacket = (ItemPrintJsonPacket)packet;
                    if (itemPrintJsonPacket.ReceivingPlayer == session.ConnectionInfo.Slot || session.Locations.AllLocations.Contains(itemPrintJsonPacket.Item.Location))
                    {
                        string game = session.Players.Players[session.ConnectionInfo.Team][itemPrintJsonPacket.Item.Player].Game;
                        string game2 = session.Players.Players[session.ConnectionInfo.Team][itemPrintJsonPacket.ReceivingPlayer].Game;
                        ArchipelagoPickupNotification(session.Players.GetPlayerName(itemPrintJsonPacket.ReceivingPlayer) + " got " + session.Items.GetItemName(itemPrintJsonPacket.Item.Item, game2), "from " + session.Locations.GetLocationNameFromId(itemPrintJsonPacket.Item.Location, game));
                    }
                }
                */
            }


            public static void OnDeathlink(DeathLink deathLink)
            {
                string playerCauser = deathLink.Source;

                string deathlinkCause = $"Deathlink by {playerCauser}";

                ArchipelagoGungeonBridge.DeathlinkKillPlayer(deathlinkCause);
                return;
            }


            public static void OnItemReceived(ReceivedItemsHelper helper)
            {
                ItemInfo itemInfo = helper.PeekItem();

                //ArchipelagoGUI.ConsoleLog(itemInfo.ItemId);
                AddItemToLocalGungeon(itemInfo);

                helper.DequeueItem();
                
                /*
                ItemInfo itemInfo = helper.PeekItem();
                if (allow_traps || (!allow_traps && itemInfo.ItemId < 8754200))
                {
                    items_received.Add(itemInfo.ItemId);
                }
                helper.DequeueItem();
                */

                return;
            }

            
            public static void OnMessageReceived(LogMessage message)
            {
                ArchipelagoGUI.ConsoleLog(message.ToString());
            }

            public static void OnScoutedItemLocationReceived(Dictionary<long, ScoutedItemInfo> scoutedInfo)
            {
                System.Random random = new();

                foreach (long key in scoutedInfo.Keys)
                {
                    ArchipelagoGUI.ConsoleLog($"ID: {key} Item: {scoutedInfo[key].Player}'s + {scoutedInfo[key].ItemName}");
                    string itemName = $"{scoutedInfo[key].Player}'s + {scoutedInfo[key].ItemName}";

                    int randomIndex = random.Next(0, APItemData.itemFunnyPrefix.Length);

                    string shortDesc = $"{APItemData.itemFunnyPrefix[randomIndex]} item from {scoutedInfo[key].ItemGame}";

                    remainingAPItems.Add(APItem.RegisterAPItem(key, passiveName: itemName, shortDesc: shortDesc));
                }

                return;
            }
        }

    }
}
