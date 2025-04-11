using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class BlankProjModifier : MonoBehaviour
{
	private Projectile m_projectile;

	public EasyBlankType blankType;

	public BlankProjModifier()
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		blankType = (EasyBlankType)1;
	}

	private void Awake()
	{
		m_projectile = ((Component)this).GetComponent<Projectile>();
		m_projectile.OnDestruction += HandleBlankOnDestruction;
	}

	private void HandleBlankOnDestruction(Projectile obj)
	{
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)m_projectile) && Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(m_projectile)))
		{
			PlayerUtility.DoEasyBlank(ProjectileUtility.ProjectilePlayerOwner(m_projectile), (!Object.op_Implicit((Object)(object)((BraveBehaviour)obj).specRigidbody)) ? Vector3Extensions.XY(((BraveBehaviour)obj).transform.position) : ((BraveBehaviour)obj).specRigidbody.UnitCenter, (EasyBlankType)1);
		}
	}
}
