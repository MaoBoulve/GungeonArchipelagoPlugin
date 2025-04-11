using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class RC360 : AdvancedGunBehavior
{
	public static int RC360ID;

	public static void Add()
	{
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0274: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("RC-360", "rc360");
		Game.Items.Rename("outdated_gun_mods:rc360", "nn:rc_360");
		((Component)val).gameObject.AddComponent<RC360>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Sentry Gun");
		GunExt.SetLongDescription((PickupObject)(object)val, "The final bullet in the clip of this strange gun is actually an entirely self-contained sentry-robot.");
		val.SetGunSprites("rc360");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 15);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 30);
		PickupObject byId = PickupObjectDatabase.GetById(80);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 0.5f;
		val.DefaultModule.angleVariance = 10f;
		val.DefaultModule.cooldownTime = 0.1f;
		val.DefaultModule.numberOfShotsInClip = 20;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.18f, 0.93f, 0f);
		val.SetBaseMaxAmmo(500);
		val.gunClass = (GunClass)10;
		val.DefaultModule.usesOptionalFinalProjectile = true;
		val.DefaultModule.numberOfFinalProjectiles = 1;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val2.baseData.damage = 4.5f;
		val.DefaultModule.projectiles[0] = val2;
		PickupObject byId2 = PickupObjectDatabase.GetById(86);
		Projectile val3 = Object.Instantiate<Projectile>(((Gun)((byId2 is Gun) ? byId2 : null)).DefaultModule.projectiles[0]);
		((Component)val3).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val3).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val3);
		ProjectileData baseData = val3.baseData;
		baseData.speed *= 0.1f;
		val3.baseData.damage = 25f;
		val3.SetProjectileSprite("goopyproj_001", 16, 16, lightened: true, (Anchor)4, 14, 14, anchorChangesCollider: true, fixesScale: false, null, null);
		val3.hitEffects.alwaysUseMidair = true;
		val3.hitEffects.overrideMidairDeathVFX = SharedVFX.YellowLaserCircleVFX;
		((Component)val3).gameObject.AddComponent<RC360TurretShot>();
		val3.pierceMinorBreakables = true;
		val.DefaultModule.finalProjectile = val3;
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		RC360ID = ((PickupObject)val).PickupObjectId;
	}
}
