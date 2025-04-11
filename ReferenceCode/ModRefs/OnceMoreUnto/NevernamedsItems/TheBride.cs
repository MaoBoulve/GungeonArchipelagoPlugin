using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class TheBride : GunBehaviour
{
	public static int TheBrideID;

	public static void Add()
	{
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0268: Unknown result type (might be due to invalid IL or missing references)
		//IL_0299: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d5: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("The Bride", "thebride");
		Game.Items.Rename("outdated_gun_mods:the_bride", "nn:the_bride");
		((Component)val).gameObject.AddComponent<TheBride>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Here Comes The Bride");
		GunExt.SetLongDescription((PickupObject)(object)val, "A lonesome gun, stood up on it's wedding day and forever hoping to be reunited with it's partner.");
		GunInt.SetupSprite(val, Initialisation.gunCollection, "thebride_idle_001", 8, "thebride_ammonomicon_001");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 13);
		GunExt.SetAnimationFPS(val, val.idleAnimation, 5);
		for (int i = 0; i < 7; i++)
		{
			PickupObject byId = PickupObjectDatabase.GetById(86);
			GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		}
		int num = 0;
		foreach (ProjectileModule projectile in val.Volley.projectiles)
		{
			projectile.ammoCost = 1;
			projectile.shootStyle = (ShootStyle)0;
			projectile.sequenceStyle = (ProjectileSequenceStyle)0;
			projectile.cooldownTime = 0.5f;
			projectile.angleVariance = 11.25f;
			projectile.numberOfShotsInClip = 7;
			Projectile val2 = Object.Instantiate<Projectile>(projectile.projectiles[0]);
			projectile.projectiles[0] = val2;
			((Component)val2).gameObject.SetActive(false);
			FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
			Object.DontDestroyOnLoad((Object)(object)val2);
			val2.baseData.range = 15f;
			val2.baseData.damage = 12f;
			val2.hitEffects.alwaysUseMidair = true;
			val2.hitEffects.overrideMidairDeathVFX = SharedVFX.WhiteCircleVFX;
			val2.SetProjectileSprite("bride_projectile", 12, 12, lightened: true, (Anchor)4, 10, 10, anchorChangesCollider: true, fixesScale: false, null, null);
			if (num == 1 || num == 2 || num == 3)
			{
				projectile.angleFromAim = 45f;
			}
			else if (num == 4 || num == 5 || num == 6)
			{
				projectile.angleFromAim = -45f;
			}
			num++;
			if (projectile != val.DefaultModule)
			{
				projectile.ammoCost = 0;
			}
			((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		}
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Bride Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/bride_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/groom_clipempty");
		val.reloadTime = 1.5f;
		val.gunHandedness = (GunHandedness)1;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.62f, 0.81f, 0f);
		val.SetBaseMaxAmmo(100);
		val.gunClass = (GunClass)5;
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		val.Volley.UsesShotgunStyleVelocityRandomizer = true;
		TheBrideID = ((PickupObject)val).PickupObjectId;
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)projectile) && Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(projectile)) && CustomSynergies.PlayerHasActiveSynergy(ProjectileUtility.ProjectilePlayerOwner(projectile), "Wuv... twue wuv...") && Random.value <= 0.1f)
		{
			projectile.AdjustPlayerProjectileTint(ExtendedColours.charmPink, 2, 0f);
			projectile.statusEffectsToApply.Add((GameActorEffect)(object)StaticStatusEffects.charmingRoundsEffect);
		}
		((GunBehaviour)this).PostProcessProjectile(projectile);
	}
}
