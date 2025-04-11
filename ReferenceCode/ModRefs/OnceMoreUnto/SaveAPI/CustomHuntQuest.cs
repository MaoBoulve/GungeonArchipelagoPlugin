using System;
using System.Collections.Generic;
using UnityEngine;

namespace SaveAPI;

[Serializable]
public class CustomHuntQuest : MonsterHuntQuest
{
	[LongEnum]
	[SerializeField]
	public CustomDungeonFlags CustomQuestFlag;

	[LongEnum]
	[SerializeField]
	public List<CustomDungeonFlags> CustomFlagsToSetUponReward;

	[SerializeField]
	public Func<AIActor, MonsterHuntProgress, bool> ValidTargetCheck;

	[SerializeField]
	public JammedEnemyState RequiredEnemyState;

	public bool IsQuestComplete()
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		if (CustomQuestFlag != 0 && AdvancedGameStatsManager.Instance.GetFlag(CustomQuestFlag))
		{
			return true;
		}
		return GameStatsManager.Instance.GetFlag(base.QuestFlag);
	}

	public bool IsEnemyValid(AIActor enemy, MonsterHuntProgress progress)
	{
		if (ValidTargetCheck != null && !ValidTargetCheck(enemy, progress))
		{
			return false;
		}
		return SaveTools.IsEnemyStateValid(enemy, RequiredEnemyState);
	}

	public void Complete()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		if ((int)base.QuestFlag > 0)
		{
			GameStatsManager.Instance.SetFlag(base.QuestFlag, true);
		}
		if (CustomQuestFlag != 0)
		{
			AdvancedGameStatsManager.Instance.SetFlag(CustomQuestFlag, value: true);
		}
	}

	public void UnlockRewards()
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		for (int i = 0; i < base.FlagsToSetUponReward.Count; i++)
		{
			GameStatsManager.Instance.SetFlag(base.FlagsToSetUponReward[i], true);
		}
		for (int j = 0; j < CustomFlagsToSetUponReward.Count; j++)
		{
			AdvancedGameStatsManager.Instance.SetFlag(CustomFlagsToSetUponReward[j], value: true);
		}
	}
}
