using System.Collections.Generic;
using Alexandria.Misc;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class DistortionWaveDamager : BraveBehaviour
{
	public float Damage = 5f;

	public float Range = 4f;

	public bool MultByPlayerDamage = true;

	public string audioEvent = null;

	public float lockDownDuration = -1f;

	private List<GameActorEffect> eff = new List<GameActorEffect>();

	public float stunDuration = -1f;

	public void Start()
	{
		if (Object.op_Implicit((Object)(object)((BraveBehaviour)this).projectile))
		{
			((BraveBehaviour)this).projectile.OnDestruction += OnDest;
		}
	}

	public void OnDest(Projectile self)
	{
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)self))
		{
			float num = Damage;
			if (!string.IsNullOrEmpty(audioEvent))
			{
				AkSoundEngine.PostEvent(audioEvent, ((Component)self).gameObject);
			}
			if (Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(self)) && MultByPlayerDamage)
			{
				num *= ProjectileUtility.ProjectilePlayerOwner(self).stats.GetStatValue((StatType)5);
			}
			Exploder.DoDistortionWave(self.SafeCenter, 0.5f, 0.04f, Range, 0.3f);
			Exploder.DoRadialDamage(num, Vector2.op_Implicit(self.SafeCenter), Range, false, true, false, (VFXPool)null);
			if (lockDownDuration > 0f)
			{
				eff.Add((GameActorEffect)(object)StatusEffectHelper.GenerateLockdown(lockDownDuration));
			}
			if ((float)eff.Count > 0f)
			{
				AfflictEnemiesInRadius(self.SafeCenter);
			}
		}
	}

	private void AfflictEnemiesInRadius(Vector2 vector2)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		if (!Object.op_Implicit((Object)(object)((BraveBehaviour)this).projectile))
		{
			return;
		}
		List<AIActor> activeEnemies = Vector3Extensions.GetAbsoluteRoom(vector2).GetActiveEnemies((ActiveEnemyType)0);
		if (activeEnemies == null)
		{
			return;
		}
		for (int i = 0; i < activeEnemies.Count; i++)
		{
			AIActor val = activeEnemies[i];
			if (!((Object)(object)val != (Object)null) || !val.IsNormalEnemy || !Object.op_Implicit((Object)(object)((BraveBehaviour)val).transform))
			{
				continue;
			}
			float num = Vector2.Distance(vector2, ((GameActor)val).CenterPosition);
			if (!(num <= Range))
			{
				continue;
			}
			foreach (GameActorEffect item in eff)
			{
				((GameActor)val).ApplyEffect(item, 1f, (Projectile)null);
			}
			if (stunDuration > 0f && Object.op_Implicit((Object)(object)((BraveBehaviour)val).behaviorSpeculator))
			{
				((BraveBehaviour)val).behaviorSpeculator.Stun(stunDuration, true);
			}
		}
	}
}
