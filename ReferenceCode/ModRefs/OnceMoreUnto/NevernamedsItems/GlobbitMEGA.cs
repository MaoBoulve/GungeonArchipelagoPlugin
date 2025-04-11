using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class GlobbitMEGA : AdvancedGunBehavior
{
	public static int GlobbitLargeID;

	public static void Add()
	{
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0203: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Globbit", "globbitlarge");
		Game.Items.Rename("outdated_gun_mods:globbit", "nn:globbit");
		((Component)val).gameObject.AddComponent<GlobbitMEGA>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Oh!");
		GunExt.SetLongDescription((PickupObject)(object)val, "Shrinks slowly as it's ammo depletes.\n\nA former Blobulonian soldier, genetically modified beyond the point of sapience until only a gun remained.");
		GunExt.SetupSprite(val, (tk2dSpriteCollectionData)null, "globbitlarge_idle_001", 8);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(404);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		GunExt.SetAnimationFPS(val, val.shootAnimation, 10);
		PickupObject byId2 = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1.1f;
		val.DefaultModule.cooldownTime = 0.5f;
		val.DefaultModule.numberOfShotsInClip = 3;
		val.SetBaseMaxAmmo(250);
		((PickupObject)val).quality = (ItemQuality)(-100);
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 3f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.speed *= 0.5f;
		val2.pierceMinorBreakables = true;
		ProjectileData baseData3 = val2.baseData;
		baseData3.range *= 2f;
		GoopModifier val3 = ((Component)val2).gameObject.AddComponent<GoopModifier>();
		val3.goopDefinition = EasyGoopDefinitions.BlobulonGoopDef;
		val3.SpawnGoopInFlight = true;
		val3.InFlightSpawnFrequency = 0.05f;
		val3.InFlightSpawnRadius = 1f;
		val3.SpawnGoopOnCollision = true;
		val3.CollisionSpawnRadius = 2f;
		((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.93f, 1.12f, 0f);
		AmmoBasedFormeChanger ammoBasedFormeChanger = ((Component)val).gameObject.AddComponent<AmmoBasedFormeChanger>();
		ammoBasedFormeChanger.baseGunID = ((PickupObject)val).PickupObjectId;
		ammoBasedFormeChanger.lowerAmmoGunID = GlobbitMED.GlobbitMediumID;
		ammoBasedFormeChanger.lowerAmmoAmount = 200;
		ammoBasedFormeChanger.lowestAmmoGunID = GlobbitSMALL.GlobbitSmallID;
		ammoBasedFormeChanger.lowestAmmoAmount = 100;
		GlobbitLargeID = ((PickupObject)val).PickupObjectId;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
	}
}
