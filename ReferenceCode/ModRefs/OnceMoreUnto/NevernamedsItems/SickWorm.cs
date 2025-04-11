using System.Collections.Generic;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class SickWorm : AdvancedGunBehavior
{
	public static void Add()
	{
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_020d: Unknown result type (might be due to invalid IL or missing references)
		//IL_029b: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d7: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Sick Worm", "sickworm");
		Game.Items.Rename("outdated_gun_mods:sick_worm", "nn:sick_worm");
		SickWorm sickWorm = ((Component)val).gameObject.AddComponent<SickWorm>();
		((AdvancedGunBehavior)sickWorm).preventNormalFireAudio = true;
		GunExt.SetShortDescription((PickupObject)(object)val, "Projectile Vomit");
		GunExt.SetLongDescription((PickupObject)(object)val, "A rare example of Gungeon Gigantism, this worm has developed a remarkable evolutionary defence mechanism; regurgitating high-speed digestive juices at potential predators.");
		val.SetGunSprites("sickworm");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 16);
		val.isAudioLoop = true;
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.doesScreenShake = false;
		val.DefaultModule.ammoCost = 10;
		val.DefaultModule.angleVariance = 0f;
		val.DefaultModule.shootStyle = (ShootStyle)2;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		val.DefaultModule.cooldownTime = 0.001f;
		val.DefaultModule.numberOfShotsInClip = 2000;
		val.DefaultModule.ammoType = (AmmoType)2;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.06f, 0.62f, 0f);
		val.SetBaseMaxAmmo(2000);
		val.ammo = 2000;
		val.gunClass = (GunClass)50;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).wrapMode = (WrapMode)1;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).loopStart = 1;
		List<string> list = new List<string> { "NevernamedsItems/Resources/BeamSprites/sickworm_mid_001" };
		List<string> list2 = new List<string> { "NevernamedsItems/Resources/BeamSprites/sickworm_end_001" };
		Projectile val2 = ProjectileUtility.SetupProjectile(86);
		BasicBeamController val3 = BeamAPI.GenerateBeamPrefab(val2, "NevernamedsItems/Resources/BeamSprites/sickworm_mid_001", new Vector2(8f, 8f), new Vector2(0f, 1f), list, 9, (List<string>)null, -1, (Vector2?)null, (Vector2?)null, list2, 9, (Vector2?)new Vector2(8f, 8f), (Vector2?)new Vector2(0f, 1f), (List<string>)null, -1, (Vector2?)null, (Vector2?)null, 0f, 0f);
		val2.baseData.damage = 30f;
		ProjectileData baseData = val2.baseData;
		baseData.force *= 1f;
		val2.baseData.range = 7f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.speed *= 0.7f;
		val3.penetration = 2;
		val3.boneType = (BeamBoneType)2;
		val3.interpolateStretchedBones = false;
		val3.endAudioEvent = "Stop_WPN_All";
		val3.startAudioEvent = "Play_WPN_SeriousCannon_Scream_01";
		PickupObject byId2 = PickupObjectDatabase.GetById(86);
		Projectile val4 = Object.Instantiate<Projectile>(((Gun)((byId2 is Gun) ? byId2 : null)).DefaultModule.projectiles[0]);
		((Component)val4).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val4).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val4);
		val4.SetProjectileSprite("sickworm_projectile", 5, 5, lightened: false, (Anchor)4, 3, 3, anchorChangesCollider: true, fixesScale: false, null, null);
		val4.baseData.damage = 2f;
		RandomProjectileStatsComponent randomProjectileStatsComponent = ((Component)val4).gameObject.AddComponent<RandomProjectileStatsComponent>();
		randomProjectileStatsComponent.randomScale = true;
		randomProjectileStatsComponent.randomSpeed = true;
		BeamProjSpewModifier beamProjSpewModifier = ((Component)val2).gameObject.AddComponent<BeamProjSpewModifier>();
		beamProjSpewModifier.bulletToSpew = val4;
		beamProjSpewModifier.accuracyVariance = 5f;
		beamProjSpewModifier.tickOnTimer = true;
		val.DefaultModule.projectiles[0] = val2;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("SickWorm Clip", "NevernamedsItems/Resources/CustomGunAmmoTypes/sickworm_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/sickworm_clipempty");
		((PickupObject)val).quality = (ItemQuality)4;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
	}
}
