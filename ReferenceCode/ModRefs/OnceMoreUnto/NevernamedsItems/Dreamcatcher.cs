using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Dungeonator;
using HarmonyLib;
using UnityEngine;

namespace NevernamedsItems;

public class Dreamcatcher : PassiveItem
{
	[HarmonyPatch(typeof(Gun))]
	[HarmonyPatch(/*Could not decode attribute arguments.*/)]
	public class CasingSpawner
	{
		[HarmonyPrefix]
		public static bool HarmonyPostfix(Gun __instance, Vector3 position)
		{
			//IL_0054: Unknown result type (might be due to invalid IL or missing references)
			//IL_005b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b0: Expected O, but got Unknown
			//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_019d: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cf: Expected O, but got Unknown
			//IL_02cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_026d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0272: Unknown result type (might be due to invalid IL or missing references)
			//IL_027d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0294: Unknown result type (might be due to invalid IL or missing references)
			//IL_029b: Unknown result type (might be due to invalid IL or missing references)
			//IL_02bf: Expected O, but got Unknown
			if ((Object)(object)__instance != (Object)null && (Object)(object)GunTools.GunPlayerOwner(__instance) != (Object)null && GunTools.GunPlayerOwner(__instance).IsInCombat && GunTools.GunPlayerOwner(__instance).HasPickupID(ID) && (Object)(object)__instance.shellCasing != (Object)null)
			{
				GameObject val = SpawnManager.SpawnDebris(__instance.shellCasing, Vector3Extensions.WithZ(position, __instance.m_transform.position.z), Quaternion.Euler(0f, 0f, __instance.gunAngle));
				DebrisObject component = val.GetComponent<DebrisObject>();
				if ((Object)(object)component != (Object)null)
				{
					Object.Destroy((Object)(object)component);
				}
				SpeculativeRigidbody orAddComponent = GameObjectExtensions.GetOrAddComponent<SpeculativeRigidbody>(val);
				PixelCollider val2 = new PixelCollider();
				val2.ColliderGenerationMode = (PixelColliderGeneration)0;
				val2.CollisionLayer = (CollisionLayer)3;
				val2.ManualWidth = 3;
				val2.ManualHeight = 3;
				val2.ManualOffsetX = 0;
				val2.ManualOffsetY = 0;
				orAddComponent.PixelColliders = new List<PixelCollider> { val2 };
				Projectile orAddComponent2 = GameObjectExtensions.GetOrAddComponent<Projectile>(val);
				orAddComponent2.Shooter = ((BraveBehaviour)GunTools.GunPlayerOwner(__instance)).specRigidbody;
				orAddComponent2.Owner = ((BraveBehaviour)GunTools.GunPlayerOwner(__instance)).gameActor;
				orAddComponent2.baseData.damage = 2.5f;
				orAddComponent2.baseData.range = 1000f;
				orAddComponent2.baseData.speed = 5f;
				orAddComponent2.collidesWithProjectiles = false;
				orAddComponent2.shouldRotate = false;
				orAddComponent2.baseData.force = 10f;
				((BraveBehaviour)orAddComponent2).specRigidbody.CollideWithTileMap = true;
				((BraveBehaviour)orAddComponent2).specRigidbody.Reinitialize();
				((BraveBehaviour)orAddComponent2).specRigidbody.PrimaryPixelCollider.CollisionLayer = (CollisionLayer)4;
				orAddComponent2.Start();
				orAddComponent2.UpdateCollisionMask();
				if (orAddComponent2.hitEffects == null)
				{
					orAddComponent2.hitEffects = new ProjectileImpactVFXPool();
				}
				orAddComponent2.hitEffects.overrideMidairDeathVFX = vfx;
				orAddComponent2.hitEffects.alwaysUseMidair = true;
				SlowDownOverTimeModifier slowDownOverTimeModifier = val.AddComponent<SlowDownOverTimeModifier>();
				slowDownOverTimeModifier.timeToSlowOver = 0.5f;
				slowDownOverTimeModifier.targetSpeed = 0f;
				slowDownOverTimeModifier.doRandomTimeMultiplier = true;
				val.AddComponent<ProjectileSpinner>();
				val.AddComponent<DreamcatcherProjectile>();
				if ((((PickupObject)__instance).PickupObjectId == 145 || ((PickupObject)__instance).PickupObjectId == 385) && CustomSynergies.PlayerHasActiveSynergy(GunTools.GunPlayerOwner(__instance), "Spellcatcher"))
				{
					AdvancedTransmogrifyBehaviour orAddComponent3 = GameObjectExtensions.GetOrAddComponent<AdvancedTransmogrifyBehaviour>(((Component)orAddComponent2).gameObject);
					orAddComponent3.TransmogDataList.Add(new TransmogData
					{
						identifier = "Dreamcatcher",
						TargetGuids = new List<string> { "4254a93fc3c84c0dbe0a8f0dddf48a5a" },
						maintainHPPercent = false,
						TransmogChance = ((((PickupObject)__instance).PickupObjectId == 145) ? 0.2f : 1f)
					});
				}
				orAddComponent2.SendInDirection(MathsAndLogicHelper.DegreeToVector2(__instance.gunAngle + 180f), false, false);
				return false;
			}
			return true;
		}
	}

