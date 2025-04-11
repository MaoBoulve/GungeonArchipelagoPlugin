using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class GregTheEgg : CompanionItem
{
	public class GoodMimicStoredGregHealth : MonoBehaviour
	{
		public float cachedHealth = 3000f;
	}

	public class GregTheEggBehaviour : CompanionController
	{
		[CompilerGenerated]
		private sealed class _003CGiveGregDeathPayout_003Ed__8 : IEnumerator<object>, IDisposable, IEnumerator
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public PlayerController playerOwner;

			public Vector3 positionToSpawn;

			public PickupObject itemInPlayerInventory;

			public bool isGoodMimic;

			public bool hasSynergyFreeRange;

			public bool hasSynergyGregSalad;

			public GregTheEggBehaviour _003C_003E4__this;

			private PickupObject _003CitemToSpawn_003E5__1;

			private float _003CrandomType_003E5__2;

			private int _003Ci_003E5__3;

			private int _003Ci_003E5__4;

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
			public _003CGiveGregDeathPayout_003Ed__8(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				_003CitemToSpawn_003E5__1 = null;
				_003C_003E1__state = -2;
			}

			private bool MoveNext()
			{
				//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
				//IL_0100: Expected O, but got Unknown
				//IL_011c: Unknown result type (might be due to invalid IL or missing references)
				//IL_0121: Unknown result type (might be due to invalid IL or missing references)
				//IL_0160: Unknown result type (might be due to invalid IL or missing references)
				//IL_0165: Unknown result type (might be due to invalid IL or missing references)
				switch (_003C_003E1__state)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					itemInPlayerInventory.CanBeDropped = false;
					_003CitemToSpawn_003E5__1 = null;
					if (hasSynergyFreeRange)
					{
						_003CrandomType_003E5__2 = Random.value;
						if (_003CrandomType_003E5__2 <= 0.25f)
						{
							_003CitemToSpawn_003E5__1 = (PickupObject)(object)LootEngine.GetItemOfTypeAndQuality<PlayerItem>((ItemQuality)4, GameManager.Instance.RewardManager.ItemsLootTable, true);
						}
						else if (_003CrandomType_003E5__2 <= 0.625f)
						{
							_003CitemToSpawn_003E5__1 = (PickupObject)(object)LootEngine.GetItemOfTypeAndQuality<Gun>((ItemQuality)4, GameManager.Instance.RewardManager.GunsLootTable, true);
						}
						else
						{
							_003CitemToSpawn_003E5__1 = (PickupObject)(object)LootEngine.GetItemOfTypeAndQuality<PassiveItem>((ItemQuality)4, GameManager.Instance.RewardManager.ItemsLootTable, true);
						}
					}
					else
					{
						_003CitemToSpawn_003E5__1 = (PickupObject)(object)LootEngine.GetItemOfTypeAndQuality<CompanionItem>((ItemQuality)4, GameManager.Instance.RewardManager.ItemsLootTable, true);
					}
					_003C_003E2__current = (object)new WaitForSeconds(1f);
					_003C_003E1__state = 1;
					return true;
				case 1:
					_003C_003E1__state = -1;
					LootEngine.SpawnItem(((Component)_003CitemToSpawn_003E5__1).gameObject, positionToSpawn, Vector2.zero, 1f, false, true, true);
					if (hasSynergyGregSalad)
					{
						_003Ci_003E5__3 = 0;
						while (_003Ci_003E5__3 < 5)
						{
							LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetById(BraveUtility.RandomElement<int>(lootIDlist))).gameObject, positionToSpawn, Vector2.zero, 1f, false, true, false);
							_003Ci_003E5__3++;
						}
					}
					_003Ci_003E5__4 = 0;
					while (_003Ci_003E5__4 < playerOwner.passiveItems.Count)
					{
						if ((Object)(object)playerOwner.passiveItems[_003Ci_003E5__4] == (Object)(object)itemInPlayerInventory)
						{
							PlayerUtility.RemovePassiveItemAtIndex(playerOwner, _003Ci_003E5__4);
						}
						_003Ci_003E5__4++;
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

		private Chest lastPredictedChest;

		private bool isOnScramblerCooldown = false;

		public PlayerController Owner;

		public GregTheEgg ConnectedItem;

		public CompanionItem ConnectedItemIfGoodMimic;

		private CustomHologramDoer gregHologram;

		private void Start()
		{
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			//IL_005a: Expected O, but got Unknown
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0064: Expected O, but got Unknown
			Owner = base.m_owner;
			Owner.OnRoomClearEvent += OnRoomClear;
			((BraveBehaviour)this).healthHaver.OnPreDeath += OnPreDeath;
			SpeculativeRigidbody specRigidbody = ((BraveBehaviour)this).specRigidbody;
			specRigidbody.OnPreRigidbodyCollision = (OnPreRigidbodyCollisionDelegate)Delegate.Combine((Delegate)(object)specRigidbody.OnPreRigidbodyCollision, (Delegate)new OnPreRigidbodyCollisionDelegate(OnPreCollision));
			gregHologram = GameObjectExtensions.GetOrAddComponent<CustomHologramDoer>(((Component)this).gameObject);
			foreach (PassiveItem passiveItem in Owner.passiveItems)
			{
				if (Object.op_Implicit((Object)(object)passiveItem) && Object.op_Implicit((Object)(object)((Component)passiveItem).GetComponent<GregTheEgg>()))
				{
					if (Object.op_Implicit((Object)(object)((CompanionItem)((Component)passiveItem).GetComponent<GregTheEgg>()).ExtantCompanion) && (Object)(object)((CompanionItem)((Component)passiveItem).GetComponent<GregTheEgg>()).ExtantCompanion == (Object)(object)((Component)this).gameObject)
					{
						ConnectedItem = ((Component)passiveItem).GetComponent<GregTheEgg>();
					}
				}
				else if (Object.op_Implicit((Object)(object)passiveItem) && Object.op_Implicit((Object)(object)((Component)passiveItem).GetComponent<CompanionItem>()) && Object.op_Implicit((Object)(object)((Component)passiveItem).GetComponent<CompanionItem>().ExtantCompanion) && (Object)(object)((Component)passiveItem).GetComponent<CompanionItem>().ExtantCompanion == (Object)(object)((Component)this).gameObject)
				{
					ConnectedItemIfGoodMimic = ((Component)passiveItem).GetComponent<CompanionItem>();
					GameObjectExtensions.GetOrAddComponent<GoodMimicStoredGregHealth>(((Component)passiveItem).gameObject);
				}
			}
		}

		public override void OnDestroy()
		{
			//IL_003c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0046: Expected O, but got Unknown
			//IL_0046: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Expected O, but got Unknown
			if (Object.op_Implicit((Object)(object)Owner))
			{
				((BraveBehaviour)this).healthHaver.OnPreDeath -= OnPreDeath;
				SpeculativeRigidbody specRigidbody = ((BraveBehaviour)this).specRigidbody;
				specRigidbody.OnPreRigidbodyCollision = (OnPreRigidbodyCollisionDelegate)Delegate.Remove((Delegate)(object)specRigidbody.OnPreRigidbodyCollision, (Delegate)new OnPreRigidbodyCollisionDelegate(OnPreCollision));
				Owner.OnRoomClearEvent -= OnRoomClear;
			}
			((CompanionController)this).OnDestroy();
		}

		public override void Update()
		{
			//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_03e4: Unknown result type (might be due to invalid IL or missing references)
			if (Object.op_Implicit((Object)(object)((BraveBehaviour)this).healthHaver) && Object.op_Implicit((Object)(object)ConnectedItem))
			{
				if (((BraveBehaviour)this).healthHaver.GetCurrentHealth() < ConnectedItem.cachedGregHealth)
				{
					ConnectedItem.cachedGregHealth = ((BraveBehaviour)this).healthHaver.GetCurrentHealth();
				}
				else if (((BraveBehaviour)this).healthHaver.GetCurrentHealth() > ConnectedItem.cachedGregHealth)
				{
					((BraveBehaviour)this).healthHaver.ForceSetCurrentHealth(ConnectedItem.cachedGregHealth);
				}
			}
			else if (Object.op_Implicit((Object)(object)((BraveBehaviour)this).healthHaver) && Object.op_Implicit((Object)(object)ConnectedItemIfGoodMimic) && Object.op_Implicit((Object)(object)((Component)ConnectedItemIfGoodMimic).GetComponent<GoodMimicStoredGregHealth>()))
			{
				float cachedHealth = ((Component)ConnectedItemIfGoodMimic).GetComponent<GoodMimicStoredGregHealth>().cachedHealth;
				if (((BraveBehaviour)this).healthHaver.GetCurrentHealth() < cachedHealth)
				{
					((Component)ConnectedItemIfGoodMimic).GetComponent<GoodMimicStoredGregHealth>().cachedHealth = ((BraveBehaviour)this).healthHaver.GetCurrentHealth();
				}
				else if (((BraveBehaviour)this).healthHaver.GetCurrentHealth() > cachedHealth)
				{
					((BraveBehaviour)this).healthHaver.ForceSetCurrentHealth(cachedHealth);
				}
			}
			if (CustomSynergies.PlayerHasActiveSynergy(Owner, "Scrambled Gregs") && Object.op_Implicit((Object)(object)((BraveBehaviour)this).aiActor) && Object.op_Implicit((Object)(object)((BraveBehaviour)this).healthHaver) && ((BraveBehaviour)this).healthHaver.IsAlive && Object.op_Implicit((Object)(object)Owner) && Owner.IsInCombat && !isOnScramblerCooldown)
			{
				PickupObject byId = PickupObjectDatabase.GetById(445);
				Projectile val = ((Gun)((byId is Gun) ? byId : null)).DefaultModule.projectiles[0];
				GameObject val2 = ProjectileUtility.InstantiateAndFireTowardsPosition(val, ((tk2dBaseSprite)((Component)this).GetComponent<tk2dSprite>()).WorldCenter, MathsAndLogicHelper.GetPositionOfNearestEnemy(((tk2dBaseSprite)((Component)this).GetComponent<tk2dSprite>()).WorldCenter, (ActorCenter)2, true, (ActiveEnemyType)1, (List<AIActor>)null, (Func<AIActor, bool>)null), 0f, 7f, Owner);
				Projectile component = val2.GetComponent<Projectile>();
				if ((Object)(object)component != (Object)null)
				{
					component.Owner = (GameActor)(object)Owner;
					component.Shooter = ((BraveBehaviour)Owner).specRigidbody;
					component.TreatedAsNonProjectileForChallenge = true;
					ProjectileData baseData = component.baseData;
					baseData.damage *= Owner.stats.GetStatValue((StatType)5);
					ProjectileData baseData2 = component.baseData;
					baseData2.speed *= Owner.stats.GetStatValue((StatType)6);
					ProjectileData baseData3 = component.baseData;
					baseData3.force *= Owner.stats.GetStatValue((StatType)12);
					component.AdditionalScaleMultiplier *= Owner.stats.GetStatValue((StatType)15);
					component.UpdateSpeed();
					((CompanionController)this).HandleCompanionPostProcessProjectile(component);
				}
				isOnScramblerCooldown = true;
				((MonoBehaviour)this).Invoke("resetFireCooldown", 5f);
			}
			if (Object.op_Implicit((Object)(object)Owner) && Object.op_Implicit((Object)(object)((BraveBehaviour)this).transform) && Object.op_Implicit((Object)(object)((BraveBehaviour)this).specRigidbody) && Object.op_Implicit((Object)(object)((Component)this).gameObject) && Object.op_Implicit((Object)(object)((BraveBehaviour)this).healthHaver) && ((BraveBehaviour)this).healthHaver.IsAlive && CustomSynergies.PlayerHasActiveSynergy(Owner, "Century Greg"))
			{
				Chest val3 = null;
				float num = float.MaxValue;
				for (int i = 0; i < StaticReferenceManager.AllChests.Count; i++)
				{
					Chest val4 = StaticReferenceManager.AllChests[i];
					if (Object.op_Implicit((Object)(object)val4) && Object.op_Implicit((Object)(object)((BraveBehaviour)val4).sprite) && !val4.IsOpen && !val4.IsBroken && !val4.IsSealed)
					{
						float num2 = Vector2.Distance(Vector2.op_Implicit(((BraveBehaviour)this).transform.position), ((BraveBehaviour)val4).sprite.WorldCenter);
						if (num2 < num)
						{
							val3 = val4;
							num = num2;
						}
					}
				}
				if (num > 5f)
				{
					val3 = null;
				}
				if ((Object)(object)lastPredictedChest != (Object)(object)val3)
				{
					if (Object.op_Implicit((Object)(object)lastPredictedChest))
					{
						gregHologram.HideSprite();
					}
					if (Object.op_Implicit((Object)(object)val3))
					{
						List<PickupObject> list = val3.PredictContents(Owner);
						if (list.Count > 0 && Object.op_Implicit((Object)(object)((BraveBehaviour)list[0]).encounterTrackable))
						{
							tk2dSpriteCollectionData encounterIconCollection = AmmonomiconController.ForceInstance.EncounterIconCollection;
							gregHologram.ShowSprite(encounterIconCollection, encounterIconCollection.GetSpriteIdByName(((BraveBehaviour)list[0]).encounterTrackable.journalData.AmmonomiconSprite));
						}
					}
					lastPredictedChest = val3;
				}
			}
			else if (Object.op_Implicit((Object)(object)gregHologram.extantSprite))
			{
				gregHologram.HideSprite();
			}
			((CompanionController)this).Update();
		}

		private void OnPreCollision(SpeculativeRigidbody myRigidbody, PixelCollider myPixelCollider, SpeculativeRigidbody otherRigidbody, PixelCollider otherPixelCollider)
		{
			//IL_0277: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
			//IL_0105: Unknown result type (might be due to invalid IL or missing references)
			if (!Object.op_Implicit((Object)(object)((BraveBehaviour)this).specRigidbody) || !Object.op_Implicit((Object)(object)((BraveBehaviour)this).aiActor) || !Object.op_Implicit((Object)(object)((BraveBehaviour)this).healthHaver) || !((BraveBehaviour)this).healthHaver.IsAlive || !Object.op_Implicit((Object)(object)Owner) || !Object.op_Implicit((Object)(object)((BraveBehaviour)this).sprite) || !Object.op_Implicit((Object)(object)((BraveBehaviour)otherRigidbody).projectile) || ((BraveBehaviour)otherRigidbody).projectile.Owner is PlayerController)
			{
				return;
			}
			if (CustomSynergies.PlayerHasActiveSynergy(Owner, "Deviled Gregs") && Random.value <= 0.15f)
			{
				float num = 0f;
				for (int i = 0; i < 8; i++)
				{
					PickupObject byId = PickupObjectDatabase.GetById(336);
					GameObject val = SpawnManager.SpawnProjectile(((Component)((Gun)((byId is Gun) ? byId : null)).DefaultModule.projectiles[0]).gameObject, Vector2.op_Implicit(((BraveBehaviour)this).sprite.WorldCenter), Quaternion.Euler(0f, 0f, num), true);
					Projectile component = val.GetComponent<Projectile>();
					if (Object.op_Implicit((Object)(object)component))
					{
						component.SpawnedFromOtherPlayerProjectile = false;
						if ((Object)(object)Owner != (Object)null)
						{
							component.TreatedAsNonProjectileForChallenge = true;
							ProjectileData baseData = component.baseData;
							baseData.damage *= Owner.stats.GetStatValue((StatType)5);
							ProjectileData baseData2 = component.baseData;
							baseData2.speed *= Owner.stats.GetStatValue((StatType)6);
							ProjectileData baseData3 = component.baseData;
							baseData3.force *= Owner.stats.GetStatValue((StatType)12);
							component.AdditionalScaleMultiplier *= Owner.stats.GetStatValue((StatType)15);
							component.UpdateSpeed();
							((CompanionController)this).HandleCompanionPostProcessProjectile(component);
						}
					}
					num += 45f;
				}
			}
			if (CustomSynergies.PlayerHasActiveSynergy(Owner, "Hard Boiled Gregs"))
			{
				PassiveReflectItem.ReflectBullet(((BraveBehaviour)otherRigidbody).projectile, true, ((BraveBehaviour)((BraveBehaviour)Owner).specRigidbody).gameActor, 10f, 1f, 1f, 0f);
				if (Object.op_Implicit((Object)(object)((BraveBehaviour)this).healthHaver))
				{
					((BraveBehaviour)this).healthHaver.ApplyDamage(13f, Vector2.zero, "Greggo", (CoreDamageTypes)0, (DamageCategory)0, false, (PixelCollider)null, false);
				}
				PhysicsEngine.SkipCollision = true;
			}
		}

		private void resetFireCooldown()
		{
			isOnScramblerCooldown = false;
		}

		private void OnPreDeath(Vector2 something)
		{
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
			if (Object.op_Implicit((Object)(object)ConnectedItem) && Object.op_Implicit((Object)(object)((BraveBehaviour)this).transform) && Object.op_Implicit((Object)(object)Owner))
			{
				((MonoBehaviour)Owner).StartCoroutine(GiveGregDeathPayout(Owner, ((BraveBehaviour)this).transform.position, (PickupObject)(object)ConnectedItem, isGoodMimic: false, CustomSynergies.PlayerHasActiveSynergy(Owner, "Free Range Gregs"), CustomSynergies.PlayerHasActiveSynergy(Owner, "Greg Salad")));
			}
			else if (Object.op_Implicit((Object)(object)ConnectedItemIfGoodMimic) && Object.op_Implicit((Object)(object)((BraveBehaviour)this).transform) && Object.op_Implicit((Object)(object)Owner))
			{
				((MonoBehaviour)Owner).StartCoroutine(GiveGregDeathPayout(Owner, ((BraveBehaviour)this).transform.position, (PickupObject)(object)ConnectedItemIfGoodMimic, isGoodMimic: true, CustomSynergies.PlayerHasActiveSynergy(Owner, "Free Range Gregs"), CustomSynergies.PlayerHasActiveSynergy(Owner, "Greg Salad")));
			}
			Owner.OnRoomClearEvent -= OnRoomClear;
			((BraveBehaviour)this).healthHaver.OnPreDeath -= OnPreDeath;
		}

		public IEnumerator GiveGregDeathPayout(PlayerController playerOwner, Vector3 positionToSpawn, PickupObject itemInPlayerInventory, bool isGoodMimic, bool hasSynergyFreeRange, bool hasSynergyGregSalad)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
			return new _003CGiveGregDeathPayout_003Ed__8(0)
			{
				_003C_003E4__this = this,
				playerOwner = playerOwner,
				positionToSpawn = positionToSpawn,
				itemInPlayerInventory = itemInPlayerInventory,
				isGoodMimic = isGoodMimic,
				hasSynergyFreeRange = hasSynergyFreeRange,
				hasSynergyGregSalad = hasSynergyGregSalad
			};
		}

		public void OnRoomClear(PlayerController player)
		{
			try
			{
				if (Object.op_Implicit((Object)(object)((BraveBehaviour)this).aiActor) && Object.op_Implicit((Object)(object)((BraveBehaviour)((BraveBehaviour)this).aiActor).healthHaver) && ((BraveBehaviour)((BraveBehaviour)this).aiActor).healthHaver.IsAlive && Random.value < 0.15f)
				{
					if (Object.op_Implicit((Object)(object)((BraveBehaviour)this).aiAnimator))
					{
						((BraveBehaviour)this).aiAnimator.PlayUntilFinished("spawnloot", false, (string)null, -1f, false);
					}
					((MonoBehaviour)this).Invoke("SpawnMundaneLoot", 0.9f);
				}
			}
			catch (Exception ex)
			{
				ETGModConsole.Log((object)ex.Message, false);
				ETGModConsole.Log((object)ex.StackTrace, false);
			}
		}

		private void SpawnMundaneLoot()
		{
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			if (Object.op_Implicit((Object)(object)((BraveBehaviour)this).aiActor) && Object.op_Implicit((Object)(object)((BraveBehaviour)((BraveBehaviour)this).aiActor).healthHaver) && ((BraveBehaviour)((BraveBehaviour)this).aiActor).healthHaver.IsAlive)
			{
				int num = BraveUtility.RandomElement<int>(lootIDlist);
				LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetById(num)).gameObject, Vector2.op_Implicit(((BraveBehaviour)((BraveBehaviour)this).aiActor).sprite.WorldCenter), Vector2.zero, 1f, false, true, false);
			}
		}
	}

	private float cachedGregHealth = 3000f;

	private static tk2dSpriteCollectionData GregAnimationCollection;

	private static string[] spritePaths = new string[24]
	{
		"NevernamedsItems/Resources/Companions/Greg/gregtheegg_die_001", "NevernamedsItems/Resources/Companions/Greg/gregtheegg_die_002", "NevernamedsItems/Resources/Companions/Greg/gregtheegg_die_003", "NevernamedsItems/Resources/Companions/Greg/gregtheegg_die_004", "NevernamedsItems/Resources/Companions/Greg/gregtheegg_die_005", "NevernamedsItems/Resources/Companions/Greg/gregtheegg_die_006", "NevernamedsItems/Resources/Companions/Greg/gregtheegg_die_007", "NevernamedsItems/Resources/Companions/Greg/gregtheegg_die_008", "NevernamedsItems/Resources/Companions/Greg/gregtheegg_die_009", "NevernamedsItems/Resources/Companions/Greg/gregtheegg_idle_001",
		"NevernamedsItems/Resources/Companions/Greg/gregtheegg_idle_002", "NevernamedsItems/Resources/Companions/Greg/gregtheegg_idle_003", "NevernamedsItems/Resources/Companions/Greg/gregtheegg_idle_004", "NevernamedsItems/Resources/Companions/Greg/gregtheegg_spawnloot_001", "NevernamedsItems/Resources/Companions/Greg/gregtheegg_spawnloot_002", "NevernamedsItems/Resources/Companions/Greg/gregtheegg_spawnloot_003", "NevernamedsItems/Resources/Companions/Greg/gregtheegg_run_001", "NevernamedsItems/Resources/Companions/Greg/gregtheegg_run_002", "NevernamedsItems/Resources/Companions/Greg/gregtheegg_run_003", "NevernamedsItems/Resources/Companions/Greg/gregtheegg_run_004",
		"NevernamedsItems/Resources/Companions/Greg/gregtheegg_run_005", "NevernamedsItems/Resources/Companions/Greg/gregtheegg_run_006", "NevernamedsItems/Resources/Companions/Greg/gregtheegg_run_007", "NevernamedsItems/Resources/Companions/Greg/gregtheegg_run_008"
	};

	public static List<int> lootIDlist = new List<int> { 78, 600, 565, 73, 85, 120, 224, 67 };

	public static GameObject prefab;

	private static readonly string guid = "greg_the_egg9327892378594676";

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<GregTheEgg>("Greg The Egg", "I'm About To Break!", "A strange friendly egg.\n\nLegends of this creature span history, with him accompanying hundreds of ancient heroes upon their adventures.", "gregtheegg_icon", assetbundle: true);
		CompanionItem val = (CompanionItem)(object)((obj is CompanionItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)3;
		val.CompanionGuid = guid;
		BuildPrefab();
	}

	public static void BuildPrefab()
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Expected O, but got Unknown
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0201: Unknown result type (might be due to invalid IL or missing references)
		//IL_0208: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Expected O, but got Unknown
		//IL_0234: Unknown result type (might be due to invalid IL or missing references)
		//IL_023b: Expected O, but got Unknown
		//IL_0292: Unknown result type (might be due to invalid IL or missing references)
		//IL_0299: Expected O, but got Unknown
		//IL_029c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e0: Expected O, but got Unknown
		//IL_02ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f5: Expected O, but got Unknown
		//IL_02f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0334: Unknown result type (might be due to invalid IL or missing references)
		//IL_033b: Expected O, but got Unknown
		//IL_0349: Unknown result type (might be due to invalid IL or missing references)
		//IL_0350: Expected O, but got Unknown
		//IL_0353: Unknown result type (might be due to invalid IL or missing references)
		//IL_0396: Unknown result type (might be due to invalid IL or missing references)
		//IL_039d: Expected O, but got Unknown
		//IL_03a0: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)prefab != (Object)null || CompanionBuilder.companionDictionary.ContainsKey(guid))
		{
			return;
		}
		prefab = CompanionBuilder.BuildPrefab("Greg The Egg", guid, "NevernamedsItems/Resources/Companions/Greg/gregtheegg_idle_001", new IntVector2(1, 2), new IntVector2(9, 12));
		GregTheEggBehaviour gregTheEggBehaviour = prefab.AddComponent<GregTheEggBehaviour>();
		((CompanionController)gregTheEggBehaviour).CanInterceptBullets = true;
		((CompanionController)gregTheEggBehaviour).companionID = (CompanionIdentifier)0;
		((BraveBehaviour)gregTheEggBehaviour).aiActor.MovementSpeed = 5f;
		((BraveBehaviour)((BraveBehaviour)gregTheEggBehaviour).aiActor).healthHaver.PreventAllDamage = false;
		((BraveBehaviour)gregTheEggBehaviour).aiActor.CollisionDamage = 0f;
		((BraveBehaviour)((BraveBehaviour)gregTheEggBehaviour).aiActor).specRigidbody.CollideWithOthers = true;
		((BraveBehaviour)((BraveBehaviour)gregTheEggBehaviour).aiActor).specRigidbody.CollideWithTileMap = false;
		((BraveBehaviour)((BraveBehaviour)gregTheEggBehaviour).aiActor).healthHaver.ForceSetCurrentHealth(3000f);
		((BraveBehaviour)((BraveBehaviour)gregTheEggBehaviour).aiActor).healthHaver.SetHealthMaximum(3000f, (float?)null, false);
		((BraveBehaviour)((BraveBehaviour)gregTheEggBehaviour).aiActor).specRigidbody.PixelColliders.Clear();
		((BraveBehaviour)((BraveBehaviour)gregTheEggBehaviour).aiActor).specRigidbody.PixelColliders.Add(new PixelCollider
		{
			ColliderGenerationMode = (PixelColliderGeneration)0,
			CollisionLayer = (CollisionLayer)3,
			IsTrigger = false,
			BagleUseFirstFrameOnly = false,
			SpecifyBagelFrame = string.Empty,
			BagelColliderNumber = 0,
			ManualOffsetX = 1,
			ManualOffsetY = 2,
			ManualWidth = 9,
			ManualHeight = 12,
			ManualDiameter = 0,
			ManualLeftX = 0,
			ManualLeftY = 0,
			ManualRightX = 0,
			ManualRightY = 0
		});
		((BraveBehaviour)((BraveBehaviour)gregTheEggBehaviour).aiAnimator).specRigidbody.PixelColliders.Add(new PixelCollider
		{
			ColliderGenerationMode = (PixelColliderGeneration)0,
			CollisionLayer = (CollisionLayer)0,
			IsTrigger = false,
			BagleUseFirstFrameOnly = false,
			SpecifyBagelFrame = string.Empty,
			BagelColliderNumber = 0,
			ManualOffsetX = 1,
			ManualOffsetY = 2,
			ManualWidth = 9,
			ManualHeight = 12,
			ManualDiameter = 0,
			ManualLeftX = 0,
			ManualLeftY = 0,
			ManualRightX = 0,
			ManualRightY = 0
		});
		BehaviorSpeculator component = prefab.GetComponent<BehaviorSpeculator>();
		List<MovementBehaviorBase> movementBehaviors = component.MovementBehaviors;
		CompanionFollowPlayerBehavior val = new CompanionFollowPlayerBehavior();
		val.IdleAnimations = new string[1] { "idle" };
		val.CatchUpRadius = 6f;
		val.CatchUpMaxSpeed = 10f;
		val.CatchUpAccelTime = 1f;
		val.CatchUpSpeed = 7f;
		movementBehaviors.Add((MovementBehaviorBase)(object)val);
		AIAnimator aiAnimator = ((BraveBehaviour)gregTheEggBehaviour).aiAnimator;
		DirectionalAnimation val2 = new DirectionalAnimation();
		val2.Type = (DirectionType)1;
		val2.Prefix = "run";
		val2.AnimNames = new string[1];
		val2.Flipped = (FlipType[])(object)new FlipType[1];
		aiAnimator.MoveAnimation = val2;
		List<NamedDirectionalAnimation> list = new List<NamedDirectionalAnimation>();
		NamedDirectionalAnimation val3 = new NamedDirectionalAnimation();
		val3.name = "die";
		NamedDirectionalAnimation obj = val3;
		val2 = new DirectionalAnimation();
		val2.Type = (DirectionType)1;
		val2.Prefix = "die";
		val2.AnimNames = new string[1];
		val2.Flipped = (FlipType[])(object)new FlipType[1];
		obj.anim = val2;
		list.Add(val3);
		val3 = new NamedDirectionalAnimation();
		val3.name = "spawnloot";
		NamedDirectionalAnimation obj2 = val3;
		val2 = new DirectionalAnimation();
		val2.Type = (DirectionType)1;
		val2.Prefix = "spawnloot";
		val2.AnimNames = new string[1];
		val2.Flipped = (FlipType[])(object)new FlipType[1];
		obj2.anim = val2;
		list.Add(val3);
		aiAnimator.OtherAnimations = list;
		val2 = new DirectionalAnimation();
		val2.Type = (DirectionType)1;
		val2.Prefix = "idle";
		val2.AnimNames = new string[1];
		val2.Flipped = (FlipType[])(object)new FlipType[1];
		aiAnimator.IdleAnimation = val2;
		if ((Object)(object)GregAnimationCollection == (Object)null)
		{
			GregAnimationCollection = SpriteBuilder.ConstructCollection(prefab, "GregTheEgg_Collection", false);
			Object.DontDestroyOnLoad((Object)(object)GregAnimationCollection);
			for (int i = 0; i < spritePaths.Length; i++)
			{
				SpriteBuilder.AddSpriteToCollection(spritePaths[i], GregAnimationCollection, (Assembly)null);
			}
			SpriteBuilder.AddAnimation(((BraveBehaviour)gregTheEggBehaviour).spriteAnimator, GregAnimationCollection, new List<int>
			{
				13, 14, 15, 14, 15, 14, 15, 14, 15, 14,
				15
			}, "spawnloot", (WrapMode)2, 15f).fps = 12f;
			SpriteBuilder.AddAnimation(((BraveBehaviour)gregTheEggBehaviour).spriteAnimator, GregAnimationCollection, new List<int> { 9, 10, 11, 12 }, "idle", (WrapMode)0, 15f).fps = 6f;
			SpriteBuilder.AddAnimation(((BraveBehaviour)gregTheEggBehaviour).spriteAnimator, GregAnimationCollection, new List<int> { 16, 17, 18, 19, 20, 21, 22, 23 }, "run", (WrapMode)0, 15f).fps = 14f;
			SpriteBuilder.AddAnimation(((BraveBehaviour)gregTheEggBehaviour).spriteAnimator, GregAnimationCollection, new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8 }, "die", (WrapMode)2, 15f).fps = 12f;
		}
	}
}
