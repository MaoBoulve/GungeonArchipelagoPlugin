namespace NevernamedsItems;

public class SuperPierceProjectile : Projectile
{
	public bool shouldRemoveCooldown;

	public SuperPierceProjectile()
	{
		shouldRemoveCooldown = true;
	}

	public override void OnRigidbodyCollision(CollisionData rigidbodyCollision)
	{
		((Projectile)this).OnRigidbodyCollision(rigidbodyCollision);
		if (shouldRemoveCooldown)
		{
			((BraveBehaviour)this).specRigidbody.DeregisterTemporaryCollisionException(rigidbodyCollision.OtherRigidbody);
			rigidbodyCollision.OtherRigidbody.DeregisterTemporaryCollisionException(((BraveBehaviour)this).specRigidbody);
		}
	}
}
