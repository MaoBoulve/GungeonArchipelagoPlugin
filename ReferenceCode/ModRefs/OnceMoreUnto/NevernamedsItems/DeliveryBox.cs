using System.Collections.Generic;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

internal class DeliveryBox : PlayerItem, ILabelItem
{
	public enum ConsumableType
	{
		KEY,
		BLANK,
		AMMO,
		SPREAD_AMMO,
		ARMOR,
		HEART,
		HALF_HEART,
		GLASS_GUON_STONE
	}

	private Dictionary<ConsumableType, int> spriteDefDictionary = new Dictionary<ConsumableType, int>
	{
		{
			ConsumableType.BLANK,
			8
		},
		{
			ConsumableType.AMMO,
			1
		},
		{
			ConsumableType.SPREAD_AMMO,
			2
		},
		{
			ConsumableType.ARMOR,
			3
		},
		{
			ConsumableType.HALF_HEART,
			4
		},
		{
			ConsumableType.HEART,
			5
		},
		{
			ConsumableType.KEY,
			6
		},
		{
			ConsumableType.GLASS_GUON_STONE,
			7
		}
	};

	private Dictionary<ConsumableType, int> consumableIDDictionary = new Dictionary<ConsumableType, int>
	{
		{
			ConsumableType.BLANK,
			224
		},
		{
			ConsumableType.AMMO,
			78
		},
		{
			ConsumableType.SPREAD_AMMO,
			600
		},
		{
			ConsumableType.ARMOR,
			120
		},
		{
			ConsumableType.HALF_HEART,
			73
		},
		{
			ConsumableType.HEART,
			85
		},
		{
			ConsumableType.KEY,
			67
		},
		{
			ConsumableType.GLASS_GUON_STONE,
			565
		}
	};

	private string currentLabel;

	public ConsumableType CurrentConsumable;

	private static int[] spriteIDs;

	public static void Init()
	{
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<DeliveryBox>("Delivery Box", "Ready To Order", "Allows for the high-speed delivery of goods purchased straight from the manufacturer!\n\nCut out the middle man!", "deliverybox_closed", assetbundle: true);
		PlayerItem val = (PlayerItem)(object)((obj is PlayerItem) ? obj : null);
		ItemBuilder.SetCooldownType(val, (CooldownType)0, 0.2f);
		spriteIDs = new int[9];
		spriteIDs[0] = ((BraveBehaviour)val).sprite.spriteId;
		spriteIDs[1] = Initialisation.itemCollection.GetSpriteIdByName("deliverybox_ammo");
		spriteIDs[2] = Initialisation.itemCollection.GetSpriteIdByName("deliverybox_spreadammo");
		spriteIDs[3] = Initialisation.itemCollection.GetSpriteIdByName("deliverybox_armour");
		spriteIDs[4] = Initialisation.itemCollection.GetSpriteIdByName("deliverybox_halfheart");
		spriteIDs[5] = Initialisation.itemCollection.GetSpriteIdByName("deliverybox_heart");
		spriteIDs[6] = Initialisation.itemCollection.GetSpriteIdByName("deliverybox_key");
		spriteIDs[7] = Initialisation.itemCollection.GetSpriteIdByName("deliverybox_glassguon");
		spriteIDs[8] = Initialisation.itemCollection.GetSpriteIdByName("deliverybox_blank");
		val.consumable = false;
		((PickupObject)val).quality = (ItemQuality)3;
	}

	public string GetLabel()
	{
		return currentLabel;
	}

	public override void Pickup(PlayerController player)
	{
		currentLabel = "-1";
		if (!base.m_pickedUpThisRun)
		{
			SetConsumableTo(RandomConsumable());
		}
		else
		{
			SetConsumableTo(CurrentConsumable);
		}
		((PlayerItem)this).Pickup(player);
	}

	public override void OnPreDrop(PlayerController user)
	{
		((BraveBehaviour)this).sprite.SetSprite(spriteIDs[0]);
		((PlayerItem)this).OnPreDrop(user);
	}

	public override void DoEffect(PlayerController user)
	{
		PlayerConsumables carriedConsumables = user.carriedConsumables;
		carriedConsumables.Currency -= CalculatePrice(CurrentConsumable);
		SpawnCrate(consumableIDDictionary[CurrentConsumable]);
		SetConsumableTo(RandomConsumable());
	}

	public override void Update()
	{
		if (!string.IsNullOrEmpty(currentLabel) && int.Parse(currentLabel) != CalculatePrice(CurrentConsumable))
		{
			currentLabel = CalculatePrice(CurrentConsumable).ToString();
		}
		((PlayerItem)this).Update();
	}

	private int CalculatePrice(ConsumableType consumable)
	{
		if (consumableIDDictionary.ContainsKey(consumable))
		{
			PickupObject byId = PickupObjectDatabase.GetById(consumableIDDictionary[consumable]);
			if ((Object)(object)byId != (Object)null)
			{
				float num = byId.PurchasePrice;
				if (Object.op_Implicit((Object)(object)base.LastOwner))
				{
					num *= base.LastOwner.stats.GetStatValue((StatType)13);
					return Mathf.RoundToInt(num);
				}
				return Mathf.RoundToInt(num);
			}
			return 420;
		}
		return 69;
	}

	private void SpawnCrate(int item)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		IntVector2 bestRewardLocation = base.LastOwner.CurrentRoom.GetBestRewardLocation(new IntVector2(1, 1), (RewardLocationStyle)0, true);
		SupplyDropDoer.SpawnSupplyDrop(((IntVector2)(ref bestRewardLocation)).ToVector2(), item, -1f, false);
	}

	private ConsumableType RandomConsumable()
	{
		return RandomEnum<ConsumableType>.Get();
	}

	private void SetConsumableTo(ConsumableType consumable)
	{
		if (spriteDefDictionary.ContainsKey(consumable))
		{
			((BraveBehaviour)this).sprite.SetSprite(spriteIDs[spriteDefDictionary[consumable]]);
		}
		else
		{
			((BraveBehaviour)this).sprite.SetSprite(spriteIDs[0]);
		}
		CurrentConsumable = consumable;
	}

	public override bool CanBeUsed(PlayerController user)
	{
		if (Object.op_Implicit((Object)(object)user) && user.carriedConsumables.Currency >= CalculatePrice(CurrentConsumable))
		{
			return true;
		}
		return false;
	}
}
