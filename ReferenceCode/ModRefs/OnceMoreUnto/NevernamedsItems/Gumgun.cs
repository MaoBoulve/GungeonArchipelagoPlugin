using System.Collections.Generic;
using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Dungeonator;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Gumgun : AdvancedGunBehavior
{
	public class DenksnavelController : CompanionController
	{
		private List<string> possiblePitRemarks = new List<string> { "Keep throwing yourself around like that and I might not save you next time!", "Be more careful! WEH!", "Do you like pits or something, Scallywag?", "You're too heavy for me to keep this up forever!", "Watch your step, Scallywag!", "...WEH!" };

		private PlayerController Owner;

		private RoomHandler lastCheckedRoom;

		private void Start()
		{
			Owner = base.m_owner;
			Owner.OnRoomClearEvent += OnRoomClear;
			Owner.ImmuneToPits.SetOverride("Denksnavel", true, (float?)null);
			Owner.OnPitfall += OnPitfall;
		}

		public override void OnDestroy()
		{
			if (Object.op_Implicit((Object)(object)Owner))
			{
				Owner.OnRoomClearEvent -= OnRoomClear;
				Owner.ImmuneToPits.SetOverride("Denksnavel", false, (float?)null);
				Owner.OnPitfall -= OnPitfall;
			}
			((CompanionController)this).OnDestroy();
		}

		private void OnPitfall()
		{
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			((BraveBehaviour)this).transform.position = ((BraveBehaviour)Owner).transform.position;
			TextBubble.DoAmbientTalk(((BraveBehaviour)this).transform, new Vector3(1f, 2f, 0f), BraveUtility.RandomElement<string>(possiblePitRemarks), 4f);
		}

		private void OnRoomClear(PlayerController owner)
		{
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			TextBubble.DoAmbientTalk(((BraveBehaviour)this).transform, new Vector3(1f, 2f, 0f), "WEH!", 4f);
		}

		private int GetChestType(Chest chest)
		{
			List<PickupObject> list = chest.PredictContents(Owner);
			foreach (PickupObject item in list)
			{
				if (item is Gun)
				{
					return 0;
				}
				if (item is PlayerItem)
				{
					return 2;
				}
				if (item is PassiveItem)
				{
					return 1;
				}
			}
			return Random.Range(0, 3);
		}

		public override void Update()
		{
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0140: Unknown result type (might be due to invalid IL or missing references)
			//IL_022c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0179: Unknown result type (might be due to invalid IL or missing references)
			//IL_0293: Unknown result type (might be due to invalid IL or missing references)
			//IL_0265: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
			RoomHandler absoluteRoomFromPosition = GameManager.Instance.Dungeon.data.GetAbsoluteRoomFromPosition(Vector2Extensions.ToIntVector2(((BraveBehaviour)this).specRigidbody.UnitCenter, (VectorConversions)2));
			if (absoluteRoomFromPosition != null && absoluteRoomFromPosition != lastCheckedRoom)
			{
				Chest[] array = Object.FindObjectsOfType<Chest>();
				List<Chest> list = new List<Chest>();
				Chest[] array2 = array;
				foreach (Chest val in array2)
				{
					if (Vector3Extensions.GetAbsoluteRoom(((BraveBehaviour)val).transform.position) == absoluteRoomFromPosition && !val.IsOpen && !val.IsBroken)
					{
						list.Add(val);
					}
				}
				if (list.Count > 0)
				{
					Chest val2 = BraveUtility.RandomElement<Chest>(list);
					int chestType = GetChestType(val2);
					if (val2.IsRainbowChest)
					{
						TextBubble.DoAmbientTalk(((BraveBehaviour)this).transform, new Vector3(1f, 2f, 0f), "This chest smells like rainbows, lucky you!", 4f);
					}
					else if (list.Count > 1)
					{
						switch (chestType)
						{
						case 0:
							TextBubble.DoAmbientTalk(((BraveBehaviour)this).transform, new Vector3(1f, 2f, 0f), "One of these chests smells like a gun, Scallywag!", 4f);
							break;
						case 1:
							TextBubble.DoAmbientTalk(((BraveBehaviour)this).transform, new Vector3(1f, 2f, 0f), "One of these chests smells like a passive item...", 4f);
							break;
						case 2:
							TextBubble.DoAmbientTalk(((BraveBehaviour)this).transform, new Vector3(1f, 2f, 0f), "One of these chests is definitely an active item!", 4f);
							break;
						}
					}
					else
					{
						switch (chestType)
						{
						case 0:
							TextBubble.DoAmbientTalk(((BraveBehaviour)this).transform, new Vector3(1f, 2f, 0f), "This chest smells like a gun, Scallywag!", 4f);
							break;
						case 1:
							TextBubble.DoAmbientTalk(((BraveBehaviour)this).transform, new Vector3(1f, 2f, 0f), "This chest smells like a passive item...", 4f);
							break;
						case 2:
							TextBubble.DoAmbientTalk(((BraveBehaviour)this).transform, new Vector3(1f, 2f, 0f), "This chest is definitely an active item!", 4f);
							break;
						default:
							TextBubble.DoAmbientTalk(((BraveBehaviour)this).transform, new Vector3(1f, 2f, 0f), "This chest doesn't smell like anything at all...\nwhat did you break?", 4f);
							break;
						}
					}
				}
				lastCheckedRoom = absoluteRoomFromPosition;
			}
			((CompanionController)this).Update();
		}
	}

	public static int GumgunID;

	private GameObject extantCompanion;

	public static GameObject prefab;

	private static readonly string guid = "denksnavel01297129827873486";

	private bool hasSynergyLastWeChecked;

	public static void Add()
	{
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_020e: Unknown result type (might be due to invalid IL or missing references)
		//IL_021e: Unknown result type (might be due to invalid IL or missing references)
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0317: Unknown result type (might be due to invalid IL or missing references)
		//IL_0327: Unknown result type (might be due to invalid IL or missing references)
		//IL_0337: Unknown result type (might be due to invalid IL or missing references)
		//IL_0347: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cb: Expected O, but got Unknown
		//IL_03cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e4: Expected O, but got Unknown
		//IL_0408: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Gumgun", "gumgun");
		Game.Items.Rename("outdated_gun_mods:gumgun", "nn:gumgun");
		((Component)val).gameObject.AddComponent<Gumgun>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Wumderful");
		GunExt.SetLongDescription((PickupObject)(object)val, "Fires globs of gum at your foes.\nHolding down fire causes it to enter 'Gumzooka' mode.\n\nThis tiny handcannon was designed for use by small creatures with no hands.\nCan you still call it a handcannon then?");
		val.SetGunSprites("gumgun");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 15);
		GunExt.SetAnimationFPS(val, val.chargeAnimation, 3);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(13);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		val.gunHandedness = (GunHandedness)3;
		PickupObject byId2 = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.chargeAnimation).wrapMode = (WrapMode)1;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.chargeAnimation).loopStart = 1;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)3;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1.1f;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(334);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		val.gunClass = (GunClass)60;
		val.DefaultModule.cooldownTime = 0.2f;
		val.DefaultModule.numberOfShotsInClip = 25;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(0.56f, 0.31f, 0f);
		val.SetBaseMaxAmmo(300);
		val.ammo = 300;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		RandomiseProjectileColourComponent orAddComponent = GameObjectExtensions.GetOrAddComponent<RandomiseProjectileColourComponent>(((Component)val2).gameObject);
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 1.4f;
		ProjectileBuilders.AnimateProjectileBundle(val2, "GumGunProjectile", Initialisation.ProjectileCollection, Initialisation.projectileAnimationCollection, "GumGunProjectile", new List<IntVector2>
		{
			new IntVector2(13, 10),
			new IntVector2(15, 8),
			new IntVector2(13, 10),
			new IntVector2(11, 12)
		}, MiscTools.DupeList(value: false, 4), MiscTools.DupeList<Anchor>((Anchor)4, 4), MiscTools.DupeList(value: true, 4), MiscTools.DupeList(value: false, 4), MiscTools.DupeList<Vector3?>(null, 4), MiscTools.DupeList<IntVector2?>(null, 4), MiscTools.DupeList<IntVector2?>(null, 4), MiscTools.DupeList<Projectile>(null, 4));
		PickupObject byId4 = PickupObjectDatabase.GetById(56);
		Projectile val3 = Object.Instantiate<Projectile>(((Gun)((byId4 is Gun) ? byId4 : null)).DefaultModule.projectiles[0]);
		((Component)val3).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val3).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val3);
		RandomiseProjectileColourComponent orAddComponent2 = GameObjectExtensions.GetOrAddComponent<RandomiseProjectileColourComponent>(((Component)val3).gameObject);
		ProjectileData baseData2 = val3.baseData;
		baseData2.damage *= 4f;
		ProjectileBuilders.AnimateProjectileBundle(val2, "GumGunBigProjectile", Initialisation.ProjectileCollection, Initialisation.projectileAnimationCollection, "GumGunBigProjectile", new List<IntVector2>
		{
			new IntVector2(21, 14),
			new IntVector2(23, 12),
			new IntVector2(21, 14),
			new IntVector2(19, 16)
		}, MiscTools.DupeList(value: false, 4), MiscTools.DupeList<Anchor>((Anchor)4, 4), MiscTools.DupeList(value: true, 4), MiscTools.DupeList(value: false, 4), MiscTools.DupeList<Vector3?>(null, 4), MiscTools.DupeList<IntVector2?>(null, 4), MiscTools.DupeList<IntVector2?>(null, 4), MiscTools.DupeList<Projectile>(null, 4));
		ChargeProjectile item = new ChargeProjectile
		{
			Projectile = val2,
			ChargeTime = 0f,
			VfxPool = null
		};
		ChargeProjectile item2 = new ChargeProjectile
		{
			Projectile = val3,
			ChargeTime = 1f
		};
		val.DefaultModule.chargeProjectiles = new List<ChargeProjectile> { item, item2 };
		((PickupObject)val).quality = (ItemQuality)2;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		GumgunID = ((PickupObject)val).PickupObjectId;
		BuildDenkSnavelPrefab();
	}

	protected override void Update()
	{
		if (Object.op_Implicit((Object)(object)base.gun.CurrentOwner) && base.gun.CurrentOwner is PlayerController)
		{
			GameActor currentOwner = base.gun.CurrentOwner;
			PlayerController val = (PlayerController)(object)((currentOwner is PlayerController) ? currentOwner : null);
			if (CustomSynergies.PlayerHasActiveSynergy(val, "WEH") != hasSynergyLastWeChecked)
			{
				if (((PickupObject)((GameActor)val).CurrentGun).PickupObjectId == GumgunID && CustomSynergies.PlayerHasActiveSynergy(val, "WEH"))
				{
					SpawnNewCompanion(guid);
				}
				if (!CustomSynergies.PlayerHasActiveSynergy(val, "WEH") && Object.op_Implicit((Object)(object)extantCompanion))
				{
					Object.Destroy((Object)(object)extantCompanion);
				}
				hasSynergyLastWeChecked = CustomSynergies.PlayerHasActiveSynergy(val, "WEH");
			}
		}
		((AdvancedGunBehavior)this).Update();
	}

	public override void OnSwitchedToThisGun()
	{
		if (Object.op_Implicit((Object)(object)base.gun.CurrentOwner) && base.gun.CurrentOwner is PlayerController && CustomSynergies.PlayerHasActiveSynergy((PlayerController)/*isinst with value type is only supported in some contexts*/, "WEH"))
		{
			SpawnNewCompanion(guid);
		}
		((AdvancedGunBehavior)this).OnSwitchedToThisGun();
	}

	public override void OnSwitchedAwayFromThisGun()
	{
		if (Object.op_Implicit((Object)(object)extantCompanion))
		{
			Object.Destroy((Object)(object)extantCompanion.gameObject);
		}
		((AdvancedGunBehavior)this).OnSwitchedAwayFromThisGun();
	}

	protected override void OnPickedUpByPlayer(PlayerController player)
	{
		if (CustomSynergies.PlayerHasActiveSynergy(player, "WEH"))
		{
			SpawnNewCompanion(guid);
		}
		((AdvancedGunBehavior)this).OnPickedUpByPlayer(player);
	}

	public override void OnDropped()
	{
		if (Object.op_Implicit((Object)(object)extantCompanion))
		{
			Object.Destroy((Object)(object)extantCompanion.gameObject);
		}
		((AdvancedGunBehavior)this).OnDropped();
	}

	protected override void OnPostDroppedByPlayer(PlayerController player)
	{
		if (Object.op_Implicit((Object)(object)extantCompanion))
		{
			Object.Destroy((Object)(object)extantCompanion.gameObject);
		}
		((AdvancedGunBehavior)this).OnPostDroppedByPlayer(player);
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)extantCompanion))
		{
			Object.Destroy((Object)(object)extantCompanion.gameObject);
		}
		((BraveBehaviour)this).OnDestroy();
	}

	private void SpawnNewCompanion(string guid)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Invalid comparison between Unknown and I4
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		AIActor orLoadByGuid = EnemyDatabase.GetOrLoadByGuid(guid);
		Vector3 val = ((BraveBehaviour)((AdvancedGunBehavior)this).Owner).transform.position;
		if ((int)GameManager.Instance.CurrentLevelOverrideState == 1)
		{
			val += new Vector3(1.125f, -0.3125f, 0f);
		}
		GameObject val2 = Object.Instantiate<GameObject>(((Component)orLoadByGuid).gameObject, val, Quaternion.identity);
		CompanionController orAddComponent = GameObjectExtensions.GetOrAddComponent<CompanionController>(val2);
		extantCompanion = val2;
		_003F val3 = orAddComponent;
		GameActor currentOwner = base.gun.CurrentOwner;
		((CompanionController)val3).Initialize((PlayerController)(object)((currentOwner is PlayerController) ? currentOwner : null));
		if (Object.op_Implicit((Object)(object)((BraveBehaviour)orAddComponent).specRigidbody))
		{
			PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(((BraveBehaviour)orAddComponent).specRigidbody, (int?)null, false);
		}
	}

	public static void BuildDenkSnavelPrefab()
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Expected O, but got Unknown
		if ((Object)(object)prefab == (Object)null || !CompanionBuilder.companionDictionary.ContainsKey(guid))
		{
			prefab = CompanionBuilder.BuildPrefab("Gumgun Denksnavel", guid, "NevernamedsItems/Resources/Companions/Denksnavel/denksnavel_idle_left_001", new IntVector2(5, 0), new IntVector2(5, 13));
			DenksnavelController denksnavelController = prefab.AddComponent<DenksnavelController>();
			((BraveBehaviour)denksnavelController).aiActor.MovementSpeed = 6.5f;
			((CompanionController)denksnavelController).CanCrossPits = true;
			((GameActor)((BraveBehaviour)denksnavelController).aiActor).ActorShadowOffset = new Vector3(0f, -0.5f);
			CompanionBuilder.AddAnimation(prefab, "idle_right", "NevernamedsItems/Resources/Companions/Denksnavel/denksnavel_idle_right", 12, (AnimationType)1, (DirectionType)2, (FlipType)0);
			CompanionBuilder.AddAnimation(prefab, "idle_left", "NevernamedsItems/Resources/Companions/Denksnavel/denksnavel_idle_left", 12, (AnimationType)1, (DirectionType)2, (FlipType)0);
			((BraveBehaviour)denksnavelController).aiAnimator.GetDirectionalAnimation("idle").Prefix = "idle";
			BehaviorSpeculator component = prefab.GetComponent<BehaviorSpeculator>();
			CustomCompanionBehaviours.SimpleCompanionMeleeAttack simpleCompanionMeleeAttack = new CustomCompanionBehaviours.SimpleCompanionMeleeAttack();
			simpleCompanionMeleeAttack.DamagePerTick = 5f;
			simpleCompanionMeleeAttack.DesiredDistance = 2f;
			simpleCompanionMeleeAttack.TickDelay = 1f;
			CustomCompanionBehaviours.SimpleCompanionApproach simpleCompanionApproach = new CustomCompanionBehaviours.SimpleCompanionApproach();
			simpleCompanionApproach.DesiredDistance = 1f;
			component.MovementBehaviors.Add((MovementBehaviorBase)(object)simpleCompanionApproach);
			component.AttackBehaviors.Add((AttackBehaviorBase)(object)simpleCompanionMeleeAttack);
			List<MovementBehaviorBase> movementBehaviors = component.MovementBehaviors;
			CompanionFollowPlayerBehavior val = new CompanionFollowPlayerBehavior();
			val.IdleAnimations = new string[1] { "idle" };
			movementBehaviors.Add((MovementBehaviorBase)(object)val);
		}
	}
}
