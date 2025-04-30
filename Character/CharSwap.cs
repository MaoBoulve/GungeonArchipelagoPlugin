using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Alexandria.ItemAPI;
using ArchiGungeon.DebugTools;
using ArchiGungeon.ModConsoleVisuals;
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
            PlayerController playerController = GungeonPlayerEventListener.GetFirstAlivePlayer();
            switch (characterToSwap)
            {
                case PlayableCharacters.Pilot:
                    ETGModConsole.Instance?.ParseCommand("character pilot");
                    break;
                case PlayableCharacters.Convict:
                    ETGModConsole.Instance?.ParseCommand("character convict");
                    break;
                case PlayableCharacters.Robot:
                    ETGModConsole.Instance?.ParseCommand("character robot");
                    break;
                case PlayableCharacters.Soldier:
                    ETGModConsole.Instance?.ParseCommand("character marine");
                    break;
                case PlayableCharacters.Guide:
                    ETGModConsole.Instance?.ParseCommand("character hunter");
                    break;
                case PlayableCharacters.Bullet:
                    ETGModConsole.Instance?.ParseCommand("character bullet");
                    break;
				case PlayableCharacters.Eevee:
					ETGModConsole.Instance?.ParseCommand("character paradox");
					break;
                default:
                    break;
            }

            GameObject archipelItem = PickupObjectDatabase.GetById(Archipelagun.SpawnItemID).gameObject;
            LootEngine.SpawnItem(archipelItem, playerController.CenterPosition, Vector2.zero, 0);

            return;
        }

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
