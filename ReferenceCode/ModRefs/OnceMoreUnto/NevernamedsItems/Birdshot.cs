using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class Birdshot : PassiveItem
{
	[CompilerGenerated]
	private sealed class _003CChangeProjectileDamage_003Ed__4 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Projectile bullet;

		public float oldDamage;

		public Birdshot _003C_003E4__this;

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
		public _003CChangeProjectileDamage_003Ed__4(int _003C_003E1__state)
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
				_003C_003E2__current = (object)new WaitForSeconds(0.1f);
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				if ((Object)(object)bullet != (Object)null)
				{
					bullet.baseData.damage = oldDamage;
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

	public static int BirdshotID;

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<Birdshot>("Birdshot", "Angry", "+40% damage to flying enemies.\n\nA collection of tiny pellets enchanted with an inherent hatred for anything that dares to leave the ground.\nQuarantined in the Gungeon after several unfortunate incidents in an airport.", "birdshot_icon", assetbundle: true);
		val.quality = (ItemQuality)3;
		AlexandriaTags.SetTag(val, "bullet_modifier");
		BirdshotID = val.PickupObjectId;
		Doug.AddToLootPool(val.PickupObjectId);
	}

	private void PostProcessProjectile(Projectile sourceProjectile, float effectChanceScalar)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		try
		{
			((BraveBehaviour)sourceProjectile).specRigidbody.OnPreRigidbodyCollision = (OnPreRigidbodyCollisionDelegate)Delegate.Combine((Delegate)(object)((BraveBehaviour)sourceProjectile).specRigidbody.OnPreRigidbodyCollision, (Delegate)new OnPreRigidbodyCollisionDelegate(HandlePreCollision));
		}
		catch (Exception ex)
		{
			ETGModConsole.Log((object)ex.Message, false);
		}
	}

	private void HandlePreCollision(SpeculativeRigidbody myRigidbody, PixelCollider myPixelCollider, SpeculativeRigidbody otherRigidbody, PixelCollider otherPixelCollider)
	{
		if (Object.op_Implicit((Object)(object)otherRigidbody) && Object.op_Implicit((Object)(object)((BraveBehaviour)otherRigidbody).healthHaver) && Object.op_Implicit((Object)(object)((BraveBehaviour)otherRigidbody).aiActor) && ((GameActor)((BraveBehaviour)otherRigidbody).aiActor).IsFlying)
		{
			float damage = ((BraveBehaviour)myRigidbody).projectile.baseData.damage;
			ProjectileData baseData = ((BraveBehaviour)myRigidbody).projectile.baseData;
			baseData.damage *= 1.4f;
			((MonoBehaviour)myRigidbody).StartCoroutine(ChangeProjectileDamage(((BraveBehaviour)myRigidbody).projectile, damage));
		}
	}

	private IEnumerator ChangeProjectileDamage(Projectile bullet, float oldDamage)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CChangeProjectileDamage_003Ed__4(0)
		{
			_003C_003E4__this = this,
			bullet = bullet,
			oldDamage = oldDamage
		};
	}

	public override DebrisObject Drop(PlayerController player)
	{
		DebrisObject result = ((PassiveItem)this).Drop(player);
		player.PostProcessProjectile -= PostProcessProjectile;
		return result;
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		player.PostProcessProjectile += PostProcessProjectile;
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			((PassiveItem)this).Owner.PostProcessProjectile -= PostProcessProjectile;
		}
		((PassiveItem)this).OnDestroy();
	}
}
