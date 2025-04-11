using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MonoMod.RuntimeDetour;
using UnityEngine;

namespace SaveAPI;

public static class BreachShopTool
{
	public class DoubleMetaShopTier
	{
		private MetaShopTier m_topTier;

		private MetaShopTier m_bottomTier;

		public DoubleMetaShopTier(MetaShopTier topTier, MetaShopTier bottomTier)
		{
			m_topTier = topTier;
			m_bottomTier = bottomTier;
		}

		public DoubleMetaShopTier(DoubleMetaShopTier other)
		{
			m_topTier = other.m_topTier;
			m_bottomTier = other.m_bottomTier;
		}

		public MetaShopTier GetTopTier()
		{
			return m_topTier;
		}

		public MetaShopTier GetBottomTier()
		{
			return m_topTier;
		}

		public List<MetaShopTier> GetTierList()
		{
			return new List<MetaShopTier> { m_topTier, m_bottomTier };
		}
	}

	public static MetaShopController BaseMetaShopController;

	public static GenericLootTable TrorcMetaShopItems;

	public static GenericLootTable GooptonMetaShopItems;

	public static GenericLootTable DougMetaShopItems;

	private static FieldInfo ItemControllersInfo = typeof(ShopController).GetField("m_itemControllers", BindingFlags.Instance | BindingFlags.NonPublic);

	private static FieldInfo BaseItemControllersInfo = typeof(BaseShopController).GetField("m_itemControllers", BindingFlags.Instance | BindingFlags.NonPublic);

	private static Hook pickupObjectEncounterableHook;

	private static Hook baseShopSetupHook;

	private static Hook metaShopSetupHook;

	private static Hook metaShopCurrentTierHook;

	private static Hook metaShopProximateTierHook;

	public static Dictionary<WeightedGameObjectCollection, List<WeightedGameObject>> baseShopAddedItems;

	public static List<MetaShopTier> metaShopAddedTiers;

	private static bool m_loaded;

	public static void DoSetup()
	{
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected O, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Expected O, but got Unknown
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Expected O, but got Unknown
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected O, but got Unknown
		if (!m_loaded)
		{
			BaseMetaShopController = SaveTools.LoadAssetFromAnywhere<GameObject>("Foyer_MetaShop").GetComponent<MetaShopController>();
			TrorcMetaShopItems = SaveTools.LoadAssetFromAnywhere<GenericLootTable>("Shop_Truck_Meta");
			GooptonMetaShopItems = SaveTools.LoadAssetFromAnywhere<GenericLootTable>("Shop_Goop_Meta");
			DougMetaShopItems = SaveTools.LoadAssetFromAnywhere<GenericLootTable>("Shop_Beetle_Meta");
			pickupObjectEncounterableHook = new Hook((MethodBase)typeof(PickupObject).GetMethod("HandleEncounterable", BindingFlags.Instance | BindingFlags.NonPublic), typeof(BreachShopTool).GetMethod("HandleEncounterableHook"));
			baseShopSetupHook = new Hook((MethodBase)typeof(BaseShopController).GetMethod("DoSetup", BindingFlags.Instance | BindingFlags.NonPublic), typeof(BreachShopTool).GetMethod("BaseShopSetupHook"));
			metaShopSetupHook = new Hook((MethodBase)typeof(MetaShopController).GetMethod("DoSetup", BindingFlags.Instance | BindingFlags.NonPublic), typeof(BreachShopTool).GetMethod("MetaSetupHook"));
			metaShopCurrentTierHook = new Hook((MethodBase)typeof(MetaShopController).GetMethod("GetCurrentTier", BindingFlags.Instance | BindingFlags.NonPublic), typeof(BreachShopTool).GetMethod("MetaShopCurrentTierHook"));
			metaShopProximateTierHook = new Hook((MethodBase)typeof(MetaShopController).GetMethod("GetProximateTier", BindingFlags.Instance | BindingFlags.NonPublic), typeof(BreachShopTool).GetMethod("MetaShopProximateTierHook"));
			m_loaded = true;
		}
	}

