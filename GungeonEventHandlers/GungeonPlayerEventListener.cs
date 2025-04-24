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

namespace ArchiGungeon.GungeonEventHandlers
{
    // See: https://github.com/Nevernamed22/Alexandria/blob/main/Misc/CustomActions.cs#L121
    public class GungeonPlayerEventListener
    {
        private static PlayerController PlayerOne { get; set; }
        private static PlayerController PlayerTwo { get; set; }

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

        /*
        private static Dictionary<string, string> bossGameNameMap { get; } = new Dictionary<string, string>
        {
            { "Blobulord(Clone)", "Blobulord Killed" },
            { "OldBulletKing(Clone)", "Old King Killed" },
            { "MetalGearRat(Clone)", "Resourceful Rat Killed" },
            { "Helicopter(Clone)", "Agunim Killed" },
            { "AdvancedDraGun(Clone)", "Advanced Dragun Killed" },
            { "DraGun(Clone)", "Dragun Killed" },
            { "Infinilich(Clone)", "Lich Killed" }
        };
        */

        private static Dictionary<string, CompletionGoals> BossNameToCompletionGoal { get; } = new Dictionary<string, CompletionGoals>
        {
            { "Blobulord(Clone)", CompletionGoals.Blobulord },
            { "OldBulletKing(Clone)", CompletionGoals.OldKing },
            { "MetalGearRat(Clone)", CompletionGoals.Rat },
            { "Helicopter(Clone)", CompletionGoals.Agunim },
            { "AdvancedDraGun(Clone)", CompletionGoals.AdvancedDragun },
            { "DraGun(Clone)", CompletionGoals.Dragun },
            { "Infinilich(Clone)", CompletionGoals.Lich }
        };

        private static Dictionary<string, SaveCountStats> BossNameToSaveCountStat { get; } = new Dictionary<string, SaveCountStats>
        {
            { "Blobulord(Clone)", SaveCountStats.BlobulordKills},
            { "OldBulletKing(Clone)", SaveCountStats.OldKingKills },
            { "MetalGearRat(Clone)", SaveCountStats.RatKills },
            { "Helicopter(Clone)", SaveCountStats.DeptAgunimKills },
            { "AdvancedDraGun(Clone)", SaveCountStats.AdvancedDragunKills },
            { "DraGun(Clone)", SaveCountStats.DragunKills },
            { "Infinilich(Clone)", SaveCountStats.LichKills }
        };

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

            //OnEnemyKilled

            ETGMod.Chest.OnPostOpen += OnChestOpen;
            ETGMod.Chest.OnPreOpen += OnChestPreOpen;

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

            //ArchipelagoGUI.ConsoleLog($"Pre open: {chest}, Should Open: {shouldOpen}");

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
                ArchDebugPrint.DebugLog(DebugCategory.ItemHandling, "Clearing chest contents");
                chest.contents.Clear();

                ArchDebugPrint.DebugLog(DebugCategory.ItemHandling, "Spawning AP Item");
                chest.contents.Add(PickupObjectDatabase.GetById(APPickUpItem.SpawnItemID));
            }
            

            SessionHandler.DataSender.AddToGoalCount(SaveCountStats.ChestsOpened, 1);

            return;
        }

        

        private static void OnRunStarted(PlayerController controller1, PlayerController controller2, GameManager.GameMode mode)
        {
            ArchDebugPrint.DebugLog(DebugCategory.PlayerEventListener, $"Run started!");

            EnemySwapping.ResetEnemyDamageMult();
            roomsClearedThisRun = 0;
            SessionHandler.ResetItemRetrieveState();

            GameObject archipelItem = PickupObjectDatabase.GetById(Archipelagun.SpawnItemID).gameObject;
            LootEngine.SpawnItem(archipelItem, controller1.CenterPosition, Vector2.zero, 0);

            return;
        }

        
        private static void OnBossKilled(HealthHaver haver, bool arg2)
        {
            string bossName = haver.name;
            
            if(BossNameToSaveCountStat.ContainsKey(bossName))
            {
                SessionHandler.DataSender.AddToGoalCount(BossNameToSaveCountStat[bossName], 1);
            }

            if (BossNameToCompletionGoal.ContainsKey(bossName))
            {
                SessionHandler.DataSender.SendLocalCountValuesToServer();
                ArchDebugPrint.DebugLog(DebugCategory.PlayerEventListener, $"Possible goal boss killed: {bossName}");
                SessionHandler.DataSender.CheckForGameCompletion();
            }

            ArchDebugPrint.DebugLog(DebugCategory.PlayerEventListener, $"Boss killed: {haver}");

            return;
        }

        
        private static void OnRewardPedestalSpawn(RewardPedestal pedestal)
        {
            //throw new NotImplementedException();
        }

        private static void OnRewardPedestalDetermineContent(RewardPedestal pedestal, PlayerController controller, CustomActions.ValidPedestalContents contents)
        {
            //throw new NotImplementedException();
        }

        /*
        public void Update()
        {
            if (playerController == null)
            {
                PlayerController testPlayerController = ArchipelaGunPlugin.GameManagerInstance.m_player;

                if (testPlayerController != null)
                {
                    //StartPlayerControllerEventListens();
                }
            }

            return;
        }
        */

        private static void StartPlayerControllerEventListens(PlayerController playerToListen)
        {

            // error referring to the game manager causes a hard error
            //Player = ArchipelaGunPlugin.GameManagerInstance.m_player;

            playerToListen.OnNewFloorLoaded += OnNewFloorLoad;
            playerToListen.OnEnteredCombat += OnPlayerEnterCombat;
            playerToListen.OnRoomClearEvent += OnRoomClear;

            // playerController.OnReloadPressed += OnReloadPress; ReloadPress should be listened to by gun classes instead
            //playerToListen.OnRealPlayerDeath += OnPlayerDeath;
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
            if(shopItem == null)
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
