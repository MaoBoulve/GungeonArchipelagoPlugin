using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Gungeon;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class StunGun : GunBehaviour
{
	public static int StunGunID;

	public static void Add()
	{
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_020b: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Stun Gun", "stungun");
		Game.Items.Rename("outdated_gun_mods:stun_gun", "nn:stun_gun");
		((Component)val).gameObject.AddComponent<StunGun>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Bro!");
		GunExt.SetLongDescription((PickupObject)(object)val, "Delivers a potent electric shock to it's target.\n\nPopular amongst law enforcement, and as a personal protection sidearm.");
		GunInt.SetupSprite(val, Initialisation.gunCollection, "stungun_idle_001", 8, "stungun_ammonomicon_001");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 15);
		PickupObject byId = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 0.8f;
		val.DefaultModule.cooldownTime = 0.2f;
		val.DefaultModule.numberOfShotsInClip = 5;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1f, 0.56f, 0f);
		val.SetBaseMaxAmmo(300);
		val.gunClass = (GunClass)1;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 0.8f;
		((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		val2.damageTypes = (CoreDamageTypes)(val2.damageTypes | 0x40);
		val2.AppliesStun = true;
		val2.StunApplyChance = 0.75f;
		val2.AppliedStunDuration = 5f;
		GunTools.SetProjectileSpriteRight(val2, "stungun_projectile", 8, 4, false, (Anchor)4, (int?)8, (int?)4, true, false, (int?)null, (int?)null, (Projectile)null);
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("StunGun Ammo", "NevernamedsItems/Resources/CustomGunAmmoTypes/stungun_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/stungun_clipempty");
		((PickupObject)val).quality = (ItemQuality)2;
		((BraveBehaviour)val).encounterTrackable.EncounterGuid = "this is the Stun Gun";
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.PURCHASED_STUNGUN, requiredFlagValue: true);
		StunGunID = ((PickupObject)val).PickupObjectId;
	}
}
