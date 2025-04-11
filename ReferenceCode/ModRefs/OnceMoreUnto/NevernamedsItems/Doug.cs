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
using UnityEngine.Rendering;

namespace NevernamedsItems;

public static class Doug
{
	public static GameObject mapIcon;

	public static GenericLootTable DougLootTable;

	public static void AddToLootPool(int id, float weight = 1f)
	{
		if ((Object)(object)DougLootTable == (Object)null)
		{
			DougLootTable = LootUtility.CreateLootTable((List<GenericLootTable>)null, (DungeonPrerequisite[])null);
		}
		LootUtility.AddItemToPool(DougLootTable, id, weight);
	}

	public static void Init()
	{
		//IL_03df: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e9: Expected O, but got Unknown
		//IL_0417: Unknown result type (might be due to invalid IL or missing references)
		//IL_0421: Expected O, but got Unknown
		//IL_0431: Unknown result type (might be due to invalid IL or missing references)
		//IL_043d: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_051a: Unknown result type (might be due to invalid IL or missing references)
		//IL_055e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0563: Unknown result type (might be due to invalid IL or missing references)
		//IL_0565: Unknown result type (might be due to invalid IL or missing references)
		//IL_056a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0571: Unknown result type (might be due to invalid IL or missing references)
		//IL_0577: Unknown result type (might be due to invalid IL or missing references)
		//IL_0581: Expected O, but got Unknown
		//IL_05b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_05bd: Expected O, but got Unknown
		//IL_05c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0603: Expected O, but got Unknown
		//IL_0606: Unknown result type (might be due to invalid IL or missing references)
		//IL_0648: Unknown result type (might be due to invalid IL or missing references)
		//IL_064f: Expected O, but got Unknown
		//IL_065d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0664: Expected O, but got Unknown
		//IL_0673: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c0: Expected O, but got Unknown
		//IL_06ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d5: Expected O, but got Unknown
		//IL_06e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0782: Unknown result type (might be due to invalid IL or missing references)
		//IL_078c: Expected O, but got Unknown
		//IL_07b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_07db: Unknown result type (might be due to invalid IL or missing references)
		//IL_08fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0907: Expected O, but got Unknown
		//IL_092c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0931: Unknown result type (might be due to invalid IL or missing references)
		//IL_0938: Unknown result type (might be due to invalid IL or missing references)
		//IL_093d: Unknown result type (might be due to invalid IL or missing references)
		//IL_09a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_09b7: Expected O, but got Unknown
		//IL_09b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_09be: Unknown result type (might be due to invalid IL or missing references)
		//IL_09c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ca: Expected O, but got Unknown
		//IL_0a3d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a47: Expected O, but got Unknown
		//IL_0abb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ae4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aee: Expected O, but got Unknown
		//IL_0b62: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b8b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b95: Expected O, but got Unknown
		//IL_0c09: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c96: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c9b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ca6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cad: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cb4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cc7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cce: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cd5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ce4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ceb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cf2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cfd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d08: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d13: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d1a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d21: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d26: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d28: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d2d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d34: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d3a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d44: Expected O, but got Unknown
		//IL_0d4f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d56: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d5d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d64: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d70: Expected O, but got Unknown
		List<string> list = new List<string> { "I roll my shop around. Here, there, any way the wind blows.", "My store is number 1, never number 2!", "I left my home town when it was destroyed by a horrible green bug, sporting a 90's 'tude.", "Have you met Bello? He runs the main shop down here. I quite admire his stools.", "My goods are always duty-free!", "Doug's Traveling Emporium is back! Get a load of my quality wares!", "My prices are great, and always dropping!" };
		foreach (string item3 in list)
		{
			NpcTools.AddComplex(Databases.Strings.Core, "#NNDOUG_GENERIC_TALK", item3);
		}
		NpcTools.AddComplex(Databases.Strings.Core, "#NNDOUG_STOPPER_TALK", "Push on.");
		NpcTools.AddComplex(Databases.Strings.Core, "#NNDOUG_PURCHASE_TALK", "Thank you for your business!");
		NpcTools.AddComplex(Databases.Strings.Core, "#NNDOUG_NOSALE_TALK", "Don't waste my time!");
		NpcTools.AddComplex(Databases.Strings.Core, "#NNDOUG_NOSALE_TALK", "Sorry, no samples.");
		NpcTools.AddComplex(Databases.Strings.Core, "#NNDOUG_NOSALE_TALK", "Your wad is lookin' a little light! Ball up some more [sprite \"ui_coin\"]...");
		NpcTools.AddComplex(Databases.Strings.Core, "#NNDOUG_INTRO_TALK", "Welcome, welcome!");
		NpcTools.AddComplex(Databases.Strings.Core, "#NNDOUG_INTRO_TALK", "Hello!");
		NpcTools.AddComplex(Databases.Strings.Core, "#NNDOUG_ATTACKED_TALK", "Jerkus!");
		NpcTools.AddComplex(Databases.Strings.Core, "#NNDOUG_STEAL_TALK", "Thief!");
		List<int> list2 = new List<int>
		{
			286, 113, 298, 638, 640, 822, 655, 111, 288, 304,
			172, 373, 374, 241, 204, 295, 410, 278, 527, 533,
			277, 323, 579, 661, 284, 352, 375, 523, 636, 530,
			528, 531, 538, 532, 627, 569, 571, 521, 568, 630,
			524, 815
		};
		foreach (int item4 in list2)
		{
			AddToLootPool(item4);
		}
		mapIcon = ItemBuilder.SpriteFromBundle("doug_mapicon", Initialisation.NPCCollection.GetSpriteIdByName("doug_mapicon"), Initialisation.NPCCollection, new GameObject("doug_mapicon"));
		FakePrefabExtensions.MakeFakePrefab(mapIcon);
		GameObject val = ItemBuilder.SpriteFromBundle("doug_idle_001", Initialisation.NPCCollection.GetSpriteIdByName("doug_idle_001"), Initialisation.NPCCollection, new GameObject("Doug"));
		SpeculativeRigidbody val2 = ShopAPI.GenerateOrAddToRigidBody(val, (CollisionLayer)5, (PixelColliderGeneration)0, true, true, true, false, false, false, false, true, (IntVector2?)new IntVector2(9, 9), (IntVector2?)new IntVector2(5, -1));
		val2.AddCollisionLayerOverride(CollisionMask.LayerToMask((CollisionLayer)8));
		tk2dSpriteCollectionData nPCCollection = Initialisation.NPCCollection;
		tk2dSpriteAnimation npcAnimationCollection = Initialisation.npcAnimationCollection;
		GenericLootTable dougLootTable = DougLootTable;
		Vector3 talkPointOffset = new Vector3(0.625f, 1.3125f, 0f);
		Vector3 npcOffset = new Vector3(1.9375f, 2f, 0f);
		Vector3[] itemPositions = new List<Vector3>
		{
			new Vector3(1f, 1f, 1f),
			new Vector3(2.5f, 0.5f, 1f),
			new Vector3(4f, 1f, 1f)
		}.ToArray();
		GameObject minimapIcon = mapIcon;
		Func<PlayerController, PickupObject, int, bool> onPurchase = DougBuy;
		DungeonPrerequisite[] prerequisites = new List<DungeonPrerequisite>
		{
			new DungeonPrerequisite
			{
				prerequisiteType = (PrerequisiteType)4,
				requireFlag = true,
				saveFlagToCheck = (GungeonFlags)45602
			}
		}.ToArray();
		GameObject val3 = TempNPCTools.MakeIntoShopkeeper("Doug", "nn", val, "doug_idle", "doug_talk", nPCCollection, npcAnimationCollection, dougLootTable, (ShopCurrencyType)0, "#NNDOUG_GENERIC_TALK", "#NNDOUG_STOPPER_TALK", "#NNDOUG_PURCHASE_TALK", "#NNDOUG_NOSALE_TALK", "#NNDOUG_INTRO_TALK", "#NNDOUG_ATTACKED_TALK", "#NNDOUG_STEAL_TALK", talkPointOffset, npcOffset, "bug", itemPositions, 0.8f, giveStatsOnPurchase: false, null, null, null, null, onPurchase, null, "", "", canBeRobbed: true, "doug_carpet", null, hasMinimapIcon: true, minimapIcon, addToShopAnnex: true, 0.1f, prerequisites, 2f, (ShopItemPoolType)0);
		AIAnimator component = val.GetComponent<AIAnimator>();
		DirectionalAnimation val4 = new DirectionalAnimation();
		val4.Type = (DirectionType)1;
		val4.Prefix = "doug_idle";
		val4.AnimNames = new string[1] { "" };
		val4.Flipped = (FlipType[])(object)new FlipType[1];
		component.IdleAnimation = val4;
		val4 = new DirectionalAnimation();
		val4.Type = (DirectionType)2;
		val4.Prefix = string.Empty;
		val4.AnimNames = new string[2] { "doug_talkright", "doug_talkleft" };
		val4.Flipped = (FlipType[])(object)new FlipType[2];
		component.TalkAnimation = val4;
		NamedDirectionalAnimation val5 = new NamedDirectionalAnimation();
		val5.name = "yes";
		NamedDirectionalAnimation obj = val5;
		val4 = new DirectionalAnimation();
		val4.Prefix = string.Empty;
		val4.Type = (DirectionType)2;
		val4.Flipped = (FlipType[])(object)new FlipType[2];
		val4.AnimNames = new List<string> { "doug_nodright", "doug_nodleft" }.ToArray();
		obj.anim = val4;
		NamedDirectionalAnimation item = val5;
		val5 = new NamedDirectionalAnimation();
		val5.name = "no";
		NamedDirectionalAnimation obj2 = val5;
		val4 = new DirectionalAnimation();
		val4.Prefix = string.Empty;
		val4.Type = (DirectionType)2;
		val4.Flipped = (FlipType[])(object)new FlipType[2];
		val4.AnimNames = new List<string> { "doug_talkright", "doug_talkleft" }.ToArray();
		obj2.anim = val4;
		NamedDirectionalAnimation item2 = val5;
		if (component.OtherAnimations == null)
		{
			component.OtherAnimations = new List<NamedDirectionalAnimation>();
		}
		component.OtherAnimations.Add(item);
		component.OtherAnimations.Add(item2);
		GameObject val6 = ItemBuilder.SpriteFromBundle("dung_pack_idle_001", Initialisation.NPCCollection.GetSpriteIdByName("dung_pack_idle_001"), Initialisation.NPCCollection, new GameObject("Dung Pack"));
		val6.transform.SetParent(val3.transform);
		val6.transform.localPosition = new Vector3(1.25f, 2.8125f);
		SpeculativeRigidbody val7 = ShopAPI.GenerateOrAddToRigidBody(val6, (CollisionLayer)5, (PixelColliderGeneration)0, true, true, true, false, false, false, false, true, (IntVector2?)new IntVector2(22, 20), (IntVector2?)new IntVector2(10, -1));
		val7.AddCollisionLayerOverride(CollisionMask.LayerToMask((CollisionLayer)8));
		((Renderer)val6.GetComponent<MeshRenderer>()).lightProbeUsage = (LightProbeUsage)0;
		((BraveBehaviour)val6.GetComponent<tk2dSprite>()).renderer.material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTiltedCutout");
		((tk2dBaseSprite)val6.GetComponent<tk2dSprite>()).usesOverrideMaterial = true;
		tk2dSpriteAnimator orAddComponent = GameObjectExtensions.GetOrAddComponent<tk2dSpriteAnimator>(val6);
		orAddComponent.Library = Initialisation.npcAnimationCollection;
		orAddComponent.defaultClipId = Initialisation.npcAnimationCollection.GetClipIdByName("doug_shitball");
		orAddComponent.DefaultClipId = Initialisation.npcAnimationCollection.GetClipIdByName("doug_shitball");
		orAddComponent.playAutomatically = true;
		Dictionary<GameObject, float> dictionary = new Dictionary<GameObject, float> { { val3, 1f } };
		DungeonPlaceable val8 = BreakableAPIToolbox.GenerateDungeonPlaceable(dictionary, 1, 1, (DungeonPrerequisite[])null);
		val8.isPassable = true;
		val8.width = 5;
		val8.height = 5;
		StaticReferences.StoredDungeonPlaceables.Add("dougcustom", val8);
		StaticReferences.customPlaceables.Add("nn:dougcustom", val8);
		GameObject val9 = ItemBuilder.SpriteFromBundle("dougwall_main", Initialisation.NPCCollection.GetSpriteIdByName("dougwall_main"), Initialisation.NPCCollection, new GameObject("Poop Wall"));
		FakePrefabExtensions.MakeFakePrefab(val9);
		SpeculativeRigidbody orAddComponent2 = GameObjectExtensions.GetOrAddComponent<SpeculativeRigidbody>(val9);
		orAddComponent2.CollideWithOthers = true;
		orAddComponent2.CollideWithTileMap = false;
		orAddComponent2.Velocity = Vector2.zero;
		orAddComponent2.MaxVelocity = Vector2.zero;
		orAddComponent2.ForceAlwaysUpdate = false;
		orAddComponent2.CanPush = false;
		orAddComponent2.CanBePushed = false;
		orAddComponent2.PushSpeedModifier = 1f;
		orAddComponent2.CanCarry = false;
		orAddComponent2.CanBeCarried = false;
		orAddComponent2.PreventPiercing = false;
		orAddComponent2.SkipEmptyColliders = false;
		orAddComponent2.RecheckTriggers = false;
		orAddComponent2.UpdateCollidersOnRotation = false;
		orAddComponent2.UpdateCollidersOnScale = false;
		orAddComponent2.PixelColliders = new List<PixelCollider>
		{
			new PixelCollider
			{
				CollisionLayer = (CollisionLayer)8
			},
			new PixelCollider
			{
				CollisionLayer = (CollisionLayer)6
			}
		};
		((Renderer)val9.GetComponent<MeshRenderer>()).lightProbeUsage = (LightProbeUsage)0;
		((BraveBehaviour)val9.GetComponent<tk2dSprite>()).renderer.material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTiltedCutout");
		((tk2dBaseSprite)val9.GetComponent<tk2dSprite>()).usesOverrideMaterial = true;
		((tk2dBaseSprite)val9.GetComponent<tk2dSprite>()).HeightOffGround = -10f;
		GameObject val10 = ItemBuilder.SpriteFromBundle("dougwall_shadow", Initialisation.NPCCollection.GetSpriteIdByName("dougwall_shadow"), Initialisation.NPCCollection, new GameObject("Shadow"));
		tk2dSprite component2 = val10.GetComponent<tk2dSprite>();
		((tk2dBaseSprite)component2).HeightOffGround = -1.7f;
		((tk2dBaseSprite)component2).SortingOrder = 0;
		((tk2dBaseSprite)component2).IsPerpendicular = false;
		((BraveBehaviour)component2).renderer.material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTilted");
		((tk2dBaseSprite)component2).usesOverrideMaterial = true;
		val10.transform.SetParent(val9.transform);
		val10.transform.localPosition = new Vector3(0f, -0.1875f);
		GameObject val11 = ItemBuilder.SpriteFromBundle("dougwall_crap", Initialisation.NPCCollection.GetSpriteIdByName("dougwall_crap"), Initialisation.NPCCollection, new GameObject("Crap"));
		tk2dSprite component3 = val11.GetComponent<tk2dSprite>();
		((tk2dBaseSprite)component3).HeightOffGround = -1f;
		((tk2dBaseSprite)component3).SortingOrder = 0;
		((tk2dBaseSprite)component3).IsPerpendicular = false;
		((BraveBehaviour)component3).renderer.material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTilted");
		((tk2dBaseSprite)component3).usesOverrideMaterial = true;
		val11.transform.SetParent(val9.transform);
		val11.transform.localPosition = new Vector3(0f, -0.3125f);
		GameObject val12 = ItemBuilder.SpriteFromBundle("dougwall_overhang", Initialisation.NPCCollection.GetSpriteIdByName("dougwall_overhang"), Initialisation.NPCCollection, new GameObject("Overhang"));
		tk2dSprite component4 = val12.GetComponent<tk2dSprite>();
		((tk2dBaseSprite)component4).HeightOffGround = 10f;
		((tk2dBaseSprite)component4).SortingOrder = 0;
		((tk2dBaseSprite)component4).IsPerpendicular = true;
		((BraveBehaviour)component4).renderer.material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTiltedCutout");
		((tk2dBaseSprite)component4).usesOverrideMaterial = true;
		val12.transform.SetParent(val9.transform);
		val12.transform.localPosition = new Vector3(-1f, 4.3125f);
		Dictionary<GameObject, float> dictionary2 = new Dictionary<GameObject, float> { { val9, 1f } };
		DungeonPlaceable val13 = BreakableAPIToolbox.GenerateDungeonPlaceable(dictionary2, 1, 1, (DungeonPrerequisite[])null);
		val13.isPassable = true;
		val13.width = 13;
		val13.height = 9;
		StaticReferences.StoredDungeonPlaceables.Add("doug_wall", val13);
		StaticReferences.customPlaceables.Add("nn:doug_wall", val13);
		SharedInjectionData injectionData = GameManager.Instance.GlobalInjectionData.entries[2].injectionData;
		injectionData.InjectionData.Add(new ProceduralFlowModifierData
		{
			annotation = "DougShop",
			DEBUG_FORCE_SPAWN = false,
			OncePerRun = false,
			placementRules = new List<FlowModifierPlacementType> { (FlowModifierPlacementType)1 },
			roomTable = null,
			exactRoom = RoomFactory.BuildNewRoomFromResource("NevernamedsItems/Content/NPCs/Rooms/DougRoom.newroom", (Assembly)null).room,
			IsWarpWing = false,
			RequiresMasteryToken = false,
			chanceToLock = 0f,
			selectionWeight = 1f,
			chanceToSpawn = 1f,
			RequiredValidPlaceable = null,
			prerequisites = new List<DungeonPrerequisite>
			{
				new DungeonPrerequisite
				{
					prerequisiteType = (PrerequisiteType)4,
					requireFlag = true,
					saveFlagToCheck = (GungeonFlags)45602
				}
			}.ToArray(),
			CanBeForcedSecret = false,
			RandomNodeChildMinDistanceFromEntrance = 0,
			exactSecondaryRoom = null,
			framedCombatNodes = 0
		});
	}

	public static bool DougBuy(PlayerController player, PickupObject item, int idfk)
	{
		SaveAPIManager.RegisterStatChange(CustomTrackedStats.DOUG_ITEMS_PURCHASED, 1f);
		return false;
	}
}
