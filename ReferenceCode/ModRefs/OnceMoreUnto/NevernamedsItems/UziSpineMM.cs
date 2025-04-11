using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class UziSpineMM : AdvancedGunBehavior
{
	public static int ID;

	public static void Add()
	{
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_021a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0240: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Uzi SPINE-mm", "uzispinemm");
		Game.Items.Rename("outdated_gun_mods:uzi_spinemm", "nn:uzi_spine_mm");
		UziSpineMM uziSpineMM = ((Component)val).gameObject.AddComponent<UziSpineMM>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Boned");
		GunExt.SetLongDescription((PickupObject)(object)val, "The favoured sidearm of the dark sorcerer Nuign, and his first foray into the apocryphal field of necro-gunsmithing.");
		val.SetGunSprites("uzispinemm");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(29);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 0.8f;
		val.DefaultModule.cooldownTime = 0.11f;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(29);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		val.DefaultModule.numberOfShotsInClip = 20;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.1875f, 0.5625f, 0f);
		val.SetBaseMaxAmmo(600);
		val.gunClass = (GunClass)10;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		val2.baseData.damage = 3f;
		val2.baseData.range = 15f;
		val2.hitEffects.alwaysUseMidair = true;
		val2.hitEffects.overrideMidairDeathVFX = SharedVFX.SmoothLightBlueLaserCircleVFX;
		HomingModifier val3 = ((Component)val2).gameObject.AddComponent<HomingModifier>();
		val3.AngularVelocity = 40f;
		val3.HomingRadius = 50f;
		val2.SetProjectileSprite("uzispinemm_proj", 8, 11, lightened: false, (Anchor)4, 8, 7, anchorChangesCollider: true, fixesScale: false, null, null);
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("UziSpineMM Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/uzispinemm_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/uzispinemm_clipempty");
		((PickupObject)val).quality = (ItemQuality)2;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)2, 1f);
		ID = ((PickupObject)val).PickupObjectId;
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		if (Object.op_Implicit((Object)(object)projectile) && Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(projectile)) && CustomSynergies.PlayerHasActiveSynergy(ProjectileUtility.ProjectilePlayerOwner(projectile), "The Bone Zone"))
		{
			HomingModifier component = ((Component)projectile).GetComponent<HomingModifier>();
			if (Object.op_Implicit((Object)(object)component))
			{
				component.AngularVelocity *= 1.5f;
			}
			projectile.pierceMinorBreakables = true;
			PierceProjModifier component2 = ((Component)projectile).GetComponent<PierceProjModifier>();
			if ((Object)(object)component2 != (Object)null)
			{
				PierceProjModifier obj = component2;
				obj.penetration++;
			}
			else
			{
				component2 = ((Component)projectile).gameObject.AddComponent<PierceProjModifier>();
				component2.penetration = 1;
			}
		}
		((AdvancedGunBehavior)this).PostProcessProjectile(projectile);
	}
}
