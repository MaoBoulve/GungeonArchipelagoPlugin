using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class ViperProjModifier : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CHandleDeathSpawns_003Ed__7 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ViperProjModifier _003C_003E4__this;

		private bool _003CisLeft_003E5__1;

		private List<Vector3>.Enumerator _003C_003Es__2;

		private Vector3 _003Cvector_003E5__3;

		private float _003Crotation_003E5__4;

		private GameObject _003Cobj_003E5__5;

		private Projectile _003Ccomponent_003E5__6;

		private PierceProjModifier _003Cpiercing_003E5__7;

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
		public _003CHandleDeathSpawns_003Ed__7(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int num = _003C_003E1__state;
			if (num == -3 || num == 1)
			{
				try
				{
				}
				finally
				{
					_003C_003Em__Finally1();
				}
			}
			_003C_003Es__2 = default(List<Vector3>.Enumerator);
			_003Cobj_003E5__5 = null;
			_003Ccomponent_003E5__6 = null;
			_003Cpiercing_003E5__7 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_010f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0124: Unknown result type (might be due to invalid IL or missing references)
			try
			{
				switch (_003C_003E1__state)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					_003CisLeft_003E5__1 = true;
					_003C_003Es__2 = _003C_003E4__this.cachedPositions.GetEnumerator();
					_003C_003E1__state = -3;
					break;
				case 1:
					_003C_003E1__state = -3;
					_003Cobj_003E5__5 = null;
					_003Ccomponent_003E5__6 = null;
					break;
				}
				if (_003C_003Es__2.MoveNext())
				{
					_003Cvector_003E5__3 = _003C_003Es__2.Current;
					_003Crotation_003E5__4 = _003Cvector_003E5__3.z;
					if (_003CisLeft_003E5__1)
					{
						_003Crotation_003E5__4 -= 90f;
						_003CisLeft_003E5__1 = false;
					}
					else
					{
						_003Crotation_003E5__4 += 90f;
						_003CisLeft_003E5__1 = true;
					}
					Object.Instantiate<GameObject>(SharedVFX.RedLaserCircleVFX, new Vector3(_003Cvector_003E5__3.x, _003Cvector_003E5__3.y), Quaternion.identity);
					_003Cobj_003E5__5 = SpawnManager.SpawnProjectile(((Component)_003C_003E4__this.projToSpawn).gameObject, new Vector3(_003Cvector_003E5__3.x, _003Cvector_003E5__3.y, 0f), Quaternion.Euler(0f, 0f, _003Crotation_003E5__4), true);
					_003Ccomponent_003E5__6 = _003Cobj_003E5__5.GetComponent<Projectile>();
					if ((Object)(object)_003Ccomponent_003E5__6 != (Object)null)
					{
						_003Ccomponent_003E5__6.Owner = (GameActor)(object)_003C_003E4__this.Owner;
						_003Ccomponent_003E5__6.Shooter = ((BraveBehaviour)_003C_003E4__this.Owner).specRigidbody;
						_003Ccomponent_003E5__6.collidesWithPlayer = false;
						ProjectileData baseData = _003Ccomponent_003E5__6.baseData;
						baseData.damage *= _003C_003E4__this.Owner.stats.GetStatValue((StatType)5);
						ProjectileData baseData2 = _003Ccomponent_003E5__6.baseData;
						baseData2.range *= _003C_003E4__this.Owner.stats.GetStatValue((StatType)26);
						ProjectileData baseData3 = _003Ccomponent_003E5__6.baseData;
						baseData3.force *= _003C_003E4__this.Owner.stats.GetStatValue((StatType)12);
						ProjectileData baseData4 = _003Ccomponent_003E5__6.baseData;
						baseData4.speed *= _003C_003E4__this.Owner.stats.GetStatValue((StatType)6);
						Projectile obj = _003Ccomponent_003E5__6;
						obj.AdditionalScaleMultiplier *= _003C_003E4__this.Owner.stats.GetStatValue((StatType)15);
						_003C_003E4__this.Owner.DoPostProcessProjectile(_003Ccomponent_003E5__6);
						if (CustomSynergies.PlayerHasActiveSynergy(_003C_003E4__this.Owner, "Sniper Viper"))
						{
							ProjectileData baseData5 = _003Ccomponent_003E5__6.baseData;
							baseData5.speed *= 2f;
							_003Cpiercing_003E5__7 = GameObjectExtensions.GetOrAddComponent<PierceProjModifier>(((Component)_003Ccomponent_003E5__6).gameObject);
							PierceProjModifier obj2 = _003Cpiercing_003E5__7;
							obj2.penetration++;
							_003Cpiercing_003E5__7.penetratesBreakables = true;
							_003Cpiercing_003E5__7 = null;
						}
					}
					_003C_003E2__current = null;
					_003C_003E1__state = 1;
					return true;
				}
				_003C_003Em__Finally1();
				_003C_003Es__2 = default(List<Vector3>.Enumerator);
				return false;
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private void _003C_003Em__Finally1()
		{
			_003C_003E1__state = -1;
			((IDisposable)_003C_003Es__2/*cast due to .constrained prefix*/).Dispose();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}
	}

	private List<Vector3> cachedPositions = new List<Vector3>();

	private float LastCheckedDistance = 0f;

	public int DistanceBetweenPositions;

	private Projectile m_projectile;

	private PlayerController Owner;

	public Projectile projToSpawn;

	public ViperProjModifier()
	{
		DistanceBetweenPositions = 2;
	}

	private void Start()
	{
		m_projectile = ((Component)this).GetComponent<Projectile>();
		if (Object.op_Implicit((Object)(object)m_projectile.Owner) && m_projectile.Owner is PlayerController)
		{
			ref PlayerController owner = ref Owner;
			GameActor owner2 = m_projectile.Owner;
			owner = (PlayerController)(object)((owner2 is PlayerController) ? owner2 : null);
		}
		m_projectile.OnDestruction += Death;
	}

	private void Update()
	{
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)m_projectile) && m_projectile.GetElapsedDistance() > LastCheckedDistance + (float)DistanceBetweenPositions)
		{
			cachedPositions.Add(new Vector3(((BraveBehaviour)m_projectile).transform.position.x, ((BraveBehaviour)m_projectile).transform.position.y, Vector2Extensions.ToAngle(m_projectile.Direction)));
			LastCheckedDistance = m_projectile.GetElapsedDistance();
		}
	}

	private void Death(Projectile bullet)
	{
		if (cachedPositions.Count > 0)
		{
			((MonoBehaviour)GameManager.Instance.Dungeon).StartCoroutine(HandleDeathSpawns());
		}
	}

	private IEnumerator HandleDeathSpawns()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CHandleDeathSpawns_003Ed__7(0)
		{
			_003C_003E4__this = this
		};
	}
}
