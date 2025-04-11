using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Gungeon;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class ShroomedGun : AdvancedGunBehavior
{
	public static int ShroomedGunID;

	public static void Add()
	{
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0278: Unknown result type (might be due to invalid IL or missing references)
		//IL_027f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Shroomed Gun", "shroomedgun");
		Game.Items.Rename("outdated_gun_mods:shroomed_gun", "nn:shroomed_gun");
		ShroomedGun shroomedGun = ((Component)val).gameObject.AddComponent<ShroomedGun>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Looney");
		GunExt.SetLongDescription((PickupObject)(object)val, "The classic result of a misfired magnum.\n\nLooks like someone stuck their finger in the barrel.");
		GunInt.SetupSprite(val, Initialisation.gunCollection, "shroomedgun_idle_001", 8, "shroomedgun_ammonomicon_001");
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(38);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		GunExt.SetAnimationFPS(val, val.shootAnimation, 15);
		for (int i = 0; i < 2; i++)
		{
			PickupObject byId2 = PickupObjectDatabase.GetById(38);
			GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		}
		float cooldownTime = 0.15f;
		int numberOfShotsInClip = 6;
		int num = 0;
		foreach (ProjectileModule projectile in val.Volley.projectiles)
		{
			projectile.numberOfShotsInClip = numberOfShotsInClip;
			Projectile val2 = Object.Instantiate<Projectile>(projectile.projectiles[0]);
			projectile.projectiles[0] = val2;
			((Component)val2).gameObject.SetActive(false);
			FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
			Object.DontDestroyOnLoad((Object)(object)val2);
			ProjectileData baseData = val2.baseData;
			baseData.damage *= 0.5f;
			ProjectileData baseData2 = val2.baseData;
			baseData2.speed *= 1f;
			ProjectileData baseData3 = val2.baseData;
			baseData3.range *= 0.5f;
			if (num <= 0)
			{
				projectile.ammoCost = 0;
				projectile.sequenceStyle = (ProjectileSequenceStyle)0;
				projectile.shootStyle = (ShootStyle)0;
				projectile.cooldownTime = cooldownTime;
				projectile.angleVariance = 7f;
				projectile.angleFromAim = -30f;
				num++;
			}
			else if (num >= 1)
			{
				projectile.ammoCost = 1;
				projectile.sequenceStyle = (ProjectileSequenceStyle)0;
				projectile.shootStyle = (ShootStyle)0;
				projectile.cooldownTime = cooldownTime;
				projectile.angleVariance = 7f;
				projectile.angleFromAim = 30f;
				num++;
			}
		}
		val.reloadTime = 1f;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1f, 0.81f, 0f);
		val.SetBaseMaxAmmo(140);
		val.gunClass = (GunClass)55;
		((PickupObject)val).quality = (ItemQuality)1;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.HURT_BY_SHROOMER, requiredFlagValue: true);
		val.reloadAnimation = val.shootAnimation;
		val.AddShellCasing(0, 0, 6);
		ItemBuilder.AddToGunslingKingTable((PickupObject)(object)val, 1);
		ShroomedGunID = ((PickupObject)val).PickupObjectId;
	}

	protected override void Update()
	{
		if ((Object)(object)GunTools.GunPlayerOwner(base.gun) != (Object)null)
		{
			GameActor currentOwner = base.gun.CurrentOwner;
			PlayerController val = (PlayerController)(object)((currentOwner is PlayerController) ? currentOwner : null);
			if (CustomSynergies.PlayerHasActiveSynergy(val, "Ballistic Fingers"))
			{
				if (base.gun.Volley.projectiles[0].angleFromAim == -30f)
				{
					base.gun.Volley.projectiles[0].angleFromAim = -10f;
					base.gun.Volley.projectiles[1].angleFromAim = 10f;
				}
			}
			else if (base.gun.Volley.projectiles[0].angleFromAim == -10f)
			{
				base.gun.Volley.projectiles[0].angleFromAim = -30f;
				base.gun.Volley.projectiles[1].angleFromAim = 30f;
			}
		}
		((AdvancedGunBehavior)this).Update();
	}
}
