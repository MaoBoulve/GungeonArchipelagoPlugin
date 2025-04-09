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

            StartCoroutine(PullServerDataOnDelay());

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
            //session.DataStorage["ChestsOpened"].OnValueChanged += DataReceiver.OnChestsOpenedValueChange;

            // basic counting
            foreach (SaveCountStats countStat in (SaveCountStats[])Enum.GetValues(typeof(SaveCountStats)))
            {
                JObject initialValueJObject = CountSaveData.GetCountStatAsJObject(countStat);
                Session.DataStorage[Scope.Slot, CountSaveData.StatToKey[countStat]].Initialize(initialValueJObject);

                ArchipelagoGUI.ConsoleLog($"Sending count for {countStat}: {initialValueJObject.Value<int>("CurrentCount")}");
            }

            // GAME COMPLETION
            // composed as JSON - { Count, NextGoal, GoalList }
            JObject initValueJObject;
            initValueJObject = CountSaveData.GetCountStatAsJObject(SaveCountStats.DragunKills);
            Session.DataStorage[Scope.Slot, CountSaveData.StatToKey[SaveCountStats.DragunKills]].Initialize(initValueJObject);

            initValueJObject = CountSaveData.GetCountStatAsJObject(SaveCountStats.LichKills);
            Session.DataStorage[Scope.Slot, CountSaveData.StatToKey[SaveCountStats.LichKills]].Initialize(initValueJObject);

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

        IEnumerator PullServerDataOnDelay(float waitTime = 5.0f)
        {

            ArchipelagoGUI.ConsoleLog($"Waiting {waitTime} to pull server data");

            yield return new WaitForSeconds(waitTime);

            DataSender.PullCountSaveData();
            
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
                    SaveCountStats correspondingStat = CountSaveData.GoalToSaveStat[goalEnum];

                    ArchipelagoGUI.ConsoleLog($"{Session.DataStorage[Scope.Slot, CompletionKeys[goalEnum]]}: {Session.DataStorage[Scope.Slot, CountSaveData.StatToKey[correspondingStat]] }");
                }
            }

            //ArchipelagoGUI.ConsoleLog("Main game goal");
            if (Session.DataStorage[Scope.Slot, "Goal"] == 0)
            {
                SaveCountStats correspondingStat = CountSaveData.GoalToSaveStat[CompletionGoals.Dragun];
                ArchipelagoGUI.ConsoleLog($"Dragun killed: {Session.DataStorage[Scope.Slot, CountSaveData.StatToKey[correspondingStat]]}");
            }

            if (Session.DataStorage[Scope.Slot, "Goal"] == 1)
            {
                SaveCountStats correspondingStat = CountSaveData.GoalToSaveStat[CompletionGoals.Lich];
                ArchipelagoGUI.ConsoleLog($"Lich killed: {Session.DataStorage[Scope.Slot, CountSaveData.StatToKey[correspondingStat]]}");
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

            public static void PullCountSaveData()
            {
                
                foreach (SaveCountStats countStat in (SaveCountStats[])Enum.GetValues(typeof(SaveCountStats)))
                {
                    JObject serverData = Session.DataStorage[Scope.Slot, CountSaveData.StatToKey[countStat]].To<JObject>();

                    CountSaveData.SetCountStatInfoFromJObject(countStat, serverData);

                    ArchipelagoGUI.ConsoleLog($"Received count for {countStat}: {serverData.Value<int>("CurrentCount")}");
                }

                return;
            }

            public static void SendGoalCompletion(CompletionGoals goalCompleted)
            {
                SaveCountStats correspondingStat = CountSaveData.GoalToSaveStat[goalCompleted];

                Session.DataStorage[Scope.Slot, CountSaveData.StatToKey[correspondingStat]] += 1;

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
                        if (Session.DataStorage[Scope.Slot, CountSaveData.StatToKey[SaveCountStats.DragunKills]] < 1)
                        {
                            return false;
                        }
                    }

                    else if(goalEnum == CompletionGoals.Lich)
                    {
                        if (Session.DataStorage[Scope.Slot, CountSaveData.StatToKey[SaveCountStats.LichKills]] < 1)
                        {
                            return false;
                        }
                    }

                    else
                    {
                        if (Session.DataStorage[Scope.Slot, CompletionKeys[goalEnum]] == 1)
                        {
                            SaveCountStats correspondingStat = CountSaveData.GoalToSaveStat[goalEnum];

                            if (Session.DataStorage[Scope.Slot, CountSaveData.StatToKey[correspondingStat]] < 1)
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


            public static void SendChestOpened(int numberOpened)
            {

                bool IsGoalMet = CountSaveData.AddToCount(SaveCountStats.ChestsOpened, numberOpened);
                if(IsGoalMet){ SendChestGoalLocationCheckComplete(); }

                return;
                
            }

            public static void SendRoomPointsToAdd(int numberToAdd)
            {
                bool IsGoalMet = CountSaveData.AddToCount(SaveCountStats.RoomPoints, numberToAdd);
                if (IsGoalMet){ SendRoomPointGoalLocationCheckComplete(); }

                return;
            }

            public static void SendLocalIncrementalCountValuesToServer()
            {
                if(Session == null || Session.Socket.Connected == false)
                {
                    return;
                }

                foreach (SaveCountStats countStat in (SaveCountStats[])Enum.GetValues(typeof(SaveCountStats)))
                {
                    JObject updatedStat = CountSaveData.GetCountStatAsJObject(countStat);
                    Session.DataStorage[Scope.Slot, CountSaveData.StatToKey[countStat]] = updatedStat;

                    ArchipelagoGUI.ConsoleLog($"Sending count for {countStat}: {updatedStat.Value<int>("CurrentCount")}");
                }

                return;
            }

            public static void ScoutFoundLocationCheck(long locationID)
            {
                long[] locationList = new long[1] { locationID };

                Session.Locations.ScoutLocationsAsync(locationInfoPacket =>
                { 
                    foreach (long key in locationInfoPacket.Keys)
                    {
                        ArchipelagoGUI.ConsoleLog($"ID: {key} Item: {locationInfoPacket[key].Player}'s + {locationInfoPacket[key].ItemName} from {locationInfoPacket[key].ItemGame}");
                    }
                },

                  locationList);

                return;
            }

            public static void SendChestGoalLocationCheckComplete()
            {
                APItem.TDD_CallNextLocationCheck();
                CountSaveData.SetGoalToNextEntry(SaveCountStats.ChestsOpened);

                JObject updatedStat = CountSaveData.GetCountStatAsJObject(SaveCountStats.ChestsOpened);
                Session.DataStorage[Scope.Slot, CountSaveData.StatToKey[SaveCountStats.ChestsOpened]] = updatedStat;

                return;
            }

            public static void SendRoomPointGoalLocationCheckComplete()
            {
                APItem.TDD_CallNextLocationCheck();
                CountSaveData.SetGoalToNextEntry(SaveCountStats.RoomPoints);

                JObject updatedStat = CountSaveData.GetCountStatAsJObject(SaveCountStats.RoomPoints);
                Session.DataStorage[Scope.Slot, CountSaveData.StatToKey[SaveCountStats.ChestsOpened]] = updatedStat;

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

        }

    }
}
