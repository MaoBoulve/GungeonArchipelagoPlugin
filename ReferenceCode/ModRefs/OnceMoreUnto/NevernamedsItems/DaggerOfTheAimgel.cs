using Alexandria.ItemAPI;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class DaggerOfTheAimgel : PlayerItem
{
	public static void Init()
	{
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<DaggerOfTheAimgel>("Dagger of The Aimgels", "Sacrifices Must Be Made", "Plunging this dagger into your flesh has irreversible side effects, but it also imbues within you with the rage of a thousand corrupted Aimgels, fallen from Bullet Heaven.", "daggeroftheaimgel_icon", assetbundle: true);
		PlayerItem val = (PlayerItem)(object)((obj is PlayerItem) ? obj : null);
		ItemBuilder.SetCooldownType(val, (CooldownType)0, 5f);
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)val, (StatType)14, 1f, (ModifyMethod)0);
		val.consumable = false;
		((PickupObject)val).quality = (ItemQuality)3;
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)2, 1f);
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.USEDFALLENANGELSHRINE, requiredFlagValue: true);
	}

	public override void DoEffect(PlayerController user)
	{
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected O, but got Unknown
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		AkSoundEngine.PostEvent("Play_VO_lichA_cackle_01", ((Component)this).gameObject);
		if (user.ForceZeroHealthState)
		{
			HealthHaver healthHaver = ((BraveBehaviour)user).healthHaver;
			healthHaver.Armor -= 2f;
		}
		else
		{
			StatModifier item = new StatModifier
			{
				amount = -1f,
				statToBoost = (StatType)3,
				modifyType = (ModifyMethod)0
			};
			user.ownerlessStatModifiers.Add(item);
		}
		StatModifier item2 = new StatModifier
		{
			amount = 1.5f,
			statToBoost = (StatType)14,
			modifyType = (ModifyMethod)0
		};
		StatModifier item3 = new StatModifier
		{
			amount = 1.2f,
			statToBoost = (StatType)5,
			modifyType = (ModifyMethod)1
		};
		user.ownerlessStatModifiers.Add(item3);
		user.ownerlessStatModifiers.Add(item2);
		user.stats.RecalculateStats(user, false, false);
	}

	public override bool CanBeUsed(PlayerController user)
	{
		if (user.ForceZeroHealthState)
		{
			return ((BraveBehaviour)user).healthHaver.Armor > 2f;
		}
		return ((BraveBehaviour)user).healthHaver.GetMaxHealth() > 1f;
	}
}
