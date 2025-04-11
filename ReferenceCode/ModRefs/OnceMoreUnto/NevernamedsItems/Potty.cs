using System;
using System.Collections.Generic;
using System.Reflection;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class Potty : CompanionItem
{
	public class PottyCompanionBehaviour : CompanionController
	{
		private float timer;

		private float RadialTimer;

		public PlayerController Owner;

		public bool dealsRadialCurseDamage;

		private void Start()
		{
			Owner = base.m_owner;
			Owner.OnRoomClearEvent += OnRoomClear;
			PlayerController owner = Owner;
			owner.OnEnteredCombat = (Action)Delegate.Combine(owner.OnEnteredCombat, new Action(OnEnteredCombat));
			timer = 3f;
			RadialTimer = 0.25f;
			AIActor.OnPreStart = (Action<AIActor>)Delegate.Combine(AIActor.OnPreStart, new Action<AIActor>(AIActorPreSpawn));
		}

		private void OnEnteredCombat()
		{
			timer = 3f;
			RadialTimer = 0.25f;
		}

		public override void OnDestroy()
		{
			if (Object.op_Implicit((Object)(object)Owner))
			{
				Owner.OnRoomClearEvent -= OnRoomClear;
				PlayerController owner = Owner;
				owner.OnEnteredCombat = (Action)Delegate.Remove(owner.OnEnteredCombat, new Action(OnEnteredCombat));
			}
			AIActor.OnPreStart = (Action<AIActor>)Delegate.Remove(AIActor.OnPreStart, new Action<AIActor>(AIActorPreSpawn));
			((CompanionController)this).OnDestroy();
		}

		private void AIActorPreSpawn(AIActor enemy)
		{
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			if (enemy.EnemyGuid == "c182a5cb704d460d9d099a47af49c913" && !enemy.CanTargetEnemies && enemy.CanTargetPlayers)
			{
				CompanionController orAddComponent = GameObjectExtensions.GetOrAddComponent<CompanionController>(((Component)enemy).gameObject);
				orAddComponent.companionID = (CompanionIdentifier)0;
				orAddComponent.Initialize(Owner);
				CompanionisedEnemyBulletModifiers orAddComponent2 = GameObjectExtensions.GetOrAddComponent<CompanionisedEnemyBulletModifiers>(((Component)enemy).gameObject);
				orAddComponent2.jammedDamageMultiplier = 2f;
				orAddComponent2.TintBullets = true;
				orAddComponent2.TintColor = ExtendedColours.honeyYellow;
				orAddComponent2.baseBulletDamage = 10f;
				((GameActor)enemy).ApplyEffect((GameActorEffect)(object)GameManager.Instance.Dungeon.sharedSettingsPrefab.DefaultPermanentCharmEffect, 1f, (Projectile)null);
				((Component)enemy).gameObject.AddComponent<KillOnRoomClear>();
				enemy.IsHarmlessEnemy = true;
				enemy.IgnoreForRoomClear = true;
			}
		}

		public override void Update()
		{
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			//IL_0098: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a2: Invalid comparison between Unknown and I4
			//IL_02b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0101: Unknown result type (might be due to invalid IL or missing references)
			//IL_016b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0172: Unknown result type (might be due to invalid IL or missing references)
			//IL_0177: Unknown result type (might be due to invalid IL or missing references)
			//IL_0313: Unknown result type (might be due to invalid IL or missing references)
			//IL_0374: Unknown result type (might be due to invalid IL or missing references)
			//IL_037e: Expected O, but got Unknown
			if (Object.op_Implicit((Object)(object)Owner) && !Dungeon.IsGenerating && Owner.IsInCombat && Vector3Extensions.GetAbsoluteRoom(((BraveBehaviour)this).transform.position) == Owner.CurrentRoom)
			{
				if (timer > 0f)
				{
					timer -= BraveTime.DeltaTime;
				}
				if (timer <= 0f)
				{
					bool flag = false;
					if ((int)GameManager.Instance.Dungeon.tileIndices.tilesetId == 128 || CustomSynergies.PlayerHasActiveSynergy(Owner, "They Grow Inside"))
					{
						float num = 0.25f;
						if (CustomSynergies.PlayerHasActiveSynergy(Owner, "They Grow Inside"))
						{
							num = 0.5f;
						}
						if (Random.value <= num)
						{
							AIActor nearestEnemyToPosition = MathsAndLogicHelper.GetNearestEnemyToPosition(((BraveBehaviour)this).specRigidbody.UnitCenter, true, (ActiveEnemyType)1, (List<AIActor>)null, (Func<AIActor, bool>)null);
							flag = true;
							if (Object.op_Implicit((Object)(object)nearestEnemyToPosition))
							{
								PickupObject byId = PickupObjectDatabase.GetById(347);
								VolleyReplacementSynergyProcessor component = ((Component)((byId is Gun) ? byId : null)).GetComponent<VolleyReplacementSynergyProcessor>();
								Projectile projectile = ((BraveBehaviour)component.SynergyVolley.projectiles[0].projectiles[0]).projectile;
								GameObject val = ProjSpawnHelper.SpawnProjectileTowardsPoint(((Component)projectile).gameObject, ((BraveBehaviour)this).sprite.WorldCenter, Vector2.op_Implicit(nearestEnemyToPosition.Position), 0f, 15f);
								Projectile component2 = val.GetComponent<Projectile>();
								if ((Object)(object)component2 != (Object)null)
								{
									component2.Owner = (GameActor)(object)Owner;
									component2.Shooter = ((BraveBehaviour)Owner).specRigidbody;
									component2.TreatedAsNonProjectileForChallenge = true;
									ProjectileData baseData = component2.baseData;
									baseData.damage *= Owner.stats.GetStatValue((StatType)5);
									ProjectileData baseData2 = component2.baseData;
									baseData2.speed *= Owner.stats.GetStatValue((StatType)6);
									ProjectileData baseData3 = component2.baseData;
									baseData3.force *= Owner.stats.GetStatValue((StatType)12);
									component2.AdditionalScaleMultiplier *= Owner.stats.GetStatValue((StatType)15);
									component2.UpdateSpeed();
									((CompanionController)this).HandleCompanionPostProcessProjectile(component2);
								}
							}
						}
					}
					if (Random.value <= 0.02f)
					{
						flag = true;
						bool shouldBeJammed = false;
						if (CustomSynergies.PlayerHasActiveSynergy(Owner, "Cursed Ceramics"))
						{
							shouldBeJammed = true;
						}
						AIActor val2 = CompanionisedEnemyUtility.SpawnCompanionisedEnemy(Owner, "c182a5cb704d460d9d099a47af49c913", Vector2Extensions.ToIntVector2(((BraveBehaviour)this).specRigidbody.UnitCenter, (VectorConversions)2), doTint: false, ExtendedColours.brown, 10, 2, shouldBeJammed, doFriendlyOverhead: true);
						((BraveBehaviour)val2).specRigidbody.CollideWithOthers = false;
					}
					if (Random.value <= 0.05f && CustomSynergies.PlayerHasActiveSynergy(Owner, "The Potter Boy"))
					{
						flag = true;
						AIActor randomActiveEnemy = Vector3Extensions.GetAbsoluteRoom(((BraveBehaviour)this).transform.position).GetRandomActiveEnemy(false);
						if (Object.op_Implicit((Object)(object)randomActiveEnemy) && randomActiveEnemy.IsNormalEnemy && Object.op_Implicit((Object)(object)((BraveBehaviour)randomActiveEnemy).healthHaver) && !((BraveBehaviour)randomActiveEnemy).healthHaver.IsBoss)
						{
							randomActiveEnemy.Transmogrify(EnemyDatabase.GetOrLoadByGuid("76bc43539fc24648bff4568c75c686d1"), (GameObject)ResourceCache.Acquire("Global VFX/VFX_Item_Spawn_Poof"));
						}
					}
					if (flag && Object.op_Implicit((Object)(object)((BraveBehaviour)this).aiAnimator))
					{
						((BraveBehaviour)this).aiAnimator.PlayUntilFinished("spawnobject", false, (string)null, -1f, false);
					}
					timer = 2f;
				}
				if (RadialTimer > 0f)
				{
					RadialTimer -= BraveTime.DeltaTime;
				}
				if (RadialTimer <= 0f)
				{
					HandleRadialEffects();
					RadialTimer = 0.05f;
				}
			}
			((CompanionController)this).Update();
		}

		private void HandleRadialEffects()
		{
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_006f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
			if (!dealsRadialCurseDamage && !CustomSynergies.PlayerHasActiveSynergy(Owner, "Teapotto"))
			{
				return;
			}
			List<AIActor> activeEnemies = Vector3Extensions.GetAbsoluteRoom(((BraveBehaviour)this).transform.position).GetActiveEnemies((ActiveEnemyType)0);
			if (activeEnemies == null)
			{
				return;
			}
			for (int i = 0; i < activeEnemies.Count; i++)
			{
				AIActor val = activeEnemies[i];
				if (!val.IsNormalEnemy)
				{
					continue;
				}
				float num = Vector2.Distance(((BraveBehaviour)this).specRigidbody.UnitCenter, ((GameActor)val).CenterPosition);
				if (dealsRadialCurseDamage && num <= 4f)
				{
					float num2 = 0.35f;
					num2 += Owner.stats.GetStatValue((StatType)14) * 0.1f;
					if (num2 > 1.2f)
					{
						num2 = 1.2f;
					}
					if (Object.op_Implicit((Object)(object)((BraveBehaviour)val).healthHaver))
					{
						((BraveBehaviour)val).healthHaver.ApplyDamage(num2, Vector2.zero, "Cursed Ceramics", (CoreDamageTypes)2, (DamageCategory)1, false, (PixelCollider)null, false);
					}
				}
				if (CustomSynergies.PlayerHasActiveSynergy(Owner, "Teapotto") && num <= 4f)
				{
					((GameActor)val).ApplyEffect((GameActorEffect)(object)StaticStatusEffects.hotLeadEffect, 1f, (Projectile)null);
				}
				else if (CustomSynergies.PlayerHasActiveSynergy(Owner, "Teapotto") && num <= 7f && Object.op_Implicit((Object)(object)((GameActor)Owner).CurrentGun) && ((PickupObject)((GameActor)Owner).CurrentGun).PickupObjectId == 596)
				{
					((GameActor)val).ApplyEffect((GameActorEffect)(object)StaticStatusEffects.hotLeadEffect, 1f, (Projectile)null);
				}
			}
		}

		private void OnRoomClear(PlayerController playerController)
		{
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			int num = 4;
			int num2 = 1;
			if (CustomSynergies.PlayerHasActiveSynergy(Owner, "What does it do?"))
			{
				num = 7;
				num2 = 2;
			}
			if (CustomSynergies.PlayerHasActiveSynergy(Owner, "Pot O' Gold") && Random.value <= 0.01f)
			{
				num = 51;
				num2 = 49;
			}
			LootEngine.SpawnCurrency(((BraveBehaviour)this).specRigidbody.UnitCenter, Random.Range(num2, num), false);
			if (Object.op_Implicit((Object)(object)((BraveBehaviour)this).aiAnimator))
			{
				((BraveBehaviour)this).aiAnimator.PlayUntilFinished("spawnobject", false, (string)null, -1f, false);
			}
		}
	}

	private static tk2dSpriteCollectionData PottyAnimationCollection;

	private static string[] spritePaths = new string[28]
	{
		"NevernamedsItems/Resources/Companions/Potty/potty_idle_left_001", "NevernamedsItems/Resources/Companions/Potty/potty_idle_left_002", "NevernamedsItems/Resources/Companions/Potty/potty_idle_left_003", "NevernamedsItems/Resources/Companions/Potty/potty_idle_left_004", "NevernamedsItems/Resources/Companions/Potty/potty_idle_right_001", "NevernamedsItems/Resources/Companions/Potty/potty_idle_right_002", "NevernamedsItems/Resources/Companions/Potty/potty_idle_right_003", "NevernamedsItems/Resources/Companions/Potty/potty_idle_right_004", "NevernamedsItems/Resources/Companions/Potty/potty_run_left1", "NevernamedsItems/Resources/Companions/Potty/potty_run_left2",
		"NevernamedsItems/Resources/Companions/Potty/potty_run_left3", "NevernamedsItems/Resources/Companions/Potty/potty_run_left4", "NevernamedsItems/Resources/Companions/Potty/potty_run_left5", "NevernamedsItems/Resources/Companions/Potty/potty_run_left6", "NevernamedsItems/Resources/Companions/Potty/potty_run_right1", "NevernamedsItems/Resources/Companions/Potty/potty_run_right2", "NevernamedsItems/Resources/Companions/Potty/potty_run_right3", "NevernamedsItems/Resources/Companions/Potty/potty_run_right4", "NevernamedsItems/Resources/Companions/Potty/potty_run_right5", "NevernamedsItems/Resources/Companions/Potty/potty_run_right6",
		"NevernamedsItems/Resources/Companions/Potty/potty_spawnobject_001", "NevernamedsItems/Resources/Companions/Potty/potty_spawnobject_002", "NevernamedsItems/Resources/Companions/Potty/potty_spawnobject_003", "NevernamedsItems/Resources/Companions/Potty/potty_spawnobject_004", "NevernamedsItems/Resources/Companions/Potty/potty_spawnobject_005", "NevernamedsItems/Resources/Companions/Potty/potty_spawnobject_006", "NevernamedsItems/Resources/Companions/Potty/potty_spawnobject_007", "NevernamedsItems/Resources/Companions/Potty/potty_spawnobject_008"
	};

	private static tk2dSpriteCollectionData CursedPottyAnimationCollection;

	private static string[] cursedspritePaths = new string[28]
	{
		"NevernamedsItems/Resources/Companions/Potty/cursedpotty_idle_left_001", "NevernamedsItems/Resources/Companions/Potty/cursedpotty_idle_left_002", "NevernamedsItems/Resources/Companions/Potty/cursedpotty_idle_left_003", "NevernamedsItems/Resources/Companions/Potty/cursedpotty_idle_left_004", "NevernamedsItems/Resources/Companions/Potty/cursedpotty_idle_right_001", "NevernamedsItems/Resources/Companions/Potty/cursedpotty_idle_right_002", "NevernamedsItems/Resources/Companions/Potty/cursedpotty_idle_right_003", "NevernamedsItems/Resources/Companions/Potty/cursedpotty_idle_right_004", "NevernamedsItems/Resources/Companions/Potty/cursedpotty_run_left_001", "NevernamedsItems/Resources/Companions/Potty/cursedpotty_run_left_002",
		"NevernamedsItems/Resources/Companions/Potty/cursedpotty_run_left_003", "NevernamedsItems/Resources/Companions/Potty/cursedpotty_run_left_004", "NevernamedsItems/Resources/Companions/Potty/cursedpotty_run_left_005", "NevernamedsItems/Resources/Companions/Potty/cursedpotty_run_left_006", "NevernamedsItems/Resources/Companions/Potty/cursedpotty_run_right_001", "NevernamedsItems/Resources/Companions/Potty/cursedpotty_run_right_002", "NevernamedsItems/Resources/Companions/Potty/cursedpotty_run_right_003", "NevernamedsItems/Resources/Companions/Potty/cursedpotty_run_right_004", "NevernamedsItems/Resources/Companions/Potty/cursedpotty_run_right_005", "NevernamedsItems/Resources/Companions/Potty/cursedpotty_run_right_006",
		"NevernamedsItems/Resources/Companions/Potty/cursedpotty_spawnobject_001", "NevernamedsItems/Resources/Companions/Potty/cursedpotty_spawnobject_002", "NevernamedsItems/Resources/Companions/Potty/cursedpotty_spawnobject_003", "NevernamedsItems/Resources/Companions/Potty/cursedpotty_spawnobject_004", "NevernamedsItems/Resources/Companions/Potty/cursedpotty_spawnobject_005", "NevernamedsItems/Resources/Companions/Potty/cursedpotty_spawnobject_006", "NevernamedsItems/Resources/Companions/Potty/cursedpotty_spawnobject_007", "NevernamedsItems/Resources/Companions/Potty/cursedpotty_spawnobject_008"
	};

	public static GameObject prefab;

	public static GameObject cursedprefab;

	private static readonly string guid = "potty_companion23892838320020000";

	private static readonly string cursedguid = "cursedpotty_companion2307923873494782937839";

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<Potty>("Potto", "Clay Companion", "Occasionally pops out some money on room clear, and hides some... other secrets.\n\nThis little pot appears to have gained sentience. It's empty head contains many things, but most of all it is full of friendship!", "potto_icon", assetbundle: true);
		CompanionItem val = (CompanionItem)(object)((obj is CompanionItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)2;
		val.CompanionGuid = guid;
		BuildPrefab();
		BuildCursedPrefab();
	}

	public override void Pickup(PlayerController player)
	{
		base.CompanionGuid = guid;
		((CompanionItem)this).Pickup(player);
	}

	public override void Update()
	{
		if (Object.op_Implicit((Object)(object)((CompanionItem)this).ExtantCompanion) && Object.op_Implicit((Object)(object)((CompanionItem)this).ExtantCompanion.GetComponent<PottyCompanionBehaviour>()) && Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			if (((CompanionItem)this).ExtantCompanion.GetComponent<PottyCompanionBehaviour>().dealsRadialCurseDamage && !CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Cursed Ceramics"))
			{
				base.CompanionGuid = guid;
				((CompanionItem)this).ForceCompanionRegeneration(((PassiveItem)this).Owner, (Vector2?)null);
			}
			else if (!((CompanionItem)this).ExtantCompanion.GetComponent<PottyCompanionBehaviour>().dealsRadialCurseDamage && CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Cursed Ceramics"))
			{
				base.CompanionGuid = cursedguid;
				((CompanionItem)this).ForceCompanionRegeneration(((PassiveItem)this).Owner, (Vector2?)null);
			}
		}
		((CompanionItem)this).Update();
	}

	public static void BuildPrefab()
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Expected O, but got Unknown
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_0179: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c4: Expected O, but got Unknown
		//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Expected O, but got Unknown
		//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)prefab != (Object)null || CompanionBuilder.companionDictionary.ContainsKey(guid))
		{
			return;
		}
		prefab = CompanionBuilder.BuildPrefab("Potty Companion", guid, "NevernamedsItems/Resources/Companions/Potty/potty_idle_left_001", new IntVector2(4, 0), new IntVector2(9, 8));
		PottyCompanionBehaviour pottyCompanionBehaviour = prefab.AddComponent<PottyCompanionBehaviour>();
		((CompanionController)pottyCompanionBehaviour).CanInterceptBullets = false;
		((CompanionController)pottyCompanionBehaviour).companionID = (CompanionIdentifier)0;
		((BraveBehaviour)pottyCompanionBehaviour).aiActor.MovementSpeed = 6f;
		((BraveBehaviour)((BraveBehaviour)pottyCompanionBehaviour).aiActor).healthHaver.PreventAllDamage = true;
		((BraveBehaviour)pottyCompanionBehaviour).aiActor.CollisionDamage = 0f;
		((BraveBehaviour)((BraveBehaviour)pottyCompanionBehaviour).aiActor).specRigidbody.CollideWithOthers = false;
		((BraveBehaviour)((BraveBehaviour)pottyCompanionBehaviour).aiActor).specRigidbody.CollideWithTileMap = false;
		BehaviorSpeculator component = prefab.GetComponent<BehaviorSpeculator>();
		List<MovementBehaviorBase> movementBehaviors = component.MovementBehaviors;
		CompanionFollowPlayerBehavior val = new CompanionFollowPlayerBehavior();
		val.IdleAnimations = new string[1] { "idle" };
		val.CatchUpRadius = 6f;
		val.CatchUpMaxSpeed = 10f;
		val.CatchUpAccelTime = 1f;
		val.CatchUpSpeed = 7f;
		movementBehaviors.Add((MovementBehaviorBase)(object)val);
		AIAnimator aiAnimator = ((BraveBehaviour)pottyCompanionBehaviour).aiAnimator;
		DirectionalAnimation val2 = new DirectionalAnimation();
		val2.Type = (DirectionType)2;
		val2.Flipped = (FlipType[])(object)new FlipType[2];
		val2.AnimNames = new string[2] { "run_right", "run_left" };
		aiAnimator.MoveAnimation = val2;
		val2 = new DirectionalAnimation();
		val2.Type = (DirectionType)2;
		val2.Flipped = (FlipType[])(object)new FlipType[2];
		val2.AnimNames = new string[2] { "idle_right", "idle_left" };
		aiAnimator.IdleAnimation = val2;
		List<NamedDirectionalAnimation> list = new List<NamedDirectionalAnimation>();
		NamedDirectionalAnimation val3 = new NamedDirectionalAnimation();
		val3.name = "spawnobject";
		val2 = new DirectionalAnimation();
		val2.Type = (DirectionType)1;
		val2.Prefix = "spawnobject";
		val2.AnimNames = new string[1];
		val2.Flipped = (FlipType[])(object)new FlipType[1];
		val3.anim = val2;
		list.Add(val3);
		aiAnimator.OtherAnimations = list;
		if ((Object)(object)PottyAnimationCollection == (Object)null)
		{
			PottyAnimationCollection = SpriteBuilder.ConstructCollection(prefab, "PottyCompanion_Collection", false);
			Object.DontDestroyOnLoad((Object)(object)PottyAnimationCollection);
			for (int i = 0; i < spritePaths.Length; i++)
			{
				SpriteBuilder.AddSpriteToCollection(spritePaths[i], PottyAnimationCollection, (Assembly)null);
			}
			SpriteBuilder.AddAnimation(((BraveBehaviour)pottyCompanionBehaviour).spriteAnimator, PottyAnimationCollection, new List<int> { 4, 5, 6, 7 }, "idle_right", (WrapMode)0, 15f).fps = 8f;
			SpriteBuilder.AddAnimation(((BraveBehaviour)pottyCompanionBehaviour).spriteAnimator, PottyAnimationCollection, new List<int> { 0, 1, 2, 3 }, "idle_left", (WrapMode)0, 15f).fps = 8f;
			SpriteBuilder.AddAnimation(((BraveBehaviour)pottyCompanionBehaviour).spriteAnimator, PottyAnimationCollection, new List<int> { 14, 15, 16, 17, 18, 19 }, "run_right", (WrapMode)0, 15f).fps = 8f;
			SpriteBuilder.AddAnimation(((BraveBehaviour)pottyCompanionBehaviour).spriteAnimator, PottyAnimationCollection, new List<int> { 8, 9, 10, 11, 12, 13 }, "run_left", (WrapMode)0, 15f).fps = 8f;
			SpriteBuilder.AddAnimation(((BraveBehaviour)pottyCompanionBehaviour).spriteAnimator, PottyAnimationCollection, new List<int> { 20, 21, 22, 23, 24, 25, 26, 27 }, "spawnobject", (WrapMode)2, 15f).fps = 12f;
		}
	}

	public static void BuildCursedPrefab()
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Expected O, but got Unknown
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Expected O, but got Unknown
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ac: Expected O, but got Unknown
		//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Expected O, but got Unknown
		//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)cursedprefab != (Object)null || CompanionBuilder.companionDictionary.ContainsKey(cursedguid))
		{
			return;
		}
		cursedprefab = CompanionBuilder.BuildPrefab("Cursed Potty Companion", cursedguid, "NevernamedsItems/Resources/Companions/Potty/cursedpotty_idle_left_001", new IntVector2(4, 0), new IntVector2(9, 8));
		PottyCompanionBehaviour pottyCompanionBehaviour = cursedprefab.AddComponent<PottyCompanionBehaviour>();
		((CompanionController)pottyCompanionBehaviour).CanInterceptBullets = false;
		((CompanionController)pottyCompanionBehaviour).companionID = (CompanionIdentifier)0;
		((BraveBehaviour)pottyCompanionBehaviour).aiActor.MovementSpeed = 6f;
		pottyCompanionBehaviour.dealsRadialCurseDamage = true;
		((BraveBehaviour)((BraveBehaviour)pottyCompanionBehaviour).aiActor).healthHaver.PreventAllDamage = true;
		((BraveBehaviour)pottyCompanionBehaviour).aiActor.CollisionDamage = 0f;
		((BraveBehaviour)((BraveBehaviour)pottyCompanionBehaviour).aiActor).specRigidbody.CollideWithOthers = false;
		((BraveBehaviour)((BraveBehaviour)pottyCompanionBehaviour).aiActor).specRigidbody.CollideWithTileMap = false;
		BehaviorSpeculator component = cursedprefab.GetComponent<BehaviorSpeculator>();
		component.MovementBehaviors.Add((MovementBehaviorBase)(object)new CustomCompanionBehaviours.PottyCompanionApproach());
		List<MovementBehaviorBase> movementBehaviors = component.MovementBehaviors;
		CompanionFollowPlayerBehavior val = new CompanionFollowPlayerBehavior();
		val.IdleAnimations = new string[1] { "idle" };
		movementBehaviors.Add((MovementBehaviorBase)(object)val);
		AIAnimator aiAnimator = ((BraveBehaviour)pottyCompanionBehaviour).aiAnimator;
		DirectionalAnimation val2 = new DirectionalAnimation();
		val2.Type = (DirectionType)2;
		val2.Flipped = (FlipType[])(object)new FlipType[2];
		val2.AnimNames = new string[2] { "run_right", "run_left" };
		aiAnimator.MoveAnimation = val2;
		val2 = new DirectionalAnimation();
		val2.Type = (DirectionType)2;
		val2.Flipped = (FlipType[])(object)new FlipType[2];
		val2.AnimNames = new string[2] { "idle_right", "idle_left" };
		aiAnimator.IdleAnimation = val2;
		List<NamedDirectionalAnimation> list = new List<NamedDirectionalAnimation>();
		NamedDirectionalAnimation val3 = new NamedDirectionalAnimation();
		val3.name = "spawnobject";
		val2 = new DirectionalAnimation();
		val2.Type = (DirectionType)1;
		val2.Prefix = "spawnobject";
		val2.AnimNames = new string[1];
		val2.Flipped = (FlipType[])(object)new FlipType[1];
		val3.anim = val2;
		list.Add(val3);
		aiAnimator.OtherAnimations = list;
		if ((Object)(object)CursedPottyAnimationCollection == (Object)null)
		{
			CursedPottyAnimationCollection = SpriteBuilder.ConstructCollection(cursedprefab, "CursedPottyCompanion_Collection", false);
			Object.DontDestroyOnLoad((Object)(object)CursedPottyAnimationCollection);
			for (int i = 0; i < cursedspritePaths.Length; i++)
			{
				SpriteBuilder.AddSpriteToCollection(cursedspritePaths[i], CursedPottyAnimationCollection, (Assembly)null);
			}
			SpriteBuilder.AddAnimation(((BraveBehaviour)pottyCompanionBehaviour).spriteAnimator, CursedPottyAnimationCollection, new List<int> { 4, 5, 6, 7 }, "idle_right", (WrapMode)0, 15f).fps = 8f;
			SpriteBuilder.AddAnimation(((BraveBehaviour)pottyCompanionBehaviour).spriteAnimator, CursedPottyAnimationCollection, new List<int> { 0, 1, 2, 3 }, "idle_left", (WrapMode)0, 15f).fps = 8f;
			SpriteBuilder.AddAnimation(((BraveBehaviour)pottyCompanionBehaviour).spriteAnimator, CursedPottyAnimationCollection, new List<int> { 14, 15, 16, 17, 18, 19 }, "run_right", (WrapMode)0, 15f).fps = 8f;
			SpriteBuilder.AddAnimation(((BraveBehaviour)pottyCompanionBehaviour).spriteAnimator, CursedPottyAnimationCollection, new List<int> { 8, 9, 10, 11, 12, 13 }, "run_left", (WrapMode)0, 15f).fps = 8f;
			SpriteBuilder.AddAnimation(((BraveBehaviour)pottyCompanionBehaviour).spriteAnimator, CursedPottyAnimationCollection, new List<int> { 20, 21, 22, 23, 24, 25, 26, 27 }, "spawnobject", (WrapMode)2, 15f).fps = 12f;
		}
	}
}
