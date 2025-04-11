using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Dungeonator;
using Pathfinding;
using UnityEngine;

namespace NevernamedsItems;

public class UnsTableTech : TableFlipItem
{
	[CompilerGenerated]
	private sealed class _003CHandleShield_003Ed__5 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerController user;

		public float duration;

		public UnsTableTech _003C_003E4__this;

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
		public _003CHandleShield_003Ed__5(int _003C_003E1__state)
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
			//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00aa: Expected O, but got Unknown
			//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b4: Expected O, but got Unknown
			//IL_0198: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a2: Expected O, but got Unknown
			//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ac: Expected O, but got Unknown
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
			{
				_003C_003E1__state = -1;
				_003C_003E4__this.m_activeDuration = duration;
				_003C_003E4__this.m_usedOverrideMaterial = ((BraveBehaviour)user).sprite.usesOverrideMaterial;
				((BraveBehaviour)user).sprite.usesOverrideMaterial = true;
				user.SetOverrideShader(ShaderCache.Acquire("Brave/ItemSpecific/MetalSkinShader"));
				_003CspecRigidbody_003E5__1 = ((BraveBehaviour)user).specRigidbody;
				SpeculativeRigidbody obj = _003CspecRigidbody_003E5__1;
				obj.OnPreRigidbodyCollision = (OnPreRigidbodyCollisionDelegate)Delegate.Combine((Delegate)(object)obj.OnPreRigidbodyCollision, (Delegate)new OnPreRigidbodyCollisionDelegate(_003C_003E4__this.MetalSkinReflecter));
				((BraveBehaviour)user).healthHaver.IsVulnerable = false;
				_003Celapsed_003E5__2 = 0f;
				break;
			}
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
				SpeculativeRigidbody obj2 = _003CspecRigidbody2_003E5__3;
				obj2.OnPreRigidbodyCollision = (OnPreRigidbodyCollisionDelegate)Delegate.Remove((Delegate)(object)obj2.OnPreRigidbodyCollision, (Delegate)new OnPreRigidbodyCollisionDelegate(_003C_003E4__this.MetalSkinReflecter));
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

	[CompilerGenerated]
	private sealed class _003CHandleSlowBullets_003Ed__9 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UnsTableTech _003C_003E4__this;

