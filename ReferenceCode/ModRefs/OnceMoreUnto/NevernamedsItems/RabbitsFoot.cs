using System;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class RabbitsFoot : PassiveItem
{
	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<RabbitsFoot>("Rabbits Foot", "Feels Lucky", "Imparts a strange luck upon your weapon.\n\nMany veteran gunslingers keep good luck charms such as this. Other notable good luck charms include coins, socks, underwear, and smell.", "rabbitsfoot_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)3;
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)val, (StatType)4, 1f, (ModifyMethod)0);
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)2, 1f);
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.RAT_KILLED_BULLET, requiredFlagValue: true);
		AlexandriaTags.SetTag((PickupObject)(object)val, "lucky");
	}

	public override void Pickup(PlayerController player)
	{
		player.PostProcessProjectile += OnShoot;
		OMITBActions.ModifyChanceScalar = (OMITBActions.ChSclModify)Delegate.Combine(OMITBActions.ModifyChanceScalar, new OMITBActions.ChSclModify(ModifyChanceScalar));
		((PassiveItem)this).Pickup(player);
	}

	public override void DisableEffect(PlayerController player)
	{
		if (Object.op_Implicit((Object)(object)player))
		{
			player.PostProcessProjectile -= OnShoot;
		}
		OMITBActions.ModifyChanceScalar = (OMITBActions.ChSclModify)Delegate.Remove(OMITBActions.ModifyChanceScalar, new OMITBActions.ChSclModify(ModifyChanceScalar));
		((PassiveItem)this).DisableEffect(player);
	}

	public void ModifyChanceScalar(ref float scalar, PlayerController player)
	{
		if ((Object)(object)player == (Object)(object)((PassiveItem)this).Owner)
		{
			scalar *= 2f;
		}
	}

	public void OnShoot(Projectile bullet, float f)
	{
		if (!Object.op_Implicit((Object)(object)bullet) || !Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(bullet)))
		{
			return;
		}
		if ((Object)(object)((Component)bullet).GetComponent<HomingModifier>() != (Object)null)
		{
			HomingModifier component = ((Component)bullet).GetComponent<HomingModifier>();
			component.HomingRadius *= 2f;
			component.AngularVelocity *= 2f;
		}
		if ((Object)(object)((Component)bullet).GetComponent<SpawnProjModifier>() != (Object)null)
		{
			SpawnProjModifier component2 = ((Component)bullet).GetComponent<SpawnProjModifier>();
			if (component2.spawnProjectilesInFlight)
			{
				component2.inFlightSpawnCooldown *= 0.5f;
			}
			if (component2.spawnProjectilesOnCollision)
			{
				component2.numberToSpawnOnCollison *= 2;
			}
		}
		if ((Object)(object)((Component)bullet).GetComponent<PierceProjModifier>() != (Object)null)
		{
			PierceProjModifier component3 = ((Component)bullet).GetComponent<PierceProjModifier>();
			component3.penetratesBreakables = true;
			component3.penetration *= 2;
		}
	}
}
