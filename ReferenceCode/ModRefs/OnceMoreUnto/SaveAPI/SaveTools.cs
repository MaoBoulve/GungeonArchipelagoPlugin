using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace SaveAPI;

public static class SaveTools
{
	public static bool IsReallyCompleted(this MonsterHuntQuest quest)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Invalid comparison between Unknown and I4
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		bool flag = true;
		foreach (GungeonFlags item in quest.FlagsToSetUponReward)
		{
			if ((int)item != 0 && !GameStatsManager.Instance.GetFlag(item))
			{
				flag = false;
				break;
			}
		}
		if (quest is CustomHuntQuest customHuntQuest)
		{
			if (flag)
			{
				foreach (CustomDungeonFlags item2 in customHuntQuest.CustomFlagsToSetUponReward)
				{
					if (item2 != 0 && !AdvancedGameStatsManager.Instance.GetFlag(item2))
					{
						flag = false;
						break;
					}
				}
			}
			bool flag2 = false;
			if ((int)quest.QuestFlag > 0)
			{
				flag2 = GameStatsManager.Instance.GetFlag(quest.QuestFlag);
			}
			else if (customHuntQuest.CustomQuestFlag != 0)
			{
				flag2 = AdvancedGameStatsManager.Instance.GetFlag(customHuntQuest.CustomQuestFlag);
			}
			return flag2 && flag;
		}
		return GameStatsManager.Instance.GetFlag(quest.QuestFlag) && flag;
	}

	public static void SafeMove(string oldPath, string newPath, bool allowOverwritting = false)
	{
		if (File.Exists(oldPath) && (allowOverwritting || !File.Exists(newPath)))
		{
			string text = SaveManager.ReadAllText(oldPath);
			try
			{
				SaveManager.WriteAllText(newPath, text);
			}
			catch (Exception ex)
			{
				Debug.LogErrorFormat("Failed to move {0} to {1}: {2}", new object[3] { oldPath, newPath, ex });
				return;
			}
			try
			{
				File.Delete(oldPath);
			}
			catch (Exception ex2)
			{
				Debug.LogErrorFormat("Failed to delete old file {0}: {1}", new object[3] { oldPath, newPath, ex2 });
				return;
			}
			if (File.Exists(oldPath + ".bak"))
			{
				File.Delete(oldPath + ".bak");
			}
		}
	}

	public static List<T2> Convert<T, T2>(this List<T> self, Func<T, T2> convertor)
	{
		List<T2> list = new List<T2>();
		foreach (T item in self)
		{
			list.Add(convertor(item));
		}
		return list;
	}

	public static bool SetsCustomFlagOnDeath(this AIActor enemy)
	{
		return (Object)(object)((Component)enemy).GetComponent<SpecialAIActor>() != (Object)null && ((Component)enemy).GetComponent<SpecialAIActor>().SetsCustomFlagOnDeath;
	}

	public static CustomDungeonFlags GetCustomFlagToSetOnDeath(this AIActor enemy)
	{
		return ((Object)(object)((Component)enemy).GetComponent<SpecialAIActor>() != (Object)null && ((Component)enemy).GetComponent<SpecialAIActor>().SetsCustomFlagOnDeath) ? ((Component)enemy).GetComponent<SpecialAIActor>().CustomFlagToSetOnDeath : CustomDungeonFlags.NONE;
	}

	public static void SetCustomFlagToSetOnDeath(this AIActor enemy, CustomDungeonFlags flag)
	{
		SpecialAIActor orAddComponent = GameObjectExtensions.GetOrAddComponent<SpecialAIActor>(((Component)enemy).gameObject);
		if (flag == CustomDungeonFlags.NONE)
		{
			orAddComponent.SetsCustomFlagOnDeath = false;
		}
		else if (flag != 0)
		{
			orAddComponent.SetsCustomFlagOnDeath = true;
		}
		orAddComponent.CustomFlagToSetOnDeath = flag;
	}

	public static bool SetsCustomFlagOnActivation(this AIActor enemy)
	{
		return (Object)(object)((Component)enemy).GetComponent<SpecialAIActor>() != (Object)null && ((Component)enemy).GetComponent<SpecialAIActor>().SetsCustomFlagOnActivation;
	}

	public static CustomDungeonFlags GetCustomFlagToSetOnActivation(this AIActor enemy)
	{
		return ((Object)(object)((Component)enemy).GetComponent<SpecialAIActor>() != (Object)null && ((Component)enemy).GetComponent<SpecialAIActor>().SetsCustomFlagOnActivation) ? ((Component)enemy).GetComponent<SpecialAIActor>().CustomFlagToSetOnActivation : CustomDungeonFlags.NONE;
	}

	public static void SetCustomFlagToSetOnActivation(this AIActor enemy, CustomDungeonFlags flag)
	{
		SpecialAIActor orAddComponent = GameObjectExtensions.GetOrAddComponent<SpecialAIActor>(((Component)enemy).gameObject);
		if (flag == CustomDungeonFlags.NONE)
		{
			orAddComponent.SetsCustomFlagOnActivation = false;
		}
		else if (flag != 0)
		{
			orAddComponent.SetsCustomFlagOnActivation = true;
		}
		orAddComponent.CustomFlagToSetOnActivation = flag;
	}

	public static bool SetsCustomCharacterSpecificFlagOnDeath(this AIActor enemy)
	{
		return (Object)(object)((Component)enemy).GetComponent<SpecialAIActor>() != (Object)null && ((Component)enemy).GetComponent<SpecialAIActor>().SetsCustomCharacterSpecificFlagOnDeath;
	}

	public static CustomCharacterSpecificGungeonFlags GetCustomCharacterSpecificFlagToSetOnDeath(this AIActor enemy)
	{
		return ((Object)(object)((Component)enemy).GetComponent<SpecialAIActor>() != (Object)null && ((Component)enemy).GetComponent<SpecialAIActor>().SetsCustomCharacterSpecificFlagOnDeath) ? ((Component)enemy).GetComponent<SpecialAIActor>().CustomCharacterSpecificFlagToSetOnDeath : CustomCharacterSpecificGungeonFlags.NONE;
	}

	public static void SetCustomCharacterSpecificFlagToSetOnDeath(this AIActor enemy, CustomCharacterSpecificGungeonFlags flag)
	{
		SpecialAIActor orAddComponent = GameObjectExtensions.GetOrAddComponent<SpecialAIActor>(((Component)enemy).gameObject);
		if (flag == CustomCharacterSpecificGungeonFlags.NONE)
		{
			orAddComponent.SetsCustomCharacterSpecificFlagOnDeath = false;
		}
		else if (flag != 0)
		{
			orAddComponent.SetsCustomCharacterSpecificFlagOnDeath = true;
		}
		orAddComponent.CustomCharacterSpecificFlagToSetOnDeath = flag;
	}

	public static string PathCombine(string a, string b, string c)
	{
		return Path.Combine(Path.Combine(a, b), c);
	}

	public static DungeonPrerequisite SetupUnlockOnFlag(this PickupObject self, GungeonFlags flag, bool requiredFlagValue)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)((BraveBehaviour)self).encounterTrackable == (Object)null)
		{
			return null;
		}
		return ((BraveBehaviour)self).encounterTrackable.SetupUnlockOnFlag(flag, requiredFlagValue);
	}

	public static DungeonPrerequisite SetupUnlockOnFlag(this EncounterTrackable self, GungeonFlags flag, bool requiredFlagValue)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		return self.AddPrerequisite(new DungeonPrerequisite
		{
			prerequisiteType = (PrerequisiteType)4,
			saveFlagToCheck = flag,
			requireFlag = requiredFlagValue
		});
	}

	public static DungeonPrerequisite SetupUnlockOnStat(this PickupObject self, TrackedStats stat, float comparisonValue, PrerequisiteOperation comparisonOperation)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)((BraveBehaviour)self).encounterTrackable == (Object)null)
		{
			return null;
		}
		return ((BraveBehaviour)self).encounterTrackable.SetupUnlockOnStat(stat, comparisonValue, comparisonOperation);
	}

	public static DungeonPrerequisite SetupUnlockOnStat(this EncounterTrackable self, TrackedStats stat, float comparisonValue, PrerequisiteOperation comparisonOperation)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected O, but got Unknown
		return self.AddPrerequisite(new DungeonPrerequisite
		{
			prerequisiteType = (PrerequisiteType)1,
			statToCheck = stat,
			prerequisiteOperation = comparisonOperation,
			comparisonValue = comparisonValue
		});
	}

	public static DungeonPrerequisite SetupUnlockOnMaximum(this PickupObject self, TrackedMaximums maximum, float comparisonValue, PrerequisiteOperation comparisonOperation)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)((BraveBehaviour)self).encounterTrackable == (Object)null)
		{
			return null;
		}
		return ((BraveBehaviour)self).encounterTrackable.SetupUnlockOnMaximum(maximum, comparisonValue, comparisonOperation);
	}

	public static DungeonPrerequisite SetupUnlockOnMaximum(this EncounterTrackable self, TrackedMaximums maximum, float comparisonValue, PrerequisiteOperation comparisonOperation)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected O, but got Unknown
		return self.AddPrerequisite(new DungeonPrerequisite
		{
			prerequisiteType = (PrerequisiteType)6,
			maxToCheck = maximum,
			prerequisiteOperation = comparisonOperation,
			comparisonValue = comparisonValue
		});
	}

	public static DungeonPrerequisite SetupUnlockOnEncounter(this PickupObject self, string encounterObjectGuid, int requiredNumberOfEncounters, PrerequisiteOperation comparisonOperation)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)((BraveBehaviour)self).encounterTrackable == (Object)null)
		{
			return null;
		}
		return ((BraveBehaviour)self).encounterTrackable.SetupUnlockOnEncounter(encounterObjectGuid, requiredNumberOfEncounters, comparisonOperation);
	}

	public static DungeonPrerequisite SetupUnlockOnEncounter(this EncounterTrackable self, string encounterObjectGuid, int requiredNumberOfEncounters, PrerequisiteOperation comparisonOperation)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected O, but got Unknown
		return self.AddPrerequisite(new DungeonPrerequisite
		{
			prerequisiteType = (PrerequisiteType)0,
			encounteredObjectGuid = encounterObjectGuid,
			requiredNumberOfEncounters = requiredNumberOfEncounters,
			prerequisiteOperation = comparisonOperation
		});
	}

	public static DungeonPrerequisite SetupUnlockOnEncounter(this PickupObject self, PrototypeDungeonRoom encounterRoom, int requiredNumberOfEncounters, PrerequisiteOperation comparisonOperation)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)((BraveBehaviour)self).encounterTrackable == (Object)null)
		{
			return null;
		}
		return ((BraveBehaviour)self).encounterTrackable.SetupUnlockOnEncounter(encounterRoom, requiredNumberOfEncounters, comparisonOperation);
	}

	public static DungeonPrerequisite SetupUnlockOnEncounter(this EncounterTrackable self, PrototypeDungeonRoom encounterRoom, int requiredNumberOfEncounters, PrerequisiteOperation comparisonOperation)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected O, but got Unknown
		return self.AddPrerequisite(new DungeonPrerequisite
		{
			prerequisiteType = (PrerequisiteType)0,
			encounteredRoom = encounterRoom,
			requiredNumberOfEncounters = requiredNumberOfEncounters,
			prerequisiteOperation = comparisonOperation
		});
	}

	public static DungeonPrerequisite SetupUnlockOnEncounterOrFlag(this PickupObject self, GungeonFlags flag, bool requiredFlagValue, string encounterObjectGuid, int requiredNumberOfEncounters, PrerequisiteOperation comparisonOperation)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)((BraveBehaviour)self).encounterTrackable == (Object)null)
		{
			return null;
		}
		return ((BraveBehaviour)self).encounterTrackable.SetupUnlockOnEncounterOrFlag(flag, requiredFlagValue, encounterObjectGuid, requiredNumberOfEncounters, comparisonOperation);
	}

	public static DungeonPrerequisite SetupUnlockOnEncounterOrFlag(this EncounterTrackable self, GungeonFlags flag, bool requiredFlagValue, string encounterObjectGuid, int requiredNumberOfEncounters, PrerequisiteOperation comparisonOperation)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected O, but got Unknown
		return self.AddPrerequisite(new DungeonPrerequisite
		{
			prerequisiteType = (PrerequisiteType)7,
			saveFlagToCheck = flag,
			requireFlag = requiredFlagValue,
			encounteredObjectGuid = encounterObjectGuid,
			requiredNumberOfEncounters = requiredNumberOfEncounters,
			prerequisiteOperation = comparisonOperation
		});
	}

	public static DungeonPrerequisite SetupUnlockOnEncounterOrFlag(this PickupObject self, GungeonFlags flag, bool requiredFlagValue, PrototypeDungeonRoom encounterRoom, int requiredNumberOfEncounters, PrerequisiteOperation comparisonOperation)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)((BraveBehaviour)self).encounterTrackable == (Object)null)
		{
			return null;
		}
		return ((BraveBehaviour)self).encounterTrackable.SetupUnlockOnEncounterOrFlag(flag, requiredFlagValue, encounterRoom, requiredNumberOfEncounters, comparisonOperation);
	}

	public static DungeonPrerequisite SetupUnlockOnEncounterOrFlag(this EncounterTrackable self, GungeonFlags flag, bool requiredFlagValue, PrototypeDungeonRoom encounterRoom, int requiredNumberOfEncounters, PrerequisiteOperation comparisonOperation)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected O, but got Unknown
		return self.AddPrerequisite(new DungeonPrerequisite
		{
			prerequisiteType = (PrerequisiteType)7,
			saveFlagToCheck = flag,
			requireFlag = requiredFlagValue,
			encounteredRoom = encounterRoom,
			requiredNumberOfEncounters = requiredNumberOfEncounters,
			prerequisiteOperation = comparisonOperation
		});
	}

	public static DungeonPrerequisite SetupUnlockOnTileset(this PickupObject self, ValidTilesets requiredTileset, bool requiredTilesetValue)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)((BraveBehaviour)self).encounterTrackable == (Object)null)
		{
			return null;
		}
		return ((BraveBehaviour)self).encounterTrackable.SetupUnlockOnTileset(requiredTileset, requiredTilesetValue);
	}

	public static DungeonPrerequisite SetupUnlockOnTileset(this EncounterTrackable self, ValidTilesets requiredTileset, bool requiredTilesetValue)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		return self.AddPrerequisite(new DungeonPrerequisite
		{
			prerequisiteType = (PrerequisiteType)3,
			requireTileset = requiredTilesetValue,
			requiredTileset = requiredTileset
		});
	}

	public static DungeonPrerequisite SetupUnlockOnCharacter(this PickupObject self, PlayableCharacters requiredCharacter, bool requiredCharacterValue)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)((BraveBehaviour)self).encounterTrackable == (Object)null)
		{
			return null;
		}
		return ((BraveBehaviour)self).encounterTrackable.SetupUnlockOnCharacter(requiredCharacter, requiredCharacterValue);
	}

	public static DungeonPrerequisite SetupUnlockOnCharacter(this EncounterTrackable self, PlayableCharacters requiredCharacter, bool requiredCharacterValue)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		return self.AddPrerequisite(new DungeonPrerequisite
		{
			prerequisiteType = (PrerequisiteType)2,
			requireCharacter = requiredCharacterValue,
			requiredCharacter = requiredCharacter
		});
	}

	public static DungeonPrerequisite SetupUnlockOnEncounterOrCustomFlag(this PickupObject self, CustomDungeonFlags flag, bool requiredFlagValue, string encounterObjectGuid, int requiredNumberOfEncounters, PrerequisiteOperation comparisonOperation)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)((BraveBehaviour)self).encounterTrackable == (Object)null)
		{
			return null;
		}
		return ((BraveBehaviour)self).encounterTrackable.SetupUnlockOnEncounterOrCustomFlag(flag, requiredFlagValue, encounterObjectGuid, requiredNumberOfEncounters, comparisonOperation);
	}

	public static DungeonPrerequisite SetupUnlockOnEncounterOrCustomFlag(this EncounterTrackable self, CustomDungeonFlags flag, bool requiredFlagValue, string encounterObjectGuid, int requiredNumberOfEncounters, PrerequisiteOperation comparisonOperation)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		return (DungeonPrerequisite)(object)self.AddPrerequisite(new CustomDungeonPrerequisite
		{
			advancedPrerequisiteType = CustomDungeonPrerequisite.AdvancedPrerequisiteType.ENCOUNTER_OR_CUSTOM_FLAG,
			customFlagToCheck = flag,
			requireCustomFlag = requiredFlagValue,
			encounteredObjectGuid = encounterObjectGuid,
			requiredNumberOfEncounters = requiredNumberOfEncounters,
			prerequisiteOperation = comparisonOperation
		});
	}

	public static DungeonPrerequisite SetupUnlockOnEncounterOrCustomFlag(this PickupObject self, CustomDungeonFlags flag, bool requiredFlagValue, PrototypeDungeonRoom encounterRoom, int requiredNumberOfEncounters, PrerequisiteOperation comparisonOperation)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)((BraveBehaviour)self).encounterTrackable == (Object)null)
		{
			return null;
		}
		return ((BraveBehaviour)self).encounterTrackable.SetupUnlockOnEncounterOrCustomFlag(flag, requiredFlagValue, encounterRoom, requiredNumberOfEncounters, comparisonOperation);
	}

	public static DungeonPrerequisite SetupUnlockOnEncounterOrCustomFlag(this EncounterTrackable self, CustomDungeonFlags flag, bool requiredFlagValue, PrototypeDungeonRoom encounterRoom, int requiredNumberOfEncounters, PrerequisiteOperation comparisonOperation)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		return (DungeonPrerequisite)(object)self.AddPrerequisite(new CustomDungeonPrerequisite
		{
			advancedPrerequisiteType = CustomDungeonPrerequisite.AdvancedPrerequisiteType.ENCOUNTER_OR_CUSTOM_FLAG,
			customFlagToCheck = flag,
			requireCustomFlag = requiredFlagValue,
			encounteredRoom = encounterRoom,
			requiredNumberOfEncounters = requiredNumberOfEncounters,
			prerequisiteOperation = comparisonOperation
		});
	}

	public static DungeonPrerequisite SetupUnlockOnCustomFlag(this PickupObject self, CustomDungeonFlags flag, bool requiredFlagValue)
	{
		if ((Object)(object)((BraveBehaviour)self).encounterTrackable == (Object)null)
		{
			return null;
		}
		return ((BraveBehaviour)self).encounterTrackable.SetupUnlockOnCustomFlag(flag, requiredFlagValue);
	}

	public static DungeonPrerequisite SetupUnlockOnCustomFlag(this EncounterTrackable self, CustomDungeonFlags flag, bool requiredFlagValue)
	{
		return (DungeonPrerequisite)(object)self.AddPrerequisite(new CustomDungeonPrerequisite
		{
			advancedPrerequisiteType = CustomDungeonPrerequisite.AdvancedPrerequisiteType.CUSTOM_FLAG,
			requireCustomFlag = requiredFlagValue,
			customFlagToCheck = flag
		});
	}

	public static DungeonPrerequisite SetupUnlockOnCustomStat(this PickupObject self, CustomTrackedStats stat, float comparisonValue, PrerequisiteOperation comparisonOperation)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)((BraveBehaviour)self).encounterTrackable == (Object)null)
		{
			return null;
		}
		return ((BraveBehaviour)self).encounterTrackable.SetupUnlockOnCustomStat(stat, comparisonValue, comparisonOperation);
	}

	public static DungeonPrerequisite SetupUnlockOnCustomStat(this EncounterTrackable self, CustomTrackedStats stat, float comparisonValue, PrerequisiteOperation comparisonOperation)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		return (DungeonPrerequisite)(object)self.AddPrerequisite(new CustomDungeonPrerequisite
		{
			advancedPrerequisiteType = CustomDungeonPrerequisite.AdvancedPrerequisiteType.CUSTOM_STAT_COMPARISION,
			customStatToCheck = stat,
			prerequisiteOperation = comparisonOperation,
			comparisonValue = comparisonValue
		});
	}

	public static DungeonPrerequisite SetupUnlockOnCustomMaximum(this PickupObject self, CustomTrackedMaximums maximum, float comparisonValue, PrerequisiteOperation comparisonOperation)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)((BraveBehaviour)self).encounterTrackable == (Object)null)
		{
			return null;
		}
		return ((BraveBehaviour)self).encounterTrackable.SetupUnlockOnCustomMaximum(maximum, comparisonValue, comparisonOperation);
	}

	public static DungeonPrerequisite SetupUnlockOnCustomMaximum(this EncounterTrackable self, CustomTrackedMaximums maximum, float comparisonValue, PrerequisiteOperation comparisonOperation)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		return (DungeonPrerequisite)(object)self.AddPrerequisite(new CustomDungeonPrerequisite
		{
			advancedPrerequisiteType = CustomDungeonPrerequisite.AdvancedPrerequisiteType.CUSTOM_MAXIMUM_COMPARISON,
			customMaximumToCheck = maximum,
			prerequisiteOperation = comparisonOperation,
			comparisonValue = comparisonValue
		});
	}

	public static DungeonPrerequisite SetupUnlockOnPastsBeaten(this PickupObject self, float comparisonValue, PrerequisiteOperation comparisonOperation)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)((BraveBehaviour)self).encounterTrackable == (Object)null)
		{
			return null;
		}
		return ((BraveBehaviour)self).encounterTrackable.SetupUnlockOnPastsBeaten(comparisonValue, comparisonOperation);
	}

	public static DungeonPrerequisite SetupUnlockOnPastsBeaten(this EncounterTrackable self, float comparisonValue, PrerequisiteOperation comparisonOperation)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		return (DungeonPrerequisite)(object)self.AddPrerequisite(new CustomDungeonPrerequisite
		{
			advancedPrerequisiteType = CustomDungeonPrerequisite.AdvancedPrerequisiteType.NUMBER_PASTS_COMPLETED_BETTER,
			prerequisiteOperation = comparisonOperation,
			comparisonValue = comparisonValue
		});
	}

	public static T AddPrerequisite<T>(this PickupObject self, T prereq) where T : DungeonPrerequisite
	{
		return (T)(object)self.AddPrerequisite((DungeonPrerequisite)(object)prereq);
	}

	public static T AddPrerequisite<T>(this EncounterTrackable self, T prereq) where T : DungeonPrerequisite
	{
		return (T)(object)self.AddPrerequisite((DungeonPrerequisite)(object)prereq);
	}

	public static DungeonPrerequisite AddPrerequisite(this PickupObject self, DungeonPrerequisite prereq)
	{
		return ((BraveBehaviour)self).encounterTrackable.AddPrerequisite(prereq);
	}

	public static DungeonPrerequisite AddPrerequisite(this EncounterTrackable self, DungeonPrerequisite prereq)
	{
		if (!string.IsNullOrEmpty(self.ProxyEncounterGuid))
		{
			self.ProxyEncounterGuid = "";
		}
		if (self.prerequisites == null)
		{
			self.prerequisites = (DungeonPrerequisite[])(object)new DungeonPrerequisite[1] { prereq };
		}
		else
		{
			self.prerequisites = self.prerequisites.Concat((IEnumerable<DungeonPrerequisite>)(object)new DungeonPrerequisite[1] { prereq }).ToArray();
		}
		EncounterDatabaseEntry entry = EncounterDatabase.GetEntry(self.EncounterGuid);
		if (!string.IsNullOrEmpty(entry.ProxyEncounterGuid))
		{
			entry.ProxyEncounterGuid = "";
		}
		if (entry.prerequisites == null)
		{
			entry.prerequisites = (DungeonPrerequisite[])(object)new DungeonPrerequisite[1] { prereq };
		}
		else
		{
			entry.prerequisites = entry.prerequisites.Concat((IEnumerable<DungeonPrerequisite>)(object)new DungeonPrerequisite[1] { prereq }).ToArray();
		}
		return prereq;
	}

	public static string ListToString<T>(List<T> list)
	{
		string text = "(";
		for (int i = 0; i < list.Count; i++)
		{
			string text2 = list[i].ToString();
			text += text2;
			if (i < list.Count - 1)
			{
				text += ", ";
			}
		}
		return text + ")";
	}

	public static void InsertOrAdd<T>(this List<T> self, int index, T toAdd)
	{
		if (index < 0 || index > self.Count)
		{
			self.Add(toAdd);
		}
		else
		{
			self.Insert(index, toAdd);
		}
	}

	public static void LogSmart(string text, bool debuglog = false)
	{
		if (ETGModConsole.Instance != null)
		{
			ETGModConsole.Log((object)text, debuglog);
		}
		else
		{
			Debug.Log((object)text);
		}
	}

	public static List<T> CloneList<T>(List<T> orig)
	{
		List<T> list = new List<T>();
		for (int i = 0; i < orig.Count; i++)
		{
			list.Add(orig[i]);
		}
		return list;
	}

	public static T LoadAssetFromAnywhere<T>(string path) where T : Object
	{
		string[] array = new string[30]
		{
			"brave_resources_001", "dungeon_scene_001", "encounters_base_001", "enemies_base_001", "flows_base_001", "foyer_001", "foyer_002", "foyer_003", "shared_auto_001", "shared_auto_002",
			"shared_base_001", "dungeons/base_bullethell", "dungeons/base_castle", "dungeons/base_catacombs", "dungeons/base_cathedral", "dungeons/base_forge", "dungeons/base_foyer", "dungeons/base_gungeon", "dungeons/base_mines", "dungeons/base_nakatomi",
			"dungeons/base_resourcefulrat", "dungeons/base_sewer", "dungeons/base_tutorial", "dungeons/finalscenario_bullet", "dungeons/finalscenario_convict", "dungeons/finalscenario_coop", "dungeons/finalscenario_guide", "dungeons/finalscenario_pilot", "dungeons/finalscenario_robot", "dungeons/finalscenario_soldier"
		};
		T val = default(T);
		string[] array2 = array;
		foreach (string text in array2)
		{
			try
			{
				val = ResourceManager.LoadAssetBundle(text).LoadAsset<T>(path);
			}
			catch
			{
			}
			if ((Object)(object)val != (Object)null)
			{
				break;
			}
		}
		return val;
	}

	public static void SetComplex(this StringDBTable self, string key, params string[] values)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		StringCollection val = (StringCollection)new ComplexStringCollection();
		foreach (string text in values)
		{
			val.AddString(text, 1f);
		}
		self[key] = val;
	}

	public static bool IsEnemyStateValid(AIActor enemy, JammedEnemyState requiredState)
	{
		int result;
		switch (requiredState)
		{
		case JammedEnemyState.NoCheck:
			return true;
		case JammedEnemyState.Unjammed:
			result = ((!enemy.IsBlackPhantom) ? 1 : 0);
			break;
		default:
			result = 0;
			break;
		case JammedEnemyState.Jammed:
			result = (enemy.IsBlackPhantom ? 1 : 0);
			break;
		}
		return (byte)result != 0;
	}
}
