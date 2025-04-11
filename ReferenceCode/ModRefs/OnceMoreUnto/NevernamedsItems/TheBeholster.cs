using System;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class TheBeholster : PassiveItem
{
	public bool canActivate = true;

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<TheBeholster>("The Beholster", "CreEyetion", "Summons disgusting Beholsterspawn upon reloading an empty clip.\n\nThe infamous holster of the... Beholster.\nSome of these names sound strange when used in a sentence.", "thebeholster_icon", assetbundle: true);
		val.quality = (ItemQuality)3;
		val.SetupUnlockOnCustomStat(CustomTrackedStats.BEHOLSTER_KILLS, 14f, (PrerequisiteOperation)2);
	}

	private void HandleGunReloaded(PlayerController player, Gun playerGun)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		if (playerGun.ClipShotsRemaining != 0 || !canActivate)
		{
			return;
		}
		Projectile finalProjectile = ((Gun)Databases.Items[90]).DefaultModule.finalProjectile;
		GameObject val = SpawnManager.SpawnProjectile(((Component)finalProjectile).gameObject, Vector2.op_Implicit(((BraveBehaviour)((PassiveItem)this).Owner).sprite.WorldCenter), Quaternion.Euler(0f, 0f, ((Object)(object)((GameActor)((PassiveItem)this).Owner).CurrentGun == (Object)null) ? 0f : ((GameActor)((PassiveItem)this).Owner).CurrentGun.CurrentAngle), true);
		Projectile component = val.GetComponent<Projectile>();
		if ((Object)(object)component != (Object)null)
		{
			component.Owner = (GameActor)(object)((PassiveItem)this).Owner;
			component.Shooter = ((BraveBehaviour)((PassiveItem)this).Owner).specRigidbody;
			component.baseData.speed = 1f;
			if (((PassiveItem)this).Owner.HasPickupID(90))
			{
				component.baseData.damage = 24f * player.stats.GetStatValue((StatType)5);
				GameObject val2 = SpawnManager.SpawnProjectile(((Component)finalProjectile).gameObject, Vector2.op_Implicit(((BraveBehaviour)((PassiveItem)this).Owner).sprite.WorldCenter), Quaternion.Euler(0f, 0f, ((Object)(object)((GameActor)((PassiveItem)this).Owner).CurrentGun == (Object)null) ? 0f : ((GameActor)((PassiveItem)this).Owner).CurrentGun.CurrentAngle), true);
				Projectile component2 = val2.GetComponent<Projectile>();
				if ((Object)(object)component2 != (Object)null)
				{
					component2.Owner = (GameActor)(object)((PassiveItem)this).Owner;
					component2.Shooter = ((BraveBehaviour)((PassiveItem)this).Owner).specRigidbody;
					component2.baseData.speed = 1f;
					component2.baseData.damage = 24f * player.stats.GetStatValue((StatType)5);
				}
			}
			else
			{
				component.baseData.damage = 12f * player.stats.GetStatValue((StatType)5);
			}
		}
		canActivate = false;
		((MonoBehaviour)this).Invoke("Reset", 2f);
	}

	private void Reset()
	{
		canActivate = true;
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
