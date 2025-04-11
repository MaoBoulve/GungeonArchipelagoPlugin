using System.Collections.Generic;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class Converter : AdvancedGunBehavior
{
	public static int ConverterID;

	public static void Add()
	{
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_0213: Unknown result type (might be due to invalid IL or missing references)
		//IL_0228: Unknown result type (might be due to invalid IL or missing references)
		//IL_023c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0320: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Converter", "converter");
		Game.Items.Rename("outdated_gun_mods:converter", "nn:converter");
		Converter converter = ((Component)val).gameObject.AddComponent<Converter>();
		((AdvancedGunBehavior)converter).preventNormalFireAudio = true;
		GunExt.SetShortDescription((PickupObject)(object)val, "My Bullets!");
		GunExt.SetLongDescription((PickupObject)(object)val, "Converts enemy bullets to your side.\n\nPart of a dismantled mind control device. Not strong enough to convert the Gundead themselves, but enemy shots have far weaker wills.");
		val.SetGunSprites("converter");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 9);
		val.isAudioLoop = true;
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.doesScreenShake = false;
		val.DefaultModule.ammoCost = 20;
		val.DefaultModule.shootStyle = (ShootStyle)2;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		val.DefaultModule.cooldownTime = 0.001f;
		val.DefaultModule.numberOfShotsInClip = -1;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = "Y-Beam Laser";
		((Component)val.barrelOffset).transform.localPosition = new Vector3(0.93f, 0.5f, 0f);
		val.SetBaseMaxAmmo(2000);
		val.ammo = 2000;
		val.gunClass = (GunClass)20;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).wrapMode = (WrapMode)1;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).loopStart = 1;
		List<string> list = new List<string> { "NevernamedsItems/Resources/BeamSprites/yellowbeam_mid_001", "NevernamedsItems/Resources/BeamSprites/yellowbeam_mid_002", "NevernamedsItems/Resources/BeamSprites/yellowbeam_mid_003", "NevernamedsItems/Resources/BeamSprites/yellowbeam_mid_004" };
		List<string> list2 = new List<string> { "NevernamedsItems/Resources/BeamSprites/yellowbeam_impact_001", "NevernamedsItems/Resources/BeamSprites/yellowbeam_impact_002", "NevernamedsItems/Resources/BeamSprites/yellowbeam_impact_003", "NevernamedsItems/Resources/BeamSprites/yellowbeam_impact_004" };
		Projectile val2 = ProjectileUtility.SetupProjectile(86);
		BasicBeamController val3 = BeamAPI.GenerateBeamPrefab(val2, "NevernamedsItems/Resources/BeamSprites/yellowbeam_mid_001", new Vector2(6f, 4f), new Vector2(0f, 1f), list, 9, list2, 13, (Vector2?)new Vector2(4f, 4f), (Vector2?)new Vector2(7f, 7f), (List<string>)null, -1, (Vector2?)null, (Vector2?)null, (List<string>)null, -1, (Vector2?)null, (Vector2?)null, 50f, 0f);
		val2.baseData.damage = 7f;
		ProjectileData baseData = val2.baseData;
		baseData.force *= 1f;
		val2.baseData.range = 12f;
		((Component)val2).gameObject.AddComponent<EnemyBulletConverterBeam>();
		ProjectileData baseData2 = val2.baseData;
		baseData2.speed *= 10f;
		val3.boneType = (BeamBoneType)0;
		val3.startAudioEvent = "Play_WPN_radiationlaser_shot_01";
		val3.endAudioEvent = "Stop_WPN_All";
		val3.penetration = 1;
		val.DefaultModule.projectiles[0] = val2;
		((PickupObject)val).quality = (ItemQuality)4;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.PURCHASED_CONVERTER, requiredFlagValue: true);
		ConverterID = ((PickupObject)val).PickupObjectId;
	}
}
