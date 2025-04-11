using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Repetitron : AdvancedGunBehavior
{
	public class ProjAndPositionData
	{
		public GameObject projectile;

		public Vector2 position;

		public float angle;
	}

	[CompilerGenerated]
	private sealed class _003CHandleAddToList_003Ed__8 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Projectile proj;

		public Repetitron _003C_003E4__this;

		private ProjAndPositionData _003CnewData_003E5__1;

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
		public _003CHandleAddToList_003Ed__8(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003CnewData_003E5__1 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_007c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0081: Unknown result type (might be due to invalid IL or missing references)
			//IL_0092: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b1: Expected O, but got Unknown
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
				_003CnewData_003E5__1 = new ProjAndPositionData();
				_003CnewData_003E5__1.projectile = FakePrefab.Clone(((Component)proj).gameObject);
				_003CnewData_003E5__1.position = ((BraveBehaviour)proj).specRigidbody.UnitCenter;
				_003CnewData_003E5__1.angle = Vector2Extensions.ToAngle(proj.Direction);
				_003C_003E2__current = (object)new WaitForSeconds(0.01f);
				_003C_003E1__state = 2;
				return true;
			case 2:
				_003C_003E1__state = -1;
				_003C_003E4__this.storedProjectiles.Add(_003CnewData_003E5__1);
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
	private sealed class _003CHandleReSpawn_003Ed__4 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Repetitron _003C_003E4__this;

		private int _003Ccount_003E5__1;

		private int _003Ci_003E5__2;

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
		public _003CHandleReSpawn_003Ed__4(int _003C_003E1__state)
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
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003Ccount_003E5__1 = _003C_003E4__this.storedProjectiles.Count;
				_003Ci_003E5__2 = 0;
				break;
			case 1:
				_003C_003E1__state = -1;
				_003Ci_003E5__2++;
				break;
			}
			if (_003Ci_003E5__2 < _003Ccount_003E5__1)
			{
				_003C_003E4__this.SpawnProjectile(_003C_003E4__this.storedProjectiles[_003Ci_003E5__2]);
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

	private List<ProjAndPositionData> storedProjectiles = new List<ProjAndPositionData>();

	public static void Add()
	{
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_022a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0263: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Repetitron", "repetiton");
		Game.Items.Rename("outdated_gun_mods:repetitron", "nn:repetitron");
		Repetitron repetitron = ((Component)val).gameObject.AddComponent<Repetitron>();
		GunExt.SetShortDescription((PickupObject)(object)val, "We've Done This Before");
		GunExt.SetLongDescription((PickupObject)(object)val, "Fires bullets... again... and again... and again.\n\nThis gun is powered by a miniature recursive sub-space anomaly. Do not look at the operational end.");
		val.SetGunSprites("repetiton");
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(89);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 0.2f;
		val.DefaultModule.angleVariance = 4f;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(89);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		val.DefaultModule.numberOfShotsInClip = 5;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2f, 0.25f, 0f);
		val.SetBaseMaxAmmo(200);
		val.ammo = 200;
		val.gunClass = (GunClass)50;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 1f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.force *= 1f;
		ProjectileData baseData3 = val2.baseData;
		baseData3.speed *= 1f;
		val2.hitEffects.alwaysUseMidair = true;
		val2.hitEffects.overrideMidairDeathVFX = SharedVFX.GreenLaserCircleVFX;
		ProjectileData baseData4 = val2.baseData;
		baseData4.range *= 0.5f;
		GunTools.SetProjectileSpriteRight(val2, "repetiton_projectile", 10, 7, true, (Anchor)4, (int?)9, (int?)6, true, false, (int?)null, (int?)null, (Projectile)null);
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Repetitron Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/repetitron_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/repetitron_clipempty");
		val.DefaultModule.projectiles[0] = val2;
		((PickupObject)val).quality = (ItemQuality)4;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
	}

	public override void OnReloadPressed(PlayerController player, Gun gun, bool manualReload)
	{
		storedProjectiles.Clear();
		((AdvancedGunBehavior)this).OnReloadPressed(player, gun, manualReload);
	}

	public override void OnPostFired(PlayerController player, Gun gun)
	{
		if (storedProjectiles.Count > 0)
		{
			((MonoBehaviour)player).StartCoroutine(HandleReSpawn());
		}
		((AdvancedGunBehavior)this).OnPostFired(player, gun);
	}

	private IEnumerator HandleReSpawn()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CHandleReSpawn_003Ed__4(0)
		{
			_003C_003E4__this = this
		};
	}

	public override void OnSwitchedAwayFromThisGun()
	{
		storedProjectiles.Clear();
		((AdvancedGunBehavior)this).OnSwitchedAwayFromThisGun();
	}

	private void SpawnProjectile(ProjAndPositionData data)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		Object.Instantiate<GameObject>(SharedVFX.GreenLaserCircleVFX, new Vector3(data.position.x, data.position.y), Quaternion.identity);
		GameObject val = SpawnManager.SpawnProjectile(data.projectile, new Vector3(data.position.x, data.position.y, 0f), Quaternion.Euler(0f, 0f, data.angle), true);
		Projectile component = val.GetComponent<Projectile>();
		if ((Object)(object)component != (Object)null)
		{
			component.Owner = ((AdvancedGunBehavior)this).Owner;
			component.Shooter = ((BraveBehaviour)((AdvancedGunBehavior)this).Owner).specRigidbody;
			component.collidesWithPlayer = false;
		}
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		((MonoBehaviour)GameManager.Instance).StartCoroutine(HandleAddToList(projectile));
		((AdvancedGunBehavior)this).PostProcessProjectile(projectile);
	}

	private IEnumerator HandleAddToList(Projectile proj)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CHandleAddToList_003Ed__8(0)
		{
			_003C_003E4__this = this,
			proj = proj
		};
	}
}
