using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Dungeonator;
using Pathfinding;
using UnityEngine;

namespace NevernamedsItems;

public class CustomCompanionBehaviours
{
	public class SimpleCompanionMeleeAttack : AttackBehaviorBase
	{
		public bool findTarget = true;

		public float selfKnockbackAmount;

		public float targetKnockbackAmount;

		private PlayerController Owner;

		public float DamagePerTick = 5f;

		public float TickDelay = 1f;

		public float DesiredDistance = 3f;

		private float attackTimer;

		private bool isInRange;

		public override BehaviorResult Update()
		{
			//IL_0232: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_0233: Unknown result type (might be due to invalid IL or missing references)
			//IL_0234: Unknown result type (might be due to invalid IL or missing references)
			//IL_022d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0238: Unknown result type (might be due to invalid IL or missing references)
			//IL_0228: Unknown result type (might be due to invalid IL or missing references)
			//IL_012c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			//IL_013d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0187: Unknown result type (might be due to invalid IL or missing references)
			//IL_0193: Unknown result type (might be due to invalid IL or missing references)
			//IL_0198: Unknown result type (might be due to invalid IL or missing references)
			//IL_0223: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
			((BehaviorBase)this).DecrementTimer(ref attackTimer, false);
			if ((Object)(object)Owner == (Object)null)
			{
				if (Object.op_Implicit((Object)(object)((BehaviorBase)this).m_aiActor) && Object.op_Implicit((Object)(object)((BehaviorBase)this).m_aiActor.CompanionOwner))
				{
					Owner = ((BehaviorBase)this).m_aiActor.CompanionOwner;
				}
				else
				{
					Owner = GameManager.Instance.BestActivePlayer;
				}
			}
			if (Object.op_Implicit((Object)(object)((BehaviorBase)this).m_aiActor) && Object.op_Implicit((Object)(object)((BehaviorBase)this).m_aiActor.OverrideTarget))
			{
				SpeculativeRigidbody overrideTarget = ((BehaviorBase)this).m_aiActor.OverrideTarget;
				isInRange = Vector2.Distance(((BraveBehaviour)((BehaviorBase)this).m_aiActor).specRigidbody.UnitCenter, overrideTarget.UnitCenter) <= DesiredDistance;
				if (isInRange)
				{
					if ((Object)(object)overrideTarget != (Object)null && attackTimer == 0f)
					{
						if (Object.op_Implicit((Object)(object)((BraveBehaviour)overrideTarget).healthHaver))
						{
							((BraveBehaviour)overrideTarget).healthHaver.ApplyDamage(DamagePerTick, MathsAndLogicHelper.CalculateVectorBetween(((BraveBehaviour)((BehaviorBase)this).m_aiActor).transform.position, ((BraveBehaviour)overrideTarget).transform.position), "Companion Melee", (CoreDamageTypes)0, (DamageCategory)0, false, (PixelCollider)null, false);
						}
						if (targetKnockbackAmount != 0f && (Object)(object)((BraveBehaviour)overrideTarget).knockbackDoer != (Object)null)
						{
							((BraveBehaviour)overrideTarget).knockbackDoer.ApplyKnockback(MathsAndLogicHelper.CalculateVectorBetween(((BraveBehaviour)((BehaviorBase)this).m_aiActor).transform.position, ((BraveBehaviour)overrideTarget).transform.position), targetKnockbackAmount, false);
						}
						if (selfKnockbackAmount != 0f && (Object)(object)((BraveBehaviour)((BehaviorBase)this).m_aiActor).knockbackDoer != (Object)null)
						{
							((BraveBehaviour)((BehaviorBase)this).m_aiActor).knockbackDoer.ApplyKnockback(MathsAndLogicHelper.CalculateVectorBetween(((BraveBehaviour)overrideTarget).transform.position, ((BraveBehaviour)((BehaviorBase)this).m_aiActor).transform.position), selfKnockbackAmount, false);
						}
						ETGModConsole.Log((object)"ATTACKED!", false);
						attackTimer = TickDelay;
						return (BehaviorResult)2;
					}
					return (BehaviorResult)0;
				}
				return (BehaviorResult)0;
			}
			return (BehaviorResult)0;
		}

		public override float GetMaxRange()
		{
			return 5f;
		}

		public override float GetMinReadyRange()
		{
			return 5f;
		}

		public override bool IsReady()
		{
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_0070: Unknown result type (might be due to invalid IL or missing references)
			AIActor aiActor = ((BehaviorBase)this).m_aiActor;
			bool flag;
			if ((Object)(object)aiActor == (Object)null)
			{
				flag = true;
			}
			else
			{
				SpeculativeRigidbody targetRigidbody = aiActor.TargetRigidbody;
				flag = !(((Object)(object)targetRigidbody != (Object)null) ? new Vector2?(targetRigidbody.UnitCenter) : ((Vector2?)null)).HasValue;
			}
			return !flag && Vector2.Distance(((BraveBehaviour)((BehaviorBase)this).m_aiActor).specRigidbody.UnitCenter, ((BehaviorBase)this).m_aiActor.TargetRigidbody.UnitCenter) <= ((AttackBehaviorBase)this).GetMinReadyRange();
		}
	}

	public class SimpleCompanionApproach : MovementBehaviorBase
	{
		public float PathInterval = 0.25f;

		public float DesiredDistance = 5f;

		private float repathTimer;

		private List<AIActor> roomEnemies = new List<AIActor>();

		private bool isInRange;

		private PlayerController Owner;

		public override void Init(GameObject gameObject, AIActor aiActor, AIShooter aiShooter)
		{
			((BehaviorBase)this).Init(gameObject, aiActor, aiShooter);
		}

