using System.Collections.Generic;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class BoomBeam : AdvancedGunBehavior
{
	public static int ID;

	public static void Add()
	{
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_023d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		//IL_0267: Unknown result type (might be due to invalid IL or missing references)
		//IL_0294: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0370: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cf: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Boom Beam", "boombeam");
		Game.Items.Rename("outdated_gun_mods:boom_beam", "nn:boom_beam");
		BoomBeam boomBeam = ((Component)val).gameObject.AddComponent<BoomBeam>();
		((AdvancedGunBehavior)boomBeam).preventNormalFireAudio = true;
		GunExt.SetShortDescription((PickupObject)(object)val, "Explosive Transmission");
		GunExt.SetLongDescription((PickupObject)(object)val, "A high-tech military laser packed with so much energy that it causes violent explosions when impeded.\n\nThe laser went through five stages of R&D until it's beam was glowy enough.");
		val.SetGunSprites("boombeam");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 20);
		val.isAudioLoop = true;
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.doesScreenShake = false;
		val.DefaultModule.ammoCost = 15;
		val.DefaultModule.shootStyle = (ShootStyle)2;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		val.DefaultModule.cooldownTime = 0.001f;
		val.DefaultModule.numberOfShotsInClip = 600;
		val.DefaultModule.ammoType = (AmmoType)2;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.62f, 0.53f, 0f);
		val.SetBaseMaxAmmo(600);
		val.ammo = 600;
		val.gunClass = (GunClass)45;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).wrapMode = (WrapMode)1;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).loopStart = 1;
		List<string> list = new List<string> { "NevernamedsItems/Resources/BeamSprites/largeredbeam_mid_001", "NevernamedsItems/Resources/BeamSprites/largeredbeam_mid_002", "NevernamedsItems/Resources/BeamSprites/largeredbeam_mid_003", "NevernamedsItems/Resources/BeamSprites/largeredbeam_mid_004" };
		List<string> list2 = new List<string> { "NevernamedsItems/Resources/BeamSprites/largeredbeam_start_001", "NevernamedsItems/Resources/BeamSprites/largeredbeam_start_002", "NevernamedsItems/Resources/BeamSprites/largeredbeam_start_003", "NevernamedsItems/Resources/BeamSprites/largeredbeam_start_004" };
		List<string> list3 = new List<string> { "NevernamedsItems/Resources/BeamSprites/largeredbeam_impact_001", "NevernamedsItems/Resources/BeamSprites/largeredbeam_impact_002", "NevernamedsItems/Resources/BeamSprites/largeredbeam_impact_003", "NevernamedsItems/Resources/BeamSprites/largeredbeam_impact_004" };
		Projectile val2 = ProjectileUtility.SetupProjectile(86);
		BasicBeamController val3 = BeamAPI.GenerateBeamPrefab(val2, "NevernamedsItems/Resources/BeamSprites/largeredbeam_mid_001", new Vector2(16f, 5f), new Vector2(0f, 6f), list, 13, list3, 13, (Vector2?)new Vector2(6f, 6f), (Vector2?)new Vector2(8f, 8f), (List<string>)null, -1, (Vector2?)null, (Vector2?)null, list2, 13, (Vector2?)new Vector2(16f, 5f), (Vector2?)new Vector2(0f, 6f), 100f, 0f);
		val2.baseData.damage = 30f;
		ProjectileData baseData = val2.baseData;
		baseData.force *= 1f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.range *= 200f;
		ProjectileData baseData3 = val2.baseData;
		baseData3.speed *= 6f;
		BeamExplosiveModifier beamExplosiveModifier = ((Component)val2).gameObject.AddComponent<BeamExplosiveModifier>();
		beamExplosiveModifier.canHarmOwner = false;
		beamExplosiveModifier.chancePerTick = 1f;
		beamExplosiveModifier.explosionData = GameManager.Instance.Dungeon.sharedSettingsPrefab.DefaultExplosionData;
		beamExplosiveModifier.ignoreQueues = true;
		beamExplosiveModifier.tickDelay = 0.5f;
		val3.boneType = (BeamBoneType)2;
		val3.startAudioEvent = "Play_WPN_radiationlaser_shot_01";
		val3.endAudioEvent = "Stop_WPN_All";
		val.DefaultModule.projectiles[0] = val2;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("BoomBeam Laser", "NevernamedsItems/Resources/CustomGunAmmoTypes/boombeam_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/boombeam_clipempty");
		((PickupObject)val).quality = (ItemQuality)5;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
	}
}
