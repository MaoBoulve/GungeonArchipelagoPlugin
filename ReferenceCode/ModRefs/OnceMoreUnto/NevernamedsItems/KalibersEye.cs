using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using Gungeon;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class KalibersEye : PassiveItem
{
	[CompilerGenerated]
	private sealed class _003CDoEnemySpawn_003Ed__4 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public string enemyGuid;

		public IntVector2 position;

		public bool isJammed;

		public bool isDisplaced;

		public KalibersEye _003C_003E4__this;

		private AIActor _003CenemyToSpawn_003E5__1;

		private AIActor _003CTargetActor_003E5__2;

		private CustomEnemyTagsSystem _003Ctags_003E5__3;

		private CompanionController _003CorAddComponent_003E5__4;

		private CompanionisedEnemyBulletModifiers _003CcompanionisedBullets_003E5__5;

		private AdvancedKillOnRoomClear _003CadvKill_003E5__6;

		private DisplacedImageController _003Cdisplacedness_003E5__7;

		private Exception _003Ce_003E5__8;

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
		public _003CDoEnemySpawn_003Ed__4(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003CenemyToSpawn_003E5__1 = null;
			_003CTargetActor_003E5__2 = null;
			_003Ctags_003E5__3 = null;
			_003CorAddComponent_003E5__4 = null;
			_003CcompanionisedBullets_003E5__5 = null;
			_003CadvKill_003E5__6 = null;
			_003Cdisplacedness_003E5__7 = null;
			_003Ce_003E5__8 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_0026: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			//IL_0075: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_008d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0124: Unknown result type (might be due to invalid IL or missing references)
			//IL_0164: Unknown result type (might be due to invalid IL or missing references)
			//IL_016b: Unknown result type (might be due to invalid IL or missing references)
			//IL_016c: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b2: Unknown result type (might be due to invalid IL or missing references)
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = (object)new WaitForSeconds(1f);
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				try
				{
					if (((PassiveItem)_003C_003E4__this).Owner.IsInCombat)
					{
						_003CenemyToSpawn_003E5__1 = EnemyDatabase.GetOrLoadByGuid(enemyGuid);
						Object.Instantiate<GameObject>(SharedVFX.BloodiedScarfPoofVFX, ((IntVector2)(ref position)).ToVector3(), Quaternion.identity);
						_003CTargetActor_003E5__2 = AIActor.Spawn(_003CenemyToSpawn_003E5__1, position, GameManager.Instance.Dungeon.data.GetAbsoluteRoomFromPosition(position), true, (AwakenAnimationType)0, true);
						PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(((BraveBehaviour)_003CTargetActor_003E5__2).specRigidbody, (int?)null, false);
						_003Ctags_003E5__3 = GameObjectExtensions.GetOrAddComponent<CustomEnemyTagsSystem>(((Component)_003CTargetActor_003E5__2).gameObject);
						_003Ctags_003E5__3.isKalibersEyeMinion = true;
						_003Ctags_003E5__3.ignoreForGoodMimic = true;
						_003CorAddComponent_003E5__4 = GameObjectExtensions.GetOrAddComponent<CompanionController>(((Component)_003CTargetActor_003E5__2).gameObject);
						_003CorAddComponent_003E5__4.companionID = (CompanionIdentifier)0;
						_003CorAddComponent_003E5__4.Initialize(((PassiveItem)_003C_003E4__this).Owner);
						_003CTargetActor_003E5__2.OverrideHitEnemies = true;
						_003CTargetActor_003E5__2.CollisionDamage = 0.5f;
						AIActor obj = _003CTargetActor_003E5__2;
						obj.CollisionDamageTypes = (CoreDamageTypes)(obj.CollisionDamageTypes | 0x40);
						if (isJammed)
						{
							_003CTargetActor_003E5__2.BecomeBlackPhantom();
						}
						_003CcompanionisedBullets_003E5__5 = GameObjectExtensions.GetOrAddComponent<CompanionisedEnemyBulletModifiers>(((Component)_003CTargetActor_003E5__2).gameObject);
						_003CcompanionisedBullets_003E5__5.jammedDamageMultiplier = 2f;
						_003CcompanionisedBullets_003E5__5.TintBullets = true;
						_003CcompanionisedBullets_003E5__5.TintColor = ExtendedColours.honeyYellow;
						_003CcompanionisedBullets_003E5__5.baseBulletDamage = 10f;
						_003CcompanionisedBullets_003E5__5.scaleSpeed = true;
						_003CcompanionisedBullets_003E5__5.scaleDamage = true;
						_003CcompanionisedBullets_003E5__5.scaleSize = false;
						_003CcompanionisedBullets_003E5__5.doPostProcess = false;
						_003CcompanionisedBullets_003E5__5.enemyOwner = ((PassiveItem)_003C_003E4__this).Owner;
						((GameActor)_003CTargetActor_003E5__2).ApplyEffect((GameActorEffect)(object)GameManager.Instance.Dungeon.sharedSettingsPrefab.DefaultPermanentCharmEffect, 1f, (Projectile)null);
						_003CadvKill_003E5__6 = ((Component)_003CTargetActor_003E5__2).gameObject.AddComponent<AdvancedKillOnRoomClear>();
						_003CadvKill_003E5__6.triggersOnRoomUnseal = true;
						if (isDisplaced)
						{
							_003Cdisplacedness_003E5__7 = ((Component)_003CTargetActor_003E5__2).gameObject.AddComponent<DisplacedImageController>();
							_003Cdisplacedness_003E5__7.Init();
							_003Cdisplacedness_003E5__7 = null;
						}
						_003CTargetActor_003E5__2.IsHarmlessEnemy = true;
						((GameActor)_003CTargetActor_003E5__2).RegisterOverrideColor(Color.grey, "Ressurection");
						_003CTargetActor_003E5__2.IgnoreForRoomClear = true;
						if (Object.op_Implicit((Object)(object)((Component)_003CTargetActor_003E5__2).gameObject.GetComponent<SpawnEnemyOnDeath>()))
						{
							Object.Destroy((Object)(object)((Component)_003CTargetActor_003E5__2).gameObject.GetComponent<SpawnEnemyOnDeath>());
						}
						_003CenemyToSpawn_003E5__1 = null;
						_003CTargetActor_003E5__2 = null;
						_003Ctags_003E5__3 = null;
						_003CorAddComponent_003E5__4 = null;
						_003CcompanionisedBullets_003E5__5 = null;
						_003CadvKill_003E5__6 = null;
					}
				}
				catch (Exception ex)
				{
					_003Ce_003E5__8 = ex;
					ETGModConsole.Log((object)_003Ce_003E5__8.Message, false);
					ETGModConsole.Log((object)_003Ce_003E5__8.StackTrace, false);
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

	public static int KalibersEyeID;

	public static void Init()
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<KalibersEye>("Kaliber's Eye", "They are mine.", "Makes the Gundead your own.\n\nDestroy them, but do not waste them.", "kaliberseye_improved", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)val, (StatType)14, 1f, (ModifyMethod)0);
		((PickupObject)val).quality = (ItemQuality)5;
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)2, 1f);
		KalibersEyeID = ((PickupObject)val).PickupObjectId;
		((PickupObject)(object)val).SetupUnlockOnCustomStat(CustomTrackedStats.CHARMED_ENEMIES_KILLED, 99f, (PrerequisiteOperation)2);
		Game.Items.Rename("nn:kaliber's_eye", "nn:kalibers_eye");
	}

	private bool EnemyValidForKalibersEye(bool fatal, HealthHaver enemy)
	{
		if (Object.op_Implicit((Object)(object)((BraveBehaviour)enemy).aiActor) && fatal && !enemy.IsBoss && ((PassiveItem)this).Owner.IsInCombat && ((BraveBehaviour)enemy).aiActor.EnemyGuid != "249db525a9464e5282d02162c88e0357")
		{
			if (!((BraveBehaviour)enemy).aiActor.IgnoreForRoomClear && (Object)(object)((Component)enemy).GetComponent<MirrorImageController>() == (Object)null)
			{
				return true;
			}
			return false;
		}
		return false;
	}

	private void OnEnemyDamaged(float damage, bool fatal, HealthHaver enemy)
	{
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		if (!fatal || !EnemyValidForKalibersEye(fatal, enemy))
		{
			return;
		}
		try
		{
			float num = ((!CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "All Seeing")) ? 0.5f : 1f);
			if (Random.value < num)
			{
				bool isBlackPhantom = ((BraveBehaviour)enemy).aiActor.IsBlackPhantom;
				string enemyGuid = ((BraveBehaviour)enemy).aiActor.EnemyGuid;
				Vector2 worldBottomLeft = ((BraveBehaviour)enemy).sprite.WorldBottomLeft;
				IntVector2 position = Vector2Extensions.ToIntVector2(worldBottomLeft, (VectorConversions)2);
				((MonoBehaviour)GameManager.Instance).StartCoroutine(DoEnemySpawn(enemyGuid, position, isBlackPhantom, (Object)(object)((Component)enemy).GetComponent<DisplacedImageController>() != (Object)null));
			}
		}
		catch (Exception ex)
		{
			ETGModConsole.Log((object)ex.Message, false);
			ETGModConsole.Log((object)ex.StackTrace, false);
		}
	}

	private IEnumerator DoEnemySpawn(string enemyGuid, IntVector2 position, bool isJammed, bool isDisplaced)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CDoEnemySpawn_003Ed__4(0)
		{
			_003C_003E4__this = this,
			enemyGuid = enemyGuid,
			position = position,
			isJammed = isJammed,
			isDisplaced = isDisplaced
		};
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		player.OnAnyEnemyReceivedDamage = (Action<float, bool, HealthHaver>)Delegate.Combine(player.OnAnyEnemyReceivedDamage, new Action<float, bool, HealthHaver>(OnEnemyDamaged));
	}

	public override DebrisObject Drop(PlayerController player)
	{
		DebrisObject result = ((PassiveItem)this).Drop(player);
		player.OnAnyEnemyReceivedDamage = (Action<float, bool, HealthHaver>)Delegate.Remove(player.OnAnyEnemyReceivedDamage, new Action<float, bool, HealthHaver>(OnEnemyDamaged));
		return result;
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
}
