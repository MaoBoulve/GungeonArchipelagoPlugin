using FullSerializer;

namespace SaveAPI;

public class AdvancedMidGameSaveData
{
	[fsProperty]
	public AdvancedGameStats PriorSessionStats;

	[fsProperty]
	public string midGameSaveGuid;

	[fsProperty]
	public bool invalidated;

	public AdvancedMidGameSaveData(string midGameSaveGuid)
	{
		this.midGameSaveGuid = midGameSaveGuid;
		PriorSessionStats = AdvancedGameStatsManager.Instance.MoveSessionStatsToSavedSessionStats();
	}

	public bool IsValid()
	{
		return !invalidated;
	}

	public void Invalidate()
	{
		invalidated = true;
	}

	public void Revalidate()
	{
		invalidated = false;
	}

	public void LoadDataFromMidGameSave()
	{
		AdvancedGameStatsManager.Instance.AssignMidGameSavedSessionStats(PriorSessionStats);
	}
}
