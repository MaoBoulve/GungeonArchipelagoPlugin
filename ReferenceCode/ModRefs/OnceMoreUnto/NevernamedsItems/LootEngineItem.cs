using System.Collections.Generic;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class LootEngineItem : PlayerItem
{
	private List<DebrisObject> pickupsInRoom = new List<DebrisObject>();

	public static List<int> validIDs = new List<int> { 78, 600, 565, 73, 85, 120, 224, 67 };

	public static void Init()
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<LootEngineItem>("Loot Engine", "Lengine, if you will", "Rerolls all consumables in the room into other consumables. Also works on Glass Guon Stones, and Junk.\n\nRumour has it that a much larger version of this machine is responsible for handling the Gungeon's notoriously stingy loot system.", "lootengine_icon", assetbundle: true);
		PlayerItem val = (PlayerItem)(object)((obj is PlayerItem) ? obj : null);
		ItemBuilder.SetCooldownType(val, (CooldownType)1, 500f);
		val.consumable = false;
		((PickupObject)val).quality = (ItemQuality)2;
	}

	public override void DoEffect(PlayerController user)
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		pickupsInRoom.Clear();
		DebrisObject[] array = Object.FindObjectsOfType<DebrisObject>();
		DebrisObject[] array2 = array;
		foreach (DebrisObject val in array2)
		{
			if (DetermineIfValid(val) && Vector3Extensions.GetAbsoluteRoom(((BraveBehaviour)val).transform.position) == user.CurrentRoom)
			{
				pickupsInRoom.Add(val);
			}
		}
		if (pickupsInRoom.Count != 0)
		{
			DoReroll();
		}
	}

	private void DoReroll()
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		foreach (DebrisObject item in pickupsInRoom)
		{
			Vector2 val = Vector2.op_Implicit(((BraveBehaviour)item).transform.position);
			LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetById(BraveUtility.RandomElement<int>(validIDs))).gameObject, Vector2.op_Implicit(val), Vector2.zero, 1f, false, true, false);
			Object.Destroy((Object)(object)((Component)item).gameObject);
		}
	}

	private bool DetermineIfValid(DebrisObject thing)
	{
		PickupObject component = ((Component)thing).gameObject.GetComponent<PickupObject>();
		if ((Object)(object)component != (Object)null)
		{
			if (component.PickupObjectId == 127 || validIDs.Contains(component.PickupObjectId))
			{
				return true;
			}
			return false;
		}
		return false;
	}

	public override bool CanBeUsed(PlayerController user)
	{
		return ((PlayerItem)this).CanBeUsed(user);
	}
}
