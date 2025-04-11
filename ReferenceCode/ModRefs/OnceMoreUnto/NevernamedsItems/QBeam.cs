using System.Collections.Generic;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class QBeam : AdvancedGunBehavior
{
	public static int ID;

	public static void Add()
	{
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_021f: Unknown result type (might be due to invalid IL or missing references)
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0243: Unknown result type (might be due to invalid IL or missing references)
		//IL_0257: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_032e: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Q-Beam", "qbeam");
		Game.Items.Rename("outdated_gun_mods:qbeam", "nn:q_beam");
		QBeam qBeam = ((Component)val).gameObject.AddComponent<QBeam>();
		((AdvancedGunBehavior)qBeam).preventNormalFireAudio = true;
		GunExt.SetShortDescription((PickupObject)(object)val, "");
		GunExt.SetLongDescription((PickupObject)(object)val, "");
		val.SetGunSprites("qbeam");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 9);
		val.isAudioLoop = true;
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.gunHandedness = (GunHandedness)1;
		val.doesScreenShake = false;
		val.DefaultModule.ammoCost = 10;
		val.DefaultModule.shootStyle = (ShootStyle)2;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		val.DefaultModule.cooldownTime = 0.001f;
		val.DefaultModule.numberOfShotsInClip = 2000;
		val.DefaultModule.angleVariance = 0f;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = "Rico Laser";
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.375f, 0.375f, 0f);
		val.SetBaseMaxAmmo(2000);
		val.ammo = 2000;
		val.gunClass = (GunClass)20;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).wrapMode = (WrapMode)1;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).loopStart = 0;
		List<string> list = new List<string> { "NevernamedsItems/Resources/BeamSprites/limebeam_mid_001", "NevernamedsItems/Resources/BeamSprites/limebeam_mid_002", "NevernamedsItems/Resources/BeamSprites/limebeam_mid_003", "NevernamedsItems/Resources/BeamSprites/limebeam_mid_004" };
		List<string> list2 = new List<string> { "NevernamedsItems/Resources/BeamSprites/limebeam_impact_001", "NevernamedsItems/Resources/BeamSprites/limebeam_impact_002", "NevernamedsItems/Resources/BeamSprites/limebeam_impact_003", "NevernamedsItems/Resources/BeamSprites/limebeam_impact_004" };
		Projectile val2 = ProjectileUtility.SetupProjectile(86);
		BasicBeamController val3 = BeamAPI.GenerateBeamPrefab(val2, "NevernamedsItems/Resources/BeamSprites/limebeam_mid_001", new Vector2(6f, 4f), new Vector2(0f, 1f), list, 9, list2, 13, (Vector2?)new Vector2(4f, 4f), (Vector2?)new Vector2(7f, 7f), (List<string>)null, -1, (Vector2?)null, (Vector2?)null, (List<string>)null, -1, (Vector2?)null, (Vector2?)null, 0f, 0f);
		val2.baseData.damage = 5f;
		ProjectileData baseData = val2.baseData;
		baseData.force *= 1f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.range *= 200f;
		ProjectileData baseData3 = val2.baseData;
		baseData3.speed *= 10f;
		val3.boneType = (BeamBoneType)0;
		val3.startAudioEvent = "Play_WPN_radiationlaser_shot_01";
		val3.endAudioEvent = "Stop_WPN_All";
		val.DefaultModule.projectiles[0] = val2;
		((PickupObject)val).quality = (ItemQuality)(-100);
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
	}
}
