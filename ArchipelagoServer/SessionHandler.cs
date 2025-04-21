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
//using Newtonsoft.Json.Linq;
using ArchiGungeon.ItemArchipelago;
using ArchiGungeon.GungeonEventHandlers;
using ArchiGungeon.ModConsoleVisuals;
using ArchiGungeon.EnemyHandlers;
using ArchiGungeon.DebugTools;

namespace ArchiGungeon.ArchipelagoServer
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

    public struct CountGoalServerKeys
    {
        public string CountKey;
        public string GoalSettings;

        public CountGoalServerKeys(string countKey)
        {
            CountKey = countKey;
            GoalSettings = "SETTINGS_" + countKey;
            return;
        }
    }

    public struct LocationCheckCategoryRange
    {
        public int startIndex;
        public int stopIndex;
        public int range;

        public LocationCheckCategoryRange(int start, int stop)
        {
            startIndex = start;
            stopIndex = stop;
            range = (stopIndex - startIndex) + 1;

            return;
        }
    }

    public class SessionHandler : MonoBehaviour
    {
        public static ArchipelagoSession Session { get; protected set; }
        public static DeathLinkService DeathLinkService { get; protected set; }
        private static Dictionary<string, object> PlayerSlotSettings { get; set; } = new Dictionary<string, object>(); // player settings, use to initialize data
        private static PlayerConnectionInfo PlayerServerInfo { get; set; }

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
        private static List<long> itemsHandledThisRun = new List<long>();
        private static List<long> item_add_queue = new();

        // CONNECTION HANDLING ===============================

        public static void ArchipelagoConnect(string ip, string port, string name, string password = null)
        {
            TrapSpawnHandler.SetCanSpawn(false);
            ConsumableSpawnHandler.SetCanSpawn(false);


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
                Session = null;
                ParseLoginError(ip, port, name, loginResult);
                return;
            }

            // Success after this point
            //LoginSuccessful loginSuccessful = (LoginSuccessful)loginResult;

            InitializeServerDataStorage();
            PullLatestSlotData();

            BindToArchipelagoEvents();
            CheckToCreateDeathlink();
            CheckToRandomizeEnemies();

            // todo > write stuff to JSON

            PlayerServerInfo = new PlayerConnectionInfo(ip, port, name);
            LocalSaveDataHandler.SaveArchipelagoConnectionSettings(ip, port, name);

            
            InitializeAPLocationChecks();

            TrapSpawnHandler.SetCanSpawn(true);
            ConsumableSpawnHandler.SetCanSpawn(true);

            ArchipelagoGUI.ConsoleLog("Connected to Archipelago server.");

            var tempgameObject = new GameObject();
            TimedServerCalls timedServerCalls = tempgameObject.AddComponent<TimedServerCalls>();

            timedServerCalls.StartCoroutine(timedServerCalls.PullServerDataOnDelay());

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
            ArchDebugPrint.DebugLog(DebugCategory.InitializingGameState, "Init keys");
            //session.DataStorage["ChestsOpened"].OnValueChanged += DataReceiver.OnChestsOpenedValueChange;

            // basic counting
            foreach (SaveCountStats countStatEnum in (SaveCountStats[])Enum.GetValues(typeof(SaveCountStats)))
            {

                Session.DataStorage[Scope.Slot, CountSaveData.CountStatToKeys[countStatEnum].CountKey].Initialize(0);
            }


            return;
        }

        private static void PullLatestSlotData()
        {
            PlayerSlotSettings = Session.DataStorage.GetSlotData();

            foreach (string key in PlayerSlotSettings.Keys)
            {
                ArchDebugPrint.DebugLog(DebugCategory.InitializingGameState, $"KEY: {key} -- VALUE: {PlayerSlotSettings[key]}");
            }


            return;
        }

        public static void DisconnectFromSession()
        {
            if (Session == null)
            {
                ArchipelagoGUI.ConsoleLog("Not connected to a session!");
                return;
            }
            else if (Session.Socket.Connected == false)
            {
                ArchipelagoGUI.ConsoleLog("Not connected to a session!");
                return;
            }


            ArchipelagoGUI.ConsoleLog("Disconnected from server");

            Session.Socket.Disconnect();
            Session = null;

            EnemySwapping.ClearAllShuffleLists();

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



        // DEATHLINK =====================

        private static void CheckToCreateDeathlink()
        {
            // deathlink
            if (Convert.ToInt32(PlayerSlotSettings["DeathLink"]) == 1)
            {
                InitializeDeathlink(true);
                ArchDebugPrint.DebugLog(DebugCategory.InitializingGameState, "Deathlink ON");
            }
            else
            {
                InitializeDeathlink(false);
                ArchDebugPrint.DebugLog(DebugCategory.InitializingGameState, "Deathlink off");
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

        public static void SetDeathLinkMode(int modeToSet)
        {
            if(DeathLinkService == null || Session == null)
            {
                ArchipelagoGUI.ConsoleLog("Not connected to a session!");
                return;
            }

            switch (modeToSet)
            {
                case 0:
                    DeathLinkService.DisableDeathLink();
                    return;
                case 1:
                    DeathLinkService.EnableDeathLink();
                    return;
                case 2:
                    DeathLinkService.EnableDeathLink();
                    return;
                default:
                    ArchipelagoGUI.ConsoleLog("Invalid deathlink mode setting!");
                    return;
            }
        }

        // ENEMIES =========================================================

        private static void CheckToRandomizeEnemies()
        {
            // deathlink
            if (Convert.ToInt32(PlayerSlotSettings["RandomEnemies"]) == 1)
            {
                InitializeEnemySwapper();
                ArchDebugPrint.DebugLog(DebugCategory.InitializingGameState, "Random enemies");
            }
        }

        

        // ITEM RETRIEVAL ===============================

        public static void ResetItemRetrieveState()
        {
            pulledItemsThisRun = false;
            itemsHandledThisRun.Clear();
            return;
        }

        public static void RetrieveServerItems()
        {

            TrapSpawnHandler.SetCanSpawn(false);
            ConsumableSpawnHandler.SetCanSpawn(false);

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

            var itemList = Session.Items.AllItemsReceived;

            ArchipelagoGUI.ConsoleLog($"Retrieving {itemList.Count} server items!");

            foreach (var item in itemList)
            {
                AddItemToLocalGungeon(item);
            }

            TrapSpawnHandler.SetCanSpawn(true);
            ConsumableSpawnHandler.SetCanSpawn(true);

            return;
        }

        
        public static void AddItemToLocalGungeon(ItemInfo itemInfo)
        {
            if(TrapSpawnHandler.IsSpawnValid == false)
            {
                if(itemInfo.ItemId >= 8754200)
                {

                    return;
                }
            }

            //GungeonControl.GiveGungeonItem(itemInfo.ItemId);

            ArchDebugPrint.DebugLog(DebugCategory.ServerReceive, $"Receiving item: {itemInfo.ItemName}");

            item_add_queue.Add(itemInfo.ItemId);
            itemsHandledThisRun.Add(itemInfo.ItemId);

            return;
        }

        public static void CheckForUnhandledServerItems()
        {
            var itemList = Session.Items.AllItemsReceived;

            foreach (var item in itemList)
            {
                if(!itemsHandledThisRun.Contains(item.ItemId))
                {
                    ArchDebugPrint.DebugLog(DebugCategory.ServerReceive, $"Unhandled item on server: {item.ItemName} -- {item.ItemId}");
                    AddItemToLocalGungeon(item);
                }
            }

            return;
        }

        public static void Update()
        {
            if (item_add_queue.Count > 0)
            {
                ArchDebugPrint.DebugLog(DebugCategory.ItemHandling, $"Handling item ID: {item_add_queue[0]}");

                ArchipelagoGungeonBridge.GiveGungeonItem(item_add_queue[0]);

                

                item_add_queue.RemoveAt(0);
            }

            return;
        }

        // USER OUTPUT HELPER ===============================

        public static void OutputGameGoalStatus()
        {
            if (Session == null)
            {
                ArchipelagoGUI.ConsoleLog("ERROR: Not connected to Archipelago!");
                return;
            }

            DataSender.CheckForGameCompletion();


            foreach (CompletionGoals goalEnum in (CompletionGoals[])Enum.GetValues(typeof(CompletionGoals)))
            {
                // Wait why am i pulling from this when I pulled slot_data start of connection
                if (Convert.ToInt32(PlayerSlotSettings[CompletionKeys[goalEnum]] ) == 1)
                {

                    SaveCountStats correspondingStat = CountSaveData.GoalToSaveStat[goalEnum];
                    int statData = CountSaveData.GetCountStat(correspondingStat);
                    string killConfirm = "**** YES ****";

                    if (statData < 1)
                    {
                        killConfirm = "NO";
                    }

                    ArchipelagoGUI.ConsoleLog($"Game completion goal -- {goalEnum} -- Killed: {killConfirm}");
                }
            }

            

            return;
        }

        // ENEMY SWAPPER ==========================================
        

        private static void InitializeEnemySwapper()
        {
            string seedString = Session.RoomState.Seed;
            System.Security.Cryptography.MD5 md5Hasher = System.Security.Cryptography.MD5.Create();
            var hashed = md5Hasher.ComputeHash(Encoding.UTF8.GetBytes(seedString));
            int seed = BitConverter.ToInt32(hashed, 0);

            EnemySwapping.MakeNormalShuffleEnemies(seed);
            return;
            //TODO CHECK FOR enemy randomizer KEY
        }

        // ONLY 53 checks oops
        private static LocationCheckCategoryRange chestsOpenedIndex = new LocationCheckCategoryRange(1, 8);
        private static LocationCheckCategoryRange roomPointsIndex = new LocationCheckCategoryRange(10, 17);
        private static LocationCheckCategoryRange cashSpentIndex = new LocationCheckCategoryRange(20, 24);

        private static void InitializeAPLocationChecks()
        {
            List<long> allServerLocations = Session.Locations.AllLocations.ToList();

            //ArchipelagoGUI.ConsoleLog($"{allServerLocations[0]} starting item ID");
            ArchipelagoGungeonBridge.InitializeItemID(8754000);

            ArchipelagoGUI.ConsoleLog($"There are {allServerLocations.Count} total locations in gungeon");
            // TODO: determine how many raw location checks there are

            List<long> chestsIDs = allServerLocations.GetRange(chestsOpenedIndex.startIndex, chestsOpenedIndex.range);
            AchievementLocationCheckHandler.SetStatLocationIDs(SaveCountStats.ChestsOpened, chestsIDs);

            List<long> roomIDs = allServerLocations.GetRange(roomPointsIndex.startIndex, roomPointsIndex.range);
            AchievementLocationCheckHandler.SetStatLocationIDs(SaveCountStats.RoomPoints, roomIDs);

            List<long> cashIDs = allServerLocations.GetRange(cashSpentIndex.startIndex, cashSpentIndex.range);
            AchievementLocationCheckHandler.SetStatLocationIDs(SaveCountStats.CashSpent, cashIDs);

            List<long> serverRemainingLocations = Session.Locations.AllMissingLocations.ToList();

            serverRemainingLocations.Except(chestsIDs);
            serverRemainingLocations.Except(roomIDs);
            serverRemainingLocations.Except(cashIDs);

            APPickUpItem.RegisterLocationIDs(serverRemainingLocations.ToArray());

            return;
        }

        //
        //
        // ============================ DATA SENDER ==========================================
        //
        //

        public class DataSender
        {

            public static void SendFoundLocationCheck(long idToSend)
            {
                ScoutFoundLocationCheck(idToSend);
                Session.Locations.CompleteLocationChecks(idToSend);

                return;
            }


            public static void SendDeathlink(string playerName = "Gungeoneer", string causeOfDeath = "Died to Gungeon")
            {
                if (DeathLinkService == null || Session == null)
                {
                    ArchipelagoGUI.ConsoleLog("Tried to send Deathlink but not connected!");
                    return;
                }

                string deathName = PlayerServerInfo.PlayerName;

                DeathLinkService.SendDeathLink(new DeathLink(deathName, causeOfDeath));
                return;
            }

            public static void PullBasicCountStatsData()
            {
                if (Session == null)
                {
                    ArchipelagoGUI.ConsoleLog("ERROR: Not connected to Archipelago!");
                    return;
                }

                SaveCountStats[] basicCountStats = new SaveCountStats[]
                {
                    SaveCountStats.CashSpent,
                    SaveCountStats.RoomPoints,
                    SaveCountStats.ChestsOpened,
                    SaveCountStats.BlobulordKills,
                    SaveCountStats.OldKingKills,
                    SaveCountStats.RatKills,
                    SaveCountStats.DragunKills,
                    SaveCountStats.LichKills,
                    SaveCountStats.AdvancedDragunKills,
                };

                foreach (SaveCountStats countStat in basicCountStats)
                {
                    AsyncPullCountFromServer(countStat);
                }

                

                return;
            }

            protected static void AsyncPullCountFromServer(SaveCountStats statToPull)
            {
                Session.DataStorage[Scope.Slot, CountSaveData.CountStatToKeys[statToPull].CountKey].GetAsync(
                    statValue => DataReceiver.OnStatPulledFromServer(statToPull,statValue));
                return;
            }


            public static void CheckForGameCompletion()
            {
                foreach (CompletionGoals goalEnum in (CompletionGoals[])Enum.GetValues(typeof(CompletionGoals)))
                {
                    SaveCountStats correspondingStat = CountSaveData.GoalToSaveStat[goalEnum];
                    int statData = CountSaveData.GetCountStat(correspondingStat);

                    if (Convert.ToInt32(PlayerSlotSettings[CompletionKeys[goalEnum]] ) == 1)
                    {

                        if (statData < 0)
                        {
                            AsyncPullCountFromServer(correspondingStat);
                            return;
                        }

                        if (statData < 1)
                        {
                            return;
                        }
                    }

                }

                SendGameCompletion();
                return;
            }

            private static void SendGameCompletion()
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

            public static void AddToGoalCount(SaveCountStats statToAdd, int numberToAdd)
            {

                if (Session == null || Session.Socket.Connected == false)
                {
                    ArchipelagoGUI.ConsoleLog("TODO: Add local progress writer for goal");
                    return;
                }

                if (CountSaveData.GetCountStat(statToAdd) < 0)
                {
                    AsyncPullCountFromServer(statToAdd);
                }

                int goalsMet = CountSaveData.AddToGoalCount(statToAdd, numberToAdd);

                if (goalsMet >= 1)
                {
                    SendCountGoalLocationCheck(statToAdd, goalsMet);
                }
            }

            private static void SendCountGoalLocationCheck(SaveCountStats statCategory, int locationChecks)
            {
                AchievementLocationCheckHandler.SendStatLocationChecks(statCategory, locationChecks);
                CountSaveData.RemoveClearedGoals(statCategory, locationChecks);

                int statCountForServer = CountSaveData.GetCountStat(statCategory);
                Session.DataStorage[Scope.Slot, CountSaveData.CountStatToKeys[statCategory].CountKey] = statCountForServer;
                return;
            }


            public static void SendLocalIncrementalCountValuesToServer()
            {
                if (Session == null || Session.Socket.Connected == false)
                {
                    return;
                }

                foreach (SaveCountStats countStat in (SaveCountStats[])Enum.GetValues(typeof(SaveCountStats)))
                {
                    int statData = CountSaveData.GetCountStat(countStat);

                    if(statData > -1)
                    {
                        Session.DataStorage[Scope.Slot, CountSaveData.CountStatToKeys[countStat].CountKey] = statData;

                        ArchDebugPrint.DebugLog(DebugCategory.ServerSend, $"Sending count for {countStat}: {statData}");
                    }

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
                        ArchDebugPrint.DebugLog(DebugCategory.ServerReceive, $"Item ID: {locationInfoPacket[key].ItemId} Item: {locationInfoPacket[key].Player}'s + {locationInfoPacket[key].ItemName} from {locationInfoPacket[key].ItemGame}");
                    }
                },

                  locationList);

                return;
            }

        }

        //
        //
        // ============================ DATA RECEIVER ==========================================
        //
        //

        public class DataReceiver
        {

            public static void OnPacketReceived(ArchipelagoPacketBase packet)
            {

                //ArchipelagoGUI.ConsoleLog(packet);

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
                ArchDebugPrint.DebugLog(DebugCategory.ServerReceive, $"OnItemReceived - {itemInfo.ItemId} -- {itemInfo.ItemName}");


                AddItemToLocalGungeon(itemInfo);

                helper.DequeueItem();
                return;
            }

            
            public static void OnMessageReceived(LogMessage message)
            {
                ArchipelagoGUI.ConsoleLog(message.ToString());
            }

            public static void OnStatPulledFromServer(SaveCountStats statToPull, JToken statValue)
            {
                int count = statValue.ToObject<int>();
                ArchDebugPrint.DebugLog(DebugCategory.ServerReceive, $"Received from server {statToPull} -- Count: {count}");


                if ((int)statValue < 0)
                {
                    ArchipelagoGUI.ConsoleLog($"Something went very wrong with {statToPull} data, saved as negative on server");
                    ArchipelagoGUI.ConsoleLog($"RESETTING {statToPull} TO ZERO");

                    Session.DataStorage[Scope.Slot, CountSaveData.CountStatToKeys[statToPull].CountKey] = 0;
                    count = 0;
                }

                CountSaveData.SetCountStat(statToPull, count);
            }
        }

    }

    public class TimedServerCalls:MonoBehaviour
    {
        public IEnumerator PullServerDataOnDelay(float waitTime = 1.0f)
        {

            ArchipelagoGUI.ConsoleLog($"Pulling server data, please standby ============== ");

            yield return new WaitForSeconds(waitTime);

            SessionHandler.DataSender.PullBasicCountStatsData();

        }
    }
}
