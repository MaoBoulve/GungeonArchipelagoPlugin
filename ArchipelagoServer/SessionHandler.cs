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
using ArchiGungeon.ItemArchipelago;
using ArchiGungeon.GungeonEventHandlers;
using ArchiGungeon.UserInterface;
using ArchiGungeon.EnemyHandlers;
using ArchiGungeon.DebugTools;
using ArchiGungeon.Character;
using ArchiGungeon.Data;

namespace ArchiGungeon.ArchipelagoServer
{

    public class SessionHandler : MonoBehaviour
    {
        public static ArchipelagoSession Session { get; protected set; }
        private static string RoomSeed { get; set; }

        #region Initializing Variables
        private static Dictionary<string, object> PlayerSlotSettings { get; set; } = new Dictionary<string, object>(); // player settings, use to initialize data
        private static PlayerConnectionInfo PlayerServerInfo { get; set; }

        private static Dictionary<PlayerCompletionGoals, string> GameCompletionGoalKeys { get; } = new Dictionary<PlayerCompletionGoals, string>()
        {
            { PlayerCompletionGoals.Dragun, "Dragun" },
            { PlayerCompletionGoals.Lich, "Lich" },
            { PlayerCompletionGoals.PastsBase, "Pasts" },
            { PlayerCompletionGoals.PastsFull, "Pasts" },
            { PlayerCompletionGoals.SecretChamber, "BaseSecret" },
            { PlayerCompletionGoals.AdvancedGungeon, "AdvancedGungeon" },
            { PlayerCompletionGoals.FarewellArms, "FarewellArms" },
        };

        public static bool IsGoalsTextBoxOpen { get; private set; } = false;

        #endregion

        #region Item Handling Variables
        private static List<ItemInfo> allItemsReceivedFromServer = new List<ItemInfo>();
        private static bool hasRetrievedServerItemsOnce = false;
        private static List<long> itemsHandledThisRun = new List<long>();
        private static List<long> item_add_queue = new();

        private static bool IsProgressItemsGiven { get; set; } = false;
        public static bool IsValidToSpawnItems { get; private set; } = false;
        #endregion

        #region Randomizer Parameter Variables
        public static DeathLinkService DeathLinkService { get; protected set; }

        private static bool HandlingDeathlinkEvent { get; set; } = false;
        #endregion



        #region Connection Handling
        // CONNECTION HANDLING ===============================

        public static void ArchipelagoConnect(string ip, string port, string name, string password = "")
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

            ArchDebugPrint.DebugLog(DebugCategory.InitializingGameState, $"Login successful, handling initializing via Slot Data");
            PullPlayerYAMLSlotData();

            BindToArchipelagoEvents();
            CheckToCreateDeathlink();
            CheckToRandomizeEnemies();


            PlayerServerInfo = new PlayerConnectionInfo(ip, port, name, password, RoomSeed);
            ConnectionDataWriter.SaveArchipelagoConnectionSettings(PlayerServerInfo);

            InitializeAPLocationChecks();

            TrapSpawnHandler.SetCanSpawn(true);
            ConsumableSpawnHandler.SetCanSpawn(true);

            ArchipelagoGUI.ConsoleLog("Connected to Archipelago server.");

            // close console UI on successful connect
            ArchipelagoGUI.Instance.OnClose();

            if(!TimedServerCalls.IsRetrieveDataCoroutineRunning)
            {
                CheckCoroutineHelperValid();
                CoroutineHelperObject.StartCoroutine(CoroutineHelperObject.RetrieveDataAfterSlotDataPullDelay());
            }

            return;
        }


        private static LoginResult LoginToArchipelago(string ip, string port, string name, string password = "")
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


