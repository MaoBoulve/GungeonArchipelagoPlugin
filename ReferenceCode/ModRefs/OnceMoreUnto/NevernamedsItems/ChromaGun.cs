using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class ChromaGun : AdvancedGunBehavior
{
	public enum ColourType
	{
		NONE,
		RED,
		YELLOW,
		BLUE,
		PURPLE,
		GREEN,
		ORANGE,
		BLACK
	}

	public class ChromaGunBulletBehav : MonoBehaviour
	{
		private Projectile self;

		public ColourType ColourType;

		public ChromaGunBulletBehav()
		{
			ColourType = ColourType.NONE;
		}

		private void Start()
		{
			self = ((Component)this).GetComponent<Projectile>();
			if ((Object)(object)self.PossibleSourceGun == (Object)null || ((Object)(object)self.PossibleSourceGun != (Object)null && ((PickupObject)self.PossibleSourceGun).PickupObjectId != ChromaGunId))
			{
				ColourType = BraveUtility.RandomElement<ColourType>(RandomBaseColours);
			}
			Projectile obj = self;
			obj.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(obj.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(OnHitEnemy));
			if (ColourType != 0)
			{
				ChangeColour();
			}
		}

		public void ChangeColour()
		{
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			self.AdjustPlayerProjectileTint(actualColours[ColourType], 1, 0f);
		}

		private void OnHitEnemy(Projectile self, SpeculativeRigidbody enemy, bool fatal)
		{
			if (Object.op_Implicit((Object)(object)self) && (Object)(object)enemy != (Object)null && (Object)(object)((BraveBehaviour)enemy).aiActor != (Object)null && (Object)(object)((BraveBehaviour)enemy).healthHaver != (Object)null && (Object)(object)((Component)enemy).gameObject != (Object)null && !fatal)
			{
				ChromaGunColoured orAddComponent = GameObjectExtensions.GetOrAddComponent<ChromaGunColoured>(((Component)enemy).gameObject);
				orAddComponent.AddColour(ColourType);
			}
		}
	}

	public class ChromaGunColoured : MonoBehaviour
	{
		private AIActor self;

		public ColourType ColourType;

		public ChromaGunColoured()
		{
			ColourType = ColourType.NONE;
		}

		private void Start()
		{
			self = ((Component)this).GetComponent<AIActor>();
		}

		public void AddColour(ColourType colour)
		{
			//IL_011d: Unknown result type (might be due to invalid IL or missing references)
			if (colour == ColourType || colour == ColourType.NONE || ColourType == ColourType.BLACK)
			{
				return;
			}
			ColourType colourType = ColourType.NONE;
			if (ColourType != 0)
			{
				switch (colour)
				{
				case ColourType.RED:
					colourType = ((ColourType != ColourType.YELLOW) ? ((ColourType != ColourType.BLUE) ? ColourType.BLACK : ColourType.PURPLE) : ColourType.ORANGE);
					break;
				case ColourType.YELLOW:
					colourType = ((ColourType != ColourType.RED) ? ((ColourType != ColourType.BLUE) ? ColourType.BLACK : ColourType.GREEN) : ColourType.ORANGE);
					break;
				case ColourType.BLUE:
					colourType = ((ColourType != ColourType.YELLOW) ? ((ColourType != ColourType.RED) ? ColourType.BLACK : ColourType.PURPLE) : ColourType.GREEN);
					break;
				}
			}
			else
			{
				colourType = colour;
			}
			if (ColourType != 0)
			{
				((GameActor)self).DeregisterOverrideColor("ChromaGunTint");
			}
			((BraveBehaviour)self).gameActor.RegisterOverrideColor(actualColours[colourType], "ChromaGunTint");
			ColourType = colourType;
		}
	}

	[CompilerGenerated]
	private sealed class _003CLateUpdateProjColour_003Ed__13 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ChromaGunBulletBehav behav;

		public ChromaGun _003C_003E4__this;

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
		public _003CLateUpdateProjColour_003Ed__13(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				behav.ColourType = _003C_003E4__this.CurrentColourFiringMode;
				behav.ChangeColour();
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

	private ColourType CurrentColourFiringMode = ColourType.RED;

	public static int ChromaGunId;

	public static GameObject redDroidPrefab;

	public static GameObject yellowDroidPrefab;

	public static GameObject blueDroidPrefab;

	private GameObject extantRedDroid;

	private GameObject extantYellowDroid;

	private GameObject extantBlueDroid;

	private static readonly string RedDroidGuid = "tom93279832647466348743748";

	private static readonly string YellowDroidGuid = "dick0001191029210190129109";

	private static readonly string BlueDroidGuid = "harry152347362562232323532";

	private float recalcTimer;

	public static List<ColourType> RandomBaseColours = new List<ColourType>
	{
		ColourType.RED,
		ColourType.YELLOW,
		ColourType.BLUE
	};

	public static Dictionary<ColourType, Color> actualColours = new Dictionary<ColourType, Color>
	{
		{
			ColourType.RED,
			Color.red
		},
		{
			ColourType.YELLOW,
			ExtendedColours.honeyYellow
		},
		{
			ColourType.BLUE,
			Color.blue
		},
		{
			ColourType.PURPLE,
			ExtendedColours.purple
		},
		{
			ColourType.GREEN,
			Color.green
		},
		{
			ColourType.ORANGE,
			ExtendedColours.vibrantOrange
		},
		{
			ColourType.BLACK,
			ExtendedColours.darkBrown
		}
	};

	public static void Add()
	{
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("ChromaGun", "chromagun");
		Game.Items.Rename("outdated_gun_mods:chromagun", "nn:chromagun");
		((Component)val).gameObject.AddComponent<ChromaGun>();
		GunExt.SetShortDescription((PickupObject)(object)val, "");
		GunExt.SetLongDescription((PickupObject)(object)val, "");
		GunExt.SetupSprite(val, (tk2dSpriteCollectionData)null, "chromagun_idle_001", 8);
		GunExt.SetAnimationFPS(val, val.shootAnimation, 15);
		PickupObject byId = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 0.85f;
		val.DefaultModule.cooldownTime = 0.4f;
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		val.DefaultModule.numberOfShotsInClip = 5;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.25f, 0.62f, 0f);
		val.SetBaseMaxAmmo(150);
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		val2.baseData.damage = 7f;
		ProjectileData baseData = val2.baseData;
		baseData.speed *= 3f;
		((Component)val2).gameObject.AddComponent<ChromaGunBulletBehav>();
		((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		((PickupObject)val).quality = (ItemQuality)(-100);
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		ChromaGunId = ((PickupObject)val).PickupObjectId;
		val.gunClass = (GunClass)50;
		SetupChromaDroids();
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		if (Object.op_Implicit((Object)(object)((Component)projectile).GetComponent<ChromaGunBulletBehav>()))
		{
			ChromaGunBulletBehav component = ((Component)projectile).GetComponent<ChromaGunBulletBehav>();
			((MonoBehaviour)this).StartCoroutine(LateUpdateProjColour(component));
		}
		((AdvancedGunBehavior)this).PostProcessProjectile(projectile);
	}

	private IEnumerator LateUpdateProjColour(ChromaGunBulletBehav behav)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CLateUpdateProjColour_003Ed__13(0)
		{
			_003C_003E4__this = this,
			behav = behav
		};
	}

	public override void OnReloadPressed(PlayerController player, Gun gun, bool manualReload)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		if (CurrentColourFiringMode == ColourType.RED)
		{
			CurrentColourFiringMode = ColourType.YELLOW;
			VFXToolbox.DoStringSquirt("YELLOW", ((BraveBehaviour)gun).sprite.WorldCenter, ExtendedColours.honeyYellow);
		}
		else if (CurrentColourFiringMode == ColourType.YELLOW)
		{
			CurrentColourFiringMode = ColourType.BLUE;
			VFXToolbox.DoStringSquirt("BLUE", ((BraveBehaviour)gun).sprite.WorldCenter, Color.blue);
		}
		else if (CurrentColourFiringMode == ColourType.BLUE)
		{
			CurrentColourFiringMode = ColourType.RED;
			VFXToolbox.DoStringSquirt("RED", ((BraveBehaviour)gun).sprite.WorldCenter, Color.red);
		}
		((AdvancedGunBehavior)this).OnReloadPressed(player, gun, manualReload);
	}

	public override void OnSwitchedToThisGun()
	{
		RecalculateDrones();
		((AdvancedGunBehavior)this).OnSwitchedToThisGun();
	}

	public override void OnSwitchedAwayFromThisGun()
	{
		RecalculateDrones();
		((AdvancedGunBehavior)this).OnSwitchedAwayFromThisGun();
	}

	private GameObject SpawnNewCompanion(string guid)
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
		_003F val3 = orAddComponent;
		GameActor currentOwner = base.gun.CurrentOwner;
		((CompanionController)val3).Initialize((PlayerController)(object)((currentOwner is PlayerController) ? currentOwner : null));
		if (Object.op_Implicit((Object)(object)((BraveBehaviour)orAddComponent).specRigidbody))
		{
			PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(((BraveBehaviour)orAddComponent).specRigidbody, (int?)null, false);
		}
		return val2;
	}

	private void RecalculateDrones()
	{
		if ((Object)(object)extantRedDroid != (Object)null && !GunTools.IsCurrentGun(base.gun))
		{
			Object.Destroy((Object)(object)extantRedDroid);
			extantRedDroid = null;
		}
		else if ((Object)(object)extantRedDroid == (Object)null && GunTools.IsCurrentGun(base.gun))
		{
			extantRedDroid = SpawnNewCompanion(RedDroidGuid);
		}
		if ((Object)(object)extantYellowDroid != (Object)null && !GunTools.IsCurrentGun(base.gun))
		{
			Object.Destroy((Object)(object)extantYellowDroid);
			extantYellowDroid = null;
		}
		else if ((Object)(object)extantYellowDroid == (Object)null && !GunTools.IsCurrentGun(base.gun))
		{
		}
		if ((Object)(object)extantBlueDroid != (Object)null && !GunTools.IsCurrentGun(base.gun))
		{
			Object.Destroy((Object)(object)extantBlueDroid);
			extantBlueDroid = null;
		}
		else if ((Object)(object)extantBlueDroid == (Object)null && !GunTools.IsCurrentGun(base.gun))
		{
		}
	}

	protected override void Update()
	{
		if (Object.op_Implicit((Object)(object)((AdvancedGunBehavior)this).Owner))
		{
			if (recalcTimer > 0f)
			{
				recalcTimer -= BraveTime.DeltaTime;
			}
			else if (recalcTimer <= 0f)
			{
				recalcTimer = 1f;
			}
		}
		((AdvancedGunBehavior)this).Update();
	}

	protected override void OnPickedUpByPlayer(PlayerController player)
	{
		recalcTimer = 1f;
		((AdvancedGunBehavior)this).OnPickedUpByPlayer(player);
	}

	public static void SetupChromaDroids()
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Expected O, but got Unknown
		if ((Object)(object)redDroidPrefab == (Object)null || !CompanionBuilder.companionDictionary.ContainsKey(RedDroidGuid))
		{
			redDroidPrefab = CompanionBuilder.BuildPrefab("ChromaGun Red Droid", RedDroidGuid, "NevernamedsItems/Resources/Companions/ChromaGunDroids/chromadroid_red_idle_001", new IntVector2(5, 1), new IntVector2(6, 6));
			CompanionController val = redDroidPrefab.AddComponent<CompanionController>();
			((BraveBehaviour)val).aiActor.MovementSpeed = 6.5f;
			val.CanCrossPits = true;
			((BraveBehaviour)val).aiActor.CollisionDamage = 0f;
			((GameActor)((BraveBehaviour)val).aiActor).ActorShadowOffset = new Vector3(0f, -0.5f);
			CompanionBuilder.AddAnimation(redDroidPrefab, "idle", "NevernamedsItems/Resources/Companions/ChromaGunDroids/chromadroid_red_idle", 12, (AnimationType)1, (DirectionType)0, (FlipType)0);
			BehaviorSpeculator component = redDroidPrefab.GetComponent<BehaviorSpeculator>();
			CustomCompanionBehaviours.SimpleCompanionMeleeAttack simpleCompanionMeleeAttack = new CustomCompanionBehaviours.SimpleCompanionMeleeAttack();
			simpleCompanionMeleeAttack.DamagePerTick = 5f;
			simpleCompanionMeleeAttack.DesiredDistance = 2f;
			simpleCompanionMeleeAttack.TickDelay = 1f;
			simpleCompanionMeleeAttack.selfKnockbackAmount = 10f;
			simpleCompanionMeleeAttack.targetKnockbackAmount = 10f;
			CustomCompanionBehaviours.ChromaGunDroneApproach chromaGunDroneApproach = new CustomCompanionBehaviours.ChromaGunDroneApproach();
			chromaGunDroneApproach.DesiredDistance = 1f;
			chromaGunDroneApproach.droneColour = ColourType.RED;
			component.MovementBehaviors.Add((MovementBehaviorBase)(object)chromaGunDroneApproach);
			component.AttackBehaviors.Add((AttackBehaviorBase)(object)simpleCompanionMeleeAttack);
			List<MovementBehaviorBase> movementBehaviors = component.MovementBehaviors;
			CompanionFollowPlayerBehavior val2 = new CompanionFollowPlayerBehavior();
			val2.IdleAnimations = new string[1] { "idle" };
			movementBehaviors.Add((MovementBehaviorBase)(object)val2);
		}
	}
}