	public static void Unload()
	{
		if (!m_loaded)
		{
			return;
		}
		if (baseShopAddedItems != null)
		{
			for (int i = 0; i < baseShopAddedItems.Keys.Count; i++)
			{
				WeightedGameObjectCollection val = baseShopAddedItems.Keys.ToList()[i];
				if (val == null || baseShopAddedItems[val] == null)
				{
					continue;
				}
				for (int j = 0; j < baseShopAddedItems[val].Count; j++)
				{
					WeightedGameObject val2 = baseShopAddedItems[val][j];
					if (val2 != null && val.elements.Contains(val2))
					{
						val.elements.Remove(val2);
					}
				}
			}
			baseShopAddedItems.Clear();
			baseShopAddedItems = null;
		}
		if (metaShopAddedTiers != null)
		{
			for (int k = 0; k < metaShopAddedTiers.Count; k++)
			{
				MetaShopTier val3 = metaShopAddedTiers[k];
				if (val3 != null && BaseMetaShopController.metaShopTiers.Contains(val3))
				{
					BaseMetaShopController.metaShopTiers.Remove(val3);
				}
			}
			metaShopAddedTiers.Clear();
			metaShopAddedTiers = null;
		}
		BaseMetaShopController = null;
		TrorcMetaShopItems = null;
		GooptonMetaShopItems = null;
		DougMetaShopItems = null;
		Hook obj = pickupObjectEncounterableHook;
		if (obj != null)
		{
			obj.Dispose();
		}
		Hook obj2 = baseShopSetupHook;
		if (obj2 != null)
		{
			obj2.Dispose();
		}
		Hook obj3 = metaShopSetupHook;
		if (obj3 != null)
		{
			obj3.Dispose();
		}
		Hook obj4 = metaShopCurrentTierHook;
		if (obj4 != null)
		{
			obj4.Dispose();
		}
		Hook obj5 = metaShopProximateTierHook;
		if (obj5 != null)
		{
			obj5.Dispose();
		}
		m_loaded = false;
	}

	public static void HandleEncounterableHook(Action<PickupObject, PlayerController> orig, PickupObject po, PlayerController player)
	{
		orig(po, player);
		if ((Object)(object)po != (Object)null && (Object)(object)((Component)po).GetComponent<SpecialPickupObject>() != (Object)null && ((Component)po).GetComponent<SpecialPickupObject>().CustomSaveFlagToSetOnAcquisition != 0)
		{
			AdvancedGameStatsManager.Instance.SetFlag(((Component)po).GetComponent<SpecialPickupObject>().CustomSaveFlagToSetOnAcquisition, value: true);
		}
	}

