using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class BitBucket : PlayerItem, ILabelItem
{
	[CompilerGenerated]
	private sealed class _003CConsumeProjectile_003Ed__9 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Projectile bullet;

		public BitBucket _003C_003E4__this;

		private GameObject _003CnewBulletOBJ_003E5__1;

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
		public _003CConsumeProjectile_003Ed__9(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003CnewBulletOBJ_003E5__1 = null;
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
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				_003CnewBulletOBJ_003E5__1 = FakePrefab.Clone(((Component)bullet).gameObject);
				_003CnewBulletOBJ_003E5__1.SetActive(false);
				FakePrefab.MarkAsFakePrefab(_003CnewBulletOBJ_003E5__1);
				Object.DontDestroyOnLoad((Object)(object)_003CnewBulletOBJ_003E5__1);
				_003C_003E4__this.storedProjectiles.Add(_003CnewBulletOBJ_003E5__1.GetComponent<Projectile>());
				_003C_003E2__current = null;
				_003C_003E1__state = 2;
				return true;
			case 2:
				_003C_003E1__state = -1;
				Object.Destroy((Object)(object)((Component)bullet).gameObject);
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

	private List<Projectile> storedProjectiles = new List<Projectile>();

	private string currentLabel;

	public static void Init()
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		BitBucket bitBucket = ItemSetup.NewItem<BitBucket>("Bit Bucket", "Data Loss", "Consumes lost data, regurgitating it forth when agitated.\n\nThe cornerstone of modern computing.", "bitbucket_icon", assetbundle: true) as BitBucket;
		ItemBuilder.SetCooldownType((PlayerItem)(object)bitBucket, (CooldownType)0, 0.2f);
		((PlayerItem)bitBucket).consumable = false;
		((PickupObject)bitBucket).quality = (ItemQuality)1;
	}

	public override void Update()
	{
		currentLabel = storedProjectiles.Count().ToString();
		((PlayerItem)this).Update();
	}

	public string GetLabel()
	{
		return currentLabel;
	}

	public override void Pickup(PlayerController player)
	{
		player.PostProcessProjectile += PostProcessProjectile;
		((PlayerItem)this).Pickup(player);
	}

	public override void OnPreDrop(PlayerController user)
	{
		user.PostProcessProjectile -= PostProcessProjectile;
		((PlayerItem)this).OnPreDrop(user);
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)base.LastOwner))
		{
			base.LastOwner.PostProcessProjectile -= PostProcessProjectile;
		}
		((PlayerItem)this).OnDestroy();
	}

	private void PostProcessProjectile(Projectile bullet, float thing)
	{
		if (storedProjectiles.Count() < 20 && Random.value <= 0.2f)
		{
			((MonoBehaviour)this).StartCoroutine(ConsumeProjectile(bullet));
		}
	}

	private IEnumerator ConsumeProjectile(Projectile bullet)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CConsumeProjectile_003Ed__9(0)
		{
			_003C_003E4__this = this,
			bullet = bullet
		};
	}

	public override bool CanBeUsed(PlayerController user)
	{
		if (storedProjectiles.Count() > 0)
		{
			return true;
		}
		return false;
	}

	public override void DoEffect(PlayerController user)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		int num = storedProjectiles.Count();
		float startFloat = Vector2Extensions.ToAngle(Random.insideUnitCircle);
		if ((Object)(object)((GameActor)user).CurrentGun != (Object)null)
		{
			startFloat = ((GameActor)user).CurrentGun.CurrentAngle;
		}
		for (int num2 = num - 1; num2 >= 0; num2--)
		{
			float accuracyAngled = ProjSpawnHelper.GetAccuracyAngled(startFloat, 25f, user);
			GameObject gameObject = ((Component)storedProjectiles[num2]).gameObject;
			GameObject val = SpawnManager.SpawnProjectile(gameObject, Vector2.op_Implicit(((BraveBehaviour)user).sprite.WorldCenter), Quaternion.Euler(0f, 0f, accuracyAngled), true);
			Projectile component = val.GetComponent<Projectile>();
			if ((Object)(object)component != (Object)null)
			{
				component.Owner = (GameActor)(object)user;
				component.Shooter = ((BraveBehaviour)user).specRigidbody;
				ProjectileData baseData = component.baseData;
				baseData.speed *= Random.Range(0.9f, 1.1f);
			}
			storedProjectiles.RemoveAt(num2);
			Object.Destroy((Object)(object)gameObject);
		}
	}
}
