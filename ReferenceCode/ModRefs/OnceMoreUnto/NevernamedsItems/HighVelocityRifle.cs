using System.Collections.Generic;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class HighVelocityRifle : AdvancedGunBehavior
{
	public static int HighVelocityRifleID;

	private bool TimeIsFrozen = false;

	public static void Add()
	{
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_022a: Expected O, but got Unknown
		//IL_024b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0262: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("High Velocity Rifle", "highvelocityrifle");
		Game.Items.Rename("outdated_gun_mods:high_velocity_rifle", "nn:high_velocity_rifle");
		HighVelocityRifle highVelocityRifle = ((Component)val).gameObject.AddComponent<HighVelocityRifle>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Tracked");
		GunExt.SetLongDescription((PickupObject)(object)val, "Advanced tech designed for private security contractors on the fringes of space.\n\nHolding down fire allows the operator to enter 'aim time'.");
		val.SetGunSprites("highvelocityrifle");
		PickupObject byId = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)3;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 1f;
		val.DefaultModule.angleVariance = 0f;
		val.DefaultModule.numberOfShotsInClip = 1;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.87f, 0.31f, 0f);
		val.SetBaseMaxAmmo(80);
		val.ammo = 80;
		val.gunClass = (GunClass)15;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 8f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.force *= 3f;
		ProjectileData baseData3 = val2.baseData;
		baseData3.speed *= 6f;
		ProjectileData baseData4 = val2.baseData;
		baseData4.range *= 2f;
		PierceProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<PierceProjModifier>(((Component)val2).gameObject);
		orAddComponent.penetration++;
		orAddComponent.penetratesBreakables = true;
		val2.hitEffects.overrideMidairDeathVFX = SharedVFX.SmoothLightBlueLaserCircleVFX;
		val2.hitEffects.alwaysUseMidair = true;
		GunTools.SetProjectileSpriteRight(val2, "highvelocityrifle_projectile", 13, 5, true, (Anchor)4, (int?)11, (int?)4, true, false, (int?)null, (int?)null, (Projectile)null);
		ChargeProjectile item = new ChargeProjectile
		{
			Projectile = val2,
			ChargeTime = 0f
		};
		val.DefaultModule.chargeProjectiles = new List<ChargeProjectile> { item };
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = "Toolgun Bullets";
		((PickupObject)val).quality = (ItemQuality)4;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		HighVelocityRifleID = ((PickupObject)val).PickupObjectId;
	}

	public override void OnSwitchedAwayFromThisGun()
	{
		if (TimeIsFrozen)
		{
			BraveTime.ClearMultiplier(((Component)this).gameObject);
			TimeIsFrozen = false;
		}
		((AdvancedGunBehavior)this).OnSwitchedAwayFromThisGun();
	}

	protected override void Update()
	{
		if (Object.op_Implicit((Object)(object)base.gun.CurrentOwner) && base.gun.CurrentOwner is PlayerController)
		{
			GameActor currentOwner = base.gun.CurrentOwner;
			PlayerController val = (PlayerController)(object)((currentOwner is PlayerController) ? currentOwner : null);
			if (val.IsDodgeRolling && TimeIsFrozen)
			{
				BraveTime.ClearMultiplier(((Component)this).gameObject);
				TimeIsFrozen = false;
			}
			if (base.gun.IsCharging)
			{
				if (!TimeIsFrozen && !val.IsDodgeRolling)
				{
					BraveTime.SetTimeScaleMultiplier(0.01f, ((Component)this).gameObject);
					TimeIsFrozen = true;
				}
			}
			else if (TimeIsFrozen)
			{
				BraveTime.ClearMultiplier(((Component)this).gameObject);
				TimeIsFrozen = false;
			}
		}
		((AdvancedGunBehavior)this).Update();
	}
}
