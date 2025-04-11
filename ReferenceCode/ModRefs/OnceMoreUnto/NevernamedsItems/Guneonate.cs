using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Guneonate : AdvancedGunBehavior
{
	public static int GuneonateID;

	public static void Add()
	{
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0274: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ad: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Guneonate", "guneonate");
		Game.Items.Rename("outdated_gun_mods:guneonate", "nn:guneonate");
		Guneonate guneonate = ((Component)val).gameObject.AddComponent<Guneonate>();
		((AdvancedGunBehavior)guneonate).overrideNormalFireAudio = "Play_VO_bashellisk_hiss_01";
		((AdvancedGunBehavior)guneonate).overrideNormalReloadAudio = "Play_BOSS_bashellisk_swallow_01";
		((AdvancedGunBehavior)guneonate).preventNormalFireAudio = true;
		((AdvancedGunBehavior)guneonate).preventNormalReloadAudio = true;
		GunExt.SetShortDescription((PickupObject)(object)val, "Babyconda");
		GunExt.SetLongDescription((PickupObject)(object)val, "A hatchling ammoconda, formed from fresh discarded bullet casings.\n\nIt seems to have self esteem issues.");
		val.SetGunSprites("guneonate");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 10);
		GunExt.SetAnimationFPS(val, val.idleAnimation, 10);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 1);
		PickupObject byId = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 0.45f;
		val.DefaultModule.angleVariance = 0f;
		val.DefaultModule.numberOfShotsInClip = 3;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2f, 0.25f, 0f);
		val.SetBaseMaxAmmo(200);
		val.ammo = 200;
		val.gunClass = (GunClass)50;
		ImprovedHelixProjectile val2 = DataCloners.CopyFields<ImprovedHelixProjectile>(Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]));
		val2.SpawnShadowBulletsOnSpawn = true;
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		ProjectileData baseData = ((Projectile)val2).baseData;
		baseData.damage *= 2f;
		ProjectileData baseData2 = ((Projectile)val2).baseData;
		baseData2.force *= 1f;
		ProjectileData baseData3 = ((Projectile)val2).baseData;
		baseData3.speed *= 0.5f;
		ProjectileData baseData4 = ((Projectile)val2).baseData;
		baseData4.range *= 2f;
		PierceProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<PierceProjModifier>(((Component)val2).gameObject);
		orAddComponent.penetration++;
		orAddComponent.penetratesBreakables = true;
		val2.NumberInChain = 5;
		val2.pauseLength = 0.05f;
		((Projectile)(object)val2).SetProjectileSprite("12x12_yellowenemy_projectile", 12, 12, lightened: true, (Anchor)4, 10, 10, anchorChangesCollider: true, fixesScale: false, null, null);
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Guneonate Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/guneonate_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/guneonate_clipempty");
		val.DefaultModule.projectiles[0] = (Projectile)(object)val2;
		((PickupObject)val).quality = (ItemQuality)5;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		GuneonateID = ((PickupObject)val).PickupObjectId;
	}
}
