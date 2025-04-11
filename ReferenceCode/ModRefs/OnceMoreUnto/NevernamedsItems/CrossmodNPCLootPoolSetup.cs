using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

internal class CrossmodNPCLootPoolSetup
{
	public static void CheckItems()
	{
		foreach (string iD in Game.Items.IDs)
		{
			if (!((Object)(object)Game.Items[iD.Replace("gungeon:", "")] != (Object)null) || Game.Items[iD.Replace("gungeon:", "")] == null)
			{
				continue;
			}
			PickupObject val = Game.Items[iD.Replace("gungeon:", "")];
			Component[] components = ((Component)val).GetComponents<Component>();
			foreach (Component val2 in components)
			{
				if (((object)val2).GetType().ToString().Contains("BoomhildrItemPool"))
				{
					LootUtility.AddItemToPool(Boomhildr.BoomhildrLootTable, val.PickupObjectId, 1f);
				}
				else if (((object)val2).GetType().ToString().Contains("IronsideItemPool"))
				{
					LootUtility.AddItemToPool(Ironside.IronsideLootTable, val.PickupObjectId, 1f);
				}
				else if (((object)val2).GetType().ToString().Contains("RustyItemPool"))
				{
					LootUtility.AddItemToPool(Rusty.RustyLootTable, val.PickupObjectId, 1f);
				}
			}
		}
	}
}
