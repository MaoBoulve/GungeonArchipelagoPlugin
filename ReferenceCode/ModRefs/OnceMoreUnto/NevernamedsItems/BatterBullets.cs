using System;
using Alexandria.ItemAPI;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class BatterBullets : PassiveItem
{
	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<BatterBullets>("Batter Bullets", "Up", "Smacks enemies on fatal damage.\n\nThere are two types of people in this world; people who enjoy beating others with baseball bats, and the rest of you weirdos.", "batterbullets_icon", assetbundle: true);
		val.quality = (ItemQuality)2;
		AlexandriaTags.SetTag(val, "bullet_modifier");
		val.SetupUnlockOnCustomFlag(CustomDungeonFlags.PURCHASED_BATTERBULLETS, requiredFlagValue: true);
		val.AddItemToDougMetaShop(45, null);
		Doug.AddToLootPool(val.PickupObjectId);
	}

	private void PostProcessProjectile(Projectile sourceProjectile, float effectChanceScalar)
	{
		if (!Object.op_Implicit((Object)(object)((Component)sourceProjectile).GetComponent<KilledEnemiesBecomeProjectileModifier>()))
		{
			ProjectileData baseData = sourceProjectile.baseData;
			baseData.force *= 3f;
			ProjectileData baseData2 = sourceProjectile.baseData;
			baseData2.speed *= 1.25f;
			sourceProjectile.UpdateSpeed();
			sourceProjectile.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(sourceProjectile.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(OnHitEnemy));
			KilledEnemiesBecomeProjectileModifier val = ((Component)sourceProjectile).gameObject.AddComponent<KilledEnemiesBecomeProjectileModifier>();
			ref bool completelyBecomeProjectile = ref val.CompletelyBecomeProjectile;
			PickupObject byId = PickupObjectDatabase.GetById(541);
			completelyBecomeProjectile = ((Component)((Gun)((byId is Gun) ? byId : null)).DefaultModule.chargeProjectiles[0].Projectile).GetComponent<KilledEnemiesBecomeProjectileModifier>().CompletelyBecomeProjectile;
			ref Projectile baseProjectile = ref val.BaseProjectile;
			PickupObject byId2 = PickupObjectDatabase.GetById(541);
			baseProjectile = ((Component)((Gun)((byId2 is Gun) ? byId2 : null)).DefaultModule.chargeProjectiles[0].Projectile).GetComponent<KilledEnemiesBecomeProjectileModifier>().BaseProjectile;
		}
	}

	private void OnHitEnemy(Projectile self, SpeculativeRigidbody bodi, bool fatal)
	{
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)self) && Object.op_Implicit((Object)(object)bodi) && fatal)
		{
			PickupObject byId = PickupObjectDatabase.GetById(541);
			GameObject effect = ((Gun)((byId is Gun) ? byId : null)).DefaultModule.chargeProjectiles[0].Projectile.hitEffects.enemy.effects[0].effects[0].effect;
			Object.Instantiate<GameObject>(effect, Vector2.op_Implicit(((BraveBehaviour)self).specRigidbody.UnitCenter), Quaternion.identity);
		}
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		player.PostProcessProjectile += PostProcessProjectile;
	}

	public override void DisableEffect(PlayerController player)
	{
		player.PostProcessProjectile -= PostProcessProjectile;
		((PassiveItem)this).DisableEffect(player);
	}
}
