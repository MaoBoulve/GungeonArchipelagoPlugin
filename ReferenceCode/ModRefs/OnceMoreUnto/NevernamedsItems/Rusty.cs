using System;
using System.Collections.Generic;
using System.Reflection;
using Alexandria.BreakableAPI;
using Alexandria.DungeonAPI;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Alexandria.NPCAPI;
using Dungeonator;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public static class Rusty
{
	public static GameObject mapIcon;

	public static GenericLootTable RustyLootTable;

	public static void AddToLootPool(int id)
	{
		if ((Object)(object)RustyLootTable == (Object)null)
		{
			RustyLootTable = LootUtility.CreateLootTable((List<GenericLootTable>)null, (DungeonPrerequisite[])null);
		}
		LootUtility.AddItemToPool(RustyLootTable, id, 1f);
	}

	public static void Init()
	{
		//IL_063f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0649: Expected O, but got Unknown
		//IL_0677: Unknown result type (might be due to invalid IL or missing references)
		//IL_0681: Expected O, but got Unknown
		//IL_0691: Unknown result type (might be due to invalid IL or missing references)
		//IL_069d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0711: Unknown result type (might be due to invalid IL or missing references)
		//IL_0725: Unknown result type (might be due to invalid IL or missing references)
		//IL_0744: Unknown result type (might be due to invalid IL or missing references)
		//IL_075f: Unknown result type (might be due to invalid IL or missing references)
		//IL_077a: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0871: Unknown result type (might be due to invalid IL or missing references)
		//IL_0878: Expected O, but got Unknown
		//IL_08b8: Unknown result type (might be due to invalid IL or missing references)
		NpcTools.AddComplex(Databases.Strings.Core, "#RUSTY_GENERIC_TALK", "I sell, yes, you! Buy! Cash yes money yes yes yes!");
		NpcTools.AddComplex(Databases.Strings.Core, "#RUSTY_GENERIC_TALK", "Rusty sells trash people throw at him. Make easy money. Heheh. Fools.");
		NpcTools.AddComplex(Databases.Strings.Core, "#RUSTY_GENERIC_TALK", "You want to talk to Rusty? Nobody ever talks to Rusty.");
		NpcTools.AddComplex(Databases.Strings.Core, "#RUSTY_GENERIC_TALK", "I used to be taaaaall once, yes, yes. Taaaall, and red. Red.");
		NpcTools.AddComplex(Databases.Strings.Core, "#RUSTY_GENERIC_TALK", "They laugh at Rusty, yes... they all laugh...");
		NpcTools.AddComplex(Databases.Strings.Core, "#RUSTY_GENERIC_TALK", "Rusty has seen things... things you are not ready to see.");
		NpcTools.AddComplex(Databases.Strings.Core, "#RUSTY_GENERIC_TALK", "Chambers lurk below. Places you've never seen. Perhaps you will be ready one day, yes.");
		NpcTools.AddComplex(Databases.Strings.Core, "#RUSTY_GENERIC_TALK", "Don't trust the mad bullet Alhazard. Rusty trusted him, and is now Rusty.");
		NpcTools.AddComplex(Databases.Strings.Core, "#RUSTY_GENERIC_TALK", "What is it like. To have skin. Rusty wonders?");
		NpcTools.AddComplex(Databases.Strings.Core, "#RUSTY_GENERIC_TALK", "One day you and Rusty will be not so different, rustythinks yes.");
		NpcTools.AddComplex(Databases.Strings.Core, "#RUSTY_GENERIC_TALK", "One day, the skies will run black with the ichor of ages, and all will be unloaded...  what?");
		NpcTools.AddComplex(Databases.Strings.Core, "#RUSTY_STOPPER_TALK", "You are boring. Rusty is bored yes bored no yes");
		NpcTools.AddComplex(Databases.Strings.Core, "#RUSTY_STOPPER_TALK", "Rusty has no more to say to you, no, no.");
		NpcTools.AddComplex(Databases.Strings.Core, "#RUSTY_STOPPER_TALK", "Mmmmm, yesyesyesyesyesyesyes.");
		NpcTools.AddComplex(Databases.Strings.Core, "#RUSTY_PURCHASE_TALK", "YesYes! Deal Yes! Buy!");
		NpcTools.AddComplex(Databases.Strings.Core, "#RUSTY_PURCHASE_TALK", "A good choice, yes!");
		NpcTools.AddComplex(Databases.Strings.Core, "#RUSTY_PURCHASE_TALK", "A poor choice, yes!");
		NpcTools.AddComplex(Databases.Strings.Core, "#RUSTY_PURCHASE_TALK", "Rusty lives another day.");
		NpcTools.AddComplex(Databases.Strings.Core, "#RUSTY_PURCHASE_TALK", "Rusty will buy a new can of polish!");
		NpcTools.AddComplex(Databases.Strings.Core, "#RUSTY_NOSALE_TALK", "No. TooCheap. Even for me, hehehehehehh");
		NpcTools.AddComplex(Databases.Strings.Core, "#RUSTY_NOSALE_TALK", "Cash, upfront. No credit.");
		NpcTools.AddComplex(Databases.Strings.Core, "#RUSTY_NOSALE_TALK", "Rusty no give credit. You come back when you're richer!");
		NpcTools.AddComplex(Databases.Strings.Core, "#RUSTY_INTRO_TALK", "Oh! You are back! Yes! Heheh! BuyBuy!");
		NpcTools.AddComplex(Databases.Strings.Core, "#RUSTY_INTRO_TALK", "You Live! Rusty is Glad! Yes!");
		NpcTools.AddComplex(Databases.Strings.Core, "#RUSTY_INTRO_TALK", "Wallet person returns, yes, with wallet gold?");
		NpcTools.AddComplex(Databases.Strings.Core, "#RUSTY_ATTACKED_TALK", "Rusty no die. Rusty live forever.");
		NpcTools.AddComplex(Databases.Strings.Core, "#RUSTY_ATTACKED_TALK", "If killing Rusty was that easy, Rusty would be dead.");
		NpcTools.AddComplex(Databases.Strings.Core, "#RUSTY_ATTACKED_TALK", "Rusty think you are a %&**@. Yes.");
		NpcTools.AddComplex(Databases.Strings.Core, "#RUSTY_STEAL_TALK", "...Rusty saw what you did... ...yes...");
		List<int> list = new List<int>
		{
			120,
			224,
			127,
			558,
			108,
			109,
			66,
			308,
			136,
			366,
			234,
			77,
			403,
			432,
			447,
			644,
			573,
			65,
			250,
			353,
			488,
			256,
			137,
			565,
			306,
			106,
			487,
			197,
			56,
			378,
			539,
			79,
			8,
			9,
			202,
			122,
			12,
			31,
			181,
			327,
			577,
			196,
			10,
			363,
			33,
			176,
			440,
			MistakeBullets.MistakeBulletsID,
			TracerRound.ID,
			IronSights.IronSightsID,
			GlassChamber.GlassChamberID,
			BulletBoots.BulletBootsID,
			DiamondBracelet.DiamondBraceletID,
			PearlBracelet.PearlBraceletID,
			RingOfAmmoRedemption.RingOfAmmoRedemptionID,
			MapFragment.MapFragmentID,
			GunGrease.GunGreaseID,
			LuckyCoin.LuckyCoinID,
			AppleActive.AppleID,
			SpeedPotion.SpeedPotionID,
			ShroomedGun.ShroomedGunID,
			Glock42.Glock42ID,
			DiscGun.DiscGunID,
			Purpler.PurplerID,
			TheLodger.TheLodgerID,
			HeatRay.HeatRayID,
			Spitballer.ID
		};
		foreach (int item in list)
		{
			AddToLootPool(item);
		}
		mapIcon = ItemBuilder.SpriteFromBundle("rusty_mapicon", Initialisation.NPCCollection.GetSpriteIdByName("rusty_mapicon"), Initialisation.NPCCollection, new GameObject("rusty_mapicon"));
		FakePrefabExtensions.MakeFakePrefab(mapIcon);
		GameObject val = ItemBuilder.SpriteFromBundle("rusty_idle_001", Initialisation.NPCCollection.GetSpriteIdByName("rusty_idle_001"), Initialisation.NPCCollection, new GameObject("Rusty"));
		SpeculativeRigidbody val2 = ShopAPI.GenerateOrAddToRigidBody(val, (CollisionLayer)5, (PixelColliderGeneration)0, true, true, true, false, false, false, false, true, (IntVector2?)new IntVector2(20, 11), (IntVector2?)new IntVector2(6, -1));
		val2.AddCollisionLayerOverride(CollisionMask.LayerToMask((CollisionLayer)8));
		GameObject key = TempNPCTools.MakeIntoShopkeeper(spriteCollection: Initialisation.NPCCollection, animLibrary: Initialisation.npcAnimationCollection, lootTable: RustyLootTable, runBasedMultilineGenericStringKey: "#RUSTY_GENERIC_TALK", runBasedMultilineStopperStringKey: "#RUSTY_STOPPER_TALK", purchaseItemStringKey: "#RUSTY_PURCHASE_TALK", purchaseItemFailedStringKey: "#RUSTY_NOSALE_TALK", introStringKey: "#RUSTY_INTRO_TALK", attackedStringKey: "#RUSTY_ATTACKED_TALK", stolenFromStringKey: "#RUSTY_STEAL_TALK", talkPointOffset: new Vector3(1.0625f, 1.375f, 0f), npcOffset: new Vector3(2.375f, 2.75f, 0f), voice: "gambler", itemPositions: new List<Vector3>
		{
			new Vector3(1.1875f, 3.125f, 1f),
			new Vector3(1.5f, 1.4375f, 1f),
			new Vector3(3.5625f, 1.1875f, 1f)
		}.ToArray(), costModifier: 0.5f, giveStatsOnPurchase: false, statsToGiveOnPurchase: (StatModifier[])null, CustomCanBuy: (Func<CustomShopController, PlayerController, int, bool>)null, CustomRemoveCurrency: (Func<CustomShopController, PlayerController, int, int>)null, CustomPrice: (Func<CustomShopController, CustomShopItemController, PickupObject, int>)null, minimapIcon: mapIcon, CarpetOffset: (Vector2?)new Vector2(0.25f, 0.25f), name: "Rusty", prefix: "nn", npcOBJ: val, idleName: "rusty_idle", talkName: "rusty_talk", currency: (ShopCurrencyType)0, OnPurchase: (Func<PlayerController, PickupObject, int, bool>)RustyBuy, OnSteal: (Func<PlayerController, PickupObject, int, bool>)RustySteal, currencyIconPath: "", currencyName: "", canBeRobbed: true, Carpet: "rustycarpet", hasMinimapIcon: true, addToShopAnnex: true, shopAnnexWeight: 0.1f, prerequisites: (DungeonPrerequisite[])null, fortunesFavorRadius: 2f, poolType: (ShopItemPoolType)0, RainbowModeImmunity: false);
		Dictionary<GameObject, float> dictionary = new Dictionary<GameObject, float> { { key, 1f } };
		DungeonPlaceable val3 = BreakableAPIToolbox.GenerateDungeonPlaceable(dictionary, 1, 1, (DungeonPrerequisite[])null);
		val3.isPassable = true;
		val3.width = 5;
		val3.height = 5;
		StaticReferences.StoredDungeonPlaceables.Add("rusty", val3);
		StaticReferences.customPlaceables.Add("nn:rusty", val3);
		SharedInjectionData injectionData = GameManager.Instance.GlobalInjectionData.entries[2].injectionData;
		List<ProceduralFlowModifierData> injectionData2 = injectionData.InjectionData;
		ProceduralFlowModifierData val4 = new ProceduralFlowModifierData();
		val4.annotation = "Rusty";
		val4.DEBUG_FORCE_SPAWN = false;
		val4.OncePerRun = false;
		val4.placementRules = new List<FlowModifierPlacementType> { (FlowModifierPlacementType)1 };
		val4.roomTable = null;
		val4.exactRoom = RoomFactory.BuildNewRoomFromResource("NevernamedsItems/Content/NPCs/Rooms/RustyRoom.newroom", (Assembly)null).room;
		val4.IsWarpWing = false;
		val4.RequiresMasteryToken = false;
		val4.chanceToLock = 0f;
		val4.selectionWeight = 1f;
		val4.chanceToSpawn = 1f;
		val4.RequiredValidPlaceable = null;
		val4.prerequisites = (DungeonPrerequisite[])(object)new DungeonPrerequisite[0];
		val4.CanBeForcedSecret = false;
		val4.RandomNodeChildMinDistanceFromEntrance = 0;
		val4.exactSecondaryRoom = null;
		val4.framedCombatNodes = 0;
		injectionData2.Add(val4);
	}

	public static bool RustyBuy(PlayerController player, PickupObject item, int idfk)
	{
		SaveAPIManager.RegisterStatChange(CustomTrackedStats.RUSTY_ITEMS_PURCHASED, 1f);
		return false;
	}

	public static bool RustySteal(PlayerController player, PickupObject item, int idfk)
	{
		SaveAPIManager.RegisterStatChange(CustomTrackedStats.RUSTY_ITEMS_STOLEN, 1f);
		return false;
	}
}
