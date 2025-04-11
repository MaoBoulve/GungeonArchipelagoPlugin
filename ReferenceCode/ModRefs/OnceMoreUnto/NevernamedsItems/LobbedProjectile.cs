using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using InControl;
using UnityEngine;

namespace NevernamedsItems;

public class LobbedProjectile : Projectile
{
	[CompilerGenerated]
	private sealed class _003CHandleDestruction_003Ed__8 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public LobbedProjectile _003C_003E4__this;

		private SpawnProjModifier _003Cspawner_003E5__1;

		private GoopModifier _003Cgooper_003E5__2;

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
		public _003CHandleDestruction_003Ed__8(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003Cspawner_003E5__1 = null;
			_003Cgooper_003E5__2 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_014f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0154: Unknown result type (might be due to invalid IL or missing references)
			//IL_0169: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E4__this.canCollide = true;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				break;
			case 2:
				_003C_003E1__state = -1;
				break;
			}
			if (!_003C_003E4__this.ShouldBeDestroyed)
			{
				_003C_003E4__this.isLingering = true;
				_003C_003E4__this.OnFloorLinger();
				_003C_003E2__current = null;
				_003C_003E1__state = 2;
				return true;
			}
			_003C_003E4__this.isLingering = false;
			if (_003C_003E4__this.IsAffectedByBounce && (Object)(object)((Component)_003C_003E4__this).GetComponent<BounceProjModifier>() != (Object)null && ((Component)_003C_003E4__this).GetComponent<BounceProjModifier>().numberOfBounces > 0)
			{
				_003C_003E4__this.canCollide = false;
				BounceProjModifier component = ((Component)_003C_003E4__this).GetComponent<BounceProjModifier>();
				component.numberOfBounces--;
				_003C_003E4__this.isDestroying = false;
				_003Cspawner_003E5__1 = ((Component)_003C_003E4__this).GetComponent<SpawnProjModifier>();
				if (Object.op_Implicit((Object)(object)_003Cspawner_003E5__1) && _003C_003E4__this.spawnCollisionProjectilesOnFloorBounce)
				{
					_003Cspawner_003E5__1.SpawnCollisionProjectiles(Vector3Extensions.XY(((Projectile)_003C_003E4__this).m_transform.position), ((Vector2)(ref ((BraveBehaviour)_003C_003E4__this).specRigidbody.Velocity)).normalized, (SpeculativeRigidbody)null, false);
				}
				_003Cgooper_003E5__2 = ((Component)_003C_003E4__this).GetComponent<GoopModifier>();
				if (Object.op_Implicit((Object)(object)_003Cgooper_003E5__2) && _003C_003E4__this.spawnCollisionGoopOnFloorBounce)
				{
					DeadlyDeadlyGoopManager.GetGoopManagerForGoopType(_003Cgooper_003E5__2.goopDefinition).TimedAddGoopCircle(((Projectile)_003C_003E4__this).SafeCenter, _003Cgooper_003E5__2.CollisionSpawnRadius, 0.5f, false);
				}
				_003C_003E4__this.DoBounceReset();
				_003Cspawner_003E5__1 = null;
				_003Cgooper_003E5__2 = null;
			}
			else
			{
				((Projectile)_003C_003E4__this).DieInAir(false, true, true, false);
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

	public bool spawnCollisionProjectilesOnFloorBounce = false;

	public bool spawnCollisionGoopOnFloorBounce = false;

	public float forcedDistance = -1f;

	public float timeToLandWithNormalShotSpeed = 0.5f;

	public float visualHeight = 5f;

	public bool canHitAnythingEvenWhenNotGrounded;

	protected Vector3 lastSpritePosition;

	protected float destinationDist = -1f;

	protected bool isDestroying;

	protected float originalHeightOffGround;

	protected bool canCollide;

	protected float localDistanceElapsed;

	protected Vector3 localLastPosition;

	protected bool isLingering = false;

	public virtual bool IsAffectedByBounce => true;

	public virtual bool ShouldBeDestroyed => true;

	public static Vector2 GetRelativeAim(PlayerController player)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		BraveInput instanceForPlayer = BraveInput.GetInstanceForPlayer(player.PlayerIDX);
		Vector2 result = Vector2.zero;
		if ((Object)(object)instanceForPlayer != (Object)null)
		{
			if (instanceForPlayer.IsKeyboardAndMouse(false))
			{
				result = Vector3Extensions.XY(player.unadjustedAimPoint) - ((GameActor)player).CenterPosition;
			}
			else
			{
				if (instanceForPlayer.ActiveActions == null)
				{
					return result;
				}
				result = ((TwoAxisInputControl)instanceForPlayer.ActiveActions.Aim).Vector;
			}
		}
		return result;
	}

