using Alexandria.ItemAPI;
using Gungeon;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class Beastclaw : AdvancedGunBehavior
{
	public static int BeastclawID;

	public static void Add()
	{
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_0213: Unknown result type (might be due to invalid IL or missing references)
		//IL_0239: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Beastclaw", "beastclaw");
		Game.Items.Rename("outdated_gun_mods:beastclaw", "nn:beastclaw");
		((Component)val).gameObject.AddComponent<Beastclaw>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Out of Place");
		GunExt.SetLongDescription((PickupObject)(object)val, "The weaponised claw of a mighty Misfire Beast.\n\nRumour has it that infamous big game hunter Emmitt Calx had one of the beasts as a tame pet and lap cat.");
		val.SetGunSprites("beastclaw");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 1);
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 0.05f;
		val.DefaultModule.angleVariance = 20f;
		val.DefaultModule.numberOfShotsInClip = 100;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(0.93f, 0.37f, 0f);
		val.SetBaseMaxAmmo(1500);
		val.ammo = 1500;
		val.gunClass = (GunClass)50;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 0.8f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.speed *= 1f;
		ProjectileData baseData3 = val2.baseData;
		baseData3.range *= 1f;
		val2.SetProjectileSprite("enemystyle_projectile", 10, 10, lightened: true, (Anchor)4, 8, 8, anchorChangesCollider: true, fixesScale: false, null, null);
		InstantTeleportToPlayerCursorBehav orAddComponent = GameObjectExtensions.GetOrAddComponent<InstantTeleportToPlayerCursorBehav>(((Component)val2).gameObject);
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Beastclaw Ammo", "NevernamedsItems/Resources/CustomGunAmmoTypes/beastclaw_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/beastclaw_clipempty");
		((PickupObject)val).quality = (ItemQuality)4;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)2, 1f);
		BeastclawID = ((PickupObject)val).PickupObjectId;
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.MISFIREBEAST_QUEST_REWARDED, requiredFlagValue: true);
	}
}
