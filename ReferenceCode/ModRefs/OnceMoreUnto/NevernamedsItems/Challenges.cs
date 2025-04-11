using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.EnemyAPI;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

internal class Challenges
{
	public class HasBeenAffectedByCurrentChallenge : MonoBehaviour
	{
		private AIActor self;

		public AIActor linkedOther;

		public HasBeenAffectedByCurrentChallenge()
		{
			linkedOther = null;
		}

		private void Start()
		{
			//IL_0054: Unknown result type (might be due to invalid IL or missing references)
			//IL_005e: Expected O, but got Unknown
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Expected O, but got Unknown
			self = ((Component)this).GetComponent<AIActor>();
			if (Object.op_Implicit((Object)(object)self) && Object.op_Implicit((Object)(object)((BraveBehaviour)self).specRigidbody) && CurrentChallenge == ChallengeType.TOIL_AND_TROUBLE)
			{
				SpeculativeRigidbody specRigidbody = ((BraveBehaviour)self).specRigidbody;
				specRigidbody.OnPreRigidbodyCollision = (OnPreRigidbodyCollisionDelegate)Delegate.Combine((Delegate)(object)specRigidbody.OnPreRigidbodyCollision, (Delegate)new OnPreRigidbodyCollisionDelegate(OnPreCollide));
			}
		}

		private void OnPreCollide(SpeculativeRigidbody myRigidbody, PixelCollider myCollider, SpeculativeRigidbody otherRigidbody, PixelCollider otherCollider)
		{
			if (CurrentChallenge == ChallengeType.TOIL_AND_TROUBLE && (((Object)(object)linkedOther != (Object)null) & ((Object)(object)((BraveBehaviour)linkedOther).specRigidbody != (Object)null)) && (Object)(object)otherRigidbody == (Object)(object)((BraveBehaviour)linkedOther).specRigidbody)
			{
				PhysicsEngine.SkipCollision = true;
			}
		}
	}

	[CompilerGenerated]
	private sealed class _003CShrimk_003Ed__4 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AIActor actor;

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
		public _003CShrimk_003Ed__4(int _003C_003E1__state)
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
	private sealed class _003CToilEnemyDupe_003Ed__3 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AIActor AIActor;

		private string _003Cguid_003E5__1;

		private AIActor _003CenemyPrefab_003E5__2;

		private AIActor _003Caiactor_003E5__3;

		private HasBeenAffectedByCurrentChallenge _003Cchallengitude_003E5__4;

		private HasBeenAffectedByCurrentChallenge _003Cchallengitude2_003E5__5;

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
		public _003CToilEnemyDupe_003Ed__3(int _003C_003E1__state)
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
			//IL_031d: Unknown result type (might be due to invalid IL or missing references)
			//IL_038d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0392: Unknown result type (might be due to invalid IL or missing references)
			//IL_0421: Unknown result type (might be due to invalid IL or missing references)
			//IL_0449: Unknown result type (might be due to invalid IL or missing references)
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
				_003Cchallengitude_003E5__4 = ((Component)_003Caiactor_003E5__3).gameObject.AddComponent<HasBeenAffectedByCurrentChallenge>();
				_003Cchallengitude_003E5__4.linkedOther = AIActor;
				_003Cchallengitude2_003E5__5 = ((Component)AIActor).gameObject.AddComponent<HasBeenAffectedByCurrentChallenge>();
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
				if (_003Caiactor_003E5__3.EnemyGuid == "22fc2c2c45fb47cf9fb5f7b043a70122")
				{
					_003Caiactor_003E5__3.CollisionDamage = 0f;
					((BraveBehaviour)_003Caiactor_003E5__3).specRigidbody.AddCollisionLayerIgnoreOverride(CollisionMask.LayerToMask((CollisionLayer)0));
					((BraveBehaviour)_003Caiactor_003E5__3).specRigidbody.AddCollisionLayerIgnoreOverride(CollisionMask.LayerToMask((CollisionLayer)4));
				}
				else if (_003Caiactor_003E5__3.EnemyGuid == "249db525a9464e5282d02162c88e0357")
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
				((MonoBehaviour)GameManager.Instance).StartCoroutine(Shrimk(_003Caiactor_003E5__3));
				((MonoBehaviour)GameManager.Instance).StartCoroutine(Shrimk(AIActor));
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

