using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Felissile : AdvancedGunBehavior
{
	public static int ID;

	private static ExplosionData bigExplosion = GameManager.Instance.Dungeon.sharedSettingsPrefab.DefaultExplosionData;

	private static ExplosionData FelissileExplosion = new ExplosionData
	{
		effect = bigExplosion.effect,
		ignoreList = bigExplosion.ignoreList,
		ss = bigExplosion.ss,
		damageRadius = 2.5f,
		damageToPlayer = 0f,
		doDamage = true,
		damage = 40f,
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
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_030b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0337: Unknown result type (might be due to invalid IL or missing references)
		//IL_036a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0371: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Felissile", "felissile");
		Game.Items.Rename("outdated_gun_mods:felissile", "nn:felissile");
		((Component)val).gameObject.AddComponent<Felissile>();
		GunExt.SetShortDescription((PickupObject)(object)val, "What's New?");
		GunExt.SetLongDescription((PickupObject)(object)val, "Fires a rocket on the first shot of it's clip.\n\nOnce part of a peculiar XXXS Size mech suit.");
		GunInt.SetupSprite(val, Initialisation.gunCollection, "felissile_idle_001", 8, "felissile_ammonomicon_001");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 15);
		PickupObject byId = PickupObjectDatabase.GetById(39);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 2.5f;
		val.DefaultModule.cooldownTime = 0.25f;
		val.DefaultModule.numberOfShotsInClip = 10;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.12f, 0.37f, 0f);
		val.SetBaseMaxAmmo(500);
		val.DefaultModule.usesOptionalFinalProjectile = true;
		val.DefaultModule.numberOfFinalProjectiles = 9;
		val.gunClass = (GunClass)45;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		val2.baseData.damage = 15f;
		ExplosiveModifier component = ((Component)val2).gameObject.GetComponent<ExplosiveModifier>();
		if (Object.op_Implicit((Object)(object)component))
		{
			Object.Destroy((Object)(object)component);
		}
		ExplosiveModifier val3 = ((Component)val2).gameObject.AddComponent<ExplosiveModifier>();
		val3.doExplosion = true;
		val3.explosionData = FelissileExplosion;
		ProjectileData baseData = val2.baseData;
		baseData.range *= 0.5f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.speed *= 3f;
		((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		ProjectileBuilders.SetProjectileCollisionRight(val2, "felissile_rocket_projectile", Initialisation.ProjectileCollection, 16, 11, false, (Anchor)4, (int?)14, (int?)3, true, false, (int?)null, (int?)null, (Projectile)null);
		PickupObject byId2 = PickupObjectDatabase.GetById(56);
		Projectile val4 = Object.Instantiate<Projectile>(((Gun)((byId2 is Gun) ? byId2 : null)).DefaultModule.projectiles[0]);
		((Component)val4).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val4).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val4);
		ProjectileData baseData3 = val4.baseData;
		baseData3.speed *= 1.1f;
		val4.baseData.damage = 11f;
		ProjectileBuilders.SetProjectileCollisionRight(val4, "felissile_normal_projectile", Initialisation.ProjectileCollection, 10, 9, true, (Anchor)4, (int?)9, (int?)8, true, false, (int?)null, (int?)null, (Projectile)null);
		val4.hitEffects.alwaysUseMidair = true;
		val4.hitEffects.overrideMidairDeathVFX = SharedVFX.WhiteCircleVFX;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Felissile Rockets", "NevernamedsItems/Resources/CustomGunAmmoTypes/felissile_rocket_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/felissile_rocket_clipempty");
		val.DefaultModule.finalAmmoType = (AmmoType)14;
		val.DefaultModule.finalCustomAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Felissile Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/felissile_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/felissile_clipempty");
		val.DefaultModule.finalProjectile = val4;
		val.gunHandedness = (GunHandedness)3;
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
	}

	protected override void OnPickedUpByPlayer(PlayerController player)
	{
		((AdvancedGunBehavior)this).OnPickedUpByPlayer(player);
		if (base.everPickedUpByPlayer && Object.op_Implicit((Object)(object)base.gun))
		{
			base.gun.ClipShotsRemaining = base.gun.ClipCapacity - 1;
		}
	}

	protected override void Update()
	{
		if (Object.op_Implicit((Object)(object)base.gun) && Object.op_Implicit((Object)(object)base.gun.CurrentOwner))
		{
			if (base.gun.DefaultModule.ammoCost < 10 && base.gun.ClipShotsRemaining > 9)
			{
				base.gun.DefaultModule.ammoCost = 10;
			}
			else if (base.gun.DefaultModule.ammoCost >= 10 && base.gun.ClipShotsRemaining <= 9)
			{
				base.gun.DefaultModule.ammoCost = 1;
			}
		}
		((AdvancedGunBehavior)this).Update();
	}

	public override void OnPostFired(PlayerController player, Gun gun)
	{
	}
}
