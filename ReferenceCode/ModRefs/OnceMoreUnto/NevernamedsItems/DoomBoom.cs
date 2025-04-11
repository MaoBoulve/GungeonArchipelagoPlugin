using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.Assetbundle;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class DoomBoom : GunBehaviour
{
	public class DoomExplosion : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CExplode_003Ed__5 : IEnumerator<object>, IDisposable, IEnumerator
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Projectile source;

			public Vector2 position;

			public DoomExplosion _003C_003E4__this;

			private float _003CdamageRadius_003E5__1;

			private float _003CbulletDeletionSqrRadius_003E5__2;

			private GameObject _003CgameObject_003E5__3;

			private GameObject _003CgameObject2_003E5__4;

			private List<HealthHaver> _003CallHealth_003E5__5;

			private List<MinorBreakable> _003CallBreakables_003E5__6;

			private int _003Cj_003E5__7;

			private HealthHaver _003ChealthHaver_003E5__8;

			private int _003Ck_003E5__9;

			private SpeculativeRigidbody _003CbodyRigidbody_003E5__10;

			private Vector2 _003Cvector_003E5__11;

			private Vector2 _003Cvector2_003E5__12;

			private float _003Cnum_003E5__13;

			private string _003CenemiesString_003E5__14;

			private bool _003CwasAlive_003E5__15;

			private KnockbackDoer _003CknockbackDoer_003E5__16;

			private int _003Cl_003E5__17;

			private MinorBreakable _003CminorBreakable_003E5__18;

			private Vector2 _003Cvector3_003E5__19;

			private int _003Ci_003E5__20;

			private Vector2 _003Cvector_003E5__21;

			private Vector2 _003Cvector2_003E5__22;

			private float _003CsqrMagnitude_003E5__23;

			private float _003Cnum2_003E5__24;

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
			public _003CExplode_003Ed__5(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				_003CgameObject_003E5__3 = null;
				_003CgameObject2_003E5__4 = null;
				_003CallHealth_003E5__5 = null;
				_003CallBreakables_003E5__6 = null;
				_003ChealthHaver_003E5__8 = null;
				_003CbodyRigidbody_003E5__10 = null;
				_003CenemiesString_003E5__14 = null;
				_003CknockbackDoer_003E5__16 = null;
				_003CminorBreakable_003E5__18 = null;
				_003C_003E1__state = -2;
			}

			private bool MoveNext()
			{
				//IL_0048: Unknown result type (might be due to invalid IL or missing references)
				//IL_004d: Unknown result type (might be due to invalid IL or missing references)
				//IL_0052: Unknown result type (might be due to invalid IL or missing references)
				//IL_0067: Unknown result type (might be due to invalid IL or missing references)
				//IL_0071: Expected O, but got Unknown
				//IL_007d: Unknown result type (might be due to invalid IL or missing references)
				//IL_0082: Unknown result type (might be due to invalid IL or missing references)
				//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
				//IL_00bf: Expected O, but got Unknown
				//IL_0549: Unknown result type (might be due to invalid IL or missing references)
				//IL_057e: Unknown result type (might be due to invalid IL or missing references)
				//IL_0583: Unknown result type (might be due to invalid IL or missing references)
				//IL_0588: Unknown result type (might be due to invalid IL or missing references)
				//IL_058f: Unknown result type (might be due to invalid IL or missing references)
				//IL_0595: Unknown result type (might be due to invalid IL or missing references)
				//IL_059a: Unknown result type (might be due to invalid IL or missing references)
				//IL_059f: Unknown result type (might be due to invalid IL or missing references)
				//IL_05fc: Unknown result type (might be due to invalid IL or missing references)
				//IL_0607: Unknown result type (might be due to invalid IL or missing references)
				//IL_0611: Unknown result type (might be due to invalid IL or missing references)
				//IL_0627: Unknown result type (might be due to invalid IL or missing references)
				//IL_0172: Unknown result type (might be due to invalid IL or missing references)
				//IL_0192: Unknown result type (might be due to invalid IL or missing references)
				//IL_0498: Unknown result type (might be due to invalid IL or missing references)
				//IL_049e: Unknown result type (might be due to invalid IL or missing references)
				//IL_04a3: Unknown result type (might be due to invalid IL or missing references)
				//IL_04a8: Unknown result type (might be due to invalid IL or missing references)
				//IL_04d2: Unknown result type (might be due to invalid IL or missing references)
				//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
				//IL_01db: Unknown result type (might be due to invalid IL or missing references)
				//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
				//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
				//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
				//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
				//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
				//IL_027f: Unknown result type (might be due to invalid IL or missing references)
				//IL_0284: Unknown result type (might be due to invalid IL or missing references)
				//IL_0289: Unknown result type (might be due to invalid IL or missing references)
				//IL_0290: Unknown result type (might be due to invalid IL or missing references)
				//IL_0296: Unknown result type (might be due to invalid IL or missing references)
				//IL_029b: Unknown result type (might be due to invalid IL or missing references)
				//IL_02a0: Unknown result type (might be due to invalid IL or missing references)
				//IL_021d: Unknown result type (might be due to invalid IL or missing references)
				//IL_0222: Unknown result type (might be due to invalid IL or missing references)
				//IL_0229: Unknown result type (might be due to invalid IL or missing references)
				//IL_022f: Unknown result type (might be due to invalid IL or missing references)
				//IL_0234: Unknown result type (might be due to invalid IL or missing references)
				//IL_0239: Unknown result type (might be due to invalid IL or missing references)
				//IL_0240: Unknown result type (might be due to invalid IL or missing references)
				//IL_0250: Unknown result type (might be due to invalid IL or missing references)
				//IL_0260: Unknown result type (might be due to invalid IL or missing references)
				//IL_0341: Unknown result type (might be due to invalid IL or missing references)
				//IL_030d: Unknown result type (might be due to invalid IL or missing references)
				//IL_0393: Unknown result type (might be due to invalid IL or missing references)
				switch (_003C_003E1__state)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					_003CdamageRadius_003E5__1 = 2.5f;
					_003CbulletDeletionSqrRadius_003E5__2 = _003CdamageRadius_003E5__1 * _003CdamageRadius_003E5__1;
					_003CgameObject_003E5__3 = SpawnManager.SpawnVFX(vfx, Vector2.op_Implicit(position), Quaternion.identity);
					_003CgameObject2_003E5__4 = new GameObject("SoundSource");
					_003CgameObject2_003E5__4.transform.position = Vector2.op_Implicit(position);
					AkSoundEngine.PostEvent("Play_WPN_grenade_blast_01", _003CgameObject2_003E5__4);
					Object.Destroy((Object)(object)_003CgameObject2_003E5__4, 5f);
					_003C_003E2__current = (object)new WaitForSeconds(0.1f);
					_003C_003E1__state = 1;
					return true;
				case 1:
					_003C_003E1__state = -1;
					_003CallHealth_003E5__5 = StaticReferenceManager.AllHealthHavers;
					if (_003CallHealth_003E5__5 != null)
					{
						_003Cj_003E5__7 = 0;
						while (_003Cj_003E5__7 < _003CallHealth_003E5__5.Count)
						{
							_003ChealthHaver_003E5__8 = _003CallHealth_003E5__5[_003Cj_003E5__7];
							if (Object.op_Implicit((Object)(object)_003ChealthHaver_003E5__8) && Object.op_Implicit((Object)(object)((BraveBehaviour)_003ChealthHaver_003E5__8).aiActor) && ((BraveBehaviour)_003ChealthHaver_003E5__8).aiActor.HasBeenEngaged && (Object)(object)((BraveBehaviour)_003ChealthHaver_003E5__8).aiActor.CompanionOwner == (Object)null && !_003ChealthHaver_003E5__8.isPlayerCharacter && Vector3Extensions.GetAbsoluteRoom(position) == Vector3Extensions.GetAbsoluteRoom(((BraveBehaviour)_003CallHealth_003E5__5[_003Cj_003E5__7]).transform.position))
							{
								_003Ck_003E5__9 = 0;
								while (_003Ck_003E5__9 < _003ChealthHaver_003E5__8.NumBodyRigidbodies)
								{
									_003CbodyRigidbody_003E5__10 = _003ChealthHaver_003E5__8.GetBodyRigidbody(_003Ck_003E5__9);
									_003Cvector_003E5__11 = Vector3Extensions.XY(((BraveBehaviour)_003ChealthHaver_003E5__8).transform.position);
									_003Cvector2_003E5__12 = _003Cvector_003E5__11 - position;
									if (_003CbodyRigidbody_003E5__10.HitboxPixelCollider != null)
									{
										_003Cvector_003E5__11 = _003CbodyRigidbody_003E5__10.HitboxPixelCollider.UnitCenter;
										_003Cvector2_003E5__12 = _003Cvector_003E5__11 - position;
										_003Cnum_003E5__13 = BraveMathCollege.DistToRectangle(position, _003CbodyRigidbody_003E5__10.HitboxPixelCollider.UnitBottomLeft, _003CbodyRigidbody_003E5__10.HitboxPixelCollider.UnitDimensions);
									}
									else
									{
										_003Cvector_003E5__11 = Vector3Extensions.XY(((BraveBehaviour)_003ChealthHaver_003E5__8).transform.position);
										_003Cvector2_003E5__12 = _003Cvector_003E5__11 - position;
										_003Cnum_003E5__13 = ((Vector2)(ref _003Cvector2_003E5__12)).magnitude;
									}
									if (_003Cnum_003E5__13 < _003CdamageRadius_003E5__1)
									{
										_003CenemiesString_003E5__14 = StringTableManager.GetEnemiesString("#EXPLOSION", -1);
										_003CwasAlive_003E5__15 = !_003ChealthHaver_003E5__8.IsDead;
										if (_003CwasAlive_003E5__15)
										{
											_003ChealthHaver_003E5__8.ApplyDamage(25f, _003Cvector2_003E5__12, _003CenemiesString_003E5__14, (CoreDamageTypes)0, (DamageCategory)0, false, (PixelCollider)null, false);
										}
										_003CknockbackDoer_003E5__16 = ((BraveBehaviour)_003ChealthHaver_003E5__8).knockbackDoer;
										_003CknockbackDoer_003E5__16.ApplyKnockback(((Vector2)(ref _003Cvector2_003E5__12)).normalized, 10f, false);
										if (_003CwasAlive_003E5__15 && _003ChealthHaver_003E5__8.IsDead && Object.op_Implicit((Object)(object)((BraveBehaviour)_003ChealthHaver_003E5__8).specRigidbody))
										{
											_003C_003E4__this.DoGhost(((BraveBehaviour)_003ChealthHaver_003E5__8).specRigidbody, position);
										}
										_003CenemiesString_003E5__14 = null;
										_003CknockbackDoer_003E5__16 = null;
									}
									_003CbodyRigidbody_003E5__10 = null;
									_003Ck_003E5__9++;
								}
							}
							_003ChealthHaver_003E5__8 = null;
							_003Cj_003E5__7++;
						}
					}
					_003CallBreakables_003E5__6 = StaticReferenceManager.AllMinorBreakables;
					if (_003CallBreakables_003E5__6 != null)
					{
						_003Cl_003E5__17 = 0;
						while (_003Cl_003E5__17 < _003CallBreakables_003E5__6.Count)
						{
							_003CminorBreakable_003E5__18 = _003CallBreakables_003E5__6[_003Cl_003E5__17];
							if (Object.op_Implicit((Object)(object)_003CminorBreakable_003E5__18) && !_003CminorBreakable_003E5__18.resistsExplosions && !_003CminorBreakable_003E5__18.OnlyBrokenByCode)
							{
								_003Cvector3_003E5__19 = _003CminorBreakable_003E5__18.CenterPoint - position;
								if (((Vector2)(ref _003Cvector3_003E5__19)).sqrMagnitude < 9f)
								{
									_003CminorBreakable_003E5__18.Break(((Vector2)(ref _003Cvector3_003E5__19)).normalized);
								}
							}
							_003CminorBreakable_003E5__18 = null;
							_003Cl_003E5__17++;
						}
					}
					if ((Object)(object)GameManager.Instance.MainCameraController != (Object)null)
					{
						_003F val = GameManager.Instance.MainCameraController;
						PickupObject byId = PickupObjectDatabase.GetById(37);
						((CameraController)val).DoScreenShake(((Gun)((byId is Gun) ? byId : null)).gunScreenShake, (Vector2?)position, false);
					}
					_003Ci_003E5__20 = 0;
					while (_003Ci_003E5__20 < StaticReferenceManager.AllDebris.Count)
					{
						_003Cvector_003E5__21 = Vector3Extensions.XY(((BraveBehaviour)StaticReferenceManager.AllDebris[_003Ci_003E5__20]).transform.position);
						_003Cvector2_003E5__22 = _003Cvector_003E5__21 - position;
						_003CsqrMagnitude_003E5__23 = ((Vector2)(ref _003Cvector2_003E5__22)).sqrMagnitude;
						if (_003CsqrMagnitude_003E5__23 < 9f)
						{
							_003Cnum2_003E5__24 = 1f - ((Vector2)(ref _003Cvector2_003E5__22)).magnitude / 9f;
							StaticReferenceManager.AllDebris[_003Ci_003E5__20].ApplyVelocity(((Vector2)(ref _003Cvector2_003E5__22)).normalized * _003Cnum2_003E5__24 * 10f * (1f + Random.value / 5f));
						}
						_003Ci_003E5__20++;
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

		public Projectile self;

		public void Start()
		{
			self = ((Component)this).GetComponent<Projectile>();
			self.OnDestruction += OnDestroy;
			Projectile obj = self;
			obj.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(obj.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(OnHit));
		}

		public void OnHit(Projectile proj, SpeculativeRigidbody enemy, bool fatal)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			if (fatal && Object.op_Implicit((Object)(object)enemy))
			{
				DoGhost(enemy, Vector2.op_Implicit(proj.LastPosition));
			}
		}

		public void OnDestroy(Projectile fortunateson)
		{
			//IL_0013: Unknown result type (might be due to invalid IL or missing references)
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			((MonoBehaviour)GameManager.Instance).StartCoroutine(Explode(self, Vector2.op_Implicit(self.LastPosition)));
		}

		public void DoGhost(SpeculativeRigidbody enemy, Vector2 explosionPos)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0013: Unknown result type (might be due to invalid IL or missing references)
			GameObject val = ProjectileUtility.InstantiateAndFireInDirection(StandardisedProjectiles.ghost, enemy.UnitCenter, Vector2Extensions.ToAngle(explosionPos - enemy.UnitCenter), 0f, (PlayerController)null);
			if (Object.op_Implicit((Object)(object)self.Owner))
			{
				Projectile component = val.GetComponent<Projectile>();
				component.Owner = self.Owner;
				component.Shooter = ((BraveBehaviour)self.Owner).specRigidbody;
				if (Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(self)))
				{
					ProjectileUtility.ProjectilePlayerOwner(self).DoPostProcessProjectile(component);
					component.ScaleByPlayerStats(ProjectileUtility.ProjectilePlayerOwner(self));
				}
				((BraveBehaviour)component).specRigidbody.RegisterGhostCollisionException(enemy);
			}
		}

		public IEnumerator Explode(Projectile source, Vector2 position)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
			return new _003CExplode_003Ed__5(0)
			{
				_003C_003E4__this = this,
				source = source,
				position = position
			};
		}
	}

	public static GameObject vfx;

	public static int ID;

	public static void Add()
	{
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_022a: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Doom Boom", "doomboom");
		Game.Items.Rename("outdated_gun_mods:doom_boom", "nn:doom_boom");
		DoomBoom doomBoom = ((Component)val).gameObject.AddComponent<DoomBoom>();
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(601);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		GunExt.SetShortDescription((PickupObject)(object)val, "Momentum Mori");
		GunExt.SetLongDescription((PickupObject)(object)val, "Packs an explosive punch so powerful that it knocks enemies souls out of their bodies.\n\nIn Gundead culture, it is considered a high honour to be buried beneath funerary-grade heavy munitions such as this.");
		val.SetGunSprites("doomboom");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 13);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 10);
		PickupObject byId2 = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1.2f;
		val.DefaultModule.cooldownTime = 0.75f;
		val.muzzleFlashEffects = SharedVFX.DoomBoomMuzzle;
		val.DefaultModule.numberOfShotsInClip = 2;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.125f, 1.1875f, 0f);
		val.SetBaseMaxAmmo(50);
		((PickupObject)val).quality = (ItemQuality)4;
		val.gunClass = (GunClass)45;
		Projectile val2 = ProjectileUtility.SetupProjectile(86);
		val.DefaultModule.projectiles[0] = val2;
		val2.baseData.damage = 20f;
		ProjectileData baseData = val2.baseData;
		baseData.speed *= 0.8f;
		val2.hitEffects.overrideMidairDeathVFX = SharedVFX.BigWhitePoofVFX;
		val2.hitEffects.alwaysUseMidair = true;
		((Component)val2).gameObject.AddComponent<DoomExplosion>();
		vfx = VFXToolbox.CreateVFXBundle("DoomBoomExplosion", new IntVector2(88, 82), (Anchor)4, usesZHeight: true, 0.4f, -1f, null);
		ProjectileBuilders.AnimateProjectileBundle(val2, "DoomBoomProjectile", Initialisation.ProjectileCollection, Initialisation.projectileAnimationCollection, "DoomBoomProjectile", MiscTools.DupeList<IntVector2>(new IntVector2(16, 17), 8), MiscTools.DupeList(value: false, 8), MiscTools.DupeList<Anchor>((Anchor)4, 8), MiscTools.DupeList(value: true, 8), MiscTools.DupeList(value: false, 8), MiscTools.DupeList<Vector3?>(null, 8), MiscTools.DupeList((IntVector2?)new IntVector2(13, 13), 8), MiscTools.DupeList<IntVector2?>(null, 8), MiscTools.DupeList<Projectile>(null, 8));
		val.AddClipSprites("smallghost");
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
	}
}
