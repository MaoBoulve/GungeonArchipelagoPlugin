using System;
using UnityEngine;

namespace NevernamedsItems;

public class SpecialSizeStatModification : MonoBehaviour
{
	private AIActor baseEnemy;

	private float cachedCollisionDamage;

	public bool canBeSteppedOn;

	public bool adjustsSpeed;

	public SpecialSizeStatModification()
	{
		adjustsSpeed = true;
	}

	private void Start()
	{
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected O, but got Unknown
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected O, but got Unknown
		baseEnemy = ((Component)this).GetComponent<AIActor>();
		if ((Object)(object)baseEnemy != (Object)null && Object.op_Implicit((Object)(object)((BraveBehaviour)baseEnemy).specRigidbody))
		{
			SpeculativeRigidbody specRigidbody = ((BraveBehaviour)baseEnemy).specRigidbody;
			specRigidbody.OnPreRigidbodyCollision = (OnPreRigidbodyCollisionDelegate)Delegate.Combine((Delegate)(object)specRigidbody.OnPreRigidbodyCollision, (Delegate)new OnPreRigidbodyCollisionDelegate(preCollide));
		}
	}

	private void preCollide(SpeculativeRigidbody myRigidbody, PixelCollider myCollider, SpeculativeRigidbody otherRigidbody, PixelCollider otherCollider)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)baseEnemy) && baseEnemy.EnemyScale.x < 0.55f && Object.op_Implicit((Object)(object)((Component)otherRigidbody).GetComponent<PlayerController>()))
		{
			baseEnemy.EraseFromExistenceWithRewards(false);
			GlobalSparksDoer.DoRandomParticleBurst(5, Vector2.op_Implicit(((BraveBehaviour)baseEnemy).specRigidbody.UnitBottomLeft), Vector2.op_Implicit(((BraveBehaviour)baseEnemy).specRigidbody.UnitTopRight), new Vector3(1f, 1f, 1f), 360f, 4f, (float?)null, (float?)null, (Color?)null, (SparksType)7);
		}
	}

	private void Update()
	{
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)baseEnemy))
		{
			if (adjustsSpeed && baseEnemy.MovementSpeed != baseEnemy.BaseMovementSpeed * (1f / baseEnemy.EnemyScale.x))
			{
				baseEnemy.MovementSpeed = baseEnemy.BaseMovementSpeed * (1f / baseEnemy.EnemyScale.x);
			}
			if (baseEnemy.EnemyScale.x < 0.55f && baseEnemy.CollisionDamage > 0f)
			{
				cachedCollisionDamage = baseEnemy.CollisionDamage;
				baseEnemy.CollisionDamage = 0f;
			}
			if (baseEnemy.EnemyScale.x > 0.55f && baseEnemy.CollisionDamage <= 0f && cachedCollisionDamage > 0f)
			{
				baseEnemy.CollisionDamage = cachedCollisionDamage;
			}
		}
	}
}
