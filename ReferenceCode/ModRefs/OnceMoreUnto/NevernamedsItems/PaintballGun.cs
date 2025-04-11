using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class PaintballGun : GunBehaviour
{
	public static void Add()
	{
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Paintball Gun", "paintballgun");
		Game.Items.Rename("outdated_gun_mods:paintball_gun", "nn:paintball_gun");
		((Component)val).gameObject.AddComponent<PaintballGun>();
		GunExt.SetShortDescription((PickupObject)(object)val, "The Colours, Duke!");
		GunExt.SetLongDescription((PickupObject)(object)val, "Small rubbery pellets loaded with lethal old-school lead paint.\n\nBrought to the Gungeon by an amateur artist who wished to flee his debts.");
		val.SetGunSprites("paintballgun");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 14);
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1.1f;
		val.DefaultModule.cooldownTime = 0.1f;
		val.DefaultModule.numberOfShotsInClip = 10;
		val.SetBaseMaxAmmo(300);
		val.gunClass = (GunClass)1;
		Projectile val2 = ProjectileUtility.SetupProjectile(86);
		val.DefaultModule.projectiles[0] = val2;
		val2.baseData.damage = 7.5f;
		RandomiseProjectileColourComponent randomiseProjectileColourComponent = ((Component)val2).gameObject.AddComponent<RandomiseProjectileColourComponent>();
		randomiseProjectileColourComponent.ApplyColourToHitEnemies = true;
		randomiseProjectileColourComponent.paintballGun = true;
		((PickupObject)val).quality = (ItemQuality)2;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("PaintBall Ammo", "NevernamedsItems/Resources/CustomGunAmmoTypes/paintballgun_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/paintballgun_clipempty");
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		if (Object.op_Implicit((Object)(object)projectile) && Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(projectile)) && CustomSynergies.PlayerHasActiveSynergy(ProjectileUtility.ProjectilePlayerOwner(projectile), "Paint It Black"))
		{
			ProjectileData baseData = projectile.baseData;
			baseData.damage *= 1.2f;
			projectile.BossDamageMultiplier *= 1.1f;
		}
		((GunBehaviour)this).PostProcessProjectile(projectile);
	}

	public override void OnPostFired(PlayerController player, Gun gun)
	{
		gun.PreventNormalFireAudio = true;
		AkSoundEngine.PostEvent("Play_WPN_smileyrevolver_shot_01", ((Component)this).gameObject);
	}
}
