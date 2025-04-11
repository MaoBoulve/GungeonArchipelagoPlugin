using Alexandria.Assetbundle;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Welder : GunBehaviour
{
	public static void Add()
	{
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0310: Unknown result type (might be due to invalid IL or missing references)
		//IL_0326: Unknown result type (might be due to invalid IL or missing references)
		//IL_033c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0350: Unknown result type (might be due to invalid IL or missing references)
		//IL_0364: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0434: Unknown result type (might be due to invalid IL or missing references)
		//IL_04dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_050b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0522: Unknown result type (might be due to invalid IL or missing references)
		//IL_0529: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a0: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Welder", "welder");
		Game.Items.Rename("outdated_gun_mods:welder", "nn:welder");
		Welder welder = ((Component)val).gameObject.AddComponent<Welder>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Big Weld");
		GunExt.SetLongDescription((PickupObject)(object)val, "Designed for competitive long range welding, before the sport was shut down by Hegemony regulations.");
		val.SetGunSprites("welder", 8, noAmmonomicon: false, 2);
		GunExt.SetAnimationFPS(val, val.shootAnimation, 8);
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).wrapMode = (WrapMode)1;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).loopStart = 1;
		val.isAudioLoop = true;
		val.gunClass = (GunClass)20;
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.AddCustomSwitchGroup("nn:EMPTY", "", "");
		val.DefaultModule.angleVariance = 0f;
		val.DefaultModule.ammoCost = 11;
		val.DefaultModule.shootStyle = (ShootStyle)2;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.DefaultModule.cooldownTime = 0.001f;
		val.DefaultModule.numberOfShotsInClip = 400;
		Projectile val2 = ProjectileUtility.SetupProjectile(86);
		val2.SetProjectileSprite("welderbeam_impact_003", 14, 14, lightened: true, (Anchor)4, 6, 6, anchorChangesCollider: true, fixesScale: false, null, null);
		ScaleChangeOverTimeModifier scaleChangeOverTimeModifier = ((Component)val2).gameObject.AddComponent<ScaleChangeOverTimeModifier>();
		scaleChangeOverTimeModifier.destroyAfterChange = true;
		((Object)((Component)val2).gameObject).name = "Welding Spark Projectile";
		ProjectileData baseData = val2.baseData;
		baseData.speed /= 2f;
		scaleChangeOverTimeModifier.ScaleToChangeTo = 0.1f;
		scaleChangeOverTimeModifier.suppressDeathFXIfdestroyed = true;
		scaleChangeOverTimeModifier.timeToChangeOver = 0.25f;
		ProjectileSpriteRotation projectileSpriteRotation = ((Component)val2).gameObject.AddComponent<ProjectileSpriteRotation>();
		projectileSpriteRotation.RotPerFrame = 5f;
		val2.onDestroyEventName = "";
		val2.objectImpactEventName = "";
		Shader shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTiltedCutoutEmissive");
		tk2dSprite component = ((Component)val2).GetComponent<tk2dSprite>();
		if ((Object)(object)component != (Object)null)
		{
			((tk2dBaseSprite)component).usesOverrideMaterial = true;
			((BraveBehaviour)component).renderer.material.shader = shader;
			((BraveBehaviour)component).renderer.material.EnableKeyword("BRIGHTNESS_CLAMP_ON");
			((BraveBehaviour)component).renderer.material.SetFloat("_EmissivePower", 100f);
			((BraveBehaviour)component).renderer.material.SetFloat("_EmissiveColorPower", 100f);
			((BraveBehaviour)component).renderer.material.SetColor("_EmissiveColor", new Color(1f, 0.6313726f, 0f));
		}
		Projectile val3 = ProjectileUtility.SetupProjectile(86);
		tk2dSpriteCollectionData projectileCollection = Initialisation.ProjectileCollection;
		tk2dSpriteAnimation projectileAnimationCollection = Initialisation.projectileAnimationCollection;
		Vector2 val4 = new Vector2(20f, 2f);
		Vector2 val5 = new Vector2(0f, -1f);
		Vector2? val6 = new Vector2(20f, 2f);
		Vector2? val7 = new Vector2(0f, -1f);
		Vector2? val8 = new Vector2(20f, 2f);
		Vector2? val9 = new Vector2(0f, -1f);
		BasicBeamController val10 = BeamBuilders.GenerateAnchoredBeamPrefabBundle(val3, "welderbeam_mid_001", projectileCollection, projectileAnimationCollection, "WelderBeamMid", val4, val5, "WelderBeamImpact", (Vector2?)new Vector2(4f, 4f), (Vector2?)new Vector2(-2f, -2f), "WelderBeamEnd", val8, val9, "WelderBeamStart", val6, val7, false, false, (string)null, (string)null, (string)null, 1f, false, (string)null, (string)null, (string)null, 1f);
		EmmisiveBeams orAddComponent = GameObjectExtensions.GetOrAddComponent<EmmisiveBeams>(((Component)val3).gameObject);
		orAddComponent.EmissivePower = 100f;
		orAddComponent.EmissiveColorPower = 100f;
		orAddComponent.EmissiveColor = new Color(1f, 0.6313726f, 0f);
		((Object)((Component)val3).gameObject).name = "Welder Beam";
		val3.baseData.damage = 15f;
		val3.baseData.force = 20f;
		val3.baseData.range = 7f;
		val3.baseData.speed = 60f;
		val10.boneType = (BeamBoneType)0;
		val10.endAudioEvent = "Stop_WPN_demonhead_loop_01";
		val10.startAudioEvent = "Play_WPN_demonhead_shot_01";
		val10.penetration = 10;
		val10.PenetratesCover = true;
		BeamProjSpewModifier beamProjSpewModifier = ((Component)val3).gameObject.AddComponent<BeamProjSpewModifier>();
		beamProjSpewModifier.tickOnHit = true;
		beamProjSpewModifier.positionToSpawn = BeamProjSpewModifier.SpawnPosition.ENEMY_IMPACT;
		beamProjSpewModifier.accuracyVariance = 360f;
		beamProjSpewModifier.bulletToSpew = val2;
		val.Volley.projectiles[0].projectiles[0] = val3;
		ref ScreenShakeSettings gunScreenShake = ref val.gunScreenShake;
		PickupObject byId2 = PickupObjectDatabase.GetById(60);
		gunScreenShake = ((Gun)((byId2 is Gun) ? byId2 : null)).gunScreenShake;
		val.reloadTime = 1.25f;
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		val.SetBarrel(30, 14);
		val.SetBaseMaxAmmo(900);
		val.ammo = 900;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = "Y-Beam Laser";
		val.gunHandedness = (GunHandedness)1;
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
	}
}
