using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace NevernamedsItems;

public class GameActorSizeEffect : GameActorEffect
{
	[CompilerGenerated]
	private sealed class _003CLerpToSize_003Ed__4 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AIActor target;

		public Vector2 targetScale;

		public GameActorSizeEffect _003C_003E4__this;

		private float _003Celapsed_003E5__1;

		private Vector2 _003CstartScale_003E5__2;

		private int _003CcachedLayer_003E5__3;

		private int _003CcachedOutlineLayer_003E5__4;

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
		public _003CLerpToSize_003Ed__4(int _003C_003E1__state)
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
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			//IL_00be: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003Celapsed_003E5__1 = 0f;
				_003CstartScale_003E5__2 = target.EnemyScale;
				_003CcachedLayer_003E5__3 = ((Component)target).gameObject.layer;
				_003CcachedOutlineLayer_003E5__4 = _003CcachedLayer_003E5__3;
				((Component)target).gameObject.layer = LayerMask.NameToLayer("Unpixelated");
				_003CcachedOutlineLayer_003E5__4 = SpriteOutlineManager.ChangeOutlineLayer(((BraveBehaviour)target).sprite, LayerMask.NameToLayer("Unpixelated"));
				break;
			case 1:
				_003C_003E1__state = -1;
				break;
			}
			if (_003Celapsed_003E5__1 < 1f)
			{
				_003Celapsed_003E5__1 += target.LocalDeltaTime;
				target.EnemyScale = Vector2.Lerp(_003CstartScale_003E5__2, targetScale, _003Celapsed_003E5__1 / 1f);
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

	public Vector2 newScaleMultiplier;

	public bool adjustsSpeed;

	public GameActorSizeEffect()
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		base.TintColor = ExtendedColours.plaguePurple;
		base.DeathTintColor = ExtendedColours.plaguePurple;
		base.AppliesTint = false;
		base.AppliesDeathTint = false;
		newScaleMultiplier = new Vector2(0.4f, 0.4f);
		adjustsSpeed = false;
	}

	public override void OnEffectApplied(GameActor actor, RuntimeGameActorEffectData effectData, float partialAmount = 1f)
	{
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		((GameActorEffect)this).OnEffectApplied(actor, effectData, partialAmount);
		if (Object.op_Implicit((Object)(object)((BraveBehaviour)actor).aiActor) && (!Object.op_Implicit((Object)(object)((BraveBehaviour)actor).healthHaver) || (!((BraveBehaviour)actor).healthHaver.IsBoss && !((BraveBehaviour)actor).healthHaver.IsSubboss)))
		{
			SpecialSizeStatModification orAddComponent = GameObjectExtensions.GetOrAddComponent<SpecialSizeStatModification>(((Component)actor).gameObject);
			orAddComponent.canBeSteppedOn = true;
			orAddComponent.adjustsSpeed = adjustsSpeed;
			Vector2 targetScale = default(Vector2);
			((Vector2)(ref targetScale))._002Ector(((BraveBehaviour)actor).aiActor.EnemyScale.x * newScaleMultiplier.x, ((BraveBehaviour)actor).aiActor.EnemyScale.y * newScaleMultiplier.y);
			((MonoBehaviour)actor).StartCoroutine(LerpToSize(((BraveBehaviour)actor).aiActor, targetScale));
		}
	}

	private IEnumerator LerpToSize(AIActor target, Vector2 targetScale)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CLerpToSize_003Ed__4(0)
		{
			_003C_003E4__this = this,
			target = target,
			targetScale = targetScale
		};
	}

	public override void OnEffectRemoved(GameActor actor, RuntimeGameActorEffectData effectData)
	{
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		((GameActorEffect)this).OnEffectRemoved(actor, effectData);
		if (Object.op_Implicit((Object)(object)((BraveBehaviour)actor).aiActor) && (!Object.op_Implicit((Object)(object)((BraveBehaviour)actor).healthHaver) || (!((BraveBehaviour)actor).healthHaver.IsBoss && !((BraveBehaviour)actor).healthHaver.IsSubboss)))
		{
			Vector2 targetScale = default(Vector2);
			((Vector2)(ref targetScale))._002Ector(((BraveBehaviour)actor).aiActor.EnemyScale.x / newScaleMultiplier.x, ((BraveBehaviour)actor).aiActor.EnemyScale.y / newScaleMultiplier.y);
			((MonoBehaviour)actor).StartCoroutine(LerpToSize(((BraveBehaviour)actor).aiActor, targetScale));
		}
	}
}
