using System;
using UnityEngine;

namespace NevernamedsItems;

internal class EnemyHealthModifiers
{
	public static void Init()
	{
		AIActor.OnPostStart = (Action<AIActor>)Delegate.Combine(AIActor.OnPostStart, new Action<AIActor>(onEnemyPostSpawn));
	}

	public static void onEnemyPostSpawn(AIActor enemy)
	{
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Invalid comparison between Unknown and I4
		if (Object.op_Implicit((Object)(object)enemy) && !string.IsNullOrEmpty(enemy.EnemyGuid) && (Object)(object)((BraveBehaviour)enemy).healthHaver != (Object)null)
		{
			if (enemy.EnemyGuid == EnemyGuidDatabase.Entries["ammoconda_ball"] && (int)((DungeonPlaceableBehaviour)enemy).GetAbsoluteParentRoom().area.PrototypeRoomCategory == 3 && ((BraveBehaviour)enemy).healthHaver.GetMaxHealth() > 15f * AIActor.BaseLevelHealthModifier)
			{
				float num = 15f * AIActor.BaseLevelHealthModifier;
				((BraveBehaviour)enemy).healthHaver.ForceSetCurrentHealth(num);
				((BraveBehaviour)enemy).healthHaver.SetHealthMaximum(num, (float?)null, false);
			}
			if (enemy.EnemyGuid == EnemyGuidDatabase.Entries["black_skusket"] && ((BraveBehaviour)enemy).healthHaver.GetMaxHealth() > 10f * AIActor.BaseLevelHealthModifier)
			{
				float num2 = 10f * AIActor.BaseLevelHealthModifier;
				((BraveBehaviour)enemy).healthHaver.ForceSetCurrentHealth(num2);
				((BraveBehaviour)enemy).healthHaver.SetHealthMaximum(num2, (float?)null, false);
			}
		}
	}
}
