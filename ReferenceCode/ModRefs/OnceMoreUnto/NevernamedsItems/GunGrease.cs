using System;
using System.Collections.Generic;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

internal class GunGrease : PassiveItem
{
	public static int GunGreaseID;

	private int goopNumber;

	private float goopRadius;

	private static List<GoopDefinition> goopDefs;

	private static string[] goops = new string[2] { "assets/data/goops/oil goop.asset", "assets/data/goops/napalmgoopthatworks.asset" };

	public static void Init()
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<GunGrease>("Gun Grease", "Slippery Slope", "Slightly increases reload speed.\n\nSlathering your weapons in this fluid makes them function smoother, and it also seems to transfer a significant amount of oiley muck to your target. If only you had some way to set it alight.", "gungrease_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)val, (StatType)10, 0.85f, (ModifyMethod)1);
		((PickupObject)val).quality = (ItemQuality)1;
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)3, 1f);
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)0, 1f);
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
		GunGreaseID = ((PickupObject)val).PickupObjectId;
	}

	private void OnEnemyDamaged(float damage, bool fatal, HealthHaver enemyHealth)
	{
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)((BraveBehaviour)enemyHealth).aiActor) && fatal)
		{
			if (((PassiveItem)this).Owner.HasPickupID(242) || ((PassiveItem)this).Owner.HasPickupID(443) || ((PassiveItem)this).Owner.HasPickupID(295) || ((PassiveItem)this).Owner.HasPickupID(191) || ((PassiveItem)this).Owner.HasPickupID(253))
			{
				goopNumber = 1;
			}
			else
			{
				goopNumber = 0;
			}
			if (((PassiveItem)this).Owner.HasPickupID(Game.Items["nn:sanctified_oil"].PickupObjectId) || ((PassiveItem)this).Owner.HasPickupID(165))
			{
				goopRadius = 6f;
			}
			else
			{
				goopRadius = 3f;
			}
			float num = 1f;
			DeadlyDeadlyGoopManager.GetGoopManagerForGoopType(goopDefs[goopNumber]).TimedAddGoopCircle(((BraveBehaviour)enemyHealth).specRigidbody.UnitCenter, goopRadius, num, false);
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
