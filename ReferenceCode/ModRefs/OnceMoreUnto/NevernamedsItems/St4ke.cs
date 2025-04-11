using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class St4ke : AdvancedGunBehavior
{
	public static int St4keID;

	public static GameObject LinkVFXPrefab;

	public static void Add()
	{
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_0210: Unknown result type (might be due to invalid IL or missing references)
		//IL_0236: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("St4ke", "st4ke");
		Game.Items.Rename("outdated_gun_mods:st4ke", "nn:st4ke");
		((Component)val).gameObject.AddComponent<St4ke>();
		GunExt.SetShortDescription((PickupObject)(object)val, "For Robot Vampires");
		GunExt.SetLongDescription((PickupObject)(object)val, "Fires miniature tesla coils that stick into walls.\n\nFollowing the success of her remote diote transmitter experiment, the tinker set about seeing if she could make both ends of the tesla-relay mobile.");
		GunInt.SetupSprite(val, Initialisation.gunCollection, "st4ke_idle_001", 8, "st4ke_ammonomicon_001");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 17);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(153);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 0.15f;
		val.DefaultModule.numberOfShotsInClip = 4;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.68f, 0.62f, 0f);
		val.SetBaseMaxAmmo(175);
		ref string gunSwitchGroup2 = ref val.gunSwitchGroup;
		PickupObject byId3 = PickupObjectDatabase.GetById(153);
		gunSwitchGroup2 = ((Gun)((byId3 is Gun) ? byId3 : null)).gunSwitchGroup;
		val.ammo = 175;
		val.gunClass = (GunClass)1;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		val2.baseData.damage = 8f;
		val2.pierceMinorBreakables = true;
		GunTools.SetProjectileSpriteRight(val2, "st4keproj", 13, 7, true, (Anchor)4, (int?)9, (int?)5, true, false, (int?)null, (int?)null, (Projectile)null);
		St4keProj orAddComponent = GameObjectExtensions.GetOrAddComponent<St4keProj>(((Component)val2).gameObject);
		PierceProjModifier orAddComponent2 = GameObjectExtensions.GetOrAddComponent<PierceProjModifier>(((Component)val2).gameObject);
		orAddComponent2.penetration++;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Stk4ke Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/st4ke_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/st4ke_clipempty");
		((PickupObject)val).quality = (ItemQuality)4;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		St4keID = ((PickupObject)val).PickupObjectId;
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)3, 1f);
		LinkVFXPrefab = FakePrefab.Clone(((Component)Game.Items["shock_rounds"]).GetComponent<ComplexProjectileModifier>().ChainLightningVFX);
		FakePrefab.MarkAsFakePrefab(LinkVFXPrefab);
		Object.DontDestroyOnLoad((Object)(object)LinkVFXPrefab);
	}
}
