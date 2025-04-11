using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class DecretionCarbine : GunBehaviour
{
	public static int ID;

	public static void Add()
	{
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Decretion Carbine", "decretioncarbine");
		Game.Items.Rename("outdated_gun_mods:decretion_carbine", "nn:decretion_carbine");
		((Component)val).gameObject.AddComponent<DecretionCarbine>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Shrinky Shrinky");
		GunExt.SetLongDescription((PickupObject)(object)val, "The bullets of this rapid firing bronze marvel were originally indended to grow in size and damage as they travelled. Unfortunately, the blueprint was read upside down, and the effect was reversed.");
		val.SetGunSprites("decretioncarbine");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 15);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 0);
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(15);
		gunSwitchGroup = ((Gun)((byId2 is Gun) ? byId2 : null)).gunSwitchGroup;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(38);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 0.1f;
		val.DefaultModule.numberOfShotsInClip = 10;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.75f, 0.9375f, 0f);
		val.SetBaseMaxAmmo(450);
		val.gunClass = (GunClass)10;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("DecretionCarbine Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/decretioncarbine_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/decretioncarbine_clipempty");
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		val2.SetProjectileSprite("decretioncarbine_proj", 15, 15, lightened: true, (Anchor)4, 15, 15, anchorChangesCollider: true, fixesScale: false, null, null);
		val2.baseData.damage = 10f;
		ScaleChangeOverTimeModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<ScaleChangeOverTimeModifier>(((Component)val2).gameObject);
		orAddComponent.destroyAfterChange = true;
		orAddComponent.timeToChangeOver = 0.4f;
		orAddComponent.ScaleToChangeTo = 0.001f;
		orAddComponent.suppressDeathFXIfdestroyed = true;
		orAddComponent.scaleMultAffectsDamage = true;
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
	}
}
