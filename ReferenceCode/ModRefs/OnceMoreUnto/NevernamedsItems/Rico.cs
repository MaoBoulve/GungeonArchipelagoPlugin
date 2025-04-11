using System.Collections.Generic;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Rico : AdvancedGunBehavior
{
	public static int RicoID;

	public static void Add()
	{
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0241: Unknown result type (might be due to invalid IL or missing references)
		//IL_0255: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0333: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Rico", "rico");
		Game.Items.Rename("outdated_gun_mods:rico", "nn:rico");
		Rico rico = ((Component)val).gameObject.AddComponent<Rico>();
		((AdvancedGunBehavior)rico).preventNormalFireAudio = true;
		GunExt.SetShortDescription((PickupObject)(object)val, "Cosmic Ray Spallation");
		GunExt.SetLongDescription((PickupObject)(object)val, "The lack of any radiation filtering on this homemade energy blaster causes it's playload to ricochet uncontrollably off of surfaces!");
		val.SetGunSprites("rico");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 9);
		val.isAudioLoop = true;
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.gunHandedness = (GunHandedness)2;
		val.doesScreenShake = false;
		val.DefaultModule.ammoCost = 5;
		val.DefaultModule.shootStyle = (ShootStyle)2;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		val.DefaultModule.cooldownTime = 0.001f;
		val.DefaultModule.numberOfShotsInClip = 1000;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Rico Laser", "NevernamedsItems/Resources/CustomGunAmmoTypes/rico_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/genericbeam_clipempty");
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.31f, 0.49f, 0f);
		val.SetBaseMaxAmmo(1000);
		val.ammo = 1000;
		val.gunClass = (GunClass)20;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).wrapMode = (WrapMode)1;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).loopStart = 1;
		List<string> list = new List<string> { "NevernamedsItems/Resources/BeamSprites/limebeam_mid_001", "NevernamedsItems/Resources/BeamSprites/limebeam_mid_002", "NevernamedsItems/Resources/BeamSprites/limebeam_mid_003", "NevernamedsItems/Resources/BeamSprites/limebeam_mid_004" };
		List<string> list2 = new List<string> { "NevernamedsItems/Resources/BeamSprites/limebeam_impact_001", "NevernamedsItems/Resources/BeamSprites/limebeam_impact_002", "NevernamedsItems/Resources/BeamSprites/limebeam_impact_003", "NevernamedsItems/Resources/BeamSprites/limebeam_impact_004" };
		Projectile val2 = ProjectileUtility.SetupProjectile(86);
		BasicBeamController val3 = BeamAPI.GenerateBeamPrefab(val2, "NevernamedsItems/Resources/BeamSprites/limebeam_mid_001", new Vector2(6f, 4f), new Vector2(0f, 1f), list, 9, list2, 13, (Vector2?)new Vector2(4f, 4f), (Vector2?)new Vector2(7f, 7f), (List<string>)null, -1, (Vector2?)null, (Vector2?)null, (List<string>)null, -1, (Vector2?)null, (Vector2?)null, 0f, 0f);
		val2.baseData.damage = 7f;
		ProjectileData baseData = val2.baseData;
		baseData.force *= 1f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.range *= 200f;
		ProjectileData baseData3 = val2.baseData;
		baseData3.speed *= 10f;
		val3.boneType = (BeamBoneType)0;
		val3.reflections = 7;
		val3.startAudioEvent = "Play_WPN_radiationlaser_shot_01";
		val3.endAudioEvent = "Stop_WPN_All";
		val.DefaultModule.projectiles[0] = val2;
		((PickupObject)val).quality = (ItemQuality)2;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		RicoID = ((PickupObject)val).PickupObjectId;
	}
}
