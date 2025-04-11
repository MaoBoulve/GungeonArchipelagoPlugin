using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Alexandria.Misc;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class BejewelerStuckJewels : AppliedEffectBase
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public GameObject gem;

		internal bool _003CHandleCUBE_003Eb__0(Tuple<Bejeweler.GemColour, GameObject> x)
		{
			return (Object)(object)x.Second == (Object)(object)gem;
		}
	}

	[CompilerGenerated]
	private sealed class _003CHandleCUBE_003Ed__5 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerController user;

		public Bejeweler.GemColour colour;

		private List<AIActor> _003CActorsToGun_003E5__1;

		private List<GameObject> _003CGemsToCrack_003E5__2;

		private List<AIActor> _003CactiveEnemies_003E5__3;

		private Vector2 _003CpositionForCube_003E5__4;

		private GameObject _003Ccube_003E5__5;

		private int _003Ci_003E5__6;

		private AIActor _003Caiactor_003E5__7;

		private List<Tuple<Bejeweler.GemColour, GameObject>>.Enumerator _003C_003Es__8;

		private Tuple<Bejeweler.GemColour, GameObject> _003Ctup_003E5__9;

		private List<AIActor>.Enumerator _003C_003Es__10;

		private AIActor _003Cactor_003E5__11;

		private Jeweled _003Ccomp_003E5__12;

		private List<GameObject>.Enumerator _003C_003Es__13;

		private _003C_003Ec__DisplayClass5_0 _003C_003E8__14;

		private List<AIActor>.Enumerator _003C_003Es__15;

		private AIActor _003Cactor_003E5__16;

		private GameObject _003Cinst_003E5__17;

		private Projectile _003Cinstproj_003E5__18;

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
		public _003CHandleCUBE_003Ed__5(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003CActorsToGun_003E5__1 = null;
			_003CGemsToCrack_003E5__2 = null;
			_003CactiveEnemies_003E5__3 = null;
			_003Ccube_003E5__5 = null;
			_003Caiactor_003E5__7 = null;
			_003C_003Es__8 = default(List<Tuple<Bejeweler.GemColour, GameObject>>.Enumerator);
			_003Ctup_003E5__9 = null;
			_003C_003Es__10 = default(List<AIActor>.Enumerator);
			_003Cactor_003E5__11 = null;
			_003Ccomp_003E5__12 = null;
			_003C_003Es__13 = default(List<GameObject>.Enumerator);
			_003C_003E8__14 = null;
			_003C_003Es__15 = default(List<AIActor>.Enumerator);
			_003Cactor_003E5__16 = null;
			_003Cinst_003E5__17 = null;
			_003Cinstproj_003E5__18 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_032f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0334: Unknown result type (might be due to invalid IL or missing references)
			//IL_0340: Unknown result type (might be due to invalid IL or missing references)
			//IL_0345: Unknown result type (might be due to invalid IL or missing references)
			//IL_034a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0369: Unknown result type (might be due to invalid IL or missing references)
			//IL_0373: Expected O, but got Unknown
			//IL_04e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_04ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_04ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_03f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0400: Unknown result type (might be due to invalid IL or missing references)
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003CActorsToGun_003E5__1 = new List<AIActor>();
				_003CGemsToCrack_003E5__2 = new List<GameObject>();
				_003CactiveEnemies_003E5__3 = user.CurrentRoom.GetActiveEnemies((ActiveEnemyType)0);
				if (_003CactiveEnemies_003E5__3 != null)
				{
					_003Ci_003E5__6 = 0;
					while (_003Ci_003E5__6 < _003CactiveEnemies_003E5__3.Count)
					{
						_003Caiactor_003E5__7 = _003CactiveEnemies_003E5__3[_003Ci_003E5__6];
						if (Object.op_Implicit((Object)(object)_003Caiactor_003E5__7) && Object.op_Implicit((Object)(object)((Component)_003Caiactor_003E5__7).GetComponent<Jeweled>()))
						{
							_003C_003Es__8 = ((Component)_003Caiactor_003E5__7).GetComponent<Jeweled>().instantiatedGemVFX.GetEnumerator();
							try
							{
								while (_003C_003Es__8.MoveNext())
								{
									_003Ctup_003E5__9 = _003C_003Es__8.Current;
									if (_003CGemsToCrack_003E5__2.Count >= 3)
									{
										break;
									}
									if (_003Ctup_003E5__9.First == colour && !_003CGemsToCrack_003E5__2.Contains(_003Ctup_003E5__9.Second))
									{
										_003CGemsToCrack_003E5__2.Add(_003Ctup_003E5__9.Second);
										if (!_003CActorsToGun_003E5__1.Contains(_003Caiactor_003E5__7))
										{
											_003CActorsToGun_003E5__1.Add(_003Caiactor_003E5__7);
										}
									}
									_003Ctup_003E5__9 = null;
								}
							}
							finally
							{
								((IDisposable)_003C_003Es__8/*cast due to .constrained prefix*/).Dispose();
							}
							_003C_003Es__8 = default(List<Tuple<Bejeweler.GemColour, GameObject>>.Enumerator);
						}
						_003Caiactor_003E5__7 = null;
						_003Ci_003E5__6++;
					}
				}
				_003C_003Es__10 = _003CActorsToGun_003E5__1.GetEnumerator();
				try
				{
					while (_003C_003Es__10.MoveNext())
					{
						_003Cactor_003E5__11 = _003C_003Es__10.Current;
						_003Ccomp_003E5__12 = ((Component)_003Cactor_003E5__11).GetComponent<Jeweled>();
						if (Object.op_Implicit((Object)(object)_003Ccomp_003E5__12))
						{
							_003C_003Es__13 = _003CGemsToCrack_003E5__2.GetEnumerator();
							try
							{
								while (_003C_003Es__13.MoveNext())
								{
									_003C_003E8__14 = new _003C_003Ec__DisplayClass5_0();
									_003C_003E8__14.gem = _003C_003Es__13.Current;
									if (_003Ccomp_003E5__12.instantiatedGemVFX.Exists((Tuple<Bejeweler.GemColour, GameObject> x) => (Object)(object)x.Second == (Object)(object)_003C_003E8__14.gem))
									{
										_003Ccomp_003E5__12.ShatterGem(_003C_003E8__14.gem);
									}
									_003C_003E8__14 = null;
								}
							}
							finally
							{
								((IDisposable)_003C_003Es__13/*cast due to .constrained prefix*/).Dispose();
							}
							_003C_003Es__13 = default(List<GameObject>.Enumerator);
						}
						_003Ccomp_003E5__12 = null;
						_003Cactor_003E5__11 = null;
					}
				}
				finally
				{
					((IDisposable)_003C_003Es__10/*cast due to .constrained prefix*/).Dispose();
				}
				_003C_003Es__10 = default(List<AIActor>.Enumerator);
				_003CpositionForCube_003E5__4 = GetCenteredPosition(user, _003CActorsToGun_003E5__1);
				_003Ccube_003E5__5 = SpawnManager.SpawnVFX(Bejeweler.cubeVFX, Vector2.op_Implicit(_003CpositionForCube_003E5__4), Quaternion.identity);
				_003C_003E2__current = (object)new WaitForSeconds(Random.Range(1f, 2f));
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				_003C_003Es__15 = _003CActorsToGun_003E5__1.GetEnumerator();
				try
				{
					while (_003C_003Es__15.MoveNext())
					{
						_003Cactor_003E5__16 = _003C_003Es__15.Current;
						if ((Object)(object)_003Cactor_003E5__16 != (Object)null && Object.op_Implicit((Object)(object)((BraveBehaviour)_003Cactor_003E5__16).healthHaver) && ((BraveBehaviour)_003Cactor_003E5__16).healthHaver.IsAlive)
						{
							_003Cinst_003E5__17 = ProjectileUtility.InstantiateAndFireTowardsPosition(Bejeweler.railgun, _003CpositionForCube_003E5__4, ((BraveBehaviour)_003Cactor_003E5__16).specRigidbody.UnitCenter, 0f, 0f, (PlayerController)null);
							_003Cinstproj_003E5__18 = _003Cinst_003E5__17.GetComponent<Projectile>();
							if (Object.op_Implicit((Object)(object)_003Cinstproj_003E5__18))
							{
								_003Cinstproj_003E5__18.Owner = (GameActor)(object)user;
								_003Cinstproj_003E5__18.Shooter = ((BraveBehaviour)user).specRigidbody;
								_003Cinstproj_003E5__18.ScaleByPlayerStats(user);
								user.DoPostProcessProjectile(_003Cinstproj_003E5__18);
							}
							_003Cinst_003E5__17 = null;
							_003Cinstproj_003E5__18 = null;
						}
						_003Cactor_003E5__16 = null;
					}
				}
				finally
				{
					((IDisposable)_003C_003Es__15/*cast due to .constrained prefix*/).Dispose();
				}
				_003C_003Es__15 = default(List<AIActor>.Enumerator);
				Object.Destroy((Object)(object)_003Ccube_003E5__5);
				SpawnManager.SpawnVFX(SharedVFX.ArcExplosion, Vector2.op_Implicit(_003CpositionForCube_003E5__4), Quaternion.identity);
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

	public Bejeweler.GemColour colour;

	public PlayerController owner;

	public void Start()
	{
		if (Object.op_Implicit((Object)(object)((Component)this).GetComponent<Projectile>()) && Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(((Component)this).GetComponent<Projectile>())))
		{
			owner = ProjectileUtility.ProjectilePlayerOwner(((Component)this).GetComponent<Projectile>());
		}
	}

	public override void Initialize(AppliedEffectBase source)
	{
	}

	public override void AddSelfToTarget(GameObject target)
	{
		if (!((Object)(object)target.GetComponent<HealthHaver>() == (Object)null) && !((Object)(object)owner == (Object)null))
		{
			Jeweled orAddComponent = GameObjectExtensions.GetOrAddComponent<Jeweled>(target);
			orAddComponent.AddGem(((BraveBehaviour)target.GetComponent<HealthHaver>()).gameActor, colour);
			if (ThreeGemmedEnemiesinRadius(owner, target.GetComponent<SpeculativeRigidbody>(), colour))
			{
				((MonoBehaviour)GameManager.Instance).StartCoroutine(HandleCUBE(owner, colour));
			}
		}
	}

	public static IEnumerator HandleCUBE(PlayerController user, Bejeweler.GemColour colour)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CHandleCUBE_003Ed__5(0)
		{
			user = user,
			colour = colour
		};
	}

	public static Vector2 GetCenteredPosition(PlayerController relevantPlayer, List<AIActor> actors)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		if (actors.Count == 1)
		{
			return Vector2.op_Implicit(Vector3.Lerp(Vector2.op_Implicit(((BraveBehaviour)actors[0]).specRigidbody.UnitCenter), Vector2.op_Implicit(((BraveBehaviour)relevantPlayer).specRigidbody.UnitCenter), 0.25f));
		}
		if (actors.Count == 2)
		{
			return Vector2.op_Implicit(Vector3.Lerp(Vector2.op_Implicit(((BraveBehaviour)actors[0]).specRigidbody.UnitCenter), Vector2.op_Implicit(((BraveBehaviour)actors[1]).specRigidbody.UnitCenter), 0.5f));
		}
		if (actors.Count >= 3)
		{
			Vector3 val = default(Vector3);
			((Vector3)(ref val))._002Ector(0f, 0f, 0f);
			float num = 0f;
			foreach (AIActor actor in actors)
			{
				val += new Vector3(((BraveBehaviour)actor).specRigidbody.UnitCenter.x, ((BraveBehaviour)actor).specRigidbody.UnitCenter.y, 0f);
				num += 1f;
			}
			return Vector2.op_Implicit(val / num);
		}
		return ((GameActor)relevantPlayer).CenterPosition;
	}

	public bool ThreeGemmedEnemiesinRadius(PlayerController user, SpeculativeRigidbody center, Bejeweler.GemColour colourToCheck)
	{
		int num = 0;
		List<AIActor> activeEnemies = user.CurrentRoom.GetActiveEnemies((ActiveEnemyType)0);
		if (activeEnemies != null)
		{
			for (int i = 0; i < activeEnemies.Count; i++)
			{
				AIActor val = activeEnemies[i];
				if (Object.op_Implicit((Object)(object)val) && Object.op_Implicit((Object)(object)((Component)val).GetComponent<Jeweled>()))
				{
					num += ((Component)val).GetComponent<Jeweled>().instantiatedGemVFX.FindAll((Tuple<Bejeweler.GemColour, GameObject> x) => x.First == colourToCheck).Count();
				}
			}
		}
		return num >= 3;
	}
}
