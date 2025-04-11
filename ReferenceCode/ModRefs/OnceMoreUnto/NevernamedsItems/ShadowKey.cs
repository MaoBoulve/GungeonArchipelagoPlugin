using Alexandria.ChestAPI;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

internal class ShadowKey : PlayerItem
{
	public static void Init()
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<ShadowKey>("Shadow Key", "Dark Realmed", "Duplicates a chest. One use.\n\nRecovered from a mysterious chest in a far off dungeon, this key is capable of turning a chest's shadow into an exact duplicate of the original.", "shadowkey_icon", assetbundle: true);
		PlayerItem val = (PlayerItem)(object)((obj is PlayerItem) ? obj : null);
		ItemBuilder.SetCooldownType(val, (CooldownType)3, 5f);
		val.consumable = true;
		((PickupObject)val).quality = (ItemQuality)1;
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)1, 1f);
	}

	public override void DoEffect(PlayerController user)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Invalid comparison between Unknown and I4
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Invalid comparison between Unknown and I4
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		IPlayerInteractable nearestInteractable = user.CurrentRoom.GetNearestInteractable(((GameActor)user).CenterPosition, 1f, user);
		if (nearestInteractable is Chest)
		{
			Chest val = (Chest)(object)((nearestInteractable is Chest) ? nearestInteractable : null);
			IntVector2 bestRewardLocation = user.CurrentRoom.GetBestRewardLocation(IntVector2.One * 3, (RewardLocationStyle)1, true);
			ChestTier val2 = ChestUtility.GetChestTier(val);
			if ((int)val2 == 7)
			{
				val2 = (ChestTier)3;
			}
			else if ((int)val2 == 9)
			{
				val2 = (ChestTier)1;
			}
			ThreeStateValue val3 = (ThreeStateValue)2;
			val3 = ((!val.IsMimic) ? ((ThreeStateValue)1) : ((ThreeStateValue)0));
			ThreeStateValue val4 = (ThreeStateValue)2;
			val4 = ((!((Object)(object)ChestUtility.GetFuse(val) != (Object)null)) ? ((ThreeStateValue)1) : ((ThreeStateValue)0));
			Chest val5 = ChestUtility.SpawnChestEasy(bestRewardLocation, val2, val.IsLocked, (GeneralChestType)0, val3, val4);
			if (Object.op_Implicit((Object)(object)((Component)val).GetComponent<JammedChestBehav>()))
			{
				((Component)val5).gameObject.AddComponent<JammedChestBehav>();
			}
			else if (Object.op_Implicit((Object)(object)((Component)val).GetComponent<PassedOverForJammedChest>()))
			{
				((Component)val5).gameObject.AddComponent<PassedOverForJammedChest>();
			}
		}
	}

	public override bool CanBeUsed(PlayerController user)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		IPlayerInteractable nearestInteractable = user.CurrentRoom.GetNearestInteractable(((GameActor)user).CenterPosition, 1f, user);
		if (nearestInteractable is Chest)
		{
			return true;
		}
		return false;
	}
}
