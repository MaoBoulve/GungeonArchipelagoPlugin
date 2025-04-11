using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class AgarGun : AdvancedGunBehavior
{
	public static int ID;

	public static void Add()
	{
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0372: Unknown result type (might be due to invalid IL or missing references)
		//IL_0402: Unknown result type (might be due to invalid IL or missing references)
		//IL_042e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0454: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Agar Gun", "agargun");
		Game.Items.Rename("outdated_gun_mods:agar_gun", "nn:agar_gun");
		((Component)val).gameObject.AddComponent<AgarGun>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Feeda Me");
		GunExt.SetLongDescription((PickupObject)(object)val, "An old historical remnant reinvigorated for bio warfare.\n\nThe final shot launches a hungry macrobacteria, who gobbles up agar to fuel its own destructive power.");
		val.SetGunSprites("agargun");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 0);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(33);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(33);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1.15f;
		val.DefaultModule.cooldownTime = 0.15f;
		val.DefaultModule.numberOfShotsInClip = 15;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(3f, 0.5f, 0f);
		val.SetBaseMaxAmmo(470);
		val.ammo = 470;
		val.gunClass = (GunClass)10;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		val2.baseData.damage = 5f;
		BounceProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<BounceProjModifier>(((Component)val2).gameObject);
		orAddComponent.numberOfBounces = 2;
		((Component)val2).gameObject.AddComponent<AgarGunSmallProj>();
		ref GameObject overrideMidairDeathVFX = ref val2.hitEffects.overrideMidairDeathVFX;
		PickupObject byId4 = PickupObjectDatabase.GetById(33);
		overrideMidairDeathVFX = ((Gun)((byId4 is Gun) ? byId4 : null)).DefaultModule.projectiles[0].hitEffects.overrideMidairDeathVFX;
		val2.hitEffects.alwaysUseMidair = true;
		ProjectileBuilders.AnimateProjectileBundle(val2, "AgarGunProjectile", Initialisation.ProjectileCollection, Initialisation.projectileAnimationCollection, "AgarGunProjectile", MiscTools.DupeList<IntVector2>(new IntVector2(12, 11), 4), MiscTools.DupeList(value: true, 4), MiscTools.DupeList<Anchor>((Anchor)4, 4), MiscTools.DupeList(value: true, 4), MiscTools.DupeList(value: false, 4), MiscTools.DupeList<Vector3?>(null, 4), MiscTools.DupeList<IntVector2?>(null, 4), MiscTools.DupeList<IntVector2?>(null, 4), MiscTools.DupeList<Projectile>(null, 4));
		PickupObject byId5 = PickupObjectDatabase.GetById(56);
		Projectile val3 = Object.Instantiate<Projectile>(((Gun)((byId5 is Gun) ? byId5 : null)).DefaultModule.projectiles[0]);
		((Component)val3).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val3).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val3);
		val3.baseData.damage = 10f;
		ProjectileData baseData = val3.baseData;
		baseData.speed *= 0.7f;
		ProjectileData baseData2 = val3.baseData;
		baseData2.range *= 2f;
		((Component)val3).gameObject.AddComponent<PierceProjModifier>();
		ref GameObject overrideMidairDeathVFX2 = ref val3.hitEffects.overrideMidairDeathVFX;
		PickupObject byId6 = PickupObjectDatabase.GetById(755);
		overrideMidairDeathVFX2 = ((Gun)((byId6 is Gun) ? byId6 : null)).DefaultModule.projectiles[0].hitEffects.overrideMidairDeathVFX;
		val3.hitEffects.alwaysUseMidair = true;
		((Component)val3).gameObject.AddComponent<AgarGunBigProj>();
		ProjectileBuilders.AnimateProjectileBundle(val3, "AgarGunAgarProjectile", Initialisation.ProjectileCollection, Initialisation.projectileAnimationCollection, "AgarGunAgarProjectile", MiscTools.DupeList<IntVector2>(new IntVector2(17, 12), 4), MiscTools.DupeList(value: true, 4), MiscTools.DupeList<Anchor>((Anchor)4, 4), MiscTools.DupeList(value: true, 4), MiscTools.DupeList(value: false, 4), MiscTools.DupeList<Vector3?>(null, 4), MiscTools.DupeList<IntVector2?>(null, 4), MiscTools.DupeList<IntVector2?>(null, 4), MiscTools.DupeList<Projectile>(null, 4));
		val.DefaultModule.finalProjectile = val3;
		val.DefaultModule.usesOptionalFinalProjectile = true;
		val.DefaultModule.numberOfFinalProjectiles = 1;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Agar Gun Ammo", "NevernamedsItems/Resources/CustomGunAmmoTypes/agargun_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/agargun_clipempty");
		val.DefaultModule.finalAmmoType = (AmmoType)14;
		val.DefaultModule.finalCustomAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Agar Gun Glob", "NevernamedsItems/Resources/CustomGunAmmoTypes/agargun_final_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/agargun_final_clipempty");
		((PickupObject)val).quality = (ItemQuality)2;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)0, 1f);
		ID = ((PickupObject)val).PickupObjectId;
	}
}
