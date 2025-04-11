using System;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class TableTechAmmo : TableFlipItem
{
	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<TableTechAmmo>("Table Tech Ammo", "Flip Replenishment", "Grants a small amount of ammo each time a table is flipped.\n\nChapter 10 of the \"Tabla Sutra.\" And he who flips shall never be hungry, for he will always have the flip within his heart.", "tabletechammo_icon", assetbundle: true);
		TableFlipItem val = (TableFlipItem)(object)((obj is TableFlipItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)2;
		AlexandriaTags.SetTag((PickupObject)(object)val, "table_tech");
		val.TableFlocking = true;
	}

	public override void Pickup(PlayerController player)
	{
		player.OnTableFlipped = (Action<FlippableCover>)Delegate.Combine(player.OnTableFlipped, new Action<FlippableCover>(GainAmmo));
		((TableFlipItem)this).Pickup(player);
	}

	public override void DisableEffect(PlayerController player)
	{
		player.OnTableFlipped = (Action<FlippableCover>)Delegate.Remove(player.OnTableFlipped, new Action<FlippableCover>(GainAmmo));
		((PassiveItem)this).DisableEffect(player);
	}

	private void GainAmmo(FlippableCover obj)
	{
		int num = Random.Range(1, 5);
		if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Tabletop"))
		{
			num = Random.Range(5, 10);
		}
		((GameActor)((PassiveItem)this).Owner).CurrentGun.GainAmmo(num);
	}
}
