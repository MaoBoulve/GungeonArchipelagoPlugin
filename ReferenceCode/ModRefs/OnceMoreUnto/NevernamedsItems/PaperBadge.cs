using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class PaperBadge : PassiveItem
{
	public static void Init()
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<PaperBadge>("Paper Badge", "All or Nothing", "Randomly either doubles or negates your bullet damage!\n\nThis paper badge looks far too flimsy to be of any use, but you'd be surprised.", "paperbadge_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		((PickupObject)val).CanBeDropped = true;
		((PickupObject)val).quality = (ItemQuality)2;
	}

	public void PostProcess(Projectile bullet, float chanceScaler)
	{
		if (Object.op_Implicit((Object)(object)bullet) && Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(bullet)))
		{
			float num = 0.5f;
			num += ProjectileUtility.ProjectilePlayerOwner(bullet).stats.GetStatValue((StatType)4) * 0.05f;
			if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Lucky Day"))
			{
				num += 0.3f;
			}
			if (Random.value <= num)
			{
				ProjectileData baseData = bullet.baseData;
				baseData.damage *= 2f;
				bullet.RuntimeUpdateScale(1.5f);
			}
			else
			{
				ProjectileData baseData2 = bullet.baseData;
				baseData2.damage *= 0.01f;
				bullet.RuntimeUpdateScale(0.5f);
			}
		}
	}

	public override void Pickup(PlayerController player)
	{
		player.PostProcessProjectile += PostProcess;
		((PassiveItem)this).Pickup(player);
	}

	public override void DisableEffect(PlayerController player)
	{
		if (Object.op_Implicit((Object)(object)player))
		{
			player.PostProcessProjectile -= PostProcess;
		}
		((PassiveItem)this).DisableEffect(player);
	}
}
