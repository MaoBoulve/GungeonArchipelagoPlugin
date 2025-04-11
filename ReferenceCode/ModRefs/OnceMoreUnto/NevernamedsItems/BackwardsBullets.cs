using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class BackwardsBullets : PassiveItem
{
	public static void Init()
	{
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<BackwardsBullets>("Backwards Bullets", "gnaB gnaB ytoohS", "...thgin ymrots dna dloc a no tnemirepxe cifirroh a fo tluser eht era stellub esehT\n\n!sdrawkcab levart meht sekam osla tub, lufrewop erom stellub ruoy sekaM", "backwardsbullets_icon", assetbundle: true);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)2, 0.5f, (ModifyMethod)1);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)5, 2f, (ModifyMethod)1);
		val.quality = (ItemQuality)2;
		AlexandriaTags.SetTag(val, "bullet_modifier");
		Doug.AddToLootPool(val.PickupObjectId);
	}

	public void ModifyVolley(ProjectileVolleyData volleyToModify)
	{
		int count = volleyToModify.projectiles.Count;
		for (int i = 0; i < count; i++)
		{
			ProjectileModule val = volleyToModify.projectiles[i];
			val.angleFromAim += 180f;
		}
	}

	public override void Pickup(PlayerController player)
	{
		player.stats.AdditionalVolleyModifiers += ModifyVolley;
		player.stats.RecalculateStats(player, false, false);
		((PassiveItem)this).Pickup(player);
	}

	public override DebrisObject Drop(PlayerController player)
	{
		player.stats.AdditionalVolleyModifiers -= ModifyVolley;
		player.stats.RecalculateStats(player, false, false);
		return ((PassiveItem)this).Drop(player);
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			((PassiveItem)this).Owner.stats.AdditionalVolleyModifiers -= ModifyVolley;
			((PassiveItem)this).Owner.stats.RecalculateStats(((PassiveItem)this).Owner, false, false);
		}
		((PassiveItem)this).OnDestroy();
	}
}
