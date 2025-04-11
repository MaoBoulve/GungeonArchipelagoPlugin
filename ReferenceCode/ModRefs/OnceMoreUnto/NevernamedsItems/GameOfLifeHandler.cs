using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class GameOfLifeHandler : MonoBehaviour
{
	public class GameOfLifeProjectile : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CPostStart_003Ed__3 : IEnumerator<object>, IDisposable, IEnumerator
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public GameOfLifeProjectile _003C_003E4__this;

			private CellData _003Cdata_003E5__1;

			private Vector2 _003CcellCenter_003E5__2;

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
			public _003CPostStart_003Ed__3(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				_003Cdata_003E5__1 = null;
				_003C_003E1__state = -2;
			}

			private bool MoveNext()
			{
				//IL_0052: Unknown result type (might be due to invalid IL or missing references)
				//IL_0057: Unknown result type (might be due to invalid IL or missing references)
				//IL_005d: Unknown result type (might be due to invalid IL or missing references)
				//IL_0078: Unknown result type (might be due to invalid IL or missing references)
				//IL_0087: Unknown result type (might be due to invalid IL or missing references)
				//IL_008c: Unknown result type (might be due to invalid IL or missing references)
				//IL_0091: Unknown result type (might be due to invalid IL or missing references)
				//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
				//IL_00da: Unknown result type (might be due to invalid IL or missing references)
				//IL_00df: Unknown result type (might be due to invalid IL or missing references)
				//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
				//IL_0199: Unknown result type (might be due to invalid IL or missing references)
				//IL_019e: Unknown result type (might be due to invalid IL or missing references)
				//IL_0142: Unknown result type (might be due to invalid IL or missing references)
				//IL_0151: Unknown result type (might be due to invalid IL or missing references)
				//IL_0156: Unknown result type (might be due to invalid IL or missing references)
				//IL_015b: Unknown result type (might be due to invalid IL or missing references)
				switch (_003C_003E1__state)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					_003C_003E2__current = null;
					_003C_003E1__state = 1;
					return true;
				case 1:
					_003C_003E1__state = -1;
					_003Cdata_003E5__1 = GameManager.Instance.Dungeon.data[Vector2Extensions.ToIntVector2(Vector2.op_Implicit(_003C_003E4__this.self.LastPosition), (VectorConversions)0)];
					_003CcellCenter_003E5__2 = ((IntVector2)(ref _003Cdata_003E5__1.position)).ToVector2() + new Vector2(0.5f, 0.5f);
					if (registeredCells.ContainsKey(_003Cdata_003E5__1) && _003C_003E4__this.beginInactive)
					{
						VFXToolbox.DoStringSquirt("Cell Killed for Dupe Register", ((IntVector2)(ref _003Cdata_003E5__1.position)).ToVector2() + new Vector2(0.5f, 0.5f), Color.blue);
						Object.Destroy((Object)(object)((Component)_003C_003E4__this.self).gameObject);
						return false;
					}
					_003C_003E4__this.initialCell = _003Cdata_003E5__1;
					if (_003Cdata_003E5__1.IsAnyFaceWall())
					{
						VFXToolbox.DoStringSquirt("Cell Killed for Wall overlap", ((IntVector2)(ref _003Cdata_003E5__1.position)).ToVector2() + new Vector2(0.5f, 0.5f), Color.blue);
						Object.Destroy((Object)(object)((Component)_003C_003E4__this.self).gameObject);
						return false;
					}
					((BraveBehaviour)_003C_003E4__this.self).transform.position = Vector2.op_Implicit(_003CcellCenter_003E5__2);
					((BraveBehaviour)_003C_003E4__this.self).specRigidbody.Reinitialize();
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

		private CellData initialCell;

		private Projectile self;

		public bool beginInactive;

		private bool isActive;

		public GameOfLifeProjectile()
		{
			beginInactive = true;
		}

		private void Start()
		{
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			if (beginInactive)
			{
				isActive = false;
			}
			else
			{
				isActive = true;
			}
			self = ((Component)this).GetComponent<Projectile>();
			if (Object.op_Implicit((Object)(object)self) && Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(self)) && beginInactive)
			{
				self.AdjustPlayerProjectileTint(Color.grey, 2, 0f);
				PlayerController obj = ProjectileUtility.ProjectilePlayerOwner(self);
				obj.OnReloadPressed = (Action<PlayerController, Gun>)Delegate.Combine(obj.OnReloadPressed, new Action<PlayerController, Gun>(ActivateSelf));
			}
			((MonoBehaviour)this).StartCoroutine(PostStart());
		}

		private void ActivateSelf(PlayerController activator, Gun gun)
		{
			//IL_0051: Unknown result type (might be due to invalid IL or missing references)
			if (!isActive)
			{
				if (initialCell != null)
				{
					if (!registeredCells.ContainsKey(initialCell))
					{
						registeredCells.Add(initialCell, self);
					}
					self.AdjustPlayerProjectileTint(Color.white, 1, 0f);
				}
				else
				{
					Debug.LogError((object)"Attempted to activate an inactive cell that does not have a set initial cell position");
				}
				isActive = true;
			}
			if (Object.op_Implicit((Object)(object)self) && Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(self)))
			{
				PlayerController obj = ProjectileUtility.ProjectilePlayerOwner(self);
				obj.OnReloadPressed = (Action<PlayerController, Gun>)Delegate.Remove(obj.OnReloadPressed, new Action<PlayerController, Gun>(ActivateSelf));
			}
		}

		private IEnumerator PostStart()
		{
			//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
			return new _003CPostStart_003Ed__3(0)
			{
				_003C_003E4__this = this
			};
		}

		private void OnDestroy()
		{
			if (Object.op_Implicit((Object)(object)self) && Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(self)))
			{
				PlayerController obj = ProjectileUtility.ProjectilePlayerOwner(self);
				obj.OnReloadPressed = (Action<PlayerController, Gun>)Delegate.Remove(obj.OnReloadPressed, new Action<PlayerController, Gun>(ActivateSelf));
			}
		}
	}

	[CompilerGenerated]
	private sealed class _003CHandleGeneration_003Ed__6 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public GameOfLifeHandler _003C_003E4__this;

		private Dictionary<CellData, int> _003CbirthCandidates_003E5__1;

		private int _003Cbirth_003E5__2;

		private int _003Cdeath_003E5__3;

		private int _003Ci_003E5__4;

		private List<CellData> _003CNeighbors_003E5__5;

		private int _003CnumberOfNeighbors_003E5__6;

		private List<CellData>.Enumerator _003C_003Es__7;

		private CellData _003CpotNeighbor_003E5__8;

		private Dictionary<CellData, int>.KeyCollection.Enumerator _003C_003Es__9;

		private CellData _003CpotBirth_003E5__10;

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
		public _003CHandleGeneration_003Ed__6(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003CbirthCandidates_003E5__1 = null;
			_003CNeighbors_003E5__5 = null;
			_003C_003Es__7 = default(List<CellData>.Enumerator);
			_003CpotNeighbor_003E5__8 = null;
			_003C_003Es__9 = default(Dictionary<CellData, int>.KeyCollection.Enumerator);
			_003CpotBirth_003E5__10 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				generationRunning = true;
				if (!((Object)(object)GameManager.Instance.Dungeon != (Object)null) || GameManager.Instance.Dungeon.data == null || Dungeon.IsGenerating)
				{
					break;
				}
				_003CbirthCandidates_003E5__1 = new Dictionary<CellData, int>();
				if (Object.op_Implicit((Object)(object)GameManager.Instance.PrimaryPlayer))
				{
					VFXToolbox.DoStringSquirt("Generation", ((GameActor)GameManager.Instance.PrimaryPlayer).CenterPosition, Color.red);
				}
				if (plannedBirths != null && plannedBirths.Count > 0)
				{
					_003Cbirth_003E5__2 = plannedBirths.Count - 1;
					goto IL_0134;
				}
				goto IL_0152;
			case 1:
				_003C_003E1__state = -1;
				_003Cbirth_003E5__2--;
				goto IL_0134;
			case 2:
				_003C_003E1__state = -1;
				_003Cdeath_003E5__3--;
				goto IL_01cb;
			case 3:
				{
					_003C_003E1__state = -1;
					_003Ci_003E5__4 = registeredCells.Keys.Count - 1;
					while (_003Ci_003E5__4 >= 0)
					{
						if ((Object)(object)registeredCells.ElementAt(_003Ci_003E5__4).Value == (Object)null)
						{
							registeredCells.Remove(registeredCells.ElementAt(_003Ci_003E5__4).Key);
						}
						else
						{
							_003CNeighbors_003E5__5 = new List<CellData>();
							_003CNeighbors_003E5__5.AddRange(GameManager.Instance.Dungeon.data.GetCellNeighbors(registeredCells.ElementAt(_003Ci_003E5__4).Key, true));
							_003CnumberOfNeighbors_003E5__6 = _003C_003E4__this.NumberOfLiveCells(_003CNeighbors_003E5__5);
							if (_003CnumberOfNeighbors_003E5__6 > 3 || _003CnumberOfNeighbors_003E5__6 < 2)
							{
								plannedDeaths.Add(registeredCells.ElementAt(_003Ci_003E5__4).Key);
							}
							_003C_003Es__7 = _003CNeighbors_003E5__5.GetEnumerator();
							try
							{
								while (_003C_003Es__7.MoveNext())
								{
									_003CpotNeighbor_003E5__8 = _003C_003Es__7.Current;
									if (!registeredCells.ContainsKey(_003CpotNeighbor_003E5__8))
									{
										if (_003CbirthCandidates_003E5__1.ContainsKey(_003CpotNeighbor_003E5__8))
										{
											_003CbirthCandidates_003E5__1[_003CpotNeighbor_003E5__8]++;
										}
										else
										{
											_003CbirthCandidates_003E5__1.Add(_003CpotNeighbor_003E5__8, 1);
										}
									}
									_003CpotNeighbor_003E5__8 = null;
								}
							}
							finally
							{
								((IDisposable)_003C_003Es__7/*cast due to .constrained prefix*/).Dispose();
							}
							_003C_003Es__7 = default(List<CellData>.Enumerator);
							_003C_003Es__9 = _003CbirthCandidates_003E5__1.Keys.GetEnumerator();
							try
							{
								while (_003C_003Es__9.MoveNext())
								{
									_003CpotBirth_003E5__10 = _003C_003Es__9.Current;
									if (_003CbirthCandidates_003E5__1[_003CpotBirth_003E5__10] == 3)
									{
										plannedBirths.Add(_003CpotBirth_003E5__10);
									}
									_003CpotBirth_003E5__10 = null;
								}
							}
							finally
							{
								((IDisposable)_003C_003Es__9/*cast due to .constrained prefix*/).Dispose();
							}
							_003C_003Es__9 = default(Dictionary<CellData, int>.KeyCollection.Enumerator);
							_003CNeighbors_003E5__5 = null;
						}
						_003Ci_003E5__4--;
					}
					_003CbirthCandidates_003E5__1 = null;
					break;
				}
				IL_01cb:
				if (_003Cdeath_003E5__3 >= 0)
				{
					_003C_003E4__this.KillCell(plannedDeaths[_003Cdeath_003E5__3]);
					_003C_003E2__current = null;
					_003C_003E1__state = 2;
					return true;
				}
				plannedDeaths.Clear();
				goto IL_01e9;
				IL_0152:
				if (plannedDeaths != null && plannedDeaths.Count > 0)
				{
					_003Cdeath_003E5__3 = plannedDeaths.Count - 1;
					goto IL_01cb;
				}
				goto IL_01e9;
				IL_01e9:
				_003C_003E2__current = null;
				_003C_003E1__state = 3;
				return true;
				IL_0134:
				if (_003Cbirth_003E5__2 >= 0)
				{
					_003C_003E4__this.BirthCell(plannedBirths[_003Cbirth_003E5__2]);
					_003C_003E2__current = null;
					_003C_003E1__state = 1;
					return true;
				}
				plannedBirths.Clear();
				goto IL_0152;
			}
			generationRunning = false;
			timer = 0.5f;
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

	public static Projectile GOLProjPrefab;

	private static bool generationRunning = false;

	private static float timer = 0.5f;

	public static List<CellData> plannedBirths = new List<CellData>();

	public static List<CellData> plannedDeaths = new List<CellData>();

	public static Dictionary<CellData, Projectile> registeredCells = new Dictionary<CellData, Projectile>();

	public static Dictionary<CellData, Projectile> deactivatedCells = new Dictionary<CellData, Projectile>();

	public static void Init()
	{
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GOLProjPrefab = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)((Gun)((byId is Gun) ? byId : null)).DefaultModule.projectiles[0]).gameObject).GetComponent<Projectile>();
		GOLProjPrefab.baseData.speed = 0f;
		GOLProjPrefab.shouldRotate = false;
		GOLProjPrefab.SetProjectileSprite("gameoflife_projectile", 16, 16, lightened: true, (Anchor)4, 16, 16, anchorChangesCollider: true, fixesScale: false, null, null);
		((Component)GOLProjPrefab).gameObject.AddComponent<GameOfLifeProjectile>();
		((BraveBehaviour)GOLProjPrefab).specRigidbody.CollideWithTileMap = false;
	}

	private void Start()
	{
		timer = 0.5f;
		generationRunning = false;
		ETGModConsole.Log((object)"GOL Handler Started", false);
	}

	private void OnDestroy()
	{
		ETGModConsole.Log((object)"GOL Handler ended", false);
	}

	private void Update()
	{
		if (!generationRunning)
		{
			if (timer >= 0f)
			{
				timer -= BraveTime.DeltaTime;
			}
			else
			{
				ETGMod.StartGlobalCoroutine(HandleGeneration());
			}
		}
	}

	public IEnumerator HandleGeneration()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CHandleGeneration_003Ed__6(0)
		{
			_003C_003E4__this = this
		};
	}

	public int NumberOfLiveCells(List<CellData> cells)
	{
		int num = 0;
		foreach (CellData cell in cells)
		{
			if (registeredCells.ContainsKey(cell))
			{
				num++;
			}
		}
		return num;
	}

	public void KillCell(CellData targetCell)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		if (registeredCells.ContainsKey(targetCell))
		{
			VFXToolbox.DoStringSquirt("Cell Killed", ((IntVector2)(ref targetCell.position)).ToVector2() + new Vector2(0.5f, 0.5f), Color.blue);
			registeredCells[targetCell].DieInAir(false, true, true, false);
			registeredCells.Remove(targetCell);
		}
		else
		{
			Debug.LogWarning((object)"Tried to kill an unregistered cell, but we caught it.");
		}
	}

	public void BirthCell(CellData targetCell)
	{
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		if (registeredCells.ContainsKey(targetCell))
		{
			Debug.LogWarning((object)"Tried to birth a cell where a cell already lives!");
		}
		else if (!targetCell.IsAnyFaceWall())
		{
			GameObject val = SpawnManager.SpawnProjectile(((Component)GOLProjPrefab).gameObject, Vector2.op_Implicit(((IntVector2)(ref targetCell.position)).ToVector2() + new Vector2(0.5f, 0.5f)), Quaternion.identity, true);
			val.GetComponent<GameOfLifeProjectile>().beginInactive = false;
			Projectile component = val.GetComponent<Projectile>();
			if ((Object)(object)component != (Object)null && (Object)(object)GameManager.Instance.PrimaryPlayer != (Object)null)
			{
				component.Owner = (GameActor)(object)GameManager.Instance.PrimaryPlayer;
				component.Shooter = ((BraveBehaviour)GameManager.Instance.PrimaryPlayer).specRigidbody;
			}
			VFXToolbox.DoStringSquirt("Cell Birthed", ((IntVector2)(ref targetCell.position)).ToVector2() + new Vector2(0.5f, 0.5f), Color.blue);
			registeredCells.Add(targetCell, component);
		}
	}
}
