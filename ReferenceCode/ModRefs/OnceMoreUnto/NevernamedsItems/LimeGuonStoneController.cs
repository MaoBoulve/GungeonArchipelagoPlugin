using System;
using System.Collections.Generic;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class LimeGuonStoneController : MonoBehaviour
{
	public List<Projectile> registered = new List<Projectile>();

	public List<Projectile> orbiters = new List<Projectile>();

	private PlayerOrbital self;

	private SpeculativeRigidbody rigidbody;

	private PlayerController owner;

	private void Start()
	{
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Expected O, but got Unknown
		self = ((Component)this).GetComponent<PlayerOrbital>();
		rigidbody = ((Component)this).GetComponent<SpeculativeRigidbody>();
		owner = ((Component)this).GetComponent<PlayerOrbital>().Owner;
		SpeculativeRigidbody obj = rigidbody;
		obj.OnPreRigidbodyCollision = (OnPreRigidbodyCollisionDelegate)Delegate.Combine((Delegate)(object)obj.OnPreRigidbodyCollision, (Delegate)new OnPreRigidbodyCollisionDelegate(OnGuonHitByBullet));
	}

	private void OnGuonHitByBullet(SpeculativeRigidbody myRigidbody, PixelCollider myCollider, SpeculativeRigidbody other, PixelCollider otherCollider)
	{
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Expected O, but got Unknown
		if (!Object.op_Implicit((Object)(object)owner) || !Object.op_Implicit((Object)(object)((BraveBehaviour)other).projectile) || !Object.op_Implicit((Object)(object)((BraveBehaviour)other).projectile.Owner) || ((BraveBehaviour)other).projectile.Owner is PlayerController || registered.Contains(((BraveBehaviour)other).projectile))
		{
			return;
		}
		registered.Add(((BraveBehaviour)other).projectile);
		int num = 1;
		if (CustomSynergies.PlayerHasActiveSynergy(owner, "Limer Guon Stone"))
		{
			num++;
		}
		for (int i = 0; i < num; i++)
		{
			int orbitersInGroup = OrbitProjectileMotionModule.GetOrbitersInGroup(-138760);
			if (orbitersInGroup >= 30)
			{
				break;
			}
			Projectile component = ProjectileUtility.InstantiateAndFireInDirection(LimeGuonStone.orbitalShot, rigidbody.UnitCenter, Vector2Extensions.ToAngle(Random.insideUnitCircle), 0f, (PlayerController)null).GetComponent<Projectile>();
			((BraveBehaviour)component).specRigidbody.CollideWithTileMap = false;
			OrbitProjectileMotionModule val = new OrbitProjectileMotionModule();
			val.lifespan = 150f;
			val.MinRadius = 2f;
			val.MaxRadius = 5f;
			val.usesAlternateOrbitTarget = true;
			val.OrbitGroup = -138760;
			val.alternateOrbitTarget = rigidbody;
			if (component.OverrideMotionModule != null && component.OverrideMotionModule is HelixProjectileMotionModule)
			{
				val.StackHelix = true;
				ref bool forceInvert = ref val.ForceInvert;
				ProjectileMotionModule overrideMotionModule = component.OverrideMotionModule;
				forceInvert = ((HelixProjectileMotionModule)((overrideMotionModule is HelixProjectileMotionModule) ? overrideMotionModule : null)).ForceInvert;
			}
			component.OverrideMotionModule = (ProjectileMotionModule)(object)val;
			component.Owner = (GameActor)(object)owner;
			component.Shooter = ((BraveBehaviour)owner).specRigidbody;
			ProjectileData baseData = component.baseData;
			baseData.damage *= owner.stats.GetStatValue((StatType)5);
			ProjectileData baseData2 = component.baseData;
			baseData2.speed *= owner.stats.GetStatValue((StatType)6);
			ProjectileData baseData3 = component.baseData;
			baseData3.force *= owner.stats.GetStatValue((StatType)12);
			component.BossDamageMultiplier *= owner.stats.GetStatValue((StatType)22);
			owner.DoPostProcessProjectile(component);
			orbiters.Add(component);
		}
	}

	private void OnDestroy()
	{
		for (int num = orbiters.Count - 1; num >= 0; num--)
		{
			if ((Object)(object)orbiters[num] != (Object)null)
			{
				orbiters[num].DieInAir(false, true, true, false);
			}
		}
		orbiters.Clear();
	}
}
