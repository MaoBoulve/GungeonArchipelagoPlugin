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

        // public readonly int location_check_initial_ID = 8755000;

        public static ArchipelagoSession Session { get; protected set; }
        private static Dictionary<string, object> PlayerSlotSettings { get; set; } = new Dictionary<string, object>(); // player settings, use to initialize data

        
        private static RandomizerSaveData CountSaveData { get; } = new();
        private static CountMilestones CountMilestones { get; } = new();

        public static DeathLinkService deathLinkService;

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
            if (Session != null && Session.Socket.Connected)
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
            PullLatestSlotData();

            BindToArchipelagoEvents();
            CheckToCreateDeathlink();

            // todo > write stuff to JSON
            SaveDataHandler.SaveArchipelagoConnectionSettings(ip, port, name);

            
            InitializeAPItems();
            allow_traps = true;

            ArchipelagoGUI.ConsoleLog("Connected to Archipelago server.");

            return;
        }

        private static LoginResult LoginToArchipelago(string ip, string port, string name, string password = null)
        {
            Session = ArchipelagoSessionFactory.CreateSession(ip, int.Parse(port));
            LoginResult loginResult;

            if (password == null || password == "")
            {
                loginResult = Session.TryConnectAndLogin("Enter The Gungeon", name, ItemsHandlingFlags.IncludeOwnItems);
            }

            else
            {
                loginResult = Session.TryConnectAndLogin("Enter The Gungeon", name, ItemsHandlingFlags.IncludeOwnItems, password: password);
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
            ArchipelagoGUI.ConsoleLog("Init keys");
            // todo: test if can write new etire entry
            Session.DataStorage[Scope.Slot, "ChestsOpened"].Initialize(0);
            //session.DataStorage["ChestsOpened"].OnValueChanged += DataReceiver.OnChestsOpenedValueChange;
            Session.DataStorage[Scope.Slot, "NextGoalChestsOpened"].Initialize(1);

            Session.DataStorage[Scope.Slot, "RoomPoints"].Initialize(0);
            //session.DataStorage["RoomPoints"].OnValueChanged += DataReceiver.OnRoomPointsValueChange;
            Session.DataStorage[Scope.Slot, "NextGoalRoomPoints"].Initialize(1);

            // GAME COMPLETION
            Session.DataStorage[Scope.Slot, "Blobulord Killed"].Initialize(0);
            Session.DataStorage[Scope.Slot, "Old King Killed"].Initialize(0);
            Session.DataStorage[Scope.Slot, "Resourceful Rat Killed"].Initialize(0);
            Session.DataStorage[Scope.Slot, "Agunim Killed"].Initialize(0);
            Session.DataStorage[Scope.Slot, "Dragun Killed"].Initialize(0);
            Session.DataStorage[Scope.Slot, "Advanced Dragun Killed"].Initialize(0);
            Session.DataStorage[Scope.Slot, "Lich Killed"].Initialize(0);

            
        }

        private static void PullLatestSlotData()
        {
            PlayerSlotSettings = Session.DataStorage.GetSlotData();

            foreach (string key in PlayerSlotSettings.Keys)
            {
                ArchipelagoGUI.ConsoleLog($"KEY: {key} -- VALUE: {PlayerSlotSettings[key]}");
            }

            ArchipelagoGUI.ConsoleLog("Pulling keys");
            //nextOpenedChestGoal = Convert.ToInt32(archipelago_slot_save_data["NextGoalChestsOpened"]);
            //nextRoomPointsGoal = Convert.ToInt32(archipelago_slot_save_data["NextGoalRoomPoints"]);
        }


        private static void BindToArchipelagoEvents()
        {
            // binds
            Session.Socket.PacketReceived += DataReceiver.OnPacketReceived;
            Session.Items.ItemReceived += DataReceiver.OnItemReceived;
            Session.MessageLog.OnMessageReceived += DataReceiver.OnMessageReceived;

            return;
        }



        private static void CheckToCreateDeathlink()
        {
            // deathlink
            if (Convert.ToInt32(PlayerSlotSettings["DeathLink"]) == 1)
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
            deathLinkService = Session.CreateDeathLinkService();

            if (isDeathlinkEnabled)
            {
                deathLinkService.EnableDeathLink();
            }

            deathLinkService.OnDeathLinkReceived += DataReceiver.OnDeathlink;

            return;
        }

        public static void ResetItemRetrieveState()
        {
            CountSaveData.ItemsRetrievedThisRun = 0;
            return;
        }

        public static void RetrieveServerItems()
        {
            allow_traps = false;
            if (Session == null)
            {
                ArchipelagoGUI.ConsoleLog("ERROR: Not connected to Archipelago!");
                return;
            }
            if (CountSaveData.ItemsRetrievedThisRun == 1)
            {
                ArchipelagoGUI.ConsoleLog("ERROR: Server items already retrieved!");
                return;
            }

            CountSaveData.ItemsRetrievedThisRun = 1;

            ArchipelagoGUI.ConsoleLog("Retrieving server items!");

            foreach (var item in Session.Items.AllItemsReceived)
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
            if (Session == null)
            {
                ArchipelagoGUI.ConsoleLog("ERROR: Not connected to Archipelago!");
                return;
            }

            //ArchipelagoGUI.ConsoleLog("Blobby");
            if (Session.DataStorage[Scope.Slot, "Blobulord Goal"] == 1)
            {
                ArchipelagoGUI.ConsoleLog($"Blobulord killed: {(bool)Session.DataStorage[Scope.Slot, "Blobulord Killed"]}");
            }

            //ArchipelagoGUI.ConsoleLog("Old");
            if (Session.DataStorage[Scope.Slot, "Old King Goal"] == 1)
            {
                ArchipelagoGUI.ConsoleLog($"Old King killed: {(bool)Session.DataStorage[Scope.Slot, "Old King Killed"]}");
            }

            //ArchipelagoGUI.ConsoleLog("RAT");
            if (Session.DataStorage[Scope.Slot, "Resourceful Rat Goal"] == 1)
            {
                ArchipelagoGUI.ConsoleLog($"Resourceful Rat killed: {(bool)Session.DataStorage[Scope.Slot, "Resourceful Rat Killed"]}");
            }

            //ArchipelagoGUI.ConsoleLog("Agunim");
            if (Session.DataStorage[Scope.Slot, "Agunim Goal"] == 1)
            {
                ArchipelagoGUI.ConsoleLog($"Liquid Agunim killed: {(bool)Session.DataStorage[Scope.Slot, "Agunim Killed"]}");
            }

            //ArchipelagoGUI.ConsoleLog("Advanced Dwagun");
            if (Session.DataStorage[Scope.Slot, "Advanced Dragun Goal"] == 1)
            {
                ArchipelagoGUI.ConsoleLog($"Advanced Dragun killed: {(bool)Session.DataStorage[Scope.Slot, "Advanced Dragun Killed"]}");
            }

            //ArchipelagoGUI.ConsoleLog("Main game goal");
            if (Session.DataStorage[Scope.Slot, "Goal"] == 0)
            {
                ArchipelagoGUI.ConsoleLog($"Dragun killed: {(bool)Session.DataStorage[Scope.Slot, "Dragun Killed"]}");
            }

            if (Session.DataStorage[Scope.Slot, "Goal"] == 1)
            {
                ArchipelagoGUI.ConsoleLog($"Lich killed: {(bool)Session.DataStorage[Scope.Slot, "Lich Killed"]}");
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

            ReadOnlyCollection<long> serverRemainingLocations = Session.Locations.AllMissingLocations;

            List<long> serverRemaining = new List<long>();

            serverRemaining = serverRemainingLocations.ToList();
            
            APItem.RegisterLocationIDs(serverRemaining.ToArray());

            return;
        }


        public class DataSender
        {

            public static void SendFoundLocationCheck(string locationName)
            {
                long locationID = Session.Locations.GetLocationIdFromName("Enter the Gungeon", locationName);
                Session.Locations.CompleteLocationChecks(locationID);
                return;
            }

            public static void SendFoundLocationCheck(long idToSend)
            {
                ScoutFoundLocationCheck(idToSend);
                Session.Locations.CompleteLocationChecks(idToSend);

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
                Session.DataStorage[Scope.Slot, goalName] = 1;

                if ((Session.DataStorage[Scope.Slot, "Blobulord Goal"] != 1 || (bool)Session.DataStorage[Scope.Slot, "Blobulord Killed"]) && (Session.DataStorage[Scope.Slot, "Old King Goal"] != 1 || (bool)Session.DataStorage[Scope.Slot, "Old King Killed"]) && (Session.DataStorage[Scope.Slot, "Resourceful Rat Goal"] != 1 || (bool)Session.DataStorage[Scope.Slot, "Resourceful Rat Killed"]) && (Session.DataStorage[Scope.Slot, "Agunim Goal"] != 1 || (bool)Session.DataStorage[Scope.Slot, "Agunim Killed"]) && (Session.DataStorage[Scope.Slot, "Advanced Dragun Goal"] != 1 || (bool)Session.DataStorage[Scope.Slot, "Advanced Dragun Killed"]) && (Session.DataStorage[Scope.Slot, "Goal"] != 0 || (bool)Session.DataStorage[Scope.Slot, "Dragun Killed"]) && (Session.DataStorage[Scope.Slot, "Goal"] != 1 || (bool)Session.DataStorage[Scope.Slot, "Lich Killed"]))
                {
                    SendGameCompletion();
                }

                return;
            }

            public static void SendGameCompletion()
            {
                StatusUpdatePacket statusUpdatePacket = new StatusUpdatePacket();
                statusUpdatePacket.Status = ArchipelagoClientState.ClientGoal;
                Session.Socket.SendPacket(statusUpdatePacket);
                return;
            }

            public static void SendChatMessage(string message)
            {
                Session.Socket.SendPacketAsync(new SayPacket
                {
                    Text = message
                });
            }


            public static void SendChestOpened(int numberToAdd)
            {
                if(CountSaveData.IsSaveDataInitialize != 1)
                {
                    PullServerCountSaveDataToLocalVariable();
                }

                CountSaveData.ChestsOpened += numberToAdd;
                bool IsGoalMet = CountSaveData.ChestsOpened >= CountMilestones.OpenedChestGoal;
                
                ArchipelagoGUI.ConsoleLog($"{CountSaveData.ChestsOpened} check against: {CountMilestones.OpenedChestGoal}");
               
                if (IsGoalMet)
                {
                    SendChestGoalLocationCheckComplete(CountMilestones.OpenedChestGoal);
                    SendLocalIncrementalCountValuesToServer();
                    return;
                }

                return;
            }

            public static void SendRoomPointsToAdd(int numberToAdd)
            {
                if (CountSaveData.IsSaveDataInitialize != 1)
                {
                    PullServerCountSaveDataToLocalVariable();
                }

                CountSaveData.RoomPoints += numberToAdd;
                bool IsGoalMet = CountSaveData.RoomPoints >= CountMilestones.RoomPointsGoal;

                ArchipelagoGUI.ConsoleLog($"{CountSaveData.RoomPoints} check against: {CountMilestones.RoomPointsGoal}");

                if (IsGoalMet)
                {
                    SendRoomPointGoalLocationCheckComplete(CountSaveData.RoomPoints);
                    SendLocalIncrementalCountValuesToServer();
                }

                return;
            }

            private static void PullServerCountSaveDataToLocalVariable()
            {
                if (Session == null || Session.Socket.Connected == false)
                {
                    return;
                }

                CountSaveData.ChestsOpened = Session.DataStorage[Scope.Slot, "ChestsOpened"];
                CountSaveData.RoomPoints = Session.DataStorage[Scope.Slot, "RoomPoints"];

                CountMilestones.OpenedChestGoal = Session.DataStorage[Scope.Slot, "NextGoalChestsOpened"];
                CountMilestones.RoomPointsGoal = Session.DataStorage[Scope.Slot, "NextGoalRoomPoints"];

                CountSaveData.IsSaveDataInitialize = 1;

            }

            public static void SendLocalIncrementalCountValuesToServer()
            {
                if(Session == null || Session.Socket.Connected == false)
                {
                    return;
                }

                ArchipelagoGUI.ConsoleLog($"Sending count for chests: {CountSaveData.ChestsOpened}");
                ArchipelagoGUI.ConsoleLog($"Sending count for room points: {CountSaveData.RoomPoints}");

                Session.DataStorage[Scope.Slot, "ChestsOpened"] = CountSaveData.ChestsOpened;
                Session.DataStorage[Scope.Slot, "RoomPoints"] = CountSaveData.RoomPoints;

                return;
            }

            public static void ScoutFoundLocationCheck(long locationID)
            {
                long[] locationList = new long[1];
                locationList[0] = locationID;

                Session.Locations.ScoutLocationsAsync(locationInfoPacket => DataReceiver.OnScoutedItemLocationReceived(locationInfoPacket),
                    locationList);

                return;
            }

            public static void SendChestGoalLocationCheckComplete(int currentGoalValue)
            {
                APItem.TDD_CallNextLocationCheck();

                int currentStep = Array.IndexOf(CountMilestones.ChestMilestones, currentGoalValue);
                CountMilestones.OpenedChestGoal = CountMilestones.ChestMilestones[currentStep + 1];

                //counting_save_data["NextGoalChestsOpened"] = currentOpenedChestGoal;
                Session.DataStorage[Scope.Slot, "NextGoalChestsOpened"] = CountMilestones.OpenedChestGoal;

                return;
            }

            public static void SendRoomPointGoalLocationCheckComplete(int currentGoalPoints)
            {
                APItem.TDD_CallNextLocationCheck();

                int currentStep = Array.IndexOf(CountMilestones.RoomPointsMilestones, currentGoalPoints);
                CountMilestones.RoomPointsGoal = CountMilestones.RoomPointsMilestones[currentStep + 1];

                //counting_save_data["NextGoalRoomPoints"] = currentRoomPointsGoal;
                Session.DataStorage[Scope.Slot, "NextGoalRoomPoints"] = CountMilestones.RoomPointsGoal;

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
                AddItemToLocalGungeon(itemInfo);

                helper.DequeueItem();
                

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

            /*
            public static void OnChestsOpenedValueChange(JToken originalValue, JToken newValue, Dictionary<string, JToken> additionalArguments)
            {
                // Check updated value against next milestone

                ArchipelagoGUI.ConsoleLog("Checking chests opened value from server async: " + newValue);

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
                ArchipelagoGUI.ConsoleLog("Checking room points value from server async: " + newValue);

                if (newValue.ToObject<int>() > nextRoomPointsGoal)
                {
                    // need to send location check
                    APItem.TDD_CallNextLocationCheck();

                    // update next milestone

                    DataSender.UpdateRoomPointsGoalToNextvalue(nextRoomPointsGoal);
                }

                return;
            }

            */

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
