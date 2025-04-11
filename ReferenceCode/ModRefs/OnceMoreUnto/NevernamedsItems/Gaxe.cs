using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Gaxe : AdvancedGunBehavior
{
	public static int ID;

	public static void Add()
	{
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0336: Unknown result type (might be due to invalid IL or missing references)
		//IL_035c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ee: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Gaxe", "gaxe");
		Game.Items.Rename("outdated_gun_mods:gaxe", "nn:gaxe");
		((Component)val).gameObject.AddComponent<Gaxe>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Diggy Diggy");
		GunExt.SetLongDescription((PickupObject)(object)val, "Advanced powder-powered mining tech only recently developed for use in the Black Powder Mine.");
		val.SetGunSprites("gaxe");
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
				val2.baseData.damage = 7f;
				flag = true;
			}
			else
			{
				projectile.ammoCost = 0;
				PickupObject byId4 = PickupObjectDatabase.GetById(56);
				Projectile val3 = Object.Instantiate<Projectile>(((Gun)((byId4 is Gun) ? byId4 : null)).DefaultModule.projectiles[0]);
				projectile.projectiles[0] = val3;
				((Component)val3).gameObject.SetActive(false);
				FakePrefab.MarkAsFakePrefab(((Component)val3).gameObject);
				((BraveBehaviour)val3).transform.parent = val.barrelOffset;
				Object.DontDestroyOnLoad((Object)(object)val3);
				ProjectileData baseData3 = val3.baseData;
				baseData3.range *= 0.1f;
				val3.baseData.damage = 15f;
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
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Gaxe Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/gaxe_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/gaxe_clipempty");
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
	}
}
