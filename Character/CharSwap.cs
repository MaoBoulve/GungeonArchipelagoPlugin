using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Alexandria.ItemAPI;
using ArchiGungeon.DebugTools;
using ArchiGungeon.GungeonEventHandlers;
using static ArchiGungeon.Character.CharSwap;
using ArchiGungeon.Data;

namespace ArchiGungeon.Character
{
    public class CharSwap
    {
        public delegate void CharacterSelected();
        public static CharacterSelected OnCharacterSelected;
        private static List<PickupObject> paradoxPassiveItems = new List<PickupObject>();
        private static List<PickupObject> paradoxGunItems = new List<PickupObject>();

        public static bool IsChosenCharForRun { get; private set; }
        public static bool IsParadoxModeOn { get; private set; }

        #region Character Swap Control

        public static void DoCharacterSwap(PlayableCharacters characterToSwap, PlayerController user)
        {
            if(IsChosenCharForRun)
            {
                return;
            }

            //PlayerController playerController = GungeonPlayerEventListener.GetFirstAlivePlayer();
            //PickupObject archipelaGun = PickupObjectDatabase.GetById(Archipelagun.SpawnItemID);
            //playerController.inventory.RemoveGunFromInventory((Gun)archipelaGun);

            if(characterToSwap == PlayableCharacters.Eevee)
            {
                ArchDebugPrint.DebugLog(DebugCategory.CharacterSystems, "Handling enabling Paradox Mode");
                SwapToParadox(GameManager.Instance.PrimaryPlayer);
                return;
            }
            else
            {
                OnCharacterSelected.Invoke();
                //RemoveParadoxStartItems(user);
                IsChosenCharForRun = true;
            }

            ArchDebugPrint.DebugLog(DebugCategory.CharacterSystems, "Handling switch case: " + characterToSwap);
            switch (characterToSwap)
            {
                case PlayableCharacters.Pilot:
                    //ETGModConsole.Instance?.ParseCommand("character pilot");
                    SwapToPilot(user);
                    break;
                case PlayableCharacters.Convict:
                    //ETGModConsole.Instance?.ParseCommand("character convict");
                    SwapToConvict(user);
                    break;
                case PlayableCharacters.Robot:
                    //ETGModConsole.Instance?.ParseCommand("character robot");
                    SwapToRobot(user);
                    break;
                case PlayableCharacters.Soldier:
                    //ETGModConsole.Instance?.ParseCommand("character marine");
                    SwapToMarine(user);
                    break;
                case PlayableCharacters.Guide:
                    //ETGModConsole.Instance?.ParseCommand("character hunter");
                    SwapToHunter(user);
                    break;
                case PlayableCharacters.Bullet:
                    //ETGModConsole.Instance?.ParseCommand("character bullet");
                    SwapToBullet(user);
                    break;
                default:
                    break;
            }

            //LootEngine.SpawnItem(archipelaGun.gameObject, user.CenterPosition, Vector2.zero, 0);
            //SpawnedItemLog.GivePlayerMissingItemsFromLog(user);

            return;
        }

        public static void HandleLostItemsOnCharacterSwap(PlayerController player)
        {
            ArchDebugPrint.DebugLog(DebugCategory.CharacterSystems, "Reint lost items from character swap paradox mode");

            PickupObject archipelaGun = PickupObjectDatabase.GetById(Archipelagun.SpawnItemID);
            player.inventory.AddGunToInventory((Gun)archipelaGun, makeActive: true);
        }

        #endregion

        #region Character Swap Defitions
        private static void SwapToParadox(PlayerController player)
        {
            ArchDebugPrint.DebugLog(DebugCategory.CharacterSystems, $"Swapping player to Paradox Character via console commands");
            ETGModConsole.Instance?.ParseCommand("character paradox");

            return;

        }
        

        private static void SwapToPilot(PlayerController player)
        {
            player.characterIdentity = PlayableCharacters.Pilot;

            // 187, 473, 89, 356
            // passives
            //player.AcquirePassiveItemPrefabDirectly((PassiveItem)PickupObjectDatabase.GetById(187));
            //player.AcquirePassiveItemPrefabDirectly((PassiveItem)PickupObjectDatabase.GetById(473));
            LootEngine.SpawnItem(PickupObjectDatabase.GetById(187).gameObject, player.specRigidbody.UnitCenter, Vector2.left, 1f, false, true, false);
            LootEngine.SpawnItem(PickupObjectDatabase.GetById(473).gameObject, player.specRigidbody.UnitCenter, Vector2.left, 1f, false, true, false);


            // gun
            //player.inventory.AddGunToInventory((Gun)PickupObjectDatabase.GetById(89));
            LootEngine.SpawnItem(PickupObjectDatabase.GetById(89).gameObject, player.specRigidbody.UnitCenter, Vector2.left, 1f, false, true, false);

            // active
            //LootEngine.SpawnItem(PickupObjectDatabase.GetById(356).gameObject, player.specRigidbody.UnitCenter, Vector2.left, 1f, false, true, false);

            return;
        }

