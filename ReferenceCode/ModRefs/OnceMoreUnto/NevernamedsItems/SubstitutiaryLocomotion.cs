using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

internal class SubstitutiaryLocomotion : PlayerItem
{
	[CompilerGenerated]
	private sealed class _003CHandleEffect_003Ed__3 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerController user;

		private List<SpeculativeRigidbody> _003Ctrg1_003E5__1;

		private List<SpeculativeRigidbody> _003Ctrg2_003E5__2;

		private List<SpeculativeRigidbody> _003Ctrg3_003E5__3;

		private List<SpeculativeRigidbody> _003Ctrg4_003E5__4;

		private int _003Citerator_003E5__5;

		private List<MinorBreakable>.Enumerator _003C_003Es__6;

		private MinorBreakable _003Cbr_003E5__7;

		private RoomHandler _003CrH_003E5__8;

		private int _003C_003Es__9;

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
		public _003CHandleEffect_003Ed__3(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003Ctrg1_003E5__1 = null;
			_003Ctrg2_003E5__2 = null;
			_003Ctrg3_003E5__3 = null;
			_003Ctrg4_003E5__4 = null;
			_003C_003Es__6 = default(List<MinorBreakable>.Enumerator);
			_003Cbr_003E5__7 = null;
			_003CrH_003E5__8 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_0301: Unknown result type (might be due to invalid IL or missing references)
			//IL_031d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0327: Expected O, but got Unknown
			//IL_0349: Unknown result type (might be due to invalid IL or missing references)
			//IL_0365: Unknown result type (might be due to invalid IL or missing references)
			//IL_036f: Expected O, but got Unknown
			//IL_0391: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b7: Expected O, but got Unknown
			//IL_02b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_02df: Expected O, but got Unknown
			//IL_0110: Unknown result type (might be due to invalid IL or missing references)
			//IL_017a: Unknown result type (might be due to invalid IL or missing references)
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				incanting = true;
				AkSoundEngine.PostEvent("TregunaMekoidesTrecorumSatisDee", ((Component)user).gameObject);
				_003Ctrg1_003E5__1 = new List<SpeculativeRigidbody>();
				_003Ctrg2_003E5__2 = new List<SpeculativeRigidbody>();
				_003Ctrg3_003E5__3 = new List<SpeculativeRigidbody>();
				_003Ctrg4_003E5__4 = new List<SpeculativeRigidbody>();
				_003Citerator_003E5__5 = 1;
				_003C_003Es__6 = StaticReferenceManager.AllMinorBreakables.GetEnumerator();
				try
				{
					while (_003C_003Es__6.MoveNext())
					{
						_003Cbr_003E5__7 = _003C_003Es__6.Current;
						if (Object.op_Implicit((Object)(object)_003Cbr_003E5__7) && !_003Cbr_003E5__7.IsBroken && (Object)(object)((BraveBehaviour)_003Cbr_003E5__7).specRigidbody != (Object)null && (Object)(object)((Component)_003Cbr_003E5__7).GetComponent<PathfindingProjectile>() == (Object)null)
						{
							_003CrH_003E5__8 = Vector3Extensions.GetAbsoluteRoom(((BraveBehaviour)_003Cbr_003E5__7).specRigidbody.GetUnitCenter((ColliderType)2));
							if (_003CrH_003E5__8 != null && _003CrH_003E5__8 == user.CurrentRoom)
							{
								_003Cbr_003E5__7.OnlyBrokenByCode = true;
								_003Cbr_003E5__7.isInvulnerableToGameActors = true;
								_003Cbr_003E5__7.resistsExplosions = true;
								((BraveBehaviour)_003Cbr_003E5__7).specRigidbody.PrimaryPixelCollider.CollisionLayer = (CollisionLayer)4;
								((BraveBehaviour)_003Cbr_003E5__7).specRigidbody.Reinitialize();
								int num = _003Citerator_003E5__5;
								_003C_003Es__9 = num;
								switch (_003C_003Es__9)
								{
								case 1:
									_003Ctrg1_003E5__1.Add(((BraveBehaviour)_003Cbr_003E5__7).specRigidbody);
									_003Citerator_003E5__5++;
									break;
								case 2:
									_003Ctrg2_003E5__2.Add(((BraveBehaviour)_003Cbr_003E5__7).specRigidbody);
									_003Citerator_003E5__5++;
									break;
								case 3:
									_003Ctrg3_003E5__3.Add(((BraveBehaviour)_003Cbr_003E5__7).specRigidbody);
									_003Citerator_003E5__5++;
									break;
								case 4:
									_003Ctrg4_003E5__4.Add(((BraveBehaviour)_003Cbr_003E5__7).specRigidbody);
									_003Citerator_003E5__5 = 1;
									break;
								}
							}
							_003CrH_003E5__8 = null;
						}
						_003Cbr_003E5__7 = null;
					}
				}
				finally
				{
					((IDisposable)_003C_003Es__6/*cast due to .constrained prefix*/).Dispose();
				}
				_003C_003Es__6 = default(List<MinorBreakable>.Enumerator);
				((MonoBehaviour)user).StartCoroutine(LifeWave(_003Ctrg1_003E5__1, ((GameActor)user).CenterPosition, user));
				_003C_003E2__current = (object)new WaitForSeconds(2f);
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				((MonoBehaviour)user).StartCoroutine(LifeWave(_003Ctrg2_003E5__2, ((GameActor)user).CenterPosition, user));
				_003C_003E2__current = (object)new WaitForSeconds(2f);
				_003C_003E1__state = 2;
				return true;
			case 2:
				_003C_003E1__state = -1;
				((MonoBehaviour)user).StartCoroutine(LifeWave(_003Ctrg3_003E5__3, ((GameActor)user).CenterPosition, user));
				_003C_003E2__current = (object)new WaitForSeconds(1.5f);
				_003C_003E1__state = 3;
				return true;
			case 3:
				_003C_003E1__state = -1;
				((MonoBehaviour)user).StartCoroutine(LifeWave(_003Ctrg4_003E5__4, ((GameActor)user).CenterPosition, user));
				_003C_003E2__current = (object)new WaitForSeconds(2f);
				_003C_003E1__state = 4;
				return true;
			case 4:
				_003C_003E1__state = -1;
				incanting = false;
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
	private sealed class _003CLifeWave_003Ed__4 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public List<SpeculativeRigidbody> waveTargets;

		public Vector2 waveCenter;

		public PlayerController player;

		private float _003Cm_timer_003E5__1;

		private float _003Cm_prevWaveDist_003E5__2;

		private float _003Cnum_003E5__3;

		private int _003Ci_003E5__4;

		private SpeculativeRigidbody _003CindivTarget_003E5__5;

		private Vector2 _003CunitCenter_003E5__6;

		private float _003Cnum2_003E5__7;

		private int _003Ci_003E5__8;

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
		public _003CLifeWave_003Ed__4(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003CindivTarget_003E5__5 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_00db: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003Cm_timer_003E5__1 = 1.5f - BraveTime.DeltaTime;
				_003Cm_prevWaveDist_003E5__2 = 0f;
				Exploder.DoDistortionWave(waveCenter, 0.5f, 0.04f, 20f, 1.5f);
				break;
			case 1:
				_003C_003E1__state = -1;
				break;
			}
			if (_003Cm_timer_003E5__1 > 0f)
			{
				_003Cm_timer_003E5__1 -= BraveTime.DeltaTime;
				_003Cnum_003E5__3 = BraveMathCollege.LinearToSmoothStepInterpolate(0f, 20f, 1f - _003Cm_timer_003E5__1 / 1.5f);
				if (waveTargets != null)
				{
					_003Ci_003E5__4 = 0;
					while (_003Ci_003E5__4 < waveTargets.Count)
					{
						_003CindivTarget_003E5__5 = waveTargets[_003Ci_003E5__4];
						_003CunitCenter_003E5__6 = _003CindivTarget_003E5__5.GetUnitCenter((ColliderType)2);
						_003Cnum2_003E5__7 = Vector2.Distance(_003CunitCenter_003E5__6, waveCenter);
						if (_003Cnum2_003E5__7 >= _003Cm_prevWaveDist_003E5__2 - 0.25f && _003Cnum2_003E5__7 <= _003Cnum_003E5__3 + 0.25f && (Object)(object)_003CindivTarget_003E5__5 != (Object)null && Object.op_Implicit((Object)(object)((BraveBehaviour)_003CindivTarget_003E5__5).minorBreakable) && !((BraveBehaviour)_003CindivTarget_003E5__5).minorBreakable.IsBroken)
						{
							BringToLife(((Component)_003CindivTarget_003E5__5).gameObject, player);
						}
						_003CindivTarget_003E5__5 = null;
						_003Ci_003E5__4++;
					}
				}
				_003Ci_003E5__8 = waveTargets.Count - 1;
				while (_003Ci_003E5__8 >= 0)
				{
					if (Object.op_Implicit((Object)(object)waveTargets[_003Ci_003E5__8]) && Object.op_Implicit((Object)(object)((Component)waveTargets[_003Ci_003E5__8]).gameObject) && (Object)(object)((Component)waveTargets[_003Ci_003E5__8]).gameObject.GetComponent<PathfindingProjectile>() == (Object)null && Object.op_Implicit((Object)(object)((BraveBehaviour)waveTargets[_003Ci_003E5__8]).minorBreakable) && !((BraveBehaviour)waveTargets[_003Ci_003E5__8]).minorBreakable.IsBroken)
					{
						BringToLife(((Component)waveTargets[_003Ci_003E5__8]).gameObject, player);
					}
					_003Ci_003E5__8--;
				}
				_003Cm_prevWaveDist_003E5__2 = _003Cnum_003E5__3;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
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

	public static bool incanting;

	public static void Init()
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<SubstitutiaryLocomotion>("Substitutiary Locomotion", "Star of Astoroth", "Breathes ancient life into lifeless objects.\n\nAn ancient emblem of witchcraft. The words \"Treguna mekoides trecorum satis dee\" are inscribed around the rim.", "substitutiarylocomotion_icon", assetbundle: true);
		PlayerItem val = (PlayerItem)(object)((obj is PlayerItem) ? obj : null);
		ItemBuilder.SetCooldownType(val, (CooldownType)1, 400f);
		val.consumable = false;
		((PickupObject)val).quality = (ItemQuality)2;
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)2, 1f);
	}

	public override void DoEffect(PlayerController user)
	{
		((MonoBehaviour)user).StartCoroutine(HandleEffect(user));
	}

	private static IEnumerator HandleEffect(PlayerController user)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CHandleEffect_003Ed__3(0)
		{
			user = user
		};
	}

	private static IEnumerator LifeWave(List<SpeculativeRigidbody> waveTargets, Vector2 waveCenter, PlayerController player)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CLifeWave_003Ed__4(0)
		{
			waveTargets = waveTargets,
			waveCenter = waveCenter,
			player = player
		};
	}

	public static void BringToLife(GameObject thingy, PlayerController owner)
	{
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)thingy.GetComponent<PathfindingProjectile>() != (Object)null)
		{
			return;
		}
		IPlayerInteractable @interface = GameObjectExtensions.GetInterface<IPlayerInteractable>(thingy);
		if (@interface != null)
		{
			RoomHandler roomFromPosition = GameManager.Instance.Dungeon.GetRoomFromPosition(Vector3Extensions.IntXY(thingy.transform.position, (VectorConversions)2));
			if (roomFromPosition.IsRegistered(@interface))
			{
				roomFromPosition.DeregisterInteractable(@interface);
			}
		}
		MinorBreakable component = thingy.GetComponent<MinorBreakable>();
		if (Object.op_Implicit((Object)(object)component))
		{
			thingy.GetComponent<MinorBreakable>().OnlyBrokenByCode = true;
			thingy.GetComponent<MinorBreakable>().isInvulnerableToGameActors = true;
			thingy.GetComponent<MinorBreakable>().resistsExplosions = true;
		}
		PathfindingProjectile orAddComponent = GameObjectExtensions.GetOrAddComponent<PathfindingProjectile>(thingy);
		((Projectile)orAddComponent).shouldRotate = false;
		((Projectile)orAddComponent).Shooter = ((BraveBehaviour)owner).specRigidbody;
		((Projectile)orAddComponent).Owner = (GameActor)(object)owner;
		((Projectile)orAddComponent).baseData.damage = 8f * owner.stats.GetStatValue((StatType)5);
		((Projectile)orAddComponent).baseData.range = 200f;
		((Projectile)orAddComponent).baseData.speed = Random.Range(5, 8);
		((Projectile)orAddComponent).collidesWithProjectiles = false;
		GameObjectExtensions.GetOrAddComponent<HitEffectHandler>(((Component)orAddComponent).gameObject);
		((Component)orAddComponent).gameObject.AddComponent<PierceProjModifier>();
		((Component)orAddComponent).gameObject.AddComponent<PierceDeadActors>();
		((Projectile)orAddComponent).pierceMinorBreakables = true;
		((Projectile)orAddComponent).baseData.force = 30f;
		ref ProjectileImpactVFXPool hitEffects = ref ((Projectile)orAddComponent).hitEffects;
		PickupObject byId = PickupObjectDatabase.GetById(541);
		hitEffects = ((Gun)((byId is Gun) ? byId : null)).DefaultModule.chargeProjectiles[0].Projectile.hitEffects;
		((Projectile)orAddComponent).enemyImpactEventName = "";
		((BraveBehaviour)orAddComponent).specRigidbody.CollideWithTileMap = false;
		((BraveBehaviour)orAddComponent).specRigidbody.PrimaryPixelCollider.CollisionLayer = (CollisionLayer)4;
		((Projectile)orAddComponent).UpdateCollisionMask();
		((BraveBehaviour)orAddComponent).specRigidbody.Reinitialize();
		((Projectile)orAddComponent).Start();
		((Component)orAddComponent).gameObject.AddComponent<GravityGun.GravityGunObjectDeathHandler>();
	}

	public override bool CanBeUsed(PlayerController user)
	{
		return !incanting;
	}
}