	public static ChallengeType CurrentChallenge;

	public static Vector2 TargetScale = new Vector2(0.75f, 0.75f);

	private static List<string> ValidDoubleableBosses = new List<string>
	{
		EnemyGuidDatabase.Entries["blockner_rematch"],
		EnemyGuidDatabase.Entries["fuselier"],
		EnemyGuidDatabase.Entries["shadow_agunim"],
		EnemyGuidDatabase.Entries["gatling_gull"],
		EnemyGuidDatabase.Entries["bullet_king"],
		EnemyGuidDatabase.Entries["blobulord"],
		EnemyGuidDatabase.Entries["beholster"],
		EnemyGuidDatabase.Entries["gorgun"],
		EnemyGuidDatabase.Entries["ammoconda"],
		EnemyGuidDatabase.Entries["old_king"],
		EnemyGuidDatabase.Entries["treadnaught"],
		EnemyGuidDatabase.Entries["mine_flayer"],
		EnemyGuidDatabase.Entries["door_lord"],
		EnemyGuidDatabase.Entries["helicopter_agunim"],
		"6c43fddfd401456c916089fdd1c99b1c",
		"ea40fcc863d34b0088f490f4e57f8913",
		"c00390483f394a849c36143eb878998f"
	};

	public static void Init()
	{
		ChallengeUnlocks.Init();
		Databases.Strings.Core.Set("#NNCHALLENGES_TITLE", "List of Custom Challenges");
		Databases.Strings.Core.Set("#NNCHALLENGES_DESCRIPTION", "Custom challenges present in Once More Into The Breach.");
		Databases.Strings.Core.Set("#NNCHALLENGES_TECHEXPLANATION", "Type 'nnchallenges [challengeid]' to start the challenge (can only be done from the Breach).");
		Databases.Strings.Core.Set("#NNCHALLENGES_DISABLEEXPLANATION", "Challenges will be automatically disabled if Blessed Mode or Rainbow Mode are enabled, if a shortcut is taken from the Breach, or if the player is the Gunslinger or Paradox.");
		Databases.Strings.Core.Set("#NNCHALLENGES_NONBREACHDENIAL", "Challenges can only be activated or deactivated from the Breach.");
		Databases.Strings.Core.Set("#NNCHALLENGES_RAINBOWDENIAL", "Challenges cannot be played in Rainbow Mode.");
		Databases.Strings.Core.Set("#NNCHALLENGES_BLESSEDDENIAL", "Challenges cannot be played in Blessed Mode.");
		Databases.Strings.Core.Set("#NNCHALLENGES_SLINGERDENIAL", "Challenges cannot be played as the Gunslinger.");
		Databases.Strings.Core.Set("#NNCHALLENGES_PARADOXDENIAL", "Challenges cannot be played as the Paradox.");
		Databases.Strings.Core.Set("#NNCHALLENGES_NOCHARDENIAL", "Please select a character before enabling the challenge.");
		Databases.Strings.Core.Set("#NNCHALLENGES_NOWPLAYING", "You are now playing");
		Databases.Strings.Core.Set("#CHAL_TOIL_NAME", "Toil and Trouble");
		Databases.Strings.Core.Set("#CHAL_WHATARMY_NAME", "What Army?");
		Databases.Strings.Core.Set("#CHAL_INVIS_NAME", "Invisible-O");
		Databases.Strings.Core.Set("#CHAL_COOL_NAME", "Keep It Cool");
		Databases.Strings.Core.Set("#CHAL_TOIL_DESC", "All enemy spawns are doubled. Non-doubleable bosses gain a health boost.");
		Databases.Strings.Core.Set("#CHAL_WHATARMY_DESC", "All enemy spawns are randomised.");
		Databases.Strings.Core.Set("#CHAL_INVIS_DESC", "The player, their gun, and their bullets are all completely invisible!");
		Databases.Strings.Core.Set("#CHAL_COOL_DESC", "Permanent ice physics. 45% chance to fire freezing shots.");
		CurrentChallenge = ChallengeType.NONE;
		ETGModConsole.Commands.AddGroup("nnchallenges", (Action<string[]>)delegate
		{
			ETGModConsole.Log((object)("<size=100><color=#ff0000ff>" + StringTableManager.GetString("NNCHALLENGES_TITLE") + "</color></size>"), false);
			ETGModConsole.Log((object)StringTableManager.GetString("#NNCHALLENGES_DESCRIPTION"), false);
			ETGModConsole.Log((object)StringTableManager.GetString("#NNCHALLENGES_TECHEXPLANATION"), false);
			ETGModConsole.Log((object)(StringTableManager.GetString("#CHAL_TOIL_NAME") + ":  [id]<color=#ff0000ff>toilandtrouble</color> - " + StringTableManager.GetString("#CHAL_TOIL_DESC")), false);
			ETGModConsole.Log((object)(StringTableManager.GetString("#CHAL_WHATARMY_NAME") + ": [id]<color=#ff0000ff>whatarmy</color> - " + StringTableManager.GetString("#CHAL_WHATARMY_DESC")), false);
			ETGModConsole.Log((object)(StringTableManager.GetString("#CHAL_INVIS_NAME") + ":  [id]<color=#ff0000ff>invisibleo</color> - " + StringTableManager.GetString("#CHAL_INVIS_DESC")), false);
			ETGModConsole.Log((object)(StringTableManager.GetString("#CHAL_COOL_NAME") + ":  [id]<color=#ff0000ff>keepitcool</color> - " + StringTableManager.GetString("#CHAL_COOL_DESC")), false);
			ETGModConsole.Log((object)StringTableManager.GetString("#NNCHALLENGES_DISABLEEXPLANATION"), false);
		});
		ETGModConsole.Commands.GetGroup("nnchallenges").AddUnit("clear", (Action<string[]>)delegate
		{
			if (GameManager.Instance.IsFoyer)
			{
				ETGModConsole.Log((object)"Challenge Removed", false);
				CurrentChallenge = ChallengeType.NONE;
			}
			else
			{
				ETGModConsole.Log((object)("<color=#ff0000ff>" + StringTableManager.GetString("#NNCHALLENGES_NONBREACHDENIAL") + "</color>"), false);
			}
		});
		ETGModConsole.Commands.GetGroup("nnchallenges").AddUnit("whatarmy", (Action<string[]>)delegate
		{
			string text = FetchFailureType();
			if (text == "none")
			{
				ETGModConsole.Log((object)(StringTableManager.GetString("#NNCHALLENGES_NOWPLAYING") + "; " + StringTableManager.GetString("#CHAL_WHATARMY_NAME")), false);
				CurrentChallenge = ChallengeType.WHAT_ARMY;
			}
			else
			{
				ETGModConsole.Log((object)("<color=#ff0000ff>" + text + "</color>"), false);
			}
		});
		ETGModConsole.Commands.GetGroup("nnchallenges").AddUnit("toilandtrouble", (Action<string[]>)delegate
		{
			string text2 = FetchFailureType();
			if (text2 == "none")
			{
				ETGModConsole.Log((object)(StringTableManager.GetString("#NNCHALLENGES_NOWPLAYING") + "; " + StringTableManager.GetString("#CHAL_TOIL_NAME")), false);
				CurrentChallenge = ChallengeType.TOIL_AND_TROUBLE;
			}
			else
			{
				ETGModConsole.Log((object)("<color=#ff0000ff>" + text2 + "</color>"), false);
			}
		});
		ETGModConsole.Commands.GetGroup("nnchallenges").AddUnit("invisibleo", (Action<string[]>)delegate
		{
			string text3 = FetchFailureType();
			if (text3 == "none")
			{
				ETGModConsole.Log((object)(StringTableManager.GetString("#NNCHALLENGES_NOWPLAYING") + "; " + StringTableManager.GetString("#CHAL_INVIS_NAME")), false);
				CurrentChallenge = ChallengeType.INVISIBLEO;
			}
			else
			{
				ETGModConsole.Log((object)("<color=#ff0000ff>" + text3 + "</color>"), false);
			}
		});
		ETGModConsole.Commands.GetGroup("nnchallenges").AddUnit("keepitcool", (Action<string[]>)delegate
		{
			string text4 = FetchFailureType();
			if (text4 == "none")
			{
				ETGModConsole.Log((object)(StringTableManager.GetString("#NNCHALLENGES_NOWPLAYING") + "; " + StringTableManager.GetString("#CHAL_COOL_NAME")), false);
				CurrentChallenge = ChallengeType.KEEP_IT_COOL;
			}
			else
			{
				ETGModConsole.Log((object)("<color=#ff0000ff>" + text4 + "</color>"), false);
			}
		});
		AIActor.OnPostStart = (Action<AIActor>)Delegate.Combine(AIActor.OnPostStart, new Action<AIActor>(AIActorPostSpawn));
	}

