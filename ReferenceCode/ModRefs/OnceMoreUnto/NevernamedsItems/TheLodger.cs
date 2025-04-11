using System.Collections.Generic;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class TheLodger : GunBehaviour
{
	public static int TheLodgerID;

	public static List<int> badStuff = new List<int>
	{
		378, 122, 440, 63, 104, 108, 109, 234, 403, 462,
		216, 205, 201, 448, 447, 521, 488, 256, 119, 432,
		306, 106, 487, 197, 83, 79, 9, 10, 510, 383,
		334, 3, 196, 26, 292, 340, 150
	};

	public static List<int> reallyBadStuff = new List<int> { 209, 460, 136, 66, 308, 132, 31, 202 };

	public static void Add()
	{
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("The Lodger", "lodger");
		Game.Items.Rename("outdated_gun_mods:the_lodger", "nn:the_lodger");
		((Component)val).gameObject.AddComponent<TheLodger>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Cherish What You Have");
		GunExt.SetLongDescription((PickupObject)(object)val, "Many Gungeoneers have a bad habit of turning their noses up at items they deem to be of poor quality, but the Lodger seeks to teach them a lesson in humility.");
		val.SetGunSprites("lodger");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 10);
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 3;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1.1f;
		val.DefaultModule.cooldownTime = 0.3f;
		val.DefaultModule.numberOfShotsInClip = 10;
		val.SetBaseMaxAmmo(1924);
		val.gunClass = (GunClass)55;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId2 = PickupObjectDatabase.GetById(26);
		muzzleFlashEffects = ((Gun)((byId2 is Gun) ? byId2 : null)).muzzleFlashEffects;
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId3 = PickupObjectDatabase.GetById(477);
		gunSwitchGroup = ((Gun)((byId3 is Gun) ? byId3 : null)).gunSwitchGroup;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		val2.baseData.damage = 5f;
		GunTools.SetProjectileSpriteRight(val2, "lodger_projectile", 8, 9, false, (Anchor)4, (int?)7, (int?)8, true, false, (int?)null, (int?)null, (Projectile)null);
		val2.hitEffects.alwaysUseMidair = true;
		ref GameObject overrideMidairDeathVFX = ref val2.hitEffects.overrideMidairDeathVFX;
		PickupObject byId4 = PickupObjectDatabase.GetById(28);
		overrideMidairDeathVFX = ((Gun)((byId4 is Gun) ? byId4 : null)).DefaultModule.projectiles[0].hitEffects.tileMapVertical.effects[0].effects[0].effect;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Lodger Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/lodger_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/lodger_clipempty");
		((PickupObject)val).quality = (ItemQuality)1;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		TheLodgerID = ((PickupObject)val).PickupObjectId;
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		GameActor currentOwner = base.gun.CurrentOwner;
		PlayerController val = (PlayerController)(object)((currentOwner is PlayerController) ? currentOwner : null);
		float num = 1f;
		foreach (PassiveItem passiveItem in val.passiveItems)
		{
			if (badStuff.Contains(((PickupObject)passiveItem).PickupObjectId))
			{
				num += 0.1f;
			}
			else if (reallyBadStuff.Contains(((PickupObject)passiveItem).PickupObjectId))
			{
				num += 0.2f;
			}
			else if (((PickupObject)passiveItem).PickupObjectId == 127)
			{
				num += 0.05f;
			}
		}
		foreach (PlayerItem activeItem in val.activeItems)
		{
			if (badStuff.Contains(((PickupObject)activeItem).PickupObjectId))
			{
				num += 0.1f;
			}
			else if (reallyBadStuff.Contains(((PickupObject)activeItem).PickupObjectId))
			{
				num += 0.2f;
			}
			else if ((float)((PickupObject)activeItem).PickupObjectId == 409f)
			{
				num += 1f;
			}
		}
		foreach (Gun allGun in val.inventory.AllGuns)
		{
			if (badStuff.Contains(((PickupObject)allGun).PickupObjectId))
			{
				num += 0.1f;
			}
			else if (reallyBadStuff.Contains(((PickupObject)allGun).PickupObjectId))
			{
				num += 0.2f;
			}
		}
		ProjectileData baseData = projectile.baseData;
		baseData.damage *= num;
		((GunBehaviour)this).PostProcessProjectile(projectile);
	}
}
