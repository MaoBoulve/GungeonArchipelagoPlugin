using System.Collections.Generic;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class G11 : AdvancedGunBehavior
{
	public static int ID;

	public static void Add()
	{
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_0221: Unknown result type (might be due to invalid IL or missing references)
		//IL_0226: Unknown result type (might be due to invalid IL or missing references)
		//IL_0230: Unknown result type (might be due to invalid IL or missing references)
		//IL_0235: Unknown result type (might be due to invalid IL or missing references)
		//IL_023c: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("G11", "g11");
		Game.Items.Rename("outdated_gun_mods:g11", "nn:g11");
		G11 g = ((Component)val).gameObject.AddComponent<G11>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Kechler and Hock");
		GunExt.SetLongDescription((PickupObject)(object)val, "Revolutionary recoil mitigation mechanisms cause the first two shots in each magazine of this clockwork marvel to fire with increased power.\n\nAn old Hegemony prototype. Somehow, never caught on.");
		val.SetGunSprites("g11");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 0);
		PickupObject byId = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(83);
		gunSwitchGroup = ((Gun)((byId2 is Gun) ? byId2 : null)).gunSwitchGroup;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(49);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.burstShotCount = 2;
		val.DefaultModule.shootStyle = (ShootStyle)4;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1.34f;
		val.DefaultModule.cooldownTime = 0.25f;
		val.DefaultModule.burstCooldownTime = 0.1f;
		val.DefaultModule.numberOfShotsInClip = 12;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.0625f, 0.625f, 0f);
		val.SetBaseMaxAmmo(400);
		val.gunClass = (GunClass)10;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = "Rifle";
		PickupObject byId4 = PickupObjectDatabase.GetById(86);
		Projectile val2 = ProjectileUtility.InstantiateAndFakeprefab(((Gun)((byId4 is Gun) ? byId4 : null)).DefaultModule.projectiles[0]);
		ProjectileData baseData = val2.baseData;
		baseData.speed *= 1.2f;
		val2.baseData.damage = 7.5f;
		List<Projectile> projectiles = val.DefaultModule.projectiles;
		PickupObject byId5 = PickupObjectDatabase.GetById(49);
		projectiles[0] = ProjectileUtility.InstantiateAndFakeprefab(((Gun)((byId5 is Gun) ? byId5 : null)).DefaultModule.projectiles[0]);
		val.DefaultModule.usesOptionalFinalProjectile = true;
		val.DefaultModule.numberOfFinalProjectiles = 10;
		val.DefaultModule.finalProjectile = val2;
		val.carryPixelOffset = new IntVector2(10, 0);
		val.carryPixelDownOffset = new IntVector2(-2, -10);
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
	}
}
