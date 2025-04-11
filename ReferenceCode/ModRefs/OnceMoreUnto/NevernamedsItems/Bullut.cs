using Alexandria.ChestAPI;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

internal class Bullut : PlayerItem
{
	public static void Init()
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<Bullut>("Bullut", "Supposed Delicacy", "Bullet Embryos, boiled inside their shells. Apparently this is supposed to be food.\n\nEating this makes the Gundead, Kaliber, and pretty much everyone else mad at you, though the Gunsling King describes it as a... rewarding experience.", "bullut_icon", assetbundle: true);
		PlayerItem val = (PlayerItem)(object)((obj is PlayerItem) ? obj : null);
		ItemBuilder.SetCooldownType(val, (CooldownType)3, 1000f);
		val.consumable = true;
		((PickupObject)val).quality = (ItemQuality)1;
	}

	public override void DoEffect(PlayerController user)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		ChangeStatPermanent(user, (StatType)14, 2f, (ModifyMethod)0);
		ChangeStatPermanent(user, (StatType)23, 1.5f, (ModifyMethod)1);
		for (int i = 0; i < 3; i++)
		{
			IntVector2 randomVisibleClearSpot = user.CurrentRoom.GetRandomVisibleClearSpot(2, 2);
			Chest val = GameManager.Instance.RewardManager.SpawnRewardChestAt(randomVisibleClearSpot, -1f, (ItemQuality)(-100));
			val.RegisterChestOnMinimap(((DungeonPlaceableBehaviour)val).GetAbsoluteParentRoom());
		}
		ChestUtility.SpawnChestEasy(user.CurrentRoom.GetRandomVisibleClearSpot(2, 2), (ChestTier)8, true, (GeneralChestType)0, (ThreeStateValue)2, (ThreeStateValue)2);
		ChestUtility.SpawnChestEasy(user.CurrentRoom.GetRandomVisibleClearSpot(2, 2), (ChestTier)3, true, (GeneralChestType)0, (ThreeStateValue)2, (ThreeStateValue)2);
		ChestUtility.SpawnChestEasy(user.CurrentRoom.GetRandomVisibleClearSpot(2, 2), (ChestTier)4, true, (GeneralChestType)0, (ThreeStateValue)2, (ThreeStateValue)2);
		for (int j = 0; j < 10; j++)
		{
			LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(67)).gameObject, user);
		}
	}

	private void ChangeStatPermanent(PlayerController target, StatType statToChance, float amount, ModifyMethod modifyMethod)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		StatModifier val = new StatModifier();
		val.amount = amount;
		val.modifyType = modifyMethod;
		val.statToBoost = statToChance;
		target.ownerlessStatModifiers.Add(val);
		target.stats.RecalculateStats(target, false, false);
	}
}
