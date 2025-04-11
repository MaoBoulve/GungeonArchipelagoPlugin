using System;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Schwarzlose : AdvancedGunBehavior
{
	public static int ID;

	public static void Add()
	{
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Schwarzlose", "schwarzlose");
		Game.Items.Rename("outdated_gun_mods:schwarzlose", "nn:schwarzlose");
		((Component)val).gameObject.AddComponent<Schwarzlose>();
		GunExt.SetShortDescription((PickupObject)(object)val, "I See It's As Big As Mine");
		GunExt.SetLongDescription((PickupObject)(object)val, "An old fashioned machine gun with a water-cooled barrel.\n\nExcercising remarkable minimalism in it's parts- it's bullets seem prone to drift.");
		val.SetGunSprites("schwarzlose");
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(51);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		PickupObject byId2 = PickupObjectDatabase.GetById(519);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1.5f;
		val.DefaultModule.cooldownTime = 0.1f;
		val.DefaultModule.numberOfShotsInClip = 20;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.3125f, 0.375f, 0f);
		val.SetBaseMaxAmmo(350);
		val.gunClass = (GunClass)10;
		Projectile val2 = ProjectileUtility.SetupProjectile(519);
		val.DefaultModule.projectiles[0] = val2;
		val2.baseData.damage = 9f;
		val2.AdditionalScaleMultiplier = 0.8f;
		((Component)val2).gameObject.AddComponent<ProjectileMotionDrift>();
		((PickupObject)val).quality = (ItemQuality)2;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)3, 1f);
		ID = ((PickupObject)val).PickupObjectId;
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		if (Object.op_Implicit((Object)(object)projectile) && Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(projectile)) && CustomSynergies.PlayerHasActiveSynergy(ProjectileUtility.ProjectilePlayerOwner(projectile), "Water Jacket"))
		{
			if (Object.op_Implicit((Object)(object)((Component)projectile).GetComponent<BounceProjModifier>()))
			{
				BounceProjModifier component = ((Component)projectile).GetComponent<BounceProjModifier>();
				component.numberOfBounces++;
			}
			else
			{
				((Component)projectile).gameObject.AddComponent<BounceProjModifier>();
			}
			BounceProjModifier component2 = ((Component)projectile).GetComponent<BounceProjModifier>();
			component2.OnBounceContext = (Action<BounceProjModifier, SpeculativeRigidbody>)Delegate.Combine(component2.OnBounceContext, new Action<BounceProjModifier, SpeculativeRigidbody>(OnBounced));
		}
		((AdvancedGunBehavior)this).PostProcessProjectile(projectile);
	}

	public void OnBounced(BounceProjModifier bounce, SpeculativeRigidbody body)
	{
		if (Object.op_Implicit((Object)(object)body) && Object.op_Implicit((Object)(object)((BraveBehaviour)body).projectile))
		{
			HomingModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<HomingModifier>(((Component)((BraveBehaviour)body).projectile).gameObject);
			orAddComponent.HomingRadius += 5f;
		}
	}
}
