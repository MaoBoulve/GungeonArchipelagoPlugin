using System.Collections.Generic;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class LightningRod : AdvancedGunBehavior
{
	public static int ID;

	public static void Add()
	{
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_023b: Unknown result type (might be due to invalid IL or missing references)
		//IL_024a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0260: Unknown result type (might be due to invalid IL or missing references)
		//IL_0274: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_031f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0326: Unknown result type (might be due to invalid IL or missing references)
		//IL_0327: Unknown result type (might be due to invalid IL or missing references)
		//IL_0358: Unknown result type (might be due to invalid IL or missing references)
		//IL_038b: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Lightning Rod", "lightningrod");
		Game.Items.Rename("outdated_gun_mods:lightning_rod", "nn:lightning_rod");
		LightningRod lightningRod = ((Component)val).gameObject.AddComponent<LightningRod>();
		((AdvancedGunBehavior)lightningRod).preventNormalFireAudio = true;
		GunExt.SetShortDescription((PickupObject)(object)val, "By Jove!");
		GunExt.SetLongDescription((PickupObject)(object)val, "An ancient magical staff that harnesses the electric power of the sky.\n\nUsed for forestry, battery charging, and sometimes for dungeon crawling.");
		val.SetGunSprites("lightningrod");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 9);
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
		val.DefaultModule.numberOfShotsInClip = -1;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = "Y-Beam Laser";
		((Component)val.barrelOffset).transform.localPosition = new Vector3(0.75f, 0.81f, 0f);
		val.SetBaseMaxAmmo(1000);
		val.ammo = 1000;
		val.gunClass = (GunClass)20;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).wrapMode = (WrapMode)1;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).loopStart = 1;
		List<string> list = new List<string> { "NevernamedsItems/Resources/BeamSprites/stormrodbeam_start_001", "NevernamedsItems/Resources/BeamSprites/stormrodbeam_start_002", "NevernamedsItems/Resources/BeamSprites/stormrodbeam_start_003", "NevernamedsItems/Resources/BeamSprites/stormrodbeam_start_004" };
		List<string> list2 = new List<string> { "NevernamedsItems/Resources/BeamSprites/stormrodbeam_mid_001", "NevernamedsItems/Resources/BeamSprites/stormrodbeam_mid_002", "NevernamedsItems/Resources/BeamSprites/stormrodbeam_mid_003", "NevernamedsItems/Resources/BeamSprites/stormrodbeam_mid_004" };
		List<string> list3 = new List<string> { "NevernamedsItems/Resources/BeamSprites/stormrodbeam_impact_001", "NevernamedsItems/Resources/BeamSprites/stormrodbeam_impact_002", "NevernamedsItems/Resources/BeamSprites/stormrodbeam_impact_003", "NevernamedsItems/Resources/BeamSprites/stormrodbeam_impact_004" };
		Projectile val2 = ProjectileUtility.SetupProjectile(86);
		BasicBeamController val3 = BeamAPI.GenerateBeamPrefab(val2, "NevernamedsItems/Resources/BeamSprites/stormrodbeam_mid_001", new Vector2(17f, 7f), new Vector2(0f, 5f), list2, 10, list3, 10, (Vector2?)new Vector2(4f, 4f), (Vector2?)new Vector2(7f, 7f), (List<string>)null, -1, (Vector2?)null, (Vector2?)null, list, 10, (Vector2?)new Vector2(4f, 4f), (Vector2?)new Vector2(7f, 7f), 10f, 10f);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val2.baseData.damage = 30f;
		ProjectileData baseData = val2.baseData;
		baseData.force *= 1f;
		val2.damageTypes = (CoreDamageTypes)(val2.damageTypes | 0x40);
		val2.baseData.range = 1000f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.speed *= 10f;
		val3.boneType = (BeamBoneType)0;
		val3.startAudioEvent = "Play_ElectricSoundLoop";
		val3.endAudioEvent = "Stop_ElectricSoundLoop";
		val.DefaultModule.projectiles[0] = val2;
		((PickupObject)val).quality = (ItemQuality)2;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
	}
}
