using System;
using Alexandria.ItemAPI;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class WoodenKnife : TableFlipItem
{
	public static int ID;

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<WoodenKnife>("Wooden Knife", "Set the Table", "Flipping a table creates 1-3 orbiting knives.\n\nFollowers of the Tabla Sutra would use knives such as these, carved from pure tablewood, for ritual purposes.", "woodenknife_icon", assetbundle: true);
		TableFlipItem val = (TableFlipItem)(object)((obj is TableFlipItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)1;
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)val, (StatType)14, 1f, (ModifyMethod)0);
		ID = ((PickupObject)val).PickupObjectId;
		((PickupObject)(object)val).SetupUnlockOnCustomStat(CustomTrackedStats.BEGGAR_TOTAL_DONATIONS, 314f, (PrerequisiteOperation)2);
	}

	public override void Pickup(PlayerController player)
	{
		player.OnTableFlipped = (Action<FlippableCover>)Delegate.Combine(player.OnTableFlipped, new Action<FlippableCover>(CreateKnives));
		((TableFlipItem)this).Pickup(player);
	}

	public override void DisableEffect(PlayerController player)
	{
		if (Object.op_Implicit((Object)(object)player))
		{
			player.OnTableFlipped = (Action<FlippableCover>)Delegate.Remove(player.OnTableFlipped, new Action<FlippableCover>(CreateKnives));
		}
		((PassiveItem)this).DisableEffect(player);
	}

	private void CreateKnives(FlippableCover obj)
	{
		DoKnoife(isTable: false, null);
		if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Five Finger Fillet"))
		{
			DoKnoife(isTable: true, null);
		}
	}

	public void DoKnoife(bool isTable, GameObject table)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		int numKnives = Random.Range(1, 4);
		if (isTable)
		{
			numKnives = 3;
		}
		GameObject val = new GameObject("knife shield effect");
		val.transform.position = ((PassiveItem)this).Owner.LockedApproximateSpriteCenter;
		val.transform.parent = ((BraveBehaviour)((PassiveItem)this).Owner).transform;
		KnifeShieldEffect val2 = val.AddComponent<KnifeShieldEffect>();
		val2.numKnives = numKnives;
		val2.remainingHealth = 0.5f;
		val2.knifeDamage = 30f;
		val2.circleRadius = (isTable ? 5f : 2f);
		val2.rotationDegreesPerSecond = 360f;
		val2.throwSpeed = 10f;
		val2.throwRange = 25f;
		val2.throwRadius = 3f;
		val2.radiusChangeDistance = 3f;
		ref GameObject deathVFX = ref val2.deathVFX;
		PickupObject byId = PickupObjectDatabase.GetById(65);
		deathVFX = ((KnifeShieldItem)((byId is KnifeShieldItem) ? byId : null)).knifeDeathVFX;
		_003F val3 = val2;
		PlayerController owner = ((PassiveItem)this).Owner;
		PickupObject byId2 = PickupObjectDatabase.GetById(65);
		((KnifeShieldEffect)val3).Initialize(owner, ((KnifeShieldItem)((byId2 is KnifeShieldItem) ? byId2 : null)).knifePrefab);
	}
}
