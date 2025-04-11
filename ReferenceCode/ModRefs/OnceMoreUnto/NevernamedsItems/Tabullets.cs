using System;
using System.Collections.Generic;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class Tabullets : PassiveItem
{
	private List<SpeculativeRigidbody> tablesHitAlready = new List<SpeculativeRigidbody>();

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<Tabullets>("Tabullets", "Surface Level", "Your bullets no longer damage tables, and are allowed to pass right through. Passing through a table increases a bullet's damage.\n\nAn initiation gift among the Knights of the Octagonal Table.", "tabullets_icon", assetbundle: true);
		val.quality = (ItemQuality)2;
		AlexandriaTags.SetTag(val, "bullet_modifier");
		Doug.AddToLootPool(val.PickupObjectId);
	}

	private void PostProcessProjectile(Projectile sourceProjectile, float effectChanceScalar)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		try
		{
			((BraveBehaviour)sourceProjectile).specRigidbody.OnPreRigidbodyCollision = (OnPreRigidbodyCollisionDelegate)Delegate.Combine((Delegate)(object)((BraveBehaviour)sourceProjectile).specRigidbody.OnPreRigidbodyCollision, (Delegate)new OnPreRigidbodyCollisionDelegate(HandlePreCollision));
		}
		catch (Exception ex)
		{
			ETGModConsole.Log((object)ex.Message, false);
		}
	}

	private void HandlePreCollision(SpeculativeRigidbody myRigidbody, PixelCollider myPixelCollider, SpeculativeRigidbody otherRigidbody, PixelCollider otherPixelCollider)
	{
		if (((Object)((Component)otherRigidbody).gameObject).name != null && (((Object)((Component)otherRigidbody).gameObject).name == "Table_Vertical" || ((Object)((Component)otherRigidbody).gameObject).name == "Table_Horizontal"))
		{
			if (!tablesHitAlready.Contains(otherRigidbody))
			{
				tablesHitAlready.Add(otherRigidbody);
				ProjectileData baseData = ((BraveBehaviour)myRigidbody).projectile.baseData;
				baseData.damage *= 1.2f;
				((BraveBehaviour)myRigidbody).projectile.RuntimeUpdateScale(1.2f);
			}
			PhysicsEngine.SkipCollision = true;
		}
	}

	public override DebrisObject Drop(PlayerController player)
	{
		DebrisObject result = ((PassiveItem)this).Drop(player);
		player.PostProcessProjectile -= PostProcessProjectile;
		return result;
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			((PassiveItem)this).Owner.PostProcessProjectile -= PostProcessProjectile;
		}
		((PassiveItem)this).OnDestroy();
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		player.PostProcessProjectile += PostProcessProjectile;
	}
}
