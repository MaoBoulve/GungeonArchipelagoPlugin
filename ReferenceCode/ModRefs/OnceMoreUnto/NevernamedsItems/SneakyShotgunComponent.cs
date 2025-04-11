using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class SneakyShotgunComponent : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003ChandleShotgunBlast_003Ed__16 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public SneakyShotgunComponent _003C_003E4__this;

		private List<Projectile>.Enumerator _003C_003Es__1;

		private Projectile _003Cproj_003E5__2;

		private GameObject _003Cprefabtouse_003E5__3;

		private int _003Ci_003E5__4;

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
		public _003ChandleShotgunBlast_003Ed__16(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003C_003Es__1 = default(List<Projectile>.Enumerator);
			_003Cproj_003E5__2 = null;
			_003Cprefabtouse_003E5__3 = null;
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
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				if (_003C_003E4__this.useComplexPrefabs)
				{
					_003C_003Es__1 = _003C_003E4__this.complexPrefabs.GetEnumerator();
					try
					{
						while (_003C_003Es__1.MoveNext())
						{
							_003Cproj_003E5__2 = _003C_003Es__1.Current;
							_003C_003E4__this.FireIndiv(((Component)_003Cproj_003E5__2).gameObject);
							_003Cproj_003E5__2 = null;
						}
					}
					finally
					{
						((IDisposable)_003C_003Es__1/*cast due to .constrained prefix*/).Dispose();
					}
					_003C_003Es__1 = default(List<Projectile>.Enumerator);
				}
				else
				{
					_003Cprefabtouse_003E5__3 = ((Component)_003C_003E4__this.projPrefabToFire).gameObject;
					if (!string.IsNullOrEmpty(_003C_003E4__this.overrideProjectileSynergy) && (Object)(object)_003C_003E4__this.synergyProjectilePrefab != (Object)null && Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(_003C_003E4__this.self)) && CustomSynergies.PlayerHasActiveSynergy(ProjectileUtility.ProjectilePlayerOwner(_003C_003E4__this.self), _003C_003E4__this.overrideProjectileSynergy))
					{
						_003Cprefabtouse_003E5__3 = ((Component)_003C_003E4__this.synergyProjectilePrefab).gameObject;
					}
					_003Ci_003E5__4 = 0;
					while (_003Ci_003E5__4 < _003C_003E4__this.numToFire)
					{
						_003C_003E4__this.FireIndiv(_003Cprefabtouse_003E5__3);
						_003Ci_003E5__4++;
					}
					_003Cprefabtouse_003E5__3 = null;
				}
				if (_003C_003E4__this.eraseSource)
				{
					Object.Destroy((Object)(object)((Component)_003C_003E4__this.self).gameObject);
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

	public bool scaleOffOwnerAccuracy;

	public bool eraseSource;

	public float angleVariance;

	public int numToFire;

	public Projectile projPrefabToFire;

	public string overrideProjectileSynergy;

	public Projectile synergyProjectilePrefab;

	public bool postProcess;

	public bool doVelocityRandomiser;

	public float damageMult;

	public float scaleMult;

	public bool useComplexPrefabs;

	public List<Projectile> complexPrefabs = new List<Projectile>();

	private Projectile self;

	public SneakyShotgunComponent()
	{
		scaleOffOwnerAccuracy = true;
		eraseSource = true;
		numToFire = 5;
		ref Projectile reference = ref projPrefabToFire;
		PickupObject byId = PickupObjectDatabase.GetById(56);
		reference = ((Gun)((byId is Gun) ? byId : null)).DefaultModule.projectiles[0];
		postProcess = true;
		doVelocityRandomiser = true;
		angleVariance = 40f;
		scaleMult = 1f;
		damageMult = 1f;
		overrideProjectileSynergy = null;
		synergyProjectilePrefab = null;
		useComplexPrefabs = false;
	}

	private void Start()
	{
		self = ((Component)this).GetComponent<Projectile>();
		((MonoBehaviour)this).StartCoroutine(handleShotgunBlast());
	}

	private IEnumerator handleShotgunBlast()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003ChandleShotgunBlast_003Ed__16(0)
		{
			_003C_003E4__this = this
		};
	}

	private void FireIndiv(GameObject prefabtouse)
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		PlayerController playerToScaleAccuracyOff = null;
		if (scaleOffOwnerAccuracy && Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(self)))
		{
			playerToScaleAccuracyOff = ProjectileUtility.ProjectilePlayerOwner(self);
		}
		float accuracyAngled = ProjSpawnHelper.GetAccuracyAngled(Vector2Extensions.ToAngle(self.Direction), angleVariance, playerToScaleAccuracyOff);
		GameObject val = SpawnManager.SpawnProjectile(prefabtouse, ((BraveBehaviour)self).transform.position, Quaternion.Euler(new Vector3(0f, 0f, accuracyAngled)), true);
		Projectile component = val.GetComponent<Projectile>();
		if ((Object)(object)component != (Object)null)
		{
			component.Owner = self.Owner;
			component.Shooter = self.Shooter;
			if (doVelocityRandomiser)
			{
				ProjectileData baseData = component.baseData;
				baseData.speed *= 1f + Random.Range(-5f, 5f) / 100f;
			}
			component.UpdateSpeed();
			ProjectileData baseData2 = component.baseData;
			baseData2.damage *= damageMult;
			ProjectileData baseData3 = component.baseData;
			baseData3.force *= damageMult;
			component.RuntimeUpdateScale(scaleMult);
			if (postProcess && Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(self)))
			{
				ProjectileUtility.ProjectilePlayerOwner(self).DoPostProcessProjectile(component);
			}
		}
	}
}
