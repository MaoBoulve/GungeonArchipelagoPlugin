using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class OwnerConnectLightningModifier : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CHandleDamageCooldown_003Ed__12 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AIActor damagedTarget;

		public OwnerConnectLightningModifier _003C_003E4__this;

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
		public _003CHandleDamageCooldown_003Ed__12(int _003C_003E1__state)
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
				_003C_003E2__current = (object)new WaitForSeconds(0.1f);
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

	public GameObject linkPrefab;

	public float DamagePerTick;

	private GameActor owner;

	private tk2dTiledSprite extantLink;

	private Projectile self;

	private HashSet<AIActor> m_damagedEnemies = new HashSet<AIActor>();

	public OwnerConnectLightningModifier()
	{
		linkPrefab = St4ke.LinkVFXPrefab;
		DamagePerTick = 2f;
	}

	private void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)extantLink))
		{
			SpawnManager.Despawn(((Component)extantLink).gameObject);
		}
	}

	private void Start()
	{
		self = ((Component)this).GetComponent<Projectile>();
		if (Object.op_Implicit((Object)(object)self) && Object.op_Implicit((Object)(object)self.Owner))
		{
			owner = self.Owner;
		}
	}

	private void Update()
	{
		if (Object.op_Implicit((Object)(object)self) && Object.op_Implicit((Object)(object)owner) && (Object)(object)extantLink == (Object)null)
		{
			tk2dTiledSprite component = SpawnManager.SpawnVFX(linkPrefab, false).GetComponent<tk2dTiledSprite>();
			extantLink = component;
		}
		else if (Object.op_Implicit((Object)(object)self) && Object.op_Implicit((Object)(object)owner) && (Object)(object)extantLink != (Object)null)
		{
			UpdateLink(owner, extantLink);
		}
		else if ((Object)(object)extantLink != (Object)null)
		{
			SpawnManager.Despawn(((Component)extantLink).gameObject);
			extantLink = null;
		}
	}

	private void UpdateLink(GameActor target, tk2dTiledSprite m_extantLink)
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
		Vector2 unitCenter = ((BraveBehaviour)self).specRigidbody.UnitCenter;
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
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_027e: Unknown result type (might be due to invalid IL or missing references)
		//IL_025d: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_039f: Unknown result type (might be due to invalid IL or missing references)
		//IL_037e: Unknown result type (might be due to invalid IL or missing references)
		if (owner is PlayerController)
		{
			float damagePerTick = DamagePerTick;
			damagePerTick *= ProjectileUtility.ProjectilePlayerOwner(self).stats.GetStatValue((StatType)5);
			for (int i = 0; i < StaticReferenceManager.AllEnemies.Count; i++)
			{
				AIActor val = StaticReferenceManager.AllEnemies[i];
				if (!m_damagedEnemies.Contains(val) && Object.op_Implicit((Object)(object)val) && val.HasBeenEngaged && val.IsNormalEnemy && Object.op_Implicit((Object)(object)((BraveBehaviour)val).specRigidbody) && Object.op_Implicit((Object)(object)((BraveBehaviour)val).healthHaver))
				{
					if (((BraveBehaviour)val).healthHaver.IsBoss)
					{
						damagePerTick *= ProjectileUtility.ProjectilePlayerOwner(self).stats.GetStatValue((StatType)22);
					}
					Vector2 zero = Vector2.zero;
					if (BraveUtility.LineIntersectsAABB(p1, p2, ((BraveBehaviour)val).specRigidbody.HitboxPixelCollider.UnitBottomLeft, ((BraveBehaviour)val).specRigidbody.HitboxPixelCollider.UnitDimensions, ref zero))
					{
						((BraveBehaviour)val).healthHaver.ApplyDamage(DamagePerTick, Vector2.zero, "Chain Lightning", (CoreDamageTypes)64, (DamageCategory)0, false, (PixelCollider)null, false);
						((MonoBehaviour)GameManager.Instance).StartCoroutine(HandleDamageCooldown(val));
					}
				}
			}
		}
		else
		{
			if (!(owner is AIActor))
			{
				return;
			}
			if ((Object)(object)GameManager.Instance.PrimaryPlayer != (Object)null)
			{
				PlayerController primaryPlayer = GameManager.Instance.PrimaryPlayer;
				Vector2 zero2 = Vector2.zero;
				if (BraveUtility.LineIntersectsAABB(p1, p2, ((BraveBehaviour)primaryPlayer).specRigidbody.HitboxPixelCollider.UnitBottomLeft, ((BraveBehaviour)primaryPlayer).specRigidbody.HitboxPixelCollider.UnitDimensions, ref zero2) && Object.op_Implicit((Object)(object)((BraveBehaviour)primaryPlayer).healthHaver) && ((BraveBehaviour)primaryPlayer).healthHaver.IsVulnerable && !primaryPlayer.IsEthereal && !primaryPlayer.IsGhost)
				{
					string text = "Electricity";
					if (Object.op_Implicit((Object)(object)((BraveBehaviour)owner).encounterTrackable))
					{
						text = ((BraveBehaviour)owner).encounterTrackable.GetModifiedDisplayName();
					}
					if (self.IsBlackBullet)
					{
						((BraveBehaviour)primaryPlayer).healthHaver.ApplyDamage(1f, Vector2.zero, text, (CoreDamageTypes)64, (DamageCategory)4, true, (PixelCollider)null, false);
					}
					else
					{
						((BraveBehaviour)primaryPlayer).healthHaver.ApplyDamage(0.5f, Vector2.zero, text, (CoreDamageTypes)64, (DamageCategory)0, false, (PixelCollider)null, false);
					}
				}
			}
			if (!((Object)(object)GameManager.Instance.SecondaryPlayer != (Object)null))
			{
				return;
			}
			PlayerController secondaryPlayer = GameManager.Instance.SecondaryPlayer;
			Vector2 zero3 = Vector2.zero;
			if (BraveUtility.LineIntersectsAABB(p1, p2, ((BraveBehaviour)secondaryPlayer).specRigidbody.HitboxPixelCollider.UnitBottomLeft, ((BraveBehaviour)secondaryPlayer).specRigidbody.HitboxPixelCollider.UnitDimensions, ref zero3) && Object.op_Implicit((Object)(object)((BraveBehaviour)secondaryPlayer).healthHaver) && ((BraveBehaviour)secondaryPlayer).healthHaver.IsVulnerable && !secondaryPlayer.IsEthereal && !secondaryPlayer.IsGhost)
			{
				string text2 = "Electricity";
				if (Object.op_Implicit((Object)(object)((BraveBehaviour)owner).encounterTrackable))
				{
					text2 = ((BraveBehaviour)owner).encounterTrackable.GetModifiedDisplayName();
				}
				if (self.IsBlackBullet)
				{
					((BraveBehaviour)secondaryPlayer).healthHaver.ApplyDamage(1f, Vector2.zero, text2, (CoreDamageTypes)64, (DamageCategory)4, true, (PixelCollider)null, false);
				}
				else
				{
					((BraveBehaviour)secondaryPlayer).healthHaver.ApplyDamage(0.5f, Vector2.zero, text2, (CoreDamageTypes)64, (DamageCategory)0, false, (PixelCollider)null, false);
				}
			}
		}
	}

	private IEnumerator HandleDamageCooldown(AIActor damagedTarget)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CHandleDamageCooldown_003Ed__12(0)
		{
			_003C_003E4__this = this,
			damagedTarget = damagedTarget
		};
	}
}
