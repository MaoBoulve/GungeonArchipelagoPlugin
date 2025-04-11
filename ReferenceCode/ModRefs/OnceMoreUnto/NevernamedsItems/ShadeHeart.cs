using System;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Alexandria.TranslationAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class ShadeHeart : PassiveItem
{
	private float currentArmour;

	private float lastArmour;

	private bool hasDoneFirstArmourResetThisRun = false;

	private DamageTypeModifier m_poisonImmunity;

	private DamageTypeModifier m_fireImmunity;

	public static void Init()
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		string text = "Shade Heart";
		GameObject val = new GameObject(text);
		ShadeHeart shadeHeart = val.AddComponent<ShadeHeart>();
		ItemBuilder.AddSpriteToObjectAssetbundle(text, Initialisation.itemCollection.GetSpriteIdByName("shadeheart_icon"), Initialisation.itemCollection, val);
		string text2 = "Heart of Darkness";
		string text3 = "The ventricles of this shadowy organ are paper-thin, and ripple with a strange otherworldly energy.\n\nThough fragile, it holds fantastic power.";
		ItemBuilder.SetupItem((PickupObject)(object)shadeHeart, text2, text3, "nn");
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)shadeHeart, (StatType)11, 10f, (ModifyMethod)0);
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)shadeHeart, (StatType)23, 0.95f, (ModifyMethod)1);
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)shadeHeart, (StatType)13, 0.7f, (ModifyMethod)1);
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)shadeHeart, (StatType)18, 1f, (ModifyMethod)0);
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)shadeHeart, (StatType)4, 4f, (ModifyMethod)0);
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)shadeHeart, (StatType)8, 1f, (ModifyMethod)0);
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)shadeHeart, (StatType)5, 1.1f, (ModifyMethod)1);
		((PickupObject)shadeHeart).quality = (ItemQuality)(-100);
		((PickupObject)shadeHeart).CanBeDropped = false;
		TranslationManager.TranslateItemName((PickupObject)(object)shadeHeart, (GungeonSupportedLanguages)9, "Теневое Сердце");
		TranslationManager.TranslateItemShortDescription((PickupObject)(object)shadeHeart, (GungeonSupportedLanguages)9, "Сердце Тьмы");
		TranslationManager.TranslateItemLongDescription((PickupObject)(object)shadeHeart, (GungeonSupportedLanguages)9, "Тонкие, как бумага, стенки этого тёмного сосуда излучают энергию прямиком из другого мира.\n\nИ хотя оно хрупкое, внутри него заточена огромная сила.");
	}

	public override void Update()
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			CalculateHealth(((PassiveItem)this).Owner);
			string overridePlayerSwitchState = ((PassiveItem)this).Owner.OverridePlayerSwitchState;
			PlayableCharacters val = (PlayableCharacters)0;
			if (overridePlayerSwitchState != ((object)(PlayableCharacters)(ref val)/*cast due to .constrained prefix*/).ToString())
			{
				PlayerController owner = ((PassiveItem)this).Owner;
				val = (PlayableCharacters)0;
				owner.OverridePlayerSwitchState = ((object)(PlayableCharacters)(ref val)/*cast due to .constrained prefix*/).ToString();
			}
		}
	}

	private void CalculateHealth(PlayerController player)
	{
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		currentArmour = ((BraveBehaviour)player).healthHaver.Armor;
		if (currentArmour == lastArmour)
		{
			return;
		}
		if (((BraveBehaviour)player).healthHaver.Armor > 1f)
		{
			if (hasDoneFirstArmourResetThisRun)
			{
				int num = (int)((BraveBehaviour)player).healthHaver.Armor - 1;
				float num2 = 0.025f;
				if (player.HasPickupID(FullArmourJacket.FullArmourJacketID))
				{
					num2 = 0.05f;
				}
				StatModifier val = new StatModifier();
				val.amount = num2 * (float)num + 1f;
				val.modifyType = (ModifyMethod)1;
				val.statToBoost = (StatType)5;
				((PassiveItem)this).Owner.ownerlessStatModifiers.Add(val);
				((PassiveItem)this).Owner.stats.RecalculateStats(((PassiveItem)this).Owner, false, false);
				LootEngine.SpawnCurrency(((GameActor)((PassiveItem)this).Owner).CenterPosition, 15 * num, false);
			}
			hasDoneFirstArmourResetThisRun = true;
			((BraveBehaviour)player).healthHaver.Armor = 1f;
		}
		lastArmour = currentArmour;
	}

	public void OnNudgedHP(PlayerController playerCont, HealthPickup self)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		if (self.armorAmount <= 0 && self.healAmount > 0f)
		{
			if (playerCont.HasPickupID(BloodshotEye.BloodshotEyeID))
			{
				float num = 0.02f;
				StatModifier val = new StatModifier();
				val.amount = num * (float)Mathf.CeilToInt(self.healAmount / 0.5f) + 1f;
				val.modifyType = (ModifyMethod)1;
				val.statToBoost = (StatType)5;
				playerCont.ownerlessStatModifiers.Add(val);
				playerCont.stats.RecalculateStats(playerCont, false, false);
			}
			self.m_pickedUp = true;
			AkSoundEngine.PostEvent("Play_OBJ_coin_medium_01", ((Component)self).gameObject);
			int num2 = ((self.healAmount >= 1f) ? Random.Range(5, 12) : Random.Range(3, 7));
			LootEngine.SpawnCurrency((!Object.op_Implicit((Object)(object)((BraveBehaviour)self).sprite)) ? ((BraveBehaviour)self).specRigidbody.UnitCenter : ((BraveBehaviour)self).sprite.WorldCenter, num2, false);
			self.GetRidOfMinimapIcon();
			self.ToggleLabel(false);
			Object.Destroy((Object)(object)((Component)self).gameObject);
		}
	}

	public override void Pickup(PlayerController player)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		m_poisonImmunity = new DamageTypeModifier();
		m_poisonImmunity.damageMultiplier = 0f;
		m_poisonImmunity.damageType = (CoreDamageTypes)16;
		((BraveBehaviour)player).healthHaver.damageTypeModifiers.Add(m_poisonImmunity);
		m_fireImmunity = new DamageTypeModifier();
		m_fireImmunity.damageMultiplier = 0f;
		m_fireImmunity.damageType = (CoreDamageTypes)4;
		((BraveBehaviour)player).healthHaver.damageTypeModifiers.Add(m_fireImmunity);
		player.ImmuneToPits.SetOverride("ShadeHeart", true, (float?)null);
		((GameActor)player).SetIsFlying(true, "Shadeheart", false, false);
		player.AdditionalCanDodgeRollWhileFlying.AddOverride("Shadeheart", (float?)null);
		ExtendedPlayerComponent extComp = PlayerUtility.GetExtComp(player);
		extComp.OnNudgedHP = (Action<PlayerController, HealthPickup>)Delegate.Combine(extComp.OnNudgedHP, new Action<PlayerController, HealthPickup>(OnNudgedHP));
		((PassiveItem)this).Pickup(player);
	}

	public override void DisableEffect(PlayerController player)
	{
		((BraveBehaviour)player).healthHaver.damageTypeModifiers.Remove(m_poisonImmunity);
		((BraveBehaviour)player).healthHaver.damageTypeModifiers.Remove(m_fireImmunity);
		player.ImmuneToPits.SetOverride("ShadeHeart", false, (float?)null);
		((GameActor)player).SetIsFlying(false, "Shadeheart", false, false);
		player.AdditionalCanDodgeRollWhileFlying.RemoveOverride("Shadeheart");
		ExtendedPlayerComponent extComp = PlayerUtility.GetExtComp(player);
		extComp.OnNudgedHP = (Action<PlayerController, HealthPickup>)Delegate.Remove(extComp.OnNudgedHP, new Action<PlayerController, HealthPickup>(OnNudgedHP));
		((PassiveItem)this).DisableEffect(player);
	}
}
