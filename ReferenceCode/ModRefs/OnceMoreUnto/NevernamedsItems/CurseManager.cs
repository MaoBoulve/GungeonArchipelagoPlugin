using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Dungeonator;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class CurseManager
{
	public class CurseData
	{
		public string curseName = null;

		public string curseSubtitle = null;

		public int curseIconId = -1;
	}

	[CompilerGenerated]
	private sealed class _003CDoCursePopups_003Ed__7 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		private List<CurseData>.Enumerator _003C_003Es__1;

		private CurseData _003Ccurse_003E5__2;

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
		public _003CDoCursePopups_003Ed__7(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003C_003Es__1 = default(List<CurseData>.Enumerator);
			_003Ccurse_003E5__2 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_0026: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = (object)new WaitForSeconds(1f);
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				if (CurrentActiveCurses.Count > 0)
				{
					_003C_003Es__1 = CurrentActiveCurses.GetEnumerator();
					try
					{
						while (_003C_003Es__1.MoveNext())
						{
							_003Ccurse_003E5__2 = _003C_003Es__1.Current;
							Debug.Log((object)("CursePopup Processed: " + _003Ccurse_003E5__2.curseName));
							DoSpecificCursePopup(_003Ccurse_003E5__2.curseName, _003Ccurse_003E5__2.curseSubtitle, _003Ccurse_003E5__2.curseIconId);
							_003Ccurse_003E5__2 = null;
						}
					}
					finally
					{
						((IDisposable)_003C_003Es__1/*cast due to .constrained prefix*/).Dispose();
					}
					_003C_003Es__1 = default(List<CurseData>.Enumerator);
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

	private static tk2dSpriteCollectionData CurseIconCollection;

	private static GameObject VFXScapegoat;

	public static bool levelOnCooldown;

	public static List<CurseData> CurrentActiveCurses;

	public static List<CurseData> CursePrefabs;

	public static List<string> previousCursesThisRun;

	public static List<string> bannedCursesThisRun;

	public static List<string> cursesLastFloor;

	public static event Action PostNewLevelCurseProcessing;

	public static void Init()
	{
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected O, but got Unknown
		CurrentActiveCurses = new List<CurseData>();
		CursePrefabs = new List<CurseData>();
		CustomActions.OnRunStart = (Action<PlayerController, PlayerController, GameMode>)Delegate.Combine(CustomActions.OnRunStart, new Action<PlayerController, PlayerController, GameMode>(OnNewRun));
		CustomActions.PostDungeonTrueStart = (Action<Dungeon>)Delegate.Combine(CustomActions.PostDungeonTrueStart, new Action<Dungeon>(LevelLoaded));
		CurseEffects.Init();
		VFXScapegoat = new GameObject("CurseVFXScapegoat");
		VFXScapegoat.gameObject.SetActive(false);
		Object.DontDestroyOnLoad((Object)(object)VFXScapegoat);
		CurseIconCollection = SpriteBuilder.ConstructCollection(VFXScapegoat, "CurseIcon_Collection", false);
		Object.DontDestroyOnLoad((Object)(object)CurseIconCollection);
		CurseData curseData = new CurseData();
		curseData.curseName = "Curse of Infestation";
		curseData.curseSubtitle = "They crawl beneath the surface";
		curseData.curseIconId = SpriteBuilder.AddSpriteToCollection("NevernamedsItems/Resources/CurseIcons/infestation_icon", CurseIconCollection, (Assembly)null);
		CursePrefabs.Add(curseData);
		CurseData curseData2 = new CurseData();
		curseData2.curseName = "Curse of Sludge";
		curseData2.curseSubtitle = "You. Will. Love. My... Toxic love";
		curseData2.curseIconId = SpriteBuilder.AddSpriteToCollection("NevernamedsItems/Resources/CurseIcons/sludge_icon", CurseIconCollection, (Assembly)null);
		CursePrefabs.Add(curseData2);
		CurseData curseData3 = new CurseData();
		curseData3.curseName = "Curse of The Hive";
		curseData3.curseSubtitle = "You hear a faint buzzing";
		curseData3.curseIconId = SpriteBuilder.AddSpriteToCollection("NevernamedsItems/Resources/CurseIcons/hive_icon", CurseIconCollection, (Assembly)null);
		CursePrefabs.Add(curseData3);
		CurseData curseData4 = new CurseData();
		curseData4.curseName = "Curse of The Flames";
		curseData4.curseSubtitle = "Cannot live with me.";
		curseData4.curseIconId = SpriteBuilder.AddSpriteToCollection("NevernamedsItems/Resources/CurseIcons/flames_icon", CurseIconCollection, (Assembly)null);
		CursePrefabs.Add(curseData4);
		CurseData curseData5 = new CurseData();
		curseData5.curseName = "Curse of Butterfingers";
		curseData5.curseSubtitle = "Be careful not to slip up";
		curseData5.curseIconId = SpriteBuilder.AddSpriteToCollection("NevernamedsItems/Resources/CurseIcons/butterfingers_icon", CurseIconCollection, (Assembly)null);
		CursePrefabs.Add(curseData5);
		CurseData curseData6 = new CurseData();
		curseData6.curseName = "Curse of Darkness";
		curseData6.curseSubtitle = "Spirit of the Night";
		curseData6.curseIconId = SpriteBuilder.AddSpriteToCollection("NevernamedsItems/Resources/CurseIcons/darkness_icon", CurseIconCollection, (Assembly)null);
		CursePrefabs.Add(curseData6);
	}

	public static void OnNewRun(PlayerController player, PlayerController p2, GameMode mode)
	{
		cursesLastFloor = new List<string>();
		bannedCursesThisRun = new List<string>();
		previousCursesThisRun = new List<string>();
		RemoveAllCurses();
	}

	public static void LevelLoaded(Dungeon instance)
	{
		if (cursesLastFloor == null)
		{
			cursesLastFloor = new List<string>();
		}
		foreach (CurseData currentActiveCurse in CurrentActiveCurses)
		{
			cursesLastFloor.Add(currentActiveCurse.curseName);
		}
		RemoveAllCurses();
		float combinedPlayersStatAmount = GameManagerUtility.GetCombinedPlayersStatAmount(GameManager.Instance, (StatType)14);
		float value = Random.value;
		float num = 0.0666f;
		Debug.Log((object)$"Running Curse Check on Floor Load | Random ({value}) | Required ({combinedPlayersStatAmount * num}) | CurseTotal ({combinedPlayersStatAmount})");
		if (!SaveAPIManager.GetFlag(CustomDungeonFlags.CURSES_DISABLED) && Random.value <= combinedPlayersStatAmount * num)
		{
			float playerStatValue = GameStatsManager.Instance.GetPlayerStatValue((TrackedStats)70);
			if (playerStatValue > 0f)
			{
				AddRandomCurse();
			}
		}
		if (CurseManager.PostNewLevelCurseProcessing != null)
		{
			CurseManager.PostNewLevelCurseProcessing();
		}
		InherentPostLevelCurseProcessing();
		((MonoBehaviour)GameManager.Instance).StartCoroutine(DoCursePopups());
	}

	public static void AddRandomCurse(bool doPopup = false)
	{
		List<CurseData> list = new List<CurseData>();
		list.AddRange(CursePrefabs);
		if (CurrentActiveCurses.Count > 0)
		{
			for (int num = list.Count - 1; num >= 0; num--)
			{
				if (CurseIsActive(list[num].curseName))
				{
					list.RemoveAt(num);
				}
				else if (cursesLastFloor != null && cursesLastFloor.Contains(list[num].curseName))
				{
					list.RemoveAt(num);
				}
				else if (bannedCursesThisRun != null && bannedCursesThisRun.Contains(list[num].curseName))
				{
					list.RemoveAt(num);
				}
			}
		}
		if (list.Count > 0)
		{
			CurseData curseData = BraveUtility.RandomElement<CurseData>(list);
			AddCurse(curseData.curseName, doPopup);
		}
	}

	private static IEnumerator DoCursePopups()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CDoCursePopups_003Ed__7(0);
	}

	private static void DoSpecificCursePopup(string cursename, string curseSubtext, int id)
	{
		GameUIRoot.Instance.notificationController.DoCustomNotification(cursename, curseSubtext, CurseIconCollection, id, (NotificationColor)2, true, false);
	}

	public static void AddCurse(string CurseName, bool dopopup = false)
	{
		if (CurseIsActive(CurseName))
		{
			Debug.LogWarning((object)("Attempted to Add Curse (" + CurseName + ") but it was already active!"));
			return;
		}
		CurseData curseData = null;
		foreach (CurseData cursePrefab in CursePrefabs)
		{
			if (cursePrefab.curseName == CurseName)
			{
				curseData = cursePrefab;
			}
		}
		if (!GameManagerUtility.AnyPlayerHasPickupID(GameManager.Instance, HoleyWater.HoleyWaterID) || GameManagerUtility.AnyPlayerHasActiveSynergy(GameManager.Instance, "The Last Crusade"))
		{
			CurrentActiveCurses.Add(curseData);
			if (previousCursesThisRun == null)
			{
				previousCursesThisRun = new List<string>();
			}
			if (previousCursesThisRun.Contains(curseData.curseName))
			{
				if (bannedCursesThisRun == null)
				{
					bannedCursesThisRun = new List<string>();
				}
				bannedCursesThisRun.Add(curseData.curseName);
			}
			else
			{
				previousCursesThisRun.Add(curseData.curseName);
			}
			Debug.Log((object)("Added New Curse: " + curseData.curseName + " (Popup: " + dopopup + ")"));
			if (dopopup)
			{
				DoSpecificCursePopup(CurseName, curseData.curseSubtitle, curseData.curseIconId);
			}
		}
		InherentPostLevelCurseProcessing();
	}

	private static void InherentPostLevelCurseProcessing()
	{
		if (CurseIsActive("Curse of Darkness") && !CustomDarknessHandler.isDark)
		{
			if (GameManagerUtility.AnyPlayerHasActiveSynergy(GameManager.Instance, "The Last Crusade"))
			{
				Minimap.Instance.RevealAllRooms(false);
			}
			else
			{
				CustomDarknessHandler.shouldBeDark.SetOverride("DarknessCurse", true, (float?)null);
			}
		}
	}

	public static void RemoveCurse(string name)
	{
		if (!CurseIsActive(name))
		{
			return;
		}
		for (int num = CurrentActiveCurses.Count - 1; num >= 0; num--)
		{
			if (CurrentActiveCurses[num].curseName == name)
			{
				if (CurrentActiveCurses[num].curseName == "Curse of Darkness")
				{
					CustomDarknessHandler.shouldBeDark.RemoveOverride("DarknessCurse");
				}
				CurrentActiveCurses.RemoveAt(num);
			}
		}
	}

	public static void RemoveAllCurses()
	{
		List<string> list = new List<string>();
		if (CurrentActiveCurses.Count <= 0)
		{
			return;
		}
		foreach (CurseData currentActiveCurse in CurrentActiveCurses)
		{
			list.Add(currentActiveCurse.curseName);
		}
		foreach (string item in list)
		{
			RemoveCurse(item);
		}
	}

	public static bool CurseIsActive(string CurseName)
	{
		foreach (CurseData currentActiveCurse in CurrentActiveCurses)
		{
			if (currentActiveCurse.curseName == CurseName)
			{
				return true;
			}
		}
		return false;
	}
}
