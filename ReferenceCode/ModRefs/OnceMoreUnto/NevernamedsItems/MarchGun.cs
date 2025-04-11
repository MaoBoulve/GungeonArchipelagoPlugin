using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class MarchGun : GunBehaviour
{
	public static int DemolitionistID;

	public static void Add()
	{
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_034d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0373: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("March Gun", "marchgun");
		Game.Items.Rename("outdated_gun_mods:march_gun", "nn:march_gun");
		((Component)val).gameObject.AddComponent<MarchGun>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Direct To The Point");
		GunExt.SetLongDescription((PickupObject)(object)val, "Deals bonus damage when fired in the same direction the user is moving.\n\nBrought to the Gungeon by notorious tapdancer Tom Toe Tucker.");
		GunInt.SetupSprite(val, Initialisation.gunCollection, "marchgun_idle_001", 8, "marchgun_ammonomicon_001");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(732);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 0.1f;
		val.DefaultModule.numberOfShotsInClip = 9;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.37f, 0.63f, 0f);
		val.SetBaseMaxAmmo(222);
		val.gunClass = (GunClass)1;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(18);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		val2.baseData.damage = 7.5f;
		ProjectileData baseData = val2.baseData;
		baseData.speed *= 1f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.range *= 1f;
		val2.hitEffects.overrideMidairDeathVFX = SharedVFX.SmoothLightBlueLaserCircleVFX;
		val2.hitEffects.alwaysUseMidair = true;
		val2.SetProjectileSprite("march_none_projectile", 9, 9, lightened: false, (Anchor)4, 7, 7, anchorChangesCollider: true, fixesScale: false, null, null);
		GunTools.SetupDefinitionForProjectileSprite("march_left_projectile", Databases.Items.ProjectileCollection.inst.GetSpriteIdByName("march_left_projectile"), 17, 11, false, (int?)15, (int?)9, (int?)0, (int?)0, (Projectile)null);
		GunTools.SetupDefinitionForProjectileSprite("march_right_projectile", Databases.Items.ProjectileCollection.inst.GetSpriteIdByName("march_right_projectile"), 17, 11, false, (int?)15, (int?)9, (int?)0, (int?)0, (Projectile)null);
		GunTools.SetupDefinitionForProjectileSprite("march_up_projectile", Databases.Items.ProjectileCollection.inst.GetSpriteIdByName("march_up_projectile"), 11, 17, false, (int?)9, (int?)15, (int?)0, (int?)0, (Projectile)null);
		GunTools.SetupDefinitionForProjectileSprite("march_down_projectile", Databases.Items.ProjectileCollection.inst.GetSpriteIdByName("march_down_projectile"), 11, 17, false, (int?)9, (int?)15, (int?)0, (int?)0, (Projectile)null);
		((Component)val2).gameObject.AddComponent<MarchGunBulletController>();
		((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("March gun Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/marchgun_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/marchgun_clipempty");
		((PickupObject)val).quality = (ItemQuality)2;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		DemolitionistID = ((PickupObject)val).PickupObjectId;
	}
}
