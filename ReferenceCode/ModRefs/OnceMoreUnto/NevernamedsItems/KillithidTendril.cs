using System.Collections.Generic;
using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class KillithidTendril : AdvancedGunBehavior
{
	public static Projectile subProjectile;

	public static int KillithidTendrilID;

	public static void Add()
	{
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_0335: Unknown result type (might be due to invalid IL or missing references)
		//IL_0345: Unknown result type (might be due to invalid IL or missing references)
		//IL_0355: Unknown result type (might be due to invalid IL or missing references)
		//IL_0365: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_040e: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Killithid Tendril", "killithidtendril");
		Game.Items.Rename("outdated_gun_mods:killithid_tendril", "nn:killithid_tendril");
		KillithidTendril killithidTendril = ((Component)val).gameObject.AddComponent<KillithidTendril>();
		((AdvancedGunBehavior)killithidTendril).preventNormalFireAudio = true;
		((AdvancedGunBehavior)killithidTendril).preventNormalReloadAudio = true;
		((AdvancedGunBehavior)killithidTendril).overrideNormalFireAudio = "Play_ENM_squidface_cast_01";
		((AdvancedGunBehavior)killithidTendril).overrideNormalReloadAudio = "Play_ENM_squidface_chant_01";
		GunExt.SetShortDescription((PickupObject)(object)val, "Wiggle Wiggle");
		GunExt.SetLongDescription((PickupObject)(object)val, "A tadpole of the Killithid species, capable of opening up portals to it's home dimension.\n\nWhile currently dormant, one day it will become active and burrow into the head of a sapient humanoid, eat their brain, and turn them into another Killithid.");
		val.SetGunSprites("killithidtendril");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 10);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(35);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)1;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 0.4f;
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		val.DefaultModule.numberOfShotsInClip = 200;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(0.93f, 0.56f, 0f);
		val.SetBaseMaxAmmo(200);
		val.ammo = 200;
		val.gunClass = (GunClass)50;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val2.baseData.damage = 8f;
		GunTools.SetProjectileSpriteRight(val2, "enemystyleproj", 10, 10, true, (Anchor)4, (int?)8, (int?)8, true, false, (int?)null, (int?)null, (Projectile)null);
		subProjectile = val2;
		Projectile val3 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val3).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val3).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val3);
		val3.baseData.damage = 15f;
		val3.baseData.speed = 0f;
		RandomRoomPosBehaviour randomRoomPosBehaviour = ((Component)val3).gameObject.AddComponent<RandomRoomPosBehaviour>();
		BulletLifeTimer bulletLifeTimer = ((Component)val3).gameObject.AddComponent<BulletLifeTimer>();
		bulletLifeTimer.secondsTillDeath = 15f;
		PierceProjModifier val4 = ((Component)val3).gameObject.AddComponent<PierceProjModifier>();
		val4.penetration = 100;
		val4.penetratesBreakables = true;
		SpawnProjModifier val5 = ((Component)val3).gameObject.AddComponent<SpawnProjModifier>();
		val5.InFlightSourceTransform = ((BraveBehaviour)val3).transform;
		val5.projectileToSpawnInFlight = subProjectile;
		val5.PostprocessSpawnedProjectiles = true;
		val5.spawnProjectilesInFlight = true;
		val5.spawnProjecitlesOnDieInAir = false;
		val5.spawnOnObjectCollisions = false;
		val5.inFlightAimAtEnemies = true;
		val5.usesComplexSpawnInFlight = true;
		val5.numToSpawnInFlight = 1;
		val5.inFlightSpawnCooldown = 1f;
		ProjectileData baseData = val3.baseData;
		baseData.force *= 1.2f;
		val3.hitEffects.alwaysUseMidair = true;
		val3.hitEffects.overrideMidairDeathVFX = SharedVFX.YellowLaserCircleVFX;
		ProjectileBuilders.AnimateProjectileBundle(val3, "KillithidTendrilProjectile", Initialisation.ProjectileCollection, Initialisation.projectileAnimationCollection, "KillithidTendrilProjectile", new List<IntVector2>
		{
			new IntVector2(16, 16),
			new IntVector2(20, 20),
			new IntVector2(24, 24),
			new IntVector2(20, 20)
		}, MiscTools.DupeList(value: true, 4), MiscTools.DupeList<Anchor>((Anchor)4, 4), MiscTools.DupeList(value: true, 4), MiscTools.DupeList(value: false, 4), MiscTools.DupeList<Vector3?>(null, 4), MiscTools.DupeList((IntVector2?)new IntVector2(16, 16), 4), MiscTools.DupeList<IntVector2?>(null, 4), MiscTools.DupeList<Projectile>(null, 4));
		val.DefaultModule.projectiles[0] = val3;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("KillithidTendril Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/killithidtendril_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/killithidtendril_clipempty");
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		KillithidTendrilID = ((PickupObject)val).PickupObjectId;
	}
}
