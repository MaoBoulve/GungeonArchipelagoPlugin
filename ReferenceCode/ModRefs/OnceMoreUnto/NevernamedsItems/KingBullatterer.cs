using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class KingBullatterer : AdvancedGunBehavior
{
	public static int KingBullattererID;

	public static void Add()
	{
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_02df: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_06aa: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("King Bullatterer", "kingbullatterer");
		Game.Items.Rename("outdated_gun_mods:king_bullatterer", "nn:bullatterer+king_bullatterer");
		((Component)val).gameObject.AddComponent<Bullatterer>();
		GunExt.SetShortDescription((PickupObject)(object)val, "djahksdhkssdfdfssdf");
		GunExt.SetLongDescription((PickupObject)(object)val, "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
		val.SetGunSprites("kingbullatterer", 8, noAmmonomicon: true);
		GunExt.SetAnimationFPS(val, val.shootAnimation, 13);
		GunExt.SetAnimationFPS(val, val.idleAnimation, 13);
		for (int i = 0; i < 13; i++)
		{
			PickupObject byId = PickupObjectDatabase.GetById(86);
			GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		}
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		val.reloadTime = 1.5f;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.25f, 0.43f, 0f);
		val.SetBaseMaxAmmo(400);
		val.ammo = 400;
		PickupObject byId2 = PickupObjectDatabase.GetById(86);
		Projectile val2 = Object.Instantiate<Projectile>(((Gun)((byId2 is Gun) ? byId2 : null)).DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 1.2f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.speed *= 0.65f;
		GunTools.SetProjectileSpriteRight(val2, "yellow_enemystyle_projectile", 10, 10, true, (Anchor)4, (int?)8, (int?)8, true, false, (int?)null, (int?)null, (Projectile)null);
		BounceProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<BounceProjModifier>(((Component)val2).gameObject);
		orAddComponent.numberOfBounces = 1;
		PickupObject byId3 = PickupObjectDatabase.GetById(86);
		Projectile val3 = Object.Instantiate<Projectile>(((Gun)((byId3 is Gun) ? byId3 : null)).DefaultModule.projectiles[0]);
		((Component)val3).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val3).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val3);
		ProjectileData baseData3 = val3.baseData;
		baseData3.damage *= 0f;
		((BraveBehaviour)((BraveBehaviour)val3).sprite).renderer.enabled = false;
		val3.pierceMinorBreakables = true;
		SpawnEnemyOnBulletSpawn orAddComponent2 = GameObjectExtensions.GetOrAddComponent<SpawnEnemyOnBulletSpawn>(((Component)val3).gameObject);
		orAddComponent2.companioniseEnemy = true;
		orAddComponent2.deleteProjAfterSpawn = true;
		orAddComponent2.enemyBulletDamage = 15f;
		orAddComponent2.guidToSpawn = EnemyGuidDatabase.Entries["bullat"];
		orAddComponent2.ignoreSpawnedEnemyForGoodMimic = true;
		orAddComponent2.killSpawnedEnemyOnRoomClear = true;
		orAddComponent2.procChance = 1f;
		orAddComponent2.scaleEnemyDamage = true;
		orAddComponent2.scaleEnemyProjSize = true;
		orAddComponent2.scaleEnemyProjSpeed = true;
		orAddComponent2.doPostProcessOnEnemyBullets = false;
		int num = 0;
		foreach (ProjectileModule projectile in val.Volley.projectiles)
		{
			projectile.numberOfShotsInClip = 15;
			projectile.cooldownTime = 0.55f;
			projectile.sequenceStyle = (ProjectileSequenceStyle)0;
			projectile.shootStyle = (ShootStyle)1;
			if (num <= 0)
			{
				projectile.ammoCost = 1;
				projectile.angleVariance = 0.01f;
				projectile.angleFromAim = 0f;
				projectile.projectiles[0] = val3;
				num++;
			}
			else if (num == 1)
			{
				projectile.ammoCost = 0;
				projectile.angleVariance = 7f;
				projectile.angleFromAim = 0f;
				projectile.projectiles[0] = val2;
				num++;
			}
			else if (num == 2)
			{
				projectile.ammoCost = 0;
				projectile.angleVariance = 7f;
				projectile.angleFromAim = 30f;
				projectile.projectiles[0] = val2;
				num++;
			}
			else if (num == 3)
			{
				projectile.ammoCost = 0;
				projectile.angleVariance = 7f;
				projectile.angleFromAim = 60f;
				projectile.projectiles[0] = val2;
				num++;
			}
			else if (num == 4)
			{
				projectile.ammoCost = 0;
				projectile.angleVariance = 7f;
				projectile.angleFromAim = 90f;
				projectile.projectiles[0] = val2;
				num++;
			}
			else if (num == 5)
			{
				projectile.ammoCost = 0;
				projectile.angleVariance = 7f;
				projectile.angleFromAim = 120f;
				projectile.projectiles[0] = val2;
				num++;
			}
			else if (num == 6)
			{
				projectile.ammoCost = 0;
				projectile.angleVariance = 7f;
				projectile.angleFromAim = 150f;
				projectile.projectiles[0] = val2;
				num++;
			}
			else if (num == 7)
			{
				projectile.ammoCost = 0;
				projectile.angleVariance = 7f;
				projectile.angleFromAim = 180f;
				projectile.projectiles[0] = val2;
				num++;
			}
			else if (num == 8)
			{
				projectile.ammoCost = 0;
				projectile.angleVariance = 7f;
				projectile.angleFromAim = -30f;
				projectile.projectiles[0] = val2;
				num++;
			}
			else if (num == 9)
			{
				projectile.ammoCost = 0;
				projectile.angleVariance = 7f;
				projectile.angleFromAim = -60f;
				projectile.projectiles[0] = val2;
				num++;
			}
			else if (num == 10)
			{
				projectile.ammoCost = 0;
				projectile.angleVariance = 7f;
				projectile.angleFromAim = -90f;
				projectile.projectiles[0] = val2;
				num++;
			}
			else if (num == 11)
			{
				projectile.ammoCost = 0;
				projectile.angleVariance = 7f;
				projectile.angleFromAim = -120f;
				projectile.projectiles[0] = val2;
				num++;
			}
			else if (num >= 12)
			{
				projectile.ammoCost = 0;
				projectile.angleVariance = 7f;
				projectile.angleFromAim = -150f;
				projectile.projectiles[0] = val2;
				num++;
			}
		}
		((PickupObject)val).quality = (ItemQuality)(-100);
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		GunExt.SetName((PickupObject)(object)val, "Bullatterer");
		KingBullattererID = ((PickupObject)val).PickupObjectId;
	}
}