	public static void BaseShopSetupHook(Action<BaseShopController> orig, BaseShopController self)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Invalid comparison between Unknown and I4
		orig(self);
		if ((int)self.baseShopType != 6 || !((Object)(object)self.ExampleBlueprintPrefab != (Object)null))
		{
			return;
		}
		List<ShopItemController> list = (List<ShopItemController>)BaseItemControllersInfo.GetValue(self);
		if (list == null)
		{
			return;
		}
		foreach (ShopItemController item in list)
		{
			if (!((Object)(object)item != (Object)null) || !((Object)(object)item.item != (Object)null) || !((Object)(object)((BraveBehaviour)item.item).encounterTrackable != (Object)null) || ((BraveBehaviour)item.item).encounterTrackable.journalData == null)
			{
				continue;
			}
			PickupObject blueprintUnlockedItem = GetBlueprintUnlockedItem(((BraveBehaviour)item.item).encounterTrackable);
			if (!((Object)(object)blueprintUnlockedItem != (Object)null) || !((Object)(object)((BraveBehaviour)blueprintUnlockedItem).encounterTrackable != (Object)null) || ((BraveBehaviour)blueprintUnlockedItem).encounterTrackable.prerequisites == null)
			{
				continue;
			}
			CustomDungeonFlags customDungeonFlags = CustomDungeonFlags.NONE;
			for (int i = 0; i < ((BraveBehaviour)blueprintUnlockedItem).encounterTrackable.prerequisites.Length; i++)
			{
				if (((BraveBehaviour)blueprintUnlockedItem).encounterTrackable.prerequisites[i] is CustomDungeonPrerequisite && (((BraveBehaviour)blueprintUnlockedItem).encounterTrackable.prerequisites[i] as CustomDungeonPrerequisite).advancedPrerequisiteType == CustomDungeonPrerequisite.AdvancedPrerequisiteType.CUSTOM_FLAG)
				{
					customDungeonFlags = (((BraveBehaviour)blueprintUnlockedItem).encounterTrackable.prerequisites[i] as CustomDungeonPrerequisite).customFlagToCheck;
				}
			}
			if (customDungeonFlags != 0)
			{
				((Component)item.item).gameObject.AddComponent<SpecialPickupObject>().CustomSaveFlagToSetOnAcquisition = customDungeonFlags;
			}
		}
	}

	public static void MetaSetupHook(Action<MetaShopController> orig, MetaShopController meta)
	{
		orig(meta);
		List<ShopItemController> list = (List<ShopItemController>)ItemControllersInfo.GetValue(meta);
		if (list == null)
		{
			return;
		}
		foreach (ShopItemController item in list)
		{
			if (!((Object)(object)item != (Object)null) || !((Object)(object)item.item != (Object)null) || !((Object)(object)((BraveBehaviour)item.item).encounterTrackable != (Object)null) || ((BraveBehaviour)item.item).encounterTrackable.journalData == null)
			{
				continue;
			}
			PickupObject blueprintUnlockedItem = GetBlueprintUnlockedItem(((BraveBehaviour)item.item).encounterTrackable);
			if (!((Object)(object)blueprintUnlockedItem != (Object)null) || !((Object)(object)((BraveBehaviour)blueprintUnlockedItem).encounterTrackable != (Object)null) || ((BraveBehaviour)blueprintUnlockedItem).encounterTrackable.prerequisites == null)
			{
				continue;
			}
			CustomDungeonFlags customFlagFromTargetItem = GetCustomFlagFromTargetItem(blueprintUnlockedItem.PickupObjectId);
			if (customFlagFromTargetItem != 0)
			{
				((Component)item.item).gameObject.AddComponent<SpecialPickupObject>().CustomSaveFlagToSetOnAcquisition = customFlagFromTargetItem;
				if (AdvancedGameStatsManager.Instance.GetFlag(customFlagFromTargetItem))
				{
					item.ForceOutOfStock();
				}
			}
		}
	}

	private static bool GetMetaItemUnlockedAdvanced(int pickupObjectId)
	{
		CustomDungeonFlags customFlagFromTargetItem = GetCustomFlagFromTargetItem(pickupObjectId);
		if (customFlagFromTargetItem == CustomDungeonFlags.NONE)
		{
			return true;
		}
		return AdvancedGameStatsManager.Instance.GetFlag(customFlagFromTargetItem);
	}

	public static MetaShopTier MetaShopCurrentTierHook(Func<MetaShopController, MetaShopTier> orig, MetaShopController self)
	{
		MetaShopTier val = null;
		for (int i = 0; i < self.metaShopTiers.Count; i++)
		{
			if (!GetMetaItemUnlockedAdvanced(self.metaShopTiers[i].itemId1) || !GetMetaItemUnlockedAdvanced(self.metaShopTiers[i].itemId2) || !GetMetaItemUnlockedAdvanced(self.metaShopTiers[i].itemId3))
			{
				val = self.metaShopTiers[i];
				break;
			}
		}
		List<MetaShopTier> metaShopTiers = self.metaShopTiers;
		List<MetaShopTier> list = new List<MetaShopTier>();
		for (int j = 0; j < metaShopTiers.Count; j++)
		{
			if (metaShopTiers[j] != null && (!ItemConditionsFulfilled(metaShopTiers[j].itemId1) || !ItemConditionsFulfilled(metaShopTiers[j].itemId2) || !ItemConditionsFulfilled(metaShopTiers[j].itemId3) || j == metaShopTiers.Count - 1))
			{
				list.Add(metaShopTiers[j]);
			}
		}
		self.metaShopTiers = list;
		MetaShopTier val2 = orig(self);
		self.metaShopTiers = metaShopTiers;
		if (val == null)
		{
			return val2;
		}
		if (val2 == null)
		{
			return val;
		}
		return (self.metaShopTiers.IndexOf(val) < self.metaShopTiers.IndexOf(val2)) ? val : val2;
	}

	public static MetaShopTier MetaShopProximateTierHook(Func<MetaShopController, MetaShopTier> orig, MetaShopController self)
	{
		MetaShopTier val = null;
		for (int i = 0; i < self.metaShopTiers.Count - 1; i++)
		{
			if (!GetMetaItemUnlockedAdvanced(self.metaShopTiers[i].itemId1) || !GetMetaItemUnlockedAdvanced(self.metaShopTiers[i].itemId2) || !GetMetaItemUnlockedAdvanced(self.metaShopTiers[i].itemId3))
			{
				val = self.metaShopTiers[i + 1];
				break;
			}
		}
		List<MetaShopTier> metaShopTiers = self.metaShopTiers;
		List<MetaShopTier> list = new List<MetaShopTier>();
		for (int j = 0; j < metaShopTiers.Count; j++)
		{
			if (metaShopTiers[j] != null && (!ItemConditionsFulfilled(metaShopTiers[j].itemId1) || !ItemConditionsFulfilled(metaShopTiers[j].itemId2) || !ItemConditionsFulfilled(metaShopTiers[j].itemId3)))
			{
				list.Add(metaShopTiers[j]);
			}
		}
		self.metaShopTiers = list;
		MetaShopTier val2 = orig(self);
		self.metaShopTiers = metaShopTiers;
		if (val == null)
		{
			return val2;
		}
		if (val2 == null)
		{
			return val;
		}
		return (self.metaShopTiers.IndexOf(val) < self.metaShopTiers.IndexOf(val2)) ? val : val2;
	}

	public static CustomDungeonFlags GetCustomFlagFromTargetItem(int shopItemId)
	{
		CustomDungeonFlags result = CustomDungeonFlags.NONE;
		PickupObject byId = PickupObjectDatabase.GetById(shopItemId);
		for (int i = 0; i < ((BraveBehaviour)byId).encounterTrackable.prerequisites.Length; i++)
		{
			if (((BraveBehaviour)byId).encounterTrackable.prerequisites[i] is CustomDungeonPrerequisite && (((BraveBehaviour)byId).encounterTrackable.prerequisites[i] as CustomDungeonPrerequisite).advancedPrerequisiteType == CustomDungeonPrerequisite.AdvancedPrerequisiteType.CUSTOM_FLAG)
			{
				result = (((BraveBehaviour)byId).encounterTrackable.prerequisites[i] as CustomDungeonPrerequisite).customFlagToCheck;
			}
		}
		return result;
	}

	public static GungeonFlags GetFlagFromTargetItem(int shopItemId)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Invalid comparison between Unknown and I4
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		GungeonFlags result = (GungeonFlags)0;
		PickupObject byId = PickupObjectDatabase.GetById(shopItemId);
		for (int i = 0; i < ((BraveBehaviour)byId).encounterTrackable.prerequisites.Length; i++)
		{
			if ((int)((BraveBehaviour)byId).encounterTrackable.prerequisites[i].prerequisiteType == 4)
			{
				result = ((BraveBehaviour)byId).encounterTrackable.prerequisites[i].saveFlagToCheck;
			}
		}
		return result;
	}

	public static bool ItemConditionsFulfilled(int shopItemId)
	{
		return (Object)(object)PickupObjectDatabase.GetById(shopItemId) != (Object)null && PickupObjectDatabase.GetById(shopItemId).PrerequisitesMet();
	}

	public static PickupObject GetBlueprintUnlockedItem(EncounterTrackable blueprintTrackable)
	{
		for (int i = 0; i < ((ObjectDatabase<PickupObject>)(object)PickupObjectDatabase.Instance).Objects.Count; i++)
		{
			PickupObject val = ((ObjectDatabase<PickupObject>)(object)PickupObjectDatabase.Instance).Objects[i];
			if (!Object.op_Implicit((Object)(object)val))
			{
				continue;
			}
			EncounterTrackable encounterTrackable = ((BraveBehaviour)val).encounterTrackable;
			if (!Object.op_Implicit((Object)(object)encounterTrackable))
			{
				continue;
			}
			string primaryDisplayName = encounterTrackable.journalData.PrimaryDisplayName;
			if (!primaryDisplayName.Equals(blueprintTrackable.journalData.PrimaryDisplayName, StringComparison.OrdinalIgnoreCase))
			{
				continue;
			}
			string notificationPanelDescription = encounterTrackable.journalData.NotificationPanelDescription;
			if (!notificationPanelDescription.Equals(blueprintTrackable.journalData.NotificationPanelDescription, StringComparison.OrdinalIgnoreCase))
			{
				continue;
			}
			string ammonomiconFullEntry = encounterTrackable.journalData.AmmonomiconFullEntry;
			if (ammonomiconFullEntry.Equals(blueprintTrackable.journalData.AmmonomiconFullEntry, StringComparison.OrdinalIgnoreCase))
			{
				string ammonomiconSprite = encounterTrackable.journalData.AmmonomiconSprite;
				if (ammonomiconSprite.Equals(blueprintTrackable.journalData.AmmonomiconSprite, StringComparison.OrdinalIgnoreCase))
				{
					return val;
				}
			}
		}
		return null;
	}

	public static WeightedGameObject AddItemToTrorcMetaShop(this PickupObject po, int cost, int? index = null)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Expected O, but got Unknown
		if ((Object)(object)TrorcMetaShopItems == (Object)null)
		{
			DoSetup();
		}
		WeightedGameObject val = new WeightedGameObject();
		val.rawGameObject = null;
		val.pickupId = po.PickupObjectId;
		val.weight = cost;
		val.forceDuplicatesPossible = false;
		val.additionalPrerequisites = (DungeonPrerequisite[])(object)new DungeonPrerequisite[0];
		WeightedGameObject val2 = val;
		if (!index.HasValue)
		{
			TrorcMetaShopItems.defaultItemDrops.elements.Add(val2);
		}
		else if (index.Value < 0)
		{
			TrorcMetaShopItems.defaultItemDrops.elements.Add(val2);
		}
		else
		{
			TrorcMetaShopItems.defaultItemDrops.elements.InsertOrAdd(index.Value, val2);
		}
		RegisterBaseShopControllerAddedItem(val2, TrorcMetaShopItems.defaultItemDrops);
		return val2;
	}

	public static WeightedGameObject AddItemToGooptonMetaShop(this PickupObject po, int cost, int? index = null)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Expected O, but got Unknown
		if ((Object)(object)GooptonMetaShopItems == (Object)null)
		{
			DoSetup();
		}
		WeightedGameObject val = new WeightedGameObject();
		val.rawGameObject = null;
		val.pickupId = po.PickupObjectId;
		val.weight = cost;
		val.forceDuplicatesPossible = false;
		val.additionalPrerequisites = (DungeonPrerequisite[])(object)new DungeonPrerequisite[0];
		WeightedGameObject val2 = val;
		if (!index.HasValue)
		{
			GooptonMetaShopItems.defaultItemDrops.elements.Add(val2);
		}
		else if (index.Value < 0)
		{
			TrorcMetaShopItems.defaultItemDrops.elements.Add(val2);
		}
		else
		{
			GooptonMetaShopItems.defaultItemDrops.elements.InsertOrAdd(index.Value, val2);
		}
		RegisterBaseShopControllerAddedItem(val2, GooptonMetaShopItems.defaultItemDrops);
		return val2;
	}

	public static WeightedGameObject AddItemToDougMetaShop(this PickupObject po, int cost, int? index = null)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Expected O, but got Unknown
		if ((Object)(object)DougMetaShopItems == (Object)null)
		{
			DoSetup();
		}
		WeightedGameObject val = new WeightedGameObject();
		val.rawGameObject = null;
		val.pickupId = po.PickupObjectId;
		val.weight = cost;
		val.forceDuplicatesPossible = false;
		val.additionalPrerequisites = (DungeonPrerequisite[])(object)new DungeonPrerequisite[0];
		WeightedGameObject val2 = val;
		if (!index.HasValue)
		{
			DougMetaShopItems.defaultItemDrops.elements.Add(val2);
		}
		else if (index.Value < 0)
		{
			DougMetaShopItems.defaultItemDrops.elements.Add(val2);
		}
		else
		{
			DougMetaShopItems.defaultItemDrops.elements.InsertOrAdd(index.Value, val2);
		}
		RegisterBaseShopControllerAddedItem(val2, DougMetaShopItems.defaultItemDrops);
		return val2;
	}

	private static void RegisterBaseShopControllerAddedItem(WeightedGameObject obj, WeightedGameObjectCollection collection)
	{
		if (baseShopAddedItems == null)
		{
			baseShopAddedItems = new Dictionary<WeightedGameObjectCollection, List<WeightedGameObject>>();
		}
		if (!baseShopAddedItems.ContainsKey(collection))
		{
			baseShopAddedItems.Add(collection, new List<WeightedGameObject>());
		}
		if (baseShopAddedItems[collection] == null)
		{
			baseShopAddedItems[collection] = new List<WeightedGameObject>();
		}
		baseShopAddedItems[collection].Add(obj);
	}

	public static List<MetaShopTier> AddBaseMetaShopDoubleTier(int topLeftItemId, int topLeftItemPrice, int topMiddleItemId, int topMiddleItemPrice, int topRightItemId, int topRightItemPrice, int bottomLeftItemId, int bottomLeftItemPrice, int bottomMiddleItemId, int bottomMiddleItemPrice, int bottomRightItemId, int bottomRightItemPrice, int? index = null)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected O, but got Unknown
		//IL_007a: Expected O, but got Unknown
		return AddBaseMetaShopDoubleTier(new DoubleMetaShopTier(new MetaShopTier
		{
			itemId1 = topLeftItemId,
			overrideItem1Cost = topLeftItemPrice,
			itemId2 = topMiddleItemId,
			overrideItem2Cost = topMiddleItemPrice,
			itemId3 = topRightItemId,
			overrideItem3Cost = topRightItemPrice,
			overrideTierCost = topLeftItemId
		}, new MetaShopTier
		{
			itemId1 = bottomLeftItemId,
			overrideItem1Cost = bottomLeftItemPrice,
			itemId2 = bottomMiddleItemId,
			overrideItem2Cost = bottomMiddleItemPrice,
			itemId3 = bottomRightItemId,
			overrideItem3Cost = bottomRightItemPrice,
			overrideTierCost = topLeftItemId
		}), index);
	}

	public static List<MetaShopTier> AddBaseMetaShopDoubleTier(int topLeftItemId, int topLeftItemPrice, int topMiddleItemId, int topMiddleItemPrice, int topRightItemId, int topRightItemPrice, int bottomLeftItemId, int bottomLeftItemPrice, int bottomMiddleItemId, int bottomMiddleItemPrice, int? index = null)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Expected O, but got Unknown
		//IL_0078: Expected O, but got Unknown
		return AddBaseMetaShopDoubleTier(new DoubleMetaShopTier(new MetaShopTier
		{
			itemId1 = topLeftItemId,
			overrideItem1Cost = topLeftItemPrice,
			itemId2 = topMiddleItemId,
			overrideItem2Cost = topMiddleItemPrice,
			itemId3 = topRightItemId,
			overrideItem3Cost = topRightItemPrice,
			overrideTierCost = topLeftItemId
		}, new MetaShopTier
		{
			itemId1 = bottomLeftItemId,
			overrideItem1Cost = bottomLeftItemPrice,
			itemId2 = bottomMiddleItemId,
			overrideItem2Cost = bottomMiddleItemPrice,
			itemId3 = -1,
			overrideItem3Cost = -1,
			overrideTierCost = topLeftItemId
		}), index);
	}

	public static List<MetaShopTier> AddBaseMetaShopDoubleTier(int topLeftItemId, int topLeftItemPrice, int topMiddleItemId, int topMiddleItemPrice, int topRightItemId, int topRightItemPrice, int bottomLeftItemId, int bottomLeftItemPrice, int? index = null)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Expected O, but got Unknown
		//IL_0076: Expected O, but got Unknown
		return AddBaseMetaShopDoubleTier(new DoubleMetaShopTier(new MetaShopTier
		{
			itemId1 = topLeftItemId,
			overrideItem1Cost = topLeftItemPrice,
			itemId2 = topMiddleItemId,
			overrideItem2Cost = topMiddleItemPrice,
			itemId3 = topRightItemId,
			overrideItem3Cost = topRightItemPrice,
			overrideTierCost = topLeftItemId
		}, new MetaShopTier
		{
			itemId1 = bottomLeftItemId,
			overrideItem1Cost = bottomLeftItemPrice,
			itemId2 = -1,
			overrideItem2Cost = -1,
			itemId3 = -1,
			overrideItem3Cost = -1,
			overrideTierCost = topLeftItemId
		}), index);
	}

	public static MetaShopTier AddBaseMetaShopTier(int leftItemId, int leftItemPrice, int middleItemId, int middleItemPrice, int rightItemId, int rightItemPrice, int? index = null)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected O, but got Unknown
		return AddBaseMetaShopTier(new MetaShopTier
		{
			itemId1 = leftItemId,
			overrideItem1Cost = leftItemPrice,
			itemId2 = middleItemId,
			overrideItem2Cost = middleItemPrice,
			itemId3 = rightItemId,
			overrideItem3Cost = rightItemPrice,
			overrideTierCost = leftItemPrice
		}, index);
	}

	public static MetaShopTier AddBaseMetaShopTier(int leftItemId, int leftItemPrice, int middleItemId, int middleItemPrice, int? index = null)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		return AddBaseMetaShopTier(new MetaShopTier
		{
			itemId1 = leftItemId,
			overrideItem1Cost = leftItemPrice,
			itemId2 = middleItemId,
			overrideItem2Cost = middleItemPrice,
			itemId3 = -1,
			overrideItem3Cost = -1,
			overrideTierCost = leftItemPrice
		}, index);
	}

	public static MetaShopTier AddBaseMetaShopTier(int leftItemId, int leftItemPrice, int? index = null)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		return AddBaseMetaShopTier(new MetaShopTier
		{
			itemId1 = leftItemId,
			overrideItem1Cost = leftItemPrice,
			itemId2 = -1,
			overrideItem2Cost = -1,
			itemId3 = -1,
			overrideItem3Cost = -1,
			overrideTierCost = leftItemPrice
		}, index);
	}

	public static List<MetaShopTier> AddBaseMetaShopDoubleTier(DoubleMetaShopTier tier, int? index = null)
	{
		return new List<MetaShopTier>
		{
			AddBaseMetaShopTier(tier.GetBottomTier(), index),
			AddBaseMetaShopTier(tier.GetTopTier(), index)
		};
	}

	public static MetaShopTier AddBaseMetaShopTier(MetaShopTier tier, int? index = null)
	{
		if ((Object)(object)BaseMetaShopController == (Object)null)
		{
			DoSetup();
		}
		if (!index.HasValue)
		{
			BaseMetaShopController.metaShopTiers.Add(tier);
		}
		else if (index.Value < 0)
		{
			BaseMetaShopController.metaShopTiers.Add(tier);
		}
		else
		{
			BaseMetaShopController.metaShopTiers.InsertOrAdd(index.Value, tier);
		}
		if (metaShopAddedTiers == null)
		{
			metaShopAddedTiers = new List<MetaShopTier>();
		}
		metaShopAddedTiers.Add(tier);
		ReloadInstanceMetaShopTiers();
		return tier;
	}

	public static void ReloadInstanceMetaShopTiers()
	{
		MetaShopController[] array = Object.FindObjectsOfType<MetaShopController>();
		foreach (MetaShopController val in array)
		{
			val.metaShopTiers = SaveTools.CloneList(BaseMetaShopController.metaShopTiers);
		}
	}
}
