using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class PlayerProjectileTeleportModifier : BraveBehaviour
{
	public enum TeleportTrigger
	{
		AngleToTarget = 10,
		DistanceFromTarget = 20
	}

	public enum TeleportType
	{
		BackToSpawn = 10,
		BehindTarget = 20
	}

	[CompilerGenerated]
	private sealed class _003CDoTeleport_003Ed__12 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerProjectileTeleportModifier _003C_003E4__this;

		private VFXPool _003Cvfxpool_003E5__1;

		private Vector3 _003Cposition_003E5__2;

		private Transform _003Ctransform_003E5__3;

		private Vector2 _003CnewPosition_003E5__4;

		private VFXPool _003Cvfxpool2_003E5__5;

		private Vector2 _003CfiringCenter_003E5__6;

		private Vector2 _003CtargetCenter_003E5__7;

		private PlayerController _003CtargetPlayer_003E5__8;

		private Vector2 _003CtargetVelocity_003E5__9;

		private Vector2 _003CpredictedPosition_003E5__10;

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
		public _003CDoTeleport_003Ed__12(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003Cvfxpool_003E5__1 = null;
			_003Ctransform_003E5__3 = null;
			_003Cvfxpool2_003E5__5 = null;
			_003CtargetPlayer_003E5__8 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Unknown result type (might be due to invalid IL or missing references)
			//IL_004a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			//IL_0206: Unknown result type (might be due to invalid IL or missing references)
			//IL_020b: Unknown result type (might be due to invalid IL or missing references)
			//IL_021c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0221: Unknown result type (might be due to invalid IL or missing references)
			//IL_025a: Unknown result type (might be due to invalid IL or missing references)
			//IL_025f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0264: Unknown result type (might be due to invalid IL or missing references)
			//IL_0281: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_02de: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_013d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0147: Expected O, but got Unknown
			//IL_03b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_03bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_03c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_0353: Unknown result type (might be due to invalid IL or missing references)
			//IL_0341: Unknown result type (might be due to invalid IL or missing references)
			//IL_0358: Unknown result type (might be due to invalid IL or missing references)
			//IL_035f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0365: Unknown result type (might be due to invalid IL or missing references)
			//IL_036b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0380: Unknown result type (might be due to invalid IL or missing references)
			//IL_0385: Unknown result type (might be due to invalid IL or missing references)
			//IL_038c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0392: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0420: Unknown result type (might be due to invalid IL or missing references)
			//IL_0441: Unknown result type (might be due to invalid IL or missing references)
			//IL_0447: Unknown result type (might be due to invalid IL or missing references)
			//IL_044c: Unknown result type (might be due to invalid IL or missing references)
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003Cvfxpool_003E5__1 = _003C_003E4__this.teleportVfx;
				_003Cposition_003E5__2 = Vector2.op_Implicit(((BraveBehaviour)_003C_003E4__this).specRigidbody.UnitCenter);
				_003Ctransform_003E5__3 = ((BraveBehaviour)_003C_003E4__this).transform;
				_003Cvfxpool_003E5__1.SpawnAtPosition(_003Cposition_003E5__2, 0f, _003Ctransform_003E5__3, (Vector2?)null, (Vector2?)null, (float?)null, false, (SpawnMethod)null, (tk2dBaseSprite)null, false);
				if (_003C_003E4__this.teleportPauseTime > 0f)
				{
					_003C_003E4__this.m_isTeleporting = true;
					((BraveBehaviour)((BraveBehaviour)_003C_003E4__this).sprite).renderer.enabled = false;
					((Behaviour)((BraveBehaviour)_003C_003E4__this).projectile).enabled = false;
					((Behaviour)((BraveBehaviour)_003C_003E4__this).specRigidbody).enabled = false;
					if (Object.op_Implicit((Object)(object)((BraveBehaviour)_003C_003E4__this).projectile.braveBulletScript))
					{
						((Behaviour)((BraveBehaviour)_003C_003E4__this).projectile.braveBulletScript).enabled = false;
					}
					_003C_003E2__current = (object)new WaitForSeconds(_003C_003E4__this.teleportPauseTime);
					_003C_003E1__state = 1;
					return true;
				}
				break;
			case 1:
				_003C_003E1__state = -1;
				if (!Object.op_Implicit((Object)(object)_003C_003E4__this) || !Object.op_Implicit((Object)(object)_003C_003E4__this.m_targetRigidbody))
				{
					return false;
				}
				_003C_003E4__this.m_isTeleporting = false;
				((BraveBehaviour)((BraveBehaviour)_003C_003E4__this).sprite).renderer.enabled = true;
				((Behaviour)((BraveBehaviour)_003C_003E4__this).projectile).enabled = true;
				((Behaviour)((BraveBehaviour)_003C_003E4__this).specRigidbody).enabled = true;
				if (Object.op_Implicit((Object)(object)((BraveBehaviour)_003C_003E4__this).projectile.braveBulletScript))
				{
					((Behaviour)((BraveBehaviour)_003C_003E4__this).projectile.braveBulletScript).enabled = true;
				}
				break;
			}
			_003CnewPosition_003E5__4 = _003C_003E4__this.GetTeleportPosition();
			((BraveBehaviour)_003C_003E4__this).transform.position = Vector2.op_Implicit(_003CnewPosition_003E5__4);
			((BraveBehaviour)_003C_003E4__this).specRigidbody.Reinitialize();
			_003Cvfxpool2_003E5__5 = _003C_003E4__this.teleportVfx;
			_003Cposition_003E5__2 = Vector2.op_Implicit(((BraveBehaviour)_003C_003E4__this).specRigidbody.UnitCenter);
			_003Ctransform_003E5__3 = ((BraveBehaviour)_003C_003E4__this).transform;
			_003Cvfxpool2_003E5__5.SpawnAtPosition(_003Cposition_003E5__2, 0f, _003Ctransform_003E5__3, (Vector2?)null, (Vector2?)null, (float?)null, false, (SpawnMethod)null, (tk2dBaseSprite)null, false);
			_003CfiringCenter_003E5__6 = ((BraveBehaviour)_003C_003E4__this).specRigidbody.UnitCenter;
			_003CtargetCenter_003E5__7 = ((BraveBehaviour)_003C_003E4__this.m_targetRigidbody).specRigidbody.GetUnitCenter((ColliderType)2);
			ref PlayerController reference = ref _003CtargetPlayer_003E5__8;
			GameActor gameActor = ((BraveBehaviour)_003C_003E4__this.m_targetRigidbody).gameActor;
			reference = (PlayerController)(object)((gameActor is PlayerController) ? gameActor : null);
			if (_003C_003E4__this.leadAmount > 0f && Object.op_Implicit((Object)(object)_003CtargetPlayer_003E5__8))
			{
				_003CtargetVelocity_003E5__9 = ((!Object.op_Implicit((Object)(object)_003CtargetPlayer_003E5__8)) ? _003C_003E4__this.m_targetRigidbody.Velocity : _003CtargetPlayer_003E5__8.AverageVelocity);
				_003CpredictedPosition_003E5__10 = BraveMathCollege.GetPredictedPosition(_003CtargetCenter_003E5__7, _003CtargetVelocity_003E5__9, _003CfiringCenter_003E5__6, ((BraveBehaviour)_003C_003E4__this).projectile.Speed);
				_003CtargetCenter_003E5__7 = Vector2.Lerp(_003CtargetCenter_003E5__7, _003CpredictedPosition_003E5__10, _003C_003E4__this.leadAmount);
			}
			((BraveBehaviour)_003C_003E4__this).projectile.SendInDirection(_003CtargetCenter_003E5__7 - _003CfiringCenter_003E5__6, true, true);
			if (Object.op_Implicit((Object)(object)((BraveBehaviour)_003C_003E4__this).projectile.braveBulletScript) && ((BraveBehaviour)_003C_003E4__this).projectile.braveBulletScript.bullet != null)
			{
				((BraveBehaviour)_003C_003E4__this).projectile.braveBulletScript.bullet.Position = _003CnewPosition_003E5__4;
				((BraveBehaviour)_003C_003E4__this).projectile.braveBulletScript.bullet.Direction = Vector2Extensions.ToAngle(_003CtargetCenter_003E5__7 - _003CnewPosition_003E5__4);
			}
			_003C_003E4__this.numTeleports--;
			_003C_003E4__this.m_cooldown = _003C_003E4__this.teleportCooldown;
			if (_003C_003E4__this.OnTeleport != null)
			{
				_003C_003E4__this.OnTeleport();
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

	public TeleportTrigger trigger;

	[ShowInInspectorIf("ShowMMinAngleToTeleport", true)]
	public float minAngleToTeleport;

	[ShowInInspectorIf("ShowDistToTeleport", true)]
	public float distToTeleport;

	public TeleportType type;

	[ShowInInspectorIf("ShowBehindTargetDistance", true)]
	public float behindTargetDistance;

	public int numTeleports;

	public float teleportPauseTime;

	public float leadAmount;

	public float teleportCooldown;

	public VFXPool teleportVfx;

	private SpeculativeRigidbody m_targetRigidbody;

	private Vector3 m_startingPos;

	private bool m_isTeleporting;

	private float m_cooldown;

	public event Action OnTeleport;

	public PlayerProjectileTeleportModifier()
	{
		trigger = TeleportTrigger.AngleToTarget;
		minAngleToTeleport = 70f;
		distToTeleport = 3f;
		type = TeleportType.BackToSpawn;
		behindTargetDistance = 5f;
	}

	private bool ShowMMinAngleToTeleport()
	{
		return trigger == TeleportTrigger.AngleToTarget;
	}

	private bool ShowDistToTeleport()
	{
		return trigger == TeleportTrigger.DistanceFromTarget;
	}

	private bool ShowBehindTargetDistance()
	{
		return type == TeleportType.BehindTarget;
	}

	public void Start()
	{
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		if (!Object.op_Implicit((Object)(object)((BraveBehaviour)this).sprite))
		{
			((BraveBehaviour)this).sprite = (tk2dBaseSprite)(object)((Component)this).GetComponentInChildren<tk2dSprite>();
		}
		if (Object.op_Implicit((Object)(object)((BraveBehaviour)this).projectile) && ((BraveBehaviour)this).projectile.Owner is AIActor)
		{
			ref SpeculativeRigidbody targetRigidbody = ref m_targetRigidbody;
			GameActor owner = ((BraveBehaviour)this).projectile.Owner;
			targetRigidbody = ((AIActor)((owner is AIActor) ? owner : null)).TargetRigidbody;
		}
		else if (Object.op_Implicit((Object)(object)((BraveBehaviour)this).projectile) && ((BraveBehaviour)this).projectile.Owner is PlayerController)
		{
			AIActor randomActiveEnemy = MiscToolbox.GetAbsoluteRoomFromProjectile(((BraveBehaviour)this).projectile).GetRandomActiveEnemy(false);
			m_targetRigidbody = ((BraveBehaviour)randomActiveEnemy).specRigidbody;
		}
		if (!Object.op_Implicit((Object)(object)m_targetRigidbody))
		{
			((Behaviour)this).enabled = false;
		}
		else
		{
			m_startingPos = ((BraveBehaviour)this).transform.position;
		}
	}

	public void Update()
	{
		if (!m_isTeleporting)
		{
			if (m_cooldown > 0f)
			{
				m_cooldown -= BraveTime.DeltaTime;
			}
			else if (numTeleports > 0 && ShouldTeleport())
			{
				((MonoBehaviour)this).StartCoroutine(DoTeleport());
			}
		}
	}

	public override void OnDestroy()
	{
		((MonoBehaviour)this).StopAllCoroutines();
		((BraveBehaviour)this).OnDestroy();
	}

	private bool ShouldTeleport()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)m_targetRigidbody))
		{
			Vector2 unitCenter = m_targetRigidbody.GetUnitCenter((ColliderType)2);
			if (trigger == TeleportTrigger.AngleToTarget)
			{
				float num = Vector2Extensions.ToAngle(unitCenter - ((BraveBehaviour)this).specRigidbody.UnitCenter);
				float num2 = Vector2Extensions.ToAngle(((BraveBehaviour)this).specRigidbody.Velocity);
				return BraveMathCollege.AbsAngleBetween(num, num2) > minAngleToTeleport;
			}
			return trigger == TeleportTrigger.DistanceFromTarget && Vector2.Distance(unitCenter, ((BraveBehaviour)this).specRigidbody.UnitCenter) < distToTeleport;
		}
		return false;
	}

	private Vector2 GetTeleportPosition()
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		if (type == TeleportType.BackToSpawn)
		{
			return Vector2.op_Implicit(m_startingPos);
		}
		if (type == TeleportType.BehindTarget && Object.op_Implicit((Object)(object)m_targetRigidbody) && Object.op_Implicit((Object)(object)((BraveBehaviour)m_targetRigidbody).gameActor))
		{
			Vector2 unitCenter = m_targetRigidbody.GetUnitCenter((ColliderType)2);
			float facingDirection = ((BraveBehaviour)m_targetRigidbody).gameActor.FacingDirection;
			Dungeon dungeon = GameManager.Instance.Dungeon;
			for (int i = 0; i < 18; i++)
			{
				Vector2 val = unitCenter + BraveMathCollege.DegreesToVector(facingDirection + 180f + (float)(i * 20), behindTargetDistance);
				if (!dungeon.CellExists(val) || !dungeon.data.isWall((int)val.x, (int)val.y))
				{
					return val;
				}
				val = unitCenter + BraveMathCollege.DegreesToVector(facingDirection + 180f + (float)(i * -20), behindTargetDistance);
				if (!dungeon.CellExists(val) || !dungeon.data.isWall((int)val.x, (int)val.y))
				{
					return val;
				}
			}
		}
		return Vector2.op_Implicit(m_startingPos);
	}

	private IEnumerator DoTeleport()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CDoTeleport_003Ed__12(0)
		{
			_003C_003E4__this = this
		};
	}
}
