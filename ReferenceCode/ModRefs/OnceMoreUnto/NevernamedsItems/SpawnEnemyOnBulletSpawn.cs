using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace NevernamedsItems;

public class SpawnEnemyOnBulletSpawn : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CPostSpawn_003Ed__3 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AIActor spawnedEnemy;

		public float knockbackAway;

		public Vector2 dir;

		public SpawnEnemyOnBulletSpawn _003C_003E4__this;

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
		public _003CPostSpawn_003Ed__3(int _003C_003E1__state)
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
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
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
				if (knockbackAway > 0f && Object.op_Implicit((Object)(object)((BraveBehaviour)spawnedEnemy).knockbackDoer))
				{
					((BraveBehaviour)spawnedEnemy).knockbackDoer.ApplyKnockback(dir, knockbackAway, false);
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
	private sealed class _003ChandleSpawn_003Ed__2 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public SpawnEnemyOnBulletSpawn _003C_003E4__this;

		private AIActor _003CenemyToSpawn_003E5__1;

		private Vector2 _003Cposition_003E5__2;

		private AIActor _003CTargetActor_003E5__3;

		private CustomEnemyTagsSystem _003Ctags_003E5__4;

		private CompanionController _003CorAddComponent_003E5__5;

		private CompanionisedEnemyBulletModifiers _003CcompanionisedBullets_003E5__6;

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
		public _003ChandleSpawn_003Ed__2(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003CenemyToSpawn_003E5__1 = null;
			_003CTargetActor_003E5__3 = null;
			_003Ctags_003E5__4 = null;
			_003CorAddComponent_003E5__5 = null;
			_003CcompanionisedBullets_003E5__6 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_00be: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0194: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e9: Unknown result type (might be due to invalid IL or missing references)
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
				if (Random.value <= _003C_003E4__this.procChance && _003C_003E4__this.guidToSpawn != null)
				{
					_003CenemyToSpawn_003E5__1 = EnemyDatabase.GetOrLoadByGuid(_003C_003E4__this.guidToSpawn);
					_003Cposition_003E5__2 = ((BraveBehaviour)_003C_003E4__this.m_projectile).specRigidbody.UnitCenter;
					Object.Instantiate<GameObject>(SharedVFX.SpiratTeleportVFX, Vector2.op_Implicit(_003Cposition_003E5__2), Quaternion.identity);
					_003CTargetActor_003E5__3 = AIActor.Spawn(_003CenemyToSpawn_003E5__1, _003Cposition_003E5__2, GameManager.Instance.Dungeon.data.GetAbsoluteRoomFromPosition(Vector2Extensions.ToIntVector2(_003Cposition_003E5__2, (VectorConversions)2)), true, (AwakenAnimationType)0, true);
					PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(((BraveBehaviour)_003CTargetActor_003E5__3).specRigidbody, (int?)null, false);
					if (_003C_003E4__this.ignoreSpawnedEnemyForGoodMimic)
					{
						_003Ctags_003E5__4 = GameObjectExtensions.GetOrAddComponent<CustomEnemyTagsSystem>(((Component)_003CTargetActor_003E5__3).gameObject);
						_003Ctags_003E5__4.ignoreForGoodMimic = true;
						_003Ctags_003E5__4 = null;
					}
					if (_003C_003E4__this.companioniseEnemy && (Object)(object)_003C_003E4__this.projOwner != (Object)null)
					{
						_003CorAddComponent_003E5__5 = GameObjectExtensions.GetOrAddComponent<CompanionController>(((Component)_003CTargetActor_003E5__3).gameObject);
						_003CorAddComponent_003E5__5.companionID = (CompanionIdentifier)0;
						_003CorAddComponent_003E5__5.Initialize(_003C_003E4__this.projOwner);
						_003CcompanionisedBullets_003E5__6 = GameObjectExtensions.GetOrAddComponent<CompanionisedEnemyBulletModifiers>(((Component)_003CTargetActor_003E5__3).gameObject);
						_003CcompanionisedBullets_003E5__6.jammedDamageMultiplier = 2f;
						_003CcompanionisedBullets_003E5__6.TintBullets = true;
						_003CcompanionisedBullets_003E5__6.TintColor = ExtendedColours.honeyYellow;
						_003CcompanionisedBullets_003E5__6.baseBulletDamage = _003C_003E4__this.enemyBulletDamage;
						_003CcompanionisedBullets_003E5__6.scaleDamage = _003C_003E4__this.scaleEnemyDamage;
						_003CcompanionisedBullets_003E5__6.doPostProcess = _003C_003E4__this.doPostProcessOnEnemyBullets;
						_003CcompanionisedBullets_003E5__6.scaleSize = _003C_003E4__this.scaleEnemyProjSize;
						_003CcompanionisedBullets_003E5__6.scaleSpeed = _003C_003E4__this.scaleEnemyProjSpeed;
						_003CcompanionisedBullets_003E5__6.enemyOwner = _003C_003E4__this.projOwner;
						_003CorAddComponent_003E5__5 = null;
						_003CcompanionisedBullets_003E5__6 = null;
					}
					if (_003C_003E4__this.killSpawnedEnemyOnRoomClear)
					{
						((Component)_003CTargetActor_003E5__3).gameObject.AddComponent<KillOnRoomClear>();
					}
					_003CTargetActor_003E5__3.IsHarmlessEnemy = true;
					_003CTargetActor_003E5__3.IgnoreForRoomClear = true;
					((MonoBehaviour)_003CTargetActor_003E5__3).StartCoroutine(_003C_003E4__this.PostSpawn(_003CTargetActor_003E5__3, _003C_003E4__this.knockbackAmountAwayFromOwner, _003C_003E4__this.m_projectile.Direction));
					if (Object.op_Implicit((Object)(object)((Component)_003CTargetActor_003E5__3).gameObject.GetComponent<SpawnEnemyOnDeath>()))
					{
						Object.Destroy((Object)(object)((Component)_003CTargetActor_003E5__3).gameObject.GetComponent<SpawnEnemyOnDeath>());
					}
					if (_003C_003E4__this.deleteProjAfterSpawn)
					{
						Object.Destroy((Object)(object)((Component)_003C_003E4__this.m_projectile).gameObject);
					}
					_003CenemyToSpawn_003E5__1 = null;
					_003CTargetActor_003E5__3 = null;
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

	public float knockbackAmountAwayFromOwner;

	private Projectile m_projectile;

	private PlayerController projOwner;

	public float procChance;

	public float enemyBulletDamage;

	public bool companioniseEnemy;

	public bool killSpawnedEnemyOnRoomClear;

	public bool deleteProjAfterSpawn;

	public bool ignoreSpawnedEnemyForGoodMimic;

	public string guidToSpawn;

	public bool scaleEnemyDamage;

	public bool scaleEnemyProjSize;

	public bool scaleEnemyProjSpeed;

	public bool doPostProcessOnEnemyBullets;

	public SpawnEnemyOnBulletSpawn()
	{
		procChance = 1f;
		deleteProjAfterSpawn = true;
		companioniseEnemy = true;
		ignoreSpawnedEnemyForGoodMimic = true;
		killSpawnedEnemyOnRoomClear = true;
		doPostProcessOnEnemyBullets = true;
		scaleEnemyDamage = true;
		scaleEnemyProjSize = true;
		scaleEnemyProjSpeed = true;
		enemyBulletDamage = 10f;
	}

	private void Start()
	{
		m_projectile = ((Component)this).GetComponent<Projectile>();
		if (m_projectile.Owner is PlayerController)
		{
			ref PlayerController reference = ref projOwner;
			GameActor owner = m_projectile.Owner;
			reference = (PlayerController)(object)((owner is PlayerController) ? owner : null);
		}
		((MonoBehaviour)GameManager.Instance).StartCoroutine(handleSpawn());
	}

	private IEnumerator handleSpawn()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003ChandleSpawn_003Ed__2(0)
		{
			_003C_003E4__this = this
		};
	}

	private IEnumerator PostSpawn(AIActor spawnedEnemy, float knockbackAway, Vector2 dir)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CPostSpawn_003Ed__3(0)
		{
			_003C_003E4__this = this,
			spawnedEnemy = spawnedEnemy,
			knockbackAway = knockbackAway,
			dir = dir
		};
	}
}
