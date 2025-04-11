using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class PearlAmmolet : BlankModificationItem
{
	[CompilerGenerated]
	private sealed class _003COnBlankedDelay_003Ed__3 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Projectile component;

		public Vector2 direction;

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
		public _003COnBlankedDelay_003Ed__3(int _003C_003E1__state)
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
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Expected O, but got Unknown
			//IL_0051: Unknown result type (might be due to invalid IL or missing references)
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = (object)new WaitForEndOfFrame();
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				if (Object.op_Implicit((Object)(object)component))
				{
					component.SendInDirection(direction, true, true);
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

	private static int ID;

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<PearlAmmolet>("Pearl Ammolet", "Blanks Bubble", "Blanks convert enemy bullets into bubbles.\n\n Stolen from the Mother Clam, in a daring heist along the floor of a bottomless ocean.", "pearlammolet_icon", assetbundle: true);
		BlankModificationItem val = (BlankModificationItem)(object)((obj is BlankModificationItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)2;
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)val, (StatType)18, 1f, (ModifyMethod)0);
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)4, 1f);
		ID = ((PickupObject)val).PickupObjectId;
		AlexandriaTags.SetTag((PickupObject)(object)val, "ammolet");
	}

	public static void OnBlankedProjectile(Projectile proj)
	{
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)GameManager.Instance.PrimaryPlayer))
		{
			PickupObject byId = PickupObjectDatabase.GetById(599);
			GameObject val = SpawnManager.SpawnProjectile(((Component)((Gun)((byId is Gun) ? byId : null)).DefaultModule.projectiles[0]).gameObject, ((BraveBehaviour)proj).transform.position + Vector2Extensions.ToVector3ZisY(Random.insideUnitCircle, 0f), Quaternion.identity, true);
			Projectile component = val.GetComponent<Projectile>();
			component.Owner = (GameActor)(object)GameManager.Instance.PrimaryPlayer;
			component.Shooter = ((BraveBehaviour)GameManager.Instance.PrimaryPlayer).specRigidbody;
			if (GameManagerUtility.AnyPlayerHasActiveSynergy(GameManager.Instance, "Bubble Blowing, Baby!"))
			{
				component.RuntimeUpdateScale(1.3f);
				ProjectileData baseData = component.baseData;
				baseData.damage *= 1.5f;
			}
			component.collidesWithPlayer = false;
			component.collidesWithEnemies = true;
			component.collidesWithProjectiles = false;
			((MonoBehaviour)component).StartCoroutine(OnBlankedDelay(component, proj.Direction));
			((Component)component).gameObject.AddComponent<DieWhenOwnerNotInRoom>();
		}
	}

	public static IEnumerator OnBlankedDelay(Projectile component, Vector2 direction)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003COnBlankedDelay_003Ed__3(0)
		{
			component = component,
			direction = direction
		};
	}

	public override void Pickup(PlayerController player)
	{
		ExtendedPlayerComponent extComp = PlayerUtility.GetExtComp(player);
		extComp.OnBlankModificationItemProcessed = (Action<PlayerController, SilencerInstance, Vector2, BlankModificationItem>)Delegate.Combine(extComp.OnBlankModificationItemProcessed, new Action<PlayerController, SilencerInstance, Vector2, BlankModificationItem>(OnBlankModTriggered));
		((BlankModificationItem)this).Pickup(player);
	}

	public override void DisableEffect(PlayerController player)
	{
		ExtendedPlayerComponent extComp = PlayerUtility.GetExtComp(player);
		extComp.OnBlankModificationItemProcessed = (Action<PlayerController, SilencerInstance, Vector2, BlankModificationItem>)Delegate.Remove(extComp.OnBlankModificationItemProcessed, new Action<PlayerController, SilencerInstance, Vector2, BlankModificationItem>(OnBlankModTriggered));
		((PassiveItem)this).DisableEffect(player);
	}

	private void OnBlankModTriggered(PlayerController user, SilencerInstance blank, Vector2 pos, BlankModificationItem item)
	{
		if (item is PearlAmmolet)
		{
			blank.UsesCustomProjectileCallback = true;
			blank.OnCustomBlankedProjectile = (Action<Projectile>)Delegate.Combine(blank.OnCustomBlankedProjectile, new Action<Projectile>(OnBlankedProjectile));
		}
	}
}
