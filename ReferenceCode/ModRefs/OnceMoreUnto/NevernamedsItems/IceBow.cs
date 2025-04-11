using System.Collections.Generic;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class IceBow : AdvancedGunBehavior
{
	public static int IceBowID;

	public static void Add()
	{
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0266: Unknown result type (might be due to invalid IL or missing references)
		//IL_0273: Expected O, but got Unknown
		//IL_0294: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ba: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Ice Bow", "icebow");
		Game.Items.Rename("outdated_gun_mods:ice_bow", "nn:ice_bow");
		IceBow iceBow = ((Component)val).gameObject.AddComponent<IceBow>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Arctery");
		GunExt.SetLongDescription((PickupObject)(object)val, "Freezes enemies.\n\nFerried to the Gungeon from a remote island on the edge of civilisation.");
		val.SetGunSprites("icebow");
		PickupObject byId = PickupObjectDatabase.GetById(12);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		GunExt.SetAnimationFPS(val, val.chargeAnimation, 3);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(8);
		gunSwitchGroup = ((Gun)((byId2 is Gun) ? byId2 : null)).gunSwitchGroup;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)3;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 1f;
		val.DefaultModule.angleVariance = 0f;
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		val.DefaultModule.numberOfShotsInClip = 1;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(0.81f, 0.81f, 0f);
		val.SetBaseMaxAmmo(100);
		val.ammo = 100;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.chargeAnimation).wrapMode = (WrapMode)1;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.chargeAnimation).loopStart = 2;
		val.carryPixelOffset = new IntVector2(10, 0);
		val.gunClass = (GunClass)35;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val2.baseData.damage = 17f;
		val2.baseData.speed = 35f;
		ProjectileData baseData = val2.baseData;
		baseData.range *= 2f;
		val2.AppliesFreeze = true;
		val2.FreezeApplyChance = 1f;
		val2.freezeEffect = StaticStatusEffects.chaosBulletsFreeze;
		PierceProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<PierceProjModifier>(((Component)val2).gameObject);
		orAddComponent.penetration++;
		orAddComponent.penetratesBreakables = true;
		val2.SetProjectileSprite("icebow_projectile", 15, 5, lightened: true, (Anchor)4, 14, 4, anchorChangesCollider: true, fixesScale: false, null, null);
		ChargeProjectile item = new ChargeProjectile
		{
			Projectile = val2,
			ChargeTime = 1f
		};
		val.DefaultModule.chargeProjectiles = new List<ChargeProjectile> { item };
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Ice Bow Arrows", "NevernamedsItems/Resources/CustomGunAmmoTypes/icebow_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/icebow_clipempty");
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		AlexandriaTags.SetTag((PickupObject)(object)val, "arrow_bolt_weapon");
		IceBowID = ((PickupObject)val).PickupObjectId;
	}
}
