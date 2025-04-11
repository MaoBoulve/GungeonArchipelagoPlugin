using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.Assetbundle;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Dulcannon : GunBehaviour
{
	[CompilerGenerated]
	private sealed class _003CLerpToMaxRadius_003Ed__4 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Projectile proj;

		public float radius;

		public Dulcannon _003C_003E4__this;

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
		public _003CLerpToMaxRadius_003Ed__4(int _003C_003E1__state)
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

	public static void Add()
	{
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_025d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0289: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Dulcannon", "dulcannon");
		Game.Items.Rename("outdated_gun_mods:dulcannon", "nn:dulcannon");
		((Component)val).gameObject.AddComponent<Dulcannon>();
		GunExt.SetShortDescription((PickupObject)(object)val, "At Wits End");
		GunExt.SetLongDescription((PickupObject)(object)val, "Summons a single bullet from each held gun upon reloading.\n\nDiscerning the true origins of this strange cannon have driven Gungeonologists mad with frustration for centuries.");
		val.SetGunSprites("dulcannon", 8, noAmmonomicon: false, 2);
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		PickupObject byId = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(37);
		gunSwitchGroup = ((Gun)((byId2 is Gun) ? byId2 : null)).gunSwitchGroup;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1.2f;
		val.DefaultModule.cooldownTime = 1f;
		val.DefaultModule.numberOfShotsInClip = 5;
		val.DefaultModule.angleVariance = 7f;
		val.SetBarrel(37, 14);
		val.SetBaseMaxAmmo(100);
		val.ammo = 100;
		val.gunClass = (GunClass)50;
		Projectile val2 = ProjectileSetupUtility.MakeProjectile(56, 25f);
		((Object)((Component)val2).gameObject).name = "Dulcannon Projectile";
		ProjectileBuilders.AnimateProjectileBundle(val2, "DulcannonProjectile", Initialisation.ProjectileCollection, Initialisation.projectileAnimationCollection, "DulcannonProjectile", MiscTools.DupeList<IntVector2>(new IntVector2(21, 10), 4), MiscTools.DupeList(value: true, 4), MiscTools.DupeList<Anchor>((Anchor)4, 4), MiscTools.DupeList(value: true, 4), MiscTools.DupeList(value: false, 4), MiscTools.DupeList<Vector3?>(null, 4), MiscTools.DupeList((IntVector2?)new IntVector2(21, 10), 4), MiscTools.DupeList<IntVector2?>(null, 4), MiscTools.DupeList<Projectile>(null, 4));
		val2.baseData.speed = 20f;
		val2.hitEffects.enemy = VFXToolbox.CreateBlankVFXPool(SharedVFX.SmoothLightBlueLaserCircleVFX);
		val2.hitEffects.tileMapVertical = VFXToolbox.CreateBlankVFXPool(SharedVFX.BigDustCloud);
		val2.hitEffects.tileMapHorizontal = VFXToolbox.CreateBlankVFXPool(SharedVFX.BigDustCloud);
		val2.hitEffects.overrideMidairDeathVFX = SharedVFX.BigDustCloud;
		val2.objectImpactEventName = "anvil";
		PierceProjModifier val3 = ((Component)val2).gameObject.AddComponent<PierceProjModifier>();
		val3.penetration = 1;
		val.DefaultModule.projectiles[0] = val2;
		val.gunHandedness = (GunHandedness)0;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(37);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		val.AddClipSprites("dulcannon");
		((PickupObject)val).quality = (ItemQuality)4;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
	}

	public override void OnReloadedPlayer(PlayerController owner, Gun gun)
	{
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Invalid comparison between Unknown and I4
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)gun) && Object.op_Implicit((Object)(object)owner) && gun.ClipShotsRemaining == 0)
		{
			List<Projectile> list = new List<Projectile>();
			foreach (Gun allGun in owner.inventory.AllGuns)
			{
				if ((Object)(object)allGun != (Object)null && allGun.DefaultModule != null && (Object)(object)allGun.DefaultModule.GetCurrentProjectile() != (Object)null && (Object)(object)((Component)allGun.DefaultModule.GetCurrentProjectile()).GetComponent<BeamController>() == (Object)null && ((PickupObject)allGun).PickupObjectId != ID)
				{
					list.Add(allGun.DefaultModule.GetCurrentProjectile());
					if ((int)allGun.DefaultModule.shootStyle == 3)
					{
						allGun.ammo = Math.Max(0, allGun.ammo - allGun.DefaultModule.ammoCost);
					}
					else
					{
						allGun.DecrementAmmoCost(allGun.DefaultModule);
					}
				}
			}
			float num = 360f / (float)list.Count;
			float num2 = 0f;
			foreach (Projectile item in list)
			{
				StartOrbital(owner, item, ((GameActor)owner).CenterPosition, 4f, num * num2);
				num2 += 1f;
			}
		}
		((GunBehaviour)this).OnReloadedPlayer(owner, gun);
	}

	public void StartOrbital(PlayerController player, Projectile proj, Vector2 v, float radius, float angular)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = ProjectileUtility.InstantiateAndFireInDirection(proj, v, 0f, 0f, (PlayerController)null);
		Projectile component = val.GetComponent<Projectile>();
		if ((Object)(object)component != (Object)null)
		{
			component.Owner = (GameActor)(object)player;
			component.Shooter = ((BraveBehaviour)player).specRigidbody;
			NoCollideBehaviour noCollideBehaviour = val.AddComponent<NoCollideBehaviour>();
			noCollideBehaviour.worksOnEnemies = false;
			((BraveBehaviour)component).specRigidbody.CollideWithTileMap = false;
			component.pierceMinorBreakables = true;
			component.ScaleByPlayerStats(player);
			player.DoPostProcessProjectile(component);
			component.baseData.speed = 20f;
			component.baseData.range = float.MaxValue;
			component.UpdateSpeed();
			OrbitProjectileMotionModule val2 = new OrbitProjectileMotionModule();
			val2.lifespan = 50f;
			val2.MinRadius = 0.1f;
			val2.MaxRadius = 0.1f;
			val2.OrbitGroup = -66;
			component.OverrideMotionModule = (ProjectileMotionModule)(object)val2;
			((BraveBehaviour)component).transform.localRotation = Quaternion.Euler(0f, 0f, ((BraveBehaviour)component).transform.localRotation.z + angular);
			BulletLifeTimer bulletLifeTimer = ((Component)component).gameObject.AddComponent<BulletLifeTimer>();
			bulletLifeTimer.secondsTillDeath = 6f;
			((MonoBehaviour)component).StartCoroutine(LerpToMaxRadius(component, radius));
		}
	}

	private IEnumerator LerpToMaxRadius(Projectile proj, float radius)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CLerpToMaxRadius_003Ed__4(0)
		{
			_003C_003E4__this = this,
			proj = proj,
			radius = radius
		};
	}
}
