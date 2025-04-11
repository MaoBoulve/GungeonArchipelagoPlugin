using System.Collections.Generic;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class ARCPistol : GunBehaviour
{
	public static int ID;

	public static void Add()
	{
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0225: Unknown result type (might be due to invalid IL or missing references)
		//IL_0234: Unknown result type (might be due to invalid IL or missing references)
		//IL_026b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0291: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("ARC Pistol", "arcpistol");
		Game.Items.Rename("outdated_gun_mods:arc_pistol", "nn:arc_pistol");
		((Component)val).gameObject.AddComponent<ARCPistol>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Shocked And Loaded");
		GunExt.SetLongDescription((PickupObject)(object)val, "Developed by the ARC Private Security company for easy manufacture and deployment, this electrotech blaster is the epittome of the ARC brand.");
		val.SetGunSprites("arcpistol");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 15);
		PickupObject byId = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(153);
		gunSwitchGroup = ((Gun)((byId2 is Gun) ? byId2 : null)).gunSwitchGroup;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(41);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 0.7f;
		val.DefaultModule.cooldownTime = 0.15f;
		val.DefaultModule.numberOfShotsInClip = 5;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.375f, 0.6875f, 0f);
		val.SetBaseMaxAmmo(300);
		val.gunClass = (GunClass)1;
		Projectile val2 = ProjectileSetupUtility.MakeProjectile(56, 6f);
		val.DefaultModule.projectiles[0] = val2;
		ProjectileData baseData = val2.baseData;
		baseData.speed *= 5f;
		val2.SetProjectileSprite("arc_proj", 8, 2, lightened: false, (Anchor)4, 8, 2, anchorChangesCollider: true, fixesScale: false, null, null);
		LightningProjectileComp orAddComponent = GameObjectExtensions.GetOrAddComponent<LightningProjectileComp>(((Component)val2).gameObject);
		orAddComponent.targetEnemies = true;
		((Component)val2).gameObject.AddComponent<PierceDeadActors>();
		val2.hitEffects.overrideMidairDeathVFX = SharedVFX.ArcImpact;
		val2.hitEffects.alwaysUseMidair = true;
		List<string> list = new List<string> { "NevernamedsItems/Resources/TrailSprites/arctrail_mid_001", "NevernamedsItems/Resources/TrailSprites/arctrail_mid_002", "NevernamedsItems/Resources/TrailSprites/arctrail_mid_003" };
		TrailAPI.AddTrailToProjectile(val2, "NevernamedsItems/Resources/TrailSprites/arctrail_mid_001", new Vector2(3f, 2f), new Vector2(1f, 1f), list, 20, list, 20, -1f, 0.0001f, -1f, true, true);
		EmmisiveTrail orAddComponent2 = GameObjectExtensions.GetOrAddComponent<EmmisiveTrail>(((Component)val2).gameObject);
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("ARC Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/arcweapon_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/arcweapon_clipempty");
		((PickupObject)val).quality = (ItemQuality)2;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
	}
}
