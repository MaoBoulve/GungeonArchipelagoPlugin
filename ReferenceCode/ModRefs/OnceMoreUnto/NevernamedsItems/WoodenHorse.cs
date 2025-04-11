using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class WoodenHorse : AdvancedGunBehavior
{
	[CompilerGenerated]
	private sealed class _003CUnstealthy_003Ed__7 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public WoodenHorse _003C_003E4__this;

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
		public _003CUnstealthy_003Ed__7(int _003C_003E1__state)
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
				_003C_003E2__current = (object)new WaitForSeconds(0.15f);
				_003C_003E1__state = 1;
				return true;
			case 1:
			{
				_003C_003E1__state = -1;
				GameActor currentOwner = ((AdvancedGunBehavior)_003C_003E4__this).gun.CurrentOwner;
				((PlayerController)((currentOwner is PlayerController) ? currentOwner : null)).OnDidUnstealthyAction += _003C_003E4__this.BreakStealth;
				return false;
			}
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

	public static int WoodenHorseID;

	public static void Add()
	{
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Wooden Horse", "woodenhorse");
		Game.Items.Rename("outdated_gun_mods:wooden_horse", "nn:wooden_horse");
		((Component)val).gameObject.AddComponent<WoodenHorse>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Let Me In!");
		GunExt.SetLongDescription((PickupObject)(object)val, "This equine effigy was engineered by an ancient gunslinger as a misleading gift to gain the trust of the Gundead.\n\nTo this day, Gundead are still fooled!");
		val.SetGunSprites("woodenhorse");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(12);
		gunSwitchGroup = ((Gun)((byId2 is Gun) ? byId2 : null)).gunSwitchGroup;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1.5f;
		val.DefaultModule.cooldownTime = 0.11f;
		val.DefaultModule.numberOfShotsInClip = 30;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.75f, 1.06f, 0f);
		val.SetBaseMaxAmmo(400);
		val.ammo = 400;
		val.gunClass = (GunClass)50;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		val2.baseData.damage = 7.7f;
		val2.SetProjectileSprite("woodenhorse_projectile", 8, 8, lightened: false, (Anchor)4, 7, 7, anchorChangesCollider: true, fixesScale: false, null, null);
		((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Wooden Horse Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/woodenhorse_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/thinline_clipempty");
		((PickupObject)val).quality = (ItemQuality)4;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		WoodenHorseID = ((PickupObject)val).PickupObjectId;
	}

	private void OnEnteredCombat()
	{
		if (Object.op_Implicit((Object)(object)base.gun) && Object.op_Implicit((Object)(object)GunTools.GunPlayerOwner(base.gun)) && Object.op_Implicit((Object)(object)((GameActor)GunTools.GunPlayerOwner(base.gun)).CurrentGun) && ((PickupObject)((GameActor)GunTools.GunPlayerOwner(base.gun)).CurrentGun).PickupObjectId == ((PickupObject)base.gun).PickupObjectId)
		{
			StealthEffect();
		}
	}

	protected override void OnPickedUpByPlayer(PlayerController player)
	{
		player.OnEnteredCombat = (Action)Delegate.Combine(player.OnEnteredCombat, new Action(OnEnteredCombat));
		((AdvancedGunBehavior)this).OnPickedUpByPlayer(player);
	}

	protected override void OnPostDroppedByPlayer(PlayerController player)
	{
		player.OnEnteredCombat = (Action)Delegate.Remove(player.OnEnteredCombat, new Action(OnEnteredCombat));
		if (((GameActor)player).IsStealthed)
		{
			BreakStealth(player);
		}
		((AdvancedGunBehavior)this).OnPostDroppedByPlayer(player);
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)base.gun) && Object.op_Implicit((Object)(object)GunTools.GunPlayerOwner(base.gun)))
		{
			GameActor currentOwner = base.gun.CurrentOwner;
			BreakStealth((PlayerController)(object)((currentOwner is PlayerController) ? currentOwner : null));
			PlayerController obj = GunTools.GunPlayerOwner(base.gun);
			obj.OnEnteredCombat = (Action)Delegate.Remove(obj.OnEnteredCombat, new Action(OnEnteredCombat));
		}
		((BraveBehaviour)this).OnDestroy();
	}

	private void StealthEffect()
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Expected O, but got Unknown
		GameActor currentOwner = base.gun.CurrentOwner;
		PlayerController val = (PlayerController)(object)((currentOwner is PlayerController) ? currentOwner : null);
		BreakStealth(val);
		val.OnItemStolen += BreakStealthOnSteal;
		val.ChangeSpecialShaderFlag(1, 1f);
		((BraveBehaviour)val).healthHaver.OnDamaged += new OnDamagedEvent(OnDamaged);
		((GameActor)val).SetIsStealthed(true, "woodenhorse");
		val.SetCapableOfStealing(true, "woodenhorse", (float?)null);
		((MonoBehaviour)GameManager.Instance).StartCoroutine(Unstealthy());
	}

	private IEnumerator Unstealthy()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CUnstealthy_003Ed__7(0)
		{
			_003C_003E4__this = this
		};
	}

	private void OnDamaged(float resultValue, float maxValue, CoreDamageTypes damageTypes, DamageCategory damageCategory, Vector2 damageDirection)
	{
		GameActor currentOwner = base.gun.CurrentOwner;
		BreakStealth((PlayerController)(object)((currentOwner is PlayerController) ? currentOwner : null));
	}

	private void BreakStealthOnSteal(PlayerController arg1, ShopItemController arg2)
	{
		BreakStealth(arg1);
	}

	private void BreakStealth(PlayerController player)
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected O, but got Unknown
		player.ChangeSpecialShaderFlag(1, 0f);
		player.OnItemStolen -= BreakStealthOnSteal;
		((GameActor)player).SetIsStealthed(false, "woodenhorse");
		((BraveBehaviour)player).healthHaver.OnDamaged -= new OnDamagedEvent(OnDamaged);
		player.SetCapableOfStealing(false, "woodenhorse", (float?)null);
		player.OnDidUnstealthyAction -= BreakStealth;
		AkSoundEngine.PostEvent("Play_ENM_wizardred_appear_01", ((Component)this).gameObject);
	}
}
