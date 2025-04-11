using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Bullatterer : AdvancedGunBehavior
{
	public static int BullattererID;

	public static void Add()
	{
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_0214: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Bullatterer", "bullatterer");
		Game.Items.Rename("outdated_gun_mods:bullatterer", "nn:bullatterer");
		((Component)val).gameObject.AddComponent<Bullatterer>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Fly, my pretties!");
		GunExt.SetLongDescription((PickupObject)(object)val, "Releases angry Bullats to fight for you.\n\nCreated by an ancient vampire in order to fight the most intimidating monster of all... his own loneliness.");
		val.SetGunSprites("bullatterer");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 13);
		PickupObject byId = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1.5f;
		val.DefaultModule.cooldownTime = 0.35f;
		val.DefaultModule.numberOfShotsInClip = 30;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.75f, 1.12f, 0f);
		val.SetBaseMaxAmmo(400);
		val.ammo = 400;
		val.gunClass = (GunClass)40;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 0f;
		((BraveBehaviour)((BraveBehaviour)val2).sprite).renderer.enabled = false;
		val2.pierceMinorBreakables = true;
		SpawnEnemyOnBulletSpawn orAddComponent = GameObjectExtensions.GetOrAddComponent<SpawnEnemyOnBulletSpawn>(((Component)val2).gameObject);
		orAddComponent.companioniseEnemy = true;
		orAddComponent.deleteProjAfterSpawn = true;
		orAddComponent.enemyBulletDamage = 15f;
		orAddComponent.guidToSpawn = EnemyGuidDatabase.Entries["bullat"];
		orAddComponent.ignoreSpawnedEnemyForGoodMimic = true;
		orAddComponent.killSpawnedEnemyOnRoomClear = true;
		orAddComponent.procChance = 1f;
		orAddComponent.scaleEnemyDamage = true;
		orAddComponent.knockbackAmountAwayFromOwner = 20f;
		orAddComponent.scaleEnemyProjSize = true;
		orAddComponent.scaleEnemyProjSpeed = true;
		orAddComponent.doPostProcessOnEnemyBullets = false;
		((PickupObject)val).quality = (ItemQuality)2;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		BullattererID = ((PickupObject)val).PickupObjectId;
	}

	protected override void Update()
	{
		((AdvancedGunBehavior)this).Update();
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		GameActor owner = projectile.Owner;
		PlayerController val = (PlayerController)(object)((owner is PlayerController) ? owner : null);
		if ((Object)(object)val != (Object)null && Object.op_Implicit((Object)(object)((Component)projectile).gameObject.GetComponent<SpawnEnemyOnBulletSpawn>()))
		{
			int num = Random.Range(1, 5);
			if (num == 1 && CustomSynergies.PlayerHasActiveSynergy(val, "Shotgatterer"))
			{
				SpawnEnemyOnBulletSpawn orAddComponent = GameObjectExtensions.GetOrAddComponent<SpawnEnemyOnBulletSpawn>(((Component)projectile).gameObject);
				orAddComponent.companioniseEnemy = true;
				orAddComponent.deleteProjAfterSpawn = true;
				orAddComponent.enemyBulletDamage = 30f;
				orAddComponent.guidToSpawn = EnemyGuidDatabase.Entries["shotgat"];
				orAddComponent.ignoreSpawnedEnemyForGoodMimic = true;
				orAddComponent.killSpawnedEnemyOnRoomClear = true;
				orAddComponent.procChance = 1f;
				orAddComponent.scaleEnemyDamage = true;
				orAddComponent.scaleEnemyProjSize = true;
				orAddComponent.scaleEnemyProjSpeed = true;
				orAddComponent.doPostProcessOnEnemyBullets = false;
			}
			else if (num == 2 && CustomSynergies.PlayerHasActiveSynergy(val, "Grenatterer"))
			{
				SpawnEnemyOnBulletSpawn orAddComponent2 = GameObjectExtensions.GetOrAddComponent<SpawnEnemyOnBulletSpawn>(((Component)projectile).gameObject);
				orAddComponent2.companioniseEnemy = true;
				orAddComponent2.deleteProjAfterSpawn = true;
				orAddComponent2.enemyBulletDamage = 10f;
				orAddComponent2.guidToSpawn = EnemyGuidDatabase.Entries["grenat"];
				orAddComponent2.ignoreSpawnedEnemyForGoodMimic = true;
				orAddComponent2.killSpawnedEnemyOnRoomClear = true;
				orAddComponent2.procChance = 1f;
				orAddComponent2.scaleEnemyDamage = true;
				orAddComponent2.scaleEnemyProjSize = true;
				orAddComponent2.scaleEnemyProjSpeed = true;
				orAddComponent2.doPostProcessOnEnemyBullets = false;
			}
			else if (num == 3 && CustomSynergies.PlayerHasActiveSynergy(val, "Spiratterer"))
			{
				SpawnEnemyOnBulletSpawn orAddComponent3 = GameObjectExtensions.GetOrAddComponent<SpawnEnemyOnBulletSpawn>(((Component)projectile).gameObject);
				orAddComponent3.companioniseEnemy = true;
				orAddComponent3.deleteProjAfterSpawn = true;
				orAddComponent3.enemyBulletDamage = 10f;
				orAddComponent3.guidToSpawn = EnemyGuidDatabase.Entries["spirat"];
				orAddComponent3.ignoreSpawnedEnemyForGoodMimic = true;
				orAddComponent3.killSpawnedEnemyOnRoomClear = true;
				orAddComponent3.procChance = 1f;
				orAddComponent3.scaleEnemyDamage = true;
				orAddComponent3.scaleEnemyProjSize = true;
				orAddComponent3.scaleEnemyProjSpeed = true;
				orAddComponent3.doPostProcessOnEnemyBullets = false;
			}
		}
		((AdvancedGunBehavior)this).PostProcessProjectile(projectile);
	}
}
