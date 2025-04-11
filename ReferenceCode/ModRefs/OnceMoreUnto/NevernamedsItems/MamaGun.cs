using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class MamaGun : GunBehaviour
{
	public static void Add()
	{
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Mama", "mama2");
		Game.Items.Rename("outdated_gun_mods:mama", "nn:mama");
		((Component)val).gameObject.AddComponent<MamaGun>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Just killed a man...");
		GunExt.SetLongDescription((PickupObject)(object)val, "Heavy with symbolism, this gun was brought to the Gungeon by a poor boy with many regrets.\n\nDoes significantly more damage when placed right against an enemy, and fired at point-blank range.");
		GunInt.SetupSprite(val, Initialisation.gunCollection, "mama2_idle_001", 8, "mama2_ammonomicon_001");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 15);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 15);
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.reloadAnimation).wrapMode = (WrapMode)0;
		PickupObject byId = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(38);
		gunSwitchGroup = ((Gun)((byId2 is Gun) ? byId2 : null)).gunSwitchGroup;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 0.1f;
		val.DefaultModule.numberOfShotsInClip = 15;
		val.SetBarrel(22, 13);
		val.SetBaseMaxAmmo(200);
		val.gunClass = (GunClass)1;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(80);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 1.5f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.speed *= 1f;
		PutAGunAgainstHisHeadPulledMyTriggerNowHesDeadBehaviour putAGunAgainstHisHeadPulledMyTriggerNowHesDeadBehaviour = ((Component)val2).gameObject.AddComponent<PutAGunAgainstHisHeadPulledMyTriggerNowHesDeadBehaviour>();
		val.AddShellCasing(1, 1, 0, 0, "shell_bigbeige");
		val.AddClipDebris(0, 1, "clipdebris_mama");
		val.AddClipSprites("mama");
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
	}
}
