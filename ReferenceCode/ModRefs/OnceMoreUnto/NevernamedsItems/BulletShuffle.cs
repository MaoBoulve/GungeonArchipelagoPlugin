using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Dungeonator;
using Gungeon;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class BulletShuffle : PassiveItem
{
	public class HasBeenBulletShuffled : MonoBehaviour
	{
	}

	[CompilerGenerated]
	private sealed class _003CDoAdditionalShot_003Ed__4 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Projectile source;

		public float angleFromAim;

		public float AngleVariance;

		public bool helix;

		public BulletShuffle _003C_003E4__this;

		private Projectile _003CtoSpawn_003E5__1;

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
		public _003CDoAdditionalShot_003Ed__4(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003CtoSpawn_003E5__1 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
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
				if ((Object)(object)source != (Object)null && (Object)(object)source.PossibleSourceGun != (Object)null && source.PossibleSourceGun.DefaultModule != null)
				{
					_003CtoSpawn_003E5__1 = source.PossibleSourceGun.DefaultModule.GetCurrentProjectile();
					if ((Object)(object)_003CtoSpawn_003E5__1 != (Object)null)
					{
						((MonoBehaviour)_003C_003E4__this).StartCoroutine(_003C_003E4__this.SpawnAdditionalProjectile(ProjectileUtility.ProjectilePlayerOwner(source), ((BraveBehaviour)source).specRigidbody.UnitCenter, Vector2Extensions.ToAngle(source.Direction), _003CtoSpawn_003E5__1, AngleVariance, angleFromAim, helix));
					}
					_003CtoSpawn_003E5__1 = null;
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
	private sealed class _003CEraseAndReplace_003Ed__16 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Projectile target;

		public Projectile replacement;

		public BulletShuffle _003C_003E4__this;

		private PlayerController _003Cplayer_003E5__1;

		private GameObject _003CspawnedProj_003E5__2;

		private Projectile _003Cproj_003E5__3;

		private Exception _003Ce_003E5__4;

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
		public _003CEraseAndReplace_003Ed__16(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003Cplayer_003E5__1 = null;
			_003CspawnedProj_003E5__2 = null;
			_003Cproj_003E5__3 = null;
			_003Ce_003E5__4 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_009b: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
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
				try
				{
					if (Object.op_Implicit((Object)(object)target) && Object.op_Implicit((Object)(object)((BraveBehaviour)target).specRigidbody))
					{
						_003Cplayer_003E5__1 = ProjectileUtility.ProjectilePlayerOwner(target);
						if (Object.op_Implicit((Object)(object)_003Cplayer_003E5__1))
						{
							_003CspawnedProj_003E5__2 = SpawnManager.SpawnProjectile(((Component)replacement).gameObject, Vector2.op_Implicit(((BraveBehaviour)target).specRigidbody.UnitCenter), Quaternion.Euler(0f, 0f, Vector2Extensions.ToAngle(target.Direction)), true);
							if (Object.op_Implicit((Object)(object)_003CspawnedProj_003E5__2.GetComponent<Projectile>()))
							{
								_003Cproj_003E5__3 = _003CspawnedProj_003E5__2.GetComponent<Projectile>();
								ProjectileData baseData = _003Cproj_003E5__3.baseData;
								baseData.damage *= _003Cplayer_003E5__1.stats.GetStatValue((StatType)5);
								ProjectileData baseData2 = _003Cproj_003E5__3.baseData;
								baseData2.speed *= _003Cplayer_003E5__1.stats.GetStatValue((StatType)6);
								ProjectileData baseData3 = _003Cproj_003E5__3.baseData;
								baseData3.range *= _003Cplayer_003E5__1.stats.GetStatValue((StatType)26);
								ProjectileData baseData4 = _003Cproj_003E5__3.baseData;
								baseData4.force *= _003Cplayer_003E5__1.stats.GetStatValue((StatType)12);
								Projectile obj = _003Cproj_003E5__3;
								obj.BossDamageMultiplier *= _003Cplayer_003E5__1.stats.GetStatValue((StatType)22);
								_003Cproj_003E5__3.UpdateSpeed();
								((Component)_003Cproj_003E5__3).gameObject.AddComponent<HasBeenBulletShuffled>();
								_003Cplayer_003E5__1.DoPostProcessProjectile(_003Cproj_003E5__3);
								_003Cproj_003E5__3 = null;
							}
							Object.Destroy((Object)(object)((Component)target).gameObject);
							_003CspawnedProj_003E5__2 = null;
						}
						_003Cplayer_003E5__1 = null;
					}
				}
				catch (Exception ex)
				{
					_003Ce_003E5__4 = ex;
					ETGModConsole.Log((object)_003Ce_003E5__4.Message, false);
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
	private sealed class _003CHandleChainExplosion_003Ed__14 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public SpeculativeRigidbody enemySRB;

		public Vector2 startPosition;

		public Vector2 direction;

		public BulletShuffle _003C_003E4__this;

		private float _003CperExplosionTime_003E5__1;

		private float[] _003CexplosionTimes_003E5__2;

		private Vector2 _003ClastValidPosition_003E5__3;

		private bool _003ChitWall_003E5__4;

		private int _003Cindex_003E5__5;

		private float _003Celapsed_003E5__6;

		private Vector2 _003CcurrentDirection_003E5__7;

		private RoomHandler _003CcurrentRoom_003E5__8;

		private float _003CenemyDistance_003E5__9;

		private AIActor _003CnearestEnemy_003E5__10;

		private int _003Ci_003E5__11;

		private Vector2 _003Cvector_003E5__12;

		private Vector2 _003Cvector2_003E5__13;

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
		public _003CHandleChainExplosion_003Ed__14(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003CexplosionTimes_003E5__2 = null;
			_003CcurrentRoom_003E5__8 = null;
			_003CnearestEnemy_003E5__10 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0101: Unknown result type (might be due to invalid IL or missing references)
			//IL_0106: Unknown result type (might be due to invalid IL or missing references)
			//IL_010d: Unknown result type (might be due to invalid IL or missing references)
			//IL_012f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0135: Unknown result type (might be due to invalid IL or missing references)
			//IL_0194: Unknown result type (might be due to invalid IL or missing references)
			//IL_019a: Unknown result type (might be due to invalid IL or missing references)
			//IL_019f: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01de: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_0205: Unknown result type (might be due to invalid IL or missing references)
			//IL_0224: Unknown result type (might be due to invalid IL or missing references)
			//IL_0229: Unknown result type (might be due to invalid IL or missing references)
			//IL_0235: Unknown result type (might be due to invalid IL or missing references)
			//IL_026f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0274: Unknown result type (might be due to invalid IL or missing references)
			//IL_0285: Unknown result type (might be due to invalid IL or missing references)
			//IL_0263: Unknown result type (might be due to invalid IL or missing references)
			//IL_0268: Unknown result type (might be due to invalid IL or missing references)
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003CperExplosionTime_003E5__1 = _003C_003E4__this.LCEChainDuration / (float)_003C_003E4__this.LCEChainNumExplosions;
				_003CexplosionTimes_003E5__2 = new float[_003C_003E4__this.LCEChainNumExplosions];
				_003CexplosionTimes_003E5__2[0] = 0f;
				_003CexplosionTimes_003E5__2[1] = _003CperExplosionTime_003E5__1;
				_003Ci_003E5__11 = 2;
				while (_003Ci_003E5__11 < _003C_003E4__this.LCEChainNumExplosions)
				{
					_003CexplosionTimes_003E5__2[_003Ci_003E5__11] = _003CexplosionTimes_003E5__2[_003Ci_003E5__11 - 1] + _003CperExplosionTime_003E5__1;
					_003Ci_003E5__11++;
				}
				_003ClastValidPosition_003E5__3 = startPosition;
				_003ChitWall_003E5__4 = false;
				_003Cindex_003E5__5 = 0;
				_003Celapsed_003E5__6 = 0f;
				_003ClastValidPosition_003E5__3 = startPosition;
				_003ChitWall_003E5__4 = false;
				_003CcurrentDirection_003E5__7 = direction;
				_003CcurrentRoom_003E5__8 = Vector3Extensions.GetAbsoluteRoom(startPosition);
				_003CenemyDistance_003E5__9 = -1f;
				_003CnearestEnemy_003E5__10 = _003CcurrentRoom_003E5__8.GetNearestEnemyInDirection(startPosition, _003CcurrentDirection_003E5__7, 35f, ref _003CenemyDistance_003E5__9, true, (!Object.op_Implicit((Object)(object)enemySRB)) ? null : ((BraveBehaviour)enemySRB).aiActor);
				if (Object.op_Implicit((Object)(object)_003CnearestEnemy_003E5__10) && _003CenemyDistance_003E5__9 < 20f)
				{
					Vector2 val = ((GameActor)_003CnearestEnemy_003E5__10).CenterPosition - startPosition;
					_003CcurrentDirection_003E5__7 = ((Vector2)(ref val)).normalized;
				}
				break;
			case 1:
				_003C_003E1__state = -1;
				break;
			}
			if (_003Celapsed_003E5__6 < _003C_003E4__this.LCEChainDuration)
			{
				_003Celapsed_003E5__6 += BraveTime.DeltaTime;
				while (_003Cindex_003E5__5 < _003C_003E4__this.LCEChainNumExplosions && _003Celapsed_003E5__6 >= _003CexplosionTimes_003E5__2[_003Cindex_003E5__5])
				{
					_003Cvector_003E5__12 = startPosition + ((Vector2)(ref _003CcurrentDirection_003E5__7)).normalized * _003C_003E4__this.LCEChainDistance;
					_003Cvector2_003E5__13 = Vector2.Lerp(startPosition, _003Cvector_003E5__12, ((float)_003Cindex_003E5__5 + 1f) / (float)_003C_003E4__this.LCEChainNumExplosions);
					if (!_003C_003E4__this.ValidExplosionPosition(_003Cvector2_003E5__13))
					{
						_003ChitWall_003E5__4 = true;
					}
					if (!_003ChitWall_003E5__4)
					{
						_003ClastValidPosition_003E5__3 = _003Cvector2_003E5__13;
					}
					Exploder.Explode(Vector2.op_Implicit(_003ClastValidPosition_003E5__3), _003C_003E4__this.LinearChainExplosionData, _003CcurrentDirection_003E5__7, (Action)null, false, (CoreDamageTypes)0, false);
					_003Cindex_003E5__5++;
				}
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

	[CompilerGenerated]
	private sealed class _003CSpawnAdditionalProjectile_003Ed__5 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerController Owner;

		public Vector2 Position;

		public float angle;

		public Projectile toSpawn;

		public float variance;

		public float FromAim;

		public bool helix;

		public BulletShuffle _003C_003E4__this;

		private GameObject _003CspawnBee_003E5__1;

		private Projectile _003Cbeeproj_003E5__2;

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
		public _003CSpawnAdditionalProjectile_003Ed__5(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003CspawnBee_003E5__1 = null;
			_003Cbeeproj_003E5__2 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_006e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0073: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
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
				if ((Object)(object)toSpawn != (Object)null && (Object)(object)((Component)toSpawn).gameObject != (Object)null)
				{
					_003CspawnBee_003E5__1 = SpawnManager.SpawnProjectile(((Component)toSpawn).gameObject, Vector2.op_Implicit(Position), Quaternion.Euler(0f, 0f, ProjSpawnHelper.GetAccuracyAngled(angle + FromAim, variance, Owner)), true);
					if (Object.op_Implicit((Object)(object)_003CspawnBee_003E5__1.GetComponent<Projectile>()))
					{
						_003Cbeeproj_003E5__2 = _003CspawnBee_003E5__1.GetComponent<Projectile>();
						_003Cbeeproj_003E5__2.Owner = (GameActor)(object)Owner;
						_003Cbeeproj_003E5__2.Shooter = ((BraveBehaviour)Owner).specRigidbody;
						ProjectileData baseData = _003Cbeeproj_003E5__2.baseData;
						baseData.damage *= Owner.stats.GetStatValue((StatType)5);
						ProjectileData baseData2 = _003Cbeeproj_003E5__2.baseData;
						baseData2.speed *= Owner.stats.GetStatValue((StatType)6);
						ProjectileData baseData3 = _003Cbeeproj_003E5__2.baseData;
						baseData3.range *= Owner.stats.GetStatValue((StatType)26);
						ProjectileData baseData4 = _003Cbeeproj_003E5__2.baseData;
						baseData4.force *= Owner.stats.GetStatValue((StatType)12);
						Projectile obj = _003Cbeeproj_003E5__2;
						obj.BossDamageMultiplier *= Owner.stats.GetStatValue((StatType)22);
						_003Cbeeproj_003E5__2.UpdateSpeed();
						if (helix)
						{
							ProjectileUtility.ConvertToHelixMotion(_003Cbeeproj_003E5__2, true);
						}
						((Component)_003Cbeeproj_003E5__2).gameObject.AddComponent<HasBeenBulletShuffled>();
						Owner.DoPostProcessProjectile(_003Cbeeproj_003E5__2);
						_003Cbeeproj_003E5__2 = null;
					}
					_003CspawnBee_003E5__1 = null;
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

	public float LCEChainDuration = 1f;

	public float LCEChainDistance = 10f;

	public int LCEChainNumExplosions = 5;

	public GameObject LCEChainTargetSprite = ((Component)PickupObjectDatabase.GetById(822)).GetComponent<ComplexProjectileModifier>().LCEChainTargetSprite;

	public ExplosionData LinearChainExplosionData = ((Component)PickupObjectDatabase.GetById(822)).GetComponent<ComplexProjectileModifier>().LinearChainExplosionData;

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<BulletShuffle>("Bullet Shuffle", "Ask Questions Later", "Grants completely random bullet effects on every shot.\n\nA belt of infinite potential, you can pluck any type of ammunition from it's ample supply.", "bulletshuffle_icon", assetbundle: true);
		val.quality = (ItemQuality)5;
		val.SetupUnlockOnCustomFlag(CustomDungeonFlags.BOSSRUSH_GUNSLINGER, requiredFlagValue: true);
	}

	private void PostProcessProjectile(Projectile sourceProjectile, float effectChanceScalar)
	{
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Expected O, but got Unknown
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_034b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0373: Unknown result type (might be due to invalid IL or missing references)
		//IL_038b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0392: Unknown result type (might be due to invalid IL or missing references)
		//IL_0393: Unknown result type (might be due to invalid IL or missing references)
		//IL_03af: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0402: Unknown result type (might be due to invalid IL or missing references)
		//IL_0407: Unknown result type (might be due to invalid IL or missing references)
		//IL_0412: Unknown result type (might be due to invalid IL or missing references)
		//IL_0419: Unknown result type (might be due to invalid IL or missing references)
		//IL_0430: Unknown result type (might be due to invalid IL or missing references)
		//IL_0440: Expected O, but got Unknown
		//IL_05da: Unknown result type (might be due to invalid IL or missing references)
		//IL_0609: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_073e: Unknown result type (might be due to invalid IL or missing references)
		//IL_077c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0782: Unknown result type (might be due to invalid IL or missing references)
		//IL_07fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0968: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a93: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a98: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aa3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aaa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ac1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ad1: Expected O, but got Unknown
		//IL_0bbd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d73: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d7e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d83: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d88: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d8d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d91: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (!((Object)(object)((Component)sourceProjectile).GetComponent<HasBeenBulletShuffled>() == (Object)null))
			{
				return;
			}
			switch (Random.Range(1, 62))
			{
			case 1:
			{
				ProjectileData baseData2 = sourceProjectile.baseData;
				baseData2.damage *= 1.25f;
				break;
			}
			case 2:
			{
				ProjectileData baseData16 = sourceProjectile.baseData;
				baseData16.damage *= 1.1f;
				ProjectileData baseData17 = sourceProjectile.baseData;
				baseData17.speed *= 1.5f;
				sourceProjectile.UpdateSpeed();
				break;
			}
			case 3:
			{
				AdvancedTransmogrifyBehaviour val12 = ((Component)sourceProjectile).gameObject.AddComponent<AdvancedTransmogrifyBehaviour>();
				val12.TransmogDataList = new List<TransmogData>
				{
					new TransmogData
					{
						identifier = "BulletShuffle",
						maintainHPPercent = false,
						TargetGuids = new List<string> { "05891b158cd542b1a5f3df30fb67a7ff" },
						TransmogChance = 1f
					}
				};
				break;
			}
			case 4:
				((MonoBehaviour)this).StartCoroutine(EraseAndReplace(sourceProjectile, ((Component)PickupObjectDatabase.GetById(640)).GetComponent<ComplexProjectileModifier>().CriticalProjectile));
				break;
			case 5:
				sourceProjectile.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(sourceProjectile.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(DoKatana));
				break;
			case 6:
			{
				HungryProjectileModifier orAddComponent7 = GameObjectExtensions.GetOrAddComponent<HungryProjectileModifier>(((Component)sourceProjectile).gameObject);
				orAddComponent7.HungryRadius = 1.5f;
				orAddComponent7.DamagePercentGainPerSnack = 0.25f;
				orAddComponent7.MaxMultiplier = 3f;
				orAddComponent7.MaximumBulletsEaten = 10;
				sourceProjectile.AdjustPlayerProjectileTint(ExtendedColours.purple, 1, 0f);
				break;
			}
			case 7:
			{
				ProjectileData baseData13 = sourceProjectile.baseData;
				baseData13.damage *= 1.25f;
				ProjectileData baseData14 = sourceProjectile.baseData;
				baseData14.speed *= 0.5f;
				ProjectileData baseData15 = sourceProjectile.baseData;
				baseData15.force *= 2f;
				sourceProjectile.RuntimeUpdateScale(1.25f);
				sourceProjectile.UpdateSpeed();
				break;
			}
			case 8:
			{
				BounceProjModifier orAddComponent6 = GameObjectExtensions.GetOrAddComponent<BounceProjModifier>(((Component)sourceProjectile).gameObject);
				orAddComponent6.numberOfBounces++;
				break;
			}
			case 9:
			{
				ExplosiveModifier val11 = ((Component)sourceProjectile).gameObject.AddComponent<ExplosiveModifier>();
				val11.doExplosion = true;
				val11.explosionData = StaticExplosionDatas.explosiveRoundsExplosion;
				break;
			}
			case 10:
			{
				PierceProjModifier val10 = ((Component)sourceProjectile).gameObject.AddComponent<PierceProjModifier>();
				val10.penetration++;
				break;
			}
			case 11:
				sourceProjectile.statusEffectsToApply.Add((GameActorEffect)(object)StaticStatusEffects.irradiatedLeadEffect);
				sourceProjectile.AdjustPlayerProjectileTint(ExtendedColours.poisonGreen, 1, 0f);
				break;
			case 12:
				sourceProjectile.statusEffectsToApply.Add((GameActorEffect)(object)StaticStatusEffects.hotLeadEffect);
				sourceProjectile.AdjustPlayerProjectileTint(Color.red, 1, 0f);
				break;
			case 13:
				sourceProjectile.damageTypes = (CoreDamageTypes)(sourceProjectile.damageTypes | 0x40);
				break;
			case 14:
				sourceProjectile.statusEffectsToApply.Add((GameActorEffect)(object)StaticStatusEffects.chaosBulletsFreeze);
				sourceProjectile.AdjustPlayerProjectileTint(ExtendedColours.freezeBlue, 1, 0f);
				break;
			case 15:
				sourceProjectile.statusEffectsToApply.Add((GameActorEffect)(object)StaticStatusEffects.charmingRoundsEffect);
				sourceProjectile.AdjustPlayerProjectileTint(ExtendedColours.charmPink, 1, 0f);
				break;
			case 16:
			{
				AdvancedTransmogrifyBehaviour val9 = ((Component)sourceProjectile).gameObject.AddComponent<AdvancedTransmogrifyBehaviour>();
				val9.TransmogDataList = new List<TransmogData>
				{
					new TransmogData
					{
						identifier = "BulletShuffle",
						maintainHPPercent = false,
						TargetGuids = new List<string> { "76bc43539fc24648bff4568c75c686d1" },
						TransmogChance = 1f
					}
				};
				break;
			}
			case 17:
			{
				ProjectileData baseData11 = sourceProjectile.baseData;
				baseData11.force *= 2f;
				sourceProjectile.RuntimeUpdateScale(2f);
				ProjectileData baseData12 = sourceProjectile.baseData;
				baseData12.damage *= 1.3f;
				break;
			}
			case 18:
			{
				AngryBulletsProjectileBehaviour angryBulletsProjectileBehaviour = ((Component)sourceProjectile).gameObject.AddComponent<AngryBulletsProjectileBehaviour>();
				break;
			}
			case 19:
				GameObjectExtensions.GetOrAddComponent<BlankProjModifier>(((Component)sourceProjectile).gameObject);
				break;
			case 20:
			{
				OrbitalBulletsBehaviour orAddComponent5 = GameObjectExtensions.GetOrAddComponent<OrbitalBulletsBehaviour>(((Component)sourceProjectile).gameObject);
				break;
			}
			case 21:
				ShadowBulletDoer.SpawnChainedShadowBullets(sourceProjectile, 1, 0.05f, 1f, (Projectile)null, true);
				break;
			case 22:
				sourceProjectile.RuntimeUpdateScale(1.5f);
				GameObjectExtensions.GetOrAddComponent<StoutBulletsProjectileBehaviour>(((Component)sourceProjectile).gameObject);
				break;
			case 23:
			{
				ScalingProjectileModifier val8 = ((Component)sourceProjectile).gameObject.AddComponent<ScalingProjectileModifier>();
				val8.ScaleToDamageRatio = 0.25f;
				val8.MaximumDamageMultiplier = 2.5f;
				val8.IsSynergyContingent = false;
				val8.PercentGainPerUnit = 10f;
				break;
			}
			case 24:
				GameObjectExtensions.GetOrAddComponent<RemoteBulletsProjectileBehaviour>(((Component)sourceProjectile).gameObject);
				break;
			case 25:
				sourceProjectile.OnDestruction += HandleZombieEffect;
				break;
			case 26:
			{
				SpawnProjModifier val7 = ((Component)sourceProjectile).gameObject.AddComponent<SpawnProjModifier>();
				val7.SpawnedProjectilesInheritAppearance = true;
				val7.SpawnedProjectileScaleModifier = 0.5f;
				val7.SpawnedProjectilesInheritData = true;
				val7.spawnProjectilesOnCollision = true;
				val7.spawnProjecitlesOnDieInAir = true;
				val7.doOverrideObjectCollisionSpawnStyle = true;
				val7.startAngle = Random.Range(0, 180);
				val7.numberToSpawnOnCollison = 3;
				val7.projectileToSpawnOnCollision = ((Component)Game.Items["flak_bullets"]).GetComponent<ComplexProjectileModifier>().CollisionSpawnProjectile;
				val7.collisionSpawnStyle = (CollisionSpawnStyle)1;
				break;
			}
			case 27:
				sourceProjectile.BossDamageMultiplier *= 1.25f;
				sourceProjectile.BlackPhantomDamageMultiplier *= 2.25f;
				sourceProjectile.AdjustPlayerProjectileTint(ExtendedColours.silvedBulletsSilver, 1, 0f);
				break;
			case 28:
			{
				float num3 = 0f;
				ScalingStatBoostItem component3 = ((Component)PickupObjectDatabase.GetById(532)).GetComponent<ScalingStatBoostItem>();
				num3 = Mathf.Clamp01(Mathf.InverseLerp(component3.ScalingTargetMin, component3.ScalingTargetMax, (float)ProjectileUtility.ProjectilePlayerOwner(sourceProjectile).carriedConsumables.Currency));
				num3 = component3.ScalingCurve.Evaluate(num3);
				float num4 = Mathf.Lerp(component3.MinScaling, component3.MaxScaling, num3);
				ProjectileData baseData10 = sourceProjectile.baseData;
				baseData10.damage *= num4;
				sourceProjectile.AdjustPlayerProjectileTint(component3.TintColor, component3.TintPriority, 0f);
				break;
			}
			case 29:
			{
				float num = 0f;
				ScalingStatBoostItem component2 = ((Component)PickupObjectDatabase.GetById(571)).GetComponent<ScalingStatBoostItem>();
				num = Mathf.Clamp01(Mathf.InverseLerp(component2.ScalingTargetMin, component2.ScalingTargetMax, ProjectileUtility.ProjectilePlayerOwner(sourceProjectile).stats.GetStatValue((StatType)14)));
				num = component2.ScalingCurve.Evaluate(num);
				float num2 = Mathf.Lerp(component2.MinScaling, component2.MaxScaling, num);
				ProjectileData baseData9 = sourceProjectile.baseData;
				baseData9.damage *= num2;
				sourceProjectile.AdjustPlayerProjectileTint(component2.TintColor, component2.TintPriority, 0f);
				sourceProjectile.CurseSparks = true;
				break;
			}
			case 30:
				DoChanceBulletsEffect(sourceProjectile);
				break;
			case 31:
			{
				_003F val6 = this;
				PlayerController owner = ProjectileUtility.ProjectilePlayerOwner(sourceProjectile);
				Vector2 unitCenter = ((BraveBehaviour)sourceProjectile).specRigidbody.UnitCenter;
				float angle = Vector2Extensions.ToAngle(sourceProjectile.Direction);
				PickupObject byId8 = PickupObjectDatabase.GetById(14);
				((MonoBehaviour)val6).StartCoroutine(SpawnAdditionalProjectile(owner, unitCenter, angle, ((Gun)((byId8 is Gun) ? byId8 : null)).DefaultModule.projectiles[0]));
				break;
			}
			case 32:
				((MonoBehaviour)this).StartCoroutine(EraseAndReplace(sourceProjectile, ((Component)PickupObjectDatabase.GetById(524)).GetComponent<RandomProjectileReplacementItem>().ReplacementProjectile));
				break;
			case 33:
				sourceProjectile.statusEffectsToApply.Add((GameActorEffect)(object)StaticStatusEffects.tripleCrossbowSlowEffect);
				sourceProjectile.AdjustPlayerProjectileTint(Color.yellow, 1, 0f);
				break;
			case 34:
				sourceProjectile.pierceMinorBreakables = true;
				sourceProjectile.PenetratesInternalWalls = true;
				break;
			case 35:
				sourceProjectile.ignoreDamageCaps = true;
				break;
			case 36:
			{
				ProjectileData baseData8 = sourceProjectile.baseData;
				baseData8.damage *= 0.55f;
				((MonoBehaviour)this).StartCoroutine(DoAdditionalShot(sourceProjectile, 0f, 30f));
				((MonoBehaviour)this).StartCoroutine(DoAdditionalShot(sourceProjectile, 0f, 30f));
				break;
			}
			case 37:
				((MonoBehaviour)this).StartCoroutine(DoAdditionalShot(sourceProjectile, 180f, 5f));
				break;
			case 38:
				((MonoBehaviour)this).StartCoroutine(DoAdditionalShot(sourceProjectile, 0f, 0f, helix: true));
				ProjectileUtility.ConvertToHelixMotion(sourceProjectile, false);
				break;
			case 39:
			{
				ProjectileData baseData7 = sourceProjectile.baseData;
				baseData7.force *= 3f;
				KilledEnemiesBecomeProjectileModifier val5 = ((Component)sourceProjectile).gameObject.AddComponent<KilledEnemiesBecomeProjectileModifier>();
				ref bool completelyBecomeProjectile = ref val5.CompletelyBecomeProjectile;
				PickupObject byId6 = PickupObjectDatabase.GetById(541);
				completelyBecomeProjectile = ((Component)((Gun)((byId6 is Gun) ? byId6 : null)).DefaultModule.chargeProjectiles[0].Projectile).GetComponent<KilledEnemiesBecomeProjectileModifier>().CompletelyBecomeProjectile;
				ref Projectile baseProjectile = ref val5.BaseProjectile;
				PickupObject byId7 = PickupObjectDatabase.GetById(541);
				baseProjectile = ((Component)((Gun)((byId7 is Gun) ? byId7 : null)).DefaultModule.chargeProjectiles[0].Projectile).GetComponent<KilledEnemiesBecomeProjectileModifier>().BaseProjectile;
				break;
			}
			case 40:
				sourceProjectile.statusEffectsToApply.Add((GameActorEffect)(object)StaticStatusEffects.instantCheese);
				sourceProjectile.AdjustPlayerProjectileTint(ExtendedColours.honeyYellow, 1, 0f);
				break;
			case 41:
				sourceProjectile.StunApplyChance = 1f;
				sourceProjectile.AppliedStunDuration = 2f;
				sourceProjectile.AppliesStun = true;
				break;
			case 42:
				sourceProjectile.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(sourceProjectile.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(KaliberShit));
				break;
			case 43:
			{
				PickupObject byId5 = PickupObjectDatabase.GetById(175);
				ProjectileUtility.ApplyClonedShaderProjModifier(sourceProjectile, ((Component)((Gun)((byId5 is Gun) ? byId5 : null)).DefaultModule.projectiles[0]).GetComponent<ShaderProjModifier>());
				break;
			}
			case 44:
				((Component)sourceProjectile).gameObject.AddComponent<KeyProjModifier>();
				break;
			case 45:
			{
				ProjectileData baseData6 = sourceProjectile.baseData;
				baseData6.damage *= 2f;
				PickupObject byId4 = PickupObjectDatabase.GetById(519);
				CombineEvaporateEffect component = ((Component)((Gun)((byId4 is Gun) ? byId4 : null)).alternateVolley.projectiles[0].projectiles[0]).GetComponent<CombineEvaporateEffect>();
				CombineEvaporateEffect val4 = ((Component)sourceProjectile).gameObject.AddComponent<CombineEvaporateEffect>();
				val4.FallbackShader = component.FallbackShader;
				val4.ParticleSystemToSpawn = component.ParticleSystemToSpawn;
				break;
			}
			case 46:
			{
				AdvancedTransmogrifyBehaviour val3 = ((Component)sourceProjectile).gameObject.AddComponent<AdvancedTransmogrifyBehaviour>();
				val3.TransmogDataList = new List<TransmogData>
				{
					new TransmogData
					{
						identifier = "BulletShuffle",
						maintainHPPercent = false,
						TargetGuids = new List<string> { "1386da0f42fb4bcabc5be8feb16a7c38" },
						TransmogChance = 1f
					}
				};
				break;
			}
			case 47:
				sourceProjectile.statusEffectsToApply.Add((GameActorEffect)(object)StaticStatusEffects.SunlightBurn);
				break;
			case 48:
			{
				SummonTigerModifier val2 = ((Component)sourceProjectile).gameObject.AddComponent<SummonTigerModifier>();
				ref Projectile tigerProjectilePrefab = ref val2.TigerProjectilePrefab;
				PickupObject byId3 = PickupObjectDatabase.GetById(369);
				tigerProjectilePrefab = ((Component)((Gun)((byId3 is Gun) ? byId3 : null)).DefaultModule.chargeProjectiles[0].Projectile).GetComponent<SummonTigerModifier>().TigerProjectilePrefab;
				break;
			}
			case 49:
				sourceProjectile.OnDestruction += SpawnShieldOnDestroy;
				break;
			case 50:
			{
				PickupObject byId2 = PickupObjectDatabase.GetById(28);
				ProjectileUtility.ApplyClonedShaderProjModifier(sourceProjectile, ((Component)((Gun)((byId2 is Gun) ? byId2 : null)).modifiedFinalVolley.projectiles[0].projectiles[1]).GetComponent<ShaderProjModifier>());
				break;
			}
			case 51:
				((Component)sourceProjectile).gameObject.AddComponent<BlackRevolverModifier>();
				break;
			case 52:
				((Component)sourceProjectile).gameObject.AddComponent<EnemyBulletsBecomeJammedModifier>();
				break;
			case 53:
				sourceProjectile.statusEffectsToApply.Add((GameActorEffect)(object)StaticStatusEffects.greenFireEffect);
				sourceProjectile.AdjustPlayerProjectileTint(Color.green, 1, 0f);
				break;
			case 54:
			{
				PickupObject byId = PickupObjectDatabase.GetById(648);
				ProjectileUtility.ApplyClonedShaderProjModifier(sourceProjectile, ((Component)((Gun)((byId is Gun) ? byId : null)).DefaultModule.projectiles[0]).GetComponent<ShaderProjModifier>());
				break;
			}
			case 55:
			{
				ProjectileData baseData4 = sourceProjectile.baseData;
				baseData4.damage *= 1.16f;
				ProjectileData baseData5 = sourceProjectile.baseData;
				baseData5.speed *= 1.25f;
				sourceProjectile.UpdateSpeed();
				break;
			}
			case 56:
			{
				ProjectileInstakillBehaviour orAddComponent4 = GameObjectExtensions.GetOrAddComponent<ProjectileInstakillBehaviour>(((Component)sourceProjectile).gameObject);
				orAddComponent4.tagsToKill.Add("blobulon");
				orAddComponent4.protectBosses = false;
				orAddComponent4.enemyGUIDSToEraseFromExistence.Add(EnemyGuidDatabase.Entries["bloodbulon"]);
				break;
			}
			case 57:
			{
				ProjectileInstakillBehaviour orAddComponent3 = GameObjectExtensions.GetOrAddComponent<ProjectileInstakillBehaviour>(((Component)sourceProjectile).gameObject);
				orAddComponent3.tagsToKill.AddRange(new List<string> { "gunjurer", "gunsinger", "bookllet" });
				orAddComponent3.enemyGUIDsToKill.AddRange(new List<string>
				{
					EnemyGuidDatabase.Entries["wizbang"],
					EnemyGuidDatabase.Entries["pot_fairy"]
				});
				break;
			}
			case 58:
			{
				ExplodeOnBulletIntersection orAddComponent2 = GameObjectExtensions.GetOrAddComponent<ExplodeOnBulletIntersection>(((Component)sourceProjectile).gameObject);
				orAddComponent2.explosionData = AntimatterBullets.smallPlayerSafeExplosion;
				break;
			}
			case 59:
			{
				ProjectileData baseData3 = sourceProjectile.baseData;
				baseData3.force *= 10f;
				((Component)sourceProjectile).gameObject.AddComponent<BreakableBashingBehaviour>();
				break;
			}
			case 60:
				GameObjectExtensions.GetOrAddComponent<BloodthirstyBulletsComp>(((Component)sourceProjectile).gameObject);
				break;
			case 61:
			{
				KnockbackDoer knockbackDoer = ((BraveBehaviour)ProjectileUtility.ProjectilePlayerOwner(sourceProjectile)).knockbackDoer;
				Vector2 val = ((GameActor)ProjectileUtility.ProjectilePlayerOwner(sourceProjectile)).CenterPosition - Vector3Extensions.XY(ProjectileUtility.ProjectilePlayerOwner(sourceProjectile).unadjustedAimPoint);
				knockbackDoer.ApplyKnockback(((Vector2)(ref val)).normalized, Mathf.Min(100f, 40f * (sourceProjectile.baseData.damage / 10f)), false);
				sourceProjectile.RuntimeUpdateScale(1.3f);
				ProjectileData baseData = sourceProjectile.baseData;
				baseData.damage *= 2f;
				if (Random.value <= 0.07f)
				{
					ExplosiveModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<ExplosiveModifier>(((Component)sourceProjectile).gameObject);
					orAddComponent.doExplosion = true;
					orAddComponent.explosionData = StaticExplosionDatas.explosiveRoundsExplosion;
				}
				break;
			}
			}
			((Component)sourceProjectile).gameObject.AddComponent<HasBeenBulletShuffled>();
		}
		catch (Exception ex)
		{
			ETGModConsole.Log((object)ex.Message, false);
		}
	}

	private void SpawnShieldOnDestroy(Projectile self)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		MiscToolbox.SpawnShield(ProjectileUtility.ProjectilePlayerOwner(self), Vector2.op_Implicit(((BraveBehaviour)self).sprite.WorldCenter));
	}

	private void KaliberShit(Projectile self, SpeculativeRigidbody enemy, bool fatal)
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		PickupObject byId = PickupObjectDatabase.GetById(761);
		GameObject gameObject = ((Component)((Gun)((byId is Gun) ? byId : null)).DefaultModule.projectiles[0]).gameObject;
		GameObject val = SpawnManager.SpawnProjectile(gameObject, Vector2.op_Implicit(enemy.UnitCenter), Quaternion.Euler(0f, 0f, Vector2Extensions.ToAngle(self.Direction)), true);
		if (Object.op_Implicit((Object)(object)val.GetComponent<Projectile>()))
		{
			Projectile component = val.GetComponent<Projectile>();
			component.Owner = self.Owner;
			component.Shooter = self.Shooter;
			ProjectileData baseData = component.baseData;
			baseData.damage *= 0f;
		}
	}

	private IEnumerator DoAdditionalShot(Projectile source, float angleFromAim, float AngleVariance, bool helix = false)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CDoAdditionalShot_003Ed__4(0)
		{
			_003C_003E4__this = this,
			source = source,
			angleFromAim = angleFromAim,
			AngleVariance = AngleVariance,
			helix = helix
		};
	}

	private IEnumerator SpawnAdditionalProjectile(PlayerController Owner, Vector2 Position, float angle, Projectile toSpawn, float variance = 0f, float FromAim = 0f, bool helix = false)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CSpawnAdditionalProjectile_003Ed__5(0)
		{
			_003C_003E4__this = this,
			Owner = Owner,
			Position = Position,
			angle = angle,
			toSpawn = toSpawn,
			variance = variance,
			FromAim = FromAim,
			helix = helix
		};
	}

	private void DoChanceBulletsEffect(Projectile source)
	{
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Invalid comparison between Unknown and I4
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Invalid comparison between Unknown and I4
		PlayerController val = ProjectileUtility.ProjectilePlayerOwner(source);
		if (!Object.op_Implicit((Object)(object)val) || val.inventory == null)
		{
			return;
		}
		for (int i = 0; i < val.inventory.AllGuns.Count; i++)
		{
			if (!Object.op_Implicit((Object)(object)val.inventory.AllGuns[i]) || val.inventory.AllGuns[i].InfiniteAmmo)
			{
				continue;
			}
			Gun val2 = val.inventory.AllGuns[i];
			ProjectileModule defaultModule = val.inventory.AllGuns[i].DefaultModule;
			if ((int)defaultModule.shootStyle == 2)
			{
				BeamController.FreeFireBeam(defaultModule.GetCurrentProjectile(), val, ((GameActor)val).CurrentGun.CurrentAngle, 3f, true);
			}
			else if ((int)defaultModule.shootStyle == 3)
			{
				Projectile val3 = null;
				for (int j = 0; j < 15; j++)
				{
					ChargeProjectile val4 = defaultModule.chargeProjectiles[Random.Range(0, defaultModule.chargeProjectiles.Count)];
					if (val4 != null)
					{
						val3 = val4.Projectile;
					}
					if (Object.op_Implicit((Object)(object)val3))
					{
						break;
					}
				}
				if ((Object)(object)val3 != (Object)null)
				{
					((MonoBehaviour)this).StartCoroutine(EraseAndReplace(source, val3));
				}
			}
			Projectile currentProjectile = defaultModule.GetCurrentProjectile();
			if ((Object)(object)currentProjectile != (Object)null)
			{
				((MonoBehaviour)this).StartCoroutine(EraseAndReplace(source, currentProjectile));
			}
		}
	}

	private void HandleZombieEffect(Projectile source)
	{
		if (Object.op_Implicit((Object)(object)source) && Object.op_Implicit((Object)(object)source.PossibleSourceGun) && !source.PossibleSourceGun.InfiniteAmmo && !source.HasImpactedEnemy)
		{
			source.PossibleSourceGun.GainAmmo(1);
		}
	}

	private void DoKatana(Projectile sourceProjectile, SpeculativeRigidbody enemy, bool fatal)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		Vector2 val = ((!Object.op_Implicit((Object)(object)((BraveBehaviour)enemy).aiActor)) ? Vector3Extensions.XY(((BraveBehaviour)enemy).transform.position) : ((GameActor)((BraveBehaviour)enemy).aiActor).CenterPosition);
		Debug.LogError((object)val);
		_003F val2;
		Vector2 val3;
		if (!Object.op_Implicit((Object)(object)sourceProjectile))
		{
			val2 = ((!Object.op_Implicit((Object)(object)((BraveBehaviour)enemy).healthHaver)) ? BraveMathCollege.DegreesToVector(((GameActor)((PassiveItem)this).Owner).FacingDirection, 1f) : ((BraveBehaviour)enemy).healthHaver.lastIncurredDamageDirection);
		}
		else
		{
			val3 = sourceProjectile.LastVelocity;
			val2 = ((Vector2)(ref val3)).normalized;
		}
		Vector2 val4 = (Vector2)val2;
		if (((Vector2)(ref val4)).magnitude < 0.05f)
		{
			val3 = Random.insideUnitCircle;
			val4 = ((Vector2)(ref val3)).normalized;
		}
		((MonoBehaviour)GameManager.Instance.Dungeon).StartCoroutine(HandleChainExplosion(enemy, val, ((Vector2)(ref val4)).normalized));
	}

	private IEnumerator HandleChainExplosion(SpeculativeRigidbody enemySRB, Vector2 startPosition, Vector2 direction)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CHandleChainExplosion_003Ed__14(0)
		{
			_003C_003E4__this = this,
			enemySRB = enemySRB,
			startPosition = startPosition,
			direction = direction
		};
	}

	private bool ValidExplosionPosition(Vector2 pos)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Invalid comparison between Unknown and I4
		IntVector2 val = Vector2Extensions.ToIntVector2(pos, (VectorConversions)0);
		return GameManager.Instance.Dungeon.data.CheckInBoundsAndValid(val) && (int)GameManager.Instance.Dungeon.data[val].type != 1;
	}

	private IEnumerator EraseAndReplace(Projectile target, Projectile replacement)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CEraseAndReplace_003Ed__16(0)
		{
			_003C_003E4__this = this,
			target = target,
			replacement = replacement
		};
	}

	public override DebrisObject Drop(PlayerController player)
	{
		DebrisObject result = ((PassiveItem)this).Drop(player);
		player.PostProcessProjectile -= PostProcessProjectile;
		return result;
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		player.PostProcessProjectile += PostProcessProjectile;
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			((PassiveItem)this).Owner.PostProcessProjectile -= PostProcessProjectile;
		}
		((PassiveItem)this).OnDestroy();
	}
}
