using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alexandria.Misc;
using ArchiGungeon.ItemArchipelago;
using UnityEngine;

namespace ArchiGungeon.Archipelago
{
    // See: https://github.com/Nevernamed22/Alexandria/blob/main/Misc/CustomActions.cs#L121
    public class GungeonPlayerEventListener
    {
        private static PlayerController playerController;

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

        private static Dictionary<string, CompletionGoals> bossObjectNameToSaveStat { get; } = new Dictionary<string, CompletionGoals>
        {
            { "Blobulord(Clone)", CompletionGoals.Blobulord },
            { "OldBulletKing(Clone)", CompletionGoals.OldKing },
            { "MetalGearRat(Clone)", CompletionGoals.Rat },
            { "Helicopter(Clone)", CompletionGoals.Agunim },
            { "AdvancedDraGun(Clone)", CompletionGoals.AdvancedDragun },
            { "DraGun(Clone)", CompletionGoals.Dragun },
            { "Infinilich(Clone)", CompletionGoals.Lich }
        };

        private static int roomsClearedThisRun;

        public void StartSystemEventListens()
        {
            ArchipelagoGUI.OnMenuOpen += OnArchipelagoMenuOpen;
            ArchipelagoGUI.OnMenuClose += OnArchipelagoMenuClose;

            CustomActions.OnRunStart += OnRunStarted;
            CustomActions.OnBossKilled += OnBossKilled;
            CustomActions.OnNewPlayercontrollerSpawned += OnPlayerControllerSpawned;
            CustomActions.OnRewardPedestalSpawned += OnRewardPedestalSpawn;
            CustomActions.OnRewardPedestalDetermineContents += OnRewardPedestalDetermineContent;

            //OnEnemyKilled

            ETGMod.Chest.OnPostOpen = (Action<Chest, PlayerController>)Delegate.Combine(ETGMod.Chest.OnPostOpen, new Action<Chest, PlayerController>(OnChestOpen));
            ETGMod.Chest.OnPreOpen += OnChestPreOpen;

            return;
        }

        private void OnPlayerControllerSpawned(PlayerController controller)
        {
            playerController = controller;

            ArchipelagoGungeonBridge.SetPlayerController(playerController);
            StartPlayerControllerEventListens();

            return;
        }

        private void OnArchipelagoMenuOpen()
        {
            KeyboardInputConsuming.BlockPlayerInputToCharacter(true);
            return;
        }

        private void OnArchipelagoMenuClose()
        {
            KeyboardInputConsuming.BlockPlayerInputToCharacter(false);
            return;
        }

        private bool OnChestPreOpen(bool shouldOpen, Chest chest, PlayerController player)
        {

            //ArchipelagoGUI.ConsoleLog($"Pre open: {chest}, Should Open: {shouldOpen}");

            return shouldOpen;
        }

        private void OnChestOpen(Chest chest, PlayerController controller)
        {
            if (SessionHandler.Session == null || SessionHandler.Session.Socket.Connected == false)
            {
                return;
            }

            chest.contents.Clear();
            chest.contents.Add(PickupObjectDatabase.GetById(APItem.SpawnItemID));

            SessionHandler.DataSender.SendChestOpened(1);

            //ArchipelagoGUI.ConsoleLog($"OPEN: {chest}");

            return;
        }

        

        private void OnRunStarted(PlayerController controller1, PlayerController controller2, GameManager.GameMode mode)
        {
            ETGModConsole.Log($"Run started!");

            roomsClearedThisRun = 0;
            SessionHandler.ResetItemRetrieveState();

            GameObject archipelItem = PickupObjectDatabase.GetById(Archipelagun.SpawnItemID).gameObject;
            LootEngine.SpawnItem(archipelItem, controller1.CenterPosition, Vector2.zero, 0);

            return;
        }

        
        private void OnBossKilled(HealthHaver haver, bool arg2)
        {
            string bossName = haver.name;


            SessionHandler.DataSender.SendLocalIncrementalCountValuesToServer();

            /*
            if (bossGameNameMap.ContainsKey(bossName))
            {
                ETGModConsole.Log($"Possible goal boss killed: {haver}");
                ETGModConsole.Log($"========== Checking for game completion ===========");
                SessionHandler.DataSender.SendGoalCompletion(bossGameNameMap[bossName]);
            }
            */

            if (bossObjectNameToSaveStat.ContainsKey(bossName))
            {
                ArchipelagoGUI.ConsoleLog($"Possible goal boss killed: {bossName}");
                SessionHandler.DataSender.SendGoalCompletion(bossObjectNameToSaveStat[bossName]);
            }

            ETGModConsole.Log($"Boss killed: {haver}");

            return;
        }

        
        private void OnRewardPedestalSpawn(RewardPedestal pedestal)
        {
            //throw new NotImplementedException();
        }

        private void OnRewardPedestalDetermineContent(RewardPedestal pedestal, PlayerController controller, CustomActions.ValidPedestalContents contents)
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

        public void StartPlayerControllerEventListens()
        {

            playerController = ArchipelaGunPlugin.GameManagerInstance.m_player;

            playerController.OnNewFloorLoaded += OnNewFloorLoad;
            playerController.OnEnteredCombat += OnPlayerEnterCombat;
            playerController.OnRoomClearEvent += OnRoomClear;

            // playerController.OnReloadPressed += OnReloadPress; ReloadPress should be listened to by gun classes instead
            playerController.OnRealPlayerDeath += OnPlayerDeath;
            playerController.OnItemPurchased += OnItemPurchased;

            playerController.OnKilledEnemyContext += OnKilledEnemy;
            playerController.OnTableFlipped += OnTableFlip;

            ArchipelagoGUI.ConsoleLog(playerController);

            return;
        }

        private void OnNewFloorLoad(PlayerController playerController)
        {
            SessionHandler.DataSender.SendLocalIncrementalCountValuesToServer();
            return;
        }

        private void OnPlayerEnterCombat()
        {
            // TODO: hide archipelagun
            return;
        }

        private void OnPlayerDeath(PlayerController controller)
        {
            SessionHandler.DataSender.SendLocalIncrementalCountValuesToServer();

            string deathCause = $"Died to {controller.healthHaver.lastIncurredDamageSource} in the Gungeon";
            SessionHandler.DataSender.SendDeathlink(causeOfDeath:deathCause);
        }

        private void OnRoomClear(PlayerController playerController)
        {
            roomsClearedThisRun += 1;

            ArchipelagoGUI.ConsoleLog("Room points sent: " + roomsClearedThisRun);
            SessionHandler.DataSender.SendRoomPointsToAdd(roomsClearedThisRun);

            return;
        }

        private void OnItemPurchased(PlayerController playerController, ShopItemController shopItem)
        {
            int spentMoney = shopItem.CurrentPrice;
            // TODO: add to purchase cost
            return;
        }

        private void OnKilledEnemy(PlayerController playerController, HealthHaver enemy)
        {
            string enemyName = enemy.name;
            // TODO: add enemy headhunter check
            return;
        }

        private void OnTableFlip(FlippableCover tableFlipped)
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
