using System;
using System.Collections.Generic;
using Alexandria.ItemAPI;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

internal class LibationtoIcosahedrax : PlayerItem
{
	public static List<string> scaryMessages = new List<string>
	{
		"Tarry not, they come for you", "Darkness Shrouds You", "You are Doomed", "Living a Lie", "He comes", "The Dentist is but a servant", "Secret Message", "Doom", "31/07/1715", "Broken",
		"Caused Irreparable Damage", "You will never recover", "Kaliber's Wrath", "Summoned Horror", "Kaliber k'pow uboom k'bhang", "Hope Lost", "Courage Down", "Nobody loves you", "Everything is dead", "Trail of Tears",
		"Is this the real life?", "Is this just fantasy?", "The world is a dark place", "You will never succeed", "The Past is Forgotten", "Who am I?", "Am I Alone?", "Feast Upon Yourself", "The Mistake Holds Secrets", "Prince of Errors",
		"I AM ERROR", "My mind, slipping", "Shall we dance, mortal?", "Arousal", "Clatter of the Bones", "The Jungle is Dark", "Kylius Physicus", "Broken Legacy", "Did you really expect to win?", "All Jammed Mode",
		"Next Hit Kills", "CURSED!!!", "I'm Blue", "Perish", "I love you", "What's going on?...", "I'm scared...", "I feel so alone", "I feel so cold", "Lost and Forgotten",
		"Wrath of Icosahidrax", "Bad Time", "On days like these...", "Fin"
	};

