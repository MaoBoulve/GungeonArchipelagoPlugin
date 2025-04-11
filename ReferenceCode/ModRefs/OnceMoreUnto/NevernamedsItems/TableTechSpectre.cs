using System;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class TableTechSpectre : TableFlipItem
{
	public static int ID;

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<TableTechSpectre>("Table Tech Spectre", "Flip Fatale", "Flipped tables create friendly phantoms.\n\nChapter 16 of the \"Tabla Sutra.\" For life is a great table, and even it too, shall be flipped.", "NevernamedsItems/Resources/NeoItemSprites/tabletechspectre_icon", assetbundle: false);
		val.quality = (ItemQuality)3;
		((TableFlipItem)(val as TableTechSpectre)).TableFlocking = true;
		ID = val.PickupObjectId;
		AlexandriaTags.SetTag(val, "table_tech");
	}

	public override void Pickup(PlayerController player)
	{
		player.OnTableFlipped = (Action<FlippableCover>)Delegate.Combine(player.OnTableFlipped, new Action<FlippableCover>(SpawnGhost));
		((TableFlipItem)this).Pickup(player);
	}

	public override void DisableEffect(PlayerController player)
	{
		if (Object.op_Implicit((Object)(object)player))
		{
			player.OnTableFlipped = (Action<FlippableCover>)Delegate.Remove(player.OnTableFlipped, new Action<FlippableCover>(SpawnGhost));
		}
		((PassiveItem)this).DisableEffect(player);
	}

	private void SpawnGhost(FlippableCover obj)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = ProjectileUtility.InstantiateAndFireInDirection(StandardisedProjectiles.ghost, ((BraveBehaviour)obj).specRigidbody.UnitCenter, (float)Random.Range(0, 360), 0f, (PlayerController)null);
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			Projectile component = val.GetComponent<Projectile>();
			component.Owner = (GameActor)(object)((PassiveItem)this).Owner;
			ProjectileData baseData = component.baseData;
			baseData.range *= 2f;
			PierceProjModifier component2 = ((Component)component).GetComponent<PierceProjModifier>();
			component2.penetration += 2;
			component.Shooter = ((BraveBehaviour)((PassiveItem)this).Owner).specRigidbody;
			((PassiveItem)this).Owner.DoPostProcessProjectile(component);
			component.ScaleByPlayerStats(((PassiveItem)this).Owner);
			((BraveBehaviour)component).specRigidbody.RegisterGhostCollisionException(((BraveBehaviour)obj).specRigidbody);
		}
	}
}
