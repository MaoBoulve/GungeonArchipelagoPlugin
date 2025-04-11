using System.Collections.Generic;
using System.Reflection;
using Alexandria.DungeonAPI;
using Dungeonator;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class ChanceCard : PassiveItem
{
	public static int ID;

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<ChanceCard>("Chance Card", "Third Chances", "A special card which guarantees access to Chancelots gambling parlour.\n\nThough Chancelot was expelled from the Knights of the Octagonal Table many years ago, all his business cards still falsely claim his knighthood.", "chancecard_icon", assetbundle: true);
		val.quality = (ItemQuality)2;
		ID = val.PickupObjectId;
		val.SetupUnlockOnCustomStat(CustomTrackedStats.CHANCELOT_MONEY_SPENT, 499f, (PrerequisiteOperation)2);
	}

	public static void InitRooms()
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		SharedInjectionData val = ScriptableObject.CreateInstance<SharedInjectionData>();
		val.UseInvalidWeightAsNoInjection = true;
		val.PreventInjectionOfFailedPrerequisites = false;
		val.IsNPCCell = false;
		val.IgnoreUnmetPrerequisiteEntries = false;
		val.OnlyOne = false;
		val.ChanceToSpawnOne = 1f;
		val.AttachedInjectionData = new List<SharedInjectionData>();
		List<ProceduralFlowModifierData> list = new List<ProceduralFlowModifierData>();
		ProceduralFlowModifierData val2 = new ProceduralFlowModifierData();
		val2.annotation = "ChancelotMiniShop";
		val2.DEBUG_FORCE_SPAWN = false;
		val2.OncePerRun = false;
		val2.placementRules = new List<FlowModifierPlacementType> { (FlowModifierPlacementType)1 };
		val2.roomTable = null;
		val2.exactRoom = RoomFactory.BuildNewRoomFromResource("NevernamedsItems/Content/NPCs/Rooms/MiniChancelotShop.newroom", (Assembly)null).room;
		val2.IsWarpWing = false;
		val2.RequiresMasteryToken = false;
		val2.chanceToLock = 0f;
		val2.selectionWeight = 2f;
		val2.chanceToSpawn = 1f;
		val2.RequiredValidPlaceable = null;
		val2.prerequisites = (DungeonPrerequisite[])(object)new DungeonPrerequisite[1]
		{
			new AdvancedDungeonPrerequisite
			{
				advancedAdvancedPrerequisiteType = AdvancedDungeonPrerequisite.AdvancedAdvancedPrerequisiteType.PASSIVE_ITEM_FLAG,
				requiredPassiveFlag = typeof(ChanceCard),
				requireTileset = false
			}
		};
		val2.CanBeForcedSecret = false;
		val2.RandomNodeChildMinDistanceFromEntrance = 0;
		val2.exactSecondaryRoom = null;
		val2.framedCombatNodes = 0;
		list.Add(val2);
		val.InjectionData = list;
		((Object)val).name = "ChancelotMiniShops";
		SharedInjectionData val3 = LoadHelper.LoadAssetFromAnywhere<SharedInjectionData>("Base Shared Injection Data");
		if (val3.AttachedInjectionData == null)
		{
			val3.AttachedInjectionData = new List<SharedInjectionData>();
		}
		val3.AttachedInjectionData.Add(val);
	}

	public override void Pickup(PlayerController player)
	{
		PassiveItem.IncrementFlag(player, typeof(ChanceCard));
		((PassiveItem)this).Pickup(player);
	}

	public override void DisableEffect(PlayerController player)
	{
		PassiveItem.DecrementFlag(player, typeof(ChanceCard));
		((PassiveItem)this).DisableEffect(player);
	}
}
