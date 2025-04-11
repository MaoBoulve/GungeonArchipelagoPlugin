using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class ClickProjMod : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CHandleClickDeath_003Ed__2 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ClickProjMod _003C_003E4__this;

		private int _003Ci_003E5__1;

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
		public _003CHandleClickDeath_003Ed__2(int _003C_003E1__state)
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
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				Object.Instantiate<GameObject>(SharedVFX.WhiteCircleVFX, Vector2.op_Implicit(((BraveBehaviour)_003C_003E4__this.m_projectile).specRigidbody.UnitCenter), Quaternion.identity);
				_003Ci_003E5__1 = 0;
				break;
			case 1:
				_003C_003E1__state = -1;
				_003Ci_003E5__1++;
				break;
			}
			if (_003Ci_003E5__1 < 10)
			{
				_003C_003E4__this.HandleForceToPosition();
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			_003C_003E4__this.m_projectile.DieInAir(false, true, true, false);
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

	private Projectile m_projectile;

	private PlayerController owner;

	private void Start()
	{
		m_projectile = ((Component)this).GetComponent<Projectile>();
		if (m_projectile.Owner is PlayerController)
		{
			ref PlayerController reference = ref owner;
			GameActor obj = m_projectile.Owner;
			reference = (PlayerController)(object)((obj is PlayerController) ? obj : null);
		}
		if (Object.op_Implicit((Object)(object)owner))
		{
			if (!BraveInput.GetInstanceForPlayer(owner.PlayerIDX).IsKeyboardAndMouse(false))
			{
				ProjectileData baseData = m_projectile.baseData;
				baseData.damage *= 2f;
				m_projectile.RuntimeUpdateScale(1.5f);
			}
			if (CustomSynergies.PlayerHasActiveSynergy(owner, "One Click Away!"))
			{
				m_projectile.RuntimeUpdateScale(1.5f);
			}
		}
		HandleForceToPosition();
		((MonoBehaviour)this).StartCoroutine(HandleClickDeath());
	}

	private void HandleForceToPosition()
	{
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		if (!Object.op_Implicit((Object)(object)owner))
		{
			return;
		}
		if (BraveInput.GetInstanceForPlayer(owner.PlayerIDX).IsKeyboardAndMouse(false))
		{
			Vector2 cursorPosition = PlayerUtility.GetCursorPosition(owner, 1f);
			cursorPosition += new Vector2(0f, 0.56f);
			((BraveBehaviour)m_projectile).specRigidbody.Position = new Position(cursorPosition);
			((BraveBehaviour)m_projectile).specRigidbody.UpdateColliderPositions();
		}
		else if ((Object)(object)m_projectile.PossibleSourceGun != (Object)null && (Object)(object)((Component)m_projectile.PossibleSourceGun).GetComponent<Clicker>() != (Object)null)
		{
			Clicker component = ((Component)m_projectile.PossibleSourceGun).GetComponent<Clicker>();
			if ((Object)(object)component.m_extantReticleQuad != (Object)null)
			{
				Vector2 worldCenter = component.m_extantReticleQuad.WorldCenter;
				((BraveBehaviour)m_projectile).specRigidbody.Position = new Position(worldCenter);
				((BraveBehaviour)m_projectile).specRigidbody.UpdateColliderPositions();
			}
		}
		else
		{
			((BraveBehaviour)m_projectile).specRigidbody.Position = new Position(PlayerUtility.GetCursorPosition(owner, Random.Range(5f, 10f)));
			((BraveBehaviour)m_projectile).specRigidbody.UpdateColliderPositions();
		}
	}

	private IEnumerator HandleClickDeath()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CHandleClickDeath_003Ed__2(0)
		{
			_003C_003E4__this = this
		};
	}
}
