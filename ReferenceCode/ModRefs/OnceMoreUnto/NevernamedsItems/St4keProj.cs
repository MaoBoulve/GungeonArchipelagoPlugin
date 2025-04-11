using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace NevernamedsItems;

public class St4keProj : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CHandleDamageCooldown_003Ed__7 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AIActor damagedTarget;

		public St4keProj _003C_003E4__this;

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
		public _003CHandleDamageCooldown_003Ed__7(int _003C_003E1__state)
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
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Expected O, but got Unknown
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E4__this.m_damagedEnemies.Add(damagedTarget);
				_003C_003E2__current = (object)new WaitForSeconds(0.25f);
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				_003C_003E4__this.m_damagedEnemies.Remove(damagedTarget);
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

	public static Projectile lastFiredSt4keBullet;

	public float DamagePerHit;

	private tk2dTiledSprite extantLink;

	private HashSet<AIActor> m_damagedEnemies = new HashSet<AIActor>();

	private Projectile electricTarget;

	public bool IsElectricitySource;

	private Projectile m_projectile;

	private float m_hitNormal;

	private PlayerController projOwner;

	public St4keProj()
	{
		DamagePerHit = 7f;
		IsElectricitySource = false;
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
		if ((Object)(object)lastFiredSt4keBullet == (Object)null || (Object)(object)((Component)lastFiredSt4keBullet).gameObject == (Object)null || !((Behaviour)lastFiredSt4keBullet).isActiveAndEnabled)
		{
			lastFiredSt4keBullet = m_projectile;
			return;
		}
		if (!((Component)lastFiredSt4keBullet).GetComponent<St4keProj>().IsElectricitySource)
		{
			IsElectricitySource = true;
			electricTarget = lastFiredSt4keBullet;
		}
		lastFiredSt4keBullet = m_projectile;
	}

	private void Update()
	{
		if (Object.op_Implicit((Object)(object)m_projectile) && Object.op_Implicit((Object)(object)electricTarget) && (Object)(object)extantLink == (Object)null)
		{
			tk2dTiledSprite component = SpawnManager.SpawnVFX(St4ke.LinkVFXPrefab, false).GetComponent<tk2dTiledSprite>();
			extantLink = component;
		}
		else if (Object.op_Implicit((Object)(object)m_projectile) && Object.op_Implicit((Object)(object)electricTarget) && (Object)(object)extantLink != (Object)null)
		{
			UpdateLink(electricTarget, extantLink);
		}
		else if ((Object)(object)extantLink != (Object)null)
		{
			SpawnManager.Despawn(((Component)extantLink).gameObject);
			extantLink = null;
		}
	}

	private void UpdateLink(Projectile target, tk2dTiledSprite m_extantLink)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		Vector2 unitCenter = ((BraveBehaviour)m_projectile).specRigidbody.UnitCenter;
		Vector2 unitCenter2 = ((BraveBehaviour)target).specRigidbody.HitboxPixelCollider.UnitCenter;
		((BraveBehaviour)m_extantLink).transform.position = Vector2.op_Implicit(unitCenter);
		Vector2 val = unitCenter2 - unitCenter;
		float num = BraveMathCollege.Atan2Degrees(((Vector2)(ref val)).normalized);
		int num2 = Mathf.RoundToInt(((Vector2)(ref val)).magnitude / 0.0625f);
		m_extantLink.dimensions = new Vector2((float)num2, m_extantLink.dimensions.y);
		((BraveBehaviour)m_extantLink).transform.rotation = Quaternion.Euler(0f, 0f, num);
		((tk2dBaseSprite)m_extantLink).UpdateZDepth();
		ApplyLinearDamage(unitCenter, unitCenter2);
	}

	private void ApplyLinearDamage(Vector2 p1, Vector2 p2)
	{
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		float damagePerHit = DamagePerHit;
		damagePerHit *= projOwner.stats.GetStatValue((StatType)5);
		for (int i = 0; i < StaticReferenceManager.AllEnemies.Count; i++)
		{
			AIActor val = StaticReferenceManager.AllEnemies[i];
			if (!m_damagedEnemies.Contains(val) && Object.op_Implicit((Object)(object)val) && val.HasBeenEngaged && val.IsNormalEnemy && Object.op_Implicit((Object)(object)((BraveBehaviour)val).specRigidbody))
			{
				Vector2 zero = Vector2.zero;
				if (BraveUtility.LineIntersectsAABB(p1, p2, ((BraveBehaviour)val).specRigidbody.HitboxPixelCollider.UnitBottomLeft, ((BraveBehaviour)val).specRigidbody.HitboxPixelCollider.UnitDimensions, ref zero))
				{
					((BraveBehaviour)val).healthHaver.ApplyDamage(damagePerHit, Vector2.zero, "Chain Lightning", (CoreDamageTypes)64, (DamageCategory)0, false, (PixelCollider)null, false);
					((MonoBehaviour)GameManager.Instance).StartCoroutine(HandleDamageCooldown(val));
				}
			}
		}
	}

	private void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)extantLink))
		{
			SpawnManager.Despawn(((Component)extantLink).gameObject);
		}
	}

	private IEnumerator HandleDamageCooldown(AIActor damagedTarget)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CHandleDamageCooldown_003Ed__7(0)
		{
			_003C_003E4__this = this,
			damagedTarget = damagedTarget
		};
	}

	private void OnCollision(CollisionData tileCollision)
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		ProjectileData baseData = m_projectile.baseData;
		baseData.speed *= 0f;
		m_projectile.UpdateSpeed();
		m_hitNormal = Vector2Extensions.ToAngle(((CastResult)tileCollision).Normal);
		PhysicsEngine.PostSliceVelocity = default(Vector2);
		SpeculativeRigidbody specRigidbody = ((BraveBehaviour)m_projectile).specRigidbody;
		specRigidbody.OnCollision = (Action<CollisionData>)Delegate.Remove(specRigidbody.OnCollision, new Action<CollisionData>(OnCollision));
		BulletLifeTimer orAddComponent = GameObjectExtensions.GetOrAddComponent<BulletLifeTimer>(((Component)m_projectile).gameObject);
		orAddComponent.secondsTillDeath = 20f;
	}
}
