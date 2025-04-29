using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alexandria.Misc;
using ArchiGungeon.ItemArchipelago;
using UnityEngine;
using ArchiGungeon.ModConsoleVisuals;
using ArchiGungeon.ArchipelagoServer;
using ArchiGungeon.EnemyHandlers;
using ArchiGungeon.DebugTools;
using Alexandria.ItemAPI;
using Alexandria.NPCAPI;

namespace ArchiGungeon.GungeonEventHandlers
{
    // See: https://github.com/Nevernamed22/Alexandria/blob/main/Misc/CustomActions.cs#L121
    public class GungeonPlayerEventListener
    {
        private static PlayerController PlayerOne { get; set; }
        private static PlayerController PlayerTwo { get; set; }
        private static bool IsOnOddCountChest { get; set; } = true;
        private static List<BaseShopController> baseShopControllers = new List<BaseShopController>();
        private static int ItemCountToReachToReplaceShopItem { get; } = 3;
        private static int CurrentShopItemCount { get; set; }

        public static PlayerController GetFirstAlivePlayer()
        {
            if (PlayerOne.healthHaver.IsAlive)
            {
                return PlayerOne;
            }
            else if (PlayerTwo.healthHaver.IsAlive)
            {
                return PlayerTwo;
            }

            return null;
        }


        private static List<string> PastKillsGuids { get; } = new List<string>()
        {
             "8d441ad4e9924d91b6070d5b3438d066",
             "dc3cd41623d447aeba77c77c99598426",
             "8b913eea3d174184be1af362d441910d",
             "b98b10fca77d469e80fb45f3c5badec5",
             "880bbe4ce1014740ba6b4e2ea521e49d",
             "39dca963ae2b4688b016089d926308ab",
        };

        private static Dictionary<string, SaveCountStats> GameCompletionGUIds { get; } = new Dictionary<string, SaveCountStats>()
        {
            { "1b5810fafbec445d89921a4efb4e42b7", SaveCountStats.BlobulordKills},
            { "5729c8b5ffa7415bb3d01205663a33ef", SaveCountStats.OldKingKills },
            { "4d164ba3f62648809a4a82c90fc22cae", SaveCountStats.RatKills },
            { "41ee1c8538e8474a82a74c4aff99c712", SaveCountStats.DeptAgunimKills },
            { "05b8afe0b6cc4fffa9dc6036fa24c8ec", SaveCountStats.AdvancedDragunKills },
            { "465da2bb086a4a88a803f79fe3a27677", SaveCountStats.DragunKills },
            { "7c5d5f09911e49b78ae644d2b50ff3bf", SaveCountStats.LichKills },

            { "8d441ad4e9924d91b6070d5b3438d066", SaveCountStats.PastHunter },
            { "dc3cd41623d447aeba77c77c99598426", SaveCountStats.PastMarine },
            { "8b913eea3d174184be1af362d441910d", SaveCountStats.PastConvict },
            { "b98b10fca77d469e80fb45f3c5badec5", SaveCountStats.PastPilot },
            { "880bbe4ce1014740ba6b4e2ea521e49d", SaveCountStats.PastRobot },
            { "39dca963ae2b4688b016089d926308ab", SaveCountStats.PastBullet },
        };

        private static Dictionary<string, SaveCountStats> BossGUIDToStat { get; } = new Dictionary<string, SaveCountStats>
        {

            //floor 1
            { "ffca09398635467da3b1f4a54bcfda80  ", SaveCountStats.Floor1Clears },
            { "ec6b674e0acd4553b47ee94493d66422 ", SaveCountStats.Floor1Clears },

            //floor 2
            { "da797878d215453abba824ff902e21b4", SaveCountStats.Floor2Clears },
            { "4b992de5b4274168a8878ef9bf7ea36b", SaveCountStats.Floor2Clears },
            { "c367f00240a64d5d9f3c26484dc35833", SaveCountStats.Floor2Clears },

            //floor 3
            { "5e0af7f7d9de4755a68d2fd3bbc15df4", SaveCountStats.Floor3Clears },
            { "fa76c8cfdf1c4a88b55173666b4bc7fb", SaveCountStats.Floor3Clears },
            { "8b0dd96e2fe74ec7bebc1bc689c0008a", SaveCountStats.Floor3Clears },
            { "9189f46c47564ed588b9108965f975c9", SaveCountStats.Floor3Clears },

            //floor 4
            { "f3b04a067a65492f8b279130323b41f0", SaveCountStats.Floor4Clears },
            { "6c43fddfd401456c916089fdd1c99b1c", SaveCountStats.Floor4Clears },

  
            //floor 5
            { "b98b10fca77d469e80fb45f3c5badec5", SaveCountStats.Floor5Clears },
            { "880bbe4ce1014740ba6b4e2ea521e49d", SaveCountStats.Floor5Clears },

            //hell
            { "7c5d5f09911e49b78ae644d2b50ff3bf", SaveCountStats.FloorHellClears},

            //oublie
            { "1b5810fafbec445d89921a4efb4e42b7", SaveCountStats.FloorGoopClears },

            //abbey
            { "5729c8b5ffa7415bb3d01205663a33ef", SaveCountStats.FloorAbbeyClears },

            //rat
            { "4d164ba3f62648809a4a82c90fc22cae", SaveCountStats.FloorRatClears },

            //dept
            { "41ee1c8538e8474a82a74c4aff99c712", SaveCountStats.FloorDeptClears },
            
        };