        private static void PullPlayerYAMLSlotData()
        {
            ArchDebugPrint.DebugLog(DebugCategory.InitializingGameState, $"Pulling slot data");

            PlayerSlotSettings = Session.DataStorage.GetSlotData();
            RoomSeed = Session.RoomState.Seed;
            SetPlayerCompletionGoalsDataFromSlotData();

            foreach (string key in PlayerSlotSettings.Keys)
            {
                ArchDebugPrint.DebugLog(DebugCategory.InitializingGameState, $"KEY: {key} -- VALUE: {PlayerSlotSettings[key]}");
            }


            return;
        }

        private static void SetPlayerCompletionGoalsDataFromSlotData()
        {
            foreach (PlayerCompletionGoals possiblePlayerGoal in (PlayerCompletionGoals[])Enum.GetValues(typeof(PlayerCompletionGoals)))
            {

                // check all goals and see if player has key for goal set to true/1
                if (possiblePlayerGoal == PlayerCompletionGoals.PastsFull || possiblePlayerGoal == PlayerCompletionGoals.PastsBase)
                {
                    int chosenPlayerPastsCase = Convert.ToInt32(PlayerSlotSettings[GameCompletionGoalKeys[PlayerCompletionGoals.PastsFull]]);

                    if (chosenPlayerPastsCase == 1 && possiblePlayerGoal == PlayerCompletionGoals.PastsBase)
                    {
                        ArchipelagoCompletion.AddToCompletionGoalsToCheck(PlayerCompletionGoals.PastsBase);
                    }
                    else if (chosenPlayerPastsCase == 2 && possiblePlayerGoal == PlayerCompletionGoals.PastsFull)
                    {
                        ArchipelagoCompletion.AddToCompletionGoalsToCheck(PlayerCompletionGoals.PastsFull);
                    }
                }

                else if (Convert.ToInt32(PlayerSlotSettings[GameCompletionGoalKeys[possiblePlayerGoal]]) == 1)
                {
                    ArchipelagoCompletion.AddToCompletionGoalsToCheck(possiblePlayerGoal);
                }
            }

            return;
        }

