using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Alexandria.VisualAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Pallbearer : AdvancedGunBehavior
{
	public static int ID;

	public static void Add()
	{
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0301: Unknown result type (might be due to invalid IL or missing references)
		//IL_039e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0414: Unknown result type (might be due to invalid IL or missing references)
		//IL_041b: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Pallbearer", "pallbearer");
		Game.Items.Rename("outdated_gun_mods:pallbearer", "nn:pallbearer");
		Pallbearer pallbearer = ((Component)val).gameObject.AddComponent<Pallbearer>();
		GunExt.SetShortDescription((PickupObject)(object)val, "One In The Chamber");
		GunExt.SetLongDescription((PickupObject)(object)val, "An ornate coffin pulled from the deepest crypts of the Gungeon's Hollow catacombs.\n\nThe spirits inside are broiling with rage.");
		val.SetGunSprites("pallbearer", 8, noAmmonomicon: false, 2);
		GunExt.SetAnimationFPS(val, val.shootAnimation, 13);
		GunExt.SetAnimationFPS(val, val.idleAnimation, 5);
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.reloadAnimation).wrapMode = (WrapMode)0;
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(45);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		val.muzzleFlashEffects = SharedVFX.DoomBoomMuzzle;
		for (int i = 0; i < 3; i++)
		{
			PickupObject byId2 = PickupObjectDatabase.GetById(86);
			GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		}
		int num = 1;
		foreach (ProjectileModule projectile in val.Volley.projectiles)
		{
			projectile.ammoCost = 1;
			projectile.shootStyle = (ShootStyle)0;
			projectile.sequenceStyle = (ProjectileSequenceStyle)0;
			projectile.cooldownTime = 1f;
			projectile.angleVariance = 17f;
			projectile.numberOfShotsInClip = 2;
			Projectile val2 = ProjectileUtility.SetupProjectile(86);
			projectile.projectiles[0] = val2;
			SlowDownOverTimeModifier slowDownOverTimeModifier = ((Component)val2).gameObject.AddComponent<SlowDownOverTimeModifier>();
			slowDownOverTimeModifier.timeToSlowOver = 0.5f;
			slowDownOverTimeModifier.doRandomTimeMultiplier = true;
			slowDownOverTimeModifier.extendTimeByRangeStat = true;
			slowDownOverTimeModifier.killAfterCompleteStop = true;
			slowDownOverTimeModifier.targetSpeed = 0.1f;
			slowDownOverTimeModifier.timeTillKillAfterCompleteStop = 0.25f * (float)num;
			ProjectileBuilders.AnimateProjectileBundle(val2, "PallbearerProj", Initialisation.ProjectileCollection, Initialisation.projectileAnimationCollection, "PallbearerProj", MiscTools.DupeList<IntVector2>(new IntVector2(13, 13), 3), MiscTools.DupeList(value: true, 3), MiscTools.DupeList<Anchor>((Anchor)4, 3), MiscTools.DupeList(value: true, 3), MiscTools.DupeList(value: false, 3), MiscTools.DupeList<Vector3?>(null, 3), MiscTools.DupeList<IntVector2?>(null, 3), MiscTools.DupeList<IntVector2?>(null, 3), MiscTools.DupeList<Projectile>(null, 3));
			SpawnProjModifier val3 = ((Component)val2).gameObject.AddComponent<SpawnProjModifier>();
			val3.spawnProjecitlesOnDieInAir = true;
			val3.spawnProjectilesInFlight = false;
			val3.spawnProjectilesOnCollision = true;
			val3.spawnOnObjectCollisions = true;
			val3.spawnCollisionProjectilesOnBounce = true;
			Projectile val4 = ProjectileUtility.SetupProjectile(56);
			val4.baseData.damage = 10f;
			val4.SetProjectileSprite("pallbearer_ghost", 17, 11, lightened: true, (Anchor)4, 15, 9, anchorChangesCollider: true, fixesScale: false, null, null);
			HomingModifier val5 = ((Component)val4).gameObject.AddComponent<HomingModifier>();
			val5.HomingRadius = 100f;
			val5.HomingRadius = 600f;
			ImprovedAfterImage val6 = ((Component)val4).gameObject.AddComponent<ImprovedAfterImage>();
			val6.spawnShadows = true;
			val6.shadowLifetime = 0.1f;
			val6.shadowTimeDelay = 0.01f;
			val6.dashColor = Color.white;
			((Object)val6).name = "Gun Trail";
			val6.maxEmission = 10f;
			val4.pierceMinorBreakables = true;
			ExplosiveModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<ExplosiveModifier>(((Component)val4).gameObject);
			orAddComponent.doExplosion = true;
			orAddComponent.explosionData = StaticExplosionDatas.explosiveRoundsExplosion.CopyExplosionData();
			orAddComponent.explosionData.damageRadius = 2f;
			orAddComponent.explosionData.damage = 15f;
			orAddComponent.explosionData.effect = SharedVFX.KillDevilExplosion;
			orAddComponent.explosionData.pushRadius = 0.2f;
			val3.projectileToSpawnOnCollision = val4;
			val3.collisionSpawnStyle = (CollisionSpawnStyle)1;
			val3.PostprocessSpawnedProjectiles = true;
			val3.numberToSpawnOnCollison = 1;
			if (projectile != val.DefaultModule)
			{
				projectile.ammoCost = 0;
			}
			num++;
		}
		val.reloadTime = 1.8f;
		val.SetBarrel(32, 15);
		val.SetBaseMaxAmmo(30);
		val.gunClass = (GunClass)45;
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		val.Volley.UsesShotgunStyleVelocityRandomizer = true;
		val.AddClipSprites("smallghost");
		ID = ((PickupObject)val).PickupObjectId;
	}
}
