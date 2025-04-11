using UnityEngine;

namespace NevernamedsItems;

public class BootLeg : PassiveItem
{
	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<BootLeg>("Legboot", "Knock It Off", "From a peculiar and less graphically appealing alternate dimension where dodge rolling through bullets or into enemies restores ammo.\n\nThis boot is as long as your entire leg!", "legboot_icon", assetbundle: true);
		val.quality = (ItemQuality)4;
	}

	private void onDodgeRolledOverBullet(Projectile bullet)
	{
		if ((Object)(object)((GameActor)((PassiveItem)this).Owner).CurrentGun != (Object)null)
		{
			((GameActor)((PassiveItem)this).Owner).CurrentGun.GainAmmo(1);
		}
	}

	private void onDodgeRolledIntoEnemy(PlayerController player, AIActor enemy)
	{
		if ((Object)(object)((GameActor)((PassiveItem)this).Owner).CurrentGun != (Object)null)
		{
			((GameActor)((PassiveItem)this).Owner).CurrentGun.GainAmmo(5);
		}
	}

	public override void Pickup(PlayerController player)
	{
		player.OnDodgedProjectile += onDodgeRolledOverBullet;
		player.OnRolledIntoEnemy += onDodgeRolledIntoEnemy;
		((PassiveItem)this).Pickup(player);
	}

	public override DebrisObject Drop(PlayerController player)
	{
		DebrisObject result = ((PassiveItem)this).Drop(player);
		player.OnDodgedProjectile -= onDodgeRolledOverBullet;
		player.OnRolledIntoEnemy -= onDodgeRolledIntoEnemy;
		return result;
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			((PassiveItem)this).Owner.OnDodgedProjectile -= onDodgeRolledOverBullet;
			((PassiveItem)this).Owner.OnRolledIntoEnemy -= onDodgeRolledIntoEnemy;
		}
		((PassiveItem)this).OnDestroy();
	}
}
