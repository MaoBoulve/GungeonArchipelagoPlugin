using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class GlobbitMED : AdvancedGunBehavior
{
	public static int GlobbitMediumID;

	public static void Add()
	{
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_022d: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("GlobbitMedium", "globbitmed");
		Game.Items.Rename("outdated_gun_mods:globbitmedium", "nn:globbit_medium_forme");
		((Component)val).gameObject.AddComponent<GlobbitMED>();
		GunExt.SetShortDescription((PickupObject)(object)val, "no");
		GunExt.SetLongDescription((PickupObject)(object)val, "no");
		GunExt.SetupSprite(val, (tk2dSpriteCollectionData)null, "globbitmed_idle_001", 8);
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
		val.DefaultModule.cooldownTime = 0.3f;
		val.DefaultModule.numberOfShotsInClip = 6;
		val.SetBaseMaxAmmo(250);
		((PickupObject)val).quality = (ItemQuality)(-100);
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 1.6f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.speed *= 0.8f;
		ProjectileData baseData3 = val2.baseData;
		baseData3.range *= 2f;
		GoopModifier val3 = ((Component)val2).gameObject.AddComponent<GoopModifier>();
		val3.goopDefinition = EasyGoopDefinitions.BlobulonGoopDef;
		val3.SpawnGoopInFlight = true;
		val3.InFlightSpawnFrequency = 0.05f;
		val3.InFlightSpawnRadius = 0.5f;
		val3.SpawnGoopOnCollision = true;
		val3.CollisionSpawnRadius = 1f;
		GunTools.SetProjectileSpriteRight(val2, "globbitmed_projectile", 7, 7, false, (Anchor)4, (int?)6, (int?)6, true, false, (int?)null, (int?)null, (Projectile)null);
		((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.31f, 0.81f, 0f);
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		GlobbitMediumID = ((PickupObject)val).PickupObjectId;
	}
}
