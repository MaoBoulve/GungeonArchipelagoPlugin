using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class BusterGun : AdvancedGunBehavior
{
	public static int ID;

	public static void Add()
	{
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		//IL_020b: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cb: Expected O, but got Unknown
		//IL_02f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_041a: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c4: Expected O, but got Unknown
		Gun val = Databases.Items.NewGun("Buster Gun", "bustergun");
		Game.Items.Rename("outdated_gun_mods:buster_gun", "nn:buster_gun");
		BusterGun busterGun = ((Component)val).gameObject.AddComponent<BusterGun>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Strife");
		GunExt.SetLongDescription((PickupObject)(object)val, "Fires powerful blasts that ripple the air and stop the Gundead in their tracks.\n\nThe true origin of this weapon is unknown, but some Gungeonologists speculate it to be a Pre-Gungeon artefact.");
		val.SetGunSprites("bustergun", 8, noAmmonomicon: false, 2);
		GunExt.SetAnimationFPS(val, val.shootAnimation, 16);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 5);
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.reloadAnimation).wrapMode = (WrapMode)0;
		val.doesScreenShake = true;
		val.gunScreenShake = StaticExplosionDatas.genericLargeExplosion.ss;
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(593);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		val.gunHandedness = (GunHandedness)2;
		PickupObject byId2 = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(180);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 1.5f;
		val.DefaultModule.numberOfShotsInClip = 3;
		val.SetBarrel(63, 15);
		val.SetBaseMaxAmmo(50);
		val.gunClass = (GunClass)45;
		Projectile val2 = ProjectileSetupUtility.MakeProjectile(56, 50f);
		ProjectileData baseData = val2.baseData;
		baseData.speed *= 2f;
		val.DefaultModule.projectiles[0] = val2;
		val2.SetProjectileSprite("bustergun_proj", 29, 10, lightened: true, (Anchor)4, 25, 8, anchorChangesCollider: true, fixesScale: false, null, null);
		GameObject val3 = VFXToolbox.CreateVFXBundle("BusterGunImpact", usesZHeight: false, 0f, 10f, 10f, Color32.op_Implicit(new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue)));
		VFXPool val4 = VFXToolbox.CreateBlankVFXPool(val3);
		val2.hitEffects.tileMapVertical = val4;
		val2.hitEffects.tileMapHorizontal = val4;
		val2.hitEffects.enemy = val4;
		val2.hitEffects.overrideMidairDeathVFX = val3;
		val2.pierceMinorBreakables = true;
		val2.objectImpactEventName = "plasmarifle";
		DistortionWaveDamager distortionWaveDamager = ((Component)val2).gameObject.AddComponent<DistortionWaveDamager>();
		distortionWaveDamager.lockDownDuration = 5f;
		distortionWaveDamager.audioEvent = "Play_WPN_distortion_split_01";
		distortionWaveDamager.Range = 5f;
		val.carryPixelOffset = new IntVector2(1, 4);
		val.AddShellCasing(1, 1, 0, 0, "shell_bustergun");
		GameObject val5 = new GameObject("Smokepoint");
		val5.transform.SetParent(val.shellCasing.transform);
		val5.transform.localPosition = new Vector3(0.4375f, 0.1875f, 0f);
		SpriteSparkler spriteSparkler = val.shellCasing.AddComponent<SpriteSparkler>();
		spriteSparkler.childTarget = "Smokepoint";
		spriteSparkler.doVFX = true;
		spriteSparkler.particlesPerSecond = 3f;
		spriteSparkler.lifetime = 5f;
		spriteSparkler.randomise = true;
		spriteSparkler.VFX = VFXToolbox.CreateVFXBundle("SmallSmokePuff", usesZHeight: false, 0f, -1f, -1f, null);
		val.reloadEffects = VFXToolbox.CreateBlankVFXPool(VFXToolbox.CreateVFXBundle("SmokePlume", usesZHeight: false, 0f, -1f, -1f, null));
		if ((Object)(object)val.reloadOffset == (Object)null)
		{
			GameObject val6 = new GameObject("reloadOffset");
			val6.transform.SetParent(((BraveBehaviour)val).transform);
			val.reloadOffset = val6.transform;
		}
		((Component)val.reloadOffset).transform.localPosition = new Vector3(2.25f, 1.125f, 0f);
		val.AddClipSprites("bustergun");
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
	}
}
