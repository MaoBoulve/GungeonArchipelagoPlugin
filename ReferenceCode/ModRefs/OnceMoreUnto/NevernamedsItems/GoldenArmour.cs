using System;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class GoldenArmour : PassiveItem
{
	public static int GoldenArmourID;

	public static GameObject vfx;

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<GoldenArmour>("Golden Armour", "You Can't Take It With You", "If the bearer has money, and takes damage that would kill them, the cash has a chance to take the hit instead.\n\nGold is a soft metal, and doesn't make for very good protection. Whoever decided to make gold armour probably isn't very smart.\n\nActivation chance is equal to cash amount. More than 100 cash guarantees a safety net.", "goldenarmour_improved", assetbundle: true);
		val.quality = (ItemQuality)1;
		GoldenArmourID = val.PickupObjectId;
		vfx = VFXToolbox.CreateVFXBundle("GoldenArmourBreak", new IntVector2(32, 22), (Anchor)4, usesZHeight: true, 2f, -1f, null);
	}

	private void ModifyIncomingDamage(HealthHaver source, ModifyDamageEventArgs args)
	{
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		if (!(source.GetCurrentHealth() <= args.InitialDamage) || !(source.Armor <= (float)(((PassiveItem)this).Owner.ForceZeroHealthState ? 1 : 0)))
		{
			return;
		}
		int num = Random.Range(1, 101);
		if (((PassiveItem)this).Owner.carriedConsumables.Currency >= num)
		{
			args.ModifiedDamage = 0f;
			((GameActor)((PassiveItem)this).Owner).PlayEffectOnActor(vfx, new Vector3(0.5f, 0f), true, true, false);
			AkSoundEngine.PostEvent("Play_OBJ_item_purchase_01", ((Component)this).gameObject);
			if (source.shakesCameraOnDamage)
			{
				GameManager.Instance.MainCameraController.DoScreenShake(source.cameraShakeOnDamage, (Vector2?)((BraveBehaviour)((PassiveItem)this).Owner).specRigidbody.UnitCenter, false);
			}
			((PassiveItem)this).Owner.ForceBlank(25f, 0.5f, false, true, (Vector2?)null, true, -1f);
			if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Gold Reserves"))
			{
				PlayerConsumables carriedConsumables = ((PassiveItem)this).Owner.carriedConsumables;
				carriedConsumables.Currency -= Random.Range(1, Mathf.Min(((PassiveItem)this).Owner.carriedConsumables.Currency, num));
			}
			else
			{
				PlayerConsumables carriedConsumables2 = ((PassiveItem)this).Owner.carriedConsumables;
				carriedConsumables2.Currency -= num;
			}
			((PassiveItem)this).Owner.carriedConsumables.Currency = Math.Max(((PassiveItem)this).Owner.carriedConsumables.Currency, 0);
			if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Zilvered Up"))
			{
				LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(120)).gameObject, ((PassiveItem)this).Owner);
				LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(120)).gameObject, ((PassiveItem)this).Owner);
			}
		}
	}

	public override void Pickup(PlayerController player)
	{
		if (Object.op_Implicit((Object)(object)player) && Object.op_Implicit((Object)(object)((BraveBehaviour)player).healthHaver))
		{
			HealthHaver healthHaver = ((BraveBehaviour)player).healthHaver;
			healthHaver.ModifyDamage = (Action<HealthHaver, ModifyDamageEventArgs>)Delegate.Combine(healthHaver.ModifyDamage, new Action<HealthHaver, ModifyDamageEventArgs>(ModifyIncomingDamage));
			if (!base.m_pickedUpThisRun)
			{
				LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(120)).gameObject, player);
			}
		}
		((PassiveItem)this).Pickup(player);
	}

	public override void DisableEffect(PlayerController player)
	{
		if (Object.op_Implicit((Object)(object)player) && Object.op_Implicit((Object)(object)((BraveBehaviour)player).healthHaver))
		{
			HealthHaver healthHaver = ((BraveBehaviour)player).healthHaver;
			healthHaver.ModifyDamage = (Action<HealthHaver, ModifyDamageEventArgs>)Delegate.Remove(healthHaver.ModifyDamage, new Action<HealthHaver, ModifyDamageEventArgs>(ModifyIncomingDamage));
		}
		((PassiveItem)this).DisableEffect(player);
	}
}
