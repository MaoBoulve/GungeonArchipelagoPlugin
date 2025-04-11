using System.Collections.Generic;
using System.Reflection;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class Peanut : PassiveItem
{
	public class PeanutCompanionBehaviour : CompanionController
	{
		public PlayerController Owner;

		private void Start()
		{
			Owner = base.m_owner;
		}
	}

	private static tk2dSpriteCollectionData PeanutAnimationCollection;

	private static string[] spritePaths = new string[71]
	{
		"NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_idlewest_001", "NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_idlewest_002", "NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_idlewest_003", "NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_idlewest_004", "NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_idleeast_001", "NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_idleeast_002", "NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_idleeast_003", "NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_idleeast_004", "NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_idlenorth_001", "NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_idlenorth_002",
		"NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_idlenorth_003", "NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_idlenorth_004", "NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_idlesouth_001", "NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_idlesouth_002", "NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_idlesouth_003", "NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_idlesouth_004", "NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_movewest_001", "NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_movewest_002", "NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_movewest_003", "NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_movewest_004",
		"NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_movewest_005", "NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_movewest_006", "NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_moveeast_001", "NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_moveeast_002", "NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_moveeast_003", "NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_moveeast_004", "NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_moveeast_005", "NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_moveeast_006", "NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_movenorth_001", "NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_movenorth_002",
		"NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_movenorth_003", "NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_movenorth_004", "NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_movenorth_005", "NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_movenorth_006", "NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_movesouth_001", "NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_movesouth_002", "NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_movesouth_003", "NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_movesouth_004", "NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_movesouth_005", "NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_movesouth_006",
		"NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_attackeast_001", "NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_attackeast_002", "NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_attackeast_003", "NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_attackeast_004", "NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_attackeast_005", "NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_attackeast_006", "NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_attackeast_007", "NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_attackeast_008", "NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_attackwest_001", "NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_attackwest_002",
		"NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_attackwest_003", "NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_attackwest_004", "NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_attackwest_005", "NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_attackwest_006", "NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_attackwest_007", "NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_attackwest_008", "NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_attacknorth_001", "NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_attacknorth_002", "NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_attacknorth_003", "NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_attacknorth_004",
		"NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_attacknorth_005", "NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_attacknorth_006", "NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_attacknorth_007", "NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_attacksouth_001", "NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_attacksouth_002", "NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_attacksouth_003", "NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_attacksouth_004", "NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_attacksouth_005", "NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_attacksouth_006", "NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_attacksouth_007",
		"NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_attacksouth_008"
	};

	public static GameObject prefab;

	private static readonly string guid = "peanut_companion83279843696946";

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<CompanionItem>("Peanut", "Prince of the Pea", "This young, soft-shelled Gun Nut sought the teachings of Ser Manuel, but was lost in the labyrinthine and confusing Halls of Knowledge for many years.\n\nHe now wields the mighty Peablade, made from a Peashooter that he found in a chest.", "peanut_icon", assetbundle: true);
		CompanionItem val = (CompanionItem)(object)((obj is CompanionItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)4;
		val.CompanionGuid = guid;
		BuildPrefab();
	}

	public static void BuildPrefab()
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Expected O, but got Unknown
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ac: Expected O, but got Unknown
		//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0201: Unknown result type (might be due to invalid IL or missing references)
		//IL_0208: Expected O, but got Unknown
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Expected O, but got Unknown
		//IL_022d: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)prefab != (Object)null || CompanionBuilder.companionDictionary.ContainsKey(guid))
		{
			return;
		}
		prefab = CompanionBuilder.BuildPrefab("Peanut Companion", guid, "NevernamedsItems/Resources/Companions/PeanutCompanion/peanut_idlesouth_001", new IntVector2(16, 11), new IntVector2(8, 9));
		PeanutCompanionBehaviour peanutCompanionBehaviour = prefab.AddComponent<PeanutCompanionBehaviour>();
		((CompanionController)peanutCompanionBehaviour).companionID = (CompanionIdentifier)0;
		((BraveBehaviour)peanutCompanionBehaviour).aiActor.MovementSpeed = 5f;
		((BraveBehaviour)((BraveBehaviour)peanutCompanionBehaviour).aiActor).healthHaver.PreventAllDamage = true;
		((BraveBehaviour)peanutCompanionBehaviour).aiActor.CollisionDamage = 0f;
		((BraveBehaviour)((BraveBehaviour)peanutCompanionBehaviour).aiActor).specRigidbody.CollideWithOthers = false;
		((BraveBehaviour)((BraveBehaviour)peanutCompanionBehaviour).aiActor).specRigidbody.CollideWithTileMap = false;
		BehaviorSpeculator component = prefab.GetComponent<BehaviorSpeculator>();
		component.AttackBehaviors.Add((AttackBehaviorBase)(object)new CustomCompanionBehaviours.PeanutAttackBehaviour());
		component.MovementBehaviors.Add((MovementBehaviorBase)(object)new CustomCompanionBehaviours.SimpleCompanionApproach());
		List<MovementBehaviorBase> movementBehaviors = component.MovementBehaviors;
		CompanionFollowPlayerBehavior val = new CompanionFollowPlayerBehavior();
		val.IdleAnimations = new string[1] { "idle" };
		val.CatchUpRadius = 6f;
		val.CatchUpMaxSpeed = 10f;
		val.CatchUpAccelTime = 1f;
		val.CatchUpSpeed = 7f;
		movementBehaviors.Add((MovementBehaviorBase)(object)val);
		AIAnimator aiAnimator = ((BraveBehaviour)peanutCompanionBehaviour).aiAnimator;
		AIAnimator aiAnimator2 = ((BraveBehaviour)aiAnimator).aiAnimator;
		DirectionalAnimation val2 = new DirectionalAnimation();
		val2.Type = (DirectionType)9;
		val2.Flipped = (FlipType[])(object)new FlipType[4];
		val2.AnimNames = new string[4] { "move_north", "move_east", "move_south", "move_west" };
		aiAnimator2.MoveAnimation = val2;
		val2 = new DirectionalAnimation();
		val2.Type = (DirectionType)9;
		val2.Flipped = (FlipType[])(object)new FlipType[4];
		val2.AnimNames = new string[4] { "idle_north", "idle_east", "idle_south", "idle_west" };
		aiAnimator.IdleAnimation = val2;
		List<NamedDirectionalAnimation> list = new List<NamedDirectionalAnimation>();
		NamedDirectionalAnimation val3 = new NamedDirectionalAnimation();
		val3.name = "attack";
		val2 = new DirectionalAnimation();
		val2.Prefix = "attack";
		val2.Type = (DirectionType)9;
		val2.Flipped = (FlipType[])(object)new FlipType[4];
		val2.AnimNames = new string[4] { "attack_west", "attack_east", "attack_north", "attack_south" };
		val3.anim = val2;
		list.Add(val3);
		aiAnimator.OtherAnimations = list;
		if ((Object)(object)PeanutAnimationCollection == (Object)null)
		{
			PeanutAnimationCollection = SpriteBuilder.ConstructCollection(prefab, "PeanutCompanion_Collection", false);
			Object.DontDestroyOnLoad((Object)(object)PeanutAnimationCollection);
			for (int i = 0; i < spritePaths.Length; i++)
			{
				SpriteBuilder.AddSpriteToCollection(spritePaths[i], PeanutAnimationCollection, (Assembly)null);
			}
			SpriteBuilder.AddAnimation(((BraveBehaviour)peanutCompanionBehaviour).spriteAnimator, PeanutAnimationCollection, new List<int> { 0, 1, 2, 3 }, "idle_west", (WrapMode)0, 15f).fps = 4f;
			SpriteBuilder.AddAnimation(((BraveBehaviour)peanutCompanionBehaviour).spriteAnimator, PeanutAnimationCollection, new List<int> { 4, 5, 6, 7 }, "idle_east", (WrapMode)0, 15f).fps = 4f;
			SpriteBuilder.AddAnimation(((BraveBehaviour)peanutCompanionBehaviour).spriteAnimator, PeanutAnimationCollection, new List<int> { 8, 9, 10, 11 }, "idle_north", (WrapMode)0, 15f).fps = 4f;
			SpriteBuilder.AddAnimation(((BraveBehaviour)peanutCompanionBehaviour).spriteAnimator, PeanutAnimationCollection, new List<int> { 12, 13, 14, 15 }, "idle_south", (WrapMode)0, 15f).fps = 4f;
			SpriteBuilder.AddAnimation(((BraveBehaviour)peanutCompanionBehaviour).spriteAnimator, PeanutAnimationCollection, new List<int> { 16, 17, 18, 19, 20, 21 }, "move_west", (WrapMode)0, 15f).fps = 8f;
			SpriteBuilder.AddAnimation(((BraveBehaviour)peanutCompanionBehaviour).spriteAnimator, PeanutAnimationCollection, new List<int> { 22, 23, 24, 25, 26, 27 }, "move_east", (WrapMode)0, 15f).fps = 8f;
			SpriteBuilder.AddAnimation(((BraveBehaviour)peanutCompanionBehaviour).spriteAnimator, PeanutAnimationCollection, new List<int> { 28, 29, 30, 31, 32, 33 }, "move_north", (WrapMode)0, 15f).fps = 8f;
			SpriteBuilder.AddAnimation(((BraveBehaviour)peanutCompanionBehaviour).spriteAnimator, PeanutAnimationCollection, new List<int> { 34, 35, 36, 37, 38, 39 }, "move_south", (WrapMode)0, 15f).fps = 8f;
			SpriteBuilder.AddAnimation(((BraveBehaviour)peanutCompanionBehaviour).spriteAnimator, PeanutAnimationCollection, new List<int> { 40, 41, 42, 43, 44, 45, 46, 47 }, "attack_east", (WrapMode)2, 15f).fps = 8f;
			SpriteBuilder.AddAnimation(((BraveBehaviour)peanutCompanionBehaviour).spriteAnimator, PeanutAnimationCollection, new List<int> { 48, 49, 50, 51, 52, 53, 54, 55 }, "attack_west", (WrapMode)2, 15f).fps = 8f;
			SpriteBuilder.AddAnimation(((BraveBehaviour)peanutCompanionBehaviour).spriteAnimator, PeanutAnimationCollection, new List<int> { 56, 57, 58, 59, 60, 61, 62 }, "attack_north", (WrapMode)2, 15f).fps = 8f;
			SpriteBuilder.AddAnimation(((BraveBehaviour)peanutCompanionBehaviour).spriteAnimator, PeanutAnimationCollection, new List<int> { 63, 64, 65, 66, 67, 68, 69, 70 }, "attack_south", (WrapMode)2, 15f).fps = 8f;
		}
	}
}
