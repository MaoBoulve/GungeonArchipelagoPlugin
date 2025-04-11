using UnityEngine;

namespace NevernamedsItems;

internal class BeamAutoAddMotionModule : BraveBehaviour
{
	public bool Helix;

	public bool invertHelix;

	public bool Orbit;

	public float beamOrbitRadius = 5f;

	private void Start()
	{
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected O, but got Unknown
		if (!Object.op_Implicit((Object)(object)((BraveBehaviour)this).projectile) || !((Object)(object)((Component)this).GetComponent<BasicBeamController>() != (Object)null))
		{
			return;
		}
		BasicBeamController component = ((Component)this).GetComponent<BasicBeamController>();
		if (Orbit)
		{
			component.PenetratesCover = true;
			component.penetration += 10;
			OrbitProjectileMotionModule val = new OrbitProjectileMotionModule();
			val.BeamOrbitRadius = beamOrbitRadius;
			val.RegisterAsBeam((BeamController)(object)component);
			if (Helix)
			{
				val.StackHelix = true;
				val.ForceInvert = invertHelix;
			}
			((BraveBehaviour)this).projectile.OverrideMotionModule = (ProjectileMotionModule)(object)val;
		}
		else if (Helix)
		{
			HelixProjectileMotionModule val2 = new HelixProjectileMotionModule();
			val2.ForceInvert = invertHelix;
			((BraveBehaviour)this).projectile.OverrideMotionModule = (ProjectileMotionModule)(object)val2;
		}
		_003F val3 = component;
		ProjectileMotionModule overrideMotionModule = ((BraveBehaviour)this).projectile.OverrideMotionModule;
		((BasicBeamController)val3).ProjectileAndBeamMotionModule = (ProjectileAndBeamMotionModule)(object)((overrideMotionModule is ProjectileAndBeamMotionModule) ? overrideMotionModule : null);
	}
}
