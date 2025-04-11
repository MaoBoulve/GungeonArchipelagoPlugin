using UnityEngine;

namespace NevernamedsItems;

public class EightButton : PassiveItem
{
	public int trackedShots = 0;

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<EightButton>("88888888", "88888888", "8888888888888888888888888888888888888888888888888888888888888888888888888888888888888888", "88888888_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)2;
	}

	private void PostProcessProjectile(Projectile bullet, float thing)
	{
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		trackedShots++;
		if (trackedShots >= 8)
		{
			AkSoundEngine.PostEvent("Play_StanleyEight", ((Component)((PassiveItem)this).Owner).gameObject);
			PickupObject byId = PickupObjectDatabase.GetById(Sweeper.ID);
			Projectile val = ((Gun)((byId is Gun) ? byId : null)).RawSourceVolley.projectiles[1].projectiles[7];
			GameObject val2 = SpawnManager.SpawnProjectile(((Component)val).gameObject, Vector2.op_Implicit(((BraveBehaviour)((PassiveItem)this).Owner).sprite.WorldCenter), Quaternion.Euler(0f, 0f, ((Object)(object)((GameActor)((PassiveItem)this).Owner).CurrentGun == (Object)null) ? 0f : ((GameActor)((PassiveItem)this).Owner).CurrentGun.CurrentAngle), true);
			Projectile component = val2.GetComponent<Projectile>();
			if ((Object)(object)component != (Object)null)
			{
				component.Owner = (GameActor)(object)((PassiveItem)this).Owner;
				component.Shooter = ((BraveBehaviour)((PassiveItem)this).Owner).specRigidbody;
				component.AdjustPlayerProjectileTint(Color.red, 1, 0f);
			}
			trackedShots = 0;
		}
	}

	public override void Pickup(PlayerController player)
	{
		player.PostProcessProjectile += PostProcessProjectile;
		((PassiveItem)this).Pickup(player);
	}

	public override DebrisObject Drop(PlayerController player)
	{
		player.PostProcessProjectile -= PostProcessProjectile;
		return ((PassiveItem)this).Drop(player);
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			((PassiveItem)this).Owner.PostProcessProjectile -= PostProcessProjectile;
		}
		((PassiveItem)this).OnDestroy();
	}
}
