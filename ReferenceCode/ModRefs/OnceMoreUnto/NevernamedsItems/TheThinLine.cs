using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Gungeon;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class TheThinLine : AdvancedGunBehavior
{
	public static int ID;

	public static ExplosionData DataForProjectiles;

	public static void Add()
	{
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_0321: Unknown result type (might be due to invalid IL or missing references)
		//IL_035c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0221: Unknown result type (might be due to invalid IL or missing references)
		//IL_025c: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fc: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("The Thin Line", "thinline");
		Game.Items.Rename("outdated_gun_mods:the_thin_line", "nn:the_thin_line");
		((Component)val).gameObject.AddComponent<TheThinLine>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Scienced To The Max");
		GunExt.SetLongDescription((PickupObject)(object)val, "A slimmed down, pocket version of the tachyon projectile emmitter known as the Fat Line.\n\nIt's projectiles defy each other, and have volatile effects upon meeting.");
		val.SetGunSprites("thinline");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 10);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(562);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		for (int i = 0; i < 2; i++)
		{
			PickupObject byId2 = PickupObjectDatabase.GetById(86);
			GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		}
		val.reloadTime = 1f;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.37f, 0.87f, 0f);
		val.SetBaseMaxAmmo(260);
		val.ammo = 200;
		val.gunClass = (GunClass)1;
		foreach (ProjectileModule projectile in val.Volley.projectiles)
		{
			projectile.shootStyle = (ShootStyle)0;
			projectile.sequenceStyle = (ProjectileSequenceStyle)0;
			projectile.cooldownTime = 0.2f;
			projectile.numberOfShotsInClip = 6;
			projectile.angleVariance = 0f;
			if (projectile != val.DefaultModule)
			{
				Projectile val2 = (Projectile)(object)DataCloners.CopyFields<TachyonProjectile>(Object.Instantiate<Projectile>(projectile.projectiles[0]));
				((Component)val2).gameObject.SetActive(false);
				FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
				Object.DontDestroyOnLoad((Object)(object)val2);
				ProjectileData baseData = val2.baseData;
				baseData.damage *= 2f;
				ProjectileData baseData2 = val2.baseData;
				baseData2.speed *= 0.5f;
				((BraveBehaviour)val2).specRigidbody.CollideWithTileMap = false;
				val2.m_ignoreTileCollisionsTimer = 1f;
				val2.pierceMinorBreakables = true;
				ThinLineCollidee orAddComponent = GameObjectExtensions.GetOrAddComponent<ThinLineCollidee>(((Component)val2).gameObject);
				projectile.ammoCost = 0;
				ProjectileBuilders.AnimateProjectileBundle(val2, "ThinLinePinkProjectile", Initialisation.ProjectileCollection, Initialisation.projectileAnimationCollection, "ThinLinePinkProjectile", MiscTools.DupeList<IntVector2>(new IntVector2(10, 10), 6), MiscTools.DupeList(value: true, 6), MiscTools.DupeList<Anchor>((Anchor)4, 6), MiscTools.DupeList(value: true, 6), MiscTools.DupeList(value: false, 6), MiscTools.DupeList<Vector3?>(null, 6), MiscTools.DupeList((IntVector2?)new IntVector2(10, 10), 6), MiscTools.DupeList<IntVector2?>(null, 6), MiscTools.DupeList<Projectile>(null, 6));
				projectile.projectiles[0] = val2;
			}
			else
			{
				Projectile val3 = Object.Instantiate<Projectile>(projectile.projectiles[0]);
				((Component)val3).gameObject.SetActive(false);
				FakePrefab.MarkAsFakePrefab(((Component)val3).gameObject);
				Object.DontDestroyOnLoad((Object)(object)val3);
				ProjectileData baseData3 = val3.baseData;
				baseData3.damage *= 2f;
				ProjectileData baseData4 = val3.baseData;
				baseData4.speed *= 0.5f;
				ProjectileBuilders.AnimateProjectileBundle(val3, "ThinLineBlueProjectile", Initialisation.ProjectileCollection, Initialisation.projectileAnimationCollection, "ThinLineBlueProjectile", MiscTools.DupeList<IntVector2>(new IntVector2(10, 10), 6), MiscTools.DupeList(value: true, 6), MiscTools.DupeList<Anchor>((Anchor)4, 6), MiscTools.DupeList(value: true, 6), MiscTools.DupeList(value: false, 6), MiscTools.DupeList<Vector3?>(null, 6), MiscTools.DupeList((IntVector2?)new IntVector2(10, 10), 6), MiscTools.DupeList<IntVector2?>(null, 6), MiscTools.DupeList<Projectile>(null, 6));
				projectile.ammoCost = 1;
				ThinLineCollision orAddComponent2 = GameObjectExtensions.GetOrAddComponent<ThinLineCollision>(((Component)val3).gameObject);
				projectile.projectiles[0] = val3;
			}
		}
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Thinline Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/thinline_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/thinline_clipempty");
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.PURCHASED_THETHINLINE, requiredFlagValue: true);
		((PickupObject)(object)val).AddItemToDougMetaShop(25, null);
		ID = ((PickupObject)val).PickupObjectId;
	}

	protected override void OnPickedUpByPlayer(PlayerController player)
	{
		if (DataForProjectiles == null)
		{
			DataForProjectiles = StaticExplosionDatas.explosiveRoundsExplosion.CopyExplosionData();
		}
		if (!DataForProjectiles.ignoreList.Contains(((BraveBehaviour)player).specRigidbody))
		{
			DataForProjectiles.ignoreList.Add(((BraveBehaviour)player).specRigidbody);
		}
		((AdvancedGunBehavior)this).OnPickedUpByPlayer(player);
	}
}
