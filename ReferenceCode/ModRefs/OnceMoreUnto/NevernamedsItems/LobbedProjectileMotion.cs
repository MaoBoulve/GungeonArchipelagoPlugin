using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace NevernamedsItems;

public class LobbedProjectileMotion : BraveBehaviour
{
	[CompilerGenerated]
	private sealed class _003CHandleDestruction_003Ed__7 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public LobbedProjectileMotion _003C_003E4__this;

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
		public _003CHandleDestruction_003Ed__7(int _003C_003E1__state)
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
				if ((Object)(object)((Component)_003C_003E4__this).GetComponent<BounceProjModifier>() != (Object)null && ((Component)_003C_003E4__this).GetComponent<BounceProjModifier>().numberOfBounces > 0)
				{
					_003C_003E4__this.canCollide = false;
					BounceProjModifier component = ((Component)_003C_003E4__this).GetComponent<BounceProjModifier>();
					component.numberOfBounces--;
					_003C_003E4__this.isDestroying = false;
				}
				else
				{
					((BraveBehaviour)_003C_003E4__this).projectile.DieInAir(false, true, true, false);
				}
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

	public static bool CONTROLLER_LOB_DEBUG;

	public float forcedDistance = -1f;

	public float timeToLandWithNormalShotSpeed = 0.5f;

	public float visualHeight = 5f;

	public bool canHitAnythingEvenWhenNotGrounded;

	private Vector3 lastSpritePosition;

	private float destinationDist = -1f;

	private bool isDestroying;

	private float originalHeightOffGround;

	private bool canCollide;

	private float localDistanceElapsed;

	private Vector3 localLastPosition;

