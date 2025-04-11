using System.Collections.Generic;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Copygat : AdvancedGunBehavior
{
	public static int CopygatID;

	public static void Add()
	{
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_021a: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Copygat", "copygat");
		Game.Items.Rename("outdated_gun_mods:copygat", "nn:copygat");
		Copygat copygat = ((Component)val).gameObject.AddComponent<Copygat>();
		((AdvancedGunBehavior)copygat).overrideNormalFireAudio = "Play_BOSS_DragunGold_Baby_Death_01";
		((AdvancedGunBehavior)copygat).preventNormalFireAudio = true;
		GunExt.SetShortDescription((PickupObject)(object)val, "Follow The Leader");
		GunExt.SetLongDescription((PickupObject)(object)val, "Mimics the projectiles of other guns.\n\nThis industrial mimigoo weapon has attained a low level of sentience, and now communicates solely in meowing and scratching.");
		val.SetGunSprites("copygat");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1.5f;
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		val.DefaultModule.cooldownTime = 0.15f;
		val.DefaultModule.numberOfShotsInClip = 10;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.5f, 0.56f, 0f);
		val.SetBaseMaxAmmo(200);
		val.ammo = 200;
		val.gunClass = (GunClass)10;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val2.baseData.damage = 20f;
		val2.SetProjectileSprite("wrench_null_projectile", 13, 7, lightened: false, (Anchor)4, 12, 7, anchorChangesCollider: true, fixesScale: false, null, null);
		val2.hitEffects.alwaysUseMidair = true;
		val2.hitEffects.overrideMidairDeathVFX = SharedVFX.RedLaserCircleVFX;
		((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Copygat Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/copygat_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/copygat_clipempty");
		val.DefaultModule.projectiles[0] = val2;
		((PickupObject)val).quality = (ItemQuality)4;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		CopygatID = ((PickupObject)val).PickupObjectId;
	}

	public override Projectile OnPreFireProjectileModifier(Gun gun, Projectile defaultproj, ProjectileModule mod)
	{
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Invalid comparison between Unknown and I4
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Invalid comparison between Unknown and I4
		if (Object.op_Implicit((Object)(object)gun) && Object.op_Implicit((Object)(object)gun.CurrentOwner) && Object.op_Implicit((Object)(object)GunTools.GunPlayerOwner(gun)) && GunTools.GunPlayerOwner(gun).inventory.AllGuns.Count > 1)
		{
			PlayerController val = GunTools.GunPlayerOwner(gun);
			List<Projectile> list = new List<Projectile>();
			List<Projectile> list2 = new List<Projectile>();
			if (Object.op_Implicit((Object)(object)val) && val.inventory != null)
			{
				for (int i = 0; i < val.inventory.AllGuns.Count; i++)
				{
					if (!Object.op_Implicit((Object)(object)val.inventory.AllGuns[i]) || val.inventory.AllGuns[i].InfiniteAmmo)
					{
						continue;
					}
					ProjectileModule defaultModule = val.inventory.AllGuns[i].DefaultModule;
					if ((int)defaultModule.shootStyle == 2)
					{
						list2.Add(defaultModule.GetCurrentProjectile());
					}
					else if ((int)defaultModule.shootStyle == 3)
					{
						Projectile val2 = null;
						for (int j = 0; j < 15; j++)
						{
							ChargeProjectile val3 = defaultModule.chargeProjectiles[Random.Range(0, defaultModule.chargeProjectiles.Count)];
							if (val3 != null)
							{
								val2 = val3.Projectile;
							}
							if (Object.op_Implicit((Object)(object)val2))
							{
								break;
							}
						}
						list.Add(val2);
					}
					else
					{
						list.Add(defaultModule.GetCurrentProjectile());
					}
				}
				int num = list.Count + list2.Count;
				if (num > 0)
				{
					int num2 = Random.Range(0, num);
					if (num2 > list.Count)
					{
						return BraveUtility.RandomElement<Projectile>(list2);
					}
					return BraveUtility.RandomElement<Projectile>(list);
				}
			}
		}
		return ((AdvancedGunBehavior)this).OnPreFireProjectileModifier(gun, defaultproj, mod);
	}
}