		public override void Upkeep()
		{
			((MovementBehaviorBase)this).Upkeep();
			((BehaviorBase)this).DecrementTimer(ref repathTimer, false);
		}

		public override BehaviorResult Update()
		{
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01af: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_013a: Unknown result type (might be due to invalid IL or missing references)
			//IL_016a: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
			if ((Object)(object)Owner == (Object)null)
			{
				if (Object.op_Implicit((Object)(object)((BehaviorBase)this).m_aiActor) && Object.op_Implicit((Object)(object)((BehaviorBase)this).m_aiActor.CompanionOwner))
				{
					Owner = ((BehaviorBase)this).m_aiActor.CompanionOwner;
				}
				else
				{
					Owner = GameManager.Instance.BestActivePlayer;
				}
			}
			SpeculativeRigidbody overrideTarget = ((BehaviorBase)this).m_aiActor.OverrideTarget;
			if (repathTimer > 0f)
			{
				return (BehaviorResult)((!((Object)(object)overrideTarget == (Object)null) && (!Object.op_Implicit((Object)(object)((BraveBehaviour)overrideTarget).healthHaver) || !((BraveBehaviour)overrideTarget).healthHaver.IsDead)) ? 1 : 0);
			}
			if ((Object)(object)overrideTarget == (Object)null || (Object.op_Implicit((Object)(object)((BraveBehaviour)overrideTarget).healthHaver) && ((BraveBehaviour)overrideTarget).healthHaver.IsDead))
			{
				PickNewTarget();
				return (BehaviorResult)0;
			}
			isInRange = Vector2.Distance(((BraveBehaviour)((BehaviorBase)this).m_aiActor).specRigidbody.UnitCenter, overrideTarget.UnitCenter) <= DesiredDistance;
			if ((Object)(object)overrideTarget != (Object)null && !isInRange)
			{
				((BehaviorBase)this).m_aiActor.PathfindToPosition(overrideTarget.UnitCenter, (Vector2?)null, true, (CellValidator)null, (ExtraWeightingFunction)null, (CellTypes?)null, false);
				repathTimer = PathInterval;
				return (BehaviorResult)1;
			}
			if ((Object)(object)overrideTarget != (Object)null && repathTimer >= 0f)
			{
				((BehaviorBase)this).m_aiActor.ClearPath();
				repathTimer = -1f;
			}
			return (BehaviorResult)0;
		}

		private void PickNewTarget()
		{
			if (!((Object)(object)((BehaviorBase)this).m_aiActor != (Object)null))
			{
				return;
			}
			if ((Object)(object)Owner == (Object)null)
			{
				if (Object.op_Implicit((Object)(object)((BehaviorBase)this).m_aiActor) && Object.op_Implicit((Object)(object)((BehaviorBase)this).m_aiActor.CompanionOwner))
				{
					Owner = ((BehaviorBase)this).m_aiActor.CompanionOwner;
				}
				else
				{
					Owner = GameManager.Instance.BestActivePlayer;
				}
			}
			Owner.CurrentRoom.GetActiveEnemies((ActiveEnemyType)1, ref roomEnemies);
			for (int i = 0; i < roomEnemies.Count; i++)
			{
				AIActor val = roomEnemies[i];
				if (val.IsHarmlessEnemy || !val.IsNormalEnemy || ((BraveBehaviour)val).healthHaver.IsDead || (Object)(object)val == (Object)(object)((BehaviorBase)this).m_aiActor || val.EnemyGuid == "ba928393c8ed47819c2c5f593100a5bc")
				{
					roomEnemies.Remove(val);
				}
			}
			if (roomEnemies.Count == 0)
			{
				((BehaviorBase)this).m_aiActor.OverrideTarget = null;
				return;
			}
			AIActor aiActor = ((BehaviorBase)this).m_aiActor;
			AIActor val2 = roomEnemies[Random.Range(0, roomEnemies.Count)];
			aiActor.OverrideTarget = (((Object)(object)val2 != (Object)null) ? ((BraveBehaviour)val2).specRigidbody : null);
		}
	}

	public class PottyCompanionApproach : MovementBehaviorBase
	{
		public float PathInterval = 0.25f;

		public float DesiredDistance = 3f;

		private float repathTimer;

		private List<AIActor> roomEnemies = new List<AIActor>();

		private bool isInRange;

		private PlayerController Owner;

		public override void Init(GameObject gameObject, AIActor aiActor, AIShooter aiShooter)
		{
			((BehaviorBase)this).Init(gameObject, aiActor, aiShooter);
		}

		public override void Upkeep()
		{
			((MovementBehaviorBase)this).Upkeep();
			((BehaviorBase)this).DecrementTimer(ref repathTimer, false);
		}

		public override BehaviorResult Update()
		{
			//IL_0046: Unknown result type (might be due to invalid IL or missing references)
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			//IL_009c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_014e: Unknown result type (might be due to invalid IL or missing references)
			//IL_014f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0153: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_014a: Unknown result type (might be due to invalid IL or missing references)
			SpeculativeRigidbody overrideTarget = ((BehaviorBase)this).m_aiActor.OverrideTarget;
			if (repathTimer > 0f)
			{
				return (BehaviorResult)((!((Object)(object)overrideTarget == (Object)null) && (!Object.op_Implicit((Object)(object)((BraveBehaviour)overrideTarget).healthHaver) || !((BraveBehaviour)overrideTarget).healthHaver.IsDead)) ? 1 : 0);
			}
			if ((Object)(object)overrideTarget == (Object)null || (Object.op_Implicit((Object)(object)((BraveBehaviour)overrideTarget).healthHaver) && ((BraveBehaviour)overrideTarget).healthHaver.IsDead))
			{
				PickNewTarget();
				return (BehaviorResult)0;
			}
			isInRange = Vector2.Distance(((BraveBehaviour)((BehaviorBase)this).m_aiActor).specRigidbody.UnitCenter, overrideTarget.UnitCenter) <= DesiredDistance;
			if ((Object)(object)overrideTarget != (Object)null && !isInRange)
			{
				((BehaviorBase)this).m_aiActor.PathfindToPosition(overrideTarget.UnitCenter, (Vector2?)null, true, (CellValidator)null, (ExtraWeightingFunction)null, (CellTypes?)null, false);
				repathTimer = PathInterval;
				return (BehaviorResult)1;
			}
			if ((Object)(object)overrideTarget != (Object)null && repathTimer >= 0f)
			{
				((BehaviorBase)this).m_aiActor.ClearPath();
				repathTimer = -1f;
			}
			return (BehaviorResult)0;
		}

