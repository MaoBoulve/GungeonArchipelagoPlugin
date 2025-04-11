using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class SporeLauncher : AdvancedGunBehavior
{
	public static int SporeLauncherID;

	public static void Add()
	{
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_0254: Unknown result type (might be due to invalid IL or missing references)
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Spore Launcher", "sporelauncher");
		Game.Items.Rename("outdated_gun_mods:spore_launcher", "nn:spore_launcher");
		((Component)val).gameObject.AddComponent<SporeLauncher>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Ain't He Cute?");
		GunExt.SetLongDescription((PickupObject)(object)val, "An infant alien from another dimension. Capable of storing potent spores in it's digestive tract in order to regurgitate them for self defense.\n\nEnjoys headpats, belly rubs, and those little fish-shaped cracker things.");
		val.SetGunSprites("sporelauncher");
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(599);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		GunExt.SetAnimationFPS(val, val.shootAnimation, 14);
		GunExt.SetAnimationFPS(val, val.idleAnimation, 5);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 10);
		PickupObject byId2 = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 2.5f;
		val.DefaultModule.cooldownTime = 0.6f;
		val.DefaultModule.numberOfShotsInClip = 10;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.31f, 0.75f, 0f);
		val.SetBaseMaxAmmo(200);
		val.gunClass = (GunClass)15;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		ProjectileData baseData = val2.baseData;
		baseData.speed *= 1f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.damage *= 4f;
		ProjectileData baseData3 = val2.baseData;
		baseData3.range *= 10f;
		BounceProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<BounceProjModifier>(((Component)val2).gameObject);
		orAddComponent.numberOfBounces = 1;
		HomingModifier val3 = ((Component)val2).gameObject.AddComponent<HomingModifier>();
		val3.AngularVelocity = 70f;
		val3.HomingRadius = 100f;
		val2.SetProjectileSprite("sporelauncher_projectile", 10, 10, lightened: false, (Anchor)4, 9, 9, anchorChangesCollider: true, fixesScale: false, null, null);
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("SporeLauncher Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/sporelauncher_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/sporelauncher_clipempty");
		((PickupObject)val).quality = (ItemQuality)3;
		((BraveBehaviour)val).encounterTrackable.EncounterGuid = "this is the Spore Launcher";
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		SporeLauncherID = ((PickupObject)val).PickupObjectId;
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.PURCHASED_SPORELAUNCHER, requiredFlagValue: true);
		((PickupObject)(object)val).AddItemToGooptonMetaShop(20, null);
		AlexandriaTags.SetTag((PickupObject)(object)val, "non_companion_living_item");
	}

	public override void OnPostFired(PlayerController player, Gun gun)
	{
		if (CustomSynergies.PlayerHasActiveSynergy(player, "Enspore!"))
		{
			int pickupObjectId = Game.Items["nn:fungo_cannon"].PickupObjectId;
			if (player.HasPickupID(pickupObjectId) && (double)Random.value <= 0.45)
			{
				PlayerUtility.GiveAmmoToGunNotInHand(player, pickupObjectId, 1);
			}
		}
		((AdvancedGunBehavior)this).OnPostFired(player, gun);
	}
}
