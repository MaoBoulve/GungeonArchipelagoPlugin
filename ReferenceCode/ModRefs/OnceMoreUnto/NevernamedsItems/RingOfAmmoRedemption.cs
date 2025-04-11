using System;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class RingOfAmmoRedemption : PassiveItem
{
	public static int RingOfAmmoRedemptionID;

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<RingOfAmmoRedemption>("Ring of Ammo Redemption", "Thrown Guns Reload", "Killing an enemy with a thrown gun restores 10% of that gun's ammo.\n\nThis ring once belonged to Peale-4, an infamously loot-oriented Gungeoneer.\nHis ring is so hungry for loot that it encourages your guns to steal ammo directly from the dead.", "ringofammoredemption_icon", assetbundle: true);
		val.quality = (ItemQuality)1;
		RingOfAmmoRedemptionID = val.PickupObjectId;
	}

	private void PostProcessThrownGun(Projectile thrownGunProjectile)
	{
		thrownGunProjectile.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(thrownGunProjectile.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(RestoreAmmo));
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		player.PostProcessThrownGun += PostProcessThrownGun;
	}

	private void RestoreAmmo(Projectile arg1, SpeculativeRigidbody arg2, bool arg3)
	{
		if (arg3)
		{
			float num = 0.1f;
			GameActor owner = arg1.Owner;
			if (CustomSynergies.PlayerHasActiveSynergy((PlayerController)(object)((owner is PlayerController) ? owner : null), "Ammo Economy Inflation"))
			{
				num = 0.2f;
			}
			Gun componentInChildren = ((Component)arg1).GetComponentInChildren<Gun>();
			if (Object.op_Implicit((Object)(object)componentInChildren))
			{
				componentInChildren.GainAmmo(Mathf.FloorToInt((float)componentInChildren.AdjustedMaxAmmo * num));
			}
		}
	}

	public override DebrisObject Drop(PlayerController player)
	{
		player.PostProcessThrownGun -= PostProcessThrownGun;
		return ((PassiveItem)this).Drop(player);
	}

	public override void OnDestroy()
	{
		if ((Object)(object)((PassiveItem)this).Owner != (Object)null)
		{
			((PassiveItem)this).Owner.PostProcessThrownGun -= PostProcessThrownGun;
		}
		((PassiveItem)this).OnDestroy();
	}
}
