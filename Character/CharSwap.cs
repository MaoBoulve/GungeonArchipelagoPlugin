using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Alexandria.ItemAPI;
using ArchiGungeon.DebugTools;
using ArchiGungeon.ModConsoleVisuals;

namespace ArchiGungeon.Character
{
    public class CharSwap
    {
		private static int currentCharacterIndex = 0;
		private static Dictionary<PlayableCharacters, bool> AvailableChars { get; } = new Dictionary<PlayableCharacters, bool>()
		{
			{PlayableCharacters.Eevee, false },
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
                default:
                    break;
            }

            GameObject archipelItem = PickupObjectDatabase.GetById(Archipelagun.SpawnItemID).gameObject;
            LootEngine.SpawnItem(archipelItem, user.CenterPosition, Vector2.zero, 0);

            return;
        }

		public static void CheckToGiveActiveItem(PlayerController user)
        {
			PlayableCharacters currentChar = CharacterOrder[currentCharacterIndex];

            switch (currentChar)
            {
                case PlayableCharacters.Pilot:
					if (!user.HasPickupID(356))
					{
						ArchDebugPrint.DebugLog(DebugCategory.CharacterSystems, "Pilot Active");
						user.GiveItem("trusty_lockpicks");

                    }
					break;
                case PlayableCharacters.Convict:
					if (!user.HasPickupID(366))
					{
						ArchDebugPrint.DebugLog(DebugCategory.CharacterSystems, "Convict Active");
						user.GiveItem("molotov");
					}

					break;
                case PlayableCharacters.Robot:
					if (!user.HasPickupID(411))
					{
						ArchDebugPrint.DebugLog(DebugCategory.CharacterSystems, "Robot Active");
						user.GiveItem("coolant_leak");

                    }
					break;
                case PlayableCharacters.Soldier:

					if (!user.HasPickupID(77))
					{
						ArchDebugPrint.DebugLog(DebugCategory.CharacterSystems, "Soldier Active");
						user.GiveItem("supply_drop");
					}
					if(user.healthHaver.Armor < 1)
                    {
						LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(120)).gameObject, user);
					}
					break;

                default:
                    break;
            }

            return;
        }
    }
}