	public override void Start()
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		canCollide = false;
		base.pierceMinorBreakables = true;
		PierceProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<PierceProjModifier>(((Component)this).gameObject);
		orAddComponent.penetratesBreakables = true;
		orAddComponent.BeastModeLevel = (BeastModeStatus)1;
		orAddComponent.preventPenetrationOfActors = false;
		((Projectile)this).Start();
		((BraveBehaviour)((BraveBehaviour)this).sprite).transform.localRotation = ((BraveBehaviour)this).transform.rotation;
		((BraveBehaviour)this).transform.rotation = Quaternion.identity;
		originalHeightOffGround = ((BraveBehaviour)this).sprite.HeightOffGround;
		((Projectile)this).OnPostUpdate += HandleHeight;
		localLastPosition = ((BraveBehaviour)this).transform.position;
		base.baseData.range = 999999f;
		if (destinationDist < 0f)
		{
			if (forcedDistance > 0f)
			{
				destinationDist = forcedDistance;
			}
			else
			{
				GameActor owner = ((Projectile)this).Owner;
				SpeculativeRigidbody shooter = ((Projectile)this).Shooter;
				PlayerController val = (PlayerController)(object)((owner is PlayerController) ? owner : null);
				if (val != null && (Object)(object)((BraveBehaviour)owner).specRigidbody == (Object)(object)shooter)
				{
					SetPlayerDestination(val);
				}
				else if ((Object)(object)shooter != (Object)null && (Object)(object)((BraveBehaviour)shooter).aiActor != (Object)null && (Object)(object)((BraveBehaviour)shooter).aiActor.TargetRigidbody != (Object)null)
				{
					SetDestination(((BraveBehaviour)shooter).aiActor.TargetRigidbody.UnitCenter, null);
				}
				else
				{
					PlayerController val2 = (PlayerController)(object)((owner is PlayerController) ? owner : null);
					if (val2 != null)
					{
						SetPlayerDestination(val2);
					}
				}
			}
		}
		if (destinationDist < 0f)
		{
			destinationDist = 0.0625f;
		}
	}

	public void SetPlayerDestination(PlayerController play)
	{
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_021c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0201: Unknown result type (might be due to invalid IL or missing references)
		BraveInput instanceForPlayer = BraveInput.GetInstanceForPlayer(play.PlayerIDX);
		if (!((Object)(object)instanceForPlayer != (Object)null))
		{
			return;
		}
		if (instanceForPlayer.IsKeyboardAndMouse(false) && !LobbedProjectileMotion.CONTROLLER_LOB_DEBUG)
		{
			SetDestination(((GameActor)play).CenterPosition + GetRelativeAim(play), null);
			return;
		}
		PhysicsEngine instance = PhysicsEngine.Instance;
		Vector2 unitCenter = ((BraveBehaviour)this).specRigidbody.UnitCenter;
		Vector2 relativeAim = GetRelativeAim(play);
		RaycastResult val = default(RaycastResult);
		instance.Raycast(unitCenter, ((Vector2)(ref relativeAim)).normalized, 1000f, ref val, true, true, int.MaxValue, (CollisionLayer?)(CollisionLayer)4, false, (Func<SpeculativeRigidbody, bool>)((SpeculativeRigidbody x) => !((Object)(object)((BraveBehaviour)x).minorBreakable == (Object)null) || !((Object)(object)((BraveBehaviour)x).majorBreakable == (Object)null)), (SpeculativeRigidbody)null);
		if ((Object)(object)val.SpeculativeRigidbody == (Object)null)
		{
			RaycastResult.Pool.Free(ref val);
			PhysicsEngine instance2 = PhysicsEngine.Instance;
			Vector2 unitCenter2 = ((BraveBehaviour)this).specRigidbody.UnitCenter;
			relativeAim = GetRelativeAim(play);
			instance2.Raycast(unitCenter2, ((Vector2)(ref relativeAim)).normalized, 1000f, ref val, true, true, int.MaxValue, (CollisionLayer?)(CollisionLayer)4, false, (Func<SpeculativeRigidbody, bool>)((SpeculativeRigidbody x) => !((Object)(object)((BraveBehaviour)x).minorBreakable == (Object)null) || (!((Object)(object)((BraveBehaviour)x).majorBreakable == (Object)null) && (((BraveBehaviour)x).majorBreakable.m_isBroken || (!((Object)(object)((Component)x).GetComponent<FlippableCover>() == (Object)null) && ((Component)x).GetComponent<FlippableCover>().m_flipped)))), (SpeculativeRigidbody)null);
		}
		if ((Object)(object)val.SpeculativeRigidbody == (Object)null)
		{
			RaycastResult.Pool.Free(ref val);
			PhysicsEngine instance3 = PhysicsEngine.Instance;
			Vector2 unitCenter3 = ((BraveBehaviour)this).specRigidbody.UnitCenter;
			relativeAim = GetRelativeAim(play);
			instance3.Raycast(unitCenter3, ((Vector2)(ref relativeAim)).normalized, 1000f, ref val, true, true, int.MaxValue, (CollisionLayer?)(CollisionLayer)4, false, (Func<SpeculativeRigidbody, bool>)((SpeculativeRigidbody x) => (!((Object)(object)((BraveBehaviour)x).majorBreakable == (Object)null) && (((BraveBehaviour)x).majorBreakable.m_isBroken || (!((Object)(object)((Component)x).GetComponent<FlippableCover>() == (Object)null) && ((Component)x).GetComponent<FlippableCover>().m_flipped))) || (!((Object)(object)((BraveBehaviour)x).minorBreakable == (Object)null) && ((BraveBehaviour)x).minorBreakable.IsBroken)), (SpeculativeRigidbody)null);
		}
		if ((Object)(object)val.SpeculativeRigidbody != (Object)null)
		{
			SetDestination(val.SpeculativeRigidbody.UnitCenter + val.SpeculativeRigidbody.Velocity * base.baseData.speed * timeToLandWithNormalShotSpeed / 23f, null);
			return;
		}
		SetDestination(((CastResult)val).Contact, null);
		destinationDist = Mathf.Max(destinationDist - 0.25f, 0.0625f);
	}

	public void HandleHeight(Projectile proj)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0223: Unknown result type (might be due to invalid IL or missing references)
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0245: Unknown result type (might be due to invalid IL or missing references)
		//IL_024a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_0210: Unknown result type (might be due to invalid IL or missing references)
		//IL_0215: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		SpeculativeRigidbody specRigidbody = ((BraveBehaviour)proj).specRigidbody;
		specRigidbody.Velocity *= destinationDist / 23f / timeToLandWithNormalShotSpeed;
		if ((Object)(object)((BraveBehaviour)this).sprite != (Object)null)
		{
			float num = Mathf.Max(localDistanceElapsed / destinationDist * 4f * visualHeight * (1f - localDistanceElapsed / destinationDist), 0f);
			((BraveBehaviour)((BraveBehaviour)this).sprite).transform.localPosition = new Vector3(((BraveBehaviour)((BraveBehaviour)this).sprite).transform.localPosition.x, Mathf.Max(num, 0f));
			((BraveBehaviour)this).sprite.HeightOffGround = originalHeightOffGround + num;
			Quaternion rotation = ((BraveBehaviour)this).transform.rotation;
			if (((Quaternion)(ref rotation)).eulerAngles.z != 0f)
			{
				Quaternion rotation2 = ((BraveBehaviour)((BraveBehaviour)this).sprite).transform.rotation;
				rotation = ((BraveBehaviour)((BraveBehaviour)this).sprite).transform.rotation;
				float x = ((Quaternion)(ref rotation)).eulerAngles.x;
				rotation = ((BraveBehaviour)((BraveBehaviour)this).sprite).transform.rotation;
				float y = ((Quaternion)(ref rotation)).eulerAngles.y;
				rotation = ((BraveBehaviour)((BraveBehaviour)this).sprite).transform.rotation;
				float z = ((Quaternion)(ref rotation)).eulerAngles.z;
				rotation = ((BraveBehaviour)this).transform.rotation;
				((Quaternion)(ref rotation2)).eulerAngles = new Vector3(x, y, z + ((Quaternion)(ref rotation)).eulerAngles.z);
				((BraveBehaviour)((BraveBehaviour)this).sprite).transform.rotation = rotation2;
				((BraveBehaviour)this).transform.rotation = Quaternion.identity;
			}
			if (base.shouldRotate && base.angularVelocity == 0f)
			{
				((BraveBehaviour)((BraveBehaviour)this).sprite).transform.rotation = Quaternion.Euler(0f, 0f, Vector2Extensions.ToAngle(Vector3Extensions.XY(((BraveBehaviour)((BraveBehaviour)this).sprite).transform.position - lastSpritePosition)));
			}
			lastSpritePosition = ((BraveBehaviour)((BraveBehaviour)this).sprite).transform.position;
		}
		localDistanceElapsed += Vector3.Distance(localLastPosition, ((BraveBehaviour)this).transform.position);
		localLastPosition = ((BraveBehaviour)this).transform.position;
		if (localDistanceElapsed >= destinationDist && !isDestroying)
		{
			localDistanceElapsed = 0f;
			((MonoBehaviour)this).StartCoroutine(HandleDestruction());
			isDestroying = true;
		}
	}

	public override void OnPreCollision(SpeculativeRigidbody body, PixelCollider collider, SpeculativeRigidbody collision, PixelCollider collisionCollider)
	{
		if (!canHitAnythingEvenWhenNotGrounded && !canCollide && (Object)(object)((Component)collision).GetComponentInParent<DungeonDoorController>() == (Object)null && ((Object)(object)((Component)collision).GetComponent<MajorBreakable>() == (Object)null || !((Component)collision).GetComponent<MajorBreakable>().IsSecretDoor))
		{
			PhysicsEngine.SkipCollision = true;
		}
		else
		{
			((Projectile)this).OnPreCollision(body, collider, collision, collisionCollider);
		}
	}

	public void SetDestination(Vector2 destination, Vector2? overrideStart = null)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		float num = destinationDist;
		destinationDist = Mathf.Max(Vector2.Distance(Vector3Extensions.XY(((BraveBehaviour)this).transform.position), destination), 0.0625f);
		if (num >= 0f)
		{
			localDistanceElapsed *= destinationDist / num;
		}
	}

	public override void Move()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		if (base.angularVelocity != 0f)
		{
			((BraveBehaviour)((BraveBehaviour)this).sprite).transform.RotateAround(Vector2.op_Implicit(Vector3Extensions.XY(((BraveBehaviour)((BraveBehaviour)this).sprite).transform.position)), Vector3.forward, base.angularVelocity * ((Projectile)this).LocalDeltaTime);
		}
		float angularVelocity = base.angularVelocity;
		base.angularVelocity = 0f;
		((Projectile)this).Move();
		base.angularVelocity += angularVelocity;
	}

	public override void OnRigidbodyCollision(CollisionData rigidbodyCollision)
	{
		((Projectile)this).OnRigidbodyCollision(rigidbodyCollision);
		base.m_hasPierced = false;
	}

	protected IEnumerator HandleDestruction()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CHandleDestruction_003Ed__8(0)
		{
			_003C_003E4__this = this
		};
	}

	public virtual void DoBounceReset()
	{
	}

	public virtual void OnFloorLinger()
	{
	}
}
