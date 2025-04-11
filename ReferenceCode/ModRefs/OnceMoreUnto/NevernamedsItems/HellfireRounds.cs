using System;
using System.Collections.Generic;
using System.Linq;
using Alexandria.ItemAPI;

namespace NevernamedsItems;

public class HellfireRounds : PassiveItem
{
	public float currentDamageMod = 1f;

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<HellfireRounds>("Hellfire Rounds", "Lead and Brimstone", "These bullets hit harder the closer they get to the fires of Bullet Hell.\n\nMany years ago, the red flames of the pit were used one single time to soften metal for the Blacksmith's anvil. That was a bad idea.", "hellfirerounds_new", assetbundle: true);
		val.quality = (ItemQuality)5;
		AlexandriaTags.SetTag(val, "bullet_modifier");
		Doug.AddToLootPool(val.PickupObjectId);
	}

	private void OnNewFloor()
	{
		CalculateStats();
	}

	private void CalculateStats()
	{
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Invalid comparison between Unknown and I4
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Invalid comparison between Unknown and I4
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Invalid comparison between Unknown and I4
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Invalid comparison between Unknown and I4
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Invalid comparison between Unknown and I4
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Invalid comparison between Unknown and I4
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Expected I4, but got Unknown
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Invalid comparison between Unknown and I4
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Invalid comparison between Unknown and I4
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Invalid comparison between Unknown and I4
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Invalid comparison between Unknown and I4
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Invalid comparison between Unknown and I4
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Invalid comparison between Unknown and I4
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Invalid comparison between Unknown and I4
		try
		{
			RemoveStat((StatType)5);
			((PassiveItem)this).Owner.stats.RecalculateStats(((PassiveItem)this).Owner, true, false);
			float amount = 1f;
			PlayerController owner = ((PassiveItem)this).Owner;
			bool flag = false;
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
							flag = true;
							amount = 1.207f;
						}
						break;
					case 1:
						amount = 1.083f;
						flag = true;
						break;
					case 3:
						flag = true;
						amount = 1.124f;
						break;
					case 0:
						flag = true;
						amount = 1.166f;
						break;
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
							flag = true;
							amount = 1.415f;
						}
					}
					else
					{
						flag = true;
						amount = 1.332f;
					}
				}
				else
				{
					flag = true;
					amount = 1.249f;
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
							flag = true;
							amount = 1.373f;
						}
					}
					else
					{
						flag = true;
						amount = 1.373f;
					}
				}
				else
				{
					flag = true;
					amount = 1.5f;
				}
			}
			else if ((int)val != 4096)
			{
				if ((int)val != 8192)
				{
					if ((int)val == 32768)
					{
						flag = true;
						amount = 1.29f;
					}
				}
				else
				{
					flag = true;
					amount = 1.124f;
				}
			}
			else
			{
				flag = true;
				amount = 1.207f;
			}
			if (!flag)
			{
				amount = currentDamageMod + 0.083f;
			}
			AddStat((StatType)5, amount, (ModifyMethod)1);
			((PassiveItem)this).Owner.stats.RecalculateStats(((PassiveItem)this).Owner, true, false);
			currentDamageMod = amount;
		}
		catch (Exception ex)
		{
			ETGModConsole.Log((object)ex.Message, false);
			ETGModConsole.Log((object)ex.StackTrace, false);
		}
	}

	public override void Pickup(PlayerController player)
	{
		GameManager.Instance.OnNewLevelFullyLoaded += CalculateStats;
		((PassiveItem)this).Pickup(player);
		CalculateStats();
	}

	public override DebrisObject Drop(PlayerController player)
	{
		DebrisObject result = ((PassiveItem)this).Drop(player);
		GameManager.Instance.OnNewLevelFullyLoaded -= CalculateStats;
		return result;
	}

	public override void OnDestroy()
	{
		GameManager.Instance.OnNewLevelFullyLoaded -= CalculateStats;
		((PassiveItem)this).OnDestroy();
	}

	private void AddStat(StatType statType, float amount, ModifyMethod method = 0)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected O, but got Unknown
		StatModifier val = new StatModifier
		{
			amount = amount,
			statToBoost = statType,
			modifyType = method
		};
		if (base.passiveStatModifiers == null)
		{
			base.passiveStatModifiers = (StatModifier[])(object)new StatModifier[1] { val };
		}
		else
		{
			base.passiveStatModifiers = base.passiveStatModifiers.Concat((IEnumerable<StatModifier>)(object)new StatModifier[1] { val }).ToArray();
		}
	}

	private void RemoveStat(StatType statType)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		List<StatModifier> list = new List<StatModifier>();
		for (int i = 0; i < base.passiveStatModifiers.Length; i++)
		{
			if (base.passiveStatModifiers[i].statToBoost != statType)
			{
				list.Add(base.passiveStatModifiers[i]);
			}
		}
		base.passiveStatModifiers = list.ToArray();
	}
}
