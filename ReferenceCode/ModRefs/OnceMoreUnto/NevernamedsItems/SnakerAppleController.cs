using UnityEngine;

namespace NevernamedsItems;

public class SnakerAppleController : MonoBehaviour
{
	private float timer;

	private Projectile m_projectile;

	private PlayerController Owner;

	public SnakerAppleController()
	{
		timer = 40f;
	}

	private void Start()
	{
		m_projectile = ((Component)this).GetComponent<Projectile>();
		if (Object.op_Implicit((Object)(object)m_projectile) && Object.op_Implicit((Object)(object)m_projectile.Owner) && m_projectile.Owner is PlayerController)
		{
			ref PlayerController owner = ref Owner;
			GameActor owner2 = m_projectile.Owner;
			owner = (PlayerController)(object)((owner2 is PlayerController) ? owner2 : null);
		}
	}

	private void Update()
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		if (!Object.op_Implicit((Object)(object)Owner) || Owner.CurrentRoom != Vector3Extensions.GetAbsoluteRoom(((BraveBehaviour)m_projectile).transform.position))
		{
			m_projectile.DieInAir(true, false, false, false);
		}
		if (timer > 0f)
		{
			timer -= BraveTime.DeltaTime;
		}
		if (timer <= 0f)
		{
			m_projectile.DieInAir(true, false, false, false);
		}
	}
}
