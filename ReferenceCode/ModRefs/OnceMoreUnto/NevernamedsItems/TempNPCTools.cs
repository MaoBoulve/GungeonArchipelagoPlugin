using System;
using System.Collections.Generic;
using System.Reflection;
using Alexandria.ItemAPI;
using Alexandria.NPCAPI;
using Dungeonator;
using HutongGames.PlayMaker;
using UnityEngine;

namespace NevernamedsItems;

internal class TempNPCTools
{
	public static GameObject MakeIntoShopkeeper(string name, string prefix, GameObject npcOBJ, string idleName, string talkName, tk2dSpriteCollectionData spriteCollection, tk2dSpriteAnimation animLibrary, GenericLootTable lootTable, ShopCurrencyType currency, string runBasedMultilineGenericStringKey, string runBasedMultilineStopperStringKey, string purchaseItemStringKey, string purchaseItemFailedStringKey, string introStringKey, string attackedStringKey, string stolenFromStringKey, Vector3 talkPointOffset, Vector3 npcOffset, string voice = "oldman", Vector3[] itemPositions = null, float costModifier = 1f, bool giveStatsOnPurchase = false, StatModifier[] statsToGiveOnPurchase = null, Func<CustomShopController, PlayerController, int, bool> CustomCanBuy = null, Func<CustomShopController, PlayerController, int, int> CustomRemoveCurrency = null, Func<CustomShopController, CustomShopItemController, PickupObject, int> CustomPrice = null, Func<PlayerController, PickupObject, int, bool> OnPurchase = null, Func<PlayerController, PickupObject, int, bool> OnSteal = null, string currencyIconPath = "", string currencyName = "", bool canBeRobbed = true, string Carpet = "", Vector2? CarpetOffset = null, bool hasMinimapIcon = false, GameObject minimapIcon = null, bool addToShopAnnex = false, float shopAnnexWeight = 0.1f, DungeonPrerequisite[] prerequisites = null, float fortunesFavorRadius = 2f, ShopItemPoolType poolType = 0, bool RainbowModeImmunity = false)
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected O, but got Unknown
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0201: Expected O, but got Unknown
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_023c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0243: Expected O, but got Unknown
		//IL_0246: Unknown result type (might be due to invalid IL or missing references)
		//IL_0493: Unknown result type (might be due to invalid IL or missing references)
		//IL_049a: Expected O, but got Unknown
		//IL_04a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_053d: Unknown result type (might be due to invalid IL or missing references)
		//IL_053f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0556: Unknown result type (might be due to invalid IL or missing references)
		//IL_0559: Invalid comparison between Unknown and I4
		//IL_05be: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0722: Unknown result type (might be due to invalid IL or missing references)
		//IL_0756: Unknown result type (might be due to invalid IL or missing references)
		//IL_0760: Expected O, but got Unknown
		//IL_084b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0852: Expected O, but got Unknown
		//IL_0867: Unknown result type (might be due to invalid IL or missing references)
		//IL_086c: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0799: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (prerequisites == null)
			{
				prerequisites = (DungeonPrerequisite[])(object)new DungeonPrerequisite[0];
			}
			AssetBundle val = ResourceManager.LoadAssetBundle("shared_auto_001");
			AssetBundle val2 = ResourceManager.LoadAssetBundle("shared_auto_002");
			GameObject val3 = new GameObject("SpeechPoint");
			val3.transform.position = talkPointOffset;
			FakePrefab.MarkAsFakePrefab(npcOBJ);
			Object.DontDestroyOnLoad((Object)(object)npcOBJ);
			npcOBJ.SetActive(false);
			npcOBJ.layer = 22;
			tk2dSpriteCollectionData collection = ((tk2dBaseSprite)npcOBJ.GetComponent<tk2dSprite>()).Collection;
			val3.transform.parent = npcOBJ.transform;
			FakePrefab.MarkAsFakePrefab(val3);
			Object.DontDestroyOnLoad((Object)(object)val3);
			val3.SetActive(true);
			tk2dSpriteAnimator orAddComponent = GameObjectExtensions.GetOrAddComponent<tk2dSpriteAnimator>(npcOBJ);
			orAddComponent.Library = animLibrary;
			TalkDoerLite val4 = npcOBJ.AddComponent<TalkDoerLite>();
			((DungeonPlaceableBehaviour)val4).placeableWidth = 4;
			((DungeonPlaceableBehaviour)val4).placeableHeight = 3;
			((DungeonPlaceableBehaviour)val4).difficulty = (PlaceableDifficulty)0;
			((DungeonPlaceableBehaviour)val4).isPassable = true;
			val4.usesOverrideInteractionRegion = false;
			val4.overrideRegionOffset = Vector2.zero;
			val4.overrideRegionDimensions = Vector2.zero;
			val4.overrideInteractionRadius = -1f;
			val4.PreventInteraction = false;
			val4.AllowPlayerToPassEventually = true;
			val4.speakPoint = val3.transform;
			val4.SpeaksGleepGlorpenese = false;
			val4.audioCharacterSpeechTag = voice;
			val4.playerApproachRadius = 5f;
			val4.conversationBreakRadius = 5f;
			val4.echo1 = null;
			val4.echo2 = null;
			val4.PreventCoopInteraction = false;
			val4.IsPaletteSwapped = false;
			val4.PaletteTexture = null;
			val4.OutlineDepth = 0.5f;
			val4.OutlineLuminanceCutoff = 0.05f;
			val4.MovementSpeed = 3f;
			val4.PathableTiles = (CellTypes)2;
			UltraFortunesFavor val5 = npcOBJ.AddComponent<UltraFortunesFavor>();
			val5.goopRadius = fortunesFavorRadius;
			val5.beamRadius = fortunesFavorRadius;
			val5.bulletRadius = fortunesFavorRadius;
			val5.bulletSpeedModifier = 0.8f;
			val5.vfxOffset = 0.625f;
			val5.sparkOctantVFX = val.LoadAsset<GameObject>("FortuneFavor_VFX_Spark");
			AIAnimator val6 = ShopAPI.GenerateBlankAIAnimator(npcOBJ);
			((BraveBehaviour)val6).spriteAnimator = orAddComponent;
			DirectionalAnimation val7 = new DirectionalAnimation();
			val7.Type = (DirectionType)1;
			val7.Prefix = idleName;
			val7.AnimNames = new string[1] { "" };
			val7.Flipped = (FlipType[])(object)new FlipType[1];
			val6.IdleAnimation = val7;
			val7 = new DirectionalAnimation();
			val7.Type = (DirectionType)1;
			val7.Prefix = talkName;
			val7.AnimNames = new string[1] { "" };
			val7.Flipped = (FlipType[])(object)new FlipType[1];
			val6.TalkAnimation = val7;
			GameObject gameObject = ((Component)ResourceManager.LoadAssetBundle("shared_auto_001").LoadAsset<GameObject>("Merchant_Key").transform.Find("NPC_Key")).gameObject;
			PlayMakerFSM val8 = npcOBJ.AddComponent<PlayMakerFSM>();
			JsonUtility.FromJsonOverwrite(JsonUtility.ToJson((object)gameObject.GetComponent<PlayMakerFSM>()), (object)val8);
			FieldInfo field = typeof(ActionData).GetField("fsmStringParams", BindingFlags.Instance | BindingFlags.NonPublic);
			(field.GetValue(val8.FsmStates[1].ActionData) as List<FsmString>)[0].Value = runBasedMultilineGenericStringKey;
			(field.GetValue(val8.FsmStates[1].ActionData) as List<FsmString>)[1].Value = runBasedMultilineStopperStringKey;
			(field.GetValue(val8.FsmStates[4].ActionData) as List<FsmString>)[0].Value = purchaseItemStringKey;
			(field.GetValue(val8.FsmStates[5].ActionData) as List<FsmString>)[0].Value = purchaseItemFailedStringKey;
			(field.GetValue(val8.FsmStates[7].ActionData) as List<FsmString>)[0].Value = introStringKey;
			(field.GetValue(val8.FsmStates[8].ActionData) as List<FsmString>)[0].Value = attackedStringKey;
			(field.GetValue(val8.FsmStates[9].ActionData) as List<FsmString>)[0].Value = stolenFromStringKey;
			(field.GetValue(val8.FsmStates[9].ActionData) as List<FsmString>)[1].Value = stolenFromStringKey;
			(field.GetValue(val8.FsmStates[10].ActionData) as List<FsmString>)[0].Value = "#SHOP_GENERIC_NO_SALE_LABEL";
			(field.GetValue(val8.FsmStates[12].ActionData) as List<FsmString>)[0].Value = "#COOP_REBUKE";
			List<Transform> list = new List<Transform>();
			for (int i = 0; i < itemPositions.Length; i++)
			{
				GameObject val9 = new GameObject("ItemPoint" + i);
				val9.transform.position = itemPositions[i];
				FakePrefab.MarkAsFakePrefab(val9);
				Object.DontDestroyOnLoad((Object)(object)val9);
				val9.SetActive(true);
				list.Add(val9.transform);
			}
			CustomShopController val10 = new GameObject(prefix + ":" + name + "_Shop").AddComponent<CustomShopController>();
			val10.AllowedToSpawnOnRainbowMode = RainbowModeImmunity;
			FakePrefab.MarkAsFakePrefab(((Component)val10).gameObject);
			Object.DontDestroyOnLoad((Object)(object)((Component)val10).gameObject);
			((Component)val10).gameObject.SetActive(false);
			val10.currencyType = currency;
			val10.ActionAndFuncSetUp(CustomCanBuy, CustomRemoveCurrency, CustomPrice, OnPurchase, OnSteal);
			if ((int)currency == 4)
			{
				if (!string.IsNullOrEmpty(currencyIconPath))
				{
					val10.customPriceSprite = ShopAPI.AddCustomCurrencyType(currencyIconPath, prefix + ":" + currencyName, Assembly.GetCallingAssembly());
				}
				else
				{
					val10.customPriceSprite = currencyName;
				}
			}
			val10.canBeRobbed = canBeRobbed;
			((DungeonPlaceableBehaviour)val10).placeableHeight = 5;
			((DungeonPlaceableBehaviour)val10).placeableWidth = 5;
			((DungeonPlaceableBehaviour)val10).difficulty = (PlaceableDifficulty)0;
			((DungeonPlaceableBehaviour)val10).isPassable = true;
			((BaseShopController)val10).baseShopType = (AdditionalShopType)5;
			((BaseShopController)val10).FoyerMetaShopForcedTiers = false;
			((BaseShopController)val10).IsBeetleMerchant = false;
			((BaseShopController)val10).ExampleBlueprintPrefab = null;
			val10.poolType = poolType;
			((BaseShopController)val10).shopItems = lootTable;
			((BaseShopController)val10).spawnPositions = list.ToArray();
			Transform[] spawnPositions = ((BaseShopController)val10).spawnPositions;
			foreach (Transform val11 in spawnPositions)
			{
				val11.parent = ((Component)val10).gameObject.transform;
			}
			((BaseShopController)val10).shopItemsGroup2 = null;
			((BaseShopController)val10).spawnPositionsGroup2 = null;
			((BaseShopController)val10).spawnGroupTwoItem1Chance = 0.5f;
			((BaseShopController)val10).spawnGroupTwoItem2Chance = 0.5f;
			((BaseShopController)val10).spawnGroupTwoItem3Chance = 0.5f;
			((BaseShopController)val10).shopkeepFSM = npcOBJ.GetComponent<PlayMakerFSM>();
			((BaseShopController)val10).shopItemShadowPrefab = val.LoadAsset<GameObject>("Merchant_Key").GetComponent<BaseShopController>().shopItemShadowPrefab;
			val10.prerequisites = prerequisites;
			((BaseShopController)val10).cat = null;
			if (hasMinimapIcon)
			{
				((BaseShopController)val10).OptionalMinimapIcon = (GameObject)(((Object)(object)minimapIcon != (Object)null) ? ((object)minimapIcon) : ((object)/*isinst with value type is only supported in some contexts*/));
			}
			((BaseShopController)val10).ShopCostModifier = costModifier;
			((BaseShopController)val10).FlagToSetOnEncounter = (GungeonFlags)0;
			val10.giveStatsOnPurchase = giveStatsOnPurchase;
			val10.statsToGive = statsToGiveOnPurchase;
			npcOBJ.transform.parent = ((Component)val10).gameObject.transform;
			npcOBJ.transform.position = npcOffset;
			if (!string.IsNullOrEmpty(Carpet))
			{
				GameObject val12 = ItemBuilder.SpriteFromBundle(Carpet, Initialisation.NPCCollection.GetSpriteIdByName(Carpet), Initialisation.NPCCollection, new GameObject("Carpet"));
				((tk2dBaseSprite)val12.GetComponent<tk2dSprite>()).SortingOrder = 2;
				FakePrefab.MarkAsFakePrefab(val12);
				Object.DontDestroyOnLoad((Object)(object)val12);
				val12.SetActive(true);
				if (!CarpetOffset.HasValue)
				{
					CarpetOffset = Vector2.zero;
				}
				val12.transform.position = new Vector3(CarpetOffset.Value.x, CarpetOffset.Value.y, 1.7f);
				val12.transform.parent = ((Component)val10).gameObject.transform;
				val12.layer = 20;
				((BraveBehaviour)val12.GetComponent<tk2dSprite>()).renderer.material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTilted");
				((tk2dBaseSprite)val12.GetComponent<tk2dSprite>()).usesOverrideMaterial = true;
			}
			npcOBJ.SetActive(true);
			if (addToShopAnnex)
			{
				List<DungeonPlaceableVariant> variantTiers = val2.LoadAsset<DungeonPlaceable>("shopannex_contents_01").variantTiers;
				DungeonPlaceableVariant val13 = new DungeonPlaceableVariant();
				val13.percentChance = shopAnnexWeight;
				val13.unitOffset = new Vector2(-0.5f, -1.25f);
				val13.nonDatabasePlaceable = ((Component)val10).gameObject;
				val13.enemyPlaceableGuid = "";
				val13.pickupObjectPlaceableId = -1;
				val13.forceBlackPhantom = false;
				val13.addDebrisObject = false;
				val13.prerequisites = prerequisites;
				val13.materialRequirements = (DungeonPlaceableRoomMaterialRequirement[])(object)new DungeonPlaceableRoomMaterialRequirement[0];
				variantTiers.Add(val13);
			}
			ShopAPI.builtShops.Add(prefix + ":" + name, ((Component)val10).gameObject);
			return ((Component)val10).gameObject;
		}
		catch (Exception ex)
		{
			ETGModConsole.Log((object)ex.ToString(), false);
			return null;
		}
	}
}
