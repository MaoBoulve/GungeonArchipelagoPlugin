using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

internal class SetOfAllSets : PassiveItem
{
	[CompilerGenerated]
	private sealed class _003CHandleGunnerSkullLifespan_003Ed__7 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public GameObject source;

		public SetOfAllSets _003C_003E4__this;

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
		public _003CHandleGunnerSkullLifespan_003Ed__7(int _003C_003E1__state)
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
			//IL_0026: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0064: Unknown result type (might be due to invalid IL or missing references)
			//IL_0069: Unknown result type (might be due to invalid IL or missing references)
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = (object)new WaitForSeconds(4f);
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				LootEngine.DoDefaultPurplePoof(Vector2.op_Implicit(source.transform.position + new Vector3(0.75f, 0.5f, 0f)), false);
				Object.Destroy((Object)(object)source);
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

	[CompilerGenerated]
	private sealed class _003CHandleShield_003Ed__15 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerController user;

		public SetOfAllSets _003C_003E4__this;

		private bool _003Cm_usedOverrideMaterial_003E5__1;

		private SpeculativeRigidbody _003CspecRigidbody_003E5__2;

		private float _003Celapsed_003E5__3;

		private SpeculativeRigidbody _003CspecRigidbody2_003E5__4;

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
		public _003CHandleShield_003Ed__15(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003CspecRigidbody_003E5__2 = null;
			_003CspecRigidbody2_003E5__4 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_008a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0094: Expected O, but got Unknown
			//IL_0094: Unknown result type (might be due to invalid IL or missing references)
			//IL_009e: Expected O, but got Unknown
			//IL_017c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Expected O, but got Unknown
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0190: Expected O, but got Unknown
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
			{
				_003C_003E1__state = -1;
				_003Cm_usedOverrideMaterial_003E5__1 = ((BraveBehaviour)user).sprite.usesOverrideMaterial;
				((BraveBehaviour)user).sprite.usesOverrideMaterial = true;
				user.SetOverrideShader(ShaderCache.Acquire("Brave/ItemSpecific/MetalSkinShader"));
				_003CspecRigidbody_003E5__2 = ((BraveBehaviour)user).specRigidbody;
				SpeculativeRigidbody obj = _003CspecRigidbody_003E5__2;
				obj.OnPreRigidbodyCollision = (OnPreRigidbodyCollisionDelegate)Delegate.Combine((Delegate)(object)obj.OnPreRigidbodyCollision, (Delegate)new OnPreRigidbodyCollisionDelegate(_003C_003E4__this.OnLeadSkinPreCollision));
				((BraveBehaviour)user).healthHaver.IsVulnerable = false;
				_003Celapsed_003E5__3 = 0f;
				break;
			}
			case 1:
				_003C_003E1__state = -1;
				break;
			}
			if (_003Celapsed_003E5__3 < 3.5f)
			{
				_003Celapsed_003E5__3 += BraveTime.DeltaTime;
				((BraveBehaviour)user).healthHaver.IsVulnerable = false;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			if (Object.op_Implicit((Object)(object)user))
			{
				((BraveBehaviour)user).healthHaver.IsVulnerable = true;
				user.ClearOverrideShader();
				((BraveBehaviour)user).sprite.usesOverrideMaterial = _003Cm_usedOverrideMaterial_003E5__1;
				_003CspecRigidbody2_003E5__4 = ((BraveBehaviour)user).specRigidbody;
				SpeculativeRigidbody obj2 = _003CspecRigidbody2_003E5__4;
				obj2.OnPreRigidbodyCollision = (OnPreRigidbodyCollisionDelegate)Delegate.Remove((Delegate)(object)obj2.OnPreRigidbodyCollision, (Delegate)new OnPreRigidbodyCollisionDelegate(_003C_003E4__this.OnLeadSkinPreCollision));
				AkSoundEngine.PostEvent("Play_OBJ_metalskin_end_01", ((Component)user).gameObject);
				_003CspecRigidbody2_003E5__4 = null;
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
	private sealed class _003CHandleSlowBullets_003Ed__5 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public SetOfAllSets _003C_003E4__this;

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
		public _003CHandleSlowBullets_003Ed__5(int _003C_003E1__state)
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
				_003C_003E4__this.m_isSlowingBullets = true;
				_003CslowMultiplier_003E5__1 = _003C_003E4__this.SlowBulletsMultiplier;
				Projectile.BaseEnemyBulletSpeedMultiplier *= _003CslowMultiplier_003E5__1;
				_003C_003E4__this.m_slowDurationRemaining = _003C_003E4__this.SlowBulletsDuration;
				break;
			case 2:
				_003C_003E1__state = -1;
				_003C_003E4__this.m_slowDurationRemaining -= BraveTime.DeltaTime;
				Projectile.BaseEnemyBulletSpeedMultiplier /= _003CslowMultiplier_003E5__1;
				_003CslowMultiplier_003E5__1 = Mathf.Lerp(_003C_003E4__this.SlowBulletsMultiplier, 1f, 1f - _003C_003E4__this.m_slowDurationRemaining);
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
			_003C_003E4__this.m_isSlowingBullets = false;
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

	public float friendlyifyTimer;

	public float SlowBulletsDuration = 15f;

	public float SlowBulletsMultiplier = 0.5f;

	private bool m_isSlowingBullets;

	private float m_slowDurationRemaining;

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<SetOfAllSets>("Set of All Sets", "Contains Itself", "On damage, triggers a random 'on hit' effect.\n\nA physical manifestation of the question which has been hassling mathematicians and philosophers for centuries. The answer is yes.", "setofallsets_icon", assetbundle: true);
		val.quality = (ItemQuality)2;
	}

	private void OnHit(PlayerController user)
	{
		//IL_023d: Unknown result type (might be due to invalid IL or missing references)
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_029d: Unknown result type (might be due to invalid IL or missing references)
		int num = 1;
		if (CustomSynergies.PlayerHasActiveSynergy(user, "Recursive Recursions"))
		{
			num = 2;
		}
		for (int i = 0; i < num; i++)
		{
			switch (Random.Range(0, 17))
			{
			case 0:
				PlayerUtility.GetExtComp(user).Enrage(3f, true);
				if ((Object)(object)((GameActor)user).CurrentGun != (Object)null)
				{
					((GameActor)user).CurrentGun.ForceImmediateReload(false);
				}
				break;
			case 1:
			{
				SpawnProjectileOnDamagedItem component = ((Component)PickupObjectDatabase.GetById(138)).GetComponent<SpawnProjectileOnDamagedItem>();
				SpawnProjectiles(component.minNumToSpawn, component.maxNumToSpawn, component.projectileToSpawn, component.randomAngle, user);
				break;
			}
			case 2:
			{
				SpawnProjectileOnDamagedItem component2 = ((Component)PickupObjectDatabase.GetById(364)).GetComponent<SpawnProjectileOnDamagedItem>();
				SpawnProjectiles(component2.minNumToSpawn, component2.maxNumToSpawn, component2.projectileToSpawn, component2.randomAngle, user);
				break;
			}
			case 3:
				((BraveBehaviour)user).healthHaver.ApplyHealing(0.5f);
				break;
			case 4:
				if (!m_isSlowingBullets)
				{
					((MonoBehaviour)user).StartCoroutine(HandleSlowBullets());
				}
				else
				{
					m_slowDurationRemaining = SlowBulletsDuration;
				}
				break;
			case 5:
			{
				user.ForceBlank(25f, 0.5f, false, true, (Vector2?)null, true, -1f);
				if (user.inventory == null || user.inventory.AllGuns == null)
				{
					break;
				}
				for (int j = 0; j < user.inventory.AllGuns.Count; j++)
				{
					Gun val = user.inventory.AllGuns[j];
					if (!val.InfiniteAmmo && val.CanGainAmmo)
					{
						val.GainAmmo(Mathf.CeilToInt((float)val.AdjustedMaxAmmo * 0.01f * 5f));
					}
				}
				break;
			}
			case 6:
				DeadlyDeadlyGoopManager.GetGoopManagerForGoopType(EasyGoopDefinitions.PlayerFriendlyPoisonGoop).TimedAddGoopCircle(((BraveBehaviour)user).specRigidbody.UnitCenter, ((Component)PickupObjectDatabase.GetById(313)).GetComponent<PassiveGooperItem>().goopRadius, 0.5f, false);
				break;
			case 7:
				SpawnGunnerSkull(user);
				break;
			case 8:
				LootEngine.SpawnCurrency(((BraveBehaviour)user).sprite.WorldCenter, 10, false);
				break;
			case 9:
				DeadlyDeadlyGoopManager.GetGoopManagerForGoopType(EasyGoopDefinitions.CheeseDef).TimedAddGoopCircle(((BraveBehaviour)user).sprite.WorldCenter, 10f, 1f, false);
				break;
			case 10:
				friendlyifyTimer = 2f;
				foreach (Projectile allProjectile in StaticReferenceManager.AllProjectiles)
				{
					if ((Object)(object)allProjectile.Owner == (Object)null || !(allProjectile.Owner is PlayerController))
					{
						ConvertBullet(allProjectile);
					}
				}
				break;
			case 11:
				DoShadowRing(user);
				break;
			case 12:
				((MonoBehaviour)this).StartCoroutine(HandleShield(user));
				break;
			case 13:
				FullRoomStatusEffect(user, (GameActorEffect)(object)StaticStatusEffects.hotLeadEffect);
				break;
			case 14:
				FullRoomStatusEffect(user, (GameActorEffect)(object)StaticStatusEffects.charmingRoundsEffect);
				break;
			case 15:
			{
				AIActor randomActiveEnemy = user.CurrentRoom.GetRandomActiveEnemy(true);
				if ((Object)(object)randomActiveEnemy != (Object)null && !((BraveBehaviour)randomActiveEnemy).healthHaver.IsBoss)
				{
					((GameActor)randomActiveEnemy).ForceFall();
				}
				break;
			}
			case 16:
				DeathCurse(user);
				break;
			}
		}
	}

	private void DeathCurse(PlayerController playa)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		List<AIActor> activeEnemies = playa.CurrentRoom.GetActiveEnemies((ActiveEnemyType)0);
		GameManager.Instance.MainCameraController.DoScreenShake(StaticExplosionDatas.genericLargeExplosion.ss, (Vector2?)null, false);
		Pixelator.Instance.FadeToColor(0.1f, Color.white, true, 0.1f);
		Exploder.DoDistortionWave(((GameActor)playa).CenterPosition, 0.4f, 0.15f, 10f, 0.4f);
		if (playa.CurrentRoom != null)
		{
			playa.CurrentRoom.ClearReinforcementLayers();
		}
		if (activeEnemies == null)
		{
			return;
		}
		for (int i = 0; i < activeEnemies.Count; i++)
		{
			AIActor val = activeEnemies[i];
			if (val.IsNormalEnemy && Object.op_Implicit((Object)(object)((BraveBehaviour)val).healthHaver))
			{
				((BraveBehaviour)val).healthHaver.ApplyDamage(((BraveBehaviour)val).healthHaver.IsBoss ? 100f : 10000000f, Vector2.zero, string.Empty, (CoreDamageTypes)0, (DamageCategory)0, false, (PixelCollider)null, false);
			}
		}
	}

