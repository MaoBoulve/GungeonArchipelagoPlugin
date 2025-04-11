using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.EnemyAPI;
using Alexandria.ItemAPI;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class WitchsBrew : PassiveItem
{
	public class HasBeenDoubledByWitchsBrew : MonoBehaviour
	{
		private AIActor self;

		public AIActor linkedOther;

		public HasBeenDoubledByWitchsBrew()
		{
			linkedOther = null;
		}

		private void Start()
		{
			//IL_004a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Expected O, but got Unknown
			//IL_0054: Unknown result type (might be due to invalid IL or missing references)
			//IL_005e: Expected O, but got Unknown
			self = ((Component)this).GetComponent<AIActor>();
			if (Object.op_Implicit((Object)(object)self) && Object.op_Implicit((Object)(object)((BraveBehaviour)self).specRigidbody))
			{
				SpeculativeRigidbody specRigidbody = ((BraveBehaviour)self).specRigidbody;
				specRigidbody.OnPreRigidbodyCollision = (OnPreRigidbodyCollisionDelegate)Delegate.Combine((Delegate)(object)specRigidbody.OnPreRigidbodyCollision, (Delegate)new OnPreRigidbodyCollisionDelegate(OnPreCollide));
			}
		}

		private void OnPreCollide(SpeculativeRigidbody myRigidbody, PixelCollider myCollider, SpeculativeRigidbody otherRigidbody, PixelCollider otherCollider)
		{
			if ((((Object)(object)linkedOther != (Object)null) & ((Object)(object)((BraveBehaviour)linkedOther).specRigidbody != (Object)null)) && (Object)(object)otherRigidbody == (Object)(object)((BraveBehaviour)linkedOther).specRigidbody)
			{
				PhysicsEngine.SkipCollision = true;
			}
		}
	}

	[CompilerGenerated]
	private sealed class _003CShrimk_003Ed__3 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AIActor actor;

		public WitchsBrew _003C_003E4__this;

		private int _003CcachedLayer_003E5__1;

		private int _003CcachedOutlineLayer_003E5__2;

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
		public _003CShrimk_003Ed__3(int _003C_003E1__state)
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
			//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				break;
			case 1:
				_003C_003E1__state = -1;
				break;
			}
			if (!actor.HasBeenEngaged || !actor.HasBeenAwoken)
			{
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			_003CcachedLayer_003E5__1 = ((Component)actor).gameObject.layer;
			((Component)actor).gameObject.layer = LayerMask.NameToLayer("Unpixelated");
			_003CcachedOutlineLayer_003E5__2 = SpriteOutlineManager.ChangeOutlineLayer(((BraveBehaviour)actor).sprite, LayerMask.NameToLayer("Unpixelated"));
			actor.EnemyScale = TargetScale;
			((Component)actor).gameObject.layer = _003CcachedLayer_003E5__1;
			SpriteOutlineManager.ChangeOutlineLayer(((BraveBehaviour)actor).sprite, _003CcachedOutlineLayer_003E5__2);
			_003C_003E4__this.ModifyHP(((BraveBehaviour)actor).healthHaver);
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
	private sealed class _003CToilEnemyDupe_003Ed__2 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AIActor AIActor;

		public WitchsBrew _003C_003E4__this;

		private string _003Cguid_003E5__1;

		private AIActor _003CenemyPrefab_003E5__2;

		private AIActor _003Caiactor_003E5__3;

		private HasBeenDoubledByWitchsBrew _003Cchallengitude_003E5__4;

		private HasBeenDoubledByWitchsBrew _003Cchallengitude2_003E5__5;

		private KillOnRoomClear _003Ckill_003E5__6;

		private List<PickupObject> _003CnewDrops_003E5__7;

		private ItemQuality _003Cqual_003E5__8;

		private int _003CitemsToReAdd_003E5__9;

		private int _003Ci_003E5__10;

		private int _003Ci_003E5__11;

		private PickupObject _003Citem_003E5__12;

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
		public _003CToilEnemyDupe_003Ed__2(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003Cguid_003E5__1 = null;
			_003CenemyPrefab_003E5__2 = null;
			_003Caiactor_003E5__3 = null;
			_003Cchallengitude_003E5__4 = null;
			_003Cchallengitude2_003E5__5 = null;
			_003Ckill_003E5__6 = null;
			_003CnewDrops_003E5__7 = null;
			_003Citem_003E5__12 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_006b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			//IL_02bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_032d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0332: Unknown result type (might be due to invalid IL or missing references)
			//IL_03c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_03e9: Unknown result type (might be due to invalid IL or missing references)
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
				_003Cguid_003E5__1 = AIActor.EnemyGuid;
				_003CenemyPrefab_003E5__2 = EnemyDatabase.GetOrLoadByGuid(_003Cguid_003E5__1);
				_003Caiactor_003E5__3 = AIActor.Spawn(_003CenemyPrefab_003E5__2, Vector2Extensions.ToIntVector2(((BraveBehaviour)AIActor).gameActor.CenterPosition, (VectorConversions)0), ((DungeonPlaceableBehaviour)AIActor).GetAbsoluteParentRoom(), true, (AwakenAnimationType)0, true);
				_003Cchallengitude_003E5__4 = ((Component)_003Caiactor_003E5__3).gameObject.AddComponent<HasBeenDoubledByWitchsBrew>();
				_003Cchallengitude_003E5__4.linkedOther = AIActor;
				_003Cchallengitude2_003E5__5 = ((Component)AIActor).gameObject.AddComponent<HasBeenDoubledByWitchsBrew>();
				_003Cchallengitude2_003E5__5.linkedOther = _003Caiactor_003E5__3;
				_003Caiactor_003E5__3.procedurallyOutlined = true;
				AIActor.procedurallyOutlined = true;
				_003Caiactor_003E5__3.IsWorthShootingAt = AIActor.IsWorthShootingAt;
				_003Caiactor_003E5__3.IgnoreForRoomClear = AIActor.IgnoreForRoomClear;
				_003Caiactor_003E5__3.AssignedCurrencyToDrop = AIActor.AssignedCurrencyToDrop;
				_003Caiactor_003E5__3.AdditionalSafeItemDrops = AIActor.AdditionalSafeItemDrops;
				_003Caiactor_003E5__3.AdditionalSimpleItemDrops = AIActor.AdditionalSimpleItemDrops;
				_003Caiactor_003E5__3.CanTargetEnemies = AIActor.CanTargetEnemies;
				_003Caiactor_003E5__3.CanTargetPlayers = AIActor.CanTargetPlayers;
				if (AIActor.IsInReinforcementLayer)
				{
					_003Caiactor_003E5__3.HandleReinforcementFallIntoRoom(0f);
				}
				if ((Object)(object)((Component)AIActor).GetComponent<KillOnRoomClear>() != (Object)null)
				{
					_003Ckill_003E5__6 = GameObjectExtensions.GetOrAddComponent<KillOnRoomClear>(((Component)_003Caiactor_003E5__3).gameObject);
					_003Ckill_003E5__6.overrideDeathAnim = ((Component)AIActor).GetComponent<KillOnRoomClear>().overrideDeathAnim;
					_003Ckill_003E5__6.preventExplodeOnDeath = ((Component)AIActor).GetComponent<KillOnRoomClear>().preventExplodeOnDeath;
					_003Ckill_003E5__6 = null;
				}
				if (_003Caiactor_003E5__3.EnemyGuid == "249db525a9464e5282d02162c88e0357")
				{
					if (Object.op_Implicit((Object)(object)((Component)_003Caiactor_003E5__3).gameObject.GetComponent<SpawnEnemyOnDeath>()))
					{
						Object.Destroy((Object)(object)((Component)_003Caiactor_003E5__3).gameObject.GetComponent<SpawnEnemyOnDeath>());
					}
				}
				else if (AlexandriaTags.HasTag(_003Caiactor_003E5__3, "mimic") && AIActor.AdditionalSafeItemDrops != null && _003Caiactor_003E5__3.AdditionalSafeItemDrops != null)
				{
					_003CnewDrops_003E5__7 = new List<PickupObject>();
					_003Cqual_003E5__8 = (ItemQuality)1;
					_003CitemsToReAdd_003E5__9 = 0;
					_003Ci_003E5__10 = _003Caiactor_003E5__3.AdditionalSafeItemDrops.Count - 1;
					while (_003Ci_003E5__10 >= 0)
					{
						if (!BabyGoodChanceKin.lootIDlist.Contains(_003Caiactor_003E5__3.AdditionalSafeItemDrops[_003Ci_003E5__10].PickupObjectId))
						{
							_003Cqual_003E5__8 = _003Caiactor_003E5__3.AdditionalSafeItemDrops[_003Ci_003E5__10].quality;
							_003CitemsToReAdd_003E5__9++;
						}
						else
						{
							_003CnewDrops_003E5__7.Add(PickupObjectDatabase.GetById(_003Caiactor_003E5__3.AdditionalSafeItemDrops[_003Ci_003E5__10].PickupObjectId));
						}
						_003Ci_003E5__10--;
					}
					if (_003CitemsToReAdd_003E5__9 > 0)
					{
						_003Ci_003E5__11 = 0;
						while (_003Ci_003E5__11 < _003CitemsToReAdd_003E5__9)
						{
							_003Citem_003E5__12 = (PickupObject)(object)LootEngine.GetItemOfTypeAndQuality<PassiveItem>(_003Cqual_003E5__8, (GenericLootTable)null, false);
							if (Random.value <= 0.5f)
							{
								_003Citem_003E5__12 = (PickupObject)(object)LootEngine.GetItemOfTypeAndQuality<Gun>(_003Cqual_003E5__8, (GenericLootTable)null, false);
							}
							_003CnewDrops_003E5__7.Add(_003Citem_003E5__12);
							_003Citem_003E5__12 = null;
							_003Ci_003E5__11++;
						}
						_003Caiactor_003E5__3.AdditionalSafeItemDrops = _003CnewDrops_003E5__7;
					}
					_003CnewDrops_003E5__7 = null;
				}
				((MonoBehaviour)GameManager.Instance).StartCoroutine(_003C_003E4__this.Shrimk(_003Caiactor_003E5__3));
				((MonoBehaviour)GameManager.Instance).StartCoroutine(_003C_003E4__this.Shrimk(AIActor));
				((BraveBehaviour)_003Caiactor_003E5__3).specRigidbody.Reinitialize();
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

	public static Vector2 TargetScale = new Vector2(0.75f, 0.75f);

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<WitchsBrew>("Witches Brew", "Fire Burn and Cauldron Bubble", "Doubles all enemies, but makes them much weaker.\n\nNot suitable for vegans or vegetarians.", "witchsbrew_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)4;
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.CHALLENGE_TOILANDTROUBLE_BEATEN, requiredFlagValue: true);
	}

	public void AIActorMods(AIActor target)
	{
		if (Object.op_Implicit((Object)(object)target) && Object.op_Implicit((Object)(object)((BraveBehaviour)target).healthHaver) && !((BraveBehaviour)target).healthHaver.IsBoss && !((BraveBehaviour)target).healthHaver.IsSubboss && !AIActorUtility.IsSecretlyTheMineFlayer(target) && (Object)(object)((Component)target).GetComponent<CompanionController>() == (Object)null && (Object)(object)((Component)target).GetComponent<HasBeenDoubledByWitchsBrew>() == (Object)null && (Object)(object)((Component)target).GetComponent<DisplacedImageController>() == (Object)null && (Object)(object)((Component)target).GetComponent<MirrorImageController>() == (Object)null && target.EnemyGuid != "22fc2c2c45fb47cf9fb5f7b043a70122")
		{
			((MonoBehaviour)this).StartCoroutine(ToilEnemyDupe(target));
		}
	}

	private IEnumerator ToilEnemyDupe(AIActor AIActor)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CToilEnemyDupe_003Ed__2(0)
		{
			_003C_003E4__this = this,
			AIActor = AIActor
		};
	}

	private IEnumerator Shrimk(AIActor actor)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CShrimk_003Ed__3(0)
		{
			_003C_003E4__this = this,
			actor = actor
		};
	}

	private void ModifyHP(HealthHaver hp)
	{
		float maxHealth = hp.GetMaxHealth();
		hp.SetHealthMaximum(maxHealth * 0.25f, (float?)null, false);
		hp.ForceSetCurrentHealth(maxHealth * 0.25f);
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		AIActor.OnPreStart = (Action<AIActor>)Delegate.Combine(AIActor.OnPreStart, new Action<AIActor>(AIActorMods));
	}

	public override DebrisObject Drop(PlayerController player)
	{
		DebrisObject result = ((PassiveItem)this).Drop(player);
		AIActor.OnPreStart = (Action<AIActor>)Delegate.Remove(AIActor.OnPreStart, new Action<AIActor>(AIActorMods));
		return result;
	}

	public override void OnDestroy()
	{
		AIActor.OnPreStart = (Action<AIActor>)Delegate.Remove(AIActor.OnPreStart, new Action<AIActor>(AIActorMods));
		((PassiveItem)this).OnDestroy();
	}
}
