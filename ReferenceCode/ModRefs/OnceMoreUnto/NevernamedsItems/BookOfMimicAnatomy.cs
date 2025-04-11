using System;
using System.Collections.Generic;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class BookOfMimicAnatomy : PassiveItem
{
	private List<string> mimicGuids = new List<string> { "2ebf8ef6728648089babb507dec4edb7", "d8d651e3484f471ba8a2daa4bf535ce6", "abfb454340294a0992f4173d6e5898a8", "d8fd592b184b4ac9a3be217bc70912a2", "ac9d345575444c9a8d11b799e8719be0", "6450d20137994881aff0ddd13e3d40c8", "479556d05c7c44f3b6abb3b2067fc778" };

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<BookOfMimicAnatomy>("Book of Mimic Anatomy", "Look closer...", "This book, while bound and covered identically to the Book of Chest Anatomy, is in fact a much more interesting tome on the anatomy of the creature known as the Mimic.\n\nIt appears to be a sequel to the Book of Chest Anatomy from the same author, which is good ‘cause that one left off on a cliffhanger.", "bookofmimicanatomy_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)4;
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)1, 1f);
	}

	private void OnEnemyDamaged(float damage, bool fatal, HealthHaver enemy)
	{
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0299: Unknown result type (might be due to invalid IL or missing references)
		//IL_029e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0301: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0334: Unknown result type (might be due to invalid IL or missing references)
		//IL_0345: Unknown result type (might be due to invalid IL or missing references)
		//IL_034a: Unknown result type (might be due to invalid IL or missing references)
		//IL_034b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0353: Unknown result type (might be due to invalid IL or missing references)
		//IL_0364: Unknown result type (might be due to invalid IL or missing references)
		//IL_0369: Unknown result type (might be due to invalid IL or missing references)
		//IL_036a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0372: Unknown result type (might be due to invalid IL or missing references)
		//IL_0383: Unknown result type (might be due to invalid IL or missing references)
		//IL_0388: Unknown result type (might be due to invalid IL or missing references)
		//IL_0389: Unknown result type (might be due to invalid IL or missing references)
		//IL_021f: Unknown result type (might be due to invalid IL or missing references)
		//IL_025b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0232: Unknown result type (might be due to invalid IL or missing references)
		//IL_0245: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Unknown result type (might be due to invalid IL or missing references)
		if (!fatal || !Object.op_Implicit((Object)(object)((BraveBehaviour)enemy).aiActor))
		{
			return;
		}
		if (GameStatsManager.Instance.IsRainbowRun && mimicGuids.Contains(((BraveBehaviour)enemy).aiActor.EnemyGuid))
		{
			LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetById(120)).gameObject, Vector2.op_Implicit(((BraveBehaviour)enemy).specRigidbody.UnitCenter), Vector2.zero, 1f, false, true, false);
			LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetById(120)).gameObject, Vector2.op_Implicit(((BraveBehaviour)enemy).specRigidbody.UnitCenter), Vector2.zero, 1f, false, true, false);
			LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetById(120)).gameObject, Vector2.op_Implicit(((BraveBehaviour)enemy).specRigidbody.UnitCenter), Vector2.zero, 1f, false, true, false);
			return;
		}
		ItemQuality itemQuality = (ItemQuality)1;
		if (((BraveBehaviour)enemy).aiActor.EnemyGuid == "2ebf8ef6728648089babb507dec4edb7")
		{
			itemQuality = (ItemQuality)1;
			SpawnBonusItem(enemy, itemQuality);
		}
		else if (((BraveBehaviour)enemy).aiActor.EnemyGuid == "d8d651e3484f471ba8a2daa4bf535ce6")
		{
			itemQuality = (ItemQuality)2;
			SpawnBonusItem(enemy, itemQuality);
		}
		else if (((BraveBehaviour)enemy).aiActor.EnemyGuid == "abfb454340294a0992f4173d6e5898a8")
		{
			itemQuality = (ItemQuality)3;
			SpawnBonusItem(enemy, itemQuality);
		}
		else if (((BraveBehaviour)enemy).aiActor.EnemyGuid == "d8fd592b184b4ac9a3be217bc70912a2" || ((BraveBehaviour)enemy).aiActor.EnemyGuid == "ac9d345575444c9a8d11b799e8719be0")
		{
			itemQuality = (ItemQuality)4;
			SpawnBonusItem(enemy, itemQuality);
		}
		else if (((BraveBehaviour)enemy).aiActor.EnemyGuid == "6450d20137994881aff0ddd13e3d40c8")
		{
			itemQuality = (ItemQuality)5;
			SpawnBonusItem(enemy, itemQuality);
		}
		else if (((BraveBehaviour)enemy).aiActor.EnemyGuid == "479556d05c7c44f3b6abb3b2067fc778")
		{
			int num = Random.Range(1, 100);
			if (num <= 50)
			{
				itemQuality = (ItemQuality)1;
			}
			else if (num <= 67)
			{
				itemQuality = (ItemQuality)2;
			}
			else if (num <= 87)
			{
				itemQuality = (ItemQuality)3;
			}
			else if (num <= 98)
			{
				itemQuality = (ItemQuality)4;
			}
			else if (num <= 100)
			{
				itemQuality = (ItemQuality)5;
			}
			SpawnBonusItem(enemy, itemQuality);
		}
		else if (((BraveBehaviour)enemy).aiActor.EnemyGuid == "796a7ed4ad804984859088fc91672c7f")
		{
			LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetById(120)).gameObject, Vector2.op_Implicit(((BraveBehaviour)enemy).specRigidbody.UnitCenter), Vector2.zero, 1f, false, true, false);
			LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetById(120)).gameObject, Vector2.op_Implicit(((BraveBehaviour)enemy).specRigidbody.UnitCenter), Vector2.zero, 1f, false, true, false);
			LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetById(78)).gameObject, Vector2.op_Implicit(((BraveBehaviour)enemy).specRigidbody.UnitCenter), Vector2.zero, 1f, false, true, false);
		}
		else if (((BraveBehaviour)enemy).aiActor.EnemyGuid == "9189f46c47564ed588b9108965f975c9")
		{
			itemQuality = (ItemQuality)5;
			GameManager.Instance.RewardManager.SpawnTotallyRandomItem(((BraveBehaviour)enemy).specRigidbody.UnitCenter, itemQuality, itemQuality);
			itemQuality = (ItemQuality)4;
			GameManager.Instance.RewardManager.SpawnTotallyRandomItem(((BraveBehaviour)enemy).specRigidbody.UnitCenter, itemQuality, itemQuality);
			itemQuality = (ItemQuality)3;
			GameManager.Instance.RewardManager.SpawnTotallyRandomItem(((BraveBehaviour)enemy).specRigidbody.UnitCenter, itemQuality, itemQuality);
		}
	}

	private void SpawnBonusItem(HealthHaver enemy, ItemQuality itemQuality)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		GameManager.Instance.RewardManager.SpawnTotallyRandomItem(((BraveBehaviour)enemy).specRigidbody.UnitCenter, itemQuality, itemQuality);
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		player.OnAnyEnemyReceivedDamage = (Action<float, bool, HealthHaver>)Delegate.Combine(player.OnAnyEnemyReceivedDamage, new Action<float, bool, HealthHaver>(OnEnemyDamaged));
	}

	public override void DisableEffect(PlayerController player)
	{
		if (Object.op_Implicit((Object)(object)player))
		{
			player.OnAnyEnemyReceivedDamage = (Action<float, bool, HealthHaver>)Delegate.Remove(player.OnAnyEnemyReceivedDamage, new Action<float, bool, HealthHaver>(OnEnemyDamaged));
		}
		((PassiveItem)this).DisableEffect(player);
	}
}
