using System.Collections.Generic;
using Alexandria.ItemAPI;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class AffectEnemiesInProximityTickItem : PassiveItem
{
	public string rangeMultSynergy;

	public float synergyRangeMult;

	public float range;

	public AffectEnemiesInProximityTickItem()
	{
		rangeMultSynergy = "";
		synergyRangeMult = 1f;
		range = 2f;
	}

	public override void Update()
	{
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner) && ((PassiveItem)this).Owner.CurrentRoom != null)
		{
			List<AIActor> activeEnemies = ((PassiveItem)this).Owner.CurrentRoom.GetActiveEnemies((ActiveEnemyType)0);
			if (activeEnemies != null)
			{
				for (int i = 0; i < activeEnemies.Count; i++)
				{
					AIActor val = activeEnemies[i];
					if ((Object)(object)val != (Object)null && val.IsNormalEnemy && Object.op_Implicit((Object)(object)((BraveBehaviour)val).transform))
					{
						float num = range;
						if (!string.IsNullOrEmpty(rangeMultSynergy) && CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, rangeMultSynergy))
						{
							num *= synergyRangeMult;
						}
						float num2 = Vector2.Distance(((GameActor)((PassiveItem)this).Owner).CenterPosition, ((GameActor)val).CenterPosition);
						if (num2 <= num)
						{
							AffectEnemy(val);
						}
					}
				}
			}
		}
		((PassiveItem)this).Update();
	}

	public virtual void AffectEnemy(AIActor aiactor)
	{
	}
}
