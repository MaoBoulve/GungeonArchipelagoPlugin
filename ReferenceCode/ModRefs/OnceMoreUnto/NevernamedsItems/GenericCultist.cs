using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.BreakableAPI;
using Alexandria.DungeonAPI;
using Alexandria.ItemAPI;
using Dungeonator;
using InControl;
using UnityEngine;

namespace NevernamedsItems;

public class GenericCultist : BraveBehaviour, IPlayerInteractable
{
	[CompilerGenerated]
	private sealed class _003CConversation_003Ed__11 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public string dialogue;

		public PlayerController speaker;

		public string itemName;

		public GenericCultist _003C_003E4__this;

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
		public _003CConversation_003Ed__11(int _003C_003E1__state)
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
			//IL_0023: Unknown result type (might be due to invalid IL or missing references)
			if (_003C_003E1__state != 0)
			{
				return false;
			}
			_003C_003E1__state = -1;
			TextBoxManager.ShowTextBox(_003C_003E4__this.talkpoint.position, _003C_003E4__this.talkpoint, 3f, dialogue, "owl", false, (BoxSlideOrientation)0, false, false);
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
	private sealed class _003CHandleInteract_003Ed__19 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerController interactor;

		public GenericCultist _003C_003E4__this;

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
		public _003CHandleInteract_003Ed__19(int _003C_003E1__state)
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
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				if (!_003C_003E4__this.spokenOnce)
				{
					interactor.SetInputOverride("npcConversation");
					Pixelator.Instance.LerpToLetterbox(0.35f, 0.25f);
					_003CmainCameraController_003E5__1 = GameManager.Instance.MainCameraController;
					_003CmainCameraController_003E5__1.SetManualControl(true, true);
					_003CmainCameraController_003E5__1.OverridePosition = ((BraveBehaviour)_003C_003E4__this).transform.position;
					_003C_003E2__current = _003C_003E4__this.LongConversation(BraveUtility.RandomElement<List<string>>(longTalk), interactor, clearAfter: true);
					_003C_003E1__state = 1;
					return true;
				}
				if (!_003C_003E4__this.Bored)
				{
					_003C_003E2__current = _003C_003E4__this.Conversation(BraveUtility.RandomElement<string>(chatter), interactor);
					_003C_003E1__state = 2;
					return true;
				}
				_003C_003E2__current = _003C_003E4__this.Conversation(BraveUtility.RandomElement<string>(bored), interactor);
				_003C_003E1__state = 3;
				return true;
			case 1:
				_003C_003E1__state = -1;
				_003C_003E4__this.spokenOnce = true;
				interactor.ClearInputOverride("npcConversation");
				Pixelator.Instance.LerpToLetterbox(1f, 0.25f);
				GameManager.Instance.MainCameraController.SetManualControl(false, true);
				_003CmainCameraController_003E5__1 = null;
				break;
			case 2:
				_003C_003E1__state = -1;
				_003C_003E4__this.Bored = true;
				break;
			case 3:
				_003C_003E1__state = -1;
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
	private sealed class _003CLongConversation_003Ed__12 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public List<string> dialogue;

		public PlayerController speaker;

		public bool clearAfter;

		public string itemName;

