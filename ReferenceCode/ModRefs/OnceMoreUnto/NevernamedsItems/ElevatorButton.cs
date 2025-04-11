using System;
using Alexandria.ChestAPI;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Dungeonator;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

internal class ElevatorButton : PlayerItem
{
	public bool goUp;

	public static void Init()
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<ElevatorButton>("Elevator Button", "Going... Down", "Transports the user to the next floor. One use.\n\nMay malfunction.", "elevatorbutton_improved", assetbundle: true);
		PlayerItem val = (PlayerItem)(object)((obj is PlayerItem) ? obj : null);
		ItemBuilder.SetCooldownType(val, (CooldownType)3, 1000f);
		val.consumable = true;
		((PickupObject)val).quality = (ItemQuality)1;
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)3, 1f);
	}

	public override void DoEffect(PlayerController user)
	{
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Invalid comparison between Unknown and I4
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Invalid comparison between Unknown and I4
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Invalid comparison between Unknown and I4
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Invalid comparison between Unknown and I4
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Invalid comparison between Unknown and I4
		//IL_01fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0202: Invalid comparison between Unknown and I4
		//IL_0255: Unknown result type (might be due to invalid IL or missing references)
		//IL_025c: Invalid comparison between Unknown and I4
		//IL_02af: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b9: Invalid comparison between Unknown and I4
		//IL_030c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0313: Invalid comparison between Unknown and I4
		//IL_0366: Unknown result type (might be due to invalid IL or missing references)
		//IL_0370: Invalid comparison between Unknown and I4
		//IL_03c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ca: Invalid comparison between Unknown and I4
		//IL_041d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0427: Invalid comparison between Unknown and I4
		//IL_047a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0484: Invalid comparison between Unknown and I4
		//IL_04e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ba: Unknown result type (might be due to invalid IL or missing references)
		if (user.HasPickupID(Game.Items["space_friend"].PickupObjectId))
		{
			goUp = true;
		}
		else if ((double)Random.value > 0.05)
		{
			goUp = false;
		}
		else
		{
			goUp = true;
		}
		if ((int)GameManager.Instance.Dungeon.tileIndices.tilesetId == 2)
		{
			GameManager.Instance.LoadCustomLevel("tt5");
		}
		else if ((int)GameManager.Instance.Dungeon.tileIndices.tilesetId == 4)
		{
			if (!goUp)
			{
				GameManager.Instance.LoadCustomLevel("tt5");
			}
			else
			{
				GameManager.Instance.LoadCustomLevel("tt_castle");
			}
		}
		else if ((int)GameManager.Instance.Dungeon.tileIndices.tilesetId == 8192)
		{
			if (!goUp)
			{
				GameManager.Instance.LoadCustomLevel("tt5");
			}
			else
			{
				GameManager.Instance.LoadCustomLevel("tt_castle");
			}
		}
		else if ((int)GameManager.Instance.Dungeon.tileIndices.tilesetId == 4096)
		{
			if (!goUp)
			{
				GameManager.Instance.LoadCustomLevel("tt_mines");
			}
			else
			{
				GameManager.Instance.LoadCustomLevel("tt5");
			}
		}
		else if ((int)GameManager.Instance.Dungeon.tileIndices.tilesetId == 1)
		{
			if (!goUp)
			{
				GameManager.Instance.LoadCustomLevel("tt_mines");
			}
			else
			{
				GameManager.Instance.LoadCustomLevel("tt_castle");
			}
		}
		else if ((int)GameManager.Instance.Dungeon.tileIndices.tilesetId == 8)
		{
			if (!goUp)
			{
				GameManager.Instance.LoadCustomLevel("tt_mines");
			}
			else
			{
				GameManager.Instance.LoadCustomLevel("tt5");
			}
		}
		else if ((int)GameManager.Instance.Dungeon.tileIndices.tilesetId == 16)
		{
			if (!goUp)
			{
				GameManager.Instance.LoadCustomLevel("tt_catacombs");
			}
			else
			{
				GameManager.Instance.LoadCustomLevel("tt5");
			}
		}
		else if ((int)GameManager.Instance.Dungeon.tileIndices.tilesetId == 32768)
		{
			if (!goUp)
			{
				GameManager.Instance.LoadCustomLevel("tt_catacombs");
			}
			else
			{
				GameManager.Instance.LoadCustomLevel("tt_mines");
			}
		}
		else if ((int)GameManager.Instance.Dungeon.tileIndices.tilesetId == 32)
		{
			if (!goUp)
			{
				GameManager.Instance.LoadCustomLevel("tt_forge");
			}
			else
			{
				GameManager.Instance.LoadCustomLevel("tt_mines");
			}
		}
		else if ((int)GameManager.Instance.Dungeon.tileIndices.tilesetId == 2048)
		{
			if (!goUp)
			{
				GameManager.Instance.LoadCustomLevel("tt_forge");
			}
			else
			{
				GameManager.Instance.LoadCustomLevel("tt_catacombs");
			}
		}
		else if ((int)GameManager.Instance.Dungeon.tileIndices.tilesetId == 64)
		{
			if (!goUp)
			{
				GameManager.Instance.LoadCustomLevel("tt_bullethell");
			}
			else
			{
				GameManager.Instance.LoadCustomLevel("tt_catacombs");
			}
		}
		else if ((int)GameManager.Instance.Dungeon.tileIndices.tilesetId == 1024)
		{
			if (!goUp)
			{
				GameManager.Instance.LoadCustomLevel("tt_bullethell");
			}
			else
			{
				GameManager.Instance.LoadCustomLevel("tt_catacombs");
			}
		}
		else if ((int)GameManager.Instance.Dungeon.tileIndices.tilesetId == 128)
		{
			if (!goUp)
			{
				Exploder.DoDefaultExplosion(Vector2.op_Implicit(((BraveBehaviour)base.LastOwner).specRigidbody.UnitCenter), default(Vector2), (Action)null, false, (CoreDamageTypes)0, false);
			}
			else
			{
				GameManager.Instance.LoadCustomLevel("tt_forge");
			}
		}
		else
		{
			ChestUtility.SpawnChestEasy(user.CurrentRoom.GetBestRewardLocation(IntVector2.One * 3, (RewardLocationStyle)1, true), (ChestTier)5, false, (GeneralChestType)0, (ThreeStateValue)2, (ThreeStateValue)2);
		}
	}
}