	private void FullRoomStatusEffect(PlayerController user, GameActorEffect effect)
	{
		List<AIActor> activeEnemies = user.CurrentRoom.GetActiveEnemies((ActiveEnemyType)0);
		if (activeEnemies == null)
		{
			return;
		}
		for (int i = 0; i < activeEnemies.Count; i++)
		{
			AIActor val = activeEnemies[i];
			if (val.IsNormalEnemy)
			{
				((BraveBehaviour)val).gameActor.ApplyEffect(effect, 1f, (Projectile)null);
			}
		}
	}

	private void SpawnProjectiles(int minNum, int maxnum, Projectile prefab, bool randomAngle, PlayerController player)
	{
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		int num = Random.Range(minNum, maxnum + 1);
		float num2 = 360f / (float)num;
		float num3 = Random.Range(0f, num2);
		for (int i = 0; i < num; i++)
		{
			float num4 = ((!randomAngle) ? (num3 + num2 * (float)i) : ((float)Random.Range(0, 360)));
			GameObject val = SpawnManager.SpawnProjectile(((Component)prefab).gameObject, Vector2.op_Implicit(((BraveBehaviour)player).specRigidbody.UnitCenter), Quaternion.Euler(0f, 0f, num4), true);
			Projectile component = val.GetComponent<Projectile>();
			component.Owner = (GameActor)(object)player;
			component.Shooter = ((BraveBehaviour)player).specRigidbody;
		}
	}

