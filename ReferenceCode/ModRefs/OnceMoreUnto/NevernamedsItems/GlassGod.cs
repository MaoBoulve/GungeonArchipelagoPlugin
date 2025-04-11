using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class GlassGod : PassiveItem
{
	public static void Init()
	{
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<GlassGod>("Glass God", "Fragile Divinity", "Grants great power, but shatters upon it's bearer taking damage.\n\nThe emblem of the Lady of Pane's greatest champion, a shining titan known only as 'The Glass One'. After his fall in battle, outnumbered ten to one, his crest somehow made it's way to the Gungeon.", "glassgod_icon", assetbundle: true);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)4, 5f, (ModifyMethod)0);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)5, 1.5f, (ModifyMethod)1);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)10, 0.5f, (ModifyMethod)1);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)0, 1.2f, (ModifyMethod)1);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)8, 5f, (ModifyMethod)0);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)9, 1.5f, (ModifyMethod)1);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)1, 1.5f, (ModifyMethod)1);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)6, 1.5f, (ModifyMethod)1);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)2, 0.5f, (ModifyMethod)1);
		val.quality = (ItemQuality)4;
	}

	private void breakItem(PlayerController player)
	{
		PickupObject byId = PickupObjectDatabase.GetById(565);
		player.AcquirePassiveItemPrefabDirectly((PassiveItem)(object)((byId is PassiveItem) ? byId : null));
		player.AcquirePassiveItemPrefabDirectly((PassiveItem)(object)((byId is PassiveItem) ? byId : null));
		player.AcquirePassiveItemPrefabDirectly((PassiveItem)(object)((byId is PassiveItem) ? byId : null));
		player.AcquirePassiveItemPrefabDirectly((PassiveItem)(object)((byId is PassiveItem) ? byId : null));
		player.AcquirePassiveItemPrefabDirectly((PassiveItem)(object)((byId is PassiveItem) ? byId : null));
		((PassiveItem)this).Owner.RemovePassiveItem(((PickupObject)this).PickupObjectId);
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		player.OnReceivedDamage += breakItem;
	}

	public override void DisableEffect(PlayerController player)
	{
		if (Object.op_Implicit((Object)(object)player))
		{
			player.OnReceivedDamage -= breakItem;
		}
		((PassiveItem)this).DisableEffect(player);
	}
}
