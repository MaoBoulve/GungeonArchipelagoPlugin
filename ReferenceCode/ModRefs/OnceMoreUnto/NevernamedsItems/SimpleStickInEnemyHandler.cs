using System;
using UnityEngine;

namespace NevernamedsItems;

public class SimpleStickInEnemyHandler : BraveBehaviour
{
	public GameObject stickyToSpawn;

	private void Start()
	{
		Projectile projectile = ((BraveBehaviour)this).projectile;
		projectile.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(projectile.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(OnHit));
	}

	private void OnHit(Projectile self, SpeculativeRigidbody body, bool fatal)
	{
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		if (!Object.op_Implicit((Object)(object)body) || fatal || !Object.op_Implicit((Object)(object)((BraveBehaviour)body).gameActor) || !Object.op_Implicit((Object)(object)((BraveBehaviour)body).sprite) || !Object.op_Implicit((Object)(object)((Component)body).GetComponent<tk2dSprite>()))
		{
			return;
		}
		GameActor gameActor = ((BraveBehaviour)body).gameActor;
		GameObject val = SpawnManager.SpawnVFX(stickyToSpawn, ((BraveBehaviour)body).transform.position, Quaternion.identity, true);
		tk2dSprite component = val.GetComponent<tk2dSprite>();
		tk2dSprite component2 = ((Component)gameActor).gameObject.GetComponent<tk2dSprite>();
		if ((Object)(object)component != (Object)null && (Object)(object)component2 != (Object)null)
		{
			((tk2dBaseSprite)component2).AttachRenderer((tk2dBaseSprite)(object)component);
			((tk2dBaseSprite)component).HeightOffGround = 0.1f;
			((tk2dBaseSprite)component).IsPerpendicular = true;
			((tk2dBaseSprite)component).usesOverrideMaterial = true;
		}
		BuffVFXAnimator orAddComponent = GameObjectExtensions.GetOrAddComponent<BuffVFXAnimator>(val);
		if ((Object)(object)orAddComponent != (Object)null)
		{
			if (Object.op_Implicit((Object)(object)self) && self.LastVelocity != Vector2.zero)
			{
				orAddComponent.InitializePierce(((BraveBehaviour)body).gameActor, self.LastVelocity);
			}
			else
			{
				orAddComponent.Initialize(((BraveBehaviour)body).gameActor);
			}
		}
	}
}