		private void PickNewTarget()
		{
			if (!((Object)(object)((BehaviorBase)this).m_aiActor != (Object)null))
			{
				return;
			}
			if ((Object)(object)Owner == (Object)null)
			{
				Owner = ((Component)((BehaviorBase)this).m_aiActor).GetComponent<Potty.PottyCompanionBehaviour>().Owner;
			}
			Owner.CurrentRoom.GetActiveEnemies((ActiveEnemyType)1, ref roomEnemies);
			for (int i = 0; i < roomEnemies.Count; i++)
			{
				AIActor val = roomEnemies[i];
				if (val.IsHarmlessEnemy || !val.IsNormalEnemy || ((BraveBehaviour)val).healthHaver.IsDead || (Object)(object)val == (Object)(object)((BehaviorBase)this).m_aiActor || val.EnemyGuid == "ba928393c8ed47819c2c5f593100a5bc")
				{
					roomEnemies.Remove(val);
				}
			}
			if (roomEnemies.Count == 0)
			{
				((BehaviorBase)this).m_aiActor.OverrideTarget = null;
				return;
			}
			AIActor aiActor = ((BehaviorBase)this).m_aiActor;
			AIActor val2 = roomEnemies[Random.Range(0, roomEnemies.Count)];
			aiActor.OverrideTarget = (((Object)(object)val2 != (Object)null) ? ((BraveBehaviour)val2).specRigidbody : null);
		}
	}

	public class LeadOfLifeCompanionApproach : MovementBehaviorBase
	{
		public float PathInterval = 0.25f;

		public float DesiredDistance = 5f;

		public bool isZombieBullets = false;

		private float attackTimer;

		private float repathTimer;

		private List<AIActor> roomEnemies = new List<AIActor>();

		private bool isInRange;

		private PlayerController Owner;

		public override void Init(GameObject gameObject, AIActor aiActor, AIShooter aiShooter)
		{
			((BehaviorBase)this).Init(gameObject, aiActor, aiShooter);
		}

		public override void Upkeep()
		{
			((MovementBehaviorBase)this).Upkeep();
			((BehaviorBase)this).DecrementTimer(ref repathTimer, false);
			((BehaviorBase)this).DecrementTimer(ref attackTimer, false);
		}

		public override BehaviorResult Update()
		{
			//IL_0046: Unknown result type (might be due to invalid IL or missing references)
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			//IL_009c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0154: Unknown result type (might be due to invalid IL or missing references)
			SpeculativeRigidbody overrideTarget = ((BehaviorBase)this).m_aiActor.OverrideTarget;
			if (repathTimer > 0f)
			{
				return (BehaviorResult)((!((Object)(object)overrideTarget == (Object)null) && (!Object.op_Implicit((Object)(object)((BraveBehaviour)overrideTarget).healthHaver) || !((BraveBehaviour)overrideTarget).healthHaver.IsDead)) ? 1 : 0);
			}
			if ((Object)(object)overrideTarget == (Object)null || (Object.op_Implicit((Object)(object)((BraveBehaviour)overrideTarget).healthHaver) && ((BraveBehaviour)overrideTarget).healthHaver.IsDead))
			{
				PickNewTarget();
				return (BehaviorResult)0;
			}
			isInRange = Vector2.Distance(((BraveBehaviour)((BehaviorBase)this).m_aiActor).specRigidbody.UnitCenter, overrideTarget.UnitCenter) <= DesiredDistance;
			if ((Object)(object)overrideTarget != (Object)null && !isInRange)
			{
				((BehaviorBase)this).m_aiActor.PathfindToPosition(overrideTarget.UnitCenter, (Vector2?)null, true, (CellValidator)null, (ExtraWeightingFunction)null, (CellTypes?)null, false);
				repathTimer = PathInterval;
				return (BehaviorResult)1;
			}
			if (isZombieBullets && (Object)(object)overrideTarget != (Object)null && attackTimer == 0f)
			{
				((BraveBehaviour)overrideTarget).healthHaver.ApplyDamage(5f, ((BraveBehaviour)((BehaviorBase)this).m_aiActor).specRigidbody.Velocity, "Zombie Bullets!", (CoreDamageTypes)0, (DamageCategory)0, false, (PixelCollider)null, false);
				attackTimer = 0.5f;
			}
			if ((Object)(object)overrideTarget != (Object)null && repathTimer >= 0f)
			{
				((BehaviorBase)this).m_aiActor.ClearPath();
				repathTimer = -1f;
			}
			return (BehaviorResult)0;
		}

