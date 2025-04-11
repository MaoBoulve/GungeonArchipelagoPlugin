using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.Misc;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class LeadMaidenProjectileReAiming : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003COnReload_003Ed__9 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public LeadMaidenProjectileReAiming _003C_003E4__this;

		private Vector2 _003CdirVec_003E5__1;

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
		public _003COnReload_003Ed__9(int _003C_003E1__state)
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
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			//IL_003e: Expected O, but got Unknown
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			//IL_0074: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ea: Expected O, but got Unknown
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = (object)new WaitForSeconds(Random.value);
				_003C_003E1__state = 1;
				return true;
			case 1:
			{
				_003C_003E1__state = -1;
				_003CdirVec_003E5__1 = ProjectileUtility.GetVectorToNearestEnemy(_003C_003E4__this.m_projectile, true, (ActiveEnemyType)1, (List<AIActor>)null, (Func<AIActor, bool>)null);
				_003C_003E4__this.m_projectile.SendInDirection(_003CdirVec_003E5__1, false, true);
				ProjectileData baseData = _003C_003E4__this.m_projectile.baseData;
				baseData.speed *= 10000f;
				_003C_003E4__this.m_projectile.UpdateSpeed();
				((BraveBehaviour)_003C_003E4__this.m_projectile).specRigidbody.CollideWithTileMap = false;
				_003C_003E4__this.m_projectile.UpdateCollisionMask();
				_003C_003E2__current = (object)new WaitForSeconds(0.25f);
				_003C_003E1__state = 2;
				return true;
			}
			case 2:
				_003C_003E1__state = -1;
				((BraveBehaviour)_003C_003E4__this.m_projectile).specRigidbody.CollideWithTileMap = true;
				_003C_003E4__this.m_projectile.UpdateCollisionMask();
				_003C_003E4__this.m_projectile.BulletScriptSettings.surviveTileCollisions = false;
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

	public int timesReAimed;

	public int maxTimedToReAim;

	public float reAimCooldown;

	private bool canReAimRightNow;

	private Projectile m_projectile;

	private float m_hitNormal;

	private PlayerController projOwner;

	public LeadMaidenProjectileReAiming()
	{
		timesReAimed = 0;
		maxTimedToReAim = 1;
		reAimCooldown = 5f;
		canReAimRightNow = true;
	}

	private void Start()
	{
		m_projectile = ((Component)this).GetComponent<Projectile>();
		if (m_projectile.Owner is PlayerController)
		{
			ref PlayerController reference = ref projOwner;
			GameActor owner = m_projectile.Owner;
			reference = (PlayerController)(object)((owner is PlayerController) ? owner : null);
		}
		SpeculativeRigidbody specRigidbody = ((BraveBehaviour)m_projectile).specRigidbody;
		m_projectile.BulletScriptSettings.surviveTileCollisions = true;
		specRigidbody.OnCollision = (Action<CollisionData>)Delegate.Combine(specRigidbody.OnCollision, new Action<CollisionData>(OnCollision));
	}

	private void OnCollision(CollisionData tileCollision)
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		ProjectileData baseData = m_projectile.baseData;
		baseData.speed *= 0.0001f;
		m_projectile.UpdateSpeed();
		m_hitNormal = Vector2Extensions.ToAngle(((CastResult)tileCollision).Normal);
		PhysicsEngine.PostSliceVelocity = default(Vector2);
		SpeculativeRigidbody specRigidbody = ((BraveBehaviour)m_projectile).specRigidbody;
		specRigidbody.OnCollision = (Action<CollisionData>)Delegate.Remove(specRigidbody.OnCollision, new Action<CollisionData>(OnCollision));
	}

	private void Update()
	{
		if (canReAimRightNow && timesReAimed < maxTimedToReAim && (Object)(object)projOwner != (Object)null && (Object)(object)((GameActor)projOwner).CurrentGun != (Object)null && ((GameActor)projOwner).CurrentGun.IsReloading)
		{
			timesReAimed++;
			((MonoBehaviour)GameManager.Instance).StartCoroutine(OnReload());
			canReAimRightNow = false;
			((MonoBehaviour)this).Invoke("HandleCooldown", reAimCooldown);
		}
	}

	private void HandleCooldown()
	{
		canReAimRightNow = true;
	}

	private IEnumerator OnReload()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003COnReload_003Ed__9(0)
		{
			_003C_003E4__this = this
		};
	}
}