	public class DreamcatcherProjectile : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CHandleCasingProjectile_003Ed__2 : IEnumerator<object>, IDisposable, IEnumerator
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Projectile proj;

			public DreamcatcherProjectile _003C_003E4__this;

			private float _003Ctime_003E5__1;

			private Vector2 _003CdirVec_003E5__2;

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
			public _003CHandleCasingProjectile_003Ed__2(int _003C_003E1__state)
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
				//IL_004a: Unknown result type (might be due to invalid IL or missing references)
				//IL_0054: Expected O, but got Unknown
				//IL_006f: Unknown result type (might be due to invalid IL or missing references)
				//IL_0074: Unknown result type (might be due to invalid IL or missing references)
				//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
				//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
				//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
				switch (_003C_003E1__state)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					_003Ctime_003E5__1 = 0.5f;
					_003Ctime_003E5__1 *= Random.value * 2f;
					_003C_003E2__current = (object)new WaitForSeconds(_003Ctime_003E5__1);
					_003C_003E1__state = 1;
					return true;
				case 1:
					_003C_003E1__state = -1;
					_003CdirVec_003E5__2 = ProjectileUtility.GetVectorToNearestEnemy(proj, true, (ActiveEnemyType)1, (List<AIActor>)null, (Func<AIActor, bool>)null);
					AkSoundEngine.PostEvent("Play_ENM_pop_shot_01", ((Component)proj).gameObject);
					proj.baseData.speed = 23f;
					proj.UpdateSpeed();
					if (_003CdirVec_003E5__2 != Vector2.zero)
					{
						proj.SendInDirection(_003CdirVec_003E5__2, false, false);
					}
					else
					{
						proj.DieInAir(false, true, true, false);
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

		private void Start()
		{
			SlowDownOverTimeModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<SlowDownOverTimeModifier>(((Component)this).gameObject);
			orAddComponent.OnCompleteStop = (Action<Projectile>)Delegate.Combine(orAddComponent.OnCompleteStop, new Action<Projectile>(OnStop));
		}

		public void OnStop(Projectile proj)
		{
			((MonoBehaviour)this).StartCoroutine(HandleCasingProjectile(proj));
		}

		public IEnumerator HandleCasingProjectile(Projectile proj)
		{
			//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
			return new _003CHandleCasingProjectile_003Ed__2(0)
			{
				_003C_003E4__this = this,
				proj = proj
			};
		}
	}

	private float timer = 0f;

	public static int ID;

	public static GameObject vfx;

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<Dreamcatcher>("Dreamcatcher", "Close Your Eyes", "Catches spent shells ejected from the owners guns and flings them at nearby foes. Chance to also catch nearby bullets.\n\nYoung Bullet Kin sometimes hang these spiritual ornaments above their sleeping chambers to catch bad dreams and stray bullets.", "dreamcatcher_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)3;
		ID = ((PickupObject)val).PickupObjectId;
		vfx = VFXToolbox.CreateVFXBundle("TinyShellImpact", new IntVector2(9, 11), (Anchor)4, usesZHeight: true, 5f, -1f, null);
	}

	public override void Update()
	{
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)((PassiveItem)this).Owner != (Object)null)
		{
			if (timer <= 0f)
			{
				List<Projectile> list = new List<Projectile>();
				for (int i = 0; i < StaticReferenceManager.AllProjectiles.Count; i++)
				{
					Projectile val = StaticReferenceManager.AllProjectiles[i];
					if (Object.op_Implicit((Object)(object)val) && ((Object)(object)val.Owner == (Object)null || !(val.Owner is PlayerController)) && Vector2.Distance(Vector2.op_Implicit(val.LastPosition), ((GameActor)((PassiveItem)this).Owner).CenterPosition) <= 3f)
					{
						CatchProjectile(val);
					}
				}
				timer = Random.Range(0.25f, 5f);
			}
			else
			{
				timer -= BraveTime.DeltaTime;
			}
		}
		((PassiveItem)this).Update();
	}

	public void CatchProjectile(Projectile p)
	{
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			p.RemoveBulletScriptControl();
			if (Object.op_Implicit((Object)(object)p.Owner) && Object.op_Implicit((Object)(object)((BraveBehaviour)p.Owner).specRigidbody))
			{
				((BraveBehaviour)p).specRigidbody.DeregisterSpecificCollisionException(((BraveBehaviour)p.Owner).specRigidbody);
			}
			p.Owner = (GameActor)(object)((PassiveItem)this).Owner;
			p.SetNewShooter(((BraveBehaviour)((PassiveItem)this).Owner).specRigidbody);
			p.allowSelfShooting = false;
			p.collidesWithPlayer = false;
			p.collidesWithEnemies = true;
			p.UpdateCollisionMask();
			p.Reflected();
			SlowDownOverTimeModifier slowDownOverTimeModifier = ((Component)p).gameObject.AddComponent<SlowDownOverTimeModifier>();
			slowDownOverTimeModifier.timeToSlowOver = 0.5f;
			slowDownOverTimeModifier.targetSpeed = 0f;
			slowDownOverTimeModifier.doRandomTimeMultiplier = true;
			((Component)p).gameObject.AddComponent<DreamcatcherProjectile>();
			ProjectileUtility.RemoveFromPool(p);
			p.ChangeColor(0.5f, ExtendedColours.honeyYellow);
		}
	}
}
