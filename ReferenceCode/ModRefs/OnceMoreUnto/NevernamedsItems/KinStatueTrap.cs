using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class KinStatueTrap : BasicTrapController
{
	public GameObject shootPoint;

	public GameObject trapShot;

	public GameObject vfx;

	public Vector3 vfxOffset;

	public KinStatueTrap()
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		base.triggerMethod = (TriggerMethod)2;
	}

	public override void Start()
	{
		shootPoint = ((Component)((Component)this).gameObject.transform.Find("shootPoint")).gameObject;
		((BasicTrapController)this).Start();
	}

	public override void TriggerTrap(SpeculativeRigidbody target)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		((BasicTrapController)this).TriggerTrap(target);
		PlayerController activePlayerClosestToPoint = GameManager.Instance.GetActivePlayerClosestToPoint(Vector3Extensions.XY(shootPoint.transform.position), false);
		if (Object.op_Implicit((Object)(object)activePlayerClosestToPoint) && Object.op_Implicit((Object)(object)((BraveBehaviour)activePlayerClosestToPoint).specRigidbody) && activePlayerClosestToPoint.CurrentRoom == base.m_parentRoom)
		{
			Vector2 direction = MathsAndLogicHelper.CalculateVectorBetween(shootPoint.transform.position, Vector2.op_Implicit(((BraveBehaviour)activePlayerClosestToPoint).specRigidbody.UnitCenter));
			ShootProjectileInDirection(shootPoint.transform.position, direction);
		}
	}

	private void ShootProjectileInDirection(Vector3 spawnPosition, Vector2 direction)
	{
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)vfx != (Object)null)
		{
			SpawnManager.SpawnVFX(vfx, ((Component)this).gameObject.transform.position + vfxOffset, Quaternion.identity);
		}
		AkSoundEngine.PostEvent("Play_TRP_bullet_shot_01", ((Component)this).gameObject);
		float num = Mathf.Atan2(direction.y, direction.x) * 57.29578f;
		GameObject val = SpawnManager.SpawnProjectile(trapShot, spawnPosition, Quaternion.Euler(0f, 0f, num), true);
		SpeculativeRigidbody component = val.GetComponent<SpeculativeRigidbody>();
		if (Object.op_Implicit((Object)(object)component))
		{
			component.RegisterGhostCollisionException(((BraveBehaviour)this).specRigidbody);
		}
		Projectile component2 = val.GetComponent<Projectile>();
		component2.Shooter = ((BraveBehaviour)this).specRigidbody;
		component2.OwnerName = StringTableManager.GetEnemiesString("#TRAP", -1);
	}
}
