using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class HeavyAssaultRifle : GunBehaviour
{
	public static int HeavyAssaultRifleID;

	public static void Add()
	{
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_022a: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Heavy Assault Rifle", "heavyassaultrifle");
		Game.Items.Rename("outdated_gun_mods:heavy_assault_rifle", "nn:heavy_assault_rifle");
		((Component)val).gameObject.AddComponent<HeavyAssaultRifle>();
		GunExt.SetShortDescription((PickupObject)(object)val, "It's so big...");
		GunExt.SetLongDescription((PickupObject)(object)val, "An oversized assault rifle from the FUTURE... which by now has already become the past.");
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(81);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		val.SetGunSprites("heavyassaultrifle");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 15);
		PickupObject byId2 = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 2.5f;
		val.DefaultModule.cooldownTime = 0.11f;
		val.DefaultModule.numberOfShotsInClip = 40;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(4.18f, 0.87f, 0f);
		val.SetBaseMaxAmmo(250);
		val.gunClass = (GunClass)10;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 6f;
		val2.SetProjectileSprite("heavyassaultrifle_projectile", 22, 7, lightened: false, (Anchor)4, 22, 7, anchorChangesCollider: true, fixesScale: false, null, null);
		((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		PierceProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<PierceProjModifier>(((Component)val2).gameObject);
		orAddComponent.penetratesBreakables = true;
		orAddComponent.penetration = 5;
		ItemBuilder.AddCurrentGunStatModifier(val, (StatType)0, 0.8f, (ModifyMethod)1);
		ItemBuilder.AddCurrentGunStatModifier(val, (StatType)28, 0.8f, (ModifyMethod)1);
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("HeavyAssaultRifle Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/heavyassaultrifle_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/heavyassaultrifle_clipempty");
		val.DefaultModule.projectiles[0] = val2;
		((PickupObject)val).quality = (ItemQuality)5;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		HeavyAssaultRifleID = ((PickupObject)val).PickupObjectId;
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)3, 1f);
	}
}
