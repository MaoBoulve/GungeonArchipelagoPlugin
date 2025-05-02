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

		public static bool ParadoxMode { get; protected set; } = false;
		private static int currentCharacterIndex = 0;
		private static Dictionary<PlayableCharacters, bool> AvailableChars { get; } = new Dictionary<PlayableCharacters, bool>()
		{
			{PlayableCharacters.Eevee, true },
			{PlayableCharacters.Soldier, true },
			{PlayableCharacters.Convict, true },
			{PlayableCharacters.Pilot, true },
			{PlayableCharacters.Guide, true },
			{PlayableCharacters.Robot, true },
			{PlayableCharacters.Bullet, true },
			{PlayableCharacters.Gunslinger, false },
		};


		private static List<PlayableCharacters> CharacterOrder = new()
		{
			PlayableCharacters.Eevee,
			PlayableCharacters.Soldier,
			PlayableCharacters.Convict,
			PlayableCharacters.Pilot,
			PlayableCharacters.Guide,
			PlayableCharacters.Robot,
			PlayableCharacters.Bullet,
			PlayableCharacters.Gunslinger,
		};

		public static void StartParadoxMode(PlayerController player)
        {
			AvailableChars[PlayableCharacters.Eevee] = true;
			AvailableChars[PlayableCharacters.Soldier] = false;
			AvailableChars[PlayableCharacters.Convict] = false;
			AvailableChars[PlayableCharacters.Pilot] = false;
			AvailableChars[PlayableCharacters.Guide] = false;
			AvailableChars[PlayableCharacters.Robot] = false;
			AvailableChars[PlayableCharacters.Bullet] = false;
			AvailableChars[PlayableCharacters.Gunslinger] = false;

			HandleCharacterSwapCase(PlayableCharacters.Eevee, player);
			currentCharacterIndex = 0;

			ParadoxMode = true;

			return;
		}

        public static void CheckForParadoxOnRunStart(PlayerController player)
        {
            if(ParadoxMode)
            {
                HandleCharacterSwapCase(PlayableCharacters.Eevee, player);
                currentCharacterIndex = 0;
            }
        }

		private static void AddNewParadoxCharacter(PlayableCharacters addedCharacter)
        {
			AvailableChars[addedCharacter] = true;
			return;
        }

		public static void SetPlayerToNextAvailableChar(PlayerController user)
        {
			currentCharacterIndex = GetNextAvailableCharacterIndex(currentCharacterIndex);
			ArchDebugPrint.DebugLog(DebugCategory.CharacterSystems, $"Swapping to {CharacterOrder[currentCharacterIndex]}");
			HandleCharacterSwapCase(CharacterOrder[currentCharacterIndex], user);

			return;
        }

		private static int GetNextAvailableCharacterIndex(int currentIndex)
        {
			//recursively call until a valid character is found
			currentIndex += 1;

			if(currentIndex >= AvailableChars.Count)
			{
				currentIndex = 0;
			}

			if(AvailableChars[CharacterOrder[currentIndex]] == false)
            {
				currentIndex = GetNextAvailableCharacterIndex(currentIndex);
            }

			return currentIndex;
        }

		private static void HandleCharacterSwapCase(PlayableCharacters characterToSwap, PlayerController user)
        {
            //PlayerController playerController = GungeonPlayerEventListener.GetFirstAlivePlayer();
            PickupObject archipelaGun = PickupObjectDatabase.GetById(Archipelagun.SpawnItemID);
            //playerController.inventory.RemoveGunFromInventory((Gun)archipelaGun);

            switch (characterToSwap)
            {
                case PlayableCharacters.Pilot:
                    //ETGModConsole.Instance?.ParseCommand("character pilot");
                    break;
                case PlayableCharacters.Convict:
                    //ETGModConsole.Instance?.ParseCommand("character convict");
                    break;
                case PlayableCharacters.Robot:
                    //ETGModConsole.Instance?.ParseCommand("character robot");
                    break;
                case PlayableCharacters.Soldier:
                    //ETGModConsole.Instance?.ParseCommand("character marine");
                    break;
                case PlayableCharacters.Guide:
                    //ETGModConsole.Instance?.ParseCommand("character hunter");
                    break;
                case PlayableCharacters.Bullet:
                    //ETGModConsole.Instance?.ParseCommand("character bullet");
                    break;
				case PlayableCharacters.Eevee:
                    //ETGModConsole.Instance?.ParseCommand("character paradox");
                    DoCharacterSwapWithoutDestroyingPlayerObject("paradox");

                    break;
                default:
                    break;
            }

            //LootEngine.SpawnItem(archipelaGun.gameObject, user.CenterPosition, Vector2.zero, 0);

            //playerController.inventory.AddGunToInventory((Gun)archipelaGun, makeActive: true);
            //SpawnedItemLog.GivePlayerMissingItemsFromLog(user);

            return;
        }

        private static void DoCharacterSwapWithoutDestroyingPlayerObject(string characterToSwap)
        {
            GameObject gameObject = (GameObject)BraveResources.Load("Player" + characterToSwap);
            if (gameObject == null)
            {
                gameObject = (GameObject)Resources.Load("Player" + characterToSwap);
            }

            GameObject gameObject2 = UnityEngine.Object.Instantiate(GameManager.PlayerPrefabForNewGame, Vector3.zero, Quaternion.identity);
            gameObject2.SetActive(value: true);


            GameManager.Instance.PrimaryPlayer.sprite = gameObject2.GetComponent<PlayerController>().GetAnySprite();
        }
        /*
        public static void SwitchCharacter(string[] args)
        {
            if (args.Length < 1)
            {
                Log("Character not given!");
            }

            if (!Characters.TryGetValue(args[0], out var value))
            {
                value = args[0];
            }

            GameObject gameObject = (GameObject)BraveResources.Load("Player" + value);
            if (gameObject == null)
            {
                gameObject = (GameObject)Resources.Load("Player" + value);
            }

            if (gameObject == null)
            {
                Log("Invalid character " + args[0] + "!");
                return;
            }

            Pixelator.Instance.FadeToBlack(0.5f);
            bool flag = false;
            if ((bool)GameManager.Instance.PrimaryPlayer)
            {
                flag = GameManager.Instance.PrimaryPlayer.CharacterUsesRandomGuns;
            }

            GameManager.Instance.PrimaryPlayer.SetInputOverride("getting deleted");
            PlayerController primaryPlayer = GameManager.Instance.PrimaryPlayer;
            Vector3 position = primaryPlayer.transform.position;
            UnityEngine.Object.Destroy(primaryPlayer.gameObject);
            GameManager.Instance.ClearPrimaryPlayer();
            GameManager.PlayerPrefabForNewGame = gameObject;
            PlayerController component = GameManager.PlayerPrefabForNewGame.GetComponent<PlayerController>();
            GameStatsManager.Instance.BeginNewSession(component);
            GameObject gameObject2 = UnityEngine.Object.Instantiate(GameManager.PlayerPrefabForNewGame, position, Quaternion.identity);
            GameManager.PlayerPrefabForNewGame = null;
            gameObject2.SetActive(value: true);
            PlayerController component2 = gameObject2.GetComponent<PlayerController>();
            GameManager.Instance.PrimaryPlayer = component2;
            component2.PlayerIDX = 0;
            GameManager.Instance.MainCameraController.ClearPlayerCache();
            GameManager.Instance.MainCameraController.SetManualControl(manualControl: false);
            if (GameManager.Instance.IsFoyer)
            {
                Foyer.Instance.PlayerCharacterChanged(component2);
            }

            if (Minimap.Instance?.UIMinimap?.dockItems != null)
            {
                new List<Tuple<tk2dSprite, PassiveItem>>(Minimap.Instance.UIMinimap.dockItems).ForEach(delegate (Tuple<tk2dSprite, PassiveItem> x)
                {
                    Minimap.Instance.UIMinimap.RemovePassiveItemFromDock(x.Second);
                });
            }

            Pixelator.Instance.FadeToBlack(0.5f, reverse: true);
            if (flag)
            {
                GameManager.Instance.PrimaryPlayer.CharacterUsesRandomGuns = true;
                while (GameManager.Instance.PrimaryPlayer.inventory.AllGuns.Count > 1)
                {
                    Gun gun = GameManager.Instance.PrimaryPlayer.inventory.AllGuns[1];
                    GameManager.Instance.PrimaryPlayer.inventory.RemoveGunFromInventory(gun);
                    UnityEngine.Object.Destroy(gun.gameObject);
                }
            }

            if (args.Length == 2)
            {
                component2.SwapToAlternateCostume();
            }
        }
        */

        public static void ReceiveParadoxModeItem(int itemCase)
        {
            EffectsController.PlaySynergyVFX();

            switch (itemCase)
            {
                case 0:
                    ArchDebugPrint.DebugLog(DebugCategory.CharacterSystems, $"Marine unlocked for Paradox Mode");
					AddNewParadoxCharacter(PlayableCharacters.Soldier);
                    break;
                case 1:
                    ArchDebugPrint.DebugLog(DebugCategory.CharacterSystems, $"Convict unlocked for Paradox Mode");
                    AddNewParadoxCharacter(PlayableCharacters.Convict);
                    break;
                case 2:
                    ArchDebugPrint.DebugLog(DebugCategory.CharacterSystems, $"Pilot unlocked for Paradox Mode");
                    AddNewParadoxCharacter(PlayableCharacters.Pilot);
                    break;
                case 3:
                    ArchDebugPrint.DebugLog(DebugCategory.CharacterSystems, $"Hunter unlocked for Paradox Mode");
                    AddNewParadoxCharacter(PlayableCharacters.Guide);
                    break;
                case 4:
                    ArchDebugPrint.DebugLog(DebugCategory.CharacterSystems, $"Robot unlocked for Paradox Mode");
                    AddNewParadoxCharacter(PlayableCharacters.Robot);
                    break;
                case 5:
                    ArchDebugPrint.DebugLog(DebugCategory.CharacterSystems, $"Bullet unlocked for Paradox Mode");
                    AddNewParadoxCharacter(PlayableCharacters.Bullet);
                    break;

                default:
                    ArchDebugPrint.DebugLog(DebugCategory.CharacterSystems, $"Paradox Mode items received invalid ID: {itemCase}");
                    break;
            }

            return;
        }
    }
}
