using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using InControl;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class FlayedRevolver : AdvancedGunBehavior
{
	[CompilerGenerated]
	private sealed class _003CLerpToMaxRadius_003Ed__5 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Projectile proj;

		public float radius;

		public FlayedRevolver _003C_003E4__this;

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
		public _003CLerpToMaxRadius_003Ed__5(int _003C_003E1__state)
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

	public static GameObject dummyCenter;

	public static int FlayedRevolverID;

	public GameObject reticleQuad;

	private tk2dBaseSprite m_extantReticleQuad;

	private float m_currentAngle;

	private float m_currentDistance = 5f;

	public static void Add()
	{
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Expected O, but got Unknown
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Expected O, but got Unknown
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Flayed Revolver", "flayedrevolver2");
		Game.Items.Rename("outdated_gun_mods:flayed_revolver", "nn:flayed_revolver");
		((Component)val).gameObject.AddComponent<FlayedRevolver>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Sinister Bells");
		GunExt.SetLongDescription((PickupObject)(object)val, "The favoured weapon of the cruel Mine Flayer, Planar lord of rings.\n\nReloading a full clip allows the bearer to slip beyond the curtain, if only briefly.");
		GunInt.SetupSprite(val, Initialisation.gunCollection, "flayedrevolver2_idle_001", 13, "flayedrevolver2_ammonomicon_001");
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(35);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 12);
		PickupObject byId2 = PickupObjectDatabase.GetById(35);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1.1f;
		val.SetBarrel(28, 15);
		val.SetBaseMaxAmmo(250);
		val.gunClass = (GunClass)1;
		val.DefaultModule.numberOfShotsInClip = 6;
		val.DefaultModule.cooldownTime = 0.1f;
		val.DefaultModule.projectiles[0] = ProjectileSetupUtility.MakeProjectile(35, 9.9f);
		val.AddShellCasing(0, 0, 6, 1);
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		FlayedRevolverID = ((PickupObject)val).PickupObjectId;
		((PickupObject)(object)val).SetupUnlockOnCustomStat(CustomTrackedStats.MINEFLAYER_KILLS, 9f, (PrerequisiteOperation)2);
		dummyCenter = new GameObject();
		FakePrefabExtensions.MakeFakePrefab(dummyCenter);
		SpeculativeRigidbody orAddComponent = GameObjectExtensions.GetOrAddComponent<SpeculativeRigidbody>(dummyCenter);
		PixelCollider val2 = new PixelCollider();
		val2.ColliderGenerationMode = (PixelColliderGeneration)0;
		val2.CollisionLayer = (CollisionLayer)3;
		val2.ManualWidth = 1;
		val2.ManualHeight = 1;
		val2.ManualOffsetX = 0;
		val2.ManualOffsetY = 0;
		orAddComponent.PixelColliders = new List<PixelCollider> { val2 };
		orAddComponent.CollideWithOthers = false;
	}

	public override void OnReloadPressedSafe(PlayerController player, Gun gun, bool manualReload)
	{
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		if ((gun.ClipCapacity != gun.ClipShotsRemaining && gun.CurrentAmmo != gun.ClipShotsRemaining) || gun.CurrentAmmo < 5)
		{
			return;
		}
		if (Object.op_Implicit((Object)(object)m_extantReticleQuad))
		{
			gun.CurrentAmmo -= 5;
			Vector2 worldCenter = m_extantReticleQuad.WorldCenter;
			Object.Destroy((Object)(object)((Component)m_extantReticleQuad).gameObject);
			worldCenter += new Vector2(1.5f, 1.5f);
			if (CustomSynergies.PlayerHasActiveSynergy(player, "Lord of Rings"))
			{
				DoRing(((GameActor)player).CenterPosition, 6f, player);
			}
			TeleportPlayerToCursorPosition.StartTeleport(player, worldCenter);
		}
		else
		{
			GameObject val = Object.Instantiate<GameObject>(reticleQuad);
			m_extantReticleQuad = val.GetComponent<tk2dBaseSprite>();
			m_currentAngle = BraveMathCollege.Atan2Degrees(Vector3Extensions.XY(player.unadjustedAimPoint) - ((GameActor)player).CenterPosition);
			m_currentDistance = 5f;
			UpdateReticlePosition();
		}
	}

	public void DoRing(Vector2 v, float radius, PlayerController owner)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Expected O, but got Unknown
		GameObject val = Object.Instantiate<GameObject>(dummyCenter, Vector2.op_Implicit(v), Quaternion.identity);
		SpeculativeRigidbody component = val.GetComponent<SpeculativeRigidbody>();
		int num = 0;
		for (int i = 0; i < 6; i++)
		{
			GameObject val2 = ProjectileUtility.InstantiateAndFireInDirection(base.gun.DefaultModule.projectiles[0], v, 0f, 0f, (PlayerController)null);
			Projectile component2 = val2.GetComponent<Projectile>();
			if ((Object)(object)component2 != (Object)null)
			{
				component2.Owner = ((AdvancedGunBehavior)this).Owner;
				component2.Shooter = ((BraveBehaviour)((AdvancedGunBehavior)this).Owner).specRigidbody;
				NoCollideBehaviour noCollideBehaviour = val2.AddComponent<NoCollideBehaviour>();
				noCollideBehaviour.worksOnEnemies = false;
				((BraveBehaviour)component2).specRigidbody.CollideWithTileMap = false;
				component2.pierceMinorBreakables = true;
				ProjectileData baseData = component2.baseData;
				baseData.range *= 2f;
				((BraveBehaviour)component2).transform.localRotation = Quaternion.Euler(0f, 0f, ((BraveBehaviour)component2).transform.localRotation.z + (float)num);
				num += 60;
				component2.ScaleByPlayerStats(owner);
				owner.DoPostProcessProjectile(component2);
				component2.shouldRotate = true;
				OrbitProjectileMotionModule val3 = new OrbitProjectileMotionModule();
				val3.lifespan = 50f;
				val3.MinRadius = 0.1f;
				val3.MaxRadius = 0.1f;
				val3.usesAlternateOrbitTarget = true;
				val3.OrbitGroup = -6;
				val3.alternateOrbitTarget = component;
				component2.OverrideMotionModule = (ProjectileMotionModule)(object)val3;
				((MonoBehaviour)component2).StartCoroutine(LerpToMaxRadius(component2, radius));
			}
		}
	}

	private IEnumerator LerpToMaxRadius(Projectile proj, float radius)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CLerpToMaxRadius_003Ed__5(0)
		{
			_003C_003E4__this = this,
			proj = proj,
			radius = radius
		};
	}

	protected override void Update()
	{
		if (Object.op_Implicit((Object)(object)m_extantReticleQuad))
		{
			UpdateReticlePosition();
		}
		((AdvancedGunBehavior)this).Update();
	}

	public override void OnSwitchedAwayFromThisGun()
	{
		if (Object.op_Implicit((Object)(object)m_extantReticleQuad))
		{
			Object.Destroy((Object)(object)((Component)m_extantReticleQuad).gameObject);
		}
		((AdvancedGunBehavior)this).OnSwitchedAwayFromThisGun();
	}

	public override void OnPostFired(PlayerController player, Gun gun)
	{
		if (Object.op_Implicit((Object)(object)m_extantReticleQuad))
		{
			Object.Destroy((Object)(object)((Component)m_extantReticleQuad).gameObject);
		}
		((AdvancedGunBehavior)this).OnPostFired(player, gun);
	}

	private void UpdateReticlePosition()
	{
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		PlayerController val = GunTools.GunPlayerOwner(base.gun);
		if (Object.op_Implicit((Object)(object)val))
		{
			Bounds bounds;
			if (BraveInput.GetInstanceForPlayer(val.PlayerIDX).IsKeyboardAndMouse(false))
			{
				Vector2 val2 = Vector3Extensions.XY(val.unadjustedAimPoint);
				bounds = m_extantReticleQuad.GetBounds();
				Vector2 val3 = val2 - Vector3Extensions.XY(((Bounds)(ref bounds)).extents);
				((BraveBehaviour)m_extantReticleQuad).transform.position = Vector2.op_Implicit(val3);
				return;
			}
			BraveInput instanceForPlayer = BraveInput.GetInstanceForPlayer(val.PlayerIDX);
			Vector2 val4 = ((GameActor)val).CenterPosition + Vector3Extensions.XY(Quaternion.Euler(0f, 0f, m_currentAngle) * Vector2.op_Implicit(Vector2.right)) * m_currentDistance;
			val4 += ((TwoAxisInputControl)instanceForPlayer.ActiveActions.Aim).Vector * 12f * BraveTime.DeltaTime;
			m_currentAngle = BraveMathCollege.Atan2Degrees(val4 - ((GameActor)val).CenterPosition);
			m_currentDistance = Vector2.Distance(val4, ((GameActor)val).CenterPosition);
			m_currentDistance = Mathf.Min(m_currentDistance, 100f);
			val4 = ((GameActor)val).CenterPosition + Vector3Extensions.XY(Quaternion.Euler(0f, 0f, m_currentAngle) * Vector2.op_Implicit(Vector2.right)) * m_currentDistance;
			Vector2 val5 = val4;
			bounds = m_extantReticleQuad.GetBounds();
			Vector2 val6 = val5 - Vector3Extensions.XY(((Bounds)(ref bounds)).extents);
			((BraveBehaviour)m_extantReticleQuad).transform.position = Vector2.op_Implicit(val6);
		}
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)m_extantReticleQuad))
		{
			Object.Destroy((Object)(object)((Component)m_extantReticleQuad).gameObject);
		}
		((BraveBehaviour)this).OnDestroy();
	}

	public override void OnDropped()
	{
		if (Object.op_Implicit((Object)(object)m_extantReticleQuad))
		{
			Object.Destroy((Object)(object)((Component)m_extantReticleQuad).gameObject);
		}
		((AdvancedGunBehavior)this).OnDropped();
	}

	public FlayedRevolver()
	{
		ref GameObject reference = ref reticleQuad;
		PickupObject byId = PickupObjectDatabase.GetById(443);
		reference = ((TargetedAttackPlayerItem)((byId is TargetedAttackPlayerItem) ? byId : null)).reticleQuad;
	}
}
