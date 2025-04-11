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
using UnityEngine.Rendering;

namespace NevernamedsItems;

public class Chancellot : BraveBehaviour, IPlayerInteractable
{
	[CompilerGenerated]
	private sealed class _003CConversation_003Ed__9 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public string dialogue;

		public PlayerController speaker;

		public string animation;

		public Chancellot _003C_003E4__this;

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
			((BraveBehaviour)_003C_003E4__this).spriteAnimator.PlayForDuration("chancelot_" + animation, 2f, "chancelot_idle", false);
			TextBoxManager.ShowTextBox(_003C_003E4__this.talkpoint.position, _003C_003E4__this.talkpoint, 2f, dialogue, "gambler", false, (BoxSlideOrientation)0, false, false);
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
	private sealed class _003CHandleInteract_003Ed__15 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerController interactor;

		public Chancellot _003C_003E4__this;

		private List<string> _003Cinteractions_003E5__1;

		private string _003Cchosen_003E5__2;

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
		public _003CHandleInteract_003Ed__15(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003Cinteractions_003E5__1 = null;
			_003Cchosen_003E5__2 = null;
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
				if (!SaveAPIManager.GetFlag(CustomDungeonFlags.CHANCELOT_METONCE))
				{
					_003C_003E2__current = _003C_003E4__this.LongConversation(new List<string> { "Ahh. Another bullet-riddled fool stumbles into my establishment.", "Tell me, did you save the [sprite \"ui_coin\"]?", "You'll need them.", "For here, I...", "SER CHANCELOT", "...will test you in games of great chance!", "Or, rather, that machine in the corner will... self service and all that.", "It matters not. Bother me no further, Staker.", "...you are of no rank to speak with a knight..." }, interactor, clearAfter: true);
					_003C_003E1__state = 1;
					return true;
				}
				if (_003C_003E4__this.timesspoken < 2)
				{
					_003Cinteractions_003E5__1 = new List<string>(talkStrings);
					if (SaveAPIManager.GetFlag(CustomDungeonFlags.ALLJAMMEDMODE_ENABLED_GENUINE))
					{
						_003Cinteractions_003E5__1.AddRange(allJammedInteractions);
					}
					if (_003C_003E4__this.firstInteract != null)
					{
						_003Cinteractions_003E5__1.Remove(_003C_003E4__this.firstInteract);
					}
					_003Cchosen_003E5__2 = BraveUtility.RandomElement<string>(talkStrings);
					_003C_003E2__current = _003C_003E4__this.Conversation(_003Cchosen_003E5__2, interactor);
					_003C_003E1__state = 2;
					return true;
				}
				_003C_003E2__current = _003C_003E4__this.Conversation(BraveUtility.RandomElement<string>(boredStrings), interactor);
				_003C_003E1__state = 3;
				return true;
			case 1:
				_003C_003E1__state = -1;
				SaveAPIManager.SetFlag(CustomDungeonFlags.CHANCELOT_METONCE, value: true);
				break;
			case 2:
				_003C_003E1__state = -1;
				_003C_003E4__this.firstInteract = _003Cchosen_003E5__2;
				_003Cinteractions_003E5__1 = null;
				_003Cchosen_003E5__2 = null;
				goto IL_0204;
			case 3:
				{
					_003C_003E1__state = -1;
					goto IL_0204;
				}
				IL_0204:
				_003C_003E4__this.timesspoken++;
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
	private sealed class _003CLongConversation_003Ed__10 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public List<string> dialogue;

		public PlayerController speaker;

		public bool clearAfter;

		public string animation;

		public Chancellot _003C_003E4__this;

		private CameraController _003CmainCameraController_003E5__1;

		private int _003CconversationIndex_003E5__2;

		private float _003Ctimer_003E5__3;

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
			_003CmainCameraController_003E5__1 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			//IL_007d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			if (num != 0)
			{
				if (num != 1)
				{
					return false;
				}
				_003C_003E1__state = -1;
				goto IL_0139;
			}
			_003C_003E1__state = -1;
			speaker.SetInputOverride("npcConversation");
			Pixelator.Instance.LerpToLetterbox(0.35f, 0.25f);
			_003CmainCameraController_003E5__1 = GameManager.Instance.MainCameraController;
			_003CmainCameraController_003E5__1.SetManualControl(true, true);
			_003CmainCameraController_003E5__1.OverridePosition = ((BraveBehaviour)_003C_003E4__this).transform.position;
			_003CconversationIndex_003E5__2 = 0;
			((BraveBehaviour)_003C_003E4__this).spriteAnimator.Play("chancelot_" + animation);
			goto IL_0181;
			IL_0139:
			if (!((OneAxisInputControl)BraveInput.GetInstanceForPlayer(speaker.PlayerIDX).ActiveActions.GetActionFromType((GungeonActionType)10)).WasPressed || _003Ctimer_003E5__3 < 0.4f)
			{
				_003Ctimer_003E5__3 += BraveTime.DeltaTime;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			_003CconversationIndex_003E5__2++;
			goto IL_0181;
			IL_0181:
			if (_003CconversationIndex_003E5__2 <= dialogue.Count - 1)
			{
				TextBoxManager.ClearTextBox(_003C_003E4__this.talkpoint);
				TextBoxManager.ShowTextBox(_003C_003E4__this.talkpoint.position, _003C_003E4__this.talkpoint, -1f, dialogue[_003CconversationIndex_003E5__2], "gambler", false, (BoxSlideOrientation)0, true, false);
				_003Ctimer_003E5__3 = 0f;
				goto IL_0139;
			}
			if (clearAfter)
			{
				TextBoxManager.ClearTextBox(_003C_003E4__this.talkpoint);
			}
			((BraveBehaviour)_003C_003E4__this).spriteAnimator.Play("chancelot_idle");
			speaker.ClearInputOverride("npcConversation");
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

	public static GameObject mapIcon;

	public RoomHandler m_room;

	private Transform talkpoint;

	public static List<Chancellot> allChancelots = new List<Chancellot>();

	private int timesspoken = 0;

	private string firstInteract = null;

	public static List<string> allJammedInteractions = new List<string> { "Something about you... the shadows cling to you in droves...", "You seem... familiar.", "That magic about you... surely not...", "Leave this place, cursed one.", "I deal not with sorcery of the kind you wear. That is long ago.", "So... the old monster still draws breath..." };

	public static List<string> entryStrings = new List<string> { "I smell something...", "Ah, you... survived.", "Another lowborn...", "Mhm. 'Welcome'", "Please, spend some [sprite \"ui_coin\"]" };

	public static List<string> talkStrings = new List<string> { "Such a strange little thing you are. Most stupefying that you managed to survive the Gungeon at all...", "Does this one fancy itself a gambler? Do they have the stomach to try?", "If you see Winchester, tell him he's no longer allowed in my establishment. He knows why.", "That Bello fellow has neither a sense of style or business.", "If you desire to make a purchase, peruse the Dispensers over there. I don't keep wares at the counter.", "The Dispensers may be drab, but they keep the sticky fingers of Gungeoneers like you at bay.", "...those fools at the Table...   ...one day they will rue their hubris.", "It matters not what those at the Table say! I am a knight, and will be respected as such!" };

	public static List<string> boredStrings = new List<string> { "If you must bother me, at least spend some [sprite \"ui_coin\"]", "Tarry not.", "Shuffle off, Lowborn", "You irritate me." };

	public static List<string> onDispense = new List<string> { "...much obliged.", "Very well.", "Your 'donation' is appreciated." };

	public static List<string> onDispenseFail = new List<string> { "You need more [sprite \"ui_coin\"], taffer.", "Scoundrel.", "You can't haggle with the Dispensers, they know not fear or reason.", "[sprite \"ui_coin\"] only." };

	public static List<string> onSlotWin = new List<string> { "...I suppose everyone gets one...", "Did you bring a lucky charm?", "No matter.", "...lucky pull.", "...good- for you..." };

	public static List<string> onSlotLoss = new List<string> { "Why not try again? Surely you could win it all back...", "Thank you for the [sprite \"ui_coin\"]", "There's one born every minute...", "Lady luck smiles on me this day.", "Lost it.", "Shame.", "So sad.", "The house always wins." };

	public static List<string> onSlotBigWin = new List<string> { "How!", "Preposterous!", "Taffer!", "You must surely be cheating!" };

	public static void Init()
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected O, but got Unknown
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c7: Expected O, but got Unknown
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0209: Unknown result type (might be due to invalid IL or missing references)
		//IL_0212: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0345: Unknown result type (might be due to invalid IL or missing references)
		//IL_034f: Expected O, but got Unknown
		//IL_0402: Unknown result type (might be due to invalid IL or missing references)
		//IL_040c: Expected O, but got Unknown
		//IL_04cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d9: Expected O, but got Unknown
		//IL_059c: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a6: Expected O, but got Unknown
		//IL_0669: Unknown result type (might be due to invalid IL or missing references)
		//IL_0673: Expected O, but got Unknown
		//IL_073b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0740: Unknown result type (might be due to invalid IL or missing references)
		//IL_074b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0752: Unknown result type (might be due to invalid IL or missing references)
		//IL_0759: Unknown result type (might be due to invalid IL or missing references)
		//IL_076c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0773: Unknown result type (might be due to invalid IL or missing references)
		//IL_077a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0789: Unknown result type (might be due to invalid IL or missing references)
		//IL_0790: Unknown result type (might be due to invalid IL or missing references)
		//IL_0797: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_07bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_07cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_07cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_07df: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e9: Expected O, but got Unknown
		//IL_07f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_07fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0802: Unknown result type (might be due to invalid IL or missing references)
		//IL_0809: Unknown result type (might be due to invalid IL or missing references)
		//IL_0815: Expected O, but got Unknown
		mapIcon = ItemBuilder.SpriteFromBundle("chancelot_mapicon", Initialisation.NPCCollection.GetSpriteIdByName("chancelot_mapicon"), Initialisation.NPCCollection, new GameObject("chancelot_mapicon"));
		FakePrefabExtensions.MakeFakePrefab(mapIcon);
		GameObject val = new GameObject("chancellotShop");
		val.SetActive(false);
		FakePrefab.MarkAsFakePrefab(val);
		GameObject val2 = ItemBuilder.SpriteFromBundle("chancellot_counter", Initialisation.NPCCollection.GetSpriteIdByName("chancellot_counter"), Initialisation.NPCCollection, new GameObject("Counter"));
		val2.transform.SetParent(val.transform);
		((tk2dBaseSprite)val2.GetComponent<tk2dSprite>()).HeightOffGround = -1f;
		SpeculativeRigidbody val3 = SpriteBuilder.SetUpSpeculativeRigidbody(val2.GetComponent<tk2dSprite>(), new IntVector2(-15, -1), new IntVector2(128, 17));
		val3.CollideWithTileMap = false;
		val3.CollideWithOthers = true;
		((Renderer)val2.GetComponent<MeshRenderer>()).material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTiltedCutout");
		((tk2dBaseSprite)val2.GetComponent<tk2dSprite>()).usesOverrideMaterial = true;
		val3.PrimaryPixelCollider.CollisionLayer = (CollisionLayer)5;
		GameObject val4 = ItemBuilder.SpriteFromBundle("chancellot_carpet", Initialisation.NPCCollection.GetSpriteIdByName("chancellot_carpet"), Initialisation.NPCCollection, new GameObject("Carpet"));
		tk2dSprite component = val4.GetComponent<tk2dSprite>();
		val4.layer = 20;
		((tk2dBaseSprite)component).SortingOrder = 2;
		((tk2dBaseSprite)component).IsPerpendicular = false;
		((BraveBehaviour)component).renderer.material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTilted");
		((tk2dBaseSprite)component).usesOverrideMaterial = true;
		val4.transform.SetParent(val.transform);
		val4.transform.localPosition = new Vector3(0f, 1f);
		GameObject val5 = ItemBuilder.SpriteFromBundle("chancelot_idle_001", Initialisation.NPCCollection.GetSpriteIdByName("chancelot_idle_001"), Initialisation.NPCCollection, new GameObject("Chancelot"));
		val5.transform.SetParent(val.transform);
		val5.transform.localPosition = new Vector3(4.125f, 0.9375f);
		val5.AddComponent<Chancellot>();
		SpeculativeRigidbody val6 = SpriteBuilder.SetUpSpeculativeRigidbody(val5.GetComponent<tk2dSprite>(), new IntVector2(8, 2), new IntVector2(17, 34));
		val6.CollideWithTileMap = false;
		val6.CollideWithOthers = true;
		UltraFortunesFavor val7 = val5.AddComponent<UltraFortunesFavor>();
		val7.sparkOctantVFX = ResourceManager.LoadAssetBundle("shared_auto_002").LoadAsset<GameObject>("npc_blank_jailed").GetComponentInChildren<UltraFortunesFavor>()
			.sparkOctantVFX;
		tk2dSpriteAnimator orAddComponent = GameObjectExtensions.GetOrAddComponent<tk2dSpriteAnimator>(val5);
		orAddComponent.Library = Initialisation.npcAnimationCollection;
		orAddComponent.defaultClipId = Initialisation.npcAnimationCollection.GetClipIdByName("chancelot_idle");
		orAddComponent.DefaultClipId = Initialisation.npcAnimationCollection.GetClipIdByName("chancelot_idle");
		orAddComponent.playAutomatically = true;
		Transform transform = new GameObject("talkpoint").transform;
		transform.SetParent(val5.transform);
		((Component)transform).transform.localPosition = new Vector3(0f, 3.0625f);
		Dictionary<GameObject, float> dictionary = new Dictionary<GameObject, float> { { val, 1f } };
		DungeonPlaceable value = BreakableAPIToolbox.GenerateDungeonPlaceable(dictionary, 1, 1, (DungeonPrerequisite[])null);
		StaticReferences.StoredDungeonPlaceables.Add("chancelot_shop", value);
		StaticReferences.customPlaceables.Add("nn:chancelot_shop", value);
		GameObject val8 = ItemBuilder.SpriteFromBundle("chancellot_carpet", Initialisation.NPCCollection.GetSpriteIdByName("chancellot_carpet"), Initialisation.NPCCollection, new GameObject("Carpet"));
		FakePrefabExtensions.MakeFakePrefab(val8);
		tk2dSprite component2 = val8.GetComponent<tk2dSprite>();
		val8.layer = 20;
		((tk2dBaseSprite)component2).SortingOrder = 0;
		((tk2dBaseSprite)component2).IsPerpendicular = false;
		((BraveBehaviour)component2).renderer.material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTilted");
		((tk2dBaseSprite)component2).usesOverrideMaterial = true;
		DungeonPlaceable value2 = BreakableAPIToolbox.GenerateDungeonPlaceable(new Dictionary<GameObject, float> { { val8, 1f } }, 1, 1, (DungeonPrerequisite[])null);
		StaticReferences.StoredDungeonPlaceables.Add("chancelot_carpet", value2);
		StaticReferences.customPlaceables.Add("nn:chancelot_carpet", value2);
		GameObject val9 = ItemBuilder.SpriteFromBundle("chancelot_taxidermy", Initialisation.NPCCollection.GetSpriteIdByName("chancelot_taxidermy"), Initialisation.NPCCollection, new GameObject("taxidermy"));
		FakePrefabExtensions.MakeFakePrefab(val9);
		tk2dSprite component3 = val9.GetComponent<tk2dSprite>();
		((tk2dBaseSprite)component3).HeightOffGround = -1f;
		((tk2dBaseSprite)component3).SortingOrder = 0;
		((tk2dBaseSprite)component3).renderLayer = 0;
		((BraveBehaviour)component3).renderer.lightProbeUsage = (LightProbeUsage)0;
		((BraveBehaviour)component3).renderer.material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTiltedCutout");
		((tk2dBaseSprite)component3).usesOverrideMaterial = true;
		DungeonPlaceable value3 = BreakableAPIToolbox.GenerateDungeonPlaceable(new Dictionary<GameObject, float> { { val9, 1f } }, 1, 1, (DungeonPrerequisite[])null);
		StaticReferences.StoredDungeonPlaceables.Add("chancelot_taxidermy", value3);
		StaticReferences.customPlaceables.Add("nn:chancelot_taxidermy", value3);
		GameObject val10 = ItemBuilder.SpriteFromBundle("chancelot_crate_001", Initialisation.NPCCollection.GetSpriteIdByName("chancelot_crate_001"), Initialisation.NPCCollection, new GameObject("Chance Crate"));
		FakePrefabExtensions.MakeFakePrefab(val10);
		tk2dSprite component4 = val10.GetComponent<tk2dSprite>();
		((tk2dBaseSprite)component4).HeightOffGround = -1f;
		((tk2dBaseSprite)component4).SortingOrder = 0;
		((tk2dBaseSprite)component4).renderLayer = 0;
		((BraveBehaviour)component4).renderer.lightProbeUsage = (LightProbeUsage)0;
		((BraveBehaviour)component4).renderer.material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTiltedCutout");
		((tk2dBaseSprite)component4).usesOverrideMaterial = true;
		DungeonPlaceable value4 = BreakableAPIToolbox.GenerateDungeonPlaceable(new Dictionary<GameObject, float> { { val10, 1f } }, 1, 1, (DungeonPrerequisite[])null);
		StaticReferences.StoredDungeonPlaceables.Add("chancelot_chancecrate_1", value4);
		StaticReferences.customPlaceables.Add("nn:chancelot_chancecrate_1", value4);
		GameObject val11 = ItemBuilder.SpriteFromBundle("chancelot_crate_002", Initialisation.NPCCollection.GetSpriteIdByName("chancelot_crate_002"), Initialisation.NPCCollection, new GameObject("Chance Crate"));
		FakePrefabExtensions.MakeFakePrefab(val11);
		tk2dSprite component5 = val11.GetComponent<tk2dSprite>();
		((tk2dBaseSprite)component5).HeightOffGround = -1f;
		((tk2dBaseSprite)component5).SortingOrder = 0;
		((tk2dBaseSprite)component5).renderLayer = 0;
		((BraveBehaviour)component5).renderer.lightProbeUsage = (LightProbeUsage)0;
		((BraveBehaviour)component5).renderer.material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTiltedCutout");
		((tk2dBaseSprite)component5).usesOverrideMaterial = true;
		DungeonPlaceable value5 = BreakableAPIToolbox.GenerateDungeonPlaceable(new Dictionary<GameObject, float> { { val11, 1f } }, 1, 1, (DungeonPrerequisite[])null);
		StaticReferences.StoredDungeonPlaceables.Add("chancelot_chancecrate_2", value5);
		StaticReferences.customPlaceables.Add("nn:chancelot_chancecrate_2", value5);
		GameObject val12 = ItemBuilder.SpriteFromBundle("chancelot_shelf", Initialisation.NPCCollection.GetSpriteIdByName("chancelot_shelf"), Initialisation.NPCCollection, new GameObject("shelf"));
		FakePrefabExtensions.MakeFakePrefab(val12);
		tk2dSprite component6 = val12.GetComponent<tk2dSprite>();
		((tk2dBaseSprite)component6).HeightOffGround = -1f;
		((tk2dBaseSprite)component6).SortingOrder = 0;
		((tk2dBaseSprite)component6).renderLayer = 0;
		((BraveBehaviour)component6).renderer.lightProbeUsage = (LightProbeUsage)0;
		((BraveBehaviour)component6).renderer.material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTiltedCutout");
		((tk2dBaseSprite)component6).usesOverrideMaterial = true;
		DungeonPlaceable value6 = BreakableAPIToolbox.GenerateDungeonPlaceable(new Dictionary<GameObject, float> { { val12, 1f } }, 1, 1, (DungeonPrerequisite[])null);
		StaticReferences.StoredDungeonPlaceables.Add("chancelot_shelf", value6);
		StaticReferences.customPlaceables.Add("nn:chancelot_shelf", value6);
		SharedInjectionData injectionData = GameManager.Instance.GlobalInjectionData.entries[0].injectionData;
		injectionData.InjectionData.Add(new ProceduralFlowModifierData
		{
			annotation = "Chancelot Shop",
			DEBUG_FORCE_SPAWN = false,
			OncePerRun = false,
			placementRules = new List<FlowModifierPlacementType> { (FlowModifierPlacementType)1 },
			roomTable = null,
			exactRoom = RoomFactory.BuildNewRoomFromResource("NevernamedsItems/Content/NPCs/Rooms/ChancelotRoomAnnex.newroom", (Assembly)null).room,
			IsWarpWing = false,
			RequiresMasteryToken = false,
			chanceToLock = 0f,
			selectionWeight = 0.15f,
			chanceToSpawn = 1f,
			RequiredValidPlaceable = null,
			prerequisites = new List<DungeonPrerequisite>
			{
				new DungeonPrerequisite
				{
					prerequisiteType = (PrerequisiteType)4,
					requireFlag = true,
					saveFlagToCheck = (GungeonFlags)10500
				}
			}.ToArray(),
			CanBeForcedSecret = false,
			RandomNodeChildMinDistanceFromEntrance = 0,
			exactSecondaryRoom = null,
			framedCombatNodes = 0
		});
	}

	private void Start()
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Expected O, but got Unknown
		talkpoint = ((BraveBehaviour)this).transform.Find("talkpoint");
		SpriteOutlineManager.AddOutlineToSprite(((BraveBehaviour)this).sprite, Color.black);
		m_room = GameManager.Instance.Dungeon.data.GetAbsoluteRoomFromPosition(Vector3Extensions.IntXY(((BraveBehaviour)this).transform.position, (VectorConversions)2));
		m_room.RegisterInteractable((IPlayerInteractable)(object)this);
		Minimap.Instance.RegisterRoomIcon(m_room, mapIcon, false);
		m_room.Entered += new OnEnteredEventHandler(PlayerEnteredRoom);
		allChancelots.Add(this);
	}

