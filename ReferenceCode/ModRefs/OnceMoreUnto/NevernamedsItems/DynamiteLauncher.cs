using System.Collections.Generic;
using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Gungeon;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class DynamiteLauncher : AdvancedGunBehavior
{
	public static int DynamiteLauncherID;

	public static void Add()
	{
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_021c: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_023c: Unknown result type (might be due to invalid IL or missing references)
		//IL_024c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02de: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Dynamite Launcher", "dynamitelauncher");
		Game.Items.Rename("outdated_gun_mods:dynamite_launcher", "nn:dynamite_launcher");
		((Component)val).gameObject.AddComponent<DynamiteLauncher>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Dynamight makes Dynaright");
		GunExt.SetLongDescription((PickupObject)(object)val, "Fires a potent stick of nitroglycerin.\n\nCreated by mad Nitra Gunsmith, before he realised that he didn't have hands.");
		val.SetGunSprites("dynamitelauncher");
		val.outOfAmmoAnimation = "empty";
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 1);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(150);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 2f;
		val.DefaultModule.cooldownTime = 1f;
		val.DefaultModule.numberOfShotsInClip = 1;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.56f, 0.62f, 0f);
		val.SetBaseMaxAmmo(40);
		val.gunClass = (GunClass)45;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 6f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.speed *= 0.4f;
		ProjectileData baseData3 = val2.baseData;
		baseData3.range *= 1f;
		BounceProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<BounceProjModifier>(((Component)val2).gameObject);
		orAddComponent.numberOfBounces = 1;
		ExplosiveModifier orAddComponent2 = GameObjectExtensions.GetOrAddComponent<ExplosiveModifier>(((Component)val2).gameObject);
		orAddComponent2.doExplosion = true;
		orAddComponent2.explosionData = StaticExplosionDatas.customDynamiteExplosion;
		val2.pierceMinorBreakables = true;
		ProjectileBuilders.AnimateProjectileBundle(val2, "DynamiteLauncherProj", Initialisation.ProjectileCollection, Initialisation.projectileAnimationCollection, "DynamiteLauncherProj", new List<IntVector2>
		{
			new IntVector2(14, 15),
			new IntVector2(15, 14),
			new IntVector2(14, 15),
			new IntVector2(15, 14)
		}, AnimateBullet.ConstructListOfSameValues(value: false, 4), AnimateBullet.ConstructListOfSameValues<Anchor>((Anchor)4, 4), AnimateBullet.ConstructListOfSameValues(value: true, 4), AnimateBullet.ConstructListOfSameValues(value: false, 4), AnimateBullet.ConstructListOfSameValues<Vector3?>(null, 4), AnimateBullet.ConstructListOfSameValues<IntVector2?>(null, 4), AnimateBullet.ConstructListOfSameValues<IntVector2?>(null, 4), AnimateBullet.ConstructListOfSameValues<Projectile>(null, 4));
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Dynamite Launcher Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/dynamitelauncher_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/dynamitelauncher_clipempty");
		((PickupObject)val).quality = (ItemQuality)4;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		DynamiteLauncherID = ((PickupObject)val).PickupObjectId;
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)3, 1f);
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.NITRA_QUEST_REWARDED, requiredFlagValue: true);
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		GameActor owner = projectile.Owner;
		PlayerController val = (PlayerController)(object)((owner is PlayerController) ? owner : null);
		if ((Object)(object)val != (Object)null && CustomSynergies.PlayerHasActiveSynergy(val, "Nobel Effort"))
		{
			SpawnEnemyOnBulletSpawn orAddComponent = GameObjectExtensions.GetOrAddComponent<SpawnEnemyOnBulletSpawn>(((Component)projectile).gameObject);
			orAddComponent.companioniseEnemy = true;
			orAddComponent.deleteProjAfterSpawn = false;
			orAddComponent.enemyBulletDamage = 30f;
			orAddComponent.knockbackAmountAwayFromOwner = 40f;
			orAddComponent.guidToSpawn = EnemyGuidDatabase.Entries["dynamite_kin"];
			orAddComponent.ignoreSpawnedEnemyForGoodMimic = true;
			orAddComponent.killSpawnedEnemyOnRoomClear = true;
			orAddComponent.procChance = 1f;
			orAddComponent.scaleEnemyDamage = true;
			orAddComponent.scaleEnemyProjSize = true;
			orAddComponent.scaleEnemyProjSpeed = true;
			orAddComponent.doPostProcessOnEnemyBullets = false;
			((AdvancedGunBehavior)this).PostProcessProjectile(projectile);
		}
	}
}
