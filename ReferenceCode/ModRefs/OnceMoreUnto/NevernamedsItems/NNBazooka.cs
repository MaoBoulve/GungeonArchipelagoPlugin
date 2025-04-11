using Alexandria.ItemAPI;
using Gungeon;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class NNBazooka : GunBehaviour
{
	public static int BazookaID;

	public static void Add()
	{
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Bazooka", "bazooka");
		Game.Items.Rename("outdated_gun_mods:bazooka", "nn:bazooka");
		((Component)val).gameObject.AddComponent<NNBazooka>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Boom Boom Boom Boom");
		GunExt.SetLongDescription((PickupObject)(object)val, "It takes a lunatic to be a legend.\n\nThis powerful explosive weapon has one major drawback; it is capable of damaging it's bearer. You'd think more bombs would do that, but the Gungeon forgives.");
		val.SetGunSprites("bazooka");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		PickupObject byId = PickupObjectDatabase.GetById(39);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 4f;
		val.DefaultModule.cooldownTime = 2f;
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		val.DefaultModule.numberOfShotsInClip = 3;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.5f, 0.68f, 0f);
		val.SetBaseMaxAmmo(100);
		val.gunClass = (GunClass)45;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 3f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.speed *= 1.2f;
		val2.ignoreDamageCaps = true;
		val2.pierceMinorBreakables = true;
		if (Object.op_Implicit((Object)(object)((Component)val2).GetComponent<ExplosiveModifier>()))
		{
			Object.Destroy((Object)(object)((Component)val2).GetComponent<ExplosiveModifier>());
		}
		FuckingExplodeYouCunt fuckingExplodeYouCunt = ((Component)val2).gameObject.AddComponent<FuckingExplodeYouCunt>();
		GunTools.SetProjectileSpriteRight(val2, "bazooka_projectile", 26, 7, false, (Anchor)4, (int?)26, (int?)7, true, false, (int?)null, (int?)null, (Projectile)null);
		((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		((PickupObject)val).quality = (ItemQuality)3;
		((BraveBehaviour)val).encounterTrackable.EncounterGuid = "this is the Bazooka";
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)3, 1f);
		BazookaID = ((PickupObject)val).PickupObjectId;
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.PURCHASED_BAZOOKA, requiredFlagValue: true);
		((PickupObject)(object)val).AddItemToTrorcMetaShop(20, null);
	}

	public override void OnPostFired(PlayerController player, Gun gun)
	{
	}
}