        private static List<string> TriggerTwinGuids { get; } = new List<string>
        {
            "ea40fcc863d34b0088f490f4e57f8913",
            "c00390483f394a849c36143eb878998f"
        };

        private static string KillPillarGuid { get; } = "3f11bbbc439c4086a180eb0fb9990cb4";

        private static int triggerTwinKills;
        private static int killPillarKills;
        private static int roomsClearedThisRun;

        public static void StartSystemEventListens()
        {
            ArchDebugPrint.DebugLog(DebugCategory.PluginStartup, "Starting Gungeon Event Listener");

            ArchipelagoGUI.OnMenuOpen += OnArchipelagoMenuOpen;
            ArchipelagoGUI.OnMenuClose += OnArchipelagoMenuClose;

            CustomActions.OnRunStart += OnRunStarted;
            CustomActions.OnBossKilled += OnBossKilled;
            CustomActions.OnNewPlayercontrollerSpawned += OnPlayerControllerSpawned;
            CustomActions.OnRewardPedestalSpawned += OnRewardPedestalSpawn;
            CustomActions.OnRewardPedestalDetermineContents += OnRewardPedestalDetermineContent;

            CustomActions.OnShopItemStarted += OnShopItemCreated;

            ETGMod.Chest.OnPreOpen += OnChestPreOpen;
            ETGMod.Chest.OnPostOpen += OnChestOpen;


            return;
        }

        // SUPER stumped on this
        private static void OnShopItemCreated(ShopItemController obj)
        {

            if (obj.CurrencyType == ShopItemController.ShopCurrencyType.META_CURRENCY|| obj.m_baseParentShop.baseShopType == BaseShopController.AdditionalShopType.FOYER_META)
            {
                ArchDebugPrint.DebugLog(DebugCategory.ItemHandling, "Shop Item replacement ignoring meta shop items");
                return;
            }

            if(obj.m_baseParentShop == null)
            {
                return;
            }

            CurrentShopItemCount++;

            if(CurrentShopItemCount < ItemCountToReachToReplaceShopItem)
            {
                return;
            }

            BaseShopController shopContext = obj.m_baseParentShop;
            baseShopControllers.Add(shopContext);

            ArchipelagoGUI.ConsoleLog(shopContext.GetType());

            ArchipelagoGUI.ConsoleLog(obj.sprite.HeightOffGround);

            obj.sprite.HeightOffGround -= .5f;

            obj.item = PickupObjectDatabase.GetById(APPickUpItem.SpawnItemID);
            obj.sprite.FlipY = true;
            //obj.sprite.HeightOffGround = .5f;


            return;
        }

        private static void OnPlayerControllerSpawned(PlayerController controller)
        {
            if(controller.characterIdentity == PlayableCharacters.CoopCultist)
            {
                ArchDebugPrint.DebugLog(DebugCategory.PluginStartup, "Player Two Controller Listener Started");
                PlayerTwo = controller;
                PlayerTwo.OnRealPlayerDeath += OnPlayerTwoDeath;
                ArchipelagoGungeonBridge.SetPlayerTwo(PlayerTwo);
            }

            else
            {
                ArchDebugPrint.DebugLog(DebugCategory.PluginStartup, "Player One Controller Listener Started");
                PlayerOne = controller;
                PlayerOne.OnRealPlayerDeath += OnPlayerOneDeath;
                ArchipelagoGungeonBridge.SetPlayerOne(PlayerOne);
            }

            //ArchipelagoGungeonBridge.SetPlayerController(Player);
            StartPlayerControllerEventListens(controller);

            return;
        }

