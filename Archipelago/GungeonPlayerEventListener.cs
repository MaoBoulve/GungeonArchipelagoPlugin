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

        private static Dictionary<string, string> bossGameNameMap = new Dictionary<string, string>
        {
            { "Blobulord(Clone)", "Blobulord Killed" },
            { "OldBulletKing(Clone)", "Old King Killed" },
            { "MetalGearRat(Clone)", "Resourceful Rat Killed" },
            { "Helicopter(Clone)", "Agunim Killed" },
            { "AdvancedDraGun(Clone)", "Advanced Dragun Killed" },
            { "DraGun(Clone)", "Dragun Killed" },
            { "Infinilich(Clone)", "Lich Killed" }
        };

        public void StartSystemEventListens()
        {
            ArchipelagoGUI.OnMenuOpen += OnArchipelagoMenuOpen;
            ArchipelagoGUI.OnMenuClose += OnArchipelagoMenuClose;


            //OnEnteredCombat
            
            //GunChanged
            //OnUsedPlayerItem
            //OnItemPurchased
            //OnItemStolen
            //OnRoomClearEvent

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
            ArchipelagoGUI.ConsoleLog($"Pre open: {chest}, Should Open: {shouldOpen}");

            return shouldOpen;
        }

        private void OnChestOpen(Chest chest, PlayerController controller)
        {
            ArchipelagoGUI.ConsoleLog($"OPEN: {chest}");

            if (SessionHandler.session == null)
            {
                return;
            }

            if (SessionHandler.session.Socket.Connected == false)
            {
                return;
            }

            chest.contents.Clear();
            chest.contents.Add(PickupObjectDatabase.GetById(APItem.SpawnItemID));

            //chest.ExplodeInSadness();

            //SessionHandler.DataSender.ParseOpenedChestToLocationCheck();

            return;
        }

        

        private void OnRunStarted(PlayerController controller1, PlayerController controller2, GameManager.GameMode mode)
        {
            ETGModConsole.Log($"Run started!");

            SessionHandler.RetrievedServerItemsThisRun = false;

            GameObject archipelItem = PickupObjectDatabase.GetById(Archipelagun.SpawnItemID).gameObject;
            LootEngine.SpawnItem(archipelItem, controller1.CenterPosition, Vector2.zero, 0);

            return;
        }

        
        private void OnBossKilled(HealthHaver haver, bool arg2)
        {
            string bossName = haver.name;

            if (bossGameNameMap.ContainsKey(bossName))
            {
                ETGModConsole.Log($"Possible goal boss killed: {haver}");
                ETGModConsole.Log($"========== Checking for game completion ===========");
                SessionHandler.DataSender.SendGoalCompletion(bossGameNameMap[bossName]);
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

        public void StartPlayerControllerEventListens()
        {
            playerController = ArchipelaGunPlugin.GameManagerInstance.m_player;

            playerController.OnRealPlayerDeath += OnPlayerDeath;

            ArchipelagoGUI.ConsoleLog(playerController);

            return;
        }

        private void OnPlayerDeath(PlayerController controller)
        {
            string deathCause = $"Died to {controller.healthHaver.lastIncurredDamageSource} in the Gungeon";
            SessionHandler.DataSender.SendDeathlink(causeOfDeath:deathCause);
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
