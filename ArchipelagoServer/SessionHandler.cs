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
using ArchiGungeon.GungeonEventHandlers;
using ArchiGungeon.ModConsoleVisuals;
using ArchiGungeon.EnemyHandlers;
using ArchiGungeon.DebugTools;
using ArchiGungeon.Character;
using System.Collections.ObjectModel;
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

        #endregion

        #region Item Handling Variables
        private static List<long> itemsHandledThisRun = new List<long>();
        private static List<long> item_add_queue = new();

        private static bool IsProgressItemsGiven { get; set; } = false;
        public static bool IsValidToSpawnItems { get; private set; } = false;
        #endregion

        #region Randomizer Parameter Variables
        public static DeathLinkService DeathLinkService { get; protected set; }

        private static bool HandlingDeathlinkEvent { get; set; } = false;

        private static bool ShouldOutputCheckBeInteruppted { get; set; } = false;
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

            //InitializeServerDataStorage();
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

            CheckCoroutineHelperValid();
            CoroutineHelperObject.StartCoroutine(CoroutineHelperObject.RetrieveDataAfterSlotDataPullDelay());

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

        private static void InitializeServerDataStorage()
        {
            ArchDebugPrint.DebugLog(DebugCategory.InitializingGameState, "Init server storage keys");
            //session.DataStorage["ChestsOpened"].OnValueChanged += DataReceiver.OnChestsOpenedValueChange;

            // basic counting
            foreach (SaveCountStats countStatEnum in (SaveCountStats[])Enum.GetValues(typeof(SaveCountStats)))
            {

                Session.DataStorage[Scope.Slot, CountSaveData.CountStatToKeys[countStatEnum].CountKey].Initialize(0);
            }


            return;
        }

        private static void PullPlayerYAMLSlotData()
        {
            ArchDebugPrint.DebugLog(DebugCategory.InitializingGameState, $"Pulling slot data");

            PlayerSlotSettings = Session.DataStorage.GetSlotData();
            RoomSeed = Session.RoomState.Seed;

            foreach (string key in PlayerSlotSettings.Keys)
            {
                ArchDebugPrint.DebugLog(DebugCategory.InitializingGameState, $"KEY: {key} -- VALUE: {PlayerSlotSettings[key]}");
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
            CountSaveData.SetGoalList(userAchievementCase);

            List<SaveCountStats> countStatLocationChecks = CountSaveData.GetListOfStatsWithGoals();
            foreach (SaveCountStats stats in countStatLocationChecks)
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

            CheckCoroutineHelperValid();
            CoroutineHelperObject.StartCoroutine(CoroutineHelperObject.WaitForParadoxReint());


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

        public static void RetrieveServerItems()
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

        public static void CheckForUnhandledServerItems()
        {
            if (Session == null)
            {
                
                return;
            }

            if(Session.Socket.Connected == false)
            {
                return;
            }

            ArchDebugPrint.DebugLog(DebugCategory.ServerReceive, $"Checking for unhandled items");

            ReadOnlyCollection<ItemInfo> allItemsReceived = Session.Items.AllItemsReceived;

            foreach (var item in allItemsReceived)
            {
                ArchDebugPrint.DebugLog(DebugCategory.ServerReceive, $"Checking item on server: {item.ItemName} -- {item.ItemId}");
                if (!itemsHandledThisRun.Contains(item.ItemId))
                {
                    ArchDebugPrint.DebugLog(DebugCategory.ServerReceive, $"Unhandled item: {item.ItemName} -- {item.ItemId}");
                    AddItemToLocalGungeon(item);
                }
            }

            return;
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

        public static void HandleParadoxModeInit()
        {

            RetrieveServerItems();
            CheckForProgressItems();

            IsValidToSpawnItems = true;
            //CheckReverseCurse();
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
            if (reverseCurseModeValue == 1 && CountSaveData.GetCountStat(SaveCountStats.PastKills) > 0)
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
            if (Session == null)
            {
                ArchipelagoGUI.ConsoleLog("ERROR: Not connected to Archipelago!");
                return;
            }
            ShouldOutputCheckBeInteruppted = false;

            DataSender.CheckForGameCompletion();

            if (ShouldOutputCheckBeInteruppted)
            {
                ArchipelagoGUI.ConsoleLog("\n\nHad to pull server data for Goal Progress. Please hold ========== \n");

                CheckCoroutineHelperValid();
                CoroutineHelperObject.StartCoroutine(CoroutineHelperObject.DelayOutputRepeatCall());

                return;
            }

            foreach (PlayerCompletionGoals playerGoal in (PlayerCompletionGoals[])Enum.GetValues(typeof(PlayerCompletionGoals)))
            {
                List<SaveCountStats> statsForGoal = new List<SaveCountStats>();

                if (playerGoal == PlayerCompletionGoals.PastsFull || playerGoal == PlayerCompletionGoals.PastsBase)
                {
                    int pastsCase = Convert.ToInt32(PlayerSlotSettings[GameCompletionGoalKeys[PlayerCompletionGoals.PastsFull]]);

                    if (pastsCase == 1 && playerGoal == PlayerCompletionGoals.PastsBase)
                    {
                        statsForGoal = CountSaveData.GoalToStatChecks[PlayerCompletionGoals.PastsBase].ToList();
                    }
                    else if (pastsCase == 2 && playerGoal == PlayerCompletionGoals.PastsFull)
                    {
                        statsForGoal = CountSaveData.GoalToStatChecks[PlayerCompletionGoals.PastsFull].ToList();
                    }
                }

                else if (Convert.ToInt32(PlayerSlotSettings[GameCompletionGoalKeys[playerGoal]]) == 1)
                {
                    statsForGoal = CountSaveData.GoalToStatChecks[playerGoal].ToList();

                }

                foreach (SaveCountStats statCheck in statsForGoal)
                {
                    int statCount = CountSaveData.GetCountStat(statCheck);
                    string killConfirm = "*** YES ****";

                    if (statCount < 1)
                    {
                        killConfirm = "NO";
                    }

                    ArchipelagoGUI.ConsoleLog($"Game completion goal -- {playerGoal}: {statCheck} -- Killed: {killConfirm}");
                }
            }



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

                foreach (PlayerCompletionGoals playerGoalEnum in (PlayerCompletionGoals[])Enum.GetValues(typeof(PlayerCompletionGoals)))
                {
                    List<SaveCountStats> statsToCheck = new List<SaveCountStats>();

                    //Setup stats to check for goal completion
                    if (playerGoalEnum == PlayerCompletionGoals.PastsFull || playerGoalEnum == PlayerCompletionGoals.PastsBase)
                    {
                        int pastsCase = Convert.ToInt32(PlayerSlotSettings[GameCompletionGoalKeys[PlayerCompletionGoals.PastsFull]]);

                        if (pastsCase == 1)
                        {
                            ArchDebugPrint.DebugLog(DebugCategory.GameCompletion, $"Checking Base 4 Pasts");
                            statsToCheck = CountSaveData.GoalToStatChecks[PlayerCompletionGoals.PastsBase].ToList();
                        }
                        else if (pastsCase == 2)
                        {
                            ArchDebugPrint.DebugLog(DebugCategory.GameCompletion, $"Checking 6 Pasts");
                            statsToCheck = CountSaveData.GoalToStatChecks[PlayerCompletionGoals.PastsFull].ToList();
                        }
                    }

                    else if (Convert.ToInt32(PlayerSlotSettings[GameCompletionGoalKeys[playerGoalEnum]]) == 1)
                    {
                        ArchDebugPrint.DebugLog(DebugCategory.GameCompletion, $"{playerGoalEnum} marked for game completion check by Slot Data");
                        statsToCheck = CountSaveData.GoalToStatChecks[playerGoalEnum].ToList();
                    }

                    // Iterate through savecountstats enum
                    foreach (SaveCountStats statCheck in statsToCheck)
                    {
                        int statCount = CountSaveData.GetCountStat(statCheck);
                        if (statCount < 1)
                        {
                            ArchDebugPrint.DebugLog(DebugCategory.GameCompletion, $"Goal {statCheck} not met, STOPPING game completion check");
                            return;
                        }
                    }
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

        public IEnumerator RetrieveDataAfterSlotDataPullDelay(float waitTime = 1.0f)
        {
            ArchipelagoGUI.ConsoleLog($"Waiting for Archipelago data, please standby ============== ");

            yield return new WaitForSeconds(waitTime);

            SessionHandler.InitializeSaveData();

            SessionHandler.CheckForSlotDataInstantiation();
            SaveDataManagement.CheckFullCountStatsForGoals();

        }

        public IEnumerator WaitForParadoxReint(float waitTime = 2f)
        {
            ArchipelagoGUI.ConsoleLog("Starting paradox mode! Need to initialize backend");
            yield return new WaitForSeconds(waitTime);

            SessionHandler.HandleParadoxModeInit();
        }

        public IEnumerator CheckIfStatInitFailed(SaveCountStats statToCheck, float waitTime = 10.0f)
        {
            yield return new WaitForSeconds(waitTime);

            if(CountSaveData.GetCountStat(statToCheck) == -1)
            {
                ArchipelagoGUI.ConsoleLog("Detected archipelago broken connection, reconnecting");
                SessionHandler.ReconnectSession();
            }

        }

        public IEnumerator DelayOutputRepeatCall(float waitTime = 3.0f)
        {
            yield return new WaitForSeconds(waitTime);

            SessionHandler.OutputGameGoalStatus();
        }
    }

    #endregion
}
