using System;
using System.Collections.Generic;
using Alexandria.Misc;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

internal static class JammedChests
{
	private static List<int> LootIDs = new List<int> { 78, 600, 565, 73, 85, 120, 224, 67 };

	public static void Init()
	{
		CustomActions.OnChestPostSpawn = (Action<Chest>)Delegate.Combine(CustomActions.OnChestPostSpawn, new Action<Chest>(PostProcessChest));
		CustomActions.OnChestPreOpen = (Action<Chest, PlayerController>)Delegate.Combine(CustomActions.OnChestPreOpen, new Action<Chest, PlayerController>(ChestPreOpen));
		CustomActions.OnChestBroken = (Action<Chest>)Delegate.Combine(CustomActions.OnChestBroken, new Action<Chest>(OnBroken));
	}

	public static void PostProcessChest(Chest self)
	{
		JammedChestBehav component = ((Component)self).gameObject.GetComponent<JammedChestBehav>();
		PassedOverForJammedChest component2 = ((Component)self).gameObject.GetComponent<PassedOverForJammedChest>();
		if (!((Object)(object)component == (Object)null) || !((Object)(object)component2 == (Object)null))
		{
			return;
		}
		PlayerController val = null;
		if (Object.op_Implicit((Object)(object)GameManager.Instance) && Object.op_Implicit((Object)(object)GameManager.Instance.PrimaryPlayer) && GameManager.Instance.PrimaryPlayer.HasPickupID(CursedTumbler.CursedTumblerID))
		{
			val = GameManager.Instance.PrimaryPlayer;
		}
		else if (Object.op_Implicit((Object)(object)GameManager.Instance) && Object.op_Implicit((Object)(object)GameManager.Instance.SecondaryPlayer) && GameManager.Instance.SecondaryPlayer.HasPickupID(CursedTumbler.CursedTumblerID))
		{
			val = GameManager.Instance.SecondaryPlayer;
		}
		if (!AllJammedState.AllJammedActive && !((Object)(object)val != (Object)null))
		{
			return;
		}
		float num = 0f;
		float num2 = 0f;
		if (Object.op_Implicit((Object)(object)val))
		{
			float statValue = val.stats.GetStatValue((StatType)14);
			num = 0.25f;
			if (statValue >= 10f)
			{
				num = 1f;
			}
			else if (statValue >= 9f)
			{
				num = 0.9f;
			}
			else if (statValue >= 8f)
			{
				num = 0.8f;
			}
			else if (statValue >= 7f)
			{
				num = 0.7f;
			}
			else if (statValue >= 6f)
			{
				num = 0.6f;
			}
			else if (statValue >= 5f)
			{
				num = 0.5f;
			}
			else if (statValue >= 4f)
			{
				num = 0.4f;
			}
			else if (statValue >= 3f)
			{
				num = 0.35f;
			}
			else if (statValue >= 2f)
			{
				num = 0.3f;
			}
		}
		if (AllJammedState.AllJammedActive)
		{
			int totalCurse = PlayerStats.GetTotalCurse();
			num2 = ((totalCurse <= 0) ? 0.1f : ((float)totalCurse * 0.1f));
		}
		float num3 = num2 + num;
		if (Random.value <= num3)
		{
			JammedChestBehav orAddComponent = GameObjectExtensions.GetOrAddComponent<JammedChestBehav>(((Component)self).gameObject);
		}
		else
		{
			GameObjectExtensions.GetOrAddComponent<PassedOverForJammedChest>(((Component)self).gameObject);
		}
	}

	public static void ChestPreOpen(Chest self, PlayerController opener)
	{
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		JammedChestBehav component = ((Component)self).gameObject.GetComponent<JammedChestBehav>();
		if ((Object)(object)component != (Object)null)
		{
			self.PredictContents(opener);
			if (Random.value <= 0.5f)
			{
				List<PickupObject> collection = GenerateContents(self.lootTable, self.breakertronLootTable, opener, 0, new Random());
				self.contents.AddRange(collection);
			}
			else
			{
				int num = BraveUtility.RandomElement<int>(LootIDs);
				PickupObject byId = PickupObjectDatabase.GetById(num);
				self.contents.Add(byId);
			}
		}
		if ((Object)(object)component != (Object)null)
		{
			SaveAPIManager.RegisterStatChange(CustomTrackedStats.JAMMED_CHESTS_OPENED, 1f);
			LootEngine.SpawnCurrency(((BraveBehaviour)self).sprite.WorldCenter, Random.Range(10, 21), false);
			if (Random.value <= 0.25f && ((Object)opener).name != "PlayerShade(Clone)")
			{
				((BraveBehaviour)opener).healthHaver.ApplyDamage(1f, Vector2.zero, "Jammed Chest", (CoreDamageTypes)0, (DamageCategory)0, false, (PixelCollider)null, false);
			}
		}
	}

	public static void OnBroken(Chest self)
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		if (!self.IsOpen && (Object)(object)((Component)self).GetComponent<JammedChestBehav>() != (Object)null)
		{
			LootEngine.SpawnCurrency(((BraveBehaviour)self).sprite.WorldCenter, 10, false);
		}
	}

	private static List<PickupObject> GenerateContents(LootData lootTable, LootData breakertronLootTable, PlayerController player, int tierShift, Random safeRandom = null)
	{
		List<PickupObject> list = new List<PickupObject>();
		if ((Object)(object)lootTable.lootTable == (Object)null)
		{
			list.Add(GameManager.Instance.Dungeon.baseChestContents.SelectByWeight(false).GetComponent<PickupObject>());
		}
		else if (lootTable != null)
		{
			if (tierShift <= -1)
			{
				list = ((!((Object)(object)breakertronLootTable.lootTable != (Object)null)) ? lootTable.GetItemsForPlayer(player, tierShift, (GenericLootTable)null, safeRandom) : breakertronLootTable.GetItemsForPlayer(player, -1, (GenericLootTable)null, safeRandom));
			}
			else
			{
				list = lootTable.GetItemsForPlayer(player, tierShift, (GenericLootTable)null, safeRandom);
				if (lootTable.CompletesSynergy)
				{
					float num = Mathf.Clamp01(0.6f - 0.1f * (float)lootTable.LastGenerationNumSynergiesCalculated);
					num = Mathf.Clamp(num, 0.2f, 1f);
					if (num > 0f)
					{
						float num2 = ((safeRandom == null) ? Random.value : ((float)safeRandom.NextDouble()));
						if (num2 < num)
						{
							lootTable.CompletesSynergy = false;
							list = lootTable.GetItemsForPlayer(player, tierShift, (GenericLootTable)null, safeRandom);
							lootTable.CompletesSynergy = true;
						}
					}
				}
			}
		}
		return list;
	}
}
