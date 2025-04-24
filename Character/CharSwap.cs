using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Alexandria.ItemAPI;
using ArchiGungeon.DebugTools;

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

		private static List<int> GunIDs { get; } = new()
		{
			12,
			99,
			810,
			202,
			80,
			652,
			473,
			89,
			651,
			86,
			809,
			88,
			812,
			417,
			813
		};

		private static List<int> PassiveIDs { get; } = new()
		{
			300,
			353,
			187,
			473,
			354,
			410,
			414
		};

		
		// TODO: hook into deep player debug
		public static void SetPlayerToNextAvailableChar(PlayerController user)
        {
			ArchDebugPrint.DebugLog(DebugCategory.CharacterSystems, "Removing all actives");
			user.RemoveAllActiveItems();

			foreach(int gunID in GunIDs)
            {
				ArchDebugPrint.DebugLog(DebugCategory.CharacterSystems, "Removing all guns");

				if (user.HasGun(gunID))
                {
					user.inventory.RemoveGunFromInventory((Gun)PickupObjectDatabase.GetById(gunID));
                }
            }

			foreach(int passiveID in PassiveIDs)
            {
				ArchDebugPrint.DebugLog(DebugCategory.CharacterSystems, "Removing all passives");

				if (user.HasPickupID(passiveID))
                {
					user.RemovePassiveItem(passiveID);
                }
            }

			currentCharacterIndex = GetNextAvailableCharacterIndex(currentCharacterIndex);
			ArchDebugPrint.DebugLog(DebugCategory.CharacterSystems, $"Swapping to {CharacterOrder[currentCharacterIndex]}");
			HandleCharacterSwapCase(CharacterOrder[currentCharacterIndex], user);

			return;
        }

		private static int GetNextAvailableCharacterIndex(int currentIndex)
        {
			//recursively call until a valid character is found
			currentIndex += 1;

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
					GivePilotLoadout(user);
					break;
                case PlayableCharacters.Convict:
					GiveConvictLoadout(user);
					break;
                case PlayableCharacters.Robot:
					GiveRobotLoadout(user);
					break;
                case PlayableCharacters.Soldier:
					GiveMarineLoadout(user);
					break;
                case PlayableCharacters.Guide:
					GiveHunterLoadout(user);
					break;
                case PlayableCharacters.Bullet:
					GiveBulletLoadout(user);
					break;
                default:
                    break;
            }

			return;
        }

        private static void GiveHunterLoadout(PlayerController user)
		{
			if (!user.HasPickupID(300))
			{
				PickupObject byId = PickupObjectDatabase.GetById(300);
				user.AcquirePassiveItemPrefabDirectly((PassiveItem)(object)((byId is PassiveItem) ? byId : null));
			}
			if (!user.HasPickupID(12))
			{
				PickupObject byId2 = PickupObjectDatabase.GetById(12);
				Gun val = (Gun)(object)((byId2 is Gun) ? byId2 : null);
				user.inventory.AddGunToInventory(val, true);
			}
			if (!user.HasPickupID(99) && !user.HasPickupID(810))
			{
				PickupObject byId3 = PickupObjectDatabase.GetById(99);
				Gun val2 = (Gun)(object)((byId3 is Gun) ? byId3 : null);
				user.inventory.AddGunToInventory(val2, true);
			}

			return;
		}

		private static void GiveConvictLoadout(PlayerController user)
		{
			
			if (!user.HasPickupID(353))
			{
				PickupObject byId = PickupObjectDatabase.GetById(353);
				user.AcquirePassiveItemPrefabDirectly((PassiveItem)(object)((byId is PassiveItem) ? byId : null));
			}
			if (!user.HasPickupID(202))
			{
				PickupObject byId2 = PickupObjectDatabase.GetById(202);
				Gun val = (Gun)(object)((byId2 is Gun) ? byId2 : null);
				user.inventory.AddGunToInventory(val, true);
			}
			if (!user.HasPickupID(80) && !user.HasPickupID(652))
			{
				PickupObject byId3 = PickupObjectDatabase.GetById(80);
				Gun val2 = (Gun)(object)((byId3 is Gun) ? byId3 : null);
				user.inventory.AddGunToInventory(val2, true);
			}
			
		}

		private static void GivePilotLoadout(PlayerController user)
		{
			
			if (!user.HasPickupID(187))
			{
				PickupObject byId = PickupObjectDatabase.GetById(187);
				user.AcquirePassiveItemPrefabDirectly((PassiveItem)(object)((byId is PassiveItem) ? byId : null));
			}
			if (!user.HasPickupID(473))
			{
				PickupObject byId2 = PickupObjectDatabase.GetById(473);
				user.AcquirePassiveItemPrefabDirectly((PassiveItem)(object)((byId2 is PassiveItem) ? byId2 : null));
			}
			if (!user.HasPickupID(89) && !user.HasPickupID(651))
			{
				PickupObject byId3 = PickupObjectDatabase.GetById(89);
				Gun val = (Gun)(object)((byId3 is Gun) ? byId3 : null);
				user.inventory.AddGunToInventory(val, true);
			}
			

		}


		private static void GiveMarineLoadout(PlayerController user)
		{
			
			if (!user.HasPickupID(354))
			{
				PickupObject byId = PickupObjectDatabase.GetById(354);
				user.AcquirePassiveItemPrefabDirectly((PassiveItem)(object)((byId is PassiveItem) ? byId : null));
			}
			if (!user.HasPickupID(86) && !user.HasPickupID(809))
			{
				PickupObject byId2 = PickupObjectDatabase.GetById(86);
				Gun val = (Gun)(object)((byId2 is Gun) ? byId2 : null);
				user.inventory.AddGunToInventory(val, true);
			}
			
		}

		private static void GiveRobotLoadout(PlayerController user)
		{
			
			if (!user.HasPickupID(410))
			{
				PickupObject byId = PickupObjectDatabase.GetById(410);
				user.AcquirePassiveItemPrefabDirectly((PassiveItem)(object)((byId is PassiveItem) ? byId : null));
			}
			if (!user.HasPickupID(88) && !user.HasPickupID(812))
			{
				PickupObject byId2 = PickupObjectDatabase.GetById(88);
				Gun val = (Gun)(object)((byId2 is Gun) ? byId2 : null);
				user.inventory.AddGunToInventory(val, true);
			}
			

		}

		private static void GiveBulletLoadout(PlayerController user)
		{
			if (!user.HasPickupID(414))
			{
				PickupObject byId = PickupObjectDatabase.GetById(414);
				user.AcquirePassiveItemPrefabDirectly((PassiveItem)(object)((byId is PassiveItem) ? byId : null));
			}
			if (!user.HasPickupID(417) && !user.HasPickupID(813))
			{
				PickupObject byId2 = PickupObjectDatabase.GetById(417);
				Gun val = (Gun)(object)((byId2 is Gun) ? byId2 : null);
				user.inventory.AddGunToInventory(val, true);
			}

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
						PickupObject byId4 = PickupObjectDatabase.GetById(356);
						user.GiveItem(byId4.itemName);
					}
					break;
                case PlayableCharacters.Convict:
					if (!user.HasPickupID(366))
					{
						ArchDebugPrint.DebugLog(DebugCategory.CharacterSystems, "Convict Active");
						PickupObject byId4 = PickupObjectDatabase.GetById(366);
						user.GiveItem(byId4.itemName);
					}

					break;
                case PlayableCharacters.Robot:
					if (!user.HasPickupID(411))
					{
						ArchDebugPrint.DebugLog(DebugCategory.CharacterSystems, "Robot Active");
						PickupObject byId3 = PickupObjectDatabase.GetById(411);
						user.GiveItem(byId3.itemName);
					}
					break;
                case PlayableCharacters.Soldier:

					if (!user.HasPickupID(77))
					{
						ArchDebugPrint.DebugLog(DebugCategory.CharacterSystems, "Soldier Active");
						PickupObject byId3 = PickupObjectDatabase.GetById(77);
						user.GiveItem(byId3.itemName);
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
