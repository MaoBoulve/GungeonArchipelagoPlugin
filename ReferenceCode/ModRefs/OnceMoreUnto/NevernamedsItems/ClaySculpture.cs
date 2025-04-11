using UnityEngine;

namespace NevernamedsItems;

internal class ClaySculpture : PassiveItem
{
	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<ClaySculpture>("Clay Sculpture", "This Gungeon Has Gundead In It", "Upon taking damage, Gundead are consumed by the floor beneath them.\n\nThe foundations of the Gungeon are built on a special type of 12-gauge granular clay, which is the ABSOLUTE best for sculptures such as these.\nJust be careful... you don't want to catch anything...", "claysculpture_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)2;
	}

	private void charmAll(PlayerController user)
	{
		AIActor randomActiveEnemy = user.CurrentRoom.GetRandomActiveEnemy(true);
		if ((Object)(object)randomActiveEnemy != (Object)null && !((BraveBehaviour)randomActiveEnemy).healthHaver.IsBoss)
		{
			((GameActor)randomActiveEnemy).ForceFall();
		}
		if (((PassiveItem)this).Owner.HasPickupID(159))
		{
			AIActor randomActiveEnemy2 = user.CurrentRoom.GetRandomActiveEnemy(true);
			if ((Object)(object)randomActiveEnemy2 != (Object)null && !((BraveBehaviour)randomActiveEnemy2).healthHaver.IsBoss)
			{
				((GameActor)randomActiveEnemy2).ForceFall();
			}
		}
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		player.OnReceivedDamage += charmAll;
	}

	public override DebrisObject Drop(PlayerController player)
	{
		DebrisObject result = ((PassiveItem)this).Drop(player);
		player.OnReceivedDamage -= charmAll;
		return result;
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			((PassiveItem)this).Owner.OnReceivedDamage -= charmAll;
		}
		((PassiveItem)this).OnDestroy();
	}
}
