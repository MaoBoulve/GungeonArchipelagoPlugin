using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace NevernamedsItems;

public class ClipBurner : BraveBehaviour
{
	[CompilerGenerated]
	private sealed class _003CBurnBlackPhantomCorpse_003Ed__2 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ClipBurner _003C_003E4__this;

		private Material _003CtargetMaterial_003E5__1;

		private float _003Cela_003E5__2;

		private float _003Cdura_003E5__3;

		private float _003Ct_003E5__4;

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
		public _003CBurnBlackPhantomCorpse_003Ed__2(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003CtargetMaterial_003E5__1 = null;
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
				_003CtargetMaterial_003E5__1 = ((BraveBehaviour)((BraveBehaviour)_003C_003E4__this).sprite).renderer.material;
				_003Cela_003E5__2 = 0f;
				_003Cdura_003E5__3 = 3f;
				break;
			case 1:
				_003C_003E1__state = -1;
				break;
			}
			if (_003Cela_003E5__2 < _003Cdura_003E5__3)
			{
				_003Cela_003E5__2 += BraveTime.DeltaTime;
				_003Ct_003E5__4 = _003Cela_003E5__2 / _003Cdura_003E5__3;
				_003CtargetMaterial_003E5__1.SetFloat("_BurnAmount", _003Ct_003E5__4);
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			_003C_003E4__this.doParticles = false;
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

	private float particleCounter = 0f;

	private bool doParticles = true;

	private void Start()
	{
		((BraveBehaviour)((BraveBehaviour)this).sprite).renderer.material.shader = ShaderCache.Acquire("Brave/LitCutoutUberPhantom");
		((BraveBehaviour)((BraveBehaviour)this).sprite).renderer.material.SetFloat("_PhantomGradientScale", 0.75f);
		((BraveBehaviour)((BraveBehaviour)this).sprite).renderer.material.SetFloat("_PhantomContrastPower", 1.3f);
		((BraveBehaviour)((BraveBehaviour)this).sprite).renderer.material.SetFloat("_ApplyFade", 0.3f);
		((BraveBehaviour)this).sprite.usesOverrideMaterial = true;
		DebrisObject debris = ((BraveBehaviour)this).debris;
		debris.OnGrounded = (Action<DebrisObject>)Delegate.Combine(debris.OnGrounded, new Action<DebrisObject>(OnGround));
	}

	public void OnGround(DebrisObject self)
	{
		((MonoBehaviour)this).StartCoroutine(BurnBlackPhantomCorpse());
	}

	private IEnumerator BurnBlackPhantomCorpse()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CBurnBlackPhantomCorpse_003Ed__2(0)
		{
			_003C_003E4__this = this
		};
	}

	private void Update()
	{
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		if (doParticles)
		{
			particleCounter += BraveTime.DeltaTime * 2f;
			if (particleCounter > 1f)
			{
				int num = Mathf.FloorToInt(particleCounter);
				particleCounter %= 1f;
				GlobalSparksDoer.DoRandomParticleBurst(num, Vector2Extensions.ToVector3ZisY(((BraveBehaviour)this).sprite.WorldBottomLeft, 0f), Vector2Extensions.ToVector3ZisY(((BraveBehaviour)this).sprite.WorldTopRight, 0f), Vector3.up, 90f, 0.5f, (float?)null, (float?)null, (Color?)null, (SparksType)1);
			}
		}
	}
}
