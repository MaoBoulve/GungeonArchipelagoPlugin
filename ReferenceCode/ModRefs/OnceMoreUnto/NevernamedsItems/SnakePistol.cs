using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class SnakePistol : AdvancedGunBehavior
{
	public static int ID;

	public static void Add()
	{
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Snake Pistol", "snakepistol");
		Game.Items.Rename("outdated_gun_mods:snake_pistol", "nn:snake_pistol");
		SnakePistol snakePistol = ((Component)val).gameObject.AddComponent<SnakePistol>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Hiss Bang");
		GunExt.SetLongDescription((PickupObject)(object)val, "This starkly cylindrical sidearm hails from a dimension of permanent combat.\n\nContains dehydrated snakes.");
		val.SetGunSprites("snakepistol");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 0);
		PickupObject byId = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(150);
		gunSwitchGroup = ((Gun)((byId2 is Gun) ? byId2 : null)).gunSwitchGroup;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(150);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 0.8f;
		val.DefaultModule.cooldownTime = 0.1f;
		val.DefaultModule.numberOfShotsInClip = 1;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.125f, 0.6875f, 0f);
		val.SetBaseMaxAmmo(100);
		val.gunClass = (GunClass)25;
		Projectile value = ProjectileUtility.InstantiateAndFakeprefab(StandardisedProjectiles.snake);
		val.DefaultModule.projectiles[0] = value;
		val.AddClipSprites("snakeclip");
		((PickupObject)val).quality = (ItemQuality)1;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
		AdvancedHoveringGunSynergyProcessor advancedHoveringGunSynergyProcessor = ((Component)val).gameObject.AddComponent<AdvancedHoveringGunSynergyProcessor>();
		advancedHoveringGunSynergyProcessor.RequiredSynergy = "Serpents Reach";
		advancedHoveringGunSynergyProcessor.requiresTargetGunInInventory = true;
		advancedHoveringGunSynergyProcessor.FireType = (FireType)1;
		advancedHoveringGunSynergyProcessor.Trigger = AdvancedHoveringGunSynergyProcessor.TriggerStyle.CONSTANT;
	}
}
