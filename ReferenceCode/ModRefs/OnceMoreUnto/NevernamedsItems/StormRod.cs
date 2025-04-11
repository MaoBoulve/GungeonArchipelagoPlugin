using System.Collections.Generic;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class StormRod : AdvancedGunBehavior
{
	public static int ID;

	public static void Add()
	{
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0389: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_0219: Unknown result type (might be due to invalid IL or missing references)
		//IL_0228: Unknown result type (might be due to invalid IL or missing references)
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		//IL_0281: Unknown result type (might be due to invalid IL or missing references)
		//IL_0295: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0315: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Storm Rod", "stormrod");
		Game.Items.Rename("outdated_gun_mods:storm_rod", "nn:lightning_rod+storm_rod");
		StormRod stormRod = ((Component)val).gameObject.AddComponent<StormRod>();
		((AdvancedGunBehavior)stormRod).preventNormalFireAudio = true;
		GunExt.SetShortDescription((PickupObject)(object)val, "");
		GunExt.SetLongDescription((PickupObject)(object)val, "");
		val.SetGunSprites("stormrod", 8, noAmmonomicon: true);
		GunExt.SetAnimationFPS(val, val.shootAnimation, 8);
		val.isAudioLoop = true;
		val.gunClass = (GunClass)20;
		int num = 0;
		for (int i = 0; i < 3; i++)
		{
			PickupObject byId = PickupObjectDatabase.GetById(86);
			GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		}
		foreach (ProjectileModule projectile in val.Volley.projectiles)
		{
			if (num == 1)
			{
				projectile.angleFromAim = 30f;
			}
			if (num == 2)
			{
				projectile.angleFromAim = -30f;
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
			projectile.ammoType = (AmmoType)14;
			projectile.customAmmoType = "Y-Beam Laser";
			List<string> list = new List<string> { "NevernamedsItems/Resources/BeamSprites/stormrodbeam_start_001", "NevernamedsItems/Resources/BeamSprites/stormrodbeam_start_002", "NevernamedsItems/Resources/BeamSprites/stormrodbeam_start_003", "NevernamedsItems/Resources/BeamSprites/stormrodbeam_start_004" };
			List<string> list2 = new List<string> { "NevernamedsItems/Resources/BeamSprites/stormrodbeam_mid_001", "NevernamedsItems/Resources/BeamSprites/stormrodbeam_mid_002", "NevernamedsItems/Resources/BeamSprites/stormrodbeam_mid_003", "NevernamedsItems/Resources/BeamSprites/stormrodbeam_mid_004" };
			List<string> list3 = new List<string> { "NevernamedsItems/Resources/BeamSprites/stormrodbeam_impact_001", "NevernamedsItems/Resources/BeamSprites/stormrodbeam_impact_002", "NevernamedsItems/Resources/BeamSprites/stormrodbeam_impact_003", "NevernamedsItems/Resources/BeamSprites/stormrodbeam_impact_004" };
			Projectile val2 = ProjectileUtility.SetupProjectile(86);
			BasicBeamController val3 = BeamAPI.GenerateBeamPrefab(val2, "NevernamedsItems/Resources/BeamSprites/stormrodbeam_mid_001", new Vector2(17f, 7f), new Vector2(0f, 5f), list2, 10, list3, 10, (Vector2?)new Vector2(4f, 4f), (Vector2?)new Vector2(7f, 7f), (List<string>)null, -1, (Vector2?)null, (Vector2?)null, list, 10, (Vector2?)new Vector2(4f, 4f), (Vector2?)new Vector2(7f, 7f), 10f, 10f);
			val2.baseData.damage = 30f;
			ProjectileData baseData = val2.baseData;
			baseData.force *= 1f;
			val2.damageTypes = (CoreDamageTypes)(val2.damageTypes | 0x40);
			val2.baseData.range = 1000f;
			ProjectileData baseData2 = val2.baseData;
			baseData2.speed *= 10f;
			val3.boneType = (BeamBoneType)0;
			if (num == 0)
			{
				val3.startAudioEvent = "Play_ElectricSoundLoop";
				val3.endAudioEvent = "Stop_ElectricSoundLoop";
			}
			num++;
			projectile.projectiles[0] = val2;
		}
		val.doesScreenShake = false;
		val.reloadTime = 1f;
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(0.87f, 0.93f, 0f);
		val.SetBaseMaxAmmo(1700);
		val.ammo = 1700;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).wrapMode = (WrapMode)1;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).loopStart = 1;
		((PickupObject)val).quality = (ItemQuality)(-100);
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
		GunExt.SetName((PickupObject)(object)val, "Lightning Rod");
	}
}
