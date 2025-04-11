using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.BreakableAPI;
using Alexandria.ChestAPI;
using Alexandria.DungeonAPI;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Dungeonator;
using SaveAPI;
using UnityEngine;
using UnityEngine.Rendering;

namespace NevernamedsItems;

public class SlotMachine : BraveBehaviour
{
	[CompilerGenerated]
	private sealed class _003CRollTheBones_003Ed__21 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerController interactor;

		public SlotMachine _003C_003E4__this;

		private string _003CoutcomeA_003E5__1;

		private string _003CoutcomeB_003E5__2;

		private string _003CoutcomeC_003E5__3;

		private bool _003Cx2_003E5__4;

		private List<string> _003CnoPoints_003E5__5;

		private int _003Cexp_003E5__6;

		private List<Chancellot>.Enumerator _003C_003Es__7;

		private Chancellot _003Cchance_003E5__8;

		private int _003C_003Es__9;

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
		public _003CRollTheBones_003Ed__21(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003CoutcomeA_003E5__1 = null;
			_003CoutcomeB_003E5__2 = null;
			_003CoutcomeC_003E5__3 = null;
			_003CnoPoints_003E5__5 = null;
			_003C_003Es__7 = default(List<Chancellot>.Enumerator);
			_003Cchance_003E5__8 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_0295: Unknown result type (might be due to invalid IL or missing references)
			//IL_029f: Expected O, but got Unknown
			//IL_0309: Unknown result type (might be due to invalid IL or missing references)
			//IL_0313: Expected O, but got Unknown
			//IL_0360: Unknown result type (might be due to invalid IL or missing references)
			//IL_036a: Expected O, but got Unknown
			//IL_0221: Unknown result type (might be due to invalid IL or missing references)
			//IL_022b: Expected O, but got Unknown
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
			{
				_003C_003E1__state = -1;
				if ((Object)(object)_003C_003E4__this.master == (Object)null)
				{
					_003C_003Es__7 = Chancellot.allChancelots.GetEnumerator();
					try
					{
						while (_003C_003Es__7.MoveNext())
						{
							_003Cchance_003E5__8 = _003C_003Es__7.Current;
							if (_003Cchance_003E5__8.m_room == _003C_003E4__this.m_room)
							{
								_003C_003E4__this.master = _003Cchance_003E5__8;
							}
							_003Cchance_003E5__8 = null;
						}
					}
					finally
					{
						((IDisposable)_003C_003Es__7/*cast due to .constrained prefix*/).Dispose();
					}
					_003C_003Es__7 = default(List<Chancellot>.Enumerator);
				}
				PlayerConsumables carriedConsumables = interactor.carriedConsumables;
				carriedConsumables.Currency -= _003C_003E4__this.currentBet;
				if (Object.op_Implicit((Object)(object)_003C_003E4__this.master))
				{
					_003C_003E4__this.master.Inform("betmade", _003C_003E4__this.currentBet);
				}
				SaveAPIManager.RegisterStatChange(CustomTrackedStats.TIMES_GAMBLED, 1f);
				_003C_003E4__this.playingOutcomeFace = false;
				_003C_003E4__this.timePlayingOutcomeFace = 0f;
				_003C_003E4__this.busy = true;
				((BraveBehaviour)_003C_003E4__this.lever).spriteAnimator.Play("lever_pull");
				_003C_003E4__this.faceAnimator.Play("slotface_spinning");
				_003C_003E4__this.wheel1.Play("slot_spin");
				_003C_003E4__this.wheel2.Play("slot_spin");
				_003C_003E4__this.wheel3.Play("slot_spin");
				AkSoundEngine.PostEvent("Play_OBJ_Chest_Synergy_Slots_01", ((Component)_003C_003E4__this).gameObject);
				_003CoutcomeA_003E5__1 = _003C_003E4__this.GetOutcome("null", interactor);
				_003C_003E2__current = (object)new WaitForSeconds(0.8f);
				_003C_003E1__state = 1;
				return true;
			}
			case 1:
				_003C_003E1__state = -1;
				_003C_003E4__this.wheel1.Play("slot_" + _003CoutcomeA_003E5__1);
				AkSoundEngine.PostEvent("Play_Respawn", ((Component)_003C_003E4__this).gameObject);
				_003CoutcomeB_003E5__2 = _003C_003E4__this.GetOutcome(_003CoutcomeA_003E5__1, interactor);
				_003C_003E2__current = (object)new WaitForSeconds(0.8f);
				_003C_003E1__state = 2;
				return true;
			case 2:
				_003C_003E1__state = -1;
				_003C_003E4__this.wheel2.Play("slot_" + _003CoutcomeB_003E5__2);
				AkSoundEngine.PostEvent("Play_Respawn", ((Component)_003C_003E4__this).gameObject);
				_003CoutcomeC_003E5__3 = _003C_003E4__this.GetOutcome(_003CoutcomeB_003E5__2, interactor);
				_003C_003E2__current = (object)new WaitForSeconds(1.5f);
				_003C_003E1__state = 3;
				return true;
			case 3:
				_003C_003E1__state = -1;
				_003C_003E4__this.wheel3.Play("slot_" + _003CoutcomeC_003E5__3);
				AkSoundEngine.PostEvent("Play_Respawn", ((Component)_003C_003E4__this).gameObject);
				_003C_003E2__current = (object)new WaitForSeconds(0.5f);
				_003C_003E1__state = 4;
				return true;
			case 4:
			{
				_003C_003E1__state = -1;
				_003Cx2_003E5__4 = _003CoutcomeA_003E5__1 == "x2" || _003CoutcomeA_003E5__1 == "x2" || _003CoutcomeC_003E5__3 == "x2";
				_003CnoPoints_003E5__5 = new List<string> { "fail", "x2" };
				_003Cexp_003E5__6 = 0;
				if (_003CoutcomeB_003E5__2 == _003CoutcomeA_003E5__1)
				{
					if (_003CoutcomeB_003E5__2 == _003CoutcomeC_003E5__3)
					{
						_003C_003E4__this.Payout(_003CoutcomeB_003E5__2, 2, _003Cx2_003E5__4);
						_003Cexp_003E5__6 = ((!_003CnoPoints_003E5__5.Contains(_003CoutcomeB_003E5__2)) ? 2 : 0);
					}
					else
					{
						_003C_003E4__this.Payout(_003CoutcomeB_003E5__2, 1, _003Cx2_003E5__4);
						_003Cexp_003E5__6 = ((!_003CnoPoints_003E5__5.Contains(_003CoutcomeB_003E5__2)) ? 1 : 0);
					}
				}
				else if (_003CoutcomeB_003E5__2 == _003CoutcomeC_003E5__3)
				{
					_003C_003E4__this.Payout(_003CoutcomeB_003E5__2, 1, _003Cx2_003E5__4);
					_003Cexp_003E5__6 = ((!_003CnoPoints_003E5__5.Contains(_003CoutcomeB_003E5__2)) ? 1 : 0);
				}
				else if (_003CoutcomeA_003E5__1 == _003CoutcomeC_003E5__3)
				{
					_003C_003E4__this.Payout(_003CoutcomeA_003E5__1, 1, _003Cx2_003E5__4);
					_003Cexp_003E5__6 = ((!_003CnoPoints_003E5__5.Contains(_003CoutcomeA_003E5__1)) ? 1 : 0);
				}
				int num = _003Cexp_003E5__6;
				_003C_003Es__9 = num;
				switch (_003C_003Es__9)
				{
				case 0:
					if (_003C_003E4__this.currentBet > 100)
					{
						_003C_003E4__this.faceAnimator.Play("slotface_bigloss");
					}
					else
					{
						_003C_003E4__this.faceAnimator.Play("slotface_minorloss");
					}
					if (Object.op_Implicit((Object)(object)_003C_003E4__this.master))
					{
						_003C_003E4__this.master.Inform("loss");
					}
					AkSoundEngine.PostEvent("Play_OBJ_Chest_Synergy_Lose_01", ((Component)_003C_003E4__this).gameObject);
					break;
				case 1:
					_003C_003E4__this.faceAnimator.Play("slotface_minorwin");
					if (Object.op_Implicit((Object)(object)_003C_003E4__this.master))
					{
						_003C_003E4__this.master.Inform("minorwin");
					}
					AkSoundEngine.PostEvent("Play_OBJ_Chest_Synergy_Win_01", ((Component)_003C_003E4__this).gameObject);
					break;
				case 2:
					_003C_003E4__this.faceAnimator.Play("slotface_bigwin");
					if (Object.op_Implicit((Object)(object)_003C_003E4__this.master))
					{
						_003C_003E4__this.master.Inform("bigwin");
					}
					AkSoundEngine.PostEvent("Play_OBJ_Chest_Synergy_Win_01", ((Component)_003C_003E4__this).gameObject);
					break;
				}
				_003C_003E4__this.playingOutcomeFace = true;
				_003C_003E4__this.timePlayingOutcomeFace = 0f;
				((BraveBehaviour)_003C_003E4__this.lever).spriteAnimator.Play("lever_reset");
				_003C_003E4__this.busy = false;
				return false;
			}
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

	public RoomHandler m_room;

	public static GameObject mapIcon;

	public GameObject instancedMapIcon;

	public Chancellot master;

	public SlotMachineLever lever;

	public SlotMachineButton increaseButton;

	public SlotMachineButton decreaseButton;

	public GameObject face;

	public tk2dSpriteAnimator faceAnimator;

	public tk2dSpriteAnimator wheel1;

	public tk2dSpriteAnimator wheel2;

	public tk2dSpriteAnimator wheel3;

	public bool busy;

	public int currentBet = 20;

	private bool playingOutcomeFace = false;

	private float timePlayingOutcomeFace = 0f;

	public static List<string> outcomes = new List<string>
	{
		"fail", "fail", "fail", "copper", "copper", "copper", "copper", "silver", "silver", "silver",
		"gold", "gold", "chest", "chest", "x2"
	};

	public static void Init()
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected O, but got Unknown
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Expected O, but got Unknown
		//IL_026a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0293: Unknown result type (might be due to invalid IL or missing references)
		//IL_029d: Expected O, but got Unknown
		//IL_0330: Unknown result type (might be due to invalid IL or missing references)
		//IL_0359: Unknown result type (might be due to invalid IL or missing references)
		//IL_0363: Expected O, but got Unknown
		//IL_043b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0464: Unknown result type (might be due to invalid IL or missing references)
		//IL_046e: Expected O, but got Unknown
		//IL_04e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_050a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0514: Expected O, but got Unknown
		//IL_0567: Unknown result type (might be due to invalid IL or missing references)
		//IL_0590: Unknown result type (might be due to invalid IL or missing references)
		//IL_059a: Expected O, but got Unknown
		//IL_05ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0616: Unknown result type (might be due to invalid IL or missing references)
		//IL_0620: Expected O, but got Unknown
		//IL_0673: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0702: Expected O, but got Unknown
		GameObject val = ItemBuilder.SpriteFromBundle("slotmachine_body", Initialisation.NPCCollection.GetSpriteIdByName("slotmachine_body"), Initialisation.NPCCollection, new GameObject("Slot Machine"));
		val.SetActive(false);
		FakePrefab.MarkAsFakePrefab(val);
		tk2dSprite component = val.GetComponent<tk2dSprite>();
		((tk2dBaseSprite)component).HeightOffGround = -1f;
		((tk2dBaseSprite)component).SortingOrder = 0;
		((tk2dBaseSprite)component).renderLayer = 0;
		((Renderer)val.GetComponent<MeshRenderer>()).lightProbeUsage = (LightProbeUsage)0;
		((BraveBehaviour)component).renderer.material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTiltedCutout");
		((tk2dBaseSprite)component).usesOverrideMaterial = true;
		val.AddComponent<SlotMachine>();
		SpeculativeRigidbody val2 = SpriteBuilder.SetUpSpeculativeRigidbody(val.GetComponent<tk2dSprite>(), new IntVector2(3, -1), new IntVector2(51, 29));
		val2.CollideWithTileMap = false;
		val2.CollideWithOthers = true;
		((BraveBehaviour)val.GetComponent<tk2dSprite>()).renderer.material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTiltedCutout");
		((tk2dBaseSprite)val.GetComponent<tk2dSprite>()).usesOverrideMaterial = true;
		val2.PrimaryPixelCollider.CollisionLayer = (CollisionLayer)6;
		GameObject val3 = ItemBuilder.SpriteFromBundle("slotmachine_face_idle_001", Initialisation.NPCCollection.GetSpriteIdByName("slotmachine_face_idle_001"), Initialisation.NPCCollection, new GameObject("Face"));
		tk2dSprite component2 = val3.GetComponent<tk2dSprite>();
		((tk2dBaseSprite)component2).HeightOffGround = 5f;
		tk2dSpriteAnimator orAddComponent = GameObjectExtensions.GetOrAddComponent<tk2dSpriteAnimator>(val3);
		orAddComponent.Library = Initialisation.npcAnimationCollection;
		orAddComponent.defaultClipId = Initialisation.npcAnimationCollection.GetClipIdByName("slotface_idle");
		orAddComponent.DefaultClipId = Initialisation.npcAnimationCollection.GetClipIdByName("slotface_idle");
		orAddComponent.playAutomatically = true;
		val3.transform.SetParent(val.transform);
		val3.transform.localPosition = new Vector3(0.5625f, 2.3125f, 0f);
		GameObject val4 = ItemBuilder.SpriteFromBundle("slotmachine_button1", Initialisation.NPCCollection.GetSpriteIdByName("slotmachine_button1"), Initialisation.NPCCollection, new GameObject("buttonA"));
		tk2dSprite component3 = val4.GetComponent<tk2dSprite>();
		((tk2dBaseSprite)component3).HeightOffGround = 0.5f;
		((tk2dBaseSprite)component3).SortingOrder = 0;
		((tk2dBaseSprite)component3).renderLayer = 0;
		((Renderer)val4.GetComponent<MeshRenderer>()).lightProbeUsage = (LightProbeUsage)0;
		((BraveBehaviour)component3).renderer.material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTiltedCutout");
		((tk2dBaseSprite)component3).usesOverrideMaterial = true;
		val4.AddComponent<SlotMachineButton>().betAlteration = 10;
		val4.transform.SetParent(val.transform);
		val4.transform.localPosition = new Vector3(0.4375f, 0.375f, 0f);
		GameObject val5 = ItemBuilder.SpriteFromBundle("slotmachine_button2", Initialisation.NPCCollection.GetSpriteIdByName("slotmachine_button2"), Initialisation.NPCCollection, new GameObject("buttonB"));
		tk2dSprite component4 = val5.GetComponent<tk2dSprite>();
		((tk2dBaseSprite)component4).HeightOffGround = 0.5f;
		((tk2dBaseSprite)component4).SortingOrder = 0;
		((tk2dBaseSprite)component4).renderLayer = 0;
		((Renderer)val5.GetComponent<MeshRenderer>()).lightProbeUsage = (LightProbeUsage)0;
		((BraveBehaviour)component4).renderer.material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTiltedCutout");
		((tk2dBaseSprite)component4).usesOverrideMaterial = true;
		val5.AddComponent<SlotMachineButton>().betAlteration = -10;
		val5.transform.SetParent(val.transform);
		val5.transform.localPosition = new Vector3(1.4375f, 0.375f, 0f);
		GameObject val6 = ItemBuilder.SpriteFromBundle("slotmachine_lever_idle_001", Initialisation.NPCCollection.GetSpriteIdByName("slotmachine_lever_idle_001"), Initialisation.NPCCollection, new GameObject("lever"));
		tk2dSprite component5 = val6.GetComponent<tk2dSprite>();
		((tk2dBaseSprite)component5).HeightOffGround = 2f;
		((tk2dBaseSprite)component5).SortingOrder = 0;
		((tk2dBaseSprite)component5).renderLayer = 0;
		((Renderer)val6.GetComponent<MeshRenderer>()).lightProbeUsage = (LightProbeUsage)0;
		((BraveBehaviour)component5).renderer.material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTiltedCutout");
		((tk2dBaseSprite)component5).usesOverrideMaterial = true;
		val6.AddComponent<SlotMachineLever>();
		tk2dSpriteAnimator orAddComponent2 = GameObjectExtensions.GetOrAddComponent<tk2dSpriteAnimator>(val6);
		orAddComponent2.Library = Initialisation.npcAnimationCollection;
		orAddComponent2.defaultClipId = Initialisation.npcAnimationCollection.GetClipIdByName("lever_idle");
		orAddComponent2.DefaultClipId = Initialisation.npcAnimationCollection.GetClipIdByName("lever_idle");
		orAddComponent2.playAutomatically = true;
		val6.transform.SetParent(val.transform);
		val6.transform.localPosition = new Vector3(3.375f, 1.1875f, 0f);
		GameObject val7 = ItemBuilder.SpriteFromBundle("slotmachine_shadow", Initialisation.NPCCollection.GetSpriteIdByName("slotmachine_shadow"), Initialisation.NPCCollection, new GameObject("Shadow"));
		tk2dSprite component6 = val7.GetComponent<tk2dSprite>();
		((tk2dBaseSprite)component6).HeightOffGround = -2f;
		((tk2dBaseSprite)component6).SortingOrder = 0;
		((tk2dBaseSprite)component6).IsPerpendicular = false;
		((BraveBehaviour)component6).renderer.material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTilted");
		((tk2dBaseSprite)component6).usesOverrideMaterial = true;
		val7.transform.SetParent(val.transform);
		val7.transform.localPosition = new Vector3(0f, -0.125f);
		GameObject val8 = ItemBuilder.SpriteFromBundle("slot_default_001", Initialisation.NPCCollection.GetSpriteIdByName("slot_default_001"), Initialisation.NPCCollection, new GameObject("Slot1"));
		tk2dSprite component7 = val8.GetComponent<tk2dSprite>();
		((tk2dBaseSprite)component7).HeightOffGround = 3f;
		val8.transform.SetParent(val.transform);
		GameObjectExtensions.GetOrAddComponent<tk2dSpriteAnimator>(val8).Library = Initialisation.npcAnimationCollection;
		val8.transform.localPosition = new Vector3(0.4375f, 1.0625f, 0f);
		GameObject val9 = ItemBuilder.SpriteFromBundle("slot_default_002", Initialisation.NPCCollection.GetSpriteIdByName("slot_default_002"), Initialisation.NPCCollection, new GameObject("Slot2"));
		tk2dSprite component8 = val9.GetComponent<tk2dSprite>();
		((tk2dBaseSprite)component8).HeightOffGround = 3f;
		val9.transform.SetParent(val.transform);
		GameObjectExtensions.GetOrAddComponent<tk2dSpriteAnimator>(val9).Library = Initialisation.npcAnimationCollection;
		val9.transform.localPosition = new Vector3(1.375f, 1.0625f, 0f);
		GameObject val10 = ItemBuilder.SpriteFromBundle("slot_default_003", Initialisation.NPCCollection.GetSpriteIdByName("slot_default_003"), Initialisation.NPCCollection, new GameObject("Slot3"));
		tk2dSprite component9 = val10.GetComponent<tk2dSprite>();
		((tk2dBaseSprite)component9).HeightOffGround = 3f;
		val10.transform.SetParent(val.transform);
		GameObjectExtensions.GetOrAddComponent<tk2dSpriteAnimator>(val10).Library = Initialisation.npcAnimationCollection;
		val10.transform.localPosition = new Vector3(2.375f, 1.0625f, 0f);
		Dictionary<GameObject, float> dictionary = new Dictionary<GameObject, float> { { val, 1f } };
		DungeonPlaceable val11 = BreakableAPIToolbox.GenerateDungeonPlaceable(dictionary, 1, 1, (DungeonPrerequisite[])null);
		val11.isPassable = false;
		val11.width = 4;
		val11.height = 2;
		StaticReferences.StoredDungeonPlaceables.Add("slotmachine", val11);
		StaticReferences.customPlaceables.Add("nn:slotmachine", val11);
		mapIcon = ItemBuilder.SpriteFromBundle("slotmachine_map", Initialisation.NPCCollection.GetSpriteIdByName("slotmachine_map"), Initialisation.NPCCollection, new GameObject("slotmachine_map"));
		FakePrefabExtensions.MakeFakePrefab(mapIcon);
	}

