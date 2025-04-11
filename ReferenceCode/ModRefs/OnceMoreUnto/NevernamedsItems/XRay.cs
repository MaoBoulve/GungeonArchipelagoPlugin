using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class XRay : AdvancedGunBehavior
{
	public static void Add()
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0312: Unknown result type (might be due to invalid IL or missing references)
		//IL_033a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0341: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0257: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("X-Ray", "xray");
		Game.Items.Rename("outdated_gun_mods:xray", "nn:x_ray");
		XRay xRay = ((Component)val).gameObject.AddComponent<XRay>();
		((AdvancedGunBehavior)xRay).preventNormalFireAudio = true;
		GunExt.SetShortDescription((PickupObject)(object)val, "Ionizing");
		GunExt.SetLongDescription((PickupObject)(object)val, "A portable medical imaging device brought to the Gungeon by the Medecins Sans Diplome. Hasn't seen much field use, as diagnosis is a very small part of their standard operating proceedure.");
		val.SetGunSprites("xray", 2, noAmmonomicon: false, 2);
		val.isAudioLoop = true;
		val.gunClass = (GunClass)20;
		int num = 0;
		for (int i = 0; i < 2; i++)
		{
			PickupObject byId = PickupObjectDatabase.GetById(86);
			GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		}
		foreach (ProjectileModule projectile in val.Volley.projectiles)
		{
			projectile.ammoCost = 10;
			if (projectile != val.DefaultModule)
			{
				projectile.ammoCost = 0;
			}
			projectile.shootStyle = (ShootStyle)2;
			projectile.sequenceStyle = (ProjectileSequenceStyle)0;
			projectile.cooldownTime = 0.001f;
			projectile.numberOfShotsInClip = -1;
			projectile.ammoType = (AmmoType)2;
			Projectile val2 = ProjectileUtility.SetupProjectile(86);
			string text = ((num == 0) ? "black" : "white");
			BasicBeamController val3 = BeamBuilders.GenerateAnchoredBeamPrefabBundle(val2, "xraybeam" + text + "_mid_001", Initialisation.ProjectileCollection, Initialisation.projectileAnimationCollection, "xraybeam" + text + "_mid", new Vector2(16f, 4f), new Vector2(0f, -2f), "XRayImpact", (Vector2?)new Vector2(4f, 4f), (Vector2?)new Vector2(-2f, -2f), (string)null, (Vector2?)null, (Vector2?)null, (string)null, (Vector2?)null, (Vector2?)null, false, false, (string)null, (string)null, (string)null, 1f, false, (string)null, (string)null, (string)null, 1f);
			EmmisiveBeams orAddComponent = GameObjectExtensions.GetOrAddComponent<EmmisiveBeams>(((Component)val2).gameObject);
			orAddComponent.EmissivePower = 50f;
			orAddComponent.EmissiveColorPower = 5f;
			val2.baseData.damage = 15f;
			val2.baseData.force = 15f;
			val2.baseData.range = 50f;
			val2.baseData.speed = 50f;
			val3.boneType = (BeamBoneType)2;
			((Object)((Component)val2).gameObject).name = "XRay Beam " + text;
			BeamAutoAddMotionModule beamAutoAddMotionModule = ((Component)val2).gameObject.AddComponent<BeamAutoAddMotionModule>();
			beamAutoAddMotionModule.Helix = true;
			val3.penetration = 2;
			val3.PenetratesCover = true;
			if (num == 0)
			{
				val3.endAudioEvent = "Stop_WPN_All";
				val3.startAudioEvent = "Play_WPN_moonscraperLaser_shot_01";
				beamAutoAddMotionModule.invertHelix = true;
			}
			num++;
			projectile.projectiles[0] = val2;
		}
		val.doesScreenShake = false;
		val.reloadTime = 1f;
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		val.SetBarrel(20, 5);
		val.SetBaseMaxAmmo(500);
		val.ammo = 500;
		val.gunHandedness = (GunHandedness)3;
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
	}
}
