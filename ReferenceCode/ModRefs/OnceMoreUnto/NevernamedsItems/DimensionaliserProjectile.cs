using System;
using System.Collections.Generic;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class DimensionaliserProjectile : MonoBehaviour
{
	private Projectile self;

	public GameObject portalPrefab;

	private void Start()
	{
		self = ((Component)this).GetComponent<Projectile>();
		if (Object.op_Implicit((Object)(object)self))
		{
			self.OnDestruction += OnDeath;
		}
	}

	private void OnDeath(Projectile me)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = SpawnManager.SpawnProjectile(portalPrefab, Vector2.op_Implicit(((BraveBehaviour)self).specRigidbody.UnitCenter), Quaternion.identity, true);
		Projectile component = val.GetComponent<Projectile>();
		if (Object.op_Implicit((Object)(object)component))
		{
			CorrectForWalls(component);
			component.Owner = me.Owner;
			component.Shooter = me.Shooter;
			if (Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(me)))
			{
				ProjectileUtility.ProjectilePlayerOwner(me).DoPostProcessProjectile(component);
			}
		}
	}

	private void CorrectForWalls(Projectile portal)
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		if (!PhysicsEngine.Instance.OverlapCast(((BraveBehaviour)portal).specRigidbody, (List<CollisionData>)null, true, false, (int?)null, (int?)null, false, (Vector2?)null, (Func<SpeculativeRigidbody, bool>)null, (SpeculativeRigidbody[])(object)new SpeculativeRigidbody[0]))
		{
			return;
		}
		Vector2 val = Vector3Extensions.XY(((Component)this).transform.position);
		IntVector2[] cardinalsAndOrdinals = IntVector2.CardinalsAndOrdinals;
		int num = 0;
		int num2 = 1;
		do
		{
			for (int i = 0; i < cardinalsAndOrdinals.Length; i++)
			{
				((Component)this).transform.position = Vector2.op_Implicit(val + PhysicsEngine.PixelToUnit(cardinalsAndOrdinals[i] * num2));
				((BraveBehaviour)portal).specRigidbody.Reinitialize();
				if (!PhysicsEngine.Instance.OverlapCast(((BraveBehaviour)portal).specRigidbody, (List<CollisionData>)null, true, false, (int?)null, (int?)null, false, (Vector2?)null, (Func<SpeculativeRigidbody, bool>)null, (SpeculativeRigidbody[])(object)new SpeculativeRigidbody[0]))
				{
					return;
				}
			}
			num2++;
			num++;
		}
		while (num <= 200);
		Debug.LogError((object)"FREEZE AVERTED!  TELL RUBEL!  (you're welcome) 147");
	}
}