	private IEnumerator HandleSlowBullets()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CHandleSlowBullets_003Ed__5(0)
		{
			_003C_003E4__this = this
		};
	}

	private void SpawnGunnerSkull(PlayerController p)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		GameObject val = SpawnManager.SpawnDebris(((Component)PickupObjectDatabase.GetById(602)).GetComponent<GunnerGunController>().SkullPrefab, Vector2Extensions.ToVector3ZisY(((GameActor)p).CenterPosition, 0f), Quaternion.identity);
		DebrisObject component = val.GetComponent<DebrisObject>();
		component.FlagAsPickup();
		Vector2 insideUnitCircle = Random.insideUnitCircle;
		component.Trigger(Vector2Extensions.ToVector3ZUp(((Vector2)(ref insideUnitCircle)).normalized * 20f, 3f), 1f, 0f);
		SpeculativeRigidbody component2 = val.GetComponent<SpeculativeRigidbody>();
		PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(component2, (int?)null, false);
		component2.RegisterTemporaryCollisionException(((BraveBehaviour)p).specRigidbody, 0.25f, (float?)null);
		SpeculativeRigidbody val2 = component2;
		val2.OnEnterTrigger = (OnTriggerDelegate)Delegate.Combine((Delegate)(object)val2.OnEnterTrigger, (Delegate)new OnTriggerDelegate(HandleSkullTrigger));
		((MonoBehaviour)component2).StartCoroutine(HandleGunnerSkullLifespan(val));
	}

	private IEnumerator HandleGunnerSkullLifespan(GameObject source)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CHandleGunnerSkullLifespan_003Ed__7(0)
		{
			_003C_003E4__this = this,
			source = source
		};
	}

	private void HandleSkullTrigger(SpeculativeRigidbody specRigidbody, SpeculativeRigidbody sourceSpecRigidbody, CollisionData collisionData)
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Invalid comparison between Unknown and I4
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		if (!Object.op_Implicit((Object)(object)specRigidbody))
		{
			return;
		}
		PlayerController component = ((Component)specRigidbody).GetComponent<PlayerController>();
		if (Object.op_Implicit((Object)(object)component))
		{
			sourceSpecRigidbody.OnEnterTrigger = (OnTriggerDelegate)Delegate.Remove((Delegate)(object)sourceSpecRigidbody.OnEnterTrigger, (Delegate)new OnTriggerDelegate(HandleSkullTrigger));
			tk2dSpriteAnimator component2 = ((Component)sourceSpecRigidbody).gameObject.GetComponent<tk2dSpriteAnimator>();
			component2.PlayAndDestroyObject("gonner_skull_pickup_vfx", (Action)null);
			if ((int)component.characterIdentity == 2)
			{
				HealthHaver healthHaver = ((BraveBehaviour)component).healthHaver;
				healthHaver.Armor += 1f;
			}
			else
			{
				((BraveBehaviour)component).healthHaver.ApplyHealing(0.5f);
			}
			AkSoundEngine.PostEvent("Play_OBJ_heart_heal_01", ((Component)this).gameObject);
			((GameActor)component).PlayEffectOnActor(SharedVFX.HealingSparkles, Vector3.zero, true, false, false);
		}
	}

	private void NewBulletAppeared(Projectile proj)
	{
		if (friendlyifyTimer > 0f && ((Object)(object)proj.Owner == (Object)null || !(proj.Owner is PlayerController)))
		{
			ConvertBullet(proj);
		}
	}

	public override void Update()
	{
		if (friendlyifyTimer >= 0f)
		{
			friendlyifyTimer -= BraveTime.DeltaTime;
		}
		((PassiveItem)this).Update();
	}

	private void DoShadowRing(PlayerController user)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		GameObject objectToSpawn = ((Component)PickupObjectDatabase.GetById(820)).GetComponent<SpawnObjectPlayerItem>().objectToSpawn;
		GameObject val = Object.Instantiate<GameObject>(objectToSpawn, Vector2.op_Implicit(((BraveBehaviour)user).specRigidbody.UnitCenter), Quaternion.identity);
		tk2dBaseSprite component = val.GetComponent<tk2dBaseSprite>();
		if ((Object)(object)component != (Object)null)
		{
			component.PlaceAtPositionByAnchor(Vector2Extensions.ToVector3ZUp(((BraveBehaviour)user).specRigidbody.UnitCenter, ((BraveBehaviour)component).transform.position.z), (Anchor)4);
			if ((Object)(object)((BraveBehaviour)component).specRigidbody != (Object)null)
			{
				((BraveBehaviour)component).specRigidbody.RegisterGhostCollisionException(((BraveBehaviour)user).specRigidbody);
			}
		}
		KageBunshinController component2 = val.GetComponent<KageBunshinController>();
		if (Object.op_Implicit((Object)(object)component2))
		{
			component2.InitializeOwner(user);
		}
		val.transform.position = dfVectorExtensions.Quantize(val.transform.position, 0.0625f);
	}

	private void ConvertBullet(Projectile proj)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_024d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0274: Unknown result type (might be due to invalid IL or missing references)
		Vector2 direction = proj.Direction;
		if (Object.op_Implicit((Object)(object)proj.Owner) && Object.op_Implicit((Object)(object)((BraveBehaviour)proj.Owner).specRigidbody))
		{
			((BraveBehaviour)proj).specRigidbody.DeregisterSpecificCollisionException(((BraveBehaviour)proj.Owner).specRigidbody);
		}
		proj.Owner = (GameActor)(object)((PassiveItem)this).Owner;
		proj.SetNewShooter(((BraveBehaviour)((PassiveItem)this).Owner).specRigidbody);
		proj.allowSelfShooting = false;
		proj.collidesWithPlayer = false;
		proj.collidesWithEnemies = true;
		proj.baseData.damage = 15f;
		if (proj.IsBlackBullet)
		{
			ProjectileData baseData = proj.baseData;
			baseData.damage *= 2f;
		}
		PlayerController owner = ((PassiveItem)this).Owner;
		if ((Object)(object)owner != (Object)null)
		{
			ProjectileData baseData2 = proj.baseData;
			baseData2.damage *= owner.stats.GetStatValue((StatType)5);
			ProjectileData baseData3 = proj.baseData;
			baseData3.speed *= owner.stats.GetStatValue((StatType)6);
			proj.UpdateSpeed();
			ProjectileData baseData4 = proj.baseData;
			baseData4.force *= owner.stats.GetStatValue((StatType)12);
			ProjectileData baseData5 = proj.baseData;
			baseData5.range *= owner.stats.GetStatValue((StatType)26);
			proj.BossDamageMultiplier *= owner.stats.GetStatValue((StatType)22);
			proj.RuntimeUpdateScale(owner.stats.GetStatValue((StatType)15));
			if (owner.stats.GetStatValue((StatType)17) > 0f)
			{
				bool flag = Object.op_Implicit((Object)(object)((Component)proj).gameObject.GetComponent<BounceProjModifier>());
				BounceProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<BounceProjModifier>(((Component)proj).gameObject);
				if (flag)
				{
					orAddComponent.numberOfBounces += (int)owner.stats.GetStatValue((StatType)17);
				}
				else
				{
					orAddComponent.numberOfBounces = (int)owner.stats.GetStatValue((StatType)17);
				}
			}
			owner.DoPostProcessProjectile(proj);
		}
		if ((Object)(object)((Component)proj).GetComponent<BeamController>() != (Object)null)
		{
			((Component)proj).GetComponent<BeamController>().HitsPlayers = false;
			((Component)proj).GetComponent<BeamController>().HitsEnemies = true;
		}
		else if ((Object)(object)((Component)proj).GetComponent<BasicBeamController>() != (Object)null)
		{
			((BeamController)((Component)proj).GetComponent<BasicBeamController>()).HitsPlayers = false;
			((BeamController)((Component)proj).GetComponent<BasicBeamController>()).HitsEnemies = true;
		}
		proj.AdjustPlayerProjectileTint(ExtendedColours.honeyYellow, 1, 0f);
		proj.UpdateCollisionMask();
		ProjectileUtility.RemoveFromPool(proj);
		proj.Reflected();
		proj.SendInDirection(direction, false, true);
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		StaticReferenceManager.ProjectileAdded += NewBulletAppeared;
		player.OnReceivedDamage += OnHit;
	}

	public override void DisableEffect(PlayerController player)
	{
		if (Object.op_Implicit((Object)(object)player))
		{
			player.OnReceivedDamage -= OnHit;
		}
		StaticReferenceManager.ProjectileAdded -= NewBulletAppeared;
		((PassiveItem)this).DisableEffect(player);
	}

	private IEnumerator HandleShield(PlayerController user)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CHandleShield_003Ed__15(0)
		{
			_003C_003E4__this = this,
			user = user
		};
	}

	private void OnLeadSkinPreCollision(SpeculativeRigidbody myRigidbody, PixelCollider myCollider, SpeculativeRigidbody otherRigidbody, PixelCollider otherCollider)
	{
		Projectile component = ((Component)otherRigidbody).GetComponent<Projectile>();
		if ((Object)(object)component != (Object)null && !(component.Owner is PlayerController))
		{
			PassiveReflectItem.ReflectBullet(component, true, ((BraveBehaviour)((BraveBehaviour)((PassiveItem)this).Owner).specRigidbody).gameActor, 10f, 1f, 1f, 0f);
			PhysicsEngine.SkipCollision = true;
		}
	}
}
