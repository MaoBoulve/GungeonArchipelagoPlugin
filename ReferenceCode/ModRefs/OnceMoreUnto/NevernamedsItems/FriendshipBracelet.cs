using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

internal class FriendshipBracelet : PlayerItem
{
	[CompilerGenerated]
	private sealed class _003CHandleEffect_003Ed__4 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerController user;

		public FriendshipBracelet _003C_003E4__this;

		private int _003Cc1_003E5__1;

		private int _003Cc2_003E5__2;

		private int _003Cc3_003E5__3;

		private float _003Celapsed_003E5__4;

		private int _003Ci_003E5__5;

		private int _003Cj_003E5__6;

		private int _003Ci_003E5__7;

		private string _003Cguid_003E5__8;

		private AIActor _003CorLoadByGuid_003E5__9;

		private Vector3 _003Cvector_003E5__10;

		private GameObject _003CextantCompanion2_003E5__11;

		private CompanionController _003CorAddComponent_003E5__12;

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
		public _003CHandleEffect_003Ed__4(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003Cguid_003E5__8 = null;
			_003CorLoadByGuid_003E5__9 = null;
			_003CextantCompanion2_003E5__11 = null;
			_003CorAddComponent_003E5__12 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_0197: Unknown result type (might be due to invalid IL or missing references)
			//IL_019c: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
			if (_003C_003E1__state != 0)
			{
				return false;
			}
			_003C_003E1__state = -1;
			((PlayerItem)_003C_003E4__this).IsCurrentlyActive = true;
			((PlayerItem)_003C_003E4__this).m_activeElapsed = 0f;
			((PlayerItem)_003C_003E4__this).m_activeDuration = 60f;
			_003Cc1_003E5__1 = user.orbitals.Count;
			_003Cc2_003E5__2 = user.trailOrbitals.Count;
			_003Cc3_003E5__3 = user.companions.Count;
			_003Ci_003E5__5 = 0;
			while (_003Ci_003E5__5 < _003Cc1_003E5__1)
			{
				_003C_003E4__this.CloneOrbital(((Component)user.orbitals[_003Ci_003E5__5].GetTransform()).gameObject, user);
				_003Ci_003E5__5++;
			}
			_003Cj_003E5__6 = 0;
			while (_003Cj_003E5__6 < _003Cc2_003E5__2)
			{
				_003C_003E4__this.CloneOrbital(((Component)user.trailOrbitals[_003Cj_003E5__6]).gameObject, user);
				_003Cj_003E5__6++;
			}
			PlayerUtility.RecalculateOrbitals(user);
			_003Ci_003E5__7 = 0;
			while (_003Ci_003E5__7 < _003Cc3_003E5__3)
			{
				_003Cguid_003E5__8 = user.companions[_003Ci_003E5__7].EnemyGuid;
				_003CorLoadByGuid_003E5__9 = EnemyDatabase.GetOrLoadByGuid(_003Cguid_003E5__8);
				_003Cvector_003E5__10 = ((BraveBehaviour)user).transform.position;
				_003CextantCompanion2_003E5__11 = Object.Instantiate<GameObject>(((Component)_003CorLoadByGuid_003E5__9).gameObject, _003Cvector_003E5__10, Quaternion.identity);
				_003CorAddComponent_003E5__12 = GameObjectExtensions.GetOrAddComponent<CompanionController>(_003CextantCompanion2_003E5__11);
				_003CorAddComponent_003E5__12.Initialize(user);
				if (Object.op_Implicit((Object)(object)((BraveBehaviour)_003CorAddComponent_003E5__12).specRigidbody))
				{
					PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(((BraveBehaviour)_003CorAddComponent_003E5__12).specRigidbody, (int?)null, false);
				}
				_003C_003E4__this.Summons.Add(_003CextantCompanion2_003E5__11);
				_003Cguid_003E5__8 = null;
				_003CorLoadByGuid_003E5__9 = null;
				_003CextantCompanion2_003E5__11 = null;
				_003CorAddComponent_003E5__12 = null;
				_003Ci_003E5__7++;
			}
			_003Celapsed_003E5__4 = 0f;
			while (_003Celapsed_003E5__4 < 60f)
			{
				_003Celapsed_003E5__4 += BraveTime.DeltaTime;
				if ((Object)(object)((PlayerItem)_003C_003E4__this).LastOwner == (Object)null || (Object)(object)user != (Object)(object)((PlayerItem)_003C_003E4__this).LastOwner || GameManager.Instance.IsLoadingLevel)
				{
					return false;
				}
			}
			_003C_003E4__this.ClearCompanions(user);
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

	public List<GameObject> Summons = new List<GameObject>();

	public static void Init()
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<FriendshipBracelet>("Friendship Bracelet", "SaKeyfice", "This key is hungry for sustenance so that it may lay its eggs, and spawn the next generation of keys.", "sharpkey_improved", assetbundle: true);
		PlayerItem val = (PlayerItem)(object)((obj is PlayerItem) ? obj : null);
		ItemBuilder.SetCooldownType(val, (CooldownType)0, 5f);
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)val, (StatType)14, 1f, (ModifyMethod)0);
		val.consumable = false;
		((PickupObject)val).quality = (ItemQuality)(-100);
	}

	public void CloneOrbital(GameObject orb, PlayerController play)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = Object.Instantiate<GameObject>(orb, ((BraveBehaviour)play).transform.position, Quaternion.identity);
		if (Object.op_Implicit((Object)(object)val.GetComponent<PlayerOrbital>()))
		{
			PlayerOrbital component = val.GetComponent<PlayerOrbital>();
			component.Initialize(play);
		}
		else if (Object.op_Implicit((Object)(object)val.GetComponent<PlayerOrbitalFollower>()))
		{
			PlayerOrbitalFollower component2 = val.GetComponent<PlayerOrbitalFollower>();
			component2.Initialize(play);
		}
		Summons.Add(val);
	}

	public override void DoEffect(PlayerController user)
	{
		((MonoBehaviour)GameManager.Instance).StartCoroutine(HandleEffect(user));
	}

	public IEnumerator HandleEffect(PlayerController user)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CHandleEffect_003Ed__4(0)
		{
			_003C_003E4__this = this,
			user = user
		};
	}

	public override void Pickup(PlayerController player)
	{
		player.OnNewFloorLoaded = (Action<PlayerController>)Delegate.Combine(player.OnNewFloorLoaded, new Action<PlayerController>(OnNewFloor));
		((PlayerItem)this).Pickup(player);
	}

	public override void OnPreDrop(PlayerController user)
	{
		if ((Object)(object)user != (Object)null)
		{
			Disable(user);
		}
		((PlayerItem)this).OnPreDrop(user);
	}

	public override void OnDestroy()
	{
		if ((Object)(object)base.LastOwner != (Object)null)
		{
			Disable(base.LastOwner);
		}
		((PlayerItem)this).OnDestroy();
	}

	private void ClearCompanions(PlayerController player = null)
	{
		for (int num = Summons.Count - 1; num >= 0; num--)
		{
			Object.Destroy((Object)(object)Summons[num]);
		}
		if (Object.op_Implicit((Object)(object)player))
		{
			PlayerUtility.RecalculateOrbitals(player);
		}
		Summons.Clear();
	}

	private void Disable(PlayerController player)
	{
		ClearCompanions(player);
		player.OnNewFloorLoaded = (Action<PlayerController>)Delegate.Remove(player.OnNewFloorLoaded, new Action<PlayerController>(OnNewFloor));
	}

	private void OnNewFloor(PlayerController player)
	{
		ClearCompanions(player);
	}

	public override bool CanBeUsed(PlayerController user)
	{
		return ((PlayerItem)this).CanBeUsed(user);
	}
}
