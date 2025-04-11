using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class GoldenAppleCore : PassiveItem
{
	public static int GoldenAppleCoreID;

	public bool givesFlight = false;

	public static void Init()
	{
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<GoldenAppleCore>("Golden Apple Core", "Trash?", "An apple core.\n\nMaybe this one isn't so worthless.", "goldenapplecore_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)val, (StatType)6, 1.05f, (ModifyMethod)1);
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)val, (StatType)15, 1.05f, (ModifyMethod)1);
		((PickupObject)val).CustomCost = 100;
		((PickupObject)val).UsesCustomCost = true;
		((PickupObject)val).CanBeDropped = true;
		((PickupObject)val).quality = (ItemQuality)(-100);
		GoldenAppleCoreID = ((PickupObject)val).PickupObjectId;
	}

	public override void Update()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner) && !((GameActor)((PassiveItem)this).Owner).IsFlying && givesFlight)
		{
			((GameActor)((PassiveItem)this).Owner).SetIsFlying(true, "GoldenAppleCoreNewton", true, false);
			((PassiveItem)this).Owner.AdditionalCanDodgeRollWhileFlying.AddOverride("GoldenAppleCoreNewton", (float?)null);
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
			((GameActor)((PassiveItem)this).Owner).SetIsFlying(false, "GoldenAppleCoreNewton", true, false);
			((PassiveItem)this).Owner.AdditionalCanDodgeRollWhileFlying.RemoveOverride("GoldenAppleCoreNewton");
		}
		((PassiveItem)this).OnDestroy();
	}

	public override DebrisObject Drop(PlayerController player)
	{
		if (givesFlight)
		{
			((GameActor)player).SetIsFlying(false, "GoldenAppleCoreNewton", true, false);
			player.AdditionalCanDodgeRollWhileFlying.RemoveOverride("GoldenAppleCoreNewton");
		}
		return ((PassiveItem)this).Drop(player);
	}
}
