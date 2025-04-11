using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class AppleCore : PassiveItem
{
	public static int AppleCoreID;

	public bool givesFlight = false;

	public static void Init()
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<AppleCore>("Apple Core", "Trash", "A worthless apple core.", "applecore_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)val, (StatType)6, 1.05f, (ModifyMethod)1);
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)val, (StatType)15, 1.05f, (ModifyMethod)1);
		((PickupObject)val).CanBeDropped = true;
		((PickupObject)val).quality = (ItemQuality)(-100);
		AppleCoreID = ((PickupObject)val).PickupObjectId;
		((PickupObject)val).CustomCost = 3;
		((PickupObject)val).UsesCustomCost = true;
	}

	public override void Update()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner) && !((GameActor)((PassiveItem)this).Owner).IsFlying && givesFlight)
		{
			((GameActor)((PassiveItem)this).Owner).SetIsFlying(true, "AppleCoreNewton", true, false);
			((PassiveItem)this).Owner.AdditionalCanDodgeRollWhileFlying.AddOverride("AppleCoreNewton", (float?)null);
		}
		((PassiveItem)this).Update();
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner) && givesFlight)
		{
			((GameActor)((PassiveItem)this).Owner).SetIsFlying(false, "AppleCoreNewton", true, false);
			((PassiveItem)this).Owner.AdditionalCanDodgeRollWhileFlying.RemoveOverride("AppleCoreNewton");
		}
		((PassiveItem)this).OnDestroy();
	}

	public override DebrisObject Drop(PlayerController player)
	{
		if (givesFlight)
		{
			((GameActor)player).SetIsFlying(false, "AppleCoreNewton", true, false);
			player.AdditionalCanDodgeRollWhileFlying.RemoveOverride("AppleCoreNewton");
		}
		return ((PassiveItem)this).Drop(player);
	}
}
