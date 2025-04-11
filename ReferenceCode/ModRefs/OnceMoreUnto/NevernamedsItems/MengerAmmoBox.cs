using System;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class MengerAmmoBox : PassiveItem
{
	public static int MengerAmmoBoxID;

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<MengerAmmoBox>("Menger Ammo Box", "Fractal Replenishment", "Equalises regular and spread ammo boxes.\n\nA delicate fractal of infinitely patterned bullets. Occasionally coughs up lead from the void.", "mengerammobox_icon", assetbundle: true);
		val.quality = (ItemQuality)3;
		MengerAmmoBoxID = val.PickupObjectId;
	}

	public void OnAmmoCollected(PlayerController player, AmmoPickup self)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Invalid comparison between Unknown and I4
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Invalid comparison between Unknown and I4
		if ((int)self.mode == 1)
		{
			for (int i = 0; i < player.inventory.AllGuns.Count; i++)
			{
				if (Object.op_Implicit((Object)(object)player.inventory.AllGuns[i]) && (Object)(object)((GameActor)player).CurrentGun != (Object)(object)player.inventory.AllGuns[i])
				{
					player.inventory.AllGuns[i].GainAmmo(Mathf.FloorToInt((float)player.inventory.AllGuns[i].AdjustedMaxAmmo * 0.2f));
				}
			}
			((GameActor)player).CurrentGun.ForceImmediateReload(false);
			if ((int)GameManager.Instance.CurrentGameType != 1)
			{
				return;
			}
			PlayerController otherPlayer = GameManager.Instance.GetOtherPlayer(player);
			if (otherPlayer.IsGhost)
			{
				return;
			}
			for (int j = 0; j < otherPlayer.inventory.AllGuns.Count; j++)
			{
				if (Object.op_Implicit((Object)(object)otherPlayer.inventory.AllGuns[j]))
				{
					otherPlayer.inventory.AllGuns[j].GainAmmo(Mathf.FloorToInt((float)otherPlayer.inventory.AllGuns[j].AdjustedMaxAmmo * 0.2f));
				}
			}
			((GameActor)otherPlayer).CurrentGun.ForceImmediateReload(false);
		}
		else if ((int)self.mode == 2 && (Object)(object)((GameActor)player).CurrentGun != (Object)null && ((GameActor)player).CurrentGun.CanGainAmmo)
		{
			((GameActor)player).CurrentGun.GainAmmo(((GameActor)player).CurrentGun.AdjustedMaxAmmo);
			((GameActor)player).CurrentGun.ForceImmediateReload(false);
		}
	}

	public override void Pickup(PlayerController player)
	{
		if (Object.op_Implicit((Object)(object)PlayerUtility.GetExtComp(player)))
		{
			ExtendedPlayerComponent extComp = PlayerUtility.GetExtComp(player);
			extComp.OnPickedUpAmmo = (Action<PlayerController, AmmoPickup>)Delegate.Combine(extComp.OnPickedUpAmmo, new Action<PlayerController, AmmoPickup>(OnAmmoCollected));
		}
		((PassiveItem)this).Pickup(player);
	}

	public override void DisableEffect(PlayerController player)
	{
		if (Object.op_Implicit((Object)(object)PlayerUtility.GetExtComp(player)))
		{
			ExtendedPlayerComponent extComp = PlayerUtility.GetExtComp(player);
			extComp.OnPickedUpAmmo = (Action<PlayerController, AmmoPickup>)Delegate.Remove(extComp.OnPickedUpAmmo, new Action<PlayerController, AmmoPickup>(OnAmmoCollected));
		}
		((PassiveItem)this).DisableEffect(player);
	}
}
