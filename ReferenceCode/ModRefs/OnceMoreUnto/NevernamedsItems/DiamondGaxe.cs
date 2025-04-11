using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class DiamondGaxe : AdvancedGunBehavior
{
	public static int ID;

	public static void Add()
	{
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0361: Unknown result type (might be due to invalid IL or missing references)
		//IL_0368: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Diamond Gaxe", "diamondgaxe");
		Game.Items.Rename("outdated_gun_mods:diamond_gaxe", "nn:gaxe+diamond_gaxe");
		((Component)val).gameObject.AddComponent<DiamondGaxe>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Diggy Diggy+");
		GunExt.SetLongDescription((PickupObject)(object)val, "Never spend your diamonds on a hoe");
		val.SetGunSprites("diamondgaxe", 8, noAmmonomicon: true);
		GunExt.SetAnimationFPS(val, val.shootAnimation, 16);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(335);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		PickupObject byId3 = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId3 is Gun) ? byId3 : null), true, false);
		val.reloadTime = 1f;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.62f, 1.12f, 0f);
		val.SetBaseMaxAmmo(150);
		val.gunClass = (GunClass)1;
		bool flag = false;
		foreach (ProjectileModule projectile in val.Volley.projectiles)
		{
			if (!flag)
			{
				projectile.ammoCost = 1;
				Projectile val2 = Object.Instantiate<Projectile>(projectile.projectiles[0]);
				projectile.projectiles[0] = val2;
				((Component)val2).gameObject.SetActive(false);
				FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
				Object.DontDestroyOnLoad((Object)(object)val2);
				((BraveBehaviour)val2).transform.parent = val.barrelOffset;
				ProjectileData baseData = val2.baseData;
				baseData.range *= 2f;
				ProjectileData baseData2 = val2.baseData;
				baseData2.speed *= 1.5f;
				val2.baseData.damage = 14f;
				ref GameObject overrideMidairDeathVFX = ref val2.hitEffects.overrideMidairDeathVFX;
				PickupObject byId4 = PickupObjectDatabase.GetById(506);
				overrideMidairDeathVFX = ((Gun)((byId4 is Gun) ? byId4 : null)).DefaultModule.projectiles[0].hitEffects.overrideMidairDeathVFX;
				val2.hitEffects.alwaysUseMidair = true;
				GunTools.SetProjectileSpriteRight(val2, "diamond_projectile", 11, 11, false, (Anchor)4, (int?)10, (int?)10, true, false, (int?)null, (int?)null, (Projectile)null);
				flag = true;
			}
			else
			{
				projectile.ammoCost = 0;
				PickupObject byId5 = PickupObjectDatabase.GetById(56);
				Projectile val3 = Object.Instantiate<Projectile>(((Gun)((byId5 is Gun) ? byId5 : null)).DefaultModule.projectiles[0]);
				projectile.projectiles[0] = val3;
				((Component)val3).gameObject.SetActive(false);
				FakePrefab.MarkAsFakePrefab(((Component)val3).gameObject);
				((BraveBehaviour)val3).transform.parent = val.barrelOffset;
				Object.DontDestroyOnLoad((Object)(object)val3);
				ProjectileData baseData3 = val3.baseData;
				baseData3.range *= 0.1f;
				val3.baseData.damage = 30f;
				((BraveBehaviour)val3).specRigidbody.CollideWithTileMap = false;
				val3.pierceMinorBreakables = true;
				PierceProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<PierceProjModifier>(((Component)val3).gameObject);
				orAddComponent.penetration = 100;
				MaintainDamageOnPierce orAddComponent2 = GameObjectExtensions.GetOrAddComponent<MaintainDamageOnPierce>(((Component)val3).gameObject);
				GunTools.SetProjectileSpriteRight(val3, "gaxe_projectile", 12, 40, true, (Anchor)4, (int?)8, (int?)30, true, false, (int?)null, (int?)null, (Projectile)null);
				DamageSecretWalls orAddComponent3 = GameObjectExtensions.GetOrAddComponent<DamageSecretWalls>(((Component)val3).gameObject);
			}
			projectile.shootStyle = (ShootStyle)0;
			projectile.sequenceStyle = (ProjectileSequenceStyle)0;
			projectile.cooldownTime = 0.35f;
			projectile.angleVariance = 5f;
			projectile.numberOfShotsInClip = 5;
		}
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Diamond Gaxe Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/diamondgaxe_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/gaxe_clipempty");
		((PickupObject)val).quality = (ItemQuality)(-100);
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		GunExt.SetName((PickupObject)(object)val, "Gaxe");
		ID = ((PickupObject)val).PickupObjectId;
	}
}
