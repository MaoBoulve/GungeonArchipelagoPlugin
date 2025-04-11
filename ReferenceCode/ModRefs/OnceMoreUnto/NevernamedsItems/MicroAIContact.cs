using Alexandria.ItemAPI;

namespace NevernamedsItems;

public class MicroAIContact : PassiveItem
{
	public static void Init()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<MicroAIContact>("Aimbot", "Virtual Assistant", "This highly advanced contact lens contains a Hegemony Issue Virtual Aim Assistant Micro-AI, or Aimbot for short. It projects mathematic predictions, bullet aerodynamics simulations, and a targeting reticule onto your vision, making your accuracy second to none.", "aimbot_improved", assetbundle: true);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)2, 0.01f, (ModifyMethod)1);
		val.quality = (ItemQuality)4;
	}
}
