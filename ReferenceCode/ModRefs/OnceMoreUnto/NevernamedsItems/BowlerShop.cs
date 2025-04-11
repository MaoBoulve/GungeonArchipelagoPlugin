using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Alexandria.BreakableAPI;
using Alexandria.ChestAPI;
using Alexandria.DungeonAPI;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Dungeonator;
using InControl;
using SaveAPI;
using UnityEngine;
using UnityEngine.Rendering;

namespace NevernamedsItems;

public class BowlerShop
{
	public class BowlerShopInteractible : BraveBehaviour, IPlayerInteractable
	{
		[CompilerGenerated]
		private sealed class _003CConversation_003Ed__15 : IEnumerator<object>, IDisposable, IEnumerator
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public string dialogue;

			public PlayerController speaker;

			public BowlerShopInteractible _003C_003E4__this;

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
			public _003CConversation_003Ed__15(int _003C_003E1__state)
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
				_003C_003E4__this.bowlerSpriteAnimator.PlayForDuration("bowlershop_talk", 2f, "bowlershop_idle", false);
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
		private sealed class _003CDoFinalChoice_003Ed__13 : IEnumerator<object>, IDisposable, IEnumerator
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public PlayerController speaker;

			public BowlerShopInteractible _003C_003E4__this;

			private int _003Cresponse2_003E5__1;

			private GameObject _003Cchest_003E5__2;

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
			public _003CDoFinalChoice_003Ed__13(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				_003Cchest_003E5__2 = null;
				_003C_003E1__state = -2;
			}

			private bool MoveNext()
			{
				//IL_0158: Unknown result type (might be due to invalid IL or missing references)
				//IL_015d: Unknown result type (might be due to invalid IL or missing references)
				//IL_016c: Unknown result type (might be due to invalid IL or missing references)
				//IL_0171: Unknown result type (might be due to invalid IL or missing references)
				//IL_0177: Unknown result type (might be due to invalid IL or missing references)
				switch (_003C_003E1__state)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					GameUIRoot.Instance.DisplayPlayerConversationOptions(speaker, (TalkModule)null, $"Yeah whatever <Pay {_003C_003E4__this.Cost}[sprite \"ui_coin\"]>", "That's way too expensive!");
					_003Cresponse2_003E5__1 = -1;
					goto IL_0091;
				case 1:
					_003C_003E1__state = -1;
					goto IL_0091;
				case 2:
				{
					_003C_003E1__state = -1;
					PlayerConsumables carriedConsumables = speaker.carriedConsumables;
					carriedConsumables.Currency -= _003C_003E4__this.Cost;
					_003Cchest_003E5__2 = ((Component)ChestUtility.SpawnChestEasy(Vector2Extensions.ToIntVector2(Vector2.op_Implicit(((BraveBehaviour)_003C_003E4__this).transform.parent.parent.parent.position) + new Vector2(-1f, 0f), (VectorConversions)2), (ChestTier)5, false, (GeneralChestType)0, (ThreeStateValue)1, (ThreeStateValue)1)).gameObject;
					_003Cchest_003E5__2.AddComponent<BowlerShopChest>().interactible = _003C_003E4__this;
					_003C_003E4__this.hasBeenUsed = true;
					_003Cchest_003E5__2 = null;
					break;
				}
				case 3:
					_003C_003E1__state = -1;
					break;
				case 4:
					{
						_003C_003E1__state = -1;
						break;
					}
					IL_0091:
					if (!GameUIRoot.Instance.GetPlayerConversationResponse(ref _003Cresponse2_003E5__1))
					{
						_003C_003E2__current = null;
						_003C_003E1__state = 1;
						return true;
					}
					if (_003Cresponse2_003E5__1 == 0)
					{
						if (speaker.carriedConsumables.Currency >= _003C_003E4__this.Cost)
						{
							_003C_003E2__current = _003C_003E4__this.LongConversation(new List<string> { "Let's {wb}GOOOOOOOO{w}" }, speaker, clearAfter: true);
							_003C_003E1__state = 2;
							return true;
						}
						_003C_003E4__this.hasDeclinedOnce = true;
						_003C_003E2__current = _003C_003E4__this.LongConversation(new List<string>
						{
							"Ohhhh noooo! You're BROOOOKE",
							BraveUtility.RandomElement<string>(brokeTalk)
						}, speaker, clearAfter: true);
						_003C_003E1__state = 3;
						return true;
					}
					_003C_003E4__this.hasDeclinedOnce = true;
					_003C_003E2__current = _003C_003E4__this.LongConversation(new List<string> { "Suit yourself!", "...your {wb}BOOOOORING{w} non-{wb}RAINBOW{w} self!" }, speaker, clearAfter: true);
					_003C_003E1__state = 4;
					return true;
				}
				speaker.ClearInputOverride("npcConversation");
				Pixelator.Instance.LerpToLetterbox(1f, 0.25f);
				_003C_003E4__this.bowlerSpriteAnimator.Play("bowlershop_idle");
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
		private sealed class _003CHandleInteract_003Ed__10 : IEnumerator<object>, IDisposable, IEnumerator
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public PlayerController interactor;

