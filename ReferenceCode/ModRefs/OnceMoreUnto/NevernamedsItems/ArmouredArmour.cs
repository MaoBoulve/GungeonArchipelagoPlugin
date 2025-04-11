using System;
using System.Reflection;
using Alexandria.ItemAPI;
using Gungeon;
using MonoMod.RuntimeDetour;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class ArmouredArmour : PassiveItem
{
	public static int ArmouredArmourID;

	private Hook healthPickupHook = new Hook((MethodBase)typeof(HealthPickup).GetMethod("Pickup", BindingFlags.Instance | BindingFlags.Public), typeof(ArmouredArmour).GetMethod("heartPickupHookMethod"));

	private static bool canGiveArmor;

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<ArmouredArmour>("Armoured Armour", "Why ARE they shields?", "Chance to double armour pickups.\n\nA suit of armour made out of smaller, less effective pieces of armour.\nIt's genius!", "armouredarmour_icon", assetbundle: true);
		val.quality = (ItemQuality)3;
		val.SetupUnlockOnCustomFlag(CustomDungeonFlags.PLAYERHELDMORETHANFIVEARMOUR, requiredFlagValue: true);
		ArmouredArmourID = val.PickupObjectId;
	}

	public static void heartPickupHookMethod(Action<HealthPickup, PlayerController> orig, HealthPickup self, PlayerController player)
	{
		orig(self, player);
		if (self.armorAmount <= 0 || !player.HasPickupID(Game.Items["nn:armoured_armour"].PickupObjectId))
		{
			return;
		}
		if (canGiveArmor)
		{
			float num = 0.5f;
			if (CustomSynergies.PlayerHasActiveSynergy(player, "Armoured Armoured Armour"))
			{
				num = 0.75f;
			}
			if (Random.value >= num)
			{
				HealthHaver healthHaver = ((BraveBehaviour)player).healthHaver;
				healthHaver.Armor += 1f;
			}
			canGiveArmor = false;
		}
		else
		{
			canGiveArmor = true;
		}
	}

	public override void Pickup(PlayerController player)
	{
		if (!base.m_pickedUpThisRun)
		{
			HealthHaver healthHaver = ((BraveBehaviour)player).healthHaver;
			healthHaver.Armor += 1f;
		}
		((PassiveItem)this).Pickup(player);
	}
}
