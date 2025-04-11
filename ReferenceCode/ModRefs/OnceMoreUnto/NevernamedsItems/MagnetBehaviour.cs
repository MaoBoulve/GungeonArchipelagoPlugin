using UnityEngine;

namespace NevernamedsItems;

internal class MagnetBehaviour : MonoBehaviour
{
	public float radius;

	public float gravitationalForce;

	public float radiusSquared;

	public bool debugMode;

	public float statMult;

	private SpeculativeRigidbody baseBody;

	public MagnetBehaviour()
	{
		radius = 15f;
		gravitationalForce = 50f;
		debugMode = false;
	}

	private void Start()
	{
		radiusSquared = radius * radius;
		baseBody = ((Component)this).GetComponent<SpeculativeRigidbody>();
		PhysicsEngine.Instance.OnPreRigidbodyMovement += PreRigidMovement;
		((Component)this).GetComponent<Projectile>().OnDestruction += Destruction;
	}

	private void Destruction(Projectile proj)
	{
		((Component)this).GetComponent<Projectile>().OnDestruction -= Destruction;
		PhysicsEngine.Instance.OnPreRigidbodyMovement -= PreRigidMovement;
	}

	private void OnDestroy()
	{
		((Component)this).GetComponent<Projectile>().OnDestruction -= Destruction;
		PhysicsEngine.Instance.OnPreRigidbodyMovement -= PreRigidMovement;
	}

	private Vector2 GetFrameAccelerationForRigidbody(Vector2 unitCenter, float currentDistance, float g)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		Vector2 zero = Vector2.zero;
		float num = Mathf.Clamp01(1f - currentDistance / radius);
		float num2 = g * num * num;
		Vector2 val = baseBody.UnitCenter - unitCenter;
		Vector2 normalized = ((Vector2)(ref val)).normalized;
		return normalized * num2;
	}

	private bool AdjustDebrisVelocity(DebrisObject debris)
	{
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		if (debris.IsPickupObject)
		{
			return false;
		}
		if ((Object)(object)((Component)debris).GetComponent<BlackHoleDoer>() != (Object)null || (Object)(object)((Component)debris).GetComponent<MagnetBehaviour>() != (Object)null)
		{
			return false;
		}
		Vector2 val = ((BraveBehaviour)debris).sprite.WorldCenter - baseBody.UnitCenter;
		float num = Vector2.SqrMagnitude(val);
		if (num >= radiusSquared)
		{
			return false;
		}
		float g = gravitationalForce / 5f * statMult;
		float num2 = Mathf.Sqrt(num);
		Vector2 frameAccelerationForRigidbody = GetFrameAccelerationForRigidbody(((BraveBehaviour)debris).sprite.WorldCenter, num2, g);
		float num3 = Mathf.Clamp(BraveTime.DeltaTime, 0f, 0.02f);
		if (debris.HasBeenTriggered)
		{
			debris.ApplyVelocity(frameAccelerationForRigidbody * num3);
		}
		else if (num2 < radius / 2f)
		{
			debris.Trigger(Vector2.op_Implicit(frameAccelerationForRigidbody * num3), 0.5f, 1f);
		}
		return true;
	}

	private bool AdjustRigidbodyVelocity(SpeculativeRigidbody other)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0214: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0230: Unknown result type (might be due to invalid IL or missing references)
		//IL_0235: Unknown result type (might be due to invalid IL or missing references)
		//IL_0237: Unknown result type (might be due to invalid IL or missing references)
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		//IL_0260: Unknown result type (might be due to invalid IL or missing references)
		//IL_0265: Unknown result type (might be due to invalid IL or missing references)
		//IL_0291: Unknown result type (might be due to invalid IL or missing references)
		//IL_0293: Unknown result type (might be due to invalid IL or missing references)
		Vector2 val = other.UnitCenter - baseBody.UnitCenter;
		float num = Vector2.SqrMagnitude(val);
		if (num < radiusSquared)
		{
			Vector2 velocity = other.Velocity;
			if (debugMode)
			{
				ETGModConsole.Log((object)"---------------------", false);
			}
			if (debugMode)
			{
				ETGModConsole.Log((object)("Checking Rigidbody: " + ((Object)other).name), false);
			}
			if (Object.op_Implicit((Object)(object)((BraveBehaviour)other).projectile) || !Object.op_Implicit((Object)(object)((BraveBehaviour)other).aiActor) || !((Behaviour)((BraveBehaviour)other).aiActor).enabled || !((BraveBehaviour)other).aiActor.HasBeenEngaged || (Object.op_Implicit((Object)(object)((BraveBehaviour)other).healthHaver) && ((BraveBehaviour)other).healthHaver.IsBoss))
			{
				if (debugMode)
				{
					ETGModConsole.Log((object)"Rigidbody was invalid", false);
					ETGModConsole.Log((object)$"Projectile: {(Object)(object)((BraveBehaviour)other).projectile != (Object)null}", false);
					ETGModConsole.Log((object)$"AiActor: {(Object)(object)((BraveBehaviour)other).aiActor != (Object)null}", false);
					if (Object.op_Implicit((Object)(object)((BraveBehaviour)other).aiActor))
					{
						ETGModConsole.Log((object)$"AiActor Enabled: {((Behaviour)((BraveBehaviour)other).aiActor).enabled}", false);
					}
					if (Object.op_Implicit((Object)(object)((BraveBehaviour)other).aiActor))
					{
						ETGModConsole.Log((object)$"AiActor Engaged: {((BraveBehaviour)other).aiActor.HasBeenEngaged}", false);
					}
					ETGModConsole.Log((object)$"IsBoss: {Object.op_Implicit((Object)(object)((BraveBehaviour)other).healthHaver) && ((BraveBehaviour)other).healthHaver.IsBoss}", false);
				}
				return false;
			}
			if (debugMode)
			{
				ETGModConsole.Log((object)$"Rigidbody was valid. Velocity: {((Vector2)(ref velocity)).magnitude}", false);
			}
			Vector2 frameAccelerationForRigidbody = GetFrameAccelerationForRigidbody(other.UnitCenter, Mathf.Sqrt(num), gravitationalForce * statMult);
			float num2 = Mathf.Clamp(BraveTime.DeltaTime, 0f, 0.02f);
			Vector2 val2 = frameAccelerationForRigidbody * num2;
			Vector2 val3 = velocity + val2;
			if (BraveTime.DeltaTime > 0.02f)
			{
				val3 *= 0.02f / BraveTime.DeltaTime;
			}
			if (debugMode)
			{
				ETGModConsole.Log((object)$"Target velocity vector: {((Vector2)(ref val3)).magnitude}", false);
			}
			other.Velocity = val3;
			return true;
		}
		return false;
	}

	private void PreRigidMovement()
	{
		if (!((Behaviour)this).enabled || !((Component)this).gameObject.activeSelf)
		{
			return;
		}
		for (int i = 0; i < PhysicsEngine.Instance.AllRigidbodies.Count; i++)
		{
			if (((Component)PhysicsEngine.Instance.AllRigidbodies[i]).gameObject.activeSelf && ((Behaviour)PhysicsEngine.Instance.AllRigidbodies[i]).enabled)
			{
				AdjustRigidbodyVelocity(PhysicsEngine.Instance.AllRigidbodies[i]);
			}
		}
		for (int j = 0; j < StaticReferenceManager.AllDebris.Count; j++)
		{
			AdjustDebrisVelocity(StaticReferenceManager.AllDebris[j]);
		}
	}
}
