using System.Collections.Generic;
using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Gungeon;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class TheOutbreak : AdvancedGunBehavior
{
	public static int TheOutbreakID;

	public static void Add()
	{
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0300: Unknown result type (might be due to invalid IL or missing references)
		//IL_030f: Unknown result type (might be due to invalid IL or missing references)
		//IL_031f: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ff: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("The Outbreak", "theoutbreak");
		Game.Items.Rename("outdated_gun_mods:the_outbreak", "nn:the_outbreak");
		((Component)val).gameObject.AddComponent<TheOutbreak>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Epidemical!");
		GunExt.SetLongDescription((PickupObject)(object)val, "A terrifying piece of bioweaponry. The final shot is a highly concentrated gel projectile containing a virulent load.");
		val.SetGunSprites("theoutbreak");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 20);
		PickupObject byId = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.angleVariance = 6.5f;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1.5f;
		val.DefaultModule.cooldownTime = 0.15f;
		val.DefaultModule.numberOfShotsInClip = 13;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.43f, 0.81f, 0f);
		val.SetBaseMaxAmmo(330);
		val.gunClass = (GunClass)25;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		ProjectileData baseData = val2.baseData;
		baseData.speed *= 1.1f;
		val2.baseData.damage = 6f;
		val2.SetProjectileSprite("theoutbreak_proj", 10, 10, lightened: true, (Anchor)4, 9, 9, anchorChangesCollider: true, fixesScale: false, null, null);
		val2.hitEffects.alwaysUseMidair = true;
		val2.hitEffects.overrideMidairDeathVFX = SharedVFX.ColouredPoofGrey;
		((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		PickupObject byId2 = PickupObjectDatabase.GetById(56);
		Projectile val3 = Object.Instantiate<Projectile>(((Gun)((byId2 is Gun) ? byId2 : null)).DefaultModule.projectiles[0]);
		((Component)val3).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val3).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val3);
		ProjectileData baseData2 = val3.baseData;
		baseData2.speed *= 0.8f;
		val3.baseData.damage = 14.1414f;
		ProjectileData baseData3 = val3.baseData;
		baseData3.range *= 2f;
		ModdedStatusEffectApplier moddedStatusEffectApplier = ((Component)val3).gameObject.AddComponent<ModdedStatusEffectApplier>();
		moddedStatusEffectApplier.appliesPlague = true;
		GoopModifier val4 = ((Component)val3).gameObject.AddComponent<GoopModifier>();
		val4.SpawnGoopOnCollision = true;
		val4.CollisionSpawnRadius = 4f;
		val4.SpawnGoopInFlight = false;
		val4.goopDefinition = EasyGoopDefinitions.PlagueGoop;
		val3.hitEffects.alwaysUseMidair = true;
		val3.hitEffects.overrideMidairDeathVFX = SharedVFX.ColouredPoofRed;
		ProjectileBuilders.AnimateProjectileBundle(val3, "OutbreakPlagueProjectile", Initialisation.ProjectileCollection, Initialisation.projectileAnimationCollection, "OutbreakPlagueProjectile", new List<IntVector2>
		{
			new IntVector2(13, 8),
			new IntVector2(11, 10),
			new IntVector2(13, 8),
			new IntVector2(10, 11)
		}, MiscTools.DupeList(value: false, 4), MiscTools.DupeList<Anchor>((Anchor)4, 4), MiscTools.DupeList(value: true, 4), MiscTools.DupeList(value: false, 4), MiscTools.DupeList<Vector3?>(null, 4), MiscTools.DupeList<IntVector2?>(null, 4), MiscTools.DupeList<IntVector2?>(null, 4), MiscTools.DupeList<Projectile>(null, 4));
		val.DefaultModule.usesOptionalFinalProjectile = true;
		val.DefaultModule.finalProjectile = val3;
		val.DefaultModule.numberOfFinalProjectiles = 1;
		((PickupObject)val).quality = (ItemQuality)4;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		TheOutbreakID = ((PickupObject)val).PickupObjectId;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Outbreak Ammo", "NevernamedsItems/Resources/CustomGunAmmoTypes/outbreak_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/outbreak_clipempty");
		val.DefaultModule.finalAmmoType = (AmmoType)14;
		val.DefaultModule.finalCustomAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Outbreak Glob", "NevernamedsItems/Resources/CustomGunAmmoTypes/outbreak_plagueprojectile_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/outbreak_plagueprojectile_clipempty");
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.PURCHASED_THEOUTBREAK, requiredFlagValue: true);
		((PickupObject)(object)val).AddItemToDougMetaShop(45, null);
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)0, 1f);
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		((AdvancedGunBehavior)this).PostProcessProjectile(projectile);
		GameActor currentOwner = base.gun.CurrentOwner;
		PlayerController val = (PlayerController)(object)((currentOwner is PlayerController) ? currentOwner : null);
		if (!CustomSynergies.PlayerHasActiveSynergy(val, "Toxic Avenger"))
		{
		}
	}
}
