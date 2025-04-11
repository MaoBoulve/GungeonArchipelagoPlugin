using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class FireLance : GunBehaviour
{
	public static int FireLanceID;

	private static ExplosionData smallExplosion = GameManager.Instance.Dungeon.sharedSettingsPrefab.DefaultSmallExplosionData;

	private static ExplosionData FireLanceExplosion = new ExplosionData
	{
		effect = smallExplosion.effect,
		ignoreList = smallExplosion.ignoreList,
		ss = smallExplosion.ss,
		damageRadius = 2.5f,
		damageToPlayer = 0f,
		doDamage = true,
		damage = 25f,
		doDestroyProjectiles = true,
		doForce = true,
		debrisForce = 30f,
		preventPlayerForce = true,
		explosionDelay = 0.1f,
		usesComprehensiveDelay = false,
		doScreenShake = true,
		playDefaultSFX = true
	};

	public static void Add()
	{
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Fire Lance", "firelance");
		Game.Items.Rename("outdated_gun_mods:fire_lance", "nn:fire_lance");
		((Component)val).gameObject.AddComponent<FireLance>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Where it all started");
		GunExt.SetLongDescription((PickupObject)(object)val, "Long explosive lances such as these are recorded to be some of the first gunpowder-based weapons in human history, beaten out only by crude bombs.\n\nWithout this, none of this would be possible.");
		val.SetGunSprites("firelance");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 15);
		PickupObject byId = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 0.5f;
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		val.DefaultModule.numberOfShotsInClip = 5;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(4.56f, 1.18f, 0f);
		val.SetBaseMaxAmmo(100);
		val.gunClass = (GunClass)45;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 3f;
		((BraveBehaviour)((BraveBehaviour)val2).sprite).renderer.enabled = false;
		ProjectileData baseData2 = val2.baseData;
		baseData2.range /= 35f;
		((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		ExplosiveModifier val3 = ((Component)val2).gameObject.AddComponent<ExplosiveModifier>();
		val3.doExplosion = true;
		val3.explosionData = FireLanceExplosion;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Fire Lance Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/firelance_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/firelance_clipempty");
		((PickupObject)val).quality = (ItemQuality)1;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		FireLanceID = ((PickupObject)val).PickupObjectId;
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		if (Object.op_Implicit((Object)(object)projectile) && Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(projectile)) && CustomSynergies.PlayerHasActiveSynergy(ProjectileUtility.ProjectilePlayerOwner(projectile), "There are some who call me..."))
		{
			projectile.baseData.range = 1000f;
			ProjectileData baseData = projectile.baseData;
			baseData.speed *= 20f;
		}
		((GunBehaviour)this).PostProcessProjectile(projectile);
	}

	public override void OnPostFired(PlayerController player, Gun gun)
	{
		gun.PreventNormalFireAudio = true;
	}
}
