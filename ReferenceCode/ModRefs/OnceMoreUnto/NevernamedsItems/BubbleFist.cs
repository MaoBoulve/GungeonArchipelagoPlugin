using System.Collections.Generic;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class BubbleFist : GunBehaviour
{
	public static int ID;

	public float reloadsynergyccooldown = 0f;

	public static void Add()
	{
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_027e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_02af: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c6: Expected O, but got Unknown
		Gun val = Databases.Items.NewGun("Bubble Fist", "bubblefist");
		Game.Items.Rename("outdated_gun_mods:bubble_fist", "nn:bubble_fist");
		((Component)val).gameObject.AddComponent<BubbleFist>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Aqua, Man!");
		GunExt.SetLongDescription((PickupObject)(object)val, "A peculiar spell that conjures seafoam from the users clenched fist.\n\nPerhaps a homebrew version of the flame hand?");
		val.SetGunSprites("bubblefist", 8, noAmmonomicon: false, 2);
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(404);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)3;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1.2f;
		val.gunClass = (GunClass)60;
		val.DefaultModule.cooldownTime = 1f;
		val.DefaultModule.numberOfShotsInClip = 1;
		val.SetBaseMaxAmmo(80);
		((PickupObject)val).quality = (ItemQuality)2;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		val.gunHandedness = (GunHandedness)3;
		val.SetBarrel(40, 21);
		Projectile val2 = ProjectileSetupUtility.MakeProjectile(86, 15f);
		((Object)((Component)val2).gameObject).name = "BubbleFistCoreProjectile";
		((BraveBehaviour)((BraveBehaviour)val2).sprite).renderer.enabled = false;
		ProjectileData baseData = val2.baseData;
		baseData.speed *= 2f;
		val2.baseData.range = 7f;
		PierceProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<PierceProjModifier>(((Component)val2).gameObject);
		orAddComponent.penetration = 100;
		orAddComponent.penetratesBreakables = true;
		Projectile val3 = ProjectileSetupUtility.MakeProjectile(599, 6f);
		RandomProjectileStatsComponent randomProjectileStatsComponent = ((Component)val3).gameObject.AddComponent<RandomProjectileStatsComponent>();
		randomProjectileStatsComponent.randomScale = true;
		randomProjectileStatsComponent.highScalePercent = 100;
		randomProjectileStatsComponent.lowScalePercent = 70;
		SpawnProjModifier orAddComponent2 = GameObjectExtensions.GetOrAddComponent<SpawnProjModifier>(((Component)val2).gameObject);
		orAddComponent2.spawnProjectilesInFlight = true;
		orAddComponent2.numToSpawnInFlight = 1;
		orAddComponent2.fireRandomlyInAngle = true;
		orAddComponent2.inFlightSpawnAngle = 360f;
		orAddComponent2.inFlightSpawnCooldown = 0.01f;
		orAddComponent2.projectileToSpawnInFlight = val3;
		orAddComponent2.usesComplexSpawnInFlight = true;
		orAddComponent2.PostprocessSpawnedProjectiles = true;
		orAddComponent2.spawnProjectilesOnCollision = true;
		orAddComponent2.projectileToSpawnOnCollision = val3;
		orAddComponent2.numberToSpawnOnCollison = 3;
		orAddComponent2.spawnOnObjectCollisions = true;
		orAddComponent2.spawnCollisionProjectilesOnBounce = true;
		orAddComponent2.spawnProjecitlesOnDieInAir = true;
		orAddComponent2.collisionSpawnStyle = (CollisionSpawnStyle)1;
		orAddComponent2.randomRadialStartAngle = true;
		val.DefaultModule.projectiles[0] = val2;
		val.DefaultModule.chargeProjectiles = new List<ChargeProjectile>
		{
			new ChargeProjectile
			{
				Projectile = val2,
				ChargeTime = 0.4f
			}
		};
		val.AddClipSprites("bubblefist");
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)0, 1f);
		ID = ((PickupObject)val).PickupObjectId;
	}

	public override void Update()
	{
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)base.gun) && Object.op_Implicit((Object)(object)GunTools.GunPlayerOwner(base.gun)) && CustomSynergies.PlayerHasActiveSynergy(GunTools.GunPlayerOwner(base.gun), "F#!^@in' Bubbles") && base.gun.IsReloading)
		{
			if (reloadsynergyccooldown > 0f)
			{
				reloadsynergyccooldown -= BraveTime.DeltaTime;
			}
			else
			{
				PickupObject byId = PickupObjectDatabase.GetById(599);
				GameObject val = ProjectileUtility.InstantiateAndFireInDirection(((Gun)((byId is Gun) ? byId : null)).DefaultModule.projectiles[2], Vector2.op_Implicit(base.gun.PrimaryHandAttachPoint.position), base.gun.CurrentAngle, 5f, GunTools.GunPlayerOwner(base.gun));
				Projectile component = val.GetComponent<Projectile>();
				if (Object.op_Implicit((Object)(object)val) && Object.op_Implicit((Object)(object)component))
				{
					component.Owner = base.gun.CurrentOwner;
					component.Shooter = ((BraveBehaviour)base.gun.CurrentOwner).specRigidbody;
					component.ScaleByPlayerStats(GunTools.GunPlayerOwner(base.gun));
					GunTools.GunPlayerOwner(base.gun).DoPostProcessProjectile(component);
				}
				reloadsynergyccooldown = 0.1f;
			}
		}
		((GunBehaviour)this).Update();
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		if (Object.op_Implicit((Object)(object)projectile) && ((Object)((Component)projectile).gameObject).name.Contains("BubbleFistCoreProjectile") && Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(projectile)) && CustomSynergies.PlayerHasActiveSynergy(ProjectileUtility.ProjectilePlayerOwner(projectile), "Bubble Column"))
		{
			projectile.baseData.range = 100f;
		}
		((GunBehaviour)this).PostProcessProjectile(projectile);
	}
}
