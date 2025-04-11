using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.Misc;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class DeskFanBlowey : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CDoBlowey_003Ed__2 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public DeskFanBlowey _003C_003E4__this;

		private RoomHandler _003Croom_003E5__1;

		private List<AIActor> _003Cenemies_003E5__2;

		private int _003Ci_003E5__3;

		private AIActor _003Cenemy_003E5__4;

		private Vector2 _003Cdir_003E5__5;

		private float _003Cknockback_003E5__6;

		private float _003Cdmg_003E5__7;

		private List<GameActorEffect> _003Ceffects_003E5__8;

		private List<GameActorEffect>.Enumerator _003C_003Es__9;

		private GameActorEffect _003Ceffect_003E5__10;

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
		public _003CDoBlowey_003Ed__2(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003Croom_003E5__1 = null;
			_003Cenemies_003E5__2 = null;
			_003Cenemy_003E5__4 = null;
			_003Ceffects_003E5__8 = null;
			_003C_003Es__9 = default(List<GameActorEffect>.Enumerator);
			_003Ceffect_003E5__10 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_012b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0140: Unknown result type (might be due to invalid IL or missing references)
			//IL_0145: Unknown result type (might be due to invalid IL or missing references)
			//IL_014a: Unknown result type (might be due to invalid IL or missing references)
			//IL_014e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0153: Unknown result type (might be due to invalid IL or missing references)
			//IL_029e: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_02df: Unknown result type (might be due to invalid IL or missing references)
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
				_003Croom_003E5__1 = ProjectileUtility.GetAbsoluteRoom(_003C_003E4__this.self);
				if (_003Croom_003E5__1 != null)
				{
					_003Cenemies_003E5__2 = _003Croom_003E5__1.GetActiveEnemies((ActiveEnemyType)0);
					_003Ci_003E5__3 = 0;
					while (_003Ci_003E5__3 < _003Cenemies_003E5__2.Count)
					{
						_003Cenemy_003E5__4 = _003Cenemies_003E5__2[_003Ci_003E5__3];
						if (Object.op_Implicit((Object)(object)_003Cenemy_003E5__4) && Object.op_Implicit((Object)(object)((BraveBehaviour)_003Cenemy_003E5__4).healthHaver) && ((BraveBehaviour)_003Cenemy_003E5__4).healthHaver.IsAlive && MathsAndLogicHelper.PositionBetweenRelativeValidAngles(((BraveBehaviour)_003Cenemy_003E5__4).sprite.WorldCenter, ((BraveBehaviour)_003C_003E4__this.self).specRigidbody.UnitCenter, Vector2Extensions.ToAngle(_003C_003E4__this.self.Direction), 1000000f, 45f))
						{
							Vector2 val = ((BraveBehaviour)_003Cenemy_003E5__4).sprite.WorldCenter - ((BraveBehaviour)_003C_003E4__this.self).specRigidbody.UnitCenter;
							_003Cdir_003E5__5 = ((Vector2)(ref val)).normalized;
							_003Cknockback_003E5__6 = 10f;
							_003Cdmg_003E5__7 = _003C_003E4__this.damageToDeal;
							if (_003C_003E4__this.deleteSelf)
							{
								_003Cdmg_003E5__7 *= _003C_003E4__this.self.baseData.damage;
							}
							else
							{
								_003Cdmg_003E5__7 *= _003C_003E4__this.self.baseData.damage / 10f;
							}
							if (Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(_003C_003E4__this.self)))
							{
								_003Cknockback_003E5__6 *= ProjectileUtility.ProjectilePlayerOwner(_003C_003E4__this.self).stats.GetStatValue((StatType)12);
								if (((BraveBehaviour)_003Cenemy_003E5__4).healthHaver.IsBoss)
								{
									_003Cdmg_003E5__7 *= ProjectileUtility.ProjectilePlayerOwner(_003C_003E4__this.self).stats.GetStatValue((StatType)22);
								}
								if (((BraveBehaviour)_003Cenemy_003E5__4).aiActor.IsBlackPhantom)
								{
									_003Cdmg_003E5__7 *= _003C_003E4__this.self.BlackPhantomDamageMultiplier;
								}
							}
							((BraveBehaviour)_003Cenemy_003E5__4).healthHaver.ApplyDamage(_003Cdmg_003E5__7, _003Cdir_003E5__5 * -1f, "Blowie", (CoreDamageTypes)0, (DamageCategory)0, false, (PixelCollider)null, false);
							if (Object.op_Implicit((Object)(object)((BraveBehaviour)_003Cenemy_003E5__4).knockbackDoer))
							{
								((BraveBehaviour)_003Cenemy_003E5__4).knockbackDoer.ApplyKnockback(_003Cdir_003E5__5, _003Cknockback_003E5__6, false);
							}
							_003Ceffects_003E5__8 = ProjectileUtility.GetFullListOfStatusEffects(_003C_003E4__this.self, false);
							if (_003Ceffects_003E5__8.Count > 0)
							{
								_003C_003Es__9 = _003Ceffects_003E5__8.GetEnumerator();
								try
								{
									while (_003C_003Es__9.MoveNext())
									{
										_003Ceffect_003E5__10 = _003C_003Es__9.Current;
										((GameActor)_003Cenemy_003E5__4).ApplyEffect(_003Ceffect_003E5__10, 1f, (Projectile)null);
										_003Ceffect_003E5__10 = null;
									}
								}
								finally
								{
									((IDisposable)_003C_003Es__9/*cast due to .constrained prefix*/).Dispose();
								}
								_003C_003Es__9 = default(List<GameActorEffect>.Enumerator);
							}
							if (Object.op_Implicit((Object)(object)((BraveBehaviour)_003Cenemy_003E5__4).behaviorSpeculator) && _003C_003E4__this.self.AppliesStun && Random.value <= _003C_003E4__this.self.StunApplyChance)
							{
								((BraveBehaviour)_003Cenemy_003E5__4).behaviorSpeculator.Stun(_003C_003E4__this.self.AppliedStunDuration, true);
							}
							_003Ceffects_003E5__8 = null;
						}
						_003Cenemy_003E5__4 = null;
						_003Ci_003E5__3++;
					}
					_003Cenemies_003E5__2 = null;
				}
				if (_003C_003E4__this.deleteSelf)
				{
					Object.Destroy((Object)(object)((Component)_003C_003E4__this.self).gameObject);
				}
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

	private Projectile self;

	public bool deleteSelf;

	public float damageToDeal;

	public DeskFanBlowey()
	{
		deleteSelf = true;
		damageToDeal = 1f;
	}

	private void Start()
	{
		self = ((Component)this).GetComponent<Projectile>();
		((MonoBehaviour)this).StartCoroutine(DoBlowey());
	}

	private IEnumerator DoBlowey()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CDoBlowey_003Ed__2(0)
		{
			_003C_003E4__this = this
		};
	}
}
