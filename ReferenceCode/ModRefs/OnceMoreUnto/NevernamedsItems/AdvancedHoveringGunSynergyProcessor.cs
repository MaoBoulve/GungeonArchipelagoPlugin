using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class AdvancedHoveringGunSynergyProcessor : MonoBehaviour
{
	public enum TriggerStackingMode
	{
		IGNORE,
		RESET,
		STACK
	}

	public enum TriggerStyle
	{
		CONSTANT,
		ON_DAMAGE,
		ON_ACTIVE_ITEM,
		ON_DODGE_ROLL,
		ON_BLANKED
	}

	[CompilerGenerated]
	private sealed class _003CHandleTimedDuration_003Ed__8 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AdvancedHoveringGunSynergyProcessor _003C_003E4__this;

		private float _003CremainingTime_003E5__1;

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
		public _003CHandleTimedDuration_003Ed__8(int _003C_003E1__state)
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
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E4__this.m_currentlyActive = true;
				_003C_003E4__this.SpawnGuns();
				_003CremainingTime_003E5__1 = _003C_003E4__this.TriggerDuration;
				break;
			case 1:
				_003C_003E1__state = -1;
				break;
			}
			if (_003CremainingTime_003E5__1 > 0f)
			{
				_003CremainingTime_003E5__1 -= BraveTime.DeltaTime;
				if (_003C_003E4__this.m_resetTimer)
				{
					if (_003C_003E4__this.TriggerStacking == TriggerStackingMode.RESET)
					{
						_003CremainingTime_003E5__1 = _003C_003E4__this.TriggerDuration;
					}
					else if (_003C_003E4__this.TriggerStacking == TriggerStackingMode.STACK)
					{
						_003CremainingTime_003E5__1 += _003C_003E4__this.TriggerDuration;
					}
					_003C_003E4__this.m_resetTimer = false;
				}
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			_003C_003E4__this.EraseGuns();
			_003C_003E4__this.m_currentlyActive = false;
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

	public bool shouldHaveGunsLastFrame;

	public PlayerController cachedPlayer;

	public bool m_currentlyActive = false;

	public bool m_resetTimer = false;

	public int[] IDsToSpawn;

	public string RequiredSynergy;

	public List<HoveringGunController> currentHoveringGuns = new List<HoveringGunController>();

	public HoverPosition PositionType;

	public AimType AimType;

	public FireType FireType;

	public bool requiresTargetGunInInventory;

	public bool requiresBaseGunInHand = true;

	public bool fireDelayBasedOnGun = false;

	public bool fireDelayBenefitsFromPlayerFirerate = false;

	public float chanceToSpawnOnTrigger = 1f;

	public int reqActiveItemID = -1;

	public float FireCooldown = 1f;

	public float BeamFireDuration = 1f;

	public bool OnlyOnEmptyReload;

	public string ShootAudioEvent;

	public string OnEveryShotAudioEvent;

	public string FinishedShootingAudioEvent;

	public TriggerStyle Trigger;

	public TriggerStackingMode TriggerStacking;

	public float TriggerDuration = -1f;

	public float ChanceToConsumeTargetGunAmmo = 0f;

	private Gun m_gun;

	public bool ShouldHaveGuns => (Object)(object)cachedPlayer != (Object)null && (Object)(object)m_gun != (Object)null && (string.IsNullOrEmpty(RequiredSynergy) || CustomSynergies.PlayerHasActiveSynergy(cachedPlayer, RequiredSynergy)) && ((Object)(object)((GameActor)cachedPlayer).CurrentGun == (Object)(object)m_gun || !requiresBaseGunInHand);

	public void Awake()
	{
		m_gun = ((Component)this).GetComponent<Gun>();
	}

	public void Update()
	{
		if (!Object.op_Implicit((Object)(object)m_gun))
		{
			return;
		}
		if ((Object)(object)cachedPlayer != (Object)(object)GunTools.GunPlayerOwner(m_gun))
		{
			RelinkActions(cachedPlayer, GunTools.GunPlayerOwner(m_gun));
			cachedPlayer = GunTools.GunPlayerOwner(m_gun);
		}
		if (Trigger != 0)
		{
			return;
		}
		bool shouldHaveGuns = ShouldHaveGuns;
		if (shouldHaveGunsLastFrame != shouldHaveGuns)
		{
			if (shouldHaveGunsLastFrame)
			{
				EraseGuns();
			}
			else
			{
				SpawnGuns();
			}
			shouldHaveGunsLastFrame = shouldHaveGuns;
		}
	}

	public void SpawnGuns()
	{
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_0265: Unknown result type (might be due to invalid IL or missing references)
		//IL_026b: Invalid comparison between Unknown and I4
		if (currentHoveringGuns.Count > 0)
		{
			EraseGuns();
		}
		if (!Object.op_Implicit((Object)(object)cachedPlayer))
		{
			return;
		}
		int i;
		for (i = 0; i < IDsToSpawn.Length; i++)
		{
			if (requiresTargetGunInInventory && !((Object)(object)cachedPlayer.inventory.AllGuns.Find((Gun x) => ((PickupObject)x).PickupObjectId == IDsToSpawn[i]) != (Object)null))
			{
				continue;
			}
			Object obj = ResourceCache.Acquire("Global Prefabs/HoveringGun");
			GameObject val = Object.Instantiate<GameObject>((GameObject)(object)((obj is GameObject) ? obj : null), Vector2Extensions.ToVector3ZisY(((GameActor)cachedPlayer).CenterPosition, 0f), Quaternion.identity);
			val.transform.parent = ((BraveBehaviour)cachedPlayer).transform;
			HoveringGunController component = val.GetComponent<HoveringGunController>();
			component.ShootAudioEvent = ShootAudioEvent;
			component.OnEveryShotAudioEvent = OnEveryShotAudioEvent;
			component.FinishedShootingAudioEvent = FinishedShootingAudioEvent;
			component.ConsumesTargetGunAmmo = ChanceToConsumeTargetGunAmmo > 0f;
			component.ChanceToConsumeTargetGunAmmo = ChanceToConsumeTargetGunAmmo;
			component.Position = PositionType;
			component.Aim = AimType;
			component.Trigger = FireType;
			component.CooldownTime = FireCooldown;
			component.OnlyOnEmptyReload = OnlyOnEmptyReload;
			Gun val2 = null;
			int num = IDsToSpawn[i];
			for (int j = 0; j < cachedPlayer.inventory.AllGuns.Count; j++)
			{
				if (((PickupObject)cachedPlayer.inventory.AllGuns[j]).PickupObjectId == num)
				{
					val2 = cachedPlayer.inventory.AllGuns[j];
				}
			}
			if (!Object.op_Implicit((Object)(object)val2))
			{
				PickupObject obj2 = ((ObjectDatabase<PickupObject>)(object)PickupObjectDatabase.Instance).InternalGetById(num);
				val2 = (Gun)(object)((obj2 is Gun) ? obj2 : null);
			}
			if (fireDelayBasedOnGun && (Object)(object)val2 != (Object)null)
			{
				component.CooldownTime = GetProperShootingSpeed(val2);
			}
			if (fireDelayBenefitsFromPlayerFirerate)
			{
				component.CooldownTime /= cachedPlayer.stats.GetStatValue((StatType)1);
			}
			component.ShootDuration = (((int)val2.DefaultModule.shootStyle == 2) ? BeamFireDuration : (-1f));
			component.Initialize(val2, cachedPlayer);
			currentHoveringGuns.Add(component);
		}
	}

	public void EraseGuns()
	{
		for (int num = currentHoveringGuns.Count - 1; num >= 0; num--)
		{
			if ((Object)(object)currentHoveringGuns[num] != (Object)null)
			{
				Object.Destroy((Object)(object)((Component)currentHoveringGuns[num]).gameObject);
			}
		}
		currentHoveringGuns.Clear();
	}

	public IEnumerator HandleTimedDuration()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CHandleTimedDuration_003Ed__8(0)
		{
			_003C_003E4__this = this
		};
	}

	private void OnDamaged(PlayerController player)
	{
		if ((string.IsNullOrEmpty(RequiredSynergy) || CustomSynergies.PlayerHasActiveSynergy(player, RequiredSynergy)) && (!requiresBaseGunInHand || (Object)(object)((GameActor)player).CurrentGun == (Object)(object)m_gun) && Random.value < chanceToSpawnOnTrigger)
		{
			if (!m_currentlyActive)
			{
				((MonoBehaviour)this).StartCoroutine(HandleTimedDuration());
			}
			else if (TriggerStacking != 0)
			{
				m_resetTimer = true;
			}
		}
	}

	private void OnActiveUsed(PlayerController player, PlayerItem item)
	{
		if ((string.IsNullOrEmpty(RequiredSynergy) || CustomSynergies.PlayerHasActiveSynergy(player, RequiredSynergy)) && (!requiresBaseGunInHand || (Object)(object)((GameActor)player).CurrentGun == (Object)(object)m_gun) && Random.value < chanceToSpawnOnTrigger && (reqActiveItemID == -1 || reqActiveItemID == ((PickupObject)item).PickupObjectId))
		{
			if (!m_currentlyActive)
			{
				((MonoBehaviour)this).StartCoroutine(HandleTimedDuration());
			}
			else if (TriggerStacking != 0)
			{
				m_resetTimer = true;
			}
		}
	}

	private void OnRolled(PlayerController player, Vector2 vec)
	{
		if ((string.IsNullOrEmpty(RequiredSynergy) || CustomSynergies.PlayerHasActiveSynergy(player, RequiredSynergy)) && (!requiresBaseGunInHand || (Object)(object)((GameActor)player).CurrentGun == (Object)(object)m_gun) && Random.value < chanceToSpawnOnTrigger)
		{
			if (!m_currentlyActive)
			{
				((MonoBehaviour)this).StartCoroutine(HandleTimedDuration());
			}
			else if (TriggerStacking != 0)
			{
				m_resetTimer = true;
			}
		}
	}

	private void OnBlanked(PlayerController player, int remainingBlanks)
	{
		if ((string.IsNullOrEmpty(RequiredSynergy) || CustomSynergies.PlayerHasActiveSynergy(player, RequiredSynergy)) && (!requiresBaseGunInHand || (Object)(object)((GameActor)player).CurrentGun == (Object)(object)m_gun) && Random.value < chanceToSpawnOnTrigger)
		{
			if (!m_currentlyActive)
			{
				((MonoBehaviour)this).StartCoroutine(HandleTimedDuration());
			}
			else if (TriggerStacking != 0)
			{
				m_resetTimer = true;
			}
		}
	}

	public void RelinkActions(PlayerController old, PlayerController target)
	{
		if (Object.op_Implicit((Object)(object)old))
		{
			old.OnReceivedDamage -= OnDamaged;
			old.OnUsedPlayerItem -= OnActiveUsed;
			old.OnRollStarted -= OnRolled;
			old.OnUsedBlank -= OnBlanked;
		}
		if (Object.op_Implicit((Object)(object)target))
		{
			if (Trigger == TriggerStyle.ON_DAMAGE)
			{
				target.OnReceivedDamage += OnDamaged;
			}
			else if (Trigger == TriggerStyle.ON_ACTIVE_ITEM)
			{
				target.OnUsedPlayerItem += OnActiveUsed;
			}
			else if (Trigger == TriggerStyle.ON_DODGE_ROLL)
			{
				target.OnRollStarted += OnRolled;
			}
			else if (Trigger == TriggerStyle.ON_BLANKED)
			{
				target.OnUsedBlank += OnBlanked;
			}
		}
	}

	private void OnEnable()
	{
		m_currentlyActive = false;
		shouldHaveGunsLastFrame = false;
	}

	private void OnDisable()
	{
		EraseGuns();
	}

	public void OnDestroy()
	{
		RelinkActions(cachedPlayer, null);
		EraseGuns();
	}

	public static float GetProperShootingSpeed(Gun gun)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Invalid comparison between Unknown and I4
		float num = gun.DefaultModule.cooldownTime;
		if ((int)gun.DefaultModule.shootStyle == 3 && gun.DefaultModule.chargeProjectiles != null)
		{
			num += gun.DefaultModule.chargeProjectiles[0].ChargeTime;
		}
		if (gun.DefaultModule.numberOfShotsInClip <= 1)
		{
			num += gun.reloadTime;
		}
		return num;
	}
}
