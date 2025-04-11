using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class StickGun : AdvancedGunBehavior
{
	public static int ID;

	public static void Add()
	{
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ef: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Stick Gun", "stickgun");
		Game.Items.Rename("outdated_gun_mods:stick_gun", "nn:stick_gun");
		StickGun stickGun = ((Component)val).gameObject.AddComponent<StickGun>();
		((AdvancedGunBehavior)stickGun).preventNormalReloadAudio = true;
		((AdvancedGunBehavior)stickGun).preventNormalFireAudio = true;
		((AdvancedGunBehavior)stickGun).overrideNormalFireAudio = "Play_PencilScratch";
		GunExt.SetShortDescription((PickupObject)(object)val, "Scribble");
		GunExt.SetLongDescription((PickupObject)(object)val, "Carried by a brave stickman as he ventured through the pages of a bored child's homework.\n\nHe may be long erased, but his legacy lives on.");
		GunInt.SetupSprite(val, Initialisation.gunCollection, "stickgun_idle_001", 8, "stickgun_ammonomicon_001");
		PickupObject byId = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 0.7f;
		val.DefaultModule.cooldownTime = 0.1f;
		val.DefaultModule.numberOfShotsInClip = 3;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(0.93f, 0.68f, 0f);
		val.SetBaseMaxAmmo(222);
		val.ammo = 222;
		val.gunClass = (GunClass)55;
		val.gunHandedness = (GunHandedness)2;
		val.muzzleFlashEffects = VFXToolbox.CreateVFXPoolBundle("StickGunMuzzle", usesZHeight: false, 0f, (VFXAlignment)0, -1f, null);
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val2.baseData.damage = 6f;
		ProjectileData baseData = val2.baseData;
		baseData.speed *= 1.5f;
		PierceProjModifier val3 = ((Component)val2).gameObject.AddComponent<PierceProjModifier>();
		val3.penetration = 1;
		val2.SetProjectileSprite("stickgun_projectile", 12, 2, lightened: false, (Anchor)4, 12, 2, anchorChangesCollider: true, fixesScale: false, null, null);
		val.DefaultModule.projectiles[0] = val2;
		val2.hitEffects.overrideMidairDeathVFX = VFXToolbox.CreateVFXBundle("StickGunMidair", usesZHeight: false, 0f, -1f, -1f, null);
		val2.hitEffects.tileMapHorizontal = VFXToolbox.CreateVFXPoolBundle("StickGunTilemapHoriz", usesZHeight: false, 0f, (VFXAlignment)1, -1f, null);
		val2.hitEffects.tileMapVertical = VFXToolbox.CreateVFXPoolBundle("StickGunTilemapVert", usesZHeight: false, 0f, (VFXAlignment)1, -1f, null);
		val2.hitEffects.enemy = VFXToolbox.CreateVFXPoolBundle("StickGunEnemyImpact", usesZHeight: false, 0f, (VFXAlignment)0, -1f, null);
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("StickGun Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/stickgun_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/stickgun_clipempty");
		((PickupObject)val).quality = (ItemQuality)1;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
	}
}
