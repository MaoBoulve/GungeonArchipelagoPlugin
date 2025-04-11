using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Dungeonator;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Seismograph : AdvancedGunBehavior
{
	public class EarthquakeProjectileMod : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CQuake_003Ed__1 : IEnumerator<object>, IDisposable, IEnumerator
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public EarthquakeProjectileMod _003C_003E4__this;

			private RoomHandler _003Croom_003E5__1;

			private List<AIActor> _003Cenemies_003E5__2;

			private int _003Ci_003E5__3;

			private AIActor _003Cenemy_003E5__4;

			private float _003Cknockback_003E5__5;

			private float _003Cdmg_003E5__6;

			private List<GameActorEffect> _003Ceffects_003E5__7;

			private List<GameActorEffect>.Enumerator _003C_003Es__8;

			private GameActorEffect _003Ceffect_003E5__9;

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
			public _003CQuake_003Ed__1(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				_003Croom_003E5__1 = null;
				_003Cenemies_003E5__2 = null;
				_003Cenemy_003E5__4 = null;
				_003Ceffects_003E5__7 = null;
				_003C_003Es__8 = default(List<GameActorEffect>.Enumerator);
				_003Ceffect_003E5__9 = null;
				_003C_003E1__state = -2;
			}

			private bool MoveNext()
			{
				//IL_0069: Unknown result type (might be due to invalid IL or missing references)
				//IL_01fc: Unknown result type (might be due to invalid IL or missing references)
				//IL_0232: Unknown result type (might be due to invalid IL or missing references)
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
					_003Croom_003E5__1 = ProjectileUtility.GetAbsoluteRoom(_003C_003E4__this.self);
					if (_003Croom_003E5__1 != null)
					{
						Exploder.DoRadialMinorBreakableBreak(((Component)_003C_003E4__this).transform.position, 20f);
						_003Cenemies_003E5__2 = _003Croom_003E5__1.GetActiveEnemies((ActiveEnemyType)0);
						if (_003Cenemies_003E5__2 != null && _003Cenemies_003E5__2.Count > 0)
						{
							_003Ci_003E5__3 = 0;
							while (_003Ci_003E5__3 < _003Cenemies_003E5__2.Count)
							{
								_003Cenemy_003E5__4 = _003Cenemies_003E5__2[_003Ci_003E5__3];
								if (Object.op_Implicit((Object)(object)_003Cenemy_003E5__4) && Object.op_Implicit((Object)(object)((BraveBehaviour)_003Cenemy_003E5__4).healthHaver) && ((BraveBehaviour)_003Cenemy_003E5__4).healthHaver.IsAlive)
								{
									_003Cknockback_003E5__5 = 20f;
									_003Cdmg_003E5__6 = _003C_003E4__this.self.baseData.damage;
									if (Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(_003C_003E4__this.self)))
									{
										_003Cknockback_003E5__5 *= ProjectileUtility.ProjectilePlayerOwner(_003C_003E4__this.self).stats.GetStatValue((StatType)12);
										if (((BraveBehaviour)_003Cenemy_003E5__4).healthHaver.IsBoss)
										{
											_003Cdmg_003E5__6 *= ProjectileUtility.ProjectilePlayerOwner(_003C_003E4__this.self).stats.GetStatValue((StatType)22);
										}
										if (((BraveBehaviour)_003Cenemy_003E5__4).aiActor.IsBlackPhantom)
										{
											_003Cdmg_003E5__6 *= _003C_003E4__this.self.BlackPhantomDamageMultiplier;
										}
									}
									((BraveBehaviour)_003Cenemy_003E5__4).healthHaver.ApplyDamage(_003Cdmg_003E5__6, Random.insideUnitCircle, "Quake", (CoreDamageTypes)0, (DamageCategory)0, false, (PixelCollider)null, false);
									if (Object.op_Implicit((Object)(object)((BraveBehaviour)_003Cenemy_003E5__4).knockbackDoer))
									{
										((BraveBehaviour)_003Cenemy_003E5__4).knockbackDoer.ApplyKnockback(Random.insideUnitCircle, _003Cknockback_003E5__5, false);
									}
									_003Ceffects_003E5__7 = ProjectileUtility.GetFullListOfStatusEffects(_003C_003E4__this.self, false);
									if (_003Ceffects_003E5__7.Count > 0)
									{
										_003C_003Es__8 = _003Ceffects_003E5__7.GetEnumerator();
										try
										{
											while (_003C_003Es__8.MoveNext())
											{
												_003Ceffect_003E5__9 = _003C_003Es__8.Current;
												((GameActor)_003Cenemy_003E5__4).ApplyEffect(_003Ceffect_003E5__9, 1f, (Projectile)null);
												_003Ceffect_003E5__9 = null;
											}
										}
										finally
										{
											((IDisposable)_003C_003Es__8/*cast due to .constrained prefix*/).Dispose();
										}
										_003C_003Es__8 = default(List<GameActorEffect>.Enumerator);
									}
									if (Object.op_Implicit((Object)(object)((BraveBehaviour)_003Cenemy_003E5__4).behaviorSpeculator) && _003C_003E4__this.self.AppliesStun && Random.value <= _003C_003E4__this.self.StunApplyChance)
									{
										((BraveBehaviour)_003Cenemy_003E5__4).behaviorSpeculator.Stun(_003C_003E4__this.self.AppliedStunDuration, true);
									}
									_003Ceffects_003E5__7 = null;
								}
								_003Cenemy_003E5__4 = null;
								_003Ci_003E5__3++;
							}
						}
						_003Cenemies_003E5__2 = null;
					}
					Object.Destroy((Object)(object)((Component)_003C_003E4__this.self).gameObject);
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

		private Projectile self;

		public float damageToDeal;

		private void Start()
		{
			self = ((Component)this).GetComponent<Projectile>();
			((MonoBehaviour)this).StartCoroutine(Quake());
		}

		private IEnumerator Quake()
		{
			//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
			return new _003CQuake_003Ed__1(0)
			{
				_003C_003E4__this = this
			};
		}
	}

	public static int ID;

	public static void Add()
	{
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Seismograph", "seismograph");
		Game.Items.Rename("outdated_gun_mods:seismograph", "nn:seismograph");
		Seismograph seismograph = ((Component)val).gameObject.AddComponent<Seismograph>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Can Run Quake");
		GunExt.SetLongDescription((PickupObject)(object)val, "This gun is oddly good at predicting the seismic shaking of Gunymede's crust- it seems to always be fired moments before noticeable earthquakes.");
		val.SetGunSprites("seismograph");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 16);
		GunExt.SetAnimationFPS(val, val.idleAnimation, 16);
		PickupObject byId = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(601);
		gunSwitchGroup = ((Gun)((byId2 is Gun) ? byId2 : null)).gunSwitchGroup;
		val.doesScreenShake = true;
		val.gunScreenShake = StaticExplosionDatas.genericLargeExplosion.ss;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1.3f;
		val.DefaultModule.cooldownTime = 0.17f;
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		val.DefaultModule.numberOfShotsInClip = 10;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.5625f, 1.0625f, 0f);
		val.SetBaseMaxAmmo(300);
		val.gunClass = (GunClass)1;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		val2.baseData.damage = 4f;
		val2.pierceMinorBreakables = true;
		PierceProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<PierceProjModifier>(((Component)val2).gameObject);
		orAddComponent.penetratesBreakables = true;
		orAddComponent.penetration = 1;
		((Component)val2).gameObject.AddComponent<EarthquakeProjectileMod>();
		((PickupObject)val).quality = (ItemQuality)4;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
	}
}
