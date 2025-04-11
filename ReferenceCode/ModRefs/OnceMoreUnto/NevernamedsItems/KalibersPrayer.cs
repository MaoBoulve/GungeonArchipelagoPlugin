using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class KalibersPrayer : PlayerItem
{
	[CompilerGenerated]
	private sealed class _003CHandleShield_003Ed__6 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerController user;

		public float duration;

		public KalibersPrayer _003C_003E4__this;

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
		public _003CHandleShield_003Ed__6(int _003C_003E1__state)
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
			//IL_0094: Unknown result type (might be due to invalid IL or missing references)
			//IL_009e: Expected O, but got Unknown
			//IL_009e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a8: Expected O, but got Unknown
			//IL_0191: Unknown result type (might be due to invalid IL or missing references)
			//IL_019b: Expected O, but got Unknown
			//IL_019b: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a5: Expected O, but got Unknown
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
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
			if (_003Celapsed_003E5__2 < duration)
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
			if (Object.op_Implicit((Object)(object)_003C_003E4__this))
			{
				AkSoundEngine.PostEvent("Play_OBJ_metalskin_end_01", ((Component)_003C_003E4__this).gameObject);
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

	[CompilerGenerated]
	private sealed class _003CIncorporealityOnHit_003Ed__3 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerController player;

		public float incorporealityTime;

		public KalibersPrayer _003C_003E4__this;

		private int _003CenemyMask_003E5__1;

		private float _003Ctimer_003E5__2;

		private float _003Csubtimer_003E5__3;

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
		public _003CIncorporealityOnHit_003Ed__3(int _003C_003E1__state)
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
				_003CenemyMask_003E5__1 = CollisionMask.LayerToMask((CollisionLayer)3, (CollisionLayer)2, (CollisionLayer)4);
				((BraveBehaviour)player).specRigidbody.AddCollisionLayerIgnoreOverride(_003CenemyMask_003E5__1);
				((BraveBehaviour)player).healthHaver.IsVulnerable = false;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				_003Ctimer_003E5__2 = 0f;
				_003Csubtimer_003E5__3 = 0f;
				goto IL_01b2;
			case 2:
				_003C_003E1__state = -1;
				goto IL_0113;
			case 3:
				{
					_003C_003E1__state = -1;
					goto IL_019a;
				}
				IL_01b2:
				if (_003Ctimer_003E5__2 < incorporealityTime)
				{
					goto IL_0113;
				}
				_003C_003E4__this.EndIncorporealityOnHit(player);
				return false;
				IL_019a:
				if (_003Ctimer_003E5__2 < incorporealityTime)
				{
					_003Ctimer_003E5__2 += BraveTime.DeltaTime;
					_003Csubtimer_003E5__3 += BraveTime.DeltaTime;
					if (!(_003Csubtimer_003E5__3 > 0.12f))
					{
						_003C_003E2__current = null;
						_003C_003E1__state = 3;
						return true;
					}
					player.IsVisible = true;
					_003Csubtimer_003E5__3 -= 0.12f;
				}
				goto IL_01b2;
				IL_0113:
				if (_003Ctimer_003E5__2 < incorporealityTime)
				{
					_003Ctimer_003E5__2 += BraveTime.DeltaTime;
					_003Csubtimer_003E5__3 += BraveTime.DeltaTime;
					if (!(_003Csubtimer_003E5__3 > 0.12f))
					{
						_003C_003E2__current = null;
						_003C_003E1__state = 2;
						return true;
					}
					player.IsVisible = false;
					_003Csubtimer_003E5__3 -= 0.12f;
				}
				goto IL_019a;
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

	private bool m_usedOverrideMaterial;

	public static void Init()
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<KalibersPrayer>("Kalibers Prayer", "Book of Secrets", "Though the most commonly known prayer to Kaliber is the famous Dodge Roll, this tome is filled with lesser rites to briefly grant Kaliber's protection in battle.\n\nIt is mandated that every adult Gun Cultist carry a copy of this holy tome, though not all can read it's strange spiralling text.", "kalibersprayer_icon", assetbundle: true);
		PlayerItem val = (PlayerItem)(object)((obj is PlayerItem) ? obj : null);
		ItemBuilder.SetCooldownType(val, (CooldownType)0, 8f);
		val.consumable = false;
		((PickupObject)val).quality = (ItemQuality)1;
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.GUNCULTIST_QUEST_REWARDED, requiredFlagValue: true);
	}

	public override void DoEffect(PlayerController user)
	{
		float num = 2f;
		if (CustomSynergies.PlayerHasActiveSynergy(user, "Gunsignor") && (double)Random.value <= 0.1)
		{
			num = 8f;
		}
		if (CustomSynergies.PlayerHasActiveSynergy(user, "Liturgist"))
		{
			num *= 2f;
		}
		if (CustomSynergies.PlayerHasActiveSynergy(user, "Rod of Iron"))
		{
			((MonoBehaviour)user).StartCoroutine(HandleShield(user, num));
		}
		else
		{
			((MonoBehaviour)user).StartCoroutine(IncorporealityOnHit(user, num));
		}
	}

	public override bool CanBeUsed(PlayerController user)
	{
		return ((PlayerItem)this).CanBeUsed(user);
	}

	private IEnumerator IncorporealityOnHit(PlayerController player, float incorporealityTime)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CIncorporealityOnHit_003Ed__3(0)
		{
			_003C_003E4__this = this,
			player = player,
			incorporealityTime = incorporealityTime
		};
	}

	private void EndIncorporealityOnHit(PlayerController player)
	{
		int num = CollisionMask.LayerToMask((CollisionLayer)3, (CollisionLayer)2, (CollisionLayer)4);
		player.IsVisible = true;
		((BraveBehaviour)player).healthHaver.IsVulnerable = true;
		((BraveBehaviour)player).specRigidbody.RemoveCollisionLayerIgnoreOverride(num);
	}

	private IEnumerator HandleShield(PlayerController user, float duration)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CHandleShield_003Ed__6(0)
		{
			_003C_003E4__this = this,
			user = user,
			duration = duration
		};
	}

	private void OnPreCollision(SpeculativeRigidbody myRigidbody, PixelCollider myCollider, SpeculativeRigidbody otherRigidbody, PixelCollider otherCollider)
	{
		Projectile component = ((Component)otherRigidbody).GetComponent<Projectile>();
		if ((Object)(object)component != (Object)null && !(component.Owner is PlayerController))
		{
			PassiveReflectItem.ReflectBullet(component, true, ((BraveBehaviour)((BraveBehaviour)base.LastOwner).specRigidbody).gameActor, 10f, 1f, 1f, 0f);
			PhysicsEngine.SkipCollision = true;
		}
	}
}