		private void PickNewTarget()
		{
			if (!((Object)(object)((BehaviorBase)this).m_aiActor != (Object)null))
			{
				return;
			}
			if ((Object)(object)Owner == (Object)null)
			{
				Owner = ((Component)((BehaviorBase)this).m_aiActor).GetComponent<LeadOfLifeCompanion>().Owner;
			}
			Owner.CurrentRoom.GetActiveEnemies((ActiveEnemyType)1, ref roomEnemies);
			for (int i = 0; i < roomEnemies.Count; i++)
			{
				AIActor val = roomEnemies[i];
				if (val.IsHarmlessEnemy || !val.IsNormalEnemy || ((BraveBehaviour)val).healthHaver.IsDead || (Object)(object)val == (Object)(object)((BehaviorBase)this).m_aiActor || val.EnemyGuid == "ba928393c8ed47819c2c5f593100a5bc")
				{
					roomEnemies.Remove(val);
				}
			}
			if (roomEnemies.Count == 0)
			{
				((BehaviorBase)this).m_aiActor.OverrideTarget = null;
				return;
			}
			AIActor aiActor = ((BehaviorBase)this).m_aiActor;
			AIActor val2 = roomEnemies[Random.Range(0, roomEnemies.Count)];
			aiActor.OverrideTarget = (((Object)(object)val2 != (Object)null) ? ((BraveBehaviour)val2).specRigidbody : null);
		}
	}

	public class PeanutAttackBehaviour : AttackBehaviorBase
	{
		[CompilerGenerated]
		private sealed class _003CAttack_003Ed__5 : IEnumerator<object>, IDisposable, IEnumerator
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public PeanutAttackBehaviour _003C_003E4__this;

			private float _003Cnum_003E5__1;

			private List<AIActor> _003CactiveEnemies_003E5__2;

			private AIActor _003CnearestEnemy_003E5__3;

			private Vector2 _003CunitCenter_003E5__4;

			private Vector2 _003CunitCenter2_003E5__5;

			private float _003Cz_003E5__6;

			private Vector2 _003CvectorToSpawn_003E5__7;

			private string _003CAnimationName_003E5__8;

			private float _003CmodifiedAngle_003E5__9;

			private float _003CstartRotation_003E5__10;

			private int _003Ci_003E5__11;

			private float _003CactualDirection_003E5__12;

			private bool _003CshouldDoDMGUp_003E5__13;

			private Projectile _003Cprojectile_003E5__14;

			private GameObject _003CgameObject_003E5__15;

			private Projectile _003Ccomponent_003E5__16;

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
			public _003CAttack_003Ed__5(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				_003CactiveEnemies_003E5__2 = null;
				_003CnearestEnemy_003E5__3 = null;
				_003CAnimationName_003E5__8 = null;
				_003Cprojectile_003E5__14 = null;
				_003CgameObject_003E5__15 = null;
				_003Ccomponent_003E5__16 = null;
				_003C_003E1__state = -2;
			}

