using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class BarcodeScanner : AdvancedGunBehavior
{
	public static int BarcodeScannerID;

	public static void Add()
	{
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0210: Unknown result type (might be due to invalid IL or missing references)
		//IL_0249: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Barcode Scanner", "barcodescanner");
		Game.Items.Rename("outdated_gun_mods:barcode_scanner", "nn:barcode_scanner");
		BarcodeScanner barcodeScanner = ((Component)val).gameObject.AddComponent<BarcodeScanner>();
		((AdvancedGunBehavior)barcodeScanner).overrideNormalReloadAudio = "Play_OBJ_mine_beep_01";
		((AdvancedGunBehavior)barcodeScanner).overrideNormalFireAudio = "Play_OBJ_mine_beep_01";
		((AdvancedGunBehavior)barcodeScanner).preventNormalFireAudio = true;
		((AdvancedGunBehavior)barcodeScanner).preventNormalReloadAudio = true;
		GunExt.SetShortDescription((PickupObject)(object)val, "Beep");
		GunExt.SetLongDescription((PickupObject)(object)val, "Often used in more technologically adept shops to scan items for purchase, but Bello has no idea how to use a computer.");
		val.SetGunSprites("barcodescanner");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 5);
		PickupObject byId = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 0.5f;
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		val.DefaultModule.cooldownTime = 0.35f;
		val.DefaultModule.numberOfShotsInClip = 500;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(0.43f, 0.56f, 0f);
		val.SetBaseMaxAmmo(500);
		val.ammo = 500;
		val.gunClass = (GunClass)55;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val2.baseData.damage = 6f;
		val2.SetProjectileSprite("barcodescanner_projectile", 4, 14, lightened: false, (Anchor)4, 2, 12, anchorChangesCollider: true, fixesScale: false, null, null);
		val2.hitEffects.alwaysUseMidair = true;
		val2.hitEffects.overrideMidairDeathVFX = SharedVFX.RedLaserCircleVFX;
		((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		((Component)val2).gameObject.AddComponent<BarcodeScannerProjectile>();
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)val, (StatType)13, 0.9f, (ModifyMethod)1);
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Barcode Scanner Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/barcodescanner_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/barcodescanner_clipempty");
		val.DefaultModule.projectiles[0] = val2;
		((PickupObject)val).quality = (ItemQuality)1;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		BarcodeScannerID = ((PickupObject)val).PickupObjectId;
	}
}
