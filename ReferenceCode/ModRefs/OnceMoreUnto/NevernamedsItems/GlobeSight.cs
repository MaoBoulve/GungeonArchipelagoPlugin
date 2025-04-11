using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class GlobeSight : TableFlipItem
{
	[CompilerGenerated]
	private sealed class _003CLerpToMaxRadius_003Ed__7 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Projectile proj;

		public float radius;

		public GlobeSight _003C_003E4__this;

		private OrbitProjectileMotionModule _003CmotionMod_003E5__1;

		private float _003Celapsed_003E5__2;

		private float _003Cduration_003E5__3;

		private float _003Ct_003E5__4;

		private float _003CcurrentRadius_003E5__5;

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
		public _003CLerpToMaxRadius_003Ed__7(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003CmotionMod_003E5__1 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			int num = _003C_003E1__state;
			if (num != 0)
			{
				if (num != 1)
				{
					return false;
				}
				_003C_003E1__state = -1;
			}
			else
			{
				_003C_003E1__state = -1;
				if (!Object.op_Implicit((Object)(object)proj) || proj.OverrideMotionModule == null)
				{
					return false;
				}
				if (!(proj.OverrideMotionModule is OrbitProjectileMotionModule))
				{
					goto IL_011e;
				}
				ref OrbitProjectileMotionModule reference = ref _003CmotionMod_003E5__1;
				ProjectileMotionModule overrideMotionModule = proj.OverrideMotionModule;
				reference = (OrbitProjectileMotionModule)(object)((overrideMotionModule is OrbitProjectileMotionModule) ? overrideMotionModule : null);
				_003Celapsed_003E5__2 = 0f;
				_003Cduration_003E5__3 = 1f;
			}
			if (_003Celapsed_003E5__2 < _003Cduration_003E5__3)
			{
				_003Celapsed_003E5__2 += proj.LocalDeltaTime;
				_003Ct_003E5__4 = _003Celapsed_003E5__2 / _003Cduration_003E5__3;
				_003CcurrentRadius_003E5__5 = Mathf.Lerp(0.1f, radius, _003Ct_003E5__4);
				_003CmotionMod_003E5__1.m_radius = _003CcurrentRadius_003E5__5;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			_003CmotionMod_003E5__1 = null;
			goto IL_011e;
			IL_011e:
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

	public static GameObject dummy;

	public static Projectile Orbital;

	public static int ID;

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected O, but got Unknown
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<GlobeSight>("Globe Sight", "The World Goes Round", "Releases orbital momentum from inanimate objects.\n\nPeering through this sight makes your head spin.", "globesight_icon", assetbundle: true);
		val.quality = (ItemQuality)2;
		ID = val.PickupObjectId;
		dummy = new GameObject("Orbit Center Dummy");
		SpeculativeRigidbody orAddComponent = GameObjectExtensions.GetOrAddComponent<SpeculativeRigidbody>(dummy);
		orAddComponent.PixelColliders = new List<PixelCollider>();
		orAddComponent.PixelColliders.Add(new PixelCollider
		{
			ColliderGenerationMode = (PixelColliderGeneration)0,
			CollisionLayer = (CollisionLayer)7,
			ManualWidth = 1,
			ManualHeight = 1,
			ManualOffsetX = 0,
			ManualOffsetY = 0,
			Enabled = true,
			IsTrigger = false
		});
		orAddComponent.CollideWithOthers = false;
		FakePrefabExtensions.MakeFakePrefab(dummy);
		Orbital = ProjectileUtility.SetupProjectile(86);
		((Object)((Component)Orbital).gameObject).name = "Globesight Orbital Projectile";
		Orbital.baseData.damage = 8f;
		Orbital.baseData.force = 0.1f;
		NoCollideBehaviour noCollideBehaviour = ((Component)Orbital).gameObject.AddComponent<NoCollideBehaviour>();
		noCollideBehaviour.worksOnEnemies = false;
		Orbital.baseData.range = 100000f;
		((BraveBehaviour)Orbital).specRigidbody.CollideWithTileMap = false;
		Orbital.pierceMinorBreakables = true;
		Orbital.hitEffects.overrideMidairDeathVFX = SharedVFX.SmoothLightBlueLaserCircleVFX;
		Orbital.hitEffects.alwaysUseMidair = true;
		BulletLifeTimer bulletLifeTimer = ((Component)Orbital).gameObject.AddComponent<BulletLifeTimer>();
		bulletLifeTimer.secondsTillDeath = 15f;
		ProjectileBuilders.AnimateProjectileBundle(Orbital, "GlobesightProjectile", Initialisation.ProjectileCollection, Initialisation.projectileAnimationCollection, "GlobesightProjectile", MiscTools.DupeList<IntVector2>(new IntVector2(7, 7), 5), MiscTools.DupeList(value: false, 5), MiscTools.DupeList<Anchor>((Anchor)4, 5), MiscTools.DupeList(value: true, 5), MiscTools.DupeList(value: false, 5), MiscTools.DupeList<Vector3?>(null, 5), MiscTools.DupeList((IntVector2?)new IntVector2(7, 7), 5), MiscTools.DupeList<IntVector2?>(null, 5), MiscTools.DupeList<Projectile>(null, 5));
	}

	public override void Pickup(PlayerController player)
	{
		OMITBActions.MinorBreakableBroken = (Action<MinorBreakable>)Delegate.Combine(OMITBActions.MinorBreakableBroken, new Action<MinorBreakable>(SpawnOrbital));
		((TableFlipItem)this).Pickup(player);
	}

	public override void DisableEffect(PlayerController player)
	{
		if (Object.op_Implicit((Object)(object)player))
		{
			OMITBActions.MinorBreakableBroken = (Action<MinorBreakable>)Delegate.Remove(OMITBActions.MinorBreakableBroken, new Action<MinorBreakable>(SpawnOrbital));
		}
		((PassiveItem)this).DisableEffect(player);
	}

	private void SpawnOrbital(MinorBreakable obj)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Expected O, but got Unknown
		Vector2 val = Vector2.op_Implicit(((BraveBehaviour)obj).transform.position);
		if (Object.op_Implicit((Object)(object)((BraveBehaviour)obj).specRigidbody))
		{
			val = ((BraveBehaviour)obj).specRigidbody.UnitCenter;
		}
		GameObject val2 = Object.Instantiate<GameObject>(dummy, Vector2.op_Implicit(val), Quaternion.identity);
		GameObject val3 = ProjectileUtility.InstantiateAndFireInDirection(Orbital, val, 0f, 0f, (PlayerController)null);
		Projectile component = val3.GetComponent<Projectile>();
		if ((Object)(object)component != (Object)null)
		{
			component.Owner = (GameActor)(object)((PassiveItem)this).Owner;
			component.Shooter = ((BraveBehaviour)((PassiveItem)this).Owner).specRigidbody;
			component.ScaleByPlayerStats(((PassiveItem)this).Owner);
			((PassiveItem)this).Owner.DoPostProcessProjectile(component);
			ProjectileData baseData = component.baseData;
			baseData.speed *= Random.Range(0.8f, 1.2f);
			component.UpdateSpeed();
			OrbitProjectileMotionModule val4 = new OrbitProjectileMotionModule();
			val4.lifespan = 15f;
			val4.MinRadius = 0.1f;
			val4.MaxRadius = 0.1f;
			val4.usesAlternateOrbitTarget = true;
			val4.OrbitGroup = -7;
			val4.alternateOrbitTarget = val2.GetComponent<SpeculativeRigidbody>();
			component.OverrideMotionModule = (ProjectileMotionModule)(object)val4;
			((MonoBehaviour)this).StartCoroutine(LerpToMaxRadius(component, 3.5f));
		}
		Object.Destroy((Object)(object)val2, 20f);
	}

	private IEnumerator LerpToMaxRadius(Projectile proj, float radius)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CLerpToMaxRadius_003Ed__7(0)
		{
			_003C_003E4__this = this,
			proj = proj,
			radius = radius
		};
	}
}
