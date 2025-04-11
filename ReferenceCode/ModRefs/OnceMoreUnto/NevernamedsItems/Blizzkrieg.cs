using Alexandria.ItemAPI;
using Gungeon;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class Blizzkrieg : AdvancedGunBehavior
{
	public static int BlizzkriegID;

	public static void Add()
	{
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0277: Unknown result type (might be due to invalid IL or missing references)
		//IL_027f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0303: Unknown result type (might be due to invalid IL or missing references)
		//IL_031d: Unknown result type (might be due to invalid IL or missing references)
		//IL_032a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0379: Unknown result type (might be due to invalid IL or missing references)
		//IL_0392: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b0: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Blizzkrieg", "blizzkrieg");
		Game.Items.Rename("outdated_gun_mods:blizzkrieg", "nn:blizzkrieg");
		Blizzkrieg blizzkrieg = ((Component)val).gameObject.AddComponent<Blizzkrieg>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Kalt Action");
		GunExt.SetLongDescription((PickupObject)(object)val, "Fires chunks of hypercold H2O.\n\nSecret Blobulonian technology, developed during their ill-fated winter campaign.");
		val.SetGunSprites("blizzkrieg");
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(38);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		for (int i = 0; i < 2; i++)
		{
			PickupObject byId2 = PickupObjectDatabase.GetById(402);
			GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		}
		foreach (ProjectileModule projectile in val.Volley.projectiles)
		{
			Projectile val2 = Object.Instantiate<Projectile>(projectile.projectiles[0]);
			((Component)val2).gameObject.SetActive(false);
			FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
			Object.DontDestroyOnLoad((Object)(object)val2);
			projectile.projectiles[0] = val2;
			PickupObject byId3 = PickupObjectDatabase.GetById(56);
			Projectile val3 = Object.Instantiate<Projectile>(((Gun)((byId3 is Gun) ? byId3 : null)).DefaultModule.projectiles[0]);
			((Component)val3).gameObject.SetActive(false);
			FakePrefab.MarkAsFakePrefab(((Component)val3).gameObject);
			Object.DontDestroyOnLoad((Object)(object)val3);
			ProjectileData baseData = val3.baseData;
			baseData.damage *= 1.6f;
			ProjectileData baseData2 = val3.baseData;
			baseData2.speed *= 1f;
			val3.damageTypes = (CoreDamageTypes)(val3.damageTypes | 8);
			ScaleProjectileStatOffPlayerStat scaleProjectileStatOffPlayerStat = ((Component)val3).gameObject.AddComponent<ScaleProjectileStatOffPlayerStat>();
			scaleProjectileStatOffPlayerStat.multiplierPerLevelOfStat = 0.2f;
			scaleProjectileStatOffPlayerStat.projstat = ScaleProjectileStatOffPlayerStat.ProjectileStatType.DAMAGE;
			scaleProjectileStatOffPlayerStat.playerstat = (StatType)4;
			SimpleFreezingBulletBehaviour simpleFreezingBulletBehaviour = ((Component)val3).gameObject.AddComponent<SimpleFreezingBulletBehaviour>();
			simpleFreezingBulletBehaviour.freezeAmount = 40;
			simpleFreezingBulletBehaviour.useSpecialTint = false;
			simpleFreezingBulletBehaviour.freezeAmountForBosses = 40;
			GoopModifier val4 = ((Component)val3).gameObject.AddComponent<GoopModifier>();
			val4.CollisionSpawnRadius = 0.8f;
			val4.SpawnGoopOnCollision = true;
			val4.SpawnGoopInFlight = false;
			val4.goopDefinition = EasyGoopDefinitions.WaterGoop;
			val3.SetProjectileSprite("icicle_projectile", 13, 5, lightened: false, (Anchor)4, 13, 5, anchorChangesCollider: true, fixesScale: false, null, null);
			projectile.projectiles.Add(val3);
			projectile.ammoCost = 1;
			projectile.sequenceStyle = (ProjectileSequenceStyle)0;
			projectile.shootStyle = (ShootStyle)1;
			projectile.cooldownTime = 0.1f;
			projectile.angleVariance = 34f;
			projectile.numberOfShotsInClip = 30;
			if (projectile != val.DefaultModule)
			{
				projectile.ammoCost = 0;
			}
		}
		val.reloadTime = 1.5f;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.56f, 0.81f, 0f);
		val.SetBaseMaxAmmo(400);
		val.gunClass = (GunClass)35;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Blizzkrieg Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/blizzkreig_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/blizzkreig_clipempty");
		AdvancedHoveringGunSynergyProcessor advancedHoveringGunSynergyProcessor = ((Component)val).gameObject.AddComponent<AdvancedHoveringGunSynergyProcessor>();
		advancedHoveringGunSynergyProcessor.RequiredSynergy = "Ice Queen";
		advancedHoveringGunSynergyProcessor.TriggerDuration = 1f;
		advancedHoveringGunSynergyProcessor.requiresBaseGunInHand = true;
		advancedHoveringGunSynergyProcessor.FireType = (FireType)1;
		advancedHoveringGunSynergyProcessor.FireCooldown = 0.25f;
		advancedHoveringGunSynergyProcessor.Trigger = AdvancedHoveringGunSynergyProcessor.TriggerStyle.ON_DODGE_ROLL;
		advancedHoveringGunSynergyProcessor.PositionType = (HoverPosition)1;
		advancedHoveringGunSynergyProcessor.IDsToSpawn = new int[3] { 223, 223, 223 };
		((PickupObject)val).quality = (ItemQuality)5;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		BlizzkriegID = ((PickupObject)val).PickupObjectId;
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.CHALLENGE_KEEPITCOOL_BEATEN, requiredFlagValue: true);
	}
}
