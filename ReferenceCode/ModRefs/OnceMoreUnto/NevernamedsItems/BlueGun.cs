using System.Collections.Generic;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class BlueGun : AdvancedGunBehavior
{
	public static void Add()
	{
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_029b: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f4: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Blue Gun", "bluegun");
		Game.Items.Rename("outdated_gun_mods:blue_gun", "nn:blue_gun");
		BlueGun blueGun = ((Component)val).gameObject.AddComponent<BlueGun>();
		((AdvancedGunBehavior)blueGun).preventNormalFireAudio = true;
		GunExt.SetShortDescription((PickupObject)(object)val, "Why So Blue?");
		GunExt.SetLongDescription((PickupObject)(object)val, "Blue Guns like these are often used by Hegemony Soldiers to simulate combat situations without live weapons. This has, as per the usual, been convoluted within the Gungeon.\n\nCan be reloaded with blanks to refill ammo.");
		val.SetGunSprites("bluegun");
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.doesScreenShake = false;
		val.DefaultModule.ammoCost = 8;
		val.DefaultModule.angleVariance = 0f;
		val.DefaultModule.shootStyle = (ShootStyle)2;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		val.DefaultModule.cooldownTime = 0.001f;
		val.DefaultModule.numberOfShotsInClip = -1;
		val.DefaultModule.ammoType = (AmmoType)2;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.75f, 0.5f, 0f);
		val.SetBaseMaxAmmo(300);
		val.ammo = 300;
		val.gunClass = (GunClass)20;
		List<string> list = new List<string> { "NevernamedsItems/Resources/BeamSprites/tribeam_mid_001", "NevernamedsItems/Resources/BeamSprites/tribeam_mid_002" };
		List<string> list2 = new List<string> { "NevernamedsItems/Resources/BeamSprites/bluebeam_impact_001", "NevernamedsItems/Resources/BeamSprites/bluebeam_impact_002", "NevernamedsItems/Resources/BeamSprites/bluebeam_impact_003", "NevernamedsItems/Resources/BeamSprites/bluebeam_impact_004" };
		PickupObject byId2 = PickupObjectDatabase.GetById(86);
		Projectile val2 = ProjectileUtility.InstantiateAndFakeprefab(((Gun)((byId2 is Gun) ? byId2 : null)).DefaultModule.projectiles[0]);
		BasicBeamController val3 = BeamAPI.GenerateBeamPrefab(val2, "NevernamedsItems/Resources/BeamSprites/tribeam_mid_001", new Vector2(10f, 2f), new Vector2(0f, 4f), list, 13, list2, 13, (Vector2?)new Vector2(4f, 4f), (Vector2?)new Vector2(7f, 7f), (List<string>)null, -1, (Vector2?)null, (Vector2?)null, (List<string>)null, -1, (Vector2?)null, (Vector2?)null, 10f, 0f);
		val2.baseData.damage = 10f;
		ProjectileData baseData = val2.baseData;
		baseData.force *= 1f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.range *= 200f;
		ProjectileData baseData3 = val2.baseData;
		baseData3.speed *= 5f;
		val3.boneType = (BeamBoneType)2;
		val3.startAudioEvent = "Play_WPN_radiationlaser_shot_01";
		val3.endAudioEvent = "Stop_WPN_All";
		BeamBlankModifier beamBlankModifier = ((Component)val2).gameObject.AddComponent<BeamBlankModifier>();
		beamBlankModifier.chancePerTick = 0.5f;
		val.DefaultModule.ammoType = (AmmoType)2;
		val.DefaultModule.projectiles[0] = val2;
		((PickupObject)val).quality = (ItemQuality)4;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
	}

	public override void OnReloadPressedSafe(PlayerController player, Gun gun, bool manualReload)
	{
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		if (player.Blanks > 0)
		{
			player.Blanks -= 1;
			AkSoundEngine.PostEvent("Play_OBJ_ammo_pickup_01", ((Component)player).gameObject);
			((GameActor)player).PlayEffectOnActor(((Component)PickupObjectDatabase.GetById(78)).GetComponent<AmmoPickup>().pickupVFX, Vector3.zero, true, false, false);
			gun.GainAmmo(150);
		}
		((AdvancedGunBehavior)this).OnReloadPressedSafe(player, gun, manualReload);
	}
}
