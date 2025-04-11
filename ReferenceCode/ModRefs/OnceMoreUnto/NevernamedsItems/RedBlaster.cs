using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class RedBlaster : AdvancedGunBehavior
{
	public static void Add()
	{
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Red Blaster", "redblaster");
		Game.Items.Rename("outdated_gun_mods:red_blaster", "nn:red_blaster");
		RedBlaster redBlaster = ((Component)val).gameObject.AddComponent<RedBlaster>();
		((AdvancedGunBehavior)redBlaster).preventNormalFireAudio = true;
		GunExt.SetShortDescription((PickupObject)(object)val, "King of Crimson");
		GunExt.SetLongDescription((PickupObject)(object)val, "Fires pure, concentrated red.\n\nInvented by a mad chromatologist deep in his underground lab...");
		GunInt.SetupSprite(val, Initialisation.gunCollection, "redblaster_idle_001", 8, "redblaster_ammonomicon_001");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 8);
		val.isAudioLoop = true;
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.doesScreenShake = false;
		val.DefaultModule.ammoCost = 4;
		val.DefaultModule.angleVariance = 0f;
		val.DefaultModule.shootStyle = (ShootStyle)2;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		val.DefaultModule.cooldownTime = 0.001f;
		val.DefaultModule.numberOfShotsInClip = -1;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = "red_beam";
		((Component)val.barrelOffset).transform.localPosition = new Vector3(0.875f, 0.375f, 0f);
		val.SetBaseMaxAmmo(900);
		val.ammo = 900;
		val.gunClass = (GunClass)20;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).wrapMode = (WrapMode)1;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).loopStart = 1;
		PickupObject byId2 = PickupObjectDatabase.GetById(658);
		Projectile val2 = Object.Instantiate<Projectile>(((Gun)((byId2 is Gun) ? byId2 : null)).Volley.projectiles[3].projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val2.baseData.damage = 33f;
		TintingBeamModifier tintingBeamModifier = ((Component)val2).gameObject.AddComponent<TintingBeamModifier>();
		tintingBeamModifier.designatedSource = "RedBlaster";
		val.DefaultModule.projectiles[0] = val2;
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
	}
}
