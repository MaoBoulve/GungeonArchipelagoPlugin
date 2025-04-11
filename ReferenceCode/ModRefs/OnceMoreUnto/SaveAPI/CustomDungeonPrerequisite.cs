using System;
using UnityEngine;

namespace SaveAPI;

public class CustomDungeonPrerequisite : DungeonPrerequisite
{
	public enum AdvancedPrerequisiteType
	{
		NONE,
		CUSTOM_FLAG,
		CUSTOM_STAT_COMPARISION,
		CUSTOM_MAXIMUM_COMPARISON,
		NUMBER_PASTS_COMPLETED_BETTER,
		ENCOUNTER_OR_CUSTOM_FLAG
	}

	public AdvancedPrerequisiteType advancedPrerequisiteType;

	public CustomDungeonFlags customFlagToCheck;

	public bool requireCustomFlag;

	public Type requiredPassiveFlag;

	public CustomTrackedMaximums customMaximumToCheck;

	public CustomTrackedStats customStatToCheck;

	public virtual bool CheckConditionsFulfilled()
	{
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected I4, but got Unknown
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Expected I4, but got Unknown
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Expected I4, but got Unknown
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_0235: Unknown result type (might be due to invalid IL or missing references)
		//IL_0237: Unknown result type (might be due to invalid IL or missing references)
		//IL_0239: Unknown result type (might be due to invalid IL or missing references)
		//IL_024c: Expected I4, but got Unknown
		//IL_02bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02da: Expected I4, but got Unknown
		if (advancedPrerequisiteType == AdvancedPrerequisiteType.CUSTOM_FLAG)
		{
			return AdvancedGameStatsManager.Instance.GetFlag(customFlagToCheck) == requireCustomFlag;
		}
		if (advancedPrerequisiteType == AdvancedPrerequisiteType.CUSTOM_STAT_COMPARISION)
		{
			float playerStatValue = AdvancedGameStatsManager.Instance.GetPlayerStatValue(customStatToCheck);
			PrerequisiteOperation prerequisiteOperation = base.prerequisiteOperation;
			PrerequisiteOperation val = prerequisiteOperation;
			switch ((int)val)
			{
			case 0:
				return playerStatValue < base.comparisonValue;
			case 1:
				return playerStatValue == base.comparisonValue;
			case 2:
				return playerStatValue > base.comparisonValue;
			}
			Debug.LogError((object)"Switching on invalid stat comparison operation!");
		}
		else if (advancedPrerequisiteType == AdvancedPrerequisiteType.CUSTOM_MAXIMUM_COMPARISON)
		{
			float playerMaximum = AdvancedGameStatsManager.Instance.GetPlayerMaximum(customMaximumToCheck);
			PrerequisiteOperation prerequisiteOperation2 = base.prerequisiteOperation;
			PrerequisiteOperation val2 = prerequisiteOperation2;
			switch ((int)val2)
			{
			case 0:
				return playerMaximum < base.comparisonValue;
			case 1:
				return playerMaximum == base.comparisonValue;
			case 2:
				return playerMaximum > base.comparisonValue;
			}
			Debug.LogError((object)"Switching on invalid stat comparison operation!");
		}
		else
		{
			if (advancedPrerequisiteType != AdvancedPrerequisiteType.NUMBER_PASTS_COMPLETED_BETTER)
			{
				if (advancedPrerequisiteType == AdvancedPrerequisiteType.ENCOUNTER_OR_CUSTOM_FLAG)
				{
					EncounterDatabaseEntry val3 = null;
					if (!string.IsNullOrEmpty(base.encounteredObjectGuid))
					{
						val3 = EncounterDatabase.GetEntry(base.encounteredObjectGuid);
					}
					if (AdvancedGameStatsManager.Instance.GetFlag(customFlagToCheck) == requireCustomFlag)
					{
						return true;
					}
					if (val3 != null)
					{
						int num = GameStatsManager.Instance.QueryEncounterable(val3);
						PrerequisiteOperation prerequisiteOperation3 = base.prerequisiteOperation;
						PrerequisiteOperation val4 = prerequisiteOperation3;
						switch ((int)val4)
						{
						case 0:
							return num < base.requiredNumberOfEncounters;
						case 1:
							return num == base.requiredNumberOfEncounters;
						case 2:
							return num > base.requiredNumberOfEncounters;
						}
						Debug.LogError((object)"Switching on invalid stat comparison operation!");
					}
					else if ((Object)(object)base.encounteredRoom != (Object)null)
					{
						int num2 = GameStatsManager.Instance.QueryRoomEncountered(base.encounteredRoom.GUID);
						PrerequisiteOperation prerequisiteOperation4 = base.prerequisiteOperation;
						PrerequisiteOperation val5 = prerequisiteOperation4;
						switch ((int)val5)
						{
						case 0:
							return num2 < base.requiredNumberOfEncounters;
						case 1:
							return num2 == base.requiredNumberOfEncounters;
						case 2:
							return num2 > base.requiredNumberOfEncounters;
						}
						Debug.LogError((object)"Switching on invalid stat comparison operation!");
					}
					return false;
				}
				return CheckConditionsFulfilledOrig();
			}
			float num3 = GameStatsManager.Instance.GetNumberPastsBeaten();
			PrerequisiteOperation prerequisiteOperation5 = base.prerequisiteOperation;
			PrerequisiteOperation val6 = prerequisiteOperation5;
			switch ((int)val6)
			{
			case 0:
				return num3 < base.comparisonValue;
			case 1:
				return num3 == base.comparisonValue;
			case 2:
				return num3 > base.comparisonValue;
			}
			Debug.LogError((object)"Switching on invalid stat comparison operation!");
		}
		return false;
	}

