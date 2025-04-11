using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Alexandria.ChestAPI;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Dungeonator;
using Pathfinding;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class Keygen : PlayerItem
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static CellValidator _003C_003E9__13_0;

		internal bool _003CLaunchChestSpawns_003Eb__13_0(IntVector2 c)
		{
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			//IL_0046: Unknown result type (might be due to invalid IL or missing references)
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			//IL_005b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0061: Invalid comparison between Unknown and I4
			//IL_0072: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			for (int i = 0; i < 5; i++)
			{
				for (int j = 0; j < 5; j++)
				{
					if (!GameManager.Instance.Dungeon.data.CheckInBoundsAndValid(c.x + i, c.y + j) || (int)GameManager.Instance.Dungeon.data[c.x + i, c.y + j].type == 4 || GameManager.Instance.Dungeon.data[c.x + i, c.y + j].isOccupied)
					{
						return false;
					}
				}
			}
			return true;
		}
	}

	[CompilerGenerated]
	private sealed class _003CHandleCombatRoomExpansion_003Ed__18 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public RoomHandler sourceRoom;

		public RoomHandler targetRoom;

		public Chest sourceChest;

		public Keygen _003C_003E4__this;

		private float _003Cduration_003E5__1;

		private float _003Celapsed_003E5__2;

		private int _003CnumExpansionsDone_003E5__3;

		private Dungeon _003Cd_003E5__4;

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
		public _003CHandleCombatRoomExpansion_003Ed__18(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003Cd_003E5__4 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_004c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0056: Expected O, but got Unknown
			//IL_0144: Unknown result type (might be due to invalid IL or missing references)
			//IL_014d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0152: Unknown result type (might be due to invalid IL or missing references)
			//IL_0162: Unknown result type (might be due to invalid IL or missing references)
			//IL_016b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0170: Unknown result type (might be due to invalid IL or missing references)
			//IL_0187: Unknown result type (might be due to invalid IL or missing references)
			//IL_0191: Expected O, but got Unknown
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = (object)new WaitForSeconds(_003C_003E4__this.DelayPreExpansion);
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				_003Cduration_003E5__1 = 5.5f;
				_003Celapsed_003E5__2 = 0f;
				_003CnumExpansionsDone_003E5__3 = 0;
				goto IL_0104;
			case 2:
				_003C_003E1__state = -1;
				goto IL_0104;
			case 3:
				_003C_003E1__state = -1;
				_003C_003E2__current = _003C_003E4__this.HandleCombatWaves(_003Cd_003E5__4, targetRoom, sourceChest);
				_003C_003E1__state = 4;
				return true;
			case 4:
				{
					_003C_003E1__state = -1;
					return false;
				}
				IL_0104:
				if (_003Celapsed_003E5__2 < _003Cduration_003E5__1)
				{
					_003Celapsed_003E5__2 += BraveTime.DeltaTime * 9f;
					while (_003Celapsed_003E5__2 > (float)_003CnumExpansionsDone_003E5__3)
					{
						_003CnumExpansionsDone_003E5__3++;
						_003C_003E4__this.ExpandRoom(targetRoom);
						AkSoundEngine.PostEvent("Play_OBJ_rock_break_01", ((Component)GameManager.Instance).gameObject);
					}
					_003C_003E2__current = null;
					_003C_003E1__state = 2;
					return true;
				}
				_003Cd_003E5__4 = GameManager.Instance.Dungeon;
				Pathfinder.Instance.InitializeRegion(_003Cd_003E5__4.data, targetRoom.area.basePosition + new IntVector2(-5, -5), targetRoom.area.dimensions + new IntVector2(10, 10));
				_003C_003E2__current = (object)new WaitForSeconds(_003C_003E4__this.DelayPostExpansionPreEnemies);
				_003C_003E1__state = 3;
				return true;
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

	[CompilerGenerated]
	private sealed class _003CHandleCombatRoomShrinking_003Ed__20 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public RoomHandler targetRoom;

		public Keygen _003C_003E4__this;

		private float _003Celapsed_003E5__1;

		private int _003CnumExpansionsDone_003E5__2;

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
		public _003CHandleCombatRoomShrinking_003Ed__20(int _003C_003E1__state)
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
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003Celapsed_003E5__1 = 5.5f;
				_003CnumExpansionsDone_003E5__2 = 6;
				break;
			case 1:
				_003C_003E1__state = -1;
				break;
			}
			if (_003Celapsed_003E5__1 > 0f)
			{
				_003Celapsed_003E5__1 -= BraveTime.DeltaTime * 9f;
				while (_003Celapsed_003E5__1 < (float)_003CnumExpansionsDone_003E5__2 && _003CnumExpansionsDone_003E5__2 > 0)
				{
					_003CnumExpansionsDone_003E5__2--;
					_003C_003E4__this.ShrinkRoom(targetRoom);
				}
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
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
	private sealed class _003CHandleCombatWaves_003Ed__19 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Dungeon d;

		public RoomHandler newRoom;

		public Chest sourceChest;

		public Keygen _003C_003E4__this;

		private DrillWaveDefinition[] _003CwavesToUse_003E5__1;

		private ItemQuality _003C_003Es__2;

		private DrillWaveDefinition[] _003C_003Es__3;

		private int _003C_003Es__4;

		private DrillWaveDefinition _003CcurrentWave_003E5__5;

		private int _003CnumEnemiesToSpawn_003E5__6;

		private int _003Ci_003E5__7;

		private List<AIActor> _003CactiveEnemies_003E5__8;

		private int _003Cj_003E5__9;

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
		public _003CHandleCombatWaves_003Ed__19(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003CwavesToUse_003E5__1 = null;
			_003C_003Es__3 = null;
			_003CactiveEnemies_003E5__8 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_0066: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			//IL_007e: Expected I4, but got Unknown
			//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01aa: Expected O, but got Unknown
			//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0136: Unknown result type (might be due to invalid IL or missing references)
			//IL_017d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0187: Expected O, but got Unknown
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
			{
				_003C_003E1__state = -1;
				_003CwavesToUse_003E5__1 = _003C_003E4__this.D_Quality_Waves;
				ItemQuality qualityFromChest = GameManager.Instance.RewardManager.GetQualityFromChest(sourceChest);
				_003C_003Es__2 = qualityFromChest;
				ItemQuality val = _003C_003Es__2;
				switch (val - 2)
				{
				case 0:
					_003CwavesToUse_003E5__1 = _003C_003E4__this.C_Quality_Waves;
					break;
				case 1:
					_003CwavesToUse_003E5__1 = _003C_003E4__this.B_Quality_Waves;
					break;
				case 2:
					_003CwavesToUse_003E5__1 = _003C_003E4__this.A_Quality_Waves;
					break;
				case 3:
					_003CwavesToUse_003E5__1 = _003C_003E4__this.S_Quality_Waves;
					break;
				}
				_003C_003Es__3 = _003CwavesToUse_003E5__1;
				_003C_003Es__4 = 0;
				break;
			}
			case 1:
				_003C_003E1__state = -1;
				goto IL_01bb;
			case 2:
				{
					_003C_003E1__state = -1;
					goto IL_01bb;
				}
				IL_01bb:
				if (newRoom.GetActiveEnemiesCount((ActiveEnemyType)1) > 0)
				{
					_003C_003E2__current = (object)new WaitForSeconds(1f);
					_003C_003E1__state = 2;
					return true;
				}
				if (newRoom.GetActiveEnemiesCount((ActiveEnemyType)0) > 0)
				{
					_003CactiveEnemies_003E5__8 = newRoom.GetActiveEnemies((ActiveEnemyType)0);
					_003Cj_003E5__9 = 0;
					while (_003Cj_003E5__9 < _003CactiveEnemies_003E5__8.Count)
					{
						if (_003CactiveEnemies_003E5__8[_003Cj_003E5__9].IsNormalEnemy)
						{
							_003CactiveEnemies_003E5__8[_003Cj_003E5__9].EraseFromExistence(false);
						}
						_003Cj_003E5__9++;
					}
					_003CactiveEnemies_003E5__8 = null;
				}
				_003C_003Es__4++;
				break;
			}
			if (_003C_003Es__4 < _003C_003Es__3.Length)
			{
				_003CcurrentWave_003E5__5 = _003C_003Es__3[_003C_003Es__4];
				_003CnumEnemiesToSpawn_003E5__6 = Random.Range(_003CcurrentWave_003E5__5.MinEnemies, _003CcurrentWave_003E5__5.MaxEnemies + 1);
				_003Ci_003E5__7 = 0;
				while (_003Ci_003E5__7 < _003CnumEnemiesToSpawn_003E5__6)
				{
					newRoom.AddSpecificEnemyToRoomProcedurally(d.GetWeightedProceduralEnemy().enemyGuid, true, (Vector2?)null);
					_003Ci_003E5__7++;
				}
				_003C_003E2__current = (object)new WaitForSeconds(3f);
				_003C_003E1__state = 1;
				return true;
			}
			_003C_003Es__3 = null;
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
	private sealed class _003CHandleSeamlessTransitionToCombatRoom_003Ed__17 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public RoomHandler sourceRoom;

		public Chest sourceChest;

		public Keygen _003C_003E4__this;

		private Dungeon _003Cd_003E5__1;

		private int _003CtmapExpansion_003E5__2;

		private RoomHandler _003CnewRoom_003E5__3;

		private List<Transform> _003CmovedObjects_003E5__4;

		private Vector3 _003CchestOffset_003E5__5;

		private GameObject _003CspawnedVFX_003E5__6;

		private tk2dBaseSprite _003CspawnedSprite_003E5__7;

		private Vector2 _003ColdPlayerPosition_003E5__8;

		private Vector2 _003CplayerOffset_003E5__9;

		private Vector2 _003CnewPlayerPosition_003E5__10;

		private bool _003CgoodToGo_003E5__11;

		private int _003Ci_003E5__12;

		private Transform _003Ctransform_003E5__13;

		private int _003Cj_003E5__14;

		private int _003Ck_003E5__15;

		private float _003Cnum_003E5__16;

		private int _003Cl_003E5__17;

		private int _003Cm_003E5__18;

		private int _003Cn_003E5__19;

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
		public _003CHandleSeamlessTransitionToCombatRoom_003Ed__17(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003Cd_003E5__1 = null;
			_003CnewRoom_003E5__3 = null;
			_003CmovedObjects_003E5__4 = null;
			_003CspawnedVFX_003E5__6 = null;
			_003CspawnedSprite_003E5__7 = null;
			_003Ctransform_003E5__13 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_0090: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_046b: Unknown result type (might be due to invalid IL or missing references)
			//IL_047a: Unknown result type (might be due to invalid IL or missing references)
			//IL_047f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0484: Unknown result type (might be due to invalid IL or missing references)
			//IL_05e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_05e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_05ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_06d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0714: Unknown result type (might be due to invalid IL or missing references)
			//IL_0726: Unknown result type (might be due to invalid IL or missing references)
			//IL_072c: Invalid comparison between Unknown and I4
			//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0528: Unknown result type (might be due to invalid IL or missing references)
			//IL_053e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0245: Unknown result type (might be due to invalid IL or missing references)
			//IL_024b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0250: Unknown result type (might be due to invalid IL or missing references)
			//IL_0255: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_02cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0307: Unknown result type (might be due to invalid IL or missing references)
			//IL_0333: Unknown result type (might be due to invalid IL or missing references)
			//IL_0343: Unknown result type (might be due to invalid IL or missing references)
			//IL_0359: Unknown result type (might be due to invalid IL or missing references)
			//IL_036b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0371: Invalid comparison between Unknown and I4
			//IL_0213: Unknown result type (might be due to invalid IL or missing references)
			//IL_021e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0223: Unknown result type (might be due to invalid IL or missing references)
			//IL_0228: Unknown result type (might be due to invalid IL or missing references)
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003Cd_003E5__1 = GameManager.Instance.Dungeon;
				((BraveBehaviour)sourceChest).majorBreakable.TemporarilyInvulnerable = true;
				sourceRoom.DeregisterInteractable((IPlayerInteractable)(object)sourceChest);
				_003CtmapExpansion_003E5__2 = 13;
				_003CnewRoom_003E5__3 = _003Cd_003E5__1.RuntimeDuplicateChunk(sourceRoom.area.basePosition, sourceRoom.area.dimensions, _003CtmapExpansion_003E5__2, sourceRoom, true);
				_003CnewRoom_003E5__3.CompletelyPreventLeaving = true;
				_003CmovedObjects_003E5__4 = new List<Transform>();
				_003Ci_003E5__12 = 0;
				while (_003Ci_003E5__12 < _003C_003E4__this.c_rewardRoomObjects.Length)
				{
					_003Ctransform_003E5__13 = sourceRoom.hierarchyParent.Find(_003C_003E4__this.c_rewardRoomObjects[_003Ci_003E5__12]);
					if (Object.op_Implicit((Object)(object)_003Ctransform_003E5__13))
					{
						_003CmovedObjects_003E5__4.Add(_003Ctransform_003E5__13);
						_003C_003E4__this.MoveObjectBetweenRooms(_003Ctransform_003E5__13, sourceRoom, _003CnewRoom_003E5__3);
					}
					_003Ctransform_003E5__13 = null;
					_003Ci_003E5__12++;
				}
				_003C_003E4__this.MoveObjectBetweenRooms(((BraveBehaviour)sourceChest).transform, sourceRoom, _003CnewRoom_003E5__3);
				if (Object.op_Implicit((Object)(object)((BraveBehaviour)sourceChest).specRigidbody))
				{
					PathBlocker.BlockRigidbody(((BraveBehaviour)sourceChest).specRigidbody, false);
				}
				_003CchestOffset_003E5__5 = _003C_003E4__this.m_baseChestOffset;
				if (((Object)sourceChest).name.Contains("_Red") || ((Object)sourceChest).name.Contains("_Black"))
				{
					_003CchestOffset_003E5__5 += _003C_003E4__this.m_largeChestOffset;
				}
				_003CspawnedVFX_003E5__6 = SpawnManager.SpawnVFX(_003C_003E4__this.DrillVFXPrefab, ((BraveBehaviour)sourceChest).transform.position + _003CchestOffset_003E5__5, Quaternion.identity);
				_003CspawnedSprite_003E5__7 = _003CspawnedVFX_003E5__6.GetComponent<tk2dBaseSprite>();
				_003CspawnedSprite_003E5__7.HeightOffGround = 1f;
				_003CspawnedSprite_003E5__7.UpdateZDepth();
				_003ColdPlayerPosition_003E5__8 = Vector3Extensions.XY(((BraveBehaviour)GameManager.Instance.BestActivePlayer).transform.position);
				_003CplayerOffset_003E5__9 = _003ColdPlayerPosition_003E5__8 - ((IntVector2)(ref sourceRoom.area.basePosition)).ToVector2();
				_003CnewPlayerPosition_003E5__10 = ((IntVector2)(ref _003CnewRoom_003E5__3.area.basePosition)).ToVector2() + _003CplayerOffset_003E5__9;
				Pixelator.Instance.FadeToColor(0.25f, Color.white, true, 0.125f);
				Pathfinder.Instance.InitializeRegion(_003Cd_003E5__1.data, _003CnewRoom_003E5__3.area.basePosition, _003CnewRoom_003E5__3.area.dimensions);
				GameManager.Instance.BestActivePlayer.WarpToPoint(_003CnewPlayerPosition_003E5__10, false, false);
				if ((int)GameManager.Instance.CurrentGameType == 1)
				{
					GameManager.Instance.GetOtherPlayer(GameManager.Instance.BestActivePlayer).ReuniteWithOtherPlayer(GameManager.Instance.BestActivePlayer, false);
				}
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				_003Cj_003E5__14 = 0;
				while (_003Cj_003E5__14 < GameManager.Instance.AllPlayers.Length)
				{
					GameManager.Instance.AllPlayers[_003Cj_003E5__14].WarpFollowersToPlayer(false);
					GameManager.Instance.AllPlayers[_003Cj_003E5__14].WarpCompanionsToPlayer(false);
					_003Cj_003E5__14++;
				}
				_003C_003E2__current = ((MonoBehaviour)_003Cd_003E5__1).StartCoroutine(_003C_003E4__this.HandleCombatRoomExpansion(sourceRoom, _003CnewRoom_003E5__3, sourceChest));
				_003C_003E1__state = 2;
				return true;
			case 2:
				_003C_003E1__state = -1;
				_003C_003E4__this.DisappearDrillPoof.SpawnAtPosition(Vector2.op_Implicit(_003CspawnedSprite_003E5__7.WorldBottomLeft + new Vector2(-0.0625f, 0.25f)), 0f, (Transform)null, (Vector2?)null, (Vector2?)null, (float?)3f, false, (SpawnMethod)null, (tk2dBaseSprite)null, false);
				Object.Destroy((Object)(object)_003CspawnedVFX_003E5__6.gameObject);
				sourceChest.ForceUnlock();
				AkSoundEngine.PostEvent("Stop_OBJ_paydaydrill_loop_01", ((Component)GameManager.Instance).gameObject);
				AkSoundEngine.PostEvent("Play_OBJ_item_spawn_01", ((Component)GameManager.Instance).gameObject);
				_003CgoodToGo_003E5__11 = false;
				goto IL_05ac;
			case 3:
				_003C_003E1__state = -1;
				goto IL_05ac;
			case 4:
				{
					_003C_003E1__state = -1;
					_003Cm_003E5__18 = 0;
					while (_003Cm_003E5__18 < GameManager.Instance.AllPlayers.Length)
					{
						GameManager.Instance.AllPlayers[_003Cm_003E5__18].ClearInputOverride("shrinkage");
						_003Cm_003E5__18++;
					}
					Pixelator.Instance.FadeToColor(0.25f, Color.white, true, 0.125f);
					AkSoundEngine.PostEvent("Play_OBJ_paydaydrill_end_01", ((Component)GameManager.Instance).gameObject);
					GameManager.Instance.MainCameraController.SetManualControl(false, false);
					GameManager.Instance.BestActivePlayer.WarpToPoint(_003ColdPlayerPosition_003E5__8, false, false);
					if ((int)GameManager.Instance.CurrentGameType == 1)
					{
						GameManager.Instance.GetOtherPlayer(GameManager.Instance.BestActivePlayer).ReuniteWithOtherPlayer(GameManager.Instance.BestActivePlayer, false);
					}
					_003C_003E4__this.MoveObjectBetweenRooms(((BraveBehaviour)sourceChest).transform, _003CnewRoom_003E5__3, sourceRoom);
					_003Cn_003E5__19 = 0;
					while (_003Cn_003E5__19 < _003CmovedObjects_003E5__4.Count)
					{
						_003C_003E4__this.MoveObjectBetweenRooms(_003CmovedObjects_003E5__4[_003Cn_003E5__19], _003CnewRoom_003E5__3, sourceRoom);
						_003Cn_003E5__19++;
					}
					sourceRoom.RegisterInteractable((IPlayerInteractable)(object)sourceChest);
					_003C_003E4__this.drillInEffect = false;
					return false;
				}
				IL_05ac:
				if (!_003CgoodToGo_003E5__11)
				{
					_003CgoodToGo_003E5__11 = true;
					_003Ck_003E5__15 = 0;
					while (_003Ck_003E5__15 < GameManager.Instance.AllPlayers.Length)
					{
						_003Cnum_003E5__16 = Vector2.Distance(((BraveBehaviour)sourceChest).specRigidbody.UnitCenter, ((GameActor)GameManager.Instance.AllPlayers[_003Ck_003E5__15]).CenterPosition);
						if (_003Cnum_003E5__16 > 3f)
						{
							_003CgoodToGo_003E5__11 = false;
						}
						_003Ck_003E5__15++;
					}
					_003C_003E2__current = null;
					_003C_003E1__state = 3;
					return true;
				}
				GameManager.Instance.MainCameraController.SetManualControl(true, true);
				GameManager.Instance.MainCameraController.OverridePosition = Vector2.op_Implicit(((GameActor)GameManager.Instance.BestActivePlayer).CenterPosition);
				_003Cl_003E5__17 = 0;
				while (_003Cl_003E5__17 < GameManager.Instance.AllPlayers.Length)
				{
					GameManager.Instance.AllPlayers[_003Cl_003E5__17].SetInputOverride("shrinkage");
					_003Cl_003E5__17++;
				}
				_003C_003E2__current = ((MonoBehaviour)_003Cd_003E5__1).StartCoroutine(_003C_003E4__this.HandleCombatRoomShrinking(_003CnewRoom_003E5__3));
				_003C_003E1__state = 4;
				return true;
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

	[CompilerGenerated]
	private sealed class _003CHandleTransitionToFallbackCombatRoom_003Ed__16 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public RoomHandler sourceRoom;

		public Chest sourceChest;

		public Keygen _003C_003E4__this;

		private Dungeon _003Cd_003E5__1;

		private RoomHandler _003CnewRoom_003E5__2;

		private Vector3 _003ColdChestPosition_003E5__3;

		private SpeculativeRigidbody _003Ccomponent_003E5__4;

		private tk2dBaseSprite _003Ccomponent2_003E5__5;

		private Vector3 _003CchestOffset_003E5__6;

		private GameObject _003CspawnedVFX_003E5__7;

		private tk2dBaseSprite _003CspawnedSprite_003E5__8;

		private Vector2 _003ColdPlayerPosition_003E5__9;

		private Vector2 _003CnewPlayerPosition_003E5__10;

		private bool _003CgoodToGo_003E5__11;

		private SpeculativeRigidbody _003Ccomponent3_003E5__12;

		private tk2dBaseSprite _003Ccomponent4_003E5__13;

		private int _003Ci_003E5__14;

		private int _003Cj_003E5__15;

		private float _003Cnum_003E5__16;

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
		public _003CHandleTransitionToFallbackCombatRoom_003Ed__16(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003Cd_003E5__1 = null;
			_003CnewRoom_003E5__2 = null;
			_003Ccomponent_003E5__4 = null;
			_003Ccomponent2_003E5__5 = null;
			_003CspawnedVFX_003E5__7 = null;
			_003CspawnedSprite_003E5__8 = null;
			_003Ccomponent3_003E5__12 = null;
			_003Ccomponent4_003E5__13 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0429: Unknown result type (might be due to invalid IL or missing references)
			//IL_0438: Unknown result type (might be due to invalid IL or missing references)
			//IL_043d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0442: Unknown result type (might be due to invalid IL or missing references)
			//IL_03c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ca: Expected O, but got Unknown
			//IL_0588: Unknown result type (might be due to invalid IL or missing references)
			//IL_05a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_05b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_05bc: Invalid comparison between Unknown and I4
			//IL_0189: Unknown result type (might be due to invalid IL or missing references)
			//IL_018e: Unknown result type (might be due to invalid IL or missing references)
			//IL_05f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_04e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_04fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0203: Unknown result type (might be due to invalid IL or missing references)
			//IL_0208: Unknown result type (might be due to invalid IL or missing references)
			//IL_020d: Unknown result type (might be due to invalid IL or missing references)
			//IL_025a: Unknown result type (might be due to invalid IL or missing references)
			//IL_025f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0264: Unknown result type (might be due to invalid IL or missing references)
			//IL_0275: Unknown result type (might be due to invalid IL or missing references)
			//IL_0284: Unknown result type (might be due to invalid IL or missing references)
			//IL_0289: Unknown result type (might be due to invalid IL or missing references)
			//IL_028e: Unknown result type (might be due to invalid IL or missing references)
			//IL_029d: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_0301: Unknown result type (might be due to invalid IL or missing references)
			//IL_0307: Invalid comparison between Unknown and I4
			//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01db: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003Cd_003E5__1 = GameManager.Instance.Dungeon;
				((BraveBehaviour)sourceChest).majorBreakable.TemporarilyInvulnerable = true;
				sourceRoom.DeregisterInteractable((IPlayerInteractable)(object)sourceChest);
				_003CnewRoom_003E5__2 = _003Cd_003E5__1.AddRuntimeRoom(_003C_003E4__this.GenericFallbackCombatRoom, (Action<RoomHandler>)null, (LightGenerationStyle)1);
				_003CnewRoom_003E5__2.CompletelyPreventLeaving = true;
				_003ColdChestPosition_003E5__3 = ((BraveBehaviour)sourceChest).transform.position;
				((BraveBehaviour)sourceChest).transform.position = ((IntVector2)(ref _003CnewRoom_003E5__2.Epicenter)).ToVector3();
				if ((Object)(object)((BraveBehaviour)sourceChest).transform.parent == (Object)(object)sourceRoom.hierarchyParent)
				{
					((BraveBehaviour)sourceChest).transform.parent = _003CnewRoom_003E5__2.hierarchyParent;
				}
				_003Ccomponent_003E5__4 = ((Component)sourceChest).GetComponent<SpeculativeRigidbody>();
				if (Object.op_Implicit((Object)(object)_003Ccomponent_003E5__4))
				{
					_003Ccomponent_003E5__4.Reinitialize();
					PathBlocker.BlockRigidbody(_003Ccomponent_003E5__4, false);
				}
				_003Ccomponent2_003E5__5 = ((Component)sourceChest).GetComponent<tk2dBaseSprite>();
				if (Object.op_Implicit((Object)(object)_003Ccomponent2_003E5__5))
				{
					_003Ccomponent2_003E5__5.UpdateZDepth();
				}
				_003CchestOffset_003E5__6 = _003C_003E4__this.m_baseChestOffset;
				if (((Object)sourceChest).name.Contains("_Red") || ((Object)sourceChest).name.Contains("_Black"))
				{
					_003CchestOffset_003E5__6 += _003C_003E4__this.m_largeChestOffset;
				}
				_003CspawnedVFX_003E5__7 = SpawnManager.SpawnVFX(_003C_003E4__this.DrillVFXPrefab, ((BraveBehaviour)sourceChest).transform.position + _003CchestOffset_003E5__6, Quaternion.identity);
				_003CspawnedSprite_003E5__8 = _003CspawnedVFX_003E5__7.GetComponent<tk2dBaseSprite>();
				_003CspawnedSprite_003E5__8.HeightOffGround = 1f;
				_003CspawnedSprite_003E5__8.UpdateZDepth();
				_003ColdPlayerPosition_003E5__9 = Vector3Extensions.XY(((BraveBehaviour)GameManager.Instance.BestActivePlayer).transform.position);
				_003CnewPlayerPosition_003E5__10 = ((IntVector2)(ref _003CnewRoom_003E5__2.Epicenter)).ToVector2() + new Vector2(0f, -3f);
				Pixelator.Instance.FadeToColor(0.25f, Color.white, true, 0.125f);
				Pathfinder.Instance.InitializeRegion(_003Cd_003E5__1.data, _003CnewRoom_003E5__2.area.basePosition, _003CnewRoom_003E5__2.area.dimensions);
				GameManager.Instance.BestActivePlayer.WarpToPoint(_003CnewPlayerPosition_003E5__10, false, false);
				if ((int)GameManager.Instance.CurrentGameType == 1)
				{
					GameManager.Instance.GetOtherPlayer(GameManager.Instance.BestActivePlayer).ReuniteWithOtherPlayer(GameManager.Instance.BestActivePlayer, false);
				}
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				_003Ci_003E5__14 = 0;
				while (_003Ci_003E5__14 < GameManager.Instance.AllPlayers.Length)
				{
					GameManager.Instance.AllPlayers[_003Ci_003E5__14].WarpFollowersToPlayer(false);
					GameManager.Instance.AllPlayers[_003Ci_003E5__14].WarpCompanionsToPlayer(false);
					_003Ci_003E5__14++;
				}
				_003C_003E2__current = (object)new WaitForSeconds(_003C_003E4__this.DelayPostExpansionPreEnemies);
				_003C_003E1__state = 2;
				return true;
			case 2:
				_003C_003E1__state = -1;
				_003C_003E2__current = ((MonoBehaviour)_003C_003E4__this).StartCoroutine(_003C_003E4__this.HandleCombatWaves(_003Cd_003E5__1, _003CnewRoom_003E5__2, sourceChest));
				_003C_003E1__state = 3;
				return true;
			case 3:
				_003C_003E1__state = -1;
				_003C_003E4__this.DisappearDrillPoof.SpawnAtPosition(Vector2.op_Implicit(_003CspawnedSprite_003E5__8.WorldBottomLeft + new Vector2(-0.0625f, 0.25f)), 0f, (Transform)null, (Vector2?)null, (Vector2?)null, (float?)3f, false, (SpawnMethod)null, (tk2dBaseSprite)null, false);
				Object.Destroy((Object)(object)_003CspawnedVFX_003E5__7.gameObject);
				AkSoundEngine.PostEvent("Stop_OBJ_paydaydrill_loop_01", ((Component)GameManager.Instance).gameObject);
				AkSoundEngine.PostEvent("Play_OBJ_item_spawn_01", ((Component)GameManager.Instance).gameObject);
				sourceChest.ForceUnlock();
				_003CgoodToGo_003E5__11 = false;
				break;
			case 4:
				_003C_003E1__state = -1;
				break;
			}
			if (!_003CgoodToGo_003E5__11)
			{
				_003CgoodToGo_003E5__11 = true;
				_003Cj_003E5__15 = 0;
				while (_003Cj_003E5__15 < GameManager.Instance.AllPlayers.Length)
				{
					_003Cnum_003E5__16 = Vector2.Distance(((BraveBehaviour)sourceChest).specRigidbody.UnitCenter, ((GameActor)GameManager.Instance.AllPlayers[_003Cj_003E5__15]).CenterPosition);
					if (_003Cnum_003E5__16 > 3f)
					{
						_003CgoodToGo_003E5__11 = false;
					}
					_003Cj_003E5__15++;
				}
				_003C_003E2__current = null;
				_003C_003E1__state = 4;
				return true;
			}
			Pixelator.Instance.FadeToColor(0.25f, Color.white, true, 0.125f);
			GameManager.Instance.BestActivePlayer.WarpToPoint(_003ColdPlayerPosition_003E5__9, false, false);
			if ((int)GameManager.Instance.CurrentGameType == 1)
			{
				GameManager.Instance.GetOtherPlayer(GameManager.Instance.BestActivePlayer).ReuniteWithOtherPlayer(GameManager.Instance.BestActivePlayer, false);
			}
			((BraveBehaviour)sourceChest).transform.position = _003ColdChestPosition_003E5__3;
			if ((Object)(object)((BraveBehaviour)sourceChest).transform.parent == (Object)(object)_003CnewRoom_003E5__2.hierarchyParent)
			{
				((BraveBehaviour)sourceChest).transform.parent = sourceRoom.hierarchyParent;
			}
			_003Ccomponent3_003E5__12 = ((Component)sourceChest).GetComponent<SpeculativeRigidbody>();
			if (Object.op_Implicit((Object)(object)_003Ccomponent3_003E5__12))
			{
				_003Ccomponent3_003E5__12.Reinitialize();
			}
			_003Ccomponent4_003E5__13 = ((Component)sourceChest).GetComponent<tk2dBaseSprite>();
			if (Object.op_Implicit((Object)(object)_003Ccomponent4_003E5__13))
			{
				_003Ccomponent4_003E5__13.UpdateZDepth();
			}
			sourceRoom.RegisterInteractable((IPlayerInteractable)(object)sourceChest);
			_003C_003E4__this.drillInEffect = false;
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
	private sealed class _003CLaunchChestSpawns_003Ed__13 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Keygen _003C_003E4__this;

		private List<CachedChestData> _003CfailedList_003E5__1;

		private int _003Ci_003E5__2;

		private CachedChestData _003CcachedChestData_003E5__3;

		private RoomHandler _003Centrance_003E5__4;

		private RoomHandler _003CroomHandler_003E5__5;

		private CellValidator _003CcellValidator_003E5__6;

		private IntVector2? _003CrandomAvailableCell_003E5__7;

		private IntVector2? _003CintVector_003E5__8;

		private int _003Cj_003E5__9;

		private int _003Ck_003E5__10;

		private IntVector2 _003Ckey_003E5__11;

		private IntVector2? _003CrandomAvailableCell2_003E5__12;

		private int _003Cl_003E5__13;

		private int _003Cm_003E5__14;

		private IntVector2 _003Ckey2_003E5__15;

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
		public _003CLaunchChestSpawns_003Ed__13(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003CfailedList_003E5__1 = null;
			_003CcachedChestData_003E5__3 = null;
			_003Centrance_003E5__4 = null;
			_003CroomHandler_003E5__5 = null;
			_003CcellValidator_003E5__6 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Expected O, but got Unknown
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			//IL_013d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0176: Unknown result type (might be due to invalid IL or missing references)
			//IL_027c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0282: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_02bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_019f: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_02fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0325: Unknown result type (might be due to invalid IL or missing references)
			//IL_032a: Unknown result type (might be due to invalid IL or missing references)
			//IL_032f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0340: Unknown result type (might be due to invalid IL or missing references)
			//IL_0345: Unknown result type (might be due to invalid IL or missing references)
			//IL_034a: Unknown result type (might be due to invalid IL or missing references)
			//IL_035f: Unknown result type (might be due to invalid IL or missing references)
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				goto IL_0046;
			case 1:
				_003C_003E1__state = -1;
				goto IL_0046;
			case 2:
				{
					_003C_003E1__state = -1;
					_003CfailedList_003E5__1 = new List<CachedChestData>();
					_003Ci_003E5__2 = 0;
					while (_003Ci_003E5__2 < _003C_003E4__this.m_chestos.Count)
					{
						_003CcachedChestData_003E5__3 = _003C_003E4__this.m_chestos[_003Ci_003E5__2];
						_003Centrance_003E5__4 = GameManager.Instance.Dungeon.data.Entrance;
						_003CroomHandler_003E5__5 = _003Centrance_003E5__4;
						_003CcachedChestData_003E5__3.Upgrade();
						object obj = _003C_003Ec._003C_003E9__13_0;
						if (obj == null)
						{
							CellValidator val = delegate(IntVector2 c)
							{
								//IL_0020: Unknown result type (might be due to invalid IL or missing references)
								//IL_0028: Unknown result type (might be due to invalid IL or missing references)
								//IL_0046: Unknown result type (might be due to invalid IL or missing references)
								//IL_004e: Unknown result type (might be due to invalid IL or missing references)
								//IL_005b: Unknown result type (might be due to invalid IL or missing references)
								//IL_0061: Invalid comparison between Unknown and I4
								//IL_0072: Unknown result type (might be due to invalid IL or missing references)
								//IL_007a: Unknown result type (might be due to invalid IL or missing references)
								for (int i = 0; i < 5; i++)
								{
									for (int j = 0; j < 5; j++)
									{
										if (!GameManager.Instance.Dungeon.data.CheckInBoundsAndValid(c.x + i, c.y + j) || (int)GameManager.Instance.Dungeon.data[c.x + i, c.y + j].type == 4 || GameManager.Instance.Dungeon.data[c.x + i, c.y + j].isOccupied)
										{
											return false;
										}
									}
								}
								return true;
							};
							_003C_003Ec._003C_003E9__13_0 = val;
							obj = (object)val;
						}
						_003CcellValidator_003E5__6 = (CellValidator)obj;
						_003CrandomAvailableCell_003E5__7 = _003CroomHandler_003E5__5.GetRandomAvailableCell((IntVector2?)(IntVector2.One * 5), (CellTypes?)(CellTypes)2, false, _003CcellValidator_003E5__6);
						_003CintVector_003E5__8 = ((!_003CrandomAvailableCell_003E5__7.HasValue) ? ((IntVector2?)null) : new IntVector2?(_003CrandomAvailableCell_003E5__7.GetValueOrDefault() + IntVector2.One));
						if (_003CintVector_003E5__8.HasValue)
						{
							_003CcachedChestData_003E5__3.SpawnChest(_003CintVector_003E5__8.Value);
							_003Cj_003E5__9 = 0;
							while (_003Cj_003E5__9 < 3)
							{
								_003Ck_003E5__10 = 0;
								while (_003Ck_003E5__10 < 3)
								{
									_003Ckey_003E5__11 = _003CintVector_003E5__8.Value + IntVector2.One + new IntVector2(_003Cj_003E5__9, _003Ck_003E5__10);
									GameManager.Instance.Dungeon.data[_003Ckey_003E5__11].isOccupied = true;
									_003Ck_003E5__10++;
								}
								_003Cj_003E5__9++;
							}
						}
						else
						{
							_003CroomHandler_003E5__5 = ((_003CroomHandler_003E5__5 != _003Centrance_003E5__4) ? _003Centrance_003E5__4 : ChestTeleporterItem.FindBossFoyer());
							if (_003CroomHandler_003E5__5 == null)
							{
								_003CroomHandler_003E5__5 = _003Centrance_003E5__4;
							}
							_003CrandomAvailableCell2_003E5__12 = _003CroomHandler_003E5__5.GetRandomAvailableCell((IntVector2?)(IntVector2.One * 5), (CellTypes?)(CellTypes)2, false, _003CcellValidator_003E5__6);
							_003CintVector_003E5__8 = ((!_003CrandomAvailableCell2_003E5__12.HasValue) ? ((IntVector2?)null) : new IntVector2?(_003CrandomAvailableCell2_003E5__12.GetValueOrDefault() + IntVector2.One));
							if (_003CintVector_003E5__8.HasValue)
							{
								_003CcachedChestData_003E5__3.SpawnChest(_003CintVector_003E5__8.Value);
								_003Cl_003E5__13 = 0;
								while (_003Cl_003E5__13 < 3)
								{
									_003Cm_003E5__14 = 0;
									while (_003Cm_003E5__14 < 3)
									{
										_003Ckey2_003E5__15 = _003CintVector_003E5__8.Value + IntVector2.One + new IntVector2(_003Cl_003E5__13, _003Cm_003E5__14);
										GameManager.Instance.Dungeon.data[_003Ckey2_003E5__15].isOccupied = true;
										_003Cm_003E5__14++;
									}
									_003Cl_003E5__13++;
								}
							}
							else
							{
								_003CfailedList_003E5__1.Add(_003CcachedChestData_003E5__3);
							}
						}
						_003CcachedChestData_003E5__3 = null;
						_003Centrance_003E5__4 = null;
						_003CroomHandler_003E5__5 = null;
						_003CcellValidator_003E5__6 = null;
						_003Ci_003E5__2++;
					}
					_003C_003E4__this.m_chestos.Clear();
					_003C_003E4__this.m_chestos.AddRange(_003CfailedList_003E5__1);
					return false;
				}
				IL_0046:
				if (Dungeon.IsGenerating)
				{
					_003C_003E2__current = null;
					_003C_003E1__state = 1;
					return true;
				}
				_003C_003E2__current = null;
				_003C_003E1__state = 2;
				return true;
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

	private List<CachedChestData> m_chestos = new List<CachedChestData>();

	private bool drillInEffect;

	private string[] c_rewardRoomObjects = new string[2] { "Gungeon_Treasure_Dais(Clone)", "GodRay_Placeable(Clone)" };

	private Vector3 m_baseChestOffset = new Vector3(0.5f, 0.25f, 0f);

	private Vector3 m_largeChestOffset = new Vector3(0.4375f, 0.0625f, 0f);

	public GameObject DrillVFXPrefab = ((Component)PickupObjectDatabase.GetById(625)).GetComponent<PaydayDrillItem>().DrillVFXPrefab;

	public VFXPool VFXDustPoof = ((Component)PickupObjectDatabase.GetById(625)).GetComponent<PaydayDrillItem>().VFXDustPoof;

	public VFXPool DisappearDrillPoof = ((Component)PickupObjectDatabase.GetById(625)).GetComponent<PaydayDrillItem>().DisappearDrillPoof;

	public PrototypeDungeonRoom GenericFallbackCombatRoom = ((Component)PickupObjectDatabase.GetById(625)).GetComponent<PaydayDrillItem>().GenericFallbackCombatRoom;

	public float DelayPreExpansion = 2.5f;

	public float DelayPostExpansionPreEnemies = 2f;

	public DrillWaveDefinition[] D_Quality_Waves = ((Component)PickupObjectDatabase.GetById(625)).GetComponent<PaydayDrillItem>().D_Quality_Waves;

	public DrillWaveDefinition[] C_Quality_Waves = ((Component)PickupObjectDatabase.GetById(625)).GetComponent<PaydayDrillItem>().C_Quality_Waves;

	public DrillWaveDefinition[] B_Quality_Waves = ((Component)PickupObjectDatabase.GetById(625)).GetComponent<PaydayDrillItem>().B_Quality_Waves;

	public DrillWaveDefinition[] A_Quality_Waves = ((Component)PickupObjectDatabase.GetById(625)).GetComponent<PaydayDrillItem>().A_Quality_Waves;

	public DrillWaveDefinition[] S_Quality_Waves = ((Component)PickupObjectDatabase.GetById(625)).GetComponent<PaydayDrillItem>().S_Quality_Waves;

	public static void Init()
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<Keygen>("Keygen", "wHO n n n eEDS KEYs?!1!", "A strange fragment of corrupted software initially developed to generate free access to the contents of chests within the Gungeon.\n\nIn the years since it's creation however, it has become... chaotic, unpredictable, and dangerous. Use with extreme caution.", "keygen_icon", assetbundle: true);
		PlayerItem val = (PlayerItem)(object)((obj is PlayerItem) ? obj : null);
		ItemBuilder.SetCooldownType(val, (CooldownType)1, 70f);
		val.consumable = false;
		((PickupObject)val).quality = (ItemQuality)3;
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)1, 1f);
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.BOSSRUSH_PILOT, requiredFlagValue: true);
	}

	public override void Pickup(PlayerController player)
	{
		((PlayerItem)this).Pickup(player);
		player.OnNewFloorLoaded = (Action<PlayerController>)Delegate.Combine(player.OnNewFloorLoaded, new Action<PlayerController>(NewLevel));
	}

	public override void OnPreDrop(PlayerController user)
	{
		((PlayerItem)this).OnPreDrop(user);
		user.OnNewFloorLoaded = (Action<PlayerController>)Delegate.Remove(user.OnNewFloorLoaded, new Action<PlayerController>(NewLevel));
	}

	public override void OnDestroy()
	{
		if ((Object)(object)base.LastOwner != (Object)null)
		{
			PlayerController lastOwner = base.LastOwner;
			lastOwner.OnNewFloorLoaded = (Action<PlayerController>)Delegate.Remove(lastOwner.OnNewFloorLoaded, new Action<PlayerController>(NewLevel));
		}
		((PlayerItem)this).OnDestroy();
	}

	private void NewLevel(PlayerController player)
	{
		((MonoBehaviour)this).StartCoroutine(LaunchChestSpawns());
	}

	public override void DoEffect(PlayerController user)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_020e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Invalid comparison between Unknown and I4
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ff: Unknown result type (might be due to invalid IL or missing references)
		IPlayerInteractable nearestInteractable = user.CurrentRoom.GetNearestInteractable(((GameActor)user).CenterPosition, 1f, user);
		if (!(nearestInteractable is Chest))
		{
			return;
		}
		AkSoundEngine.PostEvent("Play_ENM_electric_charge_01", ((Component)user).gameObject);
		Chest val = (Chest)(object)((nearestInteractable is Chest) ? nearestInteractable : null);
		int num = Random.Range(1, 15);
		ETGModConsole.Log((object)num.ToString(), false);
		VFXToolbox.GlitchScreenForSeconds(1.5f);
		switch (num)
		{
		case 1:
			if (CustomSynergies.PlayerHasActiveSynergy(user, "KEYGEN"))
			{
				SpareChest(val);
				break;
			}
			Exploder.DoDefaultExplosion(Vector2.op_Implicit(((BraveBehaviour)val).specRigidbody.UnitCenter), Vector2.zero, (Action)null, false, (CoreDamageTypes)0, false);
			if (val.IsMimic)
			{
				val.m_isMimic = false;
			}
			((BraveBehaviour)val).majorBreakable.Break(Vector2.zero);
			if ((int)ChestUtility.GetChestTier(val) == 7)
			{
				Object.Destroy((Object)(object)((Component)val).gameObject);
			}
			break;
		case 2:
			val.ForceOpen(user);
			break;
		case 3:
			if (CustomSynergies.PlayerHasActiveSynergy(user, "KEYGEN"))
			{
				SpareChest(val);
			}
			else if (val.IsLocked)
			{
				val.BreakLock();
			}
			else
			{
				((BraveBehaviour)val).majorBreakable.Break(Vector2.zero);
			}
			break;
		case 4:
			DupeChest(val, user);
			break;
		case 5:
			if (!val.IsMimic)
			{
				val.overrideMimicChance = 100f;
				val.MaybeBecomeMimic();
			}
			val.ForceOpen(user);
			break;
		case 6:
		{
			List<ValidTilesets> list = new List<ValidTilesets>
			{
				(ValidTilesets)32,
				(ValidTilesets)128,
				(ValidTilesets)2048,
				(ValidTilesets)64
			};
			if (!list.Contains(GameManager.Instance.Dungeon.tileIndices.tilesetId))
			{
				val.BecomeGlitchChest();
				break;
			}
			if (!val.IsMimic)
			{
				val.MaybeBecomeMimic();
			}
			val.ForceOpen(user);
			break;
		}
		case 7:
			if (Random.value <= 0.65f)
			{
				UpgradeChest(val, user);
			}
			else
			{
				val.BecomeRainbowChest();
			}
			break;
		case 8:
			RerollChest(val, user);
			break;
		case 9:
		{
			if (CustomSynergies.PlayerHasActiveSynergy(user, "KEYGEN"))
			{
				SpareChest(val);
				break;
			}
			for (int i = 0; i < 5; i++)
			{
				LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetById(BraveUtility.RandomElement<int>(BabyGoodChanceKin.lootIDlist))).gameObject, Vector2.op_Implicit(((BraveBehaviour)val).sprite.WorldCenter), Vector2.zero, 0f, true, false, false);
			}
			LootEngine.SpawnCurrency(((BraveBehaviour)val).sprite.WorldCenter, Random.Range(5, 11), false);
			user.CurrentRoom.DeregisterInteractable((IPlayerInteractable)(object)val);
			val.DeregisterChestOnMinimap();
			Object.Destroy((Object)(object)((Component)val).gameObject);
			break;
		}
		case 10:
		{
			if (CustomSynergies.PlayerHasActiveSynergy(user, "KEYGEN"))
			{
				SpareChest(val);
				break;
			}
			Type typeFromHandle = typeof(Chest);
			MethodInfo method = typeFromHandle.GetMethod("TriggerCountdownTimer", BindingFlags.Instance | BindingFlags.NonPublic);
			object obj = method.Invoke(val, null);
			AkSoundEngine.PostEvent("Play_OBJ_fuse_loop_01", ((Component)val).gameObject);
			break;
		}
		case 11:
			if (val.IsLocked)
			{
				val.ForceUnlock();
			}
			else
			{
				val.ForceOpen(user);
			}
			break;
		case 12:
			GameObjectExtensions.GetOrAddComponent<JammedChestBehav>(((Component)val).gameObject);
			break;
		case 13:
			TeleportChest(val, user);
			break;
		case 14:
			FauxDrill(val, user);
			break;
		}
	}

	private void SpareChest(Chest chest)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		Object.Instantiate<GameObject>(SharedVFX.GundetaleSpareVFX, Vector2.op_Implicit(((BraveBehaviour)chest).sprite.WorldTopCenter + new Vector2(0f, 0.25f)), Quaternion.identity);
	}

	private void TeleportChest(Chest chest, PlayerController user)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Expected O, but got Unknown
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		CachedChestData item = new CachedChestData(chest);
		SpawnManager.SpawnVFX(SharedVFX.ChestTeleporterTimeWarp, Vector2.op_Implicit(((BraveBehaviour)chest).sprite.WorldCenter), Quaternion.identity, true);
		user.CurrentRoom.DeregisterInteractable((IPlayerInteractable)(object)chest);
		chest.DeregisterChestOnMinimap();
		if (Object.op_Implicit((Object)(object)((BraveBehaviour)chest).majorBreakable))
		{
			((BraveBehaviour)chest).majorBreakable.TemporarilyInvulnerable = true;
		}
		Object.Destroy((Object)(object)((Component)chest).gameObject, 0.8f);
		m_chestos.Add(item);
	}

	private void UpgradeChest(Chest chest, PlayerController user)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Expected I4, but got Unknown
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Invalid comparison between Unknown and I4
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		ChestTier chestTier = ChestUtility.GetChestTier(chest);
		ChestTier val = (ChestTier)11;
		ChestTier val2 = chestTier;
		ChestTier val3 = val2;
		switch ((int)val3)
		{
		case 0:
			val = (ChestTier)1;
			break;
		case 1:
			val = (ChestTier)2;
			break;
		case 2:
			val = (ChestTier)3;
			break;
		case 3:
			val = (ChestTier)4;
			break;
		case 4:
			val = (ChestTier)5;
			break;
		case 8:
			val = (ChestTier)4;
			break;
		}
		ThreeStateValue val4 = (ThreeStateValue)2;
		val4 = ((!chest.IsMimic) ? ((ThreeStateValue)1) : ((ThreeStateValue)0));
		if ((int)val != 11)
		{
			ChestUtility.SpawnChestEasy(Vector2Extensions.ToIntVector2(((BraveBehaviour)chest).sprite.WorldBottomLeft, (VectorConversions)2), val, chest.IsLocked, (GeneralChestType)0, val4, (ThreeStateValue)2);
		}
		else
		{
			GameManager.Instance.RewardManager.SpawnRewardChestAt(Vector2Extensions.ToIntVector2(((BraveBehaviour)chest).sprite.WorldBottomLeft, (VectorConversions)2), -1f, (ItemQuality)(-100));
		}
		user.CurrentRoom.DeregisterInteractable((IPlayerInteractable)(object)chest);
		chest.DeregisterChestOnMinimap();
		Object.Destroy((Object)(object)((Component)chest).gameObject);
	}

	private void RerollChest(Chest chest, PlayerController user)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		Chest val = GameManager.Instance.RewardManager.SpawnRewardChestAt(Vector2Extensions.ToIntVector2(((BraveBehaviour)chest).sprite.WorldBottomLeft, (VectorConversions)2), -1f, (ItemQuality)(-100));
		user.CurrentRoom.DeregisterInteractable((IPlayerInteractable)(object)chest);
		chest.DeregisterChestOnMinimap();
		Object.Destroy((Object)(object)((Component)chest).gameObject);
	}

	private void DupeChest(Chest chest, PlayerController user)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Invalid comparison between Unknown and I4
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Invalid comparison between Unknown and I4
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		IntVector2 bestRewardLocation = user.CurrentRoom.GetBestRewardLocation(IntVector2.One * 3, (RewardLocationStyle)1, true);
		ChestTier val = ChestUtility.GetChestTier(chest);
		if ((int)val == 7)
		{
			val = (ChestTier)3;
		}
		else if ((int)val == 9)
		{
			val = (ChestTier)1;
		}
		ThreeStateValue val2 = (ThreeStateValue)2;
		val2 = ((!chest.IsMimic) ? ((ThreeStateValue)1) : ((ThreeStateValue)0));
		ChestUtility.SpawnChestEasy(bestRewardLocation, val, chest.IsLocked, (GeneralChestType)0, val2, (ThreeStateValue)2);
	}

	public override bool CanBeUsed(PlayerController user)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		IPlayerInteractable nearestInteractable = user.CurrentRoom.GetNearestInteractable(((GameActor)user).CenterPosition, 1f, user);
		return nearestInteractable is Chest;
	}

	private IEnumerator LaunchChestSpawns()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CLaunchChestSpawns_003Ed__13(0)
		{
			_003C_003E4__this = this
		};
	}

	private void FauxDrill(Chest chest, PlayerController user)
	{
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Invalid comparison between Unknown and I4
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		AkSoundEngine.PostEvent("Play_OBJ_paydaydrill_start_01", ((Component)GameManager.Instance).gameObject);
		AkSoundEngine.PostEvent("Play_OBJ_paydaydrill_loop_01", ((Component)GameManager.Instance).gameObject);
		if (chest.IsLocked)
		{
			if (chest.IsLockBroken)
			{
				chest.ForceUnlock();
				AkSoundEngine.PostEvent("Stop_OBJ_paydaydrill_loop_01", ((Component)GameManager.Instance).gameObject);
				return;
			}
			if (chest.IsMimic && Object.op_Implicit((Object)(object)((BraveBehaviour)chest).majorBreakable))
			{
				((BraveBehaviour)chest).majorBreakable.ApplyDamage(1000f, Vector2.zero, false, false, true);
				AkSoundEngine.PostEvent("Stop_OBJ_paydaydrill_loop_01", ((Component)GameManager.Instance).gameObject);
				return;
			}
			chest.ForceKillFuse();
			chest.PreventFuse = true;
			RoomHandler absoluteRoom = Vector3Extensions.GetAbsoluteRoom(((BraveBehaviour)chest).transform.position);
			drillInEffect = true;
			if ((int)absoluteRoom.area.PrototypeRoomCategory == 4)
			{
				((MonoBehaviour)GameManager.Instance.Dungeon).StartCoroutine(HandleSeamlessTransitionToCombatRoom(absoluteRoom, chest));
			}
			else
			{
				((MonoBehaviour)GameManager.Instance.Dungeon).StartCoroutine(HandleTransitionToFallbackCombatRoom(absoluteRoom, chest));
			}
		}
		else
		{
			chest.ForceOpen(user);
			AkSoundEngine.PostEvent("Stop_OBJ_paydaydrill_loop_01", ((Component)GameManager.Instance).gameObject);
		}
	}

	protected IEnumerator HandleTransitionToFallbackCombatRoom(RoomHandler sourceRoom, Chest sourceChest)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CHandleTransitionToFallbackCombatRoom_003Ed__16(0)
		{
			_003C_003E4__this = this,
			sourceRoom = sourceRoom,
			sourceChest = sourceChest
		};
	}

	protected IEnumerator HandleSeamlessTransitionToCombatRoom(RoomHandler sourceRoom, Chest sourceChest)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CHandleSeamlessTransitionToCombatRoom_003Ed__17(0)
		{
			_003C_003E4__this = this,
			sourceRoom = sourceRoom,
			sourceChest = sourceChest
		};
	}

	private IEnumerator HandleCombatRoomExpansion(RoomHandler sourceRoom, RoomHandler targetRoom, Chest sourceChest)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CHandleCombatRoomExpansion_003Ed__18(0)
		{
			_003C_003E4__this = this,
			sourceRoom = sourceRoom,
			targetRoom = targetRoom,
			sourceChest = sourceChest
		};
	}

	protected IEnumerator HandleCombatWaves(Dungeon d, RoomHandler newRoom, Chest sourceChest)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CHandleCombatWaves_003Ed__19(0)
		{
			_003C_003E4__this = this,
			d = d,
			newRoom = newRoom,
			sourceChest = sourceChest
		};
	}

	private IEnumerator HandleCombatRoomShrinking(RoomHandler targetRoom)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CHandleCombatRoomShrinking_003Ed__20(0)
		{
			_003C_003E4__this = this,
			targetRoom = targetRoom
		};
	}

	private void ShrinkRoom(RoomHandler r)
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Invalid comparison between Unknown and I4
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		Dungeon dungeon = GameManager.Instance.Dungeon;
		AkSoundEngine.PostEvent("Play_OBJ_stone_crumble_01", ((Component)GameManager.Instance).gameObject);
		tk2dTileMap val = null;
		HashSet<IntVector2> hashSet = new HashSet<IntVector2>();
		for (int i = -5; i < r.area.dimensions.x + 5; i++)
		{
			for (int j = -5; j < r.area.dimensions.y + 5; j++)
			{
				IntVector2 val2 = r.area.basePosition + new IntVector2(i, j);
				CellData val3 = ((!dungeon.data.CheckInBoundsAndValid(val2)) ? null : dungeon.data[val2]);
				if (val3 != null && (int)val3.type != 1 && val3.HasTypeNeighbor(dungeon.data, (CellType)1))
				{
					hashSet.Add(val3.position);
				}
			}
		}
		foreach (IntVector2 item in hashSet)
		{
			CellData val4 = dungeon.data[item];
			val4.breakable = true;
			val4.occlusionData.overrideOcclusion = true;
			val4.occlusionData.cellOcclusionDirty = true;
			val = dungeon.ConstructWallAtPosition(item.x, item.y, true);
			r.Cells.Remove(val4.position);
			r.CellsWithoutExits.Remove(val4.position);
			r.RawCells.Remove(val4.position);
		}
		Pixelator.Instance.MarkOcclusionDirty();
		Pixelator.Instance.ProcessOcclusionChange(r.Epicenter, 1f, r, false);
		if (Object.op_Implicit((Object)(object)val))
		{
			dungeon.RebuildTilemap(val);
		}
	}

	private void ExpandRoom(RoomHandler r)
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_0210: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Invalid comparison between Unknown and I4
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		Dungeon dungeon = GameManager.Instance.Dungeon;
		AkSoundEngine.PostEvent("Play_OBJ_stone_crumble_01", ((Component)GameManager.Instance).gameObject);
		tk2dTileMap val = null;
		HashSet<IntVector2> hashSet = new HashSet<IntVector2>();
		for (int i = -5; i < r.area.dimensions.x + 5; i++)
		{
			for (int j = -5; j < r.area.dimensions.y + 5; j++)
			{
				IntVector2 val2 = r.area.basePosition + new IntVector2(i, j);
				CellData val3 = ((!dungeon.data.CheckInBoundsAndValid(val2)) ? null : dungeon.data[val2]);
				if (val3 != null && (int)val3.type == 1 && val3.HasTypeNeighbor(dungeon.data, (CellType)2))
				{
					hashSet.Add(val3.position);
				}
			}
		}
		foreach (IntVector2 item in hashSet)
		{
			IntVector2 current = item;
			CellData val4 = dungeon.data[current];
			val4.breakable = true;
			val4.occlusionData.overrideOcclusion = true;
			val4.occlusionData.cellOcclusionDirty = true;
			val = dungeon.DestroyWallAtPosition(current.x, current.y, true);
			if (Random.value < 0.25f)
			{
				VFXDustPoof.SpawnAtPosition(((IntVector2)(ref current)).ToCenterVector3((float)current.y), 0f, (Transform)null, (Vector2?)null, (Vector2?)null, (float?)null, false, (SpawnMethod)null, (tk2dBaseSprite)null, false);
			}
			r.Cells.Add(val4.position);
			r.CellsWithoutExits.Add(val4.position);
			r.RawCells.Add(val4.position);
		}
		Pixelator.Instance.MarkOcclusionDirty();
		Pixelator.Instance.ProcessOcclusionChange(r.Epicenter, 1f, r, false);
		if (Object.op_Implicit((Object)(object)val))
		{
			dungeon.RebuildTilemap(val);
		}
	}

	private void MoveObjectBetweenRooms(Transform foundObject, RoomHandler fromRoom, RoomHandler toRoom)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		Vector2 val = Vector3Extensions.XY(foundObject.position) - ((IntVector2)(ref fromRoom.area.basePosition)).ToVector2();
		Vector2 val2 = ((IntVector2)(ref toRoom.area.basePosition)).ToVector2() + val;
		((Component)foundObject).transform.position = Vector2.op_Implicit(val2);
		if ((Object)(object)foundObject.parent == (Object)(object)fromRoom.hierarchyParent)
		{
			foundObject.parent = toRoom.hierarchyParent;
		}
		SpeculativeRigidbody component = ((Component)foundObject).GetComponent<SpeculativeRigidbody>();
		if (Object.op_Implicit((Object)(object)component))
		{
			component.Reinitialize();
		}
		tk2dBaseSprite component2 = ((Component)foundObject).GetComponent<tk2dBaseSprite>();
		if (Object.op_Implicit((Object)(object)component2))
		{
			component2.UpdateZDepth();
		}
	}
}
