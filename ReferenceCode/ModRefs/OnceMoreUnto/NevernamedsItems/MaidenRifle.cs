using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class MaidenRifle : AdvancedGunBehavior
{
	public static int MaidenRifleID;

	public static void Add()
	{
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Maiden Rifle", "maidenrifle");
		Game.Items.Rename("outdated_gun_mods:maiden_rifle", "nn:maiden_rifle");
		((Component)val).gameObject.AddComponent<MaidenRifle>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Lady Death");
		GunExt.SetLongDescription((PickupObject)(object)val, "Reverse engineered Lead Maiden technology.\n\nOriginally, the projectiles would rotate when in walls, but this was removed for efficiency, and definitely not because quaternions and vectors are more painful than tapdancing on an echidna.");
		val.SetGunSprites("maidenrifle");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 17);
		PickupObject byId = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 2f;
		val.DefaultModule.cooldownTime = 0.15f;
		val.DefaultModule.numberOfShotsInClip = 30;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.68f, 0.62f, 0f);
		val.SetBaseMaxAmmo(400);
		val.ammo = 400;
		val.gunClass = (GunClass)10;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 1.6f;
		val2.pierceMinorBreakables = true;
		val2.SetProjectileSprite("friendlymaiden_projectile", 25, 12, lightened: true, (Anchor)4, 6, 8, anchorChangesCollider: true, fixesScale: false, null, null);
		LeadMaidenProjectileReAiming orAddComponent = GameObjectExtensions.GetOrAddComponent<LeadMaidenProjectileReAiming>(((Component)val2).gameObject);
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("MaidenRifle Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/maidenrifle_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/maidenrifle_clipempty");
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		MaidenRifleID = ((PickupObject)val).PickupObjectId;
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)2, 1f);
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		GameActor owner = projectile.Owner;
		PlayerController val = (PlayerController)(object)((owner is PlayerController) ? owner : null);
		if ((Object)(object)val != (Object)null && CustomSynergies.PlayerHasActiveSynergy(val, "Double Maiden"))
		{
			ProjectileData baseData = projectile.baseData;
			baseData.range *= 2f;
			ProjectileData baseData2 = projectile.baseData;
			baseData2.damage *= 1.2f;
			PierceProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<PierceProjModifier>(((Component)projectile).gameObject);
			orAddComponent.penetratesBreakables = true;
			orAddComponent.penetration = 2;
		}
		((AdvancedGunBehavior)this).PostProcessProjectile(projectile);
	}
}
