using Alexandria.ItemAPI;
using Gungeon;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class RiotGun : AdvancedGunBehavior
{
	public static int RiotGunID;

	public static void Add()
	{
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		//IL_0268: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Riot Gun", "riotgun");
		Game.Items.Rename("outdated_gun_mods:riot_gun", "nn:riot_gun");
		((Component)val).gameObject.AddComponent<RiotGun>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Definitely Humane");
		GunExt.SetLongDescription((PickupObject)(object)val, "Fires elastic rubber bullets.\n\nWhile rubber bullets are generally considered non-lethal, a more accurate term would be 'less-lethal'.\nThese bullets can still cause damage.");
		val.SetGunSprites("riotgun");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 1);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(150);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 0.5f;
		val.DefaultModule.numberOfShotsInClip = 5;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.06f, 0.75f, 0f);
		val.SetBaseMaxAmmo(200);
		val.gunClass = (GunClass)15;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		val2.baseData.damage = 7f;
		ProjectileData baseData = val2.baseData;
		baseData.force *= 5f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.speed *= 1f;
		ProjectileData baseData3 = val2.baseData;
		baseData3.range *= 1f;
		BounceProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<BounceProjModifier>(((Component)val2).gameObject);
		orAddComponent.numberOfBounces = 1;
		val2.AppliesStun = true;
		val2.StunApplyChance = 0.2f;
		val2.AppliedStunDuration = 2f;
		val2.SetProjectileSprite("riotgun_projectile", 12, 12, lightened: true, (Anchor)4, 10, 10, anchorChangesCollider: true, fixesScale: false, null, null);
		val2.pierceMinorBreakables = true;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("RiotGun Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/riotgun_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/riotgun_clipempty");
		((PickupObject)val).quality = (ItemQuality)1;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)3, 1f);
		RiotGunID = ((PickupObject)val).PickupObjectId;
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.PURCHASED_RIOTGUN, requiredFlagValue: true);
		((PickupObject)(object)val).AddItemToTrorcMetaShop(10, null);
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		GameActor owner = projectile.Owner;
		PlayerController val = (PlayerController)(object)((owner is PlayerController) ? owner : null);
		if (Object.op_Implicit((Object)(object)val) && CustomSynergies.PlayerHasActiveSynergy(val, "Crowd Supression"))
		{
			AreaFearBulletModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<AreaFearBulletModifier>(((Component)projectile).gameObject);
			orAddComponent.effectRadius = 3f;
			orAddComponent.fearStartDistance = 3f;
			orAddComponent.fearStopDistance = 7f;
			orAddComponent.fearLength = 2f;
			orAddComponent.procChance = 1f;
			orAddComponent.useSpecialTint = false;
		}
		((AdvancedGunBehavior)this).PostProcessProjectile(projectile);
	}
}
