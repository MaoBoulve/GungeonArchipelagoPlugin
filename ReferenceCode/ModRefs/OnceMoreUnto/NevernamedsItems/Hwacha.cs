using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Hwacha : GunBehaviour
{
	public static int HwachaID;

	public static void Add()
	{
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_022d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0234: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Hwacha", "hwacha");
		Game.Items.Rename("outdated_gun_mods:hwacha", "nn:hwacha");
		((Component)val).gameObject.AddComponent<Hwacha>();
		GunExt.SetShortDescription((PickupObject)(object)val, "15th Century");
		GunExt.SetLongDescription((PickupObject)(object)val, "An ancient machine designed to spew forth rocket-powered arrows. Some consider it the great grandfather of the modern minigun.\n\nOnce it has begun firing, it is difficult to stop it.");
		val.SetGunSprites("hwacha");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 8);
		GunExt.SetAnimationFPS(val, val.idleAnimation, 5);
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		for (int i = 0; i < 3; i++)
		{
			PickupObject byId = PickupObjectDatabase.GetById(12);
			GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		}
		foreach (ProjectileModule projectile in val.Volley.projectiles)
		{
			projectile.ammoCost = 1;
			projectile.shootStyle = (ShootStyle)4;
			projectile.burstShotCount = 200;
			projectile.burstCooldownTime = 0.05f;
			projectile.sequenceStyle = (ProjectileSequenceStyle)0;
			projectile.cooldownTime = 0.8f;
			projectile.angleVariance = 40f;
			projectile.numberOfShotsInClip = 200;
			Projectile val2 = Object.Instantiate<Projectile>(projectile.projectiles[0]);
			projectile.projectiles[0] = val2;
			((Component)val2).gameObject.SetActive(false);
			FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
			Object.DontDestroyOnLoad((Object)(object)val2);
			ProjectileData baseData = val2.baseData;
			baseData.damage *= 0.5f;
			ProjectileData baseData2 = val2.baseData;
			baseData2.speed *= 1.5f;
			if (projectile != val.DefaultModule)
			{
				projectile.ammoCost = 0;
			}
			((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		}
		val.reloadTime = 5f;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.87f, 0.68f, 0f);
		val.SetBaseMaxAmmo(600);
		val.PreventNormalFireAudio = true;
		val.gunClass = (GunClass)10;
		((PickupObject)val).quality = (ItemQuality)4;
		((BraveBehaviour)val).encounterTrackable.EncounterGuid = "this is the Hwacha";
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		AlexandriaTags.SetTag((PickupObject)(object)val, "arrow_bolt_weapon");
		HwachaID = ((PickupObject)val).PickupObjectId;
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		((GunBehaviour)this).PostProcessProjectile(projectile);
		GameActor owner = projectile.Owner;
		PlayerController val = (PlayerController)(object)((owner is PlayerController) ? owner : null);
		if (CustomSynergies.PlayerHasActiveSynergy(val, "Ancient Traditions"))
		{
			ProjectileData baseData = projectile.baseData;
			baseData.damage *= 2f;
		}
	}

	public override void OnPostFired(PlayerController player, Gun gun)
	{
		gun.PreventNormalFireAudio = true;
		AkSoundEngine.PostEvent("Play_WPN_crossbow_shot_01", ((Component)this).gameObject);
	}

	public override void OnReloadPressed(PlayerController player, Gun gun, bool bSOMETHING)
	{
		((GunBehaviour)this).OnReloadPressed(player, gun, bSOMETHING);
		AkSoundEngine.PostEvent("Play_WPN_crossbow_reload_01", ((Component)this).gameObject);
	}

	public override void Update()
	{
		if (!Object.op_Implicit((Object)(object)base.gun) || !Object.op_Implicit((Object)(object)base.gun.CurrentOwner) || !Object.op_Implicit((Object)(object)GunTools.GunPlayerOwner(base.gun)))
		{
			return;
		}
		GameActor currentOwner = base.gun.CurrentOwner;
		PlayerController val = (PlayerController)(object)((currentOwner is PlayerController) ? currentOwner : null);
		if (CustomSynergies.PlayerHasActiveSynergy(val, "Ancient Traditions"))
		{
			if (base.gun.DefaultModule.burstShotCount != 200)
			{
				return;
			}
			{
				foreach (ProjectileModule projectile in base.gun.Volley.projectiles)
				{
					projectile.burstShotCount = 100;
				}
				return;
			}
		}
		if (base.gun.DefaultModule.burstShotCount != 100)
		{
			return;
		}
		foreach (ProjectileModule projectile2 in base.gun.Volley.projectiles)
		{
			projectile2.burstShotCount = 200;
		}
	}
}
