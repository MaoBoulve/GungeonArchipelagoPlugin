using System.Collections.Generic;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class HeatRay : AdvancedGunBehavior
{
	public static int HeatRayID;

	public static void Add()
	{
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_024a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0259: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0282: Unknown result type (might be due to invalid IL or missing references)
		//IL_0325: Unknown result type (might be due to invalid IL or missing references)
		//IL_0392: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a9: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Heat Ray", "heatray");
		Game.Items.Rename("outdated_gun_mods:heat_ray", "nn:heat_ray");
		HeatRay heatRay = ((Component)val).gameObject.AddComponent<HeatRay>();
		((AdvancedGunBehavior)heatRay).overrideNormalFireAudio = "Play_ENM_shelleton_beam_01";
		((AdvancedGunBehavior)heatRay).preventNormalFireAudio = true;
		GunExt.SetShortDescription((PickupObject)(object)val, "Set to Defrost");
		GunExt.SetLongDescription((PickupObject)(object)val, "An old weaponised heating coil, will burn enemies it's focused on for long enough.");
		val.SetGunSprites("heatray");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 8);
		val.isAudioLoop = true;
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.doesScreenShake = false;
		val.DefaultModule.ammoCost = 30;
		val.DefaultModule.shootStyle = (ShootStyle)2;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		val.DefaultModule.cooldownTime = 0.001f;
		val.DefaultModule.numberOfShotsInClip = 3500;
		val.DefaultModule.ammoType = (AmmoType)2;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.06f, 0.31f, 0f);
		val.SetBaseMaxAmmo(3500);
		val.ammo = 3500;
		val.gunClass = (GunClass)55;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).wrapMode = (WrapMode)0;
		List<string> list = new List<string> { "NevernamedsItems/Resources/BeamSprites/heatray_seg_001", "NevernamedsItems/Resources/BeamSprites/heatray_seg_002", "NevernamedsItems/Resources/BeamSprites/heatray_seg_003", "NevernamedsItems/Resources/BeamSprites/heatray_seg_004", "NevernamedsItems/Resources/BeamSprites/heatray_seg_005", "NevernamedsItems/Resources/BeamSprites/heatray_seg_006", "NevernamedsItems/Resources/BeamSprites/heatray_seg_007", "NevernamedsItems/Resources/BeamSprites/heatray_seg_008" };
		List<string> list2 = new List<string> { "NevernamedsItems/Resources/BeamSprites/heatray_impact_001", "NevernamedsItems/Resources/BeamSprites/heatray_impact_002", "NevernamedsItems/Resources/BeamSprites/heatray_impact_003", "NevernamedsItems/Resources/BeamSprites/heatray_impact_004", "NevernamedsItems/Resources/BeamSprites/heatray_impact_005", "NevernamedsItems/Resources/BeamSprites/heatray_impact_006", "NevernamedsItems/Resources/BeamSprites/heatray_impact_007", "NevernamedsItems/Resources/BeamSprites/heatray_impact_008" };
		Projectile val2 = ProjectileUtility.SetupProjectile(86);
		BasicBeamController val3 = BeamAPI.GenerateBeamPrefab(val2, "NevernamedsItems/Resources/BeamSprites/heatray_seg_001", new Vector2(10f, 2f), new Vector2(0f, 3f), list, 16, list2, 20, (Vector2?)new Vector2(6f, 6f), (Vector2?)new Vector2(2f, 4f), (List<string>)null, -1, (Vector2?)null, (Vector2?)null, (List<string>)null, -1, (Vector2?)null, (Vector2?)null, 0f, 0f);
		val2.baseData.damage = 16f;
		ProjectileData baseData = val2.baseData;
		baseData.force *= 0.1f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.range *= 2f;
		ProjectileData baseData3 = val2.baseData;
		baseData3.speed *= 0.7f;
		val3.boneType = (BeamBoneType)2;
		val3.interpolateStretchedBones = false;
		val3.startAudioEvent = "Play_WPN_radiationlaser_shot_01";
		val3.endAudioEvent = "Stop_WPN_All";
		val2.AppliesFire = true;
		val2.fireEffect = StaticStatusEffects.hotLeadEffect;
		((BeamController)val3).statusEffectChance = 0.5f;
		val3.TimeToStatus = 1f;
		val.DefaultModule.projectiles[0] = val2;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = "Y-Beam Laser";
		((PickupObject)val).quality = (ItemQuality)1;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		HeatRayID = ((PickupObject)val).PickupObjectId;
	}

	protected override void PostProcessBeam(BeamController beam)
	{
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)beam) && Object.op_Implicit((Object)(object)((BraveBehaviour)beam).projectile) && Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(((BraveBehaviour)beam).projectile)))
		{
			if (CustomSynergies.PlayerHasActiveSynergy(ProjectileUtility.ProjectilePlayerOwner(((BraveBehaviour)beam).projectile), "It won't actually show up on screen, but there's no hard limit on how long you can make synergy names."))
			{
				beam.AdjustPlayerBeamTint(Color.green, 1, 0f);
				((BraveBehaviour)beam).projectile.fireEffect = StaticStatusEffects.greenFireEffect;
			}
			if (CustomSynergies.PlayerHasActiveSynergy(ProjectileUtility.ProjectilePlayerOwner(((BraveBehaviour)beam).projectile), "Re-Heat"))
			{
				((Component)beam).GetComponent<BasicBeamController>().TimeToStatus = 0.1f;
				((BeamController)((Component)beam).GetComponent<BasicBeamController>()).statusEffectChance = 1f;
			}
			if (CustomSynergies.PlayerHasActiveSynergy(ProjectileUtility.ProjectilePlayerOwner(((BraveBehaviour)beam).projectile), "Don't Trust The Toaster"))
			{
				ProjectileData baseData = ((BraveBehaviour)beam).projectile.baseData;
				baseData.speed *= 5f;
				((BraveBehaviour)beam).projectile.UpdateSpeed();
				((BraveBehaviour)beam).projectile.RuntimeUpdateScale(1.3f);
				ProjectileData baseData2 = ((BraveBehaviour)beam).projectile.baseData;
				baseData2.damage *= 2f;
				EmmisiveBeams orAddComponent = GameObjectExtensions.GetOrAddComponent<EmmisiveBeams>(((Component)((BraveBehaviour)beam).projectile).gameObject);
			}
		}
		((AdvancedGunBehavior)this).PostProcessBeam(beam);
	}
}
