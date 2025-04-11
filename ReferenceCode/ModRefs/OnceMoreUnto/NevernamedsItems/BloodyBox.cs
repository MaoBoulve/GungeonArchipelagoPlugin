using Alexandria.ItemAPI;
using Dungeonator;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class BloodyBox : PlayerItem
{
	public static void Init()
	{
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<BloodyBox>("Bloody Box", "Oozing and Gurgling", "Sacrifice blood to the gods of infinity, in return for a chest.\n\nA neatly layered series of chests, emerging upwards infinitely from the gaping maw of the eternal void. The screaming voices from the abyss rattle up through the tower, and they demand sustenance.", "bloodybox_icon2", assetbundle: true);
		PlayerItem val = (PlayerItem)(object)((obj is PlayerItem) ? obj : null);
		ItemBuilder.SetCooldownType(val, (CooldownType)0, 5f);
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)val, (StatType)14, 1f, (ModifyMethod)0);
		val.consumable = false;
		((PickupObject)val).quality = (ItemQuality)3;
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)1, 1f);
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.KILLEDJAMMEDMIMIC, requiredFlagValue: true);
	}

	public override void DoEffect(PlayerController user)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		IntVector2 bestRewardLocation = user.CurrentRoom.GetBestRewardLocation(IntVector2.One * 3, (RewardLocationStyle)1, true);
		AkSoundEngine.PostEvent("Play_VO_lichA_cackle_01", ((Component)this).gameObject);
		Chest val = GameManager.Instance.RewardManager.SpawnTotallyRandomChest(bestRewardLocation);
		val.RegisterChestOnMinimap(((DungeonPlaceableBehaviour)val).GetAbsoluteParentRoom());
		if (user.ForceZeroHealthState)
		{
			((BraveBehaviour)user).healthHaver.Armor = ((BraveBehaviour)user).healthHaver.Armor - 2f;
		}
		else
		{
			((BraveBehaviour)user).healthHaver.ApplyHealing(-2.5f);
		}
	}

	public override bool CanBeUsed(PlayerController user)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		PlayableCharacters characterIdentity = user.characterIdentity;
		if (user.ForceZeroHealthState)
		{
			return ((BraveBehaviour)user).healthHaver.Armor > 2f;
		}
		return ((BraveBehaviour)user).healthHaver.GetCurrentHealth() > 2.5f;
	}
}
