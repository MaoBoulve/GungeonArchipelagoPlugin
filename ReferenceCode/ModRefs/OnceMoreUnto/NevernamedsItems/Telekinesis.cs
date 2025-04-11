using System.Collections.Generic;
using Alexandria.ItemAPI;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

internal class Telekinesis : PlayerItem
{
	public static void Init()
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<Telekinesis>("Telekinesis", "Power Of The Mind", "Pushes all enemies in the direction aimed.\n\nOne hell of a headache.", "telekinesis_icon", assetbundle: true);
		PlayerItem val = (PlayerItem)(object)((obj is PlayerItem) ? obj : null);
		ItemBuilder.SetCooldownType(val, (CooldownType)0, 2f);
		((PickupObject)val).quality = (ItemQuality)1;
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)2, 1f);
	}

	public override void DoEffect(PlayerController user)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		Vector2 centerPosition = ((GameActor)user).CenterPosition;
		Vector2 val = Vector3Extensions.XY(user.unadjustedAimPoint) - centerPosition;
		Vector2 normalized = ((Vector2)(ref val)).normalized;
		List<AIActor> activeEnemies = user.CurrentRoom.GetActiveEnemies((ActiveEnemyType)0);
		if (activeEnemies == null)
		{
			return;
		}
		for (int i = 0; i < activeEnemies.Count; i++)
		{
			AIActor val2 = activeEnemies[i];
			if (Object.op_Implicit((Object)(object)val2) && Object.op_Implicit((Object)(object)((BraveBehaviour)val2).knockbackDoer))
			{
				((BraveBehaviour)val2).knockbackDoer.ApplyKnockback(normalized, 100f, false);
			}
		}
	}

	public override bool CanBeUsed(PlayerController user)
	{
		if (Object.op_Implicit((Object)(object)user) && (Object)(object)((GameActor)user).CurrentGun != (Object)null)
		{
			return true;
		}
		return false;
	}
}
