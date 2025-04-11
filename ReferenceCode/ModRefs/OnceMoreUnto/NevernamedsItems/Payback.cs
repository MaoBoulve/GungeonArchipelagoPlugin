using System;
using System.Collections.Generic;
using Alexandria.ItemAPI;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

internal class Payback : PassiveItem
{
	private float Radius
	{
		get
		{
			float result = 2f;
			if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner) && CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Paid In Full"))
			{
				result = 4f;
			}
			return result;
		}
	}

	private float Duration
	{
		get
		{
			float result = 10f;
			if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner) && CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Paid In Full"))
			{
				result = 1000f;
			}
			return result;
		}
	}

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<Payback>("Payback", "The Golden Touch", "Upon taking damage, closeby enemies become gilded. Enemies that shoot you also become gilded.\n\nThey can hurt you, but ultimately they'll be the ones paying for it.", "payback_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)2;
	}

	public override void Pickup(PlayerController player)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		((BraveBehaviour)player).healthHaver.OnDamaged += new OnDamagedEvent(OnDamage);
		player.OnHitByProjectile = (Action<Projectile, PlayerController>)Delegate.Combine(player.OnHitByProjectile, new Action<Projectile, PlayerController>(OnShot));
		((PassiveItem)this).Pickup(player);
	}

	public override void DisableEffect(PlayerController player)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected O, but got Unknown
		if (Object.op_Implicit((Object)(object)player))
		{
			((BraveBehaviour)player).healthHaver.OnDamaged -= new OnDamagedEvent(OnDamage);
			player.OnHitByProjectile = (Action<Projectile, PlayerController>)Delegate.Remove(player.OnHitByProjectile, new Action<Projectile, PlayerController>(OnShot));
		}
		((PassiveItem)this).DisableEffect(player);
	}

	public void OnDamage(float resultValue, float maxValue, CoreDamageTypes damageTypes, DamageCategory damageCategory, Vector2 damageDirection)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		if (!Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			return;
		}
		Exploder.DoDistortionWave(((GameActor)((PassiveItem)this).Owner).CenterPosition, 0.5f, 0.04f, Radius, 0.3f);
		Exploder.DoRadialKnockback(Vector2.op_Implicit(((GameActor)((PassiveItem)this).Owner).CenterPosition), 5f, Radius);
		AkSoundEngine.PostEvent("Play_ITM_Macho_Brace_Active_01", ((Component)this).gameObject);
		List<AIActor> activeEnemies = ((PassiveItem)this).Owner.CurrentRoom.GetActiveEnemies((ActiveEnemyType)0);
		if (activeEnemies == null)
		{
			return;
		}
		for (int i = 0; i < activeEnemies.Count; i++)
		{
			AIActor val = activeEnemies[i];
			if ((Object)(object)val != (Object)null && val.IsNormalEnemy && Object.op_Implicit((Object)(object)((BraveBehaviour)val).transform))
			{
				float num = Vector2.Distance(((GameActor)((PassiveItem)this).Owner).CenterPosition, ((GameActor)val).CenterPosition);
				if (num <= Radius)
				{
					((GameActor)val).ApplyEffect((GameActorEffect)(object)new GameActorGildedEffect
					{
						duration = 10f,
						stackMode = (EffectStackingMode)0
					}, 1f, (Projectile)null);
				}
			}
		}
	}

	public void OnShot(Projectile hitter, PlayerController tro)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)hitter != (Object)null && (Object)(object)hitter.Owner != (Object)null)
		{
			hitter.Owner.ApplyEffect((GameActorEffect)(object)new GameActorGildedEffect
			{
				duration = Duration,
				stackMode = (EffectStackingMode)0
			}, 1f, (Projectile)null);
		}
	}
}