	public void Start()
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Expected O, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0212: Unknown result type (might be due to invalid IL or missing references)
		canCollide = false;
		((BraveBehaviour)this).projectile.pierceMinorBreakables = true;
		PierceProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<PierceProjModifier>(((Component)this).gameObject);
		orAddComponent.penetratesBreakables = true;
		orAddComponent.BeastModeLevel = (BeastModeStatus)1;
		orAddComponent.preventPenetrationOfActors = false;
		((BraveBehaviour)this).transform.rotation = Quaternion.identity;
		if ((Object)(object)((BraveBehaviour)((BraveBehaviour)this).projectile).sprite != (Object)null)
		{
			((BraveBehaviour)((BraveBehaviour)((BraveBehaviour)this).projectile).sprite).transform.localRotation = ((BraveBehaviour)this).transform.rotation;
			lastSpritePosition = ((BraveBehaviour)((BraveBehaviour)((BraveBehaviour)this).projectile).sprite).transform.position;
			originalHeightOffGround = ((BraveBehaviour)((BraveBehaviour)this).projectile).sprite.HeightOffGround;
		}
		SpeculativeRigidbody specRigidbody = ((BraveBehaviour)this).specRigidbody;
		specRigidbody.OnPreRigidbodyCollision = (OnPreRigidbodyCollisionDelegate)Delegate.Combine((Delegate)(object)specRigidbody.OnPreRigidbodyCollision, (Delegate)new OnPreRigidbodyCollisionDelegate(OnPreCollision));
		SpeculativeRigidbody specRigidbody2 = ((BraveBehaviour)this).specRigidbody;
		specRigidbody2.OnRigidbodyCollision = (OnRigidbodyCollisionDelegate)Delegate.Combine((Delegate)(object)specRigidbody2.OnRigidbodyCollision, (Delegate)new OnRigidbodyCollisionDelegate(OnRigidbodyCollision));
		((BraveBehaviour)this).projectile.OnPostUpdate += HandleHeight;
		((BraveBehaviour)this).projectile.angularVelocity = 0f;
		localLastPosition = ((BraveBehaviour)this).transform.position;
		((BraveBehaviour)this).projectile.baseData.range = 999999f;
		if (destinationDist < 0f)
		{
			if (forcedDistance > 0f)
			{
				destinationDist = forcedDistance;
			}
			else
			{
				GameActor owner = ((BraveBehaviour)this).projectile.Owner;
				SpeculativeRigidbody shooter = ((BraveBehaviour)this).projectile.Shooter;
				PlayerController val = (PlayerController)(object)((owner is PlayerController) ? owner : null);
				if (val != null && (Object)(object)((BraveBehaviour)owner).specRigidbody == (Object)(object)shooter)
				{
					SetPlayerDestination(val);
				}
				else if ((Object)(object)shooter != (Object)null && (Object)(object)((BraveBehaviour)shooter).aiActor != (Object)null && (Object)(object)((BraveBehaviour)shooter).aiActor.TargetRigidbody != (Object)null)
				{
					SetDestination(((BraveBehaviour)shooter).aiActor.TargetRigidbody.UnitCenter);
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
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_0209: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		BraveInput instanceForPlayer = BraveInput.GetInstanceForPlayer(play.PlayerIDX);
		if (!((Object)(object)instanceForPlayer != (Object)null))
		{
			return;
		}
		if (instanceForPlayer.IsKeyboardAndMouse(false) && !CONTROLLER_LOB_DEBUG)
		{
			SetDestination(((GameActor)play).CenterPosition + LobbedProjectile.GetRelativeAim(play));
			return;
		}
		PhysicsEngine instance = PhysicsEngine.Instance;
		Vector2 unitCenter = ((BraveBehaviour)this).specRigidbody.UnitCenter;
		Vector2 relativeAim = LobbedProjectile.GetRelativeAim(play);
		RaycastResult val = default(RaycastResult);
		instance.Raycast(unitCenter, ((Vector2)(ref relativeAim)).normalized, 1000f, ref val, true, true, int.MaxValue, (CollisionLayer?)(CollisionLayer)4, false, (Func<SpeculativeRigidbody, bool>)((SpeculativeRigidbody x) => !((Object)(object)((BraveBehaviour)x).minorBreakable == (Object)null) || !((Object)(object)((BraveBehaviour)x).majorBreakable == (Object)null)), (SpeculativeRigidbody)null);
		if ((Object)(object)val.SpeculativeRigidbody == (Object)null)
		{
			RaycastResult.Pool.Free(ref val);
			PhysicsEngine instance2 = PhysicsEngine.Instance;
			Vector2 unitCenter2 = ((BraveBehaviour)this).specRigidbody.UnitCenter;
			relativeAim = LobbedProjectile.GetRelativeAim(play);
			instance2.Raycast(unitCenter2, ((Vector2)(ref relativeAim)).normalized, 1000f, ref val, true, true, int.MaxValue, (CollisionLayer?)(CollisionLayer)4, false, (Func<SpeculativeRigidbody, bool>)((SpeculativeRigidbody x) => !((Object)(object)((BraveBehaviour)x).minorBreakable == (Object)null) || (!((Object)(object)((BraveBehaviour)x).majorBreakable == (Object)null) && (((BraveBehaviour)x).majorBreakable.m_isBroken || (!((Object)(object)((Component)x).GetComponent<FlippableCover>() == (Object)null) && ((Component)x).GetComponent<FlippableCover>().m_flipped)))), (SpeculativeRigidbody)null);
		}
		if ((Object)(object)val.SpeculativeRigidbody == (Object)null)
		{
			RaycastResult.Pool.Free(ref val);
			PhysicsEngine instance3 = PhysicsEngine.Instance;
			Vector2 unitCenter3 = ((BraveBehaviour)this).specRigidbody.UnitCenter;
			relativeAim = LobbedProjectile.GetRelativeAim(play);
			instance3.Raycast(unitCenter3, ((Vector2)(ref relativeAim)).normalized, 1000f, ref val, true, true, int.MaxValue, (CollisionLayer?)(CollisionLayer)4, false, (Func<SpeculativeRigidbody, bool>)((SpeculativeRigidbody x) => (!((Object)(object)((BraveBehaviour)x).majorBreakable == (Object)null) && (((BraveBehaviour)x).majorBreakable.m_isBroken || (!((Object)(object)((Component)x).GetComponent<FlippableCover>() == (Object)null) && ((Component)x).GetComponent<FlippableCover>().m_flipped))) || (!((Object)(object)((BraveBehaviour)x).minorBreakable == (Object)null) && ((BraveBehaviour)x).minorBreakable.IsBroken)), (SpeculativeRigidbody)null);
		}
		if ((Object)(object)val.SpeculativeRigidbody != (Object)null)
		{
			SetDestination(val.SpeculativeRigidbody.UnitCenter + val.SpeculativeRigidbody.Velocity * ((BraveBehaviour)this).projectile.baseData.speed * timeToLandWithNormalShotSpeed / 23f);
			return;
		}
		SetDestination(((CastResult)val).Contact);
		destinationDist = Mathf.Max(destinationDist - 0.25f, 0.0625f);
	}

	public void HandleHeight(Projectile proj)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Unknown result type (might be due to invalid IL or missing references)
		//IL_0274: Unknown result type (might be due to invalid IL or missing references)
		//IL_028b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0290: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0256: Unknown result type (might be due to invalid IL or missing references)
		//IL_025b: Unknown result type (might be due to invalid IL or missing references)
		//IL_021f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0225: Unknown result type (might be due to invalid IL or missing references)
		//IL_022a: Unknown result type (might be due to invalid IL or missing references)
		//IL_022f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0239: Unknown result type (might be due to invalid IL or missing references)
		SpeculativeRigidbody specRigidbody = ((BraveBehaviour)proj).specRigidbody;
		specRigidbody.Velocity *= destinationDist / 23f / timeToLandWithNormalShotSpeed;
		if ((Object)(object)((BraveBehaviour)((BraveBehaviour)this).projectile).sprite != (Object)null)
		{
			float num = Mathf.Max(localDistanceElapsed / destinationDist * 4f * visualHeight * (1f - localDistanceElapsed / destinationDist), 0f);
			((BraveBehaviour)((BraveBehaviour)((BraveBehaviour)this).projectile).sprite).transform.localPosition = new Vector3(((BraveBehaviour)((BraveBehaviour)((BraveBehaviour)this).projectile).sprite).transform.localPosition.x, Mathf.Max(num, 0f));
			((BraveBehaviour)((BraveBehaviour)this).projectile).sprite.HeightOffGround = originalHeightOffGround + num;
			Quaternion rotation = ((BraveBehaviour)this).transform.rotation;
			if (((Quaternion)(ref rotation)).eulerAngles.z != 0f)
			{
				Quaternion rotation2 = ((BraveBehaviour)((BraveBehaviour)((BraveBehaviour)this).projectile).sprite).transform.rotation;
				rotation = ((BraveBehaviour)((BraveBehaviour)((BraveBehaviour)this).projectile).sprite).transform.rotation;
				float x = ((Quaternion)(ref rotation)).eulerAngles.x;
				rotation = ((BraveBehaviour)((BraveBehaviour)((BraveBehaviour)this).projectile).sprite).transform.rotation;
				float y = ((Quaternion)(ref rotation)).eulerAngles.y;
				rotation = ((BraveBehaviour)((BraveBehaviour)((BraveBehaviour)this).projectile).sprite).transform.rotation;
				float z = ((Quaternion)(ref rotation)).eulerAngles.z;
				rotation = ((BraveBehaviour)this).transform.rotation;
				((Quaternion)(ref rotation2)).eulerAngles = new Vector3(x, y, z + ((Quaternion)(ref rotation)).eulerAngles.z);
				((BraveBehaviour)((BraveBehaviour)((BraveBehaviour)this).projectile).sprite).transform.rotation = rotation2;
				((BraveBehaviour)this).transform.rotation = Quaternion.identity;
			}
			if (((BraveBehaviour)this).projectile.shouldRotate && ((BraveBehaviour)this).projectile.angularVelocity == 0f)
			{
				((BraveBehaviour)((BraveBehaviour)((BraveBehaviour)this).projectile).sprite).transform.rotation = Quaternion.Euler(0f, 0f, Vector2Extensions.ToAngle(Vector3Extensions.XY(((BraveBehaviour)((BraveBehaviour)((BraveBehaviour)this).projectile).sprite).transform.position - lastSpritePosition)));
			}
			lastSpritePosition = ((BraveBehaviour)((BraveBehaviour)((BraveBehaviour)this).projectile).sprite).transform.position;
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

	public void OnPreCollision(SpeculativeRigidbody body, PixelCollider collider, SpeculativeRigidbody collision, PixelCollider collisionCollider)
	{
		if (!canHitAnythingEvenWhenNotGrounded && !canCollide && (Object)(object)((Component)collision).GetComponentInParent<DungeonDoorController>() == (Object)null && ((Object)(object)((Component)collision).GetComponent<MajorBreakable>() == (Object)null || !((Component)collision).GetComponent<MajorBreakable>().IsSecretDoor))
		{
			PhysicsEngine.SkipCollision = true;
		}
	}

	public void SetDestination(Vector2 destination)
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

	public void OnRigidbodyCollision(CollisionData rigidbodyCollision)
	{
		((BraveBehaviour)this).projectile.m_hasPierced = false;
	}

	protected IEnumerator HandleDestruction()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CHandleDestruction_003Ed__7(0)
		{
			_003C_003E4__this = this
		};
	}
}
