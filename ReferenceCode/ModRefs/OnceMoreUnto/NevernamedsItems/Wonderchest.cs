using System.Collections.Generic;
using Alexandria.ChestAPI;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

internal class Wonderchest : PlayerItem
{
	public static List<ItemQuality> BToSItemTiers = new List<ItemQuality>
	{
		(ItemQuality)3,
		(ItemQuality)4,
		(ItemQuality)5
	};

	public static void Init()
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<Wonderchest>("Wonderchest", "What could be inside?", "Extremely rare chests such as this one were particularly favoured by Alben Smallbore for storing his valuables.\n\nThe complicated magically encripted lock on this thing causes it to access a different pocket subreality depending on where it is opened.", "wonderchest_icon", assetbundle: true);
		PlayerItem val = (PlayerItem)(object)((obj is PlayerItem) ? obj : null);
		ItemBuilder.SetCooldownType(val, (CooldownType)3, 1000f);
		val.consumable = true;
		((PickupObject)val).quality = (ItemQuality)3;
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)1, 1f);
	}

	public override void DoEffect(PlayerController user)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Invalid comparison between Unknown and I4
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Invalid comparison between Unknown and I4
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Invalid comparison between Unknown and I4
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Invalid comparison between Unknown and I4
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Invalid comparison between Unknown and I4
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Invalid comparison between Unknown and I4
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected I4, but got Unknown
		//IL_029b: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_02af: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Invalid comparison between Unknown and I4
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Invalid comparison between Unknown and I4
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Invalid comparison between Unknown and I4
		//IL_05c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_05cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Invalid comparison between Unknown and I4
		//IL_02e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0304: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Invalid comparison between Unknown and I4
		//IL_04a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_045e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0463: Unknown result type (might be due to invalid IL or missing references)
		//IL_0465: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Invalid comparison between Unknown and I4
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Invalid comparison between Unknown and I4
		//IL_01de: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_050a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0348: Unknown result type (might be due to invalid IL or missing references)
		//IL_034d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0359: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0420: Unknown result type (might be due to invalid IL or missing references)
		//IL_0425: Unknown result type (might be due to invalid IL or missing references)
		//IL_042a: Unknown result type (might be due to invalid IL or missing references)
		bool flag = false;
		if (GameManager.Instance.Dungeon.IsGlitchDungeon)
		{
			IntVector2 bestRewardLocation = user.CurrentRoom.GetBestRewardLocation(IntVector2.One * 3, (RewardLocationStyle)1, true);
			ChestUtility.SpawnChestEasy(bestRewardLocation, (ChestTier)4, true, (GeneralChestType)0, (ThreeStateValue)2, (ThreeStateValue)2);
		}
		if (Random.value <= 0.001f)
		{
			IntVector2 bestRewardLocation2 = user.CurrentRoom.GetBestRewardLocation(IntVector2.One * 3, (RewardLocationStyle)1, true);
			ChestUtility.SpawnChestEasy(bestRewardLocation2, (ChestTier)5, false, (GeneralChestType)0, (ThreeStateValue)1, (ThreeStateValue)1);
			return;
		}
		ValidTilesets tilesetId = GameManager.Instance.Dungeon.tileIndices.tilesetId;
		ValidTilesets val = tilesetId;
		if ((int)val <= 64)
		{
			if ((int)val <= 8)
			{
				switch (val - 1)
				{
				default:
					if ((int)val == 8)
					{
						ChangeStatPermanent(user, (StatType)3, 2f, (ModifyMethod)0);
						ChangeStatPermanent(user, (StatType)14, 2f, (ModifyMethod)0);
						if (user.ForceZeroHealthState)
						{
							LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(120)).gameObject, user);
							LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(120)).gameObject, user);
						}
						flag = true;
					}
					break;
				case 1:
				{
					int num = 224;
					if (Random.value <= 0.5f)
					{
						num = 120;
					}
					LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(num)).gameObject, user);
					LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(num)).gameObject, user);
					flag = true;
					break;
				}
				case 3:
				{
					for (int j = 0; j < 3; j++)
					{
						LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(67)).gameObject, user);
					}
					flag = true;
					break;
				}
				case 0:
				{
					for (int i = 0; i < 3; i++)
					{
						LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(74)).gameObject, user);
					}
					flag = true;
					break;
				}
				case 2:
					break;
				}
			}
			else if ((int)val != 16)
			{
				if ((int)val != 32)
				{
					if ((int)val == 64)
					{
						for (int k = 0; k < 6; k++)
						{
							LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(120)).gameObject, user);
						}
						PickupObject itemOfTypeAndQuality = LootEngine.GetItemOfTypeAndQuality<PickupObject>(BraveUtility.RandomElement<ItemQuality>(BToSItemTiers), GameManager.Instance.RewardManager.GunsLootTable, false);
						LootEngine.SpawnItem(((Component)itemOfTypeAndQuality).gameObject, Vector2.op_Implicit(((BraveBehaviour)base.LastOwner).specRigidbody.UnitCenter), Vector2.left, 1f, false, true, false);
						flag = true;
					}
				}
				else
				{
					IntVector2 bestRewardLocation3 = user.CurrentRoom.GetBestRewardLocation(IntVector2.One * 3, (RewardLocationStyle)1, true);
					Chest val2 = GameManager.Instance.RewardManager.SpawnRewardChestAt(bestRewardLocation3, -1f, (ItemQuality)(-100));
					val2.RegisterChestOnMinimap(((DungeonPlaceableBehaviour)val2).GetAbsoluteParentRoom());
					ChangeStatPermanent(user, (StatType)13, 0.8f, (ModifyMethod)1);
					flag = true;
				}
			}
			else
			{
				IntVector2 bestRewardLocation4 = user.CurrentRoom.GetBestRewardLocation(IntVector2.One * 3, (RewardLocationStyle)1, true);
				ChestUtility.SpawnChestEasy(bestRewardLocation4, (ChestTier)3, false, (GeneralChestType)0, (ThreeStateValue)2, (ThreeStateValue)2);
				flag = true;
			}
		}
		else if ((int)val <= 2048)
		{
			if ((int)val != 128)
			{
				if ((int)val != 1024)
				{
					if ((int)val == 2048)
					{
						for (int l = 0; l < 2; l++)
						{
							IntVector2 randomVisibleClearSpot = user.CurrentRoom.GetRandomVisibleClearSpot(2, 2);
							Chest val3 = GameManager.Instance.RewardManager.SpawnRewardChestAt(randomVisibleClearSpot, -1f, (ItemQuality)(-100));
							val3.RegisterChestOnMinimap(((DungeonPlaceableBehaviour)val3).GetAbsoluteParentRoom());
						}
						flag = true;
					}
				}
				else
				{
					LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(727)).gameObject, user);
					LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(137)).gameObject, user);
					flag = true;
				}
			}
			else
			{
				if (GameManager.IsGunslingerPast)
				{
					for (int m = 0; m < 2; m++)
					{
						IntVector2 randomVisibleClearSpot2 = user.CurrentRoom.GetRandomVisibleClearSpot(2, 2);
						ChestUtility.SpawnChestEasy(randomVisibleClearSpot2, (ChestTier)4, true, (GeneralChestType)0, (ThreeStateValue)2, (ThreeStateValue)2);
					}
					ChangeStatPermanent(user, (StatType)14, 5f, (ModifyMethod)0);
				}
				else
				{
					for (int n = 0; n < 2; n++)
					{
						IntVector2 randomVisibleClearSpot3 = user.CurrentRoom.GetRandomVisibleClearSpot(2, 2);
						Chest val4 = GameManager.Instance.RewardManager.SpawnRewardChestAt(randomVisibleClearSpot3, -1f, (ItemQuality)(-100));
						val4.RegisterChestOnMinimap(((DungeonPlaceableBehaviour)val4).GetAbsoluteParentRoom());
					}
					for (int num2 = 0; num2 < 2; num2++)
					{
						IntVector2 randomVisibleClearSpot4 = user.CurrentRoom.GetRandomVisibleClearSpot(2, 2);
						Chest val5 = GameManager.Instance.RewardManager.SpawnTotallyRandomChest(randomVisibleClearSpot4);
						val5.RegisterChestOnMinimap(((DungeonPlaceableBehaviour)val5).GetAbsoluteParentRoom());
					}
					ChangeStatPermanent(user, (StatType)14, 3f, (ModifyMethod)0);
				}
				flag = true;
			}
		}
		else if ((int)val != 4096)
		{
			if ((int)val != 8192)
			{
				if ((int)val == 32768)
				{
					LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(727)).gameObject, user);
					flag = true;
				}
			}
			else
			{
				for (int num3 = 0; num3 < 3; num3++)
				{
					IntVector2 randomVisibleClearSpot5 = user.CurrentRoom.GetRandomVisibleClearSpot(2, 2);
					ChestUtility.SpawnChestEasy(randomVisibleClearSpot5, (ChestTier)0, false, (GeneralChestType)0, (ThreeStateValue)2, (ThreeStateValue)2);
				}
				flag = true;
			}
		}
		else
		{
			ChangeStatPermanent(user, (StatType)3, 1f, (ModifyMethod)0);
			((BraveBehaviour)user).healthHaver.ApplyHealing(100f);
			if (user.ForceZeroHealthState)
			{
				for (int num4 = 0; num4 < 5; num4++)
				{
					LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(120)).gameObject, user);
				}
			}
			flag = true;
		}
		if (!flag)
		{
			LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetById(127)).gameObject, Vector2.op_Implicit(((BraveBehaviour)user).specRigidbody.UnitCenter), Vector2.zero, 1f, false, true, false);
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
