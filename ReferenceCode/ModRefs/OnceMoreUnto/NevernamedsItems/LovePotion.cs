using Alexandria.ItemAPI;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class LovePotion : PlayerItem
{
	public static void Init()
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<LovePotion>("Love Potion", "The Sausage Principle", "This potent potion of love was made by the Three Witches as part of a dashing romantic plot that was doomed to fail\n\nIf you like something, never learn how it was made", "lovepotion_icon", assetbundle: true);
		PlayerItem val = (PlayerItem)(object)((obj is PlayerItem) ? obj : null);
		ItemBuilder.SetCooldownType(val, (CooldownType)1, 150f);
		val.consumable = false;
		((PickupObject)val).quality = (ItemQuality)1;
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)0, 1f);
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)2, 1f);
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.PURCHASED_LOVEPOTION, requiredFlagValue: true);
		((PickupObject)(object)val).AddItemToGooptonMetaShop(10, null);
	}

	public override void DoEffect(PlayerController user)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		float num = 13f;
		float num2 = 2.5f;
		if (CustomSynergies.PlayerHasActiveSynergy(user, "Ooh Eee Ooh Ah Ah!"))
		{
			num = 20f;
			num2 = 4f;
		}
		DeadlyDeadlyGoopManager goopManagerForGoopType = DeadlyDeadlyGoopManager.GetGoopManagerForGoopType(EasyGoopDefinitions.CharmGoopDef);
		Vector2 centerPosition = ((GameActor)user).CenterPosition;
		Vector2 val = Vector3Extensions.XY(user.unadjustedAimPoint) - centerPosition;
		Vector2 normalized = ((Vector2)(ref val)).normalized;
		goopManagerForGoopType.TimedAddGoopLine(((GameActor)user).CenterPosition, ((GameActor)user).CenterPosition + normalized * num, num2, 0.5f);
		if (CustomSynergies.PlayerHasActiveSynergy(user, "Number 9"))
		{
			goopManagerForGoopType.TimedAddGoopLine(((GameActor)user).CenterPosition, ((GameActor)user).CenterPosition + normalized * -1f * num, num2, 0.5f);
		}
	}

	public override bool CanBeUsed(PlayerController user)
	{
		return true;
	}
}
