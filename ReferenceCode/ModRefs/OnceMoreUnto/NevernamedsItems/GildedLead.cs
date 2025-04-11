using System;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class GildedLead : PassiveItem
{
	public static Color gold = new Color(46f / 51f, 58f / 85f, 7f / 85f);

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<GildedLead>("Gilded Lead", "Pays Off", "Chance to consume a casing when you fire a bullet. If a bullet consumes a casing it will have it's damage doubled.\nBuffed bullets that hit enemies will drop their casing onto the floor again. You miss, you lose out.\n\nBullets found scattered at the seat of the Charthurian Throne.", "gildedlead_icon", assetbundle: true);
		val.quality = (ItemQuality)3;
		AlexandriaTags.SetTag(val, "bullet_modifier");
		Doug.AddToLootPool(val.PickupObjectId);
	}

	private void PostProcessProjectile(Projectile sourceProjectile, float effectChanceScalar)
	{
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		if (((PassiveItem)this).Owner.carriedConsumables.Currency <= 0 || sourceProjectile.TreatedAsNonProjectileForChallenge)
		{
			return;
		}
		float num = ((!((PassiveItem)this).Owner.HasPickupID(10)) ? 0.1f : 0.5f);
		if (Random.value < num * effectChanceScalar)
		{
			PlayerConsumables carriedConsumables = ((PassiveItem)this).Owner.carriedConsumables;
			carriedConsumables.Currency -= 1;
			float num2 = 3f;
			if (((PassiveItem)this).Owner.HasPickupID(532))
			{
				num2 = 4f;
			}
			ProjectileData baseData = sourceProjectile.baseData;
			baseData.damage *= num2;
			sourceProjectile.AdjustPlayerProjectileTint(gold, 1, 0f);
			sourceProjectile.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(sourceProjectile.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(OnHitEnemy));
		}
	}

	private void OnHitEnemy(Projectile bullet, SpeculativeRigidbody enemy, bool fuckingsomethingidk)
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)bullet != (Object)null && (Object)(object)((BraveBehaviour)bullet).specRigidbody != (Object)null)
		{
			LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetById(68)).gameObject, Vector2.op_Implicit(((BraveBehaviour)bullet).specRigidbody.UnitCenter), Vector2.zero, 1f, false, true, false);
			bullet.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Remove(bullet.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(OnHitEnemy));
		}
	}

	private void PostProcessBeam(BeamController beam)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		if (((PickupObject)((GameActor)((PassiveItem)this).Owner).CurrentGun).PickupObjectId == 10)
		{
			beam.AdjustPlayerBeamTint(gold, 1, 0f);
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
			((PassiveItem)this).Owner.PostProcessProjectile -= PostProcessProjectile;
			((PassiveItem)this).Owner.PostProcessBeam -= PostProcessBeam;
		}
		((PassiveItem)this).OnDestroy();
	}
}
