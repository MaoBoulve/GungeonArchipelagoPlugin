using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class C7A2 : AdvancedGunBehavior
{
	public static int ID;

	public static void Add()
	{
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0213: Unknown result type (might be due to invalid IL or missing references)
		//IL_0218: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		//IL_0247: Unknown result type (might be due to invalid IL or missing references)
		//IL_024c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_029c: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("C7A2", "cza2");
		Game.Items.Rename("outdated_gun_mods:c7a2", "nn:c7a2");
		C7A2 c7A = ((Component)val).gameObject.AddComponent<C7A2>();
		GunExt.SetShortDescription((PickupObject)(object)val, "O'");
		GunExt.SetLongDescription((PickupObject)(object)val, "A standard issue military rifle from a Pre-Hegemony civilisation.");
		val.SetGunSprites("cza2");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 16);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 0);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(96);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		val.gunHandedness = (GunHandedness)1;
		for (int i = 0; i < 3; i++)
		{
			PickupObject byId2 = PickupObjectDatabase.GetById(86);
			GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		}
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(96);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		val.reloadTime = 2f;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.875f, 0.5f, 0f);
		val.SetBaseMaxAmmo(650);
		val.ammo = 650;
		val.gunClass = (GunClass)10;
		int num = 0;
		foreach (ProjectileModule projectile in val.Volley.projectiles)
		{
			projectile.ammoCost = 1;
			projectile.shootStyle = (ShootStyle)1;
			projectile.sequenceStyle = (ProjectileSequenceStyle)0;
			projectile.cooldownTime = 0.19f;
			projectile.angleVariance = 0f;
			projectile.numberOfShotsInClip = 20;
			Projectile val2 = ProjectileSetupUtility.MakeProjectile(86, 2.5f, 700f, 30f);
			val2.baseData.force = 4f;
			ref ProjectileImpactVFXPool hitEffects = ref val2.hitEffects;
			PickupObject byId4 = PickupObjectDatabase.GetById(15);
			hitEffects = ((Gun)((byId4 is Gun) ? byId4 : null)).DefaultModule.projectiles[0].hitEffects;
			projectile.projectiles[0] = val2;
			switch (num)
			{
			case 0:
				projectile.positionOffset = Vector2.op_Implicit(new Vector2(0f, -0.3f));
				projectile.ammoCost = 0;
				break;
			case 1:
				projectile.ammoCost = 1;
				break;
			case 2:
				projectile.positionOffset = Vector2.op_Implicit(new Vector2(0f, 0.3f));
				projectile.ammoCost = 0;
				break;
			}
			num++;
		}
		val.DefaultModule.ammoType = (AmmoType)0;
		val.AddShellCasing();
		((PickupObject)val).quality = (ItemQuality)2;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)3, 1f);
		ID = ((PickupObject)val).PickupObjectId;
	}
}