		public GenericCultist _003C_003E4__this;

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
		public _003CLongConversation_003Ed__12(int _003C_003E1__state)
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
			//IL_004c: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			if (num != 0)
			{
				if (num != 1)
				{
					return false;
				}
				_003C_003E1__state = -1;
				goto IL_00b9;
			}
			_003C_003E1__state = -1;
			_003CconversationIndex_003E5__1 = 0;
			goto IL_0101;
			IL_00b9:
			if (!((OneAxisInputControl)BraveInput.GetInstanceForPlayer(speaker.PlayerIDX).ActiveActions.GetActionFromType((GungeonActionType)10)).WasPressed || _003Ctimer_003E5__2 < 0.4f)
			{
				_003Ctimer_003E5__2 += BraveTime.DeltaTime;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			_003CconversationIndex_003E5__1++;
			goto IL_0101;
			IL_0101:
			if (_003CconversationIndex_003E5__1 <= dialogue.Count - 1)
			{
				TextBoxManager.ClearTextBox(_003C_003E4__this.talkpoint);
				TextBoxManager.ShowTextBox(_003C_003E4__this.talkpoint.position, _003C_003E4__this.talkpoint, -1f, dialogue[_003CconversationIndex_003E5__1], "owl", false, (BoxSlideOrientation)0, true, false);
				_003Ctimer_003E5__2 = 0f;
				goto IL_00b9;
			}
			if (clearAfter)
			{
				TextBoxManager.ClearTextBox(_003C_003E4__this.talkpoint);
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

	private Transform talkpoint;

	public RoomHandler m_room;

	public static List<string> onEnter = new List<string> { "Welcome!", "Our worship, interrupted?", "Glory!" };

	public static List<string> onShot = new List<string> { "Iconoclast!", "Blasphemer!", "Betrayer! Betrayed me!", "Deception!" };

	public static List<string> chatter = new List<string> { "Vengeance shall be hers, she who rifles the curtain!", "She who reloads this chamber and the next, oh Glory to thee!", "The gods of the guns and nature are strange indeed...", "Show some respect! You are in the presence of a holy idol!", "Glory! Glory to Kaliber of the Seven Sidearms!" };

	public static List<string> bored = new List<string> { "Prostrate thyself!", "Bask! Bask in glory!", "Bask!", "Glory Glory Glory!" };

	public static List<List<string>> longTalk = new List<List<string>>
	{
		new List<string> { "Hark! Another reverent of the Gun!", "Come, prostrate thyself at the feet of our beloved idol!", "Bask in reverence!" },
		new List<string> { "Another iconoclast!", "Come to rub your irreverence of our faith in our faces?", "Prostrate thyself and maybe ye will be forgiven of your ignorance!" },
		new List<string> { "Gaze upon the glory of the shrine of our beloved god!", "Glory! Glory! Glory!" }
	};

	public bool spokenOnce;

	public bool Bored;

	public static void Init()
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Expected O, but got Unknown
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = ItemBuilder.SpriteFromBundle("genericcultist_idle_001", Initialisation.NPCCollection.GetSpriteIdByName("genericcultist_idle_001"), Initialisation.NPCCollection, new GameObject("Gun Cultist Talking"));
		val.SetActive(false);
		FakePrefab.MarkAsFakePrefab(val);
		val.AddComponent<GenericCultist>();
		SpeculativeRigidbody val2 = SpriteBuilder.SetUpSpeculativeRigidbody(val.GetComponent<tk2dSprite>(), new IntVector2(2, -1), new IntVector2(10, 7));
		val2.CollideWithTileMap = false;
		val2.CollideWithOthers = true;
		UltraFortunesFavor val3 = val.AddComponent<UltraFortunesFavor>();
		val3.sparkOctantVFX = ResourceManager.LoadAssetBundle("shared_auto_002").LoadAsset<GameObject>("npc_blank_jailed").GetComponentInChildren<UltraFortunesFavor>()
			.sparkOctantVFX;
		tk2dSpriteAnimator orAddComponent = GameObjectExtensions.GetOrAddComponent<tk2dSpriteAnimator>(val);
		orAddComponent.Library = Initialisation.npcAnimationCollection;
		orAddComponent.defaultClipId = Initialisation.npcAnimationCollection.GetClipIdByName("genericcultist_idle");
		orAddComponent.DefaultClipId = Initialisation.npcAnimationCollection.GetClipIdByName("genericcultist_idle");
		orAddComponent.playAutomatically = true;
		GameObjectExtensions.GetOrAddComponent<NPCShootReactor>(val);
		Transform transform = new GameObject("talkpoint").transform;
		transform.SetParent(val.transform);
		((Component)transform).transform.localPosition = new Vector3(0.4375f, 1.1875f);
		GameObject val4 = ItemBuilder.SpriteFromBundle("ms_shadow", Initialisation.MysteriousStrangerCollection.GetSpriteIdByName("ms_shadow"), Initialisation.MysteriousStrangerCollection, new GameObject("ms_shadow"));
		tk2dSprite component = val4.GetComponent<tk2dSprite>();
		((tk2dBaseSprite)component).HeightOffGround = -1.7f;
		((tk2dBaseSprite)component).SortingOrder = 0;
		((tk2dBaseSprite)component).IsPerpendicular = false;
		((BraveBehaviour)component).renderer.material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTilted");
		((tk2dBaseSprite)component).usesOverrideMaterial = true;
		val4.transform.SetParent(val.transform);
		val4.transform.localPosition = new Vector3(0.4375f, 0f);
		Dictionary<GameObject, float> dictionary = new Dictionary<GameObject, float> { { val, 1f } };
		DungeonPlaceable value = BreakableAPIToolbox.GenerateDungeonPlaceable(dictionary, 1, 1, (DungeonPrerequisite[])null);
		StaticReferences.StoredDungeonPlaceables.Add("generic_cultist", value);
		StaticReferences.customPlaceables.Add("nn:generic_cultist", value);
	}

	private void Start()
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		talkpoint = ((BraveBehaviour)this).transform.Find("talkpoint");
		SpriteOutlineManager.AddOutlineToSprite(((BraveBehaviour)this).sprite, Color.black);
		m_room = GameManager.Instance.Dungeon.data.GetAbsoluteRoomFromPosition(Vector3Extensions.IntXY(((BraveBehaviour)this).transform.position, (VectorConversions)2));
		m_room.RegisterInteractable((IPlayerInteractable)(object)this);
		NPCShootReactor component = ((Component)this).GetComponent<NPCShootReactor>();
		component.OnShot = (Action<Projectile>)Delegate.Combine(component.OnShot, new Action<Projectile>(OnShot));
		m_room.Entered += new OnEnteredEventHandler(PlayerEnteredRoom);
	}

	private void PlayerEnteredRoom(PlayerController player)
	{
		((MonoBehaviour)this).StartCoroutine(Conversation(BraveUtility.RandomElement<string>(onEnter), player));
	}

	private void OnShot(Projectile proj)
	{
		((MonoBehaviour)this).StartCoroutine(Conversation(BraveUtility.RandomElement<string>(onShot), GameManager.Instance.PrimaryPlayer));
	}

	public IEnumerator Conversation(string dialogue, PlayerController speaker, string itemName = "")
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CConversation_003Ed__11(0)
		{
			_003C_003E4__this = this,
			dialogue = dialogue,
			speaker = speaker,
			itemName = itemName
		};
	}

	public IEnumerator LongConversation(List<string> dialogue, PlayerController speaker, bool clearAfter = false, string itemName = "")
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CLongConversation_003Ed__12(0)
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
		if (!TextBoxManager.HasTextBox(talkpoint))
		{
			((MonoBehaviour)this).StartCoroutine(HandleInteract(interactor));
		}
	}

	public IEnumerator HandleInteract(PlayerController interactor)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CHandleInteract_003Ed__19(0)
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
