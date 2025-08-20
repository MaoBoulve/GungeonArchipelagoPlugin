using Alexandria.ItemAPI;
using Alexandria.Misc;
using Alexandria.NPCAPI;
using ArchiGungeon.ArchipelagoServer;
using ArchiGungeon.Character;
using ArchiGungeon.Data;
using ArchiGungeon.DebugTools;
using ArchiGungeon.EnemyHandlers;
using ArchiGungeon.ItemArchipelago;
using ArchiGungeon.UserInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using static ETGMod;

namespace ArchiGungeon.GungeonEventHandlers
{
    #region Event Listening
    // See: https://github.com/Nevernamed22/Alexandria/blob/main/Misc/CustomActions.cs#L121
    public class GungeonPlayerEventListener
    {
        #region Tracking Variables
        private static PlayerController PlayerOne { get; set; }
        private static PlayerController PlayerTwo { get; set; }
        private static bool IsOnOddCountChest { get; set; } = true;
        private static List<BaseShopController> BaseShopControllers { get; } = new List<BaseShopController>();
        private static int ItemCountToReachToReplaceShopItem { get; } = 3;
        private static int CurrentShopItemCount { get; set; }
        private static bool PickedUpArchipelagun { get; set; }
        private static int triggerTwinKills;
        private static int killPillarKills;
        private static int roomsClearedThisRun;
        public static bool IsStartOfRun { get; private set; } = false;

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

        #endregion

        #region Gungeon IDs Definitions
        private static List<string> PastKillsGuids { get; } = new List<string>()
        {
             "8d441ad4e9924d91b6070d5b3438d066",
             "dc3cd41623d447aeba77c77c99598426",
             "8b913eea3d174184be1af362d441910d",
             "b98b10fca77d469e80fb45f3c5badec5",
             "880bbe4ce1014740ba6b4e2ea521e49d",
             "39dca963ae2b4688b016089d926308ab",
        };

        private static Dictionary<string, CountStats> GameCompletionGUIds { get; } = new Dictionary<string, CountStats>()
        {
            { "1b5810fafbec445d89921a4efb4e42b7", CountStats.BlobulordKills},
            { "5729c8b5ffa7415bb3d01205663a33ef", CountStats.OldKingKills },
            { "4d164ba3f62648809a4a82c90fc22cae", CountStats.RatKills },
            { "41ee1c8538e8474a82a74c4aff99c712", CountStats.DeptAgunimKills },
            { "05b8afe0b6cc4fffa9dc6036fa24c8ec", CountStats.AdvancedDragunKills },
            { "465da2bb086a4a88a803f79fe3a27677", CountStats.DragunKills },
            { "7c5d5f09911e49b78ae644d2b50ff3bf", CountStats.LichKills },

            { "8d441ad4e9924d91b6070d5b3438d066", CountStats.PastHunter },
            { "dc3cd41623d447aeba77c77c99598426", CountStats.PastMarine },
            { "8b913eea3d174184be1af362d441910d", CountStats.PastConvict },
            { "b98b10fca77d469e80fb45f3c5badec5", CountStats.PastPilot },
            { "880bbe4ce1014740ba6b4e2ea521e49d", CountStats.PastRobot },
            { "39dca963ae2b4688b016089d926308ab", CountStats.PastBullet },
        };

        private static Dictionary<string, CountStats> BossGUIDToStat { get; } = new Dictionary<string, CountStats>
        {

            //floor 1
            { "ffca09398635467da3b1f4a54bcfda80", CountStats.Floor1Clears },
            { "ec6b674e0acd4553b47ee94493d66422", CountStats.Floor1Clears },

            //floor 2
            { "da797878d215453abba824ff902e21b4", CountStats.Floor2Clears },
            { "4b992de5b4274168a8878ef9bf7ea36b", CountStats.Floor2Clears },
            { "c367f00240a64d5d9f3c26484dc35833", CountStats.Floor2Clears },

            //floor 3
            { "5e0af7f7d9de4755a68d2fd3bbc15df4", CountStats.Floor3Clears },
            { "fa76c8cfdf1c4a88b55173666b4bc7fb", CountStats.Floor3Clears },
            { "8b0dd96e2fe74ec7bebc1bc689c0008a", CountStats.Floor3Clears },
            { "9189f46c47564ed588b9108965f975c9", CountStats.Floor3Clears },

            //floor 4
            { "f3b04a067a65492f8b279130323b41f0", CountStats.Floor4Clears },
            { "6c43fddfd401456c916089fdd1c99b1c", CountStats.Floor4Clears },

  
            //floor 5
            { "b98b10fca77d469e80fb45f3c5badec5", CountStats.Floor5Clears },
            { "880bbe4ce1014740ba6b4e2ea521e49d", CountStats.Floor5Clears },

            //hell
            { "7c5d5f09911e49b78ae644d2b50ff3bf", CountStats.FloorHellClears},

            //oublie
            { "1b5810fafbec445d89921a4efb4e42b7", CountStats.FloorGoopClears },

            //abbey
            { "5729c8b5ffa7415bb3d01205663a33ef", CountStats.FloorAbbeyClears },

            //rat
            { "4d164ba3f62648809a4a82c90fc22cae", CountStats.FloorRatClears },

            //dept
            { "41ee1c8538e8474a82a74c4aff99c712", CountStats.FloorDeptClears },
            
        };

