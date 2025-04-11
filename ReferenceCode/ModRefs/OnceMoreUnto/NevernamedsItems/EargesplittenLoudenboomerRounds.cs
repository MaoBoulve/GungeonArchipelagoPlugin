using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using Dungeonator;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class EargesplittenLoudenboomerRounds : PassiveItem
{
	[CompilerGenerated]
	private sealed class _003CKnockbackDoer_003Ed__4 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Projectile proj;

		public float flot;

		public EargesplittenLoudenboomerRounds _003C_003E4__this;

		private List<AIActor> _003CactiveEnemies_003E5__1;

		private int _003Ci_003E5__2;

		private AIActor _003Caiactor_003E5__3;

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
		public _003CKnockbackDoer_003Ed__4(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003CactiveEnemies_003E5__1 = null;
			_003Caiactor_003E5__3 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Unknown result type (might be due to invalid IL or missing references)
			//IL_0069: Unknown result type (might be due to invalid IL or missing references)
			//IL_0085: Unknown result type (might be due to invalid IL or missing references)
			//IL_0112: Unknown result type (might be due to invalid IL or missing references)
			//IL_0122: Unknown result type (might be due to invalid IL or missing references)
			//IL_017d: Unknown result type (might be due to invalid IL or missing references)
			//IL_018d: Unknown result type (might be due to invalid IL or missing references)
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
				Exploder.DoRadialKnockback(Vector2.op_Implicit(((BraveBehaviour)proj).specRigidbody.UnitCenter), 20f * flot, 7f);
				if (Vector3Extensions.GetAbsoluteRoom(proj.LastPosition) != null)
				{
					_003CactiveEnemies_003E5__1 = Vector3Extensions.GetAbsoluteRoom(proj.LastPosition).GetActiveEnemies((ActiveEnemyType)0);
					if (_003CactiveEnemies_003E5__1 != null && _003CactiveEnemies_003E5__1.Count > 0)
					{
						_003Ci_003E5__2 = 0;
						while (_003Ci_003E5__2 < _003CactiveEnemies_003E5__1.Count)
						{
							_003Caiactor_003E5__3 = _003CactiveEnemies_003E5__1[_003Ci_003E5__2];
							if (_003Caiactor_003E5__3.IsNormalEnemy && Object.op_Implicit((Object)(object)((BraveBehaviour)_003Caiactor_003E5__3).behaviorSpeculator))
							{
								if (Vector2.Distance(((BraveBehaviour)proj).specRigidbody.UnitCenter, ((BraveBehaviour)_003Caiactor_003E5__3).sprite.WorldCenter) < 3f)
								{
									if (Random.value <= 0.25f * flot)
									{
										((BraveBehaviour)_003Caiactor_003E5__3).behaviorSpeculator.Stun(1f, true);
									}
								}
								else if (Vector2.Distance(((BraveBehaviour)proj).specRigidbody.UnitCenter, ((BraveBehaviour)_003Caiactor_003E5__3).sprite.WorldCenter) < 6f && Random.value <= 0.07f * flot)
								{
									((BraveBehaviour)_003Caiactor_003E5__3).behaviorSpeculator.Stun(1f, true);
								}
							}
							_003Caiactor_003E5__3 = null;
							_003Ci_003E5__2++;
						}
					}
					_003CactiveEnemies_003E5__1 = null;
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

	public static int EargesplittenLoudenboomerRoundsID;

	public static void Init()
	{
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<EargesplittenLoudenboomerRounds>("Eargesplitten Loudenboomers", "Big Cat", "These whimsical rounds were designed to pack a big punch.\n\nTheir sonic boom is capable of pushing foes away and stunning them.", "loudenboomer_icon", assetbundle: true);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)5, 1.15f, (ModifyMethod)1);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)6, 1.25f, (ModifyMethod)1);
		val.quality = (ItemQuality)3;
		AlexandriaTags.SetTag(val, "bullet_modifier");
		EargesplittenLoudenboomerRoundsID = val.PickupObjectId;
		val.SetupUnlockOnCustomFlag(CustomDungeonFlags.PURCHASED_LOUDENBOOMER, requiredFlagValue: true);
		val.AddItemToTrorcMetaShop(50, null);
		Doug.AddToLootPool(val.PickupObjectId);
	}

	private void PostProcessProj(Projectile proj, float flot)
	{
		((MonoBehaviour)this).StartCoroutine(KnockbackDoer(proj, flot));
	}

	private void PostProcessBeam(BeamController beam)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		if (!Object.op_Implicit((Object)(object)beam) || !Object.op_Implicit((Object)(object)((BraveBehaviour)beam).projectile))
		{
			return;
		}
		Exploder.DoRadialKnockback(Vector2.op_Implicit(beam.Origin), 40f, 7f);
		if (!Object.op_Implicit((Object)(object)((BraveBehaviour)beam).projectile) || Vector3Extensions.GetAbsoluteRoom(((BraveBehaviour)((BraveBehaviour)beam).projectile).transform.position) == null)
		{
			return;
		}
		List<AIActor> activeEnemies = Vector3Extensions.GetAbsoluteRoom(((BraveBehaviour)((BraveBehaviour)beam).projectile).transform.position).GetActiveEnemies((ActiveEnemyType)0);
		if (activeEnemies == null || activeEnemies.Count <= 0)
		{
			return;
		}
		for (int i = 0; i < activeEnemies.Count; i++)
		{
			AIActor val = activeEnemies[i];
			if (!val.IsNormalEnemy || !Object.op_Implicit((Object)(object)((BraveBehaviour)val).behaviorSpeculator))
			{
				continue;
			}
			if (Vector2.Distance(beam.Origin, ((BraveBehaviour)val).sprite.WorldCenter) < 3f)
			{
				if (Random.value <= 0.5f)
				{
					((BraveBehaviour)val).behaviorSpeculator.Stun(1f, true);
				}
			}
			else if (Vector2.Distance(beam.Origin, ((BraveBehaviour)val).sprite.WorldCenter) < 6f && Random.value <= 0.14f)
			{
				((BraveBehaviour)val).behaviorSpeculator.Stun(1f, true);
			}
		}
	}

	private IEnumerator KnockbackDoer(Projectile proj, float flot)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CKnockbackDoer_003Ed__4(0)
		{
			_003C_003E4__this = this,
			proj = proj,
			flot = flot
		};
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		player.PostProcessProjectile += PostProcessProj;
		player.PostProcessBeamChanceTick += PostProcessBeam;
	}

	public override DebrisObject Drop(PlayerController player)
	{
		player.PostProcessBeamChanceTick -= PostProcessBeam;
		player.PostProcessProjectile -= PostProcessProj;
		return ((PassiveItem)this).Drop(player);
	}

	public override void OnDestroy()
	{
		if ((Object)(object)((PassiveItem)this).Owner != (Object)null)
		{
			((PassiveItem)this).Owner.PostProcessProjectile -= PostProcessProj;
			((PassiveItem)this).Owner.PostProcessBeamChanceTick += PostProcessBeam;
		}
		((PassiveItem)this).OnDestroy();
	}
}
