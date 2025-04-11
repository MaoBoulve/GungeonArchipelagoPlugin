using System;
using System.Collections.Generic;
using System.Reflection;
using MonoMod.RuntimeDetour;
using UnityEngine;

namespace SaveAPI;

public static class CustomHuntQuests
{
	private static bool m_loaded;

	private static Hook huntProgressLoadedHook;

	private static Hook huntProgressCompleteHook;

	private static Hook huntProgressQuestCompleteHook;

	private static Hook huntProgressNextQuestHook;

	private static Hook huntProgressProcessKillHook;

	private static Hook huntQuestCompleteHook;

	private static Hook huntQuestUnlockRewardsHook;

	public static MonsterHuntData HuntData;

	public static List<MonsterHuntQuest> addedOrderedQuests;

	public static List<MonsterHuntQuest> addedProceduralQuests;

	public static void DoSetup()
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected O, but got Unknown
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Expected O, but got Unknown
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected O, but got Unknown
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0187: Expected O, but got Unknown
		if (!m_loaded)
		{
			HuntData = (MonsterHuntData)BraveResources.Load("Monster Hunt Data", ".asset");
			huntProgressLoadedHook = new Hook((MethodBase)typeof(MonsterHuntProgress).GetMethod("OnLoaded"), typeof(CustomHuntQuests).GetMethod("HuntProgressLoadedHook"));
			huntProgressCompleteHook = new Hook((MethodBase)typeof(MonsterHuntProgress).GetMethod("Complete"), typeof(CustomHuntQuests).GetMethod("HuntProgressCompleteHook"));
			huntProgressQuestCompleteHook = new Hook((MethodBase)typeof(MonsterHuntProgress).GetMethod("IsQuestComplete"), typeof(CustomHuntQuests).GetMethod("HuntProgressQuestCompleteHook"));
			huntProgressNextQuestHook = new Hook((MethodBase)typeof(MonsterHuntProgress).GetMethod("TriggerNextQuest"), typeof(CustomHuntQuests).GetMethod("HuntProgressNextQuestHook"));
			huntProgressProcessKillHook = new Hook((MethodBase)typeof(MonsterHuntProgress).GetMethod("ProcessKill"), typeof(CustomHuntQuests).GetMethod("HuntProgressProcessKillHook"));
			huntQuestCompleteHook = new Hook((MethodBase)typeof(MonsterHuntQuest).GetMethod("IsQuestComplete"), typeof(CustomHuntQuests).GetMethod("HuntQuestCompleteHook"));
			huntQuestUnlockRewardsHook = new Hook((MethodBase)typeof(MonsterHuntQuest).GetMethod("UnlockRewards"), typeof(CustomHuntQuests).GetMethod("HuntQuestUnlockRewardsHook"));
			m_loaded = true;
		}
	}

	public static void Unload()
	{
		if (!m_loaded)
		{
			return;
		}
		if (addedOrderedQuests != null)
		{
			foreach (MonsterHuntQuest addedOrderedQuest in addedOrderedQuests)
			{
				if (HuntData.OrderedQuests.Contains(addedOrderedQuest))
				{
					HuntData.OrderedQuests.Remove(addedOrderedQuest);
				}
			}
			addedOrderedQuests.Clear();
			addedOrderedQuests = null;
		}
		if (addedProceduralQuests != null)
		{
			foreach (MonsterHuntQuest addedProceduralQuest in addedProceduralQuests)
			{
				if (HuntData.ProceduralQuests.Contains(addedProceduralQuest))
				{
					HuntData.ProceduralQuests.Remove(addedProceduralQuest);
				}
			}
			addedProceduralQuests.Clear();
			addedProceduralQuests = null;
		}
		if (GameStatsManager.HasInstance && GameStatsManager.Instance.huntProgress != null)
		{
			GameStatsManager.Instance.huntProgress.OnLoaded();
		}
		else
		{
			int? num = null;
			if (AdvancedGameStatsManager.HasInstance)
			{
				num = AdvancedGameStatsManager.Instance.cachedHuntIndex;
				AdvancedGameStatsManager.Save();
			}
			GameStatsManager.Load();
			if (num.HasValue && AdvancedGameStatsManager.HasInstance)
			{
				AdvancedGameStatsManager.Instance.cachedHuntIndex = num.Value;
			}
		}
		HuntData = null;
		Hook obj = huntProgressLoadedHook;
		if (obj != null)
		{
			obj.Dispose();
		}
		Hook obj2 = huntProgressCompleteHook;
		if (obj2 != null)
		{
			obj2.Dispose();
		}
		Hook obj3 = huntProgressNextQuestHook;
		if (obj3 != null)
		{
			obj3.Dispose();
		}
		Hook obj4 = huntProgressProcessKillHook;
		if (obj4 != null)
		{
			obj4.Dispose();
		}
		Hook obj5 = huntQuestCompleteHook;
		if (obj5 != null)
		{
			obj5.Dispose();
		}
		Hook obj6 = huntQuestUnlockRewardsHook;
		if (obj6 != null)
		{
			obj6.Dispose();
		}
		Hook obj7 = huntProgressQuestCompleteHook;
		if (obj7 != null)
		{
			obj7.Dispose();
		}
		m_loaded = false;
	}

	public static void HuntProgressProcessKillHook(Action<MonsterHuntProgress, AIActor> orig, MonsterHuntProgress self, AIActor target)
	{
		if (self.ActiveQuest == null || (self.CurrentActiveMonsterHuntProgress < self.ActiveQuest.NumberKillsRequired && (!(self.ActiveQuest is CustomHuntQuest) || (self.ActiveQuest as CustomHuntQuest).IsEnemyValid(target, self))))
		{
			orig(self, target);
		}
	}

	public static MonsterHuntQuest FindNextQuestNoProcedural()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		for (int i = 0; i < HuntData.OrderedQuests.Count; i++)
		{
			if (!GameStatsManager.Instance.GetFlag(HuntData.OrderedQuests[i].QuestFlag))
			{
				return HuntData.OrderedQuests[i];
			}
		}
		return null;
	}

	public static int HuntProgressNextQuestHook(Func<MonsterHuntProgress, int> orig, MonsterHuntProgress self)
	{
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Invalid comparison between Unknown and I4
		MonsterHuntQuest val = null;
		int num = 0;
		for (int i = 0; i < HuntData.OrderedQuests.Count; i++)
		{
			if (HuntData.OrderedQuests[i] != null && !HuntData.OrderedQuests[i].IsQuestComplete())
			{
				val = HuntData.OrderedQuests[i];
				num = i;
				break;
			}
		}
		List<MonsterHuntQuest> orderedQuests = HuntData.OrderedQuests;
		List<MonsterHuntQuest> list = new List<MonsterHuntQuest>();
		for (int j = 0; j < orderedQuests.Count; j++)
		{
			if (orderedQuests[j] != null && (int)orderedQuests[j].QuestFlag > 0)
			{
				list.Add(orderedQuests[j]);
			}
		}
		HuntData.OrderedQuests = list;
		if (self.ActiveQuest != null || self.ActiveQuest == null)
		{
		}
		int result = orig(self);
		MonsterHuntQuest val2 = FindNextQuestNoProcedural();
		HuntData.OrderedQuests = orderedQuests;
		if (self.ActiveQuest != null && val2 != null && HuntData.OrderedQuests.IndexOf(self.ActiveQuest) != self.CurrentActiveMonsterHuntID)
		{
			self.CurrentActiveMonsterHuntID = HuntData.OrderedQuests.IndexOf(self.ActiveQuest);
		}
		if (val != null && val2 == null)
		{
			self.ActiveQuest = val;
			self.CurrentActiveMonsterHuntID = num;
			self.CurrentActiveMonsterHuntProgress = 0;
		}
		else if (val != null && val2 != null && num < self.CurrentActiveMonsterHuntID)
		{
			self.ActiveQuest = val;
			self.CurrentActiveMonsterHuntID = num;
			self.CurrentActiveMonsterHuntProgress = 0;
		}
		return result;
	}

	public static void HuntProgressCompleteHook(Action<MonsterHuntProgress> orig, MonsterHuntProgress self)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Invalid comparison between Unknown and I4
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		if (self.ActiveQuest != null)
		{
		}
		GungeonFlags questFlag = self.ActiveQuest.QuestFlag;
		bool flag = GameStatsManager.Instance.GetFlag((GungeonFlags)1);
		if (self.ActiveQuest is CustomHuntQuest)
		{
			(self.ActiveQuest as CustomHuntQuest).Complete();
			if ((int)self.ActiveQuest.QuestFlag == 0)
			{
				self.ActiveQuest.QuestFlag = (GungeonFlags)1;
			}
		}
		orig(self);
		GameStatsManager.Instance.SetFlag((GungeonFlags)1, flag);
		self.ActiveQuest.QuestFlag = questFlag;
		if (self.ActiveQuest == null)
		{
		}
	}

	public static bool HuntQuestCompleteHook(Func<MonsterHuntQuest, bool> orig, MonsterHuntQuest self)
	{
		if (self is CustomHuntQuest)
		{
			return (self as CustomHuntQuest).IsQuestComplete();
		}
		return orig(self);
	}

	public static bool HuntProgressQuestCompleteHook(Func<MonsterHuntProgress, bool> orig, MonsterHuntProgress self)
	{
		if (self.ActiveQuest is CustomHuntQuest)
		{
			return (self.ActiveQuest as CustomHuntQuest).IsQuestComplete();
		}
		return orig(self);
	}

	public static void HuntQuestUnlockRewardsHook(Action<MonsterHuntQuest> orig, MonsterHuntQuest self)
	{
		if (self is CustomHuntQuest)
		{
			(self as CustomHuntQuest).UnlockRewards();
		}
		else
		{
			orig(self);
		}
	}

	public static void HuntProgressLoadedHook(Action<MonsterHuntProgress> orig, MonsterHuntProgress self)
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Expected O, but got Unknown
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Expected O, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected O, but got Unknown
		if (self.ActiveQuest != null)
		{
		}
		if (GameManager.HasInstance)
		{
			if (GameManager.Instance.platformInterface == null)
			{
				if (PlatformInterfaceSteam.IsSteamBuild())
				{
					GameManager.Instance.platformInterface = (PlatformInterface)new PlatformInterfaceSteam();
				}
				else if (PlatformInterfaceGalaxy.IsGalaxyBuild())
				{
					GameManager.Instance.platformInterface = (PlatformInterface)new PlatformInterfaceGalaxy();
				}
				else
				{
					GameManager.Instance.platformInterface = (PlatformInterface)new PlatformInterfaceGenericPC();
				}
			}
			GameManager.Instance.platformInterface.Start();
		}
		FieldInfo field = typeof(GameStatsManager).GetField("s_frifleHuntFlags", BindingFlags.Static | BindingFlags.NonPublic);
		FieldInfo field2 = typeof(GameStatsManager).GetField("s_pastFlags", BindingFlags.Static | BindingFlags.NonPublic);
		FieldInfo field3 = typeof(GameStatsManager).GetField("s_npcFoyerFlags", BindingFlags.Static | BindingFlags.NonPublic);
		if (field2.GetValue(null) == null)
		{
			List<GungeonFlags> list = new List<GungeonFlags>();
			list.Add((GungeonFlags)18001);
			list.Add((GungeonFlags)18002);
			list.Add((GungeonFlags)18003);
			list.Add((GungeonFlags)18004);
			field2.SetValue(null, list);
		}
		if (field3.GetValue(null) == null)
		{
			List<GungeonFlags> list2 = new List<GungeonFlags>();
			list2.Add((GungeonFlags)40005);
			list2.Add((GungeonFlags)27505);
			list2.Add((GungeonFlags)55505);
			list2.Add((GungeonFlags)24505);
			list2.Add((GungeonFlags)2003);
			list2.Add((GungeonFlags)45500);
			list2.Add((GungeonFlags)30005);
			list2.Add((GungeonFlags)25506);
			list2.Add((GungeonFlags)28501);
			list2.Add((GungeonFlags)35051);
			field3.SetValue(null, list2);
		}
		if (field.GetValue(null) == null)
		{
			List<GungeonFlags> list3 = new List<GungeonFlags>();
			list3.Add((GungeonFlags)35101);
			list3.Add((GungeonFlags)35102);
			list3.Add((GungeonFlags)35103);
			list3.Add((GungeonFlags)35104);
			list3.Add((GungeonFlags)35105);
			list3.Add((GungeonFlags)35106);
			list3.Add((GungeonFlags)35107);
			list3.Add((GungeonFlags)35108);
			list3.Add((GungeonFlags)35109);
			list3.Add((GungeonFlags)35110);
			list3.Add((GungeonFlags)35111);
			list3.Add((GungeonFlags)35112);
			list3.Add((GungeonFlags)35113);
			list3.Add((GungeonFlags)35114);
			list3.Add((GungeonFlags)35500);
			field.SetValue(null, list3);
		}
		MonsterHuntQuest val = null;
		bool flag = GameStatsManager.Instance.GetFlag((GungeonFlags)35500);
		foreach (MonsterHuntQuest orderedQuest in HuntData.OrderedQuests)
		{
			if (orderedQuest != null && !orderedQuest.IsReallyCompleted())
			{
				val = orderedQuest;
			}
		}
		if (val != null)
		{
			GameStatsManager.Instance.SetFlag((GungeonFlags)35500, false);
		}
		if (SaveAPIManager.IsFirstLoad)
		{
			if (!AdvancedGameStatsManager.HasInstance)
			{
				AdvancedGameStatsManager.Load();
			}
			AdvancedGameStatsManager.Instance.cachedHuntIndex = self.CurrentActiveMonsterHuntID;
		}
		else
		{
			if (!AdvancedGameStatsManager.HasInstance)
			{
				AdvancedGameStatsManager.Load();
			}
			if (AdvancedGameStatsManager.HasInstance && self.CurrentActiveMonsterHuntID == -1 && AdvancedGameStatsManager.Instance.cachedHuntIndex != -1)
			{
				if (GameStatsManager.Instance.GetFlag((GungeonFlags)35500) && GameStatsManager.Instance.GetFlag((GungeonFlags)36015))
				{
					if (AdvancedGameStatsManager.Instance.cachedHuntIndex >= 0 && AdvancedGameStatsManager.Instance.cachedHuntIndex < HuntData.ProceduralQuests.Count)
					{
						self.CurrentActiveMonsterHuntID = AdvancedGameStatsManager.Instance.cachedHuntIndex;
						AdvancedGameStatsManager.Instance.cachedHuntIndex = -1;
					}
				}
				else if (AdvancedGameStatsManager.Instance.cachedHuntIndex >= 0 || AdvancedGameStatsManager.Instance.cachedHuntIndex < HuntData.OrderedQuests.Count)
				{
					self.CurrentActiveMonsterHuntID = AdvancedGameStatsManager.Instance.cachedHuntIndex;
					AdvancedGameStatsManager.Instance.cachedHuntIndex = -1;
				}
			}
		}
		orig(self);
		if (val == null && !GameStatsManager.Instance.GetFlag((GungeonFlags)35500))
		{
			flag = true;
			List<GungeonFlags> list4 = (List<GungeonFlags>)field.GetValue(null);
			if (list4 != null)
			{
				int num = 0;
				for (int i = 0; i < list4.Count; i++)
				{
					num++;
				}
				if ((Object)(object)GameManager.Instance == (Object)null && GameManager.Instance.platformInterface == null)
				{
					GameManager.Instance.platformInterface.SetStat((PlatformStat)7, num);
				}
			}
		}
		GameStatsManager.Instance.SetFlag((GungeonFlags)35500, flag);
		if (self.ActiveQuest == null)
		{
		}
	}

	public static MonsterHuntQuest AddProceduralQuest(List<string> questIntroConversation, string targetEnemyName, List<string> targetEnemyGuids, int numberKillsRequired, JammedEnemyState requiredState = JammedEnemyState.NoCheck, Func<AIActor, MonsterHuntProgress, bool> validTargetCheck = null, List<GungeonFlags> rewardFlags = null, List<CustomDungeonFlags> customRewardFlags = null)
	{
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		string text = "#CUSTOMQUEST_PROCEDURAL_" + Guid.NewGuid().ToString().ToUpper() + "_" + Guid.NewGuid().ToString().ToUpper();
		string text2 = text + "_INTRO";
		string text3 = text + "_TARGET";
		Databases.Strings.Core.SetComplex(text2, questIntroConversation.ToArray());
		Databases.Strings.Enemies.Set(text3, targetEnemyName);
		return AddProceduralQuest((MonsterHuntQuest)(object)new CustomHuntQuest
		{
			QuestFlag = (GungeonFlags)0,
			QuestIntroString = text2,
			TargetStringKey = text3,
			ValidTargetMonsterGuids = SaveTools.CloneList(targetEnemyGuids),
			FlagsToSetUponReward = ((rewardFlags != null) ? SaveTools.CloneList(rewardFlags) : new List<GungeonFlags>()),
			CustomFlagsToSetUponReward = ((customRewardFlags != null) ? SaveTools.CloneList(customRewardFlags) : new List<CustomDungeonFlags>()),
			NumberKillsRequired = numberKillsRequired,
			RequiredEnemyState = requiredState,
			ValidTargetCheck = validTargetCheck,
			CustomQuestFlag = CustomDungeonFlags.NONE
		});
	}

	public static MonsterHuntQuest AddProceduralQuest(List<string> questIntroConversation, string targetEnemyName, List<AIActor> targetEnemies, int numberKillsRequired, JammedEnemyState requiredState = JammedEnemyState.NoCheck, Func<AIActor, MonsterHuntProgress, bool> validTargetCheck = null, List<GungeonFlags> rewardFlags = null, List<CustomDungeonFlags> customRewardFlags = null)
	{
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		string text = "#CUSTOMQUEST_PROCEDURAL_" + Guid.NewGuid().ToString().ToUpper() + "_" + Guid.NewGuid().ToString().ToUpper();
		string text2 = text + "_INTRO";
		string text3 = text + "_TARGET";
		Databases.Strings.Core.SetComplex(text2, questIntroConversation.ToArray());
		Databases.Strings.Enemies.Set(text3, targetEnemyName);
		return AddProceduralQuest((MonsterHuntQuest)(object)new CustomHuntQuest
		{
			QuestFlag = (GungeonFlags)0,
			QuestIntroString = text2,
			TargetStringKey = text3,
			ValidTargetMonsterGuids = targetEnemies.Convert((AIActor enemy) => enemy.EnemyGuid),
			FlagsToSetUponReward = ((rewardFlags != null) ? SaveTools.CloneList(rewardFlags) : new List<GungeonFlags>()),
			CustomFlagsToSetUponReward = ((customRewardFlags != null) ? SaveTools.CloneList(customRewardFlags) : new List<CustomDungeonFlags>()),
			NumberKillsRequired = numberKillsRequired,
			RequiredEnemyState = requiredState,
			ValidTargetCheck = validTargetCheck,
			CustomQuestFlag = CustomDungeonFlags.NONE
		});
	}

	public static MonsterHuntQuest AddQuest(CustomDungeonFlags questFlag, List<string> questIntroConversation, string targetEnemyName, List<string> targetEnemyGuids, int numberKillsRequired, List<GungeonFlags> rewardFlags = null, List<CustomDungeonFlags> customRewardFlags = null, JammedEnemyState requiredState = JammedEnemyState.NoCheck, Func<AIActor, MonsterHuntProgress, bool> validTargetCheck = null, int? index = null)
	{
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		string text = "#CUSTOMQUEST_" + questFlag.ToString() + "_" + Guid.NewGuid().ToString().ToUpper();
		string text2 = text + "_INTRO";
		string text3 = text + "_TARGET";
		Databases.Strings.Core.SetComplex(text2, questIntroConversation.ToArray());
		Databases.Strings.Enemies.Set(text3, targetEnemyName);
		return AddQuest((MonsterHuntQuest)(object)new CustomHuntQuest
		{
			QuestFlag = (GungeonFlags)0,
			QuestIntroString = text2,
			TargetStringKey = text3,
			ValidTargetMonsterGuids = SaveTools.CloneList(targetEnemyGuids),
			FlagsToSetUponReward = ((rewardFlags != null) ? SaveTools.CloneList(rewardFlags) : new List<GungeonFlags>()),
			CustomFlagsToSetUponReward = ((customRewardFlags != null) ? SaveTools.CloneList(customRewardFlags) : new List<CustomDungeonFlags>()),
			NumberKillsRequired = numberKillsRequired,
			RequiredEnemyState = requiredState,
			ValidTargetCheck = validTargetCheck,
			CustomQuestFlag = questFlag
		}, index);
	}

	public static MonsterHuntQuest AddQuest(GungeonFlags questFlag, List<string> questIntroConversation, string targetEnemyName, List<string> targetEnemyGuids, int numberKillsRequired, List<GungeonFlags> rewardFlags = null, List<CustomDungeonFlags> customRewardFlags = null, JammedEnemyState requiredState = JammedEnemyState.NoCheck, Func<AIActor, MonsterHuntProgress, bool> validTargetCheck = null, int? index = null)
	{
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		string text = "#CUSTOMQUEST_" + ((object)(GungeonFlags)(ref questFlag)/*cast due to .constrained prefix*/).ToString() + "_" + Guid.NewGuid().ToString().ToUpper();
		string text2 = text + "_INTRO";
		string text3 = text + "_TARGET";
		Databases.Strings.Core.SetComplex(text2, questIntroConversation.ToArray());
		Databases.Strings.Enemies.Set(text3, targetEnemyName);
		return AddQuest((MonsterHuntQuest)(object)new CustomHuntQuest
		{
			QuestFlag = questFlag,
			QuestIntroString = text2,
			TargetStringKey = text3,
			ValidTargetMonsterGuids = SaveTools.CloneList(targetEnemyGuids),
			FlagsToSetUponReward = ((rewardFlags != null) ? SaveTools.CloneList(rewardFlags) : new List<GungeonFlags>()),
			CustomFlagsToSetUponReward = ((customRewardFlags != null) ? SaveTools.CloneList(customRewardFlags) : new List<CustomDungeonFlags>()),
			NumberKillsRequired = numberKillsRequired,
			RequiredEnemyState = requiredState,
			ValidTargetCheck = validTargetCheck,
			CustomQuestFlag = CustomDungeonFlags.NONE
		}, index);
	}

	public static MonsterHuntQuest AddQuest(CustomDungeonFlags questFlag, List<string> questIntroConversation, string targetEnemyName, List<AIActor> targetEnemies, int numberKillsRequired, List<GungeonFlags> rewardFlags = null, List<CustomDungeonFlags> customRewardFlags = null, JammedEnemyState requiredState = JammedEnemyState.NoCheck, Func<AIActor, MonsterHuntProgress, bool> validTargetCheck = null, int? index = null)
	{
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		string text = "#CUSTOMQUEST_" + questFlag.ToString() + "_" + Guid.NewGuid().ToString().ToUpper();
		string text2 = text + "_INTRO";
		string text3 = text + "_TARGET";
		Databases.Strings.Core.SetComplex(text2, questIntroConversation.ToArray());
		Databases.Strings.Enemies.Set(text3, targetEnemyName);
		return AddQuest((MonsterHuntQuest)(object)new CustomHuntQuest
		{
			QuestFlag = (GungeonFlags)0,
			QuestIntroString = text2,
			TargetStringKey = text3,
			ValidTargetMonsterGuids = targetEnemies.Convert((AIActor enemy) => enemy.EnemyGuid),
			FlagsToSetUponReward = ((rewardFlags != null) ? SaveTools.CloneList(rewardFlags) : new List<GungeonFlags>()),
			CustomFlagsToSetUponReward = ((customRewardFlags != null) ? SaveTools.CloneList(customRewardFlags) : new List<CustomDungeonFlags>()),
			NumberKillsRequired = numberKillsRequired,
			RequiredEnemyState = requiredState,
			ValidTargetCheck = validTargetCheck,
			CustomQuestFlag = questFlag
		}, index);
	}

	public static MonsterHuntQuest AddQuest(GungeonFlags questFlag, List<string> questIntroConversation, string targetEnemyName, List<AIActor> targetEnemies, int numberKillsRequired, List<GungeonFlags> rewardFlags = null, List<CustomDungeonFlags> customRewardFlags = null, JammedEnemyState requiredState = JammedEnemyState.NoCheck, Func<AIActor, MonsterHuntProgress, bool> validTargetCheck = null, int? index = null)
	{
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		string text = "#CUSTOMQUEST_" + ((object)(GungeonFlags)(ref questFlag)/*cast due to .constrained prefix*/).ToString() + "_" + Guid.NewGuid().ToString().ToUpper();
		string text2 = text + "_INTRO";
		string text3 = text + "_TARGET";
		Databases.Strings.Core.SetComplex(text2, questIntroConversation.ToArray());
		Databases.Strings.Enemies.Set(text3, targetEnemyName);
		return AddQuest((MonsterHuntQuest)(object)new CustomHuntQuest
		{
			QuestFlag = questFlag,
			QuestIntroString = text2,
			TargetStringKey = text3,
			ValidTargetMonsterGuids = targetEnemies.Convert((AIActor enemy) => enemy.EnemyGuid),
			FlagsToSetUponReward = ((rewardFlags != null) ? SaveTools.CloneList(rewardFlags) : new List<GungeonFlags>()),
			CustomFlagsToSetUponReward = ((customRewardFlags != null) ? SaveTools.CloneList(customRewardFlags) : new List<CustomDungeonFlags>()),
			NumberKillsRequired = numberKillsRequired,
			RequiredEnemyState = requiredState,
			ValidTargetCheck = validTargetCheck,
			CustomQuestFlag = CustomDungeonFlags.NONE
		}, index);
	}

	public static MonsterHuntQuest AddQuest(MonsterHuntQuest quest, int? index = null)
	{
		if ((Object)(object)HuntData == (Object)null)
		{
			DoSetup();
		}
		if (!index.HasValue)
		{
			HuntData.OrderedQuests.Add(quest);
		}
		else if (index.Value < 0)
		{
			HuntData.OrderedQuests.Add(quest);
		}
		else
		{
			HuntData.OrderedQuests.InsertOrAdd(index.Value, quest);
		}
		if (GameStatsManager.HasInstance && GameStatsManager.Instance.huntProgress != null)
		{
			GameStatsManager.Instance.huntProgress.OnLoaded();
		}
		else
		{
			int? num = null;
			if (AdvancedGameStatsManager.HasInstance)
			{
				num = AdvancedGameStatsManager.Instance.cachedHuntIndex;
				AdvancedGameStatsManager.Save();
			}
			GameStatsManager.Load();
			if (num.HasValue && AdvancedGameStatsManager.HasInstance)
			{
				AdvancedGameStatsManager.Instance.cachedHuntIndex = num.Value;
			}
		}
		if (addedOrderedQuests == null)
		{
			addedOrderedQuests = new List<MonsterHuntQuest>();
		}
		addedOrderedQuests.Add(quest);
		return quest;
	}

	public static MonsterHuntQuest AddProceduralQuest(MonsterHuntQuest quest)
	{
		if ((Object)(object)HuntData == (Object)null)
		{
			DoSetup();
		}
		HuntData.ProceduralQuests.Add(quest);
		if (GameStatsManager.HasInstance && GameStatsManager.Instance.huntProgress != null)
		{
			GameStatsManager.Instance.huntProgress.OnLoaded();
		}
		else
		{
			int? num = null;
			if (AdvancedGameStatsManager.HasInstance)
			{
				num = AdvancedGameStatsManager.Instance.cachedHuntIndex;
				AdvancedGameStatsManager.Save();
			}
			GameStatsManager.Load();
			if (num.HasValue && AdvancedGameStatsManager.HasInstance)
			{
				AdvancedGameStatsManager.Instance.cachedHuntIndex = num.Value;
			}
		}
		if (addedProceduralQuests == null)
		{
			addedProceduralQuests = new List<MonsterHuntQuest>();
		}
		addedProceduralQuests.Add(quest);
		return quest;
	}
}
