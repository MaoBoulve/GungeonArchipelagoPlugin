using System;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class FatLineModifiers : GunBehaviour
{
	public override void PostProcessProjectile(Projectile projectile)
	{
		projectile.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(projectile.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(OnHitEnemy));
	}

	private void OnHitEnemy(Projectile bullet, SpeculativeRigidbody enemy, bool fatal)
	{
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Expected O, but got Unknown
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Expected O, but got Unknown
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		if (bullet.Owner is PlayerController && CustomSynergies.PlayerHasActiveSynergy((PlayerController)/*isinst with value type is only supported in some contexts*/, "Parallel Lines") && Random.value <= 0.1f)
		{
			if (Random.value <= 0.5f)
			{
				GameObject val = (GameObject)ResourceCache.Acquire("Global VFX/BlankVFX_Ghost");
				AkSoundEngine.PostEvent("Play_OBJ_silenceblank_small_01", ((Component)this).gameObject);
				GameObject val2 = new GameObject("silencer");
				SilencerInstance val3 = val2.AddComponent<SilencerInstance>();
				float num = 0.25f;
				_003F val4 = val3;
				Vector2 unitCenter = ((BraveBehaviour)bullet).specRigidbody.UnitCenter;
				GameActor owner = bullet.Owner;
				((SilencerInstance)val4).TriggerSilencer(unitCenter, 25f, 5f, val, 0f, 3f, 3f, 3f, 250f, 5f, num, (PlayerController)(object)((owner is PlayerController) ? owner : null), false, false);
			}
			else
			{
				ExplosionData val5 = StaticExplosionDatas.explosiveRoundsExplosion.CopyExplosionData();
				val5.ignoreList.Add(((BraveBehaviour)ProjectileUtility.ProjectilePlayerOwner(bullet)).specRigidbody);
				Exploder.Explode(Vector2.op_Implicit(((BraveBehaviour)bullet).specRigidbody.UnitCenter), val5, Vector2.zero, (Action)null, false, (CoreDamageTypes)0, false);
			}
		}
	}
}
