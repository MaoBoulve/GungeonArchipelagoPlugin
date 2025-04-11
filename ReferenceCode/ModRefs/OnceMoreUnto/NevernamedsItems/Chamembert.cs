using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Dungeonator;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class Chamembert : PassiveItem
{
	[CompilerGenerated]
	private sealed class _003CEncheese_003Ed__4 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerController user;

		public Chamembert _003C_003E4__this;

		private GameObject _003Csp_003E5__1;

		private tk2dBaseSprite _003Ccomponent_003E5__2;

		private List<AIActor> _003CactiveEnemies_003E5__3;

		private bool _003CElimentalerSynergy_003E5__4;

		private int _003Camt_003E5__5;

		private int _003Ci_003E5__6;

		private AIActor _003Caiactor_003E5__7;

		private float _003Cnum_003E5__8;

		private int _003Cj_003E5__9;

		private Projectile _003CtoSpawn_003E5__10;

		private Projectile _003Cspawned_003E5__11;

		private GoopModifier _003Cgooper_003E5__12;

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
		public _003CEncheese_003Ed__4(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003Csp_003E5__1 = null;
			_003Ccomponent_003E5__2 = null;
			_003CactiveEnemies_003E5__3 = null;
			_003Caiactor_003E5__7 = null;
			_003CtoSpawn_003E5__10 = null;
			_003Cspawned_003E5__11 = null;
			_003Cgooper_003E5__12 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e2: Expected O, but got Unknown
			//IL_011d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0122: Unknown result type (might be due to invalid IL or missing references)
			//IL_0127: Unknown result type (might be due to invalid IL or missing references)
			//IL_0142: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0566: Unknown result type (might be due to invalid IL or missing references)
			//IL_0570: Expected O, but got Unknown
			//IL_0372: Unknown result type (might be due to invalid IL or missing references)
			//IL_0510: Unknown result type (might be due to invalid IL or missing references)
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E4__this.active = true;
				_003Csp_003E5__1 = Object.Instantiate<GameObject>(SharedVFX.HighPriestImplosionRing, Vector2.op_Implicit(((BraveBehaviour)user).specRigidbody.UnitCenter), Quaternion.identity);
				_003Ccomponent_003E5__2 = _003Csp_003E5__1.GetComponent<tk2dBaseSprite>();
				_003Csp_003E5__1.transform.parent = ((BraveBehaviour)user).transform;
				_003Ccomponent_003E5__2.HeightOffGround = 0.2f;
				((BraveBehaviour)user).sprite.AttachRenderer(_003Ccomponent_003E5__2);
				AkSoundEngine.PostEvent("Play_ITM_Macho_Brace_Trigger_01", ((Component)user).gameObject);
				_003C_003E2__current = (object)new WaitForSeconds(1f);
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				AkSoundEngine.PostEvent("Play_BOSS_Rat_Cheese_Burst_01", ((Component)user).gameObject);
				Object.Instantiate<GameObject>(StaticStatusEffects.elimentalerCheeseEffect.vfxExplosion, Vector2.op_Implicit(((BraveBehaviour)user).specRigidbody.UnitCenter), Quaternion.identity);
				DeadlyDeadlyGoopManager.GetGoopManagerForGoopType(EasyGoopDefinitions.CheeseDef).TimedAddGoopCircle(((GameActor)user).CenterPosition, 4f, 0.5f, false);
				if (Object.op_Implicit((Object)(object)PlayerUtility.GetExtComp(user)))
				{
					PlayerUtility.GetExtComp(user).TriggerInvulnerableFrames(0.25f, false);
				}
				_003CactiveEnemies_003E5__3 = user.CurrentRoom.GetActiveEnemies((ActiveEnemyType)0);
				if (_003CactiveEnemies_003E5__3 != null)
				{
					_003Ci_003E5__6 = 0;
					while (_003Ci_003E5__6 < _003CactiveEnemies_003E5__3.Count)
					{
						_003Caiactor_003E5__7 = _003CactiveEnemies_003E5__3[_003Ci_003E5__6];
						if (_003Caiactor_003E5__7.IsNormalEnemy)
						{
							_003Cnum_003E5__8 = Vector2.Distance(((GameActor)user).CenterPosition, ((GameActor)_003Caiactor_003E5__7).CenterPosition);
							if (_003Cnum_003E5__8 <= 6f)
							{
								((GameActor)_003Caiactor_003E5__7).ApplyEffect((GameActorEffect)(object)StaticStatusEffects.elimentalerCheeseEffect, 1f, (Projectile)null);
							}
						}
						_003Caiactor_003E5__7 = null;
						_003Ci_003E5__6++;
					}
				}
				_003CElimentalerSynergy_003E5__4 = false;
				if (((PickupObject)((GameActor)user).CurrentGun).PickupObjectId == 626)
				{
					_003CElimentalerSynergy_003E5__4 = true;
				}
				_003Camt_003E5__5 = (_003CElimentalerSynergy_003E5__4 ? 1 : 5);
				if (CustomSynergies.PlayerHasActiveSynergy(user, "To Brie or Not To Brie"))
				{
					_003Camt_003E5__5 *= 2;
				}
				_003Cj_003E5__9 = 0;
				while (_003Cj_003E5__9 < _003Camt_003E5__5)
				{
					_003CtoSpawn_003E5__10 = ((Random.value <= 0.5f) ? ((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0] : ((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[1]);
					if (_003CElimentalerSynergy_003E5__4)
					{
						ref Projectile reference = ref _003CtoSpawn_003E5__10;
						PickupObject byId = PickupObjectDatabase.GetById(808);
						reference = ((Gun)((byId is Gun) ? byId : null)).DefaultModule.projectiles[0];
					}
					_003Cspawned_003E5__11 = ProjectileUtility.InstantiateAndFireInDirection(_003CtoSpawn_003E5__10, ((BraveBehaviour)user).specRigidbody.UnitCenter, _003CElimentalerSynergy_003E5__4 ? ((GameActor)user).CurrentGun.CurrentAngle : BraveUtility.RandomAngle(), 0f, (PlayerController)null).GetComponent<Projectile>();
					_003Cspawned_003E5__11.Owner = (GameActor)(object)user;
					_003Cspawned_003E5__11.Shooter = ((BraveBehaviour)user).specRigidbody;
					if (!_003CElimentalerSynergy_003E5__4)
					{
						_003Cspawned_003E5__11.baseData.range = Random.Range(5f, 9f);
						ProjectileData baseData = _003Cspawned_003E5__11.baseData;
						baseData.speed *= Random.Range(0.8f, 1.1f);
						_003Cgooper_003E5__12 = ((Component)_003Cspawned_003E5__11).gameObject.AddComponent<GoopModifier>();
						_003Cgooper_003E5__12.SpawnGoopOnCollision = true;
						_003Cgooper_003E5__12.goopDefinition = EasyGoopDefinitions.CheeseDef;
						_003Cgooper_003E5__12.CollisionSpawnRadius = 1f;
						_003Cgooper_003E5__12 = null;
					}
					_003Cspawned_003E5__11.UpdateSpeed();
					if (CustomSynergies.PlayerHasActiveSynergy(user, "To Brie or Not To Brie") && !_003CElimentalerSynergy_003E5__4)
					{
						((Component)_003Cspawned_003E5__11).gameObject.AddComponent<BounceProjModifier>().numberOfBounces = 1;
					}
					if (CustomSynergies.PlayerHasActiveSynergy(user, "Cordon Blue"))
					{
						_003Cspawned_003E5__11.baseData.range = 1000f;
						if (Random.value <= 0.07f)
						{
							((Component)_003Cspawned_003E5__11).gameObject.AddComponent<BlankProjModifier>().blankType = (EasyBlankType)1;
						}
					}
					_003CtoSpawn_003E5__10 = null;
					_003Cspawned_003E5__11 = null;
					_003Cj_003E5__9++;
				}
				_003C_003E2__current = (object)new WaitForSeconds((float)(CustomSynergies.PlayerHasActiveSynergy(user, "To Brie or Not To Brie") ? 2 : 3));
				_003C_003E1__state = 2;
				return true;
			case 2:
				_003C_003E1__state = -1;
				_003C_003E4__this.active = false;
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

	public static int ID;

	public bool active = false;

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<Chamembert>("Chamembert", "Wheel Lock", "Creates a fine cheesy eruption on reloading.\n\nThis creamy variety of cheese is a Gungeon original, its recipe known only to the most elder and revered 'cheesemasters' of the Order.", "chamembert_icon", assetbundle: true);
		val.quality = (ItemQuality)4;
		ID = val.PickupObjectId;
		val.SetupUnlockOnCustomFlag(CustomDungeonFlags.BEATEN_RAT_BOSS_TURBO_MODE, requiredFlagValue: true);
	}

	private void HandleGunReloaded(PlayerController player, Gun playerGun)
	{
		if (playerGun.ClipShotsRemaining == 0 && !active)
		{
			float num = 1f;
			if (playerGun.InfiniteAmmo && ((PickupObject)playerGun).PickupObjectId != 626)
			{
				num = 0.4f;
			}
			if (Random.value <= num)
			{
				((MonoBehaviour)player).StartCoroutine(Encheese(player));
			}
		}
	}

	public IEnumerator Encheese(PlayerController user)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CEncheese_003Ed__4(0)
		{
			_003C_003E4__this = this,
			user = user
		};
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		active = false;
		player.OnReloadedGun = (Action<PlayerController, Gun>)Delegate.Combine(player.OnReloadedGun, new Action<PlayerController, Gun>(HandleGunReloaded));
	}

	public override void DisableEffect(PlayerController player)
	{
		if (Object.op_Implicit((Object)(object)player))
		{
			player.OnReloadedGun = (Action<PlayerController, Gun>)Delegate.Remove(player.OnReloadedGun, new Action<PlayerController, Gun>(HandleGunReloaded));
		}
		((PassiveItem)this).DisableEffect(player);
	}
}
