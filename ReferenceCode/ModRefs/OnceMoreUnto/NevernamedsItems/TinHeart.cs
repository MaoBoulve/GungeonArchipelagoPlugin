using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class TinHeart : PassiveItem
{
	[CompilerGenerated]
	private sealed class _003CHandleShield_003Ed__12 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerController user;

		public float duration;

		public TinHeart _003C_003E4__this;

		private SpeculativeRigidbody _003CspecRigidbody_003E5__1;

		private float _003Celapsed_003E5__2;

		private SpeculativeRigidbody _003CspecRigidbody2_003E5__3;

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
		public _003CHandleShield_003Ed__12(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003CspecRigidbody_003E5__1 = null;
			_003CspecRigidbody2_003E5__3 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00af: Expected O, but got Unknown
			//IL_00af: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b9: Expected O, but got Unknown
			//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ac: Expected O, but got Unknown
			//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b6: Expected O, but got Unknown
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E4__this.m_activeDuration = duration;
				_003C_003E4__this.m_usedOverrideMaterial = ((BraveBehaviour)user).sprite.usesOverrideMaterial;
				((BraveBehaviour)user).sprite.usesOverrideMaterial = true;
				user.SetOverrideShader(ShaderCache.Acquire("Brave/ItemSpecific/MetalSkinShader"));
				_003CspecRigidbody_003E5__1 = ((BraveBehaviour)user).specRigidbody;
				_003CspecRigidbody_003E5__1.OnPreRigidbodyCollision = (OnPreRigidbodyCollisionDelegate)Delegate.Combine((Delegate)(object)_003CspecRigidbody_003E5__1.OnPreRigidbodyCollision, (Delegate)new OnPreRigidbodyCollisionDelegate(_003C_003E4__this.OnPreCollision));
				((BraveBehaviour)user).healthHaver.IsVulnerable = false;
				_003Celapsed_003E5__2 = 0f;
				break;
			case 1:
				_003C_003E1__state = -1;
				break;
			}
			if (_003Celapsed_003E5__2 < duration)
			{
				_003Celapsed_003E5__2 += BraveTime.DeltaTime;
				((BraveBehaviour)user).healthHaver.IsVulnerable = false;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			if (Object.op_Implicit((Object)(object)user))
			{
				((BraveBehaviour)user).healthHaver.IsVulnerable = true;
				user.ClearOverrideShader();
				((BraveBehaviour)user).sprite.usesOverrideMaterial = _003C_003E4__this.m_usedOverrideMaterial;
				_003CspecRigidbody2_003E5__3 = ((BraveBehaviour)user).specRigidbody;
				_003CspecRigidbody2_003E5__3.OnPreRigidbodyCollision = (OnPreRigidbodyCollisionDelegate)Delegate.Remove((Delegate)(object)_003CspecRigidbody2_003E5__3.OnPreRigidbodyCollision, (Delegate)new OnPreRigidbodyCollisionDelegate(_003C_003E4__this.OnPreCollision));
				_003CspecRigidbody2_003E5__3 = null;
			}
			if (Object.op_Implicit((Object)(object)_003C_003E4__this))
			{
				AkSoundEngine.PostEvent("Play_OBJ_metalskin_end_01", ((Component)_003C_003E4__this).gameObject);
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

	public static int TinHeartID;

	private bool hadOilCanWhatLastWeChecked;

	private float m_activeDuration = 1f;

	private bool m_usedOverrideMaterial;

	public static void Init()
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<TinHeart>("Tin Heart", "If I Only Had A Heart", "The empty heart of a loving gungeoneer who was tragically turned to tin by Meduzi, the jealous gunwitch.\n\nWhen you are truly empty inside, it sacrifices the only things you have left to keep you alive.", "tinheart_improved", assetbundle: true);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)3, 1f, (ModifyMethod)0);
		val.CanBeDropped = true;
		val.quality = (ItemQuality)3;
		TinHeartID = val.PickupObjectId;
	}

	private void ModifyDamage(HealthHaver player, ModifyDamageEventArgs args)
	{
		if (!(((BraveBehaviour)player).gameActor is PlayerController))
		{
			return;
		}
		GameActor gameActor = ((BraveBehaviour)player).gameActor;
		PlayerController val = (PlayerController)(object)((gameActor is PlayerController) ? gameActor : null);
		if (val.ForceZeroHealthState)
		{
			if (Random.value <= 0.25f)
			{
				args.ModifiedDamage = 0f;
				HandleRemoveHeart();
			}
		}
		else if (PlayerUtility.NextHitWillKillPlayer(val, args.InitialDamage))
		{
			if (player.GetCurrentHealth() > 0.5f)
			{
				args.ModifiedDamage = 0.5f;
			}
			else if (((player.GetCurrentHealth() == 0.5f && player.Armor == 0f) || (player.GetCurrentHealth() == 0f && player.Armor == 1f)) && player.GetMaxHealth() > 1f)
			{
				args.ModifiedDamage = 0f;
				HandleRemoveHeart();
			}
		}
		if (CustomSynergies.PlayerHasActiveSynergy(val, "Oil Can What?") && Random.value <= 0.1f)
		{
			args.ModifiedDamage = 0f;
		}
	}

	private void HandleRemoveHeart()
	{
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected O, but got Unknown
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		((PassiveItem)this).Owner.ForceBlank(25f, 0.5f, false, true, (Vector2?)null, true, -1f);
		((MonoBehaviour)this).StartCoroutine(HandleShield(((PassiveItem)this).Owner, 7f));
		if ((!CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Woodcutter") || ((PickupObject)((GameActor)((PassiveItem)this).Owner).CurrentGun).PickupObjectId != 346 || !((GameActor)((PassiveItem)this).Owner).CurrentGun.IsReloading) && !((PassiveItem)this).Owner.ForceZeroHealthState)
		{
			StatModifier val = new StatModifier();
			val.statToBoost = (StatType)3;
			val.amount = -1f;
			val.modifyType = (ModifyMethod)0;
			((PassiveItem)this).Owner.ownerlessStatModifiers.Add(val);
			((PassiveItem)this).Owner.stats.RecalculateStats(((PassiveItem)this).Owner, false, false);
		}
	}

	private void OnPreDeath(Vector2 dir)
	{
		if (((BraveBehaviour)((PassiveItem)this).Owner).healthHaver.GetMaxHealth() > 1f)
		{
			((BraveBehaviour)((PassiveItem)this).Owner).healthHaver.ApplyHealing(0.5f);
			HandleRemoveHeart();
		}
	}

	public override void Pickup(PlayerController player)
	{
		if (!base.m_pickedUpThisRun)
		{
			if (player.ForceZeroHealthState)
			{
				for (int i = 0; i < 2; i++)
				{
					LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(120)).gameObject, player);
				}
			}
			else if (((BraveBehaviour)player).healthHaver.GetCurrentHealth() > 1f)
			{
				((BraveBehaviour)player).healthHaver.ApplyHealing(-1f);
			}
		}
		HealthHaver healthHaver = ((BraveBehaviour)player).healthHaver;
		healthHaver.ModifyDamage = (Action<HealthHaver, ModifyDamageEventArgs>)Delegate.Combine(healthHaver.ModifyDamage, new Action<HealthHaver, ModifyDamageEventArgs>(ModifyDamage));
		((BraveBehaviour)player).healthHaver.OnPreDeath += OnPreDeath;
		((PassiveItem)this).Pickup(player);
	}

	public override void Update()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Oil Can What?") && !hadOilCanWhatLastWeChecked)
			{
				RemoveStat((StatType)0);
				((PassiveItem)this).Owner.stats.RecalculateStats(((PassiveItem)this).Owner, true, false);
				AddStat((StatType)0, 1f, (ModifyMethod)0);
				((PassiveItem)this).Owner.stats.RecalculateStats(((PassiveItem)this).Owner, true, false);
				hadOilCanWhatLastWeChecked = CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Oil Can What?");
			}
			else if (!CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Oil Can What?") && hadOilCanWhatLastWeChecked)
			{
				RemoveStat((StatType)0);
				((PassiveItem)this).Owner.stats.RecalculateStats(((PassiveItem)this).Owner, true, false);
				hadOilCanWhatLastWeChecked = CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Oil Can What?");
			}
		}
		((PassiveItem)this).Update();
	}

	public override DebrisObject Drop(PlayerController player)
	{
		HealthHaver healthHaver = ((BraveBehaviour)player).healthHaver;
		healthHaver.ModifyDamage = (Action<HealthHaver, ModifyDamageEventArgs>)Delegate.Remove(healthHaver.ModifyDamage, new Action<HealthHaver, ModifyDamageEventArgs>(ModifyDamage));
		((BraveBehaviour)player).healthHaver.OnPreDeath -= OnPreDeath;
		return ((PassiveItem)this).Drop(player);
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			((BraveBehaviour)((PassiveItem)this).Owner).healthHaver.OnPreDeath -= OnPreDeath;
			HealthHaver healthHaver = ((BraveBehaviour)((PassiveItem)this).Owner).healthHaver;
			healthHaver.ModifyDamage = (Action<HealthHaver, ModifyDamageEventArgs>)Delegate.Remove(healthHaver.ModifyDamage, new Action<HealthHaver, ModifyDamageEventArgs>(ModifyDamage));
		}
		((PassiveItem)this).OnDestroy();
	}

	private IEnumerator HandleShield(PlayerController user, float duration)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CHandleShield_003Ed__12(0)
		{
			_003C_003E4__this = this,
			user = user,
			duration = duration
		};
	}

	private void OnPreCollision(SpeculativeRigidbody myRigidbody, PixelCollider myCollider, SpeculativeRigidbody otherRigidbody, PixelCollider otherCollider)
	{
		Projectile component = ((Component)otherRigidbody).GetComponent<Projectile>();
		if ((Object)(object)component != (Object)null && !(component.Owner is PlayerController))
		{
			PassiveReflectItem.ReflectBullet(component, true, ((BraveBehaviour)((BraveBehaviour)((PassiveItem)this).Owner).specRigidbody).gameActor, 10f, 1f, 1f, 0f);
			PhysicsEngine.SkipCollision = true;
		}
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