        private static void SwapToConvict(PlayerController player)
        {
            // 353, 202, 80, 366
            // passives
            //player.AcquirePassiveItemPrefabDirectly((PassiveItem)PickupObjectDatabase.GetById(353));

            // gun
            //player.inventory.AddGunToInventory((Gun)PickupObjectDatabase.GetById(202));
            //player.inventory.AddGunToInventory((Gun)PickupObjectDatabase.GetById(80));

            // active
            player.characterIdentity = PlayableCharacters.Convict;
            LootEngine.SpawnItem(PickupObjectDatabase.GetById(366).gameObject, player.specRigidbody.UnitCenter, Vector2.left, 1f, false, true, false);
            LootEngine.SpawnItem(PickupObjectDatabase.GetById(353).gameObject, player.specRigidbody.UnitCenter, Vector2.left, 1f, false, true, false);
            LootEngine.SpawnItem(PickupObjectDatabase.GetById(202).gameObject, player.specRigidbody.UnitCenter, Vector2.left, 1f, false, true, false);
            LootEngine.SpawnItem(PickupObjectDatabase.GetById(80).gameObject, player.specRigidbody.UnitCenter, Vector2.left, 1f, false, true, false);

            return;
        }

        private static void SwapToRobot(PlayerController player)
        {
            player.characterIdentity = PlayableCharacters.Robot;

            // 410, 88, 411
            // passives
            //player.AcquirePassiveItemPrefabDirectly((PassiveItem)PickupObjectDatabase.GetById(410));
            LootEngine.SpawnItem(PickupObjectDatabase.GetById(410).gameObject, player.specRigidbody.UnitCenter, Vector2.left, 1f, false, true, false);

            // gun
            //player.inventory.AddGunToInventory((Gun)PickupObjectDatabase.GetById(88));
            LootEngine.SpawnItem(PickupObjectDatabase.GetById(88).gameObject, player.specRigidbody.UnitCenter, Vector2.left, 1f, false, true, false);
            // active
            LootEngine.SpawnItem(PickupObjectDatabase.GetById(411).gameObject, player.specRigidbody.UnitCenter, Vector2.left, 1f, false, true, false);
            return;
        }

        private static void SwapToMarine(PlayerController player)
        {
            // 354, 86, 77
            // passives
            //player.AcquirePassiveItemPrefabDirectly((PassiveItem)PickupObjectDatabase.GetById(354));

            // gun
            //player.inventory.AddGunToInventory((Gun)PickupObjectDatabase.GetById(86));


            // active
            LootEngine.SpawnItem(PickupObjectDatabase.GetById(77).gameObject, player.CenterPosition, Vector2.left, 1f, false, true, false);

            player.characterIdentity = PlayableCharacters.Soldier;
            LootEngine.SpawnItem(PickupObjectDatabase.GetById(86).gameObject, player.CenterPosition, Vector2.left, 1f, false, true, false);
            LootEngine.SpawnItem(PickupObjectDatabase.GetById(354).gameObject, player.CenterPosition, Vector2.left, 1f, false, true, false);

            return;
        }

        private static void SwapToHunter(PlayerController player)
        {
            player.characterIdentity = PlayableCharacters.Guide;
            // 300, 12, 99
            // passives
            //player.AcquirePassiveItemPrefabDirectly((PassiveItem)PickupObjectDatabase.GetById(300));
            LootEngine.SpawnItem(PickupObjectDatabase.GetById(300).gameObject, player.specRigidbody.UnitCenter, Vector2.left, 1f, false, true, false);
            // gun
            //player.inventory.AddGunToInventory((Gun)PickupObjectDatabase.GetById(12));
            //player.inventory.AddGunToInventory((Gun)PickupObjectDatabase.GetById(99));

            LootEngine.SpawnItem(PickupObjectDatabase.GetById(12).gameObject, player.specRigidbody.UnitCenter, Vector2.left, 1f, false, true, false);
            LootEngine.SpawnItem(PickupObjectDatabase.GetById(99).gameObject, player.specRigidbody.UnitCenter, Vector2.left, 1f, false, true, false);

            return;
        }

        private static void SwapToBullet(PlayerController player)
        {
            // 414, 417
            // passives
            //player.AcquirePassiveItemPrefabDirectly((PassiveItem)PickupObjectDatabase.GetById(414));

            LootEngine.SpawnItem(PickupObjectDatabase.GetById(414).gameObject, player.specRigidbody.UnitCenter, Vector2.left, 1f, false, true, false);

            // active
            LootEngine.SpawnItem(PickupObjectDatabase.GetById(417).gameObject, player.specRigidbody.UnitCenter, Vector2.left, 1f, false, true, false);
            return;
        }