        // TODO: implement when APWorld updates
        private static void CheckAPWorldVersion()
        {
            ArchDebugPrint.DebugLog(DebugCategory.InitializingGameState, $"Checking AP World compatability");
            if (PlayerSlotSettings.ContainsKey("APWorld"))
            {
                if ((string)PlayerSlotSettings["APWorld"] == ArchipelaGunPlugin.AP_WORLD_VERSION)
                {
                    ArchDebugPrint.DebugLog(DebugCategory.InitializingGameState, "AP World matches!");
                    return;
                }

            }

            ArchipelagoGUI.ConsoleLog("============= INCOMPATIBLE AP WORLD VERSION ==============");

            ArchipelagoGUI.ConsoleLog($"ArchipelaGun Mod looking for APWorld {ArchipelaGunPlugin.AP_WORLD_VERSION}");
            ArchipelagoGUI.ConsoleLog("Lotsa stuff will break with mismatching versions!");

            ArchipelagoGUI.ConsoleLog("============= INCOMPATIBLE AP WORLD VERSION ==============");

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

        public static void ReconnectSession()
        {
            if (Session == null)
            {
                ServerConnectWithLocalData();
                //ArchipelagoGUI.ConsoleLog("Not connected to a session!");
                return;
            }
            else if (Session.Socket.Connected == false)
            {
                ServerConnectWithLocalData();
                //ArchipelagoGUI.ConsoleLog("Not connected to a session!");
                return;
            }

            ArchipelagoGUI.ConsoleLog("Cycling connection to Archipelago");

            DisconnectFromSession();
            ArchipelagoConnect(PlayerServerInfo.IP, PlayerServerInfo.Port, PlayerServerInfo.PlayerName, PlayerServerInfo.Password);

            return;

        }

        public static void ServerConnectWithLocalData()
        {
            if (ConnectionDataWriter.CheckPreviousConnectionExists() == true)
            {
                PlayerConnectionInfo localConnectData = ConnectionDataWriter.SavedConnectionSettings;
                ArchipelagoConnect(localConnectData.IP, localConnectData.Port, localConnectData.PlayerName, localConnectData.Password);
            }
            else
            {
                ArchipelagoGUI.ConsoleLog("No data for previous connection could be found!");
            }
                return;
        }

        #endregion

        #region Archipelago Initializing
        private static void BindToArchipelagoEvents()
        {
            ArchDebugPrint.DebugLog(DebugCategory.InitializingGameState, $"Binding to Session delegate events");

            // binds

            Session.Items.ItemReceived += DataReceiver.OnItemReceived;

            //Session.Socket.PacketReceived += DataReceiver.OnPacketReceived;
            //Session.MessageLog.OnMessageReceived += DataReceiver.OnMessageReceived;

            return;
        }


        // =====================================================================
        // LOCATION CHECKS =========================================================================
        // ===================================================
        private static void InitializeAPLocationChecks()
        {
            ArchDebugPrint.DebugLog(DebugCategory.InitializingGameState, $"Creating Location Checks");

            int userAchievementCase = Convert.ToInt32(PlayerSlotSettings["AchievementChecks"]);
            CountGoalManager.SetGoalList(userAchievementCase);

            List<CountStats> countStatLocationChecks = CountGoalManager.GetListOfStatsWithGoals();
            foreach (CountStats stats in countStatLocationChecks)
            {
                AchievementLocationCheckHandler.SetStatLocationIDsFromGoalList(stats);
            }

            int itemLocationCheckCase = Convert.ToInt32(PlayerSlotSettings["APItemChecks"]);


            int baseChecks = APPickUpItem.GetBaseAPItemAmount(itemLocationCheckCase);
            int extraLocations = Convert.ToInt32(PlayerSlotSettings["ExtraLocations"]);
            int totalChest = baseChecks + extraLocations;

            APPickUpItem.RegisterAPItemLocations(totalChest);


            //List<long> allServerLocations = Session.Locations.AllLocations.ToList();
            //ArchipelagoGUI.ConsoleLog($"There are {allServerLocations.Count} total locations in gungeon");

            return;
        }

        // RUN START ===========================================================

        public static void CheckForSlotDataInstantiation()
        {
            if (Session == null)
            {

                return;
            }

            if (Session.Socket.Connected == false)
            {
                return;
            }

            CheckToInitializeParadoxMode();

            if(!TimedServerCalls.IsDelayedItemInitCoroutineRunning)
            {
                CheckCoroutineHelperValid();
                CoroutineHelperObject.StartCoroutine(CoroutineHelperObject.HandleDelayedItemInit());
            }
            
            return;

        }

        #endregion


        #region Save Data Management

        public static void InitializeSaveData()
        {
            if (Session == null)
            {
                ArchipelagoGUI.ConsoleLog("ERROR: Not connected to Archipelago!");
                return;
            }

            ArchDebugPrint.DebugLog(DebugCategory.InitializingGameState, $"Handling save data initialization");
            SaveDataManagement.TryPreviousSaveLoad(playerInfo: PlayerServerInfo);

            return;
        }


        #endregion


        #region Item Handling

        // ITEM RETRIEVAL ===============================

        public static void ResetVariablesToStartOfRun()
        {
            ArchDebugPrint.DebugLog(DebugCategory.PluginStartup, "Resetting variables for new run");

            //SpawnedItemLog.ClearSpawnedItemLog();
            itemsHandledThisRun.Clear();
            IsReverseCurseSetForRun = false;
            IsProgressItemsGiven = false;
            IsValidToSpawnItems = false;
            HandlingDeathlinkEvent = false;

            return;
        }

        public static void RetrieveItemsFromServer()
        {

            TrapSpawnHandler.SetCanSpawn(false);
            ConsumableSpawnHandler.SetCanSpawn(false);

            if (Session == null)
            {
                ArchipelagoGUI.ConsoleLog("ERROR: Not connected to Archipelago!");
                return;
            }


            var itemList = Session.Items.AllItemsReceived;

            ArchipelagoGUI.ConsoleLog($"Retrieving server items!");

            foreach (var item in itemList)
            {
                if(!allItemsReceivedFromServer.Contains(item))
                {
                    allItemsReceivedFromServer.Add(item);

                    if (!itemsHandledThisRun.Contains(item.ItemId))
                    {
                        AddItemToLocalGungeon(item);
                    }
                }   
            }

            hasRetrievedServerItemsOnce = true;
            TrapSpawnHandler.SetCanSpawn(true);
            ConsumableSpawnHandler.SetCanSpawn(true);

            return;
        }

        private static void RetrieveItemsFromLocalData()
        {
            TrapSpawnHandler.SetCanSpawn(false);
            ConsumableSpawnHandler.SetCanSpawn(false);

            ArchipelagoGUI.ConsoleLog($"Retrieving items based on local data!");
            
            foreach(ItemInfo item in allItemsReceivedFromServer)
            {
                if (!itemsHandledThisRun.Contains(item.ItemId))
                {
                    AddItemToLocalGungeon(item);
                }
            }

            TrapSpawnHandler.SetCanSpawn(true);
            ConsumableSpawnHandler.SetCanSpawn(true);

            return;
        }

        
        public static void AddItemToLocalGungeon(ItemInfo itemInfo)
        {
            if(TrapSpawnHandler.IsSpawnValid == false)
            {
                if(itemInfo.ItemId >= 8754200 && itemInfo.ItemId < 8754300)
                {
                    ArchDebugPrint.DebugLog(DebugCategory.ServerReceive, $"Skipping item on Retrieve command: {itemInfo.ItemName}");

                    itemsHandledThisRun.Add(itemInfo.ItemId);

                    return;
                }
            }

            //GungeonControl.GiveGungeonItem(itemInfo.ItemId);

            ArchDebugPrint.DebugLog(DebugCategory.ServerReceive, $"Receiving item: {itemInfo.ItemName}");

            item_add_queue.Add(itemInfo.ItemId);

            return;
        }

        public static void HandleDelayedItemInitialize()
        {
            if(hasRetrievedServerItemsOnce)
            {
                RetrieveItemsFromLocalData();
            }
            else
            {
                RetrieveItemsFromServer(); 
            }

            CheckForProgressItems();

            IsValidToSpawnItems = true;
            //CheckReverseCurse();
        }


        private static void CheckForProgressItems()
        {
            if (IsProgressItemsGiven)
            {
                return;
            }

            if (Convert.ToInt32(PlayerSlotSettings[GameCompletionGoalKeys[PlayerCompletionGoals.PastsFull]]) != 0)
            {
                ProgressionItemSpawnHandler.GivePastBullet();
            }

            if (Convert.ToInt32(PlayerSlotSettings[GameCompletionGoalKeys[PlayerCompletionGoals.AdvancedGungeon]]) == 1)
            {
                ProgressionItemSpawnHandler.GiveRatNotes();
            }

            IsProgressItemsGiven = true;
        }

        public static void TickCheckItemQueue()
        {
            if (item_add_queue.Count > 0 && IsValidToSpawnItems)
            {
                ArchDebugPrint.DebugLog(DebugCategory.ItemHandling, $"Handling item ID: {item_add_queue[0]}");

                try
                {
                    ArchipelagoGungeonBridge.GiveGungeonItem(item_add_queue[0]);
                    itemsHandledThisRun.Add(item_add_queue[0]);
                }


                catch (Exception ex)
                {
                    ArchipelagoGUI.ConsoleLog("Exception caused during handling giving Archipelago item. Please contact dev: " + ex);
                }

                item_add_queue.RemoveAt(0);
            }

            return;
        }

        #endregion


        #region Deathlink
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
            if (DeathLinkService == null || Session == null)
            {
                ArchipelagoGUI.ConsoleLog("Not connected to a session!");
                return;
            }

            switch (modeToSet)
            {
                case 0:
                    ArchipelagoGUI.ConsoleLog("Deathlink has been DISABLED");
                    DeathLinkService.DisableDeathLink();
                    return;
                case 1:
                    ArchipelagoGUI.ConsoleLog("Deathlink has been ENABLED");
                    DeathLinkService.EnableDeathLink();
                    return;
                case 2:
                    ArchipelagoGUI.ConsoleLog("Deathlink has been ENABLED");
                    DeathLinkService.EnableDeathLink();
                    return;
                default:
                    ArchipelagoGUI.ConsoleLog("Invalid deathlink mode setting!");
                    return;
            }
        }
        #endregion

