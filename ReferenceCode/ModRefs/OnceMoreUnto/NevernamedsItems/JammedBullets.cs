using Alexandria.ItemAPI;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class JammedBullets : PassiveItem
{
	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<JammedBullets>("Jammed Bullets", "Screaming", "Increases firepower. They don't stand a chance.\n\nThe ancient metal of these bullets carries a dull otherworldly hue. You never want to let them go.", "jammedbullets_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)5;
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)val, (StatType)5, 1.75f, (ModifyMethod)1);
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)val, (StatType)14, 2.5f, (ModifyMethod)0);
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)2, 1f);
		Doug.AddToLootPool(((PickupObject)val).PickupObjectId);
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.ALLJAMMED_BEATEN_ADVANCEDDRAGUN, requiredFlagValue: true);
	}

	public override void Pickup(PlayerController player)
	{
		player.PostProcessProjectile += OnShoot;
		player.PostProcessBeam += OnBeam;
		((PassiveItem)this).Pickup(player);
	}

	public override void DisableEffect(PlayerController player)
	{
		if (Object.op_Implicit((Object)(object)player))
		{
			player.PostProcessProjectile -= OnShoot;
			player.PostProcessBeam -= OnBeam;
		}
		((PassiveItem)this).DisableEffect(player);
	}

	public void OnBeam(BeamController beam)
	{
		if (Object.op_Implicit((Object)(object)beam) && Object.op_Implicit((Object)(object)((BraveBehaviour)beam).projectile))
		{
			OnShoot(((BraveBehaviour)beam).projectile, 1f);
		}
	}

	public void OnShoot(Projectile bullet, float f)
	{
		bullet.ignoreDamageCaps = true;
		if ((Object)(object)((BraveBehaviour)bullet).sprite != (Object)null)
		{
			((BraveBehaviour)bullet).sprite.usesOverrideMaterial = true;
			((BraveBehaviour)((BraveBehaviour)bullet).sprite).renderer.material.SetFloat("_BlackBullet", 1f);
			((BraveBehaviour)((BraveBehaviour)bullet).sprite).renderer.material.SetFloat("_EmissivePower", -40f);
		}
	}
}
