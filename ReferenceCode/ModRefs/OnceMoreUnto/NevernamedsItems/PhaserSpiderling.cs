using Alexandria.ItemAPI;
using Gungeon;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class PhaserSpiderling : AdvancedGunBehavior
{
	public static int PhaserSpiderlingID;

	public static void Add()
	{
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0266: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_051f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0526: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0306: Unknown result type (might be due to invalid IL or missing references)
		//IL_034e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0356: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03af: Unknown result type (might be due to invalid IL or missing references)
		//IL_0400: Unknown result type (might be due to invalid IL or missing references)
		//IL_0408: Unknown result type (might be due to invalid IL or missing references)
		//IL_0459: Unknown result type (might be due to invalid IL or missing references)
		//IL_0461: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Phaser Spiderling", "phaserspiderling");
		Game.Items.Rename("outdated_gun_mods:phaser_spiderling", "nn:phaser_spiderling");
		PhaserSpiderling phaserSpiderling = ((Component)val).gameObject.AddComponent<PhaserSpiderling>();
		((AdvancedGunBehavior)phaserSpiderling).preventNormalReloadAudio = true;
		((AdvancedGunBehavior)phaserSpiderling).overrideNormalReloadAudio = "Play_ENM_PhaseSpider_Weave_01";
		((AdvancedGunBehavior)phaserSpiderling).preventNormalFireAudio = true;
		((AdvancedGunBehavior)phaserSpiderling).overrideNormalFireAudio = "Play_ENM_PhaseSpider_Spray_01";
		GunExt.SetShortDescription((PickupObject)(object)val, "Arachnikov");
		GunExt.SetLongDescription((PickupObject)(object)val, "The hatchling spawn of a Phaser Spider.\n\nOne of the first organs to fully develop are the spinnerets.");
		val.SetGunSprites("phaserspiderling");
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(86);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		GunExt.SetAnimationFPS(val, val.shootAnimation, 15);
		GunExt.SetAnimationFPS(val, val.idleAnimation, 9);
		for (int i = 0; i < 7; i++)
		{
			PickupObject byId2 = PickupObjectDatabase.GetById(86);
			GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		}
		float cooldownTime = 0.1f;
		int numberOfShotsInClip = 500;
		float cooldownTime2 = 0.4f;
		int num = 0;
		foreach (ProjectileModule projectile in val.Volley.projectiles)
		{
			projectile.numberOfShotsInClip = numberOfShotsInClip;
			Projectile val2 = Object.Instantiate<Projectile>(projectile.projectiles[0]);
			projectile.projectiles[0] = val2;
			((Component)val2).gameObject.SetActive(false);
			FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
			Object.DontDestroyOnLoad((Object)(object)val2);
			ProjectileData baseData = val2.baseData;
			baseData.damage *= 1f;
			ProjectileData baseData2 = val2.baseData;
			baseData2.speed *= 0.5f;
			ProjectileData baseData3 = val2.baseData;
			baseData3.range *= 2f;
			GoopModifier val3 = ((Component)val2).gameObject.AddComponent<GoopModifier>();
			val3.goopDefinition = EasyGoopDefinitions.PlayerFriendlyWebGoop;
			val3.SpawnGoopInFlight = true;
			val3.InFlightSpawnFrequency = 0.05f;
			val3.InFlightSpawnRadius = 1f;
			val3.SpawnGoopOnCollision = true;
			val3.CollisionSpawnRadius = 2f;
			val2.SetProjectileSprite("yellow_enemystyle_projectile", 10, 10, lightened: true, (Anchor)4, 8, 8, anchorChangesCollider: true, fixesScale: false, null, null);
			if (num <= 0)
			{
				projectile.ammoCost = 0;
				projectile.sequenceStyle = (ProjectileSequenceStyle)0;
				projectile.shootStyle = (ShootStyle)1;
				projectile.cooldownTime = cooldownTime;
				projectile.angleVariance = 0.01f;
				projectile.angleFromAim = -30f;
				num++;
			}
			else if (num == 1)
			{
				projectile.ammoCost = 1;
				projectile.sequenceStyle = (ProjectileSequenceStyle)0;
				projectile.shootStyle = (ShootStyle)1;
				projectile.cooldownTime = cooldownTime;
				projectile.angleVariance = 0.01f;
				projectile.angleFromAim = 0.01f;
				num++;
			}
			else if (num == 2)
			{
				projectile.ammoCost = 0;
				projectile.sequenceStyle = (ProjectileSequenceStyle)0;
				projectile.shootStyle = (ShootStyle)1;
				projectile.cooldownTime = cooldownTime;
				projectile.angleFromAim = 30f;
				projectile.angleVariance = 0.1f;
				num++;
			}
			else if (num == 3)
			{
				projectile.ammoCost = 0;
				projectile.sequenceStyle = (ProjectileSequenceStyle)0;
				projectile.shootStyle = (ShootStyle)1;
				projectile.cooldownTime = cooldownTime2;
				projectile.angleFromAim = -10f;
				projectile.angleVariance = 0.1f;
				val3.SpawnGoopInFlight = false;
				num++;
			}
			else if (num == 4)
			{
				projectile.ammoCost = 0;
				projectile.sequenceStyle = (ProjectileSequenceStyle)0;
				projectile.shootStyle = (ShootStyle)1;
				projectile.cooldownTime = cooldownTime2;
				projectile.angleFromAim = -20f;
				projectile.angleVariance = 0.1f;
				val3.SpawnGoopInFlight = false;
				num++;
			}
			else if (num == 5)
			{
				projectile.ammoCost = 0;
				projectile.sequenceStyle = (ProjectileSequenceStyle)0;
				projectile.shootStyle = (ShootStyle)1;
				projectile.cooldownTime = cooldownTime2;
				projectile.angleFromAim = 10f;
				projectile.angleVariance = 0.1f;
				val3.SpawnGoopInFlight = false;
				num++;
			}
			else if (num >= 6)
			{
				projectile.ammoCost = 0;
				projectile.sequenceStyle = (ProjectileSequenceStyle)0;
				projectile.shootStyle = (ShootStyle)1;
				projectile.cooldownTime = cooldownTime2;
				projectile.angleFromAim = 20f;
				projectile.angleVariance = 0.1f;
				val3.SpawnGoopInFlight = false;
				num++;
			}
		}
		val.reloadTime = 1.4f;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.25f, 0.62f, 0f);
		val.SetBaseMaxAmmo(600);
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("PhaserSpiderling Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/phaserspiderling_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/phaserspiderling_clipempty");
		val.gunClass = (GunClass)10;
		((PickupObject)val).quality = (ItemQuality)5;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		AlexandriaTags.SetTag((PickupObject)(object)val, "non_companion_living_item");
		PhaserSpiderlingID = ((PickupObject)val).PickupObjectId;
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.PHASERSPIDER_QUEST_REWARDED, requiredFlagValue: true);
	}
}