        #region Enemies
        // ENEMIES =========================================================

        private static void CheckToRandomizeEnemies()
        {

            if (Convert.ToInt32(PlayerSlotSettings["RandomEnemies"]) == 1)
            {
                InitializeEnemySwapper();
                ArchDebugPrint.DebugLog(DebugCategory.InitializingGameState, "Random enemies");
            }
            else
            {
                ArchDebugPrint.DebugLog(DebugCategory.InitializingGameState, "Enemies not randomized");
            }
            return;
        }


        // ENEMY SWAPPER ==========================================


        private static void InitializeEnemySwapper()
        {
            System.Security.Cryptography.MD5 md5Hasher = System.Security.Cryptography.MD5.Create();
            var hashed = md5Hasher.ComputeHash(Encoding.UTF8.GetBytes(RoomSeed));
            int seed = BitConverter.ToInt32(hashed, 0);

            EnemySwapping.MakeNormalShuffleEnemies(seed);
            return;
        }

        public static void SetEnemyShuffleMode(int modeEntry)
        {
            if (Session == null)
            {
                ArchipelagoGUI.ConsoleLog("Not connected to a session!");
                return;
            }

            if (modeEntry == 0)
            {
                ArchipelagoGUI.ConsoleLog("Enemy shuffle has been DISABLED");
                EnemySwapping.ClearAllShuffleLists();
            }
            else if (modeEntry == 1)
            {
                ArchipelagoGUI.ConsoleLog("Enemy shuffle has been ENABLED");
                InitializeEnemySwapper();
            }
            else
            {
                ArchipelagoGUI.ConsoleLog("Invalid enemy shuffle mode setting!");
            }
            return;
        }

