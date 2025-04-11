using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Dungeonator;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class RainbowGuonStone : AdvancedPlayerOrbitalItem
{
	public enum GuonState
	{
		RED,
		ORANGE,
		YELLOW,
		GREEN,
		BLUE,
		WHITE,
		CLEAR,
		CYAN,
		GOLD,
		GREY,
		BROWN,
		INDIGO
	}

	[CompilerGenerated]
	private sealed class _003CHandleMachoDamageBoost_003Ed__48 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerController target;

		public RainbowGuonStone _003C_003E4__this;

		private float _003Celapsed_003E5__1;

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
		public _003CHandleMachoDamageBoost_003Ed__48(int _003C_003E1__state)
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
				_003C_003E4__this.EnableMachoVFX(target);
				_003C_003E4__this.m_destroyVFXSemaphore++;
				if (_003C_003E4__this.m_destroyVFXSemaphore == 1)
				{
					AkSoundEngine.PostEvent("Play_ITM_Macho_Brace_Active_01", ((Component)_003C_003E4__this).gameObject);
				}
				_003C_003E4__this.m_hasUsedShot = false;
				goto IL_00ac;
			case 1:
				_003C_003E1__state = -1;
				goto IL_00ac;
			case 2:
				{
					_003C_003E1__state = -1;
					break;
				}
				IL_00ac:
				if (target.IsDodgeRolling)
				{
					_003C_003E2__current = null;
					_003C_003E1__state = 1;
					return true;
				}
				_003C_003E4__this.m_beamTickElapsed = 0f;
				_003Celapsed_003E5__1 = 0f;
				target.ownerlessStatModifiers.Add(_003C_003E4__this.machoDamageMod);
				target.stats.RecalculateStats(target, false, false);
				break;
			}
			if (_003Celapsed_003E5__1 < 1.5f && !_003C_003E4__this.m_hasUsedShot)
			{
				_003Celapsed_003E5__1 += BraveTime.DeltaTime;
				_003C_003E2__current = null;
				_003C_003E1__state = 2;
				return true;
			}
			target.ownerlessStatModifiers.Remove(_003C_003E4__this.machoDamageMod);
			if (_003C_003E4__this.m_destroyVFXSemaphore == 1)
			{
				AkSoundEngine.PostEvent("Play_ITM_Macho_Brace_Fade_01", ((Component)_003C_003E4__this).gameObject);
			}
			target.stats.RecalculateStats(target, false, false);
			_003C_003E4__this.m_destroyVFXSemaphore--;
			if (_003C_003E4__this.m_hasUsedShot)
			{
				_003C_003E4__this.m_destroyVFXSemaphore = 0;
			}
			_003C_003E4__this.DisableMachoVFX(target);
			return false;
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

	[CompilerGenerated]
	private sealed class _003CHandleShield_003Ed__44 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerController user;

		public float duration;

		public RainbowGuonStone _003C_003E4__this;

		private SpeculativeRigidbody _003CspecRigidbody_003E5__1;

		private float _003Celapsed_003E5__2;

		private SpeculativeRigidbody _003CspecRigidbody2_003E5__3;

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
		public _003CHandleShield_003Ed__44(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003CspecRigidbody_003E5__1 = null;
			_003CspecRigidbody2_003E5__3 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00af: Expected O, but got Unknown
			//IL_00af: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b9: Expected O, but got Unknown
			//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ac: Expected O, but got Unknown
			//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b6: Expected O, but got Unknown
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E4__this.m_activeDuration = duration;
				_003C_003E4__this.m_usedOverrideMaterial = ((BraveBehaviour)user).sprite.usesOverrideMaterial;
				((BraveBehaviour)user).sprite.usesOverrideMaterial = true;
				user.SetOverrideShader(ShaderCache.Acquire("Brave/ItemSpecific/MetalSkinShader"));
				_003CspecRigidbody_003E5__1 = ((BraveBehaviour)user).specRigidbody;
				_003CspecRigidbody_003E5__1.OnPreRigidbodyCollision = (OnPreRigidbodyCollisionDelegate)Delegate.Combine((Delegate)(object)_003CspecRigidbody_003E5__1.OnPreRigidbodyCollision, (Delegate)new OnPreRigidbodyCollisionDelegate(_003C_003E4__this.OnPreCollision));
				((BraveBehaviour)user).healthHaver.IsVulnerable = false;
				_003Celapsed_003E5__2 = 0f;
				break;
			case 1:
				_003C_003E1__state = -1;
				break;
			}
			if (_003Celapsed_003E5__2 < duration)
			{
				_003Celapsed_003E5__2 += BraveTime.DeltaTime;
				((BraveBehaviour)user).healthHaver.IsVulnerable = false;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			if (Object.op_Implicit((Object)(object)user))
			{
				((BraveBehaviour)user).healthHaver.IsVulnerable = true;
				user.ClearOverrideShader();
				((BraveBehaviour)user).sprite.usesOverrideMaterial = _003C_003E4__this.m_usedOverrideMaterial;
				_003CspecRigidbody2_003E5__3 = ((BraveBehaviour)user).specRigidbody;
				_003CspecRigidbody2_003E5__3.OnPreRigidbodyCollision = (OnPreRigidbodyCollisionDelegate)Delegate.Remove((Delegate)(object)_003CspecRigidbody2_003E5__3.OnPreRigidbodyCollision, (Delegate)new OnPreRigidbodyCollisionDelegate(_003C_003E4__this.OnPreCollision));
				_003CspecRigidbody2_003E5__3 = null;
			}
			if (Object.op_Implicit((Object)(object)_003C_003E4__this))
			{
				AkSoundEngine.PostEvent("Play_OBJ_metalskin_end_01", ((Component)_003C_003E4__this).gameObject);
			}
			return false;
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

	[CompilerGenerated]
	private sealed class _003CHandleSlowBullets_003Ed__46 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public RainbowGuonStone _003C_003E4__this;

		private float _003CslowMultiplier_003E5__1;

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
		public _003CHandleSlowBullets_003Ed__46(int _003C_003E1__state)
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
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0039: Expected O, but got Unknown
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = (object)new WaitForEndOfFrame();
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				_003CslowMultiplier_003E5__1 = ((Component)PickupObjectDatabase.GetById(270)).GetComponent<IounStoneOrbitalItem>().SlowBulletsMultiplier;
				Projectile.BaseEnemyBulletSpeedMultiplier *= _003CslowMultiplier_003E5__1;
				_003C_003E4__this.m_slowDurationRemaining = ((Component)PickupObjectDatabase.GetById(270)).GetComponent<IounStoneOrbitalItem>().SlowBulletsDuration;
				break;
			case 2:
				_003C_003E1__state = -1;
				_003C_003E4__this.m_slowDurationRemaining -= BraveTime.DeltaTime;
				Projectile.BaseEnemyBulletSpeedMultiplier /= _003CslowMultiplier_003E5__1;
				_003CslowMultiplier_003E5__1 = Mathf.Lerp(((Component)PickupObjectDatabase.GetById(270)).GetComponent<IounStoneOrbitalItem>().SlowBulletsMultiplier, 1f, 1f - _003C_003E4__this.m_slowDurationRemaining);
				Projectile.BaseEnemyBulletSpeedMultiplier *= _003CslowMultiplier_003E5__1;
				break;
			}
			if (_003C_003E4__this.m_slowDurationRemaining > 0f)
			{
				_003C_003E2__current = null;
				_003C_003E1__state = 2;
				return true;
			}
			Projectile.BaseEnemyBulletSpeedMultiplier /= _003CslowMultiplier_003E5__1;
			return false;
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

	public static PlayerOrbital orbitalPrefab;

	public static PlayerOrbital upgradeOrbitalPrefab;

	public static Projectile mockOrangeGuonProj;

	private bool canFireCyanProjectile = true;

	private bool canDoGreyCollisionDMG = true;

	private bool canFireOrangeProjectile = true;

	private bool canReselectGuonState = true;

	private bool canDoBlueSynergyRoomDMG = true;

	private GuonState RandomlySelectedGuonState;

	private float overrideOrbitalDistance = 2.5f;

	private float overrideOrbitalSpeed = 120f;

	private float overridePerfectOrbitalFactor = 0f;

	private DamageTypeModifier m_poisonImmunity;

	private DamageTypeModifier m_fireImmunity;

	private DamageTypeModifier m_electricityImmunity;

	public Dictionary<GuonState, GameObject> GuonTransitionVFX = new Dictionary<GuonState, GameObject>
	{
		{
			GuonState.RED,
			SharedVFX.ColouredPoofRed
		},
		{
			GuonState.ORANGE,
			SharedVFX.ColouredPoofOrange
		},
		{
			GuonState.YELLOW,
			SharedVFX.ColouredPoofYellow
		},
		{
			GuonState.GREEN,
			SharedVFX.ColouredPoofGreen
		},
		{
			GuonState.BLUE,
			SharedVFX.ColouredPoofBlue
		},
		{
			GuonState.WHITE,
			SharedVFX.ColouredPoofWhite
		},
		{
			GuonState.CYAN,
			SharedVFX.ColouredPoofCyan
		},
		{
			GuonState.GOLD,
			SharedVFX.ColouredPoofGold
		},
		{
			GuonState.GREY,
			SharedVFX.ColouredPoofGrey
		},
		{
			GuonState.INDIGO,
			SharedVFX.ColouredPoofIndigo
		},
		{
			GuonState.BROWN,
			SharedVFX.ColouredPoofBrown
		}
	};

	private float m_activeDuration = 1f;

	private bool m_usedOverrideMaterial;

	private float m_slowDurationRemaining;

	private int m_destroyVFXSemaphore;

	private bool m_hasUsedShot;

	private float m_beamTickElapsed;

	private GameObject m_instanceVFX;

	private StatModifier machoDamageMod;

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<RainbowGuonStone>("Rainbow Guon Stone", "Insanity Stone", "Proof of Alben Smallbore's theory of magical unpredictability.\n\nThis guon stone has been stuffed with so much magic that it erratically shifts it's effects like a child unable to sit still.", "rainbowguon_icon3", assetbundle: true);
		AdvancedPlayerOrbitalItem val = (AdvancedPlayerOrbitalItem)(object)((obj is AdvancedPlayerOrbitalItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)2;
		BuildPrefab();
		val.OrbitalPrefab = orbitalPrefab;
		BuildSynergyPrefab();
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)2, 1f);
		AlexandriaTags.SetTag((PickupObject)(object)val, "guon_stone");
		val.HasAdvancedUpgradeSynergy = true;
		val.AdvancedUpgradeSynergy = "Rainbower Guon Stone";
		val.AdvancedUpgradeOrbitalPrefab = ((Component)upgradeOrbitalPrefab).gameObject;
		PickupObject byId = PickupObjectDatabase.GetById(86);
		Projectile val2 = Object.Instantiate<Projectile>(((Gun)((byId is Gun) ? byId : null)).DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val2.SetProjectileSprite("mockorangeguon_proj", 4, 4, lightened: true, (Anchor)4, 4, 4, anchorChangesCollider: true, fixesScale: false, null, null);
		mockOrangeGuonProj = val2;
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.RAINBOW_KILLED_LICH, requiredFlagValue: true);
	}

	public static void BuildPrefab()
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		if (!((Object)(object)orbitalPrefab != (Object)null))
		{
			GameObject val = ItemBuilder.SpriteFromBundle("RainbowGuonOrbital", Initialisation.itemCollection.GetSpriteIdByName("rainbowguon_ingame"), Initialisation.itemCollection, (GameObject)null);
			((Object)val).name = "Rainbow Guon Orbital";
			SpeculativeRigidbody val2 = SpriteBuilder.SetUpSpeculativeRigidbody(val.GetComponent<tk2dSprite>(), IntVector2.Zero, new IntVector2(5, 9));
			GunTools.ConstructOffsetsFromAnchor(((tk2dBaseSprite)val.GetComponent<tk2dSprite>()).GetCurrentSpriteDef(), (Anchor)4, (Vector2?)Vector2.op_Implicit(((tk2dBaseSprite)((Component)val2).GetComponent<tk2dSprite>()).GetCurrentSpriteDef().position3), false, true);
			val2.CollideWithTileMap = false;
			val2.CollideWithOthers = true;
			val2.PrimaryPixelCollider.CollisionLayer = (CollisionLayer)15;
			orbitalPrefab = val.AddComponent<PlayerOrbital>();
			orbitalPrefab.motionStyle = (OrbitalMotionStyle)0;
			orbitalPrefab.shouldRotate = false;
			orbitalPrefab.orbitRadius = 2.5f;
			orbitalPrefab.orbitDegreesPerSecond = 120f;
			orbitalPrefab.SetOrbitalTier(0);
			Object.DontDestroyOnLoad((Object)(object)val);
			FakePrefab.MarkAsFakePrefab(val);
			val.SetActive(false);
		}
	}

	public static void BuildSynergyPrefab()
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)upgradeOrbitalPrefab == (Object)null)
		{
			GameObject val = ItemBuilder.SpriteFromBundle("RainbowGuonOrbitalSynergy", Initialisation.itemCollection.GetSpriteIdByName("rainbowguon_synergy"), Initialisation.itemCollection, (GameObject)null);
			((Object)val).name = "Rainbow Guon Orbital Synergy Form";
			SpeculativeRigidbody val2 = SpriteBuilder.SetUpSpeculativeRigidbody(val.GetComponent<tk2dSprite>(), IntVector2.Zero, new IntVector2(9, 14));
			GunTools.ConstructOffsetsFromAnchor(((tk2dBaseSprite)val.GetComponent<tk2dSprite>()).GetCurrentSpriteDef(), (Anchor)4, (Vector2?)Vector2.op_Implicit(((tk2dBaseSprite)val.GetComponent<tk2dSprite>()).GetCurrentSpriteDef().position3), false, true);
			upgradeOrbitalPrefab = val.AddComponent<PlayerOrbital>();
			val2.CollideWithTileMap = false;
			val2.CollideWithOthers = true;
			val2.PrimaryPixelCollider.CollisionLayer = (CollisionLayer)15;
			upgradeOrbitalPrefab.shouldRotate = false;
			upgradeOrbitalPrefab.orbitRadius = 2.5f;
			upgradeOrbitalPrefab.perfectOrbitalFactor = 10f;
			upgradeOrbitalPrefab.orbitDegreesPerSecond = 120f;
			upgradeOrbitalPrefab.SetOrbitalTier(0);
			Object.DontDestroyOnLoad((Object)(object)val);
			FakePrefab.MarkAsFakePrefab(val);
			val.SetActive(false);
		}
	}

	private void FireProjectileFromGuon(GameObject projectile, bool scaleStats, bool postProcess, float specialDamageScaling = 1f, float angleFromAim = 0f, float angleVariance = 0f, bool playerStatScalesAccuracy = false)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = ProjectileUtility.InstantiateAndFireTowardsPosition(projectile.GetComponent<Projectile>(), ((tk2dBaseSprite)base.m_extantOrbital.GetComponent<tk2dSprite>()).WorldCenter, MathsAndLogicHelper.GetPositionOfNearestEnemy(((tk2dBaseSprite)base.m_extantOrbital.GetComponent<tk2dSprite>()).WorldCenter, (ActorCenter)2, true, (ActiveEnemyType)1, (List<AIActor>)null, (Func<AIActor, bool>)null), angleVariance, angleVariance, playerStatScalesAccuracy ? ((PassiveItem)this).Owner : null);
		Projectile component = val.GetComponent<Projectile>();
		if ((Object)(object)component != (Object)null)
		{
			component.Owner = (GameActor)(object)((PassiveItem)this).Owner;
			component.Shooter = ((BraveBehaviour)((PassiveItem)this).Owner).specRigidbody;
			ProjectileData baseData = component.baseData;
			baseData.damage *= specialDamageScaling;
			if (scaleStats)
			{
				component.TreatedAsNonProjectileForChallenge = true;
				ProjectileData baseData2 = component.baseData;
				baseData2.damage *= ((PassiveItem)this).Owner.stats.GetStatValue((StatType)5);
				ProjectileData baseData3 = component.baseData;
				baseData3.speed *= ((PassiveItem)this).Owner.stats.GetStatValue((StatType)6);
				ProjectileData baseData4 = component.baseData;
				baseData4.force *= ((PassiveItem)this).Owner.stats.GetStatValue((StatType)12);
				component.AdditionalScaleMultiplier *= ((PassiveItem)this).Owner.stats.GetStatValue((StatType)15);
				component.UpdateSpeed();
			}
			if (postProcess)
			{
				((PassiveItem)this).Owner.DoPostProcessProjectile(component);
			}
		}
	}

	public override void Update()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Expected O, but got Unknown
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Expected O, but got Unknown
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a5: Unknown result type (might be due to invalid IL or missing references)
		if (m_poisonImmunity == null)
		{
			m_poisonImmunity = new DamageTypeModifier();
			m_poisonImmunity.damageMultiplier = 0f;
			m_poisonImmunity.damageType = (CoreDamageTypes)16;
		}
		if (m_fireImmunity == null)
		{
			m_fireImmunity = new DamageTypeModifier();
			m_fireImmunity.damageMultiplier = 0f;
			m_fireImmunity.damageType = (CoreDamageTypes)4;
		}
		if (m_electricityImmunity == null)
		{
			m_electricityImmunity = new DamageTypeModifier();
			m_electricityImmunity.damageMultiplier = 0f;
			m_electricityImmunity.damageType = (CoreDamageTypes)64;
		}
		if (machoDamageMod == null)
		{
			machoDamageMod = new StatModifier();
			machoDamageMod.statToBoost = (StatType)5;
			machoDamageMod.modifyType = (ModifyMethod)1;
			machoDamageMod.amount = 1.3f;
		}
		if ((Object)(object)base.m_extantOrbital != (Object)null && (Object)(object)((PassiveItem)this).Owner != (Object)null)
		{
			if (base.m_extantOrbital.GetComponent<PlayerOrbital>().orbitRadius != overrideOrbitalDistance)
			{
				base.m_extantOrbital.GetComponent<PlayerOrbital>().orbitRadius = overrideOrbitalDistance;
			}
			if (base.m_extantOrbital.GetComponent<PlayerOrbital>().orbitDegreesPerSecond != overrideOrbitalSpeed)
			{
				base.m_extantOrbital.GetComponent<PlayerOrbital>().orbitDegreesPerSecond = overrideOrbitalSpeed;
			}
			if (base.m_extantOrbital.GetComponent<PlayerOrbital>().perfectOrbitalFactor != overridePerfectOrbitalFactor)
			{
				base.m_extantOrbital.GetComponent<PlayerOrbital>().perfectOrbitalFactor = overridePerfectOrbitalFactor;
			}
			if ((Object)(object)((BraveBehaviour)base.m_extantOrbital.GetComponent<tk2dSprite>()).renderer.material.shader != (Object)(object)ShaderCache.Acquire("Brave/Internal/RainbowChestShader"))
			{
				((BraveBehaviour)((BraveBehaviour)base.m_extantOrbital.GetComponent<tk2dSprite>()).sprite).renderer.material.shader = ShaderCache.Acquire("Brave/Internal/RainbowChestShader");
				((BraveBehaviour)((BraveBehaviour)base.m_extantOrbital.GetComponent<tk2dSprite>()).sprite).renderer.material.SetFloat("_AllColorsToggle", 1f);
			}
			if (canReselectGuonState && Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
			{
				canReselectGuonState = false;
				ReSelectGuonState();
				((MonoBehaviour)this).Invoke("resetGuonStateCooldown", 5f);
			}
			if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner) && ((PassiveItem)this).Owner.IsInCombat && ((BraveBehaviour)((PassiveItem)this).Owner).specRigidbody.Velocity == Vector2.zero && canFireCyanProjectile && RandomlySelectedGuonState == GuonState.CYAN)
			{
				FireProjectileFromGuon(((Component)CyanGuonStone.cyanGuonProj).gameObject, scaleStats: true, postProcess: true, 1f, 0f, 5f, playerStatScalesAccuracy: true);
				canFireCyanProjectile = false;
				if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Rainbower Guon Stone"))
				{
					((MonoBehaviour)this).Invoke("resetCyanFireCooldown", 0.16f);
				}
				else
				{
					((MonoBehaviour)this).Invoke("resetCyanFireCooldown", 0.35f);
				}
			}
			if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner) && ((PassiveItem)this).Owner.IsInCombat && canFireOrangeProjectile && RandomlySelectedGuonState == GuonState.ORANGE)
			{
				canFireOrangeProjectile = false;
				if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Rainbower Guon Stone"))
				{
					FireProjectileFromGuon(((Component)mockOrangeGuonProj).gameObject, scaleStats: true, postProcess: true, 1.6f);
					((MonoBehaviour)this).Invoke("resetOrangeFireCooldown", 0.5f);
				}
				else
				{
					FireProjectileFromGuon(((Component)mockOrangeGuonProj).gameObject, scaleStats: true, postProcess: true);
					((MonoBehaviour)this).Invoke("resetOrangeFireCooldown", 1f);
				}
			}
		}
		((AdvancedPlayerOrbitalItem)this).Update();
	}

	private void ReSelectGuonState()
	{
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		overrideOrbitalDistance = 2.5f;
		overrideOrbitalSpeed = 120f;
		overridePerfectOrbitalFactor = 0f;
		RemoveStat((StatType)18);
		RemoveStat((StatType)28);
		((BraveBehaviour)((PassiveItem)this).Owner).healthHaver.damageTypeModifiers.Remove(m_poisonImmunity);
		((BraveBehaviour)((PassiveItem)this).Owner).healthHaver.damageTypeModifiers.Remove(m_fireImmunity);
		((BraveBehaviour)((PassiveItem)this).Owner).healthHaver.damageTypeModifiers.Remove(m_electricityImmunity);
		RandomlySelectedGuonState = RandomEnum<GuonState>.Get();
		((PassiveItem)this).Owner.stats.RecalculateStats(((PassiveItem)this).Owner, true, false);
		if (GuonTransitionVFX.ContainsKey(RandomlySelectedGuonState))
		{
			Object.Instantiate<GameObject>(GuonTransitionVFX[RandomlySelectedGuonState], Vector2.op_Implicit(base.m_extantOrbital.GetComponent<tk2dBaseSprite>().WorldCenter), Quaternion.identity);
		}
		if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Rainbower Guon Stone"))
		{
			overridePerfectOrbitalFactor = 10f;
		}
		if (RandomlySelectedGuonState == GuonState.RED)
		{
			AddStat((StatType)28, 1.3f, (ModifyMethod)1);
		}
		else if (RandomlySelectedGuonState == GuonState.WHITE)
		{
			AddStat((StatType)18, 1f, (ModifyMethod)0);
		}
		else if (RandomlySelectedGuonState == GuonState.CLEAR)
		{
			((BraveBehaviour)((PassiveItem)this).Owner).healthHaver.damageTypeModifiers.Add(m_poisonImmunity);
			if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Rainbower Guon Stone"))
			{
				((BraveBehaviour)((PassiveItem)this).Owner).healthHaver.damageTypeModifiers.Add(m_fireImmunity);
				((BraveBehaviour)((PassiveItem)this).Owner).healthHaver.damageTypeModifiers.Add(m_electricityImmunity);
			}
		}
		else if (RandomlySelectedGuonState == GuonState.BLUE)
		{
			if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Rainbower Guon Stone"))
			{
				overrideOrbitalDistance = 4f;
				overrideOrbitalSpeed = 360f;
			}
			else
			{
				overrideOrbitalSpeed = 240f;
			}
		}
		else if (RandomlySelectedGuonState == GuonState.BROWN)
		{
			if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Rainbower Guon Stone"))
			{
				overrideOrbitalDistance = 1.75f;
			}
			else
			{
				overrideOrbitalDistance = 3f;
			}
			overrideOrbitalSpeed = CalculateSpeedForBrownOrbital();
		}
		else if (RandomlySelectedGuonState == GuonState.INDIGO)
		{
			overridePerfectOrbitalFactor = 10f;
			overrideOrbitalDistance = 1f;
			overrideOrbitalSpeed = 100f;
		}
		((PassiveItem)this).Owner.stats.RecalculateStats(((PassiveItem)this).Owner, true, false);
	}

	private void DebugPrintType()
	{
		switch (RandomlySelectedGuonState)
		{
		case GuonState.RED:
			ETGModConsole.Log((object)"Red", false);
			break;
		case GuonState.ORANGE:
			ETGModConsole.Log((object)"Orange", false);
			break;
		case GuonState.YELLOW:
			ETGModConsole.Log((object)"Yellow", false);
			break;
		case GuonState.GREEN:
			ETGModConsole.Log((object)"Green", false);
			break;
		case GuonState.BLUE:
			ETGModConsole.Log((object)"Blue", false);
			break;
		case GuonState.WHITE:
			ETGModConsole.Log((object)"White", false);
			break;
		case GuonState.CLEAR:
			ETGModConsole.Log((object)"Clear", false);
			break;
		case GuonState.CYAN:
			ETGModConsole.Log((object)"Cyan", false);
			break;
		case GuonState.GOLD:
			ETGModConsole.Log((object)"Gold", false);
			break;
		case GuonState.GREY:
			ETGModConsole.Log((object)"Grey", false);
			break;
		case GuonState.BROWN:
			ETGModConsole.Log((object)"Brown", false);
			break;
		case GuonState.INDIGO:
			ETGModConsole.Log((object)"Indigo", false);
			break;
		}
	}

	private float CalculateSpeedForBrownOrbital()
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Invalid comparison between Unknown and I4
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Invalid comparison between Unknown and I4
		float num = 40f;
		foreach (PassiveItem passiveItem in ((PassiveItem)this).Owner.passiveItems)
		{
			if ((int)((PickupObject)passiveItem).quality == 1 || ((PickupObject)passiveItem).PickupObjectId == 127)
			{
				num = ((!CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Rainbower Guon Stone")) ? (num + 10f) : (num + 20f));
			}
		}
		foreach (Gun allGun in ((PassiveItem)this).Owner.inventory.AllGuns)
		{
			if ((int)((PickupObject)allGun).quality == 1)
			{
				num = ((!CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Rainbower Guon Stone")) ? (num + 10f) : (num + 20f));
			}
		}
		return num;
	}

	private void resetCyanFireCooldown()
	{
		canFireCyanProjectile = true;
	}

	private void resetBlueRoomDMG()
	{
		canDoBlueSynergyRoomDMG = true;
	}

	private void resetOrangeFireCooldown()
	{
		canFireOrangeProjectile = true;
	}

	private void resetGuonStateCooldown()
	{
		canReselectGuonState = true;
	}

	private void resetGreyCollisionDMG()
	{
		canDoGreyCollisionDMG = true;
	}

	private void OnGuonHitByBullet(SpeculativeRigidbody myRigidbody, PixelCollider myCollider, SpeculativeRigidbody other, PixelCollider otherCollider)
	{
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_0217: Unknown result type (might be due to invalid IL or missing references)
		//IL_032f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0334: Unknown result type (might be due to invalid IL or missing references)
		//IL_0339: Unknown result type (might be due to invalid IL or missing references)
		//IL_031c: Unknown result type (might be due to invalid IL or missing references)
		if (!Object.op_Implicit((Object)(object)((BraveBehaviour)other).projectile) || ((BraveBehaviour)other).projectile.Owner is PlayerController)
		{
			return;
		}
		if (RandomlySelectedGuonState == GuonState.GOLD)
		{
			float num = 0.1f;
			if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Rainbower Guon Stone"))
			{
				num = 0.15f;
			}
			if (Random.value <= num)
			{
				LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetById(68)).gameObject, Vector2.op_Implicit(((BraveBehaviour)other).specRigidbody.UnitCenter), Vector2.zero, 1f, false, true, false);
			}
		}
		if (RandomlySelectedGuonState == GuonState.BLUE && CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Rainbower Guon Stone") && canDoBlueSynergyRoomDMG)
		{
			canDoBlueSynergyRoomDMG = false;
			List<AIActor> activeEnemies = ((PassiveItem)this).Owner.CurrentRoom.GetActiveEnemies((ActiveEnemyType)0);
			if (activeEnemies != null)
			{
				for (int i = 0; i < activeEnemies.Count; i++)
				{
					AIActor val = activeEnemies[i];
					((BraveBehaviour)val).healthHaver.ApplyDamage(15f, Vector2.zero, "Blue Guon Stone", (CoreDamageTypes)0, (DamageCategory)0, true, (PixelCollider)null, false);
				}
			}
			((MonoBehaviour)this).Invoke("resetBlueRoomDMG", 1f);
		}
		if (RandomlySelectedGuonState == GuonState.GREY && canDoGreyCollisionDMG && ((BraveBehaviour)other).projectile.Owner is AIActor)
		{
			float num2 = 5f;
			if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Rainbower Guon Stone"))
			{
				num2 *= 2f;
			}
			GameActor owner = ((BraveBehaviour)other).projectile.Owner;
			if (((AIActor)((owner is AIActor) ? owner : null)).IsBlackPhantom)
			{
				num2 *= 3f;
			}
			num2 *= ((PassiveItem)this).Owner.stats.GetStatValue((StatType)5);
			GameActor owner2 = ((BraveBehaviour)other).projectile.Owner;
			((BraveBehaviour)((owner2 is AIActor) ? owner2 : null)).healthHaver.ApplyDamage(num2, Vector2.zero, "Guon Wrath", (CoreDamageTypes)0, (DamageCategory)5, true, (PixelCollider)null, false);
			((MonoBehaviour)this).Invoke("resetGreyCollisionDMG", 0.15f);
		}
		if (RandomlySelectedGuonState == GuonState.RED && CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Rainbower Guon Stone"))
		{
			((MonoBehaviour)((PassiveItem)this).Owner).StartCoroutine(HandleMachoDamageBoost(((PassiveItem)this).Owner));
		}
		if (RandomlySelectedGuonState != GuonState.INDIGO)
		{
			return;
		}
		if (((PassiveItem)this).Owner.IsDodgeRolling)
		{
			PhysicsEngine.SkipCollision = true;
			return;
		}
		float num3 = 0.35f;
		if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Rainbower Guon Stone"))
		{
			num3 = 0.6f;
		}
		if (Random.value <= num3)
		{
			EasyBlankType val2 = (EasyBlankType)1;
			if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Rainbower Guon Stone") && (double)Random.value <= 0.2)
			{
				val2 = (EasyBlankType)0;
			}
			PlayerUtility.DoEasyBlank(((PassiveItem)this).Owner, Vector2.op_Implicit(base.m_extantOrbital.transform.position), val2);
		}
	}

	private void PostProcessBeamTick(BeamController arg1, SpeculativeRigidbody arg2, float arg3)
	{
		if (!m_hasUsedShot)
		{
			m_beamTickElapsed += BraveTime.DeltaTime;
			if (m_beamTickElapsed > 1f)
			{
				m_hasUsedShot = true;
			}
		}
	}

	private void PostProcessProjectile(Projectile targetProjectile, float arg2)
	{
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		if (!Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			return;
		}
		if (RandomlySelectedGuonState == GuonState.CLEAR && CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Rainbower Guon Stone") && Object.op_Implicit((Object)(object)((GameActor)((PassiveItem)this).Owner).CurrentGoop))
		{
			if (((GameActor)((PassiveItem)this).Owner).CurrentGoop.CanBeIgnited)
			{
				if (!targetProjectile.AppliesFire)
				{
					targetProjectile.AppliesFire = true;
					targetProjectile.FireApplyChance = 1f;
					targetProjectile.fireEffect = ((GameActor)((PassiveItem)this).Owner).CurrentGoop.fireEffect;
				}
			}
			else if (((GameActor)((PassiveItem)this).Owner).CurrentGoop.CanBeFrozen && !targetProjectile.AppliesFreeze)
			{
				targetProjectile.AppliesFreeze = true;
				targetProjectile.FreezeApplyChance = 1f;
				targetProjectile.freezeEffect = ((Component)PickupObjectDatabase.GetById(264)).GetComponent<IounStoneOrbitalItem>().DefaultFreezeEffect;
			}
		}
		if (m_destroyVFXSemaphore <= 0)
		{
			return;
		}
		targetProjectile.AdjustPlayerProjectileTint(new Color(1f, 0.9f, 0f), 50, 0f);
		if (!m_hasUsedShot)
		{
			m_hasUsedShot = true;
			if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner) && Object.op_Implicit((Object)(object)SharedVFX.MachoBraceDustUpVFX))
			{
				((GameActor)((PassiveItem)this).Owner).PlayEffectOnActor(SharedVFX.MachoBraceDustUpVFX, new Vector3(0f, -0.625f, 0f), false, false, false);
				AkSoundEngine.PostEvent("Play_ITM_Macho_Brace_Trigger_01", ((Component)this).gameObject);
			}
			if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner) && Object.op_Implicit((Object)(object)SharedVFX.MachoBraceBurstVFX))
			{
				((GameActor)((PassiveItem)this).Owner).PlayEffectOnActor(SharedVFX.MachoBraceBurstVFX, new Vector3(0f, 0.375f, 0f), false, false, false);
			}
		}
	}

	private void OnTookDamage(PlayerController player)
	{
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		if (RandomlySelectedGuonState == GuonState.GREEN)
		{
			float num = 0.5f;
			if (CustomSynergies.PlayerHasActiveSynergy(player, "Rainbower Guon Stone"))
			{
				num = 0.7f;
			}
			if (((BraveBehaviour)player).healthHaver.GetCurrentHealth() < num)
			{
				if (Random.value <= 0.5f)
				{
					((BraveBehaviour)player).healthHaver.ApplyHealing(0.5f);
					if (CustomSynergies.PlayerHasActiveSynergy(player, "Rainbower Guon Stone"))
					{
						LootEngine.SpawnCurrency(((GameActor)player).CenterPosition, 20, false);
					}
				}
			}
			else if (Random.value <= 0.2f)
			{
				((BraveBehaviour)player).healthHaver.ApplyHealing(0.5f);
				if (CustomSynergies.PlayerHasActiveSynergy(player, "Rainbower Guon Stone"))
				{
					LootEngine.SpawnCurrency(((GameActor)player).CenterPosition, 20, false);
				}
			}
		}
		if (RandomlySelectedGuonState == GuonState.BLUE)
		{
			((MonoBehaviour)player).StartCoroutine(HandleSlowBullets());
		}
	}

	private void OnEnemyDamaged(float damage, bool fatal, HealthHaver enemyHealth)
	{
		if (RandomlySelectedGuonState == GuonState.YELLOW && Object.op_Implicit((Object)(object)((PassiveItem)this).Owner) && Object.op_Implicit((Object)(object)enemyHealth) && fatal)
		{
			if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Rainbower Guon Stone"))
			{
				((MonoBehaviour)this).StartCoroutine(HandleShield(((PassiveItem)this).Owner, 2f));
			}
			else
			{
				((MonoBehaviour)this).StartCoroutine(HandleShield(((PassiveItem)this).Owner, 1f));
			}
		}
	}

	public override void OnOrbitalCreated(GameObject orbital)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		if (Object.op_Implicit((Object)(object)orbital.GetComponent<SpeculativeRigidbody>()))
		{
			SpeculativeRigidbody component = orbital.GetComponent<SpeculativeRigidbody>();
			component.OnPreRigidbodyCollision = (OnPreRigidbodyCollisionDelegate)Delegate.Combine((Delegate)(object)component.OnPreRigidbodyCollision, (Delegate)new OnPreRigidbodyCollisionDelegate(OnGuonHitByBullet));
		}
		((AdvancedPlayerOrbitalItem)this).OnOrbitalCreated(orbital);
	}

	private void OnTookDamageFromProjectile(Projectile incomingProjectile, PlayerController arg2)
	{
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		if (RandomlySelectedGuonState == GuonState.GREY && Object.op_Implicit((Object)(object)incomingProjectile.Owner) && incomingProjectile.Owner is AIActor)
		{
			float num = 25f;
			if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Rainbower Guon Stone"))
			{
				num = 50f;
			}
			if (((BraveBehaviour)incomingProjectile.Owner).aiActor.IsBlackPhantom)
			{
				((BraveBehaviour)incomingProjectile.Owner).healthHaver.ApplyDamage(arg2.stats.GetStatValue((StatType)5) * num * 3f, Vector2.zero, "Guon Wrath", (CoreDamageTypes)0, (DamageCategory)5, true, (PixelCollider)null, false);
			}
			else
			{
				((BraveBehaviour)incomingProjectile.Owner).healthHaver.ApplyDamage(arg2.stats.GetStatValue((StatType)5) * num, Vector2.zero, "Guon Wrath", (CoreDamageTypes)0, (DamageCategory)5, true, (PixelCollider)null, false);
			}
		}
	}

	public override void Pickup(PlayerController player)
	{
		player.PostProcessProjectile += PostProcessProjectile;
		player.PostProcessBeamTick += PostProcessBeamTick;
		player.OnReceivedDamage += OnTookDamage;
		player.OnAnyEnemyReceivedDamage = (Action<float, bool, HealthHaver>)Delegate.Combine(player.OnAnyEnemyReceivedDamage, new Action<float, bool, HealthHaver>(OnEnemyDamaged));
		player.OnHitByProjectile = (Action<Projectile, PlayerController>)Delegate.Combine(player.OnHitByProjectile, new Action<Projectile, PlayerController>(OnTookDamageFromProjectile));
		((AdvancedPlayerOrbitalItem)this).Pickup(player);
	}

	public override DebrisObject Drop(PlayerController player)
	{
		player.PostProcessProjectile -= PostProcessProjectile;
		player.PostProcessBeamTick -= PostProcessBeamTick;
		player.OnReceivedDamage -= OnTookDamage;
		player.OnAnyEnemyReceivedDamage = (Action<float, bool, HealthHaver>)Delegate.Remove(player.OnAnyEnemyReceivedDamage, new Action<float, bool, HealthHaver>(OnEnemyDamaged));
		player.OnHitByProjectile = (Action<Projectile, PlayerController>)Delegate.Remove(player.OnHitByProjectile, new Action<Projectile, PlayerController>(OnTookDamageFromProjectile));
		return ((AdvancedPlayerOrbitalItem)this).Drop(player);
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			((PassiveItem)this).Owner.PostProcessBeamTick -= PostProcessBeamTick;
			((PassiveItem)this).Owner.PostProcessProjectile -= PostProcessProjectile;
			PlayerController owner = ((PassiveItem)this).Owner;
			owner.OnAnyEnemyReceivedDamage = (Action<float, bool, HealthHaver>)Delegate.Remove(owner.OnAnyEnemyReceivedDamage, new Action<float, bool, HealthHaver>(OnEnemyDamaged));
			((PassiveItem)this).Owner.OnReceivedDamage -= OnTookDamage;
			PlayerController owner2 = ((PassiveItem)this).Owner;
			owner2.OnHitByProjectile = (Action<Projectile, PlayerController>)Delegate.Remove(owner2.OnHitByProjectile, new Action<Projectile, PlayerController>(OnTookDamageFromProjectile));
		}
		((AdvancedPlayerOrbitalItem)this).OnDestroy();
	}

	private void AddStat(StatType statType, float amount, ModifyMethod method = 0)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected O, but got Unknown
		StatModifier val = new StatModifier
		{
			amount = amount,
			statToBoost = statType,
			modifyType = method
		};
		if (((PassiveItem)this).passiveStatModifiers == null)
		{
			((PassiveItem)this).passiveStatModifiers = (StatModifier[])(object)new StatModifier[1] { val };
		}
		else
		{
			((PassiveItem)this).passiveStatModifiers = ((PassiveItem)this).passiveStatModifiers.Concat((IEnumerable<StatModifier>)(object)new StatModifier[1] { val }).ToArray();
		}
	}

	private void RemoveStat(StatType statType)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		List<StatModifier> list = new List<StatModifier>();
		for (int i = 0; i < ((PassiveItem)this).passiveStatModifiers.Length; i++)
		{
			if (((PassiveItem)this).passiveStatModifiers[i].statToBoost != statType)
			{
				list.Add(((PassiveItem)this).passiveStatModifiers[i]);
			}
		}
		((PassiveItem)this).passiveStatModifiers = list.ToArray();
	}

	private IEnumerator HandleShield(PlayerController user, float duration)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CHandleShield_003Ed__44(0)
		{
			_003C_003E4__this = this,
			user = user,
			duration = duration
		};
	}

	private void OnPreCollision(SpeculativeRigidbody myRigidbody, PixelCollider myCollider, SpeculativeRigidbody otherRigidbody, PixelCollider otherCollider)
	{
		Projectile component = ((Component)otherRigidbody).GetComponent<Projectile>();
		if ((Object)(object)component != (Object)null && !(component.Owner is PlayerController))
		{
			PassiveReflectItem.ReflectBullet(component, true, ((BraveBehaviour)((BraveBehaviour)((PassiveItem)this).Owner).specRigidbody).gameActor, 10f, 1f, 1f, 0f);
			PhysicsEngine.SkipCollision = true;
		}
	}

	private IEnumerator HandleSlowBullets()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CHandleSlowBullets_003Ed__46(0)
		{
			_003C_003E4__this = this
		};
	}

	private IEnumerator HandleMachoDamageBoost(PlayerController target)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CHandleMachoDamageBoost_003Ed__48(0)
		{
			_003C_003E4__this = this,
			target = target
		};
	}

	public void EnableMachoVFX(PlayerController target)
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		if (m_destroyVFXSemaphore == 0)
		{
			Material outlineMaterial = SpriteOutlineManager.GetOutlineMaterial(((BraveBehaviour)target).sprite);
			if ((Object)(object)outlineMaterial != (Object)null)
			{
				outlineMaterial.SetColor("_OverrideColor", new Color(99f, 99f, 0f));
			}
			if (Object.op_Implicit((Object)(object)SharedVFX.MachoBraceOverheadVFX) && !Object.op_Implicit((Object)(object)m_instanceVFX))
			{
				m_instanceVFX = ((GameActor)target).PlayEffectOnActor(SharedVFX.MachoBraceOverheadVFX, new Vector3(0f, 1.375f, 0f), true, true, false);
			}
		}
	}

	public void DisableMachoVFX(PlayerController target)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		if (m_destroyVFXSemaphore == 0)
		{
			Material outlineMaterial = SpriteOutlineManager.GetOutlineMaterial(((BraveBehaviour)target).sprite);
			if ((Object)(object)outlineMaterial != (Object)null)
			{
				outlineMaterial.SetColor("_OverrideColor", new Color(0f, 0f, 0f));
			}
			if (!m_hasUsedShot)
			{
			}
			if (Object.op_Implicit((Object)(object)m_instanceVFX))
			{
				SpawnManager.Despawn(m_instanceVFX);
				m_instanceVFX = null;
			}
		}
	}
}
