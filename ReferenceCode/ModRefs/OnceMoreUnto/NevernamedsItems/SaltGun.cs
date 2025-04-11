using System;
using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class SaltGun : AdvancedGunBehavior
{
	private float tableDamageBonusDuration = 0f;

	public static int SaltGunID;

	public static void Add()
	{
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_022a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0273: Unknown result type (might be due to invalid IL or missing references)
		//IL_028c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0293: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Salt Gun", "saltgun");
		Game.Items.Rename("outdated_gun_mods:salt_gun", "nn:salt_gun");
		((Component)val).gameObject.AddComponent<SaltGun>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Rub It In");
		GunExt.SetLongDescription((PickupObject)(object)val, "A way over-the-top method of pest control, used in the Gungeon to avoid Kaliber's disdain for flyswatters.");
		GunInt.SetupSprite(val, Initialisation.gunCollection, "saltgun_idle_001", 8, "saltgun_ammonomicon_001");
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(150);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		GunExt.SetAnimationFPS(val, val.shootAnimation, 13);
		GunExt.SetAnimationFPS(val, val.idleAnimation, 5);
		for (int i = 0; i < 5; i++)
		{
			PickupObject byId2 = PickupObjectDatabase.GetById(86);
			GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		}
		foreach (ProjectileModule projectile in val.Volley.projectiles)
		{
			projectile.ammoCost = 1;
			projectile.shootStyle = (ShootStyle)1;
			projectile.sequenceStyle = (ProjectileSequenceStyle)0;
			projectile.cooldownTime = 0.25f;
			projectile.angleVariance = 7f;
			projectile.numberOfShotsInClip = 10;
			Projectile val2 = Object.Instantiate<Projectile>(projectile.projectiles[0]);
			projectile.projectiles[0] = val2;
			((Component)val2).gameObject.SetActive(false);
			FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
			Object.DontDestroyOnLoad((Object)(object)val2);
			val2.SetProjectileSprite("salt_projectile", 2, 2, lightened: false, (Anchor)4, 2, 2, anchorChangesCollider: true, fixesScale: false, null, null);
			val2.baseData.range = 6f;
			val2.baseData.damage = 2f;
			ProjectileData baseData = val2.baseData;
			baseData.force *= 0.3f;
			if (projectile != val.DefaultModule)
			{
				projectile.ammoCost = 0;
			}
			((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		}
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("SaltGun Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/saltgun_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/saltgun_clipempty");
		val.reloadTime = 0.8f;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.43f, 0.37f, 0f);
		val.SetBaseMaxAmmo(300);
		val.gunClass = (GunClass)5;
		((PickupObject)val).quality = (ItemQuality)1;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		val.Volley.UsesShotgunStyleVelocityRandomizer = true;
		SaltGunID = ((PickupObject)val).PickupObjectId;
	}

	protected override void OnPickedUpByPlayer(PlayerController player)
	{
		player.OnTableFlipped = (Action<FlippableCover>)Delegate.Combine(player.OnTableFlipped, new Action<FlippableCover>(Flip));
		((AdvancedGunBehavior)this).OnPickedUpByPlayer(player);
	}

	protected override void OnPostDroppedByPlayer(PlayerController player)
	{
		player.OnTableFlipped = (Action<FlippableCover>)Delegate.Remove(player.OnTableFlipped, new Action<FlippableCover>(Flip));
		((AdvancedGunBehavior)this).OnPostDroppedByPlayer(player);
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)base.gun) && Object.op_Implicit((Object)(object)GunTools.GunPlayerOwner(base.gun)))
		{
			PlayerController obj = GunTools.GunPlayerOwner(base.gun);
			obj.OnTableFlipped = (Action<FlippableCover>)Delegate.Remove(obj.OnTableFlipped, new Action<FlippableCover>(Flip));
		}
		((BraveBehaviour)this).OnDestroy();
	}

	protected override void Update()
	{
		if (tableDamageBonusDuration >= 0f)
		{
			tableDamageBonusDuration -= BraveTime.DeltaTime;
		}
		((AdvancedGunBehavior)this).Update();
	}

	private void Flip(FlippableCover table)
	{
		if (Object.op_Implicit((Object)(object)base.gun) && Object.op_Implicit((Object)(object)GunTools.GunPlayerOwner(base.gun)) && CustomSynergies.PlayerHasActiveSynergy(GunTools.GunPlayerOwner(base.gun), "Table Salt"))
		{
			tableDamageBonusDuration += 7f;
		}
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		if (tableDamageBonusDuration > 0f)
		{
			ProjectileData baseData = projectile.baseData;
			baseData.damage *= 2f;
		}
		if (Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(projectile)) && CustomSynergies.PlayerHasActiveSynergy(ProjectileUtility.ProjectilePlayerOwner(projectile), "Pillars Of Salt"))
		{
			ProjectileData baseData2 = projectile.baseData;
			baseData2.range *= 3f;
		}
		((AdvancedGunBehavior)this).PostProcessProjectile(projectile);
	}
}
