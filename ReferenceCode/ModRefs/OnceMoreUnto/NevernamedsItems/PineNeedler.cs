using System.Collections.Generic;
using Alexandria.BreakableAPI;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class PineNeedler : GunBehaviour
{
	public static int ID;

	public int cones = 0;

	public static void Add()
	{
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_024b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0252: Expected O, but got Unknown
		//IL_02ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b3: Expected O, but got Unknown
		//IL_02b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cc: Expected O, but got Unknown
		//IL_02d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02db: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0305: Unknown result type (might be due to invalid IL or missing references)
		//IL_0310: Unknown result type (might be due to invalid IL or missing references)
		//IL_0318: Unknown result type (might be due to invalid IL or missing references)
		//IL_0350: Expected O, but got Unknown
		//IL_0366: Unknown result type (might be due to invalid IL or missing references)
		//IL_036d: Expected O, but got Unknown
		//IL_0370: Unknown result type (might be due to invalid IL or missing references)
		//IL_037f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0386: Expected O, but got Unknown
		//IL_0390: Unknown result type (might be due to invalid IL or missing references)
		//IL_0395: Unknown result type (might be due to invalid IL or missing references)
		//IL_0397: Unknown result type (might be due to invalid IL or missing references)
		//IL_039c: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d2: Expected O, but got Unknown
		//IL_03e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ef: Expected O, but got Unknown
		//IL_03f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0401: Unknown result type (might be due to invalid IL or missing references)
		//IL_0408: Expected O, but got Unknown
		//IL_0412: Unknown result type (might be due to invalid IL or missing references)
		//IL_0417: Unknown result type (might be due to invalid IL or missing references)
		//IL_0419: Unknown result type (might be due to invalid IL or missing references)
		//IL_041e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0425: Unknown result type (might be due to invalid IL or missing references)
		//IL_042c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0433: Unknown result type (might be due to invalid IL or missing references)
		//IL_043a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0441: Unknown result type (might be due to invalid IL or missing references)
		//IL_044c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0454: Expected O, but got Unknown
		//IL_046a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0471: Expected O, but got Unknown
		//IL_0474: Unknown result type (might be due to invalid IL or missing references)
		//IL_0483: Unknown result type (might be due to invalid IL or missing references)
		//IL_048a: Expected O, but got Unknown
		//IL_0494: Unknown result type (might be due to invalid IL or missing references)
		//IL_0499: Unknown result type (might be due to invalid IL or missing references)
		//IL_049b: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d6: Expected O, but got Unknown
		//IL_04ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f3: Expected O, but got Unknown
		//IL_04f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0505: Unknown result type (might be due to invalid IL or missing references)
		//IL_050c: Expected O, but got Unknown
		//IL_0516: Unknown result type (might be due to invalid IL or missing references)
		//IL_051b: Unknown result type (might be due to invalid IL or missing references)
		//IL_051d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0522: Unknown result type (might be due to invalid IL or missing references)
		//IL_0529: Unknown result type (might be due to invalid IL or missing references)
		//IL_0530: Unknown result type (might be due to invalid IL or missing references)
		//IL_0537: Unknown result type (might be due to invalid IL or missing references)
		//IL_053e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0545: Unknown result type (might be due to invalid IL or missing references)
		//IL_0550: Unknown result type (might be due to invalid IL or missing references)
		//IL_0558: Expected O, but got Unknown
		//IL_0575: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05fb: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Pine Needler", "pineneedler");
		Game.Items.Rename("outdated_gun_mods:pine_needler", "nn:pine_needler");
		((Component)val).gameObject.AddComponent<PineNeedler>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Wilding");
		GunExt.SetLongDescription((PickupObject)(object)val, "A miniature pine tree grown in an undiscovered, verdant chamber. Sometimes drops cones.\n\nThe words \"No Pine, No Gine\" are crudely carved into the bark.");
		val.SetGunSprites("pineneedler");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 15);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 10);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(124);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1.1f;
		val.DefaultModule.cooldownTime = 0.17f;
		val.DefaultModule.numberOfShotsInClip = 20;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(339);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2f, 0.75f, 0f);
		val.SetBaseMaxAmmo(250);
		val.gunClass = (GunClass)45;
		Projectile val2 = ProjectileUtility.InstantiateAndFakeprefab(val.DefaultModule.projectiles[0]);
		val.DefaultModule.projectiles[0] = val2;
		ProjectileData baseData = val2.baseData;
		baseData.speed *= 2f;
		val2.SetProjectileSprite("pineneedler_proj", 8, 1, lightened: false, (Anchor)4, 5, 1, anchorChangesCollider: true, fixesScale: false, null, null);
		AdvancedFireOnReloadSynergyProcessor val3 = ((Component)val).gameObject.AddComponent<AdvancedFireOnReloadSynergyProcessor>();
		val3.synergyToCheck = "Leafy Greens";
		val3.angleVariance = 20f;
		val3.numToFire = 7;
		ref Projectile projToFire = ref val3.projToFire;
		PickupObject byId4 = PickupObjectDatabase.GetById(339);
		projToFire = ((Gun)((byId4 is Gun) ? byId4 : null)).Volley.projectiles[1].projectiles[0];
		GameObject gameObject = ((Component)BreakableAPIToolbox.GenerateDebrisObject("NevernamedsItems/Resources/Debris/pineneedler_proj.png", true, 1f, 1f, 45f, 20f, (tk2dSprite)null, 1f, (string)null, (GameObject)null, 0, false, (GoopDefinition)null, 1f)).gameObject;
		ProjectileImpactVFXPool val4 = new ProjectileImpactVFXPool();
		val4.suppressHitEffectsIfOffscreen = false;
		val4.suppressMidairDeathVfx = false;
		val4.overrideMidairZHeight = -1;
		val4.overrideEarlyDeathVfx = null;
		val4.overrideMidairDeathVFX = gameObject;
		val4.midairInheritsVelocity = false;
		val4.midairInheritsFlip = false;
		val4.midairInheritsRotation = false;
		val4.alwaysUseMidair = false;
		val4.CenterDeathVFXOnProjectile = false;
		val4.HasProjectileDeathVFX = true;
		VFXPool val5 = new VFXPool();
		val5.type = (VFXPoolType)4;
		VFXPool obj = val5;
		VFXComplex[] array = new VFXComplex[1];
		VFXComplex val6 = new VFXComplex();
		val6.effects = (VFXObject[])(object)new VFXObject[1]
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
				effect = ((Gun)PickupObjectDatabase.GetById(124)).DefaultModule.projectiles[0].hitEffects.enemy.effects[0].effects[0].effect
			}
		};
		array[0] = val6;
		obj.effects = (VFXComplex[])(object)array;
		val4.enemy = val5;
		val5 = new VFXPool();
		val5.type = (VFXPoolType)4;
		VFXPool obj2 = val5;
		VFXComplex[] array2 = new VFXComplex[1];
		val6 = new VFXComplex();
		val6.effects = (VFXObject[])(object)new VFXObject[1]
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
		array2[0] = val6;
		obj2.effects = (VFXComplex[])(object)array2;
		val4.deathEnemy = val5;
		val5 = new VFXPool();
		val5.type = (VFXPoolType)4;
		VFXPool obj3 = val5;
		VFXComplex[] array3 = new VFXComplex[1];
		val6 = new VFXComplex();
		val6.effects = (VFXObject[])(object)new VFXObject[1]
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
		array3[0] = val6;
		obj3.effects = (VFXComplex[])(object)array3;
		val4.deathTileMapHorizontal = val5;
		val5 = new VFXPool();
		val5.type = (VFXPoolType)4;
		VFXPool obj4 = val5;
		VFXComplex[] array4 = new VFXComplex[1];
		val6 = new VFXComplex();
		val6.effects = (VFXObject[])(object)new VFXObject[1]
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
		array4[0] = val6;
		obj4.effects = (VFXComplex[])(object)array4;
		val4.deathTileMapVertical = val5;
		val5 = new VFXPool();
		val5.type = (VFXPoolType)0;
		VFXPool obj5 = val5;
		VFXComplex[] array5 = new VFXComplex[1];
		val6 = new VFXComplex();
		val6.effects = (VFXObject[])(object)new VFXObject[1]
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
		array5[0] = val6;
		obj5.effects = (VFXComplex[])(object)array5;
		val4.deathAny = val5;
		val4.tileMapHorizontal = ((Gun)PickupObjectDatabase.GetById(124)).DefaultModule.projectiles[0].hitEffects.tileMapHorizontal;
		val4.tileMapVertical = ((Gun)PickupObjectDatabase.GetById(124)).DefaultModule.projectiles[0].hitEffects.tileMapVertical;
		val2.hitEffects = val4;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Pine Needles", "NevernamedsItems/Resources/CustomGunAmmoTypes/pineneedler_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/pineneedler_clipempty");
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		if (Object.op_Implicit((Object)(object)base.gun) && Object.op_Implicit((Object)(object)GunTools.GunPlayerOwner(base.gun)) && CustomSynergies.PlayerHasActiveSynergy(GunTools.GunPlayerOwner(base.gun), "Creatures of the Wood"))
		{
			AdvancedTransmogrifyBehaviour orAddComponent = GameObjectExtensions.GetOrAddComponent<AdvancedTransmogrifyBehaviour>(((Component)projectile).gameObject);
			orAddComponent.TransmogDataList.Add(new TransmogData
			{
				identifier = "Pine Needler",
				TargetGuids = new List<string> { "4254a93fc3c84c0dbe0a8f0dddf48a5a" },
				maintainHPPercent = false,
				TransmogChance = 0.1f
			});
		}
		((GunBehaviour)this).PostProcessProjectile(projectile);
	}

	public override void OnReloadPressed(PlayerController player, Gun gun, bool manual)
	{
		cones = 0;
		((GunBehaviour)this).OnReloadPressed(player, gun, manual);
	}

	public override Projectile OnPreFireProjectileModifier(Gun gun, Projectile projectile, ProjectileModule module)
	{
		if (cones < 3 && Random.value <= 0.1f)
		{
			cones++;
			PickupObject byId = PickupObjectDatabase.GetById(339);
			return ((Gun)((byId is Gun) ? byId : null)).DefaultModule.projectiles[0];
		}
		return ((GunBehaviour)this).OnPreFireProjectileModifier(gun, projectile, module);
	}
}
