using System.Collections.Generic;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class BabyGoodChanceKin : PassiveItem
{
	public class ChanceKinBehavior : CompanionController
	{
		public PlayerController Owner;

		private void Start()
		{
			Owner = base.m_owner;
			Owner.OnReceivedDamage += OnDamaged;
		}

		public override void OnDestroy()
		{
			if (Object.op_Implicit((Object)(object)Owner))
			{
				Owner.OnReceivedDamage -= OnDamaged;
			}
			((CompanionController)this).OnDestroy();
		}

		private void OnDamaged(PlayerController player)
		{
			//IL_0075: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			float num = ((!CustomSynergies.PlayerHasActiveSynergy(Owner, "Good Lads")) ? 0.4f : 0.6f);
			if (Random.value < num)
			{
				int num2 = 1;
				if (CustomSynergies.PlayerHasActiveSynergy(Owner, "Worship"))
				{
					num2++;
				}
				for (int i = 0; i < num2; i++)
				{
					int num3 = BraveUtility.RandomElement<int>(lootIDlist);
					LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetById(num3)).gameObject, Vector2.op_Implicit(((BraveBehaviour)((BraveBehaviour)this).aiActor).sprite.WorldCenter), Vector2.zero, 1f, false, true, false);
				}
			}
		}
	}

	public static List<int> lootIDlist = new List<int> { 78, 600, 565, 73, 85, 120, 224, 67 };

	public static GameObject prefab;

	private static readonly string guid = "baby_good_chance_kin180492309438";

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<CompanionItem>("Baby Good Chance Kin", "Confused Friend", "Can spawn supplies whenever the person they follow suffers damage.\n\nThis cute little lad is unable to look directly in front of himself, but in spite of this predicament he is eager to help you on your journey.", "babygoodchancekin_icon", assetbundle: true);
		CompanionItem val = (CompanionItem)(object)((obj is CompanionItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)2;
		val.CompanionGuid = guid;
		BuildPrefab();
	}

	public static void BuildPrefab()
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Expected O, but got Unknown
		if (!((Object)(object)prefab != (Object)null) && !CompanionBuilder.companionDictionary.ContainsKey(guid))
		{
			prefab = CompanionBuilder.BuildPrefab("Baby Good Chance Kin", guid, "NevernamedsItems/Resources/BabyGoodChanceKinSprites/babygoodchancekin_idleleft_001", new IntVector2(8, 0), new IntVector2(6, 11));
			ChanceKinBehavior chanceKinBehavior = prefab.AddComponent<ChanceKinBehavior>();
			((BraveBehaviour)chanceKinBehavior).aiActor.MovementSpeed = 5f;
			CompanionBuilder.AddAnimation(prefab, "idle_right", "NevernamedsItems/Resources/BabyGoodChanceKinSprites/babygoodchancekin_idleright", 7, (AnimationType)1, (DirectionType)2, (FlipType)0);
			CompanionBuilder.AddAnimation(prefab, "idle_left", "NevernamedsItems/Resources/BabyGoodChanceKinSprites/babygoodchancekin_idleleft", 7, (AnimationType)1, (DirectionType)2, (FlipType)0);
			CompanionBuilder.AddAnimation(prefab, "run_right", "NevernamedsItems/Resources/BabyGoodChanceKinSprites/babygoodchancekin_moveright", 10, (AnimationType)0, (DirectionType)2, (FlipType)0);
			CompanionBuilder.AddAnimation(prefab, "run_left", "NevernamedsItems/Resources/BabyGoodChanceKinSprites/babygoodchancekin_moveleft", 10, (AnimationType)0, (DirectionType)2, (FlipType)0);
			BehaviorSpeculator component = prefab.GetComponent<BehaviorSpeculator>();
			List<MovementBehaviorBase> movementBehaviors = component.MovementBehaviors;
			CompanionFollowPlayerBehavior val = new CompanionFollowPlayerBehavior();
			val.IdleAnimations = new string[1] { "idle" };
			val.CatchUpRadius = 6f;
			val.CatchUpMaxSpeed = 10f;
			val.CatchUpAccelTime = 1f;
			val.CatchUpSpeed = 7f;
			movementBehaviors.Add((MovementBehaviorBase)(object)val);
		}
	}
}