			private bool MoveNext()
			{
				//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
				//IL_063d: Unknown result type (might be due to invalid IL or missing references)
				//IL_06d5: Unknown result type (might be due to invalid IL or missing references)
				//IL_06db: Unknown result type (might be due to invalid IL or missing references)
				//IL_06e0: Unknown result type (might be due to invalid IL or missing references)
				//IL_06e5: Unknown result type (might be due to invalid IL or missing references)
				//IL_06fa: Unknown result type (might be due to invalid IL or missing references)
				//IL_0697: Unknown result type (might be due to invalid IL or missing references)
				//IL_0178: Unknown result type (might be due to invalid IL or missing references)
				//IL_017d: Unknown result type (might be due to invalid IL or missing references)
				//IL_0193: Unknown result type (might be due to invalid IL or missing references)
				//IL_0198: Unknown result type (might be due to invalid IL or missing references)
				//IL_019f: Unknown result type (might be due to invalid IL or missing references)
				//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
				//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
				//IL_01af: Unknown result type (might be due to invalid IL or missing references)
				//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
				//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
				//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
				//IL_0230: Unknown result type (might be due to invalid IL or missing references)
				//IL_0235: Unknown result type (might be due to invalid IL or missing references)
				//IL_030b: Unknown result type (might be due to invalid IL or missing references)
				//IL_0310: Unknown result type (might be due to invalid IL or missing references)
				//IL_02bd: Unknown result type (might be due to invalid IL or missing references)
				//IL_02c2: Unknown result type (might be due to invalid IL or missing references)
				//IL_0299: Unknown result type (might be due to invalid IL or missing references)
				//IL_029e: Unknown result type (might be due to invalid IL or missing references)
				//IL_05e1: Unknown result type (might be due to invalid IL or missing references)
				//IL_05eb: Expected O, but got Unknown
				//IL_0398: Unknown result type (might be due to invalid IL or missing references)
				//IL_039d: Unknown result type (might be due to invalid IL or missing references)
				//IL_0374: Unknown result type (might be due to invalid IL or missing references)
				//IL_0379: Unknown result type (might be due to invalid IL or missing references)
				//IL_0400: Unknown result type (might be due to invalid IL or missing references)
				//IL_0405: Unknown result type (might be due to invalid IL or missing references)
				//IL_04db: Unknown result type (might be due to invalid IL or missing references)
				//IL_04e0: Unknown result type (might be due to invalid IL or missing references)
				//IL_048d: Unknown result type (might be due to invalid IL or missing references)
				//IL_0492: Unknown result type (might be due to invalid IL or missing references)
				//IL_0469: Unknown result type (might be due to invalid IL or missing references)
				//IL_046e: Unknown result type (might be due to invalid IL or missing references)
				//IL_0568: Unknown result type (might be due to invalid IL or missing references)
				//IL_056d: Unknown result type (might be due to invalid IL or missing references)
				//IL_0544: Unknown result type (might be due to invalid IL or missing references)
				//IL_0549: Unknown result type (might be due to invalid IL or missing references)
				int num = _003C_003E1__state;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					_003C_003E1__state = -1;
					_003CstartRotation_003E5__10 = -30f;
					_003Ci_003E5__11 = 0;
					while (_003Ci_003E5__11 < 7)
					{
						_003CactualDirection_003E5__12 = _003CmodifiedAngle_003E5__9 + _003CstartRotation_003E5__10;
						_003CshouldDoDMGUp_003E5__13 = true;
						_003Cprojectile_003E5__14 = ((Gun)Databases.Items[197]).DefaultModule.projectiles[0];
						if (CustomSynergies.PlayerHasActiveSynergy(_003C_003E4__this.Owner, "Pealadin") && Random.value <= 0.1f)
						{
							_003Cprojectile_003E5__14 = ((Gun)Databases.Items[674]).DefaultModule.projectiles[0];
							_003CshouldDoDMGUp_003E5__13 = false;
						}
						_003CgameObject_003E5__15 = SpawnManager.SpawnProjectile(((Component)_003Cprojectile_003E5__14).gameObject, Vector2.op_Implicit(((BraveBehaviour)((BehaviorBase)_003C_003E4__this).m_aiActor).sprite.WorldCenter + _003CvectorToSpawn_003E5__7), Quaternion.Euler(0f, 0f, _003CactualDirection_003E5__12), true);
						_003Ccomponent_003E5__16 = _003CgameObject_003E5__15.GetComponent<Projectile>();
						_003CgameObject_003E5__15.AddComponent<PierceDeadActors>();
						if ((Object)(object)_003Ccomponent_003E5__16 != (Object)null)
						{
							_003Ccomponent_003E5__16.Owner = (GameActor)(object)_003C_003E4__this.Owner;
							_003Ccomponent_003E5__16.Shooter = ((BraveBehaviour)((BehaviorBase)_003C_003E4__this).m_aiActor).specRigidbody;
							_003Ccomponent_003E5__16.collidesWithPlayer = false;
							if (_003CshouldDoDMGUp_003E5__13)
							{
								ProjectileData baseData = _003Ccomponent_003E5__16.baseData;
								baseData.damage *= 2f;
							}
							ProjectileUtility.ApplyCompanionModifierToBullet(_003Ccomponent_003E5__16, _003C_003E4__this.Owner);
							ProjectileData baseData2 = _003Ccomponent_003E5__16.baseData;
							baseData2.damage *= _003C_003E4__this.Owner.stats.GetStatValue((StatType)5);
							ProjectileData baseData3 = _003Ccomponent_003E5__16.baseData;
							baseData3.range *= _003C_003E4__this.Owner.stats.GetStatValue((StatType)26);
							ProjectileData baseData4 = _003Ccomponent_003E5__16.baseData;
							baseData4.speed *= _003C_003E4__this.Owner.stats.GetStatValue((StatType)6);
							ProjectileData baseData5 = _003Ccomponent_003E5__16.baseData;
							baseData5.force *= _003C_003E4__this.Owner.stats.GetStatValue((StatType)12);
							Projectile obj = _003Ccomponent_003E5__16;
							obj.BossDamageMultiplier *= _003C_003E4__this.Owner.stats.GetStatValue((StatType)22);
							_003Ccomponent_003E5__16.RuntimeUpdateScale(_003C_003E4__this.Owner.stats.GetStatValue((StatType)15));
							_003C_003E4__this.Owner.DoPostProcessProjectile(_003Ccomponent_003E5__16);
						}
						_003CstartRotation_003E5__10 += 10f;
						_003Cprojectile_003E5__14 = null;
						_003CgameObject_003E5__15 = null;
						_003Ccomponent_003E5__16 = null;
						_003Ci_003E5__11++;
					}
					_003CAnimationName_003E5__8 = null;
				}
				else
				{
					_003C_003E1__state = -1;
					if ((Object)(object)_003C_003E4__this.Owner == (Object)null)
					{
						_003C_003E4__this.Owner = ((Component)((BehaviorBase)_003C_003E4__this).m_aiActor).GetComponent<Peanut.PeanutCompanionBehaviour>().Owner;
					}
					_003Cnum_003E5__1 = -1f;
					_003CactiveEnemies_003E5__2 = _003C_003E4__this.Owner.CurrentRoom.GetActiveEnemies((ActiveEnemyType)0);
					if ((_003CactiveEnemies_003E5__2 == null) | (_003CactiveEnemies_003E5__2.Count <= 0))
					{
						goto IL_0933;
					}
					_003CnearestEnemy_003E5__3 = _003C_003E4__this.GetNearestEnemy(_003CactiveEnemies_003E5__2, ((BraveBehaviour)((BehaviorBase)_003C_003E4__this).m_aiActor).sprite.WorldCenter, out _003Cnum_003E5__1, null);
					if (Object.op_Implicit((Object)(object)_003CnearestEnemy_003E5__3) && _003Cnum_003E5__1 < 10f && _003C_003E4__this.IsInRange(_003CnearestEnemy_003E5__3) && !_003CnearestEnemy_003E5__3.IsHarmlessEnemy && _003CnearestEnemy_003E5__3.IsNormalEnemy && !((BraveBehaviour)_003CnearestEnemy_003E5__3).healthHaver.IsDead && (Object)(object)_003CnearestEnemy_003E5__3 != (Object)(object)((BehaviorBase)_003C_003E4__this).m_aiActor)
					{
						_003CunitCenter_003E5__4 = ((BraveBehaviour)((BehaviorBase)_003C_003E4__this).m_aiActor).specRigidbody.UnitCenter;
						_003CunitCenter2_003E5__5 = ((BraveBehaviour)_003CnearestEnemy_003E5__3).specRigidbody.HitboxPixelCollider.UnitCenter;
						Vector2 val = _003CunitCenter2_003E5__5 - _003CunitCenter_003E5__4;
						_003Cz_003E5__6 = BraveMathCollege.Atan2Degrees(((Vector2)(ref val)).normalized);
						_003Cz_003E5__6 = (float)Math.Round(_003Cz_003E5__6, 1);
						_003CvectorToSpawn_003E5__7 = Vector2.zero;
						_003CAnimationName_003E5__8 = null;
						_003CmodifiedAngle_003E5__9 = 0f;
						if (MathsAndLogicHelper.IsBetweenRange(_003Cz_003E5__6, -22.5f, 22.5f))
						{
							_003CmodifiedAngle_003E5__9 = 0f;
							_003CAnimationName_003E5__8 = "attack_east";
							_003CvectorToSpawn_003E5__7 = new Vector2(1f, 0f);
						}
						else if (MathsAndLogicHelper.IsBetweenRange(_003Cz_003E5__6, 22.6f, 67.5f))
						{
							_003CmodifiedAngle_003E5__9 = 45f;
							if (MathsAndLogicHelper.IsBetweenRange(_003Cz_003E5__6, 22.6f, 45f))
							{
								_003CAnimationName_003E5__8 = "attack_east";
								_003CvectorToSpawn_003E5__7 = new Vector2(1f, 0f);
							}
							else
							{
								_003CAnimationName_003E5__8 = "attack_north";
								_003CvectorToSpawn_003E5__7 = new Vector2(0f, 1f);
							}
						}
						else if (MathsAndLogicHelper.IsBetweenRange(_003Cz_003E5__6, 67.6f, 112.5f))
						{
							_003CmodifiedAngle_003E5__9 = 90f;
							_003CAnimationName_003E5__8 = "attack_north";
							_003CvectorToSpawn_003E5__7 = new Vector2(0f, 1f);
						}
						else if (MathsAndLogicHelper.IsBetweenRange(_003Cz_003E5__6, 112.6f, 157.5f))
						{
							_003CmodifiedAngle_003E5__9 = 135f;
							if (MathsAndLogicHelper.IsBetweenRange(_003Cz_003E5__6, 112.6f, 135f))
							{
								_003CAnimationName_003E5__8 = "attack_north";
								_003CvectorToSpawn_003E5__7 = new Vector2(0f, 1f);
							}
							else
							{
								_003CAnimationName_003E5__8 = "attack_west";
								_003CvectorToSpawn_003E5__7 = new Vector2(-1f, 0f);
							}
						}
						else if (MathsAndLogicHelper.IsBetweenRange(_003Cz_003E5__6, 157.6f, 180f) || MathsAndLogicHelper.IsBetweenRange(_003Cz_003E5__6, -157.6f, -180f))
						{
							_003CmodifiedAngle_003E5__9 = 180f;
							_003CAnimationName_003E5__8 = "attack_west";
							_003CvectorToSpawn_003E5__7 = new Vector2(-1f, 0f);
						}
						else if (MathsAndLogicHelper.IsBetweenRange(_003Cz_003E5__6, -67.5f, -22.5f))
						{
							_003CmodifiedAngle_003E5__9 = 315f;
							if (MathsAndLogicHelper.IsBetweenRange(_003Cz_003E5__6, -45f, -22.5f))
							{
								_003CAnimationName_003E5__8 = "attack_east";
								_003CvectorToSpawn_003E5__7 = new Vector2(1f, 0f);
							}
							else
							{
								_003CAnimationName_003E5__8 = "attack_south";
								_003CvectorToSpawn_003E5__7 = new Vector2(0f, -1f);
							}
						}
						else if (MathsAndLogicHelper.IsBetweenRange(_003Cz_003E5__6, -112.5f, -67.6f))
						{
							_003CmodifiedAngle_003E5__9 = 270f;
							_003CAnimationName_003E5__8 = "attack_south";
							_003CvectorToSpawn_003E5__7 = new Vector2(0f, -1f);
						}
						else
						{
							if (!MathsAndLogicHelper.IsBetweenRange(_003Cz_003E5__6, -157.5f, -112.6f))
							{
								Debug.LogError((object)("Peanut attempted to attack in an unrecognised direction, and gave up.\nDirection: " + _003Cz_003E5__6));
								return false;
							}
							_003CmodifiedAngle_003E5__9 = 225f;
							if (MathsAndLogicHelper.IsBetweenRange(_003Cz_003E5__6, -157.5f, -136f))
							{
								_003CAnimationName_003E5__8 = "attack_west";
								_003CvectorToSpawn_003E5__7 = new Vector2(-1f, 0f);
							}
							else
							{
								_003CAnimationName_003E5__8 = "attack_south";
								_003CvectorToSpawn_003E5__7 = new Vector2(0f, -1f);
							}
						}
						if (Object.op_Implicit((Object)(object)((BraveBehaviour)((BehaviorBase)_003C_003E4__this).m_aiActor).aiAnimator))
						{
							((BraveBehaviour)((BehaviorBase)_003C_003E4__this).m_aiActor).aiAnimator.PlayUntilFinished(_003CAnimationName_003E5__8, false, (string)null, -1f, false);
						}
						_003C_003E2__current = (object)new WaitForSeconds(_003C_003E4__this.delayBetweenAttackAndProjectileSpawn);
						_003C_003E1__state = 1;
						return true;
					}
				}
				_003CnearestEnemy_003E5__3 = null;
				goto IL_0933;
				IL_0933:
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

