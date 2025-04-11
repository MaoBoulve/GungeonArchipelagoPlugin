using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class UterinePolypWombular : AdvancedGunBehavior
{
	public static int WombularPolypID;

	public static void Add()
	{
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Wombular Polyp", "wombularpolyp");
		Game.Items.Rename("outdated_gun_mods:wombular_polyp", "nn:uterine_polyp+wombular");
		UterinePolypWombular uterinePolypWombular = ((Component)val).gameObject.AddComponent<UterinePolypWombular>();
		((AdvancedGunBehavior)uterinePolypWombular).preventNormalFireAudio = true;
		((AdvancedGunBehavior)uterinePolypWombular).preventNormalReloadAudio = true;
		((AdvancedGunBehavior)uterinePolypWombular).overrideNormalReloadAudio = "Play_OBJ_cauldron_splash_01";
		((AdvancedGunBehavior)uterinePolypWombular).overrideNormalFireAudio = "Play_ENM_cult_spew_01";
		GunExt.SetShortDescription((PickupObject)(object)val, "");
		GunExt.SetLongDescription((PickupObject)(object)val, "");
		val.SetGunSprites("wombularpolyp", 8, noAmmonomicon: true);
		GunExt.SetAnimationFPS(val, val.shootAnimation, 20);
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 0.5f;
		val.DefaultModule.cooldownTime = 0.25f;
		val.DefaultModule.angleVariance = 0.1f;
		val.DefaultModule.numberOfShotsInClip = -1;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2f, 0.75f, 0f);
		val.SetBaseMaxAmmo(300);
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		ProjectileData baseData = val2.baseData;
		baseData.speed *= 1.1f;
		val2.pierceMinorBreakables = true;
		PierceProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<PierceProjModifier>(((Component)val2).gameObject);
		orAddComponent.penetration++;
		val2.baseData.damage = 15f;
		GunTools.SetProjectileSpriteRight(val2, "wombularpolyp_projectile", 7, 7, true, (Anchor)4, (int?)6, (int?)6, true, false, (int?)null, (int?)null, (Projectile)null);
		((PickupObject)val).quality = (ItemQuality)(-100);
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		GunExt.SetName((PickupObject)(object)val, "Uterine Polyp");
		WombularPolypID = ((PickupObject)val).PickupObjectId;
	}
}
