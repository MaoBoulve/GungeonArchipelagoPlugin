using System.Collections.Generic;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class WallRay : AdvancedGunBehavior
{
	public static void Add()
	{
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_042c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0450: Unknown result type (might be due to invalid IL or missing references)
		//IL_0476: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_026a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0279: Unknown result type (might be due to invalid IL or missing references)
		//IL_0290: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_035d: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Wall-Ray", "wallray");
		Game.Items.Rename("outdated_gun_mods:wallray", "nn:wall_ray");
		WallRay wallRay = ((Component)val).gameObject.AddComponent<WallRay>();
		((AdvancedGunBehavior)wallRay).preventNormalFireAudio = true;
		GunExt.SetShortDescription((PickupObject)(object)val, "90 Degrees Are Best Degrees");
		GunExt.SetLongDescription((PickupObject)(object)val, "Creates two beams at ninety degree angles from the direction aimed.\n\nInvented and used primarily for window washing.");
		val.SetGunSprites("wallray");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 8);
		val.isAudioLoop = true;
		val.gunClass = (GunClass)55;
		int num = 0;
		for (int i = 0; i < 2; i++)
		{
			PickupObject byId = PickupObjectDatabase.GetById(86);
			GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		}
		foreach (ProjectileModule projectile in val.Volley.projectiles)
		{
			if (num == 0)
			{
				projectile.angleFromAim = 90f;
				projectile.positionOffset = Vector2.op_Implicit(new Vector2(0f, 0.56f));
			}
			if (num == 1)
			{
				projectile.angleFromAim = -90f;
				projectile.positionOffset = Vector2.op_Implicit(new Vector2(0f, -0.56f));
			}
			projectile.ammoCost = 10;
			if (projectile != val.DefaultModule)
			{
				projectile.ammoCost = 0;
			}
			projectile.shootStyle = (ShootStyle)2;
			projectile.sequenceStyle = (ProjectileSequenceStyle)0;
			projectile.cooldownTime = 0.001f;
			projectile.numberOfShotsInClip = -1;
			projectile.angleVariance = 0f;
			projectile.ammoType = (AmmoType)2;
			List<string> list = new List<string> { "NevernamedsItems/Resources/BeamSprites/thickredbeam_mid_001", "NevernamedsItems/Resources/BeamSprites/thickredbeam_mid_002", "NevernamedsItems/Resources/BeamSprites/thickredbeam_mid_003", "NevernamedsItems/Resources/BeamSprites/thickredbeam_mid_004", "NevernamedsItems/Resources/BeamSprites/thickredbeam_mid_005" };
			List<string> list2 = new List<string> { "NevernamedsItems/Resources/BeamSprites/thickredbeam_start_001", "NevernamedsItems/Resources/BeamSprites/thickredbeam_start_002", "NevernamedsItems/Resources/BeamSprites/thickredbeam_start_003", "NevernamedsItems/Resources/BeamSprites/thickredbeam_start_004", "NevernamedsItems/Resources/BeamSprites/thickredbeam_start_005" };
			List<string> list3 = new List<string> { "NevernamedsItems/Resources/BeamSprites/thickredbeam_impact_001", "NevernamedsItems/Resources/BeamSprites/thickredbeam_impact_002", "NevernamedsItems/Resources/BeamSprites/thickredbeam_impact_003", "NevernamedsItems/Resources/BeamSprites/thickredbeam_impact_004" };
			Projectile val2 = ProjectileUtility.SetupProjectile(86);
			BasicBeamController val3 = BeamAPI.GenerateBeamPrefab(val2, "NevernamedsItems/Resources/BeamSprites/thickredbeam_mid_001", new Vector2(9f, 9f), new Vector2(0f, 1f), list, 13, list3, 13, (Vector2?)new Vector2(3f, 3f), (Vector2?)new Vector2(5f, 5f), (List<string>)null, -1, (Vector2?)null, (Vector2?)null, list2, 13, (Vector2?)new Vector2(9f, 9f), (Vector2?)new Vector2(0f, 1f), 100f, 0f);
			val2.baseData.damage = 25f;
			ProjectileData baseData = val2.baseData;
			baseData.force *= 2f;
			ProjectileData baseData2 = val2.baseData;
			baseData2.range *= 10f;
			ProjectileData baseData3 = val2.baseData;
			baseData3.speed *= 10f;
			val3.boneType = (BeamBoneType)2;
			val3.interpolateStretchedBones = false;
			if (num == 0)
			{
				val3.endAudioEvent = "Stop_WPN_All";
				val3.startAudioEvent = "Play_WPN_moonscraperLaser_shot_01";
			}
			num++;
			projectile.projectiles[0] = val2;
		}
		val.doesScreenShake = false;
		val.reloadTime = 1f;
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.56f, 0.62f, 0f);
		val.SetBaseMaxAmmo(2000);
		val.ammo = 2000;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).wrapMode = (WrapMode)1;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).loopStart = 1;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("OMITB GenericRed Laser", "NevernamedsItems/Resources/CustomGunAmmoTypes/genericredbeam_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/genericbeam_clipempty");
		((PickupObject)val).quality = (ItemQuality)2;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
	}
}
