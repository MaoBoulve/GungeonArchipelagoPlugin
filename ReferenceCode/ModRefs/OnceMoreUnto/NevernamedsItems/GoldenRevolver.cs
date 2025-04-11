using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class GoldenRevolver : AdvancedGunBehavior
{
	public static int GoldenRevolverID;

	public static void Add()
	{
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Golden Revolver", "goldenrevolver");
		Game.Items.Rename("outdated_gun_mods:golden_revolver", "nn:golden_revolver");
		((Component)val).gameObject.AddComponent<GoldenRevolver>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Pop Pop");
		GunExt.SetLongDescription((PickupObject)(object)val, "A flashy weapon made entirely out of solid gold.\n\nNot to be confused with the AU gun, which is meant to be hidden. This gun is meant to be shown off.");
		GunInt.SetupSprite(val, Initialisation.gunCollection, "goldenrevolver_idle_001", 8, "goldenrevolver_ammonomicon_001");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 10);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 15);
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.reloadAnimation).wrapMode = (WrapMode)0;
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(38);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(38);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 0.1f;
		val.DefaultModule.angleVariance = 5f;
		val.DefaultModule.numberOfShotsInClip = 6;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(38);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.25f, 0.75f, 0f);
		val.SetBaseMaxAmmo(140);
		val.ammo = 140;
		val.gunClass = (GunClass)1;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		AutoDoShadowChainOnSpawn val3 = ((Component)val2).gameObject.AddComponent<AutoDoShadowChainOnSpawn>();
		val3.randomiseChainNum = true;
		val3.randomChainMin = 0;
		val3.randomChainMax = 5;
		val3.pauseLength = 0.05f;
		val.DefaultModule.projectiles[0] = val2;
		val.AddShellCasing(0, 0, 6);
		((PickupObject)val).quality = (ItemQuality)5;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		GoldenRevolverID = ((PickupObject)val).PickupObjectId;
	}
}
