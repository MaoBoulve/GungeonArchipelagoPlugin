using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class TableTechAstronomy : TableFlipItem
{
	[CompilerGenerated]
	private sealed class _003CLerpToMaxRadius_003Ed__15 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Projectile proj;

		public float radius;

		public TableTechAstronomy _003C_003E4__this;

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
		public _003CLerpToMaxRadius_003Ed__15(int _003C_003E1__state)
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

	public static int ID;

	public static ParticleSystem SpaceFog;

	public static Projectile Mercury;

	public static Projectile Venus;

	public static Projectile Earth;

	public static Projectile Mars;

	public static Projectile Jupiter;

	public static Projectile Saturn;

	public static Projectile Uranus;

	public static Projectile Neptune;

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<TableTechAstronomy>("Table Tech Astronomy", "The Flip Beyond", "Flipped tables conjure a simulacrum of the heavens\n\n Among secretive flipping circles, there is a cryptic proverb; A table flipped properly will never come back down.", "tabletechastronomy_icon", assetbundle: true);
		val.quality = (ItemQuality)3;
		ID = val.PickupObjectId;
		AlexandriaTags.SetTag(val, "table_tech");
		SpaceFog = ((Component)PickupObjectDatabase.GetById(597)).gameObject.GetComponent<GunParticleSystemController>().TargetSystem;
		PickupObject byId = PickupObjectDatabase.GetById(597);
		Mercury = ((Gun)((byId is Gun) ? byId : null)).DefaultModule.projectiles[0];
		PickupObject byId2 = PickupObjectDatabase.GetById(597);
		Venus = ((Gun)((byId2 is Gun) ? byId2 : null)).DefaultModule.projectiles[1];
		PickupObject byId3 = PickupObjectDatabase.GetById(597);
		Earth = ((Gun)((byId3 is Gun) ? byId3 : null)).DefaultModule.projectiles[2];
		PickupObject byId4 = PickupObjectDatabase.GetById(597);
		Mars = ((Gun)((byId4 is Gun) ? byId4 : null)).DefaultModule.projectiles[3];
		PickupObject byId5 = PickupObjectDatabase.GetById(597);
		Jupiter = ((Gun)((byId5 is Gun) ? byId5 : null)).DefaultModule.projectiles[4];
		PickupObject byId6 = PickupObjectDatabase.GetById(597);
		Saturn = ((Gun)((byId6 is Gun) ? byId6 : null)).DefaultModule.projectiles[5];
		PickupObject byId7 = PickupObjectDatabase.GetById(597);
		Uranus = ((Gun)((byId7 is Gun) ? byId7 : null)).DefaultModule.projectiles[6];
		PickupObject byId8 = PickupObjectDatabase.GetById(597);
		Neptune = ((Gun)((byId8 is Gun) ? byId8 : null)).DefaultModule.projectiles[7];
	}

	public override void Pickup(PlayerController player)
	{
		player.OnTableFlipped = (Action<FlippableCover>)Delegate.Combine(player.OnTableFlipped, new Action<FlippableCover>(SpawnPlanets));
		((TableFlipItem)this).Pickup(player);
	}

	public override void DisableEffect(PlayerController player)
	{
		if (Object.op_Implicit((Object)(object)player))
		{
			player.OnTableFlipped = (Action<FlippableCover>)Delegate.Remove(player.OnTableFlipped, new Action<FlippableCover>(SpawnPlanets));
		}
		((PassiveItem)this).DisableEffect(player);
	}

	private void SpawnPlanets(FlippableCover obj)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Invalid comparison between Unknown and I4
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Invalid comparison between Unknown and I4
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		if ((int)GameManager.Options.ShaderQuality == 2 || (int)GameManager.Options.ShaderQuality == 1)
		{
			EmitParams val = default(EmitParams);
			((EmitParams)(ref val)).position = ((BraveBehaviour)obj).transform.position;
			SpaceFog.Emit(val, 5);
		}
		InitPlanet(Mercury, Vector2.op_Implicit(((BraveBehaviour)obj).transform.position), 2f, ((BraveBehaviour)obj).specRigidbody);
		InitPlanet(Venus, Vector2.op_Implicit(((BraveBehaviour)obj).transform.position), 3f, ((BraveBehaviour)obj).specRigidbody);
		InitPlanet(Earth, Vector2.op_Implicit(((BraveBehaviour)obj).transform.position), 4f, ((BraveBehaviour)obj).specRigidbody);
		InitPlanet(Mars, Vector2.op_Implicit(((BraveBehaviour)obj).transform.position), 5f, ((BraveBehaviour)obj).specRigidbody);
		InitPlanet(Jupiter, Vector2.op_Implicit(((BraveBehaviour)obj).transform.position), 7f, ((BraveBehaviour)obj).specRigidbody);
		InitPlanet(Saturn, Vector2.op_Implicit(((BraveBehaviour)obj).transform.position), 9f, ((BraveBehaviour)obj).specRigidbody);
		InitPlanet(Uranus, Vector2.op_Implicit(((BraveBehaviour)obj).transform.position), 11f, ((BraveBehaviour)obj).specRigidbody);
		InitPlanet(Neptune, Vector2.op_Implicit(((BraveBehaviour)obj).transform.position), 13f, ((BraveBehaviour)obj).specRigidbody);
	}

	public void InitPlanet(Projectile proj, Vector2 v, float radius, SpeculativeRigidbody cover)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Expected O, but got Unknown
		GameObject val = ProjectileUtility.InstantiateAndFireInDirection(proj, v, 0f, 0f, (PlayerController)null);
		Projectile component = val.GetComponent<Projectile>();
		if ((Object)(object)component != (Object)null)
		{
			component.Owner = (GameActor)(object)((PassiveItem)this).Owner;
			component.Shooter = ((BraveBehaviour)((PassiveItem)this).Owner).specRigidbody;
			NoCollideBehaviour noCollideBehaviour = val.AddComponent<NoCollideBehaviour>();
			noCollideBehaviour.worksOnEnemies = false;
			((BraveBehaviour)component).specRigidbody.CollideWithTileMap = false;
			component.pierceMinorBreakables = true;
			component.ScaleByPlayerStats(((PassiveItem)this).Owner);
			((PassiveItem)this).Owner.DoPostProcessProjectile(component);
			ProjectileData baseData = component.baseData;
			baseData.speed *= Random.Range(0.5f, 1.5f);
			component.UpdateSpeed();
			OrbitProjectileMotionModule val2 = new OrbitProjectileMotionModule();
			val2.lifespan = 50f;
			val2.MinRadius = 0.1f;
			val2.MaxRadius = 0.1f;
			val2.usesAlternateOrbitTarget = true;
			val2.OrbitGroup = -6;
			val2.alternateOrbitTarget = cover;
			component.OverrideMotionModule = (ProjectileMotionModule)(object)val2;
			((MonoBehaviour)this).StartCoroutine(LerpToMaxRadius(component, radius));
		}
	}

	private IEnumerator LerpToMaxRadius(Projectile proj, float radius)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CLerpToMaxRadius_003Ed__15(0)
		{
			_003C_003E4__this = this,
			proj = proj,
			radius = radius
		};
	}
}
