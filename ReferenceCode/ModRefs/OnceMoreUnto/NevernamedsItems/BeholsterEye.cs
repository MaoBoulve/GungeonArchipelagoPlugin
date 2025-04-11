using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class BeholsterEye : PlayerItem
{
	[CompilerGenerated]
	private sealed class _003CDur_003Ed__2 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerController user;

		public BeholsterEye _003C_003E4__this;

		private List<int> _003CgunIDS_003E5__1;

		private Projectile _003Cprojectile_003E5__2;

		private float _003Crandomangle_003E5__3;

		private int _003Ci_003E5__4;

		private GameObject _003CgameObject_003E5__5;

		private Projectile _003Ccomponent_003E5__6;

		private List<int>.Enumerator _003C_003Es__7;

		private int _003Cid_003E5__8;

		private Gun _003Cgun_003E5__9;

		private GameObject _003CgameObject_003E5__10;

		private HoveringGunController _003Chover_003E5__11;

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
		public _003CDur_003Ed__2(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003CgunIDS_003E5__1 = null;
			_003Cprojectile_003E5__2 = null;
			_003CgameObject_003E5__5 = null;
			_003Ccomponent_003E5__6 = null;
			_003C_003Es__7 = default(List<int>.Enumerator);
			_003Cgun_003E5__9 = null;
			_003CgameObject_003E5__10 = null;
			_003Chover_003E5__11 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0111: Unknown result type (might be due to invalid IL or missing references)
			//IL_0116: Unknown result type (might be due to invalid IL or missing references)
			//IL_012b: Unknown result type (might be due to invalid IL or missing references)
			//IL_024b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0255: Unknown result type (might be due to invalid IL or missing references)
			//IL_025a: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ad: Expected O, but got Unknown
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				((PlayerItem)_003C_003E4__this).IsCurrentlyActive = true;
				((PlayerItem)_003C_003E4__this).m_activeElapsed = 0f;
				((PlayerItem)_003C_003E4__this).m_activeDuration = 10f;
				_003CgunIDS_003E5__1 = new List<int> { 43, 42, 90, 30, 129, 32 };
				if (CustomSynergies.PlayerHasActiveSynergy(user, "Binocular"))
				{
					_003CgunIDS_003E5__1.Add(90);
					_003Cprojectile_003E5__2 = ((Gun)Databases.Items[90]).DefaultModule.finalProjectile;
					_003Crandomangle_003E5__3 = Random.Range(1, 360);
					_003Ci_003E5__4 = 0;
					while (_003Ci_003E5__4 < 3)
					{
						_003CgameObject_003E5__5 = SpawnManager.SpawnProjectile(((Component)_003Cprojectile_003E5__2).gameObject, Vector2.op_Implicit(((BraveBehaviour)user).sprite.WorldCenter), Quaternion.Euler(0f, 0f, _003Crandomangle_003E5__3), true);
						_003Ccomponent_003E5__6 = _003CgameObject_003E5__5.GetComponent<Projectile>();
						if ((Object)(object)_003Ccomponent_003E5__6 != (Object)null)
						{
							_003Ccomponent_003E5__6.Owner = (GameActor)(object)user;
							_003Ccomponent_003E5__6.Shooter = ((BraveBehaviour)user).specRigidbody;
							_003Ccomponent_003E5__6.ScaleByPlayerStats(user);
							user.DoPostProcessProjectile(_003Ccomponent_003E5__6);
						}
						_003Crandomangle_003E5__3 += 120f;
						_003CgameObject_003E5__5 = null;
						_003Ccomponent_003E5__6 = null;
						_003Ci_003E5__4++;
					}
					_003Cprojectile_003E5__2 = null;
				}
				_003C_003Es__7 = _003CgunIDS_003E5__1.GetEnumerator();
				try
				{
					while (_003C_003Es__7.MoveNext())
					{
						_003Cid_003E5__8 = _003C_003Es__7.Current;
						ref Gun reference = ref _003Cgun_003E5__9;
						PickupObject byId = PickupObjectDatabase.GetById(_003Cid_003E5__8);
						reference = (Gun)(object)((byId is Gun) ? byId : null);
						ref GameObject reference2 = ref _003CgameObject_003E5__10;
						Object obj = ResourceCache.Acquire("Global Prefabs/HoveringGun");
						reference2 = Object.Instantiate<GameObject>((GameObject)(object)((obj is GameObject) ? obj : null), Vector2Extensions.ToVector3ZisY(((GameActor)user).CenterPosition, 0f), Quaternion.identity);
						_003CgameObject_003E5__10.transform.parent = ((BraveBehaviour)user).transform;
						_003Chover_003E5__11 = _003CgameObject_003E5__10.GetComponent<HoveringGunController>();
						_003Chover_003E5__11.ConsumesTargetGunAmmo = false;
						_003Chover_003E5__11.ChanceToConsumeTargetGunAmmo = 0f;
						_003Chover_003E5__11.Position = (HoverPosition)1;
						_003Chover_003E5__11.Aim = (AimType)1;
						_003Chover_003E5__11.Trigger = (FireType)3;
						_003Chover_003E5__11.CooldownTime = ArtemissileShrine.GetProperShootingSpeed(_003Cgun_003E5__9);
						_003Chover_003E5__11.ShootDuration = ArtemissileShrine.GetProperShootDuration(_003Cgun_003E5__9);
						_003Chover_003E5__11.OnlyOnEmptyReload = false;
						_003Chover_003E5__11.Initialize(_003Cgun_003E5__9, user);
						_003C_003E4__this.spawnedGuns.Add(_003CgameObject_003E5__10);
						_003Cgun_003E5__9 = null;
						_003CgameObject_003E5__10 = null;
						_003Chover_003E5__11 = null;
					}
				}
				finally
				{
					((IDisposable)_003C_003Es__7/*cast due to .constrained prefix*/).Dispose();
				}
				_003C_003Es__7 = default(List<int>.Enumerator);
				user.stats.RecalculateStats(user, false, false);
				_003C_003E2__current = (object)new WaitForSeconds(10f);
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				_003C_003E4__this.EndEffect(user);
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

	public List<GameObject> spawnedGuns = new List<GameObject>();

	public static void Init()
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<BeholsterEye>("Beholster Eye", "Gungeon wind...", "Allows you to harness the great and terrible power of the sphere of many guns!\n\nGungeoneers who have spent too long under the influence of this abyssal relic report feeling phantom sensations of at least four other limbs.", "beholstereye_icon", assetbundle: true);
		PlayerItem val = (PlayerItem)(object)((obj is PlayerItem) ? obj : null);
		ItemBuilder.SetCooldownType(val, (CooldownType)1, 800f);
		val.consumable = false;
		((PickupObject)val).quality = (ItemQuality)5;
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)2, 1f);
	}

	public override void DoEffect(PlayerController user)
	{
		if (spawnedGuns.Count > 0)
		{
			EndEffect(user);
		}
		((MonoBehaviour)user).StartCoroutine(Dur(user));
	}

	public IEnumerator Dur(PlayerController user)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CDur_003Ed__2(0)
		{
			_003C_003E4__this = this,
			user = user
		};
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)base.LastOwner) && spawnedGuns.Count > 0)
		{
			EndEffect(base.LastOwner);
		}
		((PlayerItem)this).OnDestroy();
	}

	public override void OnPreDrop(PlayerController user)
	{
		if (spawnedGuns.Count > 0)
		{
			EndEffect(user);
		}
		((PlayerItem)this).OnPreDrop(user);
	}

	public void EndEffect(PlayerController player)
	{
		for (int num = spawnedGuns.Count - 1; num >= 0; num--)
		{
			if ((Object)(object)spawnedGuns[num] != (Object)null)
			{
				Object.Destroy((Object)(object)spawnedGuns[num].gameObject);
			}
		}
		spawnedGuns.Clear();
		((PlayerItem)this).IsCurrentlyActive = false;
	}
}
