using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Alexandria.BreakableAPI;
using Alexandria.DungeonAPI;
using Alexandria.ItemAPI;
using Dungeonator;
using InControl;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class Beggar : BraveBehaviour, IPlayerInteractable
{
	public class BeggarReward
	{
		public int req;

		public int ID;

		public CustomDungeonFlags giveFlag;
	}

	[CompilerGenerated]
	private sealed class _003CConversation_003Ed__9 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public string dialogue;

		public PlayerController speaker;

		public string animation;

		public Beggar _003C_003E4__this;

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
		public _003CConversation_003Ed__9(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			if (_003C_003E1__state != 0)
			{
				return false;
			}
			_003C_003E1__state = -1;
			((BraveBehaviour)_003C_003E4__this).spriteAnimator.PlayForDuration("beggar_" + animation, 2f, "beggar_idle", false);
			TextBoxManager.ShowTextBox(_003C_003E4__this.talkpoint.position, _003C_003E4__this.talkpoint, 2f, dialogue, "oldman", false, (BoxSlideOrientation)0, false, false);
			return false;
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

	[CompilerGenerated]
	private sealed class _003CGiveItem_003Ed__16 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerController interactor;

		public int ID;

		public bool dodialogue;

		public Beggar _003C_003E4__this;

		private CameraController _003CmainCameraController_003E5__1;

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
		public _003CGiveItem_003Ed__16(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003CmainCameraController_003E5__1 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0252: Unknown result type (might be due to invalid IL or missing references)
			//IL_025c: Expected O, but got Unknown
			//IL_0288: Unknown result type (might be due to invalid IL or missing references)
			//IL_0292: Expected O, but got Unknown
			//IL_0317: Unknown result type (might be due to invalid IL or missing references)
			//IL_0326: Unknown result type (might be due to invalid IL or missing references)
			//IL_032b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0330: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_02de: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_021c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0226: Expected O, but got Unknown
			//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0349: Unknown result type (might be due to invalid IL or missing references)
			//IL_0353: Expected O, but got Unknown
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				interactor.SetInputOverride("npcConversation");
				Pixelator.Instance.LerpToLetterbox(0.35f, 0.25f);
				_003CmainCameraController_003E5__1 = GameManager.Instance.MainCameraController;
				_003CmainCameraController_003E5__1.SetManualControl(true, true);
				_003CmainCameraController_003E5__1.OverridePosition = ((BraveBehaviour)_003C_003E4__this).transform.position;
				if (ID == BeggarsBelief.ID)
				{
					_003C_003E2__current = _003C_003E4__this.LongConversation(new List<string> { "list'n kid... you've'un givvun me a lotta [sprite \"ui_coin\"]...", "an' i just wanned ta say...", "thank ye", "ye gave this'ol shell something better'n [sprite \"ui_coin\"]", "ye gave me hope... {wj}belief{w}'n a better gungeon", "take careof yerself now... i won' forget this." }, interactor, clearAfter: true);
					_003C_003E1__state = 1;
					return true;
				}
				((BraveBehaviour)_003C_003E4__this).spriteAnimator.Play("beggar_nod");
				if (dodialogue)
				{
					TextBoxManager.ShowTextBox(_003C_003E4__this.talkpoint.position, _003C_003E4__this.talkpoint, 2f, BraveUtility.RandomElement<string>(preGive), "oldman", false, (BoxSlideOrientation)0, false, false);
				}
				_003C_003E2__current = (object)new WaitForSeconds(1f);
				_003C_003E1__state = 2;
				return true;
			case 1:
				_003C_003E1__state = -1;
				LootEngine.TryGivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(ID)).gameObject, interactor, false);
				AdvancedGameStatsManager.Instance.BeggarRepeatTarget = BraveUtility.RandomElement<int>(new List<int> { 50, 100, 120, 150, 170, 200, 230 });
				break;
			case 2:
				_003C_003E1__state = -1;
				((BraveBehaviour)_003C_003E4__this).spriteAnimator.Play("beggar_getitem");
				_003C_003E2__current = (object)new WaitForSeconds(3f);
				_003C_003E1__state = 3;
				return true;
			case 3:
				_003C_003E1__state = -1;
				((BraveBehaviour)_003C_003E4__this).spriteAnimator.Play("beggar_giveitem");
				_003C_003E2__current = (object)new WaitForSeconds(0.125f);
				_003C_003E1__state = 4;
				return true;
			case 4:
				_003C_003E1__state = -1;
				if (GameStatsManager.Instance.IsRainbowRun)
				{
					LootEngine.SpawnBowlerNote(GameManager.Instance.RewardManager.BowlerNoteOtherSource, Vector2.op_Implicit(((BraveBehaviour)_003C_003E4__this).transform.position + new Vector3(0.4375f, -0.4375f)), interactor.CurrentRoom, true);
				}
				else
				{
					LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetById(ID)).gameObject, ((BraveBehaviour)_003C_003E4__this).transform.position + new Vector3(0.4375f, -0.4375f), Vector2.down, 1f, true, false, false);
				}
				_003C_003E2__current = (object)new WaitForSeconds(0.5f);
				_003C_003E1__state = 5;
				return true;
			case 5:
				_003C_003E1__state = -1;
				((BraveBehaviour)_003C_003E4__this).spriteAnimator.Play("beggar_idle");
				break;
			}
			interactor.ClearInputOverride("npcConversation");
			Pixelator.Instance.LerpToLetterbox(1f, 0.25f);
			GameManager.Instance.MainCameraController.SetManualControl(false, true);
			return false;
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

	[CompilerGenerated]
	private sealed class _003CHandleInteract_003Ed__17 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerController interactor;

		public Beggar _003C_003E4__this;

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
		public _003CHandleInteract_003Ed__17(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			if (_003C_003E1__state != 0)
			{
				return false;
			}
			_003C_003E1__state = -1;
			if (_003C_003E4__this.timesspoken == 0)
			{
				if (_003C_003E4__this.hasDonated)
				{
					((MonoBehaviour)_003C_003E4__this).StartCoroutine(_003C_003E4__this.Conversation(BraveUtility.RandomElement<string>(postDonoTalkStrings), interactor));
				}
				else
				{
					((MonoBehaviour)_003C_003E4__this).StartCoroutine(_003C_003E4__this.Conversation(BraveUtility.RandomElement<string>(talkStrings), interactor));
				}
				_003C_003E4__this.timesspoken++;
			}
			else
			{
				((MonoBehaviour)_003C_003E4__this).StartCoroutine(_003C_003E4__this.Conversation(BraveUtility.RandomElement<string>(boredStrings), interactor));
			}
			return false;
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

	[CompilerGenerated]
	private sealed class _003CLongConversation_003Ed__10 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public List<string> dialogue;

		public PlayerController speaker;

		public bool clearAfter;

		public string animation;

		public Beggar _003C_003E4__this;

		private int _003CconversationIndex_003E5__1;

		private float _003Ctimer_003E5__2;

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
		public _003CLongConversation_003Ed__10(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			if (num != 0)
			{
				if (num != 1)
				{
					return false;
				}
				_003C_003E1__state = -1;
				goto IL_00da;
			}
			_003C_003E1__state = -1;
			_003CconversationIndex_003E5__1 = 0;
			((BraveBehaviour)_003C_003E4__this).spriteAnimator.Play("beggar_" + animation);
			goto IL_0122;
			IL_00da:
			if (!((OneAxisInputControl)BraveInput.GetInstanceForPlayer(speaker.PlayerIDX).ActiveActions.GetActionFromType((GungeonActionType)10)).WasPressed || _003Ctimer_003E5__2 < 0.4f)
			{
				_003Ctimer_003E5__2 += BraveTime.DeltaTime;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			_003CconversationIndex_003E5__1++;
			goto IL_0122;
			IL_0122:
			if (_003CconversationIndex_003E5__1 <= dialogue.Count - 1)
			{
				TextBoxManager.ClearTextBox(_003C_003E4__this.talkpoint);
				TextBoxManager.ShowTextBox(_003C_003E4__this.talkpoint.position, _003C_003E4__this.talkpoint, -1f, dialogue[_003CconversationIndex_003E5__1], "oldman", false, (BoxSlideOrientation)0, true, false);
				_003Ctimer_003E5__2 = 0f;
				goto IL_00da;
			}
			if (clearAfter)
			{
				TextBoxManager.ClearTextBox(_003C_003E4__this.talkpoint);
			}
			((BraveBehaviour)_003C_003E4__this).spriteAnimator.Play("beggar_idle");
			return false;
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

	public static GameObject mapIcon;

	public RoomHandler m_room;

	private Transform talkpoint;

	public BeggarBox box;

	public bool busy;

	private int timesspoken = 0;

	private bool hasDonated = false;

	public static List<string> entryStrings = new List<string> { "...", ". . .", "...ev'nin'", "...'lo" };

	public static List<string> talkStrings = new List<string> { "spare a [sprite \"ui_coin\"]?", ". . .", "mmm..", "ain' got much else to do..." };

	public static List<string> postDonoTalkStrings = new List<string> { "ain' many with yer gen'ros'ty", "{wj}gung'neer{w}, huh? don' see many o' you that ain' lookun to start a fight..", "i don' think The Gun's even real any'mor...", "don' take yer you't fer granned, kid...", "be caref'l out there, these chamb'rs're dang'rous", "me'n my pal {wj}Dusty{w} usedta be a right pair o' slingers... wonder what 'appen'd ta him" };

	public static List<string> boredStrings = new List<string> { "..." };

	public static List<string> postDonation = new List<string> { ". . .", "thank ye'", "oblig'd", "yer a good 'egg", "danke", "ta" };

	public static List<string> preGive = new List<string> { "summin fer yer kindness", "you d'serve it", "goes 'round, eh?" };

	public static List<BeggarReward> rewards;

	public int TotalDonated => Mathf.FloorToInt(SaveAPIManager.GetPlayerStatValue(CustomTrackedStats.BEGGAR_TOTAL_DONATIONS));

	public int TotalRequired
	{
		get
		{
			int num = 0;
			foreach (BeggarReward reward in rewards)
			{
				num += reward.req;
			}
			return num;
		}
	}

	public BeggarReward NextReward
	{
		get
		{
			BeggarReward beggarReward = null;
			foreach (BeggarReward reward in rewards)
			{
				if (beggarReward == null && TotalDonated < actualRequired(reward))
				{
					beggarReward = reward;
				}
			}
			return beggarReward;
		}
	}

	public string NextRewardString
	{
		get
		{
			if (SaveAPIManager.GetFlag(CustomDungeonFlags.GIVEN_BEGGARSBELIEF))
			{
				return $"Next Goal: {AdvancedGameStatsManager.Instance.BeggarRepeatCurrent} / {AdvancedGameStatsManager.Instance.BeggarRepeatTarget}";
			}
			BeggarReward beggarReward = null;
			int num = 0;
			foreach (BeggarReward reward in rewards)
			{
				if (beggarReward == null)
				{
					if (TotalDonated < actualRequired(reward))
					{
						beggarReward = reward;
					}
					else
					{
						num += reward.req;
					}
				}
			}
			if (beggarReward != null)
			{
				return $"Next Goal: {TotalDonated - num} / {beggarReward.req}";
			}
			return "ERR";
		}
	}

	public int AmountToNextReward
	{
		get
		{
			if (SaveAPIManager.GetFlag(CustomDungeonFlags.GIVEN_BEGGARSBELIEF))
			{
				return AdvancedGameStatsManager.Instance.BeggarRepeatTarget - AdvancedGameStatsManager.Instance.BeggarRepeatCurrent;
			}
			BeggarReward beggarReward = null;
			int num = 0;
			foreach (BeggarReward reward in rewards)
			{
				if (beggarReward == null)
				{
					if (TotalDonated < actualRequired(reward))
					{
						beggarReward = reward;
					}
					else
					{
						num += reward.req;
					}
				}
			}
			if (beggarReward != null)
			{
				return beggarReward.req - (TotalDonated - num);
			}
			return 10;
		}
	}

	public string TotalString => (TotalDonated >= TotalRequired) ? "All Donation Goals Met" : $"Total: {TotalDonated} / {TotalRequired}";

	public static void Init()
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected O, but got Unknown
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Expected O, but got Unknown
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Expected O, but got Unknown
		//IL_01df: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0305: Expected O, but got Unknown
		//IL_032b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0347: Unknown result type (might be due to invalid IL or missing references)
		//IL_034f: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0403: Unknown result type (might be due to invalid IL or missing references)
		//IL_040a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0411: Unknown result type (might be due to invalid IL or missing references)
		//IL_0420: Unknown result type (might be due to invalid IL or missing references)
		//IL_0427: Unknown result type (might be due to invalid IL or missing references)
		//IL_042e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0439: Unknown result type (might be due to invalid IL or missing references)
		//IL_0444: Unknown result type (might be due to invalid IL or missing references)
		//IL_044f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0456: Unknown result type (might be due to invalid IL or missing references)
		//IL_045d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0462: Unknown result type (might be due to invalid IL or missing references)
		//IL_0464: Unknown result type (might be due to invalid IL or missing references)
		//IL_0469: Unknown result type (might be due to invalid IL or missing references)
		//IL_0470: Unknown result type (might be due to invalid IL or missing references)
		//IL_0473: Unknown result type (might be due to invalid IL or missing references)
		//IL_047d: Expected O, but got Unknown
		//IL_04aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cb: Expected O, but got Unknown
		//IL_04d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0504: Unknown result type (might be due to invalid IL or missing references)
		//IL_050b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0512: Unknown result type (might be due to invalid IL or missing references)
		//IL_0521: Unknown result type (might be due to invalid IL or missing references)
		//IL_0528: Unknown result type (might be due to invalid IL or missing references)
		//IL_052f: Unknown result type (might be due to invalid IL or missing references)
		//IL_053a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0545: Unknown result type (might be due to invalid IL or missing references)
		//IL_0550: Unknown result type (might be due to invalid IL or missing references)
		//IL_0557: Unknown result type (might be due to invalid IL or missing references)
		//IL_0589: Unknown result type (might be due to invalid IL or missing references)
		//IL_0590: Unknown result type (might be due to invalid IL or missing references)
		//IL_0597: Unknown result type (might be due to invalid IL or missing references)
		//IL_059e: Unknown result type (might be due to invalid IL or missing references)
		//IL_05aa: Expected O, but got Unknown
		//IL_05fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_060a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0611: Unknown result type (might be due to invalid IL or missing references)
		//IL_0618: Unknown result type (might be due to invalid IL or missing references)
		//IL_062b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0632: Unknown result type (might be due to invalid IL or missing references)
		//IL_0639: Unknown result type (might be due to invalid IL or missing references)
		//IL_0648: Unknown result type (might be due to invalid IL or missing references)
		//IL_064f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0656: Unknown result type (might be due to invalid IL or missing references)
		//IL_0661: Unknown result type (might be due to invalid IL or missing references)
		//IL_066c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0677: Unknown result type (might be due to invalid IL or missing references)
		//IL_067e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0685: Unknown result type (might be due to invalid IL or missing references)
		//IL_068a: Unknown result type (might be due to invalid IL or missing references)
		//IL_068c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0691: Unknown result type (might be due to invalid IL or missing references)
		//IL_0698: Unknown result type (might be due to invalid IL or missing references)
		//IL_069b: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a5: Expected O, but got Unknown
		//IL_06d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f3: Expected O, but got Unknown
		mapIcon = ItemBuilder.SpriteFromBundle("beggar_mapicon", Initialisation.NPCCollection.GetSpriteIdByName("beggar_mapicon"), Initialisation.NPCCollection, new GameObject("beggar_mapicon"));
		FakePrefabExtensions.MakeFakePrefab(mapIcon);
		GameObject val = new GameObject("beggar placeable");
		val.SetActive(false);
		FakePrefab.MarkAsFakePrefab(val);
		GameObject val2 = ItemBuilder.SpriteFromBundle("beggar_stuff", Initialisation.NPCCollection.GetSpriteIdByName("beggar_stuff"), Initialisation.NPCCollection, new GameObject("Stuff"));
		tk2dSprite component = val2.GetComponent<tk2dSprite>();
		((tk2dBaseSprite)component).HeightOffGround = -2f;
		((tk2dBaseSprite)component).SortingOrder = 0;
		((tk2dBaseSprite)component).IsPerpendicular = false;
		((BraveBehaviour)component).renderer.material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTilted");
		((tk2dBaseSprite)component).usesOverrideMaterial = true;
		val2.transform.SetParent(val.transform);
		val2.transform.localPosition = new Vector3(1.3125f, 0f);
		GameObject val3 = ItemBuilder.SpriteFromBundle("beggar_shadow", Initialisation.NPCCollection.GetSpriteIdByName("beggar_shadow"), Initialisation.NPCCollection, new GameObject("beggar_shadow"));
		tk2dSprite component2 = val3.GetComponent<tk2dSprite>();
		((tk2dBaseSprite)component2).HeightOffGround = -1.7f;
		((tk2dBaseSprite)component2).SortingOrder = 0;
		((tk2dBaseSprite)component2).IsPerpendicular = false;
		((BraveBehaviour)component2).renderer.material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTilted");
		((tk2dBaseSprite)component2).usesOverrideMaterial = true;
		val3.transform.SetParent(val.transform);
		val3.transform.localPosition = new Vector3(0.0625f, 0.3125f);
		GameObject val4 = ItemBuilder.SpriteFromBundle("beggar_idle_001", Initialisation.NPCCollection.GetSpriteIdByName("beggar_idle_001"), Initialisation.NPCCollection, new GameObject("Beggar"));
		val4.transform.SetParent(val.transform);
		val4.transform.localPosition = new Vector3(1.4375f, 0.5f);
		val4.AddComponent<Beggar>();
		SpeculativeRigidbody val5 = SpriteBuilder.SetUpSpeculativeRigidbody(val4.GetComponent<tk2dSprite>(), new IntVector2(4, 1), new IntVector2(12, 12));
		val5.CollideWithTileMap = false;
		val5.CollideWithOthers = true;
		GameObjectExtensions.GetOrAddComponent<NPCShootReactor>(val4);
		UltraFortunesFavor val6 = val4.AddComponent<UltraFortunesFavor>();
		val6.sparkOctantVFX = ResourceManager.LoadAssetBundle("shared_auto_002").LoadAsset<GameObject>("npc_blank_jailed").GetComponentInChildren<UltraFortunesFavor>()
			.sparkOctantVFX;
		tk2dSpriteAnimator orAddComponent = GameObjectExtensions.GetOrAddComponent<tk2dSpriteAnimator>(val4);
		orAddComponent.Library = Initialisation.npcAnimationCollection;
		orAddComponent.defaultClipId = Initialisation.npcAnimationCollection.GetClipIdByName("beggar_idle");
		orAddComponent.DefaultClipId = Initialisation.npcAnimationCollection.GetClipIdByName("beggar_idle");
		orAddComponent.playAutomatically = true;
		Transform transform = new GameObject("talkpoint").transform;
		transform.SetParent(val4.transform);
		((Component)transform).transform.localPosition = new Vector3(0.75f, 1.25f);
		GameObject val7 = ItemBuilder.SpriteFromBundle("beggar_box", Initialisation.NPCCollection.GetSpriteIdByName("beggar_box"), Initialisation.NPCCollection, new GameObject("Box"));
		val7.transform.SetParent(val.transform);
		val7.transform.localPosition = new Vector3(0f, 0.375f);
		val7.AddComponent<BeggarBox>();
		SpeculativeRigidbody val8 = SpriteBuilder.SetUpSpeculativeRigidbody(val7.GetComponent<tk2dSprite>(), new IntVector2(3, -1), new IntVector2(18, 8));
		val8.CollideWithTileMap = false;
		val8.CollideWithOthers = true;
		Dictionary<GameObject, float> dictionary = new Dictionary<GameObject, float> { { val, 1f } };
		DungeonPlaceable value = BreakableAPIToolbox.GenerateDungeonPlaceable(dictionary, 1, 1, (DungeonPrerequisite[])null);
		StaticReferences.StoredDungeonPlaceables.Add("beggar", value);
		StaticReferences.customPlaceables.Add("nn:beggar", value);
		SharedInjectionData injectionData = GameManager.Instance.GlobalInjectionData.entries[0].injectionData;
		injectionData.InjectionData.Add(new ProceduralFlowModifierData
		{
			annotation = "Beggar Room NonMines",
			DEBUG_FORCE_SPAWN = false,
			OncePerRun = false,
			placementRules = new List<FlowModifierPlacementType> { (FlowModifierPlacementType)1 },
			roomTable = null,
			exactRoom = RoomFactory.BuildNewRoomFromResource("NevernamedsItems/Content/NPCs/Rooms/BeggarRoom.newroom", (Assembly)null).room,
			IsWarpWing = false,
			RequiresMasteryToken = false,
			chanceToLock = 0f,
			selectionWeight = 0.05f,
			chanceToSpawn = 1f,
			RequiredValidPlaceable = null,
			prerequisites = new List<DungeonPrerequisite>
			{
				new DungeonPrerequisite
				{
					prerequisiteType = (PrerequisiteType)3,
					requireTileset = false,
					requiredTileset = (ValidTilesets)16
				},
				(DungeonPrerequisite)(object)new CustomDungeonPrerequisite
				{
					advancedPrerequisiteType = CustomDungeonPrerequisite.AdvancedPrerequisiteType.CUSTOM_FLAG,
					requireCustomFlag = false,
					customFlagToCheck = CustomDungeonFlags.GIVEN_BEGGARSBELIEF
				}
			}.ToArray(),
			CanBeForcedSecret = false,
			RandomNodeChildMinDistanceFromEntrance = 0,
			exactSecondaryRoom = null,
			framedCombatNodes = 0
		});
		injectionData.InjectionData.Add(new ProceduralFlowModifierData
		{
			annotation = "Beggar Room",
			DEBUG_FORCE_SPAWN = false,
			OncePerRun = false,
			placementRules = new List<FlowModifierPlacementType> { (FlowModifierPlacementType)1 },
			roomTable = null,
			exactRoom = RoomFactory.BuildNewRoomFromResource("NevernamedsItems/Content/NPCs/Rooms/BeggarRoom.newroom", (Assembly)null).room,
			IsWarpWing = false,
			RequiresMasteryToken = false,
			chanceToLock = 0f,
			selectionWeight = 0.1f,
			chanceToSpawn = 1f,
			RequiredValidPlaceable = null,
			prerequisites = new List<DungeonPrerequisite> { (DungeonPrerequisite)(object)new CustomDungeonPrerequisite
			{
				advancedPrerequisiteType = CustomDungeonPrerequisite.AdvancedPrerequisiteType.CUSTOM_FLAG,
				requireCustomFlag = true,
				customFlagToCheck = CustomDungeonFlags.GIVEN_BEGGARSBELIEF
			} }.ToArray(),
			CanBeForcedSecret = false,
			RandomNodeChildMinDistanceFromEntrance = 0,
			exactSecondaryRoom = null,
			framedCombatNodes = 0
		});
		SharedInjectionData val9 = ScriptableObject.CreateInstance<SharedInjectionData>();
		val9.UseInvalidWeightAsNoInjection = true;
		val9.PreventInjectionOfFailedPrerequisites = false;
		val9.IsNPCCell = false;
		val9.IgnoreUnmetPrerequisiteEntries = false;
		val9.OnlyOne = false;
		val9.ChanceToSpawnOne = 1f;
		val9.AttachedInjectionData = new List<SharedInjectionData>();
		val9.InjectionData = new List<ProceduralFlowModifierData>
		{
			new ProceduralFlowModifierData
			{
				annotation = "BeggarRoomMines",
				DEBUG_FORCE_SPAWN = false,
				OncePerRun = false,
				placementRules = new List<FlowModifierPlacementType> { (FlowModifierPlacementType)1 },
				roomTable = null,
				exactRoom = RoomFactory.BuildNewRoomFromResource("NevernamedsItems/Content/NPCs/Rooms/BeggarRoom.newroom", (Assembly)null).room,
				IsWarpWing = false,
				RequiresMasteryToken = false,
				chanceToLock = 0f,
				selectionWeight = 2f,
				chanceToSpawn = 1f,
				RequiredValidPlaceable = null,
				prerequisites = new List<DungeonPrerequisite>
				{
					new DungeonPrerequisite
					{
						prerequisiteType = (PrerequisiteType)3,
						requireTileset = true,
						requiredTileset = (ValidTilesets)16
					},
					(DungeonPrerequisite)(object)new CustomDungeonPrerequisite
					{
						advancedPrerequisiteType = CustomDungeonPrerequisite.AdvancedPrerequisiteType.CUSTOM_FLAG,
						requireCustomFlag = false,
						customFlagToCheck = CustomDungeonFlags.GIVEN_BEGGARSBELIEF
					}
				}.ToArray(),
				CanBeForcedSecret = false,
				RandomNodeChildMinDistanceFromEntrance = 0,
				exactSecondaryRoom = null,
				framedCombatNodes = 0
			}
		};
		((Object)val9).name = "BeggarRoomMines";
		SharedInjectionData val10 = LoadHelper.LoadAssetFromAnywhere<SharedInjectionData>("Base Shared Injection Data");
		if (val10.AttachedInjectionData == null)
		{
			val10.AttachedInjectionData = new List<SharedInjectionData>();
		}
		val10.AttachedInjectionData.Add(val9);
		rewards = new List<BeggarReward>
		{
			new BeggarReward
			{
				req = 5,
				ID = Spitballer.ID,
				giveFlag = CustomDungeonFlags.GIVEN_SPITBALLER
			},
			new BeggarReward
			{
				req = 10,
				ID = ScrapStrap.ID,
				giveFlag = CustomDungeonFlags.GIVEN_SCRAPSTRAP
			},
			new BeggarReward
			{
				req = 20,
				ID = FlamingShells.ID,
				giveFlag = CustomDungeonFlags.GIVEN_FLAMINGSHELLS
			},
			new BeggarReward
			{
				req = 40,
				ID = ShellNecklace.ID,
				giveFlag = CustomDungeonFlags.GIVEN_SHELLNECKLACE
			},
			new BeggarReward
			{
				req = 80,
				ID = UnderbarrelShotgun.ID,
				giveFlag = CustomDungeonFlags.GIVEN_UNDERBARRELSHOTGUN
			},
			new BeggarReward
			{
				req = 160,
				ID = WoodenKnife.ID,
				giveFlag = CustomDungeonFlags.GIVEN_WOODENKNIFE
			},
			new BeggarReward
			{
				req = 320,
				ID = Gungineer.ID,
				giveFlag = CustomDungeonFlags.GIVEN_GUNGINEER
			},
			new BeggarReward
			{
				req = 640,
				ID = ShroomedBullets.ID,
				giveFlag = CustomDungeonFlags.GIVEN_SHROOMEDBULLETS
			},
			new BeggarReward
			{
				req = 1280,
				ID = RingOfFortune.ID,
				giveFlag = CustomDungeonFlags.GIVEN_RINGOFFORTUNE
			},
			new BeggarReward
			{
				req = 2560,
				ID = BeggarsBelief.ID,
				giveFlag = CustomDungeonFlags.GIVEN_BEGGARSBELIEF
			}
		};
	}

	private void Start()
	{
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Expected O, but got Unknown
		talkpoint = ((BraveBehaviour)this).transform.Find("talkpoint");
		box = ((Component)((BraveBehaviour)this).transform.parent.Find("Box")).gameObject.GetComponent<BeggarBox>();
		box.master = this;
		SpriteOutlineManager.AddOutlineToSprite(((BraveBehaviour)this).sprite, Color.black);
		m_room = GameManager.Instance.Dungeon.data.GetAbsoluteRoomFromPosition(Vector3Extensions.IntXY(((BraveBehaviour)this).transform.position, (VectorConversions)2));
		m_room.RegisterInteractable((IPlayerInteractable)(object)this);
		NPCShootReactor component = ((Component)this).gameObject.GetComponent<NPCShootReactor>();
		component.OnShot = (Action<Projectile>)Delegate.Combine(component.OnShot, new Action<Projectile>(OnShot));
		Minimap.Instance.RegisterRoomIcon(m_room, mapIcon, false);
		m_room.Entered += new OnEnteredEventHandler(PlayerEnteredRoom);
	}

	private void OnShot(Projectile proj)
	{
		((MonoBehaviour)this).StartCoroutine(Conversation(". . .", GameManager.Instance.PrimaryPlayer, "shake"));
	}

	private void PlayerEnteredRoom(PlayerController player)
	{
		if (!((GameActor)player).IsStealthed)
		{
			((MonoBehaviour)this).StartCoroutine(Conversation(BraveUtility.RandomElement<string>(entryStrings), player));
		}
	}

	public IEnumerator Conversation(string dialogue, PlayerController speaker, string animation = "nod")
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CConversation_003Ed__9(0)
		{
			_003C_003E4__this = this,
			dialogue = dialogue,
			speaker = speaker,
			animation = animation
		};
	}

	public IEnumerator LongConversation(List<string> dialogue, PlayerController speaker, bool clearAfter = false, string animation = "nod")
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CLongConversation_003Ed__10(0)
		{
			_003C_003E4__this = this,
			dialogue = dialogue,
			speaker = speaker,
			clearAfter = clearAfter,
			animation = animation
		};
	}

	public float GetDistanceToPoint(Vector2 point)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		return Vector2.Distance(point, Vector2.op_Implicit(((BraveBehaviour)this).transform.position)) / 1.5f;
	}

	public void OnEnteredRange(PlayerController interactor)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		SpriteOutlineManager.RemoveOutlineFromSprite(((BraveBehaviour)this).sprite, true);
		SpriteOutlineManager.AddOutlineToSprite(((BraveBehaviour)this).sprite, Color.white);
	}

	public void OnExitRange(PlayerController interactor)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		SpriteOutlineManager.RemoveOutlineFromSprite(((BraveBehaviour)this).sprite, true);
		SpriteOutlineManager.AddOutlineToSprite(((BraveBehaviour)this).sprite, Color.black);
	}

	public void Interact(PlayerController interactor)
	{
		if (!TextBoxManager.HasTextBox(talkpoint) && !busy)
		{
			((MonoBehaviour)this).StartCoroutine(HandleInteract(interactor));
		}
	}

	public void OnDonationMade(int donationAmt, PlayerController donator)
	{
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		hasDonated = true;
		timesspoken = 0;
		bool flag = false;
		if (SaveAPIManager.GetFlag(CustomDungeonFlags.GIVEN_BEGGARSBELIEF))
		{
			flag = true;
		}
		if (flag)
		{
			AdvancedGameStatsManager.Instance.BeggarRepeatCurrent += donationAmt;
		}
		else
		{
			SaveAPIManager.RegisterStatChange(CustomTrackedStats.BEGGAR_TOTAL_DONATIONS, donationAmt);
		}
		bool flag2 = false;
		if (flag)
		{
			if (AdvancedGameStatsManager.Instance.BeggarRepeatCurrent >= AdvancedGameStatsManager.Instance.BeggarRepeatTarget)
			{
				AdvancedGameStatsManager.Instance.BeggarRepeatTarget = BraveUtility.RandomElement<int>(new List<int> { 50, 100, 120, 150, 170, 200, 230 });
				AdvancedGameStatsManager.Instance.BeggarRepeatCurrent = 0;
				GenericLootTable val = ((Random.value >= 0.5f) ? GameManager.Instance.RewardManager.GunsLootTable : GameManager.Instance.RewardManager.ItemsLootTable);
				PickupObject val2 = null;
				while ((Object)(object)val2 == (Object)null)
				{
					GameObject itemForPlayer = GameManager.Instance.CurrentRewardManager.GetItemForPlayer(donator, val, BraveUtility.RandomElement<ItemQuality>(new List<ItemQuality>
					{
						(ItemQuality)3,
						(ItemQuality)4,
						(ItemQuality)5
					}), new List<GameObject>(), false, (Random)null, false, (List<GameObject>)null, false, (RewardSource)0);
					if (Object.op_Implicit((Object)(object)itemForPlayer) && (Object)(object)itemForPlayer.GetComponent<PickupObject>() != (Object)null)
					{
						val2 = itemForPlayer.GetComponent<PickupObject>();
					}
				}
				((MonoBehaviour)this).StartCoroutine(GiveItem(donator, val2.PickupObjectId, dodialogue: true));
				flag2 = true;
			}
		}
		else
		{
			foreach (BeggarReward reward in rewards)
			{
				if (!SaveAPIManager.GetFlag(reward.giveFlag) && TotalDonated >= actualRequired(reward))
				{
					((MonoBehaviour)this).StartCoroutine(GiveItem(donator, reward.ID, !flag2));
					flag2 = true;
					SaveAPIManager.SetFlag(reward.giveFlag, value: true);
				}
			}
		}
		if (!flag2)
		{
			((MonoBehaviour)this).StartCoroutine(Conversation(BraveUtility.RandomElement<string>(postDonation), donator));
		}
	}

	public IEnumerator GiveItem(PlayerController interactor, int ID, bool dodialogue)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CGiveItem_003Ed__16(0)
		{
			_003C_003E4__this = this,
			interactor = interactor,
			ID = ID,
			dodialogue = dodialogue
		};
	}

	public IEnumerator HandleInteract(PlayerController interactor)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CHandleInteract_003Ed__17(0)
		{
			_003C_003E4__this = this,
			interactor = interactor
		};
	}

	public string GetAnimationState(PlayerController interactor, out bool shouldBeFlipped)
	{
		shouldBeFlipped = false;
		return string.Empty;
	}

	public float GetOverrideMaxDistance()
	{
		return 1.5f;
	}

	public override void OnDestroy()
	{
		((BraveBehaviour)this).OnDestroy();
	}

	public int actualRequired(BeggarReward rew)
	{
		int num = 0;
		bool flag = false;
		foreach (BeggarReward reward in rewards)
		{
			if (!flag)
			{
				num += reward.req;
				if (reward.ID == rew.ID)
				{
					flag = true;
				}
			}
		}
		return num;
	}
}
