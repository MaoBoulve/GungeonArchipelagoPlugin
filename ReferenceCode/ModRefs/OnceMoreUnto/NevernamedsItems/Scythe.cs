using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Scythe : AdvancedGunBehavior
{
	public class SoulRendSlashModifier : ProjectileSlashingBehaviour
	{
		public override void SlashHitTarget(GameActor target, bool fatal)
		{
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			if (fatal && Object.op_Implicit((Object)(object)((Component)this).GetComponent<Projectile>()) && Object.op_Implicit((Object)(object)((Component)this).GetComponent<Projectile>().Owner) && ((Component)this).GetComponent<Projectile>().Owner is PlayerController)
			{
				GameActor owner = ((Component)this).GetComponent<Projectile>().Owner;
				PlayerController val = (PlayerController)(object)((owner is PlayerController) ? owner : null);
				GameObject val2 = ProjectileUtility.InstantiateAndFireInDirection(StandardisedProjectiles.ghost, ((BraveBehaviour)target).specRigidbody.UnitCenter, ((GameActor)val).CurrentGun.CurrentAngle, 0f, (PlayerController)null);
				Projectile component = val2.GetComponent<Projectile>();
				component.Owner = (GameActor)(object)val;
				component.Shooter = ((BraveBehaviour)val).specRigidbody;
				((BraveBehaviour)component).specRigidbody.RegisterGhostCollisionException(((BraveBehaviour)target).specRigidbody);
				val.DoPostProcessProjectile(component);
				component.ScaleByPlayerStats(val);
			}
			((ProjectileSlashingBehaviour)this).SlashHitTarget(target, fatal);
		}
	}

	public static int ID;

	public static void Add()
	{
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_023c: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Scythe", "scythe");
		Game.Items.Rename("outdated_gun_mods:scythe", "nn:scythe");
		Scythe scythe = ((Component)val).gameObject.AddComponent<Scythe>();
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(417);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		GunExt.SetShortDescription((PickupObject)(object)val, "Reap");
		GunExt.SetLongDescription((PickupObject)(object)val, "An old fashioned scythe without a gun attached. Rends the souls from enemies.\n\nFavoured by reapers and wheat farmers everywhere except the gungeon.");
		val.SetGunSprites("scythe");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 13);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 0);
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)val, (StatType)14, 2f, (ModifyMethod)0);
		ref ScreenShakeSettings gunScreenShake = ref val.gunScreenShake;
		PickupObject byId2 = PickupObjectDatabase.GetById(417);
		gunScreenShake = ((Gun)((byId2 is Gun) ? byId2 : null)).gunScreenShake;
		PickupObject byId3 = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId3 is Gun) ? byId3 : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1.15f;
		val.DefaultModule.cooldownTime = 0.75f;
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		val.DefaultModule.numberOfShotsInClip = 6;
		val.SetBarrel(47, 57);
		((Component)val.barrelOffset).transform.localPosition = new Vector3(3.0625f, 3.625f, 0f);
		val.SetBaseMaxAmmo(100);
		((PickupObject)val).quality = (ItemQuality)3;
		val.gunClass = (GunClass)50;
		Projectile val2 = ProjectileUtility.SetupProjectile(86);
		val.DefaultModule.projectiles[0] = val2;
		val2.baseData.damage = 20f;
		((BraveBehaviour)((BraveBehaviour)val2).sprite).renderer.enabled = false;
		SoulRendSlashModifier soulRendSlashModifier = ((Component)val2).gameObject.AddComponent<SoulRendSlashModifier>();
		((ProjectileSlashingBehaviour)soulRendSlashModifier).DestroyBaseAfterFirstSlash = true;
		((ProjectileSlashingBehaviour)soulRendSlashModifier).slashParameters = ScriptableObject.CreateInstance<SlashData>();
		((ProjectileSlashingBehaviour)soulRendSlashModifier).slashParameters.soundEvent = null;
		((ProjectileSlashingBehaviour)soulRendSlashModifier).slashParameters.projInteractMode = (ProjInteractMode)0;
		((ProjectileSlashingBehaviour)soulRendSlashModifier).SlashDamageUsesBaseProjectileDamage = true;
		((ProjectileSlashingBehaviour)soulRendSlashModifier).slashParameters.doVFX = false;
		((ProjectileSlashingBehaviour)soulRendSlashModifier).slashParameters.doHitVFX = true;
		((ProjectileSlashingBehaviour)soulRendSlashModifier).slashParameters.slashRange = 4.5f;
		((ProjectileSlashingBehaviour)soulRendSlashModifier).slashParameters.slashDegrees = 45f;
		((ProjectileSlashingBehaviour)soulRendSlashModifier).slashParameters.playerKnockbackForce = 40f;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = "white";
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
	}
}
