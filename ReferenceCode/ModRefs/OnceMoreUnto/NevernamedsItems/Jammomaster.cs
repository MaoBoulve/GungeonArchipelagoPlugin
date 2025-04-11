using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using Dungeonator;
using InControl;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class Jammomaster : BraveBehaviour, IPlayerInteractable
{
	[CompilerGenerated]
	private sealed class _003CConversation_003Ed__5 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public string dialogue;

		public PlayerController speaker;

		public Jammomaster _003C_003E4__this;

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
		public _003CConversation_003Ed__5(int _003C_003E1__state)
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
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			if (_003C_003E1__state != 0)
			{
				return false;
			}
			_003C_003E1__state = -1;
			((BraveBehaviour)_003C_003E4__this).spriteAnimator.PlayForDuration("jammomaster_talk", 2f, "jammomaster_idle", false);
			TextBoxManager.ShowTextBox(_003C_003E4__this.talkpoint.position, _003C_003E4__this.talkpoint, 2f, dialogue, "bower", false, (BoxSlideOrientation)0, false, false);
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
	private sealed class _003CHandleInteract_003Ed__11 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerController interactor;

		public Jammomaster _003C_003E4__this;

		private CameraController _003CmainCameraController_003E5__1;

		private int _003Cresponse2_003E5__2;

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
		public _003CHandleInteract_003Ed__11(int _003C_003E1__state)
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
			//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0119: Unknown result type (might be due to invalid IL or missing references)
			//IL_02db: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f9: Expected O, but got Unknown
			//IL_0335: Unknown result type (might be due to invalid IL or missing references)
			//IL_0364: Unknown result type (might be due to invalid IL or missing references)
			//IL_036e: Expected O, but got Unknown
			//IL_03c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_03cb: Expected O, but got Unknown
			//IL_0452: Unknown result type (might be due to invalid IL or missing references)
			//IL_047c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0486: Expected O, but got Unknown
			//IL_04c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_04f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_04fc: Expected O, but got Unknown
			//IL_0550: Unknown result type (might be due to invalid IL or missing references)
			//IL_055a: Expected O, but got Unknown
			//IL_0618: Unknown result type (might be due to invalid IL or missing references)
			//IL_040e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0418: Expected O, but got Unknown
			//IL_02ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b6: Expected O, but got Unknown
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
				SpriteOutlineManager.RemoveOutlineFromSprite(((BraveBehaviour)_003C_003E4__this).sprite, true);
				SpriteOutlineManager.AddOutlineToSprite(((BraveBehaviour)_003C_003E4__this).sprite, Color.black);
				_003C_003E2__current = _003C_003E4__this.LongConversation(AllJammedState.AllJammedActive ? UnjamTalkStrings : EnjamTalkStrings, interactor);
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				GameUIRoot.Instance.DisplayPlayerConversationOptions(interactor, (TalkModule)null, AllJammedState.AllJammedActive ? "I am content" : "I Accept", AllJammedState.AllJammedActive ? "Please undo... whatever you did" : "...no thanks");
				_003Cresponse2_003E5__2 = -1;
				goto IL_01be;
			case 2:
				_003C_003E1__state = -1;
				goto IL_01be;
			case 3:
				_003C_003E1__state = -1;
				break;
			case 4:
				_003C_003E1__state = -1;
				_003C_003E4__this.bored = true;
				break;
			case 5:
			{
				_003C_003E1__state = -1;
				_003F val2 = interactor;
				Object obj = ResourceCache.Acquire("Global VFX/VFX_Curse");
				((GameActor)val2).PlayEffectOnActor((GameObject)(object)((obj is GameObject) ? obj : null), Vector3.zero, true, false, false);
				_003C_003E2__current = (object)new WaitForSeconds(1f);
				_003C_003E1__state = 6;
				return true;
			}
			case 6:
				_003C_003E1__state = -1;
				((BraveBehaviour)_003C_003E4__this).spriteAnimator.PlayForDuration("jammomaster_darktalk", 2f, "jammomaster_idle", false);
				TextBoxManager.ShowTextBox(_003C_003E4__this.talkpoint.position, _003C_003E4__this.talkpoint, 2f, "{wj}It is done...{w}", "mainframe", false, (BoxSlideOrientation)0, false, false);
				_003C_003E2__current = (object)new WaitForSeconds(0.5f);
				_003C_003E1__state = 7;
				return true;
			case 7:
				_003C_003E1__state = -1;
				GameUIRoot.Instance.notificationController.DoCustomNotification("All-Jammed Mode Enabled", (string)null, Initialisation.NPCCollection, Initialisation.NPCCollection.GetSpriteIdByName("alljammedmode_icon"), (NotificationColor)2, false, true);
				SaveAPIManager.SetFlag(CustomDungeonFlags.ALLJAMMEDMODE_ENABLED_CONSOLE, value: false);
				SaveAPIManager.SetFlag(CustomDungeonFlags.ALLJAMMEDMODE_ENABLED_GENUINE, value: true);
				_003C_003E2__current = (object)new WaitForSeconds(0.5f);
				_003C_003E1__state = 8;
				return true;
			case 8:
				_003C_003E1__state = -1;
				break;
			case 9:
			{
				_003C_003E1__state = -1;
				_003F val = interactor;
				PickupObject byId = PickupObjectDatabase.GetById(538);
				((GameActor)val).PlayEffectOnActor(((SilverBulletsPassiveItem)((byId is SilverBulletsPassiveItem) ? byId : null)).SynergyPowerVFX, new Vector3(0f, -0.5f, 0f), true, false, false);
				AkSoundEngine.PostEvent("Play_OBJ_shrine_accept_01", ((Component)_003C_003E4__this).gameObject);
				_003C_003E2__current = (object)new WaitForSeconds(1f);
				_003C_003E1__state = 10;
				return true;
			}
			case 10:
				_003C_003E1__state = -1;
				((BraveBehaviour)_003C_003E4__this).spriteAnimator.PlayForDuration("jammomaster_darktalk", 2f, "jammomaster_idle", false);
				TextBoxManager.ShowTextBox(_003C_003E4__this.talkpoint.position, _003C_003E4__this.talkpoint, 2f, "{wj}It is...  Un-done.{w}", "mainframe", false, (BoxSlideOrientation)0, false, false);
				_003C_003E2__current = (object)new WaitForSeconds(0.5f);
				_003C_003E1__state = 11;
				return true;
			case 11:
				_003C_003E1__state = -1;
				GameUIRoot.Instance.notificationController.DoCustomNotification("All-Jammed Mode Disabled", (string)null, Initialisation.NPCCollection, Initialisation.NPCCollection.GetSpriteIdByName("alljammedmode_icon"), (NotificationColor)2, false, true);
				SaveAPIManager.SetFlag(CustomDungeonFlags.ALLJAMMEDMODE_ENABLED_CONSOLE, value: false);
				SaveAPIManager.SetFlag(CustomDungeonFlags.ALLJAMMEDMODE_ENABLED_GENUINE, value: false);
				_003C_003E2__current = (object)new WaitForSeconds(0.5f);
				_003C_003E1__state = 12;
				return true;
			case 12:
				_003C_003E1__state = -1;
				break;
			case 13:
				_003C_003E1__state = -1;
				break;
			case 14:
				{
					_003C_003E1__state = -1;
					_003C_003E4__this.bored = true;
					break;
				}
				IL_01be:
				if (!GameUIRoot.Instance.GetPlayerConversationResponse(ref _003Cresponse2_003E5__2))
				{
					_003C_003E2__current = null;
					_003C_003E1__state = 2;
					return true;
				}
				TextBoxManager.ClearTextBox(_003C_003E4__this.talkpoint);
				if (_003Cresponse2_003E5__2 == 0)
				{
					if (AllJammedState.AllJammedActive)
					{
						if (_003C_003E4__this.bored)
						{
							_003C_003E2__current = _003C_003E4__this.Conversation(BraveUtility.RandomElement<string>(BoredStrings), interactor);
							_003C_003E1__state = 3;
							return true;
						}
						_003C_003E2__current = _003C_003E4__this.Conversation(BraveUtility.RandomElement<string>(RandomTalkStrings), interactor);
						_003C_003E1__state = 4;
						return true;
					}
					((BraveBehaviour)_003C_003E4__this).spriteAnimator.Play("jammomaster_curse");
					_003C_003E2__current = (object)new WaitForSeconds(0.74f);
					_003C_003E1__state = 5;
					return true;
				}
				if (AllJammedState.AllJammedActive)
				{
					((BraveBehaviour)_003C_003E4__this).spriteAnimator.Play("jammomaster_curse");
					_003C_003E2__current = (object)new WaitForSeconds(0.74f);
					_003C_003E1__state = 9;
					return true;
				}
				if (_003C_003E4__this.bored)
				{
					_003C_003E2__current = _003C_003E4__this.Conversation(BraveUtility.RandomElement<string>(BoredStrings), interactor);
					_003C_003E1__state = 13;
					return true;
				}
				_003C_003E2__current = _003C_003E4__this.Conversation(BraveUtility.RandomElement<string>(RandomTalkStrings), interactor);
				_003C_003E1__state = 14;
				return true;
			}
			SpriteOutlineManager.RemoveOutlineFromSprite(((BraveBehaviour)_003C_003E4__this).sprite, true);
			SpriteOutlineManager.AddOutlineToSprite(((BraveBehaviour)_003C_003E4__this).sprite, Color.white);
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
	private sealed class _003CLongConversation_003Ed__6 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public List<string> dialogue;

		public PlayerController speaker;

		public bool clearAfter;

		public string itemName;

		public Jammomaster _003C_003E4__this;

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
		public _003CLongConversation_003Ed__6(int _003C_003E1__state)
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
			//IL_0062: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			if (num != 0)
			{
				if (num != 1)
				{
					return false;
				}
				_003C_003E1__state = -1;
				goto IL_00cf;
			}
			_003C_003E1__state = -1;
			_003CconversationIndex_003E5__1 = 0;
			((BraveBehaviour)_003C_003E4__this).spriteAnimator.Play("jammomaster_talk");
			goto IL_0117;
			IL_00cf:
			if (!((OneAxisInputControl)BraveInput.GetInstanceForPlayer(speaker.PlayerIDX).ActiveActions.GetActionFromType((GungeonActionType)10)).WasPressed || _003Ctimer_003E5__2 < 0.4f)
			{
				_003Ctimer_003E5__2 += BraveTime.DeltaTime;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			_003CconversationIndex_003E5__1++;
			goto IL_0117;
			IL_0117:
			if (_003CconversationIndex_003E5__1 <= dialogue.Count - 1)
			{
				TextBoxManager.ClearTextBox(_003C_003E4__this.talkpoint);
				TextBoxManager.ShowTextBox(_003C_003E4__this.talkpoint.position, _003C_003E4__this.talkpoint, -1f, dialogue[_003CconversationIndex_003E5__1], "bower", false, (BoxSlideOrientation)0, true, false);
				_003Ctimer_003E5__2 = 0f;
				goto IL_00cf;
			}
			if (clearAfter)
			{
				TextBoxManager.ClearTextBox(_003C_003E4__this.talkpoint);
			}
			((BraveBehaviour)_003C_003E4__this).spriteAnimator.Play("jammomaster_idle");
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

	public Transform talkpoint;

	public static GameObject JammomasterPlaceable;

	public RoomHandler m_room;

	public bool bored = false;

	public bool hasDoneWalkAway = false;

	public static List<string> RandomTalkStrings = new List<string> { "Do you feel it? The drive to embrace the darkness? That is what I have become...", "Tarry not. They come for you.", "Keep your guns about you... your wits are frayed and shattered.", "Oh. If only you knew the truth... alas, you could never understand...", "Did you ever hear the story of Slinger Scarus the Wise? I thought not...", "The shadows grow darker... things are working as planned.", "Speak not her name in my presence, for the work of the Profane Iconoclast hides from her arms..." };

	public static List<string> BoredStrings = new List<string> { "You waste my time...", "Time is precious...", ". . .", "Toil away..." };

	public static List<string> WalkAwayStrings = new List<string> { "{wj}...run...{w}", "{wj}...soon...{w}", "{wj}...things are aligning...{w}", "{wj}Yes... the Gungeon grows restless...{w}" };

	public static List<string> EnjamTalkStrings = new List<string> { "All things wise and wonderful...", "...all creatures great and small...", "...all things bright and beautiful...", "...I've cursed them, one and all." };

	public static List<string> UnjamTalkStrings = new List<string> { "What?...", "What is your desire now, young slinger?" };

	public static void Init()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Expected O, but got Unknown
		//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = new GameObject("JammomasterPlaceable");
		val.SetActive(false);
		FakePrefab.MarkAsFakePrefab(val);
		GameObject val2 = ItemBuilder.SpriteFromBundle("jammomaster2_idle_001", Initialisation.NPCCollection.GetSpriteIdByName("jammomaster2_idle_001"), Initialisation.NPCCollection, new GameObject("Jammomaster"));
		val2.transform.SetParent(val.transform);
		val2.transform.localPosition = new Vector3(-1f, 1f / 13f);
		val2.AddComponent<Jammomaster>();
		SpeculativeRigidbody val3 = SpriteBuilder.SetUpSpeculativeRigidbody(val2.GetComponent<tk2dSprite>(), new IntVector2(19, -1), new IntVector2(9, 8));
		val3.CollideWithTileMap = false;
		val3.CollideWithOthers = true;
		tk2dSpriteAnimator orAddComponent = GameObjectExtensions.GetOrAddComponent<tk2dSpriteAnimator>(val2);
		orAddComponent.Library = Initialisation.npcAnimationCollection;
		orAddComponent.defaultClipId = Initialisation.npcAnimationCollection.GetClipIdByName("jammomaster_idle");
		orAddComponent.DefaultClipId = Initialisation.npcAnimationCollection.GetClipIdByName("jammomaster_idle");
		orAddComponent.playAutomatically = true;
		Transform transform = new GameObject("talkpoint").transform;
		transform.SetParent(val2.transform);
		((Component)transform).transform.localPosition = new Vector3(1.4375f, 1.4375f);
		GameObject val4 = ItemBuilder.SpriteFromBundle("jammomaster2_shadow", Initialisation.NPCCollection.GetSpriteIdByName("jammomaster2_shadow"), Initialisation.NPCCollection, new GameObject("jammomaster_shadow"));
		tk2dSprite component = val4.GetComponent<tk2dSprite>();
		((tk2dBaseSprite)component).HeightOffGround = -1.7f;
		((tk2dBaseSprite)component).SortingOrder = 0;
		((tk2dBaseSprite)component).IsPerpendicular = false;
		((BraveBehaviour)component).renderer.material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTilted");
		((tk2dBaseSprite)component).usesOverrideMaterial = true;
		val4.transform.SetParent(val2.transform);
		JammomasterPlaceable = val;
		JammomasterPlaceable.AddComponent<BreachPlacedItem>().positionInBreach = Vector2.op_Implicit(new Vector3(51.2f, 50.8f, 51.3f));
		BreachModifications.placedInBreach.Add(JammomasterPlaceable);
	}

	private void Start()
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		talkpoint = ((BraveBehaviour)this).transform.Find("talkpoint");
		SpriteOutlineManager.AddOutlineToSprite(((BraveBehaviour)this).sprite, Color.black);
		m_room = GameManager.Instance.Dungeon.data.GetAbsoluteRoomFromPosition(Vector3Extensions.IntXY(((BraveBehaviour)this).transform.position, (VectorConversions)2));
		m_room.RegisterInteractable((IPlayerInteractable)(object)this);
	}

	public IEnumerator Conversation(string dialogue, PlayerController speaker)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CConversation_003Ed__5(0)
		{
			_003C_003E4__this = this,
			dialogue = dialogue,
			speaker = speaker
		};
	}

	public IEnumerator LongConversation(List<string> dialogue, PlayerController speaker, bool clearAfter = false, string itemName = "")
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CLongConversation_003Ed__6(0)
		{
			_003C_003E4__this = this,
			dialogue = dialogue,
			speaker = speaker,
			clearAfter = clearAfter,
			itemName = itemName
		};
	}

	public float GetDistanceToPoint(Vector2 point)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return Vector2.Distance(point, ((BraveBehaviour)this).specRigidbody.UnitCenter) / 1.5f;
	}

	public void OnEnteredRange(PlayerController interactor)
	{
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		if (((BraveBehaviour)this).spriteAnimator.CurrentClip.name == "jammomaster_darktalk")
		{
			((BraveBehaviour)this).spriteAnimator.Play("jammomaster_idle");
			TextBoxManager.ClearTextBox(talkpoint);
		}
		SpriteOutlineManager.RemoveOutlineFromSprite(((BraveBehaviour)this).sprite, true);
		SpriteOutlineManager.AddOutlineToSprite(((BraveBehaviour)this).sprite, Color.white);
	}

	public void OnExitRange(PlayerController interactor)
	{
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		if (!hasDoneWalkAway && Random.value <= 0.1f)
		{
			((BraveBehaviour)this).spriteAnimator.PlayForDuration("jammomaster_darktalk", 1f, "jammomaster_idle", false);
			TextBoxManager.ShowTextBox(talkpoint.position, talkpoint, 1f, BraveUtility.RandomElement<string>(WalkAwayStrings), "mainframe", false, (BoxSlideOrientation)0, false, false);
		}
		SpriteOutlineManager.RemoveOutlineFromSprite(((BraveBehaviour)this).sprite, true);
		SpriteOutlineManager.AddOutlineToSprite(((BraveBehaviour)this).sprite, Color.black);
	}

	public void Interact(PlayerController interactor)
	{
		if (!TextBoxManager.HasTextBox(talkpoint))
		{
			((MonoBehaviour)this).StartCoroutine(HandleInteract(interactor));
		}
	}

	public IEnumerator HandleInteract(PlayerController interactor)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CHandleInteract_003Ed__11(0)
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
}
