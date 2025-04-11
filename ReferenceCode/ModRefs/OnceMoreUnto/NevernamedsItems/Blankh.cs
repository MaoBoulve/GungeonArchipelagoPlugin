using System;
using System.Reflection;
using Alexandria.ItemAPI;
using MonoMod.RuntimeDetour;
using UnityEngine;

namespace NevernamedsItems;

public class Blankh : BlankModificationItem
{
	private static int BlankhID;

	private static Hook BlankHook = new Hook((MethodBase)typeof(PlayerController).GetMethod("DoConsumableBlank", BindingFlags.Instance | BindingFlags.NonPublic), typeof(Blankh).GetMethod("TriggerHealthBlank", BindingFlags.Static | BindingFlags.Public));

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<Blankh>("Blankh", "My Body Is A Temple", "Gives ones' body to Kaliber in order to recieve her bullet-banishing blessings.\n\nTriggered by attempting to Blank with no Blanks remaining.", "blankh_icon", assetbundle: true);
		val.quality = (ItemQuality)4;
		ItemBuilder.AddToSubShop(val, (ShopType)4, 1f);
		ItemBuilder.AddToSubShop(val, (ShopType)2, 1f);
		BlankhID = val.PickupObjectId;
	}

	public override void Pickup(PlayerController player)
	{
		((BlankModificationItem)this).Pickup(player);
	}

	public static void TriggerHealthBlank(Action<PlayerController> orig, PlayerController user)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		if (user.Blanks <= 0 && user.HasPickupID(BlankhID))
		{
			if (user.characterIdentity == OMITBChars.Shade)
			{
				if (user.carriedConsumables.Currency > 15)
				{
					PlayerConsumables carriedConsumables = user.carriedConsumables;
					carriedConsumables.Currency -= 15;
					user.ForceBlank(25f, 0.5f, false, true, (Vector2?)null, true, -1f);
				}
			}
			else if (Object.op_Implicit((Object)(object)((BraveBehaviour)user).healthHaver) && ((BraveBehaviour)user).healthHaver.GetCurrentHealth() > 0.5f)
			{
				((BraveBehaviour)user).healthHaver.ApplyHealing(-0.5f);
				user.ForceBlank(25f, 0.5f, false, true, (Vector2?)null, true, -1f);
			}
			else if (user.ForceZeroHealthState && ((BraveBehaviour)user).healthHaver.Armor > 1f)
			{
				HealthHaver healthHaver = ((BraveBehaviour)user).healthHaver;
				healthHaver.Armor -= 1f;
				user.ForceBlank(25f, 0.5f, false, true, (Vector2?)null, true, -1f);
			}
			else if ((((BraveBehaviour)user).healthHaver.Armor > 0f && ((BraveBehaviour)user).healthHaver.GetCurrentHealth() > 0f) || ((BraveBehaviour)user).healthHaver.Armor > 1f)
			{
				HealthHaver healthHaver2 = ((BraveBehaviour)user).healthHaver;
				healthHaver2.Armor -= 1f;
				user.ForceBlank(25f, 0.5f, false, true, (Vector2?)null, true, -1f);
			}
		}
		orig(user);
	}

	public override DebrisObject Drop(PlayerController player)
	{
		return ((BlankModificationItem)this).Drop(player);
	}
}
