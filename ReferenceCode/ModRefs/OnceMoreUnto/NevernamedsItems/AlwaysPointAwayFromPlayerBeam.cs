using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class AlwaysPointAwayFromPlayerBeam : MonoBehaviour
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
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)m_beam != (Object)null)
		{
			Vector2 val = MathsAndLogicHelper.CalculateVectorBetween(((BraveBehaviour)m_owner).sprite.WorldCenter, ((BeamController)m_basicBeam).Origin);
			float num = Vector2Extensions.ToAngle(((Vector2)(ref val)).normalized);
			((BeamController)m_basicBeam).Direction = MathsAndLogicHelper.DegreeToVector2(num);
		}
	}
}
