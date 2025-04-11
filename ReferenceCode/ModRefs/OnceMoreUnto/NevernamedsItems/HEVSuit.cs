using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

internal class HEVSuit : PassiveItem
{
	[CompilerGenerated]
	private sealed class _003CSayLines_003Ed__9 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public List<string> lines;

		public GameObject audioSource;

		public float initialDelay;

		public HEVSuit _003C_003E4__this;

		private List<string>.Enumerator _003C_003Es__1;

		private string _003Cline_003E5__2;

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
		public _003CSayLines_003Ed__9(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int num = _003C_003E1__state;
			if (num == -3 || num == 2)
			{
				try
				{
				}
				finally
				{
					_003C_003Em__Finally1();
				}
			}
			_003C_003Es__1 = default(List<string>.Enumerator);
			_003Cline_003E5__2 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_004a: Expected O, but got Unknown
			//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d1: Expected O, but got Unknown
			try
			{
				switch (_003C_003E1__state)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					speaking = true;
					_003C_003E2__current = (object)new WaitForSeconds(initialDelay);
					_003C_003E1__state = 1;
					return true;
				case 1:
					_003C_003E1__state = -1;
					_003C_003Es__1 = lines.GetEnumerator();
					_003C_003E1__state = -3;
					goto IL_00ed;
				case 2:
					{
						_003C_003E1__state = -3;
						goto IL_00e5;
					}
					IL_00ed:
					if (_003C_003Es__1.MoveNext())
					{
						_003Cline_003E5__2 = _003C_003Es__1.Current;
						if ((Object)(object)audioSource != (Object)null)
						{
							AkSoundEngine.PostEvent(_003Cline_003E5__2, audioSource);
							_003C_003E2__current = (object)new WaitForSeconds(_003C_003E4__this.Dialogue[_003Cline_003E5__2]);
							_003C_003E1__state = 2;
							return true;
						}
						goto IL_00e5;
					}
					_003C_003Em__Finally1();
					_003C_003Es__1 = default(List<string>.Enumerator);
					speaking = false;
					return false;
					IL_00e5:
					_003Cline_003E5__2 = null;
					goto IL_00ed;
				}
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private void _003C_003Em__Finally1()
		{
			_003C_003E1__state = -1;
			((IDisposable)_003C_003Es__1/*cast due to .constrained prefix*/).Dispose();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}
	}

	public static List<string> criticalDamageFollowups = new List<string> { "HEV_vitalsdropping", "HEV_vitalscritical", "HEV_seekmedical" };

	public static List<string> damageFollowups = new List<string> { "HEV_automed", "HEV_morphine" };

	public static List<string> poisonDialogue = new List<string> { "HEV_hazchem", "HEV_biohazard" };

	public static List<string> regDamageResponses = new List<string> { "HEV_bloodloss", "HEV_majorlacerations", "HEV_minorlacerations", "HEV_minorfracture", "HEV_majorfracture" };

	public Dictionary<string, float> Dialogue = new Dictionary<string, float>
	{
		{ "HEV_intro", 13f },
		{ "HEV_ammo", 2f },
		{ "HEV_death", 6f },
		{ "HEV_beep", 1.5f },
		{ "HEV_bloodloss", 2.25f },
		{ "HEV_automed", 3.5f },
		{ "HEV_vitalsdropping", 3f },
		{ "HEV_vitalscritical", 3.25f },
		{ "HEV_deathimminent", 3.75f },
		{ "HEV_majorlacerations", 3f },
		{ "HEV_minorlacerations", 3f },
		{ "HEV_minorfracture", 2.5f },
		{ "HEV_morphine", 2f },
		{ "HEV_seekmedical", 2.5f },
		{ "HEV_majorfracture", 2.5f },
		{ "HEV_hazchem", 3.5f },
		{ "HEV_fire", 4f },
		{ "HEV_biohazard", 3.25f }
	};

	private static bool speaking = false;

	private DamageTypeModifier fireImmunity;

