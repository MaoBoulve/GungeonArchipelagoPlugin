using Alexandria.ItemAPI;
using Gungeon;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class Corgun : AdvancedGunBehavior
{
	public static int DoggunID;

	public static void Add()
	{
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_028c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b2: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Doggun", "corgun");
		Game.Items.Rename("outdated_gun_mods:doggun", "nn:doggun");
		Corgun corgun = ((Component)val).gameObject.AddComponent<Corgun>();
		((AdvancedGunBehavior)corgun).preventNormalFireAudio = true;
		((AdvancedGunBehavior)corgun).preventNormalReloadAudio = true;
		((AdvancedGunBehavior)corgun).overrideNormalFireAudio = "Play_PET_dog_bark_02";
		((AdvancedGunBehavior)corgun).overrideNormalReloadAudio = "Play_PET_dog_bark_02";
		GunExt.SetShortDescription((PickupObject)(object)val, "Bork Bork");
		GunExt.SetLongDescription((PickupObject)(object)val, "Lovingly carved in the image of Junior II, this gun has some fighting spirit, despite it's cuddly appearance.\n\n'Bork Bork' - Junior II");
		val.SetGunSprites("corgun");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(519);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 0.8f;
		val.DefaultModule.cooldownTime = 0.4f;
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		val.DefaultModule.numberOfShotsInClip = 5;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(0.5f, 0.56f, 0f);
		val.SetBaseMaxAmmo(200);
		val.gunClass = (GunClass)50;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 1.6f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.speed *= 1f;
		ProjectileData baseData3 = val2.baseData;
		baseData3.range *= 10f;
		val2.pierceMinorBreakables = true;
		PierceProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<PierceProjModifier>(((Component)val2).gameObject);
		orAddComponent.penetratesBreakables = true;
		orAddComponent.penetration = 5;
		BounceProjModifier orAddComponent2 = GameObjectExtensions.GetOrAddComponent<BounceProjModifier>(((Component)val2).gameObject);
		orAddComponent2.numberOfBounces = 5;
		HomingModifier val3 = ((Component)val2).gameObject.AddComponent<HomingModifier>();
		val3.AngularVelocity = 70f;
		val3.HomingRadius = 100f;
		val2.SetProjectileSprite("doggun_projectile", 16, 11, lightened: false, (Anchor)4, 15, 10, anchorChangesCollider: true, fixesScale: false, null, null);
		((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Doggun Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/doggun_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/doggun_clipempty");
		((PickupObject)val).quality = (ItemQuality)4;
		((BraveBehaviour)val).encounterTrackable.EncounterGuid = "this is the Doggun";
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		DoggunID = ((PickupObject)val).PickupObjectId;
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.DRAGUN_KILLED_HUNTER, requiredFlagValue: true);
	}
}