        #endregion

        #region Paradox Mode
        // PARADOX MODE =========================================================

        private static bool CheckToInitializeParadoxMode()
        {

            if (Convert.ToInt32(PlayerSlotSettings["Paradox"]) == 1)
            {
                PlayerController playerController = GungeonPlayerEventListener.GetFirstAlivePlayer();

                //ETGModConsole.Instance?.ParseCommand("character paradox");
                //GameObject archipelItem = PickupObjectDatabase.GetById(Archipelagun.SpawnItemID).gameObject;
                //LootEngine.SpawnItem(archipelItem, playerController.CenterPosition, Vector2.zero, 0);

                CharSwap.StartParadoxMode(playerController);

                return true;
            }

            return false;
        }

        #endregion

        #region Reverse Curse

        // REVERSE CURSE =================================================

        private static bool IsReverseCurseSetForRun { get; set; } = false;
        private static void CheckReverseCurse()
        {
            if(IsReverseCurseSetForRun)
            {
                return;
            }

            ArchDebugPrint.DebugLog(DebugCategory.InitializingGameState, $"Checking for reverse curse");
            int reverseCurseModeValue = Convert.ToInt32(PlayerSlotSettings["ReverseCurse"]);


            // Check for past kills
            if (reverseCurseModeValue == 1 && CountGoalManager.GetCountStat(CountStats.PastKills) > 0)
            {
                ArchDebugPrint.DebugLog(DebugCategory.InitializingGameState, $"Giving curse items after past check");
                ArchipelagoGungeonBridge.GiveReverseCurse(8);
            }
            else if (reverseCurseModeValue == 2)
            {
                ArchDebugPrint.DebugLog(DebugCategory.InitializingGameState, $"Giving curse items without past check");
                ArchipelagoGungeonBridge.GiveReverseCurse(8);
            }

            IsReverseCurseSetForRun = true;

            return;
        }

