using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class UterinePolyp : AdvancedGunBehavior
{
	public static int UterinePolypID;

	public static void Add()
	{
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0226: Unknown result type (might be due to invalid IL or missing references)
		//IL_024c: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Uterine Polyp", "uterinepolyp");
		Game.Items.Rename("outdated_gun_mods:uterine_polyp", "nn:uterine_polyp");
		UterinePolyp uterinePolyp = ((Component)val).gameObject.AddComponent<UterinePolyp>();
		((AdvancedGunBehavior)uterinePolyp).preventNormalFireAudio = true;
		((AdvancedGunBehavior)uterinePolyp).preventNormalReloadAudio = true;
		((AdvancedGunBehavior)uterinePolyp).overrideNormalReloadAudio = "Play_OBJ_cauldron_splash_01";
		((AdvancedGunBehavior)uterinePolyp).overrideNormalFireAudio = "Play_ENM_cult_spew_01";
		GunExt.SetShortDescription((PickupObject)(object)val, "Endometrial");
		GunExt.SetLongDescription((PickupObject)(object)val, "A disgusting teratoma-esque growth cut from a demon's womb.\n\nGenuinely unpleasant to look at, touch, and think about.");
		val.SetGunSprites("uterinepolyp");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 15);
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 0.5f;
		val.DefaultModule.cooldownTime = 0.2f;
		val.DefaultModule.numberOfShotsInClip = 3;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.25f, 0.43f, 0f);
		val.SetBaseMaxAmmo(200);
		val.gunClass = (GunClass)1;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		ProjectileData baseData = val2.baseData;
		baseData.speed *= 0.9f;
		val2.baseData.damage = 15f;
		GunTools.SetProjectileSpriteRight(val2, "uterinepolyp_projectile", 7, 7, true, (Anchor)4, (int?)6, (int?)6, true, false, (int?)null, (int?)null, (Projectile)null);
		GoopModifier val3 = ((Component)val2).gameObject.AddComponent<GoopModifier>();
		val3.SpawnGoopInFlight = false;
		val3.SpawnGoopOnCollision = true;
		val3.CollisionSpawnRadius = 1f;
		val3.goopDefinition = EasyGoopDefinitions.GenerateBloodGoop(10f, ExtendedColours.orange, 10f);
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("UterinePolyp Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/uterinepolyp_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/uterinepolyp_clipempty");
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		UterinePolypID = ((PickupObject)val).PickupObjectId;
	}
}
