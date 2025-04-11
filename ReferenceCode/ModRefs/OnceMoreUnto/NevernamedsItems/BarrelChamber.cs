using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class BarrelChamber : PassiveItem
{
	[CompilerGenerated]
	private sealed class _003CBreakBarrel_003Ed__4 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MinorBreakable breakable;

		public BarrelChamber _003C_003E4__this;

		private float _003Cwait_003E5__1;

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
		public _003CBreakBarrel_003Ed__4(int _003C_003E1__state)
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
			//IL_003c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0046: Expected O, but got Unknown
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003Cwait_003E5__1 = Random.Range(15f, 20f);
				_003C_003E2__current = (object)new WaitForSeconds(_003Cwait_003E5__1);
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				breakable.Break();
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

	[CompilerGenerated]
	private sealed class _003CSpawnBarrels_003Ed__5 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerController player;

		public BarrelChamber _003C_003E4__this;

		private Vector2 _003CplayerPosition_003E5__1;

		private List<Vector2> _003ClistToUse_003E5__2;

		private List<Vector2>.Enumerator _003C_003Es__3;

		private Vector2 _003Coffset_003E5__4;

		private Vector2 _003CbarrelPos_003E5__5;

		private CellData _003Ccell_003E5__6;

		private GameObject _003Cbarrel_003E5__7;

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
		public _003CSpawnBarrels_003Ed__5(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003ClistToUse_003E5__2 = null;
			_003C_003Es__3 = default(List<Vector2>.Enumerator);
			_003Ccell_003E5__6 = null;
			_003Cbarrel_003E5__7 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_0048: Unknown result type (might be due to invalid IL or missing references)
			//IL_0095: Unknown result type (might be due to invalid IL or missing references)
			//IL_009a: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f7: Invalid comparison between Unknown and I4
			//IL_0108: Unknown result type (might be due to invalid IL or missing references)
			//IL_010d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0112: Unknown result type (might be due to invalid IL or missing references)
			//IL_014f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0159: Expected O, but got Unknown
			//IL_0159: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Expected O, but got Unknown
			//IL_0175: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_018b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0209: Unknown result type (might be due to invalid IL or missing references)
			//IL_020e: Unknown result type (might be due to invalid IL or missing references)
			if (_003C_003E1__state != 0)
			{
				return false;
			}
			_003C_003E1__state = -1;
			if (_003C_003E4__this.canFire)
			{
				_003C_003E4__this.canFire = false;
				_003CplayerPosition_003E5__1 = ((BraveBehaviour)player).sprite.WorldBottomCenter;
				_003ClistToUse_003E5__2 = offsetsForBarrels;
				if (CustomSynergies.PlayerHasActiveSynergy(player, "Double Barrelled"))
				{
					_003ClistToUse_003E5__2 = offsetsForBarrelsSynergy;
				}
				_003C_003Es__3 = _003ClistToUse_003E5__2.GetEnumerator();
				try
				{
					while (_003C_003Es__3.MoveNext())
					{
						_003Coffset_003E5__4 = _003C_003Es__3.Current;
						_003CbarrelPos_003E5__5 = _003CplayerPosition_003E5__1 + _003Coffset_003E5__4;
						_003Ccell_003E5__6 = GameManager.Instance.Dungeon.data.cellData[(int)_003CbarrelPos_003E5__5.x][(int)_003CbarrelPos_003E5__5.y];
						if ((int)_003Ccell_003E5__6.type == 2)
						{
							_003Cbarrel_003E5__7 = Object.Instantiate<GameObject>(EasyPlaceableObjects.GenericBarrel, Vector2.op_Implicit(_003CbarrelPos_003E5__5), Quaternion.identity);
							_003Cbarrel_003E5__7.GetComponentInChildren<MinorBreakable>().OnlyBrokenByCode = true;
							SpeculativeRigidbody componentInChildren = _003Cbarrel_003E5__7.GetComponentInChildren<SpeculativeRigidbody>();
							componentInChildren.OnPreRigidbodyCollision = (OnPreRigidbodyCollisionDelegate)Delegate.Combine((Delegate)(object)componentInChildren.OnPreRigidbodyCollision, (Delegate)new OnPreRigidbodyCollisionDelegate(_003C_003E4__this.HandlePreCollision));
							_003Cbarrel_003E5__7.GetComponentInChildren<SpeculativeRigidbody>().PrimaryPixelCollider.CollisionLayer = (CollisionLayer)15;
							((tk2dBaseSprite)_003Cbarrel_003E5__7.GetComponentInChildren<tk2dSprite>()).PlaceAtPositionByAnchor(Vector2.op_Implicit(_003CbarrelPos_003E5__5), (Anchor)1);
							((MonoBehaviour)_003C_003E4__this).StartCoroutine(_003C_003E4__this.BreakBarrel(_003Cbarrel_003E5__7.GetComponentInChildren<MinorBreakable>()));
							_003Cbarrel_003E5__7 = null;
							_003Cbarrel_003E5__7 = null;
						}
						_003Ccell_003E5__6 = null;
						_003Ccell_003E5__6 = null;
					}
				}
				finally
				{
					((IDisposable)_003C_003Es__3/*cast due to .constrained prefix*/).Dispose();
				}
				_003C_003Es__3 = default(List<Vector2>.Enumerator);
				_003CplayerPosition_003E5__1 = Vector2.zero;
				_003ClistToUse_003E5__2 = null;
				((MonoBehaviour)_003C_003E4__this).Invoke("HandleCooldown", 0.5f);
				_003ClistToUse_003E5__2 = null;
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

	private bool canFire = true;

	public static List<Vector2> offsetsForBarrelsSynergy = new List<Vector2>
	{
		new Vector2(2f, 1f),
		new Vector2(2f, 0f),
		new Vector2(2f, -1f),
		new Vector2(3f, 1f),
		new Vector2(3f, 0f),
		new Vector2(3f, -1f),
		new Vector2(-2f, -1f),
		new Vector2(-2f, 0f),
		new Vector2(-2f, 1f),
		new Vector2(-3f, -1f),
		new Vector2(-3f, 0f),
		new Vector2(-3f, 1f),
		new Vector2(0f, 2f),
		new Vector2(1f, 2f),
		new Vector2(-1f, 2f),
		new Vector2(0f, 3f),
		new Vector2(1f, 3f),
		new Vector2(-1f, 3f),
		new Vector2(0f, -2f),
		new Vector2(1f, -2f),
		new Vector2(-1f, -2f),
		new Vector2(0f, -3f),
		new Vector2(1f, -3f),
		new Vector2(-1f, -3f),
		new Vector2(2f, 2f),
		new Vector2(2f, -2f),
		new Vector2(-2f, 2f),
		new Vector2(-2f, -2f)
	};

	public static List<Vector2> offsetsForBarrels = new List<Vector2>
	{
		new Vector2(2f, 1f),
		new Vector2(2f, 0f),
		new Vector2(2f, -1f),
		new Vector2(-2f, -1f),
		new Vector2(-2f, 0f),
		new Vector2(-2f, 1f),
		new Vector2(0f, 2f),
		new Vector2(1f, 2f),
		new Vector2(-1f, 2f),
		new Vector2(0f, -2f),
		new Vector2(1f, -2f),
		new Vector2(-1f, -2f)
	};

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<BarrelChamber>("Barrel Chamber", "Wooden Shield", "A hilariously pathetic example of the forgotten art of doliumancy.\n\nCreates a weak, albeit free defence upon reloading an empty clip.", "barrelchamber_icon", assetbundle: true);
		val.quality = (ItemQuality)1;
		ID = val.PickupObjectId;
	}

	private void HandleGunReloaded(PlayerController player, Gun playerGun)
	{
		if (playerGun.ClipShotsRemaining == 0)
		{
			((MonoBehaviour)this).StartCoroutine(SpawnBarrels(player));
		}
	}

	private IEnumerator BreakBarrel(MinorBreakable breakable)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CBreakBarrel_003Ed__4(0)
		{
			_003C_003E4__this = this,
			breakable = breakable
		};
	}

	private IEnumerator SpawnBarrels(PlayerController player)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CSpawnBarrels_003Ed__5(0)
		{
			_003C_003E4__this = this,
			player = player
		};
	}

	private void HandlePreCollision(SpeculativeRigidbody myRigidbody, PixelCollider myPixelCollider, SpeculativeRigidbody otherRigidbody, PixelCollider otherPixelCollider)
	{
		try
		{
			if (!Object.op_Implicit((Object)(object)otherRigidbody))
			{
				return;
			}
			if (Object.op_Implicit((Object)(object)((Component)otherRigidbody).GetComponent<GameActor>()))
			{
				PhysicsEngine.SkipCollision = true;
			}
			if (Object.op_Implicit((Object)(object)((Component)otherRigidbody).GetComponent<Projectile>()))
			{
				if (Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(((Component)otherRigidbody).GetComponent<Projectile>())))
				{
					PhysicsEngine.SkipCollision = true;
				}
				else
				{
					((Component)myRigidbody).GetComponentInChildren<MinorBreakable>().Break();
				}
			}
		}
		catch (Exception ex)
		{
			ETGModConsole.Log((object)ex.Message, false);
			ETGModConsole.Log((object)ex.StackTrace, false);
		}
	}

	private void HandleCooldown()
	{
		canFire = true;
	}

	private void PostProcessProj(Projectile proj, float g)
	{
		proj.pierceMinorBreakables = true;
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		player.PostProcessProjectile += PostProcessProj;
		player.OnReloadedGun = (Action<PlayerController, Gun>)Delegate.Combine(player.OnReloadedGun, new Action<PlayerController, Gun>(HandleGunReloaded));
	}

	public override DebrisObject Drop(PlayerController player)
	{
		DebrisObject result = ((PassiveItem)this).Drop(player);
		player.PostProcessProjectile -= PostProcessProj;
		player.OnReloadedGun = (Action<PlayerController, Gun>)Delegate.Remove(player.OnReloadedGun, new Action<PlayerController, Gun>(HandleGunReloaded));
		return result;
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			PlayerController owner = ((PassiveItem)this).Owner;
			owner.OnReloadedGun = (Action<PlayerController, Gun>)Delegate.Remove(owner.OnReloadedGun, new Action<PlayerController, Gun>(HandleGunReloaded));
			((PassiveItem)this).Owner.PostProcessProjectile -= PostProcessProj;
		}
		((PassiveItem)this).OnDestroy();
	}
}