        private static void OnArchipelagoMenuOpen()
        {
            ArchDebugPrint.DebugLog(DebugCategory.UserInterface, "Menu opened, blocking character input");
            KeyboardInputConsuming.BlockPlayerInputToCharacter(true);
            return;
        }

        private static void OnArchipelagoMenuClose()
        {
            ArchDebugPrint.DebugLog(DebugCategory.UserInterface, "Menu closed, resuming input");
            KeyboardInputConsuming.BlockPlayerInputToCharacter(false);
            return;
        }

        private static bool OnChestPreOpen(bool shouldOpen, Chest chest, PlayerController player)
        {
            // TODO TEST
            if (shouldOpen)
            {
                chest.forceContentIds = new List<int> { APPickUpItem.SpawnItemID };
            }

            return shouldOpen;
        }

        private static void OnChestOpen(Chest chest, PlayerController controller)
        {
            if (SessionHandler.Session == null || SessionHandler.Session.Socket.Connected == false)
            {
                return;
            }

            ArchDebugPrint.DebugLog(DebugCategory.ItemHandling, "Chest Opened");

            if (APPickUpItem.HasAPItemChecksRemaining())
            {
                if(IsOnOddCountChest)
                {
                    ArchDebugPrint.DebugLog(DebugCategory.ItemHandling, "Clearing chest contents");
                    chest.contents.Clear();

                    ArchDebugPrint.DebugLog(DebugCategory.ItemHandling, "Spawning AP Item");
                    chest.contents.Add(PickupObjectDatabase.GetById(APPickUpItem.SpawnItemID));
                    IsOnOddCountChest = false;
                }
                else
                {
                    IsOnOddCountChest = true;
                }
            }
            

            SessionHandler.DataSender.AddToGoalCount(SaveCountStats.ChestsOpened, 1);

            return;
        }


        private static void OnRunStarted(PlayerController controller1, PlayerController controller2, GameManager.GameMode mode)
        {
            ArchDebugPrint.DebugLog(DebugCategory.PlayerEventListener, $"Run started!");

            EnemySwapping.ResetEnemyDamageMult();
            roomsClearedThisRun = 0;
            killPillarKills = 0;
            triggerTwinKills = 0;
            SessionHandler.ResetItemRetrieveState();

            GameObject archipelItem = PickupObjectDatabase.GetById(Archipelagun.SpawnItemID).gameObject;
            LootEngine.SpawnItem(archipelItem, controller1.CenterPosition, Vector2.zero, 0);

            SessionHandler.CheckForRunStartServerSettingInstantiation();

            return;
        }


        private static void OnBossKilled(HealthHaver haver, bool arg2)
        {

            ArchDebugPrint.DebugLog(DebugCategory.PlayerEventListener, $"Boss killed: {haver.name}");
            string enemyGuid = haver.aiActor.EnemyGuid;

            if(PastKillsGuids.Contains(enemyGuid))
            {
                SessionHandler.DataSender.AddToGoalCount(SaveCountStats.PastKills, 1);
            }
            
            if(BossGUIDToStat.ContainsKey(enemyGuid))
            {
                SessionHandler.DataSender.AddToGoalCount(BossGUIDToStat[enemyGuid], 1);
            }

            else if(TriggerTwinGuids.Contains(enemyGuid))
            {
                triggerTwinKills++;

                if(triggerTwinKills == 2)
                {
                    SessionHandler.DataSender.AddToGoalCount(SaveCountStats.Floor1Clears, 1);
                }
            }

            else if (enemyGuid == KillPillarGuid)
            {
                killPillarKills++;

                if (killPillarKills == 4)
                {
                    SessionHandler.DataSender.AddToGoalCount(SaveCountStats.Floor4Clears, 1);
                }
            }

            if(GameCompletionGUIds.ContainsKey(enemyGuid))
            {
                ArchDebugPrint.DebugLog(DebugCategory.PlayerEventListener, $"Possible completion boss: {haver.name}");
                SessionHandler.DataSender.AddToGoalCount(GameCompletionGUIds[enemyGuid], 1);
                SessionHandler.DataSender.SendLocalCountValuesToServer();
                SessionHandler.DataSender.CheckForGameCompletion();

            }


            return;
        }

        
        private static void OnRewardPedestalSpawn(RewardPedestal pedestal)
        {
            //throw new NotImplementedException();
        }