	private void PlayerEnteredRoom(PlayerController player)
	{
		if (!((GameActor)player).IsStealthed && SaveAPIManager.GetFlag(CustomDungeonFlags.CHANCELOT_METONCE))
		{
			((MonoBehaviour)this).StartCoroutine(Conversation(BraveUtility.RandomElement<string>(entryStrings), player));
		}
	}

	public void Inform(string information, int moneySpent = 0)
	{
		switch (information)
		{
		case "loss":
			((MonoBehaviour)this).StartCoroutine(Conversation(BraveUtility.RandomElement<string>(onSlotLoss), GameManager.Instance.PrimaryPlayer, "laugh"));
			break;
		case "minorwin":
			((MonoBehaviour)this).StartCoroutine(Conversation(BraveUtility.RandomElement<string>(onSlotWin), GameManager.Instance.PrimaryPlayer, "miffed"));
			break;
		case "bigwin":
			((MonoBehaviour)this).StartCoroutine(Conversation(BraveUtility.RandomElement<string>(onSlotBigWin), GameManager.Instance.PrimaryPlayer, "angry"));
			break;
		case "dispenserfail":
			((MonoBehaviour)this).StartCoroutine(Conversation(BraveUtility.RandomElement<string>(onDispenseFail), GameManager.Instance.PrimaryPlayer, "laugh"));
			break;
		case "dispenserbuy":
			((MonoBehaviour)this).StartCoroutine(Conversation(BraveUtility.RandomElement<string>(onDispense), GameManager.Instance.PrimaryPlayer));
			break;
		}
		if (moneySpent > 0)
		{
			SaveAPIManager.RegisterStatChange(CustomTrackedStats.CHANCELOT_MONEY_SPENT, moneySpent);
		}
	}

	private void Update()
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		PlayerController activePlayerClosestToPoint = GameManager.Instance.GetActivePlayerClosestToPoint(Vector3Extensions.XY(((BraveBehaviour)this).transform.position), false);
		if ((Object)(object)activePlayerClosestToPoint != (Object)null)
		{
			((BraveBehaviour)this).sprite.FlipX = ((GameActor)activePlayerClosestToPoint).CenterPosition.x > ((BraveBehaviour)this).transform.position.x;
		}
	}

	public IEnumerator Conversation(string dialogue, PlayerController speaker, string animation = "talk")
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

	public IEnumerator LongConversation(List<string> dialogue, PlayerController speaker, bool clearAfter = false, string animation = "talk")
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
		if (!TextBoxManager.HasTextBox(talkpoint))
		{
			((MonoBehaviour)this).StartCoroutine(HandleInteract(interactor));
		}
	}

	public IEnumerator HandleInteract(PlayerController interactor)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CHandleInteract_003Ed__15(0)
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
		allChancelots.Remove(this);
		((BraveBehaviour)this).OnDestroy();
	}
}
