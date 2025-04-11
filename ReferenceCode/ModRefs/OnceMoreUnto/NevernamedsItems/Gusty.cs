using System.Collections.Generic;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class Gusty : PassiveItem
{
	public class GustyBehav : CompanionController
	{
		private float timer;

		public PlayerController Owner;

		private float KnockBackForce
		{
			get
			{
				float num = 70f;
				if (Object.op_Implicit((Object)(object)Owner))
				{
					num *= Owner.stats.GetStatValue((StatType)12);
				}
				return num;
			}
		}

		private void Start()
		{
			Owner = base.m_owner;
			timer = 1.5f;
			Owner.OnPreDodgeRoll += OnOwnerDodgeRolled;
		}

		public override void OnDestroy()
		{
			if (Object.op_Implicit((Object)(object)Owner))
			{
				Owner.OnPreDodgeRoll -= OnOwnerDodgeRolled;
			}
			((CompanionController)this).OnDestroy();
		}

		private void OnOwnerDodgeRolled(PlayerController dodger)
		{
			if (Object.op_Implicit((Object)(object)dodger) && CustomSynergies.PlayerHasActiveSynergy(dodger, "Gale Force"))
			{
				DoPloomph();
			}
		}

		public override void Update()
		{
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			if (Object.op_Implicit((Object)(object)Owner) && !Dungeon.IsGenerating && Owner.IsInCombat && Vector3Extensions.GetAbsoluteRoom(((BraveBehaviour)this).transform.position) == Owner.CurrentRoom)
			{
				if (timer > 0f)
				{
					timer -= BraveTime.DeltaTime;
				}
				if (timer <= 0f)
				{
					DoPloomph();
				}
			}
		}

		private void DoPloomph()
		{
			//IL_0061: Unknown result type (might be due to invalid IL or missing references)
			//IL_0066: Unknown result type (might be due to invalid IL or missing references)
			//IL_0088: Unknown result type (might be due to invalid IL or missing references)
			//IL_008d: Unknown result type (might be due to invalid IL or missing references)
			((BraveBehaviour)this).aiAnimator.PlayUntilFinished("attack", false, (string)null, -1f, false);
			QueriedCompanionStats val = PlayerUtility.GetExtComp(Owner).QueryCompanionStats(((Component)this).gameObject, 2.5f, 1f, 0f, 0f, 0f, 0f, KnockBackForce, 0f, true);
			Exploder.DoRadialKnockback(Vector2.op_Implicit(((BraveBehaviour)this).specRigidbody.UnitCenter), val.modifiedKnockback, 10f);
			Exploder.DoRadialDamage(val.modifiedDamage, Vector2.op_Implicit(((BraveBehaviour)this).specRigidbody.UnitCenter), 10f, false, true, false, (VFXPool)null);
			timer = 1.5f / val.modifiedFirerate;
		}
	}

	public static GameObject prefab;

	private static readonly string guid = "gusty94374329784374984563489";

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<CompanionItem>("Gusty", "Windbag", "Plomphs around, and doesn't let anyone get in his way.\n\nStore in a cool, dry place.", "gusty_icon", assetbundle: true);
		CompanionItem val = (CompanionItem)(object)((obj is CompanionItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)1;
		val.CompanionGuid = guid;
		BuildPrefab();
	}

	public static void BuildPrefab()
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Expected O, but got Unknown
		if (!((Object)(object)prefab != (Object)null) && !CompanionBuilder.companionDictionary.ContainsKey(guid))
		{
			prefab = CompanionBuilder.BuildPrefab("Gusty", guid, "NevernamedsItems/Resources/Companions/Gusty/gusty_idle_001", new IntVector2(5, 3), new IntVector2(11, 11));
			GustyBehav gustyBehav = prefab.AddComponent<GustyBehav>();
			((BraveBehaviour)gustyBehav).aiActor.MovementSpeed = 5f;
			((CompanionController)gustyBehav).CanCrossPits = true;
			((GameActor)((BraveBehaviour)gustyBehav).aiActor).ActorShadowOffset = new Vector3(0f, -0.5f);
			CompanionBuilder.AddAnimation(prefab, "flight", "NevernamedsItems/Resources/Companions/Gusty/gusty_idle", 7, (AnimationType)1, (DirectionType)1, (FlipType)0);
			CompanionBuilder.AddAnimation(prefab, "idle", "NevernamedsItems/Resources/Companions/Gusty/gusty_idle", 7, (AnimationType)3, (DirectionType)1, (FlipType)0);
			CompanionBuilder.AddAnimation(prefab, "attack", "NevernamedsItems/Resources/Companions/Gusty/gusty_attack", 14, (AnimationType)1, (DirectionType)1, (FlipType)0);
			((BraveBehaviour)gustyBehav).aiAnimator.GetDirectionalAnimation("idle").Prefix = "idle";
			prefab.GetComponent<tk2dSpriteAnimator>().GetClipByName("attack").wrapMode = (WrapMode)2;
			BehaviorSpeculator component = prefab.GetComponent<BehaviorSpeculator>();
			CustomCompanionBehaviours.SimpleCompanionApproach simpleCompanionApproach = new CustomCompanionBehaviours.SimpleCompanionApproach();
			simpleCompanionApproach.DesiredDistance = 2f;
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
