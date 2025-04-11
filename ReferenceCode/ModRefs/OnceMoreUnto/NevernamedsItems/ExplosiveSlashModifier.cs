using System;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class ExplosiveSlashModifier : ProjectileSlashingBehaviour
{
	public ExplosionData explosionData;

	public override void SlashHitTarget(GameActor target, bool fatal)
	{
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		for (int i = 0; i < GameManager.Instance.AllPlayers.Length; i++)
		{
			PlayerController val = GameManager.Instance.AllPlayers[i];
			if (Object.op_Implicit((Object)(object)val) && Object.op_Implicit((Object)(object)((BraveBehaviour)val).specRigidbody))
			{
				explosionData.ignoreList.Add(((BraveBehaviour)val).specRigidbody);
			}
		}
		Exploder.Explode(Vector2.op_Implicit(target.CenterPosition), explosionData, Vector2.zero, (Action)null, false, (CoreDamageTypes)0, false);
		((ProjectileSlashingBehaviour)this).SlashHitTarget(target, fatal);
	}
}
