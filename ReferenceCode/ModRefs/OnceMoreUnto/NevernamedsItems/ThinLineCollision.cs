using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class ThinLineCollision : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CdelayedAssign_003Ed__2 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ThinLineCollision _003C_003E4__this;

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
		public _003CdelayedAssign_003Ed__2(int _003C_003E1__state)
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
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0096: Expected O, but got Unknown
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a0: Expected O, but got Unknown
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
			{
				_003C_003E1__state = -1;
				_003C_003E4__this.m_projectile.collidesWithProjectiles = true;
				_003C_003E4__this.m_projectile.collidesOnlyWithPlayerProjectiles = true;
				_003C_003E4__this.m_projectile.UpdateCollisionMask();
				SpeculativeRigidbody specRigidbody = ((BraveBehaviour)_003C_003E4__this.m_projectile).specRigidbody;
				specRigidbody.OnPreRigidbodyCollision = (OnPreRigidbodyCollisionDelegate)Delegate.Combine((Delegate)(object)specRigidbody.OnPreRigidbodyCollision, (Delegate)new OnPreRigidbodyCollisionDelegate(_003C_003E4__this.OnCollision));
				return false;
			}
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

	private Projectile m_projectile;

	private PlayerController owner;

	public void Start()
	{
		m_projectile = ((Component)this).GetComponent<Projectile>();
		if (m_projectile.Owner is PlayerController)
		{
			ref PlayerController reference = ref owner;
			GameActor obj = m_projectile.Owner;
			reference = (PlayerController)(object)((obj is PlayerController) ? obj : null);
		}
		((MonoBehaviour)GameManager.Instance).StartCoroutine(delayedAssign());
	}

	public IEnumerator delayedAssign()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CdelayedAssign_003Ed__2(0)
		{
			_003C_003E4__this = this
		};
	}

	private void OnCollision(SpeculativeRigidbody myRigidbody, PixelCollider myPixelCollider, SpeculativeRigidbody otherRigidbody, PixelCollider otherPixelCollider)
	{
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (Object.op_Implicit((Object)(object)otherRigidbody) && Object.op_Implicit((Object)(object)((BraveBehaviour)otherRigidbody).projectile))
			{
				ThinLineCollidee component = ((Component)((BraveBehaviour)otherRigidbody).projectile).gameObject.GetComponent<ThinLineCollidee>();
				if ((Object)(object)component != (Object)null)
				{
					DoOnCollisionEffect(((BraveBehaviour)myRigidbody).sprite.WorldCenter);
				}
				else
				{
					PhysicsEngine.SkipCollision = true;
				}
			}
		}
		catch (Exception ex)
		{
			ETGModConsole.Log((object)ex.Message, false);
			ETGModConsole.Log((object)ex.StackTrace, false);
		}
	}

	private void DoOnCollisionEffect(Vector2 position)
	{
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)owner))
		{
			if (Random.value <= 0.5f && CustomSynergies.PlayerHasActiveSynergy(owner, "Parallel Lines"))
			{
				doMiniBlank(position);
			}
			else
			{
				Exploder.Explode(Vector2.op_Implicit(position), TheThinLine.DataForProjectiles, Vector2.zero, (Action)null, false, (CoreDamageTypes)0, false);
			}
		}
	}

	private void doMiniBlank(Vector2 position)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected O, but got Unknown
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected O, but got Unknown
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = (GameObject)ResourceCache.Acquire("Global VFX/BlankVFX_Ghost");
		AkSoundEngine.PostEvent("Play_OBJ_silenceblank_small_01", ((Component)this).gameObject);
		GameObject val2 = new GameObject("silencer");
		SilencerInstance val3 = val2.AddComponent<SilencerInstance>();
		float num = 0.25f;
		val3.TriggerSilencer(position, 25f, 5f, val, 0f, 3f, 3f, 3f, 250f, 5f, num, owner, false, false);
	}
}
