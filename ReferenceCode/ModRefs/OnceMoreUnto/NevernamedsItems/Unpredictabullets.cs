using System;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class Unpredictabullets : PassiveItem
{
	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<Unpredictabullets>("Unpredictabullets", "Who? What? When? Where?", "Unpredictably modifies bullet stats.\n\nCreated by firing enough bullets at the wall and seeing what stuck.", "unpredictabullets_icon", assetbundle: true);
		val.quality = (ItemQuality)3;
		AlexandriaTags.SetTag(val, "bullet_modifier");
		Doug.AddToLootPool(val.PickupObjectId);
	}

	private void PostProcessProjectile(Projectile sourceProjectile, float effectChanceScalar)
	{
		try
		{
			ProjectileData baseData = sourceProjectile.baseData;
			baseData.damage *= GetModifierAmount(((PassiveItem)this).Owner);
			ProjectileData baseData2 = sourceProjectile.baseData;
			baseData2.range *= GetModifierAmount(((PassiveItem)this).Owner);
			ProjectileData baseData3 = sourceProjectile.baseData;
			baseData3.speed *= GetModifierAmount(((PassiveItem)this).Owner);
			ProjectileData baseData4 = sourceProjectile.baseData;
			baseData4.force *= GetModifierAmount(((PassiveItem)this).Owner);
			sourceProjectile.AdditionalScaleMultiplier *= GetModifierAmount(((PassiveItem)this).Owner);
			sourceProjectile.UpdateSpeed();
		}
		catch (Exception ex)
		{
			ETGModConsole.Log((object)ex.Message, false);
		}
	}

	private float GetModifierAmount(PlayerController owner)
	{
		int num = 200;
		int num2 = 10;
		if (CustomSynergies.PlayerHasActiveSynergy(owner, "Cause And Effect"))
		{
			num = 250;
		}
		float num3 = Random.Range(num2, num + 1);
		return num3 /= 100f;
	}

	public override DebrisObject Drop(PlayerController player)
	{
		DebrisObject result = ((PassiveItem)this).Drop(player);
		player.PostProcessProjectile -= PostProcessProjectile;
		return result;
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			((PassiveItem)this).Owner.PostProcessProjectile -= PostProcessProjectile;
		}
		((PassiveItem)this).OnDestroy();
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		player.PostProcessProjectile += PostProcessProjectile;
	}
}
