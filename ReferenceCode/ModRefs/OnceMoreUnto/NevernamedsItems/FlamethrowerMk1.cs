using System.Collections.Generic;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class FlamethrowerMk1 : AdvancedGunBehavior
{
	public static void Add()
	{
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_038e: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_041e: Unknown result type (might be due to invalid IL or missing references)
		//IL_042b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0456: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Flamethrower Mk 1", "flamethrowermk1");
		Game.Items.Rename("outdated_gun_mods:flamethrower_mk_1", "nn:flamethrower_mk_1");
		FlamethrowerMk1 flamethrowerMk = ((Component)val).gameObject.AddComponent<FlamethrowerMk1>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Bearing Down On Me");
		GunExt.SetLongDescription((PickupObject)(object)val, "A crudely modified Mega-Douser filled with gasoline.\n\nThe very first experiment of flamesmith Lucinda \"Third Degree\" Burns.");
		val.SetGunSprites("flamethrowermk1");
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(10);
		gunSwitchGroup = ((Gun)((byId2 is Gun) ? byId2 : null)).gunSwitchGroup;
		val.isAudioLoop = true;
		val.doesScreenShake = false;
		val.DefaultModule.ammoCost = 10;
		val.DefaultModule.shootStyle = (ShootStyle)2;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.muzzleFlashEffects = VFXToolbox.CreateVFXPool("Flamethrower Mk1 Muzzleflash", new List<string> { "NevernamedsItems/Resources/BeamSprites/liquidfirebeam_impact_001", "NevernamedsItems/Resources/BeamSprites/liquidfirebeam_impact_002", "NevernamedsItems/Resources/BeamSprites/liquidfirebeam_impact_003", "NevernamedsItems/Resources/BeamSprites/liquidfirebeam_impact_004", "NevernamedsItems/Resources/BeamSprites/liquidfirebeam_impact_005", "NevernamedsItems/Resources/BeamSprites/liquidfirebeam_impact_006", "NevernamedsItems/Resources/BeamSprites/liquidfirebeam_impact_007", "NevernamedsItems/Resources/BeamSprites/liquidfirebeam_impact_008" }, 17, new IntVector2(23, 23), (Anchor)3, usesZHeight: false, 0f, persist: false, (VFXAlignment)0, -1f, null, (WrapMode)0);
		val.usesContinuousMuzzleFlash = true;
		val.DefaultModule.cooldownTime = 0.1f;
		val.DefaultModule.angleVariance = 0f;
		val.DefaultModule.numberOfShotsInClip = -1;
		val.DefaultModule.ammoType = (AmmoType)2;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.125f, 0.5f, 0f);
		val.SetBaseMaxAmmo(900);
		val.ammo = 900;
		val.gunClass = (GunClass)30;
		List<string> list = new List<string> { "NevernamedsItems/Resources/BeamSprites/liquidfirebeam_mid_001", "NevernamedsItems/Resources/BeamSprites/liquidfirebeam_mid_002", "NevernamedsItems/Resources/BeamSprites/liquidfirebeam_mid_003", "NevernamedsItems/Resources/BeamSprites/liquidfirebeam_mid_004", "NevernamedsItems/Resources/BeamSprites/liquidfirebeam_mid_005" };
		List<string> list2 = new List<string> { "NevernamedsItems/Resources/BeamSprites/liquidfirebeam_impact_001", "NevernamedsItems/Resources/BeamSprites/liquidfirebeam_impact_002", "NevernamedsItems/Resources/BeamSprites/liquidfirebeam_impact_003", "NevernamedsItems/Resources/BeamSprites/liquidfirebeam_impact_004", "NevernamedsItems/Resources/BeamSprites/liquidfirebeam_impact_005", "NevernamedsItems/Resources/BeamSprites/liquidfirebeam_impact_006", "NevernamedsItems/Resources/BeamSprites/liquidfirebeam_impact_007", "NevernamedsItems/Resources/BeamSprites/liquidfirebeam_impact_008" };
		PickupObject byId3 = PickupObjectDatabase.GetById(86);
		Projectile val2 = ProjectileUtility.InstantiateAndFakeprefab(((Gun)((byId3 is Gun) ? byId3 : null)).DefaultModule.projectiles[0]);
		BasicBeamController val3 = BeamAPI.GenerateBeamPrefab(val2, "NevernamedsItems/Resources/BeamSprites/liquidfirebeam_mid_001", new Vector2(16f, 4f), new Vector2(0f, 6f), list, 13, list2, 17, (Vector2?)new Vector2(11f, 11f), (Vector2?)new Vector2(6f, 6f), (List<string>)null, -1, (Vector2?)null, (Vector2?)null, (List<string>)null, -1, (Vector2?)null, (Vector2?)null, 0f, 0f);
		val2.baseData.damage = 15f;
		val2.baseData.force = 40f;
		ProjectileData baseData = val2.baseData;
		baseData.range *= 200f;
		val2.baseData.speed = 20f;
		val3.boneType = (BeamBoneType)2;
		val3.interpolateStretchedBones = true;
		val3.collisionSeparation = true;
		val3.TileType = (BeamTileType)2;
		val3.endType = (BeamEndType)1;
		val2.AppliesFire = true;
		val2.fireEffect = StaticStatusEffects.hotLeadEffect;
		((BeamController)val3).statusEffectChance = 1f;
		val3.TimeToStatus = 0.1f;
		GoopModifier val4 = ((Component)val2).gameObject.AddComponent<GoopModifier>();
		val4.goopDefinition = GoopUtility.FireDef;
		val4.SpawnGoopOnCollision = true;
		val4.CollisionSpawnRadius = 1f;
		ParticleShitter orAddComponent = GameObjectExtensions.GetOrAddComponent<ParticleShitter>(((Component)val2).gameObject);
		orAddComponent.particleType = (SparksType)5;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = "Y-Beam Laser";
		val.DefaultModule.projectiles[0] = val2;
		((PickupObject)val).quality = (ItemQuality)2;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
	}
}
