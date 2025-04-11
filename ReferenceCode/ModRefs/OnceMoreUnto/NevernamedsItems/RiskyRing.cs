using Alexandria.ItemAPI;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class RiskyRing : PassiveItem
{
	private float currentHP;

	private float lastHP;

	private float currentArmour;

	private float lastArmour;

	private float currentGuns;

	private float lastGuns;

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<RiskyRing>("Risky Ring", "This Ring Has Fangs", "More drops when at full HP, less drops when not.\n\nThis ring feels slightly irradiated.", "riskyring_icon", assetbundle: true);
		val.quality = (ItemQuality)1;
		val.SetupUnlockOnCustomFlag(CustomDungeonFlags.HASBEENDAMAGEDBYRISKRIFLE, requiredFlagValue: true);
	}

	private float GetModifierAmount(PlayerController owner, bool ShouldBePositive)
	{
		if (owner.ForceZeroHealthState)
		{
			if (CustomSynergies.PlayerHasActiveSynergy(owner, "Double Risk, Double Reward"))
			{
				return 6f;
			}
			return 3f;
		}
		if (ShouldBePositive)
		{
			if (CustomSynergies.PlayerHasActiveSynergy(owner, "Double Risk, Double Reward"))
			{
				return 6f;
			}
			return 3f;
		}
		float num = ((!CustomSynergies.PlayerHasActiveSynergy(owner, "Double Risk, Double Reward")) ? 3f : 6f);
		if (owner.stats.GetStatValue((StatType)4) >= num)
		{
			return num * -1f;
		}
		return owner.stats.GetStatValue((StatType)4) * -1f;
	}

	private void RecalculateShit()
	{
		bool shouldBePositive = ((BraveBehaviour)((PassiveItem)this).Owner).healthHaver.GetCurrentHealthPercentage() == 1f;
		ItemBuilder.RemovePassiveStatModifier((PickupObject)(object)this, (StatType)4);
		((PassiveItem)this).Owner.stats.RecalculateStats(((PassiveItem)this).Owner, false, false);
		float modifierAmount = GetModifierAmount(((PassiveItem)this).Owner, shouldBePositive);
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)this, (StatType)4, modifierAmount, (ModifyMethod)0);
		((PassiveItem)this).Owner.stats.RecalculateStats(((PassiveItem)this).Owner, false, false);
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		player.OnRoomClearEvent += HandleChestSpawnSynergy;
		RecalculateShit();
	}

	public override DebrisObject Drop(PlayerController player)
	{
		player.OnRoomClearEvent -= HandleChestSpawnSynergy;
		return ((PassiveItem)this).Drop(player);
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			((PassiveItem)this).Owner.OnRoomClearEvent -= HandleChestSpawnSynergy;
		}
		((PassiveItem)this).OnDestroy();
	}

	private void HandleChestSpawnSynergy(PlayerController guy)
	{
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)guy != (Object)null && CustomSynergies.PlayerHasActiveSynergy(guy, "Ultra Mutation") && Random.value <= 0.05f)
		{
			IntVector2 randomVisibleClearSpot = guy.CurrentRoom.GetRandomVisibleClearSpot(2, 2);
			Chest val = GameManager.Instance.RewardManager.SpawnRewardChestAt(randomVisibleClearSpot, -1f, (ItemQuality)(-100));
			val.RegisterChestOnMinimap(((DungeonPlaceableBehaviour)val).GetAbsoluteParentRoom());
		}
	}

	public override void Update()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			currentHP = ((BraveBehaviour)((PassiveItem)this).Owner).healthHaver.GetCurrentHealth();
			currentArmour = ((BraveBehaviour)((PassiveItem)this).Owner).healthHaver.Armor;
			currentGuns = ((PassiveItem)this).Owner.inventory.AllGuns.Count;
			if (currentHP != lastHP || currentArmour != lastArmour || currentGuns != lastGuns)
			{
				RecalculateShit();
				lastHP = currentHP;
				lastArmour = currentArmour;
				lastGuns = currentGuns;
			}
			if (((PassiveItem)this).Owner.IsInCombat && ((PickupObject)this).CanBeDropped)
			{
				((PickupObject)this).CanBeDropped = false;
			}
			else if (!((PassiveItem)this).Owner.IsInCombat && !((PickupObject)this).CanBeDropped)
			{
				((PickupObject)this).CanBeDropped = true;
			}
		}
		((PassiveItem)this).Update();
	}
}
