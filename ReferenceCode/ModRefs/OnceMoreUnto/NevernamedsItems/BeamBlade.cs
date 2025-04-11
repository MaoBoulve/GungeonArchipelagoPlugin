using System.Collections.Generic;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class BeamBlade : AdvancedGunBehavior
{
	public static void Add()
	{
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_0245: Unknown result type (might be due to invalid IL or missing references)
		//IL_0254: Unknown result type (might be due to invalid IL or missing references)
		//IL_027f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0293: Unknown result type (might be due to invalid IL or missing references)
		//IL_0322: Unknown result type (might be due to invalid IL or missing references)
		//IL_035d: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Beamblade", "beamblade");
		Game.Items.Rename("outdated_gun_mods:beamblade", "nn:beamblade");
		BeamBlade beamBlade = ((Component)val).gameObject.AddComponent<BeamBlade>();
		((AdvancedGunBehavior)beamBlade).preventNormalFireAudio = true;
		GunExt.SetShortDescription((PickupObject)(object)val, "Elegant");
		GunExt.SetLongDescription((PickupObject)(object)val, "An artful weapon with a blade made of pure beam.\n\nRelic of an ancient order of Gun Knights, whose arcane religions have since fallen into obscurity.");
		val.SetGunSprites("beamblade");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 8);
		val.isAudioLoop = true;
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)val, (StatType)14, 2f, (ModifyMethod)0);
		val.doesScreenShake = false;
		val.DefaultModule.ammoCost = 10;
		val.DefaultModule.angleVariance = 0f;
		val.DefaultModule.shootStyle = (ShootStyle)2;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		val.DefaultModule.cooldownTime = 0.001f;
		val.DefaultModule.numberOfShotsInClip = 3000;
		val.DefaultModule.ammoType = (AmmoType)2;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(0.93f, 0.18f, 0f);
		val.SetBaseMaxAmmo(3000);
		val.ammo = 3000;
		val.gunClass = (GunClass)20;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).wrapMode = (WrapMode)1;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).loopStart = 1;
		List<string> list = new List<string> { "NevernamedsItems/Resources/BeamSprites/beamblade_mid_001", "NevernamedsItems/Resources/BeamSprites/beamblade_mid_002", "NevernamedsItems/Resources/BeamSprites/beamblade_mid_003", "NevernamedsItems/Resources/BeamSprites/beamblade_mid_004", "NevernamedsItems/Resources/BeamSprites/beamblade_mid_005", "NevernamedsItems/Resources/BeamSprites/beamblade_mid_006" };
		List<string> list2 = new List<string> { "NevernamedsItems/Resources/BeamSprites/beamblade_end_001", "NevernamedsItems/Resources/BeamSprites/beamblade_end_002", "NevernamedsItems/Resources/BeamSprites/beamblade_end_003", "NevernamedsItems/Resources/BeamSprites/beamblade_end_004", "NevernamedsItems/Resources/BeamSprites/beamblade_end_005", "NevernamedsItems/Resources/BeamSprites/beamblade_end_006" };
		Projectile val2 = ProjectileUtility.SetupProjectile(86);
		BasicBeamController val3 = BeamAPI.GenerateBeamPrefab(val2, "NevernamedsItems/Resources/BeamSprites/beamblade_mid_001", new Vector2(5f, 3f), new Vector2(0f, 1f), list, 9, (List<string>)null, -1, (Vector2?)null, (Vector2?)null, list2, 9, (Vector2?)new Vector2(5f, 3f), (Vector2?)new Vector2(0f, 1f), (List<string>)null, -1, (Vector2?)null, (Vector2?)null, 0f, 0f);
		val2.baseData.damage = 70f;
		ProjectileData baseData = val2.baseData;
		baseData.force *= 0.1f;
		val2.baseData.range = 3.5f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.speed *= 1f;
		val3.penetration = 100;
		val3.boneType = (BeamBoneType)0;
		val3.interpolateStretchedBones = false;
		val3.endAudioEvent = "Stop_WPN_All";
		val3.startAudioEvent = "Play_WPN_moonscraperLaser_shot_01";
		val.DefaultModule.projectiles[0] = val2;
		((PickupObject)val).quality = (ItemQuality)2;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
	}
}
