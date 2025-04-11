using System.Collections.Generic;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class AdvancedDungeonPrerequisite : CustomDungeonPrerequisite
{
	public enum AdvancedAdvancedPrerequisiteType
	{
		NONE,
		PASSIVE_ITEM_FLAG,
		SPEEDRUN_TIMER_BEFORE,
		SPEEDRUN_TIMER_AFTER,
		UNLOCK,
		MULTIPLE_FLOORS
	}

	public float BeforeTimeInSeconds;

	public float AfterTimeInSeconds;

	public bool UnlockRequirement;

	public CustomDungeonFlags UnlockFlag;

	public AdvancedAdvancedPrerequisiteType advancedAdvancedPrerequisiteType;

	public List<ValidTilesets> validTilesets = new List<ValidTilesets>();

	public override bool CheckConditionsFulfilled()
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		if (advancedAdvancedPrerequisiteType != 0)
		{
			if (advancedAdvancedPrerequisiteType == AdvancedAdvancedPrerequisiteType.MULTIPLE_FLOORS)
			{
				ValidTilesets val = (ValidTilesets)1;
				if ((Object)(object)GameManager.Instance.BestGenerationDungeonPrefab != (Object)null)
				{
					val = GameManager.Instance.BestGenerationDungeonPrefab.tileIndices.tilesetId;
					return validTilesets.Contains(val);
				}
				return false;
			}
			if (advancedAdvancedPrerequisiteType == AdvancedAdvancedPrerequisiteType.PASSIVE_ITEM_FLAG)
			{
				if (PassiveItem.IsFlagSetAtAll(requiredPassiveFlag))
				{
					return true;
				}
				return false;
			}
			if (advancedAdvancedPrerequisiteType == AdvancedAdvancedPrerequisiteType.SPEEDRUN_TIMER_BEFORE)
			{
				if (GameStatsManager.Instance.GetSessionStatValue((TrackedStats)23) <= BeforeTimeInSeconds)
				{
					return true;
				}
				return false;
			}
			if (advancedAdvancedPrerequisiteType == AdvancedAdvancedPrerequisiteType.UNLOCK)
			{
				if (SaveAPIManager.GetFlag(UnlockFlag) == UnlockRequirement)
				{
					return true;
				}
				return false;
			}
			if (advancedAdvancedPrerequisiteType == AdvancedAdvancedPrerequisiteType.SPEEDRUN_TIMER_AFTER)
			{
				if (GameStatsManager.Instance.GetSessionStatValue((TrackedStats)23) >= AfterTimeInSeconds)
				{
					return true;
				}
				return false;
			}
			return false;
		}
		return base.CheckConditionsFulfilled();
	}
}
