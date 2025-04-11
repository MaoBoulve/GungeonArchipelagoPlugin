using Alexandria.ItemAPI;

namespace NevernamedsItems;

public class EggSalad : PassiveItem
{
	public static void Init()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<EggSalad>("Egg Salad", "Tastes Fishy. Why.", "Somebody lost an egg salad down here a long, long time ago...", "egg_salad_001", assetbundle: true);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)3, 1f, (ModifyMethod)0);
		val.quality = (ItemQuality)1;
	}

	public override void Pickup(PlayerController player)
	{
		if (player.ForceZeroHealthState && !base.m_pickedUpThisRun)
		{
			HealthHaver healthHaver = ((BraveBehaviour)player).healthHaver;
			healthHaver.Armor += 1f;
		}
		((PassiveItem)this).Pickup(player);
	}
}
