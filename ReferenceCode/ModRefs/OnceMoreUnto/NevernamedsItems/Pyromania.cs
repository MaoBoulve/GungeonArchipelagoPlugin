using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

internal class Pyromania : PassiveItem
{
	[CompilerGenerated]
	private sealed class _003CplaceBarrels_003Ed__5 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Pyromania _003C_003E4__this;

		private int _003Cnum_003E5__1;

		private RoomHandler _003Croom_003E5__2;

		private int _003Cj_003E5__3;

		private IntVector2 _003Cposition_003E5__4;

		private GameObject _003Cbarrel_003E5__5;

		private SpeculativeRigidbody _003CObjectSpecRigidBody_003E5__6;

		private Component[] _003CcomponentsInChildren_003E5__7;

		private Component[] _003CcomponentsInChildren2_003E5__8;

		private int _003Ci_003E5__9;

		private IPlayerInteractable _003Cinteractable_003E5__10;

		private int _003Ci_003E5__11;

		private IPlaceConfigurable _003CplaceConfigurable_003E5__12;

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
		public _003CplaceBarrels_003Ed__5(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003Croom_003E5__2 = null;
			_003Cbarrel_003E5__5 = null;
			_003CObjectSpecRigidBody_003E5__6 = null;
			_003CcomponentsInChildren_003E5__7 = null;
			_003CcomponentsInChildren2_003E5__8 = null;
			_003Cinteractable_003E5__10 = null;
			_003CplaceConfigurable_003E5__12 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0084: Expected O, but got Unknown
			//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_00af: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_025b: Unknown result type (might be due to invalid IL or missing references)
			//IL_026a: Unknown result type (might be due to invalid IL or missing references)
			//IL_026f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0274: Unknown result type (might be due to invalid IL or missing references)
			//IL_0279: Unknown result type (might be due to invalid IL or missing references)
			//IL_028a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0294: Expected O, but got Unknown
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003Cnum_003E5__1 = 5;
				if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)_003C_003E4__this).Owner, "Meet The Pyro"))
				{
					_003Cnum_003E5__1 += 2;
				}
				_003Croom_003E5__2 = ((PassiveItem)_003C_003E4__this).Owner.CurrentRoom;
				_003C_003E2__current = (object)new WaitForSeconds(1f);
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				_003Cj_003E5__3 = 0;
				break;
			case 2:
				_003C_003E1__state = -1;
				_003Cbarrel_003E5__5 = null;
				_003CObjectSpecRigidBody_003E5__6 = null;
				_003CcomponentsInChildren_003E5__7 = null;
				_003CcomponentsInChildren2_003E5__8 = null;
				_003Cj_003E5__3++;
				break;
			}
			if (_003Cj_003E5__3 < 5)
			{
				_003Cposition_003E5__4 = _003Croom_003E5__2.GetRandomVisibleClearSpot(2, 2);
				_003Cbarrel_003E5__5 = Object.Instantiate<GameObject>(EasyPlaceableObjects.ExplosiveBarrel, ((IntVector2)(ref _003Cposition_003E5__4)).ToVector3(), Quaternion.identity);
				_003CObjectSpecRigidBody_003E5__6 = _003Cbarrel_003E5__5.GetComponentInChildren<SpeculativeRigidbody>();
				_003CcomponentsInChildren_003E5__7 = _003Cbarrel_003E5__5.GetComponentsInChildren(typeof(IPlayerInteractable));
				_003Ci_003E5__9 = 0;
				while (_003Ci_003E5__9 < _003CcomponentsInChildren_003E5__7.Length)
				{
					ref IPlayerInteractable reference = ref _003Cinteractable_003E5__10;
					Component obj = _003CcomponentsInChildren_003E5__7[_003Ci_003E5__9];
					reference = (IPlayerInteractable)(object)((obj is IPlayerInteractable) ? obj : null);
					if (_003Cinteractable_003E5__10 != null)
					{
						_003Croom_003E5__2.RegisterInteractable(_003Cinteractable_003E5__10);
					}
					_003Cinteractable_003E5__10 = null;
					_003Ci_003E5__9++;
				}
				_003CcomponentsInChildren2_003E5__8 = _003Cbarrel_003E5__5.GetComponentsInChildren(typeof(IPlaceConfigurable));
				_003Ci_003E5__11 = 0;
				while (_003Ci_003E5__11 < _003CcomponentsInChildren2_003E5__8.Length)
				{
					ref IPlaceConfigurable reference2 = ref _003CplaceConfigurable_003E5__12;
					Component obj2 = _003CcomponentsInChildren2_003E5__8[_003Ci_003E5__11];
					reference2 = (IPlaceConfigurable)(object)((obj2 is IPlaceConfigurable) ? obj2 : null);
					if (_003CplaceConfigurable_003E5__12 != null)
					{
						_003CplaceConfigurable_003E5__12.ConfigureOnPlacement(_003Croom_003E5__2);
					}
					_003CplaceConfigurable_003E5__12 = null;
					_003Ci_003E5__11++;
				}
				_003CObjectSpecRigidBody_003E5__6.Initialize();
				PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(_003CObjectSpecRigidBody_003E5__6, (int?)null, false);
				PickupObject byId = PickupObjectDatabase.GetById(328);
				Object.Instantiate<GameObject>(((Gun)((byId is Gun) ? byId : null)).DefaultModule.chargeProjectiles[0].Projectile.hitEffects.overrideMidairDeathVFX, Vector2.op_Implicit(((IntVector2)(ref _003Cposition_003E5__4)).ToVector2() + new Vector2(0.5f, 0.5f)), Quaternion.identity);
				_003C_003E2__current = (object)new WaitForSeconds(0.1f);
				_003C_003E1__state = 2;
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

	public static int ID;

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<Pyromania>("Pyromania", "Reign of Fire", "Spawns additional explosive barrels in each room.\n\nSome people just want to watch the world burn. And you're one of them.", "pyromania_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)1;
		ID = ((PickupObject)val).PickupObjectId;
	}

	public override void Pickup(PlayerController player)
	{
		player.OnEnteredCombat = (Action)Delegate.Combine(player.OnEnteredCombat, new Action(OnEnteredCombat));
		((PassiveItem)this).Pickup(player);
	}

	public override void DisableEffect(PlayerController player)
	{
		player.OnEnteredCombat = (Action)Delegate.Remove(player.OnEnteredCombat, new Action(OnEnteredCombat));
		((PassiveItem)this).DisableEffect(player);
	}

	private void OnEnteredCombat()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner) && ((PassiveItem)this).Owner.CurrentRoom != null)
		{
			((MonoBehaviour)this).StartCoroutine(placeBarrels());
		}
	}

	private IEnumerator placeBarrels()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CplaceBarrels_003Ed__5(0)
		{
			_003C_003E4__this = this
		};
	}
}
