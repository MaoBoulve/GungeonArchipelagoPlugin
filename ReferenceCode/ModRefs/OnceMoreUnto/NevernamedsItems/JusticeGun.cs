using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Gungeon;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class JusticeGun : GunBehaviour
{
	public static int JusticeID;

	public static void Add()
	{
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0237: Unknown result type (might be due to invalid IL or missing references)
		//IL_0256: Unknown result type (might be due to invalid IL or missing references)
		//IL_026c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0279: Unknown result type (might be due to invalid IL or missing references)
		//IL_029f: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Justice", "justice");
		Game.Items.Rename("outdated_gun_mods:justice", "nn:justice");
		((Component)val).gameObject.AddComponent<JusticeGun>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Served");
		GunExt.SetLongDescription((PickupObject)(object)val, "Bello's trusty shotgun, custom made for his big, burly hands.");
		GunInt.SetupSprite(val, Initialisation.gunCollection, "justice_idle_001", 8, "justice_ammonomicon_001");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 8);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 8);
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)val, (StatType)13, 0.8f, (ModifyMethod)1);
		for (int i = 0; i < 6; i++)
		{
			PickupObject byId = PickupObjectDatabase.GetById(86);
			GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		}
		foreach (ProjectileModule projectile in val.Volley.projectiles)
		{
			projectile.ammoCost = 1;
			projectile.shootStyle = (ShootStyle)0;
			projectile.sequenceStyle = (ProjectileSequenceStyle)0;
			projectile.cooldownTime = 0.6f;
			projectile.angleVariance = 45f;
			projectile.numberOfShotsInClip = 5;
			Projectile val2 = Object.Instantiate<Projectile>(projectile.projectiles[0]);
			projectile.projectiles[0] = val2;
			((Component)val2).gameObject.SetActive(false);
			FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
			Object.DontDestroyOnLoad((Object)(object)val2);
			ProjectileData baseData = val2.baseData;
			baseData.damage *= 3f;
			ProjectileData baseData2 = val2.baseData;
			baseData2.speed *= 1.2f;
			val2.pierceMinorBreakables = true;
			JusticeBurstHandler justiceBurstHandler = ((Component)val2).gameObject.AddComponent<JusticeBurstHandler>();
			val2.SetProjectileSprite("justice_projectile", 12, 12, lightened: true, (Anchor)4, 10, 10, anchorChangesCollider: true, fixesScale: false, null, null);
			if (projectile != val.DefaultModule)
			{
				projectile.ammoCost = 0;
			}
			((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		}
		val.reloadTime = 2f;
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(3.12f, 0.93f, 0f);
		val.SetBaseMaxAmmo(80);
		val.gunClass = (GunClass)5;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Justice Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/justice_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/justice_clipempty");
		((PickupObject)val).quality = (ItemQuality)4;
		((BraveBehaviour)val).encounterTrackable.EncounterGuid = "this is Justice";
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		JusticeID = ((PickupObject)val).PickupObjectId;
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.ANGERED_BELLO, requiredFlagValue: true);
	}

	public override void Update()
	{
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		if (!Object.op_Implicit((Object)(object)base.gun) || !Object.op_Implicit((Object)(object)base.gun.CurrentOwner) || !(base.gun.CurrentOwner is PlayerController))
		{
			return;
		}
		GameActor currentOwner = base.gun.CurrentOwner;
		PlayerController val = (PlayerController)(object)((currentOwner is PlayerController) ? currentOwner : null);
		if (CustomSynergies.PlayerHasActiveSynergy(val, "Shotkeeper"))
		{
			if (base.gun.DefaultModule.numberOfShotsInClip != 5)
			{
				return;
			}
			base.gun.SetBaseMaxAmmo(600);
			{
				foreach (ProjectileModule projectile in base.gun.Volley.projectiles)
				{
					projectile.shootStyle = (ShootStyle)4;
					projectile.burstShotCount = 3;
					projectile.burstCooldownTime = 0.2f;
					projectile.numberOfShotsInClip = 12;
				}
				return;
			}
		}
		if (base.gun.DefaultModule.numberOfShotsInClip != 12)
		{
			return;
		}
		base.gun.SetBaseMaxAmmo(200);
		foreach (ProjectileModule projectile2 in base.gun.Volley.projectiles)
		{
			projectile2.shootStyle = (ShootStyle)0;
			projectile2.numberOfShotsInClip = 5;
		}
	}

	public override void OnPostFired(PlayerController player, Gun gun)
	{
		gun.PreventNormalFireAudio = true;
		AkSoundEngine.PostEvent("Play_WPN_shotgun_shot_01", ((Component)this).gameObject);
	}
}
