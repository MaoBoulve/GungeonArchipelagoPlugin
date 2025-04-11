using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class DiscGun : AdvancedGunBehavior
{
	public static int DiscGunID;

	public static void Add()
	{
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_037f: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0428: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ad: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Disc Gun", "discgun2");
		Game.Items.Rename("outdated_gun_mods:disc_gun", "nn:disc_gun");
		DiscGun discGun = ((Component)val).gameObject.AddComponent<DiscGun>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Bad Choices");
		GunExt.SetLongDescription((PickupObject)(object)val, "Fires sharp, bouncing discs.\n\nCapable of hurting it's bearer, because someone thought that would be funny.");
		GunInt.SetupSprite(val, Initialisation.gunCollection, "discgun2_idle_001", 8, "discgun2_ammonomicon_001");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 14);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 14);
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId = PickupObjectDatabase.GetById(26);
		muzzleFlashEffects = ((Gun)((byId is Gun) ? byId : null)).muzzleFlashEffects;
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(12);
		gunSwitchGroup = ((Gun)((byId2 is Gun) ? byId2 : null)).gunSwitchGroup;
		PickupObject byId3 = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId3 is Gun) ? byId3 : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 0.25f;
		val.DefaultModule.numberOfShotsInClip = 10;
		val.SetBaseMaxAmmo(300);
		val.SetBarrel(19, 11);
		val.gunClass = (GunClass)1;
		Projectile val2 = ProjectileSetupUtility.MakeProjectile(86, 20f);
		val.DefaultModule.projectiles[0] = val2;
		ProjectileData baseData = val2.baseData;
		baseData.range *= 20f;
		val2.objectImpactEventName = "saw";
		ProjectileData baseData2 = val2.baseData;
		baseData2.speed *= 0.4f;
		CustomVFXTrail customVFXTrail = ((Component)val2).gameObject.AddComponent<CustomVFXTrail>();
		customVFXTrail.timeBetweenSpawns = 0.15f;
		customVFXTrail.anchor = CustomVFXTrail.Anchor.Center;
		customVFXTrail.VFX = VFXToolbox.CreateBlankVFXPool(VFXToolbox.CreateVFXBundle("DiscTrail", usesZHeight: false, 0f, -1f, -1f, null), isDebris: true);
		customVFXTrail.heightOffset = -1f;
		GameObject gameObject = ((Component)Breakables.GenerateDebrisObject(Initialisation.GunDressingCollection, "disc_debris", debrisObjectsCanRotate: true, 1f, 1f, 45f, 20f)).gameObject;
		PickupObject byId4 = PickupObjectDatabase.GetById(97);
		VFXPool tileMapVertical = ((Gun)((byId4 is Gun) ? byId4 : null)).DefaultModule.projectiles[0].hitEffects.tileMapVertical;
		VFXPool val3 = VFXToolbox.CreateBlankVFXPool(gameObject, isDebris: true);
		ref VFXPool enemy = ref val2.hitEffects.enemy;
		ref VFXPool enemy2 = ref val2.hitEffects.enemy;
		PickupObject byId5 = PickupObjectDatabase.GetById(369);
		enemy = (enemy2 = ((Gun)((byId5 is Gun) ? byId5 : null)).DefaultModule.chargeProjectiles[0].Projectile.hitEffects.tileMapVertical);
		val2.hitEffects.deathTileMapVertical = val3;
		val2.hitEffects.deathTileMapHorizontal = val3;
		val2.hitEffects.deathEnemy = val3;
		val2.hitEffects.deathAny = tileMapVertical;
		val2.hitEffects.overrideMidairDeathVFX = gameObject;
		val2.hitEffects.suppressHitEffectsIfOffscreen = false;
		val2.hitEffects.suppressMidairDeathVfx = false;
		val2.hitEffects.overrideMidairZHeight = -1;
		val2.hitEffects.overrideEarlyDeathVfx = null;
		val2.hitEffects.overrideMidairDeathVFX = gameObject;
		val2.hitEffects.midairInheritsVelocity = false;
		val2.hitEffects.midairInheritsFlip = false;
		val2.hitEffects.midairInheritsRotation = false;
		val2.hitEffects.alwaysUseMidair = false;
		val2.hitEffects.CenterDeathVFXOnProjectile = false;
		val2.hitEffects.HasProjectileDeathVFX = true;
		val2.hitEffects.tileMapHorizontal = ((Gun)PickupObjectDatabase.GetById(97)).DefaultModule.projectiles[0].hitEffects.tileMapHorizontal;
		val2.hitEffects.tileMapVertical = ((Gun)PickupObjectDatabase.GetById(97)).DefaultModule.projectiles[0].hitEffects.tileMapVertical;
		ProjectileBuilders.AnimateProjectileBundle(val2, "DiscProjectile", Initialisation.ProjectileCollection, Initialisation.projectileAnimationCollection, "DiscProjectile", MiscTools.DupeList<IntVector2>(new IntVector2(15, 15), 8), MiscTools.DupeList(value: false, 8), MiscTools.DupeList<Anchor>((Anchor)4, 8), MiscTools.DupeList(value: true, 8), MiscTools.DupeList(value: false, 8), MiscTools.DupeList<Vector3?>(null, 8), MiscTools.DupeList((IntVector2?)new IntVector2(9, 9), 8), MiscTools.DupeList<IntVector2?>(null, 8), MiscTools.DupeList<Projectile>(null, 8));
		SelfHarmBulletBehaviour selfHarmBulletBehaviour = ((Component)val2).gameObject.AddComponent<SelfHarmBulletBehaviour>();
		PierceProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<PierceProjModifier>(((Component)val2).gameObject);
		orAddComponent.penetratesBreakables = true;
		orAddComponent.penetration += 10;
		BounceProjModifier orAddComponent2 = GameObjectExtensions.GetOrAddComponent<BounceProjModifier>(((Component)val2).gameObject);
		orAddComponent2.numberOfBounces = 10;
		val.AddClipSprites("discgun");
		((PickupObject)val).quality = (ItemQuality)1;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		ItemBuilder.AddToGunslingKingTable((PickupObject)(object)val, 1);
		DiscGunID = ((PickupObject)val).PickupObjectId;
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		((AdvancedGunBehavior)this).PostProcessProjectile(projectile);
		GameActor owner = projectile.Owner;
		PlayerController val = (PlayerController)(object)((owner is PlayerController) ? owner : null);
		if (CustomSynergies.PlayerHasActiveSynergy(val, "Even Worse Choices"))
		{
			ProjectileData baseData = projectile.baseData;
			baseData.damage *= 2f;
		}
		if (CustomSynergies.PlayerHasActiveSynergy(val, "Discworld"))
		{
			HomingModifier val2 = ((Component)projectile).gameObject.AddComponent<HomingModifier>();
			val2.AngularVelocity = 50f;
			val2.HomingRadius = 50f;
		}
	}
}
