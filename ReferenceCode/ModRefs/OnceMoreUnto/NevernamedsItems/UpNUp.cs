using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class UpNUp : AdvancedGunBehavior
{
	public static void Add()
	{
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Up-N-Up", "upnup");
		Game.Items.Rename("outdated_gun_mods:upnup", "nn:up_n_up");
		((Component)val).gameObject.AddComponent<UpNUp>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Great Potential");
		GunExt.SetLongDescription((PickupObject)(object)val, "Though this pistol on it's own is unremarkable, the damage of it's bullets is affected TWICE by any bullet stat modifiers you recieve.");
		GunInt.SetupSprite(val, Initialisation.gunCollection, "upnup_idle_001", 8, "upnup_ammonomicon_001");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 0.5f;
		val.DefaultModule.cooldownTime = 0.2f;
		val.DefaultModule.numberOfShotsInClip = 7;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.31f, 0.81f, 0f);
		val.SetBaseMaxAmmo(500);
		val.gunClass = (GunClass)1;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 1f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.speed *= 1f;
		ProjectileData baseData3 = val2.baseData;
		baseData3.range *= 1f;
		((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("UpNUp Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/upnup_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/upnup_clipempty");
		((PickupObject)val).quality = (ItemQuality)1;
		((BraveBehaviour)val).encounterTrackable.EncounterGuid = "this is the Up-N-Up";
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		((AdvancedGunBehavior)this).PostProcessProjectile(projectile);
		GameActor owner = projectile.Owner;
		PlayerController val = (PlayerController)(object)((owner is PlayerController) ? owner : null);
		ProjectileData baseData = projectile.baseData;
		baseData.damage *= val.stats.GetStatValue((StatType)5);
		ProjectileData baseData2 = projectile.baseData;
		baseData2.speed *= val.stats.GetStatValue((StatType)6);
		ProjectileData baseData3 = projectile.baseData;
		baseData3.force *= val.stats.GetStatValue((StatType)12);
		projectile.BossDamageMultiplier *= val.stats.GetStatValue((StatType)22);
		projectile.UpdateSpeed();
	}
}
