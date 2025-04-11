using System;
using System.Collections.Generic;
using System.Reflection;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class BlueWhitePill : PlayerItem
{
	public struct PillEffect
	{
		public StatType statToEffect;

		public float amount;

		public int pickupID;

		public int pickupAmount;

		public float min;

		public float max;

		public ModifyMethod modifyMethod;

		public Action<PillEffect, PlayerController> action;

		public string notificationHeader;

		public string notificationText;

		public List<PillEffect> subEffects;
	}

	public static List<PillEffect> pilleffects = new List<PillEffect>();

	public static int BlueWhitePillEffect;

	public static void Init()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Expected O, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		string text = "Blue & White Pillet";
		string text2 = "NevernamedsItems/Resources/bluewhitepillet_icon";
		GameObject val = new GameObject(text);
		BlueWhitePill blueWhitePill = val.AddComponent<BlueWhitePill>();
		ItemBuilder.AddSpriteToObject(text, text2, val, (Assembly)null);
		string text3 = "The Blooneys";
		string text4 = "";
		ItemBuilder.SetupItem((PickupObject)(object)blueWhitePill, text3, text4, "nn");
		ItemBuilder.SetCooldownType((PlayerItem)(object)blueWhitePill, (CooldownType)0, 5f);
		((PlayerItem)blueWhitePill).consumable = true;
		((PickupObject)blueWhitePill).quality = (ItemQuality)(-100);
	}

	public override void DoEffect(PlayerController user)
	{
		PillEffect arg = pilleffects[BlueWhitePillEffect];
		arg.action(arg, user);
		Notify("null", arg.notificationText);
	}

	public static void DefineEffects()
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		pilleffects.Add(new PillEffect
		{
			notificationText = "Health Up",
			action = HealthModifier,
			statToEffect = (StatType)3,
			modifyMethod = (ModifyMethod)0,
			amount = 1f
		});
		pilleffects.Add(new PillEffect
		{
			notificationText = "Health Down",
			action = HealthModifier,
			statToEffect = (StatType)3,
			modifyMethod = (ModifyMethod)0,
			amount = -1f
		});
	}

	public static void HealthModifier(PillEffect effect, PlayerController user)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Invalid comparison between Unknown and I4
		float baseStatValue = user.stats.GetBaseStatValue((StatType)3);
		if ((int)user.characterIdentity == 2)
		{
			if (effect.amount >= 0f)
			{
				HealthHaver healthHaver = ((BraveBehaviour)user).healthHaver;
				healthHaver.Armor += effect.amount;
			}
			else if (effect.amount < 0f && ((BraveBehaviour)user).healthHaver.Armor > 1f)
			{
				HealthHaver healthHaver2 = ((BraveBehaviour)user).healthHaver;
				healthHaver2.Armor += effect.amount;
			}
			else if (effect.amount < 0f && ((BraveBehaviour)user).healthHaver.Armor == 1f)
			{
				HealthHaver healthHaver3 = ((BraveBehaviour)user).healthHaver;
				healthHaver3.Armor += 1f;
			}
		}
		else if (effect.amount >= 0f)
		{
			user.stats.SetBaseStatValue((StatType)3, baseStatValue + effect.amount, user);
		}
		else if (effect.amount < 0f && baseStatValue > 1f)
		{
			user.stats.SetBaseStatValue((StatType)3, baseStatValue + effect.amount, user);
		}
		else if (effect.amount < 0f && baseStatValue == 1f)
		{
			user.stats.SetBaseStatValue((StatType)3, baseStatValue + 1f, user);
		}
	}

	private void Notify(string header, string text)
	{
		tk2dBaseSprite notificationObjectSprite = GameUIRoot.Instance.notificationController.notificationObjectSprite;
		GameUIRoot.Instance.notificationController.DoCustomNotification(header, text, notificationObjectSprite.Collection, notificationObjectSprite.spriteId, (NotificationColor)2, false, false);
	}

	public override void Pickup(PlayerController player)
	{
		((PlayerItem)this).Pickup(player);
		BlueWhitePillEffect = Random.Range(0, pilleffects.Count);
	}
}
