using System;
using System.Collections.Generic;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class CleansingRounds : PassiveItem
{
	public static void Init()
	{
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<CleansingRounds>("Cleansing Rounds", "Undo What Is Done", "These holy shells are capable of saving the Gundead from eternal Jamnation.", "cleansingrounds_improved", assetbundle: true);
		List<string> list = new List<string> { "nn:cleansing_rounds", "silver_bullets" };
		CustomSynergies.Add("Holy Smackerel", list, (List<string>)null, true);
		val.quality = (ItemQuality)3;
		AlexandriaTags.SetTag(val, "bullet_modifier");
		Doug.AddToLootPool(val.PickupObjectId);
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		player.PostProcessProjectile += PostProcessProjectile;
		player.PostProcessBeam += PostProcessBeam;
	}

	private void PostProcessProjectile(Projectile sourceProjectile, float effectChanceScalar)
	{
		sourceProjectile.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(sourceProjectile.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(OnHitEnemy));
	}

	private void PostProcessBeam(BeamController sourceBeam)
	{
		try
		{
			Projectile projectile = ((BraveBehaviour)sourceBeam).projectile;
			projectile.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(projectile.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(OnHitEnemy));
		}
		catch (Exception ex)
		{
			ETGModConsole.Log((object)ex.Message, false);
		}
	}

	private void OnHitEnemy(Projectile arg1, SpeculativeRigidbody arg2, bool arg3)
	{
		if (!((Object)(object)arg2 != (Object)null) || !((Object)(object)((BraveBehaviour)arg2).aiActor != (Object)null) || !((Object)(object)((PassiveItem)this).Owner != (Object)null) || !((BraveBehaviour)arg2).aiActor.IsBlackPhantom || ((BraveBehaviour)arg2).healthHaver.IsDead)
		{
			return;
		}
		float value = Random.value;
		if (((PassiveItem)this).Owner.HasPickupID(538))
		{
			if ((double)value > 0.5)
			{
				((BraveBehaviour)arg2).aiActor.UnbecomeBlackPhantom();
			}
		}
		else if ((double)value < 0.1)
		{
			((BraveBehaviour)arg2).aiActor.UnbecomeBlackPhantom();
		}
	}

	public override DebrisObject Drop(PlayerController player)
	{
		DebrisObject result = ((PassiveItem)this).Drop(player);
		player.PostProcessProjectile -= PostProcessProjectile;
		player.PostProcessBeam -= PostProcessBeam;
		return result;
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			((PassiveItem)this).Owner.PostProcessProjectile -= PostProcessProjectile;
			((PassiveItem)this).Owner.PostProcessBeam -= PostProcessBeam;
		}
		((PassiveItem)this).OnDestroy();
	}
}
