using System.Collections.Generic;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

internal class GlobalUpdate : MonoBehaviour
{
	public static bool DungeonWasGeneratingLastChecked;

	public void Update()
	{
		if (Dungeon.IsGenerating == DungeonWasGeneratingLastChecked)
		{
			return;
		}
		if (Object.op_Implicit((Object)(object)GameManager.Instance))
		{
			if (Dungeon.IsGenerating && !DungeonWasGeneratingLastChecked)
			{
				List<PlayerController> list = new List<PlayerController>();
				if ((Object)(object)GameManager.Instance.PrimaryPlayer != (Object)null)
				{
					list.Add(GameManager.Instance.PrimaryPlayer);
				}
				if ((Object)(object)GameManager.Instance.SecondaryPlayer != (Object)null)
				{
					list.Add(GameManager.Instance.SecondaryPlayer);
				}
				FloorAndGenerationToolbox.OnFloorUnloaded(list);
			}
			if (!Dungeon.IsGenerating && DungeonWasGeneratingLastChecked)
			{
				FloorAndGenerationToolbox.OnFloorLoaded();
			}
		}
		DungeonWasGeneratingLastChecked = Dungeon.IsGenerating;
	}
}
