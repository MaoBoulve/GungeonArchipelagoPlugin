using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Accelerator : AdvancedGunBehavior
{
	public static int ID;

	public static void Add()
	{
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0209: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Accelerator", "accelerator");
		Game.Items.Rename("outdated_gun_mods:accelerator", "nn:accelerator");
		Accelerator accelerator = ((Component)val).gameObject.AddComponent<Accelerator>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Sapper");
		GunExt.SetLongDescription((PickupObject)(object)val, "The projectiles of this remarkable weapon suck the speed right out of enemy bullets!\n\nReverse engineered from vampires.");
		val.SetGunSprites("accelerator");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		PickupObject byId = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1.2f;
		val.DefaultModule.cooldownTime = 0.1f;
		val.DefaultModule.numberOfShotsInClip = 7;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.75f, 0.56f, 0f);
		val.SetBaseMaxAmmo(210);
		val.gunClass = (GunClass)1;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		val2.baseData.damage = 7f;
		ProjectileData baseData = val2.baseData;
		baseData.speed *= 1.1f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.range *= 10f;
		((Component)val2).gameObject.AddComponent<EnemyBulletSpeedSapperMod>();
		val2.pierceMinorBreakables = true;
		PierceProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<PierceProjModifier>(((Component)val2).gameObject);
		orAddComponent.penetratesBreakables = true;
		orAddComponent.penetration = 1;
		ProjectileBuilders.SetProjectileCollisionRight(val2, "accelerator_projectile", Initialisation.ProjectileCollection, 11, 9, true, (Anchor)4, (int?)10, (int?)8, true, false, (int?)null, (int?)null, (Projectile)null);
		((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		((PickupObject)val).quality = (ItemQuality)2;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
	}
}
