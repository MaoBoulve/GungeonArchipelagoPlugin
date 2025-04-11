using System.Collections.Generic;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class TitanSlayer : AdvancedGunBehavior
{
	public static int ID;

	public static void Add()
	{
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02df: Expected O, but got Unknown
		//IL_0300: Unknown result type (might be due to invalid IL or missing references)
		//IL_0326: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Titan Slayer", "titanslayer");
		Game.Items.Rename("outdated_gun_mods:titan_slayer", "nn:titan_slayer");
		TitanSlayer titanSlayer = ((Component)val).gameObject.AddComponent<TitanSlayer>();
		GunExt.SetShortDescription((PickupObject)(object)val, "A High Toll Indeed");
		GunExt.SetLongDescription((PickupObject)(object)val, "An elegant bow crafted to kill Titans on a distant world.\n\nDespite it's masterful craftsmanship, it seems its true power lies with its single, magic arrow...");
		val.SetGunSprites("titanslayer");
		PickupObject byId = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(8);
		gunSwitchGroup = ((Gun)((byId2 is Gun) ? byId2 : null)).gunSwitchGroup;
		val.DefaultModule.ammoCost = 1;
		val.doesScreenShake = true;
		val.DefaultModule.shootStyle = (ShootStyle)3;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 3f;
		val.DefaultModule.cooldownTime = 1f;
		val.DefaultModule.angleVariance = 0f;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(8);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		val.DefaultModule.numberOfShotsInClip = 1;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.1875f, 0.9375f, 0f);
		val.SetBaseMaxAmmo(100);
		val.ammo = 100;
		val.gunClass = (GunClass)60;
		GunExt.SetAnimationFPS(val, val.chargeAnimation, 16);
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.chargeAnimation).wrapMode = (WrapMode)1;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.chargeAnimation).loopStart = 5;
		val.carryPixelOffset = new IntVector2(15, 0);
		val.carryPixelUpOffset = new IntVector2(0, 8);
		val.carryPixelDownOffset = new IntVector2(0, -8);
		Projectile val2 = ProjectileUtility.InstantiateAndFakeprefab(val.DefaultModule.projectiles[0]);
		val2.SetProjectileSprite("titanslayer_proj", 21, 7, lightened: false, (Anchor)4, 17, 3, anchorChangesCollider: true, fixesScale: false, null, null);
		ProjectileData baseData = val2.baseData;
		baseData.speed *= 2f;
		val2.baseData.range = float.MaxValue;
		val2.baseData.damage = 33f;
		val2.BossDamageMultiplier = 1.4f;
		val2.pierceMinorBreakables = true;
		NoCollideBehaviour noCollideBehaviour = ((Component)val2).gameObject.AddComponent<NoCollideBehaviour>();
		noCollideBehaviour.worksOnEnemies = false;
		noCollideBehaviour.worksOnProjectiles = false;
		ref VFXPool enemy = ref val2.hitEffects.enemy;
		PickupObject byId4 = PickupObjectDatabase.GetById(535);
		enemy = ((Gun)((byId4 is Gun) ? byId4 : null)).DefaultModule.chargeProjectiles[0].Projectile.hitEffects.enemy;
		BounceProjModifier val3 = ((Component)val2).gameObject.AddComponent<BounceProjModifier>();
		val3.numberOfBounces = 100;
		((Component)val2).gameObject.AddComponent<TitanSlayerArrow>();
		PierceProjModifier val4 = ((Component)val2).gameObject.AddComponent<PierceProjModifier>();
		val4.penetration = 100;
		ChargeProjectile item = new ChargeProjectile
		{
			Projectile = val2,
			ChargeTime = 0.5f
		};
		val.DefaultModule.chargeProjectiles = new List<ChargeProjectile> { item };
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Titan Slayer Arrow", "NevernamedsItems/Resources/CustomGunAmmoTypes/titanslayer_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/titanslayer_clipempty");
		((PickupObject)val).quality = (ItemQuality)4;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		AlexandriaTags.SetTag((PickupObject)(object)val, "arrow_bolt_weapon");
		ID = ((PickupObject)val).PickupObjectId;
	}
}
