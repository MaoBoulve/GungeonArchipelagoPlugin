using System;
using UnityEngine;

namespace NevernamedsItems;

public class IntersectEnemyBulletsItem : PassiveItem
{
	public void onFired(Projectile bullet, float eventchancescaler)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		bullet.collidesWithProjectiles = true;
		SpeculativeRigidbody specRigidbody = ((BraveBehaviour)bullet).specRigidbody;
		specRigidbody.OnPreRigidbodyCollision = (OnPreRigidbodyCollisionDelegate)Delegate.Combine((Delegate)(object)specRigidbody.OnPreRigidbodyCollision, (Delegate)new OnPreRigidbodyCollisionDelegate(HandlePreCollision));
	}

	private void onFiredBeam(BeamController sourceBeam)
	{
	}

	public override void Pickup(PlayerController player)
	{
		player.PostProcessProjectile += onFired;
		player.PostProcessBeam += onFiredBeam;
		((PassiveItem)this).Pickup(player);
	}

	private void HandlePreCollision(SpeculativeRigidbody myRigidbody, PixelCollider myPixelCollider, SpeculativeRigidbody otherRigidbody, PixelCollider otherPixelCollider)
	{
		if (!Object.op_Implicit((Object)(object)otherRigidbody) || !Object.op_Implicit((Object)(object)((BraveBehaviour)otherRigidbody).projectile))
		{
			return;
		}
		if (((BraveBehaviour)otherRigidbody).projectile.Owner is PlayerController)
		{
			PhysicsEngine.SkipCollision = true;
			return;
		}
		if (((BraveBehaviour)otherRigidbody).projectile.Owner is AIActor && Random.value <= 0.3f)
		{
			DoIntersectionEffect(((BraveBehaviour)myRigidbody).projectile, ((BraveBehaviour)otherRigidbody).projectile);
		}
		if (!((BraveBehaviour)otherRigidbody).projectile.collidesWithProjectiles)
		{
			PhysicsEngine.SkipCollision = true;
		}
	}

	public override DebrisObject Drop(PlayerController player)
	{
		DebrisObject result = ((PassiveItem)this).Drop(player);
		player.PostProcessProjectile -= onFired;
		player.PostProcessBeam -= onFiredBeam;
		return result;
	}

	public override void OnDestroy()
	{
		if ((Object)(object)((PassiveItem)this).Owner != (Object)null)
		{
			((PassiveItem)this).Owner.PostProcessProjectile -= onFired;
			((PassiveItem)this).Owner.PostProcessBeam -= onFiredBeam;
		}
		((PassiveItem)this).OnDestroy();
	}

	public virtual void DoIntersectionEffect(Projectile playerBullet, Projectile enemyBullet)
	{
	}
}