        #endregion


        #region User Output
        // USER OUTPUT HELPER ===============================

        public static void OutputGameGoalStatus()
        {
            // TODO have a separate game progress text window
            if (Session == null)
            {
                ArchipelagoGUI.ConsoleLog("ERROR: Not connected to Archipelago!");
                return;
            }

            DataSender.CheckForGameCompletion();

            return;
        }

        public static void ShowGoalsTextbox()
        {
            if(IsGoalsTextBoxOpen)
            {
                return;
            }

            List<string> completionList = ArchipelagoCompletion.GetAllUnmetCountsForGoals();
            List<string> locationList = CountGoalManager.GetFormattedListOfRemainingGoals();

            string completionListAsString = String.Join(", ", completionList.ToArray());
            string locationListAsString = String.Join(", ", locationList.ToArray());

            string textboxOutput = $"To kill: {completionListAsString} \n\n" +
                $"Location checks: {locationListAsString}";

            TextBoxHandler.ShowArchipelagoLetterBox(GungeonPlayerEventListener.GetFirstAlivePlayer(), textboxOutput);
            IsGoalsTextBoxOpen = true;

            return;

        }

        public static void HideGoalsTextbox()
        {
            IsGoalsTextBoxOpen = false;
            TextBoxHandler.ClearAllTextboxes();
            return;
        }

        #endregion


        #region Server Communication

        // ============================ DATA SENDER ==========================================

        public class DataSender
        {

            #region High Priority Send Functions
            // High priority generally meaning, randomizer hard stops if these fail communication
            public static void SendFoundLocationCheck(long idToSend)
            {
                //ScoutFoundLocationCheck(idToSend);
                Session.Locations.CompleteLocationChecks(idToSend);

                return;
            }

            public static void SendFoundLocationCheck(long[] idArray)
            {
                Session.Locations.CompleteLocationChecks(idArray);
                return;
            }

            public static void SendDeathlink(string playerName = "Gungeoneer", string causeOfDeath = "Died to Gungeon")
            {
                if (DeathLinkService == null || Session == null)
                {
                    ArchipelagoGUI.ConsoleLog("Tried to send Deathlink but not connected!");
                    return;
                }

                if(HandlingDeathlinkEvent)
                {
                    return;
                }

                HandlingDeathlinkEvent = true;
                ArchDebugPrint.DebugLog(DebugCategory.ServerSend, $"Sending deathlink");

                string deathName = PlayerServerInfo.PlayerName;

                DeathLinkService.SendDeathLink(new DeathLink(deathName, causeOfDeath));
                return;
            }

            public static void CheckForGameCompletion()
            {
                ArchDebugPrint.DebugLog(DebugCategory.GameCompletion, "Checking for game completion");

                List<string> unmetGoalStatCounts = ArchipelagoCompletion.GetAllUnmetCountsForGoals();

                if (unmetGoalStatCounts.Count > 0)
                {
                    ArchDebugPrint.DebugLog(DebugCategory.GameCompletion, $"Remaining goals: ");

                    foreach(string goal in unmetGoalStatCounts)
                    {
                        ArchDebugPrint.DebugLog(DebugCategory.GameCompletion, goal);
                    }

                    return;
                }

                ArchDebugPrint.DebugLog(DebugCategory.GameCompletion, $"Goal checks passed! Sending completion event");

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

            #endregion

     

            #region Low Priority Send Functions
            public static void SendChatMessage(string message)
            {
                Session.Socket.SendPacketAsync(new SayPacket
                {
                    Text = message
                });
            }

            public static void ScoutFoundLocationCheck(long locationID)
            {
                ArchDebugPrint.DebugLog(DebugCategory.ServerReceive, $"Scouting location check: {locationID}");

                Session.Locations.ScoutLocationsAsync(locationInfoPacket =>
                {
                    foreach (long key in locationInfoPacket.Keys)
                    {
                        ArchDebugPrint.DebugLog(DebugCategory.ServerReceive, $"Item ID: {locationInfoPacket[key].ItemId} Item: {locationInfoPacket[key].Player}'s + {locationInfoPacket[key].ItemName} from {locationInfoPacket[key].ItemGame}");
                    }
                },
                locationID);
                return;
            }
            #endregion

        }

