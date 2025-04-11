using System.Collections.Generic;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class AlphaBeam : AdvancedGunBehavior
{
	public static void Add()
	{
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_0260: Unknown result type (might be due to invalid IL or missing references)
		//IL_026f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0285: Unknown result type (might be due to invalid IL or missing references)
		//IL_0299: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0367: Unknown result type (might be due to invalid IL or missing references)
		//IL_03aa: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Alpha Beam", "alphabeam");
		Game.Items.Rename("outdated_gun_mods:alpha_beam", "nn:alpha_beam");
		AlphaBeam alphaBeam = ((Component)val).gameObject.AddComponent<AlphaBeam>();
		((AdvancedGunBehavior)alphaBeam).preventNormalFireAudio = true;
		GunExt.SetShortDescription((PickupObject)(object)val, "Ancient Tech");
		GunExt.SetLongDescription((PickupObject)(object)val, "A powerful ion-beam that stings like hell.\n\nEvidence suggests this may be the first energy beam to ever find it's way to the Gungeon.");
		val.SetGunSprites("alphabeam");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 20);
		val.isAudioLoop = true;
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.doesScreenShake = false;
		val.DefaultModule.ammoCost = 5;
		val.DefaultModule.shootStyle = (ShootStyle)2;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		val.DefaultModule.cooldownTime = 0.001f;
		val.DefaultModule.numberOfShotsInClip = -1;
		val.DefaultModule.ammoType = (AmmoType)2;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.75f, 0.43f, 0f);
		val.SetBaseMaxAmmo(600);
		val.ammo = 600;
		val.gunClass = (GunClass)20;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).wrapMode = (WrapMode)1;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).loopStart = 1;
		List<string> list = new List<string> { "NevernamedsItems/Resources/BeamSprites/alphabeam_mid_001", "NevernamedsItems/Resources/BeamSprites/alphabeam_mid_002", "NevernamedsItems/Resources/BeamSprites/alphabeam_mid_003", "NevernamedsItems/Resources/BeamSprites/alphabeam_mid_004" };
		List<string> list2 = new List<string> { "NevernamedsItems/Resources/BeamSprites/alphabeam_start_001", "NevernamedsItems/Resources/BeamSprites/alphabeam_start_002", "NevernamedsItems/Resources/BeamSprites/alphabeam_start_003", "NevernamedsItems/Resources/BeamSprites/alphabeam_start_004" };
		List<string> list3 = new List<string> { "NevernamedsItems/Resources/BeamSprites/alphabeam_end_001", "NevernamedsItems/Resources/BeamSprites/alphabeam_end_002", "NevernamedsItems/Resources/BeamSprites/alphabeam_end_003", "NevernamedsItems/Resources/BeamSprites/alphabeam_end_004" };
		List<string> list4 = new List<string> { "NevernamedsItems/Resources/BeamSprites/alphabeam_impact_001", "NevernamedsItems/Resources/BeamSprites/alphabeam_impact_002", "NevernamedsItems/Resources/BeamSprites/alphabeam_impact_003", "NevernamedsItems/Resources/BeamSprites/alphabeam_impact_004" };
		Projectile val2 = ProjectileUtility.SetupProjectile(86);
		BasicBeamController val3 = BeamAPI.GenerateBeamPrefab(val2, "NevernamedsItems/Resources/BeamSprites/alphabeam_mid_001", new Vector2(15f, 7f), new Vector2(0f, 4f), list, 13, list4, 13, (Vector2?)new Vector2(7f, 7f), (Vector2?)new Vector2(4f, 4f), list3, 13, (Vector2?)new Vector2(15f, 7f), (Vector2?)new Vector2(0f, 4f), list2, 13, (Vector2?)new Vector2(15f, 7f), (Vector2?)new Vector2(0f, 4f), 100f, 0f);
		val2.baseData.damage = 70f;
		ProjectileData baseData = val2.baseData;
		baseData.force *= 20f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.range *= 200f;
		ProjectileData baseData3 = val2.baseData;
		baseData3.speed *= 4f;
		val3.boneType = (BeamBoneType)2;
		val3.startAudioEvent = "Play_WPN_radiationlaser_shot_01";
		val3.endAudioEvent = "Stop_WPN_All";
		val3.penetration += 100;
		val.DefaultModule.projectiles[0] = val2;
		((PickupObject)val).quality = (ItemQuality)4;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
	}

	protected override void PostProcessBeam(BeamController beam)
	{
		if (Object.op_Implicit((Object)(object)beam) && Object.op_Implicit((Object)(object)((BraveBehaviour)beam).projectile) && Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(((BraveBehaviour)beam).projectile)) && CustomSynergies.PlayerHasActiveSynergy(ProjectileUtility.ProjectilePlayerOwner(((BraveBehaviour)beam).projectile), "Absolute Radiance"))
		{
			BeamSplittingModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<BeamSplittingModifier>(((Component)beam).gameObject);
			orAddComponent.dmgMultOnSplit = 0.25f;
			orAddComponent.amtToSplitTo += 10;
			orAddComponent.distanceTilSplit = 1f;
			orAddComponent.splitAngles = 90f;
		}
		((AdvancedGunBehavior)this).PostProcessBeam(beam);
	}
}
