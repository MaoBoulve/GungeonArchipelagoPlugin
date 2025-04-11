using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.EnemyAPI;
using UnityEngine;

namespace NevernamedsItems;

public class LaserWelderComp : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CResetInvul_003Ed__4 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MajorBreakable breakable;

		public LaserWelderComp _003C_003E4__this;

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
		public _003CResetInvul_003Ed__4(int _003C_003E1__state)
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
				_003C_003E2__current = (object)new WaitForSeconds(0.1f);
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				breakable.TemporarilyInvulnerable = false;
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

	private Projectile self;

	public static Dictionary<string, string> RepairableEnemies;

	public LaserWelderComp()
	{
		RepairableEnemies = new Dictionary<string, string>
		{
			{ "e5cffcfabfae489da61062ea20539887", "01972dee89fc4404a5c408d50007dad5" },
			{ "d4a9836f8ab14f3fadd0f597438b1f1f", "01972dee89fc4404a5c408d50007dad5" },
			{ "844657ad68894a4facb1b8e1aef1abf9", "01972dee89fc4404a5c408d50007dad5" },
			{ "7f665bd7151347e298e4d366f8818284", "128db2f0781141bcb505d8f00f9e4d47" },
			{ "1a78cfb776f54641b832e92c44021cf2", "01972dee89fc4404a5c408d50007dad5" },
			{ "1bd8e49f93614e76b140077ff2e33f2b", "b54d89f9e802455cbb2b8a96a31e8259" }
		};
	}

	private void Start()
	{
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected O, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		self = ((Component)this).GetComponent<Projectile>();
		Projectile obj = self;
		obj.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(obj.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(OnHitEnemy));
		if (Object.op_Implicit((Object)(object)((BraveBehaviour)self).specRigidbody))
		{
			SpeculativeRigidbody specRigidbody = ((BraveBehaviour)self).specRigidbody;
			specRigidbody.OnPreRigidbodyCollision = (OnPreRigidbodyCollisionDelegate)Delegate.Combine((Delegate)(object)specRigidbody.OnPreRigidbodyCollision, (Delegate)new OnPreRigidbodyCollisionDelegate(HandlePreCollision));
		}
	}

	private void HandlePreCollision(SpeculativeRigidbody myRigidbody, PixelCollider myPixelCollider, SpeculativeRigidbody otherRigidbody, PixelCollider otherPixelCollider)
	{
		try
		{
			if (!Object.op_Implicit((Object)(object)otherRigidbody))
			{
				return;
			}
			MajorBreakable[] componentsInChildren = ((Component)otherRigidbody).GetComponentsInChildren<MajorBreakable>();
			foreach (MajorBreakable val in componentsInChildren)
			{
				val.TemporarilyInvulnerable = true;
				if (val.HitPoints < val.MaxHitPoints)
				{
					float num = val.MaxHitPoints - val.HitPoints;
					val.HitPoints += num * 0.2f;
					if (Object.op_Implicit((Object)(object)((Component)val).GetComponent<Chest>()))
					{
						((Component)val).GetComponent<Chest>().ForceKillFuse();
						int cachedSpriteForCoop = ((Component)val).GetComponent<Chest>().m_cachedSpriteForCoop;
						val.m_inZeroHPState = false;
						((BraveBehaviour)val).sprite.SetSprite(cachedSpriteForCoop);
					}
				}
				((MonoBehaviour)val).StartCoroutine(ResetInvul(val));
			}
		}
		catch (Exception ex)
		{
			ETGModConsole.Log((object)ex.Message, false);
			ETGModConsole.Log((object)ex.StackTrace, false);
		}
	}

	private IEnumerator ResetInvul(MajorBreakable breakable)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CResetInvul_003Ed__4(0)
		{
			_003C_003E4__this = this,
			breakable = breakable
		};
	}

	private void OnHitEnemy(Projectile self, SpeculativeRigidbody enemy, bool fatal)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		if (!Object.op_Implicit((Object)(object)enemy) || !Object.op_Implicit((Object)(object)((BraveBehaviour)enemy).aiActor) || !Object.op_Implicit((Object)(object)((BraveBehaviour)enemy).healthHaver))
		{
			return;
		}
		if (fatal)
		{
			Vector2 worldCenter = ((BraveBehaviour)enemy).sprite.WorldCenter;
			Exploder.Explode(Vector2.op_Implicit(worldCenter), LaserWelder.LaserWelderExplosion, Vector2.zero, (Action)null, false, (CoreDamageTypes)0, false);
			Object.Instantiate<GameObject>(SharedVFX.TeleporterPrototypeTelefragVFX, Vector2.op_Implicit(enemy.UnitCenter), Quaternion.identity);
			if (!((BraveBehaviour)enemy).healthHaver.IsBoss)
			{
				((BraveBehaviour)enemy).aiActor.EraseFromExistenceWithRewards(false);
			}
		}
		else if (RepairableEnemies.ContainsKey(((BraveBehaviour)enemy).aiActor.EnemyGuid))
		{
			AIActorUtility.AdvancedTransmogrify(((BraveBehaviour)enemy).aiActor, EnemyDatabase.GetOrLoadByGuid(RepairableEnemies[((BraveBehaviour)enemy).aiActor.EnemyGuid]), (GameObject)null, (string)null, false, (List<string>)null, (List<string>)null, true, true, true, true, true, false);
		}
	}
}