	private void Start()
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
		m_room = GameManager.Instance.Dungeon.data.GetAbsoluteRoomFromPosition(Vector3Extensions.IntXY(((BraveBehaviour)this).transform.position, (VectorConversions)2));
		increaseButton = ((Component)((BraveBehaviour)this).transform.Find("buttonA")).gameObject.GetComponent<SlotMachineButton>();
		increaseButton.master = this;
		decreaseButton = ((Component)((BraveBehaviour)this).transform.Find("buttonB")).gameObject.GetComponent<SlotMachineButton>();
		decreaseButton.master = this;
		lever = ((Component)((BraveBehaviour)this).transform.Find("lever")).gameObject.GetComponent<SlotMachineLever>();
		lever.master = this;
		face = ((Component)((BraveBehaviour)this).transform.Find("Face")).gameObject;
		faceAnimator = face.GetComponent<tk2dSpriteAnimator>();
		wheel1 = ((Component)((BraveBehaviour)this).transform.Find("Slot1")).gameObject.GetComponent<tk2dSpriteAnimator>();
		wheel2 = ((Component)((BraveBehaviour)this).transform.Find("Slot2")).gameObject.GetComponent<tk2dSpriteAnimator>();
		wheel3 = ((Component)((BraveBehaviour)this).transform.Find("Slot3")).gameObject.GetComponent<tk2dSpriteAnimator>();
		((BraveBehaviour)increaseButton).sprite.UpdateZDepthAttached(-1f, ((BraveBehaviour)this).transform.position.y, true);
		((BraveBehaviour)decreaseButton).sprite.UpdateZDepthAttached(-1f, ((BraveBehaviour)this).transform.position.y, true);
		((BraveBehaviour)lever).sprite.UpdateZDepthAttached(-1f, ((BraveBehaviour)this).transform.position.y, true);
		instancedMapIcon = Minimap.Instance.RegisterRoomIcon(m_room, mapIcon, false);
	}

	private void Update()
	{
		if (playingOutcomeFace)
		{
			if (timePlayingOutcomeFace > 5f)
			{
				faceAnimator.Play("slotface_idle");
				playingOutcomeFace = false;
				timePlayingOutcomeFace = 0f;
			}
			else
			{
				timePlayingOutcomeFace += BraveTime.DeltaTime;
			}
		}
	}

	public void DoodadTriggered(int betAlteration = 0, bool lever = false, PlayerController interactor = null)
	{
		if (betAlteration != 0)
		{
			if (currentBet + betAlteration < 10)
			{
				Talk("ERR: Minimum bet is 10[sprite \"ui_coin\"]!", interactor);
			}
			else
			{
				currentBet += betAlteration;
				Talk($"Current Bet: {currentBet}[sprite \"ui_coin\"]", interactor);
			}
		}
		if (lever)
		{
			if (interactor.carriedConsumables.Currency >= currentBet)
			{
				((MonoBehaviour)this).StartCoroutine(RollTheBones(interactor));
			}
			else
			{
				Talk("ERR: Insufficient Funds!", interactor);
			}
		}
	}

	public void Talk(string text, PlayerController interactor)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		if (!TextBoxManager.HasTextBox(((BraveBehaviour)this).transform))
		{
			TextBoxManager.ClearTextBox(((BraveBehaviour)this).transform);
		}
		TextBoxManager.ShowTextBox(((BraveBehaviour)this).transform.position + new Vector3(1.8125f, 3.625f), ((BraveBehaviour)this).transform, 1.5f, text, "computer", true, (BoxSlideOrientation)0, false, false);
	}

	private IEnumerator RollTheBones(PlayerController interactor)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CRollTheBones_003Ed__21(0)
		{
			_003C_003E4__this = this,
			interactor = interactor
		};
	}

	public void Payout(string payout, int level, bool anysliderisx2)
	{
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0203: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_024d: Unknown result type (might be due to invalid IL or missing references)
		//IL_024f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0254: Unknown result type (might be due to invalid IL or missing references)
		//IL_024b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0267: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Unknown result type (might be due to invalid IL or missing references)
		switch (payout)
		{
		case "x2":
			break;
		case "copper":
			CashOut(Mathf.CeilToInt((float)currentBet * ((level == 1) ? 1.2f : 1.4f)), hc: false, anysliderisx2);
			break;
		case "silver":
			CashOut(Mathf.CeilToInt((float)currentBet * ((level == 1) ? 1.5f : 2f)), hc: false, anysliderisx2);
			if (level == 2)
			{
				CashOut(Mathf.CeilToInt((float)currentBet * 0.1f), hc: true, anysliderisx2);
			}
			break;
		case "gold":
			CashOut(Mathf.CeilToInt((float)currentBet * ((level == 1) ? 2f : 3f)), hc: false, anysliderisx2);
			CashOut(Mathf.CeilToInt((float)currentBet * ((level == 1) ? 0.1f : 0.5f)), hc: true, anysliderisx2);
			break;
		case "chest":
		{
			Vector2 val = Vector2.op_Implicit(((BraveBehaviour)this).transform.position + new Vector3(0.8125f, -1.9375f));
			Vector2 val2 = Vector2.op_Implicit(((BraveBehaviour)this).transform.position + new Vector3(0.8125f, -3.75f));
			ChestTier val3 = (ChestTier)0;
			val3 = ((currentBet <= 30) ? ((ChestTier)0) : ((currentBet <= 40) ? ((ChestTier)1) : ((currentBet <= 60) ? ((ChestTier)2) : ((currentBet <= 80) ? ((ChestTier)8) : ((currentBet > 100) ? ((ChestTier)4) : ((ChestTier)3))))));
			if (level == 2)
			{
				val3 = UpgradeTier(val3, (!(Random.value <= 0.4f)) ? 1 : 2);
			}
			if (Random.value <= ((level == 2) ? 0.000666f : 0.000333f))
			{
				val3 = (ChestTier)5;
			}
			ChestUtility.SpawnChestEasy(Vector2Extensions.ToIntVector2(val, (VectorConversions)2), val3, false, (GeneralChestType)0, (ThreeStateValue)2, (ThreeStateValue)2);
			if (anysliderisx2)
			{
				ChestUtility.SpawnChestEasy(Vector2Extensions.ToIntVector2(val2, (VectorConversions)2), val3, false, (GeneralChestType)0, (ThreeStateValue)2, (ThreeStateValue)2);
			}
			break;
		}
		}
	}

	public ChestTier UpgradeTier(ChestTier tier, int AMT = 1)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected I4, but got Unknown
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		ChestTier result = (ChestTier)0;
		switch ((int)tier)
		{
		case 4:
			result = ((AMT != 2) ? ((ChestTier)4) : ((!(Random.value <= 0.02f)) ? ((ChestTier)4) : ((ChestTier)5)));
			break;
		case 3:
			result = ((AMT != 2) ? ((ChestTier)4) : ((ChestTier)4));
			break;
		case 2:
			result = ((AMT != 2) ? ((!(Random.value <= 0.5f)) ? ((ChestTier)3) : ((ChestTier)8)) : ((ChestTier)4));
			break;
		case 8:
			result = ((AMT != 2) ? ((ChestTier)3) : ((ChestTier)4));
			break;
		case 1:
			result = ((AMT != 2) ? ((ChestTier)2) : ((ChestTier)3));
			break;
		case 0:
			result = ((AMT != 2) ? ((ChestTier)1) : ((ChestTier)2));
			break;
		}
		return result;
	}

	public void ChestOut(IntVector2 vec, ChestTier tier)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		ChestUtility.SpawnChestEasy(vec, tier, false, (GeneralChestType)0, (ThreeStateValue)2, (ThreeStateValue)1);
	}

	public void CashOut(int amount, bool hc, bool doubled)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		int num = (doubled ? (amount * 2) : amount);
		SaveAPIManager.RegisterStatChange(CustomTrackedStats.GAMBLING_WINNINGS, num - currentBet);
		LootEngine.SpawnCurrency(Vector2.op_Implicit(((BraveBehaviour)this).transform.position + new Vector3(1.8125f, -0.3125f)), num, hc, (Vector2?)(Vector2.down * 1.75f), (float?)45f, 4f, 0.05f);
	}

	public string GetOutcome(string prev, PlayerController interactor)
	{
		string text = BraveUtility.RandomElement<string>(outcomes);
		float playerLuck = GetPlayerLuck(interactor);
		int num = 0;
		float num2 = playerLuck;
		while (num2 > 0f)
		{
			if (playerLuck > 1f)
			{
				num++;
				num2 -= 1f;
				continue;
			}
			if (Random.value <= num2)
			{
				num++;
			}
			num2 = 0f;
		}
		for (int i = 0; i < num; i++)
		{
			if (text == "fail" || (prev != "fail" && prev != "x2" && prev != "null" && text != prev))
			{
				text = BraveUtility.RandomElement<string>(outcomes);
			}
		}
		if (text == "silver" && prev != "silver" && Random.value <= playerLuck * 0.25f)
		{
			text = "gold";
		}
		if (text == "copper" && prev != "copper" && Random.value <= playerLuck * 0.75f)
		{
			text = "silver";
		}
		return text;
	}

	public float GetPlayerLuck(PlayerController interactor)
	{
		float num = 0.1f;
		num += (float)PlayerStats.GetTotalCoolness() * 0.1f;
		num = ((!interactor.HasPickupID(407)) ? (num - (float)PlayerStats.GetTotalCurse() * 0.1f) : (num + (float)PlayerStats.GetTotalCurse() * 0.1f));
		foreach (PassiveItem passiveItem in interactor.passiveItems)
		{
			if (AlexandriaTags.HasTag((PickupObject)(object)passiveItem, "lucky"))
			{
				num += 0.9f;
			}
			if (AlexandriaTags.HasTag((PickupObject)(object)passiveItem, "unlucky"))
			{
				num -= 0.9f;
			}
			if (AlexandriaTags.HasTag((PickupObject)(object)passiveItem, "very_lucky"))
			{
				num += 2.5f;
			}
		}
		foreach (PlayerItem activeItem in interactor.activeItems)
		{
			if (AlexandriaTags.HasTag((PickupObject)(object)activeItem, "lucky"))
			{
				num += 0.9f;
			}
			if (AlexandriaTags.HasTag((PickupObject)(object)activeItem, "unlucky"))
			{
				num -= 0.9f;
			}
			if (AlexandriaTags.HasTag((PickupObject)(object)activeItem, "very_lucky"))
			{
				num += 2.5f;
			}
		}
		return Mathf.Max(num, 0f);
	}

	public void Detonate()
	{
		if (Object.op_Implicit((Object)(object)instancedMapIcon))
		{
			Minimap.Instance.DeregisterRoomIcon(m_room, instancedMapIcon);
			instancedMapIcon = null;
		}
	}
}
