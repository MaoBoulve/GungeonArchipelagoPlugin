using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class GlassAmmolet : PassiveItem
{
	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<GlassAmmolet>("Glass Ammolet", "Blank Recycling", "Recycles spent blanks into handy defensive guon stones.", "glassammolet_icon", assetbundle: true);
		val.quality = (ItemQuality)3;
		ItemBuilder.AddToSubShop(val, (ShopType)4, 1f);
		AlexandriaTags.SetTag(val, "ammolet");
	}

	private void OnUsedBlank(PlayerController arg1, int arg2)
	{
		PickupObject byId = PickupObjectDatabase.GetById(565);
		((PassiveItem)this).Owner.AcquirePassiveItemPrefabDirectly((PassiveItem)(object)((byId is PassiveItem) ? byId : null));
	}

	public override void Pickup(PlayerController player)
	{
		if (!base.m_pickedUpThisRun)
		{
			PickupObject byId = PickupObjectDatabase.GetById(565);
			player.AcquirePassiveItemPrefabDirectly((PassiveItem)(object)((byId is PassiveItem) ? byId : null));
		}
		player.OnUsedBlank += OnUsedBlank;
		((PassiveItem)this).Pickup(player);
	}

	public override DebrisObject Drop(PlayerController player)
	{
		player.OnUsedBlank -= OnUsedBlank;
		return ((PassiveItem)this).Drop(player);
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			((PassiveItem)this).Owner.OnUsedBlank -= OnUsedBlank;
		}
		((PassiveItem)this).OnDestroy();
	}
}
