using Alexandria.Assetbundle;
using Alexandria.BreakableAPI;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Bloodwash : AdvancedGunBehavior
{
	public static int ID;

	public static void Add()
	{
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_021a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0232: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Bloodwash", "laundromaterielriflebloodwash");
		Game.Items.Rename("outdated_gun_mods:bloodwash", "nn:laundromateriel_rifle+bloodwash");
		((Component)val).gameObject.AddComponent<LaundromaterielRifle>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Washed Up");
		GunExt.SetLongDescription((PickupObject)(object)val, "This washing machine was stolen from the long lost communal washroom in the Breach- for use as a weapon within the Gungeon.\n\n Contains several prized artefacts, such as Winchesters lucky shorts.");
		val.SetGunSprites("laundromaterielriflebloodwash", 8, noAmmonomicon: true);
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
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId2 = PickupObjectDatabase.GetById(479);
		muzzleFlashEffects = ((Gun)((byId2 is Gun) ? byId2 : null)).muzzleFlashEffects;
		for (int i = 0; i < 5; i++)
		{
			PickupObject byId3 = PickupObjectDatabase.GetById(86);
			GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId3 is Gun) ? byId3 : null), true, false);
		}
		foreach (ProjectileModule projectile in val.Volley.projectiles)
		{
			projectile.ammoCost = ((projectile == val.DefaultModule) ? 1 : 0);
			projectile.shootStyle = (ShootStyle)1;
			projectile.sequenceStyle = (ProjectileSequenceStyle)0;
			projectile.cooldownTime = 0.34f;
			projectile.angleVariance = 30f;
			projectile.numberOfShotsInClip = 6;
			projectile.projectiles[0] = MakeProj("redshirt", "bloodpants1");
			projectile.projectiles.Add(MakeProj("redshirt", "bloodpants2"));
			projectile.projectiles.Add(MakeProj("redshirt", "bloodshirt1"));
			projectile.projectiles.Add(MakeProj("redshirt", "bloodshirt2"));
		}
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = "Laundromateriel Bullets";
		((PickupObject)val).quality = (ItemQuality)(-100);
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
		GunExt.SetName((PickupObject)(object)val, "Laundromateriel Rifle");
	}

	private static Projectile MakeProj(string projName, string debrisname)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Expected O, but got Unknown
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Expected O, but got Unknown
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Expected O, but got Unknown
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ce: Expected O, but got Unknown
		//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e8: Expected O, but got Unknown
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Expected O, but got Unknown
		//IL_0209: Unknown result type (might be due to invalid IL or missing references)
		//IL_020e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0210: Unknown result type (might be due to invalid IL or missing references)
		//IL_0215: Unknown result type (might be due to invalid IL or missing references)
		//IL_021c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0223: Unknown result type (might be due to invalid IL or missing references)
		//IL_022a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Unknown result type (might be due to invalid IL or missing references)
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_0243: Unknown result type (might be due to invalid IL or missing references)
		//IL_024b: Expected O, but got Unknown
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0265: Expected O, but got Unknown
		//IL_0267: Unknown result type (might be due to invalid IL or missing references)
		//IL_0275: Unknown result type (might be due to invalid IL or missing references)
		//IL_027c: Expected O, but got Unknown
		//IL_0286: Unknown result type (might be due to invalid IL or missing references)
		//IL_028b: Unknown result type (might be due to invalid IL or missing references)
		//IL_028d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0292: Unknown result type (might be due to invalid IL or missing references)
		//IL_0299: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c8: Expected O, but got Unknown
		//IL_02dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e2: Expected O, but got Unknown
		//IL_02e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f9: Expected O, but got Unknown
		//IL_0303: Unknown result type (might be due to invalid IL or missing references)
		//IL_0308: Unknown result type (might be due to invalid IL or missing references)
		//IL_030a: Unknown result type (might be due to invalid IL or missing references)
		//IL_030f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0316: Unknown result type (might be due to invalid IL or missing references)
		//IL_031d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0324: Unknown result type (might be due to invalid IL or missing references)
		//IL_032b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0332: Unknown result type (might be due to invalid IL or missing references)
		//IL_033d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0345: Expected O, but got Unknown
		//IL_0359: Unknown result type (might be due to invalid IL or missing references)
		//IL_035f: Expected O, but got Unknown
		//IL_0361: Unknown result type (might be due to invalid IL or missing references)
		//IL_036f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0376: Expected O, but got Unknown
		//IL_0380: Unknown result type (might be due to invalid IL or missing references)
		//IL_0385: Unknown result type (might be due to invalid IL or missing references)
		//IL_0387: Unknown result type (might be due to invalid IL or missing references)
		//IL_038c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0393: Unknown result type (might be due to invalid IL or missing references)
		//IL_039a: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03af: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c2: Expected O, but got Unknown
		//IL_03dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0409: Unknown result type (might be due to invalid IL or missing references)
		Projectile val = ProjectileUtility.InstantiateAndFakeprefab(((Gun)PickupObjectDatabase.GetById(86)).DefaultModule.projectiles[0]);
		((Object)val).name = projName;
		ProjectileData baseData = val.baseData;
		baseData.speed *= 0.7f;
		ProjectileData baseData2 = val.baseData;
		baseData2.range *= 2f;
		AnimateIndiv(val, projName);
		GameObject gameObject = ((Component)BreakableAPIToolbox.GenerateDebrisObject("NevernamedsItems/Resources/Debris/" + debrisname + "_debris.png", true, 1f, 1f, 45f, 20f, (tk2dSprite)null, 1f, (string)null, (GameObject)null, 0, false, (GoopDefinition)null, 1f)).gameObject;
		((Object)gameObject).name = debrisname;
		gameObject.GetComponent<DebrisObject>().DoesGoopOnRest = true;
		gameObject.GetComponent<DebrisObject>().GoopRadius = 1f;
		gameObject.GetComponent<DebrisObject>().AssignedGoop = EasyGoopDefinitions.BlobulonGoopDef;
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

	private static void AnimateIndiv(Projectile projectile, string projName)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		ProjectileBuilders.AnimateProjectileBundle(projectile, "LaundromaterielRedShirt", Initialisation.ProjectileCollection, Initialisation.projectileAnimationCollection, "LaundromaterielRedShirt", MiscTools.DupeList<IntVector2>(new IntVector2(12, 12), 8), MiscTools.DupeList(value: false, 8), MiscTools.DupeList<Anchor>((Anchor)4, 8), MiscTools.DupeList(value: true, 8), MiscTools.DupeList(value: false, 8), MiscTools.DupeList<Vector3?>(null, 8), MiscTools.DupeList<IntVector2?>(null, 8), MiscTools.DupeList<IntVector2?>(null, 8), MiscTools.DupeList<Projectile>(null, 8));
	}
}
