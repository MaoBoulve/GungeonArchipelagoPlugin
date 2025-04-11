using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Bleech : AdvancedGunBehavior
{
	public static void Add()
	{
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Bleech", "bleech");
		Game.Items.Rename("outdated_gun_mods:bleech", "nn:bleech");
		Bleech bleech = ((Component)val).gameObject.AddComponent<Bleech>();
		GunExt.SetShortDescription((PickupObject)(object)val, "");
		GunExt.SetLongDescription((PickupObject)(object)val, "");
		GunExt.SetupSprite(val, (tk2dSpriteCollectionData)null, "bleech_idle_001", 8);
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(198);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(80);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.5f, 0.81f, 0f);
		val.reloadTime = 1.3f;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.DefaultModule.cooldownTime = 0.1f;
		val.DefaultModule.numberOfShotsInClip = 7;
		val.gunClass = (GunClass)50;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val2.hitEffects.overrideMidairDeathVFX = SharedVFX.RedLaserCircleVFX;
		val2.hitEffects.alwaysUseMidair = true;
		val.DefaultModule.projectiles[0] = val2;
		((PickupObject)val).quality = (ItemQuality)(-100);
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
	}
}