        private static void OnRewardPedestalDetermineContent(RewardPedestal pedestal, PlayerController controller, CustomActions.ValidPedestalContents contents)
        {
            if(!APPickUpItem.HasAPItemChecksRemaining())
            {
                return;
            }

            if(!pedestal.IsBossRewardPedestal)
            {   
                pedestal.contents = PickupObjectDatabase.GetById(APPickUpItem.SpawnItemID);
            }
            else
            {
                ArchipelagoGungeonBridge.SpawnAPItem(1);
            }


            return;
        }


        private static void StartPlayerControllerEventListens(PlayerController playerToListen)
        {

            playerToListen.OnNewFloorLoaded += OnNewFloorLoad;
            playerToListen.OnEnteredCombat += OnPlayerEnterCombat;
            playerToListen.OnRoomClearEvent += OnRoomClear;

            playerToListen.OnItemPurchased += OnItemPurchased;
 

            playerToListen.OnKilledEnemyContext += OnKilledEnemy;
            playerToListen.OnTableFlipped += OnTableFlip;

            ArchDebugPrint.DebugLog(DebugCategory.PlayerEventListener, $"Listening to {playerToListen}");

            return;
        }

        private static void OnNewFloorLoad(PlayerController playerController)
        {
            SessionHandler.DataSender.SendLocalCountValuesToServer();

            EnemySwapping.ReduceEnemyDamageMult(1);

            return;
        }

        private static void OnPlayerEnterCombat()
        {
            // TODO: hide archipelagun
            return;
        }

        private static void OnPlayerOneDeath(PlayerController controller)
        {
            if(PlayerTwo != null)
            {
                if(!PlayerTwo.healthHaver.IsDead)
                {
                    return;
                }
            }

            SessionHandler.DataSender.SendLocalCountValuesToServer();

            string deathCause = $"Died to {controller.healthHaver.lastIncurredDamageSource} in the Gungeon";
            SessionHandler.DataSender.SendDeathlink(causeOfDeath:deathCause);
        }

        private static void OnPlayerTwoDeath(PlayerController controller)
        {

            if(PlayerOne.healthHaver.IsDead )
            {
                SessionHandler.DataSender.SendLocalCountValuesToServer();
                string deathCause = $"Died to {controller.healthHaver.lastIncurredDamageSource} in the Gungeon";
                SessionHandler.DataSender.SendDeathlink(causeOfDeath: deathCause);
            }
            
            return;
        }

        private static void OnRoomClear(PlayerController playerController)
        {
            roomsClearedThisRun += 1;


            ArchDebugPrint.DebugLog(DebugCategory.PlayerEventListener, "Adding room points: " + roomsClearedThisRun);

            SessionHandler.DataSender.AddToGoalCount(SaveCountStats.RoomPoints, roomsClearedThisRun);
            SessionHandler.CheckForUnhandledServerItems();

            return;
        }

        private static void OnItemPurchased(PlayerController playerController, ShopItemController shopItem)
        {

            if (shopItem == null)
            {
                return;
            }

            int spentMoney = shopItem.CurrentPrice;
            ArchDebugPrint.DebugLog(DebugCategory.PlayerEventListener, "Adding cash spent: " + spentMoney);

            SessionHandler.DataSender.AddToGoalCount(SaveCountStats.CashSpent, spentMoney);

            return;
        }

        private static void OnKilledEnemy(PlayerController playerController, HealthHaver enemy)
        {
            string enemyName = enemy.name;
            // TODO: add enemy headhunter check
            return;
        }

        private static void OnTableFlip(FlippableCover tableFlipped)
        {

            return;
        }
    }

    public class KeyboardInputConsuming
    {
        public static void BlockPlayerInputToCharacter(bool isBlocking)
        {
            if (GameManager.Instance?.PrimaryPlayer == null)
            {
                return;
            }
            bool isInputEnabled = !isBlocking;

            GameManager.Instance.PrimaryPlayer.enabled = isInputEnabled;
            CameraController cameraController = Camera.main?.GetComponent<CameraController>();

            if (cameraController != null)
            {
                cameraController.enabled = isInputEnabled;
            }

            return;
        }
    }
}
