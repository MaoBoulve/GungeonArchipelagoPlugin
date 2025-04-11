using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class DiamondCutterRangerClass : AdvancedGunBehavior
{
	public static int ID;

	public static void Add()
	{
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0250: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f2: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Red Diamond Cutter", "reddiamondcutter");
		Game.Items.Rename("outdated_gun_mods:red_diamond_cutter", "nn:diamond_cutter+ranger_class");
		DiamondCutterRangerClass diamondCutterRangerClass = ((Component)val).gameObject.AddComponent<DiamondCutterRangerClass>();
		((AdvancedGunBehavior)diamondCutterRangerClass).preventNormalReloadAudio = true;
		((AdvancedGunBehavior)diamondCutterRangerClass).preventNormalFireAudio = true;
		((AdvancedGunBehavior)diamondCutterRangerClass).overrideNormalFireAudio = "Play_WPN_blasphemy_shot_01";
		GunExt.SetShortDescription((PickupObject)(object)val, "Face It!");
		GunExt.SetLongDescription((PickupObject)(object)val, "Fires piercing gemstones.\n\nLeft in a chest by a powerful warrior of shimmering crystal... who didn't show up to work today.");
		val.SetGunSprites("reddiamondcutter", 8, noAmmonomicon: true);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 1);
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId = PickupObjectDatabase.GetById(97);
		muzzleFlashEffects = ((Gun)((byId is Gun) ? byId : null)).muzzleFlashEffects;
		PickupObject byId2 = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		PickupObject byId3 = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId3 is Gun) ? byId3 : null), true, false);
		PickupObject byId4 = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId4 is Gun) ? byId4 : null), true, false);
		foreach (ProjectileModule projectile in val.Volley.projectiles)
		{
			projectile.ammoCost = 1;
			projectile.shootStyle = (ShootStyle)0;
			projectile.sequenceStyle = (ProjectileSequenceStyle)0;
			projectile.cooldownTime = 0.2f;
			projectile.numberOfShotsInClip = 3;
			projectile.angleVariance = 20f;
			Projectile val2 = Object.Instantiate<Projectile>(projectile.projectiles[0]);
			((Component)val2).gameObject.SetActive(false);
			FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
			Object.DontDestroyOnLoad((Object)(object)val2);
			val2.baseData.damage = 10f;
			ProjectileData baseData = val2.baseData;
			baseData.speed *= 1.5f;
			val2.hitEffects.alwaysUseMidair = true;
			ref GameObject overrideMidairDeathVFX = ref val2.hitEffects.overrideMidairDeathVFX;
			PickupObject byId5 = PickupObjectDatabase.GetById(506);
			overrideMidairDeathVFX = ((Gun)((byId5 is Gun) ? byId5 : null)).DefaultModule.projectiles[0].hitEffects.overrideMidairDeathVFX;
			PierceProjModifier val3 = ((Component)val2).gameObject.AddComponent<PierceProjModifier>();
			val3.penetration = 10;
			MaintainDamageOnPierce maintainDamageOnPierce = ((Component)val2).gameObject.AddComponent<MaintainDamageOnPierce>();
			maintainDamageOnPierce.damageMultOnPierce = 1.2f;
			val2.pierceMinorBreakables = true;
			GunTools.SetProjectileSpriteRight(val2, "diamondcutter_proj", 23, 13, false, (Anchor)4, (int?)17, (int?)5, true, false, (int?)null, (int?)null, (Projectile)null);
			projectile.projectiles[0] = val2;
			projectile.ammoType = (AmmoType)14;
			projectile.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("RedDiamondCutter Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/reddiamondcutter_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/diamondcutter_clipempty");
			if (projectile != val.DefaultModule)
			{
				projectile.ammoCost = 0;
			}
		}
		val.reloadTime = 0.8f;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.81f, 1.43f, 0f);
		val.SetBaseMaxAmmo(100);
		val.ammo = 100;
		val.gunClass = (GunClass)50;
		((PickupObject)val).quality = (ItemQuality)(-100);
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
		GunExt.SetName((PickupObject)(object)val, "Diamond Cutter");
	}
}
