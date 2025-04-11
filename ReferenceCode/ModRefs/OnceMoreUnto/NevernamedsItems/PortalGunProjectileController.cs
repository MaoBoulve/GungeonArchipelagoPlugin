using UnityEngine;

namespace NevernamedsItems;

public class PortalGunProjectileController : MonoBehaviour
{
	private GameObject portalPrefab;

	private Projectile m_projectile;

	private SpeculativeRigidbody m_rigidBoy;

	private void Start()
	{
		m_projectile = ((Component)this).GetComponent<Projectile>();
		m_rigidBoy = ((Component)this).GetComponent<SpeculativeRigidbody>();
		m_projectile.OnDestruction += Collision;
	}

	private void Collision(Projectile self)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = SpawnManager.SpawnProjectile(portalPrefab, Vector2.op_Implicit(((BraveBehaviour)self).specRigidbody.UnitCenter), Quaternion.identity, true);
		Projectile component = val.GetComponent<Projectile>();
	}
}
