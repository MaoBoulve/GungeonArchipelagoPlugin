using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Robogun : AdvancedGunBehavior
{
	public static int ID;

	public static void Add()
	{
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_023c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0248: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Robogun", "robogun");
		Game.Items.Rename("outdated_gun_mods:robogun", "nn:robogun");
		Robogun robogun = ((Component)val).gameObject.AddComponent<Robogun>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Aim Electrique");
		GunExt.SetLongDescription((PickupObject)(object)val, "This laser blaster carries an on-board targeting computer so sophisticated that no aiming is required whatsoever- which is good, because the weight of the computer renders the weapon impossible to aim anyways.");
		GunInt.SetupSprite(val, Initialisation.gunCollection, "robogun_idle_001", 8, "robogun_ammonomicon_001");
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(58);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 0);
		PickupObject byId2 = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1.15f;
		val.DefaultModule.cooldownTime = 0.15f;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(58);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		val.DefaultModule.numberOfShotsInClip = 5;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.625f, 0.5625f, 0f);
		val.SetBaseMaxAmmo(200);
		val.gunClass = (GunClass)1;
		Projectile val2 = ProjectileUtility.InstantiateAndFakeprefab(val.DefaultModule.projectiles[0]);
		val.DefaultModule.projectiles[0] = val2;
		val2.baseData.damage = 8f;
		ProjectileData baseData = val2.baseData;
		baseData.speed *= 1.1f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.range *= 10f;
		SelfReAimBehaviour orAddComponent = GameObjectExtensions.GetOrAddComponent<SelfReAimBehaviour>(((Component)val2).gameObject);
		orAddComponent.trigger = SelfReAimBehaviour.ReAimTrigger.IMMEDIATE;
		val2.pierceMinorBreakables = true;
		PierceProjModifier orAddComponent2 = GameObjectExtensions.GetOrAddComponent<PierceProjModifier>(((Component)val2).gameObject);
		orAddComponent2.penetratesBreakables = true;
		orAddComponent2.penetration = 1;
		val2.SetProjectileSprite("robogun_proj", 17, 7, lightened: false, (Anchor)4, 17, 7, anchorChangesCollider: true, fixesScale: false, null, null);
		val2.hitEffects.alwaysUseMidair = true;
		val2.hitEffects.overrideMidairDeathVFX = SharedVFX.RedLaserCircleVFX;
		((PickupObject)val).quality = (ItemQuality)3;
		val.DefaultModule.ammoType = (AmmoType)6;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
	}
}
