using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Gungeon;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class GunOfAThousandSins : AdvancedGunBehavior
{
	public static int GunOfAThousandSinsID;

	public static void Add()
	{
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_022d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0268: Unknown result type (might be due to invalid IL or missing references)
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_030f: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Gun of a Thousand Sins", "gunofathousandsins");
		Game.Items.Rename("outdated_gun_mods:gun_of_a_thousand_sins", "nn:gun_of_a_thousand_sins");
		((Component)val).gameObject.AddComponent<GunOfAThousandSins>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Evisceration");
		GunExt.SetLongDescription((PickupObject)(object)val, "This sidearm was once carried by an accursed sorcerer who put countless innocents to death in order to secure his grab at penultimate power.");
		GunInt.SetupSprite(val, Initialisation.gunCollection, "gunofathousandsins_idle_001", 8, "gunofathousandsins_ammonomicon_001");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(198);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)val, (StatType)14, 1f, (ModifyMethod)0);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(83);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		val.DefaultModule.cooldownTime = 0.11f;
		val.DefaultModule.numberOfShotsInClip = 7;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.37f, 0.81f, 0f);
		val.SetBaseMaxAmmo(200);
		val.ammo = 200;
		val.gunClass = (GunClass)1;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		val2.baseData.damage = 20f;
		ProjectileData baseData = val2.baseData;
		baseData.speed *= 1f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.range *= 2f;
		PierceProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<PierceProjModifier>(((Component)val2).gameObject);
		ThousandSinsProjectileModifier orAddComponent2 = GameObjectExtensions.GetOrAddComponent<ThousandSinsProjectileModifier>(((Component)val2).gameObject);
		val2.hitEffects.alwaysUseMidair = true;
		val2.hitEffects.overrideMidairDeathVFX = SharedVFX.BloodiedScarfPoofVFX;
		ProjectileBuilders.AnimateProjectileBundle(val2, "GunOfAThousandSinsProjectile", Initialisation.ProjectileCollection, Initialisation.projectileAnimationCollection, "GunOfAThousandSinsProjectile", MiscTools.DupeList<IntVector2>(new IntVector2(23, 22), 4), MiscTools.DupeList(value: true, 4), MiscTools.DupeList<Anchor>((Anchor)4, 4), MiscTools.DupeList(value: true, 4), MiscTools.DupeList(value: false, 4), MiscTools.DupeList<Vector3?>(null, 4), MiscTools.DupeList((IntVector2?)new IntVector2(20, 11), 4), MiscTools.DupeList((IntVector2?)new IntVector2(2, 5), 4), MiscTools.DupeList<Projectile>(null, 4));
		val2.SetProjectileSprite("gunofathousandsins_projectile_001", 23, 22, lightened: true, (Anchor)4, 20, 11, anchorChangesCollider: true, fixesScale: false, null, null);
		((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Thousand Sins Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/thousandsins_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/thousandsins_clipempty");
		((PickupObject)val).quality = (ItemQuality)5;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		GunOfAThousandSinsID = ((PickupObject)val).PickupObjectId;
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.ALLJAMMED_BEATEN_HELL, requiredFlagValue: true);
	}
}
