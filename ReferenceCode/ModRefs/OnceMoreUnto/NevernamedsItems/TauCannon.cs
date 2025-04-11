using System;
using System.Collections.Generic;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class TauCannon : AdvancedGunBehavior
{
	private float timeChargine = 0f;

	public static int TauCannonID;

	public static void Add()
	{
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Unknown result type (might be due to invalid IL or missing references)
		//IL_0290: Unknown result type (might be due to invalid IL or missing references)
		//IL_0295: Unknown result type (might be due to invalid IL or missing references)
		//IL_029b: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0382: Unknown result type (might be due to invalid IL or missing references)
		//IL_0387: Unknown result type (might be due to invalid IL or missing references)
		//IL_038c: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0501: Unknown result type (might be due to invalid IL or missing references)
		//IL_0506: Unknown result type (might be due to invalid IL or missing references)
		//IL_050d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0518: Unknown result type (might be due to invalid IL or missing references)
		//IL_0521: Expected O, but got Unknown
		//IL_0521: Unknown result type (might be due to invalid IL or missing references)
		//IL_0526: Unknown result type (might be due to invalid IL or missing references)
		//IL_052d: Unknown result type (might be due to invalid IL or missing references)
		//IL_053a: Expected O, but got Unknown
		//IL_053a: Unknown result type (might be due to invalid IL or missing references)
		//IL_053f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0547: Unknown result type (might be due to invalid IL or missing references)
		//IL_0554: Expected O, but got Unknown
		//IL_0587: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ad: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Tau Cannon", "taucannon");
		Game.Items.Rename("outdated_gun_mods:tau_cannon", "nn:tau_cannon");
		((Component)val).gameObject.AddComponent<TauCannon>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Questionable Ethics");
		GunExt.SetLongDescription((PickupObject)(object)val, "An ingenious way devised by scientists in the field of materials handling to dispose of spent uranium.\n\nWill violently overcharge if powered up for too long.");
		val.SetGunSprites("taucannon");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 15);
		GunExt.SetAnimationFPS(val, val.chargeAnimation, 6);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(593);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.chargeAnimation).wrapMode = (WrapMode)1;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.chargeAnimation).loopStart = 12;
		val.doesScreenShake = true;
		ref ScreenShakeSettings gunScreenShake = ref val.gunScreenShake;
		PickupObject byId3 = PickupObjectDatabase.GetById(37);
		gunScreenShake = ((Gun)((byId3 is Gun) ? byId3 : null)).gunScreenShake;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)3;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId4 = PickupObjectDatabase.GetById(5);
		muzzleFlashEffects = ((Gun)((byId4 is Gun) ? byId4 : null)).muzzleFlashEffects;
		val.DefaultModule.angleVariance = 2f;
		val.DefaultModule.cooldownTime = 0.2f;
		val.DefaultModule.numberOfShotsInClip = -1;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(3.18f, 0.75f, 0f);
		val.SetBaseMaxAmmo(100);
		val.ammo = 100;
		val.gunClass = (GunClass)60;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val2.baseData.damage = 15f;
		val2.baseData.speed = 50f;
		val2.hitEffects.alwaysUseMidair = true;
		val2.hitEffects.overrideMidairDeathVFX = SharedVFX.YellowLaserCircleVFX;
		GunTools.SetProjectileSpriteRight(val2, "tau_projectile1", 4, 2, false, (Anchor)4, (int?)4, (int?)2, true, false, (int?)null, (int?)null, (Projectile)null);
		EasyTrailBullet easyTrailBullet = ((Component)val2).gameObject.AddComponent<EasyTrailBullet>();
		easyTrailBullet.TrailPos = Vector2.op_Implicit(((BraveBehaviour)val2).transform.position);
		easyTrailBullet.StartWidth = 0.12f;
		easyTrailBullet.EndWidth = 0.12f;
		easyTrailBullet.LifeTime = 100f;
		easyTrailBullet.BaseColor = ExtendedColours.honeyYellow;
		easyTrailBullet.EndColor = ExtendedColours.honeyYellow;
		PickupObject byId5 = PickupObjectDatabase.GetById(56);
		Projectile val3 = Object.Instantiate<Projectile>(((Gun)((byId5 is Gun) ? byId5 : null)).DefaultModule.projectiles[0]);
		((Component)val3).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val3).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val3);
		val3.baseData.speed = 50f;
		val3.baseData.damage = 25f;
		ProjectileData baseData = val3.baseData;
		baseData.force *= 2f;
		val3.hitEffects.alwaysUseMidair = true;
		val3.hitEffects.overrideMidairDeathVFX = SharedVFX.YellowLaserCircleVFX;
		GunTools.SetProjectileSpriteRight(val3, "tau_projectile2", 4, 2, false, (Anchor)4, (int?)4, (int?)2, true, false, (int?)null, (int?)null, (Projectile)null);
		EasyTrailBullet easyTrailBullet2 = ((Component)val3).gameObject.AddComponent<EasyTrailBullet>();
		easyTrailBullet2.TrailPos = Vector2.op_Implicit(((BraveBehaviour)val3).transform.position);
		easyTrailBullet2.StartWidth = 0.12f;
		easyTrailBullet2.EndWidth = 0.12f;
		easyTrailBullet2.LifeTime = 100f;
		easyTrailBullet2.BaseColor = ExtendedColours.paleYellow;
		easyTrailBullet2.EndColor = ExtendedColours.paleYellow;
		PickupObject byId6 = PickupObjectDatabase.GetById(56);
		Projectile val4 = Object.Instantiate<Projectile>(((Gun)((byId6 is Gun) ? byId6 : null)).DefaultModule.projectiles[0]);
		((Component)val4).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val4).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val4);
		val4.baseData.speed = 50f;
		ProjectileData baseData2 = val4.baseData;
		baseData2.force *= 10f;
		val4.baseData.damage = 50f;
		val4.hitEffects.alwaysUseMidair = true;
		val4.hitEffects.overrideMidairDeathVFX = SharedVFX.YellowLaserCircleVFX;
		GunTools.SetProjectileSpriteRight(val4, "tau_projectile3", 4, 2, false, (Anchor)4, (int?)4, (int?)2, true, false, (int?)null, (int?)null, (Projectile)null);
		EasyTrailBullet easyTrailBullet3 = ((Component)val4).gameObject.AddComponent<EasyTrailBullet>();
		easyTrailBullet3.TrailPos = Vector2.op_Implicit(((BraveBehaviour)val4).transform.position);
		easyTrailBullet3.StartWidth = 0.12f;
		easyTrailBullet3.EndWidth = 0.12f;
		easyTrailBullet3.LifeTime = 100f;
		easyTrailBullet3.BaseColor = Color.white;
		easyTrailBullet3.EndColor = Color.white;
		ChargeProjectile item = new ChargeProjectile
		{
			Projectile = val2,
			ChargeTime = 0f,
			VfxPool = null
		};
		ChargeProjectile item2 = new ChargeProjectile
		{
			Projectile = val3,
			ChargeTime = 1f
		};
		ChargeProjectile item3 = new ChargeProjectile
		{
			Projectile = val4,
			ChargeTime = 2f
		};
		val.DefaultModule.chargeProjectiles = new List<ChargeProjectile> { item, item2, item3 };
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("TauCannon Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/taucannon_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/taucannon_clipempty");
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		TauCannonID = ((PickupObject)val).PickupObjectId;
	}

	protected override void Update()
	{
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)base.gun) && base.gun.IsCharging)
		{
			timeChargine += BraveTime.DeltaTime;
		}
		if (timeChargine > 5f)
		{
			Exploder.Explode(Vector2.op_Implicit(((BraveBehaviour)base.gun).sprite.WorldCenter), StaticExplosionDatas.explosiveRoundsExplosion, Vector2.zero, (Action)null, false, (CoreDamageTypes)0, false);
			timeChargine = 0f;
		}
		if (!base.gun.IsCharging && timeChargine > 0f)
		{
			timeChargine = 0f;
		}
		((AdvancedGunBehavior)this).Update();
	}
}