		private bool isAttacking;

		private float attackCooldown = 4f;

		private float attackDuration = 0.5f;

		private float attackTimer;

		private float attackCooldownTimer;

		private float delayBetweenAttackAndProjectileSpawn = 0.2f;

		private PlayerController Owner;

		private List<AIActor> roomEnemies = new List<AIActor>();

		public override void Destroy()
		{
			((BehaviorBase)this).Destroy();
		}

		public override void Init(GameObject gameObject, AIActor aiActor, AIShooter aiShooter)
		{
			((BehaviorBase)this).Init(gameObject, aiActor, aiShooter);
			Owner = ((Component)((BehaviorBase)this).m_aiActor).GetComponent<Peanut.PeanutCompanionBehaviour>().Owner;
		}

		public override BehaviorResult Update()
		{
			//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0101: Unknown result type (might be due to invalid IL or missing references)
			//IL_0102: Unknown result type (might be due to invalid IL or missing references)
			//IL_0106: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
			if (attackTimer > 0f && isAttacking)
			{
				((BehaviorBase)this).DecrementTimer(ref attackTimer, false);
			}
			else if (attackCooldownTimer > 0f && !isAttacking)
			{
				((BehaviorBase)this).DecrementTimer(ref attackCooldownTimer, false);
			}
			if ((!((AttackBehaviorBase)this).IsReady() || attackCooldownTimer > 0f || attackTimer == 0f || (Object)(object)((BehaviorBase)this).m_aiActor.TargetRigidbody == (Object)null) && isAttacking)
			{
				StopAttacking();
				return (BehaviorResult)0;
			}
			if (((AttackBehaviorBase)this).IsReady() && attackCooldownTimer == 0f && !isAttacking)
			{
				attackTimer = attackDuration;
				isAttacking = true;
				((MonoBehaviour)((BehaviorBase)this).m_aiActor).StartCoroutine(Attack());
				return (BehaviorResult)2;
			}
			return (BehaviorResult)0;
		}

