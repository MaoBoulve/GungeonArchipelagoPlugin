using System.Collections.Generic;
using FullSerializer;
using UnityEngine;

namespace SaveAPI;

[fsObject]
public class AdvancedGameStats
{
	[fsProperty]
	private Dictionary<CustomTrackedStats, float> stats;

	[fsProperty]
	private Dictionary<CustomTrackedMaximums, float> maxima;

	[fsProperty]
	public HashSet<CustomCharacterSpecificGungeonFlags> m_flags;

	public AdvancedGameStats()
	{
		m_flags = new HashSet<CustomCharacterSpecificGungeonFlags>();
		stats = new Dictionary<CustomTrackedStats, float>(new CustomTrackedStatsComparer());
		maxima = new Dictionary<CustomTrackedMaximums, float>(new CustomTrackedMaximumsComparer());
	}

	public float GetStatValue(CustomTrackedStats statToCheck)
	{
		if (!stats.ContainsKey(statToCheck))
		{
			return 0f;
		}
		return stats[statToCheck];
	}

	public float GetMaximumValue(CustomTrackedMaximums maxToCheck)
	{
		if (!maxima.ContainsKey(maxToCheck))
		{
			return 0f;
		}
		return maxima[maxToCheck];
	}

	public bool GetFlag(CustomCharacterSpecificGungeonFlags flag)
	{
		if (flag == CustomCharacterSpecificGungeonFlags.NONE)
		{
			Debug.LogError((object)"Something is attempting to get a NONE character-specific save flag!");
			return false;
		}
		return m_flags.Contains(flag);
	}

	public void SetStat(CustomTrackedStats stat, float val)
	{
		if (stats.ContainsKey(stat))
		{
			stats[stat] = val;
		}
		else
		{
			stats.Add(stat, val);
		}
	}

	public void SetMax(CustomTrackedMaximums max, float val)
	{
		if (maxima.ContainsKey(max))
		{
			maxima[max] = Mathf.Max(maxima[max], val);
		}
		else
		{
			maxima.Add(max, val);
		}
	}

	public void SetFlag(CustomCharacterSpecificGungeonFlags flag, bool value)
	{
		if (flag == CustomCharacterSpecificGungeonFlags.NONE)
		{
			Debug.LogError((object)"Something is attempting to set a NONE character-specific save flag!");
		}
		else if (value)
		{
			m_flags.Add(flag);
		}
		else
		{
			m_flags.Remove(flag);
		}
	}

	public void IncrementStat(CustomTrackedStats stat, float val)
	{
		if (stats.ContainsKey(stat))
		{
			stats[stat] += val;
		}
		else
		{
			stats.Add(stat, val);
		}
	}

	public void AddStats(AdvancedGameStats otherStats)
	{
		foreach (KeyValuePair<CustomTrackedStats, float> stat in otherStats.stats)
		{
			IncrementStat(stat.Key, stat.Value);
		}
		foreach (KeyValuePair<CustomTrackedMaximums, float> item in otherStats.maxima)
		{
			SetMax(item.Key, item.Value);
		}
		foreach (CustomCharacterSpecificGungeonFlags flag in otherStats.m_flags)
		{
			m_flags.Add(flag);
		}
	}

	public void ClearAllState()
	{
		List<CustomTrackedStats> list = new List<CustomTrackedStats>();
		foreach (KeyValuePair<CustomTrackedStats, float> stat in stats)
		{
			list.Add(stat.Key);
		}
		foreach (CustomTrackedStats item in list)
		{
			stats[item] = 0f;
		}
		List<CustomTrackedMaximums> list2 = new List<CustomTrackedMaximums>();
		foreach (KeyValuePair<CustomTrackedMaximums, float> item2 in maxima)
		{
			list2.Add(item2.Key);
		}
		foreach (CustomTrackedMaximums item3 in list2)
		{
			maxima[item3] = 0f;
		}
	}
}
