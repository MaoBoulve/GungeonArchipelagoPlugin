using System.Collections.Generic;
using Alexandria.ItemAPI;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class Gungineer : PassiveItem
{
	public static int ID;

	public static GameObject prefab;

	private static readonly string guid = "gungineer_84298yhjvfactbbianxwyuew7xwu3";

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<CompanionItem>("Gungineer", "Solves Problems", "This small minelet is the sole member of the Gungeon Engineers Union, and as such bears loyalty only to the bearer of the unions signature hammer. More than happy to do construction work- on a contract basis.\n\nForklift certified.", "gungineer_icon", assetbundle: true);
		CompanionItem val = (CompanionItem)(object)((obj is CompanionItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)3;
		val.CompanionGuid = guid;
		ID = ((PickupObject)val).PickupObjectId;
		BuildPrefab();
		((PickupObject)(object)val).SetupUnlockOnCustomStat(CustomTrackedStats.BEGGAR_TOTAL_DONATIONS, 634f, (PrerequisiteOperation)2);
	}

	public static void BuildPrefab()
	{
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Expected O, but got Unknown
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Expected O, but got Unknown
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Expected O, but got Unknown
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Expected O, but got Unknown
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_026a: Unknown result type (might be due to invalid IL or missing references)
		//IL_026f: Unknown result type (might be due to invalid IL or missing references)
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0285: Unknown result type (might be due to invalid IL or missing references)
		//IL_0290: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a0: Expected O, but got Unknown
		if ((Object)(object)prefab == (Object)null || !CompanionBuilder.companionDictionary.ContainsKey(guid))
		{
			prefab = EntityTools.BuildEntity("Gungineer", guid, "gungineer_idleleft_001", Initialisation.companionCollection, new IntVector2(8, 8), new IntVector2(-4, 0));
			CompanionController val = prefab.AddComponent<CompanionController>();
			val.companionID = (CompanionIdentifier)0;
			tk2dSpriteAnimator component = prefab.GetComponent<tk2dSpriteAnimator>();
			component.Library = Initialisation.companionAnimationCollection;
			AIActor component2 = prefab.GetComponent<AIActor>();
			component2.CanDropCurrency = false;
			component2.CanDropItems = false;
			component2.BaseMovementSpeed = 6f;
			component2.IgnoreForRoomClear = false;
			component2.TryDodgeBullets = false;
			((GameActor)component2).ActorName = "Gungineer";
			((GameActor)component2).DoDustUps = true;
			((GameActor)component2).SetIsFlying(true, "hovering", false, true);
			((GameActor)component2).ActorShadowOffset = new Vector3(0f, 0.4f);
			AIAnimator component3 = prefab.GetComponent<AIAnimator>();
			DirectionalAnimation val2 = new DirectionalAnimation();
			val2.Type = (DirectionType)2;
			val2.Flipped = (FlipType[])(object)new FlipType[2];
			val2.AnimNames = new List<string> { "gungineer_idleright", "gungineer_idleleft" }.ToArray();
			val2.Prefix = string.Empty;
			component3.IdleAnimation = val2;
			val2 = new DirectionalAnimation();
			val2.Type = (DirectionType)2;
			val2.Flipped = (FlipType[])(object)new FlipType[2];
			val2.AnimNames = new List<string> { "gungineer_moveright", "gungineer_moveleft" }.ToArray();
			val2.Prefix = string.Empty;
			component3.MoveAnimation = val2;
			NamedDirectionalAnimation val3 = new NamedDirectionalAnimation();
			val3.name = "build";
			val2 = new DirectionalAnimation();
			val2.Prefix = string.Empty;
			val2.Type = (DirectionType)2;
			val2.Flipped = (FlipType[])(object)new FlipType[2];
			val2.AnimNames = new List<string> { "gungineer_buildright", "gungineer_buildleft" }.ToArray();
			val3.anim = val2;
			NamedDirectionalAnimation item = val3;
			if (component3.OtherAnimations == null)
			{
				component3.OtherAnimations = new List<NamedDirectionalAnimation>();
			}
			component3.OtherAnimations.Add(item);
			BehaviorSpeculator component4 = prefab.GetComponent<BehaviorSpeculator>();
			component4.MovementBehaviors.Add((MovementBehaviorBase)(object)new BuildTrapsBehaviour());
			component4.MovementBehaviors.Add((MovementBehaviorBase)new CompanionFollowPlayerBehavior
			{
				CatchUpRadius = 6f,
				CatchUpMaxSpeed = 10f,
				CatchUpAccelTime = 1f,
				CatchUpSpeed = 7f
			});
		}
	}
}
