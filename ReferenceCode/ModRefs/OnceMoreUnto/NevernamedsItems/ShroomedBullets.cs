using Alexandria.ItemAPI;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class ShroomedBullets : PassiveItem
{
	public static int ID;

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<ShroomedBullets>("Shroomed Bullets", "Misfired", "Busted shells that fragment upon leaving the barrel.\n\nThese particular bullets have held up quite well despite their flawed construction at the hands of a blacksmiths aspiring daughter...", "shroomedbullets_icon", assetbundle: true);
		val.quality = (ItemQuality)2;
		AlexandriaTags.SetTag(val, "bullet_modifier");
		ID = val.PickupObjectId;
		ItemBuilder.AddPassiveStatModifier(val, (StatType)5, 0.75f, (ModifyMethod)1);
		val.SetupUnlockOnCustomStat(CustomTrackedStats.BEGGAR_TOTAL_DONATIONS, 1274f, (PrerequisiteOperation)2);
		Doug.AddToLootPool(val.PickupObjectId);
	}

	public override void Pickup(PlayerController player)
	{
		player.stats.AdditionalVolleyModifiers += ModifyVolley;
		player.stats.RecalculateStats(player, false, false);
		((PassiveItem)this).Pickup(player);
	}

	public override void DisableEffect(PlayerController player)
	{
		if (Object.op_Implicit((Object)(object)player))
		{
			player.stats.AdditionalVolleyModifiers -= ModifyVolley;
			player.stats.RecalculateStats(player, false, false);
		}
		((PassiveItem)this).DisableEffect(player);
	}

	public void ModifyVolley(ProjectileVolleyData volleyToModify)
	{
		int num = 1;
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner) && CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Not Mu' Shroom Left"))
		{
			num++;
		}
		for (int i = 0; i < num; i++)
		{
			int count = volleyToModify.projectiles.Count;
			for (int j = 0; j < count; j++)
			{
				ProjectileModule val = volleyToModify.projectiles[j];
				val.angleFromAim += 20f;
				int num2 = j;
				if (val.CloneSourceIndex >= 0)
				{
					num2 = val.CloneSourceIndex;
				}
				ProjectileModule val2 = ProjectileModule.CreateClone(val, false, num2);
				val2.angleFromAim -= 40f;
				val2.ignoredForReloadPurposes = true;
				val2.ammoCost = 0;
				volleyToModify.projectiles.Add(val2);
			}
		}
	}
}
