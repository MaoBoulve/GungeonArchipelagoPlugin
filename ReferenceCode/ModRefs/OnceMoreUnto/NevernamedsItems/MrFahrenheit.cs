using System;
using System.Collections.Generic;
using System.Linq;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

internal class MrFahrenheit : PassiveItem
{
	private int currentItems;

	private int lastItems;

	private DamageTypeModifier m_fireImmunity;

	private static List<GoopDefinition> goopDefs;

	private static string[] goops = new string[2] { "assets/data/goops/napalmgoopthatworks.asset", "assets/data/goops/napalmgoopthatworks.asset" };

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<MrFahrenheit>("Mr. Fahrenheit", "200 Degrees", "Sprint around, leaving a firey trail!\n\nThere's no stopping you!", "mrfahrenheit_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)3;
		AssetBundle val2 = ResourceManager.LoadAssetBundle("shared_auto_001");
		goopDefs = new List<GoopDefinition>();
		string[] array = goops;
		foreach (string text in array)
		{
			GoopDefinition val4;
			try
			{
				Object obj2 = val2.LoadAsset(text);
				GameObject val3 = (GameObject)(object)((obj2 is GameObject) ? obj2 : null);
				val4 = val3.GetComponent<GoopDefinition>();
			}
			catch
			{
				Object obj3 = val2.LoadAsset(text);
				val4 = (GoopDefinition)(object)((obj3 is GoopDefinition) ? obj3 : null);
			}
			((Object)val4).name = text.Replace("assets/data/goops/", "").Replace(".asset", "");
			goopDefs.Add(val4);
		}
		List<GoopDefinition> list = goopDefs;
		Game.Items.Rename("nn:mr._fahrenheit", "nn:mr_fahrenheit");
	}

	public override void Update()
	{
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		if (!Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			return;
		}
		if (!((PassiveItem)this).Owner.IsDodgeRolling && Challenges.CurrentChallenge != ChallengeType.KEEP_IT_COOL)
		{
			if (((PassiveItem)this).Owner.HasPickupID(Game.Items["nn:supersonic_shots"].PickupObjectId))
			{
				PickupObject byId = PickupObjectDatabase.GetById(698);
				GoopDefinition goopDefinition = ((Component)((Gun)((byId is Gun) ? byId : null)).DefaultModule.projectiles[0]).GetComponent<GoopModifier>().goopDefinition;
				DeadlyDeadlyGoopManager goopManagerForGoopType = DeadlyDeadlyGoopManager.GetGoopManagerForGoopType(goopDefinition);
				goopManagerForGoopType.AddGoopCircle(((BraveBehaviour)((PassiveItem)this).Owner).sprite.WorldBottomCenter, 1f, -1, false, -1);
			}
			else
			{
				DeadlyDeadlyGoopManager goopManagerForGoopType2 = DeadlyDeadlyGoopManager.GetGoopManagerForGoopType(goopDefs[0]);
				goopManagerForGoopType2.AddGoopCircle(((BraveBehaviour)((PassiveItem)this).Owner).sprite.WorldBottomCenter, 1f, -1, false, -1);
			}
		}
		currentItems = ((PassiveItem)this).Owner.passiveItems.Count;
		if (currentItems != lastItems)
		{
			if (((PassiveItem)this).Owner.HasPickupID(Game.Items["nn:supersonic_shots"].PickupObjectId))
			{
				handleSpeeds(IncreasedSpeed: true);
			}
			else
			{
				handleSpeeds(IncreasedSpeed: false);
			}
			lastItems = currentItems;
		}
	}

	private void handleSpeeds(bool IncreasedSpeed)
	{
		RemoveStat((StatType)0);
		if (IncreasedSpeed)
		{
			AddStat((StatType)0, 4f, (ModifyMethod)0);
		}
		else
		{
			AddStat((StatType)0, 2f, (ModifyMethod)0);
		}
		((PassiveItem)this).Owner.stats.RecalculateStats(((PassiveItem)this).Owner, true, false);
	}

	private void OnFired(Projectile bullet, float khajhfdjsfhfdjs)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		if (((PickupObject)((GameActor)((PassiveItem)this).Owner).CurrentGun).PickupObjectId == 597 && ((Object)((Component)bullet).gameObject).name == "Planet_Mercury_Projectile(Clone)")
		{
			bullet.AdjustPlayerProjectileTint(ExtendedColours.pink, 1, 0f);
			bullet.AdditionalScaleMultiplier *= 3f;
			bullet.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(bullet.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(ApplyCharmEffect));
		}
	}

	private void ApplyCharmEffect(Projectile bullet, SpeculativeRigidbody target, bool he)
	{
		((GameActor)((BraveBehaviour)target).aiActor).ApplyEffect((GameActorEffect)(object)GameManager.Instance.Dungeon.sharedSettingsPrefab.DefaultPermanentCharmEffect, 1f, (Projectile)null);
	}

	public override void Pickup(PlayerController player)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		((PassiveItem)this).Pickup(player);
		player.PostProcessProjectile += OnFired;
		m_fireImmunity = new DamageTypeModifier();
		m_fireImmunity.damageMultiplier = 0f;
		m_fireImmunity.damageType = (CoreDamageTypes)4;
		((BraveBehaviour)((PassiveItem)this).Owner).healthHaver.damageTypeModifiers.Add(m_fireImmunity);
	}

	public override DebrisObject Drop(PlayerController player)
	{
		player.PostProcessProjectile -= OnFired;
		((BraveBehaviour)((PassiveItem)this).Owner).healthHaver.damageTypeModifiers.Remove(m_fireImmunity);
		return ((PassiveItem)this).Drop(player);
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			((BraveBehaviour)((PassiveItem)this).Owner).healthHaver.damageTypeModifiers.Remove(m_fireImmunity);
			((PassiveItem)this).Owner.PostProcessProjectile -= OnFired;
		}
		((PassiveItem)this).OnDestroy();
	}

	private void AddStat(StatType statType, float amount, ModifyMethod method = 0)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected O, but got Unknown
		StatModifier val = new StatModifier
		{
			amount = amount,
			statToBoost = statType,
			modifyType = method
		};
		if (base.passiveStatModifiers == null)
		{
			base.passiveStatModifiers = (StatModifier[])(object)new StatModifier[1] { val };
		}
		else
		{
			base.passiveStatModifiers = base.passiveStatModifiers.Concat((IEnumerable<StatModifier>)(object)new StatModifier[1] { val }).ToArray();
		}
	}

	private void RemoveStat(StatType statType)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		List<StatModifier> list = new List<StatModifier>();
		for (int i = 0; i < base.passiveStatModifiers.Length; i++)
		{
			if (base.passiveStatModifiers[i].statToBoost != statType)
			{
				list.Add(base.passiveStatModifiers[i]);
			}
		}
		base.passiveStatModifiers = list.ToArray();
	}
}
