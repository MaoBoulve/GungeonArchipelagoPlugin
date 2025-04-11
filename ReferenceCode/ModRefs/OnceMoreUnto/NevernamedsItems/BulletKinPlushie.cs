using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class BulletKinPlushie : PassiveItem
{
	[CompilerGenerated]
	private sealed class _003CInflictRage_003Ed__8 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerController player;

		public BulletKinPlushie _003C_003E4__this;

		private RagePassiveItem _003Crageitem_003E5__1;

		private float _003Celapsed_003E5__2;

		private float _003CparticleCounter_003E5__3;

		private float _003CDuration_003E5__4;

		private int _003Cnum_003E5__5;

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
		public _003CInflictRage_003Ed__8(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003Crageitem_003E5__1 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0185: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01dd: Invalid comparison between Unknown and I4
			//IL_02d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0302: Unknown result type (might be due to invalid IL or missing references)
			//IL_0307: Unknown result type (might be due to invalid IL or missing references)
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				if (_003C_003E4__this.rageActive)
				{
					((MonoBehaviour)_003C_003E4__this).StopCoroutine(_003C_003E4__this.removeRageCoroutine);
					_003C_003E4__this.RemoveStat((StatType)5);
					player.stats.RecalculateStats(player, true, false);
					_003C_003E4__this.rageActive = false;
				}
				player.stats.RecalculateStats(player, true, false);
				_003Crageitem_003E5__1 = ((Component)PickupObjectDatabase.GetById(353)).GetComponent<RagePassiveItem>();
				_003C_003E4__this.RageOverheadVFX = _003Crageitem_003E5__1.OverheadVFX.gameObject;
				_003C_003E4__this.instanceVFX = ((GameActor)((PassiveItem)_003C_003E4__this).Owner).PlayEffectOnActor(_003C_003E4__this.RageOverheadVFX, new Vector3(0f, 1.375f, 0f), true, true, false);
				_003C_003E4__this.AddStat((StatType)5, 2f, (ModifyMethod)1);
				player.stats.RecalculateStats(player, true, false);
				_003C_003E4__this.rageActive = true;
				_003Celapsed_003E5__2 = 0f;
				_003CparticleCounter_003E5__3 = 0f;
				_003CDuration_003E5__4 = 4f;
				break;
			case 1:
				_003C_003E1__state = -1;
				break;
			}
			if (_003Celapsed_003E5__2 < _003CDuration_003E5__4)
			{
				_003Celapsed_003E5__2 += BraveTime.DeltaTime;
				((PassiveItem)_003C_003E4__this).Owner.baseFlatColorOverride = Vector3Extensions.WithAlpha(_003C_003E4__this.flatColorOverride, Mathf.Lerp(_003C_003E4__this.flatColorOverride.a, 0f, Mathf.Clamp01(_003Celapsed_003E5__2 - (_003CDuration_003E5__4 - 1f))));
				if ((int)GameManager.Options.ShaderQuality != 0 && (int)GameManager.Options.ShaderQuality != 3 && Object.op_Implicit((Object)(object)((PassiveItem)_003C_003E4__this).Owner) && ((PassiveItem)_003C_003E4__this).Owner.IsVisible && !((GameActor)((PassiveItem)_003C_003E4__this).Owner).IsFalling)
				{
					_003CparticleCounter_003E5__3 += BraveTime.DeltaTime * 40f;
					if (Object.op_Implicit((Object)(object)_003C_003E4__this.instanceVFX) && _003Celapsed_003E5__2 > 1f)
					{
						_003C_003E4__this.instanceVFX.GetComponent<tk2dSpriteAnimator>().PlayAndDestroyObject("rage_face_vfx_out", (Action)null);
						_003C_003E4__this.instanceVFX = null;
					}
					if (_003CparticleCounter_003E5__3 > 1f)
					{
						_003Cnum_003E5__5 = Mathf.FloorToInt(_003CparticleCounter_003E5__3);
						_003CparticleCounter_003E5__3 %= 1f;
						GlobalSparksDoer.DoRandomParticleBurst(_003Cnum_003E5__5, Vector2Extensions.ToVector3ZisY(((BraveBehaviour)((PassiveItem)_003C_003E4__this).Owner).sprite.WorldBottomLeft, 0f), Vector2Extensions.ToVector3ZisY(((BraveBehaviour)((PassiveItem)_003C_003E4__this).Owner).sprite.WorldTopRight, 0f), Vector3.up, 90f, 0.5f, (float?)null, (float?)null, (Color?)null, (SparksType)1);
					}
				}
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			_003C_003E4__this.removeRageCoroutine = ((MonoBehaviour)GameManager.Instance).StartCoroutine(_003C_003E4__this.RemoveRage(player));
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
	private sealed class _003CRemoveRage_003Ed__10 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerController player;

		public BulletKinPlushie _003C_003E4__this;

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
		public _003CRemoveRage_003Ed__10(int _003C_003E1__state)
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
			if (_003C_003E1__state != 0)
			{
				return false;
			}
			_003C_003E1__state = -1;
			_003C_003E4__this.stopRageCoroutineActive = true;
			if (Object.op_Implicit((Object)(object)_003C_003E4__this.instanceVFX))
			{
				_003C_003E4__this.instanceVFX.GetComponent<tk2dSpriteAnimator>().PlayAndDestroyObject("rage_face_vfx_out", (Action)null);
			}
			_003C_003E4__this.RemoveStat((StatType)5);
			player.stats.RecalculateStats(player, true, false);
			_003C_003E4__this.rageActive = false;
			_003C_003E4__this.stopRageCoroutineActive = false;
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

	public GameObject RageOverheadVFX;

	public bool rageActive = false;

	public bool stopRageCoroutineActive = false;

	private Coroutine removeRageCoroutine;

	public Color flatColorOverride = new Color(0.5f, 0f, 0f, 0.75f);

	private GameObject instanceVFX;

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<BulletKinPlushie>("Bullet Kin Plushie", "Why Must I Do This?", "Chance to rage upon killing an enemy.\n\nThey’re so cute once you get to know them... even if they wanna kill you...", "bulletkinplushie_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)3;
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)2, 1f);
	}

	public override void Pickup(PlayerController player)
	{
		player.OnAnyEnemyReceivedDamage = (Action<float, bool, HealthHaver>)Delegate.Combine(player.OnAnyEnemyReceivedDamage, new Action<float, bool, HealthHaver>(OnEnemyDamaged));
		((PassiveItem)this).Pickup(player);
	}

	public override DebrisObject Drop(PlayerController player)
	{
		player.OnAnyEnemyReceivedDamage = (Action<float, bool, HealthHaver>)Delegate.Remove(player.OnAnyEnemyReceivedDamage, new Action<float, bool, HealthHaver>(OnEnemyDamaged));
		return ((PassiveItem)this).Drop(player);
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			PlayerController owner = ((PassiveItem)this).Owner;
			owner.OnAnyEnemyReceivedDamage = (Action<float, bool, HealthHaver>)Delegate.Remove(owner.OnAnyEnemyReceivedDamage, new Action<float, bool, HealthHaver>(OnEnemyDamaged));
		}
		((PassiveItem)this).OnDestroy();
	}

	private void OnEnemyDamaged(float damage, bool fatal, HealthHaver enemyHealth)
	{
		if (Object.op_Implicit((Object)(object)enemyHealth) && fatal)
		{
			float num = 0.2f;
			if (((PassiveItem)this).Owner.HasPickupID(476) || ((PassiveItem)this).Owner.HasPickupID(150))
			{
				num = 0.35f;
			}
			if (Random.value <= num)
			{
				((MonoBehaviour)this).StartCoroutine(InflictRage(((PassiveItem)this).Owner));
			}
		}
	}

	private IEnumerator InflictRage(PlayerController player)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CInflictRage_003Ed__8(0)
		{
			_003C_003E4__this = this,
			player = player
		};
	}

	private IEnumerator RemoveRage(PlayerController player)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CRemoveRage_003Ed__10(0)
		{
			_003C_003E4__this = this,
			player = player
		};
	}

	private void AddStat(StatType statType, float amount, ModifyMethod method = 0)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected O, but got Unknown
		StatModifier val = new StatModifier
		{
			amount = amount,
			statToBoost = statType,
			modifyType = method
		};
		if (base.passiveStatModifiers == null)
		{
			base.passiveStatModifiers = (StatModifier[])(object)new StatModifier[1] { val };
		}
		else
		{
			base.passiveStatModifiers = base.passiveStatModifiers.Concat((IEnumerable<StatModifier>)(object)new StatModifier[1] { val }).ToArray();
		}
	}

	private void RemoveStat(StatType statType)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		List<StatModifier> list = new List<StatModifier>();
		for (int i = 0; i < base.passiveStatModifiers.Length; i++)
		{
			if (base.passiveStatModifiers[i].statToBoost != statType)
			{
				list.Add(base.passiveStatModifiers[i]);
			}
		}
		base.passiveStatModifiers = list.ToArray();
	}
}
