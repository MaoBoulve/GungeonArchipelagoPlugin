using UnityEngine;

namespace NevernamedsItems;

public class AgarGunBigProj : MonoBehaviour
{
	private Projectile m_projectile;

	private void Start()
	{
		m_projectile = ((Component)this).GetComponent<Projectile>();
	}

	private void Update()
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		Vector2 val = Vector3Extensions.XY(((BraveBehaviour)m_projectile).transform.position);
		for (int i = 0; i < StaticReferenceManager.AllProjectiles.Count; i++)
		{
			Projectile val2 = StaticReferenceManager.AllProjectiles[i];
			if (Object.op_Implicit((Object)(object)val2) && (Object)(object)val2.Owner == (Object)(object)m_projectile.Owner && Object.op_Implicit((Object)(object)((Component)val2).GetComponent<AgarGunSmallProj>()))
			{
				Vector2 val3 = Vector3Extensions.XY(((BraveBehaviour)val2).transform.position) - val;
				float sqrMagnitude = ((Vector2)(ref val3)).sqrMagnitude;
				if (sqrMagnitude < 2f)
				{
					AbsorbBullet(val2);
				}
			}
		}
	}

	private void AbsorbBullet(Projectile target)
	{
		ProjectileData baseData = m_projectile.baseData;
		baseData.damage *= 1.1f;
		m_projectile.RuntimeUpdateScale(1.1f);
		target.DieInAir(false, true, true, false);
	}
}
