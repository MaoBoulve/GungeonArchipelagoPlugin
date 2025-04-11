using System;
using System.Collections.Generic;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class TimeFuddlersRobe : PassiveItem
{
	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<TimeFuddlersRobe>("Time Fuddler's Robe", "Timeline Twister", "Chance to freeze time upon killing an enemy.\n\nThe robes of a young bullet who broke the timeline so badly that even his garments maintain an echo of the events.", "timefuddlersrobe_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)4;
		List<string> list = new List<string> { "nn:time_fuddler's_robe" };
		List<string> list2 = new List<string> { "pig", "bullet_time" };
		CustomSynergies.Add("Epsiode", list, list2, true);
	}

	protected void activateSlow(PlayerController user)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		RadialSlowInterface val = new RadialSlowInterface();
		val.DoesSepia = false;
		val.RadialSlowHoldTime = 3f;
		val.RadialSlowTimeModifier = 0.01f;
		val.DoRadialSlow(((BraveBehaviour)user).specRigidbody.UnitCenter, user.CurrentRoom);
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

	private void OnEnemyDamaged(float damage, bool fatal, HealthHaver enemyHealth)
	{
		if (!(Object.op_Implicit((Object)(object)((BraveBehaviour)enemyHealth).aiActor) && Object.op_Implicit((Object)(object)enemyHealth) && !enemyHealth.IsBoss && fatal) || !Object.op_Implicit((Object)(object)((BraveBehaviour)enemyHealth).aiActor) || !((BraveBehaviour)enemyHealth).aiActor.IsNormalEnemy)
		{
			return;
		}
		if (((PassiveItem)this).Owner.HasPickupID(69) || ((PassiveItem)this).Owner.HasPickupID(451))
		{
			if ((double)Random.value < 0.35)
			{
				activateSlow(((PassiveItem)this).Owner);
			}
		}
		else if ((double)Random.value < 0.15)
		{
			activateSlow(((PassiveItem)this).Owner);
		}
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
}
