using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.BreakableAPI;
using Alexandria.DungeonAPI;
using Alexandria.ItemAPI;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class Dispenser : BraveBehaviour, IPlayerInteractable
{
	[CompilerGenerated]
	private sealed class _003CHandleInteraction_003Ed__17 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerController interactor;

		public Dispenser _003C_003E4__this;

		private Vector2 _003Cpoint_003E5__1;

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
		public _003CHandleInteraction_003Ed__17(int _003C_003E1__state)
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
			//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_010e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0113: Unknown result type (might be due to invalid IL or missing references)
			//IL_0118: Unknown result type (might be due to invalid IL or missing references)
			//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b4: Expected O, but got Unknown
			//IL_0168: Unknown result type (might be due to invalid IL or missing references)
			//IL_0172: Expected O, but got Unknown
			//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ef: Expected O, but got Unknown
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E4__this.busy = true;
				if (interactor.carriedConsumables.Currency > _003C_003E4__this.Cost)
				{
					PlayerConsumables carriedConsumables = interactor.carriedConsumables;
					carriedConsumables.Currency -= _003C_003E4__this.Cost;
					((BraveBehaviour)_003C_003E4__this).spriteAnimator.Play("dispenser_sale");
					_003C_003E2__current = (object)new WaitForSeconds(0.5f);
					_003C_003E1__state = 1;
					return true;
				}
				((BraveBehaviour)_003C_003E4__this).spriteAnimator.Play("dispenser_nosale");
				if (Object.op_Implicit((Object)(object)_003C_003E4__this.master))
				{
					_003C_003E4__this.master.Inform("dispenserfail");
				}
				_003C_003E2__current = (object)new WaitForSeconds(1.5f);
				_003C_003E1__state = 3;
				return true;
			case 1:
				_003C_003E1__state = -1;
				_003Cpoint_003E5__1 = Vector2.op_Implicit(((BraveBehaviour)_003C_003E4__this).transform.position + new Vector3(0.375f, -0.625f, 0f));
				LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetById(_003C_003E4__this.forSale)).gameObject, Vector2.op_Implicit(_003Cpoint_003E5__1), Vector2.down, 1f, true, false, false);
				if (Object.op_Implicit((Object)(object)_003C_003E4__this.master))
				{
					_003C_003E4__this.master.Inform("dispenserbuy", _003C_003E4__this.Cost);
				}
				_003C_003E2__current = (object)new WaitForSeconds(0.5f);
				_003C_003E1__state = 2;
				return true;
			case 2:
				_003C_003E1__state = -1;
				((BraveBehaviour)_003C_003E4__this).spriteAnimator.Play("dispenser_idle");
				break;
			case 3:
				_003C_003E1__state = -1;
				((BraveBehaviour)_003C_003E4__this).spriteAnimator.Play("dispenser_idle");
				break;
			}
			_003C_003E4__this.busy = false;
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

	public Chancellot master;

	public RoomHandler m_room;

	public GameObject itemPoint;

	public tk2dSprite itemSprite;

	public static List<Dispenser> AllDispensers = new List<Dispenser>();

	public int forSale;

	public List<int> options = new List<int> { 85, 120, 78, 600, 224, 67 };

	private bool disabled = false;

	private bool busy = false;

	public int Cost
	{
		get
		{
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Invalid comparison between Unknown and I4
			int purchasePrice = PickupObjectDatabase.GetById(forSale).PurchasePrice;
			float num = GameManager.Instance.PrimaryPlayer.stats.GetStatValue((StatType)13);
			if ((int)GameManager.Instance.CurrentGameType == 1 && Object.op_Implicit((Object)(object)GameManager.Instance.SecondaryPlayer))
			{
				num *= GameManager.Instance.SecondaryPlayer.stats.GetStatValue((StatType)13);
			}
			float num2 = GameManager.Instance.GetLastLoadedLevelDefinition()?.priceMultiplier ?? 1f;
			return Mathf.FloorToInt((float)purchasePrice * num * num2 * 1.05f);
		}
	}

	public static void Init()
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Expected O, but got Unknown
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = ItemBuilder.SpriteFromBundle("dispenser_idle_001", Initialisation.NPCCollection.GetSpriteIdByName("dispenser_idle_001"), Initialisation.NPCCollection, new GameObject("Dispenser"));
		val.SetActive(false);
		FakePrefab.MarkAsFakePrefab(val);
		tk2dSprite component = val.GetComponent<tk2dSprite>();
		((tk2dBaseSprite)component).HeightOffGround = 0.1f;
		val.AddComponent<Dispenser>();
		tk2dSpriteAnimator orAddComponent = GameObjectExtensions.GetOrAddComponent<tk2dSpriteAnimator>(val);
		orAddComponent.Library = Initialisation.npcAnimationCollection;
		orAddComponent.defaultClipId = Initialisation.npcAnimationCollection.GetClipIdByName("dispenser_idle");
		orAddComponent.DefaultClipId = Initialisation.npcAnimationCollection.GetClipIdByName("dispenser_idle");
		orAddComponent.playAutomatically = true;
		SpeculativeRigidbody val2 = SpriteBuilder.SetUpSpeculativeRigidbody(val.GetComponent<tk2dSprite>(), new IntVector2(0, -1), new IntVector2(21, 21));
		val2.CollideWithTileMap = false;
		val2.CollideWithOthers = true;
		((BraveBehaviour)val.GetComponent<tk2dSprite>()).renderer.material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTiltedCutout");
		((tk2dBaseSprite)val.GetComponent<tk2dSprite>()).usesOverrideMaterial = true;
		val2.PrimaryPixelCollider.CollisionLayer = (CollisionLayer)6;
		GameObject val3 = ItemBuilder.SpriteFromBundle("dispenser_disabled", Initialisation.NPCCollection.GetSpriteIdByName("dispenser_disabled"), Initialisation.NPCCollection, new GameObject("DispenserItem"));
		val3.transform.SetParent(val.transform);
		val3.transform.localPosition = new Vector3(0.6875f, 1.625f, 0f);
		tk2dSprite component2 = val3.GetComponent<tk2dSprite>();
		((tk2dBaseSprite)component2).HeightOffGround = 10f;
		GameObject val4 = ItemBuilder.SpriteFromBundle("dispenser_shadow", Initialisation.NPCCollection.GetSpriteIdByName("dispenser_shadow"), Initialisation.NPCCollection, new GameObject("DispenserShadow"));
		tk2dSprite component3 = val4.GetComponent<tk2dSprite>();
		((tk2dBaseSprite)component3).HeightOffGround = -1.7f;
		((tk2dBaseSprite)component3).SortingOrder = 0;
		((tk2dBaseSprite)component3).IsPerpendicular = false;
		((BraveBehaviour)component3).renderer.material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTilted");
		((tk2dBaseSprite)component3).usesOverrideMaterial = true;
		val4.transform.SetParent(val.transform);
		val4.transform.localPosition = new Vector3(-0.0625f, -0.125f);
		Dictionary<GameObject, float> dictionary = new Dictionary<GameObject, float> { { val, 1f } };
		DungeonPlaceable val5 = BreakableAPIToolbox.GenerateDungeonPlaceable(dictionary, 1, 1, (DungeonPrerequisite[])null);
		val5.isPassable = false;
		val5.width = 1;
		val5.height = 1;
		StaticReferences.StoredDungeonPlaceables.Add("dispenser", val5);
		StaticReferences.customPlaceables.Add("nn:dispenser", val5);
	}

	private void Start()
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		m_room = GameManager.Instance.Dungeon.data.GetAbsoluteRoomFromPosition(Vector3Extensions.IntXY(((BraveBehaviour)this).transform.position, (VectorConversions)2));
		m_room.RegisterInteractable((IPlayerInteractable)(object)this);
		itemPoint = ((Component)((BraveBehaviour)this).transform.Find("DispenserItem")).gameObject;
		itemSprite = itemPoint.gameObject.GetComponent<tk2dSprite>();
		List<int> list = new List<int>(options);
		foreach (Dispenser allDispenser in AllDispensers)
		{
			if (allDispenser.m_room == m_room)
			{
				list.Remove(allDispenser.forSale);
			}
		}
		if (list.Count > 0)
		{
			forSale = BraveUtility.RandomElement<int>(list);
		}
		else
		{
			forSale = BraveUtility.RandomElement<int>(list);
		}
		((tk2dBaseSprite)itemSprite).Collection = ((BraveBehaviour)PickupObjectDatabase.GetById(forSale)).sprite.collection;
		((tk2dBaseSprite)itemSprite).SetSprite(((BraveBehaviour)PickupObjectDatabase.GetById(forSale)).sprite.spriteId);
		((tk2dBaseSprite)itemSprite).PlaceAtPositionByAnchor(itemPoint.transform.position, (Anchor)4);
		((tk2dBaseSprite)itemSprite).UpdateZDepthAttached(0.1f, ((BraveBehaviour)this).transform.position.y, true);
		AllDispensers.Add(this);
		SpriteOutlineManager.AddOutlineToSprite((tk2dBaseSprite)(object)itemSprite, Color.black);
	}

	public override void OnDestroy()
	{
		AllDispensers.Remove(this);
		((BraveBehaviour)this).OnDestroy();
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
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		SpriteOutlineManager.RemoveOutlineFromSprite((tk2dBaseSprite)(object)itemSprite, true);
		SpriteOutlineManager.AddOutlineToSprite((tk2dBaseSprite)(object)itemSprite, Color.white);
		PickupObject byId = PickupObjectDatabase.GetById(forSale);
		EncounterTrackable component = ((Component)byId).GetComponent<EncounterTrackable>();
		string arg = ((!((Object)(object)component != (Object)null)) ? byId.DisplayName : component.journalData.GetPrimaryDisplayName(false));
		GameObject val = GameUIRoot.Instance.RegisterDefaultLabel(itemPoint.transform, new Vector3(0.9375f, 0f, 0f), $"{arg}: {Cost}[sprite \"ui_coin\"]");
		dfLabel componentInChildren = val.GetComponentInChildren<dfLabel>();
		componentInChildren.ColorizeSymbols = false;
		componentInChildren.ProcessMarkup = true;
	}

	public void Disable()
	{
		disabled = true;
	}

	public void OnExitRange(PlayerController interactor)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		SpriteOutlineManager.RemoveOutlineFromSprite((tk2dBaseSprite)(object)itemSprite, true);
		SpriteOutlineManager.AddOutlineToSprite((tk2dBaseSprite)(object)itemSprite, Color.black);
		GameUIRoot.Instance.DeregisterDefaultLabel(itemPoint.transform);
	}

	public void Interact(PlayerController interactor)
	{
		if ((Object)(object)master == (Object)null)
		{
			foreach (Chancellot allChancelot in Chancellot.allChancelots)
			{
				if (allChancelot.m_room == m_room)
				{
					master = allChancelot;
				}
			}
		}
		if (!disabled && !busy)
		{
			((MonoBehaviour)this).StartCoroutine(HandleInteraction(interactor));
		}
	}

	private IEnumerator HandleInteraction(PlayerController interactor)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CHandleInteraction_003Ed__17(0)
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
