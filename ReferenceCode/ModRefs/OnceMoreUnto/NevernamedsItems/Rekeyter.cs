using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Rekeyter : GunBehaviour
{
	public static int RekeyterID;

	public static void Add()
	{
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_024c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0272: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Rekeyter", "rekeyter");
		Game.Items.Rename("outdated_gun_mods:rekeyter", "nn:rekeyter");
		((Component)val).gameObject.AddComponent<Rekeyter>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Click");
		GunExt.SetLongDescription((PickupObject)(object)val, "A key clumsily fused to a grip and trigger. Low chance to open chests.\n\nHidden sidearm of the infamous criminal Locke Smith.");
		GunInt.SetupSprite(val, Initialisation.gunCollection, "rekeyter_idle_001", 8, "rekeyter_ammonomicon_001");
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(95);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		GunExt.SetAnimationFPS(val, val.shootAnimation, 15);
		PickupObject byId2 = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)4;
		val.DefaultModule.burstShotCount = 2;
		val.DefaultModule.burstCooldownTime = 0.11f;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 0.5f;
		val.DefaultModule.numberOfShotsInClip = 10;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.93f, 0.81f, 0f);
		val.SetBaseMaxAmmo(200);
		val.gunClass = (GunClass)1;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 1.6f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.range *= 1f;
		((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		KeyBulletBehaviour orAddComponent = GameObjectExtensions.GetOrAddComponent<KeyBulletBehaviour>(((Component)val2).gameObject);
		orAddComponent.useSpecialTint = false;
		orAddComponent.procChance = 0.1f;
		ScaleProjectileStatOffConsumableCount orAddComponent2 = GameObjectExtensions.GetOrAddComponent<ScaleProjectileStatOffConsumableCount>(((Component)val2).gameObject);
		orAddComponent2.multiplierPerLevelOfStat = 0.1f;
		orAddComponent2.projstat = ScaleProjectileStatOffConsumableCount.ProjectileStatType.DAMAGE;
		orAddComponent2.consumableType = ScaleProjectileStatOffConsumableCount.ConsumableType.KEYS;
		val2.SetProjectileSprite("rekeyter_projectile", 17, 7, lightened: false, (Anchor)4, 17, 6, anchorChangesCollider: true, fixesScale: false, null, null);
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Rekeyter Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/rekeyter_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/rekeyter_clipempty");
		((PickupObject)val).quality = (ItemQuality)3;
		((BraveBehaviour)val).encounterTrackable.EncounterGuid = "this is the Rekeyter";
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)1, 1f);
		RekeyterID = ((PickupObject)val).PickupObjectId;
	}

	public override void Update()
	{
		if (Object.op_Implicit((Object)(object)base.gun) && Object.op_Implicit((Object)(object)GunTools.GunPlayerOwner(base.gun)))
		{
			PlayerController val = GunTools.GunPlayerOwner(base.gun);
			if (CustomSynergies.PlayerHasActiveSynergy(val, "ReShelletonKeyter") && !base.gun.InfiniteAmmo)
			{
				base.gun.InfiniteAmmo = true;
			}
			else if (!CustomSynergies.PlayerHasActiveSynergy(val, "ReShelletonKeyter") && base.gun.InfiniteAmmo)
			{
				base.gun.InfiniteAmmo = false;
			}
		}
	}
}
