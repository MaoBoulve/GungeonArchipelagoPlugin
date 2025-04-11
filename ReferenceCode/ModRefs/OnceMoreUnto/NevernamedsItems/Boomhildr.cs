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

public static class Boomhildr
{
	public static GameObject mapIcon;

	public static GenericLootTable BoomhildrLootTable;

	public static void AddToLootPool(int id)
	{
		if ((Object)(object)BoomhildrLootTable == (Object)null)
		{
			BoomhildrLootTable = LootUtility.CreateLootTable((List<GenericLootTable>)null, (DungeonPrerequisite[])null);
		}
		LootUtility.AddItemToPool(BoomhildrLootTable, id, 1f);
	}

	public static void Init()
	{
		//IL_0651: Unknown result type (might be due to invalid IL or missing references)
		//IL_065b: Expected O, but got Unknown
		//IL_0689: Unknown result type (might be due to invalid IL or missing references)
		//IL_0693: Expected O, but got Unknown
		//IL_06a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_06af: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f4: Expected O, but got Unknown
		//IL_0763: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0813: Unknown result type (might be due to invalid IL or missing references)
		//IL_082e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0903: Unknown result type (might be due to invalid IL or missing references)
		//IL_090a: Expected O, but got Unknown
		//IL_094a: Unknown result type (might be due to invalid IL or missing references)
		NpcTools.AddComplex(Databases.Strings.Core, "#BOOMHILDR_GENERIC_TALK", "Explosions are the spice of life! ...and death.");
		NpcTools.AddComplex(Databases.Strings.Core, "#BOOMHILDR_GENERIC_TALK", "Name's Boomhildr, demolitions expert, self taught, at yer service.");
		NpcTools.AddComplex(Databases.Strings.Core, "#BOOMHILDR_GENERIC_TALK", "My legs? Got taken clean off by a dynamite explosion! It's what made me want to go into pyrotechnics!");
		NpcTools.AddComplex(Databases.Strings.Core, "#BOOMHILDR_GENERIC_TALK", "My arm? ...it was bitten off by a gator, why do you ask.");
		NpcTools.AddComplex(Databases.Strings.Core, "#BOOMHILDR_GENERIC_TALK", "My eye? It was shot out. By a bomb. With a gun.");
		NpcTools.AddComplex(Databases.Strings.Core, "#BOOMHILDR_GENERIC_TALK", "What am I here for?... none of your business.");
		NpcTools.AddComplex(Databases.Strings.Core, "#BOOMHILDR_GENERIC_TALK", "There was a little claymore running around here a while ago, screaming something about 'Booms'. Pretty cool guy.");
		NpcTools.AddComplex(Databases.Strings.Core, "#BOOMHILDR_GENERIC_TALK", "Some weirdo keeps coming by and calling me an 'Angel of Death'. What's up with that?");
		NpcTools.AddComplex(Databases.Strings.Core, "#BOOMHILDR_GENERIC_TALK", "I've got all the boom you could ask for. Boom comin' out the ears.");
		NpcTools.AddComplex(Databases.Strings.Core, "#BOOMHILDR_GENERIC_TALK", "Me and Cursula knew each other in college... before she got into mumbo jumbo.");
		NpcTools.AddComplex(Databases.Strings.Core, "#BOOMHILDR_GENERIC_TALK", "My mama always used to say that frag grenades are the fireworks of explosive warfare.");
		NpcTools.AddComplex(Databases.Strings.Core, "#BOOMHILDR_STOPPER_TALK", "Not now, got powder to mix, fuses to braid, you know the deal.");
		NpcTools.AddComplex(Databases.Strings.Core, "#BOOMHILDR_STOPPER_TALK", "I'm busy riggin' up for a big blast.");
		NpcTools.AddComplex(Databases.Strings.Core, "#BOOMHILDR_STOPPER_TALK", "Listen pal, I've only got so much patience for blabbermouths.");
		NpcTools.AddComplex(Databases.Strings.Core, "#BOOMHILDR_PURCHASE_TALK", "Thanks for the cash.");
		NpcTools.AddComplex(Databases.Strings.Core, "#BOOMHILDR_PURCHASE_TALK", "Have fun blowing &%*! up.");
		NpcTools.AddComplex(Databases.Strings.Core, "#BOOMHILDR_PURCHASE_TALK", "Send 'em to kingdom come for me!");
		NpcTools.AddComplex(Databases.Strings.Core, "#BOOMHILDR_PURCHASE_TALK", "Boom-boom-boom-boom, amirite?");
		NpcTools.AddComplex(Databases.Strings.Core, "#BOOMHILDR_NOSALE_TALK", "Sorry mate, nothin' in this world is free.");
		NpcTools.AddComplex(Databases.Strings.Core, "#BOOMHILDR_NOSALE_TALK", "Good explosives aren't cheap.");
		NpcTools.AddComplex(Databases.Strings.Core, "#BOOMHILDR_NOSALE_TALK", "I'm not running a charity here.");
		NpcTools.AddComplex(Databases.Strings.Core, "#BOOMHILDR_INTRO_TALK", "You're back. And with all your limbs too.");
		NpcTools.AddComplex(Databases.Strings.Core, "#BOOMHILDR_INTRO_TALK", "Blow up anyone special lately?");
		NpcTools.AddComplex(Databases.Strings.Core, "#BOOMHILDR_INTRO_TALK", "See any good blasts out there in the Gungeon?");
		NpcTools.AddComplex(Databases.Strings.Core, "#BOOMHILDR_INTRO_TALK", "Want a bomb? I've got bombs. Let's talk.");
		NpcTools.AddComplex(Databases.Strings.Core, "#BOOMHILDR_INTRO_TALK", "Bombs? Bombs? Bombs? You want it? It's yours, my friend- as long as you have enough cash.");
		NpcTools.AddComplex(Databases.Strings.Core, "#BOOMHILDR_ATTACKED_TALK", "Watch it buster.");
		NpcTools.AddComplex(Databases.Strings.Core, "#BOOMHILDR_ATTACKED_TALK", "No need to be jealous.");
		NpcTools.AddComplex(Databases.Strings.Core, "#BOOMHILDR_ATTACKED_TALK", "You're gonna blow your chances.");
		NpcTools.AddComplex(Databases.Strings.Core, "#BOOMHILDR_ATTACKED_TALK", "I can bring this whole chamber down on our heads, and you're attacking me?");
		NpcTools.AddComplex(Databases.Strings.Core, "#BOOMHILDR_STEAL_TALK", "Thief!");
		List<int> list = new List<int>
		{
			108,
			109,
			460,
			66,
			308,
			136,
			252,
			443,
			567,
			234,
			438,
			403,
			304,
			312,
			398,
			440,
			601,
			4,
			542,
			96,
			6,
			81,
			274,
			39,
			19,
			92,
			563,
			129,
			372,
			16,
			332,
			180,
			593,
			362,
			186,
			28,
			339,
			478,
			NitroBullets.NitroBulletsID,
			AntimatterBullets.AntimatterBulletsID,
			BombardierShells.BombardierShellsID,
			Blombk.BlombkID,
			Nitroglycylinder.NitroglycylinderID,
			GunpowderPheromones.GunpowderPheromonesID,
			RocketMan.RocketManID,
			ChemGrenade.ChemGrenadeID,
			InfantryGrenade.InfantryGrenadeID,
			BomberJacket.ID,
			Bombinomicon.ID,
			MagicMissile.ID,
			GrenadeShotgun.GrenadeShotgunID,
			Felissile.ID,
			TheThinLine.ID,
			RocketPistol.ID,
			Demolitionist.DemolitionistID,
			HandMortar.ID,
			FireLance.FireLanceID,
			DynamiteLauncher.DynamiteLauncherID,
			BottleRocket.ID,
			NNBazooka.BazookaID,
			BoomBeam.ID,
			Pillarocket.ID,
			BlastingCap.ID
		};
		foreach (int item in list)
		{
			AddToLootPool(item);
		}
		mapIcon = ItemBuilder.SpriteFromBundle("boomhildr_mapicon", Initialisation.NPCCollection.GetSpriteIdByName("boomhildr_mapicon"), Initialisation.NPCCollection, new GameObject("boomhildr_mapicon"));
		FakePrefabExtensions.MakeFakePrefab(mapIcon);
		GameObject val = ItemBuilder.SpriteFromBundle("boomhildr_idle_001", Initialisation.NPCCollection.GetSpriteIdByName("boomhildr_idle_001"), Initialisation.NPCCollection, new GameObject("Boomhildr"));
		SpeculativeRigidbody val2 = ShopAPI.GenerateOrAddToRigidBody(val, (CollisionLayer)5, (PixelColliderGeneration)0, true, true, true, false, false, false, false, true, (IntVector2?)new IntVector2(12, 16), (IntVector2?)new IntVector2(4, -1));
		val2.AddCollisionLayerOverride(CollisionMask.LayerToMask((CollisionLayer)8));
		GameObject val3 = ItemBuilder.SpriteFromBundle("boomhildr_shadow", Initialisation.NPCCollection.GetSpriteIdByName("boomhildr_shadow"), Initialisation.NPCCollection, new GameObject("shadow"));
		tk2dSprite component = val3.GetComponent<tk2dSprite>();
		((tk2dBaseSprite)component).HeightOffGround = -1.7f;
		((tk2dBaseSprite)component).SortingOrder = 0;
		((tk2dBaseSprite)component).IsPerpendicular = false;
		((BraveBehaviour)component).renderer.material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTilted");
		((tk2dBaseSprite)component).usesOverrideMaterial = true;
		val3.transform.SetParent(val.transform);
		val3.transform.localPosition = new Vector3(-0.25f, -0.4375f);
		tk2dSpriteCollectionData nPCCollection = Initialisation.NPCCollection;
		tk2dSpriteAnimation npcAnimationCollection = Initialisation.npcAnimationCollection;
		GenericLootTable boomhildrLootTable = BoomhildrLootTable;
		Vector3 talkPointOffset = new Vector3(0.75f, 3.25f, 0f);
		Vector3 npcOffset = new Vector3(1.9375f, 3.375f, 0f);
		Vector3[] itemPositions = new List<Vector3>
		{
			new Vector3(0.5f, 1.5f, 1f),
			new Vector3(2.625f, 1.5f, 1f),
			new Vector3(4.5f, 1.5f, 1f)
		}.ToArray();
		GameObject minimapIcon = mapIcon;
		GameObject key = TempNPCTools.MakeIntoShopkeeper("Boomhildr", "nn", val, "boomhildr_idle", "boomhildr_talk", nPCCollection, npcAnimationCollection, boomhildrLootTable, (ShopCurrencyType)0, "#BOOMHILDR_GENERIC_TALK", "#BOOMHILDR_STOPPER_TALK", "#BOOMHILDR_PURCHASE_TALK", "#BOOMHILDR_NOSALE_TALK", "#BOOMHILDR_INTRO_TALK", "#BOOMHILDR_ATTACKED_TALK", "#BOOMHILDR_STEAL_TALK", talkPointOffset, npcOffset, "lady", itemPositions, 0.8f, giveStatsOnPurchase: false, null, null, null, null, null, null, "", "", canBeRobbed: true, "boomhildr_carpet", null, hasMinimapIcon: true, minimapIcon, addToShopAnnex: true, 0.1f, null, 2f, (ShopItemPoolType)0);
		Dictionary<GameObject, float> dictionary = new Dictionary<GameObject, float> { { key, 1f } };
		DungeonPlaceable val4 = BreakableAPIToolbox.GenerateDungeonPlaceable(dictionary, 1, 1, (DungeonPrerequisite[])null);
		val4.isPassable = true;
		val4.width = 5;
		val4.height = 5;
		StaticReferences.StoredDungeonPlaceables.Add("boomhildr", val4);
		StaticReferences.customPlaceables.Add("nn:boomhildr", val4);
		SharedInjectionData injectionData = GameManager.Instance.GlobalInjectionData.entries[2].injectionData;
		List<ProceduralFlowModifierData> injectionData2 = injectionData.InjectionData;
		ProceduralFlowModifierData val5 = new ProceduralFlowModifierData();
		val5.annotation = "Boomhildr";
		val5.DEBUG_FORCE_SPAWN = false;
		val5.OncePerRun = false;
		val5.placementRules = new List<FlowModifierPlacementType> { (FlowModifierPlacementType)1 };
		val5.roomTable = null;
		val5.exactRoom = RoomFactory.BuildNewRoomFromResource("NevernamedsItems/Content/NPCs/Rooms/BoomhildrRoom.newroom", (Assembly)null).room;
		val5.IsWarpWing = false;
		val5.RequiresMasteryToken = false;
		val5.chanceToLock = 0f;
		val5.selectionWeight = 1f;
		val5.chanceToSpawn = 1f;
		val5.RequiredValidPlaceable = null;
		val5.prerequisites = (DungeonPrerequisite[])(object)new DungeonPrerequisite[0];
		val5.CanBeForcedSecret = false;
		val5.RandomNodeChildMinDistanceFromEntrance = 0;
		val5.exactSecondaryRoom = null;
		val5.framedCombatNodes = 0;
		injectionData2.Add(val5);
	}
}
