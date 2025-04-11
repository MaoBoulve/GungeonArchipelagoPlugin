using Alexandria.ItemAPI;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

internal class ExoticPlaceables
{
	public static GameObject secretroomlayout;

	public static GameObject SignUp;

	public static GameObject SignLeft;

	public static GameObject SignRight;

	public static GameObject Crates;

	public static GameObject Crate;

	public static GameObject Sack;

	public static GameObject ShellBarrel;

	public static GameObject Shelf;

	public static GameObject Mask;

	public static GameObject Wallsword;

	public static GameObject StandingShelf;

	public static GameObject AKBarrel;

	public static GameObject Stool;

	public static GameObject TeleporterSign;

	public static GameObject ShopLayout;

	public static GenericRoomTable FireplaceRoomTable;

	public static GenericRoomTable RewardCellTable;

	public static GameObject OubTrapdoor;

	public static GameObject OubButton;

	public static GameObject NonRatStealableArmor;

	public static GameObject NonRatStealableAmmo;

	public static GameObject NonRatStealableSpreadAmmo;

	public static GameObject MapPlaceable;

	public static GameObject GlassGuonPlaceable;

	public static GameObject FiftyCasingPlaceable;

	public static GameObject SingleCasingPlaceable;

	public static GameObject FiveCasingPlaceable;

	public static GameObject HorizontalCrusher;

	public static GameObject VerticalCrusher;

	public static GameObject FireBarTrap;

	public static GameObject FlamePipeNorth;

	public static GameObject FlamePipeEast;

	public static GameObject FlamePipeWest;

	public static GameObject FlameburstTrap;

	public static GameObject MopAndBucket;

	public static GameObject SecretRoomSkeleton;

	public static GameObject Pew;

	public static GameObject OldKingThrone;

	public static GameObject BulletKingThrone;

	public static GameObject AlienTank;

	public static GameObject DecorativeElectricFloor;

	public static GameObject AgunimBossMatt;

	public static GameObject TallComputerBreakable;

	public static GameObject VentilationTube;

	public static GameObject HologramWallVertical;

	public static GameObject HologramWallHorizontal;

	public static GameObject MetalCrate;

	public static GameObject WideComputerBreakable;

	public static GameObject TechnoFloorCellSpider;

	public static GameObject TechnoFloorCellLeever;

	public static GameObject TechnoFloorCellCaterpillar;

	public static GameObject TechnoFloorCellEmpty;

	public static GameObject LargeDesk;

	public static GameObject GlassWallHorizontal;

	public static GameObject GlassWallVertical;

	public static GameObject ToiletWest;

	public static GameObject ToiletEast;

	public static GameObject ToiletNorth;

	public static GameObject BathroomStallDividerWest;

	public static GameObject BathroomStallDividerEast;

	public static GameObject BathroomStallDividerNorth;

	public static GameObject SteelTableVertical;

	public static GameObject SteelTableHorizontal;

	public static GameObject KitchenCounter;

	public static GameObject KitchenChairRight;

	public static GameObject KitchenChairLeft;

	public static GameObject KitchenChairFront;

	public static GameObject ACVent;

	public static GameObject ACUnit;

	public static GameObject CardboardBox3;

	public static GameObject abbeylight;

	public static GameObject abbeylightside;

	public static GameObject tanpot;

	public static GameObject skel0;

	public static GameObject skel1;

	public static GameObject skel2;

	public static GameObject skel3;

	public static GameObject skel6;

	public static GameObject skel7;

	public static GameObject anvil1;

	public static GameObject anvil2;

	public static GameObject helleton;

	public static GameObject helletonside;

	public static GameObject rnglight;

	public static GameObject rnglightside;

	public static GameObject futurelight;

	public static GameObject futurelightside;

	public static GameObject forgelight;

	public static GameObject forgelightside;

	public static GameObject crumbletrap;

