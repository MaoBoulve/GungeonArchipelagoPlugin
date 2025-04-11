using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class BolaControlla : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CLerpToMaxRadius_003Ed__3 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Projectile proj;

		public BolaControlla _003C_003E4__this;

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
		public _003CLerpToMaxRadius_003Ed__3(int _003C_003E1__state)
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
					goto IL_0122;
				}
				ref OrbitProjectileMotionModule reference = ref _003CmotionMod_003E5__1;
				ProjectileMotionModule overrideMotionModule = proj.OverrideMotionModule;
				reference = (OrbitProjectileMotionModule)(object)((overrideMotionModule is OrbitProjectileMotionModule) ? overrideMotionModule : null);
				_003Celapsed_003E5__2 = 0f;
				_003Cduration_003E5__3 = 0.5f;
			}
			if (_003Celapsed_003E5__2 < _003Cduration_003E5__3)
			{
				_003Celapsed_003E5__2 += _003C_003E4__this.m_projectile.LocalDeltaTime;
				_003Ct_003E5__4 = _003Celapsed_003E5__2 / _003Cduration_003E5__3;
				_003CcurrentRadius_003E5__5 = Mathf.Lerp(0.1f, 3f, _003Ct_003E5__4);
				_003CmotionMod_003E5__1.m_radius = _003CcurrentRadius_003E5__5;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			_003CmotionMod_003E5__1 = null;
			goto IL_0122;
			IL_0122:
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
	private sealed class _003CMakeProjectileSolid_003Ed__10 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Projectile projectile;

		public BolaControlla _003C_003E4__this;

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
		public _003CMakeProjectileSolid_003Ed__10(int _003C_003E1__state)
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
			//IL_0026: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = (object)new WaitForSeconds(0.2f);
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				((BraveBehaviour)projectile).specRigidbody.CollideWithTileMap = true;
				((BraveBehaviour)projectile).specRigidbody.Reinitialize();
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

	public GameObject bolaPrefab;

	public GameObject LinkVFXPrefab;

	private tk2dTiledSprite extantLink;

	private PlayerController bolaOwna;

	private Projectile m_projectile;

	private Projectile bolaProjectileA;

	private Projectile bolaProjectileB;

	public BolaControlla()
	{
		LinkVFXPrefab = BolaGun.LinkVFX;
	}

	private void OnDestroy()
	{
		Uncouple();
	}

	private void Start()
	{
		m_projectile = ((Component)this).GetComponent<Projectile>();
		if (Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(m_projectile)))
		{
			bolaOwna = ProjectileUtility.ProjectilePlayerOwner(m_projectile);
		}
		if ((Object)(object)bolaProjectileA == (Object)null || (Object)(object)bolaProjectileB == (Object)null)
		{
			bool invert = false;
			if (Random.value <= 0.5f)
			{
				invert = true;
			}
			bolaProjectileA = CreateBolaProjectile(isB: false, invert);
			bolaProjectileB = CreateBolaProjectile(isB: true, invert);
		}
	}

	private IEnumerator LerpToMaxRadius(Projectile proj)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CLerpToMaxRadius_003Ed__3(0)
		{
			_003C_003E4__this = this,
			proj = proj
		};
	}

	private void Update()
	{
		if ((Object)(object)LinkVFXPrefab == (Object)null)
		{
			LinkVFXPrefab = FakePrefab.Clone(((Component)Game.Items["shock_rounds"]).GetComponent<ComplexProjectileModifier>().ChainLightningVFX);
		}
		if (Object.op_Implicit((Object)(object)bolaProjectileA) && Object.op_Implicit((Object)(object)bolaProjectileB) && (Object)(object)extantLink == (Object)null)
		{
			tk2dTiledSprite component = SpawnManager.SpawnVFX(LinkVFXPrefab, false).GetComponent<tk2dTiledSprite>();
			extantLink = component;
		}
		if ((Object)(object)bolaProjectileA == (Object)null || (Object)(object)bolaProjectileB == (Object)null)
		{
			Uncouple();
			m_projectile.DieInAir(false, true, true, false);
		}
	}

	private void Uncouple()
	{
		if ((Object)(object)extantLink != (Object)null)
		{
			SpawnManager.Despawn(((Component)extantLink).gameObject);
			extantLink = null;
		}
		if (Object.op_Implicit((Object)(object)bolaProjectileA))
		{
			if (bolaProjectileA.baseData.speed < 0f)
			{
				ProjectileData baseData = bolaProjectileA.baseData;
				baseData.speed *= -1f;
				bolaProjectileA.UpdateSpeed();
			}
			bolaProjectileA.OverrideMotionModule = null;
			BulletLifeTimer bulletLifeTimer = ((Component)bolaProjectileA).gameObject.AddComponent<BulletLifeTimer>();
			bulletLifeTimer.secondsTillDeath = 30f;
		}
		if (Object.op_Implicit((Object)(object)bolaProjectileB))
		{
			if (bolaProjectileB.baseData.speed < 0f)
			{
				ProjectileData baseData2 = bolaProjectileB.baseData;
				baseData2.speed *= -1f;
				bolaProjectileB.UpdateSpeed();
			}
			bolaProjectileB.OverrideMotionModule = null;
			BulletLifeTimer bulletLifeTimer2 = ((Component)bolaProjectileB).gameObject.AddComponent<BulletLifeTimer>();
			bulletLifeTimer2.secondsTillDeath = 30f;
		}
	}

	private void FixedUpdate()
	{
		if (Object.op_Implicit((Object)(object)bolaProjectileA) && Object.op_Implicit((Object)(object)bolaProjectileB) && (Object)(object)extantLink != (Object)null)
		{
			UpdateLink(extantLink);
		}
	}

	private void UpdateLink(tk2dTiledSprite m_extantLink)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		Vector2 unitCenter = ((BraveBehaviour)bolaProjectileA).specRigidbody.UnitCenter;
		Vector2 unitCenter2 = ((BraveBehaviour)bolaProjectileB).specRigidbody.UnitCenter;
		((BraveBehaviour)m_extantLink).transform.position = Vector2.op_Implicit(unitCenter);
		Vector2 val = unitCenter2 - unitCenter;
		float num = BraveMathCollege.Atan2Degrees(((Vector2)(ref val)).normalized);
		int num2 = Mathf.RoundToInt(((Vector2)(ref val)).magnitude / 0.0625f);
		m_extantLink.dimensions = new Vector2((float)num2, m_extantLink.dimensions.y);
		((BraveBehaviour)m_extantLink).transform.rotation = Quaternion.Euler(0f, 0f, num);
		((tk2dBaseSprite)m_extantLink).UpdateZDepth();
		ApplyLinearDamage(unitCenter, unitCenter2);
	}

	private void ApplyLinearDamage(Vector2 p1, Vector2 p2)
	{
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		float num = 1f;
		for (int i = 0; i < StaticReferenceManager.AllEnemies.Count; i++)
		{
			AIActor val = StaticReferenceManager.AllEnemies[i];
			if (Object.op_Implicit((Object)(object)val) && val.HasBeenEngaged && val.IsNormalEnemy && Object.op_Implicit((Object)(object)((BraveBehaviour)val).specRigidbody))
			{
				Vector2 zero = Vector2.zero;
				if (BraveUtility.LineIntersectsAABB(p1, p2, ((BraveBehaviour)val).specRigidbody.HitboxPixelCollider.UnitBottomLeft, ((BraveBehaviour)val).specRigidbody.HitboxPixelCollider.UnitDimensions, ref zero))
				{
					((BraveBehaviour)val).healthHaver.ApplyDamage(num, Vector2.zero, "Bola Gun", (CoreDamageTypes)64, (DamageCategory)0, false, (PixelCollider)null, false);
				}
			}
		}
	}

	private Projectile CreateBolaProjectile(bool isB = false, bool invert = false)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Expected O, but got Unknown
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = SpawnManager.SpawnProjectile(bolaPrefab, Vector2.op_Implicit(((BraveBehaviour)m_projectile).specRigidbody.UnitCenter), Quaternion.Euler(0f, 0f, 0f), true);
		Projectile component = val.GetComponent<Projectile>();
		if ((Object)(object)component != (Object)null)
		{
			component.Owner = (GameActor)(object)bolaOwna;
			component.Shooter = ((BraveBehaviour)bolaOwna).specRigidbody;
			ProjectileData baseData = component.baseData;
			baseData.damage *= bolaOwna.stats.GetStatValue((StatType)5);
			ProjectileData baseData2 = component.baseData;
			baseData2.speed *= bolaOwna.stats.GetStatValue((StatType)6);
			ProjectileData baseData3 = component.baseData;
			baseData3.force *= bolaOwna.stats.GetStatValue((StatType)12);
			component.UpdateSpeed();
			if (invert)
			{
				ProjectileData baseData4 = component.baseData;
				baseData4.speed *= -1f;
				component.UpdateSpeed();
			}
			((BraveBehaviour)component).specRigidbody.CollideWithTileMap = false;
			component.pierceMinorBreakables = true;
			PierceProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<PierceProjModifier>(((Component)component).gameObject);
			orAddComponent.penetration++;
			OrbitProjectileMotionModule val2 = new OrbitProjectileMotionModule();
			val2.lifespan = 50f;
			val2.MinRadius = 0.1f;
			val2.MaxRadius = 0.1f;
			val2.usesAlternateOrbitTarget = true;
			val2.OrbitGroup = -6;
			val2.alternateOrbitTarget = ((BraveBehaviour)m_projectile).specRigidbody;
			if (isB)
			{
				((BraveBehaviour)component).transform.localRotation = Quaternion.Euler(0f, 0f, ((BraveBehaviour)component).transform.localRotation.z + 180f);
			}
			bolaOwna.DoPostProcessProjectile(component);
			if (component.OverrideMotionModule != null && component.OverrideMotionModule is HelixProjectileMotionModule)
			{
				val2.StackHelix = true;
				ref bool forceInvert = ref val2.ForceInvert;
				ProjectileMotionModule overrideMotionModule = component.OverrideMotionModule;
				forceInvert = ((HelixProjectileMotionModule)((overrideMotionModule is HelixProjectileMotionModule) ? overrideMotionModule : null)).ForceInvert;
			}
			component.OverrideMotionModule = (ProjectileMotionModule)(object)val2;
			((MonoBehaviour)this).StartCoroutine(LerpToMaxRadius(component));
			((MonoBehaviour)this).StartCoroutine(MakeProjectileSolid(component));
			return component;
		}
		return null;
	}

	private IEnumerator MakeProjectileSolid(Projectile projectile)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CMakeProjectileSolid_003Ed__10(0)
		{
			_003C_003E4__this = this,
			projectile = projectile
		};
	}
}
