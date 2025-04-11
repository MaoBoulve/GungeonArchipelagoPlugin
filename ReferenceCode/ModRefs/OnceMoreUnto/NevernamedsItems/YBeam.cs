using System.Collections.Generic;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class YBeam : AdvancedGunBehavior
{
	public static void Add()
	{
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_0298: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_040c: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Y-Beam", "ybeam");
		Game.Items.Rename("outdated_gun_mods:ybeam", "nn:y_beam");
		YBeam yBeam = ((Component)val).gameObject.AddComponent<YBeam>();
		((AdvancedGunBehavior)yBeam).preventNormalFireAudio = true;
		GunExt.SetShortDescription((PickupObject)(object)val, "Energy Fissure");
		GunExt.SetLongDescription((PickupObject)(object)val, "The ion-plate in this powerful anti-air laser is faulty, causing the fired beam to delaminate after travelling a certain distance.\n\nThe unregulated energy state of the bifurcated segments causes them to do much more damage to combatant targets than the singular beam.");
		val.SetGunSprites("ybeam");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 20);
		val.isAudioLoop = true;
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.doesScreenShake = false;
		val.DefaultModule.ammoCost = 8;
		val.DefaultModule.shootStyle = (ShootStyle)2;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		val.DefaultModule.cooldownTime = 0.001f;
		val.DefaultModule.numberOfShotsInClip = 2000;
		val.DefaultModule.ammoType = (AmmoType)2;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.93f, 0.31f, 0f);
		val.SetBaseMaxAmmo(1000);
		val.ammo = 1000;
		val.gunClass = (GunClass)20;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).wrapMode = (WrapMode)1;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).loopStart = 1;
		List<string> list = new List<string> { "NevernamedsItems/Resources/BeamSprites/ybeam_mid_001", "NevernamedsItems/Resources/BeamSprites/ybeam_mid_002", "NevernamedsItems/Resources/BeamSprites/ybeam_mid_003", "NevernamedsItems/Resources/BeamSprites/ybeam_mid_004", "NevernamedsItems/Resources/BeamSprites/ybeam_mid_005" };
		List<string> list2 = new List<string> { "NevernamedsItems/Resources/BeamSprites/ybeam_start_001", "NevernamedsItems/Resources/BeamSprites/ybeam_start_002", "NevernamedsItems/Resources/BeamSprites/ybeam_start_003", "NevernamedsItems/Resources/BeamSprites/ybeam_start_004", "NevernamedsItems/Resources/BeamSprites/ybeam_start_005" };
		List<string> list3 = new List<string> { "NevernamedsItems/Resources/BeamSprites/ybeam_impact_001", "NevernamedsItems/Resources/BeamSprites/ybeam_impact_002", "NevernamedsItems/Resources/BeamSprites/ybeam_impact_003", "NevernamedsItems/Resources/BeamSprites/ybeam_impact_004" };
		PickupObject byId2 = PickupObjectDatabase.GetById(86);
		Projectile val2 = Object.Instantiate<Projectile>(((Gun)((byId2 is Gun) ? byId2 : null)).DefaultModule.projectiles[0]);
		BasicBeamController val3 = BeamAPI.GenerateBeamPrefab(val2, "NevernamedsItems/Resources/BeamSprites/ybeam_mid_001", new Vector2(9f, 9f), new Vector2(0f, 1f), list, 13, list3, 13, (Vector2?)new Vector2(3f, 3f), (Vector2?)new Vector2(5f, 5f), (List<string>)null, -1, (Vector2?)null, (Vector2?)null, list2, 13, (Vector2?)new Vector2(9f, 9f), (Vector2?)new Vector2(0f, 1f), 100f, 0f);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val2.baseData.damage = 25f;
		ProjectileData baseData = val2.baseData;
		baseData.force *= 1f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.range *= 200f;
		ProjectileData baseData3 = val2.baseData;
		baseData3.speed *= 6f;
		BeamSplittingModifier beamSplittingModifier = ((Component)val2).gameObject.AddComponent<BeamSplittingModifier>();
		beamSplittingModifier.dmgMultOnSplit = 2f;
		beamSplittingModifier.distanceTilSplit = 6f;
		beamSplittingModifier.amtToSplitTo = 2;
		beamSplittingModifier.splitAngles = 45f;
		val3.boneType = (BeamBoneType)2;
		val3.startAudioEvent = "Play_WPN_radiationlaser_shot_01";
		val3.endAudioEvent = "Stop_WPN_All";
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Y-Beam Laser", "NevernamedsItems/Resources/CustomGunAmmoTypes/ybeam_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/genericbeam_clipempty");
		val.DefaultModule.projectiles[0] = val2;
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
	}

	protected override void PostProcessBeam(BeamController beam)
	{
		if (Object.op_Implicit((Object)(object)((BraveBehaviour)beam).projectile) && Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(((BraveBehaviour)beam).projectile)) && CustomSynergies.PlayerHasActiveSynergy(ProjectileUtility.ProjectilePlayerOwner(((BraveBehaviour)beam).projectile), "Centerfold"))
		{
			ProjectileData baseData = ((BraveBehaviour)beam).projectile.baseData;
			baseData.damage *= 0.6f;
			if (Object.op_Implicit((Object)(object)((Component)beam).GetComponent<BeamSplittingModifier>()))
			{
				((Component)beam).GetComponent<BeamSplittingModifier>().amtToSplitTo++;
			}
		}
		((AdvancedGunBehavior)this).PostProcessBeam(beam);
	}
}