        private static List<string> TriggerTwinGuids { get; } = new List<string>
        {
            "ea40fcc863d34b0088f490f4e57f8913",
            "c00390483f394a849c36143eb878998f"
        };

        private static List<string> KillPillarNames { get; } = new List<string>
        {
            "AK47",
            "Shotgun",
            "Uzi",
            "DesertEagle"
        };
        #endregion

        #region General Gungeon Event Listens

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

            Archipelagun.OnPickup += OnArchipelagunPickup;

            

            return;
        }

        

        private static void OnShopItemCreated(ShopItemController obj)
        {
            if(!APPickUpItem.HasAPItemChecksRemaining())
            {
                return;
            }

            if (obj.m_baseParentShop == null)
            {
                return;
            }

            if (obj.CurrencyType == ShopItemController.ShopCurrencyType.META_CURRENCY|| obj.m_baseParentShop.baseShopType == BaseShopController.AdditionalShopType.FOYER_META)
            {
                ArchDebugPrint.DebugLog(DebugCategory.ItemHandling, "Shop Item replacement ignoring meta shop items");
                return;
            }

            

            CurrentShopItemCount++;

            if(CurrentShopItemCount < ItemCountToReachToReplaceShopItem)
            {
                return;
            }

            // reset count
            CurrentShopItemCount = 0;

            BaseShopController shopContext = obj.m_baseParentShop;
            BaseShopControllers.Add(shopContext);

            //ArchipelagoGUI.ConsoleLog(shopContext.GetType());

            //ArchipelagoGUI.ConsoleLog(obj.sprite.HeightOffGround);

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
                if(CharSwap.IsParadoxModeOn == true && controller.characterIdentity == PlayableCharacters.Eevee && PickedUpArchipelagun && IsStartOfRun)
                {
                    CharSwap.HandleLostItemsOnCharacterSwap(controller);
                    IsStartOfRun = false;
                }

                ArchDebugPrint.DebugLog(DebugCategory.PluginStartup, "Player One Controller Listener Started");
                PlayerOne = controller;
                PlayerOne.OnRealPlayerDeath += OnPlayerOneDeath;
                ArchipelagoGungeonBridge.SetPlayerOne(PlayerOne);
            }

            StartPlayerControllerEventListens(controller);

