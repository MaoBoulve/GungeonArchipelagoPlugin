using System.Collections.Generic;
using Alexandria.ItemAPI;
using Gungeon;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class ScrapStrap : AdvancedGunBehavior
{
	public static int ID;

	public static void Add()
	{
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Scrap Strap", "scrapstrap");
		Game.Items.Rename("outdated_gun_mods:scrap_strap", "nn:scrap_strap");
		ScrapStrap scrapStrap = ((Component)val).gameObject.AddComponent<ScrapStrap>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Seen Better Days");
		GunExt.SetLongDescription((PickupObject)(object)val, "This handgun has seemingly been repaired at least four separate times, but never by an experienced gunsmith. Jamming irregular pieces of metal down the barrel seems to work just fine.\n\nSo fine, in fact, that you can repurpose the weapons spent shells as ammunition for other guns!");
		val.SetGunSprites("scrapstrap");
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 0);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(510);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(1);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 2f;
		val.DefaultModule.cooldownTime = 0.02f;
		val.DefaultModule.numberOfShotsInClip = 23;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1f, 0.625f, 0f);
		val.SetBaseMaxAmmo(500);
		val.ammo = 500;
		val.gunClass = (GunClass)1;
		PickupObject byId4 = PickupObjectDatabase.GetById(86);
		Projectile component = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)((Gun)((byId4 is Gun) ? byId4 : null)).DefaultModule.projectiles[0]).gameObject).GetComponent<Projectile>();
		val.DefaultModule.projectiles[0] = component;
		component.baseData.damage = 4.5f;
		((PickupObject)val).quality = (ItemQuality)1;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
		((PickupObject)(object)val).SetupUnlockOnCustomStat(CustomTrackedStats.BEGGAR_TOTAL_DONATIONS, 14f, (PrerequisiteOperation)2);
	}

	public override void OnPostFired(PlayerController player, Gun gun)
	{
		List<Gun> list = new List<Gun>(player.inventory.AllGuns);
		list.RemoveAll((Gun x) => (Object)(object)x == (Object)(object)gun || !x.CanGainAmmo || x.InfiniteAmmo || x.CurrentAmmo >= x.maxAmmo);
		if (list.Count > 0)
		{
			BraveUtility.RandomElement<Gun>(list).GainAmmo(1);
		}
		((AdvancedGunBehavior)this).OnPostFired(player, gun);
	}
}
