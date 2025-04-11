using System;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class M70 : GunBehaviour
{
	public static Projectile flak;

	public static int ID;

	public static void Add()
	{
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("M70", "m70");
		Game.Items.Rename("outdated_gun_mods:m70", "nn:m70");
		((Component)val).gameObject.AddComponent<M70>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Total Defence Doctrine");
		GunExt.SetLongDescription((PickupObject)(object)val, "A modification of the classic AK-47, adapted for space combat by a splinter group of rebels.\n\nThough their insurgency was put down by the Hegemony, these guns still find their way in circulation throughout the galaxy.");
		val.SetGunSprites("m70", 8, noAmmonomicon: false, 2);
		GunExt.SetAnimationFPS(val, val.shootAnimation, 15);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 10);
		PickupObject byId = PickupObjectDatabase.GetById(15);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(15);
		gunSwitchGroup = ((Gun)((byId2 is Gun) ? byId2 : null)).gunSwitchGroup;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 0.14f;
		val.DefaultModule.numberOfShotsInClip = 30;
		val.SetBarrel(28, 10);
		val.SetBaseMaxAmmo(550);
		val.gunClass = (GunClass)10;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(15);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		Projectile val2 = ProjectileSetupUtility.MakeProjectile(15, 5f);
		val.DefaultModule.projectiles[0] = val2;
		val2.baseData.speed = 25f;
		flak = ProjectileSetupUtility.MakeProjectile(15, 5f);
		flak.AdditionalScaleMultiplier = 0.6f;
		FixedFlakBehaviour fixedFlakBehaviour = ((Component)val2).gameObject.AddComponent<FixedFlakBehaviour>();
		fixedFlakBehaviour.angleIsRelative = true;
		fixedFlakBehaviour.postProcess = true;
		fixedFlakBehaviour.AddProjectile(flak, 90f);
		fixedFlakBehaviour.AddProjectile(flak, -90f);
		val.AddShellCasing(1, 1);
		val.AddClipDebris(0, 1, "clipdebris_m70");
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)3, 1f);
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		FixedFlakBehaviour component = ((Component)projectile).GetComponent<FixedFlakBehaviour>();
		if (Object.op_Implicit((Object)(object)base.gun) && Object.op_Implicit((Object)(object)GunTools.GunPlayerOwner(base.gun)) && Object.op_Implicit((Object)(object)component))
		{
			if (CustomSynergies.PlayerHasActiveSynergy(GunTools.GunPlayerOwner(base.gun), "People's Army"))
			{
				component.AddProjectile(flak, 135f);
				component.AddProjectile(flak, -135f);
			}
			if (CustomSynergies.PlayerHasActiveSynergy(GunTools.GunPlayerOwner(base.gun), "Shot in the Back"))
			{
				component.OnFlakSpawn = (Action<Projectile>)Delegate.Combine(component.OnFlakSpawn, new Action<Projectile>(OnFixedFlakSpawn));
			}
		}
		((GunBehaviour)this).PostProcessProjectile(projectile);
	}

	private void OnFixedFlakSpawn(Projectile proj)
	{
		BounceProjModifier component = ((Component)proj).gameObject.GetComponent<BounceProjModifier>();
		if (Object.op_Implicit((Object)(object)component))
		{
			component.numberOfBounces++;
		}
		else
		{
			((Component)proj).gameObject.AddComponent<BounceProjModifier>();
		}
	}
}
