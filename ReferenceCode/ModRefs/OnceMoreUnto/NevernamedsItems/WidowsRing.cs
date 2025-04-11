using System;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class WidowsRing : PassiveItem
{
	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<WidowsRing>("Widow's Ring", "Deadly Charms", "Charmed enemies can be instantly slain.\n\nThe previous owner of this ring was banished to the Gungeon for murdering five of his ex-husbands.\nThere's even a small compartment inside containing poison.", "widowsring_improved", assetbundle: true);
		val.quality = (ItemQuality)2;
		Game.Items.Rename("nn:widow's_ring", "nn:widows_ring");
	}

	private void OnHitEnemy(Projectile self, SpeculativeRigidbody enemy, bool fatal)
	{
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)enemy) && Object.op_Implicit((Object)(object)((BraveBehaviour)enemy).healthHaver) && Object.op_Implicit((Object)(object)((BraveBehaviour)enemy).aiActor) && ((BraveBehaviour)enemy).aiActor.CanTargetEnemies && !((BraveBehaviour)enemy).aiActor.CanTargetPlayers && !((BraveBehaviour)enemy).healthHaver.IsBoss && (Object)(object)((Component)enemy).GetComponent<CompanionController>() == (Object)null)
		{
			((BraveBehaviour)enemy).healthHaver.ApplyDamage(10000000f, Vector2.zero, "Erasure", (CoreDamageTypes)0, (DamageCategory)5, true, (PixelCollider)null, false);
		}
	}

	private void PostProcessProjectile(Projectile sourceProjectile, float effectChanceScalar)
	{
		sourceProjectile.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(sourceProjectile.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(OnHitEnemy));
	}

	private void PostProcessBeam(BeamController beam)
	{
		if (Object.op_Implicit((Object)(object)((Component)beam).GetComponent<Projectile>()))
		{
			PostProcessProjectile(((Component)beam).GetComponent<Projectile>(), 1f);
		}
	}

	public override DebrisObject Drop(PlayerController player)
	{
		DebrisObject result = ((PassiveItem)this).Drop(player);
		player.PostProcessProjectile -= PostProcessProjectile;
		player.PostProcessBeam -= PostProcessBeam;
		return result;
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		player.PostProcessProjectile += PostProcessProjectile;
		player.PostProcessBeam += PostProcessBeam;
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			((PassiveItem)this).Owner.PostProcessBeam -= PostProcessBeam;
			((PassiveItem)this).Owner.PostProcessProjectile -= PostProcessProjectile;
		}
		((PassiveItem)this).OnDestroy();
	}
}