        // ============================ DATA RECEIVER ==========================================

        public class DataReceiver
        {
            #region High Priority Receive Calls

            public static void OnDeathlink(DeathLink deathLink)
            {
                if(HandlingDeathlinkEvent)
                {
                    return;
                }
                HandlingDeathlinkEvent = true;
                ArchDebugPrint.DebugLog(DebugCategory.ServerReceive, $"Received DeathLink");

                string playerCauser = deathLink.Source;

                string deathlinkCause = $"Deathlink by {playerCauser}";

                ArchipelagoGungeonBridge.DeathlinkKillPlayer(deathlinkCause);
                return;
            }


            public static void OnItemReceived(ReceivedItemsHelper helper)
            {
                ItemInfo itemInfo = helper.PeekItem();
                ArchDebugPrint.DebugLog(DebugCategory.ServerReceive, $"OnItemReceived - {itemInfo.ItemId} -- {itemInfo.ItemName}");

                allItemsReceivedFromServer.Add(itemInfo);

                AddItemToLocalGungeon(itemInfo);

                ItemInfo nextQueueItem = helper.DequeueItem();

                ArchDebugPrint.DebugLog(DebugCategory.ServerReceive, $"Queue item: - {nextQueueItem.ItemId} -- {nextQueueItem.ItemName}");

                return;
            }

            #endregion


            #region Low Priority Receive Calls
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

            public static void OnMessageReceived(LogMessage message)
            {
                ArchipelagoGUI.ConsoleLog(message.ToString());
            }
            #endregion
        }

        #endregion

        #region Session Coroutine Logic
        private static TimedServerCalls CoroutineHelperObject { get; set; }
        private static void CheckCoroutineHelperValid()
        {
            if (CoroutineHelperObject == null)
            {
                var tempgameObject = new GameObject();
                CoroutineHelperObject = tempgameObject.AddComponent<TimedServerCalls>();
            }

            return;
        }

        

        #endregion
    }

    #region Coroutine Handlers

    public class TimedServerCalls:MonoBehaviour
    {
        public static bool IsRetrieveDataCoroutineRunning { get; private set; } = false;

        public IEnumerator RetrieveDataAfterSlotDataPullDelay(float waitTime = 1.0f)
        {
            IsRetrieveDataCoroutineRunning = true;
            ArchipelagoGUI.ConsoleLog($"Waiting for Archipelago data, please standby ============== ");

            yield return new WaitForSeconds(waitTime);

            SessionHandler.InitializeSaveData();

            SessionHandler.CheckForSlotDataInstantiation();
            SaveDataManagement.CheckFullCountStatsForGoals();

            IsRetrieveDataCoroutineRunning = false;

        }

        public static bool IsDelayedItemInitCoroutineRunning { get; private set; } = false;

        public IEnumerator HandleDelayedItemInit(float waitTime = 2f)
        {
            IsDelayedItemInitCoroutineRunning = true;
            ArchipelagoGUI.ConsoleLog("Initializing items after initial setup, please standby =========");
            yield return new WaitForSeconds(waitTime);

            SessionHandler.HandleDelayedItemInitialize();
            SessionHandler.ShowGoalsTextbox();
            IsDelayedItemInitCoroutineRunning = false;
        }

        
    }

    #endregion
}
