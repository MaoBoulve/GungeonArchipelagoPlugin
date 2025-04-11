using System.Collections.Generic;
using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Dungeonator;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Solstice : AdvancedGunBehavior
{
	public static void Add()
	{
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_020d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_0289: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_037f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0396: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0409: Unknown result type (might be due to invalid IL or missing references)
		//IL_041d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0431: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_0518: Unknown result type (might be due to invalid IL or missing references)
		//IL_0565: Unknown result type (might be due to invalid IL or missing references)
		//IL_0594: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b2: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Solstice", "solstice");
		Game.Items.Rename("outdated_gun_mods:solstice", "nn:solstice");
		Solstice solstice = ((Component)val).gameObject.AddComponent<Solstice>();
		((AdvancedGunBehavior)solstice).preventNormalFireAudio = true;
		GunExt.SetShortDescription((PickupObject)(object)val, "Flaring Muzzle");
		GunExt.SetLongDescription((PickupObject)(object)val, "Contains a miniature portal directly to the core of Gunymede's star, channeling immense thermal and gravitational energies.");
		val.SetGunSprites("solstice", 8, noAmmonomicon: false, 2);
		GunExt.SetAnimationFPS(val, val.shootAnimation, 8);
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).wrapMode = (WrapMode)1;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).loopStart = 1;
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 12);
		val.isAudioLoop = true;
		val.gunClass = (GunClass)20;
		for (int i = 0; i < 2; i++)
		{
			PickupObject byId = PickupObjectDatabase.GetById(86);
			GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		}
		val.Volley.projectiles[0].angleVariance = 0f;
		val.Volley.projectiles[0].ammoCost = 11;
		val.Volley.projectiles[0].shootStyle = (ShootStyle)2;
		val.Volley.projectiles[0].sequenceStyle = (ProjectileSequenceStyle)0;
		val.Volley.projectiles[0].cooldownTime = 0.001f;
		val.Volley.projectiles[0].numberOfShotsInClip = 400;
		Projectile val2 = ProjectileUtility.SetupProjectile(86);
		tk2dSpriteCollectionData projectileCollection = Initialisation.ProjectileCollection;
		tk2dSpriteAnimation projectileAnimationCollection = Initialisation.projectileAnimationCollection;
		Vector2 val3 = new Vector2(16f, 4f);
		Vector2 val4 = new Vector2(0f, -2f);
		Vector2? val5 = new Vector2(16f, 4f);
		Vector2? val6 = new Vector2(0f, -2f);
		BasicBeamController val7 = BeamBuilders.GenerateAnchoredBeamPrefabBundle(val2, "solsticebeam_mid_001", projectileCollection, projectileAnimationCollection, "SolsticeBeam_Mid", val3, val4, "SolsticeBeam_Impact", (Vector2?)new Vector2(4f, 4f), (Vector2?)new Vector2(-2f, -2f), (string)null, (Vector2?)null, (Vector2?)null, "SolsticeBeam_Start", val5, val6, false, false, (string)null, (string)null, (string)null, 1f, false, (string)null, (string)null, (string)null, 1f);
		EmmisiveBeams orAddComponent = GameObjectExtensions.GetOrAddComponent<EmmisiveBeams>(((Component)val2).gameObject);
		orAddComponent.EmissivePower = 100f;
		orAddComponent.EmissiveColorPower = 100f;
		orAddComponent.EmissiveColor = new Color(1f, 0.6313726f, 0f);
		((Object)((Component)val2).gameObject).name = "Solstice Beam";
		val2.baseData.damage = 20f;
		val2.baseData.force = 20f;
		val2.baseData.range = 100f;
		val2.baseData.speed = 60f;
		val7.boneType = (BeamBoneType)2;
		val7.endAudioEvent = "Stop_WPN_demonhead_loop_01";
		val7.startAudioEvent = "Play_WPN_demonhead_shot_01";
		BeamAutoAddMotionModule beamAutoAddMotionModule = ((Component)val2).gameObject.AddComponent<BeamAutoAddMotionModule>();
		beamAutoAddMotionModule.Orbit = true;
		beamAutoAddMotionModule.beamOrbitRadius = 2f;
		val.Volley.projectiles[0].projectiles[0] = val2;
		val.Volley.projectiles[1].angleVariance = 0f;
		val.Volley.projectiles[1].ammoCost = 0;
		val.Volley.projectiles[1].shootStyle = (ShootStyle)2;
		val.Volley.projectiles[1].sequenceStyle = (ProjectileSequenceStyle)0;
		val.Volley.projectiles[1].cooldownTime = 0.001f;
		val.Volley.projectiles[1].numberOfShotsInClip = 400;
		Projectile val8 = ProjectileUtility.SetupProjectile(86);
		BasicBeamController val9 = BeamBuilders.GenerateAnchoredBeamPrefabBundle(val8, "solsticebeam2_mid_001", Initialisation.ProjectileCollection, Initialisation.projectileAnimationCollection, "SolsticeBeam2_Mid", new Vector2(16f, 4f), new Vector2(0f, -2f), "SolsticeBeam2_Impact", (Vector2?)new Vector2(4f, 4f), (Vector2?)new Vector2(-2f, -2f), (string)null, (Vector2?)null, (Vector2?)null, (string)null, (Vector2?)null, (Vector2?)null, false, false, (string)null, (string)null, (string)null, 1f, false, (string)null, (string)null, (string)null, 1f);
		EmmisiveBeams orAddComponent2 = GameObjectExtensions.GetOrAddComponent<EmmisiveBeams>(((Component)val2).gameObject);
		orAddComponent2.EmissivePower = 40f;
		orAddComponent2.EmissiveColorPower = 40f;
		orAddComponent2.EmissiveColor = new Color(1f, 0.9254902f, 0.36862746f);
		((Object)((Component)val8).gameObject).name = "Solstice Beam Small";
		val8.baseData.damage = 10f;
		val8.baseData.force = 10f;
		val8.baseData.range = 100f;
		val8.baseData.speed = 60f;
		val9.boneType = (BeamBoneType)2;
		val.Volley.projectiles[1].projectiles[0] = val8;
		ref ScreenShakeSettings gunScreenShake = ref val.gunScreenShake;
		PickupObject byId2 = PickupObjectDatabase.GetById(60);
		gunScreenShake = ((Gun)((byId2 is Gun) ? byId2 : null)).gunScreenShake;
		val.reloadTime = 1.25f;
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		val.SetBarrel(59, 29);
		val.SetBaseMaxAmmo(800);
		val.ammo = 800;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = "Y-Beam Laser";
		val.gunHandedness = (GunHandedness)1;
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
	}

	public override void OnReload(PlayerController player, Gun gun)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		Exploder.DoRadialKnockback(Vector2.op_Implicit(((GameActor)player).CenterPosition), 30f, 5f);
		if (!((Object)(object)player != (Object)null) || player.CurrentRoom == null)
		{
			return;
		}
		List<AIActor> activeEnemies = player.CurrentRoom.GetActiveEnemies((ActiveEnemyType)0);
		if (activeEnemies != null)
		{
			for (int i = 0; i < activeEnemies.Count; i++)
			{
				AIActor val = activeEnemies[i];
				if (val.IsNormalEnemy && Vector2.Distance(((GameActor)val).CenterPosition, ((GameActor)player).CenterPosition) <= 4f)
				{
					((BraveBehaviour)val).gameActor.ApplyEffect((GameActorEffect)(object)StaticStatusEffects.SunlightBurn, 1f, (Projectile)null);
				}
			}
		}
		((AdvancedGunBehavior)this).OnReload(player, gun);
	}
}
