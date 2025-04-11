using Alexandria.ItemAPI;
using Gungeon;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class Spiral : AdvancedGunBehavior
{
	public static int SpiralID;

	public static Projectile swirlyProj;

	public static void Add()
	{
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Spiral", "spiral");
		Game.Items.Rename("outdated_gun_mods:spiral", "nn:spiral");
		((Component)val).gameObject.AddComponent<Spiral>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Come Join Me...");
		GunExt.SetLongDescription((PickupObject)(object)val, "Forever. Inescapable. Beautiful.\n\nAll will become a part of the Spiral.");
		val.SetGunSprites("spiral", 16);
		GunExt.SetAnimationFPS(val, val.shootAnimation, 30);
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 2f;
		val.DefaultModule.cooldownTime = 1f;
		val.DefaultModule.numberOfShotsInClip = 1;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.12f, 0.62f, 0f);
		val.SetBaseMaxAmmo(150);
		val.gunClass = (GunClass)50;
		PickupObject byId2 = PickupObjectDatabase.GetById(56);
		Projectile val2 = Object.Instantiate<Projectile>(((Gun)((byId2 is Gun) ? byId2 : null)).DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		swirlyProj = val2;
		Projectile val3 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val3).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val3).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val3);
		val.DefaultModule.projectiles[0] = val3;
		ProjectileData baseData = val3.baseData;
		baseData.damage *= 5f;
		ProjectileData baseData2 = val3.baseData;
		baseData2.speed *= 0.1f;
		val3.pierceMinorBreakables = true;
		SpiralHandler spiralHandler = ((Component)val3).gameObject.AddComponent<SpiralHandler>();
		spiralHandler.projectileToSpawn = swirlyProj;
		val3.SetProjectileSprite("spiral_projectile", 15, 15, lightened: true, (Anchor)4, 14, 14, anchorChangesCollider: true, fixesScale: false, null, null);
		((BraveBehaviour)val3).transform.parent = val.barrelOffset;
		((PickupObject)val).quality = (ItemQuality)4;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)2, 1f);
		SpiralID = ((PickupObject)val).PickupObjectId;
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.PURCHASED_SPIRAL, requiredFlagValue: true);
	}
}
