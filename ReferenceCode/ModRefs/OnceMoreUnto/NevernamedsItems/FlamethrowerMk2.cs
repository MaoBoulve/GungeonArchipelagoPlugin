using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class FlamethrowerMk2 : GunBehaviour
{
	public static int ID;

	public static void Add()
	{
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Flamethrower Mk 2", "flamethrowermk2");
		Game.Items.Rename("outdated_gun_mods:flamethrower_mk_2", "nn:flamethrower_mk_2");
		((Component)val).gameObject.AddComponent<FlamethrowerMk2>();
		GunExt.SetShortDescription((PickupObject)(object)val, "I Fear No Man");
		GunExt.SetLongDescription((PickupObject)(object)val, "Spews an ignited gasoline vapor.\n\nThe favoured weapon of Lucinda Burns as part of her 'char-grill' fighting technique.");
		val.SetGunSprites("flamethrowermk2");
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.AddCustomSwitchGroup("NN_WPN_Flamethrower", "Play_ENM_flame_veil_01", "Play_BOSS_FuseBomb_Attack_Flame_01");
		val.doesScreenShake = false;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId2 = PickupObjectDatabase.GetById(83);
		muzzleFlashEffects = ((Gun)((byId2 is Gun) ? byId2 : null)).muzzleFlashEffects;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1.2f;
		val.DefaultModule.cooldownTime = 0.025f;
		val.DefaultModule.numberOfShotsInClip = 130;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.5f, 0.6875f, 0f);
		val.SetBaseMaxAmmo(1300);
		val.ammo = 1300;
		val.gunClass = (GunClass)30;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = "Y-Beam Laser";
		val.DefaultModule.angleVariance = 10f;
		Projectile val2 = ProjectileUtility.InstantiateAndFakeprefab(StandardisedProjectiles.flamethrower);
		((Component)val2).GetComponent<ParticleShitter>().particlesPerSecond = 20f;
		val.DefaultModule.projectiles[0] = val2;
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
	}
}
