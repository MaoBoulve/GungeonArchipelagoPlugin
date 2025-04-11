using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class TriBeam : AdvancedGunBehavior
{
	public static void Add()
	{
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0315: Unknown result type (might be due to invalid IL or missing references)
		//IL_034e: Unknown result type (might be due to invalid IL or missing references)
		//IL_036c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a1: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Tri-Beam", "tribeam");
		Game.Items.Rename("outdated_gun_mods:tribeam", "nn:tri_beam");
		TriBeam triBeam = ((Component)val).gameObject.AddComponent<TriBeam>();
		((AdvancedGunBehavior)triBeam).preventNormalFireAudio = true;
		GunExt.SetShortDescription((PickupObject)(object)val, "Revolutionary Tech");
		GunExt.SetLongDescription((PickupObject)(object)val, "This seemingly unremarkable tri-core energy weapon actually marks an astounding leap in the furthering of gunsmithing technology.");
		val.SetGunSprites("tribeam");
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
			projectile.numberOfShotsInClip = 1000;
			projectile.ammoType = (AmmoType)2;
			Projectile val2 = ProjectileUtility.SetupProjectile(86);
			tk2dSpriteCollectionData projectileCollection = Initialisation.ProjectileCollection;
			tk2dSpriteAnimation projectileAnimationCollection = Initialisation.projectileAnimationCollection;
			Vector2 val3 = new Vector2(10f, 2f);
			Vector2 val4 = new Vector2(0f, -2f);
			Vector2? val5 = new Vector2(10f, 2f);
			Vector2? val6 = new Vector2(0f, -2f);
			BasicBeamController val7 = BeamBuilders.GenerateAnchoredBeamPrefabBundle(val2, "tribeam_mid_001", projectileCollection, projectileAnimationCollection, "TriBeam_Mid", val3, val4, "LaserBeam_Impact_Blue", (Vector2?)new Vector2(4f, 4f), (Vector2?)new Vector2(-2f, -2f), (string)null, (Vector2?)null, (Vector2?)null, "TriBeam_Start", val5, val6, false, false, (string)null, (string)null, (string)null, 1f, false, (string)null, (string)null, (string)null, 1f);
			EmmisiveBeams orAddComponent = GameObjectExtensions.GetOrAddComponent<EmmisiveBeams>(((Component)val2).gameObject);
			orAddComponent.EmissivePower = 5f;
			orAddComponent.EmissiveColorPower = 5f;
			val2.baseData.damage = 18f;
			ProjectileData baseData = val2.baseData;
			baseData.force *= 1f;
			ProjectileData baseData2 = val2.baseData;
			baseData2.range *= 5f;
			ProjectileData baseData3 = val2.baseData;
			baseData3.speed *= 10f;
			val7.boneType = (BeamBoneType)0;
			if (num == 0)
			{
				val7.endAudioEvent = "Stop_WPN_All";
				val7.startAudioEvent = "Play_WPN_moonscraperLaser_shot_01";
			}
			num++;
			projectile.projectiles[0] = val2;
		}
		val.doesScreenShake = false;
		val.reloadTime = 1f;
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		val.SetBarrel(16, 10);
		val.SetBaseMaxAmmo(1000);
		val.ammo = 1000;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).wrapMode = (WrapMode)1;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).loopStart = 1;
		((PickupObject)val).quality = (ItemQuality)2;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
	}
}
