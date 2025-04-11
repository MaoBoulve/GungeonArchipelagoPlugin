using System;
using System.Collections.Generic;
using System.Reflection;
using Alexandria.BreakableAPI;
using Alexandria.DungeonAPI;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Alexandria.NPCAPI;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public static class Ironside
{
	public static GenericLootTable IronsideLootTable;

	public static GameObject mapIcon;

	public static void AddToLootPool(int id)
	{
		if ((Object)(object)IronsideLootTable == (Object)null)
		{
			IronsideLootTable = LootUtility.CreateLootTable((List<GenericLootTable>)null, (DungeonPrerequisite[])null);
		}
		LootUtility.AddItemToPool(IronsideLootTable, id, 1f);
	}

	public static void Init()
	{
		//IL_04e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f0: Expected O, but got Unknown
		//IL_051e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0528: Expected O, but got Unknown
		//IL_0538: Unknown result type (might be due to invalid IL or missing references)
		//IL_0545: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e0: Expected O, but got Unknown
		//IL_0720: Unknown result type (might be due to invalid IL or missing references)
		NpcTools.AddComplex(Databases.Strings.Core, "#IRONSIDE_GENERIC_TALK", "The Gungeon is a tough place, it pays to have thick skin.");
		NpcTools.AddComplex(Databases.Strings.Core, "#IRONSIDE_GENERIC_TALK", "My pepaw always told me to stay prepared. So that's what I do.");
		NpcTools.AddComplex(Databases.Strings.Core, "#IRONSIDE_GENERIC_TALK", "The cost of being heavily armoured is never letting anyone in.");
		NpcTools.AddComplex(Databases.Strings.Core, "#IRONSIDE_GENERIC_TALK", "Names Ironside. I specialise in armour and protective supplies.");
		NpcTools.AddComplex(Databases.Strings.Core, "#IRONSIDE_GENERIC_TALK", "Like the carpet? I got it custom made.");
		NpcTools.AddComplex(Databases.Strings.Core, "#IRONSIDE_GENERIC_TALK", "Blanks are all well and good, but you're not always going to have them. Ask yourself, do you want bullets goin' straight to your heart(s)?");
		NpcTools.AddComplex(Databases.Strings.Core, "#IRONSIDE_GENERIC_TALK", "I have done and I have dared, for everything to be prepared.");
		NpcTools.AddComplex(Databases.Strings.Core, "#IRONSIDE_GENERIC_TALK", "Did you see that tarnished old slug rooting around in my garbage? What a freak.");
		NpcTools.AddComplex(Databases.Strings.Core, "#IRONSIDE_GENERIC_TALK", "Armour up Gungeoneer, the road ahead is long and the bullets don't get any softer.");
		NpcTools.AddComplex(Databases.Strings.Core, "#IRONSIDE_STOPPER_TALK", "No more chit-chat.");
		NpcTools.AddComplex(Databases.Strings.Core, "#IRONSIDE_STOPPER_TALK", "I don't have time to talk longer.");
		NpcTools.AddComplex(Databases.Strings.Core, "#IRONSIDE_STOPPER_TALK", "Got things to be, places to do.");
		NpcTools.AddComplex(Databases.Strings.Core, "#IRONSIDE_PURCHASE_TALK", "Pleasure doin' business with you.");
		NpcTools.AddComplex(Databases.Strings.Core, "#IRONSIDE_PURCHASE_TALK", "Pays to be prepared.");
		NpcTools.AddComplex(Databases.Strings.Core, "#IRONSIDE_PURCHASE_TALK", "Armoured and ready!");
		NpcTools.AddComplex(Databases.Strings.Core, "#IRONSIDE_NOSALE_TALK", "You'd better get out there and find some more [sprite \"armor_money_icon_001\"].");
		NpcTools.AddComplex(Databases.Strings.Core, "#IRONSIDE_NOSALE_TALK", "Sorry pal, no [sprite \"armor_money_icon_001\"] no sale.");
		NpcTools.AddComplex(Databases.Strings.Core, "#IRONSIDE_INTRO_TALK", "AVAST FIEND- Oh, no. It's just you.");
		NpcTools.AddComplex(Databases.Strings.Core, "#IRONSIDE_INTRO_TALK", "Staying safe out there?");
		NpcTools.AddComplex(Databases.Strings.Core, "#IRONSIDE_INTRO_TALK", "Welcome back, you're looking beat up.");
		NpcTools.AddComplex(Databases.Strings.Core, "#IRONSIDE_INTRO_TALK", "Good grief... I didn't know someone could have that many bruises.");
		NpcTools.AddComplex(Databases.Strings.Core, "#IRONSIDE_ATTACKED_TALK", "Hah, no way you're getting through this armour!");
		NpcTools.AddComplex(Databases.Strings.Core, "#IRONSIDE_ATTACKED_TALK", "Nice try, but one of us is squishy and it ain't me.");
		NpcTools.AddComplex(Databases.Strings.Core, "#IRONSIDE_ATTACKED_TALK", "You're gonna wish you hadn't done that one day.");
		NpcTools.AddComplex(Databases.Strings.Core, "#IRONSIDE_STEAL_TALK", "THIEF!");
		NpcTools.AddComplex(Databases.Strings.Core, "#IRONSIDE_STEAL_TALK", "TAFFER!");
		NpcTools.AddComplex(Databases.Strings.Core, "#IRONSIDE_STEAL_TALK", "ARMS UP!");
		List<int> list = new List<int>
		{
			160,
			161,
			162,
			163,
			450,
			457,
			64,
			65,
			380,
			447,
			634,
			111,
			256,
			564,
			290,
			312,
			314,
			454,
			598,
			545,
			178,
			154,
			FullArmourJacket.FullArmourJacketID,
			KnightlyBullets.KnightlyBulletsID,
			ArmourBandage.ArmourBandageID,
			GoldenArmour.GoldenArmourID,
			ExoskeletalArmour.MeatShieldID,
			ArmouredArmour.ArmouredArmourID,
			KeyBullwark.KeyBulwarkID,
			TinHeart.TinHeartID,
			HeavyChamber.HeavyChamberID,
			TableTechInvulnerability.ID,
			LiquidMetalBody.LiquidMetalBodyID,
			HornedHelmet.HornedHelmetID,
			LeadSoul.LeadSoulID,
			GSwitch.GSwitchID,
			MaidenRifle.MaidenRifleID,
			RapidRiposte.RapidRiposteID,
			Converter.ConverterID
		};
		foreach (int item in list)
		{
			AddToLootPool(item);
		}
		mapIcon = ItemBuilder.SpriteFromBundle("ironside_mapicon", Initialisation.NPCCollection.GetSpriteIdByName("ironside_mapicon"), Initialisation.NPCCollection, new GameObject("ironside_mapicon"));
		FakePrefabExtensions.MakeFakePrefab(mapIcon);
		GameObject val = ItemBuilder.SpriteFromBundle("ironside_idle_001", Initialisation.NPCCollection.GetSpriteIdByName("ironside_idle_001"), Initialisation.NPCCollection, new GameObject("Ironside"));
		SpeculativeRigidbody val2 = ShopAPI.GenerateOrAddToRigidBody(val, (CollisionLayer)5, (PixelColliderGeneration)0, true, true, true, false, false, false, false, true, (IntVector2?)new IntVector2(11, 11), (IntVector2?)new IntVector2(9, -1));
		val2.AddCollisionLayerOverride(CollisionMask.LayerToMask((CollisionLayer)8));
		GameObject key = TempNPCTools.MakeIntoShopkeeper(spriteCollection: Initialisation.NPCCollection, animLibrary: Initialisation.npcAnimationCollection, lootTable: IronsideLootTable, runBasedMultilineGenericStringKey: "#IRONSIDE_GENERIC_TALK", runBasedMultilineStopperStringKey: "#IRONSIDE_STOPPER_TALK", purchaseItemStringKey: "#IRONSIDE_PURCHASE_TALK", purchaseItemFailedStringKey: "#IRONSIDE_NOSALE_TALK", introStringKey: "#IRONSIDE_INTRO_TALK", attackedStringKey: "#IRONSIDE_ATTACKED_TALK", stolenFromStringKey: "#IRONSIDE_STEAL_TALK", talkPointOffset: new Vector3(0.9375f, 2.0625f, 0f), npcOffset: new Vector3(1.6875f, 3.5f, 0f), voice: "golem", itemPositions: ShopAPI.defaultItemPositions, costModifier: 1f, giveStatsOnPurchase: false, statsToGiveOnPurchase: (StatModifier[])null, minimapIcon: mapIcon, CarpetOffset: (Vector2?)new Vector2(-0.0625f, -0.0625f), name: "Ironside", prefix: "nn", npcOBJ: val, idleName: "ironside_idle", talkName: "ironside_talk", currency: (ShopCurrencyType)4, CustomCanBuy: (Func<CustomShopController, PlayerController, int, bool>)IronsideCustomCanBuy, CustomRemoveCurrency: (Func<CustomShopController, PlayerController, int, int>)IronsideCustomRemoveCurrency, CustomPrice: (Func<CustomShopController, CustomShopItemController, PickupObject, int>)IronsideCustomPrice, OnPurchase: (Func<PlayerController, PickupObject, int, bool>)IronsideBuy, OnSteal: (Func<PlayerController, PickupObject, int, bool>)null, currencyIconPath: "NevernamedsItems/Resources/NPCSprites/Ironside/armourcurrency_icon.png", currencyName: "Armor", canBeRobbed: true, Carpet: "ironside_carpet", hasMinimapIcon: true, addToShopAnnex: true, shopAnnexWeight: 0.08f, prerequisites: (DungeonPrerequisite[])null, fortunesFavorRadius: 2f, poolType: (ShopItemPoolType)0, RainbowModeImmunity: false);
		Dictionary<GameObject, float> dictionary = new Dictionary<GameObject, float> { { key, 1f } };
		DungeonPlaceable val3 = BreakableAPIToolbox.GenerateDungeonPlaceable(dictionary, 1, 1, (DungeonPrerequisite[])null);
		val3.isPassable = true;
		val3.width = 5;
		val3.height = 5;
		StaticReferences.StoredDungeonPlaceables.Add("ironside", val3);
		StaticReferences.customPlaceables.Add("nn:ironside", val3);
		SharedInjectionData injectionData = GameManager.Instance.GlobalInjectionData.entries[2].injectionData;
		List<ProceduralFlowModifierData> injectionData2 = injectionData.InjectionData;
		ProceduralFlowModifierData val4 = new ProceduralFlowModifierData();
		val4.annotation = "Ironside";
		val4.DEBUG_FORCE_SPAWN = false;
		val4.OncePerRun = false;
		val4.placementRules = new List<FlowModifierPlacementType> { (FlowModifierPlacementType)1 };
		val4.roomTable = null;
		val4.exactRoom = RoomFactory.BuildNewRoomFromResource("NevernamedsItems/Content/NPCs/Rooms/IronsideRoom.newroom", (Assembly)null).room;
		val4.IsWarpWing = false;
		val4.RequiresMasteryToken = false;
		val4.chanceToLock = 0f;
		val4.selectionWeight = 0.8f;
		val4.chanceToSpawn = 1f;
		val4.RequiredValidPlaceable = null;
		val4.prerequisites = (DungeonPrerequisite[])(object)new DungeonPrerequisite[0];
		val4.CanBeForcedSecret = false;
		val4.RandomNodeChildMinDistanceFromEntrance = 0;
		val4.exactSecondaryRoom = null;
		val4.framedCombatNodes = 0;
		injectionData2.Add(val4);
	}

	public static bool IronsideBuy(PlayerController player, PickupObject item, int idfk)
	{
		return false;
	}

	public static int IronsideCustomPrice(CustomShopController shop, CustomShopItemController itemCont, PickupObject item)
	{
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected I4, but got Unknown
		int num = 1;
		ItemQuality quality = item.quality;
		ItemQuality val = quality;
		switch (val - 2)
		{
		case 3:
			num = 4;
			break;
		case 2:
			num = 3;
			break;
		case 1:
			num = 2;
			break;
		case 0:
			num = 2;
			break;
		}
		if (item is PassiveItem && ((PassiveItem)((item is PassiveItem) ? item : null)).ArmorToGainOnInitialPickup > 0)
		{
			num += ((PassiveItem)((item is PassiveItem) ? item : null)).ArmorToGainOnInitialPickup;
		}
		else if (item is Gun && ((Gun)((item is Gun) ? item : null)).ArmorToGainOnPickup > 0)
		{
			num += ((Gun)((item is Gun) ? item : null)).ArmorToGainOnPickup;
		}
		List<int> list = new List<int> { ArmouredArmour.ArmouredArmourID };
		if (list.Contains(item.PickupObjectId))
		{
			num++;
		}
		return Mathf.Min(num, 5);
	}

	public static int IronsideCustomRemoveCurrency(CustomShopController shop, PlayerController player, int cost)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		if (player.characterIdentity != OMITBChars.Shade)
		{
			HealthHaver healthHaver = ((BraveBehaviour)player).healthHaver;
			healthHaver.Armor -= (float)cost;
		}
		else
		{
			FieldInfo field = typeof(CustomShopController).GetField("m_itemControllers", BindingFlags.Instance | BindingFlags.NonPublic);
			foreach (CustomShopItemController item in field.GetValue(shop) as List<ShopItemController>)
			{
				CustomShopItemController val = item;
				val.ForceOutOfStock();
			}
		}
		return 1;
	}

	public static bool IronsideCustomCanBuy(CustomShopController shop, PlayerController player, int cost)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		if (player.characterIdentity == OMITBChars.Shade)
		{
			return true;
		}
		if (((BraveBehaviour)player).healthHaver.Armor >= (float)cost && ((BraveBehaviour)player).healthHaver.GetCurrentHealth() > 0f)
		{
			return true;
		}
		if (((BraveBehaviour)player).healthHaver.Armor > (float)cost)
		{
			return true;
		}
		return false;
	}
}
