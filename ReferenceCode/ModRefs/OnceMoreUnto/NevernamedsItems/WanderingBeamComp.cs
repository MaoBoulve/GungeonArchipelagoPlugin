using UnityEngine;

namespace NevernamedsItems;

public class WanderingBeamComp : MonoBehaviour
{
	private Projectile m_projectile;

	private BeamController m_beam;

	private BasicBeamController m_basicBeam;

	private PlayerController m_owner;

	private void Start()
	{
		m_projectile = ((Component)this).GetComponent<Projectile>();
		m_beam = ((Component)this).GetComponent<BeamController>();
		m_basicBeam = ((Component)this).GetComponent<BasicBeamController>();
		if (m_projectile.Owner is PlayerController)
		{
			ref PlayerController owner = ref m_owner;
			GameActor owner2 = m_projectile.Owner;
			owner = (PlayerController)(object)((owner2 is PlayerController) ? owner2 : null);
		}
	}

	private void FixedUpdate()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)m_beam != (Object)null)
		{
			((BeamController)m_basicBeam).Direction = Vector2Extensions.Rotate(((BeamController)m_basicBeam).Direction, 1f);
		}
	}
}
