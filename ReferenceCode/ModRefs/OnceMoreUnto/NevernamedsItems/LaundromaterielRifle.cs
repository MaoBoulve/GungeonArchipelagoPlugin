using System.Collections.Generic;
using Alexandria.Assetbundle;
using Alexandria.BreakableAPI;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Dungeonator;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class LaundromaterielRifle : AdvancedGunBehavior
{
	public static int ID;

	public static void Add()
	{
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0368: Unknown result type (might be due to invalid IL or missing references)
		//IL_037f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Laundromateriel Rifle", "laundromaterielrifle");
		Game.Items.Rename("outdated_gun_mods:laundromateriel_rifle", "nn:laundromateriel_rifle");
		((Component)val).gameObject.AddComponent<LaundromaterielRifle>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Washed Up");
		GunExt.SetLongDescription((PickupObject)(object)val, "This washing machine was stolen from the long lost communal washroom in the Breach- for use as a weapon within the Gungeon.\n\n Contains several prized artefacts, such as Winchesters lucky shorts.");
		val.SetGunSprites("laundromaterielrifle");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(404);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		val.reloadTime = 0.8f;
		val.SetBaseMaxAmmo(130);
		val.ammo = 130;
		val.gunHandedness = (GunHandedness)3;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.125f, 0.375f, 0f);
		val.gunClass = (GunClass)5;
		val.muzzleFlashEffects = VFXToolbox.CreateVFXPool("LaundromaterielRifle Muzzleflash", new List<string> { "NevernamedsItems/Resources/MiscVFX/GunVFX/watersplash_muzzleflash_001", "NevernamedsItems/Resources/MiscVFX/GunVFX/watersplash_muzzleflash_002", "NevernamedsItems/Resources/MiscVFX/GunVFX/watersplash_muzzleflash_003", "NevernamedsItems/Resources/MiscVFX/GunVFX/watersplash_muzzleflash_004", "NevernamedsItems/Resources/MiscVFX/GunVFX/watersplash_muzzleflash_005", "NevernamedsItems/Resources/MiscVFX/GunVFX/watersplash_muzzleflash_006", "NevernamedsItems/Resources/MiscVFX/GunVFX/watersplash_muzzleflash_007", "NevernamedsItems/Resources/MiscVFX/GunVFX/watersplash_muzzleflash_008" }, 17, new IntVector2(60, 60), (Anchor)3, usesZHeight: false, 0f, persist: false, (VFXAlignment)0, -1f, null, (WrapMode)2);
		CustomClipAmmoTypeToolbox.AddCustomAmmoType("Laundromateriel Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/laundromaterielrifle_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/laundromaterielrifle_clipempty");
		for (int i = 0; i < 4; i++)
		{
			PickupObject byId2 = PickupObjectDatabase.GetById(86);
			GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		}
		foreach (ProjectileModule projectile in val.Volley.projectiles)
		{
			projectile.ammoCost = ((projectile == val.DefaultModule) ? 1 : 0);
			projectile.shootStyle = (ShootStyle)1;
			projectile.sequenceStyle = (ProjectileSequenceStyle)0;
			projectile.cooldownTime = 0.34f;
			projectile.angleVariance = 40f;
			projectile.numberOfShotsInClip = 6;
			projectile.projectiles[0] = MakeProj("yellowshirt", "yellowshirt", "LaundromaterielYellowShirt");
			projectile.projectiles.Add(MakeProj("yellowshirt", "kinshirt", "LaundromaterielYellowShirt"));
			projectile.projectiles.Add(MakeProj("pinkshirt", "pinkshirt", "LaundromaterielPinkShirt"));
			projectile.projectiles.Add(MakeProj("redshirt", "redshirt", "LaundromaterielRedShirt"));
			projectile.projectiles.Add(MakeProj("greenshirt", "greenshirt", "LaundromaterielGreenShirt"));
			projectile.projectiles.Add(MakeProj("bluepants", "bluepants", "LaundromaterielBluePants"));
			projectile.projectiles.Add(MakeProj("greypants", "greypants", "LaundromaterielGreyPants"));
			projectile.projectiles.Add(MakeProj("whitepants", "whitepants", "LaundromaterielWhitePants"));
			projectile.projectiles.Add(MakeProj("pinkshirt", "pinkpants", "LaundromaterielPinkShirt"));
		}
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = "Laundromateriel Bullets";
		((PickupObject)val).quality = (ItemQuality)2;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
	}

	public override void OnPostFired(PlayerController player, Gun gun)
	{
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)player) && player.CurrentRoom != null && player.CurrentRoom.HasActiveEnemies((ActiveEnemyType)0) && CustomSynergies.PlayerHasActiveSynergy(player, "Bloodwash"))
		{
			List<AIActor> activeEnemies = player.CurrentRoom.GetActiveEnemies((ActiveEnemyType)0);
			for (int i = 0; i < activeEnemies.Count; i++)
			{
				AIActor val = activeEnemies[i];
				if (Object.op_Implicit((Object)(object)val) && MathsAndLogicHelper.PositionBetweenRelativeValidAngles(Vector2.op_Implicit(val.Position), Vector2.op_Implicit(gun.barrelOffset.position), gun.CurrentAngle, 4f, 60f))
				{
					((GameActor)val).ApplyEffect((GameActorEffect)(object)new GameActorExsanguinationEffect
					{
						duration = 3f
					}, 1f, (Projectile)null);
				}
			}
		}
		((AdvancedGunBehavior)this).OnPostFired(player, gun);
	}

	private static Projectile MakeProj(string projName, string debrisname, string animationName)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Expected O, but got Unknown
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Expected O, but got Unknown
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Expected O, but got Unknown
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Expected O, but got Unknown
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Expected O, but got Unknown
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d3: Expected O, but got Unknown
		//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0217: Unknown result type (might be due to invalid IL or missing references)
		//IL_021f: Expected O, but got Unknown
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_0239: Expected O, but got Unknown
		//IL_023b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0249: Unknown result type (might be due to invalid IL or missing references)
		//IL_0250: Expected O, but got Unknown
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0261: Unknown result type (might be due to invalid IL or missing references)
		//IL_0266: Unknown result type (might be due to invalid IL or missing references)
		//IL_026d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0274: Unknown result type (might be due to invalid IL or missing references)
		//IL_027b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0282: Unknown result type (might be due to invalid IL or missing references)
		//IL_0289: Unknown result type (might be due to invalid IL or missing references)
		//IL_0294: Unknown result type (might be due to invalid IL or missing references)
		//IL_029c: Expected O, but got Unknown
		//IL_02b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b6: Expected O, but got Unknown
		//IL_02b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cd: Expected O, but got Unknown
		//IL_02d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02de: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0306: Unknown result type (might be due to invalid IL or missing references)
		//IL_0311: Unknown result type (might be due to invalid IL or missing references)
		//IL_0319: Expected O, but got Unknown
		//IL_032d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0333: Expected O, but got Unknown
		//IL_0335: Unknown result type (might be due to invalid IL or missing references)
		//IL_0343: Unknown result type (might be due to invalid IL or missing references)
		//IL_034a: Expected O, but got Unknown
		//IL_0354: Unknown result type (might be due to invalid IL or missing references)
		//IL_0359: Unknown result type (might be due to invalid IL or missing references)
		//IL_035b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0360: Unknown result type (might be due to invalid IL or missing references)
		//IL_0367: Unknown result type (might be due to invalid IL or missing references)
		//IL_036e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0375: Unknown result type (might be due to invalid IL or missing references)
		//IL_037c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0383: Unknown result type (might be due to invalid IL or missing references)
		//IL_038e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0396: Expected O, but got Unknown
		//IL_03b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03dd: Unknown result type (might be due to invalid IL or missing references)
		Projectile val = ProjectileUtility.InstantiateAndFakeprefab(((Gun)PickupObjectDatabase.GetById(86)).DefaultModule.projectiles[0]);
		((Object)val).name = projName;
		ProjectileData baseData = val.baseData;
		baseData.speed *= 0.7f;
		ProjectileData baseData2 = val.baseData;
		baseData2.range *= 2f;
		AnimateIndiv(val, animationName);
		GameObject gameObject = ((Component)BreakableAPIToolbox.GenerateDebrisObject("NevernamedsItems/Resources/Debris/" + debrisname + "_debris.png", true, 1f, 1f, 45f, 20f, (tk2dSprite)null, 1f, (string)null, (GameObject)null, 0, false, (GoopDefinition)null, 1f)).gameObject;
		((Object)gameObject).name = debrisname;
		ProjectileImpactVFXPool val2 = new ProjectileImpactVFXPool();
		val2.suppressHitEffectsIfOffscreen = false;
		val2.suppressMidairDeathVfx = false;
		val2.overrideMidairZHeight = -1;
		val2.overrideEarlyDeathVfx = null;
		val2.overrideMidairDeathVFX = gameObject;
		val2.midairInheritsVelocity = false;
		val2.midairInheritsFlip = false;
		val2.midairInheritsRotation = false;
		val2.alwaysUseMidair = false;
		val2.CenterDeathVFXOnProjectile = false;
		val2.HasProjectileDeathVFX = true;
		VFXPool val3 = new VFXPool();
		val3.type = (VFXPoolType)4;
		VFXPool obj = val3;
		VFXComplex[] array = new VFXComplex[1];
		VFXComplex val4 = new VFXComplex();
		val4.effects = (VFXObject[])(object)new VFXObject[1]
		{
			new VFXObject
			{
				alignment = (VFXAlignment)0,
				attached = true,
				destructible = false,
				orphaned = true,
				persistsOnDeath = false,
				usesZHeight = false,
				zHeight = 0f,
				effect = ((Gun)PickupObjectDatabase.GetById(150)).DefaultModule.projectiles[0].hitEffects.enemy.effects[0].effects[0].effect
			}
		};
		array[0] = val4;
		obj.effects = (VFXComplex[])(object)array;
		val2.enemy = val3;
		val3 = new VFXPool();
		val3.type = (VFXPoolType)4;
		VFXPool obj2 = val3;
		VFXComplex[] array2 = new VFXComplex[1];
		val4 = new VFXComplex();
		val4.effects = (VFXObject[])(object)new VFXObject[1]
		{
			new VFXObject
			{
				alignment = (VFXAlignment)0,
				attached = true,
				destructible = false,
				orphaned = true,
				persistsOnDeath = false,
				usesZHeight = false,
				zHeight = 0f,
				effect = gameObject
			}
		};
		array2[0] = val4;
		obj2.effects = (VFXComplex[])(object)array2;
		val2.deathEnemy = val3;
		val3 = new VFXPool();
		val3.type = (VFXPoolType)4;
		VFXPool obj3 = val3;
		VFXComplex[] array3 = new VFXComplex[1];
		val4 = new VFXComplex();
		val4.effects = (VFXObject[])(object)new VFXObject[1]
		{
			new VFXObject
			{
				alignment = (VFXAlignment)0,
				attached = true,
				destructible = false,
				orphaned = true,
				persistsOnDeath = false,
				usesZHeight = false,
				zHeight = 0f,
				effect = gameObject
			}
		};
		array3[0] = val4;
		obj3.effects = (VFXComplex[])(object)array3;
		val2.deathTileMapHorizontal = val3;
		val3 = new VFXPool();
		val3.type = (VFXPoolType)4;
		VFXPool obj4 = val3;
		VFXComplex[] array4 = new VFXComplex[1];
		val4 = new VFXComplex();
		val4.effects = (VFXObject[])(object)new VFXObject[1]
		{
			new VFXObject
			{
				alignment = (VFXAlignment)0,
				attached = true,
				destructible = false,
				orphaned = true,
				persistsOnDeath = false,
				usesZHeight = false,
				zHeight = 0f,
				effect = gameObject
			}
		};
		array4[0] = val4;
		obj4.effects = (VFXComplex[])(object)array4;
		val2.deathTileMapVertical = val3;
		val3 = new VFXPool();
		val3.type = (VFXPoolType)0;
		VFXPool obj5 = val3;
		VFXComplex[] array5 = new VFXComplex[1];
		val4 = new VFXComplex();
		val4.effects = (VFXObject[])(object)new VFXObject[1]
		{
			new VFXObject
			{
				alignment = (VFXAlignment)0,
				attached = false,
				destructible = false,
				orphaned = true,
				persistsOnDeath = false,
				usesZHeight = false,
				zHeight = 0f,
				effect = gameObject
			}
		};
		array5[0] = val4;
		obj5.effects = (VFXComplex[])(object)array5;
		val2.deathAny = val3;
		val2.tileMapHorizontal = ((Gun)PickupObjectDatabase.GetById(28)).DefaultModule.projectiles[0].hitEffects.tileMapHorizontal;
		val2.tileMapVertical = ((Gun)PickupObjectDatabase.GetById(28)).DefaultModule.projectiles[0].hitEffects.tileMapVertical;
		val.hitEffects = val2;
		return val;
	}

	private static void AnimateIndiv(Projectile projectile, string animName)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		ProjectileBuilders.AnimateProjectileBundle(projectile, animName, Initialisation.ProjectileCollection, Initialisation.projectileAnimationCollection, animName, MiscTools.DupeList<IntVector2>(new IntVector2(12, 12), 8), MiscTools.DupeList(value: false, 8), MiscTools.DupeList<Anchor>((Anchor)4, 8), MiscTools.DupeList(value: true, 8), MiscTools.DupeList(value: false, 8), MiscTools.DupeList<Vector3?>(null, 8), MiscTools.DupeList<IntVector2?>(null, 8), MiscTools.DupeList<IntVector2?>(null, 8), MiscTools.DupeList<Projectile>(null, 8));
	}
}
