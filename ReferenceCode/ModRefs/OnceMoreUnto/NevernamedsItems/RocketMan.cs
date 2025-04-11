using System.Collections.Generic;
using UnityEngine;

namespace NevernamedsItems;

public class RocketMan : PassiveItem
{
	public static int RocketManID;

	public static List<int> RocketIDs = new List<int> { 92, 39, 563, 129, 372, 16, 593, 362, 739 };

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<RocketMan>("Rocket Man", "Gonna be a long long time", "Chance to fire random rockets.\n\nThe prized relic of a reclusive group of Detoknights, though in truth it does not belong to them at all...", "rocketman_improved", assetbundle: true);
		val.quality = (ItemQuality)3;
		RocketManID = val.PickupObjectId;
	}

	private void PostProcessProjectile(Projectile sourceProjectile, float effectChanceScalar)
	{
		ShootRocket(effectChanceScalar);
	}

	private void PostProcessBeamTick(BeamController whatTheFuckDoesThisDo, SpeculativeRigidbody beam, float effectChanceScalar)
	{
		ShootRocket(1f);
	}

	private void ShootRocket(float effectChanceScalar)
	{
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		float num = 0.05f;
		if (((PassiveItem)this).Owner.HasPickupID(106))
		{
			num *= 3f;
		}
		num *= effectChanceScalar;
		if (!(Random.value <= num))
		{
			return;
		}
		int num2 = BraveUtility.RandomElement<int>(RocketIDs);
		Projectile val = ((Gun)Databases.Items[num2]).DefaultModule.projectiles[0];
		GameObject val2 = SpawnManager.SpawnProjectile(((Component)val).gameObject, Vector2.op_Implicit(((BraveBehaviour)((PassiveItem)this).Owner).sprite.WorldCenter), Quaternion.Euler(0f, 0f, ((Object)(object)((GameActor)((PassiveItem)this).Owner).CurrentGun == (Object)null) ? 0f : ((GameActor)((PassiveItem)this).Owner).CurrentGun.CurrentAngle), true);
		Projectile component = val2.GetComponent<Projectile>();
		if ((Object)(object)component != (Object)null)
		{
			if (((PassiveItem)this).Owner.HasPickupID(num2) && num2 != 739)
			{
				ProjectileData baseData = component.baseData;
				baseData.damage *= 2f;
			}
			else if (((PassiveItem)this).Owner.HasPickupID(176) && num2 == 739)
			{
				ProjectileData baseData2 = component.baseData;
				baseData2.damage *= 2f;
			}
			component.Owner = (GameActor)(object)((PassiveItem)this).Owner;
			component.Shooter = ((BraveBehaviour)((PassiveItem)this).Owner).specRigidbody;
		}
	}

	public override DebrisObject Drop(PlayerController player)
	{
		DebrisObject result = ((PassiveItem)this).Drop(player);
		player.PostProcessProjectile -= PostProcessProjectile;
		player.PostProcessBeamTick -= PostProcessBeamTick;
		return result;
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		player.PostProcessProjectile += PostProcessProjectile;
		player.PostProcessBeamTick += PostProcessBeamTick;
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			((PassiveItem)this).Owner.PostProcessProjectile -= PostProcessProjectile;
			((PassiveItem)this).Owner.PostProcessBeamTick -= PostProcessBeamTick;
		}
		((PassiveItem)this).OnDestroy();
	}
}
