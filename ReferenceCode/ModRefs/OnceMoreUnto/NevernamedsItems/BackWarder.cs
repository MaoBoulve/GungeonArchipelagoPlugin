using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class BackWarder : AdvancedGunBehavior
{
	public static int BackWarderID;

	public static void Add()
	{
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Back Warder", "backwarder");
		Game.Items.Rename("outdated_gun_mods:back_warder", "nn:back_warder");
		((Component)val).gameObject.AddComponent<BackWarder>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Backup");
		GunExt.SetLongDescription((PickupObject)(object)val, "Fires backwards.\n\nThe condition of shooting backwards (known medically as disgyrismata) affects as many as one in five Gungeoneers.");
		GunInt.SetupSprite(val, Initialisation.gunCollection, "backwarder_idle_001", 8, "backwarder_ammonomicon_001");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 14);
		PickupObject byId = PickupObjectDatabase.GetById(38);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 0.15f;
		val.DefaultModule.angleFromAim = 180f;
		val.DefaultModule.angleVariance = 7f;
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		val.DefaultModule.numberOfShotsInClip = 6;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(0.18f, 0.87f, 0f);
		val.SetBaseMaxAmmo(140);
		val.ammo = 140;
		val.gunClass = (GunClass)55;
		((PickupObject)val).quality = (ItemQuality)1;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		BackWarderID = ((PickupObject)val).PickupObjectId;
		ItemBuilder.AddToGunslingKingTable((PickupObject)(object)val, 1);
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		if (Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(projectile)) && CustomSynergies.PlayerHasActiveSynergy(ProjectileUtility.ProjectilePlayerOwner(projectile), "Backstabber!"))
		{
			ProjectileSlashingBehaviour val = ((Component)projectile).gameObject.AddComponent<ProjectileSlashingBehaviour>();
			val.DestroyBaseAfterFirstSlash = false;
			val.timeBetweenSlashes = 1f;
			val.SlashDamageUsesBaseProjectileDamage = true;
			val.slashParameters.playerKnockbackForce = 0f;
		}
		((AdvancedGunBehavior)this).PostProcessProjectile(projectile);
	}
}
