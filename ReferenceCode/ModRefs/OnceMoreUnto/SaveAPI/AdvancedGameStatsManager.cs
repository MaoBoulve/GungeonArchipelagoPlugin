using System;
using System.Collections.Generic;
using FullSerializer;
using UnityEngine;

namespace SaveAPI;

[fsObject]
internal class AdvancedGameStatsManager
{
	private static AdvancedGameStatsManager m_instance;

	[fsProperty]
	public HashSet<CustomDungeonFlags> m_flags;

	[fsProperty]
	public string midGameSaveGuid;

	[fsProperty]
	public Dictionary<PlayableCharacters, AdvancedGameStats> m_characterStats;

	private AdvancedGameStats m_sessionStats;

	private AdvancedGameStats m_savedSessionStats;

	private PlayableCharacters m_sessionCharacter;

	private int m_numCharacters;

	[fsIgnore]
	public int cachedHuntIndex;

	[fsIgnore]
	public SaveSlot cachedSaveSlot;

	[fsProperty]
	public int BeggarRepeatTarget;

	[fsProperty]
	public int BeggarRepeatCurrent;

	[fsIgnore]
	public bool IsInSession => m_sessionStats != null;

	public static bool HasInstance => m_instance != null;

	public static AdvancedGameStatsManager Instance => m_instance;