			public BowlerShopInteractible _003C_003E4__this;

			private int _003C_003Es__1;

			private CameraController _003CmainCameraController_003E5__2;

			private int _003CselectedResponse_003E5__3;

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
			public _003CHandleInteract_003Ed__10(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				_003CmainCameraController_003E5__2 = null;
				_003C_003E1__state = -2;
			}

			private bool MoveNext()
			{
				//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
				//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
				switch (_003C_003E1__state)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					if (_003C_003E4__this.hasBeenUsed)
					{
						int timesInteractedPostChest = _003C_003E4__this.timesInteractedPostChest;
						_003C_003Es__1 = timesInteractedPostChest;
						switch (_003C_003Es__1)
						{
						case 0:
							_003C_003E2__current = _003C_003E4__this.Conversation("{wb}NO REFUUUUUNDSSSSSS~{w}", interactor);
							_003C_003E1__state = 1;
							return true;
						case 1:
							_003C_003E2__current = _003C_003E4__this.Conversation(BraveUtility.RandomElement<string>(randomTalk), interactor);
							_003C_003E1__state = 2;
							return true;
						default:
							_003C_003E2__current = _003C_003E4__this.Conversation(BraveUtility.RandomElement<string>(endTalk), interactor);
							_003C_003E1__state = 3;
							return true;
						}
					}
					interactor.SetInputOverride("npcConversation");
					Pixelator.Instance.LerpToLetterbox(0.35f, 0.25f);
					_003CmainCameraController_003E5__2 = GameManager.Instance.MainCameraController;
					_003CmainCameraController_003E5__2.SetManualControl(true, true);
					_003CmainCameraController_003E5__2.OverridePosition = _003C_003E4__this.bowler.transform.position;
					if (_003C_003E4__this.hasDeclinedOnce)
					{
						_003C_003E2__current = _003C_003E4__this.LongConversation(new List<string> { "{wb}SOOOOOOOOO{w}", "Did you change your miiiiind?" }, interactor);
						_003C_003E1__state = 4;
						return true;
					}
					if (SaveAPIManager.GetFlag(CustomDungeonFlags.BOWLERSHOP_METONCE))
					{
						_003C_003E2__current = _003C_003E4__this.LongConversation(new List<string> { "{wb}HEEEEEYYYYY{w} it's my favourite {wb}RAINBUDDY!{w}", "Do you wanna get... {wb}CHROMATIC?{w}" }, interactor);
						_003C_003E1__state = 6;
						return true;
					}
					_003C_003E2__current = _003C_003E4__this.LongConversation(new List<string> { "{wb}HEEEEeeeeeEEeeeeEEYYYYY{w}", "Fancy seeing {wb}YOU{w} here." }, interactor);
					_003C_003E1__state = 8;
					return true;
				case 1:
					_003C_003E1__state = -1;
					goto IL_0157;
				case 2:
					_003C_003E1__state = -1;
					goto IL_0157;
				case 3:
					_003C_003E1__state = -1;
					goto IL_0157;
				case 4:
					_003C_003E1__state = -1;
					_003C_003E2__current = _003C_003E4__this.DoFinalChoice(interactor);
					_003C_003E1__state = 5;
					return true;
				case 5:
					_003C_003E1__state = -1;
					goto IL_0488;
				case 6:
					_003C_003E1__state = -1;
					_003C_003E2__current = _003C_003E4__this.DoFinalChoice(interactor);
					_003C_003E1__state = 7;
					return true;
				case 7:
					_003C_003E1__state = -1;
					goto IL_0488;
				case 8:
					_003C_003E1__state = -1;
					GameUIRoot.Instance.DisplayPlayerConversationOptions(interactor, (TalkModule)null, "Hello", "Bowler, what are you doing.");
					_003CselectedResponse_003E5__3 = -1;
					goto IL_0360;
				case 9:
					_003C_003E1__state = -1;
					goto IL_0360;
				case 10:
					_003C_003E1__state = -1;
					goto IL_03e8;
				case 11:
					_003C_003E1__state = -1;
					SaveAPIManager.SetFlag(CustomDungeonFlags.BOWLERSHOP_METONCE, value: true);
					_003C_003E2__current = _003C_003E4__this.DoFinalChoice(interactor);
					_003C_003E1__state = 12;
					return true;
				case 12:
					{
						_003C_003E1__state = -1;
						goto IL_0488;
					}
					IL_0360:
					if (!GameUIRoot.Instance.GetPlayerConversationResponse(ref _003CselectedResponse_003E5__3))
					{
						_003C_003E2__current = null;
						_003C_003E1__state = 9;
						return true;
					}
					if (_003CselectedResponse_003E5__3 == 1)
					{
						_003C_003E2__current = _003C_003E4__this.LongConversation(new List<string> { "Are you inquiiiiiiring as to my {wb}MIGHTY{w} podium?", "I made it to look juuuuuust like the {wb}coolest person I know!{w}...", "...{wb}YOU{w}.", "AAAAnyways." }, interactor);
						_003C_003E1__state = 10;
						return true;
					}
					goto IL_03e8;
					IL_0157:
					_003C_003E4__this.timesInteractedPostChest++;
					break;
					IL_03e8:
					_003C_003E2__current = _003C_003E4__this.LongConversation(new List<string>
					{
						"I thought of a neeeeeew way to put some {wb}RAINBOW{w} in your life~",
						"For just a little [sprite \"ui_coin\"], I can {wb}spice things up{w} with a little {wb}colour{w}!",
						"How about... {wb}" + _003C_003E4__this.Cost + "{w} [sprite \"ui_coin\"]?"
					}, interactor);
					_003C_003E1__state = 11;
					return true;
					IL_0488:
					_003CmainCameraController_003E5__2 = null;
					break;
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
		private sealed class _003CLongConversation_003Ed__16 : IEnumerator<object>, IDisposable, IEnumerator
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public List<string> dialogue;

			public PlayerController speaker;

			public bool clearAfter;

			public BowlerShopInteractible _003C_003E4__this;

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
			public _003CLongConversation_003Ed__16(int _003C_003E1__state)
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
				_003C_003E4__this.bowlerSpriteAnimator.Play("bowlershop_talk");
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
				_003C_003E4__this.bowlerSpriteAnimator.Play("bowlershop_idle");
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

		public GameObject bowler;

		public tk2dSprite bowlerSprite;

		public tk2dSpriteAnimator bowlerSpriteAnimator;

		private RoomHandler m_room;

		private Transform talkpoint;

		public int timesInteractedPostChest = 0;

		public bool hasBeenUsed;

		public bool hasDeclinedOnce;

		public static List<string> randomTalk = new List<string> { "Watch out for allllll the {wb}Snaaaaaaakes{w}!", "I sure am glad there aren't {wb}Rainbow Mimics{w}, that would be awwwwful!", "Someday we'll find it! The {wb}Rainbow Connection!{w}", "See you {wb}over the Rainbow{w}~" };

		public static List<string> endTalk = new List<string> { "You should {wb}BOW{w} out...", "You're {wb}BOOOOOORING{w}.", "{wb}MMmmmmm...{w}" };

		public static List<string> brokeTalk = new List<string> { "I don't take {wb}favours{w} you know, come back when you have moooore [sprite \"ui_coin\"]!", "Come back when you're a little... {wb}MMMmmmmmmmmmm...{w} RICHER", "That's so not {wb}RAINBOW RYTHMES{w}!" };

		public static List<string> chestOpen = new List<string> { "{wb}EEEEENJOYYYYY{w}", "So much {wb}Cooooolour{w}", "Woooorth it" };

		public int Cost
		{
			get
			{
				//IL_001d: Unknown result type (might be due to invalid IL or missing references)
				//IL_0023: Invalid comparison between Unknown and I4
				float num = GameManager.Instance.PrimaryPlayer.stats.GetStatValue((StatType)13);
				if ((int)GameManager.Instance.CurrentGameType == 1 && Object.op_Implicit((Object)(object)GameManager.Instance.SecondaryPlayer))
				{
					num *= GameManager.Instance.SecondaryPlayer.stats.GetStatValue((StatType)13);
				}
				num *= GameManager.Instance.GetLastLoadedLevelDefinition()?.priceMultiplier ?? 1f;
				return Mathf.FloorToInt(90f * num * 0.8f);
			}
		}

		private void Start()
		{
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0081: Unknown result type (might be due to invalid IL or missing references)
			bowler = ((Component)((BraveBehaviour)this).transform.parent).gameObject;
			bowlerSprite = bowler.GetComponent<tk2dSprite>();
			bowlerSpriteAnimator = bowler.GetComponent<tk2dSpriteAnimator>();
			talkpoint = bowler.transform.Find("talkpoint");
			SpriteOutlineManager.AddOutlineToSprite((tk2dBaseSprite)(object)bowlerSprite, Color.black);
			m_room = GameManager.Instance.Dungeon.data.GetAbsoluteRoomFromPosition(Vector3Extensions.IntXY(((BraveBehaviour)this).transform.position, (VectorConversions)2));
			m_room.RegisterInteractable((IPlayerInteractable)(object)this);
			Minimap.Instance.RegisterRoomIcon(m_room, mapIcon, false);
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
			SpriteOutlineManager.RemoveOutlineFromSprite((tk2dBaseSprite)(object)bowlerSprite, true);
			SpriteOutlineManager.AddOutlineToSprite((tk2dBaseSprite)(object)bowlerSprite, Color.white);
		}

		public void OnExitRange(PlayerController interactor)
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			SpriteOutlineManager.RemoveOutlineFromSprite((tk2dBaseSprite)(object)bowlerSprite, true);
			SpriteOutlineManager.AddOutlineToSprite((tk2dBaseSprite)(object)bowlerSprite, Color.black);
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
			return new _003CHandleInteract_003Ed__10(0)
			{
				_003C_003E4__this = this,
				interactor = interactor
			};
		}

