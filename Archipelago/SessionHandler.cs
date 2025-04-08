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
    
    public enum CompletionGoals
    {
        Blobulord,
        OldKing,
        Rat,
        Agunim,
        AdvancedDragun,
        Dragun,
        Lich
    }

    public class SessionHandler : MonoBehaviour
    {
        // The current instance of the console.
        public static SessionHandler Instance { get; protected set; }
        public static ArchipelagoSession Session { get; protected set; }
        public static DeathLinkService DeathLinkService { get; protected set; }
        private static Dictionary<string, object> PlayerSlotSettings { get; set; } = new Dictionary<string, object>(); // player settings, use to initialize data

        private static Dictionary<CompletionGoals, string> CompletionKeys { get; } = new Dictionary<CompletionGoals, string>()
        {
            { CompletionGoals.Blobulord, "Blobulord Goal" },
            { CompletionGoals.OldKing, "Old King Goal" },
            { CompletionGoals.Rat, "Resourceful Rat Goal" },
            { CompletionGoals.Agunim, "Agunim Goal" },
            { CompletionGoals.AdvancedDragun, "Advanced Dragun Goal" },
            { CompletionGoals.Dragun, "Dragun Goal" },
            { CompletionGoals.Lich, "Lich Goal" }
        };
        

       
        private static bool pulledItemsThisRun = false;
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

            // composed as JSON - { Count, NextGoal, GoalList }
            JObject initValueJObject;

            //session.DataStorage["ChestsOpened"].OnValueChanged += DataReceiver.OnChestsOpenedValueChange;

            // basic counting
            initValueJObject = SaveStatsInfo.GetStatInitValueJObject(SaveStats.ChestsOpened);
            Session.DataStorage[Scope.Slot, SaveStatsInfo.StatToKey[SaveStats.ChestsOpened]].Initialize(initValueJObject);

            initValueJObject = SaveStatsInfo.GetStatInitValueJObject(SaveStats.RoomPoints);
            Session.DataStorage[Scope.Slot, SaveStatsInfo.StatToKey[SaveStats.RoomPoints]].Initialize(initValueJObject);

            initValueJObject = SaveStatsInfo.GetStatInitValueJObject(SaveStats.CashSpent);
            Session.DataStorage[Scope.Slot, SaveStatsInfo.StatToKey[SaveStats.CashSpent]].Initialize(initValueJObject);

            // GAME COMPLETION
            // TODO: init completion keys off SAVE DATA

            initValueJObject = SaveStatsInfo.GetStatInitValueJObject(SaveStats.DragunKills);
            Session.DataStorage[Scope.Slot, SaveStatsInfo.StatToKey[SaveStats.DragunKills]].Initialize(initValueJObject);

            initValueJObject = SaveStatsInfo.GetStatInitValueJObject(SaveStats.LichKills);
            Session.DataStorage[Scope.Slot, SaveStatsInfo.StatToKey[SaveStats.LichKills]].Initialize(initValueJObject);

        }

        private static void PullLatestSlotData()
        {
            PlayerSlotSettings = Session.DataStorage.GetSlotData();

            foreach (string key in PlayerSlotSettings.Keys)
            {
                ArchipelagoGUI.ConsoleLog($"KEY: {key} -- VALUE: {PlayerSlotSettings[key]}");
            }

            //ArchipelagoGUI.ConsoleLog("Pulling keys");

            return;
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
            DeathLinkService = Session.CreateDeathLinkService();

            if (isDeathlinkEnabled)
            {
                DeathLinkService.EnableDeathLink();
            }

            DeathLinkService.OnDeathLinkReceived += DataReceiver.OnDeathlink;

            return;
        }

        public static void ResetItemRetrieveState()
        {
            pulledItemsThisRun = false;
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
            if (pulledItemsThisRun)
            {
                ArchipelagoGUI.ConsoleLog("ERROR: Server items already retrieved!");
                return;
            }

            pulledItemsThisRun = true;

            ArchipelagoGUI.ConsoleLog("Retrieving server items!");

            var itemList = Session.Items.AllItemsReceived;

            foreach (var item in itemList)
            {
                AddItemToLocalGungeon(item);
            }

            allow_traps = true;

            return;
        }

        public static void AddItemToLocalGungeon(ItemInfo itemInfo)
        {
            if (!allow_traps || itemInfo.ItemId > 8754200)
            {
                return;
            }
            
            //GungeonControl.GiveGungeonItem(itemInfo.ItemId);
            item_add_queue.Add(itemInfo.ItemId);
            

            return;
        }

        public static void OutputGameGoalStatus()
        {
            if (Session == null)
            {
                ArchipelagoGUI.ConsoleLog("ERROR: Not connected to Archipelago!");
                return;
            }


            foreach (CompletionGoals goalEnum in (CompletionGoals[])Enum.GetValues(typeof(CompletionGoals)))
            {
                if (Session.DataStorage[Scope.Slot, CompletionKeys[goalEnum]] == 1)
                {
                    SaveStats correspondingStat = SaveStatsInfo.GoalToSaveStat[goalEnum];

                    ArchipelagoGUI.ConsoleLog($"{Session.DataStorage[Scope.Slot, CompletionKeys[goalEnum]]}: {Session.DataStorage[Scope.Slot, SaveStatsInfo.StatToKey[correspondingStat]] }");
                }
            }

            //ArchipelagoGUI.ConsoleLog("Main game goal");
            if (Session.DataStorage[Scope.Slot, "Goal"] == 0)
            {
                SaveStats correspondingStat = SaveStatsInfo.GoalToSaveStat[CompletionGoals.Dragun];
                ArchipelagoGUI.ConsoleLog($"Dragun killed: {Session.DataStorage[Scope.Slot, SaveStatsInfo.StatToKey[correspondingStat]]}");
            }

            if (Session.DataStorage[Scope.Slot, "Goal"] == 1)
            {
                SaveStats correspondingStat = SaveStatsInfo.GoalToSaveStat[CompletionGoals.Lich];
                ArchipelagoGUI.ConsoleLog($"Lich killed: {Session.DataStorage[Scope.Slot, SaveStatsInfo.StatToKey[correspondingStat]]}");
            }

            if(DataSender.CheckForGameCompletion())
            {
                DataSender.SendGameCompletion();
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
            List<long> serverRemaining = serverRemainingLocations.ToList();
            
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
                if (DeathLinkService == null)
                {
                    ArchipelagoGUI.ConsoleLog("Tried to send Deathlink but not connected!");
                    return;
                }

                string deathName = ConnectionSettings.PlayerName;

                DeathLinkService.SendDeathLink(new DeathLink(deathName, causeOfDeath));
                return;
            }

            public static void SendGoalCompletion(CompletionGoals goalCompleted)
            {
                //Session.DataStorage[Scope.Slot, goalName] = 1;
                SaveStats correspondingStat = SaveStatsInfo.GoalToSaveStat[goalCompleted];

                Session.DataStorage[Scope.Slot, SaveStatsInfo.StatToKey[correspondingStat]] += 1;

                /*
                if ((Session.DataStorage[Scope.Slot, "Blobulord Goal"] != 1 || (bool)Session.DataStorage[Scope.Slot, "Blobulord Killed"]) && (Session.DataStorage[Scope.Slot, "Old King Goal"] != 1 || (bool)Session.DataStorage[Scope.Slot, "Old King Killed"]) && (Session.DataStorage[Scope.Slot, "Resourceful Rat Goal"] != 1 || (bool)Session.DataStorage[Scope.Slot, "Resourceful Rat Killed"]) && (Session.DataStorage[Scope.Slot, "Agunim Goal"] != 1 || (bool)Session.DataStorage[Scope.Slot, "Agunim Killed"]) && (Session.DataStorage[Scope.Slot, "Advanced Dragun Goal"] != 1 || (bool)Session.DataStorage[Scope.Slot, "Advanced Dragun Killed"]) && (Session.DataStorage[Scope.Slot, "Goal"] != 0 || (bool)Session.DataStorage[Scope.Slot, "Dragun Killed"]) && (Session.DataStorage[Scope.Slot, "Goal"] != 1 || (bool)Session.DataStorage[Scope.Slot, "Lich Killed"]))
                {
                    SendGameCompletion();
                }

                */

                if (CheckForGameCompletion())
                {
                    SendGameCompletion();
                }

                return;
            }

            public static bool CheckForGameCompletion()
            {
                foreach (CompletionGoals goalEnum in (CompletionGoals[])Enum.GetValues(typeof(CompletionGoals)))
                {
                    if(goalEnum == CompletionGoals.Dragun)
                    {
                        if (Session.DataStorage[Scope.Slot, SaveStatsInfo.StatToKey[SaveStats.DragunKills]] < 1)
                        {
                            return false;
                        }
                    }

                    else if(goalEnum == CompletionGoals.Lich)
                    {
                        if (Session.DataStorage[Scope.Slot, SaveStatsInfo.StatToKey[SaveStats.LichKills]] < 1)
                        {
                            return false;
                        }
                    }

                    else
                    {
                        if (Session.DataStorage[Scope.Slot, CompletionKeys[goalEnum]] == 1)
                        {
                            SaveStats correspondingStat = SaveStatsInfo.GoalToSaveStat[goalEnum];

                            if (Session.DataStorage[Scope.Slot, SaveStatsInfo.StatToKey[correspondingStat]] < 1)
                            {
                                return false;
                            }
                        }
                    }

                }

                return true;
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
                ArchipelagoGUI.ConsoleLog("Chest opened broken ATM");

                //RandomizerSaveData.ChestsOpened += numberToAdd;
                //bool IsGoalMet = RandomizerSaveData.ChestsOpened >= CountMilestones.ChestsOpenedGoal;



                //SendChestGoalLocationCheckComplete(CountMilestones.ChestsOpenedGoal);
                //Session.DataStorage[Scope.Slot, RandomizerSaveData.StatEnumToServerKey[SaveDataTrackedStats.ChestsOpened]] = RandomizerSaveData.ChestsOpened;
                return;
                
            }

            public static void SendRoomPointsToAdd(int numberToAdd)
            {

                ArchipelagoGUI.ConsoleLog("Room points broken ATM");

                // RandomizerSaveData.RoomPoints += numberToAdd;
                // bool IsGoalMet = RandomizerSaveData.RoomPoints >= CountMilestones.RoomPointsGoal;


                //SendRoomPointGoalLocationCheckComplete(CountMilestones.RoomPointsGoal);
                // Session.DataStorage[Scope.Slot, RandomizerSaveData.StatEnumToServerKey[SaveDataTrackedStats.RoomPoints]] = RandomizerSaveData.RoomPoints;

                return;
            }

            public static void SendLocalIncrementalCountValuesToServer()
            {
                if(Session == null || Session.Socket.Connected == false)
                {
                    return;
                }

                //ArchipelagoGUI.ConsoleLog($"Sending count for chests: {RandomizerSaveData.ChestsOpened}");
                //ArchipelagoGUI.ConsoleLog($"Sending count for room points: {RandomizerSaveData.RoomPoints}");

                //Session.DataStorage[Scope.Slot, "ChestsOpened"] = RandomizerSaveData.ChestsOpened;
                //Session.DataStorage[Scope.Slot, "RoomPoints"] = RandomizerSaveData.RoomPoints;

                return;
            }

            public static void ScoutFoundLocationCheck(long locationID)
            {
                long[] locationList = new long[1];
                locationList[0] = locationID;

                /*
                Session.Locations.ScoutLocationsAsync(locationInfoPacket => DataReceiver.OnScoutedItemLocationReceived(locationInfoPacket),
                    locationList);
                */
                return;
            }

            public static void SendChestGoalLocationCheckComplete(int currentGoalValue)
            {
                APItem.TDD_CallNextLocationCheck();

                //int currentStep = Array.IndexOf(CountMilestones.ChestMilestones, currentGoalValue);
                // CountMilestones.ChestsOpenedGoal = CountMilestones.ChestMilestones[currentStep + 1];

                // Session.DataStorage[Scope.Slot, "NextGoalChestsOpened"] = CountMilestones.ChestsOpenedGoal;

                return;
            }

            public static void SendRoomPointGoalLocationCheckComplete(int currentGoalPoints)
            {
                APItem.TDD_CallNextLocationCheck();

                //int currentStep = Array.IndexOf(CountMilestones.RoomPointsMilestones, currentGoalPoints);
                // CountMilestones.RoomPointsGoal = CountMilestones.RoomPointsMilestones[currentStep + 1];

                //Session.DataStorage[Scope.Slot, "NextGoalRoomPoints"] = CountMilestones.RoomPointsGoal;

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

                }

                return;
            }

        }

    }
}
