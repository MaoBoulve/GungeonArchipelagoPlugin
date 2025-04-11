using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class BlueMoon : AdvancedGunBehavior
{
	public class BlueMoonBullet : BraveBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CHandleRelease_003Ed__5 : IEnumerator<object>, IDisposable, IEnumerator
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public List<Projectile> spawned;

			private int _003Ci_003E5__1;

			private SlowDownOverTimeModifier _003Cslow_003E5__2;

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
			public _003CHandleRelease_003Ed__5(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				_003Cslow_003E5__2 = null;
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
					_003C_003E2__current = (object)new WaitForSeconds(4f);
					_003C_003E1__state = 1;
					return true;
				case 1:
					_003C_003E1__state = -1;
					_003Ci_003E5__1 = spawned.Count - 1;
					while (_003Ci_003E5__1 >= 0)
					{
						if ((Object)(object)spawned[_003Ci_003E5__1] != (Object)null)
						{
							spawned[_003Ci_003E5__1].baseData.speed = 10f;
							_003Cslow_003E5__2 = ((Component)spawned[_003Ci_003E5__1]).gameObject.AddComponent<SlowDownOverTimeModifier>();
							_003Cslow_003E5__2.targetSpeed = 2f;
							_003Cslow_003E5__2.doRandomTimeMultiplier = true;
							_003Cslow_003E5__2.activateDriftAfterstop = true;
							_003Cslow_003E5__2 = null;
						}
						_003Ci_003E5__1--;
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

		private List<Projectile> spawned = new List<Projectile>();

		private float time = 0f;

		private void Update()
		{
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			if (!Object.op_Implicit((Object)(object)((BraveBehaviour)this).projectile))
			{
				return;
			}
			if (time > 0.02f)
			{
				Projectile component = ProjectileUtility.InstantiateAndFireInDirection(Wobbler, ((BraveBehaviour)this).projectile.SafeCenter, BraveUtility.RandomAngle(), 0f, (PlayerController)null).GetComponent<Projectile>();
				component.Shooter = ((BraveBehaviour)this).projectile.Shooter;
				component.Owner = ((BraveBehaviour)this).projectile.Owner;
				if (Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(((BraveBehaviour)this).projectile)))
				{
					component.ScaleByPlayerStats(ProjectileUtility.ProjectilePlayerOwner(((BraveBehaviour)this).projectile));
				}
				spawned.Add(component);
				time = 0f;
			}
			else
			{
				time += BraveTime.DeltaTime;
			}
		}

		private void Start()
		{
			((BraveBehaviour)this).projectile.OnDestruction += OnDest;
		}

		public void OnDest(Projectile pr)
		{
			//IL_0011: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0066: Unknown result type (might be due to invalid IL or missing references)
			//IL_0070: Unknown result type (might be due to invalid IL or missing references)
			//IL_0075: Unknown result type (might be due to invalid IL or missing references)
			for (int i = 0; i < 20; i++)
			{
				GameObject val = Object.Instantiate<GameObject>(SharedVFX.BlueSparkle, Vector2.op_Implicit(((BraveBehaviour)this).projectile.SafeCenter), Quaternion.identity);
				SimpleMover orAddComponent = GameObjectExtensions.GetOrAddComponent<SimpleMover>(val);
				orAddComponent.velocity = Vector2.op_Implicit(MathsAndLogicHelper.DegreeToVector2(BraveUtility.RandomAngle()) * (float)Random.Range(5, 10) * 0.4f);
				orAddComponent.acceleration = orAddComponent.velocity / 1.3f * -1f;
			}
			((MonoBehaviour)GameManager.Instance).StartCoroutine(HandleRelease(spawned));
		}

		public static IEnumerator HandleRelease(List<Projectile> spawned)
		{
			//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
			return new _003CHandleRelease_003Ed__5(0)
			{
				spawned = spawned
			};
		}
	}

	public static int ID;

	public static Projectile Wobbler;

	public static void Add()
	{
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_0225: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Unknown result type (might be due to invalid IL or missing references)
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Blue Moon", "bluemoon");
		Game.Items.Rename("outdated_gun_mods:blue_moon", "nn:blue_moon");
		((Component)val).gameObject.AddComponent<BlueMoon>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Strikes Once");
		GunExt.SetLongDescription((PickupObject)(object)val, "Created by the Queen of Sniperion, moon of Gunymede, for a mysterious planetside suitor. He could not have her heart, but he may have her gun.");
		val.SetGunSprites("bluemoon", 8, noAmmonomicon: false, 2);
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(385);
		gunSwitchGroup = ((Gun)((byId2 is Gun) ? byId2 : null)).gunSwitchGroup;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(45);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 2f;
		val.DefaultModule.cooldownTime = 0.7f;
		val.DefaultModule.numberOfShotsInClip = 3;
		val.SetBarrel(32, 7);
		val.SetBaseMaxAmmo(50);
		val.ammo = 50;
		val.gunClass = (GunClass)10;
		Projectile val2 = ProjectileSetupUtility.MakeProjectile(86, 20f);
		ProjectileBuilders.AnimateProjectileBundle(val2, "BlueMoonProjectile", Initialisation.ProjectileCollection, Initialisation.projectileAnimationCollection, "BlueMoonProjectile", MiscTools.DupeList<IntVector2>(new IntVector2(32, 32), 4), MiscTools.DupeList(value: true, 4), MiscTools.DupeList<Anchor>((Anchor)4, 4), MiscTools.DupeList(value: true, 4), MiscTools.DupeList(value: false, 4), MiscTools.DupeList<Vector3?>(null, 4), MiscTools.DupeList((IntVector2?)new IntVector2(20, 20), 4), MiscTools.DupeList<IntVector2?>(null, 4), MiscTools.DupeList<Projectile>(null, 4));
		val2.hitEffects.deathAny = VFXToolbox.CreateBlankVFXPool(SharedVFX.BigWhitePoofVFX);
		val2.hitEffects.HasProjectileDeathVFX = true;
		val2.hitEffects.overrideMidairDeathVFX = SharedVFX.SmoothLightBlueLaserCircleVFX;
		val2.hitEffects.alwaysUseMidair = true;
		val2.pierceMinorBreakables = true;
		((Component)val2).gameObject.AddComponent<BlueMoonBullet>();
		val.DefaultModule.projectiles[0] = val2;
		val.gunHandedness = (GunHandedness)3;
		val.DefaultModule.ammoType = (AmmoType)7;
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
		Wobbler = ProjectileSetupUtility.MakeProjectile(86, 5.5f, -1f, 0.001f);
		OscillatingProjectileModifier oscillatingProjectileModifier = ((Component)Wobbler).gameObject.AddComponent<OscillatingProjectileModifier>();
		oscillatingProjectileModifier.multiplySpeed = true;
		oscillatingProjectileModifier.multiplyScale = true;
		oscillatingProjectileModifier.multiplyDamage = true;
		Wobbler.SetProjectileSprite("blue_enemystyle_projectile", 10, 10, lightened: true, (Anchor)4, 8, 8, anchorChangesCollider: true, fixesScale: false, null, null);
		DriftModifier driftModifier = ((Component)Wobbler).gameObject.AddComponent<DriftModifier>();
		driftModifier.diesAfterMaxDrifts = true;
		driftModifier.maxDriftReaims = 10;
		driftModifier.startInactive = true;
		SpriteSparkler orAddComponent = GameObjectExtensions.GetOrAddComponent<SpriteSparkler>(((Component)Wobbler).gameObject);
		orAddComponent.doVFX = true;
		orAddComponent.VFX = SharedVFX.BlueSparkle;
		orAddComponent.particlesPerSecond = 1f;
		Wobbler.hitEffects.overrideMidairDeathVFX = SharedVFX.SmoothLightBlueLaserCircleVFX;
		Wobbler.hitEffects.alwaysUseMidair = true;
	}
}
