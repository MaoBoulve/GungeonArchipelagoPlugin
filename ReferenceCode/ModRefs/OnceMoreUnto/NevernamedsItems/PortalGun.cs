using System.Collections.Generic;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class PortalGun : AdvancedGunBehavior
{
	public static List<OMITBPortalController> allPortals;

	public static int PortalGunID;

	public static void Add()
	{
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0203: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Portal Gun", "portalgun");
		Game.Items.Rename("outdated_gun_mods:portal_gun", "nn:portal_gun");
		((Component)val).gameObject.AddComponent<PortalGun>();
		GunExt.SetShortDescription((PickupObject)(object)val, "For Science");
		GunExt.SetLongDescription((PickupObject)(object)val, "");
		GunExt.SetupSprite(val, (tk2dSpriteCollectionData)null, "st4ke_idle_001", 8);
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
		val.gunClass = (GunClass)50;
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
		((PickupObject)val).quality = (ItemQuality)(-100);
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		PortalGunID = ((PickupObject)val).PickupObjectId;
		allPortals = new List<OMITBPortalController>();
	}
}
