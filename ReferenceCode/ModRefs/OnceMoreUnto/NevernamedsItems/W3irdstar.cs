using System.Collections.Generic;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class W3irdstar : AdvancedGunBehavior
{
	public static int W3irdstarID;

	public static void Add()
	{
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_0361: Unknown result type (might be due to invalid IL or missing references)
		//IL_0366: Unknown result type (might be due to invalid IL or missing references)
		//IL_036d: Unknown result type (might be due to invalid IL or missing references)
		//IL_037a: Expected O, but got Unknown
		//IL_039b: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c1: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("W3irdstar", "w3irdstar");
		Game.Items.Rename("outdated_gun_mods:w3irdstar", "nn:w3irdstar");
		W3irdstar w3irdstar = ((Component)val).gameObject.AddComponent<W3irdstar>();
		((AdvancedGunBehavior)w3irdstar).overrideNormalFireAudio = "Play_WPN_seriouscannon_shot_01";
		((AdvancedGunBehavior)w3irdstar).preventNormalFireAudio = true;
		GunExt.SetShortDescription((PickupObject)(object)val, "Weird Champion");
		GunExt.SetLongDescription((PickupObject)(object)val, "This wiggly weapon proves that we are all made of... star... squooge.");
		val.SetGunSprites("w3irdstar");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 10);
		GunExt.SetAnimationFPS(val, val.idleAnimation, 10);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 1);
		GunExt.SetAnimationFPS(val, val.chargeAnimation, 6);
		PickupObject byId = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.chargeAnimation).wrapMode = (WrapMode)1;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.chargeAnimation).loopStart = 2;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)3;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 0.45f;
		val.DefaultModule.angleVariance = 0f;
		val.DefaultModule.numberOfShotsInClip = 2;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.1875f, 0.75f, 0f);
		val.SetBaseMaxAmmo(80);
		val.ammo = 80;
		val.gunClass = (GunClass)50;
		Projectile value = ProjectileUtility.SetupProjectile(56);
		val.DefaultModule.projectiles[0] = value;
		ImprovedHelixProjectile val2 = DataCloners.CopyFields<ImprovedHelixProjectile>(Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]));
		val2.SpawnShadowBulletsOnSpawn = false;
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		((Projectile)val2).baseData.damage = 20f;
		ProjectileData baseData = ((Projectile)val2).baseData;
		baseData.force *= 2f;
		ProjectileData baseData2 = ((Projectile)val2).baseData;
		baseData2.speed *= 0.5f;
		((Projectile)val2).baseData.range = 12f;
		((Projectile)val2).hitEffects.overrideMidairDeathVFX = SharedVFX.W3irdstarImpact;
		((Projectile)val2).hitEffects.alwaysUseMidair = true;
		((Projectile)(object)val2).SetProjectileSprite("w3irdstar_largeproj", 20, 20, lightened: true, (Anchor)4, 10, 10, anchorChangesCollider: true, fixesScale: false, null, null);
		EvenRadialBurstHandler evenRadialBurstHandler = ((Component)val2).gameObject.AddComponent<EvenRadialBurstHandler>();
		evenRadialBurstHandler.numberToSpawn = 40;
		evenRadialBurstHandler.PostProcess = false;
		Projectile sample = ProjectileUtility.SetupProjectile(56);
		ImprovedHelixProjectile val3 = DataCloners.CopyFields<ImprovedHelixProjectile>(sample);
		val3.SpawnShadowBulletsOnSpawn = false;
		((Component)val3).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val3).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val3);
		((Projectile)val3).baseData.damage = 5f;
		((Projectile)val3).baseData.range = 20f;
		((Projectile)val3).hitEffects.overrideMidairDeathVFX = SharedVFX.W3irdstarImpact;
		((Projectile)val3).hitEffects.alwaysUseMidair = true;
		((Projectile)(object)val3).SetProjectileSprite("w3irdstar_smallproj", 12, 12, lightened: true, (Anchor)4, 6, 6, anchorChangesCollider: true, fixesScale: false, null, null);
		evenRadialBurstHandler.projectileToSpawn = (Projectile)(object)val3;
		ChargeProjectile item = new ChargeProjectile
		{
			Projectile = (Projectile)(object)val2,
			ChargeTime = 0.5f
		};
		val.DefaultModule.chargeProjectiles = new List<ChargeProjectile> { item };
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("W3irdstar Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/w3irdstar_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/w3irdstar_clipempty");
		((PickupObject)val).quality = (ItemQuality)4;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		W3irdstarID = ((PickupObject)val).PickupObjectId;
	}
}
