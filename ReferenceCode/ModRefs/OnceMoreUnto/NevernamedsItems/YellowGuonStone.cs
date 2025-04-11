using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class YellowGuonStone : AdvancedPlayerOrbitalItem
{
	[CompilerGenerated]
	private sealed class _003CHandleShield_003Ed__8 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerController user;

		public YellowGuonStone _003C_003E4__this;

		private SpeculativeRigidbody _003CspecRigidbody_003E5__1;

		private float _003Celapsed_003E5__2;

		private SpeculativeRigidbody _003CspecRigidbody2_003E5__3;

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
		public _003CHandleShield_003Ed__8(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003CspecRigidbody_003E5__1 = null;
			_003CspecRigidbody2_003E5__3 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b4: Expected O, but got Unknown
			//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00be: Expected O, but got Unknown
			//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b6: Expected O, but got Unknown
			//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c0: Expected O, but got Unknown
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E4__this.m_activeDuration = _003C_003E4__this.duration;
				_003C_003E4__this.m_usedOverrideMaterial = ((BraveBehaviour)user).sprite.usesOverrideMaterial;
				((BraveBehaviour)user).sprite.usesOverrideMaterial = true;
				user.SetOverrideShader(ShaderCache.Acquire("Brave/ItemSpecific/MetalSkinShader"));
				_003CspecRigidbody_003E5__1 = ((BraveBehaviour)user).specRigidbody;
				_003CspecRigidbody_003E5__1.OnPreRigidbodyCollision = (OnPreRigidbodyCollisionDelegate)Delegate.Combine((Delegate)(object)_003CspecRigidbody_003E5__1.OnPreRigidbodyCollision, (Delegate)new OnPreRigidbodyCollisionDelegate(_003C_003E4__this.OnPreCollision));
				((BraveBehaviour)user).healthHaver.IsVulnerable = false;
				_003Celapsed_003E5__2 = 0f;
				break;
			case 1:
				_003C_003E1__state = -1;
				break;
			}
			if (_003Celapsed_003E5__2 < _003C_003E4__this.duration)
			{
				_003Celapsed_003E5__2 += BraveTime.DeltaTime;
				((BraveBehaviour)user).healthHaver.IsVulnerable = false;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			if (Object.op_Implicit((Object)(object)user))
			{
				((BraveBehaviour)user).healthHaver.IsVulnerable = true;
				user.ClearOverrideShader();
				((BraveBehaviour)user).sprite.usesOverrideMaterial = _003C_003E4__this.m_usedOverrideMaterial;
				_003CspecRigidbody2_003E5__3 = ((BraveBehaviour)user).specRigidbody;
				_003CspecRigidbody2_003E5__3.OnPreRigidbodyCollision = (OnPreRigidbodyCollisionDelegate)Delegate.Remove((Delegate)(object)_003CspecRigidbody2_003E5__3.OnPreRigidbodyCollision, (Delegate)new OnPreRigidbodyCollisionDelegate(_003C_003E4__this.OnPreCollision));
				_003CspecRigidbody2_003E5__3 = null;
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

	private float m_activeDuration = 1f;

	private float duration = 1f;

	private bool m_usedOverrideMaterial;

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<YellowGuonStone>("Yellow Guon Stone", "Yellowstone", "Grants brief invulnerability on killing an enemy.\n\nThe Yellow Guon handles defense, so that it's bearer may never stop attacking. At least, in theory.", "yellowguon_icon", assetbundle: true);
		AdvancedPlayerOrbitalItem val = (AdvancedPlayerOrbitalItem)(object)((obj is AdvancedPlayerOrbitalItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)3;
		AlexandriaTags.SetTag((PickupObject)(object)val, "guon_stone");
		val.OrbitalPrefab = ItemSetup.CreateOrbitalObject("Yellow Guon Stone", "yellowguon_ingame", new IntVector2(9, 9), new IntVector2(-4, -5), null, 2.5f, 120f, 0, (OrbitalMotionStyle)0).GetComponent<PlayerOrbital>();
	}

	public override void Pickup(PlayerController player)
	{
		player.OnAnyEnemyReceivedDamage = (Action<float, bool, HealthHaver>)Delegate.Combine(player.OnAnyEnemyReceivedDamage, new Action<float, bool, HealthHaver>(OnEnemyDamaged));
		((AdvancedPlayerOrbitalItem)this).Pickup(player);
	}

	public override DebrisObject Drop(PlayerController player)
	{
		player.OnAnyEnemyReceivedDamage = (Action<float, bool, HealthHaver>)Delegate.Remove(player.OnAnyEnemyReceivedDamage, new Action<float, bool, HealthHaver>(OnEnemyDamaged));
		return ((AdvancedPlayerOrbitalItem)this).Drop(player);
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			PlayerController owner = ((PassiveItem)this).Owner;
			owner.OnAnyEnemyReceivedDamage = (Action<float, bool, HealthHaver>)Delegate.Remove(owner.OnAnyEnemyReceivedDamage, new Action<float, bool, HealthHaver>(OnEnemyDamaged));
		}
		((AdvancedPlayerOrbitalItem)this).OnDestroy();
	}

	private void OnEnemyDamaged(float damage, bool fatal, HealthHaver enemyHealth)
	{
		if (Object.op_Implicit((Object)(object)enemyHealth) && fatal)
		{
			((MonoBehaviour)this).StartCoroutine(HandleShield(((PassiveItem)this).Owner));
		}
	}

	private IEnumerator HandleShield(PlayerController user)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CHandleShield_003Ed__8(0)
		{
			_003C_003E4__this = this,
			user = user
		};
	}

	private void OnPreCollision(SpeculativeRigidbody myRigidbody, PixelCollider myCollider, SpeculativeRigidbody otherRigidbody, PixelCollider otherCollider)
	{
		Projectile component = ((Component)otherRigidbody).GetComponent<Projectile>();
		if ((Object)(object)component != (Object)null && !(component.Owner is PlayerController))
		{
			PassiveReflectItem.ReflectBullet(component, true, ((BraveBehaviour)((BraveBehaviour)((PassiveItem)this).Owner).specRigidbody).gameActor, 10f, 1f, 1f, 0f);
			PhysicsEngine.SkipCollision = true;
		}
	}
}
