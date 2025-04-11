using Alexandria.ItemAPI;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class FalseBlank : ReusableBlankitem
{
	private int timesUsed = 0;

	public static void Init()
	{
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<FalseBlank>("False Blank", "Blanksphemer", "This artefact was created by the devilish Shell'tan to trick unwary Gungeoneers. With every use, more of the bearer's soul is stripped away, and exchanged with pure darkness.", "falseblank_icon", assetbundle: true);
		PlayerItem val = (PlayerItem)(object)((obj is PlayerItem) ? obj : null);
		ItemBuilder.SetCooldownType(val, (CooldownType)1, 50f);
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)val, (StatType)14, 1f, (ModifyMethod)0);
		val.consumable = false;
		((PickupObject)val).quality = (ItemQuality)1;
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)4, 1f);
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)2, 1f);
	}

	public override void Pickup(PlayerController player)
	{
		if (!((PlayerItem)this).m_pickedUpThisRun)
		{
			timesUsed = 0;
		}
		((PlayerItem)this).Pickup(player);
	}

	public override void DoEffect(PlayerController user)
	{
		if (!CustomSynergies.PlayerHasActiveSynergy(user, "False Pretences") || !(Random.value < 0.5f))
		{
			giveSomeCurse(user);
		}
		if (CustomSynergies.PlayerHasActiveSynergy(user, "Transparent Lies"))
		{
			PickupObject byId = PickupObjectDatabase.GetById(565);
			user.AcquirePassiveItemPrefabDirectly((PassiveItem)(object)((byId is PassiveItem) ? byId : null));
		}
		timesUsed++;
		user.ForceBlank(25f, 0.5f, false, true, (Vector2?)null, true, -1f);
		if (timesUsed >= 10 && !SaveAPIManager.GetFlag(CustomDungeonFlags.USED_FALSE_BLANK_TEN_TIMES))
		{
			SaveAPIManager.SetFlag(CustomDungeonFlags.USED_FALSE_BLANK_TEN_TIMES, value: true);
		}
	}

	private void giveSomeCurse(PlayerController user)
	{
		float baseStatValue = user.stats.GetBaseStatValue((StatType)14);
		user.stats.SetBaseStatValue((StatType)14, baseStatValue + 0.5f, user);
	}

	public override bool CanBeUsed(PlayerController user)
	{
		return ((PlayerItem)this).CanBeUsed(user);
	}
}
