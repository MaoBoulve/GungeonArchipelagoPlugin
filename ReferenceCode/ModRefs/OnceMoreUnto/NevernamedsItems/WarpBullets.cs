using System;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class WarpBullets : PassiveItem
{
	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<WarpBullets>("Warp Bullets", "Bullets Teleport", "Your bullets have a chance to teleport behind enemies.", "warpbullets_icon", assetbundle: true);
		val.quality = (ItemQuality)2;
		AlexandriaTags.SetTag(val, "bullet_modifier");
		Doug.AddToLootPool(val.PickupObjectId);
	}

	private void PostProcessProjectile(Projectile sourceProjectile, float effectChanceScalar)
	{
		if (!Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			return;
		}
		float num = 0.2f;
		if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Corrupted By Warp"))
		{
			num *= effectChanceScalar;
		}
		try
		{
			if (!(Random.value <= num))
			{
				return;
			}
			GameObject bulletObject = ((BraveBehaviour)EnemyDatabase.GetOrLoadByGuid("56fb939a434140308b8f257f0f447829")).bulletBank.GetBullet("rogue").BulletObject;
			Projectile component = bulletObject.GetComponent<Projectile>();
			if ((Object)(object)component != (Object)null)
			{
				TeleportProjModifier component2 = ((Component)component).GetComponent<TeleportProjModifier>();
				if ((Object)(object)component2 != (Object)null)
				{
					PlayerProjectileTeleportModifier playerProjectileTeleportModifier = ((Component)sourceProjectile).gameObject.AddComponent<PlayerProjectileTeleportModifier>();
					playerProjectileTeleportModifier.teleportVfx = component2.teleportVfx;
					playerProjectileTeleportModifier.teleportCooldown = component2.teleportCooldown;
					playerProjectileTeleportModifier.teleportPauseTime = component2.teleportPauseTime;
					playerProjectileTeleportModifier.trigger = PlayerProjectileTeleportModifier.TeleportTrigger.DistanceFromTarget;
					playerProjectileTeleportModifier.distToTeleport = component2.distToTeleport * 2f;
					playerProjectileTeleportModifier.behindTargetDistance = (component2.behindTargetDistance *= 0.9f);
					playerProjectileTeleportModifier.leadAmount = component2.leadAmount;
					playerProjectileTeleportModifier.minAngleToTeleport = component2.minAngleToTeleport;
					playerProjectileTeleportModifier.numTeleports = 2;
					playerProjectileTeleportModifier.type = PlayerProjectileTeleportModifier.TeleportType.BehindTarget;
				}
			}
		}
		catch (Exception ex)
		{
			ETGModConsole.Log((object)ex.Message, false);
		}
	}

	public override DebrisObject Drop(PlayerController player)
	{
		DebrisObject result = ((PassiveItem)this).Drop(player);
		player.PostProcessProjectile -= PostProcessProjectile;
		return result;
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		player.PostProcessProjectile += PostProcessProjectile;
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			((PassiveItem)this).Owner.PostProcessProjectile -= PostProcessProjectile;
		}
		((PassiveItem)this).OnDestroy();
	}
}
