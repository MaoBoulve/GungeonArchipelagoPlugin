using System;
using System.Collections.Generic;
using System.Reflection;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class DroneCompanion : PassiveItem
{
	public class DroneBulletComponent : MonoBehaviour
	{
	}

	public class DroneCompanionBehaviour : CompanionController
	{
		private bool canFireBeamChargeProjectile = true;

		public PlayerController Owner;

		private void Start()
		{
			Owner = base.m_owner;
			Owner.PostProcessProjectile += OnOwnerFiredGun;
			PlayerController owner = Owner;
			owner.OnEnteredCombat = (Action)Delegate.Combine(owner.OnEnteredCombat, new Action(OnEnteredCombat));
		}

		private void OnOwnerFiredGun(Projectile bullet, float h)
		{
			if (!bullet.TreatedAsNonProjectileForChallenge && (Object)(object)((Component)bullet).gameObject.GetComponent<DroneBulletComponent>() == (Object)null && (Object)(object)((Component)bullet).gameObject.GetComponent<BulletsWithGuns.BulletFromBulletWithGun>() == (Object)null)
			{
				TriggerShootBullet(bullet.baseData.range, bullet.baseData.speed);
			}
		}

		private void TriggerShootBullet(float range, float speed, float overrideDamageMult = 1f)
		{
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			if (Object.op_Implicit((Object)(object)((BraveBehaviour)this).specRigidbody) && Object.op_Implicit((Object)(object)Owner) && Object.op_Implicit((Object)(object)((GameActor)Owner).CurrentGun))
			{
				float angleVariance = GunTools.RawDefaultModule(((GameActor)Owner).CurrentGun).angleVariance;
				GameObject val = ProjSpawnHelper.SpawnProjectileTowardsPoint(((Component)DroneCompanionProjectile).gameObject, ((BraveBehaviour)this).specRigidbody.UnitBottomCenter, Vector3Extensions.XY(Owner.unadjustedAimPoint), 0f, angleVariance);
				Projectile component = val.GetComponent<Projectile>();
				if ((Object)(object)component != (Object)null)
				{
					component.Owner = (GameActor)(object)Owner;
					component.Shooter = ((BraveBehaviour)this).specRigidbody;
					ProjectileUtility.ApplyCompanionModifierToBullet(component, Owner);
					component.TreatedAsNonProjectileForChallenge = true;
					component.baseData.range = range;
					ProjectileData baseData = component.baseData;
					baseData.damage *= overrideDamageMult;
					ProjectileData baseData2 = component.baseData;
					baseData2.damage *= Owner.stats.GetStatValue((StatType)5);
					component.baseData.speed = speed;
					ProjectileData baseData3 = component.baseData;
					baseData3.force *= Owner.stats.GetStatValue((StatType)12);
					component.AdditionalScaleMultiplier *= Owner.stats.GetStatValue((StatType)15);
					component.UpdateSpeed();
					Owner.DoPostProcessProjectile(component);
				}
				if (CustomSynergies.PlayerHasActiveSynergy(Owner, "Wrong Kind Of Drone") && Random.value <= 0.2f)
				{
					FireBeeBullet();
				}
			}
		}

		private void FireBeeBullet()
		{
			//IL_000d: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			Projectile val = ((Gun)Databases.Items[14]).DefaultModule.projectiles[0];
			GameObject val2 = ProjSpawnHelper.SpawnProjectileTowardsPoint(((Component)val).gameObject, ((BraveBehaviour)this).specRigidbody.UnitBottomCenter, Vector3Extensions.XY(Owner.unadjustedAimPoint));
			Projectile component = val2.GetComponent<Projectile>();
			if ((Object)(object)component != (Object)null)
			{
				component.Owner = (GameActor)(object)Owner;
				component.Shooter = ((BraveBehaviour)this).specRigidbody;
				Owner.DoPostProcessProjectile(component);
			}
		}

		private void OnEnteredCombat()
		{
			//IL_0022: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Unknown result type (might be due to invalid IL or missing references)
			if (Object.op_Implicit((Object)(object)Owner))
			{
				((BraveBehaviour)this).aiActor.CompanionWarp(Vector2.op_Implicit(((BraveBehaviour)Owner).specRigidbody.UnitCenter));
			}
		}

		public override void OnDestroy()
		{
			if (Object.op_Implicit((Object)(object)Owner))
			{
				PlayerController owner = Owner;
				owner.OnEnteredCombat = (Action)Delegate.Remove(owner.OnEnteredCombat, new Action(OnEnteredCombat));
				Owner.PostProcessProjectile -= OnOwnerFiredGun;
			}
			((CompanionController)this).OnDestroy();
		}

		public override void Update()
		{
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Invalid comparison between Unknown and I4
			//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bb: Invalid comparison between Unknown and I4
			if (Object.op_Implicit((Object)(object)Owner) && Object.op_Implicit((Object)(object)((GameActor)Owner).CurrentGun) && canFireBeamChargeProjectile)
			{
				if ((int)((GameActor)Owner).CurrentGun.DefaultModule.shootStyle == 2 && ((GameActor)Owner).CurrentGun.IsFiring)
				{
					TriggerShootBullet(10000000f, 20f * Owner.stats.GetStatValue((StatType)6), 0.5f);
					canFireBeamChargeProjectile = false;
					((MonoBehaviour)this).Invoke("ResetBeamChargeShit", 0.05f);
				}
				if ((int)((GameActor)Owner).CurrentGun.DefaultModule.shootStyle == 3 && ((GameActor)Owner).CurrentGun.IsCharging)
				{
					TriggerShootBullet(10000000f, 20f * Owner.stats.GetStatValue((StatType)6));
					canFireBeamChargeProjectile = false;
					((MonoBehaviour)this).Invoke("ResetBeamChargeShit", 0.25f);
				}
			}
			((CompanionController)this).Update();
		}

		private void ResetBeamChargeShit()
		{
			canFireBeamChargeProjectile = true;
		}
	}

	public static int DroneID;

	public static Projectile DroneCompanionProjectile;

	private static tk2dSpriteCollectionData DroneAnimationCollection;

	private static string[] spritePaths = new string[12]
	{
		"NevernamedsItems/Resources/Companions/DroneCompanion/drone_idle_001", "NevernamedsItems/Resources/Companions/DroneCompanion/drone_idle_002", "NevernamedsItems/Resources/Companions/DroneCompanion/drone_idle_003", "NevernamedsItems/Resources/Companions/DroneCompanion/drone_idle_004", "NevernamedsItems/Resources/Companions/DroneCompanion/drone_idle_005", "NevernamedsItems/Resources/Companions/DroneCompanion/drone_idle_006", "NevernamedsItems/Resources/Companions/DroneCompanion/drone_run_right_001", "NevernamedsItems/Resources/Companions/DroneCompanion/drone_run_right_002", "NevernamedsItems/Resources/Companions/DroneCompanion/drone_run_right_003", "NevernamedsItems/Resources/Companions/DroneCompanion/drone_run_left_001",
		"NevernamedsItems/Resources/Companions/DroneCompanion/drone_run_left_002", "NevernamedsItems/Resources/Companions/DroneCompanion/drone_run_left_003"
	};

	public static GameObject prefab;

	private static readonly string guid = "drone_companion3873585485739893484";

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<CompanionItem>("Drone", "Beep Boop I'm A Drone", "This little drone seems friendly despite it's objective lack of most defining features.\n\nIt seems accustomed to descending...", "drone_icon", assetbundle: true);
		CompanionItem val = (CompanionItem)(object)((obj is CompanionItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)3;
		val.CompanionGuid = guid;
		BuildPrefab();
		PickupObject byId = PickupObjectDatabase.GetById(56);
		Projectile val2 = Object.Instantiate<Projectile>(((Gun)((byId is Gun) ? byId : null)).DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		ProjectileData baseData = val2.baseData;
		baseData.speed *= 1.2f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.range *= 1f;
		ProjectileData baseData3 = val2.baseData;
		baseData3.damage *= 0.8f;
		((Component)val2).gameObject.AddComponent<DroneBulletComponent>();
		val2.SetProjectileSprite("drone_projectile", 14, 8, lightened: true, (Anchor)4, 12, 6, anchorChangesCollider: true, fixesScale: false, null, null);
		DroneCompanionProjectile = val2;
		DroneID = ((PickupObject)val).PickupObjectId;
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.PURCHASED_DRONE, requiredFlagValue: true);
	}

	public static void BuildPrefab()
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Expected O, but got Unknown
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)prefab != (Object)null || CompanionBuilder.companionDictionary.ContainsKey(guid))
		{
			return;
		}
		prefab = CompanionBuilder.BuildPrefab("Drone Companion", guid, "NevernamedsItems/Resources/Companions/DroneCompanion/drone_idle_001", new IntVector2(5, 10), new IntVector2(10, 12));
		DroneCompanionBehaviour droneCompanionBehaviour = prefab.AddComponent<DroneCompanionBehaviour>();
		((CompanionController)droneCompanionBehaviour).CanCrossPits = true;
		((CompanionController)droneCompanionBehaviour).CanInterceptBullets = false;
		((CompanionController)droneCompanionBehaviour).companionID = (CompanionIdentifier)0;
		((BraveBehaviour)droneCompanionBehaviour).aiActor.MovementSpeed = 7f;
		((BraveBehaviour)((BraveBehaviour)droneCompanionBehaviour).aiActor).healthHaver.PreventAllDamage = true;
		((BraveBehaviour)droneCompanionBehaviour).aiActor.CollisionDamage = 0f;
		((GameActor)((BraveBehaviour)droneCompanionBehaviour).aiActor).ActorShadowOffset = new Vector3(0f, -1f);
		((BraveBehaviour)((BraveBehaviour)droneCompanionBehaviour).aiActor).specRigidbody.CollideWithOthers = false;
		((BraveBehaviour)((BraveBehaviour)droneCompanionBehaviour).aiActor).specRigidbody.CollideWithTileMap = false;
		BehaviorSpeculator component = prefab.GetComponent<BehaviorSpeculator>();
		List<MovementBehaviorBase> movementBehaviors = component.MovementBehaviors;
		CompanionFollowPlayerBehavior val = new CompanionFollowPlayerBehavior();
		val.IdleAnimations = new string[1] { "idle" };
		val.CatchUpRadius = 6f;
		val.CatchUpMaxSpeed = 10f;
		val.CatchUpAccelTime = 1f;
		val.CatchUpSpeed = 7f;
		movementBehaviors.Add((MovementBehaviorBase)(object)val);
		AIAnimator aiAnimator = ((BraveBehaviour)droneCompanionBehaviour).aiAnimator;
		DirectionalAnimation val2 = new DirectionalAnimation();
		val2.Type = (DirectionType)2;
		val2.Flipped = (FlipType[])(object)new FlipType[2];
		val2.AnimNames = new string[2] { "run_right", "run_left" };
		aiAnimator.MoveAnimation = val2;
		val2 = new DirectionalAnimation();
		val2.Type = (DirectionType)1;
		val2.Prefix = "idle";
		val2.AnimNames = new string[1];
		val2.Flipped = (FlipType[])(object)new FlipType[1];
		aiAnimator.IdleAnimation = val2;
		if ((Object)(object)DroneAnimationCollection == (Object)null)
		{
			DroneAnimationCollection = SpriteBuilder.ConstructCollection(prefab, "DroneCompanion_Collection", false);
			Object.DontDestroyOnLoad((Object)(object)DroneAnimationCollection);
			for (int i = 0; i < spritePaths.Length; i++)
			{
				SpriteBuilder.AddSpriteToCollection(spritePaths[i], DroneAnimationCollection, (Assembly)null);
			}
			SpriteBuilder.AddAnimation(((BraveBehaviour)droneCompanionBehaviour).spriteAnimator, DroneAnimationCollection, new List<int> { 0, 1, 2, 3, 4, 5 }, "idle", (WrapMode)0, 15f).fps = 8f;
			SpriteBuilder.AddAnimation(((BraveBehaviour)droneCompanionBehaviour).spriteAnimator, DroneAnimationCollection, new List<int> { 6, 7, 8 }, "run_right", (WrapMode)0, 15f).fps = 8f;
			SpriteBuilder.AddAnimation(((BraveBehaviour)droneCompanionBehaviour).spriteAnimator, DroneAnimationCollection, new List<int> { 9, 10, 11 }, "run_left", (WrapMode)0, 15f).fps = 8f;
		}
	}
}
