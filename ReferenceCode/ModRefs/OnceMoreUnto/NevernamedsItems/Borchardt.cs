using System;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class Borchardt : AdvancedGunBehavior
{
	public static int ID;

	public static void Add()
	{
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Borchardt", "borchardt");
		Game.Items.Rename("outdated_gun_mods:borchardt", "nn:borchardt");
		Borchardt borchardt = ((Component)val).gameObject.AddComponent<Borchardt>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Preluger");
		GunExt.SetLongDescription((PickupObject)(object)val, "Landing a shot on an enemy has a chance to force a shotgun blast from the meagre barrel of this weapon. Exactly why this works isn't entirely known, but most people don't care too much.");
		val.SetGunSprites("borchardt");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 10);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 0);
		PickupObject byId = PickupObjectDatabase.GetById(22);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId2 = PickupObjectDatabase.GetById(22);
		muzzleFlashEffects = ((Gun)((byId2 is Gun) ? byId2 : null)).muzzleFlashEffects;
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId3 = PickupObjectDatabase.GetById(22);
		gunSwitchGroup = ((Gun)((byId3 is Gun) ? byId3 : null)).gunSwitchGroup;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1.2f;
		val.DefaultModule.cooldownTime = 0.22f;
		val.DefaultModule.angleVariance = 8f;
		val.DefaultModule.numberOfShotsInClip = 12;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2f, 0.75f, 0f);
		val.SetBaseMaxAmmo(400);
		val.gunClass = (GunClass)1;
		Projectile val2 = ProjectileUtility.InstantiateAndFakeprefab(val.DefaultModule.projectiles[0]);
		val2.baseData.damage = 10f;
		val.DefaultModule.projectiles[0] = val2;
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)3, 1f);
		ID = ((PickupObject)val).PickupObjectId;
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.PURCHASED_BORCHARDT, requiredFlagValue: true);
		((PickupObject)(object)val).AddItemToTrorcMetaShop(20, null);
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		if (Object.op_Implicit((Object)(object)projectile) && Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(projectile)))
		{
			projectile.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(projectile.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(OnHit));
		}
		((AdvancedGunBehavior)this).PostProcessProjectile(projectile);
	}

	private void OnHit(Projectile proj, SpeculativeRigidbody body, bool fatal)
	{
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		if (Random.value <= 0.1f && Object.op_Implicit((Object)(object)GunTools.GunPlayerOwner(base.gun)))
		{
			for (int i = 0; i < 6; i++)
			{
				Projectile component = ProjectileUtility.InstantiateAndFireInDirection(base.gun.DefaultModule.projectiles[0], Vector2.op_Implicit(base.gun.barrelOffset.position), base.gun.CurrentAngle, 20f, GunTools.GunPlayerOwner(base.gun)).GetComponent<Projectile>();
				component.ScaleByPlayerStats(GunTools.GunPlayerOwner(base.gun));
				component.Owner = (GameActor)(object)GunTools.GunPlayerOwner(base.gun);
				component.Shooter = ((BraveBehaviour)GunTools.GunPlayerOwner(base.gun)).specRigidbody;
				GunTools.GunPlayerOwner(base.gun).DoPostProcessProjectile(component);
				ProjectileData baseData = component.baseData;
				baseData.speed *= Random.Range(1f, 0.8f);
			}
		}
	}
}