	public AdvancedGameStatsManager()
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected O, but got Unknown
		m_flags = new HashSet<CustomDungeonFlags>(new CustomDungeonFlagsComparer());
		m_characterStats = new Dictionary<PlayableCharacters, AdvancedGameStats>((IEqualityComparer<PlayableCharacters>)new PlayableCharactersComparer());
		m_numCharacters = -1;
		cachedHuntIndex = -1;
	}

	public static void Unload()
	{
		m_instance = null;
	}

	public void SetCharacterSpecificFlag(PlayableCharacters character, CustomCharacterSpecificGungeonFlags flag, bool value)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		if (flag == CustomCharacterSpecificGungeonFlags.NONE)
		{
			Debug.LogError((object)"Something is attempting to set a NONE character-specific save flag!");
			return;
		}
		if (!m_characterStats.ContainsKey(character))
		{
			m_characterStats.Add(character, new AdvancedGameStats());
		}
		if (m_sessionStats != null && m_sessionCharacter == character)
		{
			m_sessionStats.SetFlag(flag, value);
		}
		else
		{
			m_characterStats[character].SetFlag(flag, value);
		}
	}

	public void SetStat(CustomTrackedStats stat, float value)
	{
		if (!float.IsNaN(value) && !float.IsInfinity(value) && m_sessionStats != null)
		{
			m_sessionStats.SetStat(stat, value);
		}
	}

	public void UpdateMaximum(CustomTrackedMaximums maximum, float val)
	{
		if (!float.IsNaN(val) && !float.IsInfinity(val) && m_sessionStats != null)
		{
			m_sessionStats.SetMax(maximum, val);
		}
	}

	public bool GetCharacterSpecificFlag(CustomCharacterSpecificGungeonFlags flag)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		return GetCharacterSpecificFlag(m_sessionCharacter, flag);
	}

	public bool GetCharacterSpecificFlag(PlayableCharacters character, CustomCharacterSpecificGungeonFlags flag)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		if (flag == CustomCharacterSpecificGungeonFlags.NONE)
		{
			Debug.LogError((object)"Something is attempting to get a NONE character-specific save flag!");
			return false;
		}
		if (m_sessionStats != null && m_sessionCharacter == character)
		{
			if (m_sessionStats.GetFlag(flag))
			{
				return true;
			}
			if (m_savedSessionStats.GetFlag(flag))
			{
				return true;
			}
		}
		AdvancedGameStats value;
		return m_characterStats.TryGetValue(character, out value) && value.GetFlag(flag);
	}

	public static void DoMidgameSave()
	{
		string text = Guid.NewGuid().ToString();
		AdvancedMidGameSaveData advancedMidGameSaveData = new AdvancedMidGameSaveData(text);
		SaveManager.Save<AdvancedMidGameSaveData>(advancedMidGameSaveData, SaveAPIManager.AdvancedMidGameSave, GameStatsManager.Instance.PlaytimeMin, 0u, (SaveSlot?)null);
		Instance.midGameSaveGuid = text;
		Save();
	}

	public void RegisterStatChange(CustomTrackedStats stat, float value)
	{
		if (m_sessionStats == null)
		{
			Debug.LogError((object)"No session stats active and we're registering a stat change!");
		}
		else if (!float.IsNaN(value) && !float.IsInfinity(value) && !(Mathf.Abs(value) > 10000f))
		{
			m_sessionStats.IncrementStat(stat, value);
		}
	}

	public static void InvalidateMidgameSave(bool saveStats)
	{
		AdvancedMidGameSaveData midgameSave = null;
		if (VerifyAndLoadMidgameSave(out midgameSave, checkValidity: false))
		{
			midgameSave.Invalidate();
			SaveManager.Save<AdvancedMidGameSaveData>(midgameSave, SaveAPIManager.AdvancedMidGameSave, GameStatsManager.Instance.PlaytimeMin, 0u, (SaveSlot?)null);
			GameStatsManager.Instance.midGameSaveGuid = midgameSave.midGameSaveGuid;
			if (saveStats)
			{
				GameStatsManager.Save();
			}
		}
	}

	public static void RevalidateMidgameSave(bool saveStats)
	{
		AdvancedMidGameSaveData midgameSave = null;
		if (VerifyAndLoadMidgameSave(out midgameSave, checkValidity: false))
		{
			midgameSave.Revalidate();
			SaveManager.Save<AdvancedMidGameSaveData>(midgameSave, SaveAPIManager.AdvancedMidGameSave, GameStatsManager.Instance.PlaytimeMin, 0u, (SaveSlot?)null);
			GameStatsManager.Instance.midGameSaveGuid = midgameSave.midGameSaveGuid;
			if (saveStats)
			{
				GameStatsManager.Save();
			}
		}
	}

	public static bool VerifyAndLoadMidgameSave(out AdvancedMidGameSaveData midgameSave, bool checkValidity = true)
	{
		if (!SaveManager.Load<AdvancedMidGameSaveData>(SaveAPIManager.AdvancedGameSave, ref midgameSave, true, 0u, (Func<string, uint, string>)null, (SaveSlot?)null))
		{
			Debug.LogError((object)"No mid game save found");
			return false;
		}
		if (midgameSave == null)
		{
			Debug.LogError((object)"Failed to load mid game save (0)");
			return false;
		}
		if (checkValidity && !midgameSave.IsValid())
		{
			return false;
		}
		if (GameStatsManager.Instance.midGameSaveGuid == null || GameStatsManager.Instance.midGameSaveGuid != midgameSave.midGameSaveGuid)
		{
			Debug.LogError((object)"Failed to load mid game save (1)");
			return false;
		}
		return true;
	}

	public void ClearAllStatsGlobal()
	{
		m_sessionStats.ClearAllState();
		m_savedSessionStats.ClearAllState();
		if (m_numCharacters <= 0)
		{
			m_numCharacters = Enum.GetValues(typeof(PlayableCharacters)).Length;
		}
		for (int i = 0; i < m_numCharacters; i++)
		{
			if (m_characterStats.TryGetValue((PlayableCharacters)i, out var value))
			{
				value.ClearAllState();
			}
		}
	}

	public void ClearStatValueGlobal(CustomTrackedStats stat)
	{
		m_sessionStats.SetStat(stat, 0f);
		m_savedSessionStats.SetStat(stat, 0f);
		if (m_numCharacters <= 0)
		{
			m_numCharacters = Enum.GetValues(typeof(PlayableCharacters)).Length;
		}
		for (int i = 0; i < m_numCharacters; i++)
		{
			if (m_characterStats.TryGetValue((PlayableCharacters)i, out var value))
			{
				value.SetStat(stat, 0f);
			}
		}
	}

	private PlayableCharacters GetCurrentCharacter()
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		return GameManager.Instance.PrimaryPlayer.characterIdentity;
	}

	public float GetPlayerMaximum(CustomTrackedMaximums maximum)
	{
		if (m_numCharacters <= 0)
		{
			m_numCharacters = Enum.GetValues(typeof(PlayableCharacters)).Length;
		}
		float num = 0f;
		if (m_sessionStats != null)
		{
			num = Mathf.Max(new float[3]
			{
				num,
				m_sessionStats.GetMaximumValue(maximum),
				m_savedSessionStats.GetMaximumValue(maximum)
			});
		}
		for (int i = 0; i < m_numCharacters; i++)
		{
			if (m_characterStats.TryGetValue((PlayableCharacters)i, out var value))
			{
				num = Mathf.Max(num, value.GetMaximumValue(maximum));
			}
		}
		return num;
	}

	public float GetPlayerStatValue(CustomTrackedStats stat)
	{
		if (m_numCharacters <= 0)
		{
			m_numCharacters = Enum.GetValues(typeof(PlayableCharacters)).Length;
		}
		float num = 0f;
		if (m_sessionStats != null)
		{
			num += m_sessionStats.GetStatValue(stat);
		}
		for (int i = 0; i < m_numCharacters; i++)
		{
			if (m_characterStats.TryGetValue((PlayableCharacters)i, out var value))
			{
				num += value.GetStatValue(stat);
			}
		}
		return num;
	}

	public void SetCharacterSpecificFlag(CustomCharacterSpecificGungeonFlags flag, bool value)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		SetCharacterSpecificFlag(m_sessionCharacter, flag, value);
	}

	public float GetSessionStatValue(CustomTrackedStats stat)
	{
		return m_sessionStats.GetStatValue(stat) + m_savedSessionStats.GetStatValue(stat);
	}

	public float GetCharacterStatValue(CustomTrackedStats stat)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		return GetCharacterStatValue(GetCurrentCharacter(), stat);
	}

	public AdvancedGameStats MoveSessionStatsToSavedSessionStats()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		if (!IsInSession)
		{
			return null;
		}
		if (m_sessionStats != null)
		{
			if (m_characterStats.ContainsKey(m_sessionCharacter))
			{
				m_characterStats[m_sessionCharacter].AddStats(m_sessionStats);
			}
			m_savedSessionStats.AddStats(m_sessionStats);
			m_sessionStats.ClearAllState();
		}
		return m_savedSessionStats;
	}

	public float GetCharacterStatValue(PlayableCharacters character, CustomTrackedStats stat)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		float num = 0f;
		if (m_sessionCharacter == character)
		{
			num += m_sessionStats.GetStatValue(stat);
		}
		if (m_characterStats.ContainsKey(character))
		{
			num += m_characterStats[character].GetStatValue(stat);
		}
		return num;
	}

	public void BeginNewSession(PlayerController player)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		if (m_characterStats == null)
		{
			m_characterStats = new Dictionary<PlayableCharacters, AdvancedGameStats>((IEqualityComparer<PlayableCharacters>)new PlayableCharactersComparer());
		}
		if (IsInSession)
		{
			m_sessionCharacter = player.characterIdentity;
			if (!m_characterStats.ContainsKey(player.characterIdentity))
			{
				m_characterStats.Add(player.characterIdentity, new AdvancedGameStats());
			}
			return;
		}
		m_sessionCharacter = player.characterIdentity;
		m_sessionStats = new AdvancedGameStats();
		m_savedSessionStats = new AdvancedGameStats();
		if (!m_characterStats.ContainsKey(player.characterIdentity))
		{
			m_characterStats.Add(player.characterIdentity, new AdvancedGameStats());
		}
	}

	public void EndSession(bool recordSessionStats)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		if (IsInSession && m_sessionStats != null)
		{
			if (recordSessionStats && m_characterStats.ContainsKey(m_sessionCharacter))
			{
				m_characterStats[m_sessionCharacter].AddStats(m_sessionStats);
			}
			m_sessionStats = null;
			m_savedSessionStats = null;
		}
	}

	public static void Load()
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		SaveManager.Init();
		bool flag = false;
		SaveSlot? val = null;
		int num = -1;
		if (m_instance != null)
		{
			flag = true;
			val = m_instance.cachedSaveSlot;
			num = m_instance.cachedHuntIndex;
		}
		if (!SaveManager.Load<AdvancedGameStatsManager>(SaveAPIManager.AdvancedGameSave, ref m_instance, true, 0u, (Func<string, uint, string>)null, (SaveSlot?)null))
		{
			m_instance = new AdvancedGameStatsManager();
		}
		m_instance.cachedSaveSlot = SaveManager.CurrentSaveSlot;
		if (flag && val.HasValue && m_instance.cachedSaveSlot == val.Value)
		{
			m_instance.cachedHuntIndex = num;
		}
		else
		{
			m_instance.cachedHuntIndex = -1;
		}
	}

	public static void DANGEROUS_ResetAllStats()
	{
		m_instance = new AdvancedGameStatsManager();
		SaveManager.DeleteAllBackups(SaveAPIManager.AdvancedGameSave, (SaveSlot?)null);
	}

	public bool GetFlag(CustomDungeonFlags flag)
	{
		if (flag == CustomDungeonFlags.NONE)
		{
			Debug.LogError((object)"Something is attempting to get a NONE save flag!");
			return false;
		}
		return m_flags.Contains(flag);
	}

	public void SetFlag(CustomDungeonFlags flag, bool value)
	{
		if (flag == CustomDungeonFlags.NONE)
		{
			Debug.LogError((object)"Something is attempting to set a NONE save flag!");
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

	public static bool Save()
	{
		bool result = false;
		try
		{
			result = SaveManager.Save<AdvancedGameStatsManager>(m_instance, SaveAPIManager.AdvancedGameSave, GameStatsManager.Instance.PlaytimeMin, 0u, (SaveSlot?)null);
		}
		catch (Exception ex)
		{
			Debug.LogErrorFormat("SAVE FAILED: {0}", new object[1] { ex });
		}
		return result;
	}

	public void AssignMidGameSavedSessionStats(AdvancedGameStats source)
	{
		if (IsInSession && m_savedSessionStats != null)
		{
			m_savedSessionStats.AddStats(source);
		}
	}
}
