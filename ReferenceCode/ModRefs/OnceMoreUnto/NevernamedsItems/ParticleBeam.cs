using System.Collections.Generic;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class ParticleBeam : AdvancedGunBehavior
{
	public static void Add()
	{
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0203: Unknown result type (might be due to invalid IL or missing references)
		//IL_0217: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02de: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fa: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Particle Beam", "particlebeam");
		Game.Items.Rename("outdated_gun_mods:particle_beam", "nn:particle_beam");
		ParticleBeam particleBeam = ((Component)val).gameObject.AddComponent<ParticleBeam>();
		((AdvancedGunBehavior)particleBeam).preventNormalFireAudio = true;
		GunExt.SetShortDescription((PickupObject)(object)val, "Stonefaced");
		GunExt.SetLongDescription((PickupObject)(object)val, "An invisible laser which tears chunks from intersecting walls in the form of superheated shrapnel.\n\nFavoured by Gargoyle Hunters.");
		val.SetGunSprites("particlebeam");
		val.isAudioLoop = true;
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.doesScreenShake = false;
		val.DefaultModule.ammoCost = 15;
		val.DefaultModule.angleVariance = 0f;
		val.DefaultModule.shootStyle = (ShootStyle)2;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		val.DefaultModule.cooldownTime = 0.001f;
		val.DefaultModule.numberOfShotsInClip = -1;
		val.DefaultModule.ammoType = (AmmoType)2;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2f, 0.4375f, 0f);
		val.SetBaseMaxAmmo(1000);
		val.ammo = 1000;
		val.gunClass = (GunClass)20;
		List<string> list = new List<string> { "NevernamedsItems/Resources/BeamSprites/redbeam_seg_001", "NevernamedsItems/Resources/BeamSprites/redbeam_seg_002", "NevernamedsItems/Resources/BeamSprites/redbeam_seg_003", "NevernamedsItems/Resources/BeamSprites/redbeam_seg_004" };
		List<string> list2 = new List<string> { "NevernamedsItems/Resources/BeamSprites/redbeam_impact_001", "NevernamedsItems/Resources/BeamSprites/redbeam_impact_002", "NevernamedsItems/Resources/BeamSprites/redbeam_impact_003", "NevernamedsItems/Resources/BeamSprites/redbeam_impact_004" };
		PickupObject byId2 = PickupObjectDatabase.GetById(86);
		Projectile val2 = ProjectileUtility.InstantiateAndFakeprefab(((Gun)((byId2 is Gun) ? byId2 : null)).DefaultModule.projectiles[0]);
		BasicBeamController val3 = BeamAPI.GenerateBeamPrefab(val2, "NevernamedsItems/Resources/BeamSprites/redbeam_seg_001", new Vector2(18f, 2f), new Vector2(0f, 8f), list, 8, list2, 13, (Vector2?)new Vector2(4f, 4f), (Vector2?)new Vector2(7f, 7f), (List<string>)null, -1, (Vector2?)null, (Vector2?)null, (List<string>)null, -1, (Vector2?)null, (Vector2?)null, 0f, 0f);
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 4f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.range *= 2f;
		val2.baseData.speed = 400f;
		((BraveBehaviour)((BraveBehaviour)val2).sprite).renderer.enabled = false;
		val3.boneType = (BeamBoneType)0;
		val3.interpolateStretchedBones = false;
		val3.ContinueBeamArtToWall = true;
		val3.penetration += 10;
		val3.boneType = (BeamBoneType)2;
		val3.startAudioEvent = "Play_WPN_radiationlaser_shot_01";
		val3.endAudioEvent = "Stop_WPN_All";
		PickupObject byId3 = PickupObjectDatabase.GetById(83);
		Projectile val4 = ProjectileUtility.InstantiateAndFakeprefab(((Gun)((byId3 is Gun) ? byId3 : null)).DefaultModule.projectiles[0]);
		val4.baseData.damage = 2f;
		RandomProjectileStatsComponent randomProjectileStatsComponent = ((Component)val4).gameObject.AddComponent<RandomProjectileStatsComponent>();
		randomProjectileStatsComponent.randomScale = true;
		randomProjectileStatsComponent.randomSpeed = true;
		((Component)val4).gameObject.AddComponent<ProjectileTilemapGracePeriod>();
		ScaleChangeOverTimeModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<ScaleChangeOverTimeModifier>(((Component)val4).gameObject);
		orAddComponent.destroyAfterChange = true;
		orAddComponent.timeToChangeOver = 0.3f;
		orAddComponent.ScaleToChangeTo = 0.01f;
		orAddComponent.suppressDeathFXIfdestroyed = true;
		BeamProjSpewModifier beamProjSpewModifier = ((Component)val2).gameObject.AddComponent<BeamProjSpewModifier>();
		beamProjSpewModifier.bulletToSpew = val4;
		beamProjSpewModifier.tickOnTimer = true;
		beamProjSpewModifier.accuracyVariance = 10f;
		beamProjSpewModifier.angleFromAim = 180f;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = "Y-Beam Laser";
		val.DefaultModule.projectiles[0] = val2;
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
	}
}
