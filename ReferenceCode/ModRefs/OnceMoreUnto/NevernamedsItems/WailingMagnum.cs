using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class WailingMagnum : GunBehaviour
{
	public static void Add()
	{
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Wailing Magnum", "wailingmagnum");
		Game.Items.Rename("outdated_gun_mods:wailing_magnum", "nn:wailing_magnum");
		((Component)val).gameObject.AddComponent<WailingMagnum>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Sinister Bells");
		GunExt.SetLongDescription((PickupObject)(object)val, "A gun left unfinished and abandoned by its creator. It still has great potential.");
		GunExt.SetupSprite(val, (tk2dSpriteCollectionData)null, "wailingmagnum_idle_001", 8);
		GunExt.SetAnimationFPS(val, val.shootAnimation, 20);
		PickupObject byId = PickupObjectDatabase.GetById(38);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1.1f;
		val.DefaultModule.cooldownTime = 0.1f;
		val.DefaultModule.numberOfShotsInClip = 6;
		val.SetBaseMaxAmmo(166);
		((PickupObject)val).quality = (ItemQuality)(-100);
		((BraveBehaviour)val).encounterTrackable.EncounterGuid = "this is the Wailing Magnum";
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		GameActor currentOwner = base.gun.CurrentOwner;
		PlayerController val = (PlayerController)(object)((currentOwner is PlayerController) ? currentOwner : null);
		if ((Object)(object)val == (Object)null)
		{
			base.gun.ammo = base.gun.GetBaseMaxAmmo();
		}
		ProjectileData baseData = projectile.baseData;
		baseData.damage *= 0.9f;
		ProjectileData baseData2 = projectile.baseData;
		baseData2.speed *= 1f;
		base.gun.DefaultModule.ammoCost = 1;
		((GunBehaviour)this).PostProcessProjectile(projectile);
	}

	public override void OnReloadPressed(PlayerController player, Gun gun, bool bSOMETHING)
	{
		ETGModConsole.Log((object)"You reloaded the Wailing Magnum", false);
		((GunBehaviour)this).OnReloadPressed(player, gun, bSOMETHING);
	}

	public override void OnPostFired(PlayerController player, Gun gun)
	{
		gun.PreventNormalFireAudio = true;
		AkSoundEngine.PostEvent("Play_WPN_smileyrevolver_shot_01", ((Component)this).gameObject);
	}
}
