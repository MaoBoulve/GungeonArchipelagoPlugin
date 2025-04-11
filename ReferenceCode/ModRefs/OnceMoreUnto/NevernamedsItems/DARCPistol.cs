using System.Collections.Generic;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class DARCPistol : GunBehaviour
{
	public static int ID;

	public static void Add()
	{
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0267: Unknown result type (might be due to invalid IL or missing references)
		//IL_0276: Unknown result type (might be due to invalid IL or missing references)
		//IL_0307: Unknown result type (might be due to invalid IL or missing references)
		//IL_032e: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("DARC Pistol", "darcpistol");
		Game.Items.Rename("outdated_gun_mods:darc_pistol", "nn:arc_pistol+darc_pistol");
		((Component)val).gameObject.AddComponent<DARCPistol>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Shocked And Loaded");
		GunExt.SetLongDescription((PickupObject)(object)val, "Developed by the ARC Private Security company for easy manufacture and deployment, this electrotech blaster is the epittome of the ARC brand.");
		val.SetGunSprites("darcpistol", 8, noAmmonomicon: true);
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
		val.DefaultModule.cooldownTime = 0.135f;
		val.DefaultModule.numberOfShotsInClip = 7;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.375f, 0.6875f, 0f);
		val.SetBaseMaxAmmo(300);
		val.gunClass = (GunClass)1;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		ProjectileData baseData = val2.baseData;
		baseData.speed *= 5f;
		val2.baseData.damage = 7.2f;
		val2.SetProjectileSprite("darc_proj", 8, 2, lightened: false, (Anchor)4, 8, 2, anchorChangesCollider: true, fixesScale: false, null, null);
		LightningProjectileComp orAddComponent = GameObjectExtensions.GetOrAddComponent<LightningProjectileComp>(((Component)val2).gameObject);
		orAddComponent.targetEnemies = true;
		orAddComponent.arcBetweenEnemiesRange = 6f;
		((Component)val2).gameObject.AddComponent<PierceDeadActors>();
		((Component)val2).gameObject.AddComponent<MaintainDamageOnPierce>();
		val2.hitEffects.overrideMidairDeathVFX = SharedVFX.ArcImpactRed;
		val2.hitEffects.alwaysUseMidair = true;
		List<string> list = new List<string> { "NevernamedsItems/Resources/TrailSprites/darctrail_mid_001", "NevernamedsItems/Resources/TrailSprites/darctrail_mid_002", "NevernamedsItems/Resources/TrailSprites/darctrail_mid_003" };
		TrailAPI.AddTrailToProjectile(val2, "NevernamedsItems/Resources/TrailSprites/darctrail_mid_001", new Vector2(3f, 2f), new Vector2(1f, 1f), list, 20, list, 20, -1f, 0.0001f, -1f, true, true);
		EmmisiveTrail orAddComponent2 = GameObjectExtensions.GetOrAddComponent<EmmisiveTrail>(((Component)val2).gameObject);
		PickupObject byId4 = PickupObjectDatabase.GetById(519);
		CombineEvaporateEffect component = ((Component)((Gun)((byId4 is Gun) ? byId4 : null)).alternateVolley.projectiles[0].projectiles[0]).GetComponent<CombineEvaporateEffect>();
		CombineEvaporateEffect val3 = ((Component)val2).gameObject.AddComponent<CombineEvaporateEffect>();
		val3.FallbackShader = component.FallbackShader;
		val3.ParticleSystemToSpawn = component.ParticleSystemToSpawn;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("DARC Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/darcweapon_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/darcweapon_clipempty");
		((PickupObject)val).quality = (ItemQuality)(-100);
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
	}
}