	public static void AIActorPostSpawn(AIActor AIActor)
	{
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Invalid comparison between Unknown and I4
		//IL_03a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		if (CurrentChallenge == ChallengeType.WHAT_ARMY)
		{
			bool flag = (Object)(object)((Component)AIActor).gameObject.transform.parent != (Object)null && ((Object)((Component)((Component)AIActor).gameObject.transform.parent).gameObject).name.Contains("EX_Parachute");
			if (!Object.op_Implicit((Object)(object)AIActor) || !Object.op_Implicit((Object)(object)((BraveBehaviour)AIActor).healthHaver) || ((BraveBehaviour)AIActor).healthHaver.IsBoss || ((BraveBehaviour)AIActor).healthHaver.IsSubboss || AIActorUtility.IsSecretlyTheMineFlayer(AIActor) || !((Object)(object)((Component)AIActor).gameObject.GetComponent<HasBeenAffectedByCurrentChallenge>() == (Object)null) || !((Object)(object)((Component)AIActor).gameObject.GetComponent<CompanionController>() == (Object)null) || flag)
			{
				return;
			}
			float num = 1f;
			if ((int)((DungeonPlaceableBehaviour)AIActor).GetAbsoluteParentRoom().area.PrototypeRoomCategory == 3 && RuntimeRoomhandlerUtility.RoomContainsMineFlayer(((DungeonPlaceableBehaviour)AIActor).GetAbsoluteParentRoom()))
			{
				num = 0.2f;
			}
			if (Random.value <= num)
			{
				List<string> list = MagickeCauldron.GenerateChaosPalette();
				string text = BraveUtility.RandomElement<string>(list);
				AIActor orLoadByGuid = EnemyDatabase.GetOrLoadByGuid(text);
				AIActor val = AIActor.Spawn(orLoadByGuid, Vector2Extensions.ToIntVector2(((BraveBehaviour)AIActor).gameActor.CenterPosition, (VectorConversions)0), ((DungeonPlaceableBehaviour)AIActor).GetAbsoluteParentRoom(), true, (AwakenAnimationType)0, true);
				((Component)val).gameObject.AddComponent<HasBeenAffectedByCurrentChallenge>();
				val.AssignedCurrencyToDrop = AIActor.AssignedCurrencyToDrop;
				val.AdditionalSafeItemDrops = AIActor.AdditionalSafeItemDrops;
				val.AdditionalSimpleItemDrops = AIActor.AdditionalSimpleItemDrops;
				val.CanTargetEnemies = AIActor.CanTargetEnemies;
				val.CanTargetPlayers = AIActor.CanTargetPlayers;
				if (val.EnemyGuid == "556e9f2a10f9411cb9dbfd61e0e0f1e1")
				{
					val.HandleReinforcementFallIntoRoom(0f);
				}
				else if (AIActor.IsInReinforcementLayer)
				{
					val.invisibleUntilAwaken = true;
					((BraveBehaviour)val).specRigidbody.CollideWithOthers = false;
					((GameActor)val).IsGone = true;
					val.HandleReinforcementFallIntoRoom(0f);
				}
				if (val.EnemyGuid == "22fc2c2c45fb47cf9fb5f7b043a70122")
				{
					val.CollisionDamage = 0f;
				}
				if ((Object)(object)((Component)AIActor).GetComponent<ExplodeOnDeath>() != (Object)null)
				{
					Object.Destroy((Object)(object)((Component)AIActor).GetComponent<ExplodeOnDeath>());
				}
				AIActor.EraseFromExistence(true);
			}
		}
		else
		{
			if (CurrentChallenge != ChallengeType.TOIL_AND_TROUBLE)
			{
				return;
			}
			if (Object.op_Implicit((Object)(object)AIActor) && Object.op_Implicit((Object)(object)((BraveBehaviour)AIActor).healthHaver) && !((BraveBehaviour)AIActor).healthHaver.IsBoss && !((BraveBehaviour)AIActor).healthHaver.IsSubboss && !AIActorUtility.IsSecretlyTheMineFlayer(AIActor))
			{
				if ((Object)(object)((Component)AIActor).GetComponent<CompanionController>() == (Object)null && (Object)(object)AIActor.CompanionOwner == (Object)null && (Object)(object)((Component)AIActor).GetComponent<HasBeenAffectedByCurrentChallenge>() == (Object)null && (Object)(object)((Component)AIActor).GetComponent<DisplacedImageController>() == (Object)null && (Object)(object)((Component)AIActor).GetComponent<WitchsBrew.HasBeenDoubledByWitchsBrew>() == (Object)null && (Object)(object)((Component)AIActor).GetComponent<MirrorImageController>() == (Object)null)
				{
					((MonoBehaviour)GameManager.Instance).StartCoroutine(ToilEnemyDupe(AIActor));
				}
			}
			else
			{
				if (!Object.op_Implicit((Object)(object)AIActor) || !Object.op_Implicit((Object)(object)((BraveBehaviour)AIActor).healthHaver) || (!((BraveBehaviour)AIActor).healthHaver.IsBoss && !((BraveBehaviour)AIActor).healthHaver.IsSubboss) || AIActorUtility.IsSecretlyTheMineFlayer(AIActor) || !((Object)(object)((Component)AIActor).GetComponent<HasBeenAffectedByCurrentChallenge>() == (Object)null))
				{
					return;
				}
				if (ValidDoubleableBosses.Contains(AIActor.EnemyGuid))
				{
					string enemyGuid = AIActor.EnemyGuid;
					AIActor orLoadByGuid2 = EnemyDatabase.GetOrLoadByGuid(enemyGuid);
					AIActor val2 = AIActor.Spawn(orLoadByGuid2, Vector2Extensions.ToIntVector2(((BraveBehaviour)AIActor).gameActor.CenterPosition, (VectorConversions)0), ((DungeonPlaceableBehaviour)AIActor).GetAbsoluteParentRoom(), true, (AwakenAnimationType)0, true);
					HasBeenAffectedByCurrentChallenge hasBeenAffectedByCurrentChallenge = ((Component)val2).gameObject.AddComponent<HasBeenAffectedByCurrentChallenge>();
					hasBeenAffectedByCurrentChallenge.linkedOther = AIActor;
					HasBeenAffectedByCurrentChallenge hasBeenAffectedByCurrentChallenge2 = ((Component)AIActor).gameObject.AddComponent<HasBeenAffectedByCurrentChallenge>();
					hasBeenAffectedByCurrentChallenge2.linkedOther = val2;
					val2.AssignedCurrencyToDrop = AIActor.AssignedCurrencyToDrop;
					val2.AdditionalSafeItemDrops = AIActor.AdditionalSafeItemDrops;
					val2.AdditionalSimpleItemDrops = AIActor.AdditionalSimpleItemDrops;
					if (Object.op_Implicit((Object)(object)((Component)AIActor).GetComponent<BroController>()))
					{
						GameObjectExtensions.GetOrAddComponent<BroController>(((Component)val2).gameObject);
					}
					float maxHealth = ((BraveBehaviour)AIActor).healthHaver.GetMaxHealth();
					float maxHealth2 = ((BraveBehaviour)val2).healthHaver.GetMaxHealth();
					((BraveBehaviour)AIActor).healthHaver.SetHealthMaximum(maxHealth * 0.5f, (float?)null, false);
					((BraveBehaviour)AIActor).healthHaver.ForceSetCurrentHealth(maxHealth * 0.5f);
					((BraveBehaviour)val2).healthHaver.SetHealthMaximum(maxHealth2 * 0.5f, (float?)null, false);
					((BraveBehaviour)val2).healthHaver.ForceSetCurrentHealth(maxHealth2 * 0.5f);
				}
				else
				{
					float maxHealth3 = ((BraveBehaviour)AIActor).healthHaver.GetMaxHealth();
					((BraveBehaviour)AIActor).healthHaver.SetHealthMaximum(maxHealth3 * 1.5f, (float?)null, false);
					((BraveBehaviour)AIActor).healthHaver.ForceSetCurrentHealth(maxHealth3 * 1.5f);
				}
			}
		}
	}

