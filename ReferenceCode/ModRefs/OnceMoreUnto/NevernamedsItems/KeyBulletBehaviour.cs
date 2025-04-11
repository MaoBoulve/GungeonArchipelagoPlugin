using System;
using UnityEngine;

namespace NevernamedsItems;

public class KeyBulletBehaviour : MonoBehaviour
{
	private Projectile m_projectile;

	public Color tintColour;

	public bool useSpecialTint;

	public float procChance;

	public KeyBulletBehaviour()
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		tintColour = Color.grey;
		useSpecialTint = true;
		procChance = 1f;
	}

	private void Start()
	{
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got Unknown
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		m_projectile = ((Component)this).GetComponent<Projectile>();
		if (useSpecialTint)
		{
			m_projectile.AdjustPlayerProjectileTint(tintColour, 2, 0f);
		}
		SpeculativeRigidbody specRigidbody = ((BraveBehaviour)m_projectile).specRigidbody;
		specRigidbody.OnRigidbodyCollision = (OnRigidbodyCollisionDelegate)Delegate.Combine((Delegate)(object)specRigidbody.OnRigidbodyCollision, (Delegate)new OnRigidbodyCollisionDelegate(OnHitChest));
	}

	private void OnHitChest(CollisionData rigidbodyCollision)
	{
		SpeculativeRigidbody otherRigidbody = rigidbodyCollision.OtherRigidbody;
		Chest component = ((Component)otherRigidbody).GetComponent<Chest>();
		if ((Object)(object)component != (Object)null && Random.value <= procChance && !component.IsTruthChest)
		{
			component.ForceUnlock();
		}
	}
}
