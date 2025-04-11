using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using Dungeonator;
using MonoMod.RuntimeDetour;
using UnityEngine;

namespace SaveAPI;

public static class SaveAPIManager
{
	public delegate void OnActiveGameDataClearedDelegate(GameManager manager, bool destroyGameManager, bool endSession);

	[CompilerGenerated]
	private sealed class _003CFrameDelayedInitizlizationHook_003Ed__32 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Func<Dungeon, MidGameSaveData, IEnumerator> orig;

		public Dungeon self;

		public MidGameSaveData data;

		private AdvancedMidGameSaveData _003CmidgameSave_003E5__1;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CFrameDelayedInitizlizationHook_003Ed__32(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003CmidgameSave_003E5__1 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = orig(self, data);
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				if (AdvancedGameStatsManager.VerifyAndLoadMidgameSave(out _003CmidgameSave_003E5__1))
				{
					_003CmidgameSave_003E5__1.LoadDataFromMidGameSave();
				}
				return false;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}
	}

	private static Hook saveHook;

	private static Hook loadHook;

	private static Hook resetHook;

	private static Hook beginSessionHook;

	private static Hook endSessionHook;

	private static Hook clearAllStatsHook;

	private static Hook deleteMidGameSaveHook;

	private static Hook midgameSaveHook;

	private static Hook invalidateSaveHook;

	private static Hook revalidateSaveHook;

	private static Hook frameDelayedInitizlizationHook;

	private static Hook moveSessionStatsHook;

	private static Hook prerequisiteHook;

	private static Hook clearActiveGameDataHook;

	private static Hook aiactorRewardsHook;

	private static Hook aiactorEngagedHook;

	private static bool m_loaded;

	public static SaveType AdvancedGameSave;

	public static SaveType AdvancedMidGameSave;

	public static OnActiveGameDataClearedDelegate OnActiveGameDataCleared;

	private static bool FirstLoad;

	public static bool IsFirstLoad => FirstLoad;

	public static void Setup(string prefix)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f2: Expected O, but got Unknown
		//IL_021c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0226: Expected O, but got Unknown
		//IL_0250: Unknown result type (might be due to invalid IL or missing references)
		//IL_025a: Expected O, but got Unknown
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_028e: Expected O, but got Unknown
		//IL_02b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c2: Expected O, but got Unknown
		//IL_02ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f6: Expected O, but got Unknown
		//IL_0320: Unknown result type (might be due to invalid IL or missing references)
		//IL_032a: Expected O, but got Unknown
		//IL_0354: Unknown result type (might be due to invalid IL or missing references)
		//IL_035e: Expected O, but got Unknown
		//IL_0388: Unknown result type (might be due to invalid IL or missing references)
		//IL_0392: Expected O, but got Unknown
		//IL_03bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c6: Expected O, but got Unknown
		//IL_03f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fa: Expected O, but got Unknown
		//IL_0424: Unknown result type (might be due to invalid IL or missing references)
		//IL_042e: Expected O, but got Unknown
		//IL_0458: Unknown result type (might be due to invalid IL or missing references)
		//IL_0462: Expected O, but got Unknown
		//IL_048c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0496: Expected O, but got Unknown
		//IL_04c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ca: Expected O, but got Unknown
		//IL_04f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fe: Expected O, but got Unknown
		if (!m_loaded)
		{
			AdvancedGameSave = new SaveType
			{
				filePattern = "Slot{0}." + prefix + "Save",
				encrypted = true,
				backupCount = 3,
				backupPattern = "Slot{0}." + prefix + "Backup.{1}",
				backupMinTimeMin = 45,
				legacyFilePattern = prefix + "GameStatsSlot{0}.txt"
			};
			AdvancedMidGameSave = new SaveType
			{
				filePattern = "Active{0}." + prefix + "Game",
				legacyFilePattern = prefix + "ActiveSlot{0}.txt",
				encrypted = true,
				backupCount = 0,
				backupPattern = "Active{0}." + prefix + "Backup.{1}",
				backupMinTimeMin = 60
			};
			for (int i = 0; i < 3; i++)
			{
				SaveSlot val = (SaveSlot)i;
				SaveTools.SafeMove(Path.Combine(SaveManager.OldSavePath, string.Format(AdvancedGameSave.legacyFilePattern, val)), Path.Combine(SaveManager.OldSavePath, string.Format(AdvancedGameSave.filePattern, val)));
				SaveTools.SafeMove(Path.Combine(SaveManager.OldSavePath, string.Format(AdvancedGameSave.filePattern, val)), Path.Combine(SaveManager.OldSavePath, string.Format(AdvancedGameSave.filePattern, val)));
				SaveTools.SafeMove(SaveTools.PathCombine(SaveManager.SavePath, "01", string.Format(AdvancedGameSave.filePattern, val)), Path.Combine(SaveManager.SavePath, string.Format(AdvancedGameSave.filePattern, val)), allowOverwritting: true);
			}
			CustomHuntQuests.DoSetup();
			saveHook = new Hook((MethodBase)typeof(GameStatsManager).GetMethod("Save", BindingFlags.Static | BindingFlags.Public), typeof(SaveAPIManager).GetMethod("SaveHook"));
			loadHook = new Hook((MethodBase)typeof(GameStatsManager).GetMethod("Load", BindingFlags.Static | BindingFlags.Public), typeof(SaveAPIManager).GetMethod("LoadHook"));
			resetHook = new Hook((MethodBase)typeof(GameStatsManager).GetMethod("DANGEROUS_ResetAllStats", BindingFlags.Static | BindingFlags.Public), typeof(SaveAPIManager).GetMethod("ResetHook"));
			beginSessionHook = new Hook((MethodBase)typeof(GameStatsManager).GetMethod("BeginNewSession", BindingFlags.Instance | BindingFlags.Public), typeof(SaveAPIManager).GetMethod("BeginSessionHook"));
			endSessionHook = new Hook((MethodBase)typeof(GameStatsManager).GetMethod("EndSession", BindingFlags.Instance | BindingFlags.Public), typeof(SaveAPIManager).GetMethod("EndSessionHook"));
			clearAllStatsHook = new Hook((MethodBase)typeof(GameStatsManager).GetMethod("ClearAllStatsGlobal", BindingFlags.Instance | BindingFlags.Public), typeof(SaveAPIManager).GetMethod("ClearAllStatsHook"));
			deleteMidGameSaveHook = new Hook((MethodBase)typeof(SaveManager).GetMethod("DeleteCurrentSlotMidGameSave", BindingFlags.Static | BindingFlags.Public), typeof(SaveAPIManager).GetMethod("DeleteMidGameSaveHook"));
			midgameSaveHook = new Hook((MethodBase)typeof(GameManager).GetMethod("DoMidgameSave", BindingFlags.Static | BindingFlags.Public), typeof(SaveAPIManager).GetMethod("MidgameSaveHook"));
			invalidateSaveHook = new Hook((MethodBase)typeof(GameManager).GetMethod("InvalidateMidgameSave", BindingFlags.Static | BindingFlags.Public), typeof(SaveAPIManager).GetMethod("InvalidateSaveHook"));
			revalidateSaveHook = new Hook((MethodBase)typeof(GameManager).GetMethod("RevalidateMidgameSave", BindingFlags.Static | BindingFlags.Public), typeof(SaveAPIManager).GetMethod("RevalidateSaveHook"));
			frameDelayedInitizlizationHook = new Hook((MethodBase)typeof(Dungeon).GetMethod("FrameDelayedMidgameInitialization", BindingFlags.Instance | BindingFlags.NonPublic), typeof(SaveAPIManager).GetMethod("FrameDelayedInitizlizationHook"));
			moveSessionStatsHook = new Hook((MethodBase)typeof(GameStatsManager).GetMethod("MoveSessionStatsToSavedSessionStats", BindingFlags.Instance | BindingFlags.Public), typeof(SaveAPIManager).GetMethod("MoveSessionStatsHook"));
			prerequisiteHook = new Hook((MethodBase)typeof(DungeonPrerequisite).GetMethod("CheckConditionsFulfilled", BindingFlags.Instance | BindingFlags.Public), typeof(SaveAPIManager).GetMethod("PrerequisiteHook"));
			clearActiveGameDataHook = new Hook((MethodBase)typeof(GameManager).GetMethod("ClearActiveGameData", BindingFlags.Instance | BindingFlags.Public), typeof(SaveAPIManager).GetMethod("ClearActiveGameDataHook"));
			aiactorRewardsHook = new Hook((MethodBase)typeof(AIActor).GetMethod("HandleRewards", BindingFlags.Instance | BindingFlags.NonPublic), typeof(SaveAPIManager).GetMethod("AIActorRewardsHook"));
			aiactorEngagedHook = new Hook((MethodBase)typeof(AIActor).GetMethod("OnEngaged", BindingFlags.Instance | BindingFlags.NonPublic), typeof(SaveAPIManager).GetMethod("AIActorEngagedHook"));
			LoadGameStatsFirstLoad();
			BreachShopTool.DoSetup();
			m_loaded = true;
		}
	}

	public static void Reload(string prefix)
	{
		Unload();
		Setup(prefix);
	}

	private static void LoadGameStatsFirstLoad()
	{
		bool firstLoad = FirstLoad;
		FirstLoad = true;
		GameStatsManager.Load();
		FirstLoad = firstLoad;
	}

	public static void Unload()
	{
		if (m_loaded)
		{
			AdvancedGameSave = null;
			AdvancedMidGameSave = null;
			Hook obj = saveHook;
			if (obj != null)
			{
				obj.Dispose();
			}
			Hook obj2 = loadHook;
			if (obj2 != null)
			{
				obj2.Dispose();
			}
			Hook obj3 = resetHook;
			if (obj3 != null)
			{
				obj3.Dispose();
			}
			Hook obj4 = beginSessionHook;
			if (obj4 != null)
			{
				obj4.Dispose();
			}
			Hook obj5 = endSessionHook;
			if (obj5 != null)
			{
				obj5.Dispose();
			}
			Hook obj6 = clearAllStatsHook;
			if (obj6 != null)
			{
				obj6.Dispose();
			}
			Hook obj7 = deleteMidGameSaveHook;
			if (obj7 != null)
			{
				obj7.Dispose();
			}
			Hook obj8 = midgameSaveHook;
			if (obj8 != null)
			{
				obj8.Dispose();
			}
			Hook obj9 = invalidateSaveHook;
			if (obj9 != null)
			{
				obj9.Dispose();
			}
			Hook obj10 = revalidateSaveHook;
			if (obj10 != null)
			{
				obj10.Dispose();
			}
			Hook obj11 = frameDelayedInitizlizationHook;
			if (obj11 != null)
			{
				obj11.Dispose();
			}
			Hook obj12 = moveSessionStatsHook;
			if (obj12 != null)
			{
				obj12.Dispose();
			}
			Hook obj13 = prerequisiteHook;
			if (obj13 != null)
			{
				obj13.Dispose();
			}
			Hook obj14 = clearActiveGameDataHook;
			if (obj14 != null)
			{
				obj14.Dispose();
			}
			Hook obj15 = aiactorRewardsHook;
			if (obj15 != null)
			{
				obj15.Dispose();
			}
			Hook obj16 = aiactorEngagedHook;
			if (obj16 != null)
			{
				obj16.Dispose();
			}
			CustomHuntQuests.Unload();
			AdvancedGameStatsManager.Save();
			AdvancedGameStatsManager.Unload();
			BreachShopTool.Unload();
			m_loaded = false;
		}
	}

	public static bool GetFlag(CustomDungeonFlags flag)
	{
		if (!AdvancedGameStatsManager.HasInstance)
		{
			return false;
		}
		return AdvancedGameStatsManager.Instance.GetFlag(flag);
	}

	public static float GetPlayerStatValue(CustomTrackedStats stat)
	{
		if (!AdvancedGameStatsManager.HasInstance)
		{
			return 0f;
		}
		return AdvancedGameStatsManager.Instance.GetPlayerStatValue(stat);
	}

	public static float GetSessionStatValue(CustomTrackedStats stat)
	{
		if (AdvancedGameStatsManager.HasInstance && AdvancedGameStatsManager.Instance.IsInSession)
		{
			return AdvancedGameStatsManager.Instance.GetSessionStatValue(stat);
		}
		return 0f;
	}

	public static float GetCharacterStatValue(PlayableCharacters character, CustomTrackedStats stat)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		if (AdvancedGameStatsManager.HasInstance)
		{
			return AdvancedGameStatsManager.Instance.GetCharacterStatValue(character, stat);
		}
		return 0f;
	}

	public static float GetCharacterStatValue(CustomTrackedStats stat)
	{
		if (AdvancedGameStatsManager.HasInstance)
		{
			if (GameManager.HasInstance && (Object)(object)GameManager.Instance.PrimaryPlayer != (Object)null)
			{
				return AdvancedGameStatsManager.Instance.GetCharacterStatValue(stat);
			}
			return AdvancedGameStatsManager.Instance.GetCharacterStatValue((PlayableCharacters)0, stat);
		}
		return 0f;
	}

	public static bool GetCharacterSpecificFlag(CustomCharacterSpecificGungeonFlags flag)
	{
		if (AdvancedGameStatsManager.HasInstance)
		{
			if (AdvancedGameStatsManager.Instance.IsInSession)
			{
				return AdvancedGameStatsManager.Instance.GetCharacterSpecificFlag(flag);
			}
			return AdvancedGameStatsManager.Instance.GetCharacterSpecificFlag((PlayableCharacters)0, flag);
		}
		return false;
	}

	public static bool GetCharacterSpecificFlag(PlayableCharacters character, CustomCharacterSpecificGungeonFlags flag)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		if (AdvancedGameStatsManager.HasInstance)
		{
			return AdvancedGameStatsManager.Instance.GetCharacterSpecificFlag(character, flag);
		}
		return false;
	}

	public static float GetPlayerMaximum(CustomTrackedMaximums maximum)
	{
		if (AdvancedGameStatsManager.HasInstance)
		{
			return AdvancedGameStatsManager.Instance.GetPlayerMaximum(maximum);
		}
		return 0f;
	}

	public static void SetFlag(CustomDungeonFlags flag, bool value)
	{
		if (AdvancedGameStatsManager.HasInstance)
		{
			AdvancedGameStatsManager.Instance.SetFlag(flag, value);
		}
	}

	public static void SetStat(CustomTrackedStats stat, float value)
	{
		if (AdvancedGameStatsManager.HasInstance)
		{
			AdvancedGameStatsManager.Instance.SetStat(stat, value);
		}
	}

	public static void RegisterStatChange(CustomTrackedStats stat, float value)
	{
		if (AdvancedGameStatsManager.HasInstance)
		{
			AdvancedGameStatsManager.Instance.RegisterStatChange(stat, value);
		}
	}

	public static void UpdateMaximum(CustomTrackedMaximums maximum, float value)
	{
		if (AdvancedGameStatsManager.HasInstance)
		{
			AdvancedGameStatsManager.Instance.UpdateMaximum(maximum, value);
		}
	}

	public static void SetCharacterSpecificFlag(CustomCharacterSpecificGungeonFlags flag, bool value)
	{
		if (AdvancedGameStatsManager.HasInstance)
		{
			AdvancedGameStatsManager.Instance.SetCharacterSpecificFlag(flag, value);
		}
	}

	public static void SetCharacterSpecificFlag(PlayableCharacters character, CustomCharacterSpecificGungeonFlags flag, bool value)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		if (AdvancedGameStatsManager.HasInstance)
		{
			AdvancedGameStatsManager.Instance.SetCharacterSpecificFlag(character, flag, value);
		}
	}

	public static void AIActorEngagedHook(Action<AIActor, bool> orig, AIActor self, bool isReinforcement)
	{
		if (!self.HasBeenEngaged && self.SetsCustomFlagOnActivation())
		{
			AdvancedGameStatsManager.Instance.SetFlag(self.GetCustomFlagToSetOnActivation(), value: true);
		}
		orig(self, isReinforcement);
	}

	public static void AIActorRewardsHook(Action<AIActor> orig, AIActor self)
	{
		FieldInfo field = typeof(AIActor).GetField("m_hasGivenRewards", BindingFlags.Instance | BindingFlags.NonPublic);
		if (!(bool)field.GetValue(self) && !self.IsTransmogrified)
		{
			if (self.SetsCustomFlagOnDeath())
			{
				AdvancedGameStatsManager.Instance.SetFlag(self.GetCustomFlagToSetOnDeath(), value: true);
			}
			if (self.SetsCustomCharacterSpecificFlagOnDeath())
			{
				AdvancedGameStatsManager.Instance.SetCharacterSpecificFlag(self.GetCustomCharacterSpecificFlagToSetOnDeath(), value: true);
			}
		}
		orig(self);
	}

	public static bool SaveHook(Func<bool> orig)
	{
		bool result = orig();
		AdvancedGameStatsManager.Save();
		return result;
	}

	public static void LoadHook(Action orig)
	{
		AdvancedGameStatsManager.Load();
		orig();
	}

	public static void ResetHook(Action orig)
	{
		AdvancedGameStatsManager.DANGEROUS_ResetAllStats();
		orig();
	}

	public static void BeginSessionHook(Action<GameStatsManager, PlayerController> orig, GameStatsManager self, PlayerController player)
	{
		orig(self, player);
		AdvancedGameStatsManager.Instance.BeginNewSession(player);
	}

	public static void EndSessionHook(Action<GameStatsManager, bool, bool> orig, GameStatsManager self, bool recordSessionStats, bool decrementDifferentiator = true)
	{
		orig(self, recordSessionStats, decrementDifferentiator);
		AdvancedGameStatsManager.Instance.EndSession(recordSessionStats);
	}

	public static void ClearAllStatsHook(Action<GameStatsManager> orig, GameStatsManager self)
	{
		orig(self);
		AdvancedGameStatsManager.Instance.ClearAllStatsGlobal();
	}

	public static void DeleteMidGameSaveHook(Action<SaveSlot?> orig, SaveSlot? overrideSaveSlot)
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		orig(overrideSaveSlot);
		if (AdvancedGameStatsManager.HasInstance)
		{
			AdvancedGameStatsManager.Instance.midGameSaveGuid = null;
		}
		string path = string.Format(SaveManager.MidGameSave.filePattern, (!overrideSaveSlot.HasValue) ? SaveManager.CurrentSaveSlot : overrideSaveSlot.Value);
		string path2 = Path.Combine(SaveManager.SavePath, path);
		if (File.Exists(path2))
		{
			File.Delete(path2);
		}
	}

	public static void MidgameSaveHook(Action<ValidTilesets> orig, ValidTilesets tileset)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		AdvancedGameStatsManager.DoMidgameSave();
		orig(tileset);
	}

	public static void InvalidateSaveHook(Action<bool> orig, bool savestats)
	{
		AdvancedGameStatsManager.InvalidateMidgameSave(saveStats: false);
		orig(savestats);
	}

	public static void RevalidateSaveHook(Action orig)
	{
		AdvancedGameStatsManager.RevalidateMidgameSave(saveStats: false);
		orig();
	}

	public static IEnumerator FrameDelayedInitizlizationHook(Func<Dungeon, MidGameSaveData, IEnumerator> orig, Dungeon self, MidGameSaveData data)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CFrameDelayedInitizlizationHook_003Ed__32(0)
		{
			orig = orig,
			self = self,
			data = data
		};
	}

	public static GameStats MoveSessionStatsHook(Func<GameStatsManager, GameStats> orig, GameStatsManager self)
	{
		AdvancedGameStatsManager.Instance.MoveSessionStatsToSavedSessionStats();
		return orig(self);
	}

	public static bool PrerequisiteHook(Func<DungeonPrerequisite, bool> orig, DungeonPrerequisite self)
	{
		if (self is CustomDungeonPrerequisite)
		{
			return (self as CustomDungeonPrerequisite).CheckConditionsFulfilled();
		}
		return orig(self);
	}

	public static void ClearActiveGameDataHook(Action<GameManager, bool, bool> orig, GameManager self, bool destroyGameManager, bool endSession)
	{
		orig(self, destroyGameManager, endSession);
		OnActiveGameDataCleared?.Invoke(self, destroyGameManager, endSession);
	}
}
