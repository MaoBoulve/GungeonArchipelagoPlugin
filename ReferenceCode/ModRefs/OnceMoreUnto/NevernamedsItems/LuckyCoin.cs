using System;
using System.Collections.Generic;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

internal class LuckyCoin : PlayerItem
{
	public static int LuckyCoinID;

	private bool GoodEffectActive = false;

	private bool BadEffectActive = false;

	private float movementBuff = -1f;

	private float movementDeBuff = -1f;

	private float damageBuff = -1f;

	private float damageDeBuff = -1f;

	private float duration = 25f;

	public static void Init()
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<LuckyCoin>("Lucky Coin", "Heads or Tails", "50/50 change for a temporary stat bonus or a temporary stat penalty when used.\n\nLegends tell of a time when coins such as this one were commonplace in the gungeon. They've since been exchanged for more...modern currency.", "luckycoin_icon", assetbundle: true);
		PlayerItem val = (PlayerItem)(object)((obj is PlayerItem) ? obj : null);
		ItemBuilder.SetCooldownType(val, (CooldownType)1, 500f);
		val.consumable = false;
		((PickupObject)val).quality = (ItemQuality)2;
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)2, 1f);
		List<string> list = new List<string> { "nn:lucky_coin", "seven_leaf_clover" };
		CustomSynergies.Add("Even Luckier!", list, (List<string>)null, true);
		AlexandriaTags.SetTag((PickupObject)(object)val, "lucky");
		LuckyCoinID = ((PickupObject)val).PickupObjectId;
	}

	public override void DoEffect(PlayerController user)
	{
		//IL_03b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_0413: Unknown result type (might be due to invalid IL or missing references)
		//IL_0418: Unknown result type (might be due to invalid IL or missing references)
		//IL_041d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0442: Unknown result type (might be due to invalid IL or missing references)
		//IL_0447: Unknown result type (might be due to invalid IL or missing references)
		//IL_044c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0471: Unknown result type (might be due to invalid IL or missing references)
		//IL_0476: Unknown result type (might be due to invalid IL or missing references)
		//IL_047b: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0503: Unknown result type (might be due to invalid IL or missing references)
		//IL_0508: Unknown result type (might be due to invalid IL or missing references)
		//IL_052d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0532: Unknown result type (might be due to invalid IL or missing references)
		//IL_0537: Unknown result type (might be due to invalid IL or missing references)
		//IL_055c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0561: Unknown result type (might be due to invalid IL or missing references)
		//IL_0566: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0210: Unknown result type (might be due to invalid IL or missing references)
		//IL_0215: Unknown result type (might be due to invalid IL or missing references)
		//IL_021a: Unknown result type (might be due to invalid IL or missing references)
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0244: Unknown result type (might be due to invalid IL or missing references)
		//IL_0249: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0273: Unknown result type (might be due to invalid IL or missing references)
		//IL_0278: Unknown result type (might be due to invalid IL or missing references)
		if (user.HasPickupID(289))
		{
			if (Random.value > 0.25f)
			{
				GoodEffectActive = true;
				AkSoundEngine.PostEvent("luckyvoice", ((Component)this).gameObject);
				if (user.HasPickupID(Game.Items["nn:lump_of_space_metal"].PickupObjectId) || user.HasPickupID(Game.Items["nn:loose_change"].PickupObjectId) || user.HasPickupID(214) || user.HasPickupID(272) || user.HasPickupID(614) || user.HasPickupID(397))
				{
					LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetById(68)).gameObject, Vector2.op_Implicit(((BraveBehaviour)user).specRigidbody.UnitCenter), Vector2.zero, 1f, false, true, false);
					LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetById(68)).gameObject, Vector2.op_Implicit(((BraveBehaviour)user).specRigidbody.UnitCenter), Vector2.zero, 1f, false, true, false);
					LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetById(68)).gameObject, Vector2.op_Implicit(((BraveBehaviour)user).specRigidbody.UnitCenter), Vector2.zero, 1f, false, true, false);
					LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetById(68)).gameObject, Vector2.op_Implicit(((BraveBehaviour)user).specRigidbody.UnitCenter), Vector2.zero, 1f, false, true, false);
					LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetById(68)).gameObject, Vector2.op_Implicit(((BraveBehaviour)user).specRigidbody.UnitCenter), Vector2.zero, 1f, false, true, false);
					LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetById(68)).gameObject, Vector2.op_Implicit(((BraveBehaviour)user).specRigidbody.UnitCenter), Vector2.zero, 1f, false, true, false);
					LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetById(68)).gameObject, Vector2.op_Implicit(((BraveBehaviour)user).specRigidbody.UnitCenter), Vector2.zero, 1f, false, true, false);
					LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetById(68)).gameObject, Vector2.op_Implicit(((BraveBehaviour)user).specRigidbody.UnitCenter), Vector2.zero, 1f, false, true, false);
					LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetById(68)).gameObject, Vector2.op_Implicit(((BraveBehaviour)user).specRigidbody.UnitCenter), Vector2.zero, 1f, false, true, false);
					LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetById(68)).gameObject, Vector2.op_Implicit(((BraveBehaviour)user).specRigidbody.UnitCenter), Vector2.zero, 1f, false, true, false);
				}
				StartGoodEffect(user);
				((MonoBehaviour)this).StartCoroutine(ItemBuilder.HandleDuration((PlayerItem)(object)this, duration, user, (Action<PlayerController>)EndGoodEffect));
			}
			else
			{
				BadEffectActive = true;
				AkSoundEngine.PostEvent("unluckyvoice", ((Component)this).gameObject);
				StartBadEffect(user);
				((MonoBehaviour)this).StartCoroutine(ItemBuilder.HandleDuration((PlayerItem)(object)this, duration, user, (Action<PlayerController>)EndBadEffect));
			}
		}
		else if (Random.value < 0.5f)
		{
			GoodEffectActive = true;
			AkSoundEngine.PostEvent("luckyvoice", ((Component)this).gameObject);
			if (user.HasPickupID(Game.Items["nn:lump_of_space_metal"].PickupObjectId) || user.HasPickupID(Game.Items["nn:loose_change"].PickupObjectId) || user.HasPickupID(214) || user.HasPickupID(272) || user.HasPickupID(614) || user.HasPickupID(397))
			{
				LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetById(68)).gameObject, Vector2.op_Implicit(((BraveBehaviour)user).specRigidbody.UnitCenter), Vector2.zero, 1f, false, true, false);
				LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetById(68)).gameObject, Vector2.op_Implicit(((BraveBehaviour)user).specRigidbody.UnitCenter), Vector2.zero, 1f, false, true, false);
				LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetById(68)).gameObject, Vector2.op_Implicit(((BraveBehaviour)user).specRigidbody.UnitCenter), Vector2.zero, 1f, false, true, false);
				LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetById(68)).gameObject, Vector2.op_Implicit(((BraveBehaviour)user).specRigidbody.UnitCenter), Vector2.zero, 1f, false, true, false);
				LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetById(68)).gameObject, Vector2.op_Implicit(((BraveBehaviour)user).specRigidbody.UnitCenter), Vector2.zero, 1f, false, true, false);
				LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetById(68)).gameObject, Vector2.op_Implicit(((BraveBehaviour)user).specRigidbody.UnitCenter), Vector2.zero, 1f, false, true, false);
				LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetById(68)).gameObject, Vector2.op_Implicit(((BraveBehaviour)user).specRigidbody.UnitCenter), Vector2.zero, 1f, false, true, false);
				LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetById(68)).gameObject, Vector2.op_Implicit(((BraveBehaviour)user).specRigidbody.UnitCenter), Vector2.zero, 1f, false, true, false);
				LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetById(68)).gameObject, Vector2.op_Implicit(((BraveBehaviour)user).specRigidbody.UnitCenter), Vector2.zero, 1f, false, true, false);
				LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetById(68)).gameObject, Vector2.op_Implicit(((BraveBehaviour)user).specRigidbody.UnitCenter), Vector2.zero, 1f, false, true, false);
			}
			StartGoodEffect(user);
			((MonoBehaviour)this).StartCoroutine(ItemBuilder.HandleDuration((PlayerItem)(object)this, duration, user, (Action<PlayerController>)EndGoodEffect));
		}
		else
		{
			BadEffectActive = true;
			AkSoundEngine.PostEvent("unluckyvoice", ((Component)this).gameObject);
			StartBadEffect(user);
			((MonoBehaviour)this).StartCoroutine(ItemBuilder.HandleDuration((PlayerItem)(object)this, duration, user, (Action<PlayerController>)EndBadEffect));
		}
	}

	private void StartGoodEffect(PlayerController user)
	{
		float baseStatValue = user.stats.GetBaseStatValue((StatType)0);
		float num = baseStatValue * 1.3f;
		user.stats.SetBaseStatValue((StatType)0, num, user);
		movementBuff = num - baseStatValue;
		float baseStatValue2 = user.stats.GetBaseStatValue((StatType)5);
		float num2 = baseStatValue2 * 2f;
		user.stats.SetBaseStatValue((StatType)5, num2, user);
		damageBuff = num2 - baseStatValue2;
	}

	private void StartBadEffect(PlayerController user)
	{
		((PickupObject)this).CanBeDropped = false;
		float baseStatValue = user.stats.GetBaseStatValue((StatType)0);
		float num = baseStatValue * 0.7f;
		user.stats.SetBaseStatValue((StatType)0, num, user);
		movementDeBuff = baseStatValue - num;
		float baseStatValue2 = user.stats.GetBaseStatValue((StatType)5);
		float num2 = baseStatValue2 * 0.5f;
		user.stats.SetBaseStatValue((StatType)5, num2, user);
		damageDeBuff = baseStatValue2 - num2;
	}

	private void EndGoodEffect(PlayerController user)
	{
		if (movementBuff <= 0f)
		{
			ETGModConsole.Log((object)("The variable 'movementBuff' is less than or equal to 0 (" + movementBuff + ")"), false);
			return;
		}
		float baseStatValue = user.stats.GetBaseStatValue((StatType)0);
		float num = baseStatValue - movementBuff;
		user.stats.SetBaseStatValue((StatType)0, num, user);
		movementBuff = -1f;
		GoodEffectActive = false;
		if (damageBuff <= 0f)
		{
			ETGModConsole.Log((object)("The variable 'damageBuff' is less than or equal to 0 (" + damageBuff + ")"), false);
			return;
		}
		float baseStatValue2 = user.stats.GetBaseStatValue((StatType)5);
		float num2 = baseStatValue2 - damageBuff;
		user.stats.SetBaseStatValue((StatType)5, num2, user);
		damageBuff = -1f;
	}

	private void EndBadEffect(PlayerController user)
	{
		if (!(movementDeBuff <= 0f))
		{
			float baseStatValue = user.stats.GetBaseStatValue((StatType)0);
			float num = baseStatValue + movementDeBuff;
			user.stats.SetBaseStatValue((StatType)0, num, user);
			movementDeBuff = -1f;
			BadEffectActive = false;
			if (!(damageDeBuff <= 0f))
			{
				float baseStatValue2 = user.stats.GetBaseStatValue((StatType)5);
				float num2 = baseStatValue2 + damageDeBuff;
				user.stats.SetBaseStatValue((StatType)5, num2, user);
				damageDeBuff = -1f;
				((PickupObject)this).CanBeDropped = true;
			}
		}
	}

	public override void OnPreDrop(PlayerController user)
	{
		if (((PlayerItem)this).IsCurrentlyActive)
		{
			((PlayerItem)this).IsCurrentlyActive = false;
			if (GoodEffectActive)
			{
				EndGoodEffect(user);
			}
			else if (BadEffectActive)
			{
				EndBadEffect(user);
			}
		}
	}
}
