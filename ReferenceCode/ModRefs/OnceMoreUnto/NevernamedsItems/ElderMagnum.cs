using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class ElderMagnum : AdvancedGunBehavior
{
	public static void Add()
	{
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Elder Magnum", "eldermagnum2");
		Game.Items.Rename("outdated_gun_mods:elder_magnum", "nn:elder_magnum");
		ElderMagnum elderMagnum = ((Component)val).gameObject.AddComponent<ElderMagnum>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Guncestral");
		GunExt.SetLongDescription((PickupObject)(object)val, "An ancient firearm, left to age in some safe over hundreds of years.\n\nWhoever owned this gun has probably been slinging since before your great grandpappy was born.");
		GunInt.SetupSprite(val, Initialisation.gunCollection, "eldermagnum2_idle_001", 8, "eldermagnum2_ammonomicon_001");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 14);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(198);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(80);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1.3f;
		val.DefaultModule.cooldownTime = 0.1f;
		val.DefaultModule.numberOfShotsInClip = 7;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.5f, 0.81f, 0f);
		val.InfiniteAmmo = true;
		val.gunClass = (GunClass)55;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val2.hitEffects.overrideMidairDeathVFX = SharedVFX.RedLaserCircleVFX;
		val2.hitEffects.alwaysUseMidair = true;
		ProjectileBuilders.SetProjectileCollisionRight(val2, "eldermagnum_projectile", Initialisation.ProjectileCollection, 5, 5, true, (Anchor)4, (int?)4, (int?)4, true, false, (int?)null, (int?)null, (Projectile)null);
		val.DefaultModule.projectiles[0] = val2;
		val.AddShellCasing(1, 0, 0, 0, "shell_red");
		val.shellCasing.gameObject.AddComponent<ClipBurner>();
		val.AddClipSprites("riskrifle");
		((PickupObject)val).quality = (ItemQuality)(-100);
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
	}
}
