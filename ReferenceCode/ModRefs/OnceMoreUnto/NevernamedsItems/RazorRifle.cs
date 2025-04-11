using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class RazorRifle : AdvancedGunBehavior
{
	public static int ID;

	public static void Add()
	{
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_0241: Unknown result type (might be due to invalid IL or missing references)
		//IL_0267: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Razor Rifle", "razorrifle");
		Game.Items.Rename("outdated_gun_mods:razor_rifle", "nn:razor_rifle");
		((Component)val).gameObject.AddComponent<RazorRifle>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Close Shave");
		GunExt.SetLongDescription((PickupObject)(object)val, "One of the last products from Cut-Abuv(TM) Kitchenware and Personal Hygiene, before the company devolved into bankruptcy and legal litigation.");
		val.SetGunSprites("razorrifle");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 17);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 0);
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(12);
		gunSwitchGroup = ((Gun)((byId2 is Gun) ? byId2 : null)).gunSwitchGroup;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(169);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 0.7f;
		val.DefaultModule.cooldownTime = 0.5f;
		val.DefaultModule.numberOfShotsInClip = 10;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.6875f, 0.625f, 0f);
		val.SetBaseMaxAmmo(200);
		val.ammo = 200;
		val.gunClass = (GunClass)10;
		Projectile val2 = ProjectileUtility.InstantiateAndFakeprefab(val.DefaultModule.projectiles[0]);
		val.DefaultModule.projectiles[0] = val2;
		val2.baseData.damage = 7f;
		PierceProjModifier val3 = ((Component)val2).gameObject.AddComponent<PierceProjModifier>();
		val3.penetration++;
		ProjectileBuilders.AnimateProjectileBundle(val2, "RazorRifleProjectile", Initialisation.ProjectileCollection, Initialisation.projectileAnimationCollection, "RazorRifleProjectile", MiscTools.DupeList<IntVector2>(new IntVector2(10, 12), 4), MiscTools.DupeList(value: true, 4), MiscTools.DupeList<Anchor>((Anchor)4, 4), MiscTools.DupeList(value: true, 4), MiscTools.DupeList(value: false, 4), MiscTools.DupeList<Vector3?>(null, 4), MiscTools.DupeList<IntVector2?>(null, 4), MiscTools.DupeList<IntVector2?>(null, 4), MiscTools.DupeList<Projectile>(null, 4));
		InherentExsanguinationEffect inherentExsanguinationEffect = ((Component)val2).gameObject.AddComponent<InherentExsanguinationEffect>();
		inherentExsanguinationEffect.duration = 10f;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("RazorRifle Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/razorrifle_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/razorrifle_clipempty");
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
	}
}