		private float _003CslowMultiplier_003E5__1;

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
		public _003CHandleSlowBullets_003Ed__9(int _003C_003E1__state)
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
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0039: Expected O, but got Unknown
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
				_003CslowMultiplier_003E5__1 = ((Component)PickupObjectDatabase.GetById(270)).GetComponent<IounStoneOrbitalItem>().SlowBulletsMultiplier;
				Projectile.BaseEnemyBulletSpeedMultiplier *= _003CslowMultiplier_003E5__1;
				_003C_003E4__this.m_slowDurationRemaining = ((Component)PickupObjectDatabase.GetById(270)).GetComponent<IounStoneOrbitalItem>().SlowBulletsDuration;
				break;
			case 2:
				_003C_003E1__state = -1;
				_003C_003E4__this.m_slowDurationRemaining -= BraveTime.DeltaTime;
				Projectile.BaseEnemyBulletSpeedMultiplier /= _003CslowMultiplier_003E5__1;
				_003CslowMultiplier_003E5__1 = Mathf.Lerp(((Component)PickupObjectDatabase.GetById(270)).GetComponent<IounStoneOrbitalItem>().SlowBulletsMultiplier, 1f, 1f - _003C_003E4__this.m_slowDurationRemaining);
				Projectile.BaseEnemyBulletSpeedMultiplier *= _003CslowMultiplier_003E5__1;
				break;
			}
			if (_003C_003E4__this.m_slowDurationRemaining > 0f)
			{
				_003C_003E2__current = null;
				_003C_003E1__state = 2;
				return true;
			}
			Projectile.BaseEnemyBulletSpeedMultiplier /= _003CslowMultiplier_003E5__1;
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

	private float m_activeDuration;

	private bool m_usedOverrideMaterial;

	private float m_slowDurationRemaining;

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<UnsTableTech>("Uns-Table Tech", "Flip Chaos", "Triggers a random effect upon the flipping of a table.\n\n\"He who flips without reason may outwit not only his foes, but himself\" - Addendum 8 of the Tabla Sutra.", "unstabletech_icon", assetbundle: true);
		TableFlipItem val = (TableFlipItem)(object)((obj is TableFlipItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)2;
		AlexandriaTags.SetTag((PickupObject)(object)val, "table_tech");
	}

	public override void Pickup(PlayerController player)
	{
		((TableFlipItem)this).Pickup(player);
		player.OnTableFlipped = (Action<FlippableCover>)Delegate.Combine(player.OnTableFlipped, new Action<FlippableCover>(OnTableFlipped));
	}

	public override DebrisObject Drop(PlayerController player)
	{
		DebrisObject result = ((TableFlipItem)this).Drop(player);
		player.OnTableFlipped = (Action<FlippableCover>)Delegate.Remove(player.OnTableFlipped, new Action<FlippableCover>(OnTableFlipped));
		return result;
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			PlayerController owner = ((PassiveItem)this).Owner;
			owner.OnTableFlipped = (Action<FlippableCover>)Delegate.Remove(owner.OnTableFlipped, new Action<FlippableCover>(OnTableFlipped));
		}
		((TableFlipItem)this).OnDestroy();
	}

	private void OnTableFlipped(FlippableCover obj)
	{
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_028b: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03de: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0302: Unknown result type (might be due to invalid IL or missing references)
		//IL_0308: Unknown result type (might be due to invalid IL or missing references)
		//IL_036e: Unknown result type (might be due to invalid IL or missing references)
		if (!Object.op_Implicit((Object)(object)((PassiveItem)this).Owner) || !Object.op_Implicit((Object)(object)obj))
		{
			return;
		}
		int num = Random.Range(1, 28);
		ETGModConsole.Log((object)("Selected Effect: " + num), false);
		switch (num)
		{
		case 1:
			SpawnFoldingTable();
			break;
		case 2:
			DoSafeExplosion(((BraveBehaviour)obj).specRigidbody.UnitCenter);
			break;
		case 3:
			DoGoop(((BraveBehaviour)obj).specRigidbody.UnitCenter, EasyGoopDefinitions.FireDef);
			break;
		case 4:
			DoGoop(((BraveBehaviour)obj).specRigidbody.UnitCenter, EasyGoopDefinitions.PoisonDef);
			break;
		case 5:
			DoGoop(((BraveBehaviour)obj).specRigidbody.UnitCenter, EasyGoopDefinitions.CharmGoopDef);
			break;
		case 6:
			DoGoop(((BraveBehaviour)obj).specRigidbody.UnitCenter, EasyGoopDefinitions.CheeseDef);
			break;
		case 7:
			LootEngine.SpawnCurrency(((BraveBehaviour)obj).specRigidbody.UnitCenter, Random.Range(5, 10), false);
			break;
		case 8:
			PlayerUtility.DoEasyBlank(((PassiveItem)this).Owner, ((BraveBehaviour)obj).specRigidbody.UnitCenter, (EasyBlankType)0);
			break;
		case 9:
			PlayerUtility.DoEasyBlank(((PassiveItem)this).Owner, ((BraveBehaviour)obj).specRigidbody.UnitCenter, (EasyBlankType)1);
			break;
		case 10:
			FullRoomStatusEffect((GameActorEffect)(object)StaticStatusEffects.charmingRoundsEffect);
			break;
		case 11:
			FullRoomStatusEffect((GameActorEffect)(object)((Component)PickupObjectDatabase.GetById(569)).GetComponent<ChaosBulletsItem>().FreezeModifierEffect);
			break;
		case 12:
			FullRoomStatusEffect((GameActorEffect)(object)StaticStatusEffects.tripleCrossbowSlowEffect);
			break;
		case 13:
			Exploder.DoRadialKnockback(Vector2.op_Implicit(((BraveBehaviour)obj).specRigidbody.UnitCenter), 200f, 100f);
			break;
		case 14:
			SpawnBlackHole(((BraveBehaviour)obj).specRigidbody.UnitCenter);
			break;
		case 15:
			if ((Object)(object)((GameActor)((PassiveItem)this).Owner).CurrentGun != (Object)null)
			{
				((GameActor)((PassiveItem)this).Owner).CurrentGun.GainAmmo(Random.Range(5, 26));
			}
			break;
		case 16:
			FreezeTime();
			break;
		case 17:
			TurnTableIntoRocket(obj);
			break;
		case 18:
			StunEnemies();
			break;
		case 19:
			LootEngine.SpawnCurrency(((BraveBehaviour)obj).specRigidbody.UnitCenter, Random.Range(2, 6), true);
			break;
		case 20:
			CompanionisedEnemyUtility.SpawnCompanionisedEnemy(((PassiveItem)this).Owner, "01972dee89fc4404a5c408d50007dad5", Vector2Extensions.ToIntVector2(((BraveBehaviour)((PassiveItem)this).Owner).sprite.WorldCenter, (VectorConversions)2), doTint: false, Color.red, 7, 2, shouldBeJammed: false, doFriendlyOverhead: true);
			break;
		case 21:
		{
			int num3 = Random.Range(2, 6);
			for (int j = 0; j < num3; j++)
			{
				CompanionisedEnemyUtility.SpawnCompanionisedEnemy(((PassiveItem)this).Owner, "2feb50a6a40f4f50982e89fd276f6f15", Vector2Extensions.ToIntVector2(((BraveBehaviour)((PassiveItem)this).Owner).sprite.WorldCenter, (VectorConversions)2), doTint: false, Color.red, 15, 2, shouldBeJammed: false, doFriendlyOverhead: false);
			}
			break;
		}
		case 22:
			FullRoomStatusEffect((GameActorEffect)(object)StaticStatusEffects.hotLeadEffect);
			break;
		case 23:
		{
			float num2 = 0f;
			for (int i = 0; i < 15; i++)
			{
				PickupObject byId2 = PickupObjectDatabase.GetById(50);
				SpawnBullets(((Gun)((byId2 is Gun) ? byId2 : null)).DefaultModule.projectiles[0], ((BraveBehaviour)obj).specRigidbody.UnitCenter, num2);
				num2 += 24f;
			}
			break;
		}
		case 24:
		{
			PickupObject byId = PickupObjectDatabase.GetById(372);
			SpawnBullets(((Gun)((byId is Gun) ? byId : null)).DefaultModule.projectiles[0], ((BraveBehaviour)((PassiveItem)this).Owner).sprite.WorldCenter, Vector2Extensions.ToAngle(MathsAndLogicHelper.GetVectorToNearestEnemy(((BraveBehaviour)((PassiveItem)this).Owner).sprite.WorldCenter, true, (ActiveEnemyType)1, (List<AIActor>)null, (Func<AIActor, bool>)null)));
			break;
		}
		case 25:
			((MonoBehaviour)this).StartCoroutine(HandleShield(((PassiveItem)this).Owner, 7f));
			break;
		case 26:
			((MonoBehaviour)((PassiveItem)this).Owner).StartCoroutine(HandleSlowBullets());
			break;
		case 27:
			PlayerUtility.GetExtComp(((PassiveItem)this).Owner).Enrage(4f, false);
			break;
		}
	}

	private IEnumerator HandleShield(PlayerController user, float duration)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CHandleShield_003Ed__5(0)
		{
			_003C_003E4__this = this,
			user = user,
			duration = duration
		};
	}

	private void MetalSkinReflecter(SpeculativeRigidbody myRigidbody, PixelCollider myCollider, SpeculativeRigidbody otherRigidbody, PixelCollider otherCollider)
	{
		Projectile component = ((Component)otherRigidbody).GetComponent<Projectile>();
		if ((Object)(object)component != (Object)null && !(component.Owner is PlayerController))
		{
			PassiveReflectItem.ReflectBullet(component, true, ((BraveBehaviour)((BraveBehaviour)((PassiveItem)this).Owner).specRigidbody).gameActor, 10f, 1f, 1f, 0f);
			PhysicsEngine.SkipCollision = true;
		}
	}

	private IEnumerator HandleSlowBullets()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CHandleSlowBullets_003Ed__9(0)
		{
			_003C_003E4__this = this
		};
	}

	private void StunEnemies()
	{
		List<AIActor> activeEnemies = ((PassiveItem)this).Owner.CurrentRoom.GetActiveEnemies((ActiveEnemyType)0);
		if (activeEnemies == null)
		{
			return;
		}
		for (int i = 0; i < activeEnemies.Count; i++)
		{
			if (!((BraveBehaviour)activeEnemies[i]).healthHaver.IsBoss && Object.op_Implicit((Object)(object)activeEnemies[i]) && Object.op_Implicit((Object)(object)((BraveBehaviour)activeEnemies[i]).behaviorSpeculator))
			{
				activeEnemies[i].ClearPath();
				((BraveBehaviour)activeEnemies[i]).behaviorSpeculator.Interrupt();
				((BraveBehaviour)activeEnemies[i]).behaviorSpeculator.Stun(base.StunDuration, true);
			}
		}
	}

	private void FreezeTime()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		RadialSlowInterface val = new RadialSlowInterface();
		val.DoesSepia = false;
		val.RadialSlowHoldTime = 5f;
		val.RadialSlowTimeModifier = 0.01f;
		val.UpdatesForNewEnemies = false;
		val.DoRadialSlow(((BraveBehaviour)((PassiveItem)this).Owner).specRigidbody.UnitCenter, ((PassiveItem)this).Owner.CurrentRoom);
	}

	private void SpawnBullets(Projectile bullet, Vector2 pos, float rot)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = SpawnManager.SpawnProjectile(((Component)bullet).gameObject, Vector2.op_Implicit(pos), Quaternion.Euler(0f, 0f, rot), true);
		Projectile component = val.GetComponent<Projectile>();
		if ((Object)(object)component != (Object)null)
		{
			PierceProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<PierceProjModifier>(((Component)component).gameObject);
			orAddComponent.penetration++;
			orAddComponent.penetratesBreakables = true;
			component.Owner = (GameActor)(object)((PassiveItem)this).Owner;
			component.Shooter = ((BraveBehaviour)((PassiveItem)this).Owner).specRigidbody;
		}
	}

	private void SpawnBlackHole(Vector2 pos)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		Projectile val = ((Gun)Databases.Items["black_hole_gun"]).DefaultModule.projectiles[0];
		GameObject val2 = SpawnManager.SpawnProjectile(((Component)val).gameObject, Vector2.op_Implicit(pos), Quaternion.identity, true);
		Projectile component = val2.GetComponent<Projectile>();
		if ((Object)(object)component != (Object)null)
		{
			component.Owner = (GameActor)(object)((PassiveItem)this).Owner;
			component.Shooter = ((BraveBehaviour)((PassiveItem)this).Owner).specRigidbody;
			component.baseData.speed = 0f;
		}
	}

	private void FullRoomStatusEffect(GameActorEffect effect)
	{
		List<AIActor> activeEnemies = ((PassiveItem)this).Owner.CurrentRoom.GetActiveEnemies((ActiveEnemyType)0);
		if (activeEnemies == null)
		{
			return;
		}
		for (int i = 0; i < activeEnemies.Count; i++)
		{
			AIActor val = activeEnemies[i];
			if (val.IsNormalEnemy)
			{
				((BraveBehaviour)val).gameActor.ApplyEffect(effect, 1f, (Projectile)null);
			}
		}
	}

	private void DoGoop(Vector2 pos, GoopDefinition def)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		DeadlyDeadlyGoopManager goopManagerForGoopType = DeadlyDeadlyGoopManager.GetGoopManagerForGoopType(def);
		goopManagerForGoopType.TimedAddGoopCircle(pos, 7f, 0.75f, true);
	}

	private void DoSafeExplosion(Vector2 position)
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		ExplosionData val = GameManager.Instance.Dungeon.sharedSettingsPrefab.DefaultExplosionData.CopyExplosionData();
		val.ignoreList.Add(((BraveBehaviour)((PassiveItem)this).Owner).specRigidbody);
		Exploder.Explode(Vector2.op_Implicit(position), val, Vector2.zero, (Action)null, false, (CoreDamageTypes)0, false);
	}

	private void SpawnFoldingTable()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		Vector2 centerPosition = ((GameActor)((PassiveItem)this).Owner).CenterPosition;
		Vector2 val = Vector3Extensions.XY(((PassiveItem)this).Owner.unadjustedAimPoint) - ((GameActor)((PassiveItem)this).Owner).CenterPosition;
		Vector2 val2 = centerPosition + ((Vector2)(ref val)).normalized;
		IntVector2? nearestAvailableCell = ((PassiveItem)this).Owner.CurrentRoom.GetNearestAvailableCell(val2, (IntVector2?)IntVector2.One, (CellTypes?)(CellTypes)2, false, (CellValidator)null);
		FoldingTableItem component = ((Component)PickupObjectDatabase.GetById(644)).GetComponent<FoldingTableItem>();
		GameObject gameObject = ((Component)component.TableToSpawn).gameObject;
		GameObject gameObject2 = gameObject.gameObject;
		IntVector2 value = nearestAvailableCell.Value;
		GameObject val3 = Object.Instantiate<GameObject>(gameObject2, Vector2.op_Implicit(((IntVector2)(ref value)).ToVector2()), Quaternion.identity);
		SpeculativeRigidbody componentInChildren = val3.GetComponentInChildren<SpeculativeRigidbody>();
		FlippableCover component2 = val3.GetComponent<FlippableCover>();
		Vector3Extensions.GetAbsoluteRoom(Vector3Extensions.XY(((BraveBehaviour)component2).transform.position)).RegisterInteractable((IPlayerInteractable)(object)component2);
		component2.ConfigureOnPlacement(Vector3Extensions.GetAbsoluteRoom(Vector3Extensions.XY(((BraveBehaviour)component2).transform.position)));
		componentInChildren.Initialize();
		PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(componentInChildren, (int?)null, false);
	}

	private void TurnTableIntoRocket(FlippableCover table)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Expected O, but got Unknown
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected I4, but got Unknown
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_020d: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = (GameObject)ResourceCache.Acquire("Global VFX/VFX_Table_Exhaust");
		IntVector2 intVector2FromDirection = DungeonData.GetIntVector2FromDirection(table.DirectionFlipped);
		Vector2 val2 = ((IntVector2)(ref intVector2FromDirection)).ToVector2();
		float num = BraveMathCollege.Atan2Degrees(val2);
		Vector3 zero = Vector3.zero;
		Direction directionFlipped = table.DirectionFlipped;
		Direction val3 = directionFlipped;
		switch ((int)val3)
		{
		case 0:
			zero = Vector3.zero;
			break;
		case 2:
			((Vector3)(ref zero))._002Ector(-0.5f, 0.25f, 0f);
			break;
		case 4:
			((Vector3)(ref zero))._002Ector(0f, 0.5f, 1f);
			break;
		case 6:
			((Vector3)(ref zero))._002Ector(0.5f, 0.25f, 0f);
			break;
		}
		GameObject val4 = Object.Instantiate<GameObject>(val, Vector2Extensions.ToVector3ZisY(((BraveBehaviour)table).specRigidbody.UnitCenter, 0f) + zero, Quaternion.Euler(0f, 0f, num));
		val4.transform.parent = ((BraveBehaviour)((BraveBehaviour)table).specRigidbody).transform;
		Projectile val5 = ((Component)((BraveBehaviour)table).specRigidbody).gameObject.AddComponent<Projectile>();
		val5.Shooter = ((BraveBehaviour)((PassiveItem)this).Owner).specRigidbody;
		val5.Owner = (GameActor)(object)((PassiveItem)this).Owner;
		val5.baseData.damage = ((Component)PickupObjectDatabase.GetById(398)).GetComponent<TableFlipItem>().DirectHitBonusDamage;
		val5.baseData.range = 1000f;
		val5.baseData.speed = 20f;
		val5.baseData.force = 50f;
		val5.baseData.UsesCustomAccelerationCurve = true;
		val5.baseData.AccelerationCurve = ((Component)PickupObjectDatabase.GetById(398)).GetComponent<TableFlipItem>().CustomAccelerationCurve;
		val5.baseData.CustomAccelerationCurveDuration = ((Component)PickupObjectDatabase.GetById(398)).GetComponent<TableFlipItem>().CustomAccelerationCurveDuration;
		val5.shouldRotate = false;
		val5.Start();
		val5.SendInDirection(val2, true, true);
		val5.collidesWithProjectiles = true;
		val5.projectileHitHealth = 20;
		Action<Projectile> action = delegate
		{
			if (Object.op_Implicit((Object)(object)table) && Object.op_Implicit((Object)(object)table.shadowSprite))
			{
				((BraveBehaviour)table.shadowSprite).renderer.enabled = false;
			}
		};
		val5.OnDestruction += action;
		ExplosiveModifier val6 = ((Component)val5).gameObject.AddComponent<ExplosiveModifier>();
		val6.explosionData = ((Component)PickupObjectDatabase.GetById(398)).GetComponent<TableFlipItem>().ProjectileExplosionData;
		table.PreventPitFalls = true;
	}
}
