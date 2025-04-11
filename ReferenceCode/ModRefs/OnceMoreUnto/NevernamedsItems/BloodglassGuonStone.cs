using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

internal class BloodglassGuonStone : PassiveItem
{
	public static int BloodGlassGuonStoneID;

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<BloodglassGuonStone>("Bloodglass Guon Stone", "We Are The Crystal Haems", "An ancient glass blessing, perverted by Blobulonian technology.\n\nCrystallises spilt blood into glass guon stones.", "bloodglassguonstone_icon", assetbundle: true);
		val.quality = (ItemQuality)2;
		BloodGlassGuonStoneID = val.PickupObjectId;
		LootUtility.RemovePickupFromLootTables(val);
	}

	private void SpawnGuons(PlayerController player)
	{
		if (Random.value < 0.4f)
		{
			LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(565)).gameObject, player);
			LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(565)).gameObject, player);
			LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(565)).gameObject, player);
		}
	}

	public override void Pickup(PlayerController player)
	{
		if (!base.m_pickedUpThisRun)
		{
			LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(565)).gameObject, player);
			LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(565)).gameObject, player);
			LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(565)).gameObject, player);
		}
		player.OnReceivedDamage += SpawnGuons;
		((PassiveItem)this).Pickup(player);
	}

	public override DebrisObject Drop(PlayerController player)
	{
		DebrisObject result = ((PassiveItem)this).Drop(player);
		player.OnReceivedDamage -= SpawnGuons;
		return result;
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			((PassiveItem)this).Owner.OnReceivedDamage -= SpawnGuons;
		}
		((PassiveItem)this).OnDestroy();
	}
}
