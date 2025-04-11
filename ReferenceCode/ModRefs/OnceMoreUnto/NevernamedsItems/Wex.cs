using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Wex : AdvancedGunBehavior
{
	public static int ID;

	public static void Add()
	{
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_022b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0230: Unknown result type (might be due to invalid IL or missing references)
		//IL_0239: Unknown result type (might be due to invalid IL or missing references)
		//IL_023e: Unknown result type (might be due to invalid IL or missing references)
		//IL_025b: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Wex", "wex");
		Game.Items.Rename("outdated_gun_mods:wex", "nn:wex");
		((Component)val).gameObject.AddComponent<Wex>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Flammensoldat");
		GunExt.SetLongDescription((PickupObject)(object)val, "The wechselapparat is a reliable flamethrower made out of left over car parts and scrap metal. Famous for looking (and nominally behaving) like a pool floatie.");
		val.SetGunSprites("wex", 8, noAmmonomicon: false, 2);
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.reloadAnimation).wrapMode = (WrapMode)0;
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.gunSwitchGroup = "NN_WPN_Flamethrower";
		GunExt.SetAnimationFPS(val, val.shootAnimation, 15);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 13);
		GunExt.SetAnimationFPS(val, val.idleAnimation, 5);
		for (int i = 0; i < 2; i++)
		{
			PickupObject byId2 = PickupObjectDatabase.GetById(181);
			GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		}
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(83);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		foreach (ProjectileModule projectile in val.Volley.projectiles)
		{
			projectile.ammoCost = 1;
			projectile.shootStyle = (ShootStyle)1;
			projectile.sequenceStyle = (ProjectileSequenceStyle)0;
			projectile.cooldownTime = 0.05f;
			projectile.angleVariance = 0f;
			projectile.numberOfShotsInClip = 70;
			ImprovedHelixProjectile val2 = DataCloners.CopyFields<ImprovedHelixProjectile>(ProjectileUtility.InstantiateAndFakeprefab(StandardisedProjectiles.flamethrower));
			val2.helixAmplitude = 2f;
			((Component)val2).GetComponent<ParticleShitter>().particlesPerSecond = 10f;
			projectile.projectiles[0] = (Projectile)(object)val2;
			if (projectile != val.DefaultModule)
			{
				val2.startInverted = true;
				projectile.ammoCost = 0;
			}
		}
		val.SetBaseMaxAmmo(1000);
		val.ammo = 1000;
		val.gunClass = (GunClass)30;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = "Y-Beam Laser";
		val.carryPixelOffset = new IntVector2(-4, 3);
		val.carryPixelDownOffset = new IntVector2(-2, 4);
		val.carryPixelUpOffset = new IntVector2(8, -5);
		val.reloadTime = 1f;
		val.SetBarrel(43, 21);
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
	}
}
