using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Octagun : GunBehaviour
{
	public static int OctagunID;

	public bool hasSynergyLastFrame = false;

	public static void Add()
	{
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0223: Unknown result type (might be due to invalid IL or missing references)
		//IL_023c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0249: Unknown result type (might be due to invalid IL or missing references)
		//IL_026f: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Octagun", "octagun");
		Game.Items.Rename("outdated_gun_mods:octagun", "nn:octagun");
		((Component)val).gameObject.AddComponent<Octagun>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Welcome To The 2nd Dimension");
		GunExt.SetLongDescription((PickupObject)(object)val, "A simple shape, with a name that kinda sounds like it has 'gun' in it.\n\nOften confused by preschoolers for it's much more fashionable cousin, the Pentagon.");
		GunInt.SetupSprite(val, Initialisation.gunCollection, "octagun_idle_001", 8, "octagun_ammonomicon_001");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 8);
		GunExt.SetAnimationFPS(val, val.idleAnimation, 5);
		for (int i = 0; i < 8; i++)
		{
			PickupObject byId = PickupObjectDatabase.GetById(86);
			GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		}
		foreach (ProjectileModule projectile in val.Volley.projectiles)
		{
			projectile.ammoCost = 8;
			projectile.shootStyle = (ShootStyle)0;
			projectile.sequenceStyle = (ProjectileSequenceStyle)0;
			projectile.cooldownTime = 0.8f;
			projectile.angleVariance = 35f;
			projectile.numberOfShotsInClip = 8;
			Projectile val2 = Object.Instantiate<Projectile>(projectile.projectiles[0]);
			projectile.projectiles[0] = val2;
			((Component)val2).gameObject.SetActive(false);
			FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
			Object.DontDestroyOnLoad((Object)(object)val2);
			ProjectileData baseData = val2.baseData;
			baseData.damage *= 1.6f;
			ProjectileData baseData2 = val2.baseData;
			baseData2.speed *= 0.1f;
			val2.SetProjectileSprite("octagun_projectile", 10, 10, lightened: true, (Anchor)4, 8, 8, anchorChangesCollider: true, fixesScale: false, null, null);
			if (projectile != val.DefaultModule)
			{
				projectile.ammoCost = 0;
			}
			((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		}
		val.reloadTime = 1.5f;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1f, 0.43f, 0f);
		val.SetBaseMaxAmmo(888);
		val.gunClass = (GunClass)5;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Octagun Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/octagun_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/octagun_clipempty");
		((PickupObject)val).quality = (ItemQuality)2;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		OctagunID = ((PickupObject)val).PickupObjectId;
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		if ((Object)(object)ProjectileUtility.ProjectilePlayerOwner(projectile) != (Object)null && CustomSynergies.PlayerHasActiveSynergy(ProjectileUtility.ProjectilePlayerOwner(projectile), "Shapes N' Beats"))
		{
			ProjectileData baseData = projectile.baseData;
			baseData.speed *= 3f;
		}
		((GunBehaviour)this).PostProcessProjectile(projectile);
	}

	public override void Update()
	{
		if ((Object)(object)GunTools.GunPlayerOwner(base.gun) != (Object)null)
		{
			bool flag = CustomSynergies.PlayerHasActiveSynergy(GunTools.GunPlayerOwner(base.gun), "Shapes N' Beats");
			if (flag != hasSynergyLastFrame)
			{
				Recalc(flag);
				hasSynergyLastFrame = flag;
			}
		}
	}

	private void Recalc(bool hasSynergy)
	{
		ItemBuilder.RemoveCurrentGunStatModifier(base.gun, (StatType)1);
		if (hasSynergy)
		{
			ItemBuilder.AddCurrentGunStatModifier(base.gun, (StatType)1, 4f, (ModifyMethod)1);
		}
	}
}