        #endregion

        #region Paradox Mode Control
        public static void StartParadoxMode(PlayerController player)
        {
            if (IsParadoxModeOn)
            {
                ArchDebugPrint.DebugLog(DebugCategory.CharacterSystems, "Paradox mode already initialized");
                return;
            }

            ArchDebugPrint.DebugLog(DebugCategory.CharacterSystems, "Starting paradox mode");

            IsParadoxModeOn = true;
            IsChosenCharForRun = false;
            paradoxPassiveItems.Clear();
            paradoxGunItems.Clear();
            DoCharacterSwap(PlayableCharacters.Eevee, player);

            return;
        }

        public static void EndParadoxModeForReset()
        {
            if (!IsParadoxModeOn)
            {
                return;
            }

            ArchDebugPrint.DebugLog(DebugCategory.CharacterSystems, "Resetting paradox mode");

            IsParadoxModeOn = false;
            BulletParadoxItem.SetValidToPickup();
            RobotParadoxItem.SetValidToPickup();
            ConvictParadoxItem.SetValidToPickup();
            HunterParadoxItem.SetValidToPickup();
            MarineParadoxItem.SetValidToPickup();
            PilotParadoxItem.SetValidToPickup();
        }

        public static void ReceiveParadoxModeItem(int itemCase)
        {
            EffectsController.PlaySynergyVFX();

            if(IsChosenCharForRun)
            {
                return;
            }

            switch (itemCase)
            {
                case 0:
                    ArchDebugPrint.DebugLog(DebugCategory.CharacterSystems, $"Marine unlocked for Paradox Mode");
					SpawnIdentityItem(PlayableCharacters.Soldier);
                    break;
                case 1:
                    ArchDebugPrint.DebugLog(DebugCategory.CharacterSystems, $"Convict unlocked for Paradox Mode");
                    SpawnIdentityItem(PlayableCharacters.Convict);
                    break;
                case 2:
                    ArchDebugPrint.DebugLog(DebugCategory.CharacterSystems, $"Pilot unlocked for Paradox Mode");
                    SpawnIdentityItem(PlayableCharacters.Pilot);
                    break;
                case 3:
                    ArchDebugPrint.DebugLog(DebugCategory.CharacterSystems, $"Hunter unlocked for Paradox Mode");
                    SpawnIdentityItem(PlayableCharacters.Guide);
                    break;
                case 4:
                    ArchDebugPrint.DebugLog(DebugCategory.CharacterSystems, $"Robot unlocked for Paradox Mode");
                    SpawnIdentityItem(PlayableCharacters.Robot);
                    break;
                case 5:
                    ArchDebugPrint.DebugLog(DebugCategory.CharacterSystems, $"Bullet unlocked for Paradox Mode");
                    SpawnIdentityItem(PlayableCharacters.Bullet);
                    break;

                default:
                    ArchDebugPrint.DebugLog(DebugCategory.CharacterSystems, $"Paradox Mode items received invalid ID: {itemCase}");
                    break;
            }

            return;
        }


        private static void SpawnIdentityItem(PlayableCharacters playableCharacters)
        {
            PlayerController player = GameManager.Instance.PrimaryPlayer;
            int identityID = 0;
            Vector2 spawnDirec = Vector2.zero;

            ArchDebugPrint.DebugLog(DebugCategory.CharacterSystems, $"Handling identity spawn for: {playableCharacters}");

            switch (playableCharacters)
            {
                case PlayableCharacters.Pilot:
                    identityID = PilotParadoxItem.SpawnItemID;
                    spawnDirec = new Vector2(0.7f, 0.5f);
                    break;
                case PlayableCharacters.Convict:
                    identityID = ConvictParadoxItem.SpawnItemID;
                    spawnDirec = new Vector2(-0.7f, 0.5f);
                    break;
                case PlayableCharacters.Robot:
                    identityID = RobotParadoxItem.SpawnItemID;
                    spawnDirec = Vector2.down;
                    break;
                case PlayableCharacters.Soldier:
                    identityID = MarineParadoxItem.SpawnItemID;
                    spawnDirec = new Vector2(0.7f, -0.5f);
                    break;
                case PlayableCharacters.Guide:
                    identityID = HunterParadoxItem.SpawnItemID;
                    spawnDirec = new Vector2(-0.7f, -0.5f);
                    break;
                case PlayableCharacters.Bullet:
                    identityID = BulletParadoxItem.SpawnItemID;
                    spawnDirec = Vector2.up;
                    break;
                default:
                    break;
            }

            DebrisObject identityObject = LootEngine.SpawnItem(PickupObjectDatabase.GetById(identityID).gameObject, player.specRigidbody.UnitCenter, spawnDirec, 6f, false, true, false);
            
            return;
        }

        #endregion

    } // class

} // namespace
