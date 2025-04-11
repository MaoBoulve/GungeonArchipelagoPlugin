using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

internal class Bambarrage : PlayerItem
{
	[CompilerGenerated]
	private sealed class _003CSpawnBarrage_003Ed__3 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerController user;

		public Bambarrage _003C_003E4__this;

		private int _003Ci_003E5__1;

		private Projectile _003CrocketArrow_003E5__2;

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
		public _003CSpawnBarrage_003Ed__3(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003CrocketArrow_003E5__2 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0061: Unknown result type (might be due to invalid IL or missing references)
			//IL_014a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0154: Expected O, but got Unknown
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003Ci_003E5__1 = 0;
				break;
			case 1:
				_003C_003E1__state = -1;
				_003CrocketArrow_003E5__2 = null;
				_003Ci_003E5__1++;
				break;
			}
			if (_003Ci_003E5__1 < 6)
			{
				AkSoundEngine.PostEvent("Play_WPN_stickycrossbow_shot_01", ((Component)_003C_003E4__this).gameObject);
				_003CrocketArrow_003E5__2 = ProjectileUtility.InstantiateAndFireInDirection(projPrefab, Vector2.op_Implicit(((GameActor)user).CurrentGun.barrelOffset.position), ((GameActor)user).CurrentGun.CurrentAngle, 40f, user).GetComponent<Projectile>();
				_003CrocketArrow_003E5__2.Owner = (GameActor)(object)user;
				_003CrocketArrow_003E5__2.Shooter = ((BraveBehaviour)user).specRigidbody;
				ProjectileData baseData = _003CrocketArrow_003E5__2.baseData;
				baseData.damage *= user.stats.GetStatValue((StatType)5);
				ProjectileData baseData2 = _003CrocketArrow_003E5__2.baseData;
				baseData2.speed *= user.stats.GetStatValue((StatType)6);
				ProjectileData baseData3 = _003CrocketArrow_003E5__2.baseData;
				baseData3.force *= user.stats.GetStatValue((StatType)12);
				user.DoPostProcessProjectile(_003CrocketArrow_003E5__2);
				_003C_003E2__current = (object)new WaitForSeconds(0.1f);
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

	public static Projectile projPrefab;

	public static void Init()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<Bambarrage>("Bambarrage", "Xiao Zhu Tong Jian", "An ancient bamboo tube, hung at the hip- and capable of launching a devastating barrage of poisoned rocket arrows!", "bambarrage_icon", assetbundle: true);
		PlayerItem val = (PlayerItem)(object)((obj is PlayerItem) ? obj : null);
		ItemBuilder.SetCooldownType(val, (CooldownType)1, 200f);
		projPrefab = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)((Gun)PickupObjectDatabase.GetById(56)).DefaultModule.projectiles[0]).gameObject).GetComponent<Projectile>();
		projPrefab.SetProjectileSprite("bambarrage_proj", 17, 3, lightened: false, (Anchor)4, 17, 3, anchorChangesCollider: true, fixesScale: false, null, null);
		projPrefab.baseData.damage = 7f;
		projPrefab.baseData.AccelerationCurve = ((Gun)PickupObjectDatabase.GetById(39)).DefaultModule.projectiles[0].baseData.AccelerationCurve;
		projPrefab.AppliesPoison = true;
		projPrefab.PoisonApplyChance = 0.8f;
		projPrefab.healthEffect = StaticStatusEffects.irradiatedLeadEffect;
		projPrefab.hitEffects.overrideMidairDeathVFX = ((Gun)PickupObjectDatabase.GetById(543)).DefaultModule.projectiles[0].hitEffects.overrideMidairDeathVFX;
		projPrefab.hitEffects.alwaysUseMidair = true;
		((PickupObject)val).quality = (ItemQuality)1;
	}

	public override void DoEffect(PlayerController user)
	{
		((MonoBehaviour)this).StartCoroutine(SpawnBarrage(user));
	}

	private IEnumerator SpawnBarrage(PlayerController user)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CSpawnBarrage_003Ed__3(0)
		{
			_003C_003E4__this = this,
			user = user
		};
	}

	public override bool CanBeUsed(PlayerController user)
	{
		if ((Object)(object)((GameActor)user).CurrentGun != (Object)null)
		{
			return true;
		}
		return ((PlayerItem)this).CanBeUsed(user);
	}
}
