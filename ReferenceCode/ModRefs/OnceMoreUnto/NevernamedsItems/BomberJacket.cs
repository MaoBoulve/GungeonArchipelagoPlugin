using System;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class BomberJacket : PlayerItem
{
	public static int ID;

	private ExplosionData smallPlayerSafeExplosion = new ExplosionData
	{
		damageRadius = 2.5f,
		damageToPlayer = 0f,
		doDamage = true,
		damage = 25f,
		doDestroyProjectiles = true,
		doForce = true,
		debrisForce = 30f,
		preventPlayerForce = true,
		explosionDelay = 0.1f,
		usesComprehensiveDelay = false,
		doScreenShake = true,
		playDefaultSFX = true
	};

	private ExplosionData bigPlayerSafeExplosion = new ExplosionData
	{
		damageRadius = 4f,
		damageToPlayer = 0f,
		doDamage = true,
		damage = 50f,
		doDestroyProjectiles = true,
		doForce = true,
		debrisForce = 60f,
		preventPlayerForce = true,
		explosionDelay = 0.1f,
		usesComprehensiveDelay = false,
		doScreenShake = true,
		playDefaultSFX = true
	};

	public static void Init()
	{
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<BomberJacket>("Bomber Jacket", "Kamakablooey", "Use to create an explosion around yourself.\n\nBrought to the Gungeon by a rather unscrupulous individual, it has since been modified to be safe to the user, and been renamed so it can be shown on the internet without losing one's entire career.", "bomberjacket_improved", assetbundle: true);
		PlayerItem val = (PlayerItem)(object)((obj is PlayerItem) ? obj : null);
		val.usableDuringDodgeRoll = true;
		ItemBuilder.SetCooldownType(val, (CooldownType)1, 120f);
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)val, (StatType)8, 2f, (ModifyMethod)0);
		val.consumable = false;
		((PickupObject)val).quality = (ItemQuality)1;
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)3, 1f);
		ID = ((PickupObject)val).PickupObjectId;
	}

	public override void DoEffect(PlayerController user)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		DoSafeExplosion(Vector2.op_Implicit(((BraveBehaviour)user).specRigidbody.UnitCenter));
	}

	public void DoSafeExplosion(Vector3 position)
	{
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		if (base.LastOwner.HasPickupID(332))
		{
			ExplosionData defaultExplosionData = GameManager.Instance.Dungeon.sharedSettingsPrefab.DefaultExplosionData;
			bigPlayerSafeExplosion.effect = defaultExplosionData.effect;
			bigPlayerSafeExplosion.ignoreList = defaultExplosionData.ignoreList;
			bigPlayerSafeExplosion.ss = defaultExplosionData.ss;
			Exploder.Explode(position, bigPlayerSafeExplosion, Vector2.zero, (Action)null, false, (CoreDamageTypes)0, false);
		}
		else
		{
			ExplosionData defaultSmallExplosionData = GameManager.Instance.Dungeon.sharedSettingsPrefab.DefaultSmallExplosionData;
			smallPlayerSafeExplosion.effect = defaultSmallExplosionData.effect;
			smallPlayerSafeExplosion.ignoreList = defaultSmallExplosionData.ignoreList;
			smallPlayerSafeExplosion.ss = defaultSmallExplosionData.ss;
			Exploder.Explode(position, smallPlayerSafeExplosion, Vector2.zero, (Action)null, false, (CoreDamageTypes)0, false);
		}
	}
}
