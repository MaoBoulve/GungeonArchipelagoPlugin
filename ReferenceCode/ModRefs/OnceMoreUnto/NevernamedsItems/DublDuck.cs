using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class DublDuck : AdvancedGunBehavior
{
	public static int ID;

	public static void Add()
	{
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Dub'l Duck", "dublduck");
		Game.Items.Rename("outdated_gun_mods:dub'l_duck", "nn:dubl_duck");
		DublDuck dublDuck = ((Component)val).gameObject.AddComponent<DublDuck>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Quackpot");
		GunExt.SetLongDescription((PickupObject)(object)val, "An existing bolt action pistol model with a customised grip, shamelessly shipped to the Gungeon by it's own creator in an attempt to raise his own notoriety.");
		val.SetGunSprites("dublduck");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		PickupObject byId = PickupObjectDatabase.GetById(49);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 0.9f;
		val.DefaultModule.cooldownTime = 0.1f;
		val.DefaultModule.numberOfShotsInClip = 2;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.8125f, 0.75f, 0f);
		val.SetBaseMaxAmmo(100);
		val.gunClass = (GunClass)15;
		Projectile val2 = ProjectileUtility.InstantiateAndFakeprefab(val.DefaultModule.projectiles[0]);
		val.DefaultModule.projectiles[0] = val2;
		val2.baseData.damage = 15f;
		ProjectileShootbackMod projectileShootbackMod = ((Component)val2).gameObject.AddComponent<ProjectileShootbackMod>();
		projectileShootbackMod.prefabToFire = ((Gun)PickupObjectDatabase.GetById(27)).DefaultModule.finalProjectile;
		projectileShootbackMod.shootBackOnDestruction = true;
		val2.pierceMinorBreakables = true;
		((PickupObject)val).quality = (ItemQuality)2;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
	}
}
