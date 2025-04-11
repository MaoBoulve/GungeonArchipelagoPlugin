using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class SAAModifiers : GunBehaviour
{
	[CompilerGenerated]
	private sealed class _003CIncorporealityOnHit_003Ed__3 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerController player;

		public float incorporealityTime;

		public SAAModifiers _003C_003E4__this;

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

	private bool isReloading = false;

	public override void OnReloadPressed(PlayerController player, Gun gun, bool manualReload)
	{
		if (gun.IsReloading)
		{
			if (!isReloading && CustomSynergies.PlayerHasActiveSynergy(player, "Gunvana"))
			{
				((MonoBehaviour)player).StartCoroutine(IncorporealityOnHit(player, 1f));
			}
			isReloading = true;
		}
		((GunBehaviour)this).OnReloadPressed(player, gun, manualReload);
	}

	public override void Update()
	{
		if (!base.gun.IsReloading && isReloading)
		{
			isReloading = false;
		}
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
}
