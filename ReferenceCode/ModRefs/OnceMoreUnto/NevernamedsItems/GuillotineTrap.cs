using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.BreakableAPI;
using Alexandria.DungeonAPI;
using Alexandria.ItemAPI;
using Dungeonator;
using Pathfinding;
using UnityEngine;

namespace NevernamedsItems;

public class GuillotineTrap : BraveBehaviour
{
	[CompilerGenerated]
	private sealed class _003CDrop_003Ed__11 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public GuillotineTrap _003C_003E4__this;

		private List<SpeculativeRigidbody> _003CoverlappingRigidbodies_003E5__1;

		private List<ICollidableObject> _003Ccollidables_003E5__2;

		private List<ICollidableObject>.Enumerator _003C_003Es__3;

		private ICollidableObject _003Ccollidable_003E5__4;

		private int _003Ci_003E5__5;

		private Vector2 _003Cdirection_003E5__6;

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
		public _003CDrop_003Ed__11(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003CoverlappingRigidbodies_003E5__1 = null;
			_003Ccollidables_003E5__2 = null;
			_003C_003Es__3 = default(List<ICollidableObject>.Enumerator);
			_003Ccollidable_003E5__4 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Expected O, but got Unknown
			//IL_0099: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_0375: Unknown result type (might be due to invalid IL or missing references)
			//IL_037f: Expected O, but got Unknown
			//IL_0390: Unknown result type (might be due to invalid IL or missing references)
			//IL_039f: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0192: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_026d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0218: Unknown result type (might be due to invalid IL or missing references)
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				AkSoundEngine.PostEvent(_003C_003E4__this.triggersound, ((Component)_003C_003E4__this).gameObject);
				((BraveBehaviour)_003C_003E4__this).spriteAnimator.Play(_003C_003E4__this.fallAnimation);
				_003C_003E2__current = (object)new WaitForSeconds(0.2f);
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				_003CoverlappingRigidbodies_003E5__1 = new List<SpeculativeRigidbody>();
				_003Ccollidables_003E5__2 = PhysicsEngine.Instance.GetOverlappingCollidableObjects(_003C_003E4__this.triggerOBJ.GetComponent<SpeculativeRigidbody>().UnitBottomLeft, _003C_003E4__this.triggerOBJ.GetComponent<SpeculativeRigidbody>().UnitTopRight, false, true, (int?)null, false);
				_003C_003Es__3 = _003Ccollidables_003E5__2.GetEnumerator();
				try
				{
					while (_003C_003Es__3.MoveNext())
					{
						_003Ccollidable_003E5__4 = _003C_003Es__3.Current;
						if (_003Ccollidable_003E5__4 is SpeculativeRigidbody)
						{
							List<SpeculativeRigidbody> list = _003CoverlappingRigidbodies_003E5__1;
							ICollidableObject obj = _003Ccollidable_003E5__4;
							list.Add((SpeculativeRigidbody)(object)((obj is SpeculativeRigidbody) ? obj : null));
						}
						_003Ccollidable_003E5__4 = null;
					}
				}
				finally
				{
					((IDisposable)_003C_003Es__3/*cast due to .constrained prefix*/).Dispose();
				}
				_003C_003Es__3 = default(List<ICollidableObject>.Enumerator);
				_003Ci_003E5__5 = 0;
				while (_003Ci_003E5__5 < _003CoverlappingRigidbodies_003E5__1.Count)
				{
					if (Object.op_Implicit((Object)(object)((BraveBehaviour)_003CoverlappingRigidbodies_003E5__1[_003Ci_003E5__5]).gameActor))
					{
						_003Cdirection_003E5__6 = _003CoverlappingRigidbodies_003E5__1[_003Ci_003E5__5].UnitCenter - _003C_003E4__this.triggerOBJ.GetComponent<SpeculativeRigidbody>().UnitCenter;
						if (Object.op_Implicit((Object)(object)((BraveBehaviour)_003CoverlappingRigidbodies_003E5__1[_003Ci_003E5__5]).healthHaver))
						{
							((BraveBehaviour)_003CoverlappingRigidbodies_003E5__1[_003Ci_003E5__5]).healthHaver.ApplyDamage((((BraveBehaviour)_003CoverlappingRigidbodies_003E5__1[_003Ci_003E5__5]).gameActor is PlayerController) ? 0.5f : 50f, _003Cdirection_003E5__6, StringTableManager.GetEnemiesString("#TRAP", -1), (CoreDamageTypes)0, (DamageCategory)0, false, (PixelCollider)null, false);
						}
						if (Object.op_Implicit((Object)(object)((BraveBehaviour)_003CoverlappingRigidbodies_003E5__1[_003Ci_003E5__5]).knockbackDoer))
						{
							((BraveBehaviour)_003CoverlappingRigidbodies_003E5__1[_003Ci_003E5__5]).knockbackDoer.ApplyKnockback(_003Cdirection_003E5__6, 20f, false);
						}
						((BraveBehaviour)_003C_003E4__this).specRigidbody.RegisterTemporaryCollisionException(_003CoverlappingRigidbodies_003E5__1[_003Ci_003E5__5], 0.01f, (float?)null);
						_003CoverlappingRigidbodies_003E5__1[_003Ci_003E5__5].RegisterTemporaryCollisionException(((BraveBehaviour)_003C_003E4__this).specRigidbody, 0.01f, (float?)null);
					}
					_003Ci_003E5__5++;
				}
				((BraveBehaviour)_003C_003E4__this).specRigidbody.PixelColliders[4].Enabled = true;
				_003C_003E4__this.m_allOccupiedCells = new List<OccupiedCells>(1);
				_003C_003E4__this.m_allOccupiedCells.Add(new OccupiedCells(((BraveBehaviour)_003C_003E4__this).specRigidbody, ((BraveBehaviour)_003C_003E4__this).specRigidbody.PixelColliders[4], _003C_003E4__this.currentRoom));
				SpawnManager.SpawnVFX(Dustup, ((BraveBehaviour)_003C_003E4__this).transform.position + new Vector3(-0.1875f, -0.875f), Quaternion.identity);
				AkSoundEngine.PostEvent("Play_obj_katana_slash_01", ((Component)_003C_003E4__this).gameObject);
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

	public static GameObject Guillotine;

	public static GameObject Dustup;

	public bool isPortcullis = false;

	public string fallAnimation = "guillotine_fall";

	public string triggersound = "Play_WPN_crossbow_shot_01";

	public bool Dropped;

	public RoomHandler currentRoom;

	public GameObject triggerOBJ;

	private List<OccupiedCells> m_allOccupiedCells;

	public static void Init()
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected O, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Expected O, but got Unknown
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Expected O, but got Unknown
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Expected O, but got Unknown
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0202: Expected O, but got Unknown
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_028a: Expected O, but got Unknown
		//IL_0292: Unknown result type (might be due to invalid IL or missing references)
		//IL_0299: Expected O, but got Unknown
		//IL_029c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04be: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f0: Unknown result type (might be due to invalid IL or missing references)
		Guillotine = ItemBuilder.SpriteFromBundle("guillotine_idle_001", Initialisation.TrapCollection.GetSpriteIdByName("guillotine_idle_001"), Initialisation.TrapCollection, new GameObject("Guillotine"));
		FakePrefabExtensions.MakeFakePrefab(Guillotine);
		SpeculativeRigidbody val = SpriteBuilder.SetUpSpeculativeRigidbody(Guillotine.GetComponent<tk2dSprite>(), new IntVector2(0, -2), new IntVector2(16, 18));
		val.CollideWithTileMap = false;
		val.CollideWithOthers = true;
		((tk2dBaseSprite)((Component)Guillotine.GetComponent<tk2dSprite>()).GetComponent<tk2dSprite>()).HeightOffGround = -1f;
		((BraveBehaviour)Guillotine.GetComponent<tk2dSprite>()).renderer.material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTilted");
		((tk2dBaseSprite)Guillotine.GetComponent<tk2dSprite>()).usesOverrideMaterial = true;
		val.PixelColliders = new List<PixelCollider>
		{
			new PixelCollider
			{
				ColliderGenerationMode = (PixelColliderGeneration)0,
				CollisionLayer = (CollisionLayer)5,
				ManualWidth = 5,
				ManualHeight = 6,
				ManualOffsetX = 0,
				ManualOffsetY = -1
			},
			new PixelCollider
			{
				ColliderGenerationMode = (PixelColliderGeneration)0,
				CollisionLayer = (CollisionLayer)5,
				ManualWidth = 5,
				ManualHeight = 6,
				ManualOffsetX = 27,
				ManualOffsetY = -1
			},
			new PixelCollider
			{
				ColliderGenerationMode = (PixelColliderGeneration)0,
				CollisionLayer = (CollisionLayer)8,
				ManualWidth = 5,
				ManualHeight = 5,
				ManualOffsetX = 0,
				ManualOffsetY = 8
			},
			new PixelCollider
			{
				ColliderGenerationMode = (PixelColliderGeneration)0,
				CollisionLayer = (CollisionLayer)8,
				ManualWidth = 5,
				ManualHeight = 5,
				ManualOffsetX = 27,
				ManualOffsetY = 8
			},
			new PixelCollider
			{
				ColliderGenerationMode = (PixelColliderGeneration)0,
				CollisionLayer = (CollisionLayer)5,
				ManualWidth = 32,
				ManualHeight = 6,
				ManualOffsetX = 0,
				ManualOffsetY = -1,
				Enabled = false
			}
		};
		GameObject val2 = ItemBuilder.SpriteFromBundle("guillotine_shadow", Initialisation.TrapCollection.GetSpriteIdByName("guillotine_shadow"), Initialisation.TrapCollection, new GameObject("Shadow"));
		val2.transform.SetParent(Guillotine.transform);
		val2.transform.localPosition = new Vector3(-0.0625f, -0.125f, 50f);
		tk2dSprite component = val2.GetComponent<tk2dSprite>();
		((tk2dBaseSprite)component).HeightOffGround = -2f;
		((tk2dBaseSprite)component).SortingOrder = 0;
		((tk2dBaseSprite)component).IsPerpendicular = false;
		((BraveBehaviour)component).renderer.material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTilted");
		((tk2dBaseSprite)component).usesOverrideMaterial = true;
		GameObject val3 = new GameObject("TriggerBox");
		SpeculativeRigidbody orAddComponent = GameObjectExtensions.GetOrAddComponent<SpeculativeRigidbody>(val3);
		PixelCollider val4 = new PixelCollider();
		val4.ColliderGenerationMode = (PixelColliderGeneration)0;
		val4.CollisionLayer = (CollisionLayer)5;
		val4.IsTrigger = true;
		val4.ManualWidth = 22;
		val4.ManualHeight = 14;
		val4.ManualOffsetX = 5;
		val4.ManualOffsetY = -5;
		orAddComponent.PixelColliders = new List<PixelCollider> { val4 };
		val3.transform.SetParent(Guillotine.transform);
		tk2dSpriteAnimator orAddComponent2 = GameObjectExtensions.GetOrAddComponent<tk2dSpriteAnimator>(Guillotine);
		orAddComponent2.Library = Initialisation.trapAnimationCollection;
		orAddComponent2.defaultClipId = Initialisation.trapAnimationCollection.GetClipIdByName("guillotine_idle");
		orAddComponent2.DefaultClipId = Initialisation.trapAnimationCollection.GetClipIdByName("guillotine_idle");
		orAddComponent2.playAutomatically = true;
		Guillotine.AddComponent<GuillotineTrap>();
		GameObjectExtensions.SetLayerRecursively(Guillotine, LayerMask.NameToLayer("FG_Critical"));
		DungeonPlaceable val5 = BreakableAPIToolbox.GenerateDungeonPlaceable(new Dictionary<GameObject, float> { { Guillotine.gameObject, 1f } }, 1, 1, (DungeonPrerequisite[])null);
		val5.isPassable = true;
		val5.width = 2;
		val5.height = 1;
		val5.variantTiers[0].unitOffset = new Vector2(0f, 0.4375f);
		StaticReferences.StoredDungeonPlaceables.Add("guillotinetrap", val5);
		StaticReferences.customPlaceables.Add("nn:guillotinetrap", val5);
		GameObject val6 = FakePrefab.Clone(Guillotine);
		((Object)val6).name = "Portcullis";
		FakePrefabExtensions.MakeFakePrefab(val6);
		tk2dSpriteAnimator orAddComponent3 = GameObjectExtensions.GetOrAddComponent<tk2dSpriteAnimator>(val6);
		orAddComponent3.Library = Initialisation.trapAnimationCollection;
		orAddComponent3.defaultClipId = Initialisation.trapAnimationCollection.GetClipIdByName("portcullis_idle");
		orAddComponent3.DefaultClipId = Initialisation.trapAnimationCollection.GetClipIdByName("portcullis_idle");
		orAddComponent3.playAutomatically = true;
		val6.GetComponent<GuillotineTrap>().isPortcullis = true;
		DungeonPlaceable val7 = BreakableAPIToolbox.GenerateDungeonPlaceable(new Dictionary<GameObject, float> { { val6.gameObject, 1f } }, 1, 1, (DungeonPrerequisite[])null);
		val7.isPassable = true;
		val7.width = 2;
		val7.height = 1;
		val7.variantTiers[0].unitOffset = new Vector2(0f, 0.4375f);
		StaticReferences.StoredDungeonPlaceables.Add("portcullis", val7);
		StaticReferences.customPlaceables.Add("nn:portcullis", val7);
		Dustup = VFXToolbox.CreateVFXBundle("GuillotineDust", new IntVector2(35, 27), (Anchor)0, usesZHeight: true, 0.1f, -1f, null);
	}

