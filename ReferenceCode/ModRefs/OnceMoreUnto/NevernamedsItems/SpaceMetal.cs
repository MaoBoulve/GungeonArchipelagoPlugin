using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class SpaceMetal : PassiveItem
{
	public static void Init()
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<SpaceMetal>("Lump of Space Metal", "Mined Fresh To You", "This rich lump of unrefined space metal is prized throughout Hegemony of Man systems for all the useful minerals and materials that can be drawn from within it.", "spacemetal_improved", assetbundle: true);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)18, 1f, (ModifyMethod)0);
		val.CanBeDropped = true;
		val.quality = (ItemQuality)4;
	}

	public override void Pickup(PlayerController player)
	{
		if (!base.m_pickedUpThisRun)
		{
			LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(67)).gameObject, player);
			LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(67)).gameObject, player);
			LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(67)).gameObject, player);
			LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(120)).gameObject, player);
			LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(120)).gameObject, player);
			LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(120)).gameObject, player);
			LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(120)).gameObject, player);
			LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(120)).gameObject, player);
			LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(74)).gameObject, player);
			LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(224)).gameObject, player);
			LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(565)).gameObject, player);
			LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(565)).gameObject, player);
			LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(565)).gameObject, player);
			LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(565)).gameObject, player);
		}
		((PassiveItem)this).Pickup(player);
	}
}
