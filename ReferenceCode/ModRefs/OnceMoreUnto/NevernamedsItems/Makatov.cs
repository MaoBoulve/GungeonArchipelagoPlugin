using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Makatov : AdvancedGunBehavior
{
	public static int ID;

	public static void Add()
	{
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Makatov", "makatov");
		Game.Items.Rename("outdated_gun_mods:makatov", "nn:makatov");
		Makatov makatov = ((Component)val).gameObject.AddComponent<Makatov>();
		GunExt.SetShortDescription((PickupObject)(object)val, "A drink with the meal");
		GunExt.SetLongDescription((PickupObject)(object)val, "A gun grip hastily glued to the bottom of a molotov.\n\nSpits puffs of flame.");
		val.SetGunSprites("makatov");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		PickupObject byId = PickupObjectDatabase.GetById(59);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(125);
		gunSwitchGroup = ((Gun)((byId2 is Gun) ? byId2 : null)).gunSwitchGroup;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1.2f;
		val.DefaultModule.cooldownTime = 0.2f;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(42);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		val.DefaultModule.numberOfShotsInClip = 20;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.75f, 1.0625f, 0f);
		val.SetBaseMaxAmmo(230);
		val.gunClass = (GunClass)30;
		Projectile val2 = ProjectileUtility.InstantiateAndFakeprefab(StandardisedProjectiles.flamethrower);
		val2.baseData.damage = 4f;
		val.DefaultModule.projectiles[0] = val2;
		val2.pierceMinorBreakables = true;
		AdvancedFireOnReloadSynergyProcessor val3 = ((Component)val).gameObject.AddComponent<AdvancedFireOnReloadSynergyProcessor>();
		val3.synergyToCheck = "Molotovs Revenge";
		val3.angleVariance = 5f;
		val3.numToFire = 1;
		ref Projectile projToFire = ref val3.projToFire;
		PickupObject byId4 = PickupObjectDatabase.GetById(292);
		projToFire = ((Gun)((byId4 is Gun) ? byId4 : null)).DefaultModule.projectiles[0];
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
	}
}
