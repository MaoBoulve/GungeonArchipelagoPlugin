using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class ReShelletonKeyter : GunBehaviour
{
	public static int ReShelletonKeyterID;

	public static void Add()
	{
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("ReShelletonKeyter", "rekeytershelletonforme");
		Game.Items.Rename("outdated_gun_mods:reshelletonkeyter", "nn:reshelletonkeyter");
		((Component)val).gameObject.AddComponent<ReShelletonKeyter>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Click");
		GunExt.SetLongDescription((PickupObject)(object)val, "Skull lookin ass");
		val.SetGunSprites("rekeytershelletonforme", 8, noAmmonomicon: true);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(95);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		GunExt.SetAnimationFPS(val, val.shootAnimation, 15);
		PickupObject byId2 = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)4;
		val.DefaultModule.burstShotCount = 3;
		val.DefaultModule.burstCooldownTime = 0.11f;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.InfiniteAmmo = true;
		val.DefaultModule.cooldownTime = 0.5f;
		val.DefaultModule.numberOfShotsInClip = 15;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.93f, 0.81f, 0f);
		val.SetBaseMaxAmmo(200);
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
		GunTools.SetProjectileSpriteRight(val2, "rekeytershelletonforme_projectile", 17, 7, false, (Anchor)4, (int?)17, (int?)6, true, false, (int?)null, (int?)null, (Projectile)null);
		((PickupObject)val).quality = (ItemQuality)(-100);
		((BraveBehaviour)val).encounterTrackable.EncounterGuid = "this is the ReShelletonKeyter";
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		GunExt.SetName((PickupObject)(object)val, "Rekeyter");
		ReShelletonKeyterID = ((PickupObject)val).PickupObjectId;
	}
}
