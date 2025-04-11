using System.Collections.Generic;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class CarrionFormeThree : AdvancedGunBehavior
{
	public static void Add()
	{
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0224: Unknown result type (might be due to invalid IL or missing references)
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_028a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0294: Expected O, but got Unknown
		//IL_0297: Unknown result type (might be due to invalid IL or missing references)
		//IL_0366: Unknown result type (might be due to invalid IL or missing references)
		//IL_0375: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_043c: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e9: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("carrion_third_form", "carrionformthree");
		Game.Items.Rename("outdated_gun_mods:carrion_third_form", "nn:carrion_third_form");
		CarrionFormeThree carrionFormeThree = ((Component)val).gameObject.AddComponent<CarrionFormeThree>();
		((AdvancedGunBehavior)carrionFormeThree).preventNormalFireAudio = true;
		GunExt.SetShortDescription((PickupObject)(object)val, "");
		GunExt.SetLongDescription((PickupObject)(object)val, "");
		val.SetGunSprites("carrionformthree", 8, noAmmonomicon: true);
		GunExt.SetAnimationFPS(val, val.shootAnimation, 13);
		GunExt.SetAnimationFPS(val, val.idleAnimation, 13);
		val.isAudioLoop = true;
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.doesScreenShake = true;
		val.DefaultModule.ammoCost = 5;
		val.DefaultModule.shootStyle = (ShootStyle)2;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		val.DefaultModule.cooldownTime = 0.001f;
		val.DefaultModule.numberOfShotsInClip = 600;
		val.DefaultModule.ammoType = (AmmoType)2;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(0.75f, 0.56f, 0f);
		val.SetBaseMaxAmmo(600);
		val.ammo = 600;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).wrapMode = (WrapMode)1;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).loopStart = 0;
		Projectile val2 = ProjectileUtility.SetupProjectile(86);
		BasicBeamController val3 = BeamAPI.GenerateBeamPrefab(val2, "NevernamedsItems/Resources/BeamSprites/carrionsubtendril_mid_001", new Vector2(4f, 2f), new Vector2(0f, 1f), new List<string> { "NevernamedsItems/Resources/BeamSprites/carrionsubtendril_mid_001" }, 13, (List<string>)null, -1, (Vector2?)null, (Vector2?)null, new List<string> { "NevernamedsItems/Resources/BeamSprites/carrionsubtendril_end_001" }, 13, (Vector2?)new Vector2(6f, 2f), (Vector2?)new Vector2(0f, 1f), new List<string> { "NevernamedsItems/Resources/BeamSprites/carrionsubtendril_start_001" }, 13, (Vector2?)new Vector2(7f, 2f), (Vector2?)new Vector2(0f, 1f), 0f, 0f);
		val2.baseData.damage = 10f;
		ProjectileData baseData = val2.baseData;
		baseData.force *= 1f;
		val2.baseData.range = 5.5f;
		val3.ProjectileAndBeamMotionModule = (ProjectileAndBeamMotionModule)new HelixProjectileMotionModule();
		val3.boneType = (BeamBoneType)2;
		val3.penetration = 1;
		val3.homingRadius = 10f;
		val3.homingAngularVelocity = 1000f;
		CarrionSubTendrilController carrionSubTendrilController = ((Component)val2).gameObject.AddComponent<CarrionSubTendrilController>();
		List<string> list = new List<string> { "NevernamedsItems/Resources/BeamSprites/carrionformthree_mid_001", "NevernamedsItems/Resources/BeamSprites/carrionformthree_mid_002", "NevernamedsItems/Resources/BeamSprites/carrionformthree_mid_003", "NevernamedsItems/Resources/BeamSprites/carrionformthree_mid_004", "NevernamedsItems/Resources/BeamSprites/carrionformthree_mid_005" };
		List<string> list2 = new List<string> { "NevernamedsItems/Resources/BeamSprites/carrionformthree_end_001", "NevernamedsItems/Resources/BeamSprites/carrionformthree_end_002", "NevernamedsItems/Resources/BeamSprites/carrionformthree_end_003", "NevernamedsItems/Resources/BeamSprites/carrionformthree_end_004", "NevernamedsItems/Resources/BeamSprites/carrionformthree_end_005" };
		Projectile val4 = ProjectileUtility.SetupProjectile(86);
		BasicBeamController val5 = BeamAPI.GenerateBeamPrefab(val4, "NevernamedsItems/Resources/BeamSprites/carrionformthree_mid_001", new Vector2(16f, 5f), new Vector2(0f, 6f), list, 13, (List<string>)null, -1, (Vector2?)null, (Vector2?)null, list2, 13, (Vector2?)new Vector2(10f, 5f), (Vector2?)new Vector2(0f, 6f), (List<string>)null, -1, (Vector2?)null, (Vector2?)null, 0f, 0f);
		val4.baseData.damage = 50f;
		ProjectileData baseData2 = val4.baseData;
		baseData2.force *= 1f;
		val4.baseData.range = 16f;
		ProjectileData baseData3 = val4.baseData;
		baseData3.speed *= 3f;
		val5.boneType = (BeamBoneType)2;
		val5.startAudioEvent = "Play_WPN_demonhead_shot_01";
		val5.endAudioEvent = "Stop_WPN_All";
		val5.penetration = 5;
		val5.homingRadius = 10f;
		val5.homingAngularVelocity = 500f;
		val5.ProjectileScale *= 1.2f;
		CarrionMainTendrilController carrionMainTendrilController = ((Component)val4).gameObject.AddComponent<CarrionMainTendrilController>();
		carrionMainTendrilController.subTendrilPrefab = ((Component)val2).gameObject;
		((Component)val4).gameObject.AddComponent<CarrionMovementTentacles>();
		val.DefaultModule.projectiles[0] = val4;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = "Carrion Clip";
		((PickupObject)val).quality = (ItemQuality)(-100);
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		Carrion.CarrionForme3ID = ((PickupObject)val).PickupObjectId;
	}
}