	public bool CheckConditionsFulfilledOrig()
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected I4, but got Unknown
		//IL_0196: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Expected I4, but got Unknown
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_032f: Unknown result type (might be due to invalid IL or missing references)
		//IL_035f: Unknown result type (might be due to invalid IL or missing references)
		//IL_036c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0371: Unknown result type (might be due to invalid IL or missing references)
		//IL_0373: Unknown result type (might be due to invalid IL or missing references)
		//IL_0375: Unknown result type (might be due to invalid IL or missing references)
		//IL_0377: Unknown result type (might be due to invalid IL or missing references)
		//IL_038a: Expected I4, but got Unknown
		//IL_03d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_0313: Unknown result type (might be due to invalid IL or missing references)
		//IL_0319: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0244: Unknown result type (might be due to invalid IL or missing references)
		//IL_0411: Unknown result type (might be due to invalid IL or missing references)
		//IL_0416: Unknown result type (might be due to invalid IL or missing references)
		//IL_0418: Unknown result type (might be due to invalid IL or missing references)
		//IL_041a: Unknown result type (might be due to invalid IL or missing references)
		//IL_041c: Unknown result type (might be due to invalid IL or missing references)
		//IL_042f: Expected I4, but got Unknown
		//IL_0265: Unknown result type (might be due to invalid IL or missing references)
		//IL_026a: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c0: Expected I4, but got Unknown
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Expected I4, but got Unknown
		//IL_029a: Unknown result type (might be due to invalid IL or missing references)
		//IL_029f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected I4, but got Unknown
		EncounterDatabaseEntry val = null;
		if (!string.IsNullOrEmpty(base.encounteredObjectGuid))
		{
			val = EncounterDatabase.GetEntry(base.encounteredObjectGuid);
		}
		PrerequisiteType prerequisiteType = base.prerequisiteType;
		PrerequisiteType val2 = prerequisiteType;
		switch ((int)val2)
		{
		case 0:
			if (val == null && (Object)(object)base.encounteredRoom == (Object)null)
			{
				return true;
			}
			if (val != null)
			{
				int num3 = GameStatsManager.Instance.QueryEncounterable(val);
				PrerequisiteOperation prerequisiteOperation4 = base.prerequisiteOperation;
				PrerequisiteOperation val7 = prerequisiteOperation4;
				switch ((int)val7)
				{
				case 0:
					return num3 < base.requiredNumberOfEncounters;
				case 1:
					return num3 == base.requiredNumberOfEncounters;
				case 2:
					return num3 > base.requiredNumberOfEncounters;
				}
				Debug.LogError((object)"Switching on invalid stat comparison operation!");
			}
			else if ((Object)(object)base.encounteredRoom != (Object)null)
			{
				int num4 = GameStatsManager.Instance.QueryRoomEncountered(base.encounteredRoom.GUID);
				PrerequisiteOperation prerequisiteOperation5 = base.prerequisiteOperation;
				PrerequisiteOperation val8 = prerequisiteOperation5;
				switch ((int)val8)
				{
				case 0:
					return num4 < base.requiredNumberOfEncounters;
				case 1:
					return num4 == base.requiredNumberOfEncounters;
				case 2:
					return num4 > base.requiredNumberOfEncounters;
				}
				Debug.LogError((object)"Switching on invalid stat comparison operation!");
			}
			return false;
		case 1:
		{
			float playerStatValue = GameStatsManager.Instance.GetPlayerStatValue(base.statToCheck);
			PrerequisiteOperation prerequisiteOperation6 = base.prerequisiteOperation;
			PrerequisiteOperation val9 = prerequisiteOperation6;
			switch ((int)val9)
			{
			case 0:
				return playerStatValue < base.comparisonValue;
			case 1:
				return playerStatValue == base.comparisonValue;
			case 2:
				return playerStatValue > base.comparisonValue;
			}
			Debug.LogError((object)"Switching on invalid stat comparison operation!");
			break;
		}
		case 2:
		{
			PlayableCharacters val5 = (PlayableCharacters)(-1);
			if (!BraveRandom.IgnoreGenerationDifferentiator)
			{
				if ((Object)(object)GameManager.Instance.PrimaryPlayer != (Object)null)
				{
					val5 = GameManager.Instance.PrimaryPlayer.characterIdentity;
				}
				else if ((Object)(object)GameManager.PlayerPrefabForNewGame != (Object)null)
				{
					val5 = GameManager.PlayerPrefabForNewGame.GetComponent<PlayerController>().characterIdentity;
				}
				else if ((Object)(object)GameManager.Instance.BestGenerationDungeonPrefab != (Object)null)
				{
					val5 = GameManager.Instance.BestGenerationDungeonPrefab.defaultPlayerPrefab.GetComponent<PlayerController>().characterIdentity;
				}
			}
			return base.requireCharacter == (val5 == base.requiredCharacter);
		}
		case 3:
			if ((Object)(object)GameManager.Instance.BestGenerationDungeonPrefab != (Object)null)
			{
				return base.requireTileset == (GameManager.Instance.BestGenerationDungeonPrefab.tileIndices.tilesetId == base.requiredTileset);
			}
			return base.requireTileset == (GameManager.Instance.Dungeon.tileIndices.tilesetId == base.requiredTileset);
		case 4:
			return GameStatsManager.Instance.GetFlag(base.saveFlagToCheck) == base.requireFlag;
		case 5:
			return !base.requireDemoMode;
		case 6:
		{
			float playerMaximum = GameStatsManager.Instance.GetPlayerMaximum(base.maxToCheck);
			PrerequisiteOperation prerequisiteOperation3 = base.prerequisiteOperation;
			PrerequisiteOperation val6 = prerequisiteOperation3;
			switch ((int)val6)
			{
			case 0:
				return playerMaximum < base.comparisonValue;
			case 1:
				return playerMaximum == base.comparisonValue;
			case 2:
				return playerMaximum > base.comparisonValue;
			}
			Debug.LogError((object)"Switching on invalid stat comparison operation!");
			break;
		}
		case 7:
			if (GameStatsManager.Instance.GetFlag(base.saveFlagToCheck) == base.requireFlag)
			{
				return true;
			}
			if (val != null)
			{
				int num = GameStatsManager.Instance.QueryEncounterable(val);
				PrerequisiteOperation prerequisiteOperation = base.prerequisiteOperation;
				PrerequisiteOperation val3 = prerequisiteOperation;
				switch ((int)val3)
				{
				case 0:
					return num < base.requiredNumberOfEncounters;
				case 1:
					return num == base.requiredNumberOfEncounters;
				case 2:
					return num > base.requiredNumberOfEncounters;
				}
				Debug.LogError((object)"Switching on invalid stat comparison operation!");
			}
			else if ((Object)(object)base.encounteredRoom != (Object)null)
			{
				int num2 = GameStatsManager.Instance.QueryRoomEncountered(base.encounteredRoom.GUID);
				PrerequisiteOperation prerequisiteOperation2 = base.prerequisiteOperation;
				PrerequisiteOperation val4 = prerequisiteOperation2;
				switch ((int)val4)
				{
				case 0:
					return num2 < base.requiredNumberOfEncounters;
				case 1:
					return num2 == base.requiredNumberOfEncounters;
				case 2:
					return num2 > base.requiredNumberOfEncounters;
				}
				Debug.LogError((object)"Switching on invalid stat comparison operation!");
			}
			return false;
		case 8:
			return (float)GameStatsManager.Instance.GetNumberPastsBeaten() >= base.comparisonValue;
		default:
			Debug.LogError((object)"Switching on invalid prerequisite type!!!");
			break;
		}
		return false;
	}
}
