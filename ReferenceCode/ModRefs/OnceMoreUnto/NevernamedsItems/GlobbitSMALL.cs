using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class GlobbitSMALL : AdvancedGunBehavior
{
	public static int GlobbitSmallID;

	public static void Add()
	{
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("GlobbitSmall", "globbitsmall");
		Game.Items.Rename("outdated_gun_mods:globbitsmall", "nn:globbit_small_forme");
		((Component)val).gameObject.AddComponent<GlobbitSMALL>();
		GunExt.SetShortDescription((PickupObject)(object)val, "no");
		GunExt.SetLongDescription((PickupObject)(object)val, "life is suffering");
		GunExt.SetupSprite(val, (tk2dSpriteCollectionData)null, "globbitsmall_idle_001", 8);
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
		val.DefaultModule.cooldownTime = 0.1f;
		val.DefaultModule.numberOfShotsInClip = 9;
		val.SetBaseMaxAmmo(250);
		((PickupObject)val).quality = (ItemQuality)(-100);
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 0.8f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.speed *= 1f;
		ProjectileData baseData3 = val2.baseData;
		baseData3.range *= 2f;
		GoopModifier val3 = ((Component)val2).gameObject.AddComponent<GoopModifier>();
		val3.goopDefinition = EasyGoopDefinitions.BlobulonGoopDef;
		val3.SpawnGoopInFlight = true;
		val3.InFlightSpawnFrequency = 0.05f;
		val3.InFlightSpawnRadius = 0.5f;
		val3.SpawnGoopOnCollision = true;
		val3.CollisionSpawnRadius = 1f;
		GunTools.SetProjectileSpriteRight(val2, "globbitsmall_projectile", 4, 4, false, (Anchor)4, (int?)3, (int?)3, true, false, (int?)null, (int?)null, (Projectile)null);
		((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(0.93f, 0.75f, 0f);
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		GlobbitSmallID = ((PickupObject)val).PickupObjectId;
	}
}