	public void Start()
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected O, but got Unknown
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Invalid comparison between Unknown and I4
		currentRoom = Vector3Extensions.GetAbsoluteRoom(((BraveBehaviour)this).transform.position);
		((BraveBehaviour)this).specRigidbody.PixelColliders[4].Enabled = false;
		triggerOBJ = ((Component)((BraveBehaviour)this).transform.Find("TriggerBox")).gameObject;
		SpeculativeRigidbody component = triggerOBJ.GetComponent<SpeculativeRigidbody>();
		component.OnTriggerCollision = (OnTriggerDelegate)Delegate.Combine((Delegate)(object)component.OnTriggerCollision, (Delegate)new OnTriggerDelegate(HandleTrigger));
		if (!isPortcullis && Gunfigs._Gunfig.Enabled("Portcullis Trap Replacements"))
		{
			isPortcullis = true;
		}
		if (isPortcullis)
		{
			if ((int)GameManager.Instance.Dungeon.tileIndices.tilesetId == 2)
			{
				((BraveBehaviour)this).spriteAnimator.defaultClipId = Initialisation.trapAnimationCollection.GetClipIdByName("portculliskeep_idle");
				((BraveBehaviour)this).spriteAnimator.DefaultClipId = Initialisation.trapAnimationCollection.GetClipIdByName("portculliskeep_idle");
				((BraveBehaviour)this).spriteAnimator.Play("portculliskeep_idle");
				fallAnimation = "portculliskeep_fall";
				triggersound = "Play_OBJ_chainpot_drop_01";
			}
			else
			{
				((BraveBehaviour)this).spriteAnimator.defaultClipId = Initialisation.trapAnimationCollection.GetClipIdByName("portcullis_idle");
				((BraveBehaviour)this).spriteAnimator.DefaultClipId = Initialisation.trapAnimationCollection.GetClipIdByName("portcullis_idle");
				((BraveBehaviour)this).spriteAnimator.Play("portcullis_idle");
				fallAnimation = "portcullis_fall";
				triggersound = "Play_OBJ_chainpot_drop_01";
			}
		}
	}

	private void HandleTrigger(SpeculativeRigidbody specRigidbody, SpeculativeRigidbody sourceSpecRigidbody, CollisionData collisionData)
	{
		if (!Dropped)
		{
			Dropped = true;
			((MonoBehaviour)this).StartCoroutine(Drop());
		}
	}

	public IEnumerator Drop()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CDrop_003Ed__11(0)
		{
			_003C_003E4__this = this
		};
	}

	public override void OnDestroy()
	{
		if (GameManager.HasInstance && Pathfinder.HasInstance && Object.op_Implicit((Object)(object)((BraveBehaviour)this).specRigidbody) && m_allOccupiedCells != null)
		{
			for (int i = 0; i < m_allOccupiedCells.Count; i++)
			{
				OccupiedCells val = m_allOccupiedCells[i];
				if (val != null)
				{
					val.Clear();
				}
			}
		}
		((BraveBehaviour)this).OnDestroy();
	}
}
