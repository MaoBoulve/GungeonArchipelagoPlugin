using System;
using UnityEngine;

namespace NevernamedsItems;

public class GravitronBulletsBehaviour : MonoBehaviour
{
	private bool hasAlreadyOrbited;

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

	public float damageMultOnOrbitStart;

	public GravitronBulletsBehaviour()
	{
		orbitalLifespan = 15f;
		cappedOrbiters = 20;
		orbitersCollideWithTilemap = false;
		orbitalGroup = 3;
		resetTravelledDistanceOnOrbit = true;
		alterProjRangeOnOrbit = true;
		baseProjectileRangePrioritisedIfLarger = true;
		resetSpeedIfOverCappedValueOnOrbit = true;
		speedCap = 50f;
		speedResetValue = 20f;
		targetRange = 500f;
		damageMultOnOrbitStart = 2f;
		minOrbitalRadius = 2f;
		maxOrbitalRadius = 5f;
		hasAlreadyOrbited = false;
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
				PierceProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<PierceProjModifier>(((Component)m_projectile).gameObject);
				orAddComponent.penetration = Mathf.Max(orAddComponent.penetration, 20);
				orAddComponent.penetratesBreakables = true;
				Projectile projectile = m_projectile;
				projectile.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(projectile.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(HandleStartOrbit));
			}
		}
		catch (Exception ex)
		{
			ETGModConsole.Log((object)ex.Message, false);
			ETGModConsole.Log((object)ex.StackTrace, false);
		}
	}

	private void Update()
	{
		if (Object.op_Implicit((Object)(object)m_projectile) && m_projectile.OverrideMotionModule != null && m_projectile.OverrideMotionModule is OrbitProjectileMotionModule)
		{
			ProjectileMotionModule overrideMotionModule = m_projectile.OverrideMotionModule;
			OrbitProjectileMotionModule val = (OrbitProjectileMotionModule)(object)((overrideMotionModule is OrbitProjectileMotionModule) ? overrideMotionModule : null);
			if (!Object.op_Implicit((Object)(object)val.alternateOrbitTarget) && val.usesAlternateOrbitTarget)
			{
				m_projectile.DieInAir(false, true, true, false);
			}
		}
	}

	private void HandleStartOrbit(Projectile proj, SpeculativeRigidbody enemy, bool fatal)
	{
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Expected O, but got Unknown
		if (fatal || hasAlreadyOrbited)
		{
			return;
		}
		int orbitersInGroup = OrbitProjectileMotionModule.GetOrbitersInGroup(orbitalGroup);
		if (orbitersInGroup >= cappedOrbiters)
		{
		}
		((BraveBehaviour)proj).specRigidbody.CollideWithTileMap = orbitersCollideWithTilemap;
		if (resetTravelledDistanceOnOrbit)
		{
			proj.ResetDistance();
		}
		if (alterProjRangeOnOrbit)
		{
			if (baseProjectileRangePrioritisedIfLarger)
			{
				proj.baseData.range = Mathf.Max(proj.baseData.range, targetRange);
			}
			else
			{
				proj.baseData.range = targetRange;
			}
		}
		if (resetSpeedIfOverCappedValueOnOrbit && proj.baseData.speed > speedCap)
		{
			proj.baseData.speed = speedResetValue;
			proj.UpdateSpeed();
		}
		ProjectileData baseData = proj.baseData;
		baseData.damage *= damageMultOnOrbitStart;
		OrbitProjectileMotionModule val = new OrbitProjectileMotionModule();
		val.lifespan = orbitalLifespan;
		val.MinRadius = minOrbitalRadius;
		val.MaxRadius = maxOrbitalRadius;
		val.usesAlternateOrbitTarget = true;
		val.OrbitGroup = orbitalGroup;
		val.alternateOrbitTarget = enemy;
		if (proj.OverrideMotionModule != null && proj.OverrideMotionModule is HelixProjectileMotionModule)
		{
			val.StackHelix = true;
			ref bool forceInvert = ref val.ForceInvert;
			ProjectileMotionModule overrideMotionModule = proj.OverrideMotionModule;
			forceInvert = ((HelixProjectileMotionModule)((overrideMotionModule is HelixProjectileMotionModule) ? overrideMotionModule : null)).ForceInvert;
		}
		proj.OverrideMotionModule = (ProjectileMotionModule)(object)val;
		hasAlreadyOrbited = true;
	}
}