	private static IEnumerator ToilEnemyDupe(AIActor AIActor)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CToilEnemyDupe_003Ed__3(0)
		{
			AIActor = AIActor
		};
	}

	private static IEnumerator Shrimk(AIActor actor)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CShrimk_003Ed__4(0)
		{
			actor = actor
		};
	}

	public static void OnLevelLoaded()
	{
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Invalid comparison between Unknown and I4
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Invalid comparison between Unknown and I4
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Invalid comparison between Unknown and I4
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Invalid comparison between Unknown and I4
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Invalid comparison between Unknown and I4
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0245: Invalid comparison between Unknown and I4
		//IL_021f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0275: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c5: Unknown result type (might be due to invalid IL or missing references)
		if (CurrentChallenge != 0)
		{
			PlayerController primaryPlayer = GameManager.Instance.PrimaryPlayer;
			if ((Object)(object)primaryPlayer == (Object)null)
			{
				ETGModConsole.Log((object)"ERRA PLAYA NULLA", false);
			}
			PlayerController val = null;
			if ((Object)(object)GameManager.Instance.SecondaryPlayer != (Object)null)
			{
				val = GameManager.Instance.SecondaryPlayer;
			}
			if (GameStatsManager.Instance.IsRainbowRun)
			{
				ETGModConsole.Log((object)"<color=#ff0000ff>Challenge Voided: Played Rainbow Run</color>", false);
				TextBubble.DoAmbientTalk(((BraveBehaviour)primaryPlayer).transform, new Vector3(1f, 2f, 0f), "Challenge Voided: Played Rainbow Run", 4f);
				CurrentChallenge = ChallengeType.NONE;
			}
			else if (primaryPlayer.CharacterUsesRandomGuns || (Object.op_Implicit((Object)(object)val) && val.CharacterUsesRandomGuns))
			{
				ETGModConsole.Log((object)"<color=#ff0000ff>Challenge Voided: Played Blessed Run</color>", false);
				CurrentChallenge = ChallengeType.NONE;
				TextBubble.DoAmbientTalk(((BraveBehaviour)primaryPlayer).transform, new Vector3(1f, 2f, 0f), "Challenge Voided: Played Blessed Run", 4f);
			}
			else if ((int)primaryPlayer.characterIdentity == 10 || (Object.op_Implicit((Object)(object)val) && (int)val.characterIdentity == 10))
			{
				ETGModConsole.Log((object)"<color=#ff0000ff>Challenge Voided: Played as Gunslinger</color>", false);
				CurrentChallenge = ChallengeType.NONE;
				TextBubble.DoAmbientTalk(((BraveBehaviour)primaryPlayer).transform, new Vector3(1f, 2f, 0f), "Challenge Voided: Played as Gunslinger", 4f);
			}
			else if ((int)primaryPlayer.characterIdentity == 9 || (Object.op_Implicit((Object)(object)val) && (int)val.characterIdentity == 9))
			{
				ETGModConsole.Log((object)"<color=#ff0000ff>Challenge Voided: Played as Paradox</color>", false);
				CurrentChallenge = ChallengeType.NONE;
				TextBubble.DoAmbientTalk(((BraveBehaviour)primaryPlayer).transform, new Vector3(1f, 2f, 0f), "Challenge Voided: Played as Paradox", 4f);
			}
			else if ((int)GameManager.Instance.CurrentGameMode == 1)
			{
				ETGModConsole.Log((object)"<color=#ff0000ff>Challenge Voided: Took a Shortcut</color>", false);
				CurrentChallenge = ChallengeType.NONE;
				TextBubble.DoAmbientTalk(((BraveBehaviour)primaryPlayer).transform, new Vector3(1f, 2f, 0f), "Challenge Voided: Took a Shortcut", 4f);
			}
			else if ((int)GameManager.Instance.CurrentGameMode == 2)
			{
				ETGModConsole.Log((object)"<color=#ff0000ff>Challenge Voided: Entered Bossrush</color>", false);
				CurrentChallenge = ChallengeType.NONE;
				TextBubble.DoAmbientTalk(((BraveBehaviour)primaryPlayer).transform, new Vector3(1f, 2f, 0f), "Challenge Voided: Entered Bossrush", 4f);
			}
			else if (GameManager.Instance.InTutorial)
			{
				ETGModConsole.Log((object)"<color=#ff0000ff>Challenge Voided: Entered Tutorial</color>", false);
				CurrentChallenge = ChallengeType.NONE;
				TextBubble.DoAmbientTalk(((BraveBehaviour)primaryPlayer).transform, new Vector3(1f, 2f, 0f), "Challenge Voided: Entered Tutorial", 4f);
			}
		}
	}

	private static string FetchFailureType()
	{
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Invalid comparison between Unknown and I4
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Invalid comparison between Unknown and I4
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Invalid comparison between Unknown and I4
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Invalid comparison between Unknown and I4
		string result = "none";
		bool flag = false;
		PlayerController primaryPlayer = GameManager.Instance.PrimaryPlayer;
		if ((Object)(object)primaryPlayer == (Object)null)
		{
			Debug.LogWarning((object)"Attempted to set a challenge without a valid player, caught it though.");
			result = StringTableManager.GetString("#NNCHALLENGES_NOCHARDENIAL");
			flag = true;
		}
		PlayerController val = null;
		if ((Object)(object)GameManager.Instance.SecondaryPlayer != (Object)null)
		{
			val = GameManager.Instance.SecondaryPlayer;
		}
		if (!flag)
		{
			if (!GameManager.Instance.IsFoyer)
			{
				result = StringTableManager.GetString("#NNCHALLENGES_NONBREACHDENIAL");
			}
			else if (GameStatsManager.Instance.IsRainbowRun)
			{
				result = StringTableManager.GetString("#NNCHALLENGES_RAINBOWDENIAL");
			}
			else if (primaryPlayer.CharacterUsesRandomGuns || (Object.op_Implicit((Object)(object)val) && val.CharacterUsesRandomGuns))
			{
				result = StringTableManager.GetString("#NNCHALLENGES_BLESSEDDENIAL");
			}
			else if ((int)primaryPlayer.characterIdentity == 10 || (Object.op_Implicit((Object)(object)val) && (int)val.characterIdentity == 10))
			{
				result = StringTableManager.GetString("#NNCHALLENGES_SLINGERDENIAL");
			}
			else if ((int)primaryPlayer.characterIdentity == 9 || (Object.op_Implicit((Object)(object)val) && (int)val.characterIdentity == 9))
			{
				StringTableManager.GetString("#NNCHALLENGES_PARADOXDENIAL");
			}
		}
		return result;
	}
}
