using System.Collections.Generic;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class PocoLoco : AdvancedGunBehavior
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
		//IL_0270: Unknown result type (might be due to invalid IL or missing references)
		//IL_027f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0294: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_042f: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Poco Loco", "pocoloco");
		Game.Items.Rename("outdated_gun_mods:poco_loco", "nn:poco_loco");
		PocoLoco pocoLoco = ((Component)val).gameObject.AddComponent<PocoLoco>();
		((AdvancedGunBehavior)pocoLoco).preventNormalFireAudio = true;
		GunExt.SetShortDescription((PickupObject)(object)val, "Crazy");
		GunExt.SetLongDescription((PickupObject)(object)val, "This energy beam emitter has been heavily modified. At a cursory glance, it's there's no way it could possibly be functional- but what's the harm in trying?");
		val.SetGunSprites("pocoloco");
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
		val.DefaultModule.numberOfShotsInClip = 500;
		val.DefaultModule.ammoType = (AmmoType)2;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.125f, 0.5f, 0f);
		val.SetBaseMaxAmmo(500);
		val.ammo = 500;
		val.gunClass = (GunClass)20;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).wrapMode = (WrapMode)1;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).loopStart = 1;
		List<string> list = new List<string>
		{
			"NevernamedsItems/Resources/BeamSprites/pocolocobeam_mid_001", "NevernamedsItems/Resources/BeamSprites/pocolocobeam_mid_002", "NevernamedsItems/Resources/BeamSprites/pocolocobeam_mid_003", "NevernamedsItems/Resources/BeamSprites/pocolocobeam_mid_004", "NevernamedsItems/Resources/BeamSprites/pocolocobeam_mid_005", "NevernamedsItems/Resources/BeamSprites/pocolocobeam_mid_006", "NevernamedsItems/Resources/BeamSprites/pocolocobeam_mid_007", "NevernamedsItems/Resources/BeamSprites/pocolocobeam_mid_008", "NevernamedsItems/Resources/BeamSprites/pocolocobeam_mid_009", "NevernamedsItems/Resources/BeamSprites/pocolocobeam_mid_010",
			"NevernamedsItems/Resources/BeamSprites/pocolocobeam_mid_011", "NevernamedsItems/Resources/BeamSprites/pocolocobeam_mid_012"
		};
		List<string> list2 = new List<string> { "NevernamedsItems/Resources/BeamSprites/yellowbeam_impact_001", "NevernamedsItems/Resources/BeamSprites/yellowbeam_impact_002", "NevernamedsItems/Resources/BeamSprites/yellowbeam_impact_003", "NevernamedsItems/Resources/BeamSprites/yellowbeam_impact_004" };
		PickupObject byId2 = PickupObjectDatabase.GetById(86);
		Projectile val2 = Object.Instantiate<Projectile>(((Gun)((byId2 is Gun) ? byId2 : null)).DefaultModule.projectiles[0]);
		BasicBeamController val3 = BeamAPI.GenerateBeamPrefab(val2, "NevernamedsItems/Resources/BeamSprites/pocolocobeam_mid_001", new Vector2(4f, 4f), new Vector2(0f, 0f), list, 13, list2, 13, (Vector2?)new Vector2(4f, 4f), (Vector2?)new Vector2(7f, 7f), (List<string>)null, -1, (Vector2?)null, (Vector2?)null, (List<string>)null, -1, (Vector2?)null, (Vector2?)null, 10f, 0f);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val2.baseData.damage = 5f;
		ProjectileData baseData = val2.baseData;
		baseData.force *= 1f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.range *= 200f;
		ProjectileData baseData3 = val2.baseData;
		baseData3.speed *= 5f;
		BeamSplittingModifier beamSplittingModifier = ((Component)val2).gameObject.AddComponent<BeamSplittingModifier>();
		beamSplittingModifier.dmgMultOnSplit = 1f;
		beamSplittingModifier.distanceTilSplit = 4f;
		beamSplittingModifier.amtToSplitTo = 3;
		beamSplittingModifier.splitAngles = 45f;
		val3.penetration = 3;
		val3.homingAngularVelocity = 200f;
		val3.homingRadius = 30f;
		val3.reflections = 3;
		val3.boneType = (BeamBoneType)2;
		val3.startAudioEvent = "Play_WPN_radiationlaser_shot_01";
		val3.endAudioEvent = "Stop_WPN_All";
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Y-Beam Laser", "NevernamedsItems/Resources/CustomGunAmmoTypes/ybeam_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/genericbeam_clipempty");
		val.DefaultModule.projectiles[0] = val2;
		((PickupObject)val).quality = (ItemQuality)2;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
	}
}
