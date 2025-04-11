using System.Collections.Generic;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class AngrySpirit : PassiveItem
{
	public class AngrySpiritController : CompanionController
	{
		public PlayerController Owner;

		private void Start()
		{
			Owner = base.m_owner;
			Owner.PostProcessProjectile += OwnerPostProcess;
		}

		public override void OnDestroy()
		{
			if (Object.op_Implicit((Object)(object)Owner))
			{
				Owner.PostProcessProjectile -= OwnerPostProcess;
			}
			((CompanionController)this).OnDestroy();
		}

		private void OwnerPostProcess(Projectile proj, float something)
		{
			//IL_007c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			if (Random.value <= 0.2f && Owner.IsInCombat && Object.op_Implicit((Object)(object)((BraveBehaviour)this).aiActor.OverrideTarget) && Object.op_Implicit((Object)(object)((BraveBehaviour)((BraveBehaviour)this).aiActor.OverrideTarget).sprite))
			{
				((BraveBehaviour)this).aiAnimator.PlayUntilFinished("attack", false, (string)null, -1f, false);
				GameObject val = ProjSpawnHelper.SpawnProjectileTowardsPoint(((Component)proj).gameObject, ((BraveBehaviour)this).sprite.WorldCenter, ((BraveBehaviour)((BraveBehaviour)this).aiActor.OverrideTarget).sprite.WorldCenter, 0f, 5f, Owner);
				Projectile component = val.GetComponent<Projectile>();
				if (Object.op_Implicit((Object)(object)component))
				{
					component.Owner = (GameActor)(object)Owner;
					component.Shooter = ((BraveBehaviour)Owner).specRigidbody;
					ProjectileUtility.ApplyCompanionModifierToBullet(component, Owner);
				}
			}
		}

		public override void Update()
		{
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			if (Object.op_Implicit((Object)(object)Owner) && !Dungeon.IsGenerating && Owner.IsInCombat && Vector3Extensions.GetAbsoluteRoom(((BraveBehaviour)this).transform.position) != Owner.CurrentRoom)
			{
			}
		}
	}

	public static GameObject prefab;

	private static readonly string guid = "angryspirit8373429576528727654857yt7wey34gfh4w6iw4t";

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<CompanionItem>("Angry Spirit", "Furious Friend", "Aches to kill, but cannot generate it's own bullets, merely copying the firepower of it's owner.\n\nDon't let him in.", "angryspirit_icon", assetbundle: true);
		CompanionItem val = (CompanionItem)(object)((obj is CompanionItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)3;
		val.CompanionGuid = guid;
		BuildPrefab();
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)2, 1f);
	}

	public static void BuildPrefab()
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Expected O, but got Unknown
		if (!((Object)(object)prefab != (Object)null) && !CompanionBuilder.companionDictionary.ContainsKey(guid))
		{
			prefab = CompanionBuilder.BuildPrefab("Angry Spirit", guid, "NevernamedsItems/Resources/Companions/AngrySpirit/angryspirit_idleright_001", new IntVector2(2, 2), new IntVector2(12, 14));
			AngrySpiritController angrySpiritController = prefab.AddComponent<AngrySpiritController>();
			((BraveBehaviour)angrySpiritController).aiActor.MovementSpeed = 6f;
			((CompanionController)angrySpiritController).CanCrossPits = true;
			((GameActor)((BraveBehaviour)angrySpiritController).aiActor).SetIsFlying(true, "Flying Entity", false, true);
			((GameActor)((BraveBehaviour)angrySpiritController).aiActor).ActorShadowOffset = new Vector3(0f, -0.25f);
			AIAnimator orAddComponent = GameObjectExtensions.GetOrAddComponent<AIAnimator>(prefab);
			orAddComponent.AdvAddAnimation("idle", (DirectionType)2, (AnimationType)1, new List<AnimationUtilityExtensions.DirectionalAnimationData>
			{
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "idle_right",
					wrapMode = (WrapMode)0,
					fps = 9,
					pathDirectory = "NevernamedsItems/Resources/Companions/AngrySpirit/angryspirit_idleright"
				},
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "idle_left",
					wrapMode = (WrapMode)0,
					fps = 9,
					pathDirectory = "NevernamedsItems/Resources/Companions/AngrySpirit/angryspirit_idleleft"
				}
			});
			orAddComponent.AdvAddAnimation("attack", (DirectionType)2, (AnimationType)6, new List<AnimationUtilityExtensions.DirectionalAnimationData>
			{
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "attack_right",
					wrapMode = (WrapMode)2,
					fps = 12,
					pathDirectory = "NevernamedsItems/Resources/Companions/AngrySpirit/angryspirit_attackright"
				},
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "attack_left",
					wrapMode = (WrapMode)2,
					fps = 12,
					pathDirectory = "NevernamedsItems/Resources/Companions/AngrySpirit/angryspirit_attackleft"
				}
			});
			BehaviorSpeculator component = prefab.GetComponent<BehaviorSpeculator>();
			CustomCompanionBehaviours.SimpleCompanionApproach simpleCompanionApproach = new CustomCompanionBehaviours.SimpleCompanionApproach();
			simpleCompanionApproach.DesiredDistance = 5f;
			component.MovementBehaviors.Add((MovementBehaviorBase)(object)simpleCompanionApproach);
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
