using System;
using Alexandria.DungeonAPI;
using Alexandria.Misc;

namespace NevernamedsItems;

public class AdditionalMasteries
{
	public static void Init()
	{
		MasteryOverrideHandler.RegisterFloorForMasterySpawn((ViableRegisterFloors)0);
		MasteryOverrideHandler.RegisterFloorForMasterySpawn((ViableRegisterFloors)1);
		CustomActions.OnRewardPedestalDetermineContents = (Action<RewardPedestal, PlayerController, ValidPedestalContents>)Delegate.Combine(CustomActions.OnRewardPedestalDetermineContents, new Action<RewardPedestal, PlayerController, ValidPedestalContents>(OnMasteryDetermineContents));
	}

	public static void OnMasteryDetermineContents(RewardPedestal pedestal, PlayerController determiner, ValidPedestalContents valids)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Invalid comparison between Unknown and I4
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Invalid comparison between Unknown and I4
		if (MasteryOverrideHandler.ContainsMasteryTokenForCurrentLevel(pedestal))
		{
			if ((int)GameManager.Instance.Dungeon.tileIndices.tilesetId == 4)
			{
				valids.overrideItemPool.Add(new Tuple<int, float>(GooeyHeart.GooeyHeartID, 1f));
				valids.overrideItemPool.Add(new Tuple<int, float>(BloodglassGuonStone.BloodGlassGuonStoneID, 1f));
				valids.overrideItemPool.Add(new Tuple<int, float>(BlobulonRage.BlobulonRageID, 1f));
			}
			else if ((int)GameManager.Instance.Dungeon.tileIndices.tilesetId == 8)
			{
				valids.overrideItemPool.Add(new Tuple<int, float>(ExaltedHeart.ExaltedHeartID, 1f));
			}
		}
	}
}
