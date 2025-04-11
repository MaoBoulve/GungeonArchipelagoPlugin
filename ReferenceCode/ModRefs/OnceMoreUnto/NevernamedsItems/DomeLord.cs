using System.Collections.Generic;
using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class DomeLord : GunBehaviour
{
	public static string IdleSOUTH;

	public static string IdleSE;

	public static string IdleEAST;

	public static string IdleNE;

	public static string IdleNORTH;

	public static string IdleNW;

	public static string IdleWEST;

	public static string IdleSW;

	public static string FireSOUTH;

	public static string FireSE;

	public static string FireEAST;

	public static string FireNE;

	public static string FireNORTH;

	public static string FireNW;

	public static string FireWEST;

	public static string FireSW;

	public static void Add()
	{
		//IL_02a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0307: Unknown result type (might be due to invalid IL or missing references)
		//IL_0318: Unknown result type (might be due to invalid IL or missing references)
		//IL_0329: Unknown result type (might be due to invalid IL or missing references)
		//IL_034e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0353: Unknown result type (might be due to invalid IL or missing references)
		//IL_035c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0361: Unknown result type (might be due to invalid IL or missing references)
		//IL_037f: Unknown result type (might be due to invalid IL or missing references)
		//IL_039b: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b4: Expected O, but got Unknown
		//IL_03b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_042a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0431: Expected O, but got Unknown
		//IL_043f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0446: Expected O, but got Unknown
		//IL_0456: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0530: Unknown result type (might be due to invalid IL or missing references)
		//IL_053c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0586: Unknown result type (might be due to invalid IL or missing references)
		//IL_0595: Unknown result type (might be due to invalid IL or missing references)
		//IL_062a: Unknown result type (might be due to invalid IL or missing references)
		//IL_062f: Unknown result type (might be due to invalid IL or missing references)
		//IL_069a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0750: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0804: Unknown result type (might be due to invalid IL or missing references)
		//IL_080b: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Dome Lord", "domelord");
		Game.Items.Rename("outdated_gun_mods:dome_lord", "nn:dome_lord");
		DomeLord domeLord = ((Component)val).gameObject.AddComponent<DomeLord>();
		GunExt.SetShortDescription((PickupObject)(object)val, "King of the Hill");
		GunExt.SetLongDescription((PickupObject)(object)val, "A new lord to rule over your listless dome!\n\nDiminutive spawn of the elusive parriarch of portals, earl of entryways, the Lord of Doors.");
		val.SetGunSprites("domelord", 8, noAmmonomicon: false, 2);
		IdleSOUTH = GunExt.UpdateAnimation(val, "idleSOUTH", Initialisation.gunCollection2, false);
		IdleSE = GunExt.UpdateAnimation(val, "idleSE", Initialisation.gunCollection2, false);
		IdleEAST = GunExt.UpdateAnimation(val, "idleEAST", Initialisation.gunCollection2, false);
		IdleNE = GunExt.UpdateAnimation(val, "idleNE", Initialisation.gunCollection2, false);
		IdleNORTH = GunExt.UpdateAnimation(val, "idleNORTH", Initialisation.gunCollection2, false);
		IdleNW = GunExt.UpdateAnimation(val, "idleNW", Initialisation.gunCollection2, false);
		IdleWEST = GunExt.UpdateAnimation(val, "idleWEST", Initialisation.gunCollection2, false);
		IdleSW = GunExt.UpdateAnimation(val, "idleSW", Initialisation.gunCollection2, false);
		GunExt.SetAnimationFPS(val, IdleSOUTH, 8);
		GunExt.SetAnimationFPS(val, IdleSE, 8);
		GunExt.SetAnimationFPS(val, IdleEAST, 8);
		GunExt.SetAnimationFPS(val, IdleNE, 8);
		GunExt.SetAnimationFPS(val, IdleNORTH, 8);
		GunExt.SetAnimationFPS(val, IdleNW, 8);
		GunExt.SetAnimationFPS(val, IdleWEST, 8);
		GunExt.SetAnimationFPS(val, IdleSW, 8);
		FireSOUTH = GunExt.UpdateAnimation(val, "fireSOUTH", Initialisation.gunCollection2, false);
		FireSE = GunExt.UpdateAnimation(val, "fireSE", Initialisation.gunCollection2, false);
		FireEAST = GunExt.UpdateAnimation(val, "fireEAST", Initialisation.gunCollection2, false);
		FireNE = GunExt.UpdateAnimation(val, "fireNE", Initialisation.gunCollection2, false);
		FireNORTH = GunExt.UpdateAnimation(val, "fireNORTH", Initialisation.gunCollection2, false);
		FireNW = GunExt.UpdateAnimation(val, "fireNW", Initialisation.gunCollection2, false);
		FireWEST = GunExt.UpdateAnimation(val, "fireWEST", Initialisation.gunCollection2, false);
		FireSW = GunExt.UpdateAnimation(val, "fireSW", Initialisation.gunCollection2, false);
		GunExt.SetAnimationFPS(val, FireSOUTH, 8);
		GunExt.SetAnimationFPS(val, FireSE, 8);
		GunExt.SetAnimationFPS(val, FireEAST, 8);
		GunExt.SetAnimationFPS(val, FireNE, 8);
		GunExt.SetAnimationFPS(val, FireNORTH, 8);
		GunExt.SetAnimationFPS(val, FireNW, 8);
		GunExt.SetAnimationFPS(val, FireWEST, 8);
		GunExt.SetAnimationFPS(val, FireSW, 8);
		tk2dSpriteAnimator component = ((Component)val).GetComponent<tk2dSpriteAnimator>();
		component.GetClipByName(FireSOUTH).wrapMode = (WrapMode)0;
		component.GetClipByName(FireSE).wrapMode = (WrapMode)0;
		component.GetClipByName(FireEAST).wrapMode = (WrapMode)0;
		component.GetClipByName(FireNE).wrapMode = (WrapMode)0;
		component.GetClipByName(FireNORTH).wrapMode = (WrapMode)0;
		component.GetClipByName(FireNW).wrapMode = (WrapMode)0;
		component.GetClipByName(FireWEST).wrapMode = (WrapMode)0;
		component.GetClipByName(FireSW).wrapMode = (WrapMode)0;
		component.GetClipByName(FireSW).wrapMode = (WrapMode)0;
		val.usesContinuousFireAnimation = true;
		val.usesContinuousMuzzleFlash = true;
		val.usesDirectionalAnimator = true;
		val.preventRotation = true;
		val.carryPixelOffset = new IntVector2(8, 15);
		val.leftFacingPixelOffset = new IntVector2(-5, 0);
		val.IgnoresAngleQuantization = true;
		val.muzzleFlashEffects = VFXToolbox.CreateVFXPoolBundle("DomeLordMuzzle", usesZHeight: false, 0f, (VFXAlignment)0, 50f, Color.red);
		val.muzzleFlashEffects.type = (VFXPoolType)1;
		AIAnimator orAddComponent = GameObjectExtensions.GetOrAddComponent<AIAnimator>(((Component)val).gameObject);
		DirectionalAnimation val2 = new DirectionalAnimation();
		val2.Type = (DirectionType)10;
		val2.Prefix = "domelord_idle";
		val2.AnimNames = new string[8] { IdleNORTH, IdleNE, IdleEAST, IdleSE, IdleSOUTH, IdleSW, IdleWEST, IdleNW };
		val2.Flipped = (FlipType[])(object)new FlipType[8];
		orAddComponent.IdleAnimation = val2;
		NamedDirectionalAnimation val3 = new NamedDirectionalAnimation();
		val3.name = "domelord_fire";
		val2 = new DirectionalAnimation();
		val2.Prefix = string.Empty;
		val2.Type = (DirectionType)10;
		val2.Flipped = (FlipType[])(object)new FlipType[8];
		val2.AnimNames = new string[8] { FireNORTH, FireNE, FireEAST, FireSE, FireSOUTH, FireSW, FireWEST, FireNW };
		val3.anim = val2;
		NamedDirectionalAnimation item = val3;
		if (orAddComponent.OtherAnimations == null)
		{
			orAddComponent.OtherAnimations = new List<NamedDirectionalAnimation>();
		}
		orAddComponent.OtherAnimations.Add(item);
		val.isAudioLoop = true;
		val.gunClass = (GunClass)20;
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.angleVariance = 0f;
		val.DefaultModule.ammoCost = 11;
		val.DefaultModule.shootStyle = (ShootStyle)2;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.DefaultModule.cooldownTime = 0.001f;
		val.DefaultModule.numberOfShotsInClip = -1;
		Projectile val4 = ProjectileUtility.SetupProjectile(86);
		BasicBeamController val5 = BeamBuilders.GenerateAnchoredBeamPrefabBundle(val4, "domelordbeam_mid_001", Initialisation.ProjectileCollection, Initialisation.projectileAnimationCollection, "DomeLordBeamMid", new Vector2(4f, 2f), new Vector2(0f, -1f), (string)null, (Vector2?)null, (Vector2?)null, (string)null, (Vector2?)null, (Vector2?)null, (string)null, (Vector2?)null, (Vector2?)null, false, false, (string)null, (string)null, (string)null, 1f, false, (string)null, (string)null, (string)null, 1f);
		EmmisiveBeams orAddComponent2 = GameObjectExtensions.GetOrAddComponent<EmmisiveBeams>(((Component)val4).gameObject);
		orAddComponent2.EmissivePower = 50f;
		orAddComponent2.EmissiveColorPower = 50f;
		orAddComponent2.EmissiveColor = new Color(1f, 0.6313726f, 0f);
		val5.HeightOffset = 10f;
		((Object)((Component)val4).gameObject).name = "Dome Lord Beam";
		val4.baseData.damage = 25f;
		val4.baseData.force = 10f;
		val4.baseData.range = 9f;
		val4.baseData.speed = float.MaxValue;
		val5.boneType = (BeamBoneType)0;
		val5.endAudioEvent = "Stop_WPN_radiationlaser_loop_01";
		val5.startAudioEvent = "Play_WPN_radiationlaser_shot_01";
		val5.penetration = 10;
		val5.PenetratesCover = true;
		GoopModifier val6 = ((Component)val4).gameObject.AddComponent<GoopModifier>();
		val6.SpawnAtBeamEnd = true;
		val6.SpawnGoopOnCollision = true;
		val6.BeamEndRadius = 0.5f;
		val6.CollisionSpawnRadius = 0.25f;
		val6.goopDefinition = GoopUtility.FireDef;
		OscillatingProjectileModifier oscillatingProjectileModifier = ((Component)val4).gameObject.AddComponent<OscillatingProjectileModifier>();
		oscillatingProjectileModifier.multiplyRange = true;
		((Component)val4).gameObject.AddComponent<BeamAttachVFXToEnd>().VFX = VFXToolbox.CreateVFXBundle("DomeLordEndVFX", usesZHeight: true, 0.18f, 5f, 10f, (Color?)new Color(1f, 0f, 0f), persist: false, Initialisation.ProjectileCollection);
		val.DefaultModule.projectiles[0] = val4;
		val.gunSwitchGroup = "nn:EMPTY";
		ref ScreenShakeSettings gunScreenShake = ref val.gunScreenShake;
		PickupObject byId2 = PickupObjectDatabase.GetById(60);
		gunScreenShake = ((Gun)((byId2 is Gun) ? byId2 : null)).gunScreenShake;
		val.reloadTime = 1.25f;
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		val.SetBarrel(6, 11);
		val.SetBaseMaxAmmo(900);
		val.ammo = 900;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = "Y-Beam Laser";
		ItemBuilder.AddCurrentGunDamageTypeModifier(val, (CoreDamageTypes)4, 0f);
		val.gunHandedness = (GunHandedness)4;
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		((PickupObject)(object)val).SetupUnlockOnCustomStat(CustomTrackedStats.DOOR_LORD_KILLS, 0f, (PrerequisiteOperation)2);
	}
}
