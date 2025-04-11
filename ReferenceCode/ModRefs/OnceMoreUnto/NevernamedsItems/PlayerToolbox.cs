using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.ChestAPI;
using Alexandria.Misc;
using Dungeonator;
using Pathfinding;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class PlayerToolbox : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CButterFingersGun_003Ed__5 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerToolbox _003C_003E4__this;

		private Gun _003CgunToSlip_003E5__1;

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
		public _003CButterFingersGun_003Ed__5(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003CgunToSlip_003E5__1 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c2: Expected O, but got Unknown
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
				if ((Object)(object)((GameActor)_003C_003E4__this.m_attachedPlayer).CurrentGun != (Object)null)
				{
					_003CgunToSlip_003E5__1 = ((GameActor)_003C_003E4__this.m_attachedPlayer).CurrentGun;
					_003C_003E4__this.m_attachedPlayer.inventory.RemoveGunFromInventory(_003CgunToSlip_003E5__1);
					((Component)_003CgunToSlip_003E5__1).gameObject.AddComponent<ButterfingersedGun>();
					_003CgunToSlip_003E5__1.ForceThrowGun();
					_003C_003E2__current = (object)new WaitForSeconds(0.1f);
					_003C_003E1__state = 2;
					return true;
				}
				break;
			case 2:
				_003C_003E1__state = -1;
				_003CgunToSlip_003E5__1.ToggleRenderers(true);
				_003CgunToSlip_003E5__1.RegisterMinimapIcon();
				_003CgunToSlip_003E5__1 = null;
				break;
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
	private sealed class _003CButterfingersLateReTeleport_003Ed__7 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Projectile proj;

		public PlayerToolbox _003C_003E4__this;

		private bool _003ChasTeleportedOnce_003E5__1;

		private Exception _003Ce_003E5__2;

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
		public _003CButterfingersLateReTeleport_003Ed__7(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003Ce_003E5__2 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_0089: Unknown result type (might be due to invalid IL or missing references)
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
			{
				_003C_003E1__state = -1;
				Projectile obj = proj;
				obj.OnBecameDebris = (Action<DebrisObject>)Delegate.Combine(obj.OnBecameDebris, new Action<DebrisObject>(_003C_003E4__this.ButterfingersBabyMode));
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			case 1:
				_003C_003E1__state = -1;
				_003ChasTeleportedOnce_003E5__1 = false;
				while (!_003ChasTeleportedOnce_003E5__1)
				{
					try
					{
						((BraveBehaviour)proj).specRigidbody.Position = new Position(((BraveBehaviour)_003C_003E4__this.m_attachedPlayer).specRigidbody.UnitCenter);
						Object.Destroy((Object)(object)((Component)proj).gameObject.GetComponent<ButterfingersedGun>());
						_003ChasTeleportedOnce_003E5__1 = true;
					}
					catch (Exception ex)
					{
						_003Ce_003E5__2 = ex;
						ETGModConsole.Log((object)_003Ce_003E5__2.ToString(), false);
					}
				}
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
	private sealed class _003CDelay_003Ed__20 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public RoomHandler room;

		public HealthHaver health;

		public bool flawless;

		public bool crest;

		public PlayerToolbox _003C_003E4__this;

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
		public _003CDelay_003Ed__20(int _003C_003E1__state)
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
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = (object)new WaitForSeconds(0.1f);
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				if (crest)
				{
					HealthHaver obj = health;
					float armor = obj.Armor;
					obj.Armor = armor - 1f;
					LootEngine.TryGivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(305)).gameObject, _003C_003E4__this.m_attachedPlayer, false);
					health.HasCrest = true;
				}
				if (flawless)
				{
					room.PlayerHasTakenDamageInThisRoom = false;
				}
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
	private sealed class _003CGoodButterfingersEffect_003Ed__4 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerToolbox _003C_003E4__this;

		private int _003Ci_003E5__1;

		private GameObject _003CProjToSpawn_003E5__2;

		private GameObject _003CspawnedShot_003E5__3;

		private Projectile _003Ccomponent_003E5__4;

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
		public _003CGoodButterfingersEffect_003Ed__4(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003CProjToSpawn_003E5__2 = null;
			_003CspawnedShot_003E5__3 = null;
			_003Ccomponent_003E5__4 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00db: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0230: Unknown result type (might be due to invalid IL or missing references)
			//IL_023a: Expected O, but got Unknown
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
				_003Ci_003E5__1 = 0;
				break;
			case 2:
				_003C_003E1__state = -1;
				_003CProjToSpawn_003E5__2 = null;
				_003CspawnedShot_003E5__3 = null;
				_003Ccomponent_003E5__4 = null;
				_003Ci_003E5__1++;
				break;
			}
			if (_003Ci_003E5__1 < 6)
			{
				ref GameObject reference = ref _003CProjToSpawn_003E5__2;
				PickupObject byId = PickupObjectDatabase.GetById(503);
				reference = ((Component)((Gun)((byId is Gun) ? byId : null)).DefaultModule.projectiles[0]).gameObject;
				if (Random.value <= 0.5f)
				{
					ref GameObject reference2 = ref _003CProjToSpawn_003E5__2;
					PickupObject byId2 = PickupObjectDatabase.GetById(512);
					reference2 = ((Component)((Gun)((byId2 is Gun) ? byId2 : null)).DefaultModule.projectiles[0]).gameObject;
				}
				_003CspawnedShot_003E5__3 = ProjSpawnHelper.SpawnProjectileTowardsPoint(_003CProjToSpawn_003E5__2, ((GameActor)_003C_003E4__this.m_attachedPlayer).CenterPosition, Vector2.op_Implicit(_003C_003E4__this.m_attachedPlayer.unadjustedAimPoint), 0f, 10f, _003C_003E4__this.m_attachedPlayer);
				_003Ccomponent_003E5__4 = _003CspawnedShot_003E5__3.GetComponent<Projectile>();
				if ((Object)(object)_003Ccomponent_003E5__4 != (Object)null)
				{
					_003Ccomponent_003E5__4.Owner = (GameActor)(object)_003C_003E4__this.m_attachedPlayer;
					_003Ccomponent_003E5__4.Shooter = ((BraveBehaviour)_003C_003E4__this.m_attachedPlayer).specRigidbody;
					ProjectileData baseData = _003Ccomponent_003E5__4.baseData;
					baseData.damage *= _003C_003E4__this.m_attachedPlayer.stats.GetStatValue((StatType)5);
					ProjectileData baseData2 = _003Ccomponent_003E5__4.baseData;
					baseData2.speed *= _003C_003E4__this.m_attachedPlayer.stats.GetStatValue((StatType)6);
					ProjectileData baseData3 = _003Ccomponent_003E5__4.baseData;
					baseData3.force *= _003C_003E4__this.m_attachedPlayer.stats.GetStatValue((StatType)12);
					ProjectileData baseData4 = _003Ccomponent_003E5__4.baseData;
					baseData4.range *= _003C_003E4__this.m_attachedPlayer.stats.GetStatValue((StatType)26);
					_003C_003E4__this.m_attachedPlayer.DoPostProcessProjectile(_003Ccomponent_003E5__4);
				}
				_003C_003E2__current = (object)new WaitForSeconds(0.2f);
				_003C_003E1__state = 2;
				return true;
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
	private sealed class _003CHandleRageDur_003Ed__23 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public float dur;

		public PlayerToolbox _003C_003E4__this;

		private float _003Celapsed_003E5__1;

		private float _003CparticleCounter_003E5__2;

		private int _003Cnum_003E5__3;

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
		public _003CHandleRageDur_003Ed__23(int _003C_003E1__state)
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
			//IL_007c: Unknown result type (might be due to invalid IL or missing references)
			//IL_010b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0147: Unknown result type (might be due to invalid IL or missing references)
			//IL_014c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0156: Unknown result type (might be due to invalid IL or missing references)
			//IL_0162: Unknown result type (might be due to invalid IL or missing references)
			//IL_0168: Invalid comparison between Unknown and I4
			//IL_0262: Unknown result type (might be due to invalid IL or missing references)
			//IL_026c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0281: Unknown result type (might be due to invalid IL or missing references)
			//IL_028b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0290: Unknown result type (might be due to invalid IL or missing references)
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E4__this.remainingRageTime = dur;
				_003C_003E4__this.m_attachedPlayer.stats.RecalculateStats(_003C_003E4__this.m_attachedPlayer, true, false);
				_003C_003E4__this.instanceVFX = ((GameActor)_003C_003E4__this.m_attachedPlayer).PlayEffectOnActor(RageVFX, new Vector3(0f, 1.375f, 0f), true, true, false);
				_003C_003E4__this.m_attachedPlayer.ownerlessStatModifiers.Add(DoubleDamageStatMod);
				_003C_003E4__this.m_attachedPlayer.stats.RecalculateStats(_003C_003E4__this.m_attachedPlayer, true, false);
				_003Celapsed_003E5__1 = 0f;
				_003CparticleCounter_003E5__2 = 0f;
				break;
			case 1:
				_003C_003E1__state = -1;
				break;
			}
			if (_003Celapsed_003E5__1 < _003C_003E4__this.remainingRageTime)
			{
				_003Celapsed_003E5__1 += BraveTime.DeltaTime;
				_003C_003E4__this.m_attachedPlayer.baseFlatColorOverride = Vector3Extensions.WithAlpha(_003C_003E4__this.flatColorOverride, Mathf.Lerp(_003C_003E4__this.flatColorOverride.a, 0f, Mathf.Clamp01(_003Celapsed_003E5__1 - (_003C_003E4__this.remainingRageTime - 1f))));
				if ((int)GameManager.Options.ShaderQuality != 0 && (int)GameManager.Options.ShaderQuality != 3 && Object.op_Implicit((Object)(object)_003C_003E4__this.m_attachedPlayer) && _003C_003E4__this.m_attachedPlayer.IsVisible && !((GameActor)_003C_003E4__this.m_attachedPlayer).IsFalling)
				{
					_003CparticleCounter_003E5__2 += BraveTime.DeltaTime * 40f;
					if (Object.op_Implicit((Object)(object)_003C_003E4__this.instanceVFX) && _003Celapsed_003E5__1 > 1f)
					{
						_003C_003E4__this.instanceVFX.GetComponent<tk2dSpriteAnimator>().PlayAndDestroyObject("rage_face_vfx_out", (Action)null);
						_003C_003E4__this.instanceVFX = null;
					}
					if (_003CparticleCounter_003E5__2 > 1f)
					{
						_003Cnum_003E5__3 = Mathf.FloorToInt(_003CparticleCounter_003E5__2);
						_003CparticleCounter_003E5__2 %= 1f;
						GlobalSparksDoer.DoRandomParticleBurst(_003Cnum_003E5__3, Vector2Extensions.ToVector3ZisY(((BraveBehaviour)_003C_003E4__this.m_attachedPlayer).sprite.WorldBottomLeft, 0f), Vector2Extensions.ToVector3ZisY(((BraveBehaviour)_003C_003E4__this.m_attachedPlayer).sprite.WorldTopRight, 0f), Vector3.up, 90f, 0.5f, (float?)null, (float?)null, (Color?)null, (SparksType)1);
					}
				}
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			if (Object.op_Implicit((Object)(object)_003C_003E4__this.instanceVFX))
			{
				_003C_003E4__this.instanceVFX.GetComponent<tk2dSpriteAnimator>().PlayAndDestroyObject("rage_face_vfx_out", (Action)null);
			}
			_003C_003E4__this.m_attachedPlayer.ownerlessStatModifiers.Remove(DoubleDamageStatMod);
			_003C_003E4__this.m_attachedPlayer.stats.RecalculateStats(_003C_003E4__this.m_attachedPlayer, true, false);
			_003C_003E4__this.remainingRageTime = 0f;
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
	private sealed class _003CHandleTimedStatModifier_003Ed__30 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public StatType statToBoost;

		public float amount;

		public float dur;

		public ModifyMethod method;

		public PlayerToolbox _003C_003E4__this;

		private StatModifier _003CtimedMod_003E5__1;

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
		public _003CHandleTimedStatModifier_003Ed__30(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003CtimedMod_003E5__1 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_0024: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_0037: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_0048: Unknown result type (might be due to invalid IL or missing references)
			//IL_0052: Expected O, but got Unknown
			//IL_0098: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a2: Expected O, but got Unknown
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003CtimedMod_003E5__1 = new StatModifier
				{
					amount = amount,
					statToBoost = statToBoost,
					modifyType = method
				};
				_003C_003E4__this.m_attachedPlayer.ownerlessStatModifiers.Add(_003CtimedMod_003E5__1);
				_003C_003E4__this.m_attachedPlayer.stats.RecalculateStats(_003C_003E4__this.m_attachedPlayer, false, false);
				_003C_003E2__current = (object)new WaitForSeconds(dur);
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				_003C_003E4__this.m_attachedPlayer.ownerlessStatModifiers.Remove(_003CtimedMod_003E5__1);
				_003C_003E4__this.m_attachedPlayer.stats.RecalculateStats(_003C_003E4__this.m_attachedPlayer, false, false);
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
	private sealed class _003CPostDamageCheck_003Ed__21 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerController player;

		public PlayerToolbox _003C_003E4__this;

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
		public _003CPostDamageCheck_003Ed__21(int _003C_003E1__state)
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
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = (object)new WaitForSeconds(5f);
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				if (((BraveBehaviour)player).healthHaver.IsAlive && !SaveAPIManager.GetFlag(CustomDungeonFlags.CHEATED_DEATH_SHADE))
				{
					SaveAPIManager.SetFlag(CustomDungeonFlags.CHEATED_DEATH_SHADE, value: true);
				}
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

	private float remainingRageTime;

	public static GameObject RageVFX = ((Component)PickupObjectDatabase.GetById(353)).GetComponent<RagePassiveItem>().OverheadVFX.gameObject;

	private GameObject instanceVFX;

	public static StatModifier DoubleDamageStatMod;

	public Color flatColorOverride = new Color(0.5f, 0f, 0f, 0.75f);

	private bool playerIsInvisibleForChallenge;

	private bool playerShadowInvisible;

	private StatModifier keepItCoolSpeedBuff;

	private PlayerController m_attachedPlayer;

	private bool isSecondaryPlayer;

	private int armourLastChecked;

	private int hpStatLastChecked;

	private int itemCountLastChecked;

	private int gunIDLastChecked;

	private int roomsSinceAllJamAmmoDrop;

	private void Start()
	{
		//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c6: Expected O, but got Unknown
		//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Expected O, but got Unknown
		//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0219: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Expected O, but got Unknown
		m_attachedPlayer = ((Component)this).GetComponent<PlayerController>();
		if (Object.op_Implicit((Object)(object)m_attachedPlayer))
		{
			PlayerController attachedPlayer = m_attachedPlayer;
			attachedPlayer.OnAnyEnemyReceivedDamage = (Action<float, bool, HealthHaver>)Delegate.Combine(attachedPlayer.OnAnyEnemyReceivedDamage, new Action<float, bool, HealthHaver>(OnPlayerDamagedEnemy));
			m_attachedPlayer.PostProcessThrownGun += PostProcessThrownGun;
			m_attachedPlayer.PostProcessProjectile += PostProcessProjectile;
			m_attachedPlayer.PostProcessBeam += PostProcessBeam;
			PlayerController attachedPlayer2 = m_attachedPlayer;
			attachedPlayer2.OnHitByProjectile = (Action<Projectile, PlayerController>)Delegate.Combine(attachedPlayer2.OnHitByProjectile, new Action<Projectile, PlayerController>(OnHitByProjectile));
			((BraveBehaviour)m_attachedPlayer).healthHaver.OnDamaged += new OnDamagedEvent(OnDamaged);
			HealthHaver healthHaver = ((BraveBehaviour)m_attachedPlayer).healthHaver;
			healthHaver.ModifyDamage = (Action<HealthHaver, ModifyDamageEventArgs>)Delegate.Combine(healthHaver.ModifyDamage, new Action<HealthHaver, ModifyDamageEventArgs>(ModifyDamage));
			PlayerController attachedPlayer3 = m_attachedPlayer;
			attachedPlayer3.OnEnteredCombat = (Action)Delegate.Combine(attachedPlayer3.OnEnteredCombat, new Action(EnteredCombat));
			m_attachedPlayer.OnRoomClearEvent += ClearedRoom;
			PlayerController attachedPlayer4 = m_attachedPlayer;
			attachedPlayer4.OnNewFloorLoaded = (Action<PlayerController>)Delegate.Combine(attachedPlayer4.OnNewFloorLoaded, new Action<PlayerController>(NewFloor));
			m_attachedPlayer.PostProcessThrownGun += PostProcessThrownGun;
			if ((Object)(object)GameManager.Instance.SecondaryPlayer != (Object)null && (Object)(object)GameManager.Instance.SecondaryPlayer == (Object)(object)m_attachedPlayer)
			{
				isSecondaryPlayer = true;
			}
		}
		roomsSinceAllJamAmmoDrop = 0;
		DoubleDamageStatMod = new StatModifier();
		DoubleDamageStatMod.statToBoost = (StatType)5;
		DoubleDamageStatMod.amount = 2f;
		DoubleDamageStatMod.modifyType = (ModifyMethod)1;
		keepItCoolSpeedBuff = new StatModifier();
		keepItCoolSpeedBuff.statToBoost = (StatType)0;
		keepItCoolSpeedBuff.amount = 2.5f;
		keepItCoolSpeedBuff.modifyType = (ModifyMethod)0;
	}

	private void NewFloor(PlayerController self)
	{
	}

	private void EnteredCombat()
	{
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Expected O, but got Unknown
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		if (!Object.op_Implicit((Object)(object)m_attachedPlayer) || m_attachedPlayer.CurrentRoom == null || !CurseManager.CurseIsActive("Curse of The Flames"))
		{
			return;
		}
		for (int i = 0; i < 5; i++)
		{
			RoomHandler room = m_attachedPlayer.CurrentRoom;
			List<IntVector2> exits = room.roomCells.FindAll((IntVector2 x) => !room.roomCellsWithoutExits.Contains(x));
			IntVector2? randomAvailableCell = room.GetRandomAvailableCell((IntVector2?)null, (CellTypes?)(CellTypes)2, false, (CellValidator)((IntVector2 x) => !exits.Exists((IntVector2 x2) => Vector2.Distance(((IntVector2)(ref x)).ToVector2(), ((IntVector2)(ref x2)).ToVector2()) < 4f)));
			if (randomAvailableCell.HasValue)
			{
				IntVector2 value = randomAvailableCell.Value;
				DeadlyDeadlyGoopManager val = null;
				val = ((!GameManagerUtility.AnyPlayerHasActiveSynergy(GameManager.Instance, "The Last Crusade")) ? DeadlyDeadlyGoopManager.GetGoopManagerForGoopType(EasyGoopDefinitions.EnemyFriendlyFireGoop) : DeadlyDeadlyGoopManager.GetGoopManagerForGoopType(EasyGoopDefinitions.PlayerFriendlyFireGoop));
				val.TimedAddGoopCircle(((IntVector2)(ref value)).ToVector2(), Random.Range(2.5f, 4f), 0.75f, true);
			}
		}
		DeadlyDeadlyGoopManager.DelayedClearGoopsInRadius(((GameActor)m_attachedPlayer).CenterPosition, 5f);
	}

	private void OnDamaged(float resultValue, float maxValue, CoreDamageTypes damageTypes, DamageCategory damageCategory, Vector2 damageDirection)
	{
		if ((Object)(object)m_attachedPlayer != (Object)null && (Object)(object)((GameActor)m_attachedPlayer).CurrentGun != (Object)null && ((PickupObject)((GameActor)m_attachedPlayer).CurrentGun).CanActuallyBeDropped(m_attachedPlayer) && CurseManager.CurseIsActive("Curse of Butterfingers"))
		{
			if (GameManagerUtility.AnyPlayerHasActiveSynergy(GameManager.Instance, "The Last Crusade"))
			{
				((MonoBehaviour)this).StartCoroutine(GoodButterfingersEffect());
			}
			else
			{
				((MonoBehaviour)this).StartCoroutine(ButterFingersGun());
			}
		}
	}

	private IEnumerator GoodButterfingersEffect()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CGoodButterfingersEffect_003Ed__4(0)
		{
			_003C_003E4__this = this
		};
	}

	private IEnumerator ButterFingersGun()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CButterFingersGun_003Ed__5(0)
		{
			_003C_003E4__this = this
		};
	}

	private void ButterfingersBabyMode(DebrisObject obj)
	{
		obj.PreventFallingInPits = true;
	}

	private IEnumerator ButterfingersLateReTeleport(Projectile proj)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CButterfingersLateReTeleport_003Ed__7(0)
		{
			_003C_003E4__this = this,
			proj = proj
		};
	}

	private void PostProcessThrownGun(Projectile gun)
	{
		if ((Object)(object)((Component)gun).GetComponentInChildren<ButterfingersedGun>() != (Object)null)
		{
			((MonoBehaviour)this).StartCoroutine(ButterfingersLateReTeleport(gun));
		}
		gun.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(gun.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(OnThrownGunHitEnemy));
	}

	private void ModifyDamage(HealthHaver player, ModifyDamageEventArgs args)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		if (args.InitialDamage > 0f && m_attachedPlayer.characterIdentity == OMITBChars.Shade)
		{
			((MonoBehaviour)GameManager.Instance).StartCoroutine(PostDamageCheck(m_attachedPlayer));
		}
	}

	private void OnHitByProjectile(Projectile bullet, PlayerController self)
	{
		if (Object.op_Implicit((Object)(object)bullet) && Object.op_Implicit((Object)(object)bullet.Owner) && bullet.Owner is AIActor && ((AIActor)/*isinst with value type is only supported in some contexts*/).EnemyGuid == "e5cffcfabfae489da61062ea20539887" && !SaveAPIManager.GetFlag(CustomDungeonFlags.HURT_BY_SHROOMER))
		{
			SaveAPIManager.SetFlag(CustomDungeonFlags.HURT_BY_SHROOMER, value: true);
		}
	}

	private void PostProcessProjectile(Projectile proj, float shit)
	{
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		if (Challenges.CurrentChallenge == ChallengeType.INVISIBLEO)
		{
			((BraveBehaviour)((BraveBehaviour)proj).sprite).renderer.enabled = false;
		}
		else if (Challenges.CurrentChallenge == ChallengeType.KEEP_IT_COOL && Random.value <= 0.4f)
		{
			proj.statusEffectsToApply.Add((GameActorEffect)(object)StaticStatusEffects.frostBulletsEffect);
			proj.AdjustPlayerProjectileTint(ExtendedColours.frostBulletsTint, 2, 0f);
		}
	}

	private void PostProcessBeam(BeamController bem)
	{
		if (Challenges.CurrentChallenge == ChallengeType.INVISIBLEO)
		{
			((BraveBehaviour)((BraveBehaviour)bem).sprite).renderer.enabled = false;
		}
	}

	private void OnPlayerDamagedEnemy(float huh, bool fatal, HealthHaver enemy)
	{
	}

	private void OnThrownGunHitEnemy(Projectile gun, SpeculativeRigidbody enemy, bool fatal)
	{
		if (Object.op_Implicit((Object)(object)enemy) && Object.op_Implicit((Object)(object)((BraveBehaviour)enemy).healthHaver) && fatal && !SaveAPIManager.GetFlag(CustomDungeonFlags.KILLEDENEMYWITHTHROWNGUN))
		{
			SaveAPIManager.SetFlag(CustomDungeonFlags.KILLEDENEMYWITHTHROWNGUN, value: true);
		}
	}

	private void ClearedRoom(PlayerController playa)
	{
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		if (!AllJammedState.AllJammedActive)
		{
			return;
		}
		if (roomsSinceAllJamAmmoDrop < 6)
		{
			roomsSinceAllJamAmmoDrop++;
			return;
		}
		roomsSinceAllJamAmmoDrop = 0;
		if (Random.value <= 0.5f)
		{
			LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetById(78)).gameObject, Vector2.op_Implicit(((BraveBehaviour)playa).specRigidbody.UnitCenter), Vector2.zero, 1f, false, true, false);
		}
		else
		{
			LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetById(600)).gameObject, Vector2.op_Implicit(((BraveBehaviour)playa).specRigidbody.UnitCenter), Vector2.zero, 1f, false, true, false);
		}
	}

	private void Update()
	{
		//IL_04a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_055c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0562: Unknown result type (might be due to invalid IL or missing references)
		//IL_0569: Unknown result type (might be due to invalid IL or missing references)
		//IL_0593: Unknown result type (might be due to invalid IL or missing references)
		if (!((Object)(object)m_attachedPlayer != (Object)null) || Dungeon.IsGenerating)
		{
			return;
		}
		if ((Object)(object)((BraveBehaviour)m_attachedPlayer).healthHaver != (Object)null && ((BraveBehaviour)m_attachedPlayer).healthHaver.Armor != (float)armourLastChecked)
		{
			if (!SaveAPIManager.GetFlag(CustomDungeonFlags.PLAYERHELDMORETHANFIVEARMOUR))
			{
				int num = 5;
				if (m_attachedPlayer.ForceZeroHealthState)
				{
					num = 11;
				}
				if (((BraveBehaviour)m_attachedPlayer).healthHaver.Armor >= (float)num)
				{
					SaveAPIManager.SetFlag(CustomDungeonFlags.PLAYERHELDMORETHANFIVEARMOUR, value: true);
				}
			}
			armourLastChecked = (int)((BraveBehaviour)m_attachedPlayer).healthHaver.Armor;
		}
		if ((Object)(object)m_attachedPlayer.stats != (Object)null && m_attachedPlayer.stats.GetStatValue((StatType)3) != (float)hpStatLastChecked)
		{
			SaveAPIManager.UpdateMaximum(CustomTrackedMaximums.MAX_HEART_CONTAINERS_EVER, m_attachedPlayer.stats.GetStatValue((StatType)3));
			hpStatLastChecked = (int)m_attachedPlayer.stats.GetStatValue((StatType)3);
		}
		if (m_attachedPlayer.passiveItems != null && m_attachedPlayer.passiveItems.Count != itemCountLastChecked)
		{
			OnInventoryItemsChanged();
			itemCountLastChecked = m_attachedPlayer.passiveItems.Count;
		}
		if (Object.op_Implicit((Object)(object)((GameActor)m_attachedPlayer).CurrentGun) && ((PickupObject)((GameActor)m_attachedPlayer).CurrentGun).PickupObjectId != gunIDLastChecked)
		{
			OnCurrentGunChanged();
		}
		if (Challenges.CurrentChallenge == ChallengeType.INVISIBLEO && m_attachedPlayer.IsVisible)
		{
			playerIsInvisibleForChallenge = true;
			((GameActor)m_attachedPlayer).DoDustUps = false;
			m_attachedPlayer.IsVisible = false;
		}
		if (playerIsInvisibleForChallenge && Challenges.CurrentChallenge != ChallengeType.INVISIBLEO && !m_attachedPlayer.IsVisible)
		{
			playerIsInvisibleForChallenge = false;
			((GameActor)m_attachedPlayer).DoDustUps = true;
			m_attachedPlayer.IsVisible = true;
		}
		if (playerIsInvisibleForChallenge && (Object)(object)((BraveBehaviour)m_attachedPlayer).gameActor.ShadowObject != (Object)null && ((BraveBehaviour)m_attachedPlayer).gameActor.ShadowObject.GetComponent<Renderer>().enabled && !playerShadowInvisible)
		{
			((BraveBehaviour)m_attachedPlayer).gameActor.ShadowObject.GetComponent<Renderer>().enabled = false;
			playerShadowInvisible = true;
		}
		else if (!playerIsInvisibleForChallenge && !((BraveBehaviour)m_attachedPlayer).gameActor.ShadowObject.GetComponent<Renderer>().enabled && playerShadowInvisible)
		{
			((BraveBehaviour)m_attachedPlayer).gameActor.ShadowObject.GetComponent<Renderer>().enabled = true;
			playerShadowInvisible = false;
		}
		if (Challenges.CurrentChallenge == ChallengeType.INVISIBLEO && Object.op_Implicit((Object)(object)((GameActor)m_attachedPlayer).CurrentGun) && (Object)(object)((Component)((GameActor)m_attachedPlayer).CurrentGun).GetComponent<InvisibleGun>() == (Object)null)
		{
			((Component)((GameActor)m_attachedPlayer).CurrentGun).gameObject.AddComponent<InvisibleGun>();
		}
		if (Challenges.CurrentChallenge == ChallengeType.INVISIBLEO && Object.op_Implicit((Object)(object)m_attachedPlayer.CurrentSecondaryGun) && (Object)(object)((Component)m_attachedPlayer.CurrentSecondaryGun).GetComponent<InvisibleGun>() == (Object)null)
		{
			((Component)m_attachedPlayer.CurrentSecondaryGun).gameObject.AddComponent<InvisibleGun>();
		}
		if (playerIsInvisibleForChallenge && (Object)(object)m_attachedPlayer.primaryHand != (Object)null && !m_attachedPlayer.primaryHand.ForceRenderersOff)
		{
			m_attachedPlayer.primaryHand.ForceRenderersOff = true;
		}
		if (playerIsInvisibleForChallenge && (Object)(object)m_attachedPlayer.secondaryHand != (Object)null && !m_attachedPlayer.secondaryHand.ForceRenderersOff)
		{
			m_attachedPlayer.secondaryHand.ForceRenderersOff = true;
		}
		if (Challenges.CurrentChallenge == ChallengeType.INVISIBLEO && Object.op_Implicit((Object)(object)GameUIRoot.Instance.GetReloadBarForPlayer(m_attachedPlayer)))
		{
			int playerIDX = m_attachedPlayer.PlayerIDX;
			GameUIRoot.Instance.ForceClearReload(playerIDX);
		}
		if (Challenges.CurrentChallenge == ChallengeType.KEEP_IT_COOL)
		{
			DeadlyDeadlyGoopManager goopManagerForGoopType = DeadlyDeadlyGoopManager.GetGoopManagerForGoopType(EasyGoopDefinitions.WaterGoop);
			goopManagerForGoopType.TimedAddGoopCircle(((BraveBehaviour)m_attachedPlayer).specRigidbody.UnitCenter, 2f, 0.01f, true);
			DeadlyDeadlyGoopManager.FreezeGoopsCircle(((BraveBehaviour)m_attachedPlayer).specRigidbody.UnitBottomCenter, 2f);
			if (!m_attachedPlayer.ownerlessStatModifiers.Contains(keepItCoolSpeedBuff))
			{
				m_attachedPlayer.ownerlessStatModifiers.Add(keepItCoolSpeedBuff);
				m_attachedPlayer.stats.RecalculateStats(m_attachedPlayer, false, false);
			}
			if (m_attachedPlayer.HasPickupID(256))
			{
				m_attachedPlayer.RemovePassiveItem(256);
				ChestUtility.SpawnChestEasy(m_attachedPlayer.CurrentRoom.GetBestRewardLocation(IntVector2.One * 3, (RewardLocationStyle)1, true), (ChestTier)3, false, (GeneralChestType)0, (ThreeStateValue)2, (ThreeStateValue)2);
				TextBubble.DoAmbientTalk(((BraveBehaviour)m_attachedPlayer).transform, new Vector3(1f, 2f, 0f), "Nice Try", 4f);
			}
		}
		else if (m_attachedPlayer.ownerlessStatModifiers != null && m_attachedPlayer.ownerlessStatModifiers.Contains(keepItCoolSpeedBuff))
		{
			m_attachedPlayer.ownerlessStatModifiers.Remove(keepItCoolSpeedBuff);
			m_attachedPlayer.stats.RecalculateStats(m_attachedPlayer, false, false);
		}
	}

	private void OnCurrentGunChanged()
	{
		gunIDLastChecked = ((PickupObject)((GameActor)m_attachedPlayer).CurrentGun).PickupObjectId;
	}

	private void OnInventoryItemsChanged()
	{
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Invalid comparison between Unknown and I4
		int num = 0;
		foreach (PassiveItem passiveItem in m_attachedPlayer.passiveItems)
		{
			if (((PickupObject)passiveItem).PickupObjectId == 127)
			{
				num++;
			}
		}
		if (num >= 5 && (int)m_attachedPlayer.characterIdentity == 2 && !SaveAPIManager.GetFlag(CustomDungeonFlags.ROBOT_HELD_FIVE_JUNK))
		{
			SaveAPIManager.SetFlag(CustomDungeonFlags.ROBOT_HELD_FIVE_JUNK, value: true);
		}
	}

	public void DoFakeDamage()
	{
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		HealthHaver healthHaver = ((BraveBehaviour)m_attachedPlayer).healthHaver;
		float currentHealth = healthHaver.GetCurrentHealth();
		float armor = healthHaver.Armor;
		bool flawless = m_attachedPlayer.CurrentRoom != null && !m_attachedPlayer.CurrentRoom.PlayerHasTakenDamageInThisRoom;
		bool flag = false;
		if (healthHaver.NextShotKills)
		{
			healthHaver.NextShotKills = false;
			flag = true;
		}
		bool hasCrest = healthHaver.HasCrest;
		if (armor > 0f && (m_attachedPlayer.ForceZeroHealthState || !healthHaver.NextDamageIgnoresArmor))
		{
			healthHaver.Armor += 1f;
			((BraveBehaviour)healthHaver).healthHaver.ApplyDamage(0.5f, Vector2.zero, "FAKE DAMAGE - REPORT THIS BUG", (CoreDamageTypes)0, (DamageCategory)0, true, (PixelCollider)null, false);
		}
		else if (currentHealth == 0.5f)
		{
			((BraveBehaviour)healthHaver).healthHaver.ForceSetCurrentHealth(currentHealth + 0.5f);
			((BraveBehaviour)healthHaver).healthHaver.ApplyDamage(0.5f, Vector2.zero, "FAKE DAMAGE - REPORT THIS BUG", (CoreDamageTypes)0, (DamageCategory)0, true, (PixelCollider)null, false);
		}
		else
		{
			healthHaver.ApplyDamage(0.5f, Vector2.zero, "FAKE DAMAGE - REPORT THIS BUG", (CoreDamageTypes)0, (DamageCategory)0, true, (PixelCollider)null, false);
		}
		if (flag)
		{
			healthHaver.NextShotKills = true;
		}
		if (healthHaver.Armor != armor)
		{
			healthHaver.Armor = armor;
		}
		if (healthHaver.GetCurrentHealth() != currentHealth)
		{
			((BraveBehaviour)healthHaver).healthHaver.ForceSetCurrentHealth(currentHealth);
		}
		((MonoBehaviour)GameManager.Instance).StartCoroutine(Delay(m_attachedPlayer.CurrentRoom, healthHaver, flawless, hasCrest));
	}

	private IEnumerator Delay(RoomHandler room, HealthHaver health, bool flawless, bool crest)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CDelay_003Ed__20(0)
		{
			_003C_003E4__this = this,
			room = room,
			health = health,
			flawless = flawless,
			crest = crest
		};
	}

	private IEnumerator PostDamageCheck(PlayerController player)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CPostDamageCheck_003Ed__21(0)
		{
			_003C_003E4__this = this,
			player = player
		};
	}

	public void Enrage(float dur)
	{
		if (remainingRageTime > 0f)
		{
			remainingRageTime += dur;
		}
		else
		{
			((MonoBehaviour)m_attachedPlayer).StartCoroutine(HandleRageDur(dur));
		}
	}

	private IEnumerator HandleRageDur(float dur)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CHandleRageDur_003Ed__23(0)
		{
			_003C_003E4__this = this,
			dur = dur
		};
	}

	public void DoTimedStatModifier(StatType statToBoost, float amount, float time, ModifyMethod modifyMethod = 1)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		((MonoBehaviour)m_attachedPlayer).StartCoroutine(HandleTimedStatModifier(statToBoost, amount, time, modifyMethod));
	}

	private IEnumerator HandleTimedStatModifier(StatType statToBoost, float amount, float dur, ModifyMethod method)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CHandleTimedStatModifier_003Ed__30(0)
		{
			_003C_003E4__this = this,
			statToBoost = statToBoost,
			amount = amount,
			dur = dur,
			method = method
		};
	}
}
