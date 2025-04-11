using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class PopGun : AdvancedGunBehavior
{
	public static int PopGunID;

	public static void Add()
	{
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_0244: Unknown result type (might be due to invalid IL or missing references)
		//IL_026a: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Pop Gun", "popgun");
		Game.Items.Rename("outdated_gun_mods:pop_gun", "nn:pop_gun");
		PopGun popGun = ((Component)val).gameObject.AddComponent<PopGun>();
		((AdvancedGunBehavior)popGun).preventNormalReloadAudio = true;
		GunExt.SetShortDescription((PickupObject)(object)val, "Pop Goes");
		GunExt.SetLongDescription((PickupObject)(object)val, "A children's toy.\n\nFires pellets on a string to be reeled back into the barrel. Deals more damage while it's shots are being yanked back in.");
		GunInt.SetupSprite(val, Initialisation.gunCollection, "popgun_idle_001", 8, "popgun_ammonomicon_001");
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(150);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId2 = PickupObjectDatabase.GetById(28);
		muzzleFlashEffects = ((Gun)((byId2 is Gun) ? byId2 : null)).muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId3 is Gun) ? byId3 : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 0.7f;
		val.DefaultModule.cooldownTime = 0.7f;
		val.DefaultModule.numberOfShotsInClip = 1;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.31f, 0.43f, 0f);
		val.SetBaseMaxAmmo(100);
		val.ammo = 100;
		val.gunClass = (GunClass)50;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val2.baseData.damage = 10f;
		ProjectileData baseData = val2.baseData;
		baseData.speed *= 1f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.range *= 10f;
		((Component)val2).gameObject.AddComponent<PopGunBullet>();
		BounceProjModifier val3 = ((Component)val2).gameObject.AddComponent<BounceProjModifier>();
		val3.numberOfBounces += 10;
		PierceProjModifier val4 = ((Component)val2).gameObject.AddComponent<PierceProjModifier>();
		val4.penetration = 10;
		val2.pierceMinorBreakables = true;
		val2.SetProjectileSprite("popgun_proj", 7, 7, lightened: false, (Anchor)4, 6, 6, anchorChangesCollider: true, fixesScale: false, null, null);
		val.DefaultModule.projectiles[0] = val2;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("PopGun Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/popgun_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/popgun_clipempty");
		((PickupObject)val).quality = (ItemQuality)1;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		PopGunID = ((PickupObject)val).PickupObjectId;
	}
}
