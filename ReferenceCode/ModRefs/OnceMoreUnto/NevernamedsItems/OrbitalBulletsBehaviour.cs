using System;
using UnityEngine;

namespace NevernamedsItems;

public class OrbitalBulletsBehaviour : MonoBehaviour
{
	private Projectile m_projectile;

	public bool orbitersCollideWithTilemap;

	public bool resetTravelledDistanceOnOrbit;

	public bool alterProjRangeOnOrbit;

	public float targetRange;

	public bool baseProjectileRangePrioritisedIfLarger;

	public bool resetSpeedIfOverCappedValueOnOrbit;

	public float speedCap;

	public float speedResetValue;

	public int cappedOrbiters;

	public float orbitalLifespan;

	public int orbitalGroup;

	public float minOrbitalRadius;

	public float maxOrbitalRadius;

	public bool usesOverrideCenter;

	public SpeculativeRigidbody overrideCenter;

	public OrbitalBulletsBehaviour()
	{
		orbitalLifespan = 15f;
		cappedOrbiters = 20;
		orbitersCollideWithTilemap = false;
		orbitalGroup = -1;
		resetTravelledDistanceOnOrbit = true;
		alterProjRangeOnOrbit = true;
		baseProjectileRangePrioritisedIfLarger = true;
		resetSpeedIfOverCappedValueOnOrbit = true;
		speedCap = 50f;
		speedResetValue = 20f;
		targetRange = 500f;
		minOrbitalRadius = 2f;
		maxOrbitalRadius = 5f;
		usesOverrideCenter = false;
		overrideCenter = null;
	}

	public void Start()
	{
		try
		{
			m_projectile = ((Component)this).GetComponent<Projectile>();
			bool flag = true;
			if (m_projectile is InstantDamageOneEnemyProjectile)
			{
				flag = false;
			}
			if (m_projectile is InstantlyDamageAllProjectile)
			{
				flag = false;
			}
			if (Object.op_Implicit((Object)(object)((Component)m_projectile).GetComponent<ArtfulDodgerProjectileController>()))
			{
				flag = false;
			}
			if (flag)
			{
				BounceProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<BounceProjModifier>(((Component)m_projectile).gameObject);
				orAddComponent.numberOfBounces = Mathf.Max(orAddComponent.numberOfBounces, 1);
				orAddComponent.onlyBounceOffTiles = true;
				BounceProjModifier val = orAddComponent;
				val.OnBounceContext = (Action<BounceProjModifier, SpeculativeRigidbody>)Delegate.Combine(val.OnBounceContext, new Action<BounceProjModifier, SpeculativeRigidbody>(HandleStartOrbit));
			}
		}
		catch (Exception ex)
		{
			ETGModConsole.Log((object)ex.Message, false);
			ETGModConsole.Log((object)ex.StackTrace, false);
		}
	}

	private void HandleStartOrbit(BounceProjModifier mod, SpeculativeRigidbody srb)
	{
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Expected O, but got Unknown
		int orbitersInGroup = OrbitProjectileMotionModule.GetOrbitersInGroup(orbitalGroup);
		if (orbitersInGroup >= cappedOrbiters)
		{
			return;
		}
		((BraveBehaviour)((BraveBehaviour)mod).projectile).specRigidbody.CollideWithTileMap = orbitersCollideWithTilemap;
		if (resetTravelledDistanceOnOrbit)
		{
			((BraveBehaviour)mod).projectile.ResetDistance();
		}
		if (alterProjRangeOnOrbit)
		{
			if (baseProjectileRangePrioritisedIfLarger)
			{
				((BraveBehaviour)mod).projectile.baseData.range = Mathf.Max(((BraveBehaviour)mod).projectile.baseData.range, targetRange);
			}
			else
			{
				((BraveBehaviour)mod).projectile.baseData.range = targetRange;
			}
		}
		if (resetSpeedIfOverCappedValueOnOrbit && ((BraveBehaviour)mod).projectile.baseData.speed > speedCap)
		{
			((BraveBehaviour)mod).projectile.baseData.speed = speedResetValue;
			((BraveBehaviour)mod).projectile.UpdateSpeed();
		}
		OrbitProjectileMotionModule val = new OrbitProjectileMotionModule();
		val.lifespan = orbitalLifespan;
		val.MinRadius = minOrbitalRadius;
		val.MaxRadius = maxOrbitalRadius;
		val.OrbitGroup = orbitalGroup;
		val.usesAlternateOrbitTarget = usesOverrideCenter;
		val.alternateOrbitTarget = overrideCenter;
		if (((BraveBehaviour)mod).projectile.OverrideMotionModule != null && ((BraveBehaviour)mod).projectile.OverrideMotionModule is HelixProjectileMotionModule)
		{
			val.StackHelix = true;
			ref bool forceInvert = ref val.ForceInvert;
			ProjectileMotionModule overrideMotionModule = ((BraveBehaviour)mod).projectile.OverrideMotionModule;
			forceInvert = ((HelixProjectileMotionModule)((overrideMotionModule is HelixProjectileMotionModule) ? overrideMotionModule : null)).ForceInvert;
		}
		((BraveBehaviour)mod).projectile.OverrideMotionModule = (ProjectileMotionModule)(object)val;
	}
}