	public static GameObject dragunVertebrae = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)EnemyDatabase.GetOrLoadByGuid("465da2bb086a4a88a803f79fe3a27677")).GetComponent<DraGunDeathController>().neckDebris);

	public static GameObject dragunSkull = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)EnemyDatabase.GetOrLoadByGuid("465da2bb086a4a88a803f79fe3a27677")).GetComponent<DraGunDeathController>().skullDebris);

	public static void Init()
	{
		NonRatStealableArmor = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)PickupObjectDatabase.GetById(120)).gameObject);
		NonRatStealableArmor.GetComponent<PickupObject>().IgnoredByRat = true;
		NonRatStealableAmmo = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)PickupObjectDatabase.GetById(78)).gameObject);
		NonRatStealableAmmo.GetComponent<PickupObject>().IgnoredByRat = true;
		NonRatStealableSpreadAmmo = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)PickupObjectDatabase.GetById(600)).gameObject);
		NonRatStealableSpreadAmmo.GetComponent<PickupObject>().IgnoredByRat = true;
		MapPlaceable = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)PickupObjectDatabase.GetById(137)).gameObject);
		MapPlaceable.GetComponent<PickupObject>().IgnoredByRat = true;
		GameObjectExtensions.GetOrAddComponent<SquishyBounceWiggler>(MapPlaceable);
		GlassGuonPlaceable = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)PickupObjectDatabase.GetById(565)).gameObject);
		GlassGuonPlaceable.GetComponent<PickupObject>().IgnoredByRat = true;
		GameObjectExtensions.GetOrAddComponent<SquishyBounceWiggler>(GlassGuonPlaceable);
		dragunSkull.GetComponent<MajorBreakable>().SpawnItemOnBreak = false;
		if (Object.op_Implicit((Object)(object)dragunSkull.GetComponent<DebrisObject>()))
		{
			Object.Destroy((Object)(object)dragunSkull.GetComponent<DebrisObject>());
		}
		if (Object.op_Implicit((Object)(object)dragunVertebrae.GetComponent<DebrisObject>()))
		{
			Object.Destroy((Object)(object)dragunVertebrae.GetComponent<DebrisObject>());
		}
		FiftyCasingPlaceable = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)PickupObjectDatabase.GetById(74)).gameObject);
		if (Object.op_Implicit((Object)(object)FiftyCasingPlaceable.GetComponent<PickupMover>()))
		{
			Object.Destroy((Object)(object)FiftyCasingPlaceable.GetComponent<PickupMover>());
		}
		SingleCasingPlaceable = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)PickupObjectDatabase.GetById(68)).gameObject);
		if (Object.op_Implicit((Object)(object)SingleCasingPlaceable.GetComponent<PickupMover>()))
		{
			Object.Destroy((Object)(object)SingleCasingPlaceable.GetComponent<PickupMover>());
		}
		FiveCasingPlaceable = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)PickupObjectDatabase.GetById(70)).gameObject);
		if (Object.op_Implicit((Object)(object)FiveCasingPlaceable.GetComponent<PickupMover>()))
		{
			Object.Destroy((Object)(object)FiveCasingPlaceable.GetComponent<PickupMover>());
		}
		BulletKingThrone = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)EnemyDatabase.GetOrLoadByGuid("ffca09398635467da3b1f4a54bcfda80")).GetComponent<BulletKingDeathController>().thronePrefab);
		OldKingThrone = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)EnemyDatabase.GetOrLoadByGuid("5729c8b5ffa7415bb3d01205663a33ef")).GetComponent<BulletKingDeathController>().thronePrefab);
		GameObject val = LoadHelper.LoadAssetFromAnywhere<GameObject>("assets/data/prefabs/interactable objects/notes/skeleton_note_001.prefab");
		SecretRoomSkeleton = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)val.transform.Find("skleleton")).gameObject);
		Dungeon orLoadByName = DungeonDatabase.GetOrLoadByName("base_sewer");
		foreach (WeightedRoom element in orLoadByName.PatternSettings.flows[0].fallbackRoomTable.includedRooms.elements)
		{
			if ((Object)(object)element.room != (Object)null && !string.IsNullOrEmpty(((Object)element.room).name) && ((Object)element.room).name.ToLower().StartsWith("sewer_trash_compactor_001"))
			{
				HorizontalCrusher = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)element.room.placedObjects[0].nonenemyBehaviour).gameObject);
			}
		}
		orLoadByName = null;
		Dungeon orLoadByName2 = DungeonDatabase.GetOrLoadByName("base_cathedral");
		foreach (WeightedRoom element2 in orLoadByName2.PatternSettings.flows[0].fallbackRoomTable.includedRooms.elements)
		{
			if ((Object)(object)element2.room != (Object)null && !string.IsNullOrEmpty(((Object)element2.room).name) && ((Object)element2.room).name.ToLower().StartsWith("cathedral_brent_standard_02"))
			{
				Pew = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)element2.room.placedObjects[0].nonenemyBehaviour).gameObject);
			}
		}
		abbeylight = ((ObjectStampData)orLoadByName2.roomMaterialDefinitions[0].facewallLightStamps[0]).objectReference;
		abbeylightside = ((ObjectStampData)orLoadByName2.roomMaterialDefinitions[0].sidewallLightStamps[0]).objectReference;
		tanpot = orLoadByName2.stampData.objectStamps[14].objectReference;
		orLoadByName2 = null;
		Dungeon orLoadByName3 = DungeonDatabase.GetOrLoadByName("base_nakatomi");
		if (Object.op_Implicit((Object)(object)orLoadByName3))
		{
			rnglight = ((ObjectStampData)orLoadByName3.roomMaterialDefinitions[0].facewallLightStamps[0]).objectReference;
			rnglightside = ((ObjectStampData)orLoadByName3.roomMaterialDefinitions[0].sidewallLightStamps[0]).objectReference;
			futurelight = ((ObjectStampData)orLoadByName3.roomMaterialDefinitions[7].facewallLightStamps[0]).objectReference;
			futurelightside = ((ObjectStampData)orLoadByName3.roomMaterialDefinitions[7].sidewallLightStamps[0]).objectReference;
			if (((Object)orLoadByName3.PatternSettings.flows[0]).name == "FS4_Nakatomi_Flow")
			{
				if (orLoadByName3.PatternSettings.flows[0].AllNodes.Count == 14)
				{
					MopAndBucket = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)orLoadByName3.PatternSettings.flows[0].AllNodes[0].overrideExactRoom.placedObjects[0].nonenemyBehaviour).gameObject);
					CardboardBox3 = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)orLoadByName3.PatternSettings.flows[0].AllNodes[0].overrideExactRoom.placedObjects[2].nonenemyBehaviour).gameObject);
					ACUnit = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)orLoadByName3.PatternSettings.flows[0].AllNodes[1].overrideExactRoom.placedObjects[1].nonenemyBehaviour).gameObject);
					ACVent = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)orLoadByName3.PatternSettings.flows[0].AllNodes[1].overrideExactRoom.placedObjects[2].nonenemyBehaviour).gameObject);
					KitchenChairFront = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)orLoadByName3.PatternSettings.flows[0].AllNodes[4].overrideExactRoom.placedObjects[1].nonenemyBehaviour).gameObject);
					KitchenChairLeft = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)orLoadByName3.PatternSettings.flows[0].AllNodes[4].overrideExactRoom.placedObjects[8].nonenemyBehaviour).gameObject);
					KitchenChairRight = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)orLoadByName3.PatternSettings.flows[0].AllNodes[4].overrideExactRoom.placedObjects[12].nonenemyBehaviour).gameObject);
					KitchenCounter = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)orLoadByName3.PatternSettings.flows[0].AllNodes[4].overrideExactRoom.placedObjects[16].nonenemyBehaviour).gameObject);
					SteelTableHorizontal = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)orLoadByName3.PatternSettings.flows[0].AllNodes[4].overrideExactRoom.placedObjects[6].nonenemyBehaviour).gameObject);
					SteelTableVertical = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)orLoadByName3.PatternSettings.flows[0].AllNodes[4].overrideExactRoom.placedObjects[3].nonenemyBehaviour).gameObject);
					BathroomStallDividerNorth = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)orLoadByName3.PatternSettings.flows[0].AllNodes[6].overrideExactRoom.placedObjects[0].nonenemyBehaviour).gameObject);
					BathroomStallDividerEast = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)orLoadByName3.PatternSettings.flows[0].AllNodes[6].overrideExactRoom.placedObjects[6].nonenemyBehaviour).gameObject);
					BathroomStallDividerWest = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)orLoadByName3.PatternSettings.flows[0].AllNodes[6].overrideExactRoom.placedObjects[9].nonenemyBehaviour).gameObject);
					ToiletNorth = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)orLoadByName3.PatternSettings.flows[0].AllNodes[6].overrideExactRoom.placedObjects[2].nonenemyBehaviour).gameObject);
					ToiletEast = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)orLoadByName3.PatternSettings.flows[0].AllNodes[6].overrideExactRoom.placedObjects[7].nonenemyBehaviour).gameObject);
					ToiletWest = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)orLoadByName3.PatternSettings.flows[0].AllNodes[6].overrideExactRoom.placedObjects[10].nonenemyBehaviour).gameObject);
					GlassWallVertical = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)orLoadByName3.PatternSettings.flows[0].AllNodes[7].overrideExactRoom.placedObjects[0].nonenemyBehaviour).gameObject);
					GlassWallHorizontal = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)orLoadByName3.PatternSettings.flows[0].AllNodes[7].overrideExactRoom.placedObjects[6].nonenemyBehaviour).gameObject);
					LargeDesk = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)orLoadByName3.PatternSettings.flows[0].AllNodes[8].overrideExactRoom.placedObjects[0].nonenemyBehaviour).gameObject);
					TechnoFloorCellEmpty = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)orLoadByName3.PatternSettings.flows[0].AllNodes[10].overrideExactRoom.placedObjects[0].nonenemyBehaviour).gameObject);
					TechnoFloorCellCaterpillar = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)orLoadByName3.PatternSettings.flows[0].AllNodes[10].overrideExactRoom.placedObjects[4].nonenemyBehaviour).gameObject);
					TechnoFloorCellLeever = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)orLoadByName3.PatternSettings.flows[0].AllNodes[10].overrideExactRoom.placedObjects[13].nonenemyBehaviour).gameObject);
					TechnoFloorCellSpider = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)orLoadByName3.PatternSettings.flows[0].AllNodes[10].overrideExactRoom.placedObjects[14].nonenemyBehaviour).gameObject);
					WideComputerBreakable = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)orLoadByName3.PatternSettings.flows[0].AllNodes[10].overrideExactRoom.placedObjects[6].nonenemyBehaviour).gameObject);
					MetalCrate = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)orLoadByName3.PatternSettings.flows[0].AllNodes[10].overrideExactRoom.placedObjects[10].nonenemyBehaviour).gameObject);
					HologramWallHorizontal = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)orLoadByName3.PatternSettings.flows[0].AllNodes[11].overrideExactRoom.placedObjects[0].nonenemyBehaviour).gameObject);
					HologramWallVertical = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)orLoadByName3.PatternSettings.flows[0].AllNodes[11].overrideExactRoom.placedObjects[7].nonenemyBehaviour).gameObject);
					VentilationTube = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)orLoadByName3.PatternSettings.flows[0].AllNodes[11].overrideExactRoom.placedObjects[8].nonenemyBehaviour).gameObject);
					TallComputerBreakable = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)orLoadByName3.PatternSettings.flows[0].AllNodes[11].overrideExactRoom.placedObjects[13].nonenemyBehaviour).gameObject);
					AgunimBossMatt = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)orLoadByName3.PatternSettings.flows[0].AllNodes[12].overrideExactRoom.placedObjects[1].nonenemyBehaviour).gameObject);
					AlienTank = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)orLoadByName3.PatternSettings.flows[0].AllNodes[13].overrideExactRoom.placedObjects[9].nonenemyBehaviour).gameObject);
					DecorativeElectricFloor = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)orLoadByName3.PatternSettings.flows[0].AllNodes[13].overrideExactRoom.placedObjects[29].nonenemyBehaviour).gameObject);
				}
				else
				{
					ETGModConsole.Log((object)"<color=#ff0000ff>ERROR: R&G DEPARTMENT FLOW 0 HAS AN INCORRECT AMOUNT OF NODES</color>", false);
				}
			}
			else
			{
				ETGModConsole.Log((object)"<color=#ff0000ff>ERROR: R&G DEPARTMENT FLOW 0 HAS AN INCORRECT NAME, AND HAS BEEN ALTERED</color>", false);
			}
		}
		else
		{
			ETGModConsole.Log((object)"<color=#ff0000ff>ERROR: R&G DEPARTMENT DUNGEON PREFAB WAS NULL</color>", false);
		}
		orLoadByName3 = null;
		Dungeon orLoadByName4 = DungeonDatabase.GetOrLoadByName("base_forge");
		anvil1 = orLoadByName4.stampData.objectStamps[6].objectReference;
		anvil2 = orLoadByName4.stampData.objectStamps[7].objectReference;
		forgelight = ((ObjectStampData)orLoadByName4.roomMaterialDefinitions[0].facewallLightStamps[0]).objectReference;
		forgelightside = ((ObjectStampData)orLoadByName4.roomMaterialDefinitions[0].sidewallLightStamps[0]).objectReference;
		foreach (WeightedRoom element3 in orLoadByName4.PatternSettings.flows[0].fallbackRoomTable.includedRooms.elements)
		{
			if ((Object)(object)element3.room != (Object)null && !string.IsNullOrEmpty(((Object)element3.room).name))
			{
				if (((Object)element3.room).name.ToLower().StartsWith("forge_normal_cubulead_03"))
				{
					VerticalCrusher = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)element3.room.placedObjects[0].nonenemyBehaviour).gameObject);
					FireBarTrap = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)element3.room.placedObjects[7].nonenemyBehaviour).gameObject);
				}
				if (((Object)element3.room).name.ToLower().StartsWith("forge_connector_flamepipes_01"))
				{
					FlamePipeNorth = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)element3.room.placedObjects[1].nonenemyBehaviour).gameObject);
					FlamePipeWest = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)element3.room.placedObjects[3].nonenemyBehaviour).gameObject);
					FlamePipeEast = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)element3.room.placedObjects[2].nonenemyBehaviour).gameObject);
				}
			}
		}
		orLoadByName4 = null;
		Dungeon orLoadByName5 = DungeonDatabase.GetOrLoadByName("base_bullethell");
		foreach (WeightedRoom element4 in orLoadByName5.PatternSettings.flows[0].fallbackRoomTable.includedRooms.elements)
		{
			if ((Object)(object)element4.room != (Object)null && !string.IsNullOrEmpty(((Object)element4.room).name) && ((Object)element4.room).name.ToLower().StartsWith("hell_connector_pathburst_01"))
			{
				FlameburstTrap = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)element4.room.placedObjects[3].nonenemyBehaviour).gameObject);
			}
		}
		helleton = ((ObjectStampData)orLoadByName5.roomMaterialDefinitions[0].facewallLightStamps[0]).objectReference;
		helletonside = ((ObjectStampData)orLoadByName5.roomMaterialDefinitions[0].sidewallLightStamps[0]).objectReference;
		orLoadByName5 = null;
		Dungeon orLoadByName6 = DungeonDatabase.GetOrLoadByName("base_catacombs");
		skel0 = orLoadByName6.stampData.objectStamps[0].objectReference;
		skel1 = orLoadByName6.stampData.objectStamps[1].objectReference;
		skel2 = orLoadByName6.stampData.objectStamps[2].objectReference;
		skel3 = orLoadByName6.stampData.objectStamps[3].objectReference;
		skel6 = orLoadByName6.stampData.objectStamps[6].objectReference;
		skel7 = orLoadByName6.stampData.objectStamps[7].objectReference;
		orLoadByName6 = null;
		Dungeon orLoadByName7 = DungeonDatabase.GetOrLoadByName("finalscenario_bullet");
		crumbletrap = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)orLoadByName7.PatternSettings.flows[0].AllNodes[3].overrideExactRoom.placedObjects[1].nonenemyBehaviour).gameObject);
		orLoadByName7 = null;
		Dungeon orLoadByName8 = DungeonDatabase.GetOrLoadByName("base_castle");
		FireplaceRoomTable = orLoadByName8.PatternSettings.flows[0].sharedInjectionData[1].InjectionData[1].roomTable;
		RewardCellTable = orLoadByName8.PatternSettings.flows[0].sharedInjectionData[0].InjectionData[1].roomTable;
		OubTrapdoor = ((Component)orLoadByName8.PatternSettings.flows[0].sharedInjectionData[1].InjectionData[0].exactRoom.placedObjects[0].nonenemyBehaviour).gameObject;
		orLoadByName8 = null;
		Dungeon orLoadByName9 = DungeonDatabase.GetOrLoadByName("base_tutorial");
		SignRight = ((Component)orLoadByName9.PatternSettings.flows[0].AllNodes[11].overrideExactRoom.placedObjects[13].nonenemyBehaviour).gameObject;
		SignLeft = ((Component)orLoadByName9.PatternSettings.flows[0].AllNodes[11].overrideExactRoom.placedObjects[14].nonenemyBehaviour).gameObject;
		SignUp = ((Component)orLoadByName9.PatternSettings.flows[0].AllNodes[9].overrideExactRoom.placedObjects[1].nonenemyBehaviour).gameObject;
		secretroomlayout = ((Component)((Component)orLoadByName9.PatternSettings.flows[0].AllNodes[15].overrideExactRoom.placedObjects[0].nonenemyBehaviour).gameObject.transform.GetChild(2)).gameObject;
		orLoadByName9 = null;
		PrototypeDungeonRoom val2 = LoadHelper.LoadAssetFromAnywhere<PrototypeDungeonRoom>("shop02");
		TeleporterSign = ((Component)val2.placedObjects[10].nonenemyBehaviour).gameObject;
		ShopLayout = ((Component)val2.placedObjects[12].nonenemyBehaviour).gameObject;
		Crates = ((Component)ShopLayout.transform.GetChild(1)).gameObject;
		Crate = ((Component)ShopLayout.transform.GetChild(5)).gameObject;
		Sack = ((Component)ShopLayout.transform.GetChild(3)).gameObject;
		ShellBarrel = ((Component)ShopLayout.transform.GetChild(10)).gameObject;
		Shelf = ((Component)ShopLayout.transform.GetChild(7)).gameObject;
		Mask = ((Component)ShopLayout.transform.GetChild(6)).gameObject;
		Wallsword = ((Component)ShopLayout.transform.GetChild(11)).gameObject;
		StandingShelf = ((Component)ShopLayout.transform.GetChild(8)).gameObject;
		AKBarrel = ((Component)ShopLayout.transform.GetChild(9)).gameObject;
		Stool = ((Component)ShopLayout.transform.GetChild(12)).gameObject;
		val2 = null;
	}
}