	private DamageTypeModifier poisonImmunity;

	private DamageTypeModifier electricImmunity;

	private float timeSinceLastDamageMessage = 0f;

	private float timeSinceLastGoopMessage = 0f;

	private bool wasInGoopLastFrame = false;

	private bool wasOnFireLastFrame = false;

	private Gun lastGun;

	private int lastAmmo;

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<HEVSuit>("Hazardous Environment Suit Mk. 4", "You've Earned It", "A highly advanced protective suit for scientific research and surveying in hazardous environments.\n\nDeveloped by Primerdyne R&D, this suit was presumed lost in the incident- until it appeared in the Gungeon under unknown circumstances...", "hevsuit_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)4;
		val.ArmorToGainOnInitialPickup = 1;
	}

	private void OnDamaged(PlayerController user)
	{
		int num = Mathf.RoundToInt(((BraveBehaviour)user).healthHaver.currentHealth / 0.5f);
		num += (int)((BraveBehaviour)user).healthHaver.Armor;
		List<string> list = new List<string>();
		list.Add("HEV_beep");
		list.Add(BraveUtility.RandomElement<string>(regDamageResponses));
		if (num <= 1)
		{
			list.Add("HEV_deathimminent");
		}
		else if (num <= 4)
		{
			list.Add(BraveUtility.RandomElement<string>(criticalDamageFollowups));
		}
		else
		{
			list.Add(BraveUtility.RandomElement<string>(damageFollowups));
		}
		if (num > 0)
		{
			if (timeSinceLastDamageMessage > 5f)
			{
				timeSinceLastDamageMessage = 0f;
				Speak(list);
			}
		}
		else
		{
			speaking = true;
			AkSoundEngine.PostEvent("HEV_death", ((Object)(object)user != (Object)null) ? ((Component)user).gameObject : ((Component)this).gameObject);
		}
	}

	private void Speak(List<string> lines, float initidalDelay = 0f)
	{
		if (!speaking)
		{
			GameObject audioSource = (((Object)(object)((PassiveItem)this).Owner != (Object)null) ? ((Component)((PassiveItem)this).Owner).gameObject : ((Component)this).gameObject);
			((MonoBehaviour)GameManager.Instance).StartCoroutine(SayLines(lines, audioSource, initidalDelay));
		}
	}

