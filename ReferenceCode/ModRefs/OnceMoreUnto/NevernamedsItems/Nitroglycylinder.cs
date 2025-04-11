using System;
using System.Collections.Generic;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Nitroglycylinder : PassiveItem
{
	public static int NitroglycylinderID;

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
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<Nitroglycylinder>("Nitroglycylinder", "Reloader 'sploder", "Explodes safely (for you at least) upon reloading.\n\nThis attatchment was favoured by a masochistic gungeoneer who liked the smell of burnt hair just a little too much. After his inevitable death, it was modified to not actually hurt it's bearer.", "nitroglycylinder_improved", assetbundle: true);
		val.quality = (ItemQuality)1;
		ItemBuilder.AddToSubShop(val, (ShopType)3, 1f);
		List<string> list = new List<string> { "nn:nitroglycylinder" };
		List<string> list2 = new List<string> { "nn:nitro_bullets", "explosive_rounds" };
		CustomSynergies.Add("Bomb Voyage!", list, list2, true);
		List<string> list3 = new List<string> { "nn:nitro_bullets" };
		List<string> list4 = new List<string> { "nn:nitroglycylinder", "explosive_rounds" };
		CustomSynergies.Add("...Badda Boom!", list3, list4, true);
		NitroglycylinderID = val.PickupObjectId;
	}

	private void HandleGunReloaded(PlayerController player, Gun playerGun)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		DoSafeExplosion(Vector2.op_Implicit(((BraveBehaviour)((PassiveItem)this).Owner).specRigidbody.UnitCenter));
	}

	public void DoSafeExplosion(Vector3 position)
	{
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		if (((PassiveItem)this).Owner.HasPickupID(304) || ((PassiveItem)this).Owner.HasPickupID(Game.Items["nn:nitro_bullets"].PickupObjectId))
		{
			ExplosionData defaultSmallExplosionData = GameManager.Instance.Dungeon.sharedSettingsPrefab.DefaultSmallExplosionData;
			bigPlayerSafeExplosion.effect = defaultSmallExplosionData.effect;
			bigPlayerSafeExplosion.ignoreList = defaultSmallExplosionData.ignoreList;
			bigPlayerSafeExplosion.ss = defaultSmallExplosionData.ss;
			Exploder.Explode(position, bigPlayerSafeExplosion, Vector2.zero, (Action)null, false, (CoreDamageTypes)0, false);
		}
		else
		{
			ExplosionData defaultSmallExplosionData2 = GameManager.Instance.Dungeon.sharedSettingsPrefab.DefaultSmallExplosionData;
			smallPlayerSafeExplosion.effect = defaultSmallExplosionData2.effect;
			smallPlayerSafeExplosion.ignoreList = defaultSmallExplosionData2.ignoreList;
			smallPlayerSafeExplosion.ss = defaultSmallExplosionData2.ss;
			Exploder.Explode(position, smallPlayerSafeExplosion, Vector2.zero, (Action)null, false, (CoreDamageTypes)0, false);
		}
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		player.OnReloadedGun = (Action<PlayerController, Gun>)Delegate.Combine(player.OnReloadedGun, new Action<PlayerController, Gun>(HandleGunReloaded));
	}

	public override DebrisObject Drop(PlayerController player)
	{
		DebrisObject result = ((PassiveItem)this).Drop(player);
		player.OnReloadedGun = (Action<PlayerController, Gun>)Delegate.Remove(player.OnReloadedGun, new Action<PlayerController, Gun>(HandleGunReloaded));
		return result;
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			PlayerController owner = ((PassiveItem)this).Owner;
			owner.OnReloadedGun = (Action<PlayerController, Gun>)Delegate.Remove(owner.OnReloadedGun, new Action<PlayerController, Gun>(HandleGunReloaded));
		}
		((PassiveItem)this).OnDestroy();
	}
}
