using System;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class BlackHolster : PassiveItem
{
	public static void Init()
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<BlackHolster>("Black Holster", "Unload", "Chance to unholster the full power of the void upon reloading.\n\nOnce sat on the hip of a gunslinger that was neither man nor beast, nor even flesh, but given form by the void itself.", "blackholster_icon", assetbundle: true);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)14, 1f, (ModifyMethod)0);
		val.quality = (ItemQuality)4;
	}

	private void HandleGunReloaded(PlayerController player, Gun playerGun)
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		if (playerGun.ClipShotsRemaining == 0 && Random.value > 0.85f)
		{
			Projectile val = ((Gun)Databases.Items["black_hole_gun"]).DefaultModule.projectiles[0];
			GameObject val2 = SpawnManager.SpawnProjectile(((Component)val).gameObject, Vector2.op_Implicit(((BraveBehaviour)((PassiveItem)this).Owner).sprite.WorldCenter), Quaternion.Euler(0f, 0f, ((Object)(object)((GameActor)((PassiveItem)this).Owner).CurrentGun == (Object)null) ? 0f : ((GameActor)((PassiveItem)this).Owner).CurrentGun.CurrentAngle), true);
			Projectile component = val2.GetComponent<Projectile>();
			if ((Object)(object)component != (Object)null)
			{
				component.Owner = (GameActor)(object)((PassiveItem)this).Owner;
				component.Shooter = ((BraveBehaviour)((PassiveItem)this).Owner).specRigidbody;
				component.baseData.speed = 5f;
				component.baseData.damage = 3f;
			}
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
