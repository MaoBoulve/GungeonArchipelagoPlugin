using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class MoltenHeat : AdvancedGunBehavior
{
	public static void Add()
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0266: Unknown result type (might be due to invalid IL or missing references)
		//IL_028f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0296: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Molten Heat", "moltenheat");
		Game.Items.Rename("outdated_gun_mods:molten_heat", "nn:molten_heat");
		MoltenHeat moltenHeat = ((Component)val).gameObject.AddComponent<MoltenHeat>();
		((AdvancedGunBehavior)moltenHeat).preventNormalFireAudio = true;
		GunExt.SetShortDescription((PickupObject)(object)val, "Packed");
		GunExt.SetLongDescription((PickupObject)(object)val, "This normal handgun was accidentally dipped into the molten steel of the forge, partially melting it in the process.");
		val.SetGunSprites("moltenheat", 8, noAmmonomicon: false, 2);
		val.isAudioLoop = true;
		val.gunClass = (GunClass)20;
		int num = 1;
		for (int i = 0; i < 4; i++)
		{
			PickupObject byId = PickupObjectDatabase.GetById(86);
			GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		}
		foreach (ProjectileModule projectile in val.Volley.projectiles)
		{
			projectile.ammoCost = 10;
			if (projectile != val.DefaultModule)
			{
				projectile.ammoCost = 0;
			}
			projectile.angleVariance = 0f;
			projectile.shootStyle = (ShootStyle)2;
			projectile.sequenceStyle = (ProjectileSequenceStyle)0;
			projectile.cooldownTime = 0.001f;
			projectile.numberOfShotsInClip = -1;
			projectile.ammoType = (AmmoType)14;
			projectile.customAmmoType = "red_beam";
			Projectile val2 = ProjectileUtility.SetupProjectile(658);
			val2.baseData.damage = 15f;
			val2.baseData.force = 15f;
			val2.baseData.range = 100f;
			switch (num)
			{
			case 1:
				val2.baseData.speed = 90f;
				break;
			case 2:
				val2.baseData.speed = 30f;
				break;
			case 3:
				val2.baseData.speed = 10f;
				break;
			case 4:
				val2.baseData.speed = 5f;
				break;
			}
			((Component)val2).gameObject.GetComponent<BasicBeamController>().homingAngularVelocity = 0f;
			((Component)val2).gameObject.GetComponent<BasicBeamController>().endAudioEvent = "Stop_WPN_demonhead_loop_01";
			((Component)val2).gameObject.GetComponent<BasicBeamController>().startAudioEvent = "Play_WPN_demonhead_shot_01";
			num++;
			projectile.projectiles[0] = val2;
		}
		val.doesScreenShake = false;
		val.reloadTime = 1f;
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		val.SetBarrel(19, 12);
		val.SetBaseMaxAmmo(500);
		val.ammo = 500;
		val.gunHandedness = (GunHandedness)2;
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
	}
}