	private IEnumerator SayLines(List<string> lines, GameObject audioSource, float initialDelay = 0f)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CSayLines_003Ed__9(0)
		{
			_003C_003E4__this = this,
			lines = lines,
			audioSource = audioSource,
			initialDelay = initialDelay
		};
	}

	public override void Pickup(PlayerController player)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Expected O, but got Unknown
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		if (!base.m_pickedUpThisRun)
		{
			Speak(new List<string> { "HEV_intro" });
		}
		if (fireImmunity == null)
		{
			fireImmunity = new DamageTypeModifier();
			fireImmunity.damageMultiplier = 0.2f;
			fireImmunity.damageType = (CoreDamageTypes)4;
		}
		if (poisonImmunity == null)
		{
			poisonImmunity = new DamageTypeModifier();
			poisonImmunity.damageMultiplier = 0f;
			poisonImmunity.damageType = (CoreDamageTypes)16;
		}
		if (electricImmunity == null)
		{
			electricImmunity = new DamageTypeModifier();
			electricImmunity.damageMultiplier = 0f;
			electricImmunity.damageType = (CoreDamageTypes)64;
		}
		player.OnReceivedDamage += OnDamaged;
		if (Object.op_Implicit((Object)(object)((BraveBehaviour)player).healthHaver))
		{
			((BraveBehaviour)player).healthHaver.damageTypeModifiers.Add(fireImmunity);
			((BraveBehaviour)player).healthHaver.damageTypeModifiers.Add(poisonImmunity);
			((BraveBehaviour)player).healthHaver.damageTypeModifiers.Add(electricImmunity);
			HealthHaver healthHaver = ((BraveBehaviour)player).healthHaver;
			healthHaver.ModifyDamage = (Action<HealthHaver, ModifyDamageEventArgs>)Delegate.Combine(healthHaver.ModifyDamage, new Action<HealthHaver, ModifyDamageEventArgs>(ModifyDamage));
		}
		((PassiveItem)this).Pickup(player);
	}

	private void ModifyDamage(HealthHaver player, ModifyDamageEventArgs args)
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		if (((BraveBehaviour)player).gameActor is PlayerController && Random.value <= 0.15f)
		{
			GameActor gameActor = ((BraveBehaviour)player).gameActor;
			PlayerController val = (PlayerController)(object)((gameActor is PlayerController) ? gameActor : null);
			args.ModifiedDamage = 0f;
			PlayerUtility.DoEasyBlank(val, ((GameActor)val).CenterPosition, (EasyBlankType)0);
			if ((Object)(object)PlayerUtility.GetExtComp(val) != (Object)null)
			{
				PlayerUtility.GetExtComp(val).TriggerInvulnerableFrames(0.8f, true);
			}
		}
	}

	public override void DisableEffect(PlayerController player)
	{
		if (Object.op_Implicit((Object)(object)player))
		{
			player.OnReceivedDamage -= OnDamaged;
		}
		if (Object.op_Implicit((Object)(object)((BraveBehaviour)player).healthHaver))
		{
			((BraveBehaviour)player).healthHaver.damageTypeModifiers.Remove(fireImmunity);
			((BraveBehaviour)player).healthHaver.damageTypeModifiers.Remove(poisonImmunity);
			((BraveBehaviour)player).healthHaver.damageTypeModifiers.Remove(electricImmunity);
			HealthHaver healthHaver = ((BraveBehaviour)player).healthHaver;
			healthHaver.ModifyDamage = (Action<HealthHaver, ModifyDamageEventArgs>)Delegate.Remove(healthHaver.ModifyDamage, new Action<HealthHaver, ModifyDamageEventArgs>(ModifyDamage));
		}
		((PassiveItem)this).DisableEffect(player);
	}

	public override void Update()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			timeSinceLastDamageMessage += BraveTime.DeltaTime;
			timeSinceLastGoopMessage += BraveTime.DeltaTime;
			if (Object.op_Implicit((Object)(object)((GameActor)((PassiveItem)this).Owner).CurrentGun) && (Object)(object)((GameActor)((PassiveItem)this).Owner).CurrentGun == (Object)(object)lastGun && ((GameActor)((PassiveItem)this).Owner).CurrentGun.ammo != lastAmmo)
			{
				lastAmmo = ((GameActor)((PassiveItem)this).Owner).CurrentGun.ammo;
				if (((GameActor)((PassiveItem)this).Owner).CurrentGun.ammo == 0)
				{
					Speak(new List<string> { "HEV_ammo" });
				}
			}
			lastGun = ((GameActor)((PassiveItem)this).Owner).CurrentGun;
			if (((PassiveItem)this).Owner.IsOnFire && !wasOnFireLastFrame)
			{
				Speak(new List<string> { "HEV_beep", "HEV_fire" });
			}
			wasOnFireLastFrame = ((PassiveItem)this).Owner.IsOnFire;
			if ((Object)(object)((GameActor)((PassiveItem)this).Owner).CurrentGoop != (Object)null && !wasInGoopLastFrame && timeSinceLastGoopMessage > 20f && ((GameActor)((PassiveItem)this).Owner).CurrentGoop.AppliesDamageOverTime && ((GameActor)((PassiveItem)this).Owner).CurrentGoop.HealthModifierEffect != null)
			{
				Speak(new List<string> { BraveUtility.RandomElement<string>(poisonDialogue) });
				timeSinceLastGoopMessage = 0f;
			}
			wasInGoopLastFrame = (Object)(object)((GameActor)((PassiveItem)this).Owner).CurrentGoop != (Object)null;
		}
		((PassiveItem)this).Update();
	}
}
