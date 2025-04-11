using System;
using UnityEngine;

namespace NevernamedsItems;

internal class ObjectComponentLister : PassiveItem
{
	public static void Init()
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		ObjectComponentLister objectComponentLister = ItemSetup.NewItem<ObjectComponentLister>("Object Component Lister", "Work In Progress", "Lists the components present in objects that you shoot.", "workinprogress_icon", assetbundle: true) as ObjectComponentLister;
		((PickupObject)objectComponentLister).quality = (ItemQuality)(-100);
		((PickupObject)objectComponentLister).CanBeDropped = true;
		((PickupObject)objectComponentLister).CanBeSold = true;
	}

	public void onFired(Projectile bullet, float eventchancescaler)
	{
		SpeculativeRigidbody specRigidbody = ((BraveBehaviour)bullet).specRigidbody;
		specRigidbody.OnCollision = (Action<CollisionData>)Delegate.Combine(specRigidbody.OnCollision, new Action<CollisionData>(onHitEnemy));
	}

	public void onHitEnemy(CollisionData data)
	{
		if (Object.op_Implicit((Object)(object)data.OtherRigidbody) && Object.op_Implicit((Object)(object)((Component)data.OtherRigidbody).gameObject))
		{
			BulletComponentLister.ListComponents(((Component)data.OtherRigidbody).gameObject);
		}
	}

	public override void Pickup(PlayerController player)
	{
		player.PostProcessProjectile += onFired;
		((PassiveItem)this).Pickup(player);
	}

	public override DebrisObject Drop(PlayerController player)
	{
		DebrisObject result = ((PassiveItem)this).Drop(player);
		player.PostProcessProjectile -= onFired;
		return result;
	}
}