		public IEnumerator DoFinalChoice(PlayerController speaker)
		{
			//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
			return new _003CDoFinalChoice_003Ed__13(0)
			{
				_003C_003E4__this = this,
				speaker = speaker
			};
		}

		public void OnOpenedChest()
		{
			((MonoBehaviour)this).StartCoroutine(Conversation(BraveUtility.RandomElement<string>(chestOpen), GameManager.Instance.PrimaryPlayer));
		}

		public IEnumerator Conversation(string dialogue, PlayerController speaker)
		{
			//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
			return new _003CConversation_003Ed__15(0)
			{
				_003C_003E4__this = this,
				dialogue = dialogue,
				speaker = speaker
			};
		}

		public IEnumerator LongConversation(List<string> dialogue, PlayerController speaker, bool clearAfter = false)
		{
			//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
			return new _003CLongConversation_003Ed__16(0)
			{
				_003C_003E4__this = this,
				dialogue = dialogue,
				speaker = speaker,
				clearAfter = clearAfter
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
	}

	public static GameObject mapIcon;

	public static void Init()
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected O, but got Unknown
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a0: Expected O, but got Unknown
		//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		//IL_024c: Expected O, but got Unknown
		//IL_0272: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_030f: Unknown result type (might be due to invalid IL or missing references)
		//IL_031f: Unknown result type (might be due to invalid IL or missing references)
		//IL_034b: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cf: Expected O, but got Unknown
		//IL_043a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0443: Unknown result type (might be due to invalid IL or missing references)
		//IL_0467: Unknown result type (might be due to invalid IL or missing references)
		//IL_048a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0494: Expected O, but got Unknown
		//IL_04c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_052c: Unknown result type (might be due to invalid IL or missing references)
		//IL_054f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0559: Expected O, but got Unknown
		//IL_05db: Unknown result type (might be due to invalid IL or missing references)
		//IL_0610: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_06fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0708: Unknown result type (might be due to invalid IL or missing references)
		//IL_070f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0716: Unknown result type (might be due to invalid IL or missing references)
		//IL_0729: Unknown result type (might be due to invalid IL or missing references)
		//IL_0730: Unknown result type (might be due to invalid IL or missing references)
		//IL_0737: Unknown result type (might be due to invalid IL or missing references)
		//IL_0746: Unknown result type (might be due to invalid IL or missing references)
		//IL_074d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0754: Unknown result type (might be due to invalid IL or missing references)
		//IL_075f: Unknown result type (might be due to invalid IL or missing references)
		//IL_076a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0775: Unknown result type (might be due to invalid IL or missing references)
		//IL_077c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0783: Unknown result type (might be due to invalid IL or missing references)
		//IL_0788: Unknown result type (might be due to invalid IL or missing references)
		//IL_078a: Unknown result type (might be due to invalid IL or missing references)
		//IL_078f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0796: Unknown result type (might be due to invalid IL or missing references)
		//IL_079c: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a6: Expected O, but got Unknown
		//IL_07b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_07bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d2: Expected O, but got Unknown
		mapIcon = ItemBuilder.SpriteFromBundle("bowlershop_mapicon", Initialisation.NPCCollection.GetSpriteIdByName("bowlershop_mapicon"), Initialisation.NPCCollection, new GameObject("bowlershop_mapicon"));
		FakePrefabExtensions.MakeFakePrefab(mapIcon);
		GameObject val = new GameObject("BowlerShop");
		val.SetActive(false);
		FakePrefab.MarkAsFakePrefab(val);
		GameObject val2 = ItemBuilder.SpriteFromBundle("bowlershop_carpet", Initialisation.NPCCollection.GetSpriteIdByName("bowlershop_carpet"), Initialisation.NPCCollection, new GameObject("Carpet"));
		val2.transform.SetParent(val.transform);
		val2.transform.localPosition = new Vector3(-2.0625f, -1.625f);
		tk2dSprite component = val2.GetComponent<tk2dSprite>();
		((tk2dBaseSprite)component).HeightOffGround = -1.7f;
		((tk2dBaseSprite)component).SortingOrder = 0;
		val2.layer = 20;
		((tk2dBaseSprite)component).IsPerpendicular = false;
		GameObject val3 = ItemBuilder.SpriteFromBundle("bowlershop_bigstatue", Initialisation.NPCCollection.GetSpriteIdByName("bowlershop_bigstatue"), Initialisation.NPCCollection, new GameObject("BigBowlerStatue"));
		val3.transform.SetParent(val.transform);
		val3.transform.localPosition = new Vector3(-2.125f, 4.875f);
		((tk2dBaseSprite)val3.GetComponent<tk2dSprite>()).HeightOffGround = 0.1f;
		SpeculativeRigidbody val4 = SpriteBuilder.SetUpSpeculativeRigidbody(val3.GetComponent<tk2dSprite>(), new IntVector2(24, -3), new IntVector2(35, 29));
		val4.CollideWithTileMap = false;
		val4.CollideWithOthers = true;
		val4.PrimaryPixelCollider.CollisionLayer = (CollisionLayer)6;
		GameObject val5 = ItemBuilder.SpriteFromBundle("bowlershop_bigstatue_shadow", Initialisation.NPCCollection.GetSpriteIdByName("bowlershop_bigstatue_shadow"), Initialisation.NPCCollection, new GameObject("BowlerStatueShadow"));
		val5.transform.SetParent(((BraveBehaviour)val4).transform);
		val5.transform.localPosition = new Vector3(0.375f, -0.5625f, 50f);
		tk2dSprite component2 = val5.GetComponent<tk2dSprite>();
		((tk2dBaseSprite)component2).HeightOffGround = -1.7f;
		((tk2dBaseSprite)component2).SortingOrder = 0;
		((tk2dBaseSprite)component2).IsPerpendicular = false;
		((BraveBehaviour)component2).renderer.material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTilted");
		((tk2dBaseSprite)component2).usesOverrideMaterial = true;
		GameObject val6 = ItemBuilder.SpriteFromBundle("bowlershop_bowler_idle_001", Initialisation.NPCCollection.GetSpriteIdByName("bowlershop_bowler_idle_001"), Initialisation.NPCCollection, new GameObject("Bowler"));
		val6.transform.SetParent(val3.transform);
		val6.transform.localPosition = new Vector3(3.625f, 3.9375f);
		tk2dSprite component3 = val6.GetComponent<tk2dSprite>();
		((tk2dBaseSprite)component3).HeightOffGround = 20f;
		tk2dSpriteAnimator orAddComponent = GameObjectExtensions.GetOrAddComponent<tk2dSpriteAnimator>(val6);
		orAddComponent.Library = Initialisation.npcAnimationCollection;
		orAddComponent.defaultClipId = Initialisation.npcAnimationCollection.GetClipIdByName("bowlershop_idle");
		orAddComponent.DefaultClipId = Initialisation.npcAnimationCollection.GetClipIdByName("bowlershop_idle");
		orAddComponent.playAutomatically = true;
		Transform transform = new GameObject("talkpoint").transform;
		transform.SetParent(val6.transform);
		((Component)transform).transform.localPosition = new Vector3(0.6875f, 1.375f);
		Transform transform2 = new GameObject("interactPoint").transform;
		transform2.SetParent(val6.transform);
		((Component)transform2).transform.localPosition = new Vector3(1f, -2.9375f);
		((Component)transform2).gameObject.AddComponent<BowlerShopInteractible>();
		Dictionary<GameObject, float> dictionary = new Dictionary<GameObject, float> { { val, 1f } };
		DungeonPlaceable value = BreakableAPIToolbox.GenerateDungeonPlaceable(dictionary, 1, 1, (DungeonPrerequisite[])null);
		StaticReferences.StoredDungeonPlaceables.Add("bowler_shop", value);
		StaticReferences.customPlaceables.Add("nn:bowler_shop", value);
		GameObject val7 = ItemBuilder.SpriteFromBundle("bowlershop statue1", Initialisation.NPCCollection.GetSpriteIdByName("bowlershop statue1"), Initialisation.NPCCollection, new GameObject("BowlerShop Statue 1"));
		val7.SetActive(false);
		FakePrefab.MarkAsFakePrefab(val7);
		((tk2dBaseSprite)val7.GetComponent<tk2dSprite>()).HeightOffGround = 0.1f;
		((Renderer)val7.GetComponent<MeshRenderer>()).lightProbeUsage = (LightProbeUsage)0;
		((BraveBehaviour)val7.GetComponent<tk2dSprite>()).renderer.material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTiltedCutout");
		((tk2dBaseSprite)val7.GetComponent<tk2dSprite>()).usesOverrideMaterial = true;
		SpeculativeRigidbody val8 = SpriteBuilder.SetUpSpeculativeRigidbody(val7.GetComponent<tk2dSprite>(), new IntVector2(1, -1), new IntVector2(35, 18));
		val8.CollideWithTileMap = false;
		val8.CollideWithOthers = true;
		val8.PrimaryPixelCollider.CollisionLayer = (CollisionLayer)6;
		GameObject val9 = ItemBuilder.SpriteFromBundle("bowlershop statue2", Initialisation.NPCCollection.GetSpriteIdByName("bowlershop statue2"), Initialisation.NPCCollection, new GameObject("BowlerShop Statue 2"));
		val9.SetActive(false);
		FakePrefab.MarkAsFakePrefab(val9);
		((tk2dBaseSprite)val9.GetComponent<tk2dSprite>()).HeightOffGround = 0.1f;
		SpeculativeRigidbody val10 = SpriteBuilder.SetUpSpeculativeRigidbody(val9.GetComponent<tk2dSprite>(), new IntVector2(1, -1), new IntVector2(35, 18));
		val10.CollideWithTileMap = false;
		val10.CollideWithOthers = true;
		((Renderer)val9.GetComponent<MeshRenderer>()).lightProbeUsage = (LightProbeUsage)0;
		((BraveBehaviour)val9.GetComponent<tk2dSprite>()).renderer.material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTiltedCutout");
		((tk2dBaseSprite)val9.GetComponent<tk2dSprite>()).usesOverrideMaterial = true;
		val10.PrimaryPixelCollider.CollisionLayer = (CollisionLayer)6;
		GameObject val11 = ItemBuilder.SpriteFromBundle("bowlershop_statueshadow", Initialisation.NPCCollection.GetSpriteIdByName("bowlershop_statueshadow"), Initialisation.NPCCollection, new GameObject("BowlerSmallStatueShadow"));
		tk2dSprite component4 = val11.GetComponent<tk2dSprite>();
		((tk2dBaseSprite)component4).HeightOffGround = -1.7f;
		((tk2dBaseSprite)component4).SortingOrder = 0;
		((tk2dBaseSprite)component4).IsPerpendicular = false;
		((BraveBehaviour)component4).renderer.material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTilted");
		((tk2dBaseSprite)component4).usesOverrideMaterial = true;
		GameObject val12 = Object.Instantiate<GameObject>(val11);
		val11.transform.SetParent(val7.transform);
		val11.transform.localPosition = new Vector3(0.125f, -0.0625f, 50f);
		val12.transform.SetParent(val9.transform);
		val12.transform.localPosition = new Vector3(0.125f, -0.0625f, 50f);
		Dictionary<GameObject, float> dictionary2 = new Dictionary<GameObject, float> { { val7, 1f } };
		DungeonPlaceable val13 = BreakableAPIToolbox.GenerateDungeonPlaceable(dictionary2, 1, 1, (DungeonPrerequisite[])null);
		val13.isPassable = false;
		val13.width = 2;
		val13.height = 2;
		StaticReferences.StoredDungeonPlaceables.Add("bowler_shop_statue1", val13);
		StaticReferences.customPlaceables.Add("nn:bowler_shop_statue1", val13);
		Dictionary<GameObject, float> dictionary3 = new Dictionary<GameObject, float> { { val9, 1f } };
		DungeonPlaceable val14 = BreakableAPIToolbox.GenerateDungeonPlaceable(dictionary3, 1, 1, (DungeonPrerequisite[])null);
		val14.isPassable = false;
		val14.width = 2;
		val14.height = 2;
		StaticReferences.StoredDungeonPlaceables.Add("bowler_shop_statue2", val14);
		StaticReferences.customPlaceables.Add("nn:bowler_shop_statue2", val14);
		SharedInjectionData injectionData = GameManager.Instance.GlobalInjectionData.entries[0].injectionData;
		injectionData.InjectionData.Add(new ProceduralFlowModifierData
		{
			annotation = "BowlerShop",
			DEBUG_FORCE_SPAWN = false,
			OncePerRun = false,
			placementRules = new List<FlowModifierPlacementType> { (FlowModifierPlacementType)1 },
			roomTable = null,
			exactRoom = RoomFactory.BuildNewRoomFromResource("NevernamedsItems/Content/NPCs/Rooms/BowlerShop.newroom", (Assembly)null).room,
			IsWarpWing = false,
			RequiresMasteryToken = false,
			chanceToLock = 0f,
			selectionWeight = 0.067f,
			chanceToSpawn = 1f,
			RequiredValidPlaceable = null,
			prerequisites = new List<DungeonPrerequisite>
			{
				new DungeonPrerequisite
				{
					prerequisiteType = (PrerequisiteType)4,
					requireFlag = true,
					saveFlagToCheck = (GungeonFlags)57502
				}
			}.ToArray(),
			CanBeForcedSecret = false,
			RandomNodeChildMinDistanceFromEntrance = 0,
			exactSecondaryRoom = null,
			framedCombatNodes = 0
		});
	}
}
