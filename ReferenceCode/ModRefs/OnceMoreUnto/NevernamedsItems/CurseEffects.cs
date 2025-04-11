using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public static class CurseEffects
{
	[CompilerGenerated]
	private sealed class _003CTriggerCurseDeathEffects_003Ed__2 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Vector2 position;

		public string guid;

		public float maxHP;

		public bool isJammed;

		public bool isCharmed;

		private int _003Cmax_003E5__1;

		private int _003Camt_003E5__2;

		private int _003Ci_003E5__3;

		private string _003CbatGUID_003E5__4;

		private AIActor _003CtargetActor_003E5__5;

		private AIActor _003CenemyToSpawn_003E5__6;

		private AIActor _003CTargetActor_003E5__7;

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
		public _003CTriggerCurseDeathEffects_003Ed__2(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003CbatGUID_003E5__4 = null;
			_003CtargetActor_003E5__5 = null;
			_003CenemyToSpawn_003E5__6 = null;
			_003CTargetActor_003E5__7 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_0227: Unknown result type (might be due to invalid IL or missing references)
			//IL_025b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0169: Unknown result type (might be due to invalid IL or missing references)
			//IL_017e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0184: Unknown result type (might be due to invalid IL or missing references)
			//IL_0102: Unknown result type (might be due to invalid IL or missing references)
			//IL_0108: Unknown result type (might be due to invalid IL or missing references)
			//IL_010e: Unknown result type (might be due to invalid IL or missing references)
			if (_003C_003E1__state != 0)
			{
				return false;
			}
			_003C_003E1__state = -1;
			if (CurseManager.CurseIsActive("Curse of Infestation") && maxHP > 10f)
			{
				if (maxHP < 30f)
				{
					_003Cmax_003E5__1 = 2;
				}
				else if (maxHP > 30f && maxHP < 50f)
				{
					_003Cmax_003E5__1 = 3;
				}
				else
				{
					_003Cmax_003E5__1 = 4;
				}
				_003Camt_003E5__2 = Random.Range(-1, _003Cmax_003E5__1);
				if (_003Camt_003E5__2 > 0)
				{
					_003Ci_003E5__3 = 0;
					while (_003Ci_003E5__3 < _003Camt_003E5__2)
					{
						_003CbatGUID_003E5__4 = BraveUtility.RandomElement<string>(AlexandriaTags.GetAllEnemyGuidsWithTag("small_bullat"));
						if (GameManagerUtility.AnyPlayerHasActiveSynergy(GameManager.Instance, "The Last Crusade") | isCharmed)
						{
							_003CtargetActor_003E5__5 = CompanionisedEnemyUtility.SpawnCompanionisedEnemy(GameManager.Instance.PrimaryPlayer, _003CbatGUID_003E5__4, Vector2Extensions.ToIntVector2(position, (VectorConversions)2), doTint: false, Color.red, 5, 2, shouldBeJammed: false, doFriendlyOverhead: false);
							PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(((BraveBehaviour)_003CtargetActor_003E5__5).specRigidbody, (int?)null, false);
							_003CtargetActor_003E5__5 = null;
						}
						else
						{
							_003CenemyToSpawn_003E5__6 = EnemyDatabase.GetOrLoadByGuid(_003CbatGUID_003E5__4);
							_003CTargetActor_003E5__7 = AIActor.Spawn(_003CenemyToSpawn_003E5__6, position, GameManager.Instance.Dungeon.data.GetAbsoluteRoomFromPosition(Vector2Extensions.ToIntVector2(position, (VectorConversions)2)), true, (AwakenAnimationType)0, true);
							PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(((BraveBehaviour)_003CTargetActor_003E5__7).specRigidbody, (int?)null, false);
							_003CTargetActor_003E5__7.PreventBlackPhantom = true;
							_003CenemyToSpawn_003E5__6 = null;
							_003CTargetActor_003E5__7 = null;
						}
						_003CbatGUID_003E5__4 = null;
						_003Ci_003E5__3++;
					}
				}
			}
			if (CurseManager.CurseIsActive("Curse of Sludge"))
			{
				DoCurseGoopCircle(EasyGoopDefinitions.EnemyFriendlyPoisonGoop, EasyGoopDefinitions.PlayerFriendlyPoisonGoop, position, maxHP, isJammed);
			}
			if (CurseManager.CurseIsActive("Curse of The Hive"))
			{
				DoCurseGoopCircle(EasyGoopDefinitions.HoneyGoop, EasyGoopDefinitions.PlayerFriendlyHoneyGoop, position, maxHP, isJammed);
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

	public static void Init()
	{
		CustomActions.OnAnyHealthHaverDie = (Action<HealthHaver>)Delegate.Combine(CustomActions.OnAnyHealthHaverDie, new Action<HealthHaver>(AnyHealthHaverKilled));
	}

	public static void AnyHealthHaverKilled(HealthHaver target)
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)target) && Object.op_Implicit((Object)(object)((BraveBehaviour)target).aiActor) && Object.op_Implicit((Object)(object)((BraveBehaviour)target).specRigidbody))
		{
			ETGMod.StartGlobalCoroutine(TriggerCurseDeathEffects(((BraveBehaviour)target).specRigidbody.UnitCenter, ((BraveBehaviour)target).aiActor.EnemyGuid, ((BraveBehaviour)target).healthHaver.GetMaxHealth(), ((BraveBehaviour)target).aiActor.IsBlackPhantom, ((BraveBehaviour)target).aiActor.CanTargetEnemies && !((BraveBehaviour)target).aiActor.CanTargetPlayers));
		}
	}

	public static IEnumerator TriggerCurseDeathEffects(Vector2 position, string guid, float maxHP, bool isJammed, bool isCharmed)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CTriggerCurseDeathEffects_003Ed__2(0)
		{
			position = position,
			guid = guid,
			maxHP = maxHP,
			isJammed = isJammed,
			isCharmed = isCharmed
		};
	}

	public static void DoCurseGoopCircle(GoopDefinition def, GoopDefinition crusadeGoop, Vector2 pos, float maxHP, bool isJammed)
	{
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		if (maxHP > 0f)
		{
			DeadlyDeadlyGoopManager val = null;
			val = ((!GameManagerUtility.AnyPlayerHasActiveSynergy(GameManager.Instance, "The Last Crusade")) ? DeadlyDeadlyGoopManager.GetGoopManagerForGoopType(def) : DeadlyDeadlyGoopManager.GetGoopManagerForGoopType(crusadeGoop));
			float num = maxHP;
			if (isJammed)
			{
				num /= 3.5f;
			}
			num /= AIActor.BaseLevelHealthModifier;
			float num2 = Math.Min(num / 7.5f, 6f);
			val.TimedAddGoopCircle(pos, num2, 0.75f, true);
		}
	}
}