		private void StopAttacking()
		{
			isAttacking = false;
			attackTimer = 0f;
			attackCooldownTimer = attackCooldown;
		}

		public AIActor GetNearestEnemy(List<AIActor> activeEnemies, Vector2 position, out float nearestDistance, string[] filter)
		{
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			AIActor result = null;
			nearestDistance = float.MaxValue;
			if (activeEnemies == null)
			{
				return null;
			}
			for (int i = 0; i < activeEnemies.Count; i++)
			{
				AIActor val = activeEnemies[i];
				if (Object.op_Implicit((Object)(object)((BraveBehaviour)val).healthHaver) && ((BraveBehaviour)val).healthHaver.IsVulnerable && !((BraveBehaviour)val).healthHaver.IsDead && (filter == null || !filter.Contains(val.EnemyGuid)))
				{
					float num = Vector2.Distance(position, ((GameActor)val).CenterPosition);
					if (num < nearestDistance)
					{
						nearestDistance = num;
						result = val;
					}
				}
			}
			return result;
		}

		private IEnumerator Attack()
		{
			//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
			return new _003CAttack_003Ed__5(0)
			{
				_003C_003E4__this = this
			};
		}

		public override float GetMaxRange()
		{
			return 20f;
		}

		public override float GetMinReadyRange()
		{
			return 15f;
		}

		public override bool IsReady()
		{
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0062: Unknown result type (might be due to invalid IL or missing references)
			//IL_0072: Unknown result type (might be due to invalid IL or missing references)
			AIActor aiActor = ((BehaviorBase)this).m_aiActor;
			bool flag;
			if ((Object)(object)aiActor == (Object)null)
			{
				flag = true;
			}
			else
			{
				SpeculativeRigidbody targetRigidbody = aiActor.TargetRigidbody;
				flag = !(((Object)(object)targetRigidbody != (Object)null) ? new Vector2?(targetRigidbody.UnitCenter) : ((Vector2?)null)).HasValue;
			}
			return !flag && Vector2.Distance(((BraveBehaviour)((BehaviorBase)this).m_aiActor).specRigidbody.UnitCenter, ((BehaviorBase)this).m_aiActor.TargetRigidbody.UnitCenter) <= ((AttackBehaviorBase)this).GetMinReadyRange();
		}

		public bool IsInRange(AIActor enemy)
		{
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			bool flag;
			if ((Object)(object)enemy == (Object)null)
			{
				flag = true;
			}
			else
			{
				SpeculativeRigidbody specRigidbody = ((BraveBehaviour)enemy).specRigidbody;
				flag = !(((Object)(object)specRigidbody != (Object)null) ? new Vector2?(specRigidbody.UnitCenter) : ((Vector2?)null)).HasValue;
			}
			return !flag && Vector2.Distance(((BraveBehaviour)((BehaviorBase)this).m_aiActor).specRigidbody.UnitCenter, ((BraveBehaviour)enemy).specRigidbody.UnitCenter) <= ((AttackBehaviorBase)this).GetMinReadyRange();
		}
	}

	public class ChromaGunDroneApproach : MovementBehaviorBase
	{
		private bool Stealthed = false;

		public ChromaGun.ColourType droneColour;

		public float PathInterval = 0.25f;

		public float DesiredDistance = 5f;

		private float repathTimer;

		private List<AIActor> roomEnemies = new List<AIActor>();

		private bool isInRange;

		private PlayerController Owner;

		public override void Init(GameObject gameObject, AIActor aiActor, AIShooter aiShooter)
		{
			((BehaviorBase)this).Init(gameObject, aiActor, aiShooter);
		}

		public override void Upkeep()
		{
			((MovementBehaviorBase)this).Upkeep();
			((BehaviorBase)this).DecrementTimer(ref repathTimer, false);
		}

