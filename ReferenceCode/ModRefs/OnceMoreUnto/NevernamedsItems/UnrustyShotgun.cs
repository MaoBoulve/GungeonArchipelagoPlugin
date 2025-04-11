using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class UnrustyShotgun : AdvancedGunBehavior
{
	public static int ID;

	public static void Add()
	{
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_024a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0263: Unknown result type (might be due to invalid IL or missing references)
		//IL_026b: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Unrusty Shotgun", "unrustyshotgun");
		Game.Items.Rename("outdated_gun_mods:unrusty_shotgun", "nn:rusty_shotgun+proper_care_and_maintenance");
		UnrustyShotgun unrustyShotgun = ((Component)val).gameObject.AddComponent<UnrustyShotgun>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Past It's Prime");
		GunExt.SetLongDescription((PickupObject)(object)val, "This shotgun was cast aside to rust in a gutter years ago. Some of it's shots never even manage to fire!\n\nPerhaps it just needs an understanding user to let it shine.");
		val.SetGunSprites("unrustyshotgun", 8, noAmmonomicon: true);
		GunExt.SetAnimationFPS(val, val.shootAnimation, 13);
		GunExt.SetAnimationFPS(val, val.idleAnimation, 5);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 1);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(51);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		for (int i = 0; i < 5; i++)
		{
			PickupObject byId2 = PickupObjectDatabase.GetById(86);
			GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		}
		int num = 0;
		foreach (ProjectileModule projectile in val.Volley.projectiles)
		{
			projectile.ammoCost = 1;
			projectile.shootStyle = (ShootStyle)0;
			projectile.sequenceStyle = (ProjectileSequenceStyle)0;
			projectile.cooldownTime = 0.5f;
			projectile.angleVariance = 10f;
			projectile.numberOfShotsInClip = 3;
			Projectile val2 = Object.Instantiate<Projectile>(projectile.projectiles[0]);
			projectile.projectiles[0] = val2;
			((Component)val2).gameObject.SetActive(false);
			FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
			Object.DontDestroyOnLoad((Object)(object)val2);
			ProjectileData baseData = val2.baseData;
			baseData.range *= 0.7f;
			val2.baseData.damage = 8f;
			if (MathsAndLogicHelper.isEven(num))
			{
				BounceProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<BounceProjModifier>(((Component)val2).gameObject);
				orAddComponent.numberOfBounces = 1;
			}
			else
			{
				PierceProjModifier orAddComponent2 = GameObjectExtensions.GetOrAddComponent<PierceProjModifier>(((Component)val2).gameObject);
				orAddComponent2.penetration = 1;
			}
			if (projectile != val.DefaultModule)
			{
				projectile.ammoCost = 0;
			}
			((BraveBehaviour)val2).transform.parent = val.barrelOffset;
			num++;
		}
		val.reloadTime = 1.5f;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2f, 0.62f, 0f);
		val.SetBaseMaxAmmo(200);
		val.gunClass = (GunClass)5;
		((PickupObject)val).quality = (ItemQuality)(-100);
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		val.Volley.UsesShotgunStyleVelocityRandomizer = true;
		ID = ((PickupObject)val).PickupObjectId;
	}
}
