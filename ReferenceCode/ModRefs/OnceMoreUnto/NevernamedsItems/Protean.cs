using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Protean : AdvancedGunBehavior
{
	public static int ProteanID;

	public static void Add()
	{
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_0213: Unknown result type (might be due to invalid IL or missing references)
		//IL_0279: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Protean", "protean");
		Game.Items.Rename("outdated_gun_mods:protean", "nn:protean");
		((Component)val).gameObject.AddComponent<Protean>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Inexplicable");
		GunExt.SetLongDescription((PickupObject)(object)val, "These loosely bound motes of gun floated into existence through a tear in the curtain eons before the Great Bullet struck.\n\nIt's fractal bullets carve hauntingly beautiful patterns in the air, at least for those who can understand them.");
		val.SetGunSprites("protean");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		GunExt.SetAnimationFPS(val, val.idleAnimation, 12);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(479);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 0.8f;
		val.DefaultModule.cooldownTime = 0.4f;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(97);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		val.DefaultModule.numberOfShotsInClip = 6;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.56f, 0.62f, 0f);
		val.SetBaseMaxAmmo(200);
		val.gunClass = (GunClass)1;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 3f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.speed *= 0.7f;
		ProjectileData baseData3 = val2.baseData;
		baseData3.range *= 10f;
		BounceProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<BounceProjModifier>(((Component)val2).gameObject);
		orAddComponent.numberOfBounces = 5;
		RepeatedRandomReAim repeatedRandomReAim = ((Component)val2).gameObject.AddComponent<RepeatedRandomReAim>();
		val2.pierceMinorBreakables = true;
		ProjectileBuilders.AnimateProjectileBundle(val2, "ProteanProjectile", Initialisation.ProjectileCollection, Initialisation.projectileAnimationCollection, "ProteanProjectile", MiscTools.DupeList<IntVector2>(new IntVector2(9, 9), 8), MiscTools.DupeList(value: true, 8), MiscTools.DupeList<Anchor>((Anchor)4, 8), MiscTools.DupeList(value: true, 8), MiscTools.DupeList(value: false, 8), MiscTools.DupeList<Vector3?>(null, 8), MiscTools.DupeList<IntVector2?>(null, 8), MiscTools.DupeList<IntVector2?>(null, 8), MiscTools.DupeList<Projectile>(null, 8));
		((PickupObject)val).quality = (ItemQuality)2;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		ProteanID = ((PickupObject)val).PickupObjectId;
	}
}