		public override BehaviorResult Update()
		{
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_014f: Unknown result type (might be due to invalid IL or missing references)
			//IL_018d: Unknown result type (might be due to invalid IL or missing references)
			//IL_029a: Unknown result type (might be due to invalid IL or missing references)
			//IL_029b: Unknown result type (might be due to invalid IL or missing references)
			//IL_029f: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0224: Unknown result type (might be due to invalid IL or missing references)
			//IL_0254: Unknown result type (might be due to invalid IL or missing references)
			//IL_0295: Unknown result type (might be due to invalid IL or missing references)
			if ((Object)(object)Owner == (Object)null)
			{
				if (Object.op_Implicit((Object)(object)((BehaviorBase)this).m_aiActor) && Object.op_Implicit((Object)(object)((BehaviorBase)this).m_aiActor.CompanionOwner))
				{
					Owner = ((BehaviorBase)this).m_aiActor.CompanionOwner;
				}
				else
				{
					Owner = GameManager.Instance.BestActivePlayer;
				}
			}
			SpeculativeRigidbody overrideTarget = ((BehaviorBase)this).m_aiActor.OverrideTarget;
			if ((Object)(object)overrideTarget == (Object)null && !Stealthed)
			{
				((GameActor)((BehaviorBase)this).m_aiActor).PlayEffectOnActor(SharedVFX.BloodiedScarfPoofVFX, Vector3.zero, false, true, false);
				((BehaviorBase)this).m_aiActor.ToggleRenderers(false);
				((GameActor)((BehaviorBase)this).m_aiActor).ToggleShadowVisiblity(false);
				Stealthed = true;
			}
			else if ((Object)(object)overrideTarget != (Object)null && Stealthed)
			{
				((GameActor)((BehaviorBase)this).m_aiActor).PlayEffectOnActor(SharedVFX.BloodiedScarfPoofVFX, Vector3.zero, false, true, false);
				((BraveBehaviour)((BraveBehaviour)((BehaviorBase)this).m_aiActor).sprite).renderer.enabled = true;
				((BehaviorBase)this).m_aiActor.ToggleRenderers(true);
				((GameActor)((BehaviorBase)this).m_aiActor).ToggleShadowVisiblity(true);
				Stealthed = false;
			}
			if (repathTimer > 0f)
			{
				return (BehaviorResult)(!((Object)(object)overrideTarget == (Object)null));
			}
			if ((Object)(object)overrideTarget == (Object)null || (Object.op_Implicit((Object)(object)((BraveBehaviour)overrideTarget).healthHaver) && ((BraveBehaviour)overrideTarget).healthHaver.IsDead))
			{
				PickNewTarget();
				return (BehaviorResult)0;
			}
			if ((Object)(object)((Component)overrideTarget).GetComponent<ChromaGun.ChromaGunColoured>() == (Object)null || ((Component)overrideTarget).GetComponent<ChromaGun.ChromaGunColoured>().ColourType != droneColour)
			{
				overrideTarget = null;
				PickNewTarget();
				return (BehaviorResult)0;
			}
			isInRange = Vector2.Distance(((BraveBehaviour)((BehaviorBase)this).m_aiActor).specRigidbody.UnitCenter, overrideTarget.UnitCenter) <= DesiredDistance;
			if ((Object)(object)overrideTarget != (Object)null && !isInRange)
			{
				((BehaviorBase)this).m_aiActor.PathfindToPosition(overrideTarget.UnitCenter, (Vector2?)null, true, (CellValidator)null, (ExtraWeightingFunction)null, (CellTypes?)null, false);
				repathTimer = PathInterval;
				return (BehaviorResult)1;
			}
			if ((Object)(object)overrideTarget != (Object)null && repathTimer >= 0f)
			{
				((BehaviorBase)this).m_aiActor.ClearPath();
				repathTimer = -1f;
			}
			return (BehaviorResult)0;
		}

		private void PickNewTarget()
		{
			if (!((Object)(object)((BehaviorBase)this).m_aiActor != (Object)null))
			{
				return;
			}
			if ((Object)(object)Owner == (Object)null)
			{
				if (Object.op_Implicit((Object)(object)((BehaviorBase)this).m_aiActor) && Object.op_Implicit((Object)(object)((BehaviorBase)this).m_aiActor.CompanionOwner))
				{
					Owner = ((BehaviorBase)this).m_aiActor.CompanionOwner;
				}
				else
				{
					Owner = GameManager.Instance.BestActivePlayer;
				}
			}
			Owner.CurrentRoom.GetActiveEnemies((ActiveEnemyType)1, ref roomEnemies);
			for (int i = 0; i < roomEnemies.Count; i++)
			{
				AIActor val = roomEnemies[i];
				if (val.IsHarmlessEnemy || !val.IsNormalEnemy || ((BraveBehaviour)val).healthHaver.IsDead || (Object)(object)val == (Object)(object)((BehaviorBase)this).m_aiActor || val.EnemyGuid == "ba928393c8ed47819c2c5f593100a5bc")
				{
					roomEnemies.Remove(val);
				}
				if ((Object)(object)((Component)val).GetComponent<ChromaGun.ChromaGunColoured>() == (Object)null)
				{
					roomEnemies.Remove(val);
				}
				else if (((Component)val).GetComponent<ChromaGun.ChromaGunColoured>().ColourType != droneColour)
				{
					roomEnemies.Remove(val);
				}
			}
			if (roomEnemies.Count == 0)
			{
				((BehaviorBase)this).m_aiActor.OverrideTarget = null;
				return;
			}
			AIActor aiActor = ((BehaviorBase)this).m_aiActor;
			AIActor val2 = roomEnemies[Random.Range(0, roomEnemies.Count)];
			aiActor.OverrideTarget = (((Object)(object)val2 != (Object)null) ? ((BraveBehaviour)val2).specRigidbody : null);
		}
	}
}
