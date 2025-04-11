using System;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class TableTechGuon : TableFlipItem
{
	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<TableTechGuon>("Table Tech Guon", "Spinflip", "This highly special spinning flip technique causes chunks of table to become detatched and orbit their creator in a guon stone form before disintegrating from sheer awe.\n\nChapter ??? of the 'Tabla Sutra'. A true flip does not protect only once, but many times after as well.", "tabletechguon_icon", assetbundle: true);
		TableFlipItem val = (TableFlipItem)(object)((obj is TableFlipItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)2;
		AlexandriaTags.SetTag((PickupObject)(object)val, "table_tech");
	}

	public override void Pickup(PlayerController player)
	{
		((TableFlipItem)this).Pickup(player);
		player.OnTableFlipped = (Action<FlippableCover>)Delegate.Combine(player.OnTableFlipped, new Action<FlippableCover>(GiveWoodGuon));
	}

	public override DebrisObject Drop(PlayerController player)
	{
		DebrisObject result = ((TableFlipItem)this).Drop(player);
		player.OnTableFlipped = (Action<FlippableCover>)Delegate.Remove(player.OnTableFlipped, new Action<FlippableCover>(GiveWoodGuon));
		return result;
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			PlayerController owner = ((PassiveItem)this).Owner;
			owner.OnTableFlipped = (Action<FlippableCover>)Delegate.Remove(owner.OnTableFlipped, new Action<FlippableCover>(GiveWoodGuon));
		}
		((TableFlipItem)this).OnDestroy();
	}

	private void GiveWoodGuon(FlippableCover obj)
	{
		PlayerController owner = ((PassiveItem)this).Owner;
		PickupObject val = Game.Items["nn:wood_guon_stone"];
		owner.AcquirePassiveItemPrefabDirectly((PassiveItem)(object)((val is PassiveItem) ? val : null));
	}
}
