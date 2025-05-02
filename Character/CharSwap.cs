using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Alexandria.ItemAPI;
using ArchiGungeon.DebugTools;
using ArchiGungeon.GungeonEventHandlers;

namespace ArchiGungeon.Character
{
    public class CharSwap
    {
        private static List<PickupObject> paradoxPassiveItems = new List<PickupObject>();
        private static List<PickupObject> paradoxGunItems = new List<PickupObject>();

		public static void StartParadoxMode(PlayerController player)
        {
            ArchDebugPrint.DebugLog(DebugCategory.CharacterSystems, "Starting paradox mode");

            paradoxPassiveItems.Clear();
            paradoxGunItems.Clear();
			DoCharacterSwap(PlayableCharacters.Eevee, player);

			return;
		}


        public static void DoCharacterSwap(PlayableCharacters characterToSwap, PlayerController user)
        {
            //PlayerController playerController = GungeonPlayerEventListener.GetFirstAlivePlayer();
            //PickupObject archipelaGun = PickupObjectDatabase.GetById(Archipelagun.SpawnItemID);
            //playerController.inventory.RemoveGunFromInventory((Gun)archipelaGun);

            if(characterToSwap == PlayableCharacters.Eevee)
            {
                SwapToParadox(user);
            }
            else
            {
                RemoveParadoxStartItems(user);
            }

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

            //playerController.inventory.AddGunToInventory((Gun)archipelaGun, makeActive: true);
            //SpawnedItemLog.GivePlayerMissingItemsFromLog(user);

            return;
        }

       
        private static void SwapToParadox(PlayerController player)
        {
            ArchDebugPrint.DebugLog(DebugCategory.CharacterSystems, $"Swapping player to Paradox Character via console commands");
            ETGModConsole.Instance?.ParseCommand("character paradox");

            foreach (PassiveItem item in GameManager.Instance.PrimaryPlayer.passiveItems)
            {
                paradoxPassiveItems.Add(item);
            }

            foreach (Gun item in GameManager.Instance.PrimaryPlayer.inventory.AllGuns)
            {
                paradoxGunItems.Add(item);
            }

            return;

        }
      
        private static void RemoveParadoxStartItems(PlayerController player)
        {
            ArchDebugPrint.DebugLog(DebugCategory.CharacterSystems, "Removing paradox items");

            foreach (PickupObject item in paradoxPassiveItems)
            {
                player.RemovePassiveItem(item.PickupObjectId);
            }
            foreach(PickupObject gun in paradoxGunItems)
            {
                player.inventory.RemoveGunFromInventory((Gun)gun);
            }

            return;
        }

        private static void SwapToPilot(PlayerController player)
        {
            // 187, 473, 89, 356
            // passives
            player.AcquirePassiveItemPrefabDirectly((PassiveItem)PickupObjectDatabase.GetById(187));
            player.AcquirePassiveItemPrefabDirectly((PassiveItem)PickupObjectDatabase.GetById(473));

            // gun
            player.inventory.AddGunToInventory((Gun)PickupObjectDatabase.GetById(89));

            // active
            LootEngine.SpawnItem(PickupObjectDatabase.GetById(356).gameObject, player.specRigidbody.UnitCenter, Vector2.left, 1f, false, true, false);

            return;
        }

        private static void SwapToConvict(PlayerController player)
        {
            // 353, 202, 80, 366
            // passives
            player.AcquirePassiveItemPrefabDirectly((PassiveItem)PickupObjectDatabase.GetById(353));

            // gun
            player.inventory.AddGunToInventory((Gun)PickupObjectDatabase.GetById(202));
            player.inventory.AddGunToInventory((Gun)PickupObjectDatabase.GetById(80));

            // active
            LootEngine.SpawnItem(PickupObjectDatabase.GetById(366).gameObject, player.specRigidbody.UnitCenter, Vector2.left, 1f, false, true, false);
            return;
        }

        private static void SwapToRobot(PlayerController player)
        {
            // 410, 88, 411
            // passives
            player.AcquirePassiveItemPrefabDirectly((PassiveItem)PickupObjectDatabase.GetById(410));


            // gun
            player.inventory.AddGunToInventory((Gun)PickupObjectDatabase.GetById(88));

            // active
            LootEngine.SpawnItem(PickupObjectDatabase.GetById(411).gameObject, player.specRigidbody.UnitCenter, Vector2.left, 1f, false, true, false);
            return;
        }

        private static void SwapToMarine(PlayerController player)
        {
            // 354, 86, 77
            // passives
            player.AcquirePassiveItemPrefabDirectly((PassiveItem)PickupObjectDatabase.GetById(354));

            // gun
            player.inventory.AddGunToInventory((Gun)PickupObjectDatabase.GetById(86));

            // active
            LootEngine.SpawnItem(PickupObjectDatabase.GetById(77).gameObject, player.specRigidbody.UnitCenter, Vector2.left, 1f, false, true, false);
            return;
        }

        private static void SwapToHunter(PlayerController player)
        {
            // 300, 12, 99
            // passives
            player.AcquirePassiveItemPrefabDirectly((PassiveItem)PickupObjectDatabase.GetById(300));

            // gun
            player.inventory.AddGunToInventory((Gun)PickupObjectDatabase.GetById(12));
            player.inventory.AddGunToInventory((Gun)PickupObjectDatabase.GetById(99));

            return;
        }

        private static void SwapToBullet(PlayerController player)
        {
            // 414, 417
            // passives
            player.AcquirePassiveItemPrefabDirectly((PassiveItem)PickupObjectDatabase.GetById(414));

            // active
            LootEngine.SpawnItem(PickupObjectDatabase.GetById(417).gameObject, player.specRigidbody.UnitCenter, Vector2.left, 1f, false, true, false);
            return;
        }


        public static void ReceiveParadoxModeItem(int itemCase)
        {
            EffectsController.PlaySynergyVFX();

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

            ArchDebugPrint.DebugLog(DebugCategory.CharacterSystems, $"Handling identity spawn for: {playableCharacters}");

            switch (playableCharacters)
            {
                case PlayableCharacters.Pilot:
                    identityID = PilotParadoxItem.SpawnItemID;
                    break;
                case PlayableCharacters.Convict:
                    identityID = ConvictParadoxItem.SpawnItemID;
                    break;
                case PlayableCharacters.Robot:
                    identityID = RobotParadoxItem.SpawnItemID;
                    break;
                case PlayableCharacters.Soldier:
                    identityID = MarineParadoxItem.SpawnItemID;
                    break;
                case PlayableCharacters.Guide:
                    identityID = HunterParadoxItem.SpawnItemID;
                    break;
                case PlayableCharacters.Bullet:
                    identityID = BulletParadoxItem.SpawnItemID;
                    break;
                case PlayableCharacters.Gunslinger:
                    break;
                default:
                    break;
            }

            LootEngine.SpawnItem(PickupObjectDatabase.GetById(identityID).gameObject, player.specRigidbody.UnitCenter, Vector2.left, 1f, false, true, false);
            return;
        }
    }
}
