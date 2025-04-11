using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class MolotovBuddy : PassiveItem
{
	public class MolotovCompanionBehaviour : CompanionController
	{
		[CompilerGenerated]
		private sealed class _003CDoBurst_003Ed__3 : IEnumerator<object>, IDisposable, IEnumerator
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public MolotovCompanionBehaviour _003C_003E4__this;

			private DeadlyDeadlyGoopManager _003CgoopManagerForGoopType_003E5__1;

			private Vector2 _003Cvector_003E5__2;

			private Vector2 _003Cnormalized_003E5__3;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return _003C_003E2__current;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			public _003CDoBurst_003Ed__3(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				_003CgoopManagerForGoopType_003E5__1 = null;
				_003C_003E1__state = -2;
			}

			private bool MoveNext()
			{
				//IL_0067: Unknown result type (might be due to invalid IL or missing references)
				//IL_0071: Expected O, but got Unknown
				//IL_0161: Unknown result type (might be due to invalid IL or missing references)
				//IL_016b: Expected O, but got Unknown
				//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
				//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
				//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
				//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
				//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
				//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
				//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
				//IL_0103: Unknown result type (might be due to invalid IL or missing references)
				//IL_0119: Unknown result type (might be due to invalid IL or missing references)
				//IL_0129: Unknown result type (might be due to invalid IL or missing references)
				//IL_012f: Unknown result type (might be due to invalid IL or missing references)
				//IL_0139: Unknown result type (might be due to invalid IL or missing references)
				//IL_013e: Unknown result type (might be due to invalid IL or missing references)
				switch (_003C_003E1__state)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					((BraveBehaviour)_003C_003E4__this).aiActor.MovementSpeed = 0f;
					((BraveBehaviour)_003C_003E4__this).aiAnimator.PlayUntilFinished("burst", false, (string)null, -1f, false);
					_003C_003E2__current = (object)new WaitForSeconds(0.25f);
					_003C_003E1__state = 1;
					return true;
				case 1:
					_003C_003E1__state = -1;
					if (Object.op_Implicit((Object)(object)((BraveBehaviour)_003C_003E4__this).aiActor.OverrideTarget))
					{
						_003CgoopManagerForGoopType_003E5__1 = DeadlyDeadlyGoopManager.GetGoopManagerForGoopType(EasyGoopDefinitions.FireDef);
						AkSoundEngine.PostEvent("Play_OBJ_glassbottle_shatter_01", ((Component)_003C_003E4__this).gameObject);
						_003Cvector_003E5__2 = ((BraveBehaviour)_003C_003E4__this).specRigidbody.UnitCenter;
						Vector2 val = ((BraveBehaviour)_003C_003E4__this).aiActor.OverrideTarget.UnitCenter - _003Cvector_003E5__2;
						_003Cnormalized_003E5__3 = ((Vector2)(ref val)).normalized;
						_003CgoopManagerForGoopType_003E5__1.TimedAddGoopLine(((BraveBehaviour)_003C_003E4__this).specRigidbody.UnitCenter, ((BraveBehaviour)_003C_003E4__this).specRigidbody.UnitCenter + _003Cnormalized_003E5__3 * 7f, 1f, 0.5f);
						_003CgoopManagerForGoopType_003E5__1 = null;
					}
					_003C_003E2__current = (object)new WaitForSeconds(0.25f);
					_003C_003E1__state = 2;
					return true;
				case 2:
					_003C_003E1__state = -1;
					((BraveBehaviour)((BraveBehaviour)_003C_003E4__this).sprite).renderer.enabled = false;
					((BraveBehaviour)_003C_003E4__this).aiActor.EraseFromExistence(false);
					return false;
				}
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}
		}

		private bool isAttacking = false;

		public PlayerController Owner;

		private void Start()
		{
			Owner = base.m_owner;
		}

		public override void Update()
		{
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			if (Object.op_Implicit((Object)(object)this) && Object.op_Implicit((Object)(object)Owner) && !Dungeon.IsGenerating && Object.op_Implicit((Object)(object)((BraveBehaviour)this).aiActor) && Object.op_Implicit((Object)(object)((BraveBehaviour)this).aiActor.OverrideTarget) && !isAttacking && Vector2.Distance(((BraveBehaviour)this).specRigidbody.UnitCenter, ((BraveBehaviour)this).aiActor.OverrideTarget.UnitCenter) < 5f)
			{
				((MonoBehaviour)this).StartCoroutine(DoBurst());
				isAttacking = true;
			}
			((CompanionController)this).Update();
		}

		private IEnumerator DoBurst()
		{
			//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
			return new _003CDoBurst_003Ed__3(0)
			{
				_003C_003E4__this = this
			};
		}
	}

	private float respawnTimer = 0f;

	private float respawnTimer2 = 0f;

	private GameObject extantBud = null;

	private GameObject extantBud2 = null;

	private static tk2dSpriteCollectionData MolotovBudAnimationCollection;

	private static string[] spritePaths = new string[26]
	{
		"NevernamedsItems/Resources/Companions/MolotovBud/molotovbud_idle_left_001", "NevernamedsItems/Resources/Companions/MolotovBud/molotovbud_idle_left_002", "NevernamedsItems/Resources/Companions/MolotovBud/molotovbud_idle_left_003", "NevernamedsItems/Resources/Companions/MolotovBud/molotovbud_idle_left_004", "NevernamedsItems/Resources/Companions/MolotovBud/molotovbud_idle_right_001", "NevernamedsItems/Resources/Companions/MolotovBud/molotovbud_idle_right_002", "NevernamedsItems/Resources/Companions/MolotovBud/molotovbud_idle_right_003", "NevernamedsItems/Resources/Companions/MolotovBud/molotovbud_idle_right_004", "NevernamedsItems/Resources/Companions/MolotovBud/molotovbud_move_left_001", "NevernamedsItems/Resources/Companions/MolotovBud/molotovbud_move_left_002",
		"NevernamedsItems/Resources/Companions/MolotovBud/molotovbud_move_left_003", "NevernamedsItems/Resources/Companions/MolotovBud/molotovbud_move_left_004", "NevernamedsItems/Resources/Companions/MolotovBud/molotovbud_move_left_005", "NevernamedsItems/Resources/Companions/MolotovBud/molotovbud_move_left_006", "NevernamedsItems/Resources/Companions/MolotovBud/molotovbud_move_right_001", "NevernamedsItems/Resources/Companions/MolotovBud/molotovbud_move_right_002", "NevernamedsItems/Resources/Companions/MolotovBud/molotovbud_move_right_003", "NevernamedsItems/Resources/Companions/MolotovBud/molotovbud_move_right_004", "NevernamedsItems/Resources/Companions/MolotovBud/molotovbud_move_right_005", "NevernamedsItems/Resources/Companions/MolotovBud/molotovbud_move_right_006",
		"NevernamedsItems/Resources/Companions/MolotovBud/molotovbud_burst_001", "NevernamedsItems/Resources/Companions/MolotovBud/molotovbud_burst_002", "NevernamedsItems/Resources/Companions/MolotovBud/molotovbud_burst_003", "NevernamedsItems/Resources/Companions/MolotovBud/molotovbud_burst_004", "NevernamedsItems/Resources/Companions/MolotovBud/molotovbud_burst_005", "NevernamedsItems/Resources/Companions/MolotovBud/molotovbud_burst_006"
	};

	public static GameObject prefab;

	private static readonly string guid = "moltovbuddy723839ehufhwifweugfsfgskd";

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<MolotovBuddy>("Molotov Buddy", "Hot Headed Friend", "This regular molotov was given sentience by the magic of the Gungeon, and with it he gained a firey attitude.\n\nIf he could, he would burn the world. What he hates most of all is people calling him cute.", "molotovbud_icon", assetbundle: true);
		val.quality = (ItemQuality)1;
		BuildPrefab();
	}

	public override void Update()
	{
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			if (respawnTimer <= 0f)
			{
				AIActor orLoadByGuid = EnemyDatabase.GetOrLoadByGuid(guid);
				Vector3 position = ((BraveBehaviour)((PassiveItem)this).Owner).transform.position;
				GameObject val = Object.Instantiate<GameObject>(((Component)orLoadByGuid).gameObject, position, Quaternion.identity);
				MolotovCompanionBehaviour orAddComponent = GameObjectExtensions.GetOrAddComponent<MolotovCompanionBehaviour>(val);
				extantBud = val;
				((CompanionController)orAddComponent).Initialize(((PassiveItem)this).Owner);
				if (Object.op_Implicit((Object)(object)((BraveBehaviour)orAddComponent).specRigidbody))
				{
					PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(((BraveBehaviour)orAddComponent).specRigidbody, (int?)null, false);
				}
				respawnTimer = 7f;
			}
			else if ((Object)(object)extantBud == (Object)null)
			{
				respawnTimer -= BraveTime.DeltaTime;
			}
			if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Molly Tov"))
			{
				if (respawnTimer2 <= 0f)
				{
					AIActor orLoadByGuid2 = EnemyDatabase.GetOrLoadByGuid(guid);
					Vector3 position2 = ((BraveBehaviour)((PassiveItem)this).Owner).transform.position;
					GameObject val2 = Object.Instantiate<GameObject>(((Component)orLoadByGuid2).gameObject, position2, Quaternion.identity);
					MolotovCompanionBehaviour orAddComponent2 = GameObjectExtensions.GetOrAddComponent<MolotovCompanionBehaviour>(val2);
					extantBud2 = val2;
					((CompanionController)orAddComponent2).Initialize(((PassiveItem)this).Owner);
					if (Object.op_Implicit((Object)(object)((BraveBehaviour)orAddComponent2).specRigidbody))
					{
						PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(((BraveBehaviour)orAddComponent2).specRigidbody, (int?)null, false);
					}
					respawnTimer2 = 7f;
				}
				else if ((Object)(object)extantBud2 == (Object)null)
				{
					respawnTimer2 -= BraveTime.DeltaTime;
				}
			}
		}
		((PassiveItem)this).Update();
	}

	public static void BuildPrefab()
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Expected O, but got Unknown
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Expected O, but got Unknown
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_019a: Expected O, but got Unknown
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Expected O, but got Unknown
		//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fa: Expected O, but got Unknown
		//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)prefab != (Object)null || CompanionBuilder.companionDictionary.ContainsKey(guid))
		{
			return;
		}
		prefab = CompanionBuilder.BuildPrefab("Molotov Bud Companion", guid, "NevernamedsItems/Resources/Companions/MolotovBud/molotovbud_idle_left_001", new IntVector2(12, 1), new IntVector2(5, 5));
		MolotovCompanionBehaviour molotovCompanionBehaviour = prefab.AddComponent<MolotovCompanionBehaviour>();
		((CompanionController)molotovCompanionBehaviour).CanInterceptBullets = false;
		((CompanionController)molotovCompanionBehaviour).companionID = (CompanionIdentifier)0;
		((BraveBehaviour)molotovCompanionBehaviour).aiActor.MovementSpeed = 6f;
		((BraveBehaviour)((BraveBehaviour)molotovCompanionBehaviour).aiActor).healthHaver.PreventAllDamage = true;
		((BraveBehaviour)molotovCompanionBehaviour).aiActor.CollisionDamage = 0f;
		((BraveBehaviour)((BraveBehaviour)molotovCompanionBehaviour).aiActor).specRigidbody.CollideWithOthers = false;
		((BraveBehaviour)((BraveBehaviour)molotovCompanionBehaviour).aiActor).specRigidbody.CollideWithTileMap = false;
		BehaviorSpeculator component = prefab.GetComponent<BehaviorSpeculator>();
		CustomCompanionBehaviours.SimpleCompanionApproach simpleCompanionApproach = new CustomCompanionBehaviours.SimpleCompanionApproach();
		simpleCompanionApproach.DesiredDistance = 3f;
		component.MovementBehaviors.Add((MovementBehaviorBase)(object)simpleCompanionApproach);
		List<MovementBehaviorBase> movementBehaviors = component.MovementBehaviors;
		CompanionFollowPlayerBehavior val = new CompanionFollowPlayerBehavior();
		val.IdleAnimations = new string[1] { "idle" };
		val.CatchUpRadius = 6f;
		val.CatchUpMaxSpeed = 10f;
		val.CatchUpAccelTime = 1f;
		val.CatchUpSpeed = 7f;
		movementBehaviors.Add((MovementBehaviorBase)(object)val);
		AIAnimator aiAnimator = ((BraveBehaviour)molotovCompanionBehaviour).aiAnimator;
		DirectionalAnimation val2 = new DirectionalAnimation();
		val2.Type = (DirectionType)2;
		val2.Flipped = (FlipType[])(object)new FlipType[2];
		val2.AnimNames = new string[2] { "move_right", "move_left" };
		aiAnimator.MoveAnimation = val2;
		val2 = new DirectionalAnimation();
		val2.Type = (DirectionType)2;
		val2.Flipped = (FlipType[])(object)new FlipType[2];
		val2.AnimNames = new string[2] { "idle_right", "idle_left" };
		aiAnimator.IdleAnimation = val2;
		List<NamedDirectionalAnimation> list = new List<NamedDirectionalAnimation>();
		NamedDirectionalAnimation val3 = new NamedDirectionalAnimation();
		val3.name = "burst";
		val2 = new DirectionalAnimation();
		val2.Type = (DirectionType)1;
		val2.Prefix = "burst";
		val2.AnimNames = new string[1];
		val2.Flipped = (FlipType[])(object)new FlipType[1];
		val3.anim = val2;
		list.Add(val3);
		aiAnimator.OtherAnimations = list;
		if ((Object)(object)MolotovBudAnimationCollection == (Object)null)
		{
			MolotovBudAnimationCollection = SpriteBuilder.ConstructCollection(prefab, "MolotovBudCompanion_Collection", false);
			Object.DontDestroyOnLoad((Object)(object)MolotovBudAnimationCollection);
			for (int i = 0; i < spritePaths.Length; i++)
			{
				SpriteBuilder.AddSpriteToCollection(spritePaths[i], MolotovBudAnimationCollection, (Assembly)null);
			}
			SpriteBuilder.AddAnimation(((BraveBehaviour)molotovCompanionBehaviour).spriteAnimator, MolotovBudAnimationCollection, new List<int> { 4, 5, 6, 7 }, "idle_right", (WrapMode)0, 15f).fps = 8f;
			SpriteBuilder.AddAnimation(((BraveBehaviour)molotovCompanionBehaviour).spriteAnimator, MolotovBudAnimationCollection, new List<int> { 0, 1, 2, 3 }, "idle_left", (WrapMode)0, 15f).fps = 8f;
			SpriteBuilder.AddAnimation(((BraveBehaviour)molotovCompanionBehaviour).spriteAnimator, MolotovBudAnimationCollection, new List<int> { 14, 15, 16, 17, 18, 19 }, "move_right", (WrapMode)0, 15f).fps = 8f;
			SpriteBuilder.AddAnimation(((BraveBehaviour)molotovCompanionBehaviour).spriteAnimator, MolotovBudAnimationCollection, new List<int> { 8, 9, 10, 11, 12, 13 }, "move_left", (WrapMode)0, 15f).fps = 8f;
			SpriteBuilder.AddAnimation(((BraveBehaviour)molotovCompanionBehaviour).spriteAnimator, MolotovBudAnimationCollection, new List<int> { 20, 21, 22, 23, 24, 25 }, "burst", (WrapMode)2, 15f).fps = 12f;
		}
	}
}
