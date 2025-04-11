using System.Collections.Generic;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class BulletBladeGhostForme : AdvancedGunBehavior
{
	public static int GhostBladeID;

	public static Projectile BurstShot;

	public static void Add()
	{
		//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0287: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fd: Expected O, but got Unknown
		//IL_035a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0362: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0540: Unknown result type (might be due to invalid IL or missing references)
		//IL_047c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0481: Unknown result type (might be due to invalid IL or missing references)
		//IL_0489: Unknown result type (might be due to invalid IL or missing references)
		//IL_0496: Expected O, but got Unknown
		Gun val = Databases.Items.NewGun("Ghost Blade", "ghostblade");
		Game.Items.Rename("outdated_gun_mods:ghost_blade", "nn:bullet_blade+ghost_sword");
		BulletBladeGhostForme bulletBladeGhostForme = ((Component)val).gameObject.AddComponent<BulletBladeGhostForme>();
		((AdvancedGunBehavior)bulletBladeGhostForme).preventNormalFireAudio = true;
		((AdvancedGunBehavior)bulletBladeGhostForme).preventNormalReloadAudio = true;
		GunExt.SetShortDescription((PickupObject)(object)val, "Forged of Pure Bullet");
		GunExt.SetLongDescription((PickupObject)(object)val, "The hefty blade of the fearsome armoured sentinels that tread the Gungeon's Halls.\n\nHas claimed the life of many a careless gungeoneer with it's wide spread.");
		val.SetGunSprites("ghostblade", 8, noAmmonomicon: true);
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		GunExt.SetAnimationFPS(val, val.chargeAnimation, 6);
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).frames[0].eventAudio = "Play_ENM_gunnut_shockwave_01";
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).frames[0].triggerEvent = true;
		PickupObject byId = PickupObjectDatabase.GetById(86);
		BurstShot = Object.Instantiate<Projectile>(((Gun)((byId is Gun) ? byId : null)).DefaultModule.projectiles[0]);
		((Component)BurstShot).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)BurstShot).gameObject);
		Object.DontDestroyOnLoad((Object)(object)BurstShot);
		ProjectileData baseData = BurstShot.baseData;
		baseData.damage *= 1.6f;
		ProjectileData baseData2 = BurstShot.baseData;
		baseData2.speed *= 0.8f;
		GunTools.SetProjectileSpriteRight(BurstShot, "green_enemystyle_projectile", 10, 10, true, (Anchor)4, (int?)8, (int?)8, true, false, (int?)null, (int?)null, (Projectile)null);
		for (int i = 0; i < 46; i++)
		{
			PickupObject byId2 = PickupObjectDatabase.GetById(86);
			GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		}
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.angleVariance = 1f;
		val.DefaultModule.cooldownTime = 2.5f;
		val.DefaultModule.shootStyle = (ShootStyle)3;
		val.DefaultModule.numberOfShotsInClip = 1;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		val.DefaultModule.projectiles[0] = val2;
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		ProjectileData baseData3 = val2.baseData;
		baseData3.damage *= 4f;
		SpawnProjModifier val3 = ((Component)val2).gameObject.AddComponent<SpawnProjModifier>();
		val3.spawnProjectilesInFlight = false;
		val3.spawnProjectilesOnCollision = true;
		val3.spawnProjecitlesOnDieInAir = true;
		val3.spawnOnObjectCollisions = true;
		val3.collisionSpawnStyle = (CollisionSpawnStyle)0;
		val3.numberToSpawnOnCollison = 30;
		val3.randomRadialStartAngle = true;
		val3.PostprocessSpawnedProjectiles = true;
		val3.projectileToSpawnOnCollision = BurstShot;
		GunTools.SetProjectileSpriteRight(val2, "large_green_enemystyle_projectile", 18, 18, true, (Anchor)4, (int?)16, (int?)16, true, false, (int?)null, (int?)null, (Projectile)null);
		ChargeProjectile item = new ChargeProjectile
		{
			Projectile = val2,
			ChargeTime = 1f
		};
		val.DefaultModule.chargeProjectiles = new List<ChargeProjectile> { item };
		foreach (ProjectileModule projectile in val.Volley.projectiles)
		{
			if (projectile != val.DefaultModule)
			{
				projectile.ammoCost = 1;
				projectile.shootStyle = (ShootStyle)3;
				projectile.sequenceStyle = (ProjectileSequenceStyle)0;
				projectile.cooldownTime = 2.5f;
				projectile.angleVariance = 70f;
				projectile.numberOfShotsInClip = 1;
				Projectile val4 = Object.Instantiate<Projectile>(projectile.projectiles[0]);
				projectile.projectiles[0] = val4;
				((Component)val4).gameObject.SetActive(false);
				FakePrefab.MarkAsFakePrefab(((Component)val4).gameObject);
				Object.DontDestroyOnLoad((Object)(object)val4);
				ProjectileData baseData4 = val4.baseData;
				baseData4.damage *= 1.6f;
				ProjectileData baseData5 = val4.baseData;
				baseData5.speed *= 0.6f;
				ProjectileData baseData6 = val4.baseData;
				baseData6.range *= 1f;
				GunTools.SetProjectileSpriteRight(val4, "green_enemystyle_projectile", 10, 10, true, (Anchor)4, (int?)8, (int?)8, true, false, (int?)null, (int?)null, (Projectile)null);
				if (projectile != val.DefaultModule)
				{
					projectile.ammoCost = 0;
				}
				((BraveBehaviour)val4).transform.parent = val.barrelOffset;
				ChargeProjectile item2 = new ChargeProjectile
				{
					Projectile = val4,
					ChargeTime = 1f
				};
				projectile.chargeProjectiles = new List<ChargeProjectile> { item2 };
			}
		}
		val.reloadTime = 1f;
		val.SetBaseMaxAmmo(50);
		((PickupObject)val).quality = (ItemQuality)(-100);
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.chargeAnimation).wrapMode = (WrapMode)1;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.chargeAnimation).loopStart = 4;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		((Component)val.barrelOffset).transform.localPosition = new Vector3(3.18f, 2f, 0f);
		GhostBladeID = ((PickupObject)val).PickupObjectId;
		GunExt.SetName((PickupObject)(object)val, "Bullet Blade");
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		((AdvancedGunBehavior)this).PostProcessProjectile(projectile);
	}
}
