using System;
using System.Collections.Generic;
using Alexandria.ChestAPI;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

internal class PocketChest : PlayerItem
{
	public enum PocketChestTier
	{
		BROWN,
		BLUE,
		GREEN,
		RED,
		BLACK,
		SYNERGY,
		RAINBOW
	}

	public PocketChestTier MemorisedTier = PocketChestTier.BROWN;

	public float storedDamage = 0f;

	public static List<GeneralChestType> ChestyBois = new List<GeneralChestType>
	{
		(GeneralChestType)2,
		(GeneralChestType)1
	};

	private static int[] spriteIDs;

	public static void Init()
	{
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<PocketChest>("Pocket Chest", "Baby Box", "An infant chest, containing many mysteries.\n\nLevels up as you deal damage, and grows up when used.", "pocketchest_brown_icon", assetbundle: true);
		PlayerItem val = (PlayerItem)(object)((obj is PlayerItem) ? obj : null);
		spriteIDs = new int[7];
		spriteIDs[0] = Initialisation.itemCollection.GetSpriteIdByName("pocketchest_brown_icon");
		spriteIDs[1] = Initialisation.itemCollection.GetSpriteIdByName("pocketchest_blue_icon");
		spriteIDs[2] = Initialisation.itemCollection.GetSpriteIdByName("pocketchest_green_icon");
		spriteIDs[3] = Initialisation.itemCollection.GetSpriteIdByName("pocketchest_red_icon");
		spriteIDs[4] = Initialisation.itemCollection.GetSpriteIdByName("pocketchest_synergy_icon");
		spriteIDs[5] = Initialisation.itemCollection.GetSpriteIdByName("pocketchest_black_icon");
		spriteIDs[6] = Initialisation.itemCollection.GetSpriteIdByName("pocketchest_rainbow_icon");
		ItemBuilder.SetCooldownType(val, (CooldownType)3, 500f);
		val.consumable = true;
		((PickupObject)val).quality = (ItemQuality)1;
	}

	public override void Update()
	{
		if (storedDamage >= 6500f && MemorisedTier == PocketChestTier.RED)
		{
			if (Random.value <= 0.01f)
			{
				MemorisedTier = PocketChestTier.RAINBOW;
				((BraveBehaviour)this).sprite.SetSprite(spriteIDs[6]);
			}
			else
			{
				MemorisedTier = PocketChestTier.BLACK;
				((BraveBehaviour)this).sprite.SetSprite(spriteIDs[5]);
			}
		}
		else if (storedDamage >= 3500f && (MemorisedTier == PocketChestTier.GREEN || MemorisedTier == PocketChestTier.SYNERGY))
		{
			MemorisedTier = PocketChestTier.RED;
			((BraveBehaviour)this).sprite.SetSprite(spriteIDs[3]);
		}
		else if (storedDamage >= 1500f && MemorisedTier == PocketChestTier.BLUE)
		{
			if (Random.value <= 0.25f)
			{
				MemorisedTier = PocketChestTier.SYNERGY;
				((BraveBehaviour)this).sprite.SetSprite(spriteIDs[4]);
			}
			else
			{
				MemorisedTier = PocketChestTier.GREEN;
				((BraveBehaviour)this).sprite.SetSprite(spriteIDs[2]);
			}
		}
		else if (storedDamage >= 500f && MemorisedTier == PocketChestTier.BROWN)
		{
			MemorisedTier = PocketChestTier.BLUE;
			((BraveBehaviour)this).sprite.SetSprite(spriteIDs[1]);
		}
		((PlayerItem)this).Update();
	}

	private void HurtEnemy(float damage, bool fatal, HealthHaver enemy)
	{
		storedDamage += damage;
	}

	public override void Pickup(PlayerController player)
	{
		if (!base.m_pickedUpThisRun)
		{
			MemorisedTier = PocketChestTier.BROWN;
			((BraveBehaviour)this).sprite.SetSprite(spriteIDs[0]);
			storedDamage = 0f;
		}
		((PlayerItem)this).Pickup(player);
		player.OnAnyEnemyReceivedDamage = (Action<float, bool, HealthHaver>)Delegate.Combine(player.OnAnyEnemyReceivedDamage, new Action<float, bool, HealthHaver>(HurtEnemy));
	}

	public override void OnPreDrop(PlayerController user)
	{
		user.OnAnyEnemyReceivedDamage = (Action<float, bool, HealthHaver>)Delegate.Remove(user.OnAnyEnemyReceivedDamage, new Action<float, bool, HealthHaver>(HurtEnemy));
		((PlayerItem)this).OnPreDrop(user);
	}

	public override void DoEffect(PlayerController user)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Invalid comparison between Unknown and I4
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Invalid comparison between Unknown and I4
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Invalid comparison between Unknown and I4
		ChestTier val = (ChestTier)11;
		switch (MemorisedTier)
		{
		case PocketChestTier.BROWN:
			val = (ChestTier)0;
			break;
		case PocketChestTier.BLUE:
			val = (ChestTier)1;
			break;
		case PocketChestTier.GREEN:
			val = (ChestTier)2;
			break;
		case PocketChestTier.RED:
			val = (ChestTier)3;
			break;
		case PocketChestTier.BLACK:
			val = (ChestTier)4;
			break;
		case PocketChestTier.SYNERGY:
			val = (ChestTier)8;
			break;
		case PocketChestTier.RAINBOW:
			val = (ChestTier)5;
			break;
		}
		if ((int)val != 11)
		{
			IntVector2 bestRewardLocation = user.CurrentRoom.GetBestRewardLocation(IntVector2.One * 3, (RewardLocationStyle)1, true);
			ChestUtility.SpawnChestEasy(bestRewardLocation, val, (int)val != 5 && (int)val > 0, (GeneralChestType)0, (ThreeStateValue)2, (ThreeStateValue)2);
		}
	}

	public override bool CanBeUsed(PlayerController user)
	{
		return ((PlayerItem)this).CanBeUsed(user);
	}
}
