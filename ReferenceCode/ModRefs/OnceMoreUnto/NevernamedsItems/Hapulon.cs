using System;
using System.Collections.Generic;
using System.Linq;
using Alexandria.ItemAPI;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class Hapulon : PassiveItem
{
	public class HapulonController : CompanionController
	{
		private PlayerController Owner;

		private EnemyApproachingHopper hopBehaviour;

		private void Start()
		{
			Owner = base.m_owner;
			hopBehaviour = ((BraveBehaviour)((BraveBehaviour)this).aiActor).behaviorSpeculator.MovementBehaviors.OfType<EnemyApproachingHopper>().FirstOrDefault();
			EnemyApproachingHopper enemyApproachingHopper = hopBehaviour;
			enemyApproachingHopper.onLanded = (Action<AIActor, Vector2>)Delegate.Combine(enemyApproachingHopper.onLanded, new Action<AIActor, Vector2>(OnLanded));
			hopBehaviour.isValid = EnemyIsValid;
		}

		public bool EnemyIsValid(AIActor enemy)
		{
			if (enemy.CanTargetEnemies && !enemy.CanTargetPlayers)
			{
				return false;
			}
			return true;
		}

		private void OnLanded(AIActor self, Vector2 position)
		{
			//IL_004a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0086: Unknown result type (might be due to invalid IL or missing references)
			//IL_008d: Unknown result type (might be due to invalid IL or missing references)
			if (Owner.IsInCombat)
			{
				Object.Instantiate<GameObject>(SharedVFX.LoveBurstAOE, Vector2.op_Implicit(((BraveBehaviour)this).sprite.WorldCenter + new Vector2(0f, -0.5f)), Quaternion.identity);
			}
			List<AIActor> activeEnemies = Vector3Extensions.GetAbsoluteRoom(((BraveBehaviour)this).specRigidbody.UnitCenter).GetActiveEnemies((ActiveEnemyType)0);
			if (activeEnemies != null)
			{
				for (int i = 0; i < activeEnemies.Count; i++)
				{
					AIActor val = activeEnemies[i];
					if (val.IsNormalEnemy && Vector2.Distance(((GameActor)((BraveBehaviour)this).aiActor).CenterPosition, ((GameActor)val).CenterPosition) <= 2f)
					{
						((BraveBehaviour)val).gameActor.ApplyEffect((GameActorEffect)(object)StaticStatusEffects.charmingRoundsEffect, 1f, (Projectile)null);
					}
				}
			}
			DeadlyDeadlyGoopManager.GetGoopManagerForGoopType(EasyGoopDefinitions.CharmGoopDef).TimedAddGoopCircle(((BraveBehaviour)this).specRigidbody.UnitBottomCenter, 1f, 0.5f, false);
		}
	}

	public static GameObject prefab;

	private static readonly string guid = "omitb_hapulon_companion";

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<CompanionItem>("Hapulon", "Bouncing Bundle of Joy", "The result of a catastrauphic malfunction in Blobulonian genetic engineering, the Hapulon knows nothing but love and joy. For this reason, they have been almost hunted to extinction.", "hapulon_icon", assetbundle: true);
		CompanionItem val = (CompanionItem)(object)((obj is CompanionItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)4;
		val.CompanionGuid = guid;
		BuildPrefab();
		List<string> list = new List<string> { "NevernamedsItems/Resources/MiscVFX/CompanionVFX/loveburstaoe_vfx_001", "NevernamedsItems/Resources/MiscVFX/CompanionVFX/loveburstaoe_vfx_002", "NevernamedsItems/Resources/MiscVFX/CompanionVFX/loveburstaoe_vfx_003", "NevernamedsItems/Resources/MiscVFX/CompanionVFX/loveburstaoe_vfx_004", "NevernamedsItems/Resources/MiscVFX/CompanionVFX/loveburstaoe_vfx_005" };
	}

	public static void BuildPrefab()
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		if (!((Object)(object)prefab != (Object)null) && !CompanionBuilder.companionDictionary.ContainsKey(guid))
		{
			prefab = CompanionBuilder.BuildPrefab("Hapulon", guid, "NevernamedsItems/Resources/Companions/Hapulon/hapulon_idleleft_001", new IntVector2(1, 1), new IntVector2(13, 12));
			HapulonController hapulonController = prefab.AddComponent<HapulonController>();
			((BraveBehaviour)hapulonController).aiActor.MovementSpeed = 4f;
			AIAnimator orAddComponent = GameObjectExtensions.GetOrAddComponent<AIAnimator>(prefab);
			orAddComponent.AdvAddAnimation("idle", (DirectionType)4, (AnimationType)1, new List<AnimationUtilityExtensions.DirectionalAnimationData>
			{
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "idle_back_right",
					wrapMode = (WrapMode)0,
					fps = 9,
					pathDirectory = "NevernamedsItems/Resources/Companions/Hapulon/hapulon_idlebackright"
				},
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "idle_front_right",
					wrapMode = (WrapMode)0,
					fps = 9,
					pathDirectory = "NevernamedsItems/Resources/Companions/Hapulon/hapulon_idleright"
				},
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "idle_front_left",
					wrapMode = (WrapMode)0,
					fps = 9,
					pathDirectory = "NevernamedsItems/Resources/Companions/Hapulon/hapulon_idleleft"
				},
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "idle_back_left",
					wrapMode = (WrapMode)0,
					fps = 9,
					pathDirectory = "NevernamedsItems/Resources/Companions/Hapulon/hapulon_idlebackright"
				}
			});
			orAddComponent.AdvAddAnimation("hop", (DirectionType)4, (AnimationType)6, new List<AnimationUtilityExtensions.DirectionalAnimationData>
			{
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "hop_back_right",
					wrapMode = (WrapMode)2,
					fps = 12,
					pathDirectory = "NevernamedsItems/Resources/Companions/Hapulon/hapulon_hopback"
				},
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "hop_front_right",
					wrapMode = (WrapMode)2,
					fps = 12,
					pathDirectory = "NevernamedsItems/Resources/Companions/Hapulon/hapulon_hopright"
				},
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "hop_front_left",
					wrapMode = (WrapMode)2,
					fps = 12,
					pathDirectory = "NevernamedsItems/Resources/Companions/Hapulon/hapulon_hopleft"
				},
				new AnimationUtilityExtensions.DirectionalAnimationData
				{
					subAnimationName = "hop_back_left",
					wrapMode = (WrapMode)2,
					fps = 12,
					pathDirectory = "NevernamedsItems/Resources/Companions/Hapulon/hapulon_hopback"
				}
			});
			BehaviorSpeculator component = prefab.GetComponent<BehaviorSpeculator>();
			EnemyApproachingHopper enemyApproachingHopper = new EnemyApproachingHopper();
			enemyApproachingHopper.hopAnim = "hop";
			component.MovementBehaviors.Add((MovementBehaviorBase)(object)enemyApproachingHopper);
		}
	}
}
