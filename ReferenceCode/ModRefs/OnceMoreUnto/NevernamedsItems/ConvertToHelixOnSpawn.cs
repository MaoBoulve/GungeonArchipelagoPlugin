using UnityEngine;

namespace NevernamedsItems;

public class ConvertToHelixOnSpawn : MonoBehaviour
{
	private Projectile m_projectile;

	private void Start()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		m_projectile = ((Component)this).GetComponent<Projectile>();
		m_projectile.OverrideMotionModule = (ProjectileMotionModule)new HelixProjectileMotionModule
		{
			ForceInvert = (Random.value <= 0.5f)
		};
		ProjectileMotionModule overrideMotionModule = m_projectile.OverrideMotionModule;
		HelixProjectileMotionModule val = (HelixProjectileMotionModule)(object)((overrideMotionModule is HelixProjectileMotionModule) ? overrideMotionModule : null);
		val.helixAmplitude *= 0.5f;
	}
}
