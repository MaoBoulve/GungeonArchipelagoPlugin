using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace NevernamedsItems;

internal class ImplosionBehaviour : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CExplode_003Ed__3 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Vector3 vec;

		public ExplosionData explosionData;

		public CoreDamageTypes damageTypes;

		public bool ignoreQueues;

		public bool ignoreDamageCaps;

		public float distortionIntensity;

		public float distorionRadius;

		public float maxDistortionRadius;

		public float distortionDuration;

		public float waitTime;

		public GameObject vfx;

		public bool doSuck;

		public ImplosionBehaviour _003C_003E4__this;

		private float _003Celapsed_003E5__1;

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
		public _003CExplode_003Ed__3(int _003C_003E1__state)
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
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0103: Unknown result type (might be due to invalid IL or missing references)
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				if (Object.op_Implicit((Object)(object)vfx))
				{
					Object.Instantiate<GameObject>(vfx, vec, Quaternion.identity);
				}
				_003Celapsed_003E5__1 = 0f;
				break;
			case 1:
				_003C_003E1__state = -1;
				break;
			}
			if (_003Celapsed_003E5__1 < waitTime)
			{
				if (doSuck)
				{
					Exploder.DoRadialKnockback(vec, 0f - 100f * BraveTime.DeltaTime, 10f);
				}
				_003Celapsed_003E5__1 += BraveTime.DeltaTime;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			Exploder.Explode(vec, explosionData, Vector2.zero, (Action)null, ignoreQueues, damageTypes, ignoreDamageCaps);
			if (distortionIntensity != -1f)
			{
				Exploder.DoDistortionWave(Vector2.op_Implicit(vec), distortionIntensity, distorionRadius, maxDistortionRadius, distortionDuration);
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

	private Projectile projectile;

	public bool Suck = false;

	public GameObject vfx;

	public float waitTime;

	public ExplosionData explosionData;

	public bool doDistortionWave;

	public float distortionIntensity = 1f;

	public float distortionRadius = 1f;

	public float maxDistortionRadius = 10f;

	public float distortionDuration = 0.5f;

	public bool IgnoreQueues;

	public void Start()
	{
		projectile = ((Component)this).GetComponent<Projectile>();
		projectile.OnDestruction += OnDestruction;
	}

	private void OnDestruction(Projectile self)
	{
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_020e: Unknown result type (might be due to invalid IL or missing references)
		//IL_021a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)projectile) && Object.op_Implicit((Object)(object)projectile.Owner))
		{
			if (projectile.Owner is PlayerController)
			{
				for (int i = 0; i < GameManager.Instance.AllPlayers.Length; i++)
				{
					PlayerController val = GameManager.Instance.AllPlayers[i];
					if (Object.op_Implicit((Object)(object)val) && Object.op_Implicit((Object)(object)((BraveBehaviour)val).specRigidbody))
					{
						explosionData.ignoreList.Add(((BraveBehaviour)val).specRigidbody);
					}
				}
			}
			else
			{
				explosionData.ignoreList.Add(((BraveBehaviour)projectile.Owner).specRigidbody);
			}
		}
		Vector3 vec = Vector2Extensions.ToVector3ZUp(((BraveBehaviour)projectile).specRigidbody.UnitCenter, 0f);
		CoreDamageTypes val2 = (CoreDamageTypes)0;
		if (explosionData.doDamage && explosionData.damageRadius < 10f && Object.op_Implicit((Object)(object)projectile))
		{
			if (projectile.AppliesFreeze)
			{
				val2 = (CoreDamageTypes)(val2 | 8);
			}
			if (projectile.AppliesFire)
			{
				val2 = (CoreDamageTypes)(val2 | 4);
			}
			if (projectile.AppliesPoison)
			{
				val2 = (CoreDamageTypes)(val2 | 0x10);
			}
			if (projectile.statusEffectsToApply != null)
			{
				for (int j = 0; j < projectile.statusEffectsToApply.Count; j++)
				{
					GameActorEffect val3 = projectile.statusEffectsToApply[j];
					if (val3 is GameActorFreezeEffect)
					{
						val2 = (CoreDamageTypes)(val2 | 8);
					}
					else if (val3 is GameActorFireEffect)
					{
						val2 = (CoreDamageTypes)(val2 | 4);
					}
					else if (val3 is GameActorHealthEffect)
					{
						val2 = (CoreDamageTypes)(val2 | 0x10);
					}
				}
			}
		}
		((MonoBehaviour)GameManager.Instance).StartCoroutine(Explode(vec, explosionData.CopyExplosionData(), val2, IgnoreQueues, projectile.ignoreDamageCaps, doDistortionWave ? distortionIntensity : (-1f), distortionRadius, maxDistortionRadius, distortionDuration, waitTime, vfx, Suck));
	}

	private IEnumerator Explode(Vector3 vec, ExplosionData explosionData, CoreDamageTypes damageTypes, bool ignoreQueues, bool ignoreDamageCaps, float distortionIntensity, float distorionRadius, float maxDistortionRadius, float distortionDuration, float waitTime, GameObject vfx, bool doSuck)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CExplode_003Ed__3(0)
		{
			_003C_003E4__this = this,
			vec = vec,
			explosionData = explosionData,
			damageTypes = damageTypes,
			ignoreQueues = ignoreQueues,
			ignoreDamageCaps = ignoreDamageCaps,
			distortionIntensity = distortionIntensity,
			distorionRadius = distorionRadius,
			maxDistortionRadius = maxDistortionRadius,
			distortionDuration = distortionDuration,
			waitTime = waitTime,
			vfx = vfx,
			doSuck = doSuck
		};
	}
}
