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

        public static ArchipelagoSession session { get; protected set; }
        private static Dictionary<string, object> archipelago_slot_save_data = new Dictionary<string, object>();

        // TEMP MILESTONE VALUES
        private static int nextOpenedChestGoal;
        private static int[] openedChestMilestones = { 1, 2, 3, 5, 8, 13, 21};
        private static int nextRoomPointsGoal;
        private static int[] clearedRoomPointMilestones = { 1, 2, 6, 24, 120, 720, 5040};

        public static DeathLinkService deathLinkService;
        public static bool RetrievedServerItemsThisRun = false;

        private static List<long> item_add_queue = new();
        private static bool allow_traps = false;

        
        public SessionHandler()
        {
            Instance = this;
        }

        public void ArchipelagoConnect(string ip, string port, string name, string password = null)
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
                loginResult = LoginToArchipelago(ip, port, name, password: password);
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
            //LoginSuccessful loginSuccessful = (LoginSuccessful)loginResult;

            InitializeServerDataStorage();
            PullLatestServerSlotSaveData();

            BindToArchipelagoEvents();
            CheckToCreateDeathlink();

            // todo > write stuff to JSON
            PlayerPersistentDataHandler.SaveArchipelagoConnectionSettings(ip, port, name);

            
            InitializeAPItems();
            allow_traps = true;

            ArchipelagoGUI.ConsoleLog("Connected to Archipelago server.");

            return;
        }

        private static LoginResult LoginToArchipelago(string ip, string port, string name, string password = null)
        {
            session = ArchipelagoSessionFactory.CreateSession(ip, int.Parse(port));
            LoginResult loginResult;

            if (password == null || password == "")
            {
                loginResult = session.TryConnectAndLogin("Enter The Gungeon", name, ItemsHandlingFlags.IncludeOwnItems);
            }

            else
            {
                loginResult = session.TryConnectAndLogin("Enter The Gungeon", name, ItemsHandlingFlags.IncludeOwnItems, password: password);
            }

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

        private static void InitializeServerDataStorage()
        {
            // todo: test if can write new etire entry
            session.DataStorage[Scope.Slot, "ChestsOpened"].Initialize(0);
            session.DataStorage[Scope.Slot, "ChestsOpened"].OnValueChanged += DataReceiver.OnChestsOpenedValueChange;
            session.DataStorage[Scope.Slot, "NextGoalChestsOpened"].Initialize(1);

            session.DataStorage[Scope.Slot, "RoomPoints"].Initialize(0);
            session.DataStorage[Scope.Slot, "RoomPoints"].OnValueChanged += DataReceiver.OnRoomPointsValueChange;
            session.DataStorage[Scope.Slot, "NextGoalRoomPoints"].Initialize(1);

            // GAME COMPLETION
            session.DataStorage[Scope.Slot, "Blobulord Killed"].Initialize(0);
            session.DataStorage[Scope.Slot, "Old King Killed"].Initialize(0);
            session.DataStorage[Scope.Slot, "Resourceful Rat Killed"].Initialize(0);
            session.DataStorage[Scope.Slot, "Agunim Killed"].Initialize(0);
            session.DataStorage[Scope.Slot, "Dragun Killed"].Initialize(0);
            session.DataStorage[Scope.Slot, "Advanced Dragun Killed"].Initialize(0);
            session.DataStorage[Scope.Slot, "Lich Killed"].Initialize(0);

            
        }

        private static void PullLatestServerSlotSaveData()
        {
            archipelago_slot_save_data = session.DataStorage.GetSlotData();

            nextOpenedChestGoal = Convert.ToInt32((object)session.DataStorage[Scope.Slot, "NextGoalChestsOpened"]);
            nextRoomPointsGoal = Convert.ToInt32((object)session.DataStorage[Scope.Slot, "NextGoalRoomPoints"]);

            foreach (string key in archipelago_slot_save_data.Keys)
            {
                ArchipelagoGUI.ConsoleLog($"KEY: {key} -- VALUE: {archipelago_slot_save_data[key]}");
            }
        }


        private static void BindToArchipelagoEvents()
        {
            // binds
            session.Socket.PacketReceived += DataReceiver.OnPacketReceived;
            session.Items.ItemReceived += DataReceiver.OnItemReceived;
            session.MessageLog.OnMessageReceived += DataReceiver.OnMessageReceived;

            return;
        }



        private static void CheckToCreateDeathlink()
        {
            // deathlink
            if (Convert.ToInt32(archipelago_slot_save_data["DeathLink"]) == 1)
            {
                InitializeDeathlink(true);
                ArchipelagoGUI.ConsoleLog("Deathlink ON");
            }
            else
            {
                ArchipelagoGUI.ConsoleLog("Deathlink off");
            }
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

            if (session.DataStorage[Scope.Slot, "Goal"] == 1)
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

            ReadOnlyCollection<long> serverRemainingLocations = session.Locations.AllMissingLocations;

            List<long> serverRemaining = new List<long>();

            foreach (long location in serverRemainingLocations)
            {
                serverRemaining.Add(location);
            }
            
            APItem.RegisterLocationIDs(serverRemaining.ToArray());

            return;
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
                ScoutFoundLocationCheck(idToSend);
                session.Locations.CompleteLocationChecks(idToSend);

                return;
            }


            public static void SendDeathlink(string playerName = "Gungeoneer", string causeOfDeath = "Died to Gungeon")
            {
                if (deathLinkService == null)
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

            public static void SendChestOpened(int numberToAdd)
            {
                archipelago_slot_save_data["ChestsOpened"] = (Convert.ToInt32(archipelago_slot_save_data["ChestsOpened"]) + numberToAdd);

                bool IsGoalMet = Convert.ToInt32(archipelago_slot_save_data["ChestsOpened"]) > nextOpenedChestGoal;

                if (IsGoalMet)
                {
                    SendLocalIncrementalCountValuesToServer();
                    return;
                }

                return;
            }

            public static void SendRoomPointsToAdd(int numberToAdd)
            {
                archipelago_slot_save_data["RoomPoints"] = (Convert.ToInt32(archipelago_slot_save_data["RoomPoints"]) + numberToAdd);
                bool IsGoalMet = Convert.ToInt32(archipelago_slot_save_data["RoomPoints"]) > nextRoomPointsGoal;

                if (IsGoalMet)
                {
                    SendLocalIncrementalCountValuesToServer();
                }

                return;
            }

            public static void SendLocalIncrementalCountValuesToServer()
            {
                session.DataStorage[Scope.Slot, "ChestsOpened"] = Convert.ToInt32(archipelago_slot_save_data["ChestsOpened"]);
                session.DataStorage[Scope.Slot, "RoomPoints"] = Convert.ToInt32(archipelago_slot_save_data["RoomPoints"]);
            }

            public static void ScoutFoundLocationCheck(long locationID)
            {
                long[] locationList = new long[1];
                locationList[0] = locationID;

                session.Locations.ScoutLocationsAsync(locationInfoPacket => DataReceiver.OnScoutedItemLocationReceived(locationInfoPacket),
                    locationList);

                return;
            }

            public static void UpdateChestGoalToNextValue(int currentGoalValue)
            {
                int currentStep = Array.IndexOf(openedChestMilestones, currentGoalValue);
                nextOpenedChestGoal = currentStep + 1;

                archipelago_slot_save_data["NextGoalChestsOpened"] = nextOpenedChestGoal;
                session.DataStorage[Scope.Slot, "NextGoalChestsOpened"] = nextOpenedChestGoal;

                return;
            }

            public static void UpdateRoomPointsGoalToNextvalue(int currentGoalPoints)
            {
                int currentStep = Array.IndexOf(clearedRoomPointMilestones, currentGoalPoints);
                nextRoomPointsGoal = currentStep + 1;

                archipelago_slot_save_data["NextGoalRoomPoints"] = nextRoomPointsGoal;
                session.DataStorage[Scope.Slot, "NextGoalRoomPoints"] = nextRoomPointsGoal;

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
                    ArchipelagoGUI.ConsoleLog($"ID: {key} Item: {scoutedInfo[key].Player}'s + {scoutedInfo[key].ItemName} from {scoutedInfo[key].ItemGame}");
                    string name = $"{scoutedInfo[key].Player}'s + {scoutedInfo[key].ItemName}";

                    int randomIndex = random.Next(0, APItemData.itemFunnyPrefix.Length);

                    string description = $"{APItemData.itemFunnyPrefix[randomIndex]} item from {scoutedInfo[key].ItemGame}";

                }

                return;
            }

            public static void OnChestsOpenedValueChange(JToken originalValue, JToken newValue, Dictionary<string, JToken> additionalArguments)
            {
                // Check updated value against next milestone

                if (newValue.ToObject<int>() > nextOpenedChestGoal)
                {
                    // need to send location check
                    APItem.TDD_CallNextLocationCheck();

                    // update next milestone
                    DataSender.UpdateChestGoalToNextValue(nextOpenedChestGoal);
                }
                return;
            }

            public static void OnRoomPointsValueChange(JToken originalValue, JToken newValue, Dictionary<string, JToken> additionalArguments)
            {

                if (newValue.ToObject<int>() > nextRoomPointsGoal)
                {
                    // need to send location check
                    APItem.TDD_CallNextLocationCheck();

                    // update next milestone

                    DataSender.UpdateRoomPointsGoalToNextvalue(nextRoomPointsGoal);
                }

                return;
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
        }

    }
}
