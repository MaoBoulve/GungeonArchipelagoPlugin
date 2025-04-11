using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class DimensionaliserPortal : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CBatAttack_003Ed__8 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public DimensionaliserPortal _003C_003E4__this;

		private int _003Ci_003E5__1;

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
		public _003CBatAttack_003Ed__8(int _003C_003E1__state)
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
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			//IL_003e: Expected O, but got Unknown
			//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ce: Expected O, but got Unknown
			//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00af: Unknown result type (might be due to invalid IL or missing references)
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = (object)new WaitForSeconds(1f);
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				_003Ci_003E5__1 = 0;
				break;
			case 2:
				_003C_003E1__state = -1;
				_003Ci_003E5__1++;
				break;
			}
			if (_003Ci_003E5__1 < 10)
			{
				if (ProjectileUtility.ProjectilePlayerOwner(_003C_003E4__this.self).IsInCombat)
				{
					CompanionisedEnemyUtility.SpawnCompanionisedEnemy(ProjectileUtility.ProjectilePlayerOwner(_003C_003E4__this.self), BraveUtility.RandomElement<string>(AlexandriaTags.GetAllEnemyGuidsWithTag("small_bullat")), Vector2Extensions.ToIntVector2(((BraveBehaviour)_003C_003E4__this.self).specRigidbody.UnitCenter, (VectorConversions)2), doTint: false, Color.red, 7, 2, shouldBeJammed: false, doFriendlyOverhead: false);
				}
				_003C_003E2__current = (object)new WaitForSeconds(0.1f);
				_003C_003E1__state = 2;
				return true;
			}
			_003C_003E4__this.Die();
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
	private sealed class _003CBlankyBlanky_003Ed__7 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public DimensionaliserPortal _003C_003E4__this;

		private int _003Ci_003E5__1;

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
		public _003CBlankyBlanky_003Ed__7(int _003C_003E1__state)
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
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			//IL_003b: Expected O, but got Unknown
			//IL_0075: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_0091: Expected O, but got Unknown
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = (object)new WaitForSeconds(1f);
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				_003Ci_003E5__1 = 0;
				break;
			case 2:
				_003C_003E1__state = -1;
				_003Ci_003E5__1++;
				break;
			}
			if (_003Ci_003E5__1 < 3)
			{
				PlayerUtility.DoEasyBlank(ProjectileUtility.ProjectilePlayerOwner(_003C_003E4__this.self), ((BraveBehaviour)_003C_003E4__this.self).specRigidbody.UnitCenter, (EasyBlankType)1);
				_003C_003E2__current = (object)new WaitForSeconds(3f);
				_003C_003E1__state = 2;
				return true;
			}
			_003C_003E4__this.Die();
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
	private sealed class _003CDelayedBlackHole_003Ed__4 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public DimensionaliserPortal _003C_003E4__this;

		private Projectile _003Cprojectile2_003E5__1;

		private GameObject _003CgameObject_003E5__2;

		private Projectile _003Ccomponent_003E5__3;

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
		public _003CDelayedBlackHole_003Ed__4(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003Cprojectile2_003E5__1 = null;
			_003CgameObject_003E5__2 = null;
			_003Ccomponent_003E5__3 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_0026: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			//IL_0086: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = (object)new WaitForSeconds(12f);
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				_003Cprojectile2_003E5__1 = ((Gun)Databases.Items["black_hole_gun"]).DefaultModule.projectiles[0];
				_003CgameObject_003E5__2 = SpawnManager.SpawnProjectile(((Component)_003Cprojectile2_003E5__1).gameObject, Vector2.op_Implicit(((BraveBehaviour)_003C_003E4__this.self).sprite.WorldCenter), Quaternion.Euler(0f, 0f, (float)Random.Range(1, 360)), true);
				_003Ccomponent_003E5__3 = _003CgameObject_003E5__2.GetComponent<Projectile>();
				if ((Object)(object)_003Ccomponent_003E5__3 != (Object)null)
				{
					_003Ccomponent_003E5__3.Owner = _003C_003E4__this.self.Owner;
					_003Ccomponent_003E5__3.Shooter = ((BraveBehaviour)_003C_003E4__this.self.Owner).specRigidbody;
					ProjectileData baseData = _003Ccomponent_003E5__3.baseData;
					baseData.speed *= 0.5f;
				}
				_003C_003E4__this.Die();
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
	private sealed class _003CFireStorm_003Ed__6 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public DimensionaliserPortal _003C_003E4__this;

		private DeadlyDeadlyGoopManager _003Cddgm_003E5__1;

		private int _003Ci_003E5__2;

		private GameObject _003CgameObject_003E5__3;

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
		public _003CFireStorm_003Ed__6(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003Cddgm_003E5__1 = null;
			_003CgameObject_003E5__3 = null;
			_003Ccomponent_003E5__4 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			//IL_003e: Expected O, but got Unknown
			//IL_0074: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_009a: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a4: Expected O, but got Unknown
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = (object)new WaitForSeconds(1f);
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				_003Cddgm_003E5__1 = DeadlyDeadlyGoopManager.GetGoopManagerForGoopType(EasyGoopDefinitions.FireDef);
				_003Cddgm_003E5__1.AddGoopCircle(((BraveBehaviour)_003C_003E4__this.self).sprite.WorldCenter, 5f, -1, false, -1);
				_003Ci_003E5__2 = 0;
				break;
			case 2:
			{
				_003C_003E1__state = -1;
				ref GameObject reference = ref _003CgameObject_003E5__3;
				PickupObject byId = PickupObjectDatabase.GetById(336);
				reference = SpawnManager.SpawnProjectile(((Component)((Gun)((byId is Gun) ? byId : null)).DefaultModule.projectiles[0]).gameObject, Vector2.op_Implicit(((BraveBehaviour)_003C_003E4__this.self).specRigidbody.UnitCenter), Quaternion.Euler(0f, 0f, (float)Random.Range(1, 360)), true);
				_003Ccomponent_003E5__4 = _003CgameObject_003E5__3.GetComponent<Projectile>();
				if ((Object)(object)_003Ccomponent_003E5__4 != (Object)null)
				{
					_003Ccomponent_003E5__4.Owner = _003C_003E4__this.self.Owner;
					_003Ccomponent_003E5__4.Shooter = ((BraveBehaviour)_003C_003E4__this.self.Owner).specRigidbody;
				}
				_003CgameObject_003E5__3 = null;
				_003Ccomponent_003E5__4 = null;
				_003Ci_003E5__2++;
				break;
			}
			}
			if (_003Ci_003E5__2 < 40)
			{
				_003C_003E2__current = (object)new WaitForSeconds(0.1f);
				_003C_003E1__state = 2;
				return true;
			}
			_003C_003E4__this.Die();
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
	private sealed class _003CHegemonyPlatoon_003Ed__2 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public DimensionaliserPortal _003C_003E4__this;

		private int _003Ci_003E5__1;

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
		public _003CHegemonyPlatoon_003Ed__2(int _003C_003E1__state)
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
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			//IL_003e: Expected O, but got Unknown
			//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c4: Expected O, but got Unknown
			//IL_0099: Unknown result type (might be due to invalid IL or missing references)
			//IL_009f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = (object)new WaitForSeconds(1f);
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				_003Ci_003E5__1 = 0;
				break;
			case 2:
				_003C_003E1__state = -1;
				_003Ci_003E5__1++;
				break;
			}
			if (_003Ci_003E5__1 < 3)
			{
				if (ProjectileUtility.ProjectilePlayerOwner(_003C_003E4__this.self).IsInCombat)
				{
					CompanionisedEnemyUtility.SpawnCompanionisedEnemy(ProjectileUtility.ProjectilePlayerOwner(_003C_003E4__this.self), "556e9f2a10f9411cb9dbfd61e0e0f1e1", Vector2Extensions.ToIntVector2(((BraveBehaviour)_003C_003E4__this.self).specRigidbody.UnitCenter, (VectorConversions)2), doTint: false, Color.red, 5, 2, shouldBeJammed: false, doFriendlyOverhead: true);
				}
				_003C_003E2__current = (object)new WaitForSeconds(0.8f);
				_003C_003E1__state = 2;
				return true;
			}
			_003C_003E4__this.Die();
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
	private sealed class _003CHentaiTime_003Ed__5 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public DimensionaliserPortal _003C_003E4__this;

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
		public _003CHentaiTime_003Ed__5(int _003C_003E1__state)
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
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			//IL_003e: Expected O, but got Unknown
			//IL_008d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0143: Unknown result type (might be due to invalid IL or missing references)
			//IL_0165: Unknown result type (might be due to invalid IL or missing references)
			//IL_016f: Expected O, but got Unknown
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = (object)new WaitForSeconds(1f);
				_003C_003E1__state = 1;
				return true;
			case 1:
			{
				_003C_003E1__state = -1;
				PickupObject byId = PickupObjectDatabase.GetById(474);
				BeamAPI.FreeFireBeamFromAnywhere(((Gun)((byId is Gun) ? byId : null)).DefaultModule.projectiles[0], ProjectileUtility.ProjectilePlayerOwner(_003C_003E4__this.self), ((Component)_003C_003E4__this.self).gameObject, Vector2.zero, 90f, 5f, true, false, 0f);
				PickupObject byId2 = PickupObjectDatabase.GetById(474);
				BeamAPI.FreeFireBeamFromAnywhere(((Gun)((byId2 is Gun) ? byId2 : null)).DefaultModule.projectiles[0], ProjectileUtility.ProjectilePlayerOwner(_003C_003E4__this.self), ((Component)_003C_003E4__this.self).gameObject, Vector2.zero, -45f, 5f, true, false, 0f);
				PickupObject byId3 = PickupObjectDatabase.GetById(474);
				BeamAPI.FreeFireBeamFromAnywhere(((Gun)((byId3 is Gun) ? byId3 : null)).DefaultModule.projectiles[0], ProjectileUtility.ProjectilePlayerOwner(_003C_003E4__this.self), ((Component)_003C_003E4__this.self).gameObject, Vector2.zero, -135f, 5f, true, false, 0f);
				_003C_003E2__current = (object)new WaitForSeconds(6f);
				_003C_003E1__state = 2;
				return true;
			}
			case 2:
				_003C_003E1__state = -1;
				_003C_003E4__this.Die();
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
	private sealed class _003CRingBullets_003Ed__3 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public DimensionaliserPortal _003C_003E4__this;

		private int _003Ci_003E5__1;

		private float _003Cdegrees_003E5__2;

		private int _003Ci2_003E5__3;

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
		public _003CRingBullets_003Ed__3(int _003C_003E1__state)
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
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			//IL_003e: Expected O, but got Unknown
			//IL_0086: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Expected O, but got Unknown
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = (object)new WaitForSeconds(1f);
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				_003Ci_003E5__1 = 0;
				break;
			case 2:
				_003C_003E1__state = -1;
				_003Ci_003E5__1++;
				break;
			}
			if (_003Ci_003E5__1 < 7)
			{
				_003Cdegrees_003E5__2 = 0f;
				_003Ci2_003E5__3 = 0;
				while (_003Ci2_003E5__3 < 15)
				{
					_003C_003E4__this.SpawnBullets(((BraveBehaviour)_003C_003E4__this.self).specRigidbody.UnitCenter, _003Cdegrees_003E5__2);
					_003Cdegrees_003E5__2 += 24f;
					_003Ci2_003E5__3++;
				}
				_003C_003E2__current = (object)new WaitForSeconds(1f);
				_003C_003E1__state = 2;
				return true;
			}
			_003C_003E4__this.Die();
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

	private Projectile self;

	public Projectile subProj;

	private void Start()
	{
		self = ((Component)this).GetComponent<Projectile>();
		if (Object.op_Implicit((Object)(object)self) && Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(self)))
		{
			switch (Random.Range(1, 8))
			{
			case 1:
				((MonoBehaviour)this).StartCoroutine(HegemonyPlatoon());
				break;
			case 2:
				((MonoBehaviour)this).StartCoroutine(RingBullets());
				break;
			case 3:
				((MonoBehaviour)this).StartCoroutine(DelayedBlackHole());
				break;
			case 4:
				((MonoBehaviour)this).StartCoroutine(HentaiTime());
				break;
			case 5:
				((MonoBehaviour)this).StartCoroutine(FireStorm());
				break;
			case 6:
				((MonoBehaviour)this).StartCoroutine(BlankyBlanky());
				break;
			case 7:
				((MonoBehaviour)this).StartCoroutine(BatAttack());
				break;
			}
		}
	}

	private IEnumerator HegemonyPlatoon()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CHegemonyPlatoon_003Ed__2(0)
		{
			_003C_003E4__this = this
		};
	}

	private IEnumerator RingBullets()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CRingBullets_003Ed__3(0)
		{
			_003C_003E4__this = this
		};
	}

	private IEnumerator DelayedBlackHole()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CDelayedBlackHole_003Ed__4(0)
		{
			_003C_003E4__this = this
		};
	}

	private IEnumerator HentaiTime()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CHentaiTime_003Ed__5(0)
		{
			_003C_003E4__this = this
		};
	}

	private IEnumerator FireStorm()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CFireStorm_003Ed__6(0)
		{
			_003C_003E4__this = this
		};
	}

	private IEnumerator BlankyBlanky()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CBlankyBlanky_003Ed__7(0)
		{
			_003C_003E4__this = this
		};
	}

	private IEnumerator BatAttack()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CBatAttack_003Ed__8(0)
		{
			_003C_003E4__this = this
		};
	}

	private void SpawnBullets(Vector2 pos, float rot)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = SpawnManager.SpawnProjectile(((Component)subProj).gameObject, Vector2.op_Implicit(pos), Quaternion.Euler(0f, 0f, rot), true);
		Projectile component = val.GetComponent<Projectile>();
		if ((Object)(object)component != (Object)null)
		{
			component.Owner = self.Owner;
			component.Shooter = ((BraveBehaviour)self.Owner).specRigidbody;
		}
	}

	private void Die()
	{
		self.DieInAir(false, true, true, false);
	}
}
