using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class RandomRoomPosBehaviour : MonoBehaviour
{
	private Projectile m_projectile;

	private void Start()
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		m_projectile = ((Component)this).GetComponent<Projectile>();
		if (ProjectileUtility.GetAbsoluteRoom(m_projectile) != null)
		{
			IntVector2 randomVisibleClearSpot = ProjectileUtility.GetAbsoluteRoom(m_projectile).GetRandomVisibleClearSpot(3, 3);
			((BraveBehaviour)m_projectile).transform.position = ((IntVector2)(ref randomVisibleClearSpot)).ToVector3();
			((BraveBehaviour)m_projectile).specRigidbody.Reinitialize();
		}
	}
}
