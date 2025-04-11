using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class MTXGunModifiers : GunBehaviour
{
	private PlayerController lastPlayerOwner;

	private void OnKilledEnemy(PlayerController player, HealthHaver enemy)
	{
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)base.gun) && Object.op_Implicit((Object)(object)player) && Object.op_Implicit((Object)(object)enemy) && CustomSynergies.PlayerHasActiveSynergy(player, "Fully Funded") && ((PickupObject)((GameActor)player).CurrentGun).PickupObjectId == 476 && enemy.GetMaxHealth() >= 10f)
		{
			LootEngine.SpawnCurrency(((BraveBehaviour)enemy).specRigidbody.UnitCenter, 1, false);
		}
	}

	public override void Update()
	{
		if (Object.op_Implicit((Object)(object)this) && Object.op_Implicit((Object)(object)base.gun))
		{
			if ((Object)(object)GunTools.GunPlayerOwner(base.gun) != (Object)null && (Object)(object)lastPlayerOwner == (Object)null)
			{
				GunTools.GunPlayerOwner(base.gun).OnKilledEnemyContext += OnKilledEnemy;
				lastPlayerOwner = GunTools.GunPlayerOwner(base.gun);
			}
			else if ((Object)(object)GunTools.GunPlayerOwner(base.gun) == (Object)null && (Object)(object)lastPlayerOwner != (Object)null)
			{
				lastPlayerOwner.OnKilledEnemyContext -= OnKilledEnemy;
				lastPlayerOwner = null;
			}
		}
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)GunTools.GunPlayerOwner(base.gun)) || (Object)(object)lastPlayerOwner != (Object)null)
		{
			if (Object.op_Implicit((Object)(object)GunTools.GunPlayerOwner(base.gun)))
			{
				GunTools.GunPlayerOwner(base.gun).OnKilledEnemyContext -= OnKilledEnemy;
			}
			else if ((Object)(object)lastPlayerOwner != (Object)null)
			{
				lastPlayerOwner.OnKilledEnemyContext -= OnKilledEnemy;
			}
		}
	}
}
