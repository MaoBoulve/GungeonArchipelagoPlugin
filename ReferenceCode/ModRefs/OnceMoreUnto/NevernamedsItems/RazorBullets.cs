using System;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class RazorBullets : PassiveItem
{
	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<RazorBullets>("Razor Bullets", "A Cut Above", "Standard ammunition, carved down to a razor sharp edge to increase their lacerating potential.", "razorbullets_icon", assetbundle: true);
		val.quality = (ItemQuality)4;
		AlexandriaTags.SetTag(val, "bullet_modifier");
		ItemBuilder.AddPassiveStatModifier(val, (StatType)14, 1f, (ModifyMethod)0);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)5, 1.1f, (ModifyMethod)1);
		Doug.AddToLootPool(val.PickupObjectId);
	}

	private void PostProcessProjectile(Projectile sourceProjectile, float effectChanceScalar)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		float num = 0.25f;
		num *= effectChanceScalar;
		if (Random.value <= num)
		{
			sourceProjectile.AdjustPlayerProjectileTint(Color.white, 2, 0f);
			sourceProjectile.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(sourceProjectile.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(HitEnemy));
			if ((Object)(object)((Component)sourceProjectile).GetComponent<PierceProjModifier>() != (Object)null)
			{
				PierceProjModifier component = ((Component)sourceProjectile).GetComponent<PierceProjModifier>();
				component.penetration++;
			}
			else
			{
				((Component)sourceProjectile).gameObject.AddComponent<PierceProjModifier>().penetration = 1;
			}
		}
	}

	private void HitEnemy(Projectile self, SpeculativeRigidbody enemy, bool fatal)
	{
		if (!fatal && Object.op_Implicit((Object)(object)enemy) && Object.op_Implicit((Object)(object)((BraveBehaviour)enemy).gameActor))
		{
			((BraveBehaviour)enemy).gameActor.ApplyEffect((GameActorEffect)(object)new GameActorExsanguinationEffect
			{
				duration = 15f
			}, 1f, (Projectile)null);
		}
	}

	private void PostProcessBeam(BeamController beam, SpeculativeRigidbody hitRigidBody, float tickrate)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		float num = 0.25f;
		beam.AdjustPlayerBeamTint(Color.white, 1, 0f);
		GameActor gameActor = ((BraveBehaviour)hitRigidBody).gameActor;
		if (Object.op_Implicit((Object)(object)gameActor) && Random.value < BraveMathCollege.SliceProbability(num, tickrate))
		{
			((BraveBehaviour)hitRigidBody).gameActor.ApplyEffect((GameActorEffect)(object)new GameActorExsanguinationEffect
			{
				duration = 15f
			}, 1f, (Projectile)null);
		}
	}

	public override DebrisObject Drop(PlayerController player)
	{
		DebrisObject result = ((PassiveItem)this).Drop(player);
		player.PostProcessProjectile -= PostProcessProjectile;
		player.PostProcessBeamTick -= PostProcessBeam;
		return result;
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		player.PostProcessProjectile += PostProcessProjectile;
		player.PostProcessBeamTick += PostProcessBeam;
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			((PassiveItem)this).Owner.PostProcessBeamTick -= PostProcessBeam;
			((PassiveItem)this).Owner.PostProcessProjectile -= PostProcessProjectile;
		}
		((PassiveItem)this).OnDestroy();
	}
}