	public static void Init()
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<LibationtoIcosahedrax>("<WIP> Libation to Icosahedrax <WIP>", "Standing Oblation", "This ancient chalice is inscribed with 1, 100, and all the numbers in between. The runes inside the cup constantly ooze 'challenge juice', keeping this offering forever-full.", "libation_icon", assetbundle: true);
		PlayerItem val = (PlayerItem)(object)((obj is PlayerItem) ? obj : null);
		ItemBuilder.SetCooldownType(val, (CooldownType)0, 5f);
		val.consumable = false;
		((PickupObject)val).quality = (ItemQuality)(-100);
	}

	private void MakeKyleDisappointedInMe(int effect)
	{
		string text = null;
		switch (effect)
		{
		case 1:
			text = "1. Wrath of Icosahedrax!";
			break;
		case 2:
			text = "2. Damage Up";
			StatModifierStuff((StatType)5, 1.1f, (ModifyMethod)1);
			break;
		case 3:
			text = "3. Damage Down";
			StatModifierStuff((StatType)5, 0.92f, (ModifyMethod)1);
			break;
		case 4:
			text = "4. Speed Up";
			StatModifierStuff((StatType)0, 1.1f, (ModifyMethod)1);
			break;
		case 5:
			text = "5. Speed Down";
			StatModifierStuff((StatType)0, 0.95f, (ModifyMethod)1);
			break;
		case 6:
			text = "6. Reload Speed Up";
			StatModifierStuff((StatType)10, 0.9f, (ModifyMethod)1);
			break;
		case 7:
			text = "7. Reload Speed Down";
			StatModifierStuff((StatType)10, 1.08f, (ModifyMethod)1);
			break;
		case 8:
			text = "8. Accuracy Up";
			StatModifierStuff((StatType)2, 0.9f, (ModifyMethod)1);
			break;
		case 9:
			text = "9. Accuracy Down";
			StatModifierStuff((StatType)2, 1.08f, (ModifyMethod)1);
			break;
		case 10:
			text = "10. Active Item Storage Up";
			StatModifierStuff((StatType)8, 1f, (ModifyMethod)0);
			break;
		case 11:
			text = "11. Active Item Storage Down";
			StatModifierStuff((StatType)8, -1f, (ModifyMethod)0);
			break;
		case 12:
			text = "12. Clip Size Up";
			StatModifierStuff((StatType)16, 1.1f, (ModifyMethod)1);
			break;
		case 13:
			text = "13. Clip Size Down";
			StatModifierStuff((StatType)16, 0.92f, (ModifyMethod)1);
			break;
		case 14:
			text = "14. Ammo Capacity Up";
			StatModifierStuff((StatType)9, 1.1f, (ModifyMethod)1);
			break;
		case 15:
			text = "15. Ammo Capacity Down";
			StatModifierStuff((StatType)9, 0.92f, (ModifyMethod)1);
			break;
		case 16:
			text = "16. Charge Speed Up";
			StatModifierStuff((StatType)25, 1.1f, (ModifyMethod)1);
			break;
		case 17:
			text = "17. Charge Speed Down";
			StatModifierStuff((StatType)25, 0.92f, (ModifyMethod)1);
			break;
		case 18:
			text = "18. Cool-dude-ify!";
			StatModifierStuff((StatType)4, 1f, (ModifyMethod)0);
			break;
		case 19:
			text = "19. Uncool...";
			StatModifierStuff((StatType)4, -1f, (ModifyMethod)0);
			break;
		case 20:
			text = "20. Cursed!";
			StatModifierStuff((StatType)14, 1f, (ModifyMethod)0);
			break;
		case 21:
			text = "21. Cleansed";
			StatModifierStuff((StatType)14, -1f, (ModifyMethod)0);
			break;
		case 22:
			text = "22. Damage To Bosses Up";
			StatModifierStuff((StatType)22, 1.1f, (ModifyMethod)1);
			break;
		case 23:
			text = "23. Damage To Bosses Down";
			StatModifierStuff((StatType)22, 0.92f, (ModifyMethod)1);
			break;
		case 24:
			text = "24. Dodge Roll Damage Up";
			StatModifierStuff((StatType)21, 1.1f, (ModifyMethod)1);
			break;
		case 25:
			text = "25. Dodge Roll Damage Down";
			StatModifierStuff((StatType)21, 0.92f, (ModifyMethod)1);
			break;
		case 26:
			text = "26. Dodge Roll Speed Up";
			StatModifierStuff((StatType)28, 1.1f, (ModifyMethod)1);
			break;
		case 27:
			text = "27. Dodge Roll Speed Down";
			StatModifierStuff((StatType)28, 0.92f, (ModifyMethod)1);
			break;
		case 28:
			text = "28. Enemy Bullets Hastened";
			StatModifierStuff((StatType)23, 1.08f, (ModifyMethod)1);
			break;
		case 29:
			text = "29. Enemy Bullets Slowed";
			StatModifierStuff((StatType)23, 0.9f, (ModifyMethod)1);
			break;
		case 30:
			text = "30. Prices Lowered";
			StatModifierStuff((StatType)13, 0.9f, (ModifyMethod)1);
			break;
		case 31:
			text = "31. Prices Raised";
			StatModifierStuff((StatType)13, 1.08f, (ModifyMethod)1);
			break;
		case 32:
			text = "32. Knockback Up";
			StatModifierStuff((StatType)12, 1.1f, (ModifyMethod)1);
			break;
		case 33:
			text = "33. Knockback Down";
			StatModifierStuff((StatType)12, 0.92f, (ModifyMethod)1);
			break;
		case 34:
			text = "34. Bullet Speed Up";
			StatModifierStuff((StatType)6, 1.1f, (ModifyMethod)1);
			break;
		case 35:
			text = "35. Bullet Speed Down";
			StatModifierStuff((StatType)6, 0.92f, (ModifyMethod)1);
			break;
		case 36:
			text = "36. Bullet Size Up";
			StatModifierStuff((StatType)15, 1.1f, (ModifyMethod)1);
			break;
		case 37:
			text = "37. Bullet Size Down";
			StatModifierStuff((StatType)15, 0.92f, (ModifyMethod)1);
			break;
		case 38:
			text = "38. Range Up";
			StatModifierStuff((StatType)26, 1.1f, (ModifyMethod)1);
			break;
		case 39:
			text = "39. Range Down";
			StatModifierStuff((StatType)26, 0.92f, (ModifyMethod)1);
			break;
		case 40:
			text = "40. Rate of Fire Up";
			StatModifierStuff((StatType)1, 1.1f, (ModifyMethod)1);
			break;
		case 41:
			text = "41. Rate of Fire Down";
			StatModifierStuff((StatType)1, 0.92f, (ModifyMethod)1);
			break;
		case 42:
			text = "42. Throwing Damage Up";
			StatModifierStuff((StatType)20, 1.1f, (ModifyMethod)1);
			break;
		case 43:
			text = "43. Health Up";
			StatModifierStuff((StatType)3, 1f, (ModifyMethod)0);
			break;
		case 44:
			text = "44. Health Down";
			StatModifierStuff((StatType)3, -1f, (ModifyMethod)0);
			break;
		case 45:
			text = null;
			ItemGiver(127, Random.Range(1, 5), "45. Junked");
			break;
		case 46:
			text = null;
			ItemGiver(565, Random.Range(1, 4), "46. Glassed");
			break;
		case 47:
			text = "47. " + BraveUtility.RandomElement<string>(scaryMessages);
			break;
		case 48:
			text = "58. Rewarded!";
			SpawnChest();
			break;
		case 49:
			text = "59. Paid";
			GiveConsumable(68, Random.Range(10, 45));
			break;
		}
		if (text != null)
		{
			Notify(text, "");
		}
	}

	private void GiveConsumable(int id, int amount)
	{
		if (amount > 0)
		{
			LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(id)).gameObject, base.LastOwner);
		}
	}

	private void SpawnChest()
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		IntVector2 bestRewardLocation = base.LastOwner.CurrentRoom.GetBestRewardLocation(IntVector2.One * 3, (RewardLocationStyle)1, true);
		Chest val = GameManager.Instance.RewardManager.SpawnRewardChestAt(bestRewardLocation, -1f, (ItemQuality)(-100));
		val.RegisterChestOnMinimap(((DungeonPlaceableBehaviour)val).GetAbsoluteParentRoom());
	}

	private void ItemGiver(int itemID, int amount, string notifyText)
	{
		if (notifyText != null)
		{
			Notify(notifyText, "");
		}
		for (int i = 0; i < amount; i++)
		{
			LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(itemID)).gameObject, base.LastOwner);
		}
	}

	private void StatModifierStuff(StatType stat, float amount, ModifyMethod modifyType)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Invalid comparison between Unknown and I4
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Expected O, but got Unknown
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Expected O, but got Unknown
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		if ((int)modifyType == 1)
		{
			StatModifier val = new StatModifier();
			val.amount = amount;
			val.modifyType = modifyType;
			val.statToBoost = stat;
			base.LastOwner.ownerlessStatModifiers.Add(val);
			base.LastOwner.stats.RecalculateStats(base.LastOwner, false, false);
		}
		else if (amount < 0f)
		{
			if (amount * amount <= base.LastOwner.stats.GetStatValue(stat))
			{
				StatModifier val2 = new StatModifier();
				val2.amount = amount;
				val2.modifyType = modifyType;
				val2.statToBoost = stat;
				base.LastOwner.ownerlessStatModifiers.Add(val2);
				base.LastOwner.stats.RecalculateStats(base.LastOwner, false, false);
			}
		}
		else
		{
			StatModifier val3 = new StatModifier();
			val3.amount = amount;
			val3.modifyType = modifyType;
			val3.statToBoost = stat;
			base.LastOwner.ownerlessStatModifiers.Add(val3);
			base.LastOwner.stats.RecalculateStats(base.LastOwner, false, false);
		}
	}

	public override void DoEffect(PlayerController user)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			_003F val = user;
			Object obj = ResourceCache.Acquire("Global VFX/vfx_daisukefavor");
			((GameActor)val).PlayEffectOnActor((GameObject)(object)((obj is GameObject) ? obj : null), Vector3.zero, true, false, false);
			MakeKyleDisappointedInMe(Random.Range(1, 48));
		}
		catch (Exception ex)
		{
			ETGModConsole.Log((object)ex.Message, false);
			ETGModConsole.Log((object)ex.StackTrace, false);
		}
	}

	private void Notify(string header, string text)
	{
		tk2dBaseSprite notificationObjectSprite = GameUIRoot.Instance.notificationController.notificationObjectSprite;
		GameUIRoot.Instance.notificationController.DoCustomNotification(header, text, notificationObjectSprite.Collection, notificationObjectSprite.spriteId, (NotificationColor)2, false, false);
	}
}