            return;
        }

        private static void OnArchipelagunPickup()
        {
            ArchDebugPrint.DebugLog(DebugCategory.UserInterface, "Archipelagun picked up, valid for events");
            PickedUpArchipelagun = true;
            return;
        }

        private static void CheckToForceArchipelagunOwnership()
        {
            if (PickedUpArchipelagun) { return; }

            PickupObject archipelaGun = PickupObjectDatabase.GetById(Archipelagun.SpawnItemID);
            GetFirstAlivePlayer().inventory.AddGunToInventory((Gun)archipelaGun, makeActive: true);

            PickedUpArchipelagun = true;
        }

        private static void OnArchipelagoMenuOpen()
        {
            ArchDebugPrint.DebugLog(DebugCategory.UserInterface, "Menu opened, blocking character input");
            PlayerInputModifier.BlockPlayerInputToCharacter(true);
            return;
        }

        private static void OnArchipelagoMenuClose()
        {
            ArchDebugPrint.DebugLog(DebugCategory.UserInterface, "Menu closed, resuming input");
            PlayerInputModifier.BlockPlayerInputToCharacter(false);
            return;
        }

        private static bool OnChestPreOpen(bool shouldOpen, Chest chest, PlayerController player)
        {
            if (SessionHandler.Session == null || SessionHandler.Session.Socket.Connected == false)
            {
                return shouldOpen;
            }

            if(!shouldOpen)
            {
                return shouldOpen;
            }

            CheckToForceArchipelagunOwnership();

            ArchDebugPrint.DebugLog(DebugCategory.ItemHandling, "Chest Pre-Open Call");

            if (APPickUpItem.HasAPItemChecksRemaining())
            {
                ArchDebugPrint.DebugLog(DebugCategory.ItemHandling, "AP Item checks still available");

                if (IsOnOddCountChest)
                {
                    ModifyChestContentsByChestType(chest);
                    
                    IsOnOddCountChest = false;
                }
                else
                {
                    IsOnOddCountChest = true;
                }
            }

            SaveDataManagement.AddToCountSaveDataEntry(CountStats.ChestsOpened, 1);
            return shouldOpen;
        }

        private static void ModifyChestContentsByChestType(Chest chestToEdit)
        {
            
            if (chestToEdit.IsRainbowChest)
            {
                chestToEdit.forceContentIds = new List<int> { APPickUpItem.SpawnItemID, APPickUpItem.SpawnItemID, APPickUpItem.SpawnItemID, APPickUpItem.SpawnItemID, APPickUpItem.SpawnItemID, APPickUpItem.SpawnItemID, APPickUpItem.SpawnItemID, APPickUpItem.SpawnItemID };
            }
            if(chestToEdit.ChestIdentifier == Chest.SpecialChestIdentifier.RAT)
            {
                chestToEdit.forceContentIds = new List<int> { APPickUpItem.SpawnItemID, APPickUpItem.SpawnItemID, APPickUpItem.SpawnItemID };
            }
            else if(chestToEdit.name.Contains("chest_black"))
            {
                chestToEdit.forceContentIds = new List<int> { APPickUpItem.SpawnItemID, APPickUpItem.SpawnItemID, APPickUpItem.SpawnItemID };
            }
            else if(chestToEdit.name.Contains("chest_red"))
            {
                chestToEdit.forceContentIds = new List<int> { APPickUpItem.SpawnItemID, APPickUpItem.SpawnItemID };
            }
            else
            {
                chestToEdit.forceContentIds = new List<int> { APPickUpItem.SpawnItemID };
            }

            return;
        }

        private static void OnChestOpen(Chest chest, PlayerController controller)
        {
            return;
        }


        private static void OnRunStarted(PlayerController controller1, PlayerController controller2, GameManager.GameMode mode)
        {
            PickedUpArchipelagun = false;
            ArchDebugPrint.DebugLog(DebugCategory.PlayerEventListener, $"Run started!");

            EnemySwapping.ResetEnemyDamageMult();
            roomsClearedThisRun = 0;
            killPillarKills = 0;
            triggerTwinKills = 0;
            IsStartOfRun = true;

            CharSwap.EndParadoxModeForReset();
            SessionHandler.ResetVariablesToStartOfRun();
            

            //PickupObject archipelaGun = PickupObjectDatabase.GetById(Archipelagun.SpawnItemID);
            //controller1.inventory.AddGunToInventory((Gun)archipelaGun, makeActive: true);

            GameObject archipelItem = PickupObjectDatabase.GetById(Archipelagun.SpawnItemID).gameObject;
            LootEngine.SpawnItem(archipelItem, controller1.CenterPosition, Vector2.zero, 0);

            return;
        }


        private static void OnBossKilled(HealthHaver haver, bool arg2)
        {
            CheckToForceArchipelagunOwnership();

            ArchDebugPrint.DebugLog(DebugCategory.PlayerEventListener, $"Boss killed: {haver.name}");
            ArchDebugPrint.DebugLog(DebugCategory.PlayerEventListener, $"Boss GUID: {haver.aiActor.EnemyGuid}");
            string enemyGuid = haver.aiActor.EnemyGuid;

            if(PastKillsGuids.Contains(enemyGuid))
            {
                SaveDataManagement.AddToCountSaveDataEntry(CountStats.PastKills, 1);
            }
            
            if(BossGUIDToStat.ContainsKey(enemyGuid))
            {
                SaveDataManagement.AddToCountSaveDataEntry(BossGUIDToStat[enemyGuid], 1);
            }

            else if(TriggerTwinGuids.Contains(enemyGuid))
            {
                triggerTwinKills++;

                if(triggerTwinKills == 2)
                {
                    SaveDataManagement.AddToCountSaveDataEntry(CountStats.Floor1Clears, 1);
                }
            }

            else if (KillPillarNames.Contains(haver.name))
            {
                killPillarKills++;

                if (killPillarKills == 4)
                {
                    SaveDataManagement.AddToCountSaveDataEntry(CountStats.Floor4Clears, 1);
                }
            }

            if(GameCompletionGUIds.ContainsKey(enemyGuid))
            {
                ArchDebugPrint.DebugLog(DebugCategory.PlayerEventListener, $"Possible completion boss: {haver.name}");
                SaveDataManagement.AddToCountSaveDataEntry(GameCompletionGUIds[enemyGuid], 1);

                SaveDataManagement.SaveCurrentRandomizerProgress();
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

            if(pedestal.IsBossRewardPedestal)
            {   
                //pedestal.contents = PickupObjectDatabase.GetById(APPickUpItem.SpawnItemID);
                if(GameManager.Instance.CurrentFloor == 2 || GameManager.Instance.CurrentFloor == 4)
                {
                    ArchipelagoGungeonBridge.SpawnAPItem(1);
                }
            }
            else
            {
                ArchipelagoGungeonBridge.SpawnAPItem(1);
            }


            return;
        }
        #endregion

        #region Player Event Listens
        // events timed to listens after a player controller is instantiated
        // With two players BOTH players fire events for these events, need to account for repeat cases.
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

        private static int lastFloorLoaded;
        // need to give PASTS items
        private static List<int> characterPastFloors = new List<int>()
        {
            // TODO: figure these out
            -99
        };

        private static void OnNewFloorLoad(PlayerController playerController)
        {
            if(GameManager.Instance.CurrentFloor == lastFloorLoaded)
            {
                return;
            }

            lastFloorLoaded = GameManager.Instance.CurrentFloor;
            ArchDebugPrint.DebugLog(DebugCategory.PlayerEventListener, $"Floor loaded: {lastFloorLoaded}");

            SaveDataManagement.SaveCurrentRandomizerProgress();
            if (characterPastFloors.Contains(lastFloorLoaded))
            {
                ArchDebugPrint.DebugLog(DebugCategory.PlayerEventListener, $"Loading past: {lastFloorLoaded}");
                CharSwap.HandleLostItemsOnPastsLoading(lastFloorLoaded, playerController);
            }
            else
            {
                EnemySwapping.ReduceEnemyDamageMult(1);
            }
            

            return;
        }

        private static void OnPlayerEnterCombat()
        {
            IsStartOfRun = false;
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
            controller.characterIdentity = PlayableCharacters.Pilot;
            PickedUpArchipelagun = false;
            SaveDataManagement.SaveCurrentRandomizerProgress();

            string deathCause = $"Died to {controller.healthHaver.lastIncurredDamageSource} in the Gungeon";
            SessionHandler.DataSender.SendDeathlink(causeOfDeath:deathCause);
        }

        private static void OnPlayerTwoDeath(PlayerController controller)
        {

            if(PlayerOne.healthHaver.IsDead )
            {
                SaveDataManagement.SaveCurrentRandomizerProgress();
                string deathCause = $"Died to {controller.healthHaver.lastIncurredDamageSource} in the Gungeon";
                SessionHandler.DataSender.SendDeathlink(causeOfDeath: deathCause);
            }
            
            return;
        }

        private static void OnRoomClear(PlayerController playerController)
        {
            CheckToForceArchipelagunOwnership();

            roomsClearedThisRun += 1;

            EnemySwapping.ResetShuffleCountOnRoomClear();

            ArchDebugPrint.DebugLog(DebugCategory.PlayerEventListener, "Adding room points: " + roomsClearedThisRun);

            SaveDataManagement.AddToCountSaveDataEntry(CountStats.RoomPoints, roomsClearedThisRun);
            //SessionHandler.CheckForUnhandledServerItems();

            return;
        }

        private static void OnItemPurchased(PlayerController playerController, ShopItemController shopItem)
        {

            if (shopItem == null)
            {
                return;
            }

            CheckToForceArchipelagunOwnership();

            int spentMoney = shopItem.CurrentPrice;
            ArchDebugPrint.DebugLog(DebugCategory.PlayerEventListener, "Adding cash spent: " + spentMoney);

            SaveDataManagement.AddToCountSaveDataEntry(CountStats.CashSpent, spentMoney);

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
            // TODO: add table flip location
            return;
        }
        #endregion
    }
    #endregion

    #region Input Modding
    public class PlayerInputModifier
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
    #endregion
}
